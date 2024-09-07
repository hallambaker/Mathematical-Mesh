
namespace Goedel.Cryptography.Nist;





public class AllProbablePrimesWithConditionsGenerator : IFips186_5PrimeGenerator {
    private readonly IEntropyProvider _entropyProvider;
    private readonly IPrimeGenerator _primeGenerator;
    private int _pBound = 5;

    public AllProbablePrimesWithConditionsGenerator(
                    IPrimeGenerator primeGenerator) {
        _primeGenerator = primeGenerator;
        }

    public PrimeGeneratorResult GeneratePrimesFips186_5(PrimeGeneratorParameters param) {
        _pBound = 20;


        // Don't need the guards as we have declared this an internal class.
        //// Rethrow on exception
        //PrimeGeneratorGuard.AgainstInvalidModulusFips186_5(param.Modulus);
        //PrimeGeneratorGuard.AgainstInvalidPublicExponent(param.PublicE);
        //PrimeGeneratorGuard.AgainstInvalidBitlens(param.Modulus, param.BitLens);

        return GeneratePrimes(param);
        }

    private (BigInteger, BigInteger, BigInteger, BigInteger, BigInteger, BigInteger) GetQualifiedPrime(
                    int bitlens, int modulus, int a, BigInteger exponent, string tag) {

        BigInteger p, p1, p2, xp, xp1, xp2;

        var t1 = tag + "1";
        var t2 = tag + "2";

        (xp1, p1) = _primeGenerator.GetPrime(bitlens, modulus, t1);
        (xp2, p2) = _primeGenerator.GetPrime(bitlens, modulus, t2);

        var pResult = PrimeGeneratorHelper.ProbablePrimeFactor(_primeGenerator, _pBound, a, p1, p2, modulus, exponent, tag);
        //if (!pResult.Success) {
        //    throw new CryptographicException();
        //    }
        p = pResult.Prime;
        xp = pResult.XPrime;

        return (p, xp, xp1, xp2, p1, p2);
        }


    private PrimeGeneratorResult GeneratePrimes(PrimeGeneratorParameters param) {
        BigInteger p, p1, p2, q, q1, q2, xp, xq, xp1, xp2, xq1, xq2;

        (p, xp, xp1, xp2, p1, p2) = GetQualifiedPrime(param.BitLens[0], param.Modulus, param.A, param.PublicE, "p");

        do {
            (q, xq, xq1, xq2, q1, q2) = GetQualifiedPrime(param.BitLens[0], param.Modulus, param.A, param.PublicE, "q");

            // 6
            } while (BigInteger.Abs(xp - xq) <= NumberTheory.Pow2(param.Modulus / 2 - 100) ||
                 BigInteger.Abs(p - q) <= NumberTheory.Pow2(param.Modulus / 2 - 100));

        var auxValues = new AuxiliaryResult { XP1 = xp1, XP2 = xp2, XP = xp, XQ1 = xq1, XQ2 = xq2, XQ = xq };
        var primePair = new PrimePair { P = p, Q = q };
        return new PrimeGeneratorResult(primePair, auxValues);
        }
    }

