#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion



namespace Goedel.Cryptography;

/// <summary>
/// Base class for Shamir Shared Secrets.
/// </summary>
public class Shared {

    ///<summary>The prime modulus</summary>
    public BigInteger Prime;

    ///<summary>The secret value.</summary>
    public virtual BigInteger Value { get; set; }

    /// <summary>
    /// Base constructor.
    /// </summary>
    public Shared() {
        }

    /// <summary>
    /// Construct a secret sharing of <paramref name="value"/> using modulus 
    /// <paramref name="prime"/>.
    /// </summary>
    /// <param name="value">The secret value to share.</param>
    /// <param name="prime">The prime modulus.</param>
    public Shared(BigInteger value, BigInteger prime) {
        Value = value;
        Prime = prime;
        }

    /// <summary>
    /// Create a set of N key shares with a quorum of K.
    /// </summary>
    /// <param name="keyShares">The key shares pre-initialized with the x coordinate value.</param>
    /// <param name="t">Quorum of key shares required to reconstruct the secret.</param>
    /// <param name="polynomial">The polynomial co-efficients generated.</param>
    /// <returns>The key shares created.</returns>
    public virtual void Split(KeyShare[] keyShares, int t, out BigInteger[] polynomial) {
        var n = keyShares.Length;

        polynomial = new BigInteger[t];
        polynomial[0] = Value;

        //Console.WriteLine("Key = {0} ", polynomial[0]);

        for (int i = 1; i < t; i++) {
            polynomial[i] = BigNumber.Random(Prime);
            }

        for (int i = 0; i < n; i++) {
            keyShares[i].Value = PolyMod(keyShares[i].Index, polynomial, Prime);
            keyShares[i].Prime = Prime;
            }

        return;
        }

    // Note here that since BigInteger is a structure, not a class, we don't
    // need to worry about boxing or call by value issues
    static BigInteger PolyMod(BigInteger x, BigInteger[] polyNomial, BigInteger modulus) {
        BigInteger power = 1;  // expect the optimizer to catch
        var result = polyNomial[0];
        for (int i = 1; i < polyNomial.Length; i++) {
            power = (x * power) % modulus;
            result = (modulus + result + polyNomial[i] * power) % modulus;
            }

        return result;
        }

    /// <summary>
    /// Combine the shares <paramref name="shares"/> using the prime modulus 
    /// <paramref name="modulus"/> with a threshold of <paramref name="threshold"/>
    /// </summary>
    /// <param name="shares">The shares to construct the coefficient from.</param>
    /// <param name="modulus">The prime modulus.</param>
    /// <param name="threshold">The threshold value.</param>
    /// <returns>The recovered value.</returns>
    public static BigInteger CombineNT(KeyShare[] shares,
                BigInteger modulus,
                int threshold) {
        BigInteger accum = 0;

        for (var formula = 0; formula < threshold; formula++) {

            var lagrange = Lagrange(shares, formula, modulus);
            var value = shares[formula].Value;

            accum = (accum + (value * lagrange)).Mod(modulus);
            }
        return accum;
        }

    /// <summary>
    /// Construct the Lagrange coefficient for the share <paramref name="index"/> among
    /// the shares <paramref name="shares"/> in the prime modulus <paramref name="modulus"/>.
    /// </summary>
    /// <param name="shares">The shares to construct the coefficient from.</param>
    /// <param name="index">The index of the share to construct the coefficient for.</param>
    /// <param name="modulus">The prime modulus.</param>
    /// <returns>The Lagrange coefficient</returns>
    public static BigInteger Lagrange(KeyShare[] shares,
                int index,
                BigInteger modulus) {

        BigInteger numerator = 1, denominator = 1;
        var start = shares[index].Index;

        for (var count = 0; count < shares.Length; count++) {
            if (index == count) {
                continue;  // If not the same value
                }

            var next = shares[count].Index;

            numerator = (numerator * -next).Mod(modulus);
            denominator = (denominator * (start - next)).Mod(modulus);

            //Console.WriteLine($"Numerator {numerator}");
            //Console.WriteLine($"Denominator {denominator}");
            }

        var invDenominator = ModInverse(denominator, modulus);
        var result = (numerator * invDenominator).Mod(modulus);

        //Console.WriteLine($"InvDenominator {invDenominator}");
        //Console.WriteLine($"result {result}");

        return result;
        }


    // Not the fastest way to do modular inverse but the easiest with the
    // available tools in .net
    static BigInteger ModInverse(BigInteger k, BigInteger m) {
        var m2 = m - 2;
        if (k < 0) {
            k += m;
            }

        return BigInteger.ModPow(k, m2, m);
        }


    }
