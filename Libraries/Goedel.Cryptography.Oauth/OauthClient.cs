using Goedel.Cryptography.Algorithms;
using Goedel.Discovery;

using System.Security.Cryptography;

namespace Goedel.Cryptography.Oauth;

public class OauthClient {



    ClientMetadata ClientMetadata { get; }
    public byte[] ClientMetadataBytes { get; }

    public KeyPair OauthClientSignature { get; }
    public KeyPair OauthClientEncryption { get;  }

    public JWKS JWKS { get;}
    SessionManager SessionManager { get; }

    byte[] SecretKey { get; }

    EncryptedTokenManager EncryptedTokenManager { get; } = new();
    CryptoKeySymmetric CryptoKeySymmetric { get; }
    HMAC HMAC { get; }
    public OauthClient(
                string clientId,
                string redirectUri,
                JWKS keys) {
        
        SessionManager = new();
        SecretKey = Platform.GetRandomBytes(32);
        //HMAC


        CryptoKeySymmetric = new(SecretKey);

        JWKS = keys;
        ScopeTypes scope = ScopeTypes.Atproto;
        bool confidential = false;

        ClientMetadata = ClientMetadata.FactoryAtproto(clientId, [redirectUri], 
                    scope, confidential, keys);
        ClientMetadataBytes = ClientMetadata.ToString().ToUTF8();
        }

    public OauthClient(
                ClientMetadata clientMetadata) {
        ClientMetadata = clientMetadata;
        ClientMetadataBytes = ClientMetadata.ToString().ToUTF8();
        }


    #region // static methods

    public static JWKS MakeKeys() {

        var OauthClientSignature = OauthClient.GenKey(
                    KeyUses.Sign);
        var OauthClientEncryption = OauthClient.GenKey(KeyUses.Encrypt);

        var JWKS = new JWKS {
            Keys = [JWK.Factory(OauthClientSignature), JWK.Factory(OauthClientEncryption)]
            };

        return JWKS;
        }

    public static KeyPair GenKey(KeyUses keyUses = KeyUses.Sign) {

        var key = KeyPair.Factory(
                    CryptoAlgorithmId.P256,
                    KeySecurity.ExportableStored,
                    keyUses: keyUses);


        var jwk = JWK.Factory(key);

        var jwks = new JWKS {
            Keys = [jwk]
            };

        //var asString = jwk.Serialize();
        //Console.WriteLine(asString);
        return key;
        }

    #endregion


    #region // Methods

    public async Task<OauthClientResult> PreRequest(
            string handle,
            string state) {
        handle = TrimHandle(handle);
        handle.AssertNotNull(NYI.Throw);

        // https://atproto.com/specs/oauth#summary-of-authorization-flow

        var oauth = await SessionManager.TryResolveHandle(handle);

        // construct the pre-request
        var par = ConstructPar(oauth, state);
        var parBytes = par.GetAsKeyValue();

        // post to the auth service
        var result = await UriClient.PostBinaryAsync(
                    oauth.AuthorizationServerMetadata.PushedAuthorizationRequestEndpoint,
                    parBytes, "application/x-www-form-urlencoded");




        // read back the response
        using var jsonReader = new JsonReader(result);
        var response = PushedAuthorizationResponse.FromJson(jsonReader, false);


        var redirectFields = new AuthorizationRequest2() {
            ClientId = ClientMetadata.ClientId,
            RequestUri = response.RequestUri
            };

        var redirect = redirectFields.GetAsUrlQuery(oauth.AuthorizationServerMetadata.AuthorizationEndpoint);


        return new OauthClientResultPreRequest() {
            RedirectUri = redirect};
        }

    /// <summary>
    /// Construct a Pushed Authorization Request as per RFC 9126
    /// </summary>
    /// <param name="handle"></param>
    /// <param name="state"></param>
    /// <returns></returns>
    public AuthorizationRequest ConstructPar(
                        OauthHandleResolution handle,
                        string state) {

        var encodedState = new EncodedState(EncryptedTokenManager, handle, state);

        // Calculate the Proof Key for Code Exchange (PKCE) as per RFC 7636
        var codeChallenge = GetCodeChallenge(encodedState);

        var result = new AuthorizationRequest() {
            ClientId = ClientMetadata.ClientId,
            ResponseType = "code",
            CodeChallenge = codeChallenge,
            CodeChallengeMethod = "S256",
            State = encodedState.Bytes.ToStringBase64url(),
            RedirectUri = ClientMetadata.RedirectUris[0],
            Scope = ClientMetadata.Scope,

            //ClientAssertionType = OauthConstants.AssertionTypesBearerTitle,
            ClientAssertion =null,
            LoginHint = null
            };

        return result;
        }


    /// <summary>
    /// Return a code verifier using the S256 mechanism bound to the state
    /// <paramref name="state"/>.
    /// <para>
    /// code_challenge = BASE64URL-ENCODE(SHA256(ASCII(code_verifier)))
    /// </para>
    /// </summary>
    /// <param name="state">The state variable including nonce.</param>
    /// <returns>Base64URL encoded verifier string.</returns>
    string GetCodeVerifier(EncodedState state) {
        var mac = new byte[32];
        HMACSHA256.TryHashData(SecretKey, state.Bytes, mac, out _).AssertTrue(NYI.Throw);

        return mac.ToStringBase64url();
        }

    /// <summary>
    /// Return a code verifier using the S256 mechanism bound to the state
    /// <paramref name="state"/>.
    /// </summary>
    /// <param name="state">The state variable including nonce.</param>
    /// <returns>Base64URL encoded challenge string.</returns>
    string GetCodeChallenge(EncodedState state) {
        var verifier = GetCodeVerifier(state);
        var challenge = SHA256.HashData(verifier.ToBytes());

        return challenge.ToStringBase64url();
        }





    public OauthClientResult ParseResponse(
                string responseUri) {
        return new OauthClientResultFail();
        }

    public static string TrimHandle(string handle) {
        if (handle is null || handle.Length == 0) {
            return null;
            }
        return (handle[0] == '@') ? handle [1..] : handle;
        }


    #endregion

    }




public abstract record OauthClientResult {

    }

public record OauthClientResultFail : OauthClientResult {

    }

public record OauthClientResultPreRequest : OauthClientResult {

    public string RedirectUri { get; init;  } = null;

    }

public record OauthClientResultAuthRequest : OauthClientResult {
    public string ContextUri { get; init; } = null;
    }
