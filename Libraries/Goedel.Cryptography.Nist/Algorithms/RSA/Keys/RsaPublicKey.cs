
namespace Goedel.Cryptography.Nist;

/// <summary>
/// RSA public key parameters
/// </summary>
/// <param name="E">The exponent.</param>
/// <param name="N">The modulus.</param>
public record RsaPublicKey (
            BigInteger E,
            BigInteger N) {
    }

