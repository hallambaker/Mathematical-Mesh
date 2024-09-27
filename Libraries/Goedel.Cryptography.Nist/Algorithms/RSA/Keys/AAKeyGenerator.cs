
namespace Goedel.Cryptography.Nist;




/// <summary>
/// RSA Prime Generation Hints.
/// </summary>
public record RsaGenerationHints {

    /// <summary>
    /// Hints for a qualified prime.
    /// </summary>
    public record PrimeHints {
        ///<summary>Number of test operations.</summary> 
        public int PrimeTest;
        ///<summary>Tests of aux1</summary> 
        public int Aux1;
        ///<summary>Tests of Aux 2</summary> 
        public int Aux2;
        ///<summary>Number of candidate primes regenerated.</summary> 
        public int PrimeGen;
        }


    public PrimeHints Q = new();
    public PrimeHints P = new();

    /// <summary>
    /// Create an instance from the encoded string <paramref name="hints"/>
    /// </summary>
    /// <param name="hints">Base32 encoded hints.</param>
    public RsaGenerationHints(string hints) {
        var bytes = hints.FromBase32();
        int i = 0;
        P.PrimeTest = GetHint(bytes, ref i);
        Q.PrimeTest = GetHint(bytes, ref i);

        P.Aux1 = GetHint(bytes, ref i);
        Q.Aux1 = GetHint(bytes, ref i);

        P.Aux2 = GetHint(bytes, ref i);
        Q.Aux2 = GetHint(bytes, ref i);

        P.PrimeGen = GetHint(bytes, ref i);
        Q.PrimeGen = GetHint(bytes, ref i);
        }

    /// <summary>
    /// Create an instance from a dictionary of labeled call counts..
    /// </summary>
    /// <param name="callCount">The dictionary of call counts.</param>
    public RsaGenerationHints(Dictionary<string, int> callCount) {
        callCount.TryGetValue("p", out P.PrimeTest);
        callCount.TryGetValue("q", out Q.PrimeTest);

        callCount.TryGetValue("q1", out Q.Aux1);
        callCount.TryGetValue("p1", out P.Aux1);

        callCount.TryGetValue("q2", out Q.Aux2);
        callCount.TryGetValue("p2", out P.Aux2);

        callCount.TryGetValue("qq", out Q.PrimeGen);
        callCount.TryGetValue("pp", out P.PrimeGen);
        }


    static int GetHint(byte[] values, ref int index) {
        if (index >= values.Length) {
            return 0;
            }

        var x = values[index++];
        if (x < 0x80) {
            return x;
            }

        var xx = x & 0x7f;

        if (index >= values.Length) {
            return 0;
            }
        x = values[index++];

        xx = xx | ((x & 0x7f) <<7);
        if (x < 0x80) {
            return xx;
            }

        // Don't bother with more than three bytes
        if (index >= values.Length) {
            return 0;
            }
        x = values[index++];
        xx = xx | ((x & 0x7f) << 14);

        return xx;
        }

    /// <summary>
    /// Return the hints of string <paramref name="hints"/>
    /// </summary>
    /// <param name="hints">The string describing the hints.</param>
    /// <returns>The instance.</returns>
    public static RsaGenerationHints GetHints(string hints) {
        if (hints == null) {
            return null;
            }
        return new RsaGenerationHints(hints);
        }

    /// <summary>
    /// Convert the hints to anb encoded byte array.
    /// </summary>
    /// <returns></returns>
    public byte[] ToBytes() {
        var stream = new MemoryStream();
        Append(stream, P.PrimeTest);
        Append(stream, Q.PrimeTest);

        Append(stream, P.Aux1);
        Append(stream, Q.Aux1);

        Append(stream, P.Aux2);
        Append(stream, Q.Aux2);

        Append(stream, P.PrimeGen);
        Append(stream, Q.PrimeGen);

        return stream.ToArray();
        }


    void Append(MemoryStream stream, int value) {
        if (value > 0x3FFFFF) {
            stream.WriteByte((byte)0x83);
            stream.WriteByte((byte)0xFF);
            stream.WriteByte((byte)0x7F);
            }

        while (true) {
            if (value < 0x80) {
                stream.WriteByte((byte)value);
                return;
                }
            else {
                stream.WriteByte((byte)(0x80 | (value & 0x7f)));
                value = value >> 7;
                }
            }
        }

    ///<inheritdoc/>
    public override string ToString() => ToBytes().ToStringBase32(format: ConversionFormat.Dash4);

    }




public class CrtKeyComposer  {

    IFips186_5PrimeGenerator generator;


    public CrtKeyComposer(IPrimeGenerator primeGenerator) {

        generator = new AllProbablePrimesWithConditionsGenerator(primeGenerator);
        }

    public RsaFipsKeyPair GenerateKeyPair(int keySize,
                        RsaGenerationHints hintsIn = null) {
        var params1 = PrimeGeneratorParameters.GetPrimeGeneratorParameters(keySize);
        var primes = generator.GeneratePrimesFips186_5(params1, hintsIn);
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

