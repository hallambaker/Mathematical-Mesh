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
using Goedel.Utilities;

using System;
using System.Text;

namespace Goedel.Cryptography {

    /// <summary>
    /// UDF type identifier codes
    /// </summary>
    public enum UDFTypeIdentifier {
        ///<summary>Authenticator using HMAC-SHA-2-512</summary>
        AuthenticatorHMAC_SHA_2_512 = 0,

        ///<summary>Authenticator using HMAC-SHA-3-512</summary>
        AuthenticatorHMAC_SHA_3_512 = 1,

        ///<summary>Encryption/Authentication key</summary>
        Encryption = 32,

        ///<summary>Content Digest using SHA-2-512</summary>
        DigestAlgSHA_2_512 = 96,

        ///<summary>Content Digest using SHA-3-512</summary>
        DigestSHA_3_512 = 80,

        ///<summary>Type code for random nonce</summary>
        Nonce = 104,

        ///<summary>Type code for OID Sequence</summary>
        OID = 112,

        ///<summary>Type code for Shamir secret</summary>
        ShamirSecret = 144,

        ///<summary>Type code for derived key</summary>
        DerivedKey = 200
        }

    ///<summary>Algorithm identifier codes for Derived keys</summary>
    public enum UDFAlgorithmIdentifier {

        ///<summary>Seed MAY be used to generate keypairs for any algorithm</summary>
        Any = 0,

        ///<summary>X25519 keypair as described in RFC7748</summary>
        X25519 = 1,
        ///<summary>X448 keypair as described in RFC7748</summary>
        X448 = 2,
        ///<summary>Ed25519 keypair as described in RFC8032</summary>
        Ed25519 = 3,
        ///<summary>Ed448 keypair as described in RFC8032</summary>
        Ed448 = 4,
        ///<summary>NIST curve P-256</summary>
        P256 = 5,
        ///<summary>NIST curve P-384</summary>
        P384 = 6,
        ///<summary>NIST curve P-521</summary>
        P521 = 7,
        ///<summary>2048 bit RSA keypair</summary>
        RSA2048 = 8,
        ///<summary>3072 bit RSA keypair</summary>
        RSA3072 = 9,
        ///<summary>4096 bit RSA keypair</summary>
        RSA4096 = 10
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
        public const string OpenPGPKey = "application/openpgp-keys";

        /// <summary>
        /// Content type for mesh escrowed key
        /// </summary>
        public const string EscrowedKey = "application/mmm-escrowed";

        /// <summary>
        /// UDF Fingerprint list
        /// </summary>
        public const string UDFEncryption = "application/udf-encryption";

        /// <summary>
        /// UDF Fingerprint list
        /// </summary>
        public const string UDFSecret = "application/udf-secret";

        /// <summary>
        /// UDF Fingerprint list
        /// </summary>
        public const string UDFLock = "application/udf-lock";

        }

    /// <summary>
    /// Class implementing the Uniform Data Fingerprint spec.
    /// </summary>
    public static class UDF {

        // Test: Matching UDF values against strings.
        // Goal: Eliminate all UDF string values in profiles and use binary blobs for comparison

        /// <summary>
        /// Default number of UDF bits (usually 140).
        /// </summary>
        public static int DefaultBits { get; set; } = 140;

        /// <summary>
        /// Maximum precision (usually 440);
        /// </summary>
        public static int MaximumBits { get; set; } = 440;

