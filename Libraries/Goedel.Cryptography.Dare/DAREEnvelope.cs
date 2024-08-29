﻿#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
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
#endregion
using System.Runtime.CompilerServices;

namespace Goedel.Cryptography.Dare;

/// <summary>
/// DARE Message class.
/// </summary>
public partial class DareEnvelope : DareEnvelopeSequence, IDisposable {
    #region // Properties and fields

    byte[] bodyValue;

    ///<inheritdoc/>
    public override byte[] Body {
        get => GetBodyLazy();
        set => bodyValue = value;
        }

    /// <summary>
    /// Get the body through lazy evaluation
    /// </summary>
    /// <returns></returns>
    public virtual byte[] GetBodyLazy() => bodyValue;


    /// <summary>
    /// Dictionary mapping tags to factory methods
    /// </summary>
    static Dictionary<string, JsonFactoryDelegate> ThisTagDictionary =
        new()
            {
                { "DareEnvelope", Factory }
            };

    /// <summary>
    /// The module initializer. This is called during initialization of the module.
    /// </summary>
#pragma warning disable CA2255 // The 'ModuleInitializer' attribute should not be used in libraries
    [ModuleInitializer]
#pragma warning restore CA2255 // The 'ModuleInitializer' attribute should not be used in libraries
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
    public virtual JsonObject JsonObject { get; set; }

    ///<summary>Convenience accessor for the frame index.</summary>
    public long Index => Header.Index;

    ///<summary>Convenience accessor for the envelope id.</summary>
    public string EnvelopeId => Header.EnvelopeId;

    ///<summary>The declared payload digest value</summary> 
    public byte[] PayloadDigest => Header?.PayloadDigest ?? Trailer?.PayloadDigest;


    ///<summary>The payload digest value calculated during decoding.</summary> 
    public byte[] PayloadDigestComputed;

    ///<summary>The payload MAC value calculated during decoding.</summary> 
    public byte[] PayloadMac;

    ///<summary>The length of the payload value</summary> 
    public long PayloadLength;




    /// <summary>
    /// Force loading of the payload body.
    /// </summary>
    public virtual void LoadBody() { }

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
            ContentMeta = contentMeta
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
    /// Return the plaintext of a data Sequence.
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

    /////<inheritdoc/>
    //public override void Setter(
    //        string tag, TokenValue value) {
    //    switch (tag) {
    //        case "Header": {
    //            if (value is TokenValueStruct<DareHeader> vvalue) {
    //                Header = vvalue.Value;
    //                }
    //            break;
    //            }
    //        case "Body": {
    //            if (value is TokenValueBinary vvalue) {
    //                Body = vvalue.Value;
    //                }
    //            break;
    //            }
    //        case "Trailer": {
    //            if (value is TokenValueStruct<DareTrailer> vvalue) {
    //                Trailer = vvalue.Value;
    //                }
    //            break;
    //            }


    //        default: {
    //            base.Setter(tag, value);
    //            break;
    //            }
    //        }
    //    }

    /////<inheritdoc/>
    //public override TokenValue Getter(
    //        string tag) {
    //    switch (tag) {
    //        case "Header": {
    //            return new TokenValueStruct<DareHeader>(Header);
    //            }
    //        case "Body": {
    //            return new TokenValueBinary(Body);
    //            }
    //        case "Trailer": {
    //            return new TokenValueStruct<DareTrailer>(Trailer);
    //            }
    //        default: {
    //            return base.Getter(tag);
    //            }
    //        }
    //    }

