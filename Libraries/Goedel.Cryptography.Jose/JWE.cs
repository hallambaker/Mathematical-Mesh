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

using Goedel.Protocol;
using Goedel.Utilities;

using System.Collections.Generic;


namespace Goedel.Cryptography.Jose {

    /// <summary>
    /// Represents a JWE data structure.
    /// </summary>
    public partial class JoseWebEncryption {

        /// <summary>The signed data.</summary>
        public override byte[] Data {
            get => CipherText;
            set => CipherText = value;
            }


        /// <summary>
        /// The decrypted plaintext value
        /// </summary>
        public byte[] Plaintext {
            get {
                _Plaintext = _Plaintext ?? Decrypt();
                return _Plaintext;
                }
            }
        byte[] _Plaintext = null;

        /// <summary>
        /// The decrypted plaintext as a string.
        /// </summary>
        public string UTF8 => Plaintext.ToString();


        /// <summary>Caches the CryptoData instance</summary>
        protected CryptoData _CryptoDataEncrypt = null;

        /// <summary>
        /// Call GetCryptoData and return the result, unless GetCryptoData has been
        /// called previously on this instance in which case return the last result. 
        /// </summary>
        public CryptoData CryptoDataEncrypt {
            get {
                _CryptoDataEncrypt = _CryptoDataEncrypt ?? GetCryptoData();
                return _CryptoDataEncrypt;
                }
            }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public JoseWebEncryption() { }

        /// <summary>
        /// Construct a JWE instance from JSON Object
        /// </summary>
        /// <param name="JSONObject">The object to sign</param>
        /// <param name="Encoding">The data encoding to use</param>
        /// <param name="ContentType">The type of content being encrypted.</param>
        /// <param name="EncryptionKey">Optional Encryption key.</param>
        /// <param name="SigningKey">Optional signing key.</param>
        /// <param name="EncryptID">Composite ID for encryption and key exchange</param>
        /// <param name="SignID">Composite ID for signature and digest</param>
        public JoseWebEncryption(JSONObject JSONObject,
                    DataEncoding Encoding = DataEncoding.JSON,
                    KeyPair EncryptionKey = null,
                    KeyPair SigningKey = null,
                    string ContentType = null,
                    CryptoAlgorithmID EncryptID = CryptoAlgorithmID.Default,
                    CryptoAlgorithmID SignID = CryptoAlgorithmID.Default
                    ) :
                this(JSONObject.GetBytes(Encoding),
                    EncryptionKey, SigningKey, ContentType, EncryptID, SignID) {
            }

        /// <summary>
        /// Construct a JWE instance from binary data. 
        /// </summary>
        /// <param name="Data">Key information to construct the bulk and optionally
        /// key exchange headers</param>
        /// <param name="ContentType">The type of content being encrypted.</param>
        /// <param name="EncryptionKey">Optional Encryption key.</param>
        /// <param name="SigningKey">Optional signing key.</param>
        /// <param name="EncryptID">Composite ID for encryption and key exchange</param>
        /// <param name="SignID">Composite ID for signature and digest</param>
        /// <param name="KID">Key ID</param>
        public JoseWebEncryption(byte[] Data,
                    KeyPair EncryptionKey = null,
                    KeyPair SigningKey = null,
                    string ContentType = null,
                    CryptoAlgorithmID EncryptID = CryptoAlgorithmID.Default,
                    CryptoAlgorithmID SignID = CryptoAlgorithmID.Default,
                    string KID = null
                    ) {

            var Provider = CryptoCatalog.Default.GetEncryption(EncryptID);
            var EncryptEncoder = Provider.MakeEncoder(Algorithm: EncryptID);
            _CryptoDataEncrypt = EncryptEncoder;

            if (EncryptionKey != null) {
                AddRecipient(EncryptionKey, KID: KID, ProviderAlgorithm: EncryptID);
                }

            var DigestProvider = SigningKey != null ? CryptoCatalog.Default.GetDigest(SignID) : null;


            BindCryptoData(EncryptEncoder, ContentType, DigestProvider);

            EncryptEncoder.Write(Data);
            EncryptEncoder.Complete();

            CipherText = EncryptEncoder.OutputData;

            if (SigningKey != null) {
                _CryptoDataDigest = DigestProvider.Process(CipherText);
                AddSignature(SigningKey, DigestProvider.CryptoAlgorithmID);
                }

            }