/// <summary>
/// Represents a secret key that may be split into or reformed from 
/// a collection of shares.
/// </summary>
public class SharedSecret : Shared {

    /// <summary>
    /// Size of key in bits. This will determine the size of the prime
    /// </summary>
    public virtual int KeyBits => Key.Length * 8;

    /// <summary>
    /// Size of key in bytes;
    /// </summary>
    public int KeyBytes => Key.Length;

    /// <summary>
    /// The Key value
    /// </summary>
    public virtual byte[] Key { get; set; }

    /// <summary>
    /// The Key Value as a Base32 encoded string.
    /// </summary>
    public virtual string UDFKey => Udf.PresentationBase32(Key, Key.Length * 8);

    ///<summary>The UDF identifier of the secret value.</summary>
    public string UDFIdentifier => Udf.ContentDigestOfUDF(UDFKey, bits: KeyBits * 2);

    ///<summary>The maximum allowed secret value.</summary>
    public BigInteger SecretMax;

    ///<summary>The number of 32 bit words used to represent the value.</summary>
    public int ShareBytes;


    /// <summary>
    /// Create a new random secret with the specified number of bits.
    /// </summary>
    /// <param name="bits">Nyumber of bits in the secret</param>
    public SharedSecret(int bits) : this(CryptoCatalog.GetBits(bits)) {
        }




    /// <summary>
    /// Create a secret from the specified key value.
    /// </summary>
    /// <param name="key">The key value.</param>
    public SharedSecret(byte[] key) {
        Key = key;
        Value = key.BigIntegerBigEndian();
        Prime = GetPrime(KeyBits, out SecretMax, out ShareBytes);
        }


    /// <summary>
    /// Create a secret from the specified key value.
    /// </summary>
    /// <param name="udf">The key value as a UDF.</param>
    public SharedSecret(string udf) => this.Key = Udf.SymmetricKey(udf);

    /// <summary>
    /// Recreate a secret from the specified shares.
    /// </summary>
    /// <param name="shares">The shares to be recombined.</param>
    public SharedSecret(KeyShareSymmetric[] shares) => Key = Combine(shares);

    /// <summary>
    /// Recreate a secret from shares specified as Base32 encoded strings.
    /// </summary>
    /// <param name="shares">The shares to be recombined.</param>
    public SharedSecret(IEnumerable<string> shares) {
        var KeyShares = new KeyShareSymmetric[shares.Count()];
        int i = 0;
        foreach (var Share in shares) {
            KeyShares[i++] = new KeyShareSymmetric(Share);
            }

        Key = Combine(KeyShares);
        }



    /// <summary>
    /// Constructor for use in inherited classes.
    /// </summary>
    protected SharedSecret() {
        }

    // Override this because we override the Equals operator
    /// <summary>
    /// Hash code of the current class.
    /// </summary>
    /// <returns>Hash code of object instance.</returns>
    public override int GetHashCode() => UDFKey.GetHashCode();

    /// <summary>Test for equality
    /// </summary>
    /// <param name="obj">The secret to test against</param>
    /// <returns>true if the parameter has the same key value, false otherwise.</returns>
    public override bool Equals(object? obj) {
        if (obj == null) {
            return false;
            }
        if (obj is not SharedSecret p) {
            return false;
            }
        if (KeyBytes != p.KeyBytes) {
            return false;
            }
        for (int i = 0; i < KeyBytes; i++) {
            if (Key[i] != p.Key[i]) {
                return false;
                }
            }

        return true;
        }


    ///<summary>The set of prime offset values to be added to 8^(n) to give the
    ///discrete modulus for secrets of up to 8n bits.</summary>
    public readonly static int[] PrimeOffsetNext = new int[] {
            1,            1,         43,          15,
            15,          21,         81,          13,
            15,          13,          7,          61,
            111,         25,        451,          51,
            85,         175,        253,           7,
            87,         427,         27,         133,
            235,        375,        423,         735,
            357,        115,         81,         297,
            175,         57,         45,         127,
            61,          37,         91,          27,
            15,         241,        231,          55,
            105,        127,        115,         231,
            207,        181,         37,         235,
            163,       1093,        187,         211,
            21,         841,        445,         165,
            777,        583,        133,          75
            };

