using Goedel.IO;
using Goedel.Protocol;
using Goedel.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.IO;

namespace Goedel.Cryptography.Dare {
    /// <summary>
    /// DARE Message class.
    /// </summary>
    public partial class DareEnvelope : DareEnvelopeSequence, IDisposable {
        #region // Properties and fields

        /// <summary>
        /// Dictionary mapping tags to factory methods
        /// </summary>
        static Dictionary<string, JsonFactoryDelegate> ThisTagDictionary =
            new Dictionary<string, JsonFactoryDelegate>()
                {
                {"DareEnvelope", Factory}
                };

        /// <summary>
        /// The module initializer. This is called during initialization of the module.
        /// </summary>
        [ModuleInitializer]
        internal static void Initialize() => AddDictionary(ref ThisTagDictionary);

        /// <summary>
        /// Tag identifying this class
        /// </summary>
        public override string _Tag { get; } = "DareEnvelope";


        /// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
        public static JsonObject Factory() => new DareEnvelope();

        /// <summary>
        /// Return the number of data sequences.
        /// </summary>
        public int DataSequences => Header.EDSS.Count;

        ///<summary>The inner enveloped content.</summary>
        public JsonObject JsonObject { get; set; }

        ///<summary>Convenience accessor for the frame index.</summary>
        public long Index => Header.Index;

        ///<summary>Convenience accessor for the envelope id.</summary>
        public string EnvelopeId => Header.EnvelopeId;

        ///<summary>The payload digest value calculated during decoding.</summary> 
        public byte[] PayloadDigest;

        ///<summary>The payload MAC value calculated during decoding.</summary> 
        public byte[] PayloadMac;

        ///<summary>The length of the payload value</summary> 
        public long PayloadLength;


        #endregion

        #region IDisposable boilerplate code.

        /// <summary>
        /// Dispose method, frees all resources.
        /// </summary>
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
            }

        bool disposed = false;

        /// <summary>
        /// Dispose method, frees resources when disposing, 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing) {
            if (disposed) {
                return;
                }

            if (disposing) {
                Disposing();
                }

