
namespace Goedel.Cryptography.Nist;




/// <summary>
/// Generate probable primes with conditions.
/// </summary>
public class AllProbablePrimesWithConditionsGenerator  {
    private readonly IEntropyProvider _entropyProvider;
    private readonly IPrimeGenerator _primeGenerator;
    private int _pBound = 5;

    /// <summary>
    /// Constructor, return an instance using the prime generator
    /// <paramref name="primeGenerator"/>
    /// </summary>
    /// <param name="primeGenerator">The prime generator.</param>
    public AllProbablePrimesWithConditionsGenerator(
                    IPrimeGenerator primeGenerator) {
        _primeGenerator = primeGenerator;
        }

    /// <summary>
    /// Generate primes compliant with FIPS 186v5
    /// </summary>
    /// <param name="param">The prime parameters.</param>
    /// <param name="hintsIn">Generation hints, if present will be used to skip
    /// straight to the values.</param>
    /// <returns>The prime generation result.</returns>
    public PrimeGeneratorResult GeneratePrimesFips186_5(
                    PrimeGeneratorParameters param, 
                    RsaGenerationHints hintsIn = null) {
        _pBound = 20;


        // Don't need the guards as we have declared this an internal class.
        //// Rethrow on exception
        //PrimeGeneratorGuard.AgainstInvalidModulusFips186_5(param.Modulus);
        //PrimeGeneratorGuard.AgainstInvalidPublicExponent(param.PublicE);
        //PrimeGeneratorGuard.AgainstInvalidBitlens(param.Modulus, param.BitLens);

        return GeneratePrimes(param, hintsIn);
        }

    private (BigInteger, BigInteger, BigInteger, 
        BigInteger, BigInteger, BigInteger) GetQualifiedPrime(
                    int bitlens, int modulus, int a, BigInteger exponent, string tag,
                        RsaGenerationHints.PrimeHints? hints) {

        BigInteger p, p1, p2, xp, xp1, xp2;

        var t1 = tag + "1";
        var t2 = tag + "2";

        (xp1, p1) = _primeGenerator.GetPrime(bitlens, modulus, t1, hints?.Aux1);
        (xp2, p2) = _primeGenerator.GetPrime(bitlens, modulus, t2, hints?.Aux2);

        var pResult = PrimeGeneratorHelper.ProbablePrimeFactor(
                    _primeGenerator, _pBound, a, p1, p2, modulus, exponent, tag, 
                            hints?.PrimeGen, hints?.PrimeTest);
        //if (!pResult.Success) {
        //    throw new CryptographicException();
        //    }
        p = pResult.Prime;
        xp = pResult.XPrime;

        return (p, xp, xp1, xp2, p1, p2);
        }


    private PrimeGeneratorResult GeneratePrimes(PrimeGeneratorParameters param,
                    RsaGenerationHints hintsIn = null) {
        BigInteger p, p1, p2, q, q1, q2, xp, xq, xp1, xp2, xq1, xq2;

        (p, xp, xp1, xp2, p1, p2) = GetQualifiedPrime(
                param.BitLens[0], param.Modulus, param.A, param.PublicE, "p", hintsIn?.P);

        do {
            (q, xq, xq1, xq2, q1, q2) = GetQualifiedPrime(
                param.BitLens[0], param.Modulus, param.A, param.PublicE, "q", hintsIn?.Q);

            // 6
            } while (BigInteger.Abs(xp - xq) <= NumberTheory.Pow2(param.Modulus / 2 - 100) ||
                 BigInteger.Abs(p - q) <= NumberTheory.Pow2(param.Modulus / 2 - 100));

        var auxValues = new AuxiliaryResult { XP1 = xp1, XP2 = xp2, XP = xp, XQ1 = xq1, XQ2 = xq2, XQ = xq };
        var primePair = new PrimePair { P = p, Q = q };
        return new PrimeGeneratorResult(primePair, auxValues);
        }
    }

