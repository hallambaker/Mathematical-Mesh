using Goedel.Cryptography.Algorithms;
using Goedel.Discovery;

using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace Goedel.Cryptography.Oauth;

/// <summary>
/// An OAUTH client class.
/// </summary>
public class OauthClient {

    /// <summary>The DNS client to use.</summary>
    public DnsClient DnsClient { get; init; } = DnsClient.Default;


    ///<summary>Client description.</summary> 
    ClientMetadata ClientMetadata { get; }

    ///<summary>ClientMetadata as byte array.</summary> 
    public byte[] ClientMetadataBytes { get; }

    ///<summary>The session manager storing state between requests.</summary> 
    public SessionManager SessionManager { get; }

    ///<summary>Secret key used to construct challenge and verifier values.</summary> 
    byte[] SecretKey { get; }

    ///<summary>Encrypted state token manager.</summary> 
    public EncryptedTokenManager EncryptedTokenManager { get; } = new();

    JWK Signature { get; set; }
    JWK Encryption { get; set; }

    /// <summary>
    /// Constructor, returns an instance with client URI <paramref name="clientId"/>, redirect
    /// URI <paramref name="redirectUri"/> and key directory <paramref name="directory"/>.
    /// </summary>
    /// <param name="clientId">The client identifier.</param>
    /// <param name="redirectUri">The redirect URL</param>
    /// <param name="directory">The directory in which private keys for encryption 
    /// and signature are stored.</param>
    public OauthClient(
                string clientId,
                string redirectUri,
                string directory) {
        
        SessionManager = new() {
            DnsClient = DnsClient
            };
        SecretKey = Platform.GetRandomBytes(32);
        var keys = GetKeys(directory);

        ScopeTypes scope = ScopeTypes.Atproto;
        bool confidential = false;

        ClientMetadata = ClientMetadata.FactoryAtproto(clientId, [redirectUri], 
                    scope, confidential, keys);
        ClientMetadataBytes = ClientMetadata.ToString().ToUTF8();
        }


    JWKS GetKeys(string directory) {
        Signature = GetOrCreateKey(directory, "signature", KeyUses.Sign);
        Encryption = GetOrCreateKey(directory, "encryption", KeyUses.Encrypt);

        return new JWKS {
            Keys = [Signature, Encryption]
            };

        }



    static JWK GetOrCreateKey(string directory, string filename, KeyUses keyUses) {
        var keyfile = Path.Combine(directory, filename + ".jwk");

        try {
            var result = keyfile.ReadFileJson<JWK>();
            return result;
            }
        catch {
            var key = GenKey(keyUses);
            var result = JWK.Factory(key, true);

            Directory.CreateDirectory(directory);
            result.ToFile(keyfile);

            return result;
            }


        }


    #region // static methods

    /// <summary>
    /// Generate a key for use with OAUTH client.
    /// </summary>
    /// <param name="keyUses">Key uses, either <see cref="KeyUses.Sign"/> or 
    /// <see cref="KeyUses.Encrypt"/>.</param>
    /// <returns></returns>
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

    /// <summary>
    /// Attempt resolution of the handle <paramref name="handle"/> and return the result.
    /// </summary>
    /// <param name="handle">The handle to resolve.</param>
    /// <returns>Object containing the result of the resolution.</returns>
    public async Task<OauthHandleResolution> TryResolveHandle(string handle) {
        handle = TrimHandle(handle);
        handle.AssertNotNull(NYI.Throw);
        return await SessionManager.TryResolveHandle(handle);
        }


