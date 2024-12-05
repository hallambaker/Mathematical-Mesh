namespace Goedel.Cryptography.Oauth;

public record ResourceServerMetadata : ISerializable {
    public FormFields[] Fields => fields;
    static readonly FormFields[] fields = [
            new("resource", FormEntryType.String, (data, s) => ((ResourceServerMetadata)data).Resource = s as string,
                (data) => (data as ResourceServerMetadata)?.Resource),
            new("authorization_servers", FormEntryType.ArrayString, (data, s) => ((ResourceServerMetadata)data).AuthorizationServers = s as List<string>,
                (data) => (data as ResourceServerMetadata)?.AuthorizationServers),
            new("scopes_supported", FormEntryType.ArrayString, (data, s) => ((ResourceServerMetadata)data).ScopesSupported = s as List<string>,
                (data) => (data as ResourceServerMetadata)?.ScopesSupported),
            new("bearer_methods_supported", FormEntryType.ArrayString, (data, s) => ((ResourceServerMetadata)data).BearerMethodsSupported = s as List<string>,
                (data) => (data as ResourceServerMetadata)?.BearerMethodsSupported),
            new("resource_documentation", FormEntryType.String, (data, s) => ((ResourceServerMetadata)data).ResourceDocumentation = s as string,
                (data) => (data as ResourceServerMetadata)?.ResourceDocumentation),
        ];
    public string? Resource { get; set; }
    public List<string>? AuthorizationServers { get; set; }
    public List<string>? ScopesSupported { get; set; }
    public List<string>? BearerMethodsSupported { get; set; }
    public string? ResourceDocumentation { get; set; }


    }
