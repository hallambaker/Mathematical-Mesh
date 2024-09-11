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
    /// <param name="context">Optional context string of 255 bytes or fewer.</param>
    /// <returns>True if the signature is valid, otherwise false.</returns>
    public bool VerifyPure(
                    byte[] signature,
                    byte[] message,
                    byte[] context) => VerifyInternal(signature, message,
                        CryptographyExtensions.CreateManifestPrefixPure(context));


    /// <summary>
    /// Verify the signature <paramref name="signature"/> over message with digest
    /// <paramref name="digest"/> created with digest algorithm oid returning true if and only if the 
    /// signature is valid.
    /// </summary>
    /// <param name="signature">The signature to verify.</param>
    /// <param name="digest">The digest value.</param>
    /// <param name="oid">An OID specifying the digest algorithm.</param>
    /// <param name="context">Optional context string of 255 bytes or fewer.</param>
    /// <returns>Signature</returns>
    public bool VerifyHashed(
                    byte[] signature,
                    byte[] digest,
                    byte[] oid,
                    byte[] context) => VerifyInternal(signature,
                        CryptographyExtensions.CreateManifestHashed(digest, oid, context));

    /// <summary>
    /// Verify the signature <paramref name="signature"/> over message
    /// <paramref name="message"/> returning true if and only if the 
    /// signature is valid.
    /// </summary>
    /// <param name="signature">The signature to verify.</param>
    /// <param name="message">The message signed.</param>
    /// <param name="prefix">Prefix inserted ahead of the message to specify
    /// the manifest data.</param>
    /// <returns>True if the signature is valid, otherwise false.</returns>
    public bool VerifyInternal(
                byte[] signature,
                byte[] message,
                byte[]? prefix = null) => Dilithium.VerifyInternal(
                    this, signature, message, prefix);


    }
