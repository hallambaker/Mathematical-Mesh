namespace Goedel.Cryptography.Oauth;

public partial class ClientMetadata {

    public static ClientMetadata FactoryAtproto(
                string clientid,
                List<string?> redirect,
                ScopeTypes scope = ScopeTypes.Atproto,
                bool confidential = false,
                JWKS keys = null) => new ClientMetadata() {
                    ClientId = clientid,
                    ApplicationType = OauthConstants.ApplicationTypeWebTitle,
                    GrantTypes = [
                        OauthConstants.GrantTypesAuthorizationCodeTitle,
                                OauthConstants.GrantTypesRefreshTokenTitle],
                    Scope = GetScope(scope),
                    ResponseTypes = [OauthConstants.ResponseTypeCodeTitle],
                    RedirectUris = redirect,
                    TokenEndpointAuthMethod = confidential ? OauthConstants.AuthenticationMethodJWTTitle : "none",
                    TokenEndpointAuthSigningAlg = confidential ? OauthConstants.EndpointSignatureES256Title : null,
                    DpopBoundAccessTokens = true,
                    Jwks = keys
                    };
    public static string GetScope(ScopeTypes scopes) =>
        scopes switch {
            ScopeTypes.Atproto => OauthConstants.ScopeTypesAtprotoTitle,
            ScopeTypes.Generic => OauthConstants.ScopeTypesAtprotoTitle + " " +
                OauthConstants.ScopeTypesGenericTitle,
            ScopeTypes.Chat => OauthConstants.ScopeTypesAtprotoTitle + " " +
                OauthConstants.ScopeTypesGenericTitle + " " +
                OauthConstants.ScopeTypesChatTitle,
            _ => OauthConstants.ScopeTypesAtprotoTitle


            };

    }

