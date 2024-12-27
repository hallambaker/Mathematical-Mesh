namespace Goedel.Cryptography.Nist;

/// <summary>
/// Provides a means of retrieving a <see cref="ISha"/> instance.
/// </summary>
public interface IShaFactory {
    /// <summary>
    /// Gets an <see cref="ISha"/> based on the <see cref="HashFunction"/>
    /// </summary>
    /// <param name="hashFunction">Used to determine the <see cref="ISha"/> instance to retrieve.</param>
    /// <returns></returns>
    ISha GetShaInstance(HashFunction hashFunction);

    /// <summary>
    /// Gets an <see cref="IShake"/> based on the <see cref="HashFunction"/>
    /// </summary>
    /// <param name="hashFunction">Used to determine the <see cref="IShake"/> instance to retrieve.</param>
    /// <returns></returns>
    IShake GetShakeInstance(HashFunction hashFunction);

    }

