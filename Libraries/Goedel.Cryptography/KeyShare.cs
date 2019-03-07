//   Copyright © 2015 by Comodo Group Inc.
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
//  
//  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Goedel.Utilities;

namespace Goedel.Cryptography {

    /// <summary>
    /// Represents a secret key that may be split into or reformed from 
    /// a collection of shares.
    /// </summary>
    public class Secret {

        /// <summary>
        /// Size of key in bits.
        /// </summary>
        public int KeyBits => Key.Length * 8;

        /// <summary>
        /// Size of key in bytes;
        /// </summary>
        public int KeyBytes => Key.Length;

        /// <summary>
        /// The Key value
        /// </summary>
        public byte[] Key;

        /// <summary>
        /// The Key Value as a Base32 encoded string.
        /// </summary>
        public virtual string UDFKey => Cryptography.UDF.SymmetricKey(Key);

        ///<summary>The UDF identifier of the secret value.</summary>
        public string UDFIdentifier => Cryptography.UDF.ContentDigestOfUDF(UDFKey, bits:KeyBits*2);

        /// <summary>
        /// Create a new random secret with the specified number of bits.
        /// </summary>
        /// <param name="bits">Nyumber of bits in the secret</param>
        public Secret(int bits) => Key = CryptoCatalog.GetBits(bits);

        /// <summary>
        /// Create a secret from the specified key value.
        /// </summary>
        /// <param name="key">The key value.</param>
        public Secret(byte[] key) => this.Key = key;


        /// <summary>
        /// Create a secret from the specified key value.
        /// </summary>
        /// <param name="udf">The key value as a UDF.</param>
        public Secret(string udf) => this.Key = UDF.SymmetricKey(udf);

        /// <summary>
        /// Recreate a secret from the specified shares.
        /// </summary>
        /// <param name="shares">The shares to be recombined.</param>
        public Secret(KeyShare[] shares) => Key = Combine(shares);

        /// <summary>
        /// Recreate a secret from shares specified as Base32 encoded strings.
        /// </summary>
        /// <param name="shares">The shares to be recombined.</param>
        public Secret(IEnumerable<string> shares) {
            var KeyShares = new KeyShare[shares.Count()];
            int i = 0;
            foreach (var Share in shares) {
                KeyShares[i++] = new KeyShare(Share);
                }

            Key = Combine(KeyShares);
            }