        #region // Conversions to binary UDF value
        /// <summary>
        /// Calculate a UDF fingerprint from the content data with specified precision.
        /// </summary>
        /// <param name="contentType">MIME media type of data being fingerprinted.</param>
        /// <param name="data">Data to be fingerprinted.</param>
        /// <param name="bits">Precision, must be a multiple of 25 bits.</param>
        /// <param name="cryptoAlgorithmID">The cryptographic digest to use to compute
        /// the hash value.</param>
        /// <param name="key">Optional key used to create a keyed fingerprint.</param>
        /// <returns>The binary UDF fingerprint.</returns>
        public static byte[] DataToUDFBinary(
                byte[] data,
                string contentType,
                int bits = 0,
                CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.SHA_2_512,
                string key = null) {
            switch (cryptoAlgorithmID) {
                case CryptoAlgorithmID.SHA_2_512: {
                    return DigestToUDFBinary(Platform.SHA2_512.Process(data),
                        contentType, bits, cryptoAlgorithmID, key);
                    }
                case CryptoAlgorithmID.SHA_3_512: {
                    return DigestToUDFBinary(Platform.SHA3_512.Process(data),
                        contentType, bits, cryptoAlgorithmID, key);
                    }
                }
            throw new InvalidAlgorithm();
            }

        /// <summary>
        /// Calculate a UDF fingerprint from the content digest with specified precision.
        /// </summary>
        /// <param name="contentType">MIME media type of data being fingerprinted.</param>
        /// <param name="digest">Digest of the data to be fingerprinted.</param>
        /// <param name="bits">Precision, must be a multiple of 25 bits.</param>
        /// <param name="cryptoAlgorithmID">The cryptographic digest to use to compute
        /// the hash value.</param>
        /// <param name="key">Optional key used to create a keyed fingerprint.</param>
        /// <returns>The binary UDF fingerprint.</returns>
        public static byte[] DigestToUDFBinary(
                byte[] digest,
                string contentType,
                int bits = 0,
                CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.SHA_2_512,
                string key = null) {
            var buffer = UDFBuffer(digest, contentType);
            return key == null ? BufferDigestToUDF(buffer, bits, cryptoAlgorithmID) :
                BufferDigestToUDF(buffer, key, bits, cryptoAlgorithmID);
            }


        /// <summary>
        /// Calculate a UDF fingerprint with specified precision.
        /// </summary>
        /// <param name="buffer">The prepared data buffer.</param>
        /// <param name="bits">Precision, must be a multiple of 25 bits.</param>
        /// <param name="cryptoAlgorithmID">The cryptographic digest to use to compute
        /// the hash value.</param>
        /// <returns>The binary UDF fingerprint.</returns>
        public static byte[] BufferDigestToUDF(
                    byte[] buffer,
                    int bits = 0,
                    CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.SHA_2_512) {

            var UDFData = buffer.GetDigest(cryptoAlgorithmID);

            UDFTypeIdentifier versionID;
            switch (cryptoAlgorithmID) {
                case CryptoAlgorithmID.SHA_2_512: {
                    versionID = UDFTypeIdentifier.DigestAlgSHA_2_512;
                    break;
                    }
                case CryptoAlgorithmID.SHA_3_512: {
                    versionID = UDFTypeIdentifier.DigestSHA_3_512;
                    break;
                    }
                default: {
                    throw new InvalidAlgorithm();
                    }
                }

            var compress = GetCompression(UDFData);
            return TypeBDSToBinary(versionID + compress, UDFData, bits); ;
            }

        /// <summary>
        /// Returns the compression level as determined by the number of trailing zero
        /// bits of <paramref name="buffer"/>
        /// </summary>
        /// <param name="buffer">The buffer to compress (MUST have at least 7 bytes)</param>
        /// <returns>The compression level, 3 if there are 50 leading zeros, 2 if there
        /// are 40 leading zeros, 1 if there are 20 and 0 otherwise.</returns>
        public static int GetCompression(byte[] buffer) {
            Assert.True(buffer.Length == 64);

            // Check for less than 20 trailing zeros
            if (buffer[63] != 0 | buffer[62] != 0 | ((buffer[61] & 0b0000_1111) != 0)) {
                return 0;
                }

            // Check for less than 30 trailing zeros
            if (buffer[61] != 0 | ((buffer[60] & 0b0011_1111) != 0)) {
                return 1;
                }

            // Check for less than 40 trailing zeros
            if (buffer[60] != 0 | buffer[59] != 0 | buffer[58] != 0) {
                return 2;
                }

            // Check for less than 50 trailing zeros
            if (buffer[57] != 0 | ((buffer[56] & 0b0000_0011) == 0)) {
                return 3;
                }
            return 4;
            }

