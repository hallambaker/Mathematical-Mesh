#region // Copyright
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
using System;
using System.Numerics;

using Goedel.Utilities;

namespace Goedel.Cryptography {
    /// <summary>
    /// Convert a BigInteger to a Bitfield and return successive bits
    /// beginning with the most significant and ending with the least.
    /// </summary>
    public struct BitIndex {

        byte[] bitField;

        int downByte;
        int downBit;
        int upByte;
        int upBit;
        int length;
        byte dataDown, dataUp;

        //bool CountUp;

        /// <summary>
        /// Returns true if there is further work to be completed, otherwise false.
        /// </summary>
        public bool GoingDown => (downByte > 1) | (downBit > 0);


        /// <summary>
        /// Returns true if there is further work to be completed, otherwise false.
        /// </summary>
        public bool GoingUp => (upByte < (length - 1) | upBit < 8);


        /// <summary>
        /// Construct from a big integte
        /// </summary>
        /// <param name="Value">The bit field value</param>
        /// <param name="Bits">The number of bits to process</param>
        /// <param name="Up">If true, count is performed in ascending order</param>
        public BitIndex(BigInteger Value, int Bits, bool Up = false) {
            length = (Bits + 7) / 8;
            Bits--;
            downByte = Bits / 8;
            downBit = Bits % 8;
            upByte = 0;
            upBit = 0;
            bitField = Value.ToByteArrayLittleEndian(length);


            dataDown = bitField[downByte];
            dataUp = bitField[0];
            //this.CountUp = Up;
            }



        /// <summary>
        /// Return the value of the next bit as boolean value and advance the indicies
        /// </summary>
        /// <returns>True iff the next bit to be read is 1.</returns>
        public bool Down() {
            if (downBit < 0) {
                downByte--;
                downBit = 7;
                Assert.AssertTrue(downByte >= 0, InvalidOperation.Throw);

                dataDown = bitField[downByte];
                }
            var Result = (dataDown & 0x80) > 0;
            dataDown = (byte)(dataDown << 1);
            downBit--;

            return Result;
            }

        /// <summary>
        /// Return the value of the next bit as boolean value and advance the indicies
        /// </summary>
        /// <returns>True iff the next bit to be read is 1.</returns>
        public bool Up() {
            Assert.AssertTrue(upByte < length, InvalidOperation.Throw);

            if (upBit > 7) {
                upByte++;
                upBit = 0;


                dataUp = bitField[upByte];
                }
            var Result = (dataUp & 0x01) > 0;
            dataUp = (byte)(dataUp >> 1);
            upBit++;

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
        public static byte[] Duplicate(this byte[] Source) {
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
        /// Return a positive random BigInteger that is strictly less than 2^bits.
        /// </summary>
        /// <param name="Bits">The number of bits in the output</param>
        /// <returns>The random value.</returns>
        public static BigInteger Random(int Bits) {
            var bytes = CryptoCatalog.GetBytes(Bits / 8);
            return BigIntegerLittleEndian(bytes);
            }


        /// <summary>
        /// Return a positive random BigInteger that is strictly less than 2^bits.
        /// </summary>
        /// <param name="maximum">One more than the maximum value that may be returned.</param>
        /// <returns>The random value.</returns>
        public static BigInteger Random(BigInteger maximum) {
            var bytes = CryptoCatalog.GetBytes(maximum.GetByteCount() + 16);
            return BigIntegerLittleEndian(bytes) % maximum;
            }


        /// <summary>
        /// Encode the code point <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The point to encode.</param>
        /// <param name="length">The number of bytes to output.</param>
        /// <returns>The encoded format of the point</returns>
        public static byte[] ByteArrayLittleEndian(this BigInteger data, int length) {
            var bytes = data.ToByteArray();
            if (bytes.Length == length) {
                return bytes;
                }
            var result = new byte[length];
            Array.Copy(bytes, result, (bytes.Length < length ? bytes.Length : length));
            return result;
            }


        /// <summary>
        /// Convert an array of bytes in little endian format to a Big Integer
        /// </summary>
        /// <param name="Data">The data in little endian format.</param>
        /// <returns>The constructed integer</returns>
        public static BigInteger BigIntegerLittleEndian(this byte[] Data) {
            if ((Data[^1] >> 7) == 0) {
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
                Extend = new byte[Data.Length + 1];
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
            var Bytes = BaseConvert.FromBase16(Text);
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
        public static BigInteger ModularInverse(this BigInteger x, BigInteger p) => BigInteger.ModPow(x, p - 2, p);

        /// <summary>
        /// Calculate the modular inverse of a number using the x(p-2) approach
        /// </summary>
        /// <param name="x">Value</param>
        /// <param name="p">Modulus</param>
        /// <returns>The modular inverse, i.e. the number y such that 
        /// (x * y) mod p = 1.</returns>
        public static BigInteger ModularInverse(this int x, BigInteger p) => ModularInverse((BigInteger)x, p);

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
        public static BigInteger SqrtMinus1(this BigInteger p) => BigInteger.ModPow(2, (p - 1) / 4, p);



        /*
         
         */

        /// <summary>
        /// Return a Square root of a number modulo a prime. 
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
            if (p % 4 == 3) {
                x = BigInteger.ModPow(x2, (p + 1) / 4, p);
                }
            else if (p % 8 == 5) {
                x = Sqrt8k5(x2, p, SqrtMinus1, Odd);
                }
            else {
                throw new NYI("Square root not implemented for p%8 = 1");
                }

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
                Assert.AssertTrue((((x * x - x2) % p) == 0), InvalidOperation.Throw);
                }
            return x;
            }

        /// <summary>
        /// Calculate the modulus of a number with correct handling for negative numbers.
        /// </summary>
        /// <param name="x">Value</param>
        /// <param name="p">Modulus</param>
        /// <returns>x mod p</returns>
        public static BigInteger Mod(this int x, BigInteger p) => Mod((BigInteger)x, p);

        /// <summary>
        /// Convert <paramref name="bigInteger"/> to a byte array in little endian format.
        /// </summary>
        /// <param name="bigInteger">The integer to be converted.</param>
        /// <returns>The byte array.</returns>
        public static byte[] ToByteArrayLittleEndian(this BigInteger bigInteger) => bigInteger.ToByteArray();

        /// <summary>
        /// Convert <paramref name="bigInteger"/> to a byte array in little endian format,
        /// padding the resulting array so that it is at least <paramref name="length"/>
        /// bytes in length.
        /// </summary>
        /// <param name="bigInteger">The integer to be converted.</param>
        /// <param name="length">The exact length of the result.</param>
        /// <returns>The byte array.</returns>
        public static byte[] ToByteArrayLittleEndian(this BigInteger bigInteger, int length) {

            var Result = bigInteger.ToByteArray();
            if (Result.Length == length) {
                return Result;
                }

            var Copy = new byte[length];
            length = Math.Min(length, Result.Length);
            Array.Copy(Result, Copy, length);
            return Copy;

            }

        /// <summary>
        /// Convert <paramref name="bigInteger"/> to a byte array in big endian format,
        /// padding the resulting array so that it is at least <paramref name="length"/>
        /// bytes in length.
        /// </summary>
        /// <param name="bigInteger">The integer to be converted.</param>
        /// <param name="length">The exact length of the result.</param>
        /// <returns>The byte array.</returns>
        public static byte[] ToByteArrayBigEndian(this BigInteger bigInteger, int length) {
            var buffer = ToByteArrayLittleEndian(bigInteger, length);
            Array.Reverse(buffer);
            return buffer;
            }

        /// <summary>
        /// Miller-Rabin probabalistic primality test.
        /// https://rosettacode.org/wiki/Miller%E2%80%93Rabin_primality_test#C.23
        /// </summary>
        /// <param name="source">The integer to test</param>
        /// <param name="certainty">The degree of certainty.</param>
        /// <returns>If the value <paramref name="source"/> is found to not be prime,
        /// returns false. Otherwise, returns true.</returns>
        public static bool IsProbablePrime(this BigInteger source, int certainty = 128) {
            if (source == 2 || source == 3) {
                return true;
                }
            if (source < 2 || source.IsEven) {
                return false;
                }

            BigInteger d = source - 1;
            int s = 0;

            while (d % 2 == 0) {
                d /= 2;
                s += 1;
                }

            byte[] bytes = new byte[source.ToByteArray().LongLength];
            BigInteger a;

            for (int i = 0; i < certainty; i++) {
                do {
                    Platform.FillRandom(bytes, 0, bytes.Length);
                    a = new BigInteger(bytes);
                    } while (a < 2 || a >= source - 2);

                var x = BigInteger.ModPow(a, d, source);
                if (x == 1 || x == source - 1) {
                    continue;
                    }

                for (int r = 1; r < s; r++) {
                    x = BigInteger.ModPow(x, 2, source);
                    if (x == 1) {
                        return false;
                        }

                    if (x == source - 1) {
                        break;
                        }
                    }

                if (x != source - 1) {
                    return false;
                    }
                }

            return true;

            }

        }
    }
