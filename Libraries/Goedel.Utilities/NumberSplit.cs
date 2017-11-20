using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.Utilities {

    /// <summary>
    /// Utilities to split an integer value to byte chunks
    /// </summary>
    public static class NumberSplit {

        /// <summary>
        /// Extract bits 0-7 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 0-7</returns>
        public static byte Byte0 (this int Data) {
            return (byte) (Data & 0xff);
            }

        /// <summary>
        /// Extract bits 8-15 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 8-15</returns>
        public static byte Byte1(this int Data) {
            return (byte)((Data>>8) & 0xff);
            }

        /// <summary>
        /// Extract bits 16-23 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 16-23</returns>
        public static byte Byte2(this int Data) {
            return (byte)((Data >> 16) & 0xff);
            }

        /// <summary>
        /// Extract bits 24-31 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 24-31</returns>
        public static byte Byte3(this int Data) {
            return (byte)((Data >> 24) & 0xff);
            }

        /// <summary>
        /// Extract bits 0-7 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 0-7</returns>
        public static byte Byte0(this uint Data) {
            return (byte)(Data & 0xff);
            }

        /// <summary>
        /// Extract bits 8-15 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 8-15</returns>
        public static byte Byte1(this uint Data) {
            return (byte)((Data >> 8) & 0xff);
            }

        /// <summary>
        /// Extract bits 16-23 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 16-23</returns>
        public static byte Byte2(this uint Data) {
            return (byte)((Data >> 16) & 0xff);
            }

        /// <summary>
        /// Extract bits 24-31 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 24-31</returns>
        public static byte Byte3(this uint Data) {
            return (byte)((Data >> 24) & 0xff);
            }





        /// <summary>
        /// Convert integer to bigendian array. That is with the most significant byte first.
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Output array</returns>
        public static byte[] BigEndian (this int Data) {
            return new byte[] { Data.Byte3(), Data.Byte2(), Data.Byte1(), Data.Byte0() };
            }


        /// <summary>
        /// Convert integer to bigendian array. That is with the most significant byte first.
        /// This is a convenience alias for Bigendian.
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Output array</returns>
        public static byte[] NetworkByte(this int Data) {
            return BigEndian(Data);
            }

        /// <summary>
        /// Convert integer to little endian array. That is with the most significant byte first.
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Output array</returns>
        public static byte[] LittleEndian(this int Data) {
            return new byte[] { Data.Byte0(), Data.Byte1(), Data.Byte2(), Data.Byte3() };
            }

        /// <summary>
        /// Set the values of a byte array from 32 bit integer in big endian order
        /// </summary>
        /// <param name="Array">Byte array to set, MUST be sufficiently large for input</param>
        /// <param name="Data">Data value to set</param>
        public static void SetBigEndian (this byte[] Array, int Data) {
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
        public static void SetNetworkByte(this byte[] Array, int Data) {
            Array.SetBigEndian(Data);
            }


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
        public static byte Byte0(this long Data) {
            return (byte)(Data & 0xff);
            }

        /// <summary>
        /// Extract bits 8-15 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 8-15</returns>
        public static byte Byte1(this long Data) {
            return (byte)((Data >> 8) & 0xff);
            }

        /// <summary>
        /// Extract bits 16-23 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 16-23</returns>
        public static byte Byte2(this long Data) {
            return (byte)((Data >> 16) & 0xff);
            }

        /// <summary>
        /// Extract bits 24-31 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 24-31</returns>
        public static byte Byte3(this long Data) {
            return (byte)((Data >> 24) & 0xff);
            }

        /// <summary>
        /// Extract bits 32-39 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 32-39</returns>
        public static byte Byte4(this long Data) {
            return (byte)((Data >> 32) & 0xff);
            }

        /// <summary>
        /// Extract bits 40-47 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 40-47</returns>
        public static byte Byte5(this long Data) {
            return (byte)((Data >> 40) & 0xff);
            }

        /// <summary>
        /// Extract bits 48-55 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 48-55</returns>
        public static byte Byte6(this long Data) {
            return (byte)((Data >> 48) & 0xff);
            }

        /// <summary>
        /// Extract bits 55-64 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 55-64</returns>
        public static byte Byte7(this long Data) {
            return (byte)((Data >> 56) & 0xff);
            }


        /// <summary>
        /// Extract bits 0-7 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 0-7</returns>
        public static byte Byte0(this ulong Data) {
            return (byte)(Data & 0xff);
            }

        /// <summary>
        /// Extract bits 8-15 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 8-15</returns>
        public static byte Byte1(this ulong Data) {
            return (byte)((Data >> 8) & 0xff);
            }

        /// <summary>
        /// Extract bits 16-23 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 16-23</returns>
        public static byte Byte2(this ulong Data) {
            return (byte)((Data >> 16) & 0xff);
            }

        /// <summary>
        /// Extract bits 24-31 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 24-31</returns>
        public static byte Byte3(this ulong Data) {
            return (byte)((Data >> 24) & 0xff);
            }

        /// <summary>
        /// Extract bits 24-31 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 24-31</returns>
        public static byte Byte4(this ulong Data) {
            return (byte)((Data >> 32) & 0xff);
            }

        /// <summary>
        /// Extract bits 24-31 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 24-31</returns>
        public static byte Byte5(this ulong Data) {
            return (byte)((Data >> 40) & 0xff);
            }

        /// <summary>
        /// Extract bits 24-31 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 24-31</returns>
        public static byte Byte6(this ulong Data) {
            return (byte)((Data >> 48) & 0xff);
            }

        /// <summary>
        /// Extract bits 24-31 from an integer value
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Bits 24-31</returns>
        public static byte Byte7(this ulong Data) {
            return (byte)((Data >> 56) & 0xff);
            }


        /// <summary>
        /// Convert integer to bigendian array. That is with the most significant byte first.
        /// </summary>
        /// <param name="Data">Input</param>
        /// <returns>Output array</returns>
        public static byte[] BigEndian(this ulong Data) {
            return new byte[] { Data.Byte7(), Data.Byte6(), Data.Byte5(), Data.Byte4(),
                Data.Byte3(), Data.Byte2(), Data.Byte1(), Data.Byte0() };
            }


        }
    }