    ///<summary>The set of prime offset values to be subtracted from to 8^(n+1) 
    ///to give the discrete modulus for secrets of up to 8n bits.</summary>
    public readonly static int[] PrimeOffsetPrevious = new int[] {
            5,           15,          3,           5,
            87,          59,          5,          59,
            93,          65,        299,          17,
            17,          75,        119,         159,
            113,         83,         17,          47,
            257,        233,         33,         237,
            75,         299,        377,          63,
            567,        467,        237,         189,
            275,        237,         47,         167,
            285,         75,        203,         197,
            155,          3,        119,         657,
            719,        315,         57,         317,
            107,        593,       1005,         435,
            389,        299,         33,         203,
            627,        437,        209,          47,
            17,         257,        503,         569
            };

    /// <summary>
    /// Return the prime number that is strictly greater than 2^n where n is 
    /// the smallest integer multiple of 32 greater or equal to <paramref name="bits"/>.
    /// </summary>
    /// <param name="bits">The number of bits to return the prime value for.</param>
    /// <param name="exponent">The power of 32</param>
    /// <param name="index">The number of 32 bit blocks required.</param>
    /// <returns>The prime number.</returns>
    public static BigInteger GetPrime(int bits, out BigInteger exponent, out int index) {
        Assert.AssertTrue(bits > 0 & bits <= 512, KeySizeNotSupported.Throw);

        index = (bits + 7) / 8;
        exponent = BigInteger.Pow(2, 8 * index);
        var result = exponent + new BigInteger(PrimeOffsetNext[index - 1]);

        result.IsProbablePrime().VerifyTrue(Internal.Throw);

        return result;
        }


    //// Right now, this is not completely general as we require there
    //// to be at least two shares and the quorum to be at least two.

    //private BigInteger MakePositive(byte[] data) {
    //    var Data1 = new byte[data.Length + 1];
    //    Array.Copy(data, Data1, data.Length);
    //    return new BigInteger(Data1);
    //    }

    /// <summary>
    /// Create a set of N key shares with a quorum of K.
    /// </summary>
    /// <param name="n">Number of key shares to create (max is 32).</param>
    /// <param name="k">Quorum of key shares required to reconstruct the secret.</param>
    /// <returns>The key shares created.</returns>
    public KeyShareSymmetric[] Split(int n, int k) => Split(n, k, out var _);

    /// <summary>
    /// Create a set of N key shares with a quorum of K.
    /// </summary>
    /// <param name="n">Number of key shares to create (max is 15).</param>
    /// <param name="k">Quorum of key shares required to reconstruct the secret.</param>
    /// <param name="polynomial">The polynomial co-efficients generated.</param>
    /// <returns>The key shares created.</returns>
    public KeyShareSymmetric[] Split(int n, int k, out BigInteger[] polynomial) {
        Assert.AssertFalse(k > n, QuorumExceedsShares.Throw);
        Assert.AssertFalse(k < 1, QuorumInsufficient.Throw);
        Assert.AssertFalse(n < 1, SharesInsufficient.Throw);
        Assert.AssertFalse(n > 15, QuorumExceeded.Throw);
        Assert.AssertFalse(k > 15, QuorumDegreeExceeded.Throw);

        var keyShares = new KeyShareSymmetric[n];

        for (int i = 0; i < n; i++) {
            keyShares[i] = new KeyShareSymmetric(i, k, ShareBytes);
            }
        Split(keyShares, k, out polynomial);

        // Check that all our share chunks will fit into a UDF
        for (var search = true; search;
            Split(keyShares, k, out polynomial)) {
            search = false;
            for (int i = 0; i < n; i++) {
                search = search && keyShares[i].Value < SecretMax;
                }
            }

        return keyShares;
        }

    static byte[] Combine(KeyShareSymmetric[] Shares) {

        var threshold = Shares[0].Threshold;
        foreach (var Share in Shares) {
            Assert.AssertTrue(Share.Threshold == threshold, MismatchedShares.Throw);
            }
        return CombineNK(Shares);
        }


    static byte[] CombineNK(KeyShareSymmetric[] shares) {
        var threshold = shares[0].Threshold;
        Assert.AssertFalse(shares.Length < threshold, InsufficientShares.Throw);

        var secretBits = shares[0].KeyBits - 8;
        var modulus = GetPrime(secretBits, out var _, out var shareChunks);

        var accum = CombineNT(shares, modulus, threshold);
        //Console.WriteLine($"Reconstructed value = {accum}");
        return accum.ToByteArrayBigEndian(shareChunks);
        }

