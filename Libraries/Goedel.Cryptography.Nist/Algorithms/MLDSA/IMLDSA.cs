
namespace Goedel.Cryptography.Nist;


/// <summary>
/// ML-DSA internal functions interface.
/// <para>
/// The interfaces have been modified to use bytes instead of the bit arrays
/// used in the reference code.
/// </para>
/// </summary>
public interface IMLDSA {

    /// <summary>
    /// Generates a key pair (pk, sk)
    /// </summary>
    /// <param name="seed">Random 256-bit array</param>
    /// <returns>Tuple (byte[] pk, byte[] sk) containing the public key 
    /// and secret key</returns>
    public (byte[] pk, byte[] sk) GenerateKey(byte[] seed);

    /// <summary>
    /// Signs a message with a given secret key
    /// </summary>
    /// <param name="sk">Secret key.</param>
    /// <param name="message">Arbitrary set of bits.</param>
    /// <param name="rnd">The deterministic seed value.</param>
    /// <returns>Signature</returns>
    public byte[] Sign(byte[] sk, byte[] message, byte[] rnd = null);

    /// <summary>
    /// Verify a signature
    /// </summary>
    /// <param name="pk">Public key.</param>
    /// <param name="signature">Signature.</param>
    /// <param name="message">Message.</param>
    /// <returns>True if validation succeeds, otherwise false.</returns>
    public bool Verify(byte[] pk, byte[] signature, byte[] message);
    }
