using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Utilities;
using System.Threading;
using Goedel.Cryptography;
using Goedel.Protocol;
using Goedel.Cryptography.Jose;
using System.Security.Cryptography;

namespace Goedel.Cryptography.Dare {

    public partial class DAREHeader {

        byte[] MasterSecret;

        /// <summary>
        /// The IV, Payload and Signer data of the associated message.
        /// </summary>
        public EnhancedDataSequence EDS { get; set; }

        /// <summary>
        /// The Encryption algorithm
        /// </summary>
        public CryptoAlgorithmID EncryptID;

        ///// <summary>
        ///// The authentication algorithm
        ///// </summary>
        //public CryptoAlgorithmID AuthenticateID;

        /// <summary>
        /// Create a message header with a new key exchange
        /// </summary>
        /// <param name="EncryptionKeys"></param>
        /// <param name="SignerKeys"></param>
        /// <param name="EncryptID">The bulk encryption algorithm to use.</param>
        /// <param name="AuthenticateID">The bulk authentication algorithm to use. If the 
        /// encryption algorithm is an authenticated encryption algorithm, and 
        /// CryptoAlgorithmID.Default is specified, the value CryptoAlgorithmID.NULL
        /// is used.</param>
        /// <param name="ContentType">The payload content type.</param>
        /// <param name="ContentLength">The content length. This value is ignored if the Plaintext
        /// parameter is not null. If the value is less than 0, chunked encoding
        /// will be used for the payload data. </param>
        /// <param name="Plaintext">The payload plaintext, if known.</param>
        /// <param name="Cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
        /// <param name="DataSequences">Data sequences to be converted to an EDS and presented 
        ///     as an EDSS header entry.</param>
        public DAREHeader (
                    List<KeyPair> EncryptionKeys = null,
                    List<KeyPair> SignerKeys = null,
                    CryptoAlgorithmID EncryptID = CryptoAlgorithmID.Default,
                    CryptoAlgorithmID AuthenticateID = CryptoAlgorithmID.Default,
                    string ContentType = null,
                    byte[] Plaintext = null,
                    long ContentLength = -1,
                    byte[] Cloaked = null,
                    List<byte[]> DataSequences = null
                    ) {
            EncryptID = EncryptID == CryptoAlgorithmID.Default ? CryptoAlgorithmID.AES256CBC : EncryptID;
            EncryptionAlgorithm = EncryptID.ToJoseID();

            SetCiphers();
            KeyExchange(EncryptionKeys);

            SaltValue = 0;
            EnhanceHeaders(Cloaked, DataSequences);
            }

        /// <summary>
        /// Create a message header under a prior key exchange
        /// </summary>
        /// <param name="Master">Header instance defining the Master secret and associated context.</param>
        /// <param name="SignerKeys"></param>
        /// <param name="EncryptID">The bulk encryption algorithm to use.</param>
        /// <param name="ContentType">The payload content type.</param>
        /// <param name="ContentLength">The content length. This value is ignored if the Plaintext
        /// parameter is not null. If the value is less than 0, chunked encoding
        /// will be used for the payload data. </param>
        /// <param name="Plaintext">The payload plaintext, if known.</param>
        /// <param name="Cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
        /// <param name="DataSequences">Data sequences to be converted to an EDS and presented 
        ///     as an EDSS header entry.</param>
        public DAREHeader (
                    DAREHeader Master,
                    List<KeyPair> SignerKeys = null,
                    CryptoAlgorithmID EncryptID = CryptoAlgorithmID.Default,
                    //CryptoAlgorithmID AuthenticateID = CryptoAlgorithmID.Default,
                    string ContentType = null,
                    byte[] Plaintext = null,
                    long ContentLength = -1,
                    byte[] Cloaked = null,
                    List<byte[]> DataSequences = null
                    ) {
            // Read in parameters from the master header
            if (EncryptID == CryptoAlgorithmID.Default) {
                this.EncryptID = Master.EncryptID;
                }
            else {
                this.EncryptID = EncryptID;
                EncryptionAlgorithm = EncryptID.ToJoseID();
                }

            //if (AuthenticateID == CryptoAlgorithmID.Default) {
            //    this.AuthenticateID = Master.AuthenticateID;
            //    }
            //else {
            //    this.AuthenticateID = AuthenticateID;
            //    AuthenticationAlgorithm = "TBS";
            //    throw new NYI();
            //    }

            MasterSecret = Master.MasterSecret;
            SaltValue = -1;

            EnhanceHeaders(Cloaked, DataSequences);
            }

        
        /// <summary>
        /// The cryptography provider.
        /// </summary>
        CryptoProviderEncryption ProviderEncryption = null;

