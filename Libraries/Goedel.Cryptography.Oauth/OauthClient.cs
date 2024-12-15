using Goedel.Cryptography.Algorithms;

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

        var oauth = await SessionManager.TryResolveHandle(handle);

        // construct the pre-request
        var par = ConstructPAR(oauth, state);
        var parBytes = par.GetBytes();

        // post to the auth service
        

        // read back the response


        return new OauthClientResultFail();
        }


    public AuthorizationRequest ConstructPAR(
                        OauthHandleResolution handle,
                        string state) {

        var encodedState = new EncodedState(SecretKey, handle, state);
        var codeChallenge = GetCodeChallenge(encodedState);

        var result = new AuthorizationRequest() {
            ClientId = ClientMetadata.ClientId,
            CodeChallenge = codeChallenge,
            CodeChallengeMethod = "S256",
            RedirectUri = ClientMetadata.RedirectUris[0],
            Scope = ClientMetadata.Scope,
            State = encodedState.Bytes.ToStringBase64url()
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



    public record EncodedState {
        public byte[] Nonce;
        public string Handle;
        public string DID;
        public string RedirectUri;
        public byte[] Bytes;

        public EncodedState(
                byte[] key,
                OauthHandleResolution handle,
                string redirectUri
                ) {
            Nonce = Platform.GetRandomBytes(16);
            Handle = handle.Handle;
            DID = handle.DidDocument.Id;
            RedirectUri = redirectUri;


            using var memory = new MemoryStream();
            using var writer = new JsonBWriter(memory);

            writer.WriteBinary(Nonce);
            writer.WriteString(Handle);
            writer.WriteString(DID);
            writer.WriteString(RedirectUri);

            Bytes = memory.ToArray();

            }

        public EncodedState(
                byte[] key,
                string encodedDataString
                ) {
            var encodedData = encodedDataString.FromBase64();

            using var memory = new MemoryStream(encodedData);
            using var reader = new JsonBcdReader(encodedData);

            Nonce = reader.ReadBinary();
            Handle = reader.ReadString();
            DID = reader.ReadString();
            RedirectUri = reader.ReadString();
            }

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

    public string RedirectUri { get; } = null;

    }

public record OauthClientResultAuthRequest : OauthClientResult {
    public string ContextUri { get; } = null;
    }
