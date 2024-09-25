
namespace Goedel.Cryptography.Nist;

/// <summary>
/// ML-KEM public key.
/// </summary>
public class KyberPublic {

    ///<summary>The kyber parameters</summary> 
    public KyberNist Kyber { get; }

    ///<swummary>The encoded Public Key value</swummary> 
    public byte[] PublicKey { get; init; }



    private KyberPublic(byte[] publicKey, KyberNist kyber) {
        Kyber = kyber;
        PublicKey = publicKey;

        }

    /// <summary>
    /// Factory method returning an instance generated from the public key value
    /// <paramref name="publicKey"/>.
    /// </summary>
    /// <returns>The private key.</returns>
    public static KyberPublic FromPublicKey(byte[] publicKey) =>
                new KyberPublic(publicKey, KyberNist.GetByPublicKeyLength(publicKey.Length)) {
                    PublicKey = publicKey
                    };


    /// <summary>
    /// Derive and encapsulate a shared secret
    /// </summary>
    /// <param name="m">Random seed, 32 bytes</param>
    /// <returns>Tuple containing (shared secret K, ciphertext c)</returns>
    public (byte[] k, byte[] c) Encapsulate(byte[] m) =>
        Kyber.Encapsulate(this, m);

    }
