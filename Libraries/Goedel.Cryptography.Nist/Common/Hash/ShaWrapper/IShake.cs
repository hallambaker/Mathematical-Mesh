namespace Goedel.Cryptography.Nist;

public interface IShake : ISha {

    /// <summary>
    /// Absorb <paramref name="bitLength"/> bits from <paramref name="message"/>
    /// </summary>
    /// <param name="message">Source</param>
    /// <param name="bitLength">Number of bits</param>
    void Absorb(byte[] message, int bitLength);


    /// <summary>
    /// Squeeze <paramref name="outputBitLength"/> bits into <paramref name="output"/>
    /// </summary>
    /// <param name="output">Destination</param>
    /// <param name="outputBitLength">Number of bits</param>
    void Squeeze(byte[] output, int outputBitLength);
    }