        void SetCiphers () {
            ProviderEncryption = CryptoCatalog.Default.GetEncryption(EncryptID);
            }


        void KeyExchange (
                    List<KeyPair> EncryptionKeys) {
            throw new NYI();
            }

        void EnhanceHeaders (
                    byte[] Cloaked = null,
                    List<byte[]> DataSequences = null) {

            if (Cloaked != null) {
                this.Cloaked = Enhance(Cloaked);
                }
            if (DataSequences != null) {
                this.EDSS = new List<byte[]>();
                foreach (var DataSequence in DataSequences) {
                    EDSS.Add (Enhance(DataSequence));
                    }
                }

            }

        /// <summary>
        /// Return a binary EDS sequence of the specified plaintext under this header. A
        /// unique salt will be assigned.
        /// </summary>
        /// <param name="Plaintext">The EDS plaintext.</param>
        /// <returns>The EDS</returns>
        public byte[] Enhance (byte[] Plaintext) {
            return EnhancedDataSequence.Enhance(MasterSecret, Plaintext, MakeSalt(), ProviderEncryption);
            }

        long SaltValue;

        /// <summary>
        /// Threadsafe assignment of unique salt under this master secret.
        /// </summary>
        /// <returns></returns>
        /// <threadsafety static="true" instance="true"/>
        public byte[] MakeSalt () {
            if (SaltValue >= 0) {

                var Salt = Interlocked.Increment(ref SaltValue);
                return MakeSalt(Salt);
                }
            else {

                return Platform.GetRandomBits(128);
                }
            }

        /// <summary>
        /// Convert an int64 counter to a unique salt value.
        /// </summary>
        /// <param name="SaltValue"></param>
        /// <returns></returns>
        public static byte[] MakeSalt (long SaltValue) {
            var Salt = SaltValue;

            var Index = 0;
            while (Salt > 0xFF) {
                Index++;
                Salt = Salt >> 8;
                }

            var Result = new byte[Index+1];

            Salt = SaltValue;
            Index = 0;
            while (Salt > 0xFF) {
                Result[Index++] = (byte) (Salt & 0xFF);
                Salt = Salt >> 8; 
                }
            return Result;

            }


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
        //            out List<DARERecipient> Recipients,
        //            out Header Protected,
        //            List<KeyPair> EncryptionKeys = null,
        //            string ContentType = null,
        //            CryptoAlgorithmID EncryptID = CryptoAlgorithmID.Default
        //            ) {

        //    throw new NYI();

        //    //var Provider = CryptoCatalog.Default.GetEncryption(EncryptID);
        //    //var EncryptEncoder = Provider.MakeEncoder(Algorithm: EncryptID);
        //    //Protected = JoseWebEncryption.ProtectedHeader(EncryptEncoder, ContentType, null);

        //    //Recipients = new List<Cryptography.Jose.Recipient>();

        //    //foreach (var EncryptionKey in EncryptionKeys) {
        //    //    var KID = EncryptionKey.Name ?? EncryptionKey.UDF;
        //    //    var Recipient = JoseWebEncryption.Recipient(
        //    //            EncryptEncoder, EncryptionKey, KID: KID, ProviderAlgorithm: EncryptID);
        //    //    Recipients.Add(Recipient);
        //    //    }

        //    //EncryptEncoder.Write(Data);
        //    //EncryptEncoder.Complete();

        //    //return EncryptEncoder;
        //    }




        }

    /// <summary>
    /// Create an Enhanced Data Sequence.
    /// </summary>
    public abstract class EnhancedDataSequence {

        /// <summary>Constant for deriving a MAC key.</summary>
        public static readonly byte[] InfoKeyMAC = "mac".ToBytes();

