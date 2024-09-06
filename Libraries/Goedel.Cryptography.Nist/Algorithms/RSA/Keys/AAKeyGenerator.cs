
namespace Goedel.Cryptography.Nist;

public class CrtKeyComposer  {

    IFips186_5PrimeGenerator generator;


    public CrtKeyComposer(IPrimeGenerator primeGenerator) {

        generator = new AllProbablePrimesWithConditionsGenerator(primeGenerator);
        }

    public RsaFipsKeyPair GenerateKeyPair(int keySize) {
        var params1 = PrimeGeneratorParameters.GetPrimeGeneratorParameters(keySize);
        var primes = generator.GeneratePrimesFips186_5(params1);
        var result = ComposeKey(params1.PublicE, primes.Primes, params1.Modulus/8);
        return result;
        }


    public static RsaFipsKeyPair ComposeKey(BigInteger e, PrimePair primes, int keySize) {
        var n = primes.P * primes.Q;

        // Checks to avoid exceptions
        if (primes.P == 0 || primes.Q == 0 || e == 0) {
            throw new Exception("Invalid p, q, e provided for CRT Key");
            }


        var d = e.ModularInverse(NumberTheory.LCM(primes.P - 1, primes.Q - 1));
        var DMP1 = d % (primes.P - 1);
        var DMQ1 = d % (primes.Q - 1);
        var IQMP = primes.Q.ModularInverse(primes.P);

        var primeSize = keySize / 2;

        //var result = new RSAParameters() {
        //    Modulus = n.ToByteArrayBigEndian(keySize),
        //    Exponent = e.ToByteArrayBigEndian(3),

        //    P = primes.P.ToByteArrayBigEndian(primeSize),
        //    Q = primes.Q.ToByteArrayBigEndian(primeSize),
        //    D = d.ToByteArrayBigEndian(keySize),
        //    DP = DMP1.ToByteArrayBigEndian(keySize),
        //    DQ = DMQ1.ToByteArrayBigEndian(keySize),
        //    InverseQ = IQMP.ToByteArrayBigEndian(keySize),
        //    };
        //return result;

        return new RsaFipsKeyPair {
            PrivKey = new PrivateKeyRsaCrt {
                DMP1 = d % (primes.P - 1),
                DMQ1 = d % (primes.Q - 1),
                IQMP = primes.Q.ModularInverse(primes.P),
                P = primes.P,
                Q = primes.Q,
                D = d
                },
            PubKey = new RsaPublicKey {
                E = e,
                N = n
                }
            };
        }
    }

