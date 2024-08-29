namespace Goedel.Cryptography.Nist;

public interface IShake : ISha {
    void Absorb(byte[] message, int bitLength);
    void Squeeze(byte[] output, int outputBitLength);
    }