            disposed = true;
            }

        /// <summary>
        /// Destructor.
        /// </summary>
        ~DareEnvelope() {
            Dispose(false);
            }

        /// <summary>
        /// The class specific disposal routine.
        /// </summary>
        protected virtual void Disposing() { }

        #endregion

        #region // Constructors and Factories

        /// <summary>
        /// Create an empty DARE Message (for use by deserializers)
        /// </summary>
        public DareEnvelope() { }

        /// <summary>
        /// Create a DARE Message instance.
        /// </summary>
        /// <param name="cryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <param name="contentMeta">The content metadata</param>
        /// <param name="plaintext">The payload plaintext. If specified, the plaintext will be used to
        /// create the message body. Otherwise the body is specified by calls to the Process method.</param>
        /// <param name="cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
        /// <param name="dataSequences">Data sequences to be converted to an EDS and presented 
        ///     as an EDSS header entry.</param>
        public DareEnvelope(
                CryptoParameters cryptoParameters,
                byte[] plaintext,
                ContentMeta contentMeta = null,
                byte[] cloaked = null,
                List<byte[]> dataSequences = null   
                ) {
            Header = new DareHeader() {
                ContentMeta= contentMeta
                };
            Header.BindEncoder(cryptoParameters, cloaked, dataSequences);
            //var _ = new CryptoStackEncode(cryptoParameters, Header, cloaked, dataSequences);
            Body = Header.EnhanceBody(plaintext, out var trailer);
            Trailer = trailer;
            }





        /// <summary>
        /// Create a new DARE Message from the specified parameters.
        /// </summary>
        /// <param name="plaintext">The payload plaintext.</param>
        /// <param name="contentType">The content type.</param>
        /// <returns>The new envelope</returns>
        public static DareEnvelope Encode(
            byte[] plaintext,
            string contentType) => Encode(plaintext, contentMeta: new ContentMeta() { ContentType = contentType });

        /// <summary>
        /// Create a new DARE Message from the specified parameters.
        /// </summary>
        /// <param name="plaintext">The payload plaintext. If specified, the plaintext will be used to
        /// create the message body. Otherwise the body is specified by calls to the Process method.</param>
        /// <param name="signingKey">The signature key.</param>
        /// <param name="encryptionKey">The encryption key.</param>
        /// <param name="contentMeta">The content metadata</param>
        /// <param name="cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
        /// <param name="dataSequences">Data sequences to be converted to an EDS and presented 
        ///     as an EDSS header entry.</param>
        /// <returns></returns>
        public static DareEnvelope Encode(
            byte[] plaintext,
            ContentMeta contentMeta = null,
            CryptoKey signingKey = null,
            CryptoKey encryptionKey = null,
            byte[] cloaked = null,
            List<byte[]> dataSequences = null) {
            var cryptoParameters = new CryptoParameters(signer: signingKey, recipient: encryptionKey);
            return new DareEnvelope(cryptoParameters, plaintext, contentMeta, cloaked, dataSequences);
            }

        ///// <summary>
        ///// Encrypt the 
        ///// </summary>
        ///// <param name="plaintext"></param>
        ///// <param name="pin"></param>
        ///// <param name="contentMeta"></param>
        ///// <param name="cloaked"></param>
        ///// <param name="dataSequences"></param>
        ///// <returns></returns>
        //public static DareEnvelope Encrypt(byte[] plaintext, string pin,
        //            ContentMeta contentMeta = null,
        //            byte[] cloaked = null,
        //            List<byte[]> dataSequences = null) {

        //    var cryptoStack = new CryptoStack(pin);
        //    return new DareEnvelope(cryptoStack, plaintext, contentMeta, cloaked, dataSequences);
        //    }

        #endregion

        #region // Convenience accessors

        /// <summary>
        /// Return the plaintext of a data sequence.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public byte[] DataSequence(int i) => Header.DataSequence(i);

        /// <summary>
        /// Create a JSONReader for the decrypted body content according to the specified encoding.
        /// </summary>
        /// <returns></returns>
        public JsonReader GetBodyReader() => Body.JsonReader();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool ReadChunk(JsonReader jsonReader,
            out byte[] chunk) => jsonReader.ReadBinaryIncremental(out chunk);

        #endregion

        #region // Serialization overrides

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
        public override void Serialize(Writer writer,
            bool wrap,
            ref bool first) => SerializeX(writer, wrap, ref first);

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
        public new void SerializeX(Writer writer,
                    bool wrap,
                    ref bool first) {
            first = false;
            writer.WriteArrayStart();
            if (Header != null) {
                Header.Serialize(writer, false);
                }
            else {
                writer.WriteObjectStart();
                writer.WriteObjectEnd();
                }
            writer.WriteArraySeparator(ref first);
            writer.WriteBinary(Body ?? Array.Empty<byte>());
            if (Trailer != null) {
                writer.WriteArraySeparator(ref first);
                Trailer.Serialize(writer, false);
                }
            writer.WriteArrayEnd();
            }


        /// <summary>
        /// Deserialize the input string to populate this object
        /// </summary>
        /// <param name="jsonReader">Input data</param>
        public override void Deserialize(JsonReader jsonReader) {
            // NB: This was not filled in during testing. This implementation has not been regression 
            // tested and may cause other things to fail.

            if (!jsonReader.StartArray()) {
                return;
                }
            Header = new DareHeader();
            Header.Deserialize(jsonReader);
            if (!jsonReader.NextArray()) {
                return;
                }
            Body = jsonReader.ReadBinary();
            if (!jsonReader.NextArray()) {
                return;
                }
            Trailer = new DareTrailer();
            Trailer.Deserialize(jsonReader);
            jsonReader.EndArray();
            }

        #endregion

        #region // Payload decoding routines 

        /// <summary>
        /// Deserialize 
        /// </summary>
        /// <param name="data">The data to deserialize</param>
        /// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <param name="decrypt">If true, attempt to decrypt the message body as it is read.</param>
        /// <param name="keyCollection">Key collection to be used to discover decryption keys</param>
        /// <returns>The created object.</returns>	
        public static DareEnvelope FromJSON(byte[] data,
            bool tagged = true,
            bool decrypt = false,
            IKeyLocate keyCollection = null) {
            var jsonBcdReader = new JsonBcdReader(data);
            return FromJSON(jsonBcdReader, tagged, decrypt, keyCollection);
            }

        /// <summary>
        /// Return the plaintext payload using the credentials stored in <paramref name="keyCollection"/>
        /// to obtain decryption keys if necessary.
        /// </summary>
        /// <param name="keyCollection">The key collection to use to obtain decryption keys.</param>
        /// <returns>The plaintext payload.</returns>
        public byte[] GetPlaintext(IKeyLocate keyCollection) {
            using var inputStream = new MemoryStream(Body);
            using var outputStream = new MemoryStream();

            var decoder = Header.GetDecoder(
                inputStream, out var reader,
                keyCollection: keyCollection);
            reader.CopyTo(outputStream);
            decoder.Close();
            return outputStream.ToArray();
            }

        /// <summary>
        /// Verify that the signature value is correct for the key <paramref name="key"/>
        /// </summary>
        /// <param name="key">The signature key.</param>
        /// <returns>True, if the signature is valid.</returns>
        public bool Verify(KeyPair key) {

            var signature = FindSignature(key);
            if (signature == null) {
                return false;
                }

            "Recalculate the payload digest".TaskFunctionality();

            return key.VerifyHash(Trailer.PayloadDigest, signature.SignatureValue);
            }

        /// <summary>
        /// Find a signature whose key identifier matches <paramref name="key"/>
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The signature entry.</returns>
        public DareSignature FindSignature (CryptoKey key) {

            if (Trailer.Signatures != null) {
                foreach (var signature in Trailer.Signatures) {
                    if (key.MatchKeyIdentifier(signature.KeyIdentifier)) {
                        return signature;
                        }
                    }
                }
            if (Header.Signatures != null) {
                foreach (var signature in Header.Signatures) {
                    if (key.MatchKeyIdentifier(signature.KeyIdentifier)) {
                        return signature;
                        }
                    }
                }


            return null;
            }



        /// <summary>
        /// Deserialize 
        /// </summary>
        /// <param name="stream">The input stream</param>
        /// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <param name="decrypt">If true, attempt to decrypt the message body as it is read.</param>
        /// <param name="keyCollection">Key collection to be used to discover decryption keys</param>
        /// <returns>The created object.</returns>	
        public static DareEnvelope FromJSON(Stream stream,
            bool tagged = true,
            bool decrypt = false,
            IKeyLocate keyCollection = null) {
            var jsonBcdReader = new JsonBcdReader(stream); // Hack: should merge this with GetPlaintext
            return FromJSON(jsonBcdReader, tagged, decrypt, keyCollection);
            }

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <param name="decrypt">If true, attempt to decrypt the message body as it is read.</param>
        /// <param name="keyCollection">Key collection to be used to discover decryption keys</param>
        /// <param name="verify">If true perform specified verification after deserialization.</param>
        /// <returns>The created object.</returns>		
        public static DareEnvelope FromJSON(JsonBcdReader jsonReader,
                bool tagged = true,
                bool decrypt = false,
                IKeyLocate keyCollection = null,
                bool verify = true) {
            decrypt.Keep();
            Assert.AssertFalse(tagged, TaggingNotSupported.Throw);


            // DecodeHeader checks for start of array
            //bool _Going = JSONReader.StartArray();

            var message = DecodeHeader(jsonReader);

            using (var buffer = new MemoryStream()) {
                var decoder = message.Header.GetDecoder(
                    jsonReader, out var reader,
                    keyCollection: keyCollection);
                reader.CopyTo(buffer);
                decoder.Close();
                message.PayloadDigest = decoder.DigestValue;
                message.PayloadMac = decoder.MacValue;
                message.Body = buffer.ToArray();
                }

            if (jsonReader.NextArray()) {
                message.Trailer = DareTrailer.FromJson(jsonReader, false);
                }

            // Verify that the specified payload digest matches that calculated.
            if (verify & message.Header.DigestAlgorithm != null) {
                //message.PayloadDigest.AssertNotNull();
                }


            return message;
            }

        /// <summary>
        /// Read a DareEnvelope from a stream in incremental mode. The header of the 
        /// message is read but not the body.
        /// </summary>
        /// <param name="jsonReader">The stream from which data is to be read.</param>
        /// <returns>The DareEnvelope instance.</returns>
        public static DareEnvelope DecodeHeader(JsonBcdReader jsonReader) {
            Assert.AssertTrue(jsonReader.StartArray(), EnvelopeDataCorrupt.Throw);
            var header = DareHeader.FromJson(jsonReader, false);
            Assert.AssertNotNull(
                header,
                EnvelopeDataCorrupt.Throw);
            Assert.AssertTrue(jsonReader.NextArray(), EnvelopeDataCorrupt.Throw);
            return new DareEnvelope() {
                Header = header
                };
            }

        /// <summary>
        /// Decode a streamed message
        /// </summary>
        /// <param name="inputFile">The input file, must support reading.</param>
        /// <param name="outputFile">The output file, must support writing</param>
        /// <param name="cryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <param name="contentMeta">The content metadata</param>
        /// <param name="cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
        /// <param name="dataSequences">Data sequences to be converted to an EDS and presented 
        ///     as an EDSS header entry.</param>
        /// <param name="chunk">The maximum chunk size. If unspecified, the default
        /// system chunk size (2048) is used.</param>
        /// <returns>The number of bytes in the input file.</returns>
        public static long Encode(
            CryptoParameters cryptoParameters,
            string inputFile,
            string outputFile = null,
            ContentMeta contentMeta = null,
            byte[] cloaked = null,
            List<byte[]> dataSequences = null,
            int chunk = -1) {
            using var output = outputFile.OpenFileNew();
            using var input = inputFile.OpenFileRead();
            Encode(
                cryptoParameters, input, output, input.Length,
                contentMeta, cloaked, dataSequences, chunk);
            return input.Length;
            }

        /// <summary>
        /// Decode a streamed message
        /// </summary>
        /// <param name="inputData">The input data</param>
        /// <param name="cryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <param name="contentMeta">The content metadata</param>
        /// <param name="cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
        /// <param name="dataSequences">Data sequences to be converted to an EDS and presented 
        ///     as an EDSS header entry.</param>
        /// <param name="chunk">The maximum chunk size. If unspecified, the default
        /// system chunk size (2048) is used.</param>
        /// <returns>The serialized encoding of the data.</returns>
        public static byte[] Encode(
            CryptoParameters cryptoParameters,
            byte[] inputData,
            ContentMeta contentMeta = null,
            byte[] cloaked = null,
            List<byte[]> dataSequences = null,
            int chunk = -1) {
            using var outputStream = new MemoryStream();
            using var inputStream = new MemoryStream(inputData);
            Encode(
                cryptoParameters, inputStream, outputStream, inputStream.Length,
                contentMeta, cloaked, dataSequences, chunk);
            return outputStream.ToArray();
            }


        /// <summary>
        /// Encode data received on the input stream to the output stream with the specified
        /// security enhancements. If the input stream supports the seek operation, and
        /// the maximum chunk size is less than 1, the output file will be written as a 
        /// single sequence. Otherwise, the file will be written with a chunk size no
        /// greater than the maximum specified.
        /// </summary>
        /// <param name="inputStream">The input stream, must support reading.</param>
        /// <param name="outputStream">The output stream, must support writing</param>
        /// <param name="cryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <param name="contentMeta">The content metadata</param>
        /// <param name="cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
        /// <param name="dataSequences">Data sequences to be converted to an EDS and presented 
        ///     as an EDSS header entry.</param>
        /// <param name="chunk">The maximum chunk size. If unspecified, the default
        /// system chunk size (2048) is used.</param>
        /// <param name="contentLength">The content length. This value is ignored if the Plaintext
        /// parameter is not null. If the value is less than 0, chunked encoding
        /// will be used for the payload data. </param>         
        public static void Encode(
            CryptoParameters cryptoParameters,
            Stream inputStream,
            Stream outputStream,
            long contentLength = -1,
            ContentMeta contentMeta = null,
            byte[] cloaked = null,
            List<byte[]> dataSequences = null,
            int chunk = -1) {
            using var dareEnvelopeWriter = new DareEnvelopeWriter(
                cryptoParameters,
                outputStream, contentMeta, contentLength, cloaked, dataSequences);
            inputStream.CopyTo(dareEnvelopeWriter);
            }

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new DareEnvelope FromJson(JsonReader jsonReader,
            bool tagged = true) {
            if (jsonReader == null) {
                return null;
                }
            if (tagged) {
                var Out = jsonReader.ReadTaggedObject(TagDictionary);
                return Out as DareEnvelope;
                }
            var result = new DareEnvelope();
            result.Deserialize(jsonReader);
            result.PostDecode();
            return result;
            }

        /// <summary>
        /// Decode a tagged JSONObject using keys from <paramref name="keyCollection"/> to decrypt
        /// if necessary.
        /// </summary>
        /// <param name="keyCollection">Key collection to be used for decryption.</param>
        /// <returns>The decoded object.</returns>
        public JsonObject DecodeJsonObject(IKeyLocate keyCollection = null) {
            var plaintext = GetPlaintext(keyCollection);

            Console.WriteLine(plaintext.ToUTF8());
            var result = FromJson(plaintext.JsonReader(), true);
            return result;
            }


        /// <summary>
        /// Decode a streamed message
        /// </summary>
        /// <param name="inputFile">The input file, must support reading.</param>
        /// <param name="outputFile">The output file, must support writing</param>
        /// <param name="keyCollection">The key collection to be used to resolve identifiers to keys.</param>
        public static long Decode(
            string inputFile,
            string outputFile = null,
            IKeyLocate keyCollection = null) {
            using var input = inputFile.OpenFileRead();
            return Decode(input, null, outputFile, keyCollection);
            }

        /// <summary>
        /// Decode a streamed message
        /// </summary>
        /// <param name="inputStream">The input stream, must support reading.</param>
        /// <param name="outputStream">The output stream, must support writing</param>
        /// <param name="outputFile">The output file, must support writing</param>
        /// <param name="keyCollection">The key collection to be used to resolve identifiers to keys.</param>
        public static long Decode(
            Stream inputStream,
            Stream outputStream,
            string outputFile = null,
            IKeyLocate keyCollection = null) {
            long length = -1;
            keyCollection ??= Cryptography.KeyCollection.Default;

            var jsonBcdReader = new JsonBcdReader(inputStream);
            using var message = DecodeHeader(jsonBcdReader);
            var decoder = message.Header.GetDecoder(
                jsonBcdReader, out var Reader,
                keyCollection: keyCollection);

            if (outputStream != null) {
                Reader.CopyTo(outputStream);
                outputStream.Flush();
                }
            else {
                var filename = outputFile ?? message.Header.ContentMeta.Filename;
                using var output = filename.OpenFileNew();
                Reader.CopyTo(output);
                output.Flush();
                length = output.Length;
                }
            decoder.Close();

            return length;
            }


        /// <summary>
        /// Decode a streamed message
        /// </summary>
        /// <param name="inputFile">File to be read as input</param>
        /// <param name="keyCollection">The key collection to be used to resolve identifiers to keys.</param>
        public static DareEnvelope Verify(
            string inputFile,
            IKeyLocate keyCollection = null) {
            using var inputStream = inputFile.OpenFileRead();
            return Verify(inputStream, keyCollection);
            }

        /// <summary>
        /// Decode a streamed message
        /// </summary>
        /// <param name="inputStream">The input stream, must support reading.</param>
        /// <param name="keyCollection">The key collection to be used to resolve identifiers to keys.</param>
        public static DareEnvelope Verify(
            Stream inputStream,
            IKeyLocate keyCollection = null) {

            keyCollection ??= Cryptography.KeyCollection.Default;
            var jsonBcdReader = new JsonBcdReader(inputStream);
            using var message = DecodeHeader(jsonBcdReader);

            var decoder = message.Header.GetDecoder(
                jsonBcdReader, out var Reader,
                keyCollection: keyCollection, decrypt:false);

            Reader.CopyTo(Stream.Null);
            decoder.Close();
            message.PayloadDigest = decoder.DigestValue;
            message.PayloadMac = decoder.MacValue;
            message.PayloadLength = decoder.BytesRead;

            if (jsonBcdReader.NextArray()) {
                message.Trailer = DareTrailer.FromJson(jsonBcdReader, false);
                }


            return message;

            //// Hack: This routine should return a result structure showing how the data is signed and by whom
            ////[i.e. include the algorithm, digest method, scope, etc.


            ////keyCollection ??= KeyCollection.Default;

            //using (var jsonBcdReader = new JsonBcdReader(inputStream)) {
            //    //var Message = DecodeHeader(JSONBCDReader);

            //    //var Decoder = Message.Header.GetDecoder(
            //    //            JSONBCDReader, out var Reader,
            //    //            KeyCollection: keyCollection);

            //    //Decoder.Close();
            //    }

            //return true; // Hack: perform the actual check here and return a boolean.
            }



        public void Strip() {
            if (Trailer != null) {
                Trailer.PayloadDigest = null;
                }

            if (Header != null) {
                Header.ContentMeta= null;
                Header.ContentMetaData = null;
                }
            }
        #endregion
        }
    }