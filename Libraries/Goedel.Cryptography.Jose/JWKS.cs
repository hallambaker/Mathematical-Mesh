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
    /// Factory method returning an instance for the key <paramref name="keyPair"/>
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

    /// <summary>
    /// Factory method returning an instance for the Elliptic Cuve key <paramref name="keyPairECDHNist"/>
    /// </summary>
    /// <param name="keyPairECDHNist">The key to return the JWK for.</param>
    /// <returns>The created instance.</returns>
    public static JWK Factory(KeyPairECDHNist keyPairECDHNist) => new() {
        KeyType = "EC",
        Curve = "P-256",
        Use = keyPairECDHNist.KeyUses.HasFlag(KeyUses.Sign) ? "sig" : "enc",
        X = keyPairECDHNist.PublicKey.PublicKey.X.ToByteArrayBigEndian(32).ToStringBase64url(),
        Y = keyPairECDHNist.PublicKey.PublicKey.Y.ToByteArrayBigEndian(32).ToStringBase64url(),
        Kid = keyPairECDHNist.KeyIdentifier
        };

    /// <summary>
    /// Factory method returning an instance for the Elliptic Cuve key <paramref name="keyPairECDH"/>
    /// </summary>
    /// <param name="keyPairECDH">The key to return the JWK for.</param>
    /// <returns>The created instance.</returns>
    public static JWK Factory(KeyPairECDH keyPairECDH) => new(){
        KeyType = "OKP",
        Curve = GetCurve(keyPairECDH),
        X = keyPairECDH.PublicData.ToStringBase64url(),
        Kid = keyPairECDH.KeyIdentifier
        };


    /// <summary>
    /// Factory method returning an instance for the RSA key <paramref name="keyPairRsa"/>
    /// </summary>
    /// <param name="keyPairRsa">The key to return the JWK for.</param>
    /// <returns>The created instance.</returns>
    public static JWK Factory(KeyPairBaseRSA keyPairRsa) => new() {
        KeyType = "RSA",
        N = keyPairRsa.PkixPublicKeyRsa.Modulus.ToStringBase64url(),
        E = keyPairRsa.PkixPublicKeyRsa.PublicExponent.ToStringBase64url()
        };

    /// <summary>
    /// Map ECDH key pair curve to JOSE curve specifier.
    /// </summary>
    /// <param name="keyPairECDH">The key pair</param>
    /// <returns>The curve identifier.</returns>
    /// <exception cref="NYI">The key is not of a known curve.</exception>
    public static string GetCurve(KeyPairECDH keyPairECDH) => keyPairECDH switch {
        KeyPairEd25519 => "Ed25519",
        KeyPairEd448 => "Ed448",
        KeyPairX25519 => "X25519",
        KeyPairX448 => "X448",
        _ =>throw new NYI()
        };

    }