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
using System.Security.Cryptography;
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
        }

    /// <summary>
    /// Class implementing the Uniform Data Fingerprint spec.
    /// </summary>
    public class UDF {

        static int _DefaultBits = 150;
        /// <summary>
        /// Default number of UDF bits (usually 150).
        /// </summary>
        public static int DefaultBits {
            get { return _DefaultBits; }
            set { _DefaultBits = value; }
            }

        /// <summary>
        /// Compute UDF from binary data and content type with specified precision.
        /// </summary>
        /// <param name="ContentType">MIME media type. See 
        /// http://www.iana.org/assignments/media-types/media-types.xhtml for list.</param>
        /// <param name="Data">Data to be fingerprinted.</param>
        /// <param name="Bits">Precision, must be a multiple of 25 bits.</param>
        /// <returns>The binary UDF fingerprint.</returns>
        public static byte[] From(string ContentType, byte[] Data, int Bits) {
            SHA512 SHA512 = new SHA512Cng();
            byte[] HashData = SHA512.ComputeHash(Data);

            SHA512.Initialize();

            var Tag = Encoding.UTF8.GetBytes(ContentType);
            byte[] Input = new byte[HashData.Length + Tag.Length + 1];

            int i = 0;
            foreach (var Byte in Tag) {
                Input[i++] = Byte;
                }
            Input[i++] = (byte)':';
            foreach (var Byte in HashData) {
                Input[i++] = Byte;
                }

            SHA512.Initialize();
            byte[] UDFData = SHA512.ComputeHash(Input);

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
        /// Calculate a UDF fingerprint from a secret key used to escrow a private
        /// key in the mesh.
        /// </summary>
        /// <param name="Data">Data to be fingerprinted.</param>
        /// <param name="Bits">Precision, must be a multiple of 25 bits.</param>
        /// <returns>The binary UDF fingerprint.</returns>
        public static byte[] FromEscrowed(byte[] Data, int Bits) {
            return From(UDFConstants.EscrowedKey, Data, Bits);
            }


        /// <summary>
        /// Calculate a UDF fingerprint from a PKIX KeyInfo blob with specified precision.
        /// </summary>
        /// <param name="Data">Data to be fingerprinted.</param>
        /// <returns>The binary UDF fingerprint.</returns>
        public static byte[] FromKeyInfo(byte[] Data) {
            return From(UDFConstants.PKIXKey, Data, DefaultBits);
            }

        /// <summary>
        /// Calculate a UDF fingerprint from a PKIX KeyInfo blob with specified precision.
        /// </summary>
        /// <param name="Data">Data to be fingerprinted.</param>
        /// <param name="Bits">Precision, must be a multiple of 25 bits.</param>
        /// <returns>The binary UDF fingerprint.</returns>
        public static byte[] FromKeyInfo(byte[] Data, int Bits) {
            return From(UDFConstants.PKIXKey, Data, Bits);
            }

        /// <summary>
        /// Calculate a UDF fingerprint from an OpenPGP key with specified precision.
        /// </summary>
        /// <param name="ContentType">MIME media type of data being fingerprinted.</param>
        /// <param name="Data">Data to be fingerprinted.</param>
        /// <param name="Bits">Precision, must be a multiple of 25 bits.</param>
        /// <returns>The binary UDF fingerprint.</returns>
        public static string ToString(string ContentType, byte[] Data, int Bits) {
            var Bytes = From(ContentType, Data, Bits);
            return BaseConvert.ToUDF32String(Bytes);
            }

        /// <summary>
        /// Convert a binary UDF to a string.
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public static string ToString(byte[] Data) {
            int Length = (6 * ((Data.Length * 8) / 25)) - 1;
            return BaseConvert.ToUDF32String(Data, Length);
            }

        /// <summary>
        /// Calculate a SHA-1 fingerprint
        /// </summary>
        /// <param name="Data">Data to be fingerprinted</param>
        /// <returns>Fingerprint.</returns>
        public static byte[] SHA1 (byte[] Data) {
            var Provider = new CryptoProviderSHA1();
            var Result = Provider.Process(Data);
            return Result.Integrity;
            }

        /// <summary>
        /// Calculate a SHA-1 fingerprint
        /// </summary>
        /// <param name="Data">Data to be fingerprinted</param>
        /// <returns>Fingerprint.</returns>
        public static byte[] SHA256(byte[] Data) {
            var Provider = new CryptoProviderSHA2_256();
            var Result = Provider.Process(Data);
            return Result.Integrity;
            }



        /// <summary>
        /// Return a random sequence as a UDF 
        /// </summary>
        /// <returns></returns>
        public static string Random() {
            return Random(DefaultBits);
            }

        /// <summary>
        /// Return a random sequence as a UDF 
        /// </summary>
        /// <param name="Bits"></param>
        /// <returns></returns>
        public static string Random (int Bits) {
            var Data = CryptoCatalog.GetBits(Bits);
            return ToString("application/random", Data, Bits);


            }

        /// <summary>
        /// Check that a UDF fingerprint satisfies a test value. At present
        /// the test must be exact. It is possible that this can be relaxed
        /// so that a longer fingerprint will satisfy a shorter one.
        /// </summary>
        /// <param name="Test"></param>
        /// <param name="Value"></param>
        public static void Validate (string Test, string Value) {
            if (Test != Value) {
                throw new Exception("Fingerprints don't match");
                }

            }
        }
    }
