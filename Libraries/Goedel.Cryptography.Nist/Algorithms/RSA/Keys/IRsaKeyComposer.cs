
namespace Goedel.Cryptography.Nist;

public interface IRsaKeyComposer {
        KeyPair ComposeKey(BigInteger e, PrimePair primes);
        }
    