        /// <summary>Constant for deriving an encryption key.</summary>
        public static readonly byte[] InfoKeyEncrypt = "encrypt".ToBytes();

        /// <summary>Constant for deriving an initialization vector.</summary>
        public static readonly byte[] InfoKeyIV = "iv".ToBytes();





        /// <summary>The Initialization Vector</summary>
        protected byte[] IV { get; private set; }

        /// <summary>The Initialization Vector</summary>
        protected byte[] KeyEncrypt { get; private set; }

        /// <summary>The Initialization Vector</summary>
        protected byte[] KeyMac { get; private set; }

        ///// <summary>The processed message payload.</summary>
        //public virtual byte[] Payload => throw new NYI();

        /////// <summary></summary>
        ////public DARETrailer Trailer { get; set; }

        /// <summary>The computed length of the message payload. This is only known if the
        /// message content or content length was specified when the object instance was created.
        /// That is, the length of the ciphertext, padding and authentication tag (if present)
        /// but not the token specifying the payload length.</summary>
        public long PayloadLength { get; protected set; } = -1;







        //bool Finalized;



        ///// <summary>
        ///// Create a new EnhancedDataSequence with the specified cryptographic parameters.
        ///// </summary>
        ///// <param name="EncryptID">The bulk encryption algorithm to use.</param>
        ///// <param name="MasterSecret">The Master Secret</param>
        ///// <param name="Salt">The salt used to derive keys from the Master Secret.</param>



        //public EnhancedDataSequence (
        //            CryptoAlgorithmID EncryptID,
        //    byte[] MasterSecret,
        //    byte[] Salt = null
        //            ) : this (CryptoCatalog.Default.GetEncryption(EncryptID), MasterSecret, Salt) {
        //    }

        /// <summary>
        /// Create a new EnhancedDataSequence with the specified cryptographic parameters.
        /// </summary>
        /// <param name="ProviderEncrypt">Crypto algorithm provider</param>
        /// <param name="MasterSecret">The Master Secret</param>
        /// <param name="Salt">The salt used to derive keys from the Master Secret.</param>

        


        public EnhancedDataSequence (
                    CryptoProviderEncryption ProviderEncrypt,
                    byte[] MasterSecret,
                    byte[] Salt = null
                    ) {

            var KDF = new KeyDeriveHKDF(MasterSecret, Salt, CryptoAlgorithmID.HMAC_SHA_2_256);
            KeyEncrypt = KDF.Derive(InfoKeyEncrypt, 256);
            KeyMac = KDF.Derive(InfoKeyMAC, ProviderEncrypt.KeySize);
            IV = KDF.Derive(InfoKeyEncrypt, ProviderEncrypt.BlockSize);       // Hack: hardcoded the key and IV size


            }

        /// <summary>
        /// Process a data chunk and obtain a partial result.
        /// </summary>
        /// <param name="Input">The input data to process</param>
        /// <param name="Final">If true, this is the final data chunk.</param>
        /// <returns>The result of processing the partial message. 
        /// This MAY be a zero length byte array.</returns>
        public abstract void Process (byte[] Input, bool Final);

        /// <summary>
        /// Enhance the specified plaintext data under the specified Master Secret and Sale (if specified).
        /// </summary>
        /// <param name="MasterSecret">The Master Secret from which the necessary cryptographic parameters 
        /// are generated.</param>
        /// <param name="ProviderEncrypt">Crypto algorithm provider</param>
        /// <param name="Plaintext">The input</param>
        /// <param name="Salt"></param>
        /// <returns>The result of applying the enhancement.</returns>
        public static byte[] Enhance (
                    byte[] MasterSecret,
                    byte[] Plaintext,
                    byte[] Salt = null,
                    CryptoProviderEncryption ProviderEncrypt = null
                    
                    ) {

            var Output = new MemoryStream();

            var EDS = new EnhancedDataSequenceWriter(Output, MasterSecret, ProviderEncrypt, Salt, Plaintext);
            return Output.ToArray();

            }



        }

    /// <summary>
    /// Write an Enhanced Data Sequence to a buffered output stream.
    /// </summary>
    public class EnhancedDataSequenceWriter : EnhancedDataSequence {

