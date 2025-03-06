//using System.Security.Cryptography;
//using System.Text.Json.Nodes;

//namespace Goedel.Cryptography.Oauth;

///// <summary>
///// JOSE Web Key
///// </summary>
//public partial class JWK {
    
    
//    /// <summary>
//    /// Facotry method returning an instance for the key <paramref name="keyPair"/>
//    /// </summary>
//    /// <param name="keyPair">The key to return the JWK for.</param>
//    /// <returns>The created instance.</returns>
//    public static JWK? Factory(KeyPair keyPair) => keyPair switch {
//        KeyPairECDHNist keyPairECDHNist => new JWK() {
//            KeyType = "EC",
//            Curve = "P-256",
//            Use = keyPair.KeyUses.HasFlag(KeyUses.Sign) ? "sig" : "enc",
//            X = keyPairECDHNist.PublicKey.PublicKey.X.ToByteArrayBigEndian(32).ToStringBase64url(),
//            Y = keyPairECDHNist.PublicKey.PublicKey.Y.ToByteArrayBigEndian(32).ToStringBase64url(),
//            Kid = keyPair.KeyIdentifier
//            },
//        _ => null
//        };
//    }