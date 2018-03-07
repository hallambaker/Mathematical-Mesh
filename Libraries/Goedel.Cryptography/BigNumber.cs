using System;
using System.Numerics;
using Goedel.Utilities;

namespace Goedel.Cryptography {
    /// <summary>
    /// Convert a BigInteger to a Bitfield and return successive bits
    /// beginning with the most significant and ending with the least.
    /// </summary>
    public struct BitIndex {

        byte[] BitField;

        int DownByte;
        int DownBit;
        int UpByte;
        int UpBit;
        int Length;
        byte DataDown, DataUp;

        //bool CountUp;

        /// <summary>
        /// Returns true if there is further work to be completed, otherwise false.
        /// </summary>
        public bool GoingDown => (DownByte > 1) | (DownBit > 0);


        /// <summary>
        /// Returns true if there is further work to be completed, otherwise false.
        /// </summary>
        public bool GoingUp => (UpByte < (Length-1) | UpBit <8) ;


        /// <summary>
        /// Construct from a big integte
        /// </summary>
        /// <param name="Value">The bit field value</param>
        /// <param name="Bits">The number of bits to process</param>
        /// <param name="Up">If true, count is performed in ascending order</param>
        public BitIndex(BigInteger Value, int Bits, bool Up = false) {
            Length = (Bits + 7) / 8;
            Bits--;
            DownByte = Bits / 8;
            DownBit = Bits % 8;
            UpByte = 0;
            UpBit = 0;
            BitField = Value.ToByteArray();
            DataDown = BitField[DownByte];
            DataUp = BitField[0];
            //this.CountUp = Up;
            }



        /// <summary>
        /// Return the value of the next bit as boolean value and advance the indicies
        /// </summary>
        /// <returns>True iff the next bit to be read is 1.</returns>
        public bool Down() {
            if (DownBit < 0) {
                DownByte--;
                DownBit = 7;
                Assert.True(DownByte >= 0, InvalidOperation.Throw);

                DataDown = BitField[DownByte];
                }
            var Result = (DataDown & 0x80) > 0;
            DataDown = (byte)(DataDown << 1);
            DownBit--;

            return Result;
            }

        /// <summary>
        /// Return the value of the next bit as boolean value and advance the indicies
        /// </summary>
        /// <returns>True iff the next bit to be read is 1.</returns>
        public bool Up() {
            Assert.True(UpByte < Length, InvalidOperation.Throw);

            if (UpBit > 7) {
                UpByte++;
                UpBit = 0;
                

                DataUp = BitField[UpByte];
                }
            var Result = (DataUp & 0x01) > 0;
            DataUp = (byte)(DataUp >> 1);
            UpBit++;

            return Result;

            }
        }

    /// <summary>
    /// Extension methods for manipulating BigIntegers
    /// </summary>
    public static class BigNumber {

        /// <summary>
        /// Duplicate the values in the array
        /// </summary>
        /// <param name="Source">The source array</param>
        /// <returns>A new array containing a copy of the elements in the source.</returns>
        public static byte[] Duplicate (this byte[] Source) {
            var Result = new byte[Source.Length];
            Array.Copy(Source, Result, Source.Length);
            return Result;
            }

        /// <summary>
        /// Duplicate the values in the array
        /// </summary>
        /// <param name="Source">The source array</param>
        /// <param name="Index">The starting index for the copy</param>
        /// <param name="Length">The number of items to copy</param>
        /// <returns>A new array containing a copy of a selected range of the elements in the source.</returns>
        public static byte[] Duplicate(this byte[] Source, int Index, int Length) {
            var Result = new byte[Length];
            var CopyBytes = Length < Source.Length ? Length : Source.Length;
            Array.Copy(Source, Index, Result, 0, CopyBytes);
            return Result;
            }


        /// <summary>
        /// Convert an array of bytes in little endian format to a Big Integer
        /// </summary>
        /// <param name="Data">The data in little endian format.</param>
        /// <returns>The constructed integer</returns>
        public static BigInteger BigIntegerLittleEndian (this byte[] Data) {
            if ((Data[Data.Length - 1] >> 7) == 0) {
                return new BigInteger(Data);
                }
            var Extend = new byte[Data.Length + 1];
            Array.Copy(Data, Extend, Data.Length);
            return new BigInteger(Extend);
            }

        /// <summary>
        /// Convert an array of bytes in big endian format to a Big Integer
        /// </summary>
        /// <param name="Data">The data in big endian format.</param>
        /// <returns>The constructed integer</returns>
        public static BigInteger BigIntegerBigEndian(this byte[] Data) {
            byte[] Extend;

            if ((Data[0] >> 7) == 0) {
                Extend = new byte[Data.Length];
                Array.Copy(Data, Extend, Data.Length);
                }
            else {
                Extend = new byte[Data.Length+1];
                Array.Copy(Data, 0, Extend, 1, Data.Length);
                }
            Array.Reverse(Extend);
            return new BigInteger(Extend);
            }



        /// <summary>
        /// Create a Big Integer from a hexadecimal string constant. This is not optimized for
        /// speed since it is unlikely this will be called very often and may well 
        /// be optimized away. Note that the caller is responsible for making sure
        /// that the input is positive
        /// </summary>
        /// <param name="Text">The hexadecimal string to convert</param>
        /// <returns>The resulting integer</returns>
        public static BigInteger HexToBigInteger(this string Text) {
            var Bytes = BaseConvert.FromBase16String(Text);
            Array.Reverse(Bytes);
            return new BigInteger(Bytes);
            }

        /// <summary>
        /// Create a Big Integer from a decimal string constant. This is not optimized for
        /// speed since it is unlikely this will be called very often and may well 
        /// be optimized away. Note that the caller is responsible for making sure
        /// that the input is positive
        /// </summary>
        /// <param name="Text">The decimal value</param>
        /// <returns>The resulting integer</returns>
        public static BigInteger DecimalToBigInteger(this string Text) {
            BigInteger.TryParse(Text, out var Result);
            return Result;
            }

        /// <summary>
        /// Calculate the modular inverse of a number using the x(p-2) approach
        /// </summary>
        /// <param name="x">Value</param>
        /// <param name="p">Modulus</param>
        /// <returns>The modular inverse, i.e. the number y such that 
        /// (x * y) mod p = 1.</returns>
        public static BigInteger ModularInverse(this BigInteger x, BigInteger p) {
            return BigInteger.ModPow(x, p - 2, p);
            }

        /// <summary>
        /// Calculate the modular inverse of a number using the x(p-2) approach
        /// </summary>
        /// <param name="x">Value</param>
        /// <param name="p">Modulus</param>
        /// <returns>The modular inverse, i.e. the number y such that 
        /// (x * y) mod p = 1.</returns>
        public static BigInteger ModularInverse(this int x, BigInteger p) {
            return ModularInverse((BigInteger)x, p);
            }

        /// <summary>
        /// Calculate the modulus of a number with correct handling for negative numbers.
        /// </summary>
        /// <param name="x">Value</param>
        /// <param name="p">Modulus</param>
        /// <returns>x mod p</returns>
        public static BigInteger Mod(this BigInteger x, BigInteger p) {
            var Result = x % p;
            return Result.Sign >= 0 ? Result : Result + p;
            }

        /// <summary>
        /// Calculate the square root of -1 modulo p
        /// </summary>
        /// <param name="p">The modulus</param>
        /// <returns>A value x such that x*x mod p = -1 mod p</returns>
        public static BigInteger SqrtMinus1(this BigInteger p) {
            return BigInteger.ModPow(2, (p - 1) / 4, p);
            }


        /// <summary>
        /// Return a Square root of a number modulo the prime. 
        /// </summary>
        /// <param name="x2">The value</param>
        /// <param name="p">The modulus</param>
        /// <param name="SqrtMinus1">The value of the square root -1 mod p.</param>
        /// <param name="Odd">If specified, specifies whether X is odd (true) or even (false).</param>
        /// <returns>A value x such that x*x = x2.</returns>
        /// <exception cref="InvalidOperation">Thrown if the value does not have a root.</exception>

        public static BigInteger Sqrt(this BigInteger x2, BigInteger p,
                    BigInteger? SqrtMinus1 = null,
                    bool? Odd = null) {
            BigInteger x = 0;
            if (x2 % 4 == 3) {
                x = BigInteger.ModPow(x2, (p + 1) / 4, p);
                }
            else {
                x = Sqrt8k5(x2, p, SqrtMinus1, Odd);
                }
            //if (x2%8 == 5) {
            //    return Sqrt8k5(x2, p, SqrtMinus1, Odd);
            //    }
            //throw new NYI("Square root not implemented for p%8 = 1");

            if (Odd == null) {
                return x;
                }
            return (x.IsEven ^ (bool)Odd) ? x : p - x;
            }


        /// <summary>
        /// Return a Square root of a number modulo the prime for the
        /// special case x2 % 8 == 5.
        /// </summary>
        /// <param name="x2">The value</param>
        /// <param name="p">The modulus</param>
        /// <param name="SqrtMinus1">The value of the square root -1 mod p.</param>
        /// <param name="Odd">If specified, specifies whether X is odd (true) or even (false).</param>
        /// <returns>A value x such that x*x = x2.</returns>
        /// <exception cref="InvalidOperation">Thrown if the value does not have a root.</exception>
        public static BigInteger Sqrt8k5(this BigInteger x2, BigInteger p,
                            BigInteger? SqrtMinus1 = null,
                            bool? Odd = null) {
            var x = BigInteger.ModPow(x2, (p + 3) / 8, p);
            if (((x * x - x2) % p) != 0) {
                var RM1 = SqrtMinus1 ?? p.SqrtMinus1();
                x = (x * RM1) % p;
                Assert.True((((x * x - x2) % p) == 0), InvalidOperation.Throw);
                }
            return x;
            }

        /// <summary>
        /// Calculate the modulus of a number with correct handling for negative numbers.
        /// </summary>
        /// <param name="x">Value</param>
        /// <param name="p">Modulus</param>
        /// <returns>x mod p</returns>
        public static BigInteger Mod(this int x, BigInteger p) {
            return Mod((BigInteger)x, p);
            }



        }
    }
