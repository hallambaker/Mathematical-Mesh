
namespace Goedel.Cryptography.Nist;



public class RsaFipsKeyPair {
    public RsaPublicKey PubKey { get; set; }
    public PrivateKeyRsaCrt PrivKey { get; set; } = new PrivateKeyRsaCrt();
    }

