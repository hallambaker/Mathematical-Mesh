using System.Security.Cryptography;
using System.Text.Json.Nodes;

namespace Goedel.Cryptography.Oauth;

//public record JWKS : ISerializable {

//    JsonValue fred;

//    public SerialField[] Fields => fields;
//    static readonly SerialField[] fields = [

//        new("keys", FieldType.ArrayObject,
//            (data, s) => ((JWKS)data).Keys = s as List<JWK>,
//            (data) => (data as JWKS)?.Keys,
//            ()=> new JWK(),()=> new List<JWK>())


//        ];


//    public List<JWK> Keys { get; set; }

//    }


//public record JWK : ISerializable {


//    public SerialField[] Fields => fields;
//    static readonly SerialField[] fields = [
//        new("kty", FieldType.String, 
//            (data, s) => ((JWK)data).Kty = s as string,
//            (data) => (data as JWK)?.Kty),
//        new("use", FieldType.String,
//            (data, s) => ((JWK)data).Use = s as string,
//            (data) => (data as JWK)?.Use),
//        new("crv", FieldType.String,
//            (data, s) => ((JWK)data).CRV = s as string,
//            (data) => (data as JWK)?.CRV),
//        new("x", FieldType.String,
//            (data, s) => ((JWK)data).X = s as string,
//            (data) => (data as JWK)?.X),
//        new("y", FieldType.String,
//            (data, s) => ((JWK)data).Y = s as string,
//            (data) => (data as JWK)?.Y),
//        new("d", FieldType.String,
//            (data, s) => ((JWK)data).D = s as string,
//            (data) => (data as JWK)?.D),

//        ];


//    public string? Kty { get; set; }
//    public string? Use { get; set; }
//    public string? CRV { get; set; }
//    public string? X { get; set; }
//    public string? Y { get; set; }
//    public string? D { get; set; }


//    public string? Kid { get; set; }

//    public JWK() {
//        }


//    public static JWK? Factory (KeyPair  keyPair) => keyPair switch {
//        KeyPairECDHNist keyPairECDHNist => new JWK() {
//            Kty = "EC",
//            CRV = "P-256",
//            Use = keyPair.KeyUses.HasFlag (KeyUses.Sign) ? "Sig" :"Enc",
//            X = keyPairECDHNist.PublicKey.PublicKey.X.ToByteArrayBigEndian(32).ToStringBase64url(),
//            Y = keyPairECDHNist.PublicKey.PublicKey.Y.ToByteArrayBigEndian(32).ToStringBase64url(),
//            Kid = keyPair.UDFValue
//            },
//        _ => null
//        };




//    }


public partial class JWK {
    public static JWK? Factory(KeyPair keyPair) => keyPair switch {
        KeyPairECDHNist keyPairECDHNist => new JWK() {
            KeyType = "EC",
            Curve = "P-256",
            Use = keyPair.KeyUses.HasFlag(KeyUses.Sign) ? "sig" : "enc",
            X = keyPairECDHNist.PublicKey.PublicKey.X.ToByteArrayBigEndian(32).ToStringBase64url(),
            Y = keyPairECDHNist.PublicKey.PublicKey.Y.ToByteArrayBigEndian(32).ToStringBase64url(),
            Kid = keyPair.KeyIdentifier
            },
        _ => null
        };
    }