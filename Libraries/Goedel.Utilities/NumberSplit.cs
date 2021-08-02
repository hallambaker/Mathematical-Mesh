using System;

namespace Goedel.Utilities {

    /// <summary>
    /// Utilities to split an integer value to byte chunks
    /// </summary>
    public static class NumberSplit {


        /// <summary>
        /// Returns the lesser of <paramref name="value"/> and <paramref name="maximum"/>,
        /// thus ensuring that the returned value is equal to or smaller than the specified
        /// maximum.
        /// </summary>
        /// <param name="value">The test value.</param>
        /// <param name="maximum">The maximum value to return.</param>
        /// <returns>The greater of <paramref name="value"/> and <paramref name="maximum"/></returns>
        public static int Maximum(this int value, int maximum) =>
            value <= maximum ? value : maximum;


        /// <summary>
        /// Returns the greater of <paramref name="value"/> and <paramref name="minimum"/>,
        /// thus ensuring that the returned value is equal to or greater than the specified
        /// minimum.
        /// </summary>
        /// <param name="value">The test value.</param>
        /// <param name="minimum">The minimum value to return.</param>
        /// <returns>The greater of <paramref name="value"/> and <paramref name="minimum"/></returns>
        public static int Minimum(this int value, int minimum) =>
            value >= minimum ? value : minimum;


        /// <summary>
        /// Calculate the upper bound for an array index given a specified first position and
        /// length.
        /// </summary>
        /// <param name="Array">The array for which the index value will be calculated.</param>
        /// <param name="First">The first element to be read.</param>
        /// <param name="Length">The maximum number of elements to be read. If less 
        /// than zero, defaults to the size of the array.</param>
        /// <returns>The upper bound, that is one higher than the last element to
        /// be read.</returns>
        public static int GetLast(this Array Array, int First, int Length) {
            if (Length < 0) {
                return Array.Length;
                }
            return Math.Min(Array.Length, First + Length);
            }


        /// <summary>
        /// Extract bits 0-7 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 0-7</returns>
        public static byte Byte0(this int Data) => (byte)(Data & 0xff);

        /// <summary>
        /// Extract bits 8-15 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 8-15</returns>
        public static byte Byte1(this int Data) => (byte)((Data >> 8) & 0xff);

        /// <summary>
        /// Extract bits 16-23 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 16-23</returns>
        public static byte Byte2(this int Data) => (byte)((Data >> 16) & 0xff);

        /// <summary>
        /// Extract bits 24-31 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 24-31</returns>
        public static byte Byte3(this int Data) => (byte)((Data >> 24) & 0xff);

        /// <summary>
        /// Extract bits 0-7 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 0-7</returns>
        public static byte Byte0(this uint Data) => (byte)(Data & 0xff);

        /// <summary>
        /// Extract bits 8-15 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 8-15</returns>
        public static byte Byte1(this uint Data) => (byte)((Data >> 8) & 0xff);

        /// <summary>
        /// Extract bits 16-23 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 16-23</returns>
        public static byte Byte2(this uint Data) => (byte)((Data >> 16) & 0xff);

        /// <summary>
        /// Extract bits 24-31 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 24-31</returns>
        public static byte Byte3(this uint Data) => (byte)((Data >> 24) & 0xff);

        /// <summary>
        /// Convert an array of bytes in bigendian format to an unsigned integer value.
        /// </summary>
        /// <param name="Data">The data to convert</param>
        /// <param name="Count">The number of bytes to convert.</param>
        /// <returns>The integer value.</returns>
        public static ulong BigEndianInt(this byte[] Data, int Count) {
            ulong Result = 0;
            for (var i = 0; i < Count; i++) {
                Result = (Result << 8) | Data[i];
                }
            return Result;
            }




        /// <summary>
        /// Convert integer to bigendian array. That is with the most significant byte first.
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Output array</returns>
        public static byte[] BigEndian(this int Data) =>
                    new byte[] { Data.Byte3(), Data.Byte2(), Data.Byte1(), Data.Byte0() };


        /// <summary>
        /// Convert integer to bigendian array. That is with the most significant byte first.
        /// This is a convenience alias for Bigendian.
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Output array</returns>
        public static byte[] NetworkByte(this int Data) => BigEndian(Data);

        /// <summary>
        /// Convert integer to little endian array. That is with the most significant byte first.
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Output array</returns>
        public static byte[] LittleEndian(this int Data) => new byte[] { Data.Byte0(), Data.Byte1(), Data.Byte2(), Data.Byte3() };

        /// <summary>
        /// Set the values of a byte array from 32 bit integer in big endian order
        /// </summary>
        /// <param name="Array">Byte array to set, MUST be sufficiently large for input</param>
        /// <param name="Data">Data value to set</param>
        public static void SetBigEndian(this byte[] Array, int Data) {
            Array[0] = Data.Byte3();
            Array[1] = Data.Byte2();
            Array[2] = Data.Byte1();
            Array[3] = Data.Byte0();
            }

