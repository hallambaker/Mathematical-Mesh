namespace Goedel.Cryptography.Oauth;

public partial class ClientMetadata {

    public ApplicationType ApplicationType {
        get => applicationType.ToApplicationType();
        set => applicationType = value.ToLabel();
        }

    public static ClientMetadata FactoryAtproto(
            string domain,
            ScopeTypes scope = ScopeTypes.Atproto,
            bool confidential = false) => FactoryAtproto (
                $"https://{domain}/", [$"https://{domain}/"], scope, confidential);


    public static ClientMetadata FactoryAtproto(
                string clientid,
                List<string?> redirect,
                ScopeTypes scope = ScopeTypes.Atproto,
                bool confidential = false) => new ClientMetadata() {
                    ClientId = clientid,
                    ApplicationType = ApplicationType.Web,
                    GrantTypes = [
                        OauthConstants.GrantTypesAuthorizationCodeTag,
                                OauthConstants.GrantTypesRefreshTokenTag],
                    Scope = GetScope(scope),
                    ResponseTypes = [OauthConstants.ResponseTypeCodeTag],
                    RedirectUris = redirect,
                    TokenEndpointAuthMethod = confidential ? OauthConstants.AuthenticationMethodJWTTag : null,
                    TokenEndpointAuthSigningAlg = OauthConstants.EndpointSignatureES256Tag,
                    DpopBoundAccessTokens = true,
                    JWKS = null
                    };
    public static string GetScope(ScopeTypes scopes) =>
        scopes switch {
            ScopeTypes.Atproto => OauthConstants.ScopeTypesAtprotoTag,
            ScopeTypes.Generic => OauthConstants.ScopeTypesAtprotoTag + " " +
                OauthConstants.ScopeTypesGenericTag,
            ScopeTypes.Chat => OauthConstants.ScopeTypesAtprotoTag + " " +
                OauthConstants.ScopeTypesGenericTag + " " +
                OauthConstants.ScopeTypesChatTag,
            _ => OauthConstants.ScopeTypesAtprotoTag


            };

    }


//public record ClientMetadata : ISerializable {

//    public SerialField[] Fields => fields;
//    static readonly SerialField[] fields = [
//        new("client_id", FieldType.String, 
//            (data, s) => ((ClientMetadata)data).ClientId = s as string,
//            (data) => (data as ClientMetadata)?.ClientId),
//        new("application_type", FieldType.String, (data, s) => 
//        ((ClientMetadata)data).applicationType = s as string,
//            (data) => (data as ClientMetadata)?.applicationType),
//        new("grant_types", FieldType.ArrayString, 
//            (data, s) => ((ClientMetadata)data).GrantTypes = s as List<string>,
//            (data) => (data as ClientMetadata)?.GrantTypes),
//        new("scope", FieldType.String, 
//            (data, s) => ((ClientMetadata)data).Scope = s as string,
//            (data) => (data as ClientMetadata)?.Scope),
//        new("response_types", FieldType.ArrayString, 
//            (data, s) => ((ClientMetadata)data).ResponseTypes = s as List<string>,
//            (data) => (data as ClientMetadata)?.ResponseTypes),
//        new("redirect_uris", FieldType.ArrayString, 
//            (data, s) => ((ClientMetadata)data).RedirectUris = s as List<string>,
//            (data) => (data as ClientMetadata)?.RedirectUris),
//        new("dpop_bound_access_tokens", FieldType.Boolean, 
//            (data, s) => ((ClientMetadata)data).DpopBoundAccessTokens = s as bool?,
//            (data) => (data as ClientMetadata)?.DpopBoundAccessTokens),
//        new("token_endpoint_auth_method", FieldType.String, 
//            (data, s) => ((ClientMetadata)data).TokenEndpointAuthMethod = s as string,
//            (data) => (data as ClientMetadata)?.TokenEndpointAuthMethod),
//        new("token_endpoint_auth_signing_alg ", FieldType.ArrayString, 
//            (data, s) => ((ClientMetadata)data).Jwks = s as List<string>,
//            (data) => (data as ClientMetadata)?.Jwks),
//        new("jwks", FieldType.String, 
//            (data, s) => ((ClientMetadata)data).ClientName = s as string,
//            (data) => (data as ClientMetadata)?.ClientName),
//        new("client_name", FieldType.String, 
//            (data, s) => ((ClientMetadata)data).ClientUri = s as string,
//            (data) => (data as ClientMetadata)?.ClientUri),
//        new("client_uri", FieldType.String, 
//            (data, s) => ((ClientMetadata)data).ClientUri = s as string,
//            (data) => (data as ClientMetadata)?.ClientUri),
//        new("logo_uri", FieldType.String, 
//            (data, s) => ((ClientMetadata)data).LogoUri = s as string,
//            (data) => (data as ClientMetadata)?.LogoUri),
//        new("tos_uri", FieldType.String, 
//            (data, s) => ((ClientMetadata)data).TosUri = s as string,
//            (data) => (data as ClientMetadata)?.TosUri),
//        new("policy_uri ", FieldType.String, 
//            (data, s) => ((ClientMetadata)data).PolicyUri = s as string,
//            (data) => (data as ClientMetadata)?.PolicyUri)
//        ];


//    public string? ClientId { get; set; }
//    string? applicationType { get; set; }

//    public ApplicationType ApplicationType {
//        get => applicationType.ToApplicationType();
//        set => applicationType = value.ToLabel();
//        }
//    public List<string>? GrantTypes { get; set; }
//    public string? Scope { get; set; }

//    public List<string>? ResponseTypes { get; set; }
//    public List<string>? RedirectUris { get; set; }
//    public bool? DpopBoundAccessTokens { get; set; }
//    public string? TokenEndpointAuthMethod { get; set; }
//    public string? TokenEndpointAuthSigningAlg { get; set; }
//    public List<string>? Jwks { get; set; }
//    public string? ClientName { get; set; }
//    public string? ClientUri { get; set; }
//    public string? LogoUri { get; set; }
//    public string? TosUri { get; set; }
//    public string? PolicyUri { get; set; }

//    }