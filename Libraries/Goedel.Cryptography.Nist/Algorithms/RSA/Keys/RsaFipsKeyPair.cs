
namespace Goedel.Cryptography.Nist;


/// <summary>
/// RSA Key Pair
/// </summary>
public record RsaFipsKeyPair {

    /// <summary>
    /// Public key
    /// </summary>
    public RsaPublicKey PubKey { get; set; }

    /// <summary>
    /// Private key
    /// </summary>
    public PrivateKeyRsaCrt PrivKey { get; set; } = new PrivateKeyRsaCrt();
    }

