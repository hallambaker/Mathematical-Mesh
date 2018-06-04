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
using System.Collections.Generic;
using Goedel.Utilities;

namespace Goedel.Cryptography {
    /// <summary>
    /// Constants used in building UDF values.
    /// </summary>
    public partial class UDFConstants {
        /// <summary>
        /// Key identifier for UDF using SHA-2-512
        /// </summary>
        public static int KeyIdentifierAlgSHA_2_512 = 96;

        /// <summary>
        /// Key identifier for UDF using SHA-3-512
        /// </summary>
        public static int KeyIdentifierAlgSHA_3_512 = 144;

        /// <summary>
        /// Key identifier for UDF from random digits
        /// </summary>
        public static int KeyIdentifierAlgRandom = 136;


        /// <summary>
        /// Content type identifier for PKIX KeyInfo data type
        /// </summary>
        public const string PKIXKey = "application/x509-keyinfo";

        /// <summary>
        /// Content type identifier for OpenPGP Key
        /// </summary>
        public const string OpenPGPKey = "application/openpgp-key";

        /// <summary>
        /// Content type for mesh escrowed key
        /// </summary>
        public const string EscrowedKey = "application/mmm-escrowed";

        /// <summary>
        /// UDF Fingerprint list
        /// </summary>
        public const string UDF = "application/udf";
        }

    /// <summary>
    /// Class implementing the Uniform Data Fingerprint spec.
    /// </summary>
    public static class UDF {
        /// <summary>
        /// Default number of UDF bits (usually 150).
        /// </summary>
        public static int DefaultBits { get; set; } = 150;

        /// <summary>
        /// Compute UDF from binary data and content type with specified precision.
        /// </summary>
        /// <param name="ContentType">MIME media type. See 
        /// http://www.iana.org/assignments/media-types/media-types.xhtml for list.</param>
        /// <param name="Data">Data to be fingerprinted.</param>
        /// <param name="Bits">Precision, must be a multiple of 25 bits.</param>
        /// <returns>The binary UDF fingerprint.</returns>
        public static byte[] From(string ContentType, byte[] Data, int Bits) {
            Bits = Bits == 0 ? DefaultBits : Bits;

            var UDFDataBuffer = UDFBuffer(ContentType, Data);
            var UDFData = Platform.SHA2_512.Process(UDFDataBuffer);

            var TotalBits = Bits;
            var FullBytes = TotalBits / 8;
            var ExtraBits = TotalBits % 8;
            var TotalBytes = ExtraBits == 0 ? FullBytes : FullBytes + 1;

            byte[] Output = new byte[TotalBytes];
            Output[0] = (byte)UDFConstants.KeyIdentifierAlgSHA_2_512;
            for (var j = 0; j < FullBytes - 1; j++) {
                Output[j + 1] = UDFData[j];
                }

            if (ExtraBits > 0) {
                Output[TotalBytes - 1] = (byte)(UDFData[FullBytes - 1] << (8 - ExtraBits) & 0xff);
                }

            return Output;
            }


        /// <summary>
        /// Compute UDF from binary data and content type with specified precision.
        /// </summary>
        /// <param name="ContentType">MIME media type. See 
        /// http://www.iana.org/assignments/media-types/media-types.xhtml for list.</param>
        /// <param name="Data">Data to be fingerprinted.</param>
        /// <param name="Bits">Precision, must be a multiple of 25 bits.</param>
        /// <returns>The binary UDF fingerprint.</returns>
        public static byte[] From3 (string ContentType, byte[] Data, int Bits) {
            Bits = Bits == 0 ? DefaultBits : Bits;

            var UDFDataBuffer = UDFBuffer3(ContentType, Data);
            var UDFData = Platform.SHA3_512.Process(UDFDataBuffer);

            var TotalBits = Bits;
            var FullBytes = TotalBits / 8;
            var ExtraBits = TotalBits % 8;
            var TotalBytes = ExtraBits == 0 ? FullBytes : FullBytes + 1;

            byte[] Output = new byte[TotalBytes];
            Output[0] = (byte)UDFConstants.KeyIdentifierAlgSHA_3_512;
            for (var j = 0; j < FullBytes - 1; j++) {
                Output[j + 1] = UDFData[j];
                }

            if (ExtraBits > 0) {
                Output[TotalBytes - 1] = (byte)(UDFData[FullBytes - 1] << (8 - ExtraBits) & 0xff);
                }

            return Output;
            }


