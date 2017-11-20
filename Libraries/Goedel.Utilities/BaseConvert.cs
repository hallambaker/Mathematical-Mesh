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
using System.Text;


namespace Goedel.Utilities  {

    /// <summary>
    /// Static class containing extension methods for the utilities in this namespace.
    /// </summary>
    public static partial class Extension {

        /// <summary>
        /// Convert data to Base16 (hexadecimal)
        /// </summary>
        /// <param name="Data">The data to be encoded.</param>
        /// <param name="Length">The number of bytes to be encoded, if negative or unspecified,
        /// all bytes are encoded.</param>
        /// <returns>The input data converted to a Base16 encoded string</returns>
        public static string Base16(this byte[] Data, int Length = -1) {
            return BaseConvert.ToBase16String(Data, Length);
            }

        /// <summary>
        /// Convert data to Base32
        /// </summary>
        /// <param name="Data">The data to be encoded.</param>
        /// <returns>The input data converted to a Base32 encoded string</returns>
        public static string Base32(this byte[] Data) {
            return BaseConvert.ToBase32String(Data, Data.Length);
            }

        /// <summary>
        /// Convert data to Base32 string with separator characters
        /// between each five character block.
        /// </summary>
        /// <param name="Data">The data to be encoded.</param>
        /// <param name="Precision">The number of bits of precision to encode</param>
        /// <returns>The input data converted to a Base32-UDF encoded string</returns>
        public static string UDF(this byte[] Data, int Precision) {
            return BaseConvert.ToUDF(Data, Precision);
            }

        /// <summary>
        /// Convert data to Base64
        /// </summary>
        /// <param name="Data">The data to be encoded.</param>
        /// <returns>The input data converted to a Base64 encoded string</returns>
        public static string Base64(this byte[] Data) {
            return BaseConvert.ToBase64String(Data, Data.Length);
            }

        /// <summary>
        /// Convert data to Base64 URL Encoded format
        /// </summary>
        /// <param name="Data">The data to be encoded.</param>
        /// <returns>The input data converted to a Base64URL encoded string</returns>
        public static string Base64URL(this byte[] Data) {
            return BaseConvert.ToBase64urlString(Data, Data.Length);
            }


        /// <summary>
        /// Convert data to Base16 (hexadecimal) and append to the specified stringbuilder.
        /// </summary>
        /// <param name="StringBuilder">String builder to append data to</param>
        /// <param name="Data">The data to be encoded.</param>
        public static void AppendBase16(this StringBuilder StringBuilder, byte[] Data) {
            BaseConvert.ToBase16String(StringBuilder, Data, Data.Length);
            }

        /// <summary>
        /// Convert data to Base16 (hexadecimal) and append to the specified stringbuilder.
        /// </summary>
        /// <param name="StringBuilder">String builder to append data to</param>
        /// <param name="Data">The data to be encoded.</param>
        public static void AppendBase32(this StringBuilder StringBuilder, byte[] Data) {
            BaseConvert.ToBase32String(StringBuilder, Data, Data.Length);
            }

        /// <summary>
        /// Convert data to Base16 (hexadecimal) and append to the specified stringbuilder.
        /// </summary>
        /// <param name="StringBuilder">String builder to append data to</param>/// 
        /// <param name="Data">The data to be encoded.</param>
        public static void AppendBase64(this StringBuilder StringBuilder, byte[] Data) {
            BaseConvert.ToBase64String(StringBuilder, Data, 0, Data.Length, true);
            }

        /// <summary>
        /// Convert data to Base16 (hexadecimal) and append to the specified stringbuilder.
        /// </summary>
        /// <param name="StringBuilder">String builder to append data to</param>
        /// <param name="Data">The data to be encoded.</param>
        public static void AppendBase64URL(this StringBuilder StringBuilder, byte[] Data) {
            BaseConvert.ToBase64urlString(StringBuilder, Data, 0, Data.Length, true);
            }


        }
    
