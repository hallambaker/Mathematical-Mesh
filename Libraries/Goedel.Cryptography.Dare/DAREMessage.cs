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

    /// <summary>
    /// DARE Message class.
    /// </summary>
    public partial class DAREMessage : DAREMessageSequence, IDisposable {


        /// <summary>
        /// Tag identifying this class
        /// </summary>
        public override string _Tag { get; } = "DAREMessage";

        /// <summary>
        /// Create an empty DARE Message (for use by deserializers)
        /// </summary>
        public DAREMessage() {
            }

        /// <summary>
        /// Create a DARE Message instance.
        /// </summary>
        /// <param name="CryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <param name="ContentType">The payload content type.</param>
        /// <param name="Plaintext">The payload plaintext. If specified, the plaintext will be used to
        /// create the message body. Otherwise the body is specified by calls to the Process method.</param>
        /// <param name="Cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
        /// <param name="DataSequences">Data sequences to be converted to an EDS and presented 
        ///     as an EDSS header entry.</param>
        public DAREMessage(
                    CryptoParameters CryptoParameters,
                    byte[] Plaintext,
                    string ContentType = null,
                    byte[] Cloaked = null,
                    List<byte[]> DataSequences = null
                    ) {

            var CryptoStack = CryptoParameters.GetCryptoStack();

            Header = new DAREHeader(CryptoStack, ContentType, Cloaked, DataSequences);
            Body = Header.EnhanceBody(Plaintext, out var Trailer);
            this.Trailer = Trailer;

            
            }


        /// <summary>
        /// Create a DARE Message instance.
        /// </summary>
        /// <param name="CryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <param name="OutputStream">The stream to which the output will be written.</param>
        /// <param name="ContentType">The payload content type.</param>
        /// <param name="ContentLength">The content length. This value is ignored if the Plaintext
        /// parameter is not null. If the value is less than 0, chunked encoding
        /// will be used for the payload data. </param>
        /// <param name="Plaintext">The payload plaintext. If specified, the plaintext will be used to
        /// create the message body. Otherwise the body is specified by calls to the Process method.</param>
        /// <param name="Cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
        /// <param name="DataSequences">Data sequences to be converted to an EDS and presented 
        ///     as an EDSS header entry.</param>
        public DAREMessage(
                    CryptoParameters CryptoParameters,
                    Stream OutputStream,
                    string ContentType = null,
                    byte[] Plaintext = null,
                    long ContentLength = -1,
                    byte[] Cloaked = null,
                    List<byte[]> DataSequences = null
                    ) {

            var CryptoStack = CryptoParameters.GetCryptoStack();

            Header = new DAREHeader(CryptoStack, ContentType, Cloaked, DataSequences);
            JSONBWriter = new JSONBWriter(OutputStream);

            //InitializeStream(JSONBWriter, Plaintext, ContentLength);
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
        ~DAREMessage() {
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize(Writer Writer, bool wrap, ref bool first) => SerializeX(Writer, wrap, ref first);

        readonly static byte[] NullBytes = new byte[0];

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX(Writer _Writer, bool _wrap, ref bool _first) {
            _first = false;
            _Writer.WriteArrayStart();
            if (Header != null) {
                Header.Serialize(_Writer, false);
                }
            else {
                _Writer.WriteObjectStart();
                _Writer.WriteObjectEnd();
                }
            _Writer.WriteArraySeparator(ref _first);
            _Writer.WriteBinary(Body ?? NullBytes);
            if (Trailer != null) {
                _Writer.WriteArraySeparator(ref _first);
                Trailer.Serialize(_Writer, false);
                }
            _Writer.WriteArrayEnd();
            }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool ReadChunk(JSONReader JSONReader, out byte[] Chunk) => JSONReader.ReadBinaryIncremental(out Chunk);


        #region // Convenience routines 

        /// <summary>
        /// Encode data received on the input stream to the output stream with the specified
        /// security enhancements. If the input stream supports the seek operation, and
        /// the maximum chunk size is less than 1, the output file will be written as a 
        /// single sequence. Otherwise, the file will be written with a chunk size no
        /// greater than the maximum specified.
        /// </summary>
        /// <param name="InputStream">The input stream, must support reading.</param>
        /// <param name="OutputStream">The output stream, must support writing</param>
        /// <param name="CryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <param name="ContentType">The payload content type.</param>
        /// <param name="Cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
        /// <param name="DataSequences">Data sequences to be converted to an EDS and presented 
        ///     as an EDSS header entry.</param>
        /// <param name="Chunk">The maximum chunk size. If unspecified, the default
        /// system chunk size (2048) is used.</param>
        /// <param name="ContentLength">The content length. This value is ignored if the Plaintext
        /// parameter is not null. If the value is less than 0, chunked encoding
        /// will be used for the payload data. </param>         
        public static void Encode(
                CryptoParameters CryptoParameters,
                Stream InputStream,
                Stream OutputStream,
                long ContentLength = -1,
                string ContentType = null,
                byte[] Cloaked = null,
                List<byte[]> DataSequences = null,
                int Chunk=-1) {


            using (var DAREMessageWriter = new DAREMessageWriter(CryptoParameters,
                OutputStream, ContentType, ContentLength, Cloaked, DataSequences)) {
                InputStream.CopyTo(DAREMessageWriter);
                }

            }

        DAREMessage(JSONBCDReader JSONReader, DAREHeader Header) {
            this.JSONReader = JSONReader;
            this.Header = Header;
            }


        JSONBCDReader JSONReader { get; }

        /// <summary>
        /// Deserialize 
        /// </summary>
        /// <param name="Data">The data to deserialize</param>
        /// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <param name="Decrypt">If true, attempt to decrypt the message body as it is read.</param>
        /// <param name="KeyCollection">Key collection to be used to discover decryption keys</param>
        /// <returns>The created object.</returns>	
        public static DAREMessage FromJSON(byte[] Data, bool Tagged = true, 
                bool Decrypt = false, KeyCollection KeyCollection = null) {
            var JSONBCDReader = new JSONBCDReader(Data);
            return FromJSON(JSONBCDReader, Tagged, Decrypt, KeyCollection);
            }

        /// <summary>
        /// Deserialize 
        /// </summary>
        /// <param name="Stream">The input stream</param>
        /// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <param name="Decrypt">If true, attempt to decrypt the message body as it is read.</param>
        /// <param name="KeyCollection">Key collection to be used to discover decryption keys</param>
        /// <returns>The created object.</returns>	
        public static DAREMessage FromJSON(Stream Stream, bool Tagged = true, 
                bool Decrypt = false, KeyCollection KeyCollection = null) {
            var JSONBCDReader = new JSONBCDReader(Stream);
            return FromJSON(JSONBCDReader, Tagged, Decrypt, KeyCollection);
            }

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <param name="Decrypt">If true, attempt to decrypt the message body as it is read.</param>
        /// <param name="KeyCollection">Key collection to be used to discover decryption keys</param>
        /// <returns>The created object.</returns>		
        public static DAREMessage FromJSON(JSONBCDReader JSONReader, bool Tagged = true, 
                bool Decrypt=false, KeyCollection KeyCollection=null) {
            Assert.False(Tagged, NYI.Throw);


            // DecodeHeader checks for start of array
            //bool _Going = JSONReader.StartArray();

            var Message = DecodeHeader(JSONReader);

            using (var Buffer = new MemoryStream()) {
                var Decoder = Message.Header.GetDecoder(
                            JSONReader, out var Reader,
                            KeyCollection: KeyCollection);
                Reader.CopyTo(Buffer);
                Decoder.Close();
                Message.Body = Buffer.ToArray();
                }
            return Message;
            }

        /// <summary>
        /// Read a DAREMessage from a stream in incremental mode. The header of the 
        /// message is read but not the body.
        /// </summary>
        /// <param name="JSONReader">The stream from which data is to be read.</param>
        /// <returns>The DAREMessage instance.</returns>
        public static DAREMessage DecodeHeader (JSONBCDReader JSONReader) {
            Assert.True(JSONReader.StartArray());
            var Header = DAREHeader.FromJSON(JSONReader, false);
            Assert.NotNull(Header);
            Assert.True(JSONReader.NextArray());
            return new DAREMessage(JSONReader, Header);
            }

        /// <summary>
        /// Decode a streamed message
        /// </summary>
        /// <param name="InputStream">The input stream, must support reading.</param>
        /// <param name="OutputStream">The output stream, must support writing</param>
        /// <param name="KeyCollection">The key collection to be used to resolve identifiers to keys.</param>
        public static void Decode(
                Stream InputStream,
                Stream OutputStream,
                KeyCollection KeyCollection = null) {

            KeyCollection = KeyCollection ?? KeyCollection.Default;

            var JSONBCDReader = new JSONBCDReader(InputStream);
            var Message = DecodeHeader(JSONBCDReader);

            var Decoder = Message.Header.GetDecoder(
                        JSONBCDReader, out var Reader,
                        KeyCollection: KeyCollection);
            Reader.CopyTo(OutputStream);
            Decoder.Close();
            }


        #endregion


        }




    }