        /// <summary>
        /// Calculate a UDF fingerprint with specified precision.
        /// </summary>
        /// <param name="buffer">The prepared data buffer.</param>
        /// <param name="bits">Precision, must be a multiple of 25 bits.</param>
        /// <param name="cryptoAlgorithmID">The cryptographic digest to use to compute
        /// the hash value.</param>
        /// <param name="key">Key used to create a keyed fingerprint.</param>
        /// <returns>The binary UDF fingerprint.</returns>
        public static byte[] BufferDigestToUDF(
                    byte[] buffer,
                    string key,
                    int bits = 0,
                    CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.SHA_2_512
                    ) {
            byte[] UDFData;

            UDFTypeIdentifier versionID;

            switch (cryptoAlgorithmID) {
                case CryptoAlgorithmID.SHA_2_512: {
                    var macKey = KeyStringToKey(key, 512);
                    UDFData = buffer.GetMAC(macKey, CryptoAlgorithmID.HMAC_SHA_2_512);
                    versionID = UDFTypeIdentifier.AuthenticatorHMAC_SHA_2_512;
                    return TypeBDSToBinary(versionID, UDFData, bits);
                    }
                default: {
                    throw new InvalidAlgorithm();
                    }
                }

            }


        /// <summary>
        /// Convert a Type Identifier and binary data sequence to a UDF binary buffer 
        /// ready for presentation.
        /// </summary>
        /// <param name="typeID">The type identifier.</param>
        /// <param name="source">The input buffer.</param>
        /// <param name="bits">The number of bits precision of the final output. If 0, the value
        /// of the property DefaultBits is used.</param>
        /// <param name="offset">Offset in <paramref name="source"/>.</param>
        /// <returns>The resulting binary buffer.</returns>
        public static byte[] TypeBDSToBinary(
                UDFTypeIdentifier typeID,
                byte[] source,
                int bits = 0,
                int offset = 0) {
            // Constrain the number of bits to an integer multiple of 20 bits between DefaultBits
            // and MaximumBits.
            bits = bits <= 0 ? DefaultBits : bits;

            // Calculate the number of bytes
            var bytes = (bits + 7) / 8;

            var result = new byte[bytes];
            result[0] = (byte)typeID;

            Buffer.BlockCopy(source, offset, result, 1, bytes - 1);

            return result;
            }

        /// <summary>
        /// Convert a Type Identifier and binary data sequence to a UDF binary buffer 
        /// ready for presentation.
        /// </summary>
        /// <param name="typeID">The type identifier.</param>
        /// <param name="source">The input buffer.</param>
        /// <param name="bits">The number of bits precision of the final output. If 0, the value
        /// of the property DefaultBits is used.</param>
        /// <param name="offset">Offset in <paramref name="source"/>.</param>
        /// <returns>The resulting binary buffer.</returns>
        public static string TypeBDSToString(
                UDFTypeIdentifier typeID,
                byte[] source,
                int bits = 0,
                int offset = 0) {
            var buffer = TypeBDSToBinary(typeID, source, bits, offset);
            return PresentationBase32(buffer, bits);

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

            var length = digest.Length + contentTypeTag.Length + 1;
            var Input = new byte[length];

            var index = Input.AppendChecked(0, contentTypeTag);
            Input[index] = (byte)':';
            index = Input.AppendChecked(index + 1, digest);

            return Input;
            }

        /// <summary>
        /// Convert TextKey to the MAC key.
        /// </summary>
        /// <param name="textKey">The key.</param>
        /// <param name="length">The number of bits to return (defaults to the MAC output)</param>
        /// <param name="algorithm">The MAC algorithm to use.</param>
        /// <returns>The corresponding MAC key.</returns>
        public static byte[] KeyStringToKey(
                    string textKey,
                    int length = 0,
                    CryptoAlgorithmID algorithm = CryptoAlgorithmID.HMAC_SHA_2_512) {
            var keyDerive = new KeyDeriveHKDF(textKey.ToUTF8(), KeyDerive.KeyedUDFMaster, algorithm);
            return keyDerive.Derive(KeyDerive.KeyedUDFExpand, length);
            }





