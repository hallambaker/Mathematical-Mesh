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
        public string Text => BaseConvert.ToStringUDF32(Key);
        /// <summary>
        /// Create a new random secret with the specified number of bits.
        /// </summary>
        /// <param name="Bits">Nyumber of bits in the secret</param>
        public Secret(int Bits) => Key = CryptoCatalog.GetBits(Bits);

        /// <summary>
        /// Create a secret from the specified key value.
        /// </summary>
        /// <param name="Key">The key value.</param>
        public Secret(byte[] Key) => this.Key = Key;

        /// <summary>
        /// Recreate a secret from the specified shares.
        /// </summary>
        /// <param name="Shares">The shares to be recombined.</param>
        public Secret(KeyShare[] Shares) => Key = Combine(Shares);

        /// <summary>
        /// Recreate a secret from shares specified as Base32 encoded strings.
        /// </summary>
        /// <param name="Shares">The shares to be recombined.</param>
        public Secret (IEnumerable<string> Shares) {
            var KeyShares = new KeyShare[Shares.Count()];
            int i = 0;
            foreach (var Share in Shares) {
                var Bytes = BaseConvert.FromBase32(Share);
                KeyShares[i++] = new KeyShare(Bytes);
                }

            this.Key = Combine(KeyShares);
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
        public override int GetHashCode() => Text.GetHashCode();

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

        // Right now, this is not completely general as we require there
        // to be at least two shares and the quorum to be at least two.

        private BigInteger MakePositive(byte[] Data) {
            var Data1 = new byte[Data.Length + 1];
            Array.Copy(Data, Data1, Data.Length);
            return new BigInteger(Data1);
            }

        /// <summary>
        /// Create a set of N key shares with a quorum of K.
        /// </summary>
        /// <param name="N">Number of key shares to create (max is 32).</param>
        /// <param name="K">Quorum of key shares required to reconstruct the secret.</param>
        /// <returns>The key shares created.</returns>
        public KeyShare[] Split(int N, int K) => Split(N, K, out var _);

        /// <summary>
        /// Create a set of N key shares with a quorum of K.
        /// </summary>
        /// <param name="N">Number of key shares to create (max is 32).</param>
        /// <param name="K">Quorum of key shares required to reconstruct the secret.</param>
        /// <param name="Polynomial">The polynomial co-efficients generated.</param>
        /// <returns>The key shares created.</returns>
        public KeyShare[] Split(int N, int K, out BigInteger[] Polynomial) {
            Assert.False(K > N, QuorumExceedsShares.Throw);
            Assert.False(K < 2, QuorumInsufficient.Throw); 
            Assert.False(N < 2, SharesInsufficient.Throw); 
            Assert.False(N > 15, QuorumExceeded.Throw);

            //if (N == K) {
            //    return Split(N); //Special case
            //    }

            Assert.False(K > 15, QuorumDegreeExceeded.Throw);

            Polynomial = new BigInteger[K];
            Polynomial[0] = MakePositive(Key);
            //Console.WriteLine("Key = {0} ", PolyNomial[0]);


            for (int i = 1; i < K; i++) {
                var Random = CryptoCatalog.GetBytes(KeyBytes);
                Polynomial[i] = MakePositive(Random);
                }

            Assert.False(KeyBits != 128, ImplementationLimit.Throw);


            // 2^129-25 is a pseudo Mersene prime
            var Modulus = BigInteger.Pow(2, 129) - 25;
            //Console.WriteLine("Modulus = {0} ", Modulus);

            var KeyShares = new KeyShare[N];
            for (int i = 0; i < N; i++) {
                var D = PolyMod(i + 1, Polynomial, Modulus);
                KeyShares[i] = new KeyShare((K * 16) + i, D);

                //Console.WriteLine("Share {0} = {1}", i, D);
                }

            return KeyShares;
            }

        // Note here that since BigInteger is a structure, not a class, we don't
        // need to worry about boxing or call by value issues
        BigInteger PolyMod(int x, BigInteger[] PolyNomial, BigInteger Modulus) {
            int Power = 1;  // expect the optimizer to catch
            BigInteger Result = PolyNomial[0];
            for (int i = 1; i < PolyNomial.Length; i++) {
                Power = Power * x;
                Result = (Modulus + Result + PolyNomial[i] * Power) % Modulus;
                }

            return Result;
            }


        /// <summary>
        /// Create a set of 2 key shares with a quorum of 2.
        /// </summary>
        /// <returns>The key shares created.</returns> 
        public KeyShare[] Split() => Split(2);

        /// <summary>
        /// Create a set of N key shares with a quorum of N.
        /// </summary>
        /// <param name="N">Number of key shares to create.</param>
        /// <returns>The key shares created.</returns> 
        public KeyShare[] Split(int N) {
            var KeyShares = new KeyShare[N];
            var Threshold = (16 * N) + 15;

            var XOR = new byte[KeyBytes];
            Array.Copy(Key, XOR, KeyBytes);
            for (int i = 0; i < N - 1; i++) {
                var Bytes = CryptoCatalog.GetBytes(KeyBytes);
                KeyShares[i] = new KeyShare(Threshold, Bytes);
                ArrayXOR(XOR, Bytes);
                }
            KeyShares[N - 1] = new KeyShare(Threshold, XOR);

            return KeyShares;
            }

        static void ArrayXOR(byte[] Base, byte[] Mix) {
            for (int j = 0; j < Base.Length; j++) {
                Base[j] = (byte)(Base[j] ^ Mix[j]);
                }
            }

        static void ArrayXOR1(byte[] Base, byte[] Mix) {
            for (int j = 0; j < Base.Length; j++) {
                Base[j] = (byte)(Base[j] ^ Mix[j + 1]);
                }
            }

        static byte[] Combine( KeyShare[] Shares) {
            //var KeyBytes = 16; //Shares[0].Key.Length;
            var Threshold = Shares[0].Threshold;
            foreach (var Share in Shares) {
                Assert.False(Share.Threshold != Threshold, MismatchedShares.Throw);
                }

            if (Shares[0].Index == 16) {
                return CombineN(Shares);
                }
            else {
                return CombineNK(Shares);
                }

            }

        static byte[] CombineN(KeyShare[] Shares) {
            var KeyBytes = Shares[0].Key.Length;
            byte[] Result = new byte[KeyBytes - 1];

            foreach (var Share in Shares) {
                ArrayXOR1(Result, Share.Key);
                }

            return Result;
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


        static byte[] CombineNK(KeyShare[] Shares) {
            
            var Threshold = Shares[0].Threshold;

            Assert.False (Shares.Length < Threshold, InsufficientShares.Throw);

            var Modulus = BigInteger.Pow(2, 129) - 25;
            BigInteger Accum = 0;

            //Console.WriteLine("Modulus = {0} ", Modulus);


            for (var Formula = 0; Formula < Threshold; Formula++) {

                var Value = Shares[Formula].Value;
                //Console.WriteLine("Value = {0} ", Value);

                BigInteger Numerator = 1, Denominator = 1;
                for (var Count = 0; Count < Threshold; Count++) {
                    if (Formula == Count) {
                        continue;  // If not the same value
                        }

                    var Start = Shares[Formula].Index;
                    var Next = Shares[Count].Index;

                    Numerator = (Numerator * -Next) % Modulus;
                    Denominator = (Denominator * (Start - Next)) % Modulus;
                    }

                var InvDenominator = ModInverse(Denominator, Modulus);

                //Console.WriteLine("   Numerator = {0}", Numerator);
                //Console.WriteLine("   Denominator = {0}", Denominator);
                //Console.WriteLine("   InvDenominator = {0}", InvDenominator);

                Accum = (Modulus + Modulus + Accum + (Value * Numerator * InvDenominator)) % Modulus;
                if (Accum < 0) {
                    //Console.WriteLine("Accum = {0}\n", Accum);
                    }
                }

            //Console.WriteLine("Accum = {0} ", Accum);
            return GetBytes (Accum);
            }

        private static byte[] GetBytes(BigInteger In) {
            var Bytes = new byte[16];
            var Source = In.ToByteArray();
            int Length = Source.Length < 16 ? Source.Length : 16;
            Array.Copy(Source, Bytes, Length);
            return Bytes;

            }

        }



    /// <summary>
    /// A member of a key share collection.
    /// </summary>
    public class KeyShare : Secret {
        /// <summary>
        /// Quorum required to recombine the key shares to recover the secret.
        /// </summary>

        public int Threshold => Key[0] / 16;

        /// <summary>
        /// Index of this key share in the collection.
        /// </summary>
        public int Index => (Key[0] & 0xf) + 1;

        /// <summary>
        /// The key share data.
        /// </summary>
        public byte[] Data {
            get {
                var Result = new byte[KeyBytes - 1];
                Array.Copy(Key, 1, Result, 0, KeyBytes - 1);
                return Result;
                }
            }

        /// <summary>
        /// The key share data as a BigInteger.
        /// </summary>
        public BigInteger Value => new BigInteger(Data);

        /// <summary>
        /// Construct a key share with the specified number of random bits.
        /// </summary>
        /// <param name="Bits">Size of key share to create (in bits).</param>
        public KeyShare(int Bits)
            : base(Bits) {
            }

        /// <summary>
        /// Construct a key share with the specified secret value.
        /// </summary>
        /// <param name="Key">The secret value.</param>
        public KeyShare(byte[] Key) : base (Key) {
            }

        /// <summary>
        /// Construct a key share with the specified secret value and index.
        /// </summary>
        /// <param name="Index">The key share index and threshold.</param>
        /// <param name="Value">The key share value/</param>
        public KeyShare(int Index, BigInteger Value) : 
                this(Index, Value.ToByteArray()) {
            }

        /// <summary>
        /// Construct a key share with the specified secret value and index.
        /// </summary>
        /// <param name="Index">The key share index and threshold.</param>
        /// <param name="Bytes">The key share value/</param>
        public KeyShare(int Index, byte[] Bytes) {
            Key = new byte[1 + Bytes.Length];
            Key[0] = (byte) Index;
            Array.Copy(Bytes, 0, Key, 1, Bytes.Length);
            }

        }
    }