        /// <summary>
        /// Construct a JWE instance from binary data. 
        /// </summary>
        /// <param name="Data">Key information to construct the bulk and optionally
        /// key exchange headers</param>
        /// <param name="ContentType">The type of content being encrypted.</param>
        /// <param name="Secret">The symmetric master key</param>
        /// <param name="Prefix">Key derivation prefix</param>
        /// <param name="EncryptID">Bulk ID for encryption</param>
        /// <param name="AuthenticateID">Bulk ID for authentication</param>
        public JoseWebEncryption(byte[] Data,
                    byte[] Secret, string Prefix = null,
                    string ContentType = null,
                    CryptoAlgorithmID EncryptID = CryptoAlgorithmID.Default,
                    CryptoAlgorithmID AuthenticateID = CryptoAlgorithmID.Default
                    ) {

            var Provider = CryptoCatalog.Default.GetEncryption(EncryptID);
            var EncryptEncoder = Provider.MakeEncoder(Algorithm: EncryptID);
            _CryptoDataEncrypt = EncryptEncoder;

            BindCryptoData(EncryptEncoder, ContentType, null);

            //var DigestProvider = SigningKey != null ? CryptoCatalog.Default.GetDigest(SignID) : null;

            EncryptEncoder.Write(Data);
            EncryptEncoder.Complete();

            CipherText = EncryptEncoder.OutputData;

            AddRecipient(Secret, Prefix, EncryptID.Meta());



            //    _CryptoDataDigest = DigestProvider.Process(CipherText);
            //    AddSignature(SigningKey, DigestProvider.CryptoAlgorithmID);
            //    }

            }



        /// <summary>
        /// Construct a JWE instance from text data. 
        /// </summary>
        /// <param name="Text">Key information to construct the bulk and optionally
        /// key exchange headers</param>
        /// <param name="ContentType">The type of content being encrypted.</param>
        /// <param name="Secret">The symmetric master key</param>
        /// <param name="Prefix">Key derivation prefix</param>
        /// <param name="Algorithm">Specify the Meta and Bulk algorithms</param>
        public JoseWebEncryption(string Text,
                    byte[] Secret, string Prefix = null,
                    string ContentType = null,
                    CryptoAlgorithmID Algorithm = CryptoAlgorithmID.Default) :
                this(System.Text.Encoding.UTF8.GetBytes(Text),
                        Secret, Prefix, ContentType, Algorithm) { }


        /// <summary>
        /// Construct a JWE instance from text data. 
        /// </summary>
        /// <param name="Text">Key information to construct the bulk and optionally
        /// key exchange headers</param>
        /// <param name="ContentType">The type of content being encrypted.</param>
        /// <param name="EncryptionKey">Optional Encryption key.</param>
        /// <param name="SigningKey">Optional signing key.</param>
        /// <param name="Algorithm">Specify the Meta and Bulk algorithms</param>
        public JoseWebEncryption(string Text,
                    KeyPair EncryptionKey = null,
                    KeyPair SigningKey = null,
                    string ContentType = null,
                    CryptoAlgorithmID Algorithm = CryptoAlgorithmID.Default) :
                this(System.Text.Encoding.UTF8.GetBytes(Text),
                        EncryptionKey, SigningKey, ContentType, Algorithm) { }


        ///// <summary>
        ///// Create encryption info
        ///// </summary>
        ///// <param name="Data">Data to be encrypted.</param>
        ///// <param name="Recipients">The recipient information entries.</param>
        ///// <param name="Protected">The protected encryption header</param>
        ///// <param name="EncryptionKeys">The encryption key.</param>
        ///// <param name="ContentType">Content type identifier.</param>
        ///// <param name="EncryptID">Encryption algorithm to use.</param>
        ///// <returns>The encrypted data info block.</returns>
        //public static CryptoData Encrypt (byte[] Data,
        //            out List<Recipient> Recipients,
        //            out Header Protected,
        //            List<KeyPair> EncryptionKeys = null,
        //            string ContentType = null,
        //            CryptoAlgorithmID EncryptID = CryptoAlgorithmID.Default
        //            ) {


        //    var Provider = CryptoCatalog.Default.GetEncryption(EncryptID);
        //    var EncryptEncoder = Provider.MakeEncoder(Algorithm: EncryptID);
        //    Protected = JoseWebEncryption.ProtectedHeader(EncryptEncoder, ContentType, null);

        //    Recipients = new List<Cryptography.Jose.Recipient>();

        //    foreach (var EncryptionKey in EncryptionKeys) {
        //        var KID = EncryptionKey.Name ?? EncryptionKey.UDF;
        //        var Recipient = JoseWebEncryption.Recipient(
        //                EncryptEncoder, EncryptionKey, KID: KID, ProviderAlgorithm: EncryptID);
        //        Recipients.Add(Recipient);
        //        }