        /// <summary>
        /// Constructor for use in inherited classes.
        /// </summary>
        protected Secret() {
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
        public override bool Equals(System.Object obj) {
            if (obj == null) {
                return false;
                }
            if (!(obj is Secret p)) {
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

        ///<summary>The set of prime offset values to be added to 32^(n) to give the
        ///discrete modulus for secrets of up to 32n bits.</summary>
        readonly static int[] PrimeValues = new int[] {
            15,
            13,
            61,
            51,
            7,
            133,
            735,
            297,
            127,
            27,
            55,
            231,
            235,
            211,
            165,
            75,
            };

        /// <summary>
        /// Return the prime number that is strictly greater than 2^n where n is 
        /// the smallest integer multiple of 32 greater or equal to <paramref name="bits"/>.
        /// </summary>
        /// <param name="bits">The number of bits to return the prime value for.</param>
        /// <param name="exponent">The power of 32</param>
        /// <returns>The prime number.</returns>
        public static BigInteger GetPrime(int bits, out BigInteger exponent, out int index) {
            Assert.True(bits > 0 & bits <= 512, KeySizeNotSupported.Throw);

            index = (bits + 31) / 32;
            exponent = BigInteger.Pow(2, 32 * index);
            return exponent + new BigInteger(PrimeValues[index-1]);
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
        public KeyShare[] Split(int n, int k) => Split(n, k, out var _);

        /// <summary>
        /// Create a set of N key shares with a quorum of K.
        /// </summary>
        /// <param name="n">Number of key shares to create (max is 15).</param>
        /// <param name="k">Quorum of key shares required to reconstruct the secret.</param>
        /// <param name="polynomial">The polynomial co-efficients generated.</param>
        /// <returns>The key shares created.</returns>
        public KeyShare[] Split(int n, int k, out BigInteger[] polynomial) {
            Assert.False(k > n, QuorumExceedsShares.Throw);
            Assert.False(k < 1, QuorumInsufficient.Throw);
            Assert.False(n < 1, SharesInsufficient.Throw);
            Assert.False(n > 15, QuorumExceeded.Throw);
            Assert.False(k > 15, QuorumDegreeExceeded.Throw);

            polynomial = new BigInteger[k];
            polynomial[0] = Key.BigIntegerBigEndian();
            Console.WriteLine("Key = {0} ", polynomial[0]);

            var modulus = GetPrime(KeyBits, out var secretMax, out var shareChunks);
            var keyShares = new KeyShare[n];

            for (int i = 2; i < k; i++) {
                polynomial[i] = BigNumber.Random(KeyBits);
                }

            var search = true;
            while (search) {
                if (k > 1) {
                    polynomial[1] = BigNumber.Random(KeyBits);
                    }
                search = false;
                for (int i = 0; i < n; i++) {
                    var d = PolyMod(i + 1, polynomial, modulus);
                    if (d < secretMax) {
                        keyShares[i] = new KeyShare((k * 16) + i, d, 4*shareChunks);
                        Console.WriteLine("Share {0} = {1}", i, d);
                        }
                    else {
                        // Can't represent this, abort!
                        search = true;
                        i = n;
                        }
                    }
                }

            return keyShares;
            }

        // Note here that since BigInteger is a structure, not a class, we don't
        // need to worry about boxing or call by value issues
        BigInteger PolyMod(int x, BigInteger[] polyNomial, BigInteger modulus) {
            int power = 1;  // expect the optimizer to catch
            var result = polyNomial[0];
            for (int i = 1; i < polyNomial.Length; i++) {
                power = power * x;
                result = (modulus + result + polyNomial[i] * power) % modulus;
                }

            return result;
            }


        static byte[] Combine(KeyShare[] Shares) {

            var threshold = Shares[0].Threshold;
            foreach (var Share in Shares) {
                Assert.True(Share.Threshold == threshold, MismatchedShares.Throw);
                }
            return CombineNK(Shares);
            }


        static byte[] CombineNK(KeyShare[] shares) {
            var threshold = shares[0].Threshold;
            Assert.False(shares.Length < threshold, InsufficientShares.Throw);

            var secretBits = shares[0].KeyBits - 8;

            Console.WriteLine($"Recovered Share {shares[0].Value}");

            var modulus = GetPrime(secretBits, out var secretMax, out var shareChunks);
            BigInteger accum = 0;

            for (var formula = 0; formula < threshold; formula++) {

                var value = shares[formula].Value;
                Console.WriteLine("Value = {0} ", value);

                BigInteger numerator = 1, denominator = 1;
                for (var count = 0; count < threshold; count++) {
                    if (formula == count) {
                        continue;  // If not the same value
                        }

                    var start = shares[formula].Index;
                    var next = shares[count].Index;

                    numerator = (numerator * -next) % modulus;
                    denominator = (denominator * (start - next)) % modulus;
                    }

                var InvDenominator = ModInverse(denominator, modulus);

                accum = (accum + (value * numerator * InvDenominator)).Mod(modulus);
                }

            return accum.ToByteArrayBigEndian(shareChunks*4);
            }


        // Not the fastest way to do modular inverse but the easiest with the
        // available tools in .net
        static BigInteger ModInverse(BigInteger k, BigInteger m) {
            var m2 = m - 2;
            if (k < 0) {
                k = k + m;
                }

            return BigInteger.ModPow(k, m2, m);
            }



        private static byte[] GetBytes(BigInteger input) {
            var bytes = new byte[16];
            var source = input.ToByteArray();
            int length = source.Length < 16 ? source.Length : 16;
            Array.Copy(source, bytes, length);
            return bytes;

            }


        }



    /// <summary>
    /// A member of a key share collection.
    /// </summary>
    public class KeyShare : Secret {

        /// <summary>
        /// The Key Value as a Base32 encoded string.
        /// </summary>
        public override string UDFKey => Cryptography.UDF.KeyShare(Key);


        int First;

        /// <summary>
        /// Quorum required to recombine the key shares to recover the secret.
        /// </summary>
        public int Threshold => First / 16;

        /// <summary>
        /// Index of this key share in the collection.
        /// </summary>
        public int Index => (First & 0xf) + 1;

        /// <summary>
        /// The key share data.
        /// </summary>
        public byte[] Data { get; set; }

        /// <summary>
        /// The key share data as a BigInteger.
        /// </summary>
        public BigInteger Value => Data.BigIntegerBigEndian();


        void KeyValue(int index, byte[] data) {
            First = index;
            Data = data;
            Key = new byte[data.Length + 1];
            Key[0] = (byte)First;
            Array.Copy(data, 0, Key, 1, data.Length);
            }


        ///// <summary>
        ///// Create a secret from the specified key value.
        ///// </summary>
        ///// <param name="udf">The key value as a UDF.</param>
        //public KeyShare(string udf) => this.Key = UDF.SymmetricKey(udf);


        /// <summary>
        /// Construct a key share with the specified secret value.
        /// </summary>
        /// <param name="text">The secret value in text form.</param>
        public KeyShare(string text) {
            var buffer = BaseConvert.FromBase32(text);
            Assert.True(buffer[0] == (byte)UDFTypeIdentifier.ShamirSecret);
            var result = new byte[buffer.Length - 2];
            Buffer.BlockCopy(buffer, 2, result, 0, buffer.Length - 2);
            KeyValue(buffer[1], result);
            }


        /// <summary>
        /// Construct a key share with the specified secret value and index.
        /// </summary>
        /// <param name="index">The key share index and threshold.</param>
        /// <param name="value">The key share value/</param>
        /// <param name="bytes">Number of bytes in the share to be constructed.</param>
        public KeyShare(int index, BigInteger value, int bytes) =>
                KeyValue(index, value.ToByteArrayBigEndian(bytes));


        /// <summary>
        /// Construct a key share with the specified secret value and index.
        /// </summary>
        /// <param name="index">The key share index and threshold.</param>
        /// <param name="data">The key share value/</param>
        public KeyShare(int index, byte[] data) => KeyValue(index, data);

        }
    }