        static int CountLeadingZeros (int Data) {
            int Result = 0;
            for (var i = 0; i < 8; i++) {
                if (Data >= 0x80) {
                    return Result;
                    }
                Result++;
                Data = Data <<1;
                }

            return Result;
            }

        /// <summary>
        /// Count leading zero bits in a data array.
        /// </summary>
        /// <param name="Data">Input array.</param>
        /// <returns>The number of leading zero bits, counting the MSB of each byte first.</returns>
        public static int CountLeadingZeros (byte[] Data) {
            int Result = 0;

            for (var i = 0; i < Data.Length; i++) {
                if (Data[i] != 0) {
                    return Result + CountLeadingZeros(Data[i]);
                    }
                Result += 8;

                }

            return Result;
            }

        /// <summary>
        /// Calculate a UDF Hash value without prefixing the version.
        /// </summary>
        /// <param name="ContentType">MIME media type. See 
        /// http://www.iana.org/assignments/media-types/media-types.xhtml for list.</param>
        /// <param name="Data">Data to be fingerprinted.</param>
        /// <returns>SHA2-512 (UTF8(ContentType) + ":" + SHA2512(Data))</returns>
        public static byte[] UDFBuffer (string ContentType, byte[] Data) {
            var HashData = Platform.SHA2_512.Process(Data);
            var Tag = Encoding.UTF8.GetBytes(ContentType);
            var Input = new byte[HashData.Length + Tag.Length + 1];

            Input.AppendChecked(0, Tag);
            Input[Tag.Length] = (byte)':';
            Input.AppendChecked(Tag.Length + 1, HashData);
            return Input;

            }


        /// <summary>
        /// Calculate a UDF Hash value without prefixing the version.
        /// </summary>
        /// <param name="ContentType">MIME media type. See 
        /// http://www.iana.org/assignments/media-types/media-types.xhtml for list.</param>
        /// <param name="Data">Data to be fingerprinted.</param>
        /// <returns>SHA2-512 (UTF8(ContentType) + ":" + SHA2512(Data))</returns>
        public static byte[] UDFBuffer3 (string ContentType, byte[] Data) {
            var HashData = Platform.SHA3_512.Process(Data);
            var Tag = Encoding.UTF8.GetBytes(ContentType);
            var Input = new byte[HashData.Length + Tag.Length + 1];

            Input.AppendChecked(0, Tag);
            Input[Tag.Length] = (byte)':';
            Input.AppendChecked(Tag.Length + 1, HashData);
            return Input;

            }

        /// <summary>
        /// Calculate a UDF Hash value without prefixing the version.
        /// </summary>
        /// <param name="ContentType">MIME media type. See 
        /// http://www.iana.org/assignments/media-types/media-types.xhtml for list.</param>
        /// <param name="Data">Data to be fingerprinted.</param>
        /// <returns>SHA2-512 (UTF8(ContentType) + ":" + SHA2512(Data))</returns>
        public static byte[] UDFHashSHA2x (string ContentType, byte[] Data) {
            var HashData = Platform.SHA2_512.Process(Data);
            var Tag = Encoding.UTF8.GetBytes(ContentType);
            var Input = new byte[HashData.Length + Tag.Length+1];



            Input.AppendChecked(0, HashData);
            Input[HashData.Length] = (byte)':';
            Input.AppendChecked(HashData.Length+1, Tag);

            return Platform.SHA2_512.Process(Input);

            }