        //    EncryptEncoder.Write(Data);
        //    EncryptEncoder.Complete();

        //    return EncryptEncoder;
        //    }

        ///// <summary>
        ///// Add a recipient to an existing JWE header.
        ///// </summary>
        ///// <remarks>If custom crypto suites are used, the caller is responsible for 
        ///// ensuring that the exchange algorithm is compatible with the bulk algorithm 
        ///// already selected. </remarks>
        ///// <param name="CryptoData">The encryption data.</param>
        ///// <param name="EncryptionKey">The recipient key to add.</param>
        ///// <param name="ProviderAlgorithm">Algorithm parameters (if supported)</param>
        ///// <param name="KID">Key ID</param>
        ///// <returns>The recipient instance</returns>
        //static Recipient Recipient (CryptoData CryptoData, KeyPair EncryptionKey, string KID = null,
        //        CryptoAlgorithmID ProviderAlgorithm = CryptoAlgorithmID.Default) {
        //    throw new NYI();

        //    //var ExchangeData = EncryptionKey.EncryptKey(CryptoData, ProviderAlgorithm);
        //    //var Recipient = new Recipient(ExchangeData, KID);

        //    //return Recipient;
        //    }

        /// <summary>
        /// Add a recipient to an existing JWE header.
        /// </summary>
        /// <remarks>If custom crypto suites are used, the caller is responsible for 
        /// ensuring that the exchange algorithm is compatible with the bulk algorithm 
        /// already selected. </remarks>
        /// <param name="EncryptionKey">The recipient key to add.</param>
        /// <param name="ProviderAlgorithm">Algorithm parameters (if supported)</param>
        /// <param name="KID">Key ID</param>
        /// <returns>The recipient instance</returns>
        public Recipient AddRecipient(KeyPair EncryptionKey, string KID = null,
                CryptoAlgorithmID ProviderAlgorithm = CryptoAlgorithmID.Default) {

            EncryptionKey.Encrypt(CryptoDataEncrypt.Key, out var Exchange, out var Ephemeral);
            var Recipient = new Recipient(Exchange, EncryptionKey, Ephemeral, KID);

            Recipients = Recipients ?? new List<Recipient>();
            Recipients.Add(Recipient);

            return Recipient;
            }

        /// <summary>
        /// Add a recipient to an existing JWE header.
        /// </summary>
        /// <remarks>If custom crypto suites are used, the caller is responsible for 
        /// ensuring that the exchange algorithm is compatible with the bulk algorithm 
        /// already selected. </remarks>
        /// <param name="Info">Recipient specific information</param>
        /// <param name="Secret">The secret.</param>
        /// <param name="ProviderAlgorithm">Algorithm parameters (if supported)</param>
        /// <returns>The recipient instance</returns>
        public Recipient AddRecipient(byte[] Secret, string Info = null,
                CryptoAlgorithmID ProviderAlgorithm = CryptoAlgorithmID.Default) {

            var Identifier = UDF.SymmetricKeyUDF(Secret);
            Info = Info ?? Identifier;

            var KeyDerive = new KeyDeriveHKDF(Secret, Info);
            var Encrypt = KeyDerive.Derive(IV, _CryptoDataEncrypt.Key.Length * 8);
            var WrappedKey = KeyWrapRFC3394.WrapKey(Encrypt, _CryptoDataEncrypt.Key);

            var Recipient = new Recipient("KDFW_AES_SHA_512", Identifier, WrappedKey);
            Recipients = Recipients ?? new List<Recipient>();
            Recipients.Add(Recipient);

            return Recipient;
            }


        /// <summary>
        /// Finish processing of the data and write out the integrity data
        /// </summary>
        public void Complete() {
            CryptoDataEncrypt.Complete();
            CipherText = _CryptoDataEncrypt.OutputData;
            JTag = _CryptoDataEncrypt.Integrity;

            CipherText = CryptoDataEncrypt.ProcessedData;


            // Sign here?
            }


        static Header ProtectedHeader(CryptoData Data,
                    string ContentType,
                    CryptoProviderDigest Digest) {


            var enc = Data.AlgorithmIdentifier.Bulk();
            var encID = enc.ToJoseID();

            var ProtectedTBW = new Header() {
                Cty = ContentType,
                Enc = encID
                };
            if (Digest != null) {
                ProtectedTBW.Dig = Digest.CryptoAlgorithmID.ToJoseID();
                }

            return ProtectedTBW;
            }


