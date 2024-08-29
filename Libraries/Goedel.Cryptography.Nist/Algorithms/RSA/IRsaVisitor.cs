
namespace Goedel.Cryptography.Nist;

public interface IRsaVisitor {
    BigInteger Decrypt(BigInteger cipherText, CrtPrivateKey privKey, PublicKey pubKey);
    BigInteger Decrypt(BigInteger cipherText, PrivateKey privKey, PublicKey pubKey);
    }

