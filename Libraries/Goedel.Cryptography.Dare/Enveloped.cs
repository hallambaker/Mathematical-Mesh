#region // Copyright - MIT License
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
public partial class Enveloped : IDisposable{
    #region // Properties and fields

    ///<summary>Convenience accessor to the list of signatures.</summary> 
    public List<DareSignature> Signatures => Trailer?.Signatures ?? Header?.Signatures;

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

    /// <summary>
    /// Get the body through lazy evaluation (if used)
    /// </summary>
    /// <returns></returns>
    public virtual byte[] GetBodyLazy() => Body;


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
    ~Enveloped() {
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
    public Enveloped() { }

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
    public Enveloped(
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
        Body = Header.EnhanceBody(plaintext, out var trailer);
        Trailer = trailer;
        }

    /// <summary>
    /// Constructor returining an envelope containing the object <paramref name="data"/>
    /// optionally encrypted under <paramref name="encryptionKey"/> and signed under
    /// <paramref name="signingKey"/>.
    /// </summary>
    /// <param name="data">The object to be enveloped.</param>
    /// <param name="signingKey">The signature key.</param>
    /// <param name="encryptionKey">The encryption key.</param>
    /// <param name="contentMeta">The value of the ContentMeta Header tag.</param>
    /// <param name="objectEncoding">The object encoding to use for the envelope payload.</param>
    public Enveloped(
                JsonObject data,
                CryptographicKey signingKey = null,
                CryptographicKey encryptionKey = null,
                ContentMeta contentMeta = null,
                DataEncoding objectEncoding = DataEncoding.JSON) : this(
                    new CryptoParameters(signer: signingKey, recipient: encryptionKey),
                    data.GetBytes(objectEncoding: objectEncoding), contentMeta: contentMeta) {
        data.Envelope = this;
        }



    /// <summary>
    /// Create a new DARE Message from the specified parameters.
    /// </summary>
    /// <param name="plaintext">The payload plaintext.</param>
    /// <param name="contentType">The content type.</param>
    /// <returns>The new envelope</returns>
    public static Enveloped Encode(
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
    public static Enveloped Encode(
        byte[] plaintext,
        ContentMeta contentMeta = null,
        CryptographicKey signingKey = null,
        CryptographicKey encryptionKey = null,
        byte[] cloaked = null,
        List<byte[]> dataSequences = null) {
        var cryptoParameters = new CryptoParameters(signer: signingKey, recipient: encryptionKey);
        return new Enveloped(cryptoParameters, plaintext, contentMeta, cloaked, dataSequences);
        }


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
    #region // Payload decoding routines 

    /// <summary>Parse the stream to return an object of type <typeparamref name="T"/></summary>
    /// <typeparam name="T">Type of the payload object to return.</typeparam>
    /// <param name="keyCollection">Key collection for decryption.</param>
    /// <returns>Result of the parse.</returns>
    public T StreamParseTag<T>(IKeyLocate keyCollection = null) where T : JsonObject {

        var plaintext = (keyCollection == null) ? Body : GetPlaintext(keyCollection);

        var result = StreamParseTag<T>(plaintext);
        result.Envelope = this;
        return result;
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


    #endregion

    #region // Serialization methods




    #endregion
    #region // Deserialization methods




    /// <summary>
    /// Read a DareEnvelope from a stream in incremental mode. The header of the 
    /// message is read but not the body.
    /// </summary>
    /// <param name="jsonReader">The stream from which data is to be read.</param>
    /// <returns>The DareEnvelope instance.</returns>
    public static Enveloped DecodeHeader(JsonBcdReader jsonReader) {
        Assert.AssertTrue(jsonReader.StartArray(), EnvelopeDataCorrupt.Throw);
        var header = StreamParse<DareHeader>(jsonReader, false);
        Assert.AssertNotNull(
            header,
            EnvelopeDataCorrupt.Throw);
        Assert.AssertTrue(jsonReader.NextArray(), EnvelopeDataCorrupt.Throw);
        return new Enveloped() {
            Header = header
            };
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



    #endregion

    #region // Transcription methods

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
                message.Trailer = StreamParse<DareTrailer>(jsonBcdReader, false);
                }

            var payloadDigest = message.Trailer?.PayloadDigest ??
                 message.Header.PayloadDigest;

            payloadDigest.AssertEqual(decoder.DigestValue, NYI.Throw);

            // here we check the digest value
            }


        // here flip the temporary files into the final

        return length;
        }



    #endregion

    #region // Signing methods

    #endregion

    #region // Signature verification methods

    /// <summary>
    /// Static method that reads the bytes <paramref name="input"/>, parses the
    /// content to return an envelope.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="keyCollection"></param>
    /// <returns></returns>
    public static Enveloped Verify(
            byte[] input,
            IKeyLocate keyCollection = null) =>
                Verify(new MemoryStream(input), keyCollection);

    /// <summary>
    /// Decode a streamed message
    /// </summary>
    /// <param name="inputFile">File to be read as input</param>
    /// <param name="keyCollection">The key collection to be used to resolve identifiers to keys.</param>
    public static Enveloped Verify(
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
    public static Enveloped Verify(
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


        // check the witness value here.

        if (jsonBcdReader.NextArray()) {
            message.Trailer = StreamParse<DareTrailer>(jsonBcdReader, false);

            message.Trailer.PayloadDigest.AssertEqual(message.PayloadDigestComputed,
                    EnvelopeDigestCorrupt.Throw);
            }
        return message;
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
        return key.VerifyDigest(digest, signature.SignatureValue);
        }

    /// <summary>
    /// Search the signatures over the envelope to verify the first
    /// signature matching the key <paramref name="keyPair"/> returning
    /// true if and only if the signature is valid.
    /// </summary>
    /// <param name="keyPair">The signing key to check.</param>
    /// <returns></returns>
    /// <exception cref="EnvelopeSignatureMissing">The specified
    /// signature could not be found.</exception>
    public bool VerifySignature(
                KeyPair keyPair) => VerifySignature(keyPair, FindSignature(keyPair));


    /// <summary>
    /// Verify the signature <paramref name="signature"/> against the keypair
    /// <paramref name="keyPair"/>.
    /// </summary>
    /// <param name="signature">The signature entry to check.</param>
    /// <param name="keyPair">The signing key to check.</param>
    /// <returns></returns>
    /// <exception cref="EnvelopeSignatureMissing">The specified
    /// signature could not be found.</exception>
    public bool VerifySignature(
                KeyPair keyPair,
                DareSignature signature) {
        signature.AssertNotNull(EnvelopeSignatureMissing.Throw);

        // Check the payload digest exists.
        var payloadDigest = Trailer.PayloadDigest ?? Header.PayloadDigest;
        if (payloadDigest == null) {
            return false;
            }

        // Verify specified digest against the computed
        var payloadComputed = GetValidatedDigest();
        if (payloadComputed == null) {
            return false;
            }
        var digestId = Header.DigestAlgorithm.ToCryptoAlgorithmID();
        var manifest = CryptoStack.GetEnvelopeSignatureManifest(digestId, Trailer);

        var result = signature.Verify(keyPair, manifest);
        return result;
        }


    /// <summary>
    /// Find a signature whose key identifier matches <paramref name="key"/>
    /// </summary>
    /// <param name="key">The key</param>
    /// <returns>The signature entry.</returns>
    public DareSignature FindSignature(CryptographicKey key) {

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

    /// <summary>Gt the signature under the key <paramref name="keyId"/></summary>
    /// <param name="keyId">Key identifier.</param>
    /// <returns>The signature.</returns>
    public DareSignature? GetSignature(string keyId) {
        var signatures = Trailer.Signatures;
        if (signatures is null) {
            return null;
            }

        foreach (var signature in signatures) {
            if (signature.KeyIdentifier == keyId) {
                return signature;
                }
            }

        return null;
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

        if (Body is null) {
            return PayloadDigestComputed;
            }
        else {

            var provider = digestAlg.CreateDigest();
            var result = provider.ComputeHash(Body);

            if (PayloadDigest != null) {
                if (!PayloadDigest.IsEqualTo(result)) {
                    return null;
                    }
                }

            return result;
            }
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

    #endregion

    }
