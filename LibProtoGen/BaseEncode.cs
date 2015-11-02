using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Goedel.Protocol  {
    public partial class BaseConvert {

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

        private static byte[] BASE32HexValue = new byte[] {
                    255, 255, 255, 255,  255, 255, 255, 255,   //  0-7
                    255, 255, 255, 255,  255, 255, 255, 255,   //  8-15
                    255, 255, 255, 255,  255, 255, 255, 255,   //  16-23
                    255, 255, 255, 255,  255, 255, 255, 255,   //  24-31
                    255, 255, 255, 255,  255, 255, 255, 255,   //  32-39
                    255, 255, 255, 255,  255, 255, 255, 255,   //  40
                      0,   1,   2,   3,    4,   5,   6,   7,   //  48
                      8,   9, 255, 255,  255, 255, 255, 255,   //  56
                    255,  10,  11,  12,   13,  14,  15,  16,   //  64
                     17,  18,  19,  20,   21,  22,  23,  24,   //  72
                     25,  26,  27,  28,   29,  30,  31, 255,   //  80-87
                    255, 255, 255, 255,  255, 255, 255, 255,   //  88
                    255,  10,  11,  12,   13,  14,  15,  16,   //  96
                     17,  18,  19,  20,   21,  22,  23,  24,   // 104
                     25,  26,  27,  28,   29,  30,  31, 255,   // 112
                    255, 255, 255, 255,  255, 255, 255, 255,   // 120-127

        };


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


        public static string ToBase16String (byte [] data, int Length) {
            string      result = "";

            for (int i = 0; i<Length; i++) {
                //Console.WriteLine ("{0:x2}", data [i]);

                int n1 = data[i] >>4;
                int n2 = data[i] & 0xF;
                
                result = result + BASE16 [n1] + BASE16 [n2];
                }

            //Console.WriteLine ("   {0}", result);
            return result;
            }

        public static string ToBase32String(byte[] data, int Length) {
            string result = "";
            int offset = 0;
            int a = 0;

            for (int i = 0; i < Length; i++) {
                a = (a << 8) | data[i];
                offset += 8;

                //Console.WriteLine("{0:x4}/{2} : {1}", a, result, offset);

                while (offset >= 5) {
                    offset -= 5;

                    int n = a >> offset;
                    result = result + BASE32[n];
                    a = a & (0xff >> (8 - offset));
                    }
                }

            if (offset > 0) {
                result = result + BASE32[a];
                }
            return result;
            }

        public static string ToBase32sString(byte[] data, int Length) {
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
        /// <param name="Precision">The precision in multiples of 150 bits.</param>
        /// <returns></returns>
        public static string ToUDF(byte[] data, int Precision) {
            var Chunks = (Precision + 24) / 25; // number of chunks
            var Characters = (Chunks * 6) - 1;

            return ToUDF32String(data, Characters);
            }

        // Convenience function, encode whole data item.
        public static string ToUDF32String(byte[] data) {

            return ToUDF32String(data, data.Length * 16);
            }

        public static string ToUDF32String(byte[] data, int Length) {
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


        public static string ToBase32hsString(byte[] data, int Length) {
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

        public static string ToBase64urlString(byte[] data, bool Newline) {
            return ToBase64urlString (data, data.Length, Newline);
            }        
        public static string ToBase64urlString(byte[] data) {
            return ToBase64urlString (data, data.Length);
            }

        public static string ToBase64urlString(byte[] data, int Length) {
            return ToBase64urlString (data, Length, true);
            }


        public static string ToBase64urlString(byte[] data, int Length, bool Newline) {
            string result = "";
            int offset = 0;
            int a = 0;

            for (int i = 0; i < Length; i++) {
                if (Newline & ((i % 48) == 0)) {
                    result += '\n';
                    }

                a = (a << 8) | data[i];
                offset += 8;

                //Console.WriteLine ("{0:x4}/{2:3} : {1}", a, result, offset);

                while (offset >= 6) {
                    offset -= 6;

                    int n = a >> offset;
                    result = result + BASE64URL[n];
                    a = a & (0xff >> (8 - offset));
                    }
                }
            if (offset > 0) {
                result = result + BASE64URL[a << (6 - offset)];
                }
            return result;
            }

        public static StreamBuffer Base64urlToBuffer (string Data) {
            StreamBuffer StreamBuffer = new StreamBuffer ();

            foreach (char c in Data) {


                }

            return StreamBuffer;
            }

        public static byte[] Base64urlToBytes (string Data) {
            StreamBuffer StreamBuffer = Base64urlToBuffer (Data);
            return StreamBuffer.GetBytes;
            }

        public static byte[] Base64urlToString (string Data) {
            StreamBuffer StreamBuffer = Base64urlToBuffer (Data);
            return StreamBuffer.GetBytes;
            }


        public static byte[] FromBase64urlString(string Data) {
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


        public static byte[] FromBase32String(string Data) {
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

        public static byte[] FromBase16String(string Input) {
            int Length = 0;

            foreach (var c in Input) {
                if ((c < 128) && (BASE16Value[c]<16)) {
                    Length++;
                    }
                }
            Length = Length / 2;
            var Result = new byte[Length];

            bool Upper = true;
            byte Store = 0;
            Length = 0;

            foreach (var c in Input) {
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
