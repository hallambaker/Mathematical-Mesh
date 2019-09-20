using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Utilities;
using System.Threading;
using Goedel.Cryptography;
using Goedel.Protocol;
using Goedel.IO;

namespace Goedel.Cryptography.Dare {

    /// <summary>
    /// DARE Message class.
    /// </summary>
    public partial class DareEnvelope : DareEnvelopeSequence, IDisposable {


        /// <summary>
        /// Tag identifying this class
        /// </summary>
        public override string _Tag { get; } = "DareEnvelope";




        /// <summary>
        /// Create an empty DARE Message (for use by deserializers)
        /// </summary>
        public DareEnvelope() {
            }

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
                    ContentMeta contentMeta=null,
                    byte[] cloaked = null,
                    List<byte[]> dataSequences = null
                    ) {

            var cryptoStack = cryptoParameters.GetCryptoStack();

            Header = new DareHeader(cryptoStack, contentMeta, cloaked, dataSequences);
            Body = Header.EnhanceBody(plaintext, out var trailer);
            Trailer = trailer;
            }

        /// <summary>
        /// Create a DARE Message instance.
        /// </summary>
        /// <param name="cryptoStack">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <param name="contentMeta">The content metadata</param>
        /// <param name="plaintext">The payload plaintext. If specified, the plaintext will be used to
        /// create the message body. Otherwise the body is specified by calls to the Process method.</param>
        /// <param name="cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
        /// <param name="dataSequences">Data sequences to be converted to an EDS and presented 
        ///     as an EDSS header entry.</param>
        public DareEnvelope(
                    CryptoStack cryptoStack,
                    byte[] plaintext,
                    ContentMeta contentMeta=null,
                    byte[] cloaked = null,
                    List<byte[]> dataSequences = null
                    ) {
            Header = new DareHeader(cryptoStack, contentMeta, cloaked, dataSequences);
            Body = Header.EnhanceBody(plaintext, out var trailer);
            Trailer = trailer;
            }



        /// <summary>
        /// Create a DARE Message instance.
        /// </summary>
        /// <param name="cryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <param name="outputStream">The stream to which the output will be written.</param>
        /// <param name="contentMeta">The content metadata</param>
        /// <param name="contentLength">The content length. This value is ignored if the Plaintext
        /// parameter is not null. If the value is less than 0, chunked encoding
        /// will be used for the payload data. </param>
        /// <param name="plaintext">The payload plaintext. If specified, the plaintext will be used to
        /// create the message body. Otherwise the body is specified by calls to the Process method.</param>
        /// <param name="cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
        /// <param name="dataSequences">Data sequences to be converted to an EDS and presented 
        ///     as an EDSS header entry.</param>
        public DareEnvelope(
                    CryptoParameters cryptoParameters,
                    Stream outputStream,
                    ContentMeta contentMeta,
                    byte[] plaintext = null,
                    long contentLength = -1,
                    byte[] cloaked = null,
                    List<byte[]> dataSequences = null
                    ) {

            var cryptoStack = cryptoParameters.GetCryptoStack();

            Header = new DareHeader(cryptoStack, contentMeta, cloaked, dataSequences);
            JSONBWriter = new JSONBWriter(outputStream);
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
                    KeyPair signingKey = null,
                    KeyPair encryptionKey = null,
                    byte[] cloaked = null,
                    List<byte[]> dataSequences = null) {
            var cryptoParameters = new CryptoParameters(signer: signingKey, recipient: encryptionKey);
            return new DareEnvelope(cryptoParameters, plaintext, contentMeta, cloaked, dataSequences);

            }

        JSONBWriter JSONBWriter = null;

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
        #endregion

        /// <summary>
        /// The class specific disposal routine.
        /// </summary>
        protected virtual void Disposing() { }

        /// <summary>
        /// Return the number of data sequences.
        /// </summary>
        public int DataSequences => Header.EDSS.Count;

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
        public JSONReader GetBodyReader() => Body.JSONReader();


        /// <summary>
        /// Create a JSONReader for the decrypted body content according to the specified encoding.
        /// </summary>
        /// <returns></returns>
        public JSONReader GetBodyReader(Secret secret) => throw new NYI();


        /// <summary>
        /// Create a JSONReader for the decrypted body content according to the specified encoding.
        /// </summary>
        /// <returns></returns>
        public JSONReader GetBodyReader(KeyCollection keyCollection) => throw new NYI();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize(Writer writer, bool wrap, ref bool first) => SerializeX(writer, wrap, ref first);