        void BindCryptoData(CryptoData Data, string ContentType,
                    CryptoProviderDigest Digest) {
            _CryptoDataEncrypt = Data;

            var enc = Data.AlgorithmIdentifier.Bulk();
            var encID = enc.ToJoseID();

            var ProtectedTBW = new Header() {
                Cty = ContentType,
                Enc = encID
                };
            if (Digest != null) {
                ProtectedTBW.Dig = Digest.CryptoAlgorithmID.ToJoseID();
                }

            Protected = ProtectedTBW.ToJson();
            IV = Data.IV;

            if (Digest != null) {
                Unprotected = new Header() {
                    Dig = Digest.CryptoAlgorithmID.ToJoseID()
                    };
                }

            }



        /// <summary>
        /// Find a keypair on the local machine that can decrypt a recipient entry in the supplied list.
        /// </summary>
        /// <param name="Recipients">The list of recipients</param>
        /// <param name="RecipientOut">The recipient entry that matched</param>
        /// <returns>The matching keypair</returns>
        /// <param name="keyCollection">The key collection that keys are to be persisted to </param>
        public static KeyPair MatchDecryptionKey(List<Recipient> Recipients, out Recipient RecipientOut,
            KeyCollection keyCollection = null) {
            foreach (var Recipient in Recipients) {
                var KID = Recipient.Header.Kid;
                KID.SplitAccountID(out var Domain, out var Account);

                if (Account == null) {
                    var DecryptionKey = keyCollection.LocatePrivate(KID);
                    if (DecryptionKey != null) {
                        RecipientOut = Recipient;
                        return DecryptionKey;
                        }
                    }
                }

            RecipientOut = null;
            return null;
            }


        /// <summary>
        /// Decrypt the content using the specified private key.
        /// </summary>
        /// <param name="DecryptionKey">The decryption key.</param>
        /// <param name="Recipient">The recipient</param>
        /// <returns>The decrypted data</returns>
        public byte[] Decrypt(KeyPair DecryptionKey = null, Recipient Recipient = null) {

            DecryptionKey = DecryptionKey ?? MatchDecryptionKey(Recipients, out Recipient);

            Recipient = Recipient ?? MatchRecipient(DecryptionKey);
            var AlgorithmJose = Recipient?.Header.Alg;
            var ExchangeID = AlgorithmJose.FromJoseID();

            var ProtectedText = Protected.ToUTF8();
            var Header = new Header();
            Header.Deserialize(ProtectedText);
            var BulkID = Header.Enc.FromJoseID();

            var Exchange = DecryptionKey.Decrypt(Recipient.EncryptedKey,
                        algorithmID: BulkID);

            var Provider = CryptoCatalog.Default.GetEncryption(BulkID);

            var Result = Provider.Decrypt(CipherText, Exchange, IV);

            return Result;
            }




        /// <summary>
        /// Decrypt the content using the specified private key.
        /// </summary>
        /// <param name="KeyAgreementResult">The Key agreement result</param>
        /// <param name="DecryptionKey">The decryption key.</param>
        /// <param name="Recipient">The recipient.</param>
        /// <returns>The decrypted data</returns>
        public byte[] Decrypt(Recipient Recipient, KeyPair DecryptionKey, KeyAgreementResult KeyAgreementResult) {

            var AlgorithmJose = Recipient?.Header.Alg;
            var ExchangeID = AlgorithmJose.FromJoseID();

            var ProtectedHeader = Header.FromJSON(Protected.JSONReader(), false);
            var BulkID = ProtectedHeader.Enc.FromJoseID();

            var Ephemeral = Recipient.Header.Epk.GetKeyPair(KeySecurity.Bound);

            var Exchange = DecryptionKey.Decrypt(Recipient.EncryptedKey, ephemeral: Ephemeral,
                        algorithmID: BulkID, partial: KeyAgreementResult);

            var Provider = CryptoCatalog.Default.GetEncryption(BulkID);

            var Result = Provider.Decrypt(CipherText, Exchange, IV);

            return Result;
            }