    /// <summary>
    /// Routines to convert binary data to various character representations.
    /// Supported representations include Base16, Base32 and Base64 and common
    /// variations thereof.
    /// </summary>
    public static class BaseConvert {

        private static char[] BASE16 = new char[]{
                    '0', '1', '2', '3', '4', '5', '6', '7',
                    '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

        private static char[] BASE32 = new char[]{
                    'A' , 'B', 'C', 'D', 'E', 'F', 'G', 'H', 
                     'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
                     'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
                     'Y', 'Z', '2', '3', '4', '5', '6', '7'};

        private static char[] BASE32HEX = new char[]{
                    '0' , '1', '2', '3', '4', '5', '6', '7', 
                     '8', '9', 'A', 'B', 'C', 'D', 'E', 'F',
                     'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N',
                     'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V'};

        private static char[] BASE64URL = new char[]{
                    'A' , 'B', 'C', 'D', 'E', 'F', 'G', 'H', 
                     'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
                     'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
                     'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f',
                     'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n',
                     'o', 'p', 'q', 'r', 's', 't', 'u', 'v',
                     'w', 'x', 'y', 'z', '0', '1', '2', '3',
                     '4', '5', '6', '7', '8', '9', '-', '_'};

        private static char[] BASE64 = new char[]{
                    'A' , 'B', 'C', 'D', 'E', 'F', 'G', 'H',
                     'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
                     'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
                     'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f',
                     'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n',
                     'o', 'p', 'q', 'r', 's', 't', 'u', 'v',
                     'w', 'x', 'y', 'z', '0', '1', '2', '3',
                     '4', '5', '6', '7', '8', '9', '+', '/'};

        private static byte[] BASE16Value = new byte[] {
                    255, 255, 255, 255,  255, 255, 255, 255,   //  0-7
                    255, 255, 255, 255,  255, 255, 255, 255,   //  8-15
                    255, 255, 255, 255,  255, 255, 255, 255,   //  16-23
                    255, 255, 255, 255,  255, 255, 255, 255,   //  24-31
                    255, 255, 255, 255,  255, 255, 255, 255,   //  32-39
                    255, 255, 255, 255,  255, 255, 255, 255,   //  40
                      0,   1,   2,   3,    4,   5,   6,   7,   //  48
                      8,   9, 255, 255,  255, 255, 255, 255,   //  56
                    255,  10,  11,  12,   13,  14,  15, 255,   //  64
                    255, 255, 255, 255,  255, 255, 255, 255,   //  72
                    255, 255, 255, 255,  255, 255, 255, 255,   //  80-87
                    255, 255, 255, 255,  255, 255, 255, 255,   //  88
                    255,  10,  11,  12,   13,  14,  15, 255,   //  96
                    255, 255, 255, 255,  255, 255, 255, 255,   // 104
                    255, 255, 255, 255,  255, 255, 255, 255,   // 112
                    255, 255, 255, 255,  255, 255, 255, 255,   // 120-127

        };


        private static byte[] BASE32Value = new byte[] {
                    255, 255, 255, 255,  255, 255, 255, 255,   //  0-7
                    255, 255, 255, 255,  255, 255, 255, 255,   //  8-15
                    255, 255, 255, 255,  255, 255, 255, 255,   //  16-23
                    255, 255, 255, 255,  255, 255, 255, 255,   //  24-31
                    255, 255, 255, 255,  255, 255, 255, 255,   //  32-39
                    255, 255, 255, 255,  255, 255, 255, 255,   //  40
                    255, 255,  26,  27,   28,  29,  30,  31,   //  48
                    255, 255, 255, 255,  255, 255, 255, 255,   //  56
                    255,   0,   1,   2,   3,    4,   5,   6,   //  64
                      7,   8,   9,  10,  11,   12,  13,  14,   //  72
                     15,  16,  17,  18,  19,   20,  21,  22,   //  80
                     23,  24,  25, 255, 255,  255, 255, 255,   //  88
                    255,   0,   1,   2,   3,    4,   5,   6,   //  96
                      7,   8,   9,  10,  11,   12,  13,  14,   // 104
                     15,  16,  17,  18,  19,   20,  21,  22,   // 112
                     23,  24,  25, 255, 255,  255, 255, 255,    // 120-127
            };

        //private static byte[] BASE32HexValue = new byte[] {
        //            255, 255, 255, 255,  255, 255, 255, 255,   //  0-7
        //            255, 255, 255, 255,  255, 255, 255, 255,   //  8-15
        //            255, 255, 255, 255,  255, 255, 255, 255,   //  16-23
        //            255, 255, 255, 255,  255, 255, 255, 255,   //  24-31
        //            255, 255, 255, 255,  255, 255, 255, 255,   //  32-39
        //            255, 255, 255, 255,  255, 255, 255, 255,   //  40
        //              0,   1,   2,   3,    4,   5,   6,   7,   //  48
        //              8,   9, 255, 255,  255, 255, 255, 255,   //  56
        //            255,  10,  11,  12,   13,  14,  15,  16,   //  64
        //             17,  18,  19,  20,   21,  22,  23,  24,   //  72
        //             25,  26,  27,  28,   29,  30,  31, 255,   //  80-87
        //            255, 255, 255, 255,  255, 255, 255, 255,   //  88
        //            255,  10,  11,  12,   13,  14,  15,  16,   //  96
        //             17,  18,  19,  20,   21,  22,  23,  24,   // 104
        //             25,  26,  27,  28,   29,  30,  31, 255,   // 112
        //            255, 255, 255, 255,  255, 255, 255, 255,   // 120-127

        //};


        //
        // For reverse conversion permit either Base64 (+/) 
        // or Base64Url (-_) encodings of 62 and 63
        // 
        private static byte [] BASE64URLValue = new byte [] {
                    255, 255, 255, 255,  255, 255, 255, 255,   //  0-7
                    255, 255, 255, 255,  255, 255, 255, 255,   //  8-15
                    255, 255, 255, 255,  255, 255, 255, 255,   //  16-23
                    255, 255, 255, 255,  255, 255, 255, 255,   //  24-31
                    255, 255, 255, 255,  255, 255, 255, 255,   //  32-39
                    255, 255, 255,  62,  255,  62, 255,  63,   //  40
                     52,  53,  54,  55,   56,  57,  58,  59,   //  48
                     60,  61, 255, 255,  255, 255, 255, 255,   //  56
                    255,   0,   1,   2,    3,   4,   5,   6,   //  64
                      7,   8,   9,  10,   11,  12,  13,  14,   //  72
                     15,  16,  17,  18,   19,  20,  21,  22,   //  80-87
                     23,  24,  25, 255,  255, 255, 255,  63,   //  88
                    255,  26,  27,  28,   29,  30,  31,  32,   //  96
                     33,  34,  35,  36,   37,  38,  39,  40,   // 104
                     41,  42,  43,  44,   45,  46,  47,  48,   // 112
                     49,  50,  51, 255,  255, 255, 255, 255,   // 120-127
        };

        ///// <summary>
        ///// Convert the input data to a base16 string.
        ///// </summary>
        ///// <param name="data">The data to convert.</param>
        ///// <returns>The resulting string.</returns>
        //public static string ToBase16String(this byte[] data) {
        //    return ToBase16String(data, data.Length);
        //    }


        /// <summary>
        /// Convert the input data to a base16 string.
        /// </summary>
        /// <param name="data">The data to convert.</param>
        /// <param name="Length">Number of bytes to convert</param>
        /// <param name="Spaced">If true, insert a space after each entry</param>
        /// <returns>The resulting string.</returns>
        public static string ToBase16String(this byte[] data, int Length = -1, bool Spaced = false) {
            var Builder = new StringBuilder();
            ToBase16String(Builder, data, Length, Spaced);
            return Builder.ToString();
            }

        /// <summary>
        /// Convert the input data to a base16 string.
        /// </summary>
        /// <param name="data">The data to convert.</param>
        /// <param name="Length">Number of bytes to convert</param>
        /// <param name="Builder">StringBuilder to collect the emitted characteres</param>
        /// <param name="Spaced">If true, insert a space after each entry</param>
        /// <returns>The resulting string.</returns>
        public static void ToBase16String(this StringBuilder Builder, byte[] data, int Length = -1, bool Spaced = false) {
            Length = (Length < 0) | Length > data.Length ? data.Length : Length;
            for (int i = 0; i<Length; i++) {
                int n1 = data[i] >>4;
                int n2 = data[i] & 0xF;
                if (Spaced) {
                    if ((i % 16) == 0) {
                        Builder.Append("\n  ");
                        }
                    else if ((i % 4) == 0) {
                        Builder.Append("  ");
                        }
                    else {
                        Builder.Append(" ");
                        }
                    }
                Builder.Append(BASE16[n1]);
                Builder.Append(BASE16[n2]);
                }
            }

        /// <summary>
        /// Convert the input data to a base32 string.
        /// </summary>
        /// <param name="data">The data to convert.</param>
        /// <param name="Length">Number of bytes to convert</param>
        /// <returns>The resulting string.</returns>
        public static string ToBase32String(this byte[] data, int Length) {
            var Builder = new StringBuilder();
            ToBase32String(Builder, data, Length);
            return Builder.ToString();
            }


        /// <summary>
        /// Convert the input data to a base32 string.
        /// </summary>
        /// <param name="data">The data to convert.</param>
        /// <param name="Length">Number of bytes to convert</param>
        /// <param name="Builder">StringBuilder to collect the emitted characteres</param>
        /// <returns>The resulting string.</returns>
        public static void ToBase32String(this StringBuilder Builder, byte[] data, int Length) {
            int offset = 0;
            int a = 0;

            for (int i = 0; i < Length; i++) {
                a = (a << 8) | data[i];
                offset += 8;

                //Console.WriteLine("{0:x4}/{2} : {1}", a, result, offset);

                while (offset >= 5) {
                    offset -= 5;

                    int n = a >> offset;
                    Builder.Append(BASE32[n]);
                    a = a & (0xff >> (8 - offset));
                    }
                }

            if (offset > 0) {
                Builder.Append(BASE32[a]);
                }
            }

        /// <summary>
        /// Convert the input data to a base32s string.
        /// </summary>
        /// <param name="data">The data to convert.</param>
        /// <param name="Length">Number of bytes to convert</param>
        /// <returns>The encoded string</returns>
        public static string ToBase32sString(this byte[] data, int Length) {
            string result = "";
            int offset = 0;
            int a = 0;

            for (int i = 0; i < Length; i++) {

                if (((i & 0x3) == 0) & i > 0) {
                    result = result + "-";
                    }

                a = (a << 8) | data[i];
                offset += 8;

                //Console.WriteLine("{0:x4}/{2:x2} : {1}", a, result, offset);

                while (offset >= 5) {
                    offset -= 5;

                    int n = a >> offset;
                    result = result + BASE32[n];
                    a = a & (0xff >> (8 - offset));
                    
                    //Console.WriteLine("{0:x4}/{2:x2} : {1}", a, result, offset);
                    //Console.WriteLine("  {0:x2}/{2:x2} : {1}", n, result, offset);
                    }
                }

            if (offset > 0) {
                result = result + BASE32[a];
                }
            return result;
            }

        /// <summary>
        /// Convert a byte array to a UDF fingerprint with the specified precision.
        /// </summary>
        /// <param name="data">The data to take the fingerprint of.</param>
        /// <param name="Precision">The precision in multiples of 25 bits.</param>
        /// <returns>The resulting string.</returns>
        public static string ToUDF(this byte[] data, int Precision) {
            var Chunks = (Precision + 24) / 25; // number of chunks
            var Characters = (Chunks * 6) - 1;

            return ToUDF32String(data, Characters);
            }

        /// <summary>
        /// Convert data to Base32/UDF string. This is a Base32 character string with 
        /// separators between each block of five characters.
        /// </summary>
        /// <param name="data">The data to convert</param>
        /// <returns>The resulting string.</returns>
        public static string ToUDF32String(this byte[] data) {

            return ToUDF32String(data, data.Length * 16);
            }

        /// <summary>
        /// Convert data to Base32/UDF string. This is a Base32 character string with 
        /// separators between each block of five characters.
        /// </summary>
        /// <param name="data">The data to convert</param>
        /// <param name="Length">The maximum number of characters in the output string
        /// (including separactors).</param>
        /// <returns>The resulting string.</returns>
        public static string ToUDF32String(this byte[] data, int Length) {
            string result = "";
            int offset = 0;
            int a = 0;


            for (int i = 0; (i < data.Length) & (result.Length < Length); i++) {
                a = (a << 8) | data[i];
                offset += 8;

                //Console.WriteLine("{0:x4}/{2} : {1}", a, result, offset);

                while ((offset >= 5) & (result.Length < Length)) {
                    offset -= 5;

                    int n = a >> offset;
                    result = result + BASE32[n];
                    a = a & (0xff >> (8 - offset));
                    if ((result.Length < Length) & (result.Length % 6 == 5)) {
                        result = result + '-';
                        }
                    }
                }

            if ((result.Length < Length) & (offset > 0)) {
                a = a << (5 - offset); // Final shift.
                result = result + BASE32[a];
                }
            return result;
            }

        /// <summary>
        /// Convert data to Base32HS string.
        /// </summary>
        /// <param name="data">The data to convert</param>
        /// <param name="Length">The maximum number of characters in the output string</param>
        /// <returns>The resulting string.</returns>
        public static string ToBase32hsString(this byte[] data, int Length) {
            string result = "";
            int offset = 0;
            int a = 0;

            for (int i = 0; i < Length; i++) {

                if (((i & 0x3) == 0) & i > 0) {
                    result = result + "-";
                    }

                a = (a << 8) | data[i];
                offset += 8;

                //Console.WriteLine("{0:x4}/{2} : {1}", a, result, offset);

                while (offset >= 5) {
                    offset -= 5;

                    int n = a >> offset;
                    result = result + BASE32HEX[n];
                    a = a & (0xff >> (8 - offset));
                    }
                }

            if (offset > 0) {
                result = result + BASE32[a];
                }
            return result;
            }


        /// <summary>
        /// Convert data to Base64urlString string. 
        /// </summary>
        /// <param name="data">The data to convert</param>
        /// <param name="Newline">If true insert newline characters every 48 characters</param>
        /// <returns>The resulting string.</returns>
        public static string ToBase64urlString(this byte[] data, bool Newline) {
            return ToBase64urlString (data, 0, data.Length, Newline);
            }

        /// <summary>
        /// Convert data to Base64urlString string. 
        /// </summary>
        /// <param name="data">The data to convert</param>
        /// <returns>The resulting string.</returns>            
        public static string ToBase64urlString(this byte[] data) {
            return ToBase64urlString (data, data.Length);
            }

        /// <summary>
        /// Convert data to Base64urlString string. 
        /// </summary>
        /// <param name="data">The data to convert</param>
        /// <param name="Length">The number of bytes from the input stream to convert.</param>
        /// <returns>The resulting string.</returns>
        public static string ToBase64urlString(this byte[] data, int Length) {
            return ToBase64urlString (data, 0, Length, true);
            }

        /// <summary>
        /// Convert data to Base64urlString string. 
        /// </summary>
        /// <param name="data">The data to convert</param>
        /// <param name="First">The first byte in the input stream to convert</param>
        /// <param name="Length">The number of bytes from the input stream to convert.</param>
        /// <param name="Newline">If true insert newline characters every 48 characters</param>
        /// <returns>The resulting string.</returns>
        public static string ToBase64urlString(this byte[] data, int First, int Length, bool Newline) {
            var Builder = new StringBuilder();
            ToBase64urlString(Builder, data, First, Length, Newline);
            return Builder.ToString();
            }

        /// <summary>
        /// Convert data to Base64urlString string. 
        /// </summary>
        /// <param name="Builder">String builder to append data to</param>
        /// <param name="data">The data to convert</param>
        /// <param name="First">The first byte in the input stream to convert</param>
        /// <param name="Length">The number of bytes from the input stream to convert.</param>
        /// <param name="Newline">If true insert newline characters every 48 characters</param>
        /// <returns>The resulting string.</returns>
        public static void ToBase64urlString(this StringBuilder Builder, byte[] data, int First, int Length, bool Newline) {
            int offset = 0;
            int a = 0;
            int Last = First + Length;

            for (int i = First; i < Last; i++) {
                if (Newline & ((i % 48) == 0)) {
                    Builder.Append('\n');
                    }

                a = (a << 8) | data[i];
                offset += 8;

                //Console.WriteLine ("{0:x4}/{2:3} : {1}", a, result, offset);

                while (offset >= 6) {
                    offset -= 6;

                    int n = a >> offset;
                    Builder.Append(BASE64URL[n]);
                    a = a & (0xff >> (8 - offset));
                    }
                }
            if (offset > 0) {
                Builder.Append(BASE64URL[a << (6 - offset)]);
                // No trailing = characters in Base64URL encoding.
                }
            }

        /// <summary>
        /// Convert data to Base64urlString string. 
        /// </summary>
        /// <param name="data">The data to convert</param>
        /// <param name="Newline">If true insert newline characters every 48 characters</param>
        /// <returns>The resulting string.</returns>
        public static string ToBase64String(this byte[] data, bool Newline) {
            return ToBase64String(data, 0, data.Length, Newline);
            }

        /// <summary>
        /// Convert data to Base64urlString string. 
        /// </summary>
        /// <param name="data">The data to convert</param>
        /// <returns>The resulting string.</returns>
        public static string ToBase64String(this byte[] data) {
            return ToBase64String(data, data.Length);
            }

        /// <summary>
        /// Convert data to Base64urlString string. 
        /// </summary>
        /// <param name="data">The data to convert</param>
        /// <param name="Length">The number of bytes from the input stream to convert.</param>
        /// <returns>The resulting string.</returns>
        public static string ToBase64String(this byte[] data, int Length) {
            return ToBase64String(data, 0, Length, true);
            }

        /// <summary>
        /// Convert data to Base64urlString string. 
        /// </summary>
        /// <param name="data">The data to convert</param>
        /// <param name="First">The first byte in the input stream to convert</param>
        /// <param name="Length">The number of bytes from the input stream to convert.</param>
        /// <param name="Newline">If true insert newline characters every 48 characters</param>
        /// <returns>The resulting string.</returns>
        public static string ToBase64String(this byte[] data, int First, int Length, bool Newline) {
            var Builder = new StringBuilder();
            ToBase64String(Builder, data, First, Length, Newline);
            return Builder.ToString();
            }

        /// <summary>
        /// Convert data to Base64urlString string. 
        /// </summary>
        /// <param name="Builder">String builder to append data to</param>
        /// <param name="data">The data to convert</param>
        /// <param name="First">The first byte in the input stream to convert</param>
        /// <param name="Length">The number of bytes from the input stream to convert.</param>
        /// <param name="Newline">If true insert newline characters every 48 characters</param>
        public static void ToBase64String(this StringBuilder Builder, byte[] data, int First, int Length, bool Newline) {

            int offset = 0;
            int a = 0;
            int Last = First + Length;

            for (int i = First; i < Last; i++) {
                if (Newline & ((i % 48) == 0)) {
                    Builder.Append ('\n');
                    }

                a = (a << 8) | data[i];
                offset += 8;

                //Console.WriteLine ("{0:x4}/{2:3} : {1}", a, result, offset);

                while (offset >= 6) {
                    offset -= 6;

                    int n = a >> offset;
                    Builder.Append(BASE64[n]);
                    a = a & (0xff >> (8 - offset));
                    }
                }
            if (offset > 0) {
                Builder.Append(BASE64[a << (6 - offset)]);

                // The trailing characters are not always required by software but are
                // required by the Base64 specification.
                if (offset == 6) {
                    Builder.Append("=="); // just one partial character
                    }
                else {
                    Builder.Append("="); // One full, one partial character
                    }
                }
            }


        /// <summary>
        /// Convert Base64/Base64URL character string data to binary data. Note
        /// that because the two character sets are unambiguous, a single conversion
        /// function converts both types of data.
        /// </summary>
        /// <param name="Data">The string to convert</param>
        /// <returns>The resulting binary data.</returns>
        public static byte[] FromBase64urlString(this string Data) {
            int Bits = 0;
            // count bytes

            foreach (char c in Data) {
                if ((c < 128) && (BASE64URLValue[c]<64)) {
                    Bits += 6;
                    }
                }

            byte [] Result = new byte [Bits/8];
            uint Register = 0;
            Bits = 0;

            int Index = 0;
            foreach (char c in Data) {
                if ((c < 128) && (BASE64URLValue[c]<64)) {
                    Register = (Register << 6) | BASE64URLValue[c];
                    Bits += 6;
                    if (Bits >= 8) {
                        Bits -= 8;
                        Result [Index++] = (Byte) (Register >> Bits);
                        }
                    }
                }

            return Result;
            }

        /// <summary>
        /// Convert Base32 character string data to binary data.
        /// </summary>
        /// <param name="Data">The string to convert</param>
        /// <returns>The resulting binary data.</returns>
        public static byte[] FromBase32String(this string Data) {
            int Bits = 0;
            // count bytes

            foreach (char c in Data) {
                if ((c < 128) && (BASE32Value[c] < 32)) {
                    Bits += 5;
                    }
                }

            byte[] Result = new byte[Bits / 8];
            uint Register = 0;
            Bits = 0;

            int Index = 0;
            foreach (char c in Data) {
                if ((c < 128) && (BASE32Value[c] < 32)) {
                    Register = (Register << 5) | BASE32Value[c];
                    Bits += 5;
                    if (Bits >= 8) {
                        Bits -= 8;
                        Result[Index++] = (Byte)(Register >> Bits);
                        }
                    }
                }

            return Result;
            }

        /// <summary>
        /// Convert Base16 character string data to binary data.
        /// </summary>
        /// <param name="Data">The string to convert</param>
        /// <returns>The resulting binary data.</returns>
        public static byte[] FromBase16String(this string Data) {
            int Length = 0;

            foreach (var c in Data) {
                if ((c < 128) && (BASE16Value[c]<16)) {
                    Length++;
                    }
                }
            Length = Length / 2;
            var Result = new byte[Length];

            bool Upper = true;
            byte Store = 0;
            Length = 0;

            foreach (var c in Data) {
                if ((c < 128) && (BASE16Value[c] < 16)) {
                    if (Upper) {
                        Store = BASE16Value[c];
                        }
                    else {
                        Result[Length] = (byte)((Store * 16) + BASE16Value[c]);
                        Length++;
                        }
                    Upper = !Upper;
                    }
                }
            return Result;
            }
        }
    }
