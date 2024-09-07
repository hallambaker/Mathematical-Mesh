
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
    (BigInteger, BigInteger) GetPrime(int bits, int modulus, string tag = null);

    /// <summary>
    /// Return a random value in the interval <paramref name="minInclusive"/> to
    /// <paramref name="maxInclusive"/> inclusive for variable <paramref name="tag"/>.
    /// </summary>
    /// <param name="minInclusive"></param>
    /// <param name="maxInclusive"></param>
    /// <param name="tag">Tag used to identify the item for deterministic generation.</param>
    /// <returns>The random value.</returns>
    BigInteger GetEntropy(BigInteger minInclusive, BigInteger maxInclusive, string tag = null);



    void Register(string tag, int count);
    }


public class PrimeGenerator : IPrimeGenerator {

    ///<summary>Dictionary tracking the number of times the method has been called.</summary> 
    public Dictionary<string, int> CallCount { get; } = new();


    IRandom800_90 random;
    private readonly IEntropyProvider _entropyProvider;

    /// <summary>
    /// Constructor, return a prime generator using the platform random number generator.
    /// </summary>
    public PrimeGenerator() {
        random = new Random800_90();
        _entropyProvider = new EntropyProvider(random);
        }

    ///<inheritdoc/>
    public BigInteger GetEntropy(BigInteger minInclusive, BigInteger maxInclusive, string tag = null) {
        UpdateCallCount(tag);
        return _entropyProvider.GetEntropy(minInclusive, maxInclusive);
        }

    ///<inheritdoc/>
    public (BigInteger, BigInteger) GetPrime(int bits, int modulus, string tag = null) {

        var iterations = modulus switch {
            2048 => 32,
            3072 => 27,
            4096 => 22,
            _ => throw new CryptographicException()
            };

        var xp1 = _entropyProvider.GetEntropy(bits).ToPositiveBigInteger();
        if (xp1.IsEven) {
            xp1++;
            }
        var p1 = xp1;

        var count = 0;
        while (!NumberTheory.MillerRabin(p1, iterations)) {
            p1 += 2;
            count++;
            }

        CallCount.Add(tag, count);

        return (xp1, p1);
        }

    public void Register(string tag, int count) => CallCount.Add(tag, count);

    /// <summary>
    /// Update the call count in the dictionary.
    /// </summary>
    /// <param name="tag">The identifier to update.</param>
    void UpdateCallCount(string tag) {
        if (CallCount.TryGetValue(tag, out var count)) {
            CallCount.Remove(tag);
            CallCount.Add(tag, count + 1);
            }
        else {
            CallCount.Add(tag, 1);
            }
        }


    }

