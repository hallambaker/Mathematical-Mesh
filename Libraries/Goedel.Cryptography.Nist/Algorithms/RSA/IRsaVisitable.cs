
namespace Goedel.Cryptography.Nist;

public interface IRsaVisitable {
    BigInteger AcceptDecrypt(IRsaVisitor visitor, BigInteger cipherText, PublicKey pubKey);
    }