    ///<inheritdoc/>
    public override void Serialize(Writer writer,
                bool tagged = false) {
        var first = false;
        if (tagged) {
            writer.WriteObjectStart();
            writer.WriteToken(_Tag, 0);
            }

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
        if (tagged) {
            writer.WriteObjectEnd();
            }
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
    /// <param name="digest">The payload digest value if known.</param>
    /// <returns>True, if the signature is valid.</returns>
    public bool Verify(KeyPair key, byte[] digest = null) {

        var signature = FindSignature(key);
        if (signature == null) {
            return false;
            }
        digest ??= GetValidatedDigest();
        return key.VerifyHash(digest, signature.SignatureValue);
        }




    /// <summary>
    /// Compute the digest of the payload and if a digest value is specified in the header
    /// or trailer, verify that it matches.
    /// </summary>
    /// <returns>If a payload digest field is specified in the trailer that does not
    /// match the digest of the payload, returns the payload. Otherwise returns the
    /// digest of the payload.</returns>
    public byte[] GetValidatedDigest() {

        "Change from returning byte[] to byte[] plus algorithm".TaskTest();

        var digestAlg = (Header.DigestAlgorithm ?? "S512").FromJoseIDDigest();
        var provider = digestAlg.CreateDigest();
        var result = provider.ComputeHash(Body);

        if (PayloadDigest != null) {
            if (!PayloadDigest.IsEqualTo(result)) {
                return null;
                }
            }

        return result;
        }

    /// <summary>
    /// Compute the digest of the payload and if a digest value is specified in the header
    /// or trailer, verify that it matches.
    /// </summary>
    /// <returns>If a payload digest field is specified in the trailer that does not
    /// match the digest of the payload, returns the payload. Otherwise returns the
    /// digest of the payload.</returns>
    public byte[] GetUnvalidatedDigest() {
        if (PayloadDigest != null) {
            return PayloadDigest;
            }

        var digestAlg = (Header.DigestAlgorithm ?? "S512").FromJoseIDDigest();
        var provider = digestAlg.CreateDigest();
        var result = provider.ComputeHash(Body);

        return result;
        }




    /// <summary>
    /// Find a signature whose key identifier matches <paramref name="key"/>
    /// </summary>
    /// <param name="key">The key</param>
    /// <returns>The signature entry.</returns>
    public DareSignature FindSignature(CryptoKey key) {

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



    ///// <summary>
    ///// Deserialize 
    ///// </summary>
    ///// <param name="stream">The input stream</param>
    ///// <param name="decrypt">If true, attempt to decrypt the message body as it is read.</param>
    ///// <param name="keyCollection">Key collection to be used to discover decryption keys</param>
    ///// <returns>The created object.</returns>	
    //public static DareEnvelope FromJSON(Stream stream,
    //    bool decrypt = false,
    //    IKeyLocate keyCollection = null) {
    //    var jsonBcdReader = new JsonBcdReader(stream); // Hack: should merge this with GetPlaintext
    //    return FromJSON(jsonBcdReader, false, decrypt, keyCollection);
    //    }

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
                keyCollection: keyCollection,
                decrypt: decrypt,
                verify: verify);
            reader.CopyTo(buffer);
            decoder.Close();
            message.PayloadDigestComputed = decoder.DigestValue;
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
    /// <param name="cover">Optional Sequence of plaintext bytes specifying a cover page
    /// to be presented in place of an encrypted document if it cannot be decrypted.</param>
    /// <returns>The number of bytes in the input file.</returns>
    public static long Encode(
        CryptoParameters cryptoParameters,
        string inputFile,
        string outputFile = null,
        ContentMeta contentMeta = null,
        byte[] cloaked = null,
        List<byte[]> dataSequences = null,
        int chunk = -1,
        byte[] cover = null) {
        using var output = outputFile.OpenFileNew();
        using var input = inputFile.OpenFileRead();
        Encode(
            cryptoParameters, input, output, input.Length,
            contentMeta, cloaked, dataSequences, chunk, cover);
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
    /// <param name="cover">Optional Sequence of plaintext bytes specifying a cover page
    /// to be presented in place of an encrypted document if it cannot be decrypted.</param>
    /// <returns>The serialized encoding of the data.</returns>
    public static byte[] Encode(
        CryptoParameters cryptoParameters,
        byte[] inputData,
        ContentMeta contentMeta = null,
        byte[] cloaked = null,
        List<byte[]> dataSequences = null,
        int chunk = -1,
        byte[] cover = null) {
        using var outputStream = new MemoryStream();
        using var inputStream = new MemoryStream(inputData);
        Encode(
            cryptoParameters, inputStream, outputStream, inputStream.Length,
            contentMeta, cloaked, dataSequences, chunk, cover);
        return outputStream.ToArray();
        }


    /// <summary>
    /// Encode data received on the input stream to the output stream with the specified
    /// security enhancements. If the input stream supports the seek operation, and
    /// the maximum chunk size is less than 1, the output file will be written as a 
    /// single Sequence. Otherwise, the file will be written with a chunk size no
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
    /// <param name="cover">Optional Sequence of plaintext bytes specifying a cover page
    /// to be presented in place of an encrypted document if it cannot be decrypted.</param>
    public static void Encode(
        CryptoParameters cryptoParameters,
        Stream inputStream,
        Stream outputStream,
        long contentLength = -1,
        ContentMeta contentMeta = null,
        byte[] cloaked = null,
        List<byte[]> dataSequences = null,
        int chunk = -1,
        byte[] cover = null) {
        using var dareEnvelopeWriter = new DareEnvelopeWriter(
            cryptoParameters,
            outputStream, contentMeta, contentLength, cloaked, dataSequences, cover);
        inputStream.CopyTo(dareEnvelopeWriter);
        }

    /// <summary>
    /// Decode a tagged JSONObject using keys from <paramref name="keyCollection"/> to decrypt
    /// if necessary.
    /// </summary>
    /// <param name="keyCollection">Key collection to be used for decryption.</param>
    /// <returns>The decoded object.</returns>
    public JsonObject DecodeJsonObject(IKeyLocate keyCollection = null) {
        var plaintext = GetPlaintext(keyCollection);
        if (plaintext == null | plaintext?.Length == 0) {
            return null;
            }
        //Console.WriteLine(plaintext.ToUTF8());

        var reader = new JsonBcdReader(plaintext);


        var result = reader.ReadTaggedObject(TagDictionary);
        if (result != null) {
            result.Enveloped = this;
            }
        return result;
        }


    /// <summary>
    /// Decode a streamed message
    /// </summary>
    /// <param name="inputFile">The input file, must support reading.</param>
    /// <param name="outputFile">The output file, must support writing</param>
    /// <param name="keyCollection">The key collection to be used to resolve identifiers to keys.</param>
    /// <param name="verify">If true, verify the payload digest on the payload. The decoded data is 
    /// written out to a temporary file which is deleted if the verification fails and renamed
    /// to the output file otherwise.</param>
    public static long Decode(
            string inputFile,
            string outputFile = null,
            IKeyLocate keyCollection = null,
            bool verify = false) {
        using var input = inputFile.OpenFileRead();

        var tempFile = verify ? outputFile + ".tmp" : outputFile;

        var length = Decode(input, null, tempFile, keyCollection, verify);

        if (verify) {
            File.Move(tempFile, outputFile, true);
            }


        return length;
        }

    /// <summary>
    /// Decode a streamed message
    /// </summary>
    /// <param name="inputStream">The input stream, must support reading.</param>
    /// <param name="outputStream">The output stream, must support writing</param>
    /// <param name="outputFile">The output file, must support writing</param>
    /// <param name="keyCollection">The key collection to be used to resolve identifiers to keys.</param>
    /// <param name="verify">If true, verify the payload digest on the payload. The decoded data is 
    /// written out to a temporary file which is deleted if the verification fails and renamed
    /// to the output file otherwise.</param>
    public static long Decode(
            Stream inputStream,
            Stream outputStream,
            string outputFile = null,
            IKeyLocate keyCollection = null,
            bool verify = false) {
        long length = -1;
        keyCollection ??= Cryptography.KeyCollection.Default;

        var jsonBcdReader = new JsonBcdReader(inputStream);
        using var message = DecodeHeader(jsonBcdReader);
        var decoder = message.Header.GetDecoder(
            jsonBcdReader, out var Reader,
            keyCollection: keyCollection,
            verify: verify);

        if (outputStream != null) {
            Reader.CopyTo(outputStream);
            outputStream.Flush();
            }
        else {
            var filename = outputFile ?? message.Header?.ContentMeta.Filename;
            using var output = filename.OpenFileNew();
            Reader.CopyTo(output);
            output.Flush();
            length = output.Length;
            }
        decoder.Close();

        if (verify) {
            // read in the trailer
            if (jsonBcdReader.NextArray()) {
                message.Trailer = DareTrailer.FromJson(jsonBcdReader, false);
                }

            var payloadDigest = message.Trailer?.PayloadDigest ??
                 message.Header.PayloadDigest;

            payloadDigest.AssertEqual(decoder.DigestValue, NYI.Throw);

            // here we check the digest value
            }


        // here flip the temporary files into the final

        return length;
        }

    /// <summary>
    /// Decode a streamed message
    /// </summary>
    /// <param name="inputStream">The input stream, must support reading.</param>
    /// <param name="outputStream">The output stream, must support writing</param>
    /// <param name="keyCollection">The key collection to be used to resolve identifiers to keys.</param>
    /// <param name="dareHeader">The header data.</param>
    /// <param name="verify">If true, verify the payload digest on the payload. The decoded data is 
    /// written out to a temporary file which is deleted if the verification fails and renamed
    /// to the output file otherwise.</param>

    public static bool TryDecode(
        Stream inputStream,
        Stream outputStream,
        IKeyLocate keyCollection,
        out DareHeader dareHeader,
        bool verify = false
        ) {
        keyCollection ??= Cryptography.KeyCollection.Default;

        var jsonBcdReader = new JsonBcdReader(inputStream);
        using var message = DecodeHeader(jsonBcdReader);
        dareHeader = message.Header;

        try {
            var decoder = message.Header.GetDecoder(
                jsonBcdReader, out var Reader,
                keyCollection: keyCollection,
                verify: verify);

            Reader.CopyTo(outputStream);
            outputStream.Flush();

            decoder.Close();

            return true;
            }
        catch {
            return false;
            }
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
            keyCollection: keyCollection, decrypt: false, verify: true);

        Reader.CopyTo(Stream.Null);
        decoder.Close();
        message.PayloadDigestComputed = decoder.DigestValue;
        message.PayloadMac = decoder.MacValue;
        message.PayloadLength = decoder.BytesRead;

        if (jsonBcdReader.NextArray()) {
            message.Trailer = DareTrailer.FromJson(jsonBcdReader, false);
            }


        return message;

        }
    #endregion


    }
