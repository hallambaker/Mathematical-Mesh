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
    /// <param name="privateKey">If true, include the private key.</param>
    /// <returns>The created instance.</returns>
    public static JWK? Factory(KeyPair keyPair, bool privateKey=false) {
        var result = keyPair switch {
            KeyPairECDHNist keyPairECDHNist => Factory(keyPairECDHNist, privateKey),
            KeyPairECDH keyPairECDH => Factory(keyPairECDH, privateKey),
            KeyPairBaseRSA baseRSA => Factory(baseRSA, privateKey),
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
    /// <param name="privateKey">If true, include the private key.</param>
    /// <returns>The created instance.</returns>
    public static JWK Factory(KeyPairECDHNist keyPairECDHNist, bool privateKey = false) => 
            new JwkEllipticCurve() {
                Curve = "P-256",
                Use = keyPairECDHNist.KeyUses.HasFlag(KeyUses.Sign) ? "sig" : "enc",
                X = keyPairECDHNist.PublicKey.PublicKey.X.ToByteArrayBigEndian(32).ToStringBase64url(),
                Y = keyPairECDHNist.PublicKey.PublicKey.Y.ToByteArrayBigEndian(32).ToStringBase64url(),
                Kid = keyPairECDHNist.KeyIdentifier,
                D = !privateKey ? null :
                    keyPairECDHNist.PKIXPrivateKeyECDH.Data.ToStringBase64url()
                } ;
    /// <summary>
    /// Factory method returning an instance for the Elliptic Cuve key <paramref name="keyPairECDH"/>
    /// </summary>
    /// <param name="keyPairECDH">The key to return the JWK for.</param>
    /// <param name="privateKey">If true, include the private key.</param>
    /// <returns>The created instance.</returns>
    public static JWK Factory(KeyPairECDH keyPairECDH, bool privateKey = false) => new JwkOctetKeyPairs(){
        //KeyType = "OKP",
        Curve = GetCurve(keyPairECDH),
        X = keyPairECDH.PublicData.ToStringBase64url(),
        Kid = keyPairECDH.KeyIdentifier
        };


    /// <summary>
    /// Factory method returning an instance for the RSA key <paramref name="keyPairRsa"/>
    /// </summary>
    /// <param name="keyPairRsa">The key to return the JWK for.</param>
    /// <param name="privateKey">If true, include the private key.</param>
    /// <returns>The created instance.</returns>
    public static JWK Factory(KeyPairBaseRSA keyPairRsa, bool privateKey = false) => new JwkRsa() {
        //KeyType = "RSA",
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



public partial class JwkUdfSeed {

    /// <summary>Return the private key seed.</summary>
    /// <returns>The seed.</returns>
    public PrivateKeyUDF GetPrivateKeyUDF() => new(Seed);


    }