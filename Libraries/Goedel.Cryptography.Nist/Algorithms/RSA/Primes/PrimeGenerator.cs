
using System;
using System.Reflection;

namespace Goedel.Cryptography.Nist;

public interface IPrimeGenerator {

    /// <summary>
    /// Return a prime value of <paramref name="bits"/> meeting the requirments 
    /// set by a modulus of size <paramref name="modulus"/> for variable 
    /// <paramref name="tag"/>.
    /// </summary>
    /// <param name="bits">The size of the prime in bits.</param>
    /// <param name="modulus">The size of the modulus in bits.</param>
    /// <param name="tag">Tag used to identify the item for deterministic generation.</param>
    /// <returns>The primne value.</returns>
    /// <param name="hint"></param>
    (BigInteger, BigInteger) GetPrime(int bits, int modulus, string tag = null, int? hint = null);

    /// <summary>
    /// Return a random value in the interval <paramref name="minInclusive"/> to
    /// <paramref name="maxInclusive"/> inclusive for variable <paramref name="tag"/>.
    /// </summary>
    /// <param name="minInclusive"></param>
    /// <param name="maxInclusive"></param>
    /// <param name="tag">Tag used to identify the item for deterministic generation.</param>
    /// <returns>The random value.</returns>
    /// <param name="hint"></param>
    BigInteger GetEntropy(
                BigInteger minInclusive,
                BigInteger maxInclusive,
                string tag = null, int? hint = null);



    void Register(string tag, int count);
    }


