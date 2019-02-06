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
    /// UDF Prefix values
    /// </summary>
    public enum UDFPrefix {
        /// <summary>
        /// Key identifier for Keyed UDF using SHA-2-512
        /// </summary>
        KeyIdentifierAlgHMAC_SHA_2_512 = 80,

        /// <summary>
        /// Key identifier for Keyed UDF using SHA-2-512
        /// </summary>
        KeyIdentifierAlgHMAC_SHA_3_512 = 81,

        /// <summary>
        /// Key identifier for UDF using SHA-2-512
        /// </summary>
        KeyIdentifierAlgSHA_2_512 = 96,

        /// <summary>
        /// Key identifier for UDF using SHA-3-512
        /// </summary>
        KeyIdentifierAlgSHA_3_512 = 144,

        /// <summary>
        /// Key identifier for UDF from random digits
        /// </summary>
        KeyIdentifierAlgRandom = 136
        }

    /// <summary>
    /// Constants used in building UDF values.
    /// </summary>
    public partial class UDFConstants {



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

        // Test: Matching UDF values against strings.

        // Goal: Eliminate all UDF string values in profiles and use binary blobs for comparison





        /// <summary>
        /// Default number of UDF bits (usually 150).
        /// </summary>
        public static int DefaultBits { get; set; } = 125;

        /// <summary>
        /// Calculate a UDF fingerprint from an OpenPGP key with specified precision.
        /// </summary>
        /// <param name="contentType">MIME media type of data being fingerprinted.</param>
        /// <param name="data">Data to be fingerprinted.</param>
        /// <param name="bits">Precision, must be a multiple of 25 bits.</param>
        /// <param name="cryptoAlgorithmID">The cryptographic digest to use to compute
        /// the hash value.</param>
        /// <param name="key">Optional key used to create a keyed fingerprint.</param>
        /// <returns>The binary UDF fingerprint.</returns>
        public static byte[] DataToUDF(
                byte[] data,
            string contentType,
            int bits = 0,
            CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.SHA_2_512,
            string key = null) {
            switch (cryptoAlgorithmID) {
                case CryptoAlgorithmID.SHA_2_512: {
                    return DigestToUDF(Platform.SHA2_512.Process(data),
                        contentType, bits, cryptoAlgorithmID, key);
                    }
                case CryptoAlgorithmID.SHA_3_512: {
                    return DigestToUDF(Platform.SHA3_512.Process(data),
                        contentType, bits, cryptoAlgorithmID, key);
                    }
                }
            throw new InvalidAlgorithm();
            }

        /// <summary>
        /// Convert TextKey to the MAC key.
        /// </summary>
        /// <param name="textKey">The key.</param>
        /// <param name="length">The number of bits to return (defaults to the MAC output)</param>
        /// <param name="algorithm">The MAC algorithm to use.</param>
        /// <returns>The corresponding MAC key.</returns>
        public static byte[] ConvertKey(string textKey, int length=0,
                CryptoAlgorithmID algorithm = CryptoAlgorithmID.HMAC_SHA_2_512) {
            var keyDerive = new KeyDeriveHKDF(textKey.ToUTF8(), KeyDerive.KeyedUDFMaster, algorithm);
            return keyDerive.Derive(KeyDerive.KeyedUDFExpand, length);
            }


        /// <summary>
        /// Calculate a UDF fingerprint from an OpenPGP key with specified precision.
        /// </summary>
        /// <param name="contentType">MIME media type of data being fingerprinted.</param>
        /// <param name="digest">Digest of the data to be fingerprinted.</param>
        /// <param name="bits">Precision, must be a multiple of 25 bits.</param>
        /// <param name="cryptoAlgorithmID">The cryptographic digest to use to compute
        /// the hash value.</param>
        /// <param name="key">Optional key used to create a keyed fingerprint.</param>
        /// <returns>The binary UDF fingerprint.</returns>
        public static byte[] DigestToUDF(
                byte[] digest,
            string contentType,
            int bits = 0,
            CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.SHA_2_512,
            string key = null) {
            var buffer = UDFBuffer(digest, contentType);

            return BufferDigestToUDF(buffer, bits, cryptoAlgorithmID, key);
            }

        /// <summary>
        /// Calculate a UDF fingerprint from an OpenPGP key with specified precision.
        /// </summary>
        /// <param name="buffer">The prepared data buffer.</param>
        /// <param name="bits">Precision, must be a multiple of 25 bits.</param>
        /// <param name="cryptoAlgorithmID">The cryptographic digest to use to compute
        /// the hash value.</param>
        /// <param name="key">Optional key used to create a keyed fingerprint.</param>
        /// <returns>The binary UDF fingerprint.</returns>

        public static byte[] BufferDigestToUDF(
                byte[] buffer,
            int bits = 0,
            CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.SHA_2_512,
            string key =null) {
            byte[] UDFData;

            int versionID;
            // process the data and set the first byte

            if (key == null) {
                UDFData = buffer.GetDigest(cryptoAlgorithmID);
                switch (cryptoAlgorithmID) {
                    case CryptoAlgorithmID.SHA_2_512: {
                        versionID = (byte)UDFPrefix.KeyIdentifierAlgSHA_2_512;
                        break;
                        }
                    case CryptoAlgorithmID.SHA_3_512: {
                        versionID = (byte)UDFPrefix.KeyIdentifierAlgSHA_3_512;
                        break;
                        }
                    default: {
                        throw new InvalidAlgorithm();
                        }
                    }
                }
            else {
                switch (cryptoAlgorithmID) {
                    case CryptoAlgorithmID.SHA_2_512: {
                        var macKey = ConvertKey(key, 512);
                        UDFData = buffer.GetMAC(macKey, CryptoAlgorithmID.HMAC_SHA_2_512);
                        versionID = (byte)UDFPrefix.KeyIdentifierAlgHMAC_SHA_2_512;
                        break;
                        }
                    default: {
                        throw new InvalidAlgorithm();
                        }
                    }

                
                }

            var compress = CountZeros(UDFData);

            // Create the empty output buffer
            var TotalBits = bits == 0 ? DefaultBits : bits;
            var FullBytes = (TotalBits+7) / 8;

            byte[] Output = new byte[FullBytes+1];
            Output[0] = (byte) ((compress > 0) ? versionID + compress - MinCompress : versionID);
            for (var j = 0; j < FullBytes; j++) {
                Output[j + 1] = UDFData[j+ compress];
                }


            return Output;
            }

        const int MinCompress = 2;
        const int MaxCompress = 7;
        static int CountZeros (byte[]data) {
            for (var i = 0; i < MaxCompress; i++) {
                if (data[i] != 0) {
                    return i> MinCompress ? i : 0;
                    }
                }
            return MaxCompress;
            }


        /// <summary>
        /// Convert a digest value and content type to a UDF buffer.
        /// </summary>
        /// <param name="digest">Digest value to be formatted</param>
        /// <param name="contentType">MIME media type. See 
        /// http://www.iana.org/assignments/media-types/media-types.xhtml for list.</param>
        /// <returns>SHA2-512 (UTF8(ContentType) + ":" + SHA2512(Data))</returns>
        public static byte[] UDFBuffer(byte[] digest, string contentType) {
            var contentTypeTag = contentType.ToUTF8();
            //var keyTag = key?.ToUTF8();

            //var length = digest.Length + contentTypeTag.Length + 1 +
            //    (key == null ? 0 : keyTag.Length + 1);


            var length = digest.Length + contentTypeTag.Length + 1;
            var Input = new byte[length];

            var index = Input.AppendChecked(0, contentTypeTag);
            Input[index] = (byte)':';
            index = Input.AppendChecked(index+1, digest);
            //if (key != null) {
            //    Input[index] = (byte)':';
            //    Input.AppendChecked(index+1, keyTag);
            //    }
            return Input;
            }


        static bool IsBase32(char c) {
            var x = (int)c;
            if (x > 127) {
                return false;
                }
            return BaseConvert.BASE32Value[x] < 255;
            }


        /// <summary>
        /// Determine if the string <paramref name="value"/> matches the 
        /// pattern <paramref name="test"/> with at least <paramref name="minBits"/>
        /// significant bits.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="test"></param>
        /// <param name="minBits">The minimum work factor for the comparison</param>
        /// <returns>true if the string <paramref name="value"/> matches the 
        /// pattern <paramref name="test"/> with at least <paramref name="minBits"/>
        /// significant bits. Otherwise false.</returns>
        public static bool Matches(string value, byte[] test, int minBits = 100) {
            var match = test.ToStringBase32();

            var j = 0;
            for (var i=0; i< value.Length; i++) {
                var v = (int)value[i];
                v = v > 96 ? v - 32 : v;

                if (v != 45){
                    var m = (int)match[j++];
                    if (v != m) {
                        return false;
                        }
                    }
                }
            return j*5 >= minBits;
            }


        /// <summary>
        /// Calculate a UDF fingerprint from an OpenPGP key with specified precision.
        /// </summary>
        /// <param name="buffer">Fingerprint to format.</param>
        /// <param name="bits">Precision, must be a multiple of 25 bits.</param>
        /// <returns>The binary UDF fingerprint.</returns>
        public static string Format(byte[] buffer, int bits = 0) {
            bits = bits == 0 ? DefaultBits : bits;
            var Length = 5 * (bits / 25);
            return buffer.ToStringBase32(Format: ConversionFormat.Dash5, OutputMax: Length);
            }

        /// <summary>
        /// Calculate a UDF fingerprint from an OpenPGP key with specified precision.
        /// </summary>
        /// <param name="contentType">MIME media type of data being fingerprinted.</param>
        /// <param name="data">Data to be fingerprinted.</param>
        /// <param name="bits">Precision, must be a multiple of 25 bits.</param>
        /// <param name="cryptoAlgorithmID">The cryptographic digest to use to compute
        /// the hash value.</param>
        /// <param name="key">Optional key used to create a keyed fingerprint.</param>
        /// <returns>The binary UDF fingerprint.</returns>
        public static string DataToFormat(
                byte[] data,
            string contentType,
            int bits = 0,
            CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.SHA_2_512,
            string key = null) {
            var buffer = DataToUDF(data, contentType, bits, cryptoAlgorithmID, key);
            return Format(buffer, bits);
            }

        /// <summary>
        /// Calculate a UDF fingerprint from an OpenPGP key with specified precision.
        /// </summary>
        /// <param name="contentType">MIME media type of data being fingerprinted.</param>
        /// <param name="data">Data to be fingerprinted.</param>
        /// <param name="bits">Precision, must be a multiple of 25 bits.</param>
        /// <param name="cryptoAlgorithmID">The cryptographic digest to use to compute
        /// the hash value.</param>
        /// <param name="key">Optional key used to create a keyed fingerprint.</param>
        /// <returns>The binary UDF fingerprint.</returns>
        public static string DigestToFormat(
                byte[] data,
            string contentType,
            int bits = 0,
            CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.SHA_2_512,
            string key = null) {
            var buffer = DigestToUDF(data, contentType, bits, cryptoAlgorithmID, key);
            return Format(buffer, bits);
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
        /// Calculate a UDF fingerprint from a secret key used to escrow a private
        /// key in the mesh.
        /// </summary>
        /// <param name="Data">Data to be fingerprinted.</param>
        /// <param name="Bits">Precision, must be a multiple of 25 bits.</param>
        /// <returns>The binary UDF fingerprint.</returns>
        public static byte[] FromEscrowed(byte[] Data, int Bits = 0) =>
            DataToUDF(Data, UDFConstants.EscrowedKey, Bits);


        /// <summary>
        /// Calculate a UDF fingerprint from a PKIX KeyInfo blob with specified precision.
        /// </summary>
        /// <param name="Data">Data to be fingerprinted.</param>
        /// <param name="Bits">Precision, must be a multiple of 25 bits.</param>
        /// <returns>The binary UDF fingerprint.</returns>
        public static byte[] FromKeyInfo(byte[] Data, int Bits = 0) => 
            DataToUDF(Data, UDFConstants.PKIXKey, Bits);

        /// <summary>
        /// Convert a binary UDF to a string.
        /// </summary>
        /// <param name="Data">Input data.</param>
        /// <returns>The UDF value as a string.</returns>
        public static string ToString(byte[] Data) => 
            Data.ToStringBase32(Format: ConversionFormat.Dash5);

        /// <summary>
        /// Return a random sequence as a UDF 
        /// </summary>
        /// <returns>A randomly generated UDF string.</returns>
        public static string Random() => Random(DefaultBits);

        /// <summary>
        /// Return a random sequence as a UDF 
        /// </summary>
        /// <param name="bits">Number of bits in the string</param>
        /// <returns>A randomly generated UDF string.</returns>
        public static string Random (int bits) {
            var Data = CryptoCatalog.GetBits(bits);
            Data[0] = (byte)UDFPrefix.KeyIdentifierAlgRandom;
            return Format(Data, bits);
            }

        #region // Convenience functions
        /// <summary>
        /// Check that a UDF fingerprint satisfies a test value. At present
        /// the test must be exact. It is possible that this can be relaxed
        /// so that a longer fingerprint will satisfy a shorter one.
        /// </summary>
        /// <param name="test">Expected value</param>
        /// <param name="value">Comparison value.</param>
        public static void Validate(string test, string value) => Assert.False(test != 
            value, FingerprintMatchFailed.Throw);

        /// <summary>Convert address and fingerprint value to Strong Internet Name.</summary>
        /// <param name="address">DNS address.</param>
        /// <param name="uDF">Fingerprint value.</param>
        /// <returns>The strong name.</returns>
        public static string MakeStrongName(string address, string uDF) => 
            address + ".mm--" + uDF.ToLower();

        /// <summary>Parse an RFC822 address to extract strong name component if present.</summary>
        /// <param name="address">The Internet address.</param>
        /// <param name="in">The address to parse.</param>
        /// <param name="uDF">The strong name fingerprint (if found).</param>
        public static void ParseStrongRFC822 (string @in, out string address, out string uDF) {
            var Split = @in.Split('@');
            uDF = null;

            if ((Split.Length <= 0) | (Split.Length > 2)) {
                address = @in;
                return;
                }

            if (Split.Length == 1) {
                address = Split[0];
                return;
                }

            var DNS = Split[1].ToLower().Split('.');

            var Builder = new StringBuilder(Split[0]);
            Builder.Append('@');

            var First = true;
            foreach (var Label in DNS) {
                if (Label.StartsWith("mm--")) {
                    uDF = Label.Substring(4);
                    }
                else {
                    if (!First) {
                        Builder.Append('.');
                        }
                    First = false;
                    Builder.Append(Label);
                    }
                }

            address = Builder.ToString();
            }

        public static byte[] MakeWitness(
            byte[] fingerprint1, byte[] nonce1,
            byte[] fingerprint2, byte[] nonce2) {

            var s1 = MakeWitness(fingerprint1, nonce1);
            var s2 = MakeWitness(fingerprint2, nonce2);

            return MakeWitness(s1, s2);
            }

        public static string MakeWitnessString(
            byte[] fingerprint1, byte[] nonce1,
            byte[] fingerprint2, byte[] nonce2,
            int bits= 125) =>
            Format (MakeWitness(fingerprint1, nonce1, fingerprint2, nonce2), bits);


        /// <summary>
        /// Calculate a binary witness value for the specified fingerprint
        /// and nonce value.
        /// </summary>
        /// <param name="fingerprint">The fingerprint value.</param>
        /// <param name="nonce">The nonce value</param>
        /// <returns>The corresponding witness value.</returns>
        public static byte[] MakeWitness(byte[] fingerprint, byte[] nonce) {
            var provider = Platform.SHA2_512.CryptoProviderDigest();

            var encoder = provider.MakeEncoder();

            encoder.InputStream.Write(fingerprint, 0, fingerprint.Length);
            encoder.InputStream.Write(nonce, 0, nonce.Length);
            encoder.Complete();

            return encoder.Integrity;
            }

        /// <summary>
        /// Calculate a witness fingerprint for the specified fingerprint
        /// and nonce value.
        /// </summary>
        /// <param name="fingerprint">The fingerprint value.</param>
        /// <param name="nonce">The nonce value</param>
        /// <returns>The corresponding witness value.</returns>
        public static string MakeWitnessString(byte[] fingerprint, byte[] nonce, int bits= 125) =>
            Format (MakeWitness(fingerprint, nonce), bits);
        #endregion
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
        public static string GetUDF(this byte[] Data, string ContentType, int Bits = 125) => 
            UDF.DataToFormat(Data, ContentType, Bits);

        }
    }
