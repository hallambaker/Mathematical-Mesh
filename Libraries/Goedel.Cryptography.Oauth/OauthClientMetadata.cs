namespace Goedel.Cryptography.Oauth;

public record OauthClientMetadata : ISerializable {

    public FormFields[] Fields => fields;
    static readonly FormFields[] fields = [
        ];
    }