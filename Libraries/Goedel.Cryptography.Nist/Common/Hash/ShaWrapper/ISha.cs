﻿namespace Goedel.Cryptography.Nist;
/// <summary>
/// Provides a SHA implementation for hashing 
/// </summary>
public interface ISha {
    /// <summary>
    /// The <see cref="HashFunction"/> attributed to the <see cref="ISha"/> instance
    /// </summary>
    HashFunction HashFunction { get; }

    /// <summary>
    /// Given a <paramref name="message"/>, return a hash of <paramref name="outLen"/> bytes
    /// </summary>
    /// <param name="message">The message to hash</param>
    /// <param name="outLen"></param>
    /// <returns></returns>
    HashResult HashMessage(BitString message, int outLen = 0);

    /// <summary>
    /// Given a <paramref name="number"/>, return a digest
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    HashResult HashNumber(BigInteger number);

    /// <summary>
    /// Initializes the hash function
    /// </summary>
    void Init();

    /// <summary>
    /// Provides content to hash
    /// </summary>
    /// <param name="message"></param>
    /// <param name="bitLength"></param>
    void Update(byte[] message, int bitLength);

    /// <summary>
    /// Provides content to hash, MUST not have other updates of incomplete bytes
    /// </summary>
    /// <param name="message"></param>
    /// <param name="bitLength">MUST be a multiple of 8 bits</param>
    void Update(int message, int bitLength);

    /// <summary>
    /// Get the hash result
    /// </summary>
    /// <param name="output"></param>
    /// <param name="outputBitLength"></param>
    /// <returns></returns>
    void Final(byte[] output, int outputBitLength = 0);

    }

