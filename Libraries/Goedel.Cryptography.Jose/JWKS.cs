using Goedel.Cryptography.Standard;

using System.Data.SqlTypes;
using System.Security.Cryptography;
using System.Text.Json.Nodes;

namespace Goedel.Cryptography.Jose;

/// <summary>
/// JOSE Web Key
/// </summary>
public partial class JWK {


    /// <summary>
    /// Facotry method returning an instance for the key <paramref name="keyPair"/>
    /// </summary>
    /// <param name="keyPair">The key to return the JWK for.</param>
    /// <returns>The created instance.</returns>
    public static JWK? Factory(KeyPair keyPair) {
        var result = keyPair switch {
            KeyPairECDHNist keyPairECDHNist => Factory(keyPairECDHNist),
            KeyPairECDH keyPairECDH => Factory(keyPairECDH),
            KeyPairBaseRSA baseRSA => Factory(baseRSA),
            _ => null
            };

        if ((keyPair.KeyUses & KeyUses.Sign) == KeyUses.Sign) {
            result.Use = ((keyPair.KeyUses & KeyUses.Encrypt) == KeyUses.Encrypt) ? "any" : "sig";
            }
        else if ((keyPair.KeyUses & KeyUses.Encrypt) == KeyUses.Encrypt) {
            result.Use = "enc";
            }

        return result;
        }


    public static JWK Factory(KeyPairECDHNist keyPairECDHNist) => new() {
        KeyType = "EC",
        Curve = "P-256",
        Use = keyPairECDHNist.KeyUses.HasFlag(KeyUses.Sign) ? "sig" : "enc",
        X = keyPairECDHNist.PublicKey.PublicKey.X.ToByteArrayBigEndian(32).ToStringBase64url(),
        Y = keyPairECDHNist.PublicKey.PublicKey.Y.ToByteArrayBigEndian(32).ToStringBase64url(),
        Kid = keyPairECDHNist.KeyIdentifier
        };


    public static JWK Factory(KeyPairECDH keyPairECDH) => new(){
        KeyType = "OKP",
        Curve = GetCurve(keyPairECDH),
        X = keyPairECDH.PublicData.ToStringBase64url(),
        Kid = keyPairECDH.KeyIdentifier
        };


    public static JWK Factory(KeyPairBaseRSA baseRSA) => new() {
        KeyType = "RSA",
        N = baseRSA.PkixPublicKeyRsa.Modulus.ToStringBase64url(),
        E = baseRSA.PkixPublicKeyRsa.PublicExponent.ToStringBase64url()
        };
    public static string GetCurve(KeyPairECDH keyPairECDH) => keyPairECDH switch {
        KeyPairEd25519 => "Ed25519",
        KeyPairEd448 => "Ed448",
        KeyPairX25519 => "X25519",
        KeyPairX448 => "X448",
        _ =>throw new NYI()
        };

    }