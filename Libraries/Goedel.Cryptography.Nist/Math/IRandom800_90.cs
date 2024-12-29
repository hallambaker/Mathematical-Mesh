namespace Goedel.Cryptography.Nist;


/// <summary>
/// Random number generation.
/// </summary>
public interface IRandom800_90 {


    /// <summary>
    /// Return a random big integer less than or equal to <paramref name="maxInclusive"/>
    /// </summary>
    /// <param name="maxInclusive">Maximum value.</param>
    /// <returns>The random value.</returns>
    BigInteger GetRandomBigInteger(BigInteger maxInclusive);

    }