        readonly static byte[] NullBytes = new byte[0];

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public new void SerializeX(Writer writer, bool wrap, ref bool first) {
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
            writer.WriteBinary(Body ?? NullBytes);
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
        public override void Deserialize(JSONReader jsonReader) {
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


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool ReadChunk(JSONReader jsonReader, out byte[] chunk) => jsonReader.ReadBinaryIncremental(out chunk);


        #region // Convenience routines 



        DareEnvelope(JSONBCDReader jsonReader, DareHeader header) {
            this.JSONReader = jsonReader;
            this.Header = header;
            }


        JSONBCDReader JSONReader { get; }

        /// <summary>
        /// Deserialize 
        /// </summary>
        /// <param name="data">The data to deserialize</param>
        /// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <param name="decrypt">If true, attempt to decrypt the message body as it is read.</param>
        /// <param name="keyCollection">Key collection to be used to discover decryption keys</param>
        /// <returns>The created object.</returns>	
        public static DareEnvelope FromJSON(byte[] data, bool tagged = true,
                bool decrypt = false, KeyCollection keyCollection = null) {
            var JSONBCDReader = new JSONBCDReader(data);
            return FromJSON(JSONBCDReader, tagged, decrypt, keyCollection);
            }

        /// <summary>
        /// Deserialize 
        /// </summary>
        /// <param name="stream">The input stream</param>
        /// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <param name="decrypt">If true, attempt to decrypt the message body as it is read.</param>
        /// <param name="keyCollection">Key collection to be used to discover decryption keys</param>
        /// <returns>The created object.</returns>	
        public static DareEnvelope FromJSON(Stream stream, bool tagged = true,
                bool decrypt = false, KeyCollection keyCollection = null) {
            var JSONBCDReader = new JSONBCDReader(stream);
            return FromJSON(JSONBCDReader, tagged, decrypt, keyCollection);
            }

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <param name="decrypt">If true, attempt to decrypt the message body as it is read.</param>
        /// <param name="keyCollection">Key collection to be used to discover decryption keys</param>
        /// <returns>The created object.</returns>		
        public static DareEnvelope FromJSON(JSONBCDReader jsonReader, bool tagged = true,
                bool decrypt = false, KeyCollection keyCollection = null) {
            Assert.False(tagged, NYI.Throw);


            // DecodeHeader checks for start of array
            //bool _Going = JSONReader.StartArray();

            var Message = DecodeHeader(jsonReader);

            using (var Buffer = new MemoryStream()) {
                var Decoder = Message.Header.GetDecoder(
                            jsonReader, out var Reader,
                            KeyCollection: keyCollection);
                Reader.CopyTo(Buffer);
                Decoder.Close();
                Message.Body = Buffer.ToArray();
                }
            return Message;
            }

        /// <summary>
        /// Read a DareEnvelope from a stream in incremental mode. The header of the 
        /// message is read but not the body.
        /// </summary>
        /// <param name="jsonReader">The stream from which data is to be read.</param>
        /// <returns>The DareEnvelope instance.</returns>
        public static DareEnvelope DecodeHeader(JSONBCDReader jsonReader) {
            Assert.True(jsonReader.StartArray());
            var Header = DareHeader.FromJSON(jsonReader, false);
            Assert.NotNull(Header);
            Assert.True(jsonReader.NextArray());
            return new DareEnvelope(jsonReader, Header);
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
            using (var output = outputFile.OpenFileNew()) {
                using (var input = inputFile.OpenFileRead()) {
                    Encode(cryptoParameters, input, output, input.Length,
                        contentMeta, cloaked, dataSequences, chunk);
                    return input.Length;
                    }
                }

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


            using (var DAREEnvelopeWriter = new DareEnvelopeWriter(cryptoParameters,
                outputStream, contentMeta, contentLength, cloaked, dataSequences)) {
                inputStream.CopyTo(DAREEnvelopeWriter);
                }

            }

        /// <summary>
        /// Decode a streamed message
        /// </summary>
        /// <param name="inputFile">The input file, must support reading.</param>
        /// <param name="outputFile">The output file, must support writing</param>
        /// <param name="keyCollection">The key collection to be used to resolve identifiers to keys.</param>
        public static long Decode(
                string inputFile,
                string outputFile=null,
                KeyCollection keyCollection = null) {

            using (var input = inputFile.OpenFileRead()) {
                return Decode(input, null, outputFile, keyCollection);
                }

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
                KeyCollection keyCollection = null) {
            long length = -1;
            keyCollection = keyCollection ?? KeyCollection.Default;

            var JSONBCDReader = new JSONBCDReader(inputStream);
            var Message = DecodeHeader(JSONBCDReader);

            var Decoder = Message.Header.GetDecoder(
                        JSONBCDReader, out var Reader,
                        KeyCollection: keyCollection);

            if (outputStream != null) {
                Reader.CopyTo(outputStream);
                outputStream.Flush();
                }
            else {
                var filename = outputFile ?? Message.Header.ContentMeta.Filename;
                using (var output = filename.OpenFileNew()) {
                    Reader.CopyTo(output);
                    output.Flush();
                    length = output.Length;
                    }
                }
            Decoder.Close();

            return length;
            }




        /// <summary>
        /// Decode a streamed message
        /// </summary>
        /// <param name="inputFile">File to be read as input</param>
        /// <param name="keyCollection">The key collection to be used to resolve identifiers to keys.</param>
        public static bool Verify(
                string inputFile,
                KeyCollection keyCollection = null) {
            using (var inputStream = inputFile.OpenFileRead()) {
                return Verify(inputStream, keyCollection);
                }
            }

        /// <summary>
        /// Decode a streamed message
        /// </summary>
        /// <param name="inputStream">The input stream, must support reading.</param>
        /// <param name="keyCollection">The key collection to be used to resolve identifiers to keys.</param>
        public static bool Verify(
                Stream inputStream,
                KeyCollection keyCollection = null) {

            keyCollection = keyCollection ?? KeyCollection.Default;

            using (var JSONBCDReader = new JSONBCDReader(inputStream)) {
                //var Message = DecodeHeader(JSONBCDReader);

                //var Decoder = Message.Header.GetDecoder(
                //            JSONBCDReader, out var Reader,
                //            KeyCollection: keyCollection);

                //Decoder.Close();
                }

            return true; // Hack: perform the actual check here and return a boolean.
            }


        #endregion


        }




    }