        /// <summary>
        /// Set the values of a byte array from 32 bit integer in big endian order
        /// </summary>
        /// <param name="Array">Byte array to set, MUST be sufficiently large for input</param>
        /// <param name="Data">Data value to set</param>
        public static void SetBigEndian(this byte[] Array, uint Data) {
            Array[0] = Data.Byte3();
            Array[1] = Data.Byte2();
            Array[2] = Data.Byte1();
            Array[3] = Data.Byte0();
            }



        /// <summary>
        /// Set the values of a byte array from 64 bit integer in big endian order
        /// </summary>
        /// <param name="Array">Byte array to set, MUST be sufficiently large for input</param>
        /// <param name="Data">Data value to set</param>
        public static void SetBigEndian(this byte[] Array, ulong Data) {
            Array[0] = Data.Byte7();
            Array[0] = Data.Byte6();
            Array[0] = Data.Byte5();
            Array[0] = Data.Byte4();
            Array[0] = Data.Byte3();
            Array[1] = Data.Byte2();
            Array[2] = Data.Byte1();
            Array[3] = Data.Byte0();
            }

        /// <summary>
        /// Set the values of a byte array from 32 bit integer in big endian order
        /// </summary>
        /// <param name="Array">Byte array to set, MUST be sufficiently large for input</param>
        /// <param name="Data">Data value to set</param>
        public static void SetNetworkByte(this byte[] Array, int Data) => Array.SetBigEndian(Data);


        /// <summary>
        /// Set the values of a byte array from 32 bit integer in little endian order
        /// </summary>
        /// <param name="Array">Byte array to set, MUST be sufficiently large for input</param>
        /// <param name="Data">Data value to set</param>
        public static void SetLittleEndian(this byte[] Array, int Data) {
            Array[0] = Data.Byte0();
            Array[1] = Data.Byte1();
            Array[2] = Data.Byte2();
            Array[3] = Data.Byte3();
            }

        // Long values

        /// <summary>
        /// Extract bits 0-7 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 0-7</returns>
        public static byte Byte0(this long Data) => (byte)(Data & 0xff);

        /// <summary>
        /// Extract bits 8-15 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 8-15</returns>
        public static byte Byte1(this long Data) => (byte)((Data >> 8) & 0xff);

        /// <summary>
        /// Extract bits 16-23 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 16-23</returns>
        public static byte Byte2(this long Data) => (byte)((Data >> 16) & 0xff);

        /// <summary>
        /// Extract bits 24-31 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 24-31</returns>
        public static byte Byte3(this long Data) => (byte)((Data >> 24) & 0xff);

        /// <summary>
        /// Extract bits 32-39 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 32-39</returns>
        public static byte Byte4(this long Data) => (byte)((Data >> 32) & 0xff);

        /// <summary>
        /// Extract bits 40-47 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 40-47</returns>
        public static byte Byte5(this long Data) => (byte)((Data >> 40) & 0xff);

        /// <summary>
        /// Extract bits 48-55 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 48-55</returns>
        public static byte Byte6(this long Data) => (byte)((Data >> 48) & 0xff);

        /// <summary>
        /// Extract bits 55-64 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 55-64</returns>
        public static byte Byte7(this long Data) => (byte)((Data >> 56) & 0xff);


        /// <summary>
        /// Extract bits 0-7 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 0-7</returns>
        public static byte Byte0(this ulong Data) => (byte)(Data & 0xff);

        /// <summary>
        /// Extract bits 8-15 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 8-15</returns>
        public static byte Byte1(this ulong Data) => (byte)((Data >> 8) & 0xff);

        /// <summary>
        /// Extract bits 16-23 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 16-23</returns>
        public static byte Byte2(this ulong Data) => (byte)((Data >> 16) & 0xff);

        /// <summary>
        /// Extract bits 24-31 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 24-31</returns>
        public static byte Byte3(this ulong Data) => (byte)((Data >> 24) & 0xff);

        /// <summary>
        /// Extract bits 24-31 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 24-31</returns>
        public static byte Byte4(this ulong Data) => (byte)((Data >> 32) & 0xff);

        /// <summary>
        /// Extract bits 24-31 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 24-31</returns>
        public static byte Byte5(this ulong Data) => (byte)((Data >> 40) & 0xff);

        /// <summary>
        /// Extract bits 24-31 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 24-31</returns>
        public static byte Byte6(this ulong Data) => (byte)((Data >> 48) & 0xff);

        /// <summary>
        /// Extract bits 24-31 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 24-31</returns>
        public static byte Byte7(this ulong Data) => (byte)((Data >> 56) & 0xff);


        /// <summary>
        /// Convert integer to bigendian array. That is with the most significant byte first.
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Output array</returns>
        public static byte[] BigEndian(this ulong Data) => new byte[] { Data.Byte7(), Data.Byte6(), Data.Byte5(), Data.Byte4(),
                Data.Byte3(), Data.Byte2(), Data.Byte1(), Data.Byte0() };


        }
    }
