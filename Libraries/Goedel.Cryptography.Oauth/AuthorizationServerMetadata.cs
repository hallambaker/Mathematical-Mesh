namespace Goedel.Cryptography.Oauth;

public record AuthorizationServerMetadata : ISerializable {
    public FormFields[] Fields => fields;
    static readonly FormFields[] fields = [
        new("issuer", FormEntryType.String,
            (data, s) => ((AuthorizationServerMetadata)data).Issuer = s as string,
            (data) => (data as AuthorizationServerMetadata)?.Issuer),
        new("scopes_supported", FormEntryType.ArrayString,
            (data, s) => ((AuthorizationServerMetadata)data).ScopesSupported = s as List<string>,
            (data) => (data as AuthorizationServerMetadata)?.ScopesSupported),
        new("subject_types_supported", FormEntryType.ArrayString,
            (data, s) => ((AuthorizationServerMetadata)data).SubjectTypesSupported = s as List<string>,
            (data) => (data as AuthorizationServerMetadata)?.SubjectTypesSupported),
        new("response_types_supported", FormEntryType.ArrayString,
            (data, s) => ((AuthorizationServerMetadata)data).ResponseTypesSupported = s as List<string>,
            (data) => (data as AuthorizationServerMetadata)?.ResponseTypesSupported),
        new("response_modes_supported", FormEntryType.ArrayString,
            (data, s) => ((AuthorizationServerMetadata)data).ResponseModesSupported = s as List<string>,
            (data) => (data as AuthorizationServerMetadata)?.ResponseModesSupported),
        new("grant_types_supported", FormEntryType.ArrayString,
            (data, s) => ((AuthorizationServerMetadata)data).GrantTypesSupported = s as List<string>,
            (data) => (data as AuthorizationServerMetadata)?.GrantTypesSupported),
        new("code_challenge_methods_supported", FormEntryType.ArrayString,
            (data, s) => ((AuthorizationServerMetadata)data).CodeChallengeMethodsSupported = s as List<string>,
            (data) => (data as AuthorizationServerMetadata)?.CodeChallengeMethodsSupported),
        new("ui_locales_supported", FormEntryType.ArrayString,
            (data, s) => ((AuthorizationServerMetadata)data).UiLocalesSupported = s as List<string>,
            (data) => (data as AuthorizationServerMetadata)?.UiLocalesSupported),
        new("display_values_supported", FormEntryType.ArrayString,
            (data, s) => ((AuthorizationServerMetadata)data).DisplayValuesSupported = s as List<string>,
            (data) => (data as AuthorizationServerMetadata)?.DisplayValuesSupported),
        new("authorization_response_iss_parameter_supported", FormEntryType.Boolean,
            (data, s) => ((AuthorizationServerMetadata)data).AuthorizationResponseIssParameterSupported = s as bool?,
            (data) => (data as AuthorizationServerMetadata)?.AuthorizationResponseIssParameterSupported),
        new("request_object_signing_alg_values_supported", FormEntryType.ArrayString,
            (data, s) => ((AuthorizationServerMetadata)data).RequestObjectSigningAlgValuesSupported = s as List<string>,
            (data) => (data as AuthorizationServerMetadata)?.RequestObjectSigningAlgValuesSupported),
        new("request_object_encryption_alg_values_supported", FormEntryType.ArrayString,
            (data, s) => ((AuthorizationServerMetadata)data).RequestObjectEncryptionAlgValuesSupported = s as List<string>,
            (data) => (data as AuthorizationServerMetadata)?.RequestObjectEncryptionAlgValuesSupported),
        new("request_object_encryption_enc_values_supported", FormEntryType.ArrayString,
            (data, s) => ((AuthorizationServerMetadata)data).RequestObjectEncryptionEncValuesSupported = s as List<string>,
            (data) => (data as AuthorizationServerMetadata)?.RequestObjectEncryptionEncValuesSupported),  
        new("request_parameter_supported", FormEntryType.Boolean,
            (data, s) => ((AuthorizationServerMetadata)data).RequestParameterSupported = s as bool?,
            (data) => (data as AuthorizationServerMetadata)?.RequestParameterSupported),
        new("request_uri_parameter_supported", FormEntryType.Boolean, 
            (data, s) => ((AuthorizationServerMetadata)data).RequestUriParameterSupported = s as bool?,
            (data) => (data as AuthorizationServerMetadata)?.RequestUriParameterSupported),
        new("require_request_uri_registration", FormEntryType.Boolean,
            (data, s) => ((AuthorizationServerMetadata)data).RequireRequestUriRegistration = s as bool?,
            (data) => (data as AuthorizationServerMetadata)?.RequireRequestUriRegistration),
        new("jwks_uri", FormEntryType.String,
            (data, s) => ((AuthorizationServerMetadata)data).JwksUri = s as string,
            (data) => (data as AuthorizationServerMetadata)?.JwksUri),
        new("authorization_endpoint", FormEntryType.String,
            (data, s) => ((AuthorizationServerMetadata)data).AuthorizationEndpoint = s as string,
            (data) => (data as AuthorizationServerMetadata)?.AuthorizationEndpoint),
        new("token_endpoint", FormEntryType.String,
            (data, s) => ((AuthorizationServerMetadata)data).TokenEndpoint = s as string,
            (data) => (data as AuthorizationServerMetadata)?.TokenEndpoint),
        new("token_endpoint_auth_signing_alg_values_supported", FormEntryType.ArrayString,
            (data, s) => ((AuthorizationServerMetadata)data).TokenEndpointAuthSigningAlgValuesSupported = s as List<string>,
            (data) => (data as AuthorizationServerMetadata)?.TokenEndpointAuthSigningAlgValuesSupported),
        new("revocation_endpoint", FormEntryType.String,
            (data, s) => ((AuthorizationServerMetadata)data).RevocationEndpoint = s as string,
            (data) => (data as AuthorizationServerMetadata)?.RevocationEndpoint),
        new("introspection_endpoint", FormEntryType.String,
            (data, s) => ((AuthorizationServerMetadata)data).IntrospectionEndpoint = s as string,
            (data) => (data as AuthorizationServerMetadata)?.IntrospectionEndpoint),
        new("pushed_authorization_request_endpoint", FormEntryType.String,
            (data, s) => ((AuthorizationServerMetadata)data).PushedAuthorizationRequestEndpoint = s as string,
            (data) => (data as AuthorizationServerMetadata)?.PushedAuthorizationRequestEndpoint),
        new("require_pushed_authorization_requests", FormEntryType.Boolean,
            (data, s) => ((AuthorizationServerMetadata)data).RequirePushedAuthorizationRequests = s as bool?,
            (data) => (data as AuthorizationServerMetadata)?.RequirePushedAuthorizationRequests),
        new("dpop_signing_alg_values_supported", FormEntryType.ArrayString, (data, s) =>
            ((AuthorizationServerMetadata)data).DpopSigningAlgValuesSupported = s as List<string>,
            (data) => (data as AuthorizationServerMetadata)?.DpopSigningAlgValuesSupported), 
        new("client_id_metadata_document_supported", FormEntryType.String, (data, s) =>
            ((AuthorizationServerMetadata)data).ClientIdMetadataDocumentSupported = s as bool?,
            (data) => (data as AuthorizationServerMetadata)?.ClientIdMetadataDocumentSupported)
        ];

