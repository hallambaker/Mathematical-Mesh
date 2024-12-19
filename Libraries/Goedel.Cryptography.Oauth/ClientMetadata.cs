namespace Goedel.Cryptography.Oauth;

public partial class ClientMetadata {

    /// <summary>
    /// Return a ClientMetadata instance for an ATprotocol client with the
    /// specified parameters.
    /// </summary>
    /// <param name="clientid">The client ID, a HTTPS URI</param>
    /// <param name="redirect">List of HTTPS redirect URIs</param>
    /// <param name="scope">The scope(s) requested</param>
    /// <param name="confidential">If true, return a confidential client.</param>
    /// <param name="keys">The client keys</param>
    /// <returns>The constructed metadata.</returns>
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

    /// <summary>
    /// Convert the scope <paramref name="scopes"/> to a string.
    /// </summary>
    /// <param name="scopes">The scope specifier</param>
    /// <returns>String describing the scope.</returns>
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

