
namespace Goedel.Cryptography.Nist;

public class KeyPair {
        public PublicKey PubKey { get; set; }
        public PrivateKeyBase PrivKey { get; set; } = new PrivateKey();
        }
    
