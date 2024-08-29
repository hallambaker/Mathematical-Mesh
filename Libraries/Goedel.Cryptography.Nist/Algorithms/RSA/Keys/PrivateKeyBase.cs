
namespace Goedel.Cryptography.Nist;

public abstract class PrivateKeyBase : IRsaVisitable, IRsaPrivateKey {
    public BigInteger P { get; set; }
    public BigInteger Q { get; set; }
    public BigInteger D { get; set; }
    public BigInteger DMP1 { get; set; }
    public BigInteger DMQ1 { get; set; }
    public BigInteger IQMP { get; set; }

    public abstract BigInteger AcceptDecrypt(IRsaVisitor visitor, BigInteger cipherText, PublicKey pubKey);
    }