        #endregion



        #region // Comparison functions
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
            for (var i = 0; i < value.Length; i++) {
                var v = (int)value[i];
                v = v > 96 ? v - 32 : v;

                if (v != 45) {
                    var m = (int)match[j++];
                    if (v != m) {
                        return false;
                        }
                    }
                }
            return j * 5 >= minBits;
            }
        #endregion



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
        public static string ContentDigestOfDataString(
                    byte[] data,
                    string contentType,
                    int bits = 0,
                    CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.SHA_2_512,
                    string key = null) {
            var buffer = DataToUDFBinary(data, contentType, bits, cryptoAlgorithmID, key);
            return PresentationBase32(buffer, bits);
            }

        /// <summary>
        /// Calculate a UDF fingerprint from an OpenPGP key with specified precision.
        /// </summary>
        /// <param name="contentType">MIME media type of data being fingerprinted.</param>
        /// <param name="data">Data to be fingerprinted.</param>
        /// <param name="bits">Precision, must be a multiple of 20 bits.</param>
        /// <param name="cryptoAlgorithmID">The cryptographic digest to use to compute
        /// the hash value.</param>
        /// <param name="key">Optional key used to create a keyed fingerprint.</param>
        /// <returns>The binary UDF fingerprint.</returns>
        public static string ContentDigestOfDigestString(
                    byte[] data,
                    string contentType,
                    int bits = 0,
                    CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.SHA_2_512,
                    string key = null) {
            var buffer = DigestToUDFBinary(data, contentType, bits, cryptoAlgorithmID, key);
            return PresentationBase32(buffer, bits);
            }


        /// <summary>
        /// Calculate the UDF fingerprint identifier of a fingerprint identifier.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="cryptoAlgorithmID"></param>
        /// <param name="bits">Precision, must be a multiple of 20 bits.</param>
        /// <returns>The Base32 presentation of the UDF value truncated to 
        /// <paramref name="bits"/> precision.</returns>
        public static string ContentDigestOfUDF(
                    string data,
                    int bits = 0,
                    CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.SHA_2_512) {
            bits = bits == 0 ? DefaultBits * 2 : bits;

            //// Calculate the output precision, this is twice the input precision to a
            //// maximum od MaximumBits.
            //var bits = 10 * ((data.Length + 1) / 4);
            //bits = bits > MaximumBits ? MaximumBits : bits;

            var buffer = DigestToUDFBinary(data.ToUTF8(), UDFConstants.UDFEncryption, bits, cryptoAlgorithmID, null);
            return PresentationBase32(buffer, bits);
            }



        /// <summary>
        /// Calculate the UDF lock identifier for a local file.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="cryptoAlgorithmID"></param>
        /// <param name="bits">Precision, must be a multiple of 20 bits.</param>
        /// <returns>The Base32 presentation of the UDF value truncated to 
        /// <paramref name="bits"/> precision.</returns>
        public static string LockName(
                    string data,
                    int bits = 0,
                    CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.SHA_2_512) {
            bits = bits == 0 ? DefaultBits * 2 : bits;
            var buffer = DigestToUDFBinary(data.ToUTF8(), UDFConstants.UDFLock, bits, cryptoAlgorithmID, null);
            return PresentationBase32(buffer, bits);
            }
        /// <summary>
        /// Calculate a UDF fingerprint from an OpenPGP key with specified precision.
        /// </summary>
        /// <param name="buffer">Fingerprint to format.</param>
        /// <param name="bits">Precision.</param>
        /// <returns>The binary UDF fingerprint.</returns>
        public static string PresentationBase32(
                    byte[] buffer,
                    int bits = 0) {
            bits = bits == 0 ? DefaultBits : bits;
            var Length = (bits + 4) / 5;
            return buffer.ToStringBase32(format: ConversionFormat.Dash4, outputMax: Length);
            }


