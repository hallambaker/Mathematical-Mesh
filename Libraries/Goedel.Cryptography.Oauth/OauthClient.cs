namespace Goedel.Cryptography.Oauth;

public class OauthClient {

    ClientMetadata ClientMetadata { get; }
    public byte[] ClientMetadataBytes { get; }

    public KeyPair OauthClientSignature { get; }
    public KeyPair OauthClientEncryption { get;  }

    public JWKS JWKS { get;}



    public OauthClient(
                string clientId,
                string redirectUri,
                JWKS keys) {

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

    public async Task<OauthContext> BeginOAuthContext(
            string handle,
            string state) {

        return new OauthContextFail();
        }


    public OauthContext ParseResponse(
                string responseUri) {
        return new OauthContextFail();
        }



    #endregion

    }

public abstract record OauthContext {

    }

public record OauthContextFail : OauthContext {

    }

public record OauthContextSuccess : OauthContext {

    public string RedirectUri { get; } = null;

    }

public record OauthAuthSuccess : OauthContext {
    public string ContextUri { get; } = null;
    }
