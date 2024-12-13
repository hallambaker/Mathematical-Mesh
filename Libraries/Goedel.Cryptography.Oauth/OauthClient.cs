namespace Goedel.Cryptography.Oauth;

public class OauthClient {

    ClientMetadata ClientMetadata { get; }
    public byte[] ClientMetadataBytes { get; }

    public KeyPair OauthClientSignature { get; }
    public KeyPair OauthClientEncryption { get;  }

    public JWKS JWKS { get;}
    SessionManager SessionManager { get; }


    public OauthClient(
                string clientId,
                string redirectUri,
                JWKS keys) {
        
        SessionManager = new();

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
        handle = ResolveHandle(handle);
        handle.AssertNotNull(NYI.Throw);

        // Resolve the DID to a DID document
        var didDocument = SessionManager.HandleToDid(handle);
        var authServerMetadata = SessionManager.GetAuthorization(didDocument);
        // now have to get the server 


        return new OauthClientResultFail();
        }


    public OauthClientResult ParseResponse(
                string responseUri) {
        return new OauthClientResultFail();
        }

    public static string ResolveHandle(string handle) {
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