        /// <summary>
        /// Return a random sequence as a UDF 
        /// </summary>
        /// <param name="bits">Number of random bits in the string</param>
        /// <returns>A randomly generated UDF string.</returns>
        public static string Nonce(int bits = 0) {
            bits = bits <= 0 ? DefaultBits - 8 : bits;

            var Data = CryptoCatalog.GetBits(bits);
            return TypeBDSToString(UDFTypeIdentifier.Nonce, Data, bits + 8);
            }

        /// <summary>
        /// Return the OID Sequence describing the public key <paramref name="keyPair"/>.
        /// </summary>
        /// <param name="keyPair">Number of random bits in the string</param>
        /// <returns>A randomly generated UDF string.</returns>
        public static string OID(KeyPair keyPair) {
            var Data = keyPair.KeyInfoData.DER();
            var bits = Data.Length * 8;
            return TypeBDSToString(UDFTypeIdentifier.OID, Data, bits + 8);
            }



        /// <summary>
        /// Return a random sequence as a UDF 
        /// </summary>
        /// <param name="bits">Number of random bits in the string</param>
        /// <returns>A randomly generated UDF string.</returns>
        public static string SymmetricKey(int bits = 0) {
            bits = bits <= 0 ? DefaultBits - 8 : bits;

            var Data = CryptoCatalog.GetBits(bits);
            return TypeBDSToString(UDFTypeIdentifier.Encryption, Data, bits + 8);
            }

        /// <summary>
        /// Return the key value <paramref name="Data"/> in UDF form.
        /// </summary>
        /// <param name="Data">The data to convert to key form</param>
        /// <returns>A randomly generated UDF string.</returns>
        public static string SymmetricKey(byte[] Data) {
            var bits = Data.Length * 8;
            return TypeBDSToString(UDFTypeIdentifier.Encryption, Data, bits + 8);
            }

        /// <summary>
        /// Return the key value <paramref name="Data"/> in UDF form.
        /// </summary>
        /// <param name="Data">The data to convert to key form</param>
        /// <returns>A randomly generated UDF string.</returns>
        public static string KeyShare(byte[] Data) {
            var bits = Data.Length * 8;
            return TypeBDSToString(UDFTypeIdentifier.ShamirSecret, Data, bits + 8);
            }


        /// <summary>
        /// Return the key value <paramref name="Data"/> in UDF form.
        /// </summary>
        /// <param name="Data">The data to convert to key form</param>
        /// <returns>A randomly generated UDF string.</returns>
        public static string SymmetricKeyUDF(byte[] Data) => ContentDigestOfUDF(SymmetricKey(Data));




        /// <summary>
        /// Calculate a UDF fingerprint from a PKIX KeyInfo blob with specified precision.
        /// </summary>
        /// <param name="Data">Data to be fingerprinted.</param>
        /// <param name="Bits">Precision, must be a multiple of 25 bits.</param>
        /// <returns>The binary UDF fingerprint.</returns>
        public static byte[] FromKeyInfo(
                    byte[] Data,
                    int Bits = 0) =>
            DataToUDFBinary(Data, UDFConstants.PKIXKey, Bits);



        /// <summary>
        /// Parse a UDF to obtain the type identifier and Binary Data Sequence.
        /// </summary>
        /// <param name="udf">UDF to parse.</param>
        /// <param name="code">The type identifier code.</param>
        /// <returns>The Binary Data Sequence.</returns>
        public static byte[] Parse(string udf, out byte code) {
            var buffer = BaseConvert.FromBase32(udf);
            code = buffer[0];
            var result = new byte[buffer.Length - 1];
            Buffer.BlockCopy(buffer, 1, result, 0, buffer.Length - 1);
            return result;
            }

        /// <summary>
        /// Parse a UDF and return the encryption key value if and only if it
        /// is of the correct type code, otherwise null.
        /// </summary>
        /// <param name="udf">The string tro parse.</param>
        /// <returns>The key value.</returns>
        public static byte[] Nonce(string udf) {
            var result = Parse(udf, out var code);
            return code == (byte)UDFTypeIdentifier.Nonce ? result : null;
            }

