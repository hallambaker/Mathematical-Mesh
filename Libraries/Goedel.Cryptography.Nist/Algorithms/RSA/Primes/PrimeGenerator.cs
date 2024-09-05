
using System;
using System.Reflection;

namespace Goedel.Cryptography.Nist;

public interface IPrimeGenerator {
    (BigInteger, BigInteger) GetPrime(int bits, int modulus);

    BigInteger GetEntropy(BigInteger minInclusive, BigInteger maxInclusive);
    }
public class PrimeGenerator : IPrimeGenerator {

    IRandom800_90 random;
    private readonly IEntropyProvider _entropyProvider;

    public PrimeGenerator() {
        random = new Random800_90();
        _entropyProvider = new EntropyProvider(random);
        }

    public BigInteger GetEntropy(BigInteger minInclusive, BigInteger maxInclusive) =>
        _entropyProvider.GetEntropy(minInclusive, maxInclusive);

    public (BigInteger, BigInteger) GetPrime(int bits, int modulus) {
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

        while (!NumberTheory.MillerRabin(p1, iterations)) {
            p1 += 2;
            }

        return (xp1, p1);
        }

    }

