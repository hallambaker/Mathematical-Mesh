namespace Goedel.Cryptography.Nist;



/// <summary>
/// FIPS 204-Final implementation of ML-DSA from the Dilithium competition submission.
/// </summary>
public class DilithiumPublic {

    ///<summary>The parameter and operations set.</summary> 
    public DilithiumNist Dilithium { get; }

    ///<swummary>The encoded Public Key value</swummary> 
    public byte[] PublicKey { get; init; }

    internal int[][][] AHat { get; }

    internal int[][] T1 { get; }

    private DilithiumPublic(byte[] publicKey, DilithiumNist dilithium) {
        Dilithium = dilithium;

        (var rho, T1) = dilithium.PkDecode(publicKey);
        AHat = dilithium.ExpandA(rho);

        }

    /// <summary>
    /// Factory method returning an instance generated from the public key value
    /// <paramref name="publicKey"/>.
    /// </summary>
    /// <returns>The private key.</returns>
    public static DilithiumPublic FromPublicKey(byte[] publicKey) =>
                new DilithiumPublic(publicKey, DilithiumNist.GetByPublicKeyLength(publicKey.Length)) {
                    PublicKey = publicKey

                    };

    /// <summary>
    /// Verify the signature <paramref name="signature"/> over message
    /// <paramref name="message"/> returning true if and only if the 
    /// signature is valid.
    /// </summary>
    /// <param name="signature">The signature to verify.</param>
    /// <param name="message">The message signed.</param>
    /// <returns>True if the signature is valid, otherwise false.</returns>
    public bool Verify(
                byte[] signature,
                byte[] message) => Dilithium.Verify(this, signature, message);


    }