        /// <summary>
        /// Parse a UDF and return the encryption key value if and only if it
        /// is of the correct type code, otherwise null.
        /// </summary>
        /// <param name="udf">The string tro parse.</param>
        /// <returns>The key value.</returns>
        public static byte[] SymmetricKey(string udf) {
            var result = Parse(udf, out var code);
            return code == (byte)UDFTypeIdentifier.Encryption ? result : null;
            }

        /// <summary>
        /// Parse a UDF and return the encryption key value if and only if it
        /// is of the correct type code, otherwise null.
        /// </summary>
        /// <param name="udf">The string tro parse.</param>
        /// <returns>The key value.</returns>
        public static byte[] ShamirSecret(string udf) {
            var result = Parse(udf, out var code);
            return code == (byte)UDFTypeIdentifier.ShamirSecret ? result : null;
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
        public static void ParseStrongRFC822(string @in, out string address, out string uDF) {
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
        #endregion

        #region // Witness values
        /// <summary>
        /// Make a witness value from two input fingerprints and nonces.
        /// </summary>
        /// <param name="fingerprint1">The first fingerprint value</param>
        /// <param name="nonce1">The first nonce value</param>
        /// <param name="fingerprint2">The second fingerprint value</param>
        /// <param name="nonce2">The second nonce value</param>
        /// <returns>The fingerprint value</returns>
        public static byte[] MakeWitness(
                    byte[] fingerprint1, byte[] nonce1,
                    byte[] fingerprint2, byte[] nonce2) {

            var s1 = MakeWitness(fingerprint1, nonce1);
            var s2 = MakeWitness(fingerprint2, nonce2);

            return MakeWitness(s1, s2);
            }

        /// <summary>
        /// Make a witness value from two input fingerprints and nonces.
        /// </summary>
        /// <param name="fingerprint1">The first fingerprint value</param>
        /// <param name="nonce1">The first nonce value</param>
        /// <param name="fingerprint2">The second fingerprint value</param>
        /// <param name="nonce2">The second nonce value</param>
        /// <param name="bits">The output precision in bits.</param>
        /// <returns>The fingerprint value</returns>
        public static string MakeWitnessString(
                    byte[] fingerprint1, byte[] nonce1,
                    byte[] fingerprint2, byte[] nonce2,
                    int bits = 0) =>
            PresentationBase32(MakeWitness(fingerprint1, nonce1, fingerprint2, nonce2), bits);


        /// <summary>
        /// Calculate a binary witness value for the specified fingerprint
        /// and nonce value.
        /// </summary>
        /// <param name="fingerprint">The fingerprint value.</param>
        /// <param name="nonce">The nonce value</param>
        /// <returns>The corresponding witness value.</returns>
        public static byte[] MakeWitness(
                    byte[] fingerprint,
                    byte[] nonce) {
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
        /// <param name="bits">The number of bits precision to provide in the output.</param>
        /// <returns>The corresponding witness value.</returns>
        public static string MakeWitnessString(byte[] fingerprint, byte[] nonce, int bits = 0) =>
            PresentationBase32(MakeWitness(fingerprint, nonce), bits);


        /// <summary>
        /// Convert a PIN to a Pin Identifier
        /// </summary>
        /// <param name="PIN">The PIN value</param>
        /// <returns>The corresponding PIN identifier</returns>
        public static string PIN2PinID(string PIN) => PIN;
        #endregion


        /// <summary>
        /// Construct a key specifier for the specified algorithm.
        /// </summary>
        /// <param name="algorithmIdentifier">The algorithm to generate the key specifier for.</param>
        /// <returns>Two byte key specifier.</returns>
        public static byte[] KeySpecifier(UDFAlgorithmIdentifier algorithmIdentifier) {

            var result = new byte[2];

            result[1] = (byte)((int)algorithmIdentifier & 0xff);
            result[0] = (byte)((int)algorithmIdentifier >> 8 & 0xff);
            return result;


            }


        /// <summary>
        /// Create a derived key UDF for algorithm <paramref name="algorithmIdentifier"/> with
        /// key data <paramref name="data"/> if specified. Otherwise generate a new random key 
        /// of <paramref name="length"/> bits, 
        /// </summary>
        /// <param name="algorithmIdentifier">The algorithm identifier.</param>
        /// <param name="length">The key size in bits. This is ignored if <paramref name="data"/> is
        /// not null.</param>
        /// <param name="data">The master key data.</param>
        /// <returns>The generated UDF</returns>
        public static string DerivedKey(UDFAlgorithmIdentifier algorithmIdentifier,
                    int length = 128, byte[] data = null) {

            var keySpecifier = KeySpecifier(algorithmIdentifier);
            data = data ?? CryptoCatalog.GetBits(length);

            var result = new byte[keySpecifier.Length + data.Length];

            result[0] = keySpecifier[0];
            result[1] = keySpecifier[1];
            Buffer.BlockCopy(data, 0, result, 2, data.Length);

            var bits = result.Length * 8;
            return TypeBDSToString(UDFTypeIdentifier.DerivedKey, result, bits + 8);
            }

        /// <summary>
        /// Extract the binary data sequence from the string <paramref name="udf"/>.
        /// </summary>
        /// <param name="udf">The UDF to parse.</param>
        /// <returns>The corresponding binary data sequence.</returns>
        public static byte[] DerivedKey(string udf) {
            var result = Parse(udf, out var code);
            return code == (byte)UDFTypeIdentifier.DerivedKey ? result : null;
            }

        /// <summary>
        /// Derive a key pair from the UDF key <paramref name="udf"/> with Key security model
        /// <paramref name="keyType"/> and Key uses <paramref name="keyUses"/>.
        /// </summary>
        /// <param name="udf"></param>
        /// <param name="keyType"></param>
        /// <param name="keyUses"></param>
        /// <returns></returns>
        public static KeyPair DeriveKey(string udf,
                    KeySecurity keyType = KeySecurity.Public,
                    KeyUses keyUses = KeyUses.Any) {

            var binaryData = Parse(udf, out var code);
            (code == (byte)UDFTypeIdentifier.DerivedKey).AssertTrue();

            var algorithm = (UDFAlgorithmIdentifier)(256 * binaryData[0] + binaryData[1]);
            var salt = KeySpecifier(algorithm);


            switch (algorithm) {
                case UDFAlgorithmIdentifier.Ed25519: {
                    return new KeyPairEd25519(binaryData, salt, keyType, keyUses);
                    }

                }
            throw new NYI();
            }

        }

    /// <summary>Static class containing static extension methods providing convenience functions.</summary>
    public static partial class Extension {
        /// <summary>
        /// Compare the fingerprint <paramref name="UDF"/> to see that it matches the 
        /// pattern <paramref name="pattern"/> according
        /// to UDF matching rules. Currently, the method only converts strings to lower 
        /// case, it does not canonicalize.
        /// </summary>
        /// <param name="pattern">The pattern the candidate is being tested for a match against.</param>
        /// <param name="UDF">The candidate being tested</param>
        /// <returns>True if the patterns match, otherwise false.</returns>
        public static bool CompareUDF(this string pattern, string UDF) {
            if (UDF.Length < pattern.Length) {
                return false;
                }
            if (UDF.Length == pattern.Length) {
                return pattern.ToLower() == UDF.ToLower();
                }
            return pattern.ToLower().StartsWith(UDF.ToLower());
            }

        /// <summary>
        /// Calculate a UDF fingerprint from specified ContentType with specified precision.
        /// </summary>
        /// <param name="ContentType">MIME media type of data being fingerprinted.</param>
        /// <param name="Data">Data to be fingerprinted.</param>
        /// <param name="Bits">Precision, must be a multiple of 25 bits.</param>
        /// <returns>The UDF fingerprint.</returns>
        public static string GetUDFContentDigest(this byte[] Data, string ContentType, int Bits = 0) =>
            UDF.ContentDigestOfDataString(Data, ContentType, Bits);

        }
    }