        /// <summary>
        /// Calculate a UDF fingerprint from a secret key used to escrow a private
        /// key in the mesh.
        /// </summary>
        /// <param name="Data">Data to be fingerprinted.</param>
        /// <param name="Bits">Precision, must be a multiple of 25 bits.</param>
        /// <returns>The binary UDF fingerprint.</returns>
        public static byte[] FromEscrowed(byte[] Data, int Bits = 0) => From(UDFConstants.EscrowedKey, Data, Bits);


        /// <summary>
        /// Calculate a UDF fingerprint from a PKIX KeyInfo blob with specified precision.
        /// </summary>
        /// <param name="Data">Data to be fingerprinted.</param>
        /// <returns>The binary UDF fingerprint.</returns>
        public static byte[] FromKeyInfo(byte[] Data) => From(UDFConstants.PKIXKey, Data, DefaultBits);

        /// <summary>
        /// Calculate a UDF fingerprint from a PKIX KeyInfo blob with specified precision.
        /// </summary>
        /// <param name="Data">Data to be fingerprinted.</param>
        /// <param name="Bits">Precision, must be a multiple of 25 bits.</param>
        /// <returns>The binary UDF fingerprint.</returns>
        public static byte[] FromKeyInfo(byte[] Data, int Bits = 0) => From(UDFConstants.PKIXKey, Data, Bits);

        /// <summary>
        /// Calculate a UDF fingerprint from a pair of fingerprints with specified precision.
        /// </summary>
        /// <param name="UDF1">First fingerprint</param>
        /// <param name="UDF2">Second fingerprint</param>
        /// <param name="Bits">Precision, must be a multiple of 25 bits.</param>
        /// <returns>The binary UDF fingerprint.</returns>
        public static string FromUDFPair (string UDF1, string UDF2, int Bits = 0) {
            var Builder = new StringBuilder();
            Builder.Append(UDF1);
            Builder.Append(":");
            Builder.Append(UDF2);
            Builder.Append(":");
            return ToString(UDFConstants.UDF, Builder.ToString().ToUTF8(), Bits);
            }


        /// <summary>
        /// Calculate a UDF fingerprint from an OpenPGP key with specified precision.
        /// </summary>
        /// <param name="ContentType">MIME media type of data being fingerprinted.</param>
        /// <param name="Data">Data to be fingerprinted.</param>
        /// <param name="Bits">Precision, must be a multiple of 25 bits.</param>
        /// <returns>The binary UDF fingerprint.</returns>
        public static string ToString(string ContentType, byte[] Data, int Bits=0) {
            Bits = Bits == 0 ? DefaultBits : Bits;
            var Bytes = From(ContentType, Data, Bits);
            var Length = 5 * (Bits / 25);

            return Bytes.ToStringBase32(Format: ConversionFormat.Dash5, OutputMax: Length);
            }

        /// <summary>
        /// Calculate a UDF fingerprint from an OpenPGP key with specified precision.
        /// </summary>
        /// <param name="ContentType">MIME media type of data being fingerprinted.</param>
        /// <param name="Data">Data to be fingerprinted.</param>
        /// <param name="Bits">Precision, must be a multiple of 25 bits.</param>
        /// <returns>The binary UDF fingerprint.</returns>
        public static string ToString3 (string ContentType, byte[] Data, int Bits = 0) {
            Bits = Bits == 0 ? DefaultBits : Bits;
            var Bytes = From3(ContentType, Data, Bits);
            var Length = 5 * (Bits / 25);

            return Bytes.ToStringBase32(Format: ConversionFormat.Dash5, OutputMax: Length);
            }


        /// <summary>
        /// Convert a binary UDF to a string.
        /// </summary>
        /// <param name="Data">Input data.</param>
        /// <returns>The UDF value as a string.</returns>
        public static string ToString(byte[] Data) => Data.ToStringBase32(Format: ConversionFormat.Dash5);


