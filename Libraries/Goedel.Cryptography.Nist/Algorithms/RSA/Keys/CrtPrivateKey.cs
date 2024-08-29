
namespace Goedel.Cryptography.Nist;

// Chinese Remainder Theorem
public class CrtPrivateKey : PrivateKeyBase {
        public override BigInteger AcceptDecrypt(IRsaVisitor visitor, BigInteger cipherText, PublicKey pubKey) {
            return visitor.Decrypt(cipherText, this, pubKey);
            }
        }
    