        /// <summary>
        /// Decrypt the content using the specified private key.
        /// </summary>
        /// <param name="Secret">The decryption key.</param>
        /// <param name="Info">Recipient information</param>
        /// <returns>The decrypted data</returns>
        public byte[] Decrypt(byte[] Secret, string Info = null) {
            var ProtectedText = Protected.ToUTF8();
            var Header = new Header();
            Header.Deserialize(ProtectedText);
            var BulkID = Header.Enc.FromJoseID();
            var Provider = CryptoCatalog.Default.GetEncryption(BulkID);

            var Identifier = UDF.SymmetricKeyUDF(Secret);
            var Recipient = MatchRecipient(Identifier);

            Info = Info ?? Identifier;
            var KeyDerive = new KeyDeriveHKDF(Secret, Info);
            var Encrypt = KeyDerive.Derive(IV, Provider.KeySize);
            var Exchange = KeyWrapRFC3394.UnwrapKey(Encrypt, Recipient.EncryptedKey);

            return Provider.Decrypt(CipherText, Exchange, IV);
            }

        /// <summary>
        /// Match a recipient header by key.
        /// </summary>
        /// <param name="DecryptionKey">Key</param>
        /// <returns>The Recipient data for the specified key, if found.</returns>
        public Recipient MatchRecipient(KeyPair DecryptionKey) => MatchRecipient(DecryptionKey.UDF);

        /// <summary>
        /// Match a recipient header by key identifier.
        /// </summary>
        /// <param name="UDF">Key fingerprint</param>
        /// <returns>The Recipient data for the specified key, if found.</returns>
        public Recipient MatchRecipient(string UDF) {
            foreach (var Recipient in Recipients) {
                if (Recipient?.Header?.Kid == UDF) {
                    return Recipient;
                    }
                }
            return null;
            }

        /// <summary>
        /// Return the first address that has a recryption group specified.
        /// </summary>
        /// <param name="Address">The address that matched.</param>
        /// <param name="UDF">The fingerprint of the matching key.</param>
        /// <returns>The recipient record that was matched.</returns>
        public Recipient GetRecrypted(out string Address, out string UDF) {
            foreach (var Recipient in Recipients) {
                Cryptography.UDF.ParseStrongRFC822(Recipient.Header.Kid, out Address, out UDF);

                if (UDF != null) {
                    return Recipient;
                    }
                }

            UDF = null;
            Address = null;
            return null;

            }

        }

    /// <summary>
    /// Represents a JWE recipient
    /// </summary>
    public partial class Recipient {

        /// <summary>
        /// The corresponding decryption key (if located).
        /// </summary>
        public KeyPair DecryptionKey { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Recipient() { }

        ///// <summary>
        ///// Encrypt to the specified key of the specified profile.
        ///// </summary>
        ///// <param name="RecipientData">KeyPair for the recipient.</param>
        ///// <param name="KID">Recipient Key ID.</param>
        //public Recipient(CryptoDataExchange RecipientData, string KID=null) {
        //    var RecipientKey = RecipientData.Meta;
        //    Header = new Header() {
        //        Alg = RecipientKey?.CryptoAlgorithmID.Meta().ToJoseID(),
        //        Kid = KID ?? RecipientKey?.UDF
        //        };
        //    if (RecipientData.Ephemeral != null) {
        //        Header.Epk = Key.GetPublic(RecipientData.Ephemeral);
        //        }
        //    EncryptedKey = RecipientData.Exchange;
        //    }

        /// <summary>
        /// Encrypt to the specified key of the specified profile.
        /// </summary>
        /// <param name="RecipientKey">KeyPair for the recipient.</param>
        /// <param name="ExchangeData">The key to be exchanged.</param>
        /// <param name="Ephemeral">The ephemeral key (if required by the algorithm)</param>
        /// <param name="KID">Recipient Key ID.</param>
        public Recipient(byte[] ExchangeData, KeyPair RecipientKey, KeyPair Ephemeral, string KID = null) {
            Header = new Header() {
                Alg = RecipientKey?.CryptoAlgorithmID.Meta().ToJoseID(),
                Kid = KID ?? RecipientKey?.UDF
                };
            if (Ephemeral != null) {
                Header.Epk = Key.GetPublic(Ephemeral);
                }
            EncryptedKey = ExchangeData;
            }


        /// <summary>
        /// Wrap the specified content encryption key and form the corresponding 
        /// Reccipient object containing the corresponding identifier, etc.
        /// </summary>
        /// <param name="Algorithm">The algorithm identifier</param>
        /// <param name="Identifier">The key identifier</param>
        /// <param name="WrappedKey">The wrapped key</param>
        public Recipient(string Algorithm, string Identifier, byte[] WrappedKey) {
            Header = new Header() {
                Alg = Algorithm,
                Kid = Identifier
                };
            EncryptedKey = WrappedKey;

            }

        }

    }
