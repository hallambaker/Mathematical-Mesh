
namespace Goedel.Cryptography.Nist;


public interface IMLDSA {
    public (byte[] pk, byte[] sk) GenerateKey(BitArray seed);
    public byte[] Sign(byte[] sk, BitArray message, bool deterministic, BitArray rnd = null);
    public bool Verify(byte[] pk, byte[] signature, BitArray message);
    }