        JSONBWriter OutputStream;
        bool Finalized;

        ICryptoTransform EncryptTransform = null;


        ///// <summary>The processed message payload.</summary>
        //public override byte[] Payload => OutputStream.ToArray();

        /// <summary>
        /// Create a buffered writer for an Enhanced Data Sequence
        /// </summary>
        /// <param name="MasterSecret"></param>
        /// <param name="ProviderEncrypt">Crypto algorithm provider</param>
        /// <param name="Salt"></param>
        /// <param name="Plaintext"></param>
        /// <param name="OutputStream">The output stream</param>
        /// <param name="ContentLength">The content length. If this value is 0 or greater, the 
        /// PayloadLength property will be set to the value of the payload data length field. </param>
        public EnhancedDataSequenceWriter (
                    Stream OutputStream,
                    byte[] MasterSecret,
                    CryptoProviderEncryption ProviderEncrypt = null,
                    byte[] Salt = null,
                    byte[] Plaintext = null,
                    long ContentLength = -1
                    ) : this (new JSONBWriter(OutputStream), MasterSecret, ProviderEncrypt, Salt, Plaintext, ContentLength) {
            }


        /// <summary>
        /// Create a buffered writer for an Enhanced Data Sequence
        /// </summary>
        /// <param name="MasterSecret"></param>
        /// <param name="ProviderEncrypt">Crypto algorithm provider</param>
        /// <param name="Salt"></param>
        /// <param name="Plaintext"></param>
        /// <param name="OutputStream">The output stream</param>
        /// <param name="ContentLength">The content length. If this value is 0 or greater, the 
        /// PayloadLength property will be set to the value of the payload data length field. </param>
        public EnhancedDataSequenceWriter (
                    JSONBWriter OutputStream,
                    byte[] MasterSecret,
                    CryptoProviderEncryption ProviderEncrypt = null,
                    byte[] Salt = null,
                    byte[] Plaintext = null,
                    long ContentLength = -1
                    ) : base(ProviderEncrypt, MasterSecret, Salt) {

            // The encryption encoder is always the last one.
            EncryptTransform = ProviderEncrypt.CreateEncryptor(KeyEncrypt, IV);

            // write the salt to the output stream

            if (Plaintext != null) {
                ContentLength = Plaintext.LongLength;
                }

            if (ContentLength >= 0) {
                PayloadLength = ProviderEncrypt.OutputLength(ContentLength);
                OutputStream.WriteBinaryBegin(ContentLength, true);
                }
            else {
                OutputStream.WriteBinaryBegin(ContentLength, false);

                throw new NYI();
                }

            if (Plaintext != null) {
                Process(Plaintext, true);
                }


            }

        /// <summary>
        /// Process a data chunk and obtain a partial result.
        /// </summary>
        /// <param name="Input">The input data to process. Currently limited to 2^32 bytes. This is unlikely to
        /// be a concern since the need to buffer the data internally makes presenting input data in large chunks 
        /// highly undesirable.</param>
        /// <param name="Final">If true, this is the final data chunk.</param>
        /// <returns>The result of processing the partial message. 
        /// This MAY be a zero length byte array.</returns>
        public override void Process (byte[] Input, bool Final) {

            Assert.False(Finalized);
            Assert.True(Input.LongLength < Int32.MaxValue);
            Assert.NotNull(EncryptTransform);

            int BlockSize = EncryptTransform.InputBlockSize;

            int Blocks = Input.Length % BlockSize;
            int InputLength = Blocks * BlockSize;
            int Remainder = Input.Length - InputLength;

            Assert.True(Final | Remainder == 0); // Hack, constrain input length to multiple of whole blocks

            var OutputBuffer = new byte[InputLength];

            EncryptTransform.TransformBlock(Input, 0, InputLength, OutputBuffer, 0);
            OutputStream.WriteBinaryPart(OutputBuffer);

            if (Final) {
                var FinalBlock = EncryptTransform.TransformFinalBlock(Input, InputLength, Remainder);
                OutputStream.WriteBinaryPart(FinalBlock);
                }

            }

        }
    }