    public string? Issuer { get; set; }
    public List<string>? ScopesSupported { get; set; }
    public List<string>? SubjectTypesSupported { get; set; }
    public List<string>? ResponseTypesSupported { get; set; }
    public List<string>? ResponseModesSupported { get; set; }
    public List<string>? GrantTypesSupported { get; set; }
    public List<string>? CodeChallengeMethodsSupported { get; set; }
    public List<string>? UiLocalesSupported { get; set; }
    public List<string>? DisplayValuesSupported { get; set; }
    public bool? AuthorizationResponseIssParameterSupported { get; set; }
    public List<string>? RequestObjectSigningAlgValuesSupported { get; set; }
    public List<string>? RequestObjectEncryptionAlgValuesSupported { get; set; }
    public List<string>? RequestObjectEncryptionEncValuesSupported { get; set; }
    public bool? RequestParameterSupported { get; set; }
    public bool? RequestUriParameterSupported { get; set; }
    public bool? RequireRequestUriRegistration { get; set; }
    public string? JwksUri { get; set; }
    public string? AuthorizationEndpoint { get; set; }
    public string? TokenEndpoint { get; set; }
    public List<string>? TokenEndpointAuthSigningAlgValuesSupported { get; set; }
    public string? RevocationEndpoint { get; set; }
    public string? IntrospectionEndpoint { get; set; }
    public string? PushedAuthorizationRequestEndpoint { get; set; }
    public bool? RequirePushedAuthorizationRequests { get; set; }
    public List<string>? DpopSigningAlgValuesSupported { get; set; }
    public bool? ClientIdMetadataDocumentSupported { get; set; }




    }