    /// <summary>
    /// Parse the property <see cref="Key"/> as a binary UDF value and return the
    /// values.
    /// </summary>
    /// <returns>The UDF type, algorithm and data sections</returns>
    public (UdfAlgorithmIdentifier, byte[]) ParseKey() {
        int start;
        for (start = 0; (start < Key.Length) && Key[start] == 0; start++) {
            }
        (Key[start++] == (byte)UdfTypeIdentifier.DerivedKey).AssertTrue(
                    InvalidRecoveredData.Throw);


        var udfAlgorithm = (UdfAlgorithmIdentifier)(Key[start++] * 0x100 + Key[start++]);

        var length = Key.Length - start;
        var masterSecret = new byte[length];
        Buffer.BlockCopy(Key, start, masterSecret, 0, length);

        return (udfAlgorithm, masterSecret);
        }



    }



/// <summary>
/// A member of a key share collection.
/// </summary>
public class KeyShare : SharedSecret {
    ///<summary>The index value</summary>
    public virtual BigInteger Index { get; set; }

    //public virtual BigInteger Value { get; }

    /// <summary>
    /// Calculate the Lagrange coefficient for the shares <paramref name="shares"/> and
    /// index <paramref name="i"/>.
    /// </summary>
    /// <param name="shares">The shares to calculate the index for.</param>
    /// <param name="i">The x value.</param>
    /// <returns>The Lagrange coefficient.</returns>
    public BigInteger Lagrange(KeyShare[] shares, int i) => Lagrange(shares, i, Prime);


    }

/// <summary>
/// A member of a key share collection.
/// </summary>
public class KeyShareSymmetric : KeyShare {
    /// <summary>
    /// The Key Value as a Base32 encoded string.
    /// </summary>
    public override string UDFKey => Cryptography.Udf.KeyShare(Key);

    ///<summary>The value of the first byte specifying the threshold and index values</summary>
    public int First;

    /// <summary>
    /// Quorum required to recombine the key shares to recover the secret.
    /// </summary>
    public int Threshold => First / 16;

    /// <summary>
    /// Index of this key share in the collection.
    /// </summary>
    public override BigInteger Index => (First & 0xf) + 1;

    /// <summary>
    /// The full key share data.
    /// </summary>
    public override byte[] Key {
        get => key;
        set {
            key = value;
            data = new byte[key.Length - 1];
            Array.Copy(key, 1, data, 0, key.Length - 1);
            First = key[0];
            valueStore = data.BigIntegerBigEndian();
            }
        }

    byte[] key;

    /// <summary>
    /// The key share data (stripped of the quorum and index information)
    /// </summary>
    public byte[] Data {
        get => data;
        set {
            data = value;
            key = new byte[data.Length + 1];
            key[0] = (byte)First;
            Array.Copy(data, 0, key, 1, data.Length);
            valueStore = data.BigIntegerBigEndian();
            }
        }
    byte[] data;

    ///<summary>The key share value.</summary>
    public override BigInteger Value {
        get => valueStore;
        set {
            valueStore = value;
            data = Value.ToByteArrayBigEndian(ShareBytes);
            key = new byte[data.Length + 1];
            key[0] = (byte)First;
            Array.Copy(data, 0, key, 1, data.Length);
            }
        }
    BigInteger valueStore;

    /// <summary>
    /// Construct a key share with index <paramref name="index"/>, sharing a secret of 
    /// <paramref name="shareBytes"/> bytes and a threshold of <paramref name="threshold"/>.
    /// </summary>
    /// <param name="index">The x value of the share.</param>
    /// <param name="threshold">The threshold value for the shares.</param>
    /// <param name="shareBytes">The number of bytes shared.</param>
    public KeyShareSymmetric(int index, int threshold, int shareBytes) {
        First = index + 0x10 * threshold;
        ShareBytes = shareBytes;
        }

    /// <summary>
    /// Construct a key share with the specified secret value.
    /// </summary>
    /// <param name="text">The secret value in text form.</param>
    public KeyShareSymmetric(string text) {
        var buffer = Udf.Parse(text, out var code);
        Assert.AssertTrue(code == (byte)UdfTypeIdentifier.ShamirSecret, KeyTypeMismatch.Throw);
        Key = buffer;
        }


    /// <summary>
    /// Construct a key share with the specified secret value and index.
    /// </summary>
    /// <param name="index">The key share index and threshold.</param>
    /// <param name="value">The key share value/</param>
    /// <param name="bytes">Number of bytes in the share to be constructed.</param>
    public KeyShareSymmetric(int index, BigInteger value, int bytes) {
        First = index;
        ShareBytes = bytes;
        Value = value;
        }


    /// <summary>
    /// Construct a key share with the specified secret value and index.
    /// </summary>
    /// <param name="index">The key share index and threshold.</param>
    /// <param name="data">The key share value/</param>
    public KeyShareSymmetric(int index, byte[] data) {
        First = index;
        Data = data;

        }
    }
