using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Numerics;
using Goedel.Protocol;

namespace Goedel.CryptoLibNG {

    /// <summary>
    /// Represents a secret key that may be split into or reformed from 
    /// a collection of shares.
    /// </summary>
    public class Secret {

        /// <summary>
        /// Size of key in bits.
        /// </summary>
        public int KeyBits { get { return Key.Length * 8; } }

        /// <summary>
        /// Size of key in bytes;
        /// </summary>
        public int KeyBytes { get { return Key.Length; } }

        /// <summary>
        /// The Key value
        /// </summary>
        public byte[] Key;

        /// <summary>
        /// The Key Value as a Base32 encoded string.
        /// </summary>
        public string Text {
            get { return BaseConvert.ToUDF32String(Key); }
            }
        /// <summary>
        /// Create a new random secret with the specified number of bits.
        /// </summary>
        /// <param name="Bits"></param>
        public Secret(int Bits) {
            Key = CryptoCatalog.GetBits(Bits);
            }

        /// <summary>
        /// Create a secret from the specified key value.
        /// </summary>
        /// <param name="Key"></param>
        public Secret(byte[] Key) {
            this.Key = Key;
            }

        /// <summary>
        /// Recreate a secret from the specified shares.
        /// </summary>
        /// <param name="Shares">The shares to be recombined.</param>
        public Secret(KeyShare[] Shares) {
            this.Key = Combine(Shares);
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
        /// <returns></returns>
        public override int GetHashCode() {
            return Text.GetHashCode();
            }

        /// <summary>
        /// Test for equality
        /// </summary>
        /// <param name="obj">The secret to test against</param>
        /// <returns>true if the parameter has the same key value, false otherwise.</returns>
        public override bool Equals(System.Object obj) {
            if (obj == null) {
                return false;
                }
            Secret p = obj as Secret;
            if ((System.Object)p == null) {
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
        public KeyShare[] Split(int N, int K) {
            if (K > N) throw new Throw("Quorum can't exceed shares");
            if (K < 2) throw new Throw("Quorum must be at least 2");
            if (N < 2) throw new Throw("Shares must be at least 2");
            if (N > 15) throw new Throw("Too many shares");

            if (N == K) return Split(N);

            if (K > 15) throw new Throw("Degree too high");

            var PolyNomial = new BigInteger[K];
            PolyNomial[0] = MakePositive(Key);
            //Console.WriteLine("Key = {0} ", PolyNomial[0]);


            for (int i = 1; i < K; i++) {
                var Random = CryptoCatalog.GetBytes(KeyBytes);
                PolyNomial[i] = MakePositive(Random);
                }

            if (KeyBits != 128) throw new Throw("Only 128 bit keys supported right now");

            // 2^129-25 is a pseudo Mersene prime
            var Modulus = BigInteger.Pow(2, 129) - 25;
            //Console.WriteLine("Modulus = {0} ", Modulus);

            var KeyShares = new KeyShare[N];
            for (int i = 0; i < N; i++) {
                var D = PolyMod(i + 1, PolyNomial, Modulus);
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
        public KeyShare[] Split() {
            return Split(2);
            }

        /// <summary>
        /// Create a set of N key shares with a quorum of N.
        /// </summary>
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

        static byte[] Combine(KeyShare[] Shares) {
            //var KeyBytes = 16; //Shares[0].Key.Length;
            var Threshold = Shares[0].Threshold;
            foreach (var Share in Shares) {
                //if (Share.Key.Length != KeyBytes) {
                //    throw new Exception("Keys must be same length");
                //    }
                if (Share.Threshold != Threshold) {
                    throw new Throw("Keys must have same threshold");
                    }
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
            if (Shares.Length < Threshold) throw new Throw("Not Enough Shares");

            var Modulus = BigInteger.Pow(2, 129) - 25;
            BigInteger Accum = 0;

            //Console.WriteLine("Modulus = {0} ", Modulus);


            for (var Formula = 0; Formula < Threshold; Formula++) {

                var Value = Shares[Formula].Value;
                //Console.WriteLine("Value = {0} ", Value);

                BigInteger Numerator = 1, Denominator = 1;
                for (var Count = 0; Count < Threshold; Count++) {
                    if (Formula == Count) continue;  // If not the same value
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

        public int Threshold {
            get { return Key[0] / 16; }
            }

        /// <summary>
        /// Index of this key share in the collection.
        /// </summary>
        public int Index {
            get { return (Key[0] & 0xf) + 1; }
            }

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
        public BigInteger Value {
            get { return new BigInteger(Data); }
            }

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


    ///// <summary>
    ///// Construct a secret from a pass
    ///// </summary>
    //public class Passphrase {
    //    public byte[] Key;
    //    public string Text {
    //        get { return BaseConvert.ToBase32sString(Key, Key.Length); }
    //        }
    //    public string Fingerprint {
    //        get { return "tbs"; }
    //        }


    //    public Passphrase(int Bits) {
    //        Key = new byte[Bits / 8];
    //        RNGCryptoServiceProvider RNG = new RNGCryptoServiceProvider();
    //        RNG.GetBytes(Key);
    //        }

    //    public Passphrase()
    //        : this(128) {
    //        }

    //    public KeyShare[] Split(int Count, int Quorum) {

    //        KeyShare[] Shares = new KeyShare[Count];
    //        for (int i = 0; i < Shares.Length; i++) {
    //            Shares[i] = new KeyShare(Key.Length * 8);
    //            }

    //        return Shares;
    //        }
    //    }
    }
