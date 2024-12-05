namespace Goedel.Cryptography.Oauth;

public record DidDocument : ISerializable {

    public FormFields[] Fields => fields;
    static readonly FormFields[] fields = [
        new("@context", FormEntryType.ArrayString, (data, s) => ((DidDocument)data).Contexts = s as List<string>,
            (data) => (data as DidDocument)?.Contexts),
        new("id", FormEntryType.String, (data, s) => ((DidDocument)data).Id = s as string,
            (data) => (data as DidDocument)?.Id),
        new("alsoKnownAs", FormEntryType.ArrayString, (data, s) => ((DidDocument)data).AlsoKnownAs = s as List<string>,
            (data) => (data as DidDocument)?.AlsoKnownAs),
        new("verificationMethod", FormEntryType.ArrayString, (data, s) => ((DidDocument)data).VerficationMethods = s as List<DidVerficationMethod>,
            (data) => (data as DidDocument)?.VerficationMethods, ()=> new DidVerficationMethod()),
        new("service", FormEntryType.ArrayString, (data, s) => ((DidDocument)data).Services = s as List<DidService>,
            (data) => (data as DidDocument)?.Services, ()=> new DidService())
        ];

    public List<string>? Contexts { get; set; }
    public string? Id { get; set; }
    public List<string>? AlsoKnownAs { get; set; }
    public List<DidVerficationMethod>? VerficationMethods { get; set; }
    public List<DidService>? Services { get; set; }
    }

public record DidVerficationMethod : ISerializable {
    public FormFields[] Fields => fields;
    static readonly FormFields[] fields = [
        new("id", FormEntryType.String, (data, s) => ((DidVerficationMethod)data).Id = s as string,
            (data) => (data as DidVerficationMethod)?.Id),
        new("type", FormEntryType.String, (data, s) => ((DidVerficationMethod)data).Type = s as string,
            (data) => (data as DidVerficationMethod)?.Type),
        new("controller", FormEntryType.String, (data, s) => ((DidVerficationMethod)data).Controller = s as string,
            (data) => (data as DidVerficationMethod)?.Controller),
        new("publicKeyMultibase", FormEntryType.String, (data, s) => ((DidVerficationMethod)data).PublicKeyMultibase = s as string,
            (data) => (data as DidVerficationMethod)?.PublicKeyMultibase)

        ];

    public string? Id { get; set; }
    public string? Type { get; set; }
    public string? Controller { get; set; }
    public string? PublicKeyMultibase { get; set; }

    }


public record DidService : ISerializable {
    public FormFields[] Fields => fields;
    static readonly FormFields[] fields = [
        new("id", FormEntryType.String, (data, s) => ((DidService)data).Id = s as string,
            (data) => (data as DidService)?.Id),
        new("type", FormEntryType.String, (data, s) => ((DidService)data).Type = s as string,
            (data) => (data as DidService)?.Type),
        new("serviceEndpoint", FormEntryType.String, (data, s) => ((DidService)data).ServiceEndpoint = s as string,
            (data) => (data as DidService)?.ServiceEndpoint)
        ];

    public string? Id { get; set; }
    public string? Type { get; set; }
    public string? ServiceEndpoint { get; set; }
    }
