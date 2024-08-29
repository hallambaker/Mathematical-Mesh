
namespace Goedel.Cryptography.Nist;

/// <summary>
/// Abstract interface for ML-KEM-Internal
/// </summary>
public interface IMLKEM {

    /// <summary>
    /// Generate an encapsulation and decapsulation key pair
    /// </summary>
    /// <param name="z">Random concatenation on decapsulation key</param>
    /// <param name="d">Random seed provided to K-PKE.KeyGen</param>
    /// <returns>Tuple containing (encapsulation key ek, decapsulation key dk)</returns>
    public (byte[] ek, byte[] dk) GenerateKey(byte[] z, byte[] d);

    /// <summary>
    /// Derive and encapsulate a shared secret
    /// </summary>
    /// <param name="ek">Encapsulation key</param>
    /// <param name="m">Random seed, 32 bytes</param>
    /// <returns>Tuple containing (shared secret K, ciphertext c)</returns>
    public (byte[] K, byte[] c) Encapsulate(byte[] ek, byte[] m);

    /// <summary>
    /// Decapsulate a shared secret
    /// </summary>
    /// <param name="dk">Decapsulation key</param>
    /// <param name="c">Encapsulated shared secret</param>
    /// <returns>Decapsulated shared secret</returns>
    public (byte[] sharedKey, bool implicitRejection) Decapsulate(byte[] dk, byte[] c);
    }