        /// <summary>
        /// Return a random sequence as a UDF 
        /// </summary>
        /// <returns>A randomly generated UDF string.</returns>
        public static string Random() => Random(DefaultBits);

        /// <summary>
        /// Return a random sequence as a UDF 
        /// </summary>
        /// <param name="Bits">Number of bits in the string</param>
        /// <returns>A randomly generated UDF string.</returns>
        public static string Random (int Bits) {
            var Data = CryptoCatalog.GetBits(Bits);
            Data[0] = (byte)UDFConstants.KeyIdentifierAlgRandom;
            return ToString(Data);


            }

        /// <summary>
        /// Check that a UDF fingerprint satisfies a test value. At present
        /// the test must be exact. It is possible that this can be relaxed
        /// so that a longer fingerprint will satisfy a shorter one.
        /// </summary>
        /// <param name="Test">Expected value</param>
        /// <param name="Value">Comparison value.</param>
        public static void Validate(string Test, string Value) => Assert.False(Test != Value, FingerprintMatchFailed.Throw);

        /// <summary>Convert address and fingerprint value to Strong Internet Name.</summary>
        /// <param name="Address">DNS address.</param>
        /// <param name="UDF">Fingerprint value.</param>
        /// <returns>The strong name.</returns>
        public static string MakeStrongName(string Address, string UDF) => Address + ".mm--" + UDF.ToLower();

        /// <summary>Parse an RFC822 address to extract strong name component if present.</summary>
        /// <param name="Address">The Internet address.</param>
        /// <param name="In">The address to parse.</param>
        /// <param name="UDF">The strong name fingerprint (if found).</param>
        public static void ParseStrongRFC822 (string In, out string Address, out string UDF) {
            var Split = In.Split('@');
            UDF = null;

            if ((Split.Length <= 0) | (Split.Length > 2)) {
                Address = In;
                return;
                }



            if (Split.Length == 1) {
                Address = Split[0];
                return;
                }

            var DNS = Split[1].ToLower().Split('.');

            var Builder = new StringBuilder(Split[0]);
            Builder.Append('@');

            var First = true;
            foreach (var Label in DNS) {
                if (Label.StartsWith("mm--")) {
                    UDF = Label.Substring(4);
                    }
                else {
                    if (!First) {
                        Builder.Append('.');
                        }
                    First = false;
                    Builder.Append(Label);
                    }
                }

            Address = Builder.ToString();
            }



        }

    /// <summary>Static class containing static extension methods providing convenience functions.</summary>
    public static partial class Extension {
        /// <summary>
        /// Compare a fingerprint to see that it matches the specified pattern according
        /// to UDF matching rules. Currently, the method only converts strings to lower 
        /// case, it does not canonicalize.
        /// </summary>
        /// <param name="Pattern">The pattern the candidate is being tested for a match against.</param>
        /// <param name="UDF">The candidate being tested</param>
        /// <returns>True if the patterns match, otherwise false.</returns>
        public static bool CompareUDF (this string Pattern, string UDF) {
            if (UDF.Length < Pattern.Length) {
                return false;
                }
            if (UDF.Length == Pattern.Length) {
                return Pattern.ToLower() == UDF.ToLower();
                }
            return Pattern.ToLower().StartsWith(UDF.ToLower());
            }

        /// <summary>
        /// Calculate a UDF fingerprint from specified ContentType with specified precision.
        /// </summary>
        /// <param name="ContentType">MIME media type of data being fingerprinted.</param>
        /// <param name="Data">Data to be fingerprinted.</param>
        /// <param name="Bits">Precision, must be a multiple of 25 bits.</param>
        /// <returns>The UDF fingerprint.</returns>
        public static string UTF8String(this byte[] Data, string ContentType, int Bits = 125) => UDF.ToString(ContentType, Data, Bits);

        }
    }
