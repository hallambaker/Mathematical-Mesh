//namespace Goedel.Cryptography.Oauth;

//public record DidDocument : ISerializable {

//    public SerialField[] Fields => fields;
//    static readonly SerialField[] fields = [
//        new("@context", FieldType.ArrayString,
//            (data, s) => ((DidDocument)data).Contexts = s as List<string?>,
//            (data) => (data as DidDocument)?.Contexts),
//        new("id", FieldType.String, 
//            (data, s) => ((DidDocument)data).Id = s as string,
//            (data) => (data as DidDocument)?.Id),
//        new("alsoKnownAs", FieldType.ArrayString, 
//            (data, s) => ((DidDocument)data).AlsoKnownAs = s as List<string?>,
//            (data) => (data as DidDocument)?.AlsoKnownAs),
//        new("verificationMethod", FieldType.DictionaryObject, 
//            (data, s) => ((DidDocument)data).VerficationMethods = s as Dictionary<string,DidVerficationMethod?>,
//            (data) => (data as DidDocument)?.VerficationMethods, 
//            ()=> new DidVerficationMethod(),()=> new Dictionary<string,DidVerficationMethod>()),
//        new("service", FieldType.DictionaryObject, 
//            (data, s) => ((DidDocument)data).Services = s as Dictionary<string,DidService?>,
//            (data) => (data as DidDocument)?.Services, 
//            ()=> new DidService(),()=> new Dictionary<string,DidService>())
//        ];

//    public List<string?>? Contexts { get; set; }
//    public string? Id { get; set; }
//    public List<string?>? AlsoKnownAs { get; set; }
//    public Dictionary<string,DidVerficationMethod?>? VerficationMethods { get; set; }
//    public Dictionary<string,DidService?>? Services { get; set; }
//    }

//public record DidVerficationMethod : ISerializable, ISerializableKeyed {

//    public string? Key => Id;

//    public SerialField[] Fields => fields;
//    static readonly SerialField[] fields = [
//        new("id", FieldType.String, 
//            (data, s) => ((DidVerficationMethod)data).Id = s as string,
//            (data) => (data as DidVerficationMethod)?.Id),
//        new("type", FieldType.String, 
//            (data, s) => ((DidVerficationMethod)data).Type = s as string,
//            (data) => (data as DidVerficationMethod)?.Type),
//        new("controller", FieldType.String, 
//            (data, s) => ((DidVerficationMethod)data).Controller = s as string,
//            (data) => (data as DidVerficationMethod)?.Controller),
//        new("publicKeyMultibase", FieldType.String,
//            (data, s) => ((DidVerficationMethod)data).PublicKeyMultibase = s as string,
//            (data) => (data as DidVerficationMethod)?.PublicKeyMultibase)

//        ];

//    public string? Id { get; set; }
//    public string? Type { get; set; }
//    public string? Controller { get; set; }
//    public string? PublicKeyMultibase { get; set; }

//    }


//public record DidService : ISerializable, ISerializableKeyed {
//    public string? Key => Id;

//    public SerialField[] Fields => fields;
//    static readonly SerialField[] fields = [
//        new("id", FieldType.String, (data, s) => ((DidService)data).Id = s as string,
//            (data) => (data as DidService)?.Id),
//        new("type", FieldType.String, (data, s) => ((DidService)data).Type = s as string,
//            (data) => (data as DidService)?.Type),
//        new("serviceEndpoint", FieldType.String, (data, s) => ((DidService)data).ServiceEndpoint = s as string,
//            (data) => (data as DidService)?.ServiceEndpoint)
//        ];

//    public string? Id { get; set; }
//    public string? Type { get; set; }
//    public string? ServiceEndpoint { get; set; }
//    }