    /// <summary>
    /// Make a Pushed Authorization request for handle <paramref name="handle"/> with context
    /// <paramref name="state"/>.
    /// </summary>
    /// <param name="handle">The ATprotocol handle.</param>
    /// <param name="state">State to be preserved between pre request
    /// and completion.</param>
    /// <returns>A client result.</returns>
    public async Task<OauthClientResult> PreRequest(
            string handle,
            string state) {

        Screen.WriteLine("## Resolve Handle");
        var oauth = await TryResolveHandle(handle);

        Screen.WriteLine("## Begin Pre-Request");


        // construct the pre-request
        var par = ConstructPar(oauth, state);
        Screen.WriteLine("Pre Authorization Request");
        //Screen.WriteLine(par.ToString());


        var parBytes = par.GetAsKeyValue();

        // post to the auth service
        var result = await UriClient.PostBinaryAsync(
                    oauth.AuthorizationServerMetadata.PushedAuthorizationRequestEndpoint,
                    parBytes, "application/x-www-form-urlencoded");

        // read back the response
        using var jsonReader = new JsonReader(result);
        var response = JsonObject.StreamParse<PushedAuthorizationResponse>(jsonReader, false);

        Screen.WriteLine("Pre Authorization Response");
        //Screen.WriteLine(response.ToString());

        var redirectFields = new AuthorizationRequest2() {
            ClientId = ClientMetadata.ClientId,
            RequestUri = response.RequestUri
            };


        var redirect = redirectFields.GetAsUrlQuery(oauth.AuthorizationServerMetadata.AuthorizationEndpoint);
        Screen.WriteLine("Redirect Uri");
        //Screen.WriteLine(redirect);
        Screen.Flush();

        return new OauthClientResultPreRequest() {
            RedirectUri = redirect};
        }

    /// <summary>
    /// Construct a Pushed Authorization Request as per RFC 9126
    /// </summary>
    /// <param name="handle"></param>
    /// <param name="state"></param>
    /// <returns>The authorization request instance.</returns>
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
            LoginHint = handle.Handle
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




    /// <summary>
    /// Pares a response URI to recover the data from the authorization server.
    /// </summary>
    /// <param name="responseUri">The response URI.</param>
    /// <returns>The parsed result and recovered state.</returns>
    public OauthClientResult ParseResponse(
                Uri responseUri) {

        var fields = HttpUtility.ParseQueryString(responseUri.Query);
        var iss = fields["iss"];
        var state = fields["state"];
        var code = fields["code"];


        var response = WebExtensions.FromUrlQuery<AuthenticationResponse>(responseUri);

        Screen.WriteLine("# Redirect URI");
        //Screen.WriteLine($"{responseUri.Query}");
        Screen.WriteLine($"iss= {iss}");
        Screen.WriteLine($"state= {state}");
        Screen.WriteLine($"code= {code}");
        Screen.Flush();

        // ok unpack the state vector

        var encodedState = new EncodedState(EncryptedTokenManager, state);


        return new OauthClientResultAuthRequest() {
            RedirectUri = encodedState.RedirectUri,
            Handle = encodedState.Handle,
            DID = encodedState.DID,
            Nonce = encodedState.Nonce,
            Code = code
            };
        }






    /// <summary>
    /// Trim an @nything handle to remove the leading @ if present and any trailing whitespace.
    /// </summary>
    /// <param name="handle">The handle to trim.</param>
    /// <returns>The trimmed handle</returns>
    public static string TrimHandle(string handle) {
        if (handle is null || handle.Length == 0) {
            return null;
            }
        return ((handle[0] == '@') ? handle [1..] : handle).Trim();
        }


    #endregion

    }



/// <summary>
/// OAUTH Client operation result
/// </summary>
public abstract record OauthClientResult {

    }


/// <summary>
/// OAUTH Client operation fail result
/// </summary>
public record OauthClientResultFail : OauthClientResult {

    }

/// <summary>
/// OAUTH Client operation successful pre request.
/// </summary>
public record OauthClientResultPreRequest : OauthClientResult {

    ///<summary>The URI to which the user client is to be redirected.</summary> 
    public string RedirectUri { get; init;  } = null;

    }

/// <summary>
/// OAUTH Client operation successful auth request.
/// </summary>
public record OauthClientResultAuthRequest : OauthClientResult {

    ///<summary>The URI to redirect the client to on completion.</summary> 
    public string? RedirectUri { get; init; } = null;

    ///<summary>The user's handle</summary>     
    public string? Handle { get; init; } = null;

    ///<summary>The user's DID</summary> 
    public string? DID { get; init; } = null;

    ///<summary>The nonce value used to construct the PKCE verifier and 
    ///challenge.</summary> 
    public byte[]? Nonce { get; init; } = null;

    ///<summary>Value of the code field.</summary> 
    public string? Code { get; init; } = null;

    }
