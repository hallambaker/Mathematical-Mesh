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
using System.IO;
using System.Threading.Channels;

using Goedel.ASN;
using Goedel.Cryptography.Nist;
using Goedel.Protocol;

namespace Goedel.Cryptography.Dare;



/// <summary>
/// Envelope Reader
/// </summary>
public partial class VDareEnvelopeReader : Disposable {

    /// <summary>The underlying stream.</summary>
    protected VDareStream Stream { get; }

    ///<summary>The envelope version (0 or 1).</summary> 
    public ulong Version { get; private set; }


    byte[] UnprotectedBytes;
    ///<summary>The parsed unprotected header.</summary> 
    public Unprotected? UnsignedHeader { get; private set; } = null;


    byte[] ProtectedBytes;
    ///<summary>The parsed content metadata header.</summary> 
    public ContentMeta? SignedHeader { get; private set; } = null;

    ///<summary>The parsed trailer.</summary> 
    public Unprotected? Trailer { get; private set; } = null;

    HashAlgorithm? Digest = null;
    CryptoAlgorithmId DigestId;
    byte[]? MetadataDigest = null;




    //protected bool Digest { get; set; } = false;
    protected bool Encrypt { get; set; } = false;
    CryptoAlgorithmId EncryptId;

    IChunk? Unwrapper = null;

    /// <inheritdoc/>
    protected override void Disposing() {
        Stream?.Dispose();
        base.Disposing();
        }



    /// <summary>
    /// Constructor returning an instance reading from <paramref name="stream"/>.
    /// Only the initial version number is read from the stream.
    /// </summary>
    /// <param name="stream">The stream to read from.</param>
    VDareEnvelopeReader(
                VDareStream stream, 
                CryptoParameters cryptoParameters=null) {
        Stream = stream;
        //Version = Stream.ReadTypeIdentifier();

        //(Version == DareConstants.TypeIdentifierDareEnvelopeL).AssertTrue(NYI.Throw);
        UnprotectedBytes = ReadBlock();
        // read the unsigned header
        UnsignedHeader = JsonObject.StreamParseTag<Unprotected>(UnprotectedBytes, false);


        ProtectedBytes = ReadBlock();
        // read the signed header
        SignedHeader = JsonObject.StreamParseTag<ContentMeta>(ProtectedBytes, false);





        // Are we calculating the digest?
        if (UnsignedHeader.DigestAlgorithm is not null) {
            DigestId = UnsignedHeader.DigestAlgorithm.ToCryptoAlgorithmID();
            Digest = DigestId.CreateDigest();
            MetadataDigest = Digest.ComputeHash(ProtectedBytes);
            }

        // Set up the decryption stack
        Encrypt = UnsignedHeader.EncryptionAlgorithm != null;
        if (Encrypt) {

            EncryptId = UnsignedHeader.EncryptionAlgorithm.ToCryptoAlgorithmID();


            var key = cryptoParameters.KeyLocate.Decrypt(UnsignedHeader.Recipients, EncryptId);

            int chunk = UnsignedHeader.Chunk ?? 4096;

            Console.WriteLine($"Key {key.ToStringBase16FormatHex()}");
            Console.WriteLine($"Salt {UnsignedHeader.Salt.ToStringBase16FormatHex()}");

            Unwrapper = new GcmUnwrapperChunked(key, UnsignedHeader.Salt, EncryptId, chunk);


            }

        }

    /// <summary>
    /// Constructor returning an instance reading from <paramref name="bytes"/>.
    /// Only the initial version number is read from the stream.
    /// </summary>
    /// <param name="bytes">The data to read.</param>
    public VDareEnvelopeReader(byte[] bytes) : this(new VDareStream(bytes)) {
        }




    public int ReadBlocks(
                Stream streamOut) {

        var result = 0;

        var length = ReadBlock(streamOut);
        while (length > 0) {
            result += length;
            length = ReadBlock(streamOut);
            }


        return result;
        }


    public int ReadBlock (
                Stream streamOut) {

        var lengthBlock = (int) Stream.ReadVarint();

        if (lengthBlock == 0) {
            return lengthBlock; // Nothing to do
            }

        return Encrypt ? ReadBlockEncrypted(streamOut, lengthBlock) : ReadBlockPlaintext(streamOut, lengthBlock);
        }



    int ReadBlockPlaintext(
                Stream streamOut, int lengthBlock) {
        int chunk = 4096;
        var chunkedLength = lengthBlock - chunk;
        var buffer = new byte[chunk];

        // main chunks
        int i;
        for (i = 0; i < chunkedLength; i += chunk) {
            Stream.ReadExactly(buffer, i, chunk);
            streamOut.Write(buffer);
            }

        // last chunk
        Stream.ReadExactly(buffer, 0, lengthBlock-i);
        streamOut.Write(buffer, 0, lengthBlock - i);

        return lengthBlock;
        }

    int ReadBlockEncrypted(
                Stream streamOut, int lengthBlock) {
        int chunk = Unwrapper.InputChunk;

        var chunkedLength = (int)lengthBlock - chunk;
        var ciphertext = new byte[chunk];
        
        var plaintext = new byte[Unwrapper.OutputChunk];

        var outLength = 0;
        // main chunks
        int i;
        for (i = 0; i < chunkedLength; i += chunk) {
            Stream.ReadExactly(ciphertext, i, chunk);
            Unwrapper.Chunk(ciphertext, plaintext);
            streamOut.Write(plaintext);
            outLength += plaintext.Length;
            }

        // last chunk
        var ciphertextSpan = new ReadOnlySpan<byte>(ciphertext, 0, lengthBlock - i);
        var plaintextSpan = new Span<byte>(plaintext, 0, lengthBlock - i + 
                Unwrapper.OutputChunk - Unwrapper.InputChunk);

        Stream.ReadExactly(ciphertext, 0, lengthBlock - i);
        Unwrapper.Finalize(ciphertextSpan, plaintextSpan);
        streamOut.Write(plaintextSpan);
        outLength += plaintextSpan.Length;

        return outLength;
        }

    public static EarlEnvelope Read(
                VDareStream streamIn,
                CryptoParameters cryptoParameters = null) {


        var reader = new VDareEnvelopeReader(streamIn, cryptoParameters);
        var streamOut = new MemoryStream();

        reader.ReadBlocks(streamOut);
        var trailer = reader.ReadJson<Unprotected>();

        var result = new EarlEnvelope(reader.UnsignedHeader, reader.SignedHeader, trailer,
            streamOut.ToArray());

        return result;
        }




    /// <summary>Read a single envelope from the file <paramref name="fileName"/></summary>
    /// <param name="fileName">The file to read.</param>
    /// <returns>The envelope read.</returns>
    public static EarlEnvelope Read(
                string fileName,
                CryptoParameters cryptoParameters = null) {
        using var stream = VDareStream.Open(fileName, DareConstants.TypeIdentifierDareEnvelope);

        return Read(stream, cryptoParameters);
        }





    ///// <summary>Complete reading the entry, and return the complete envelope.</summary>
    ///// <returns></returns>
    //public EarlEnvelope Close () {
    //    Trailer = ReadJson<Unprotected>();

    //    // read the trailer
    //    return new EarlEnvelope(UnsignedHeader, SignedHeader, Trailer);

    //    }


    /// <summary>Read an object of type <typeparamref name="T"/> from the stream.</summary>
    /// <typeparam name="T">The type of the object to read.</typeparam>
    /// <returns>The object read.</returns>
    public T ReadJson<T>() where T : JsonObject => Stream.ReadJson<T>();

    /// <summary>Read a complete block of data from the stream</summary>
    /// <returns></returns>
    public virtual byte[] ReadBlock() => Stream.ReadBlock();









    /// <summary>Returns the enveloped data.</summary>
    /// <param name="bytes">The envelope to read.</param>
    /// <param name="keyCollection">Keys to be used to decrypt the contents.</param>
    /// <returns></returns>
    public static Enveloped GetEnveloped(byte[] bytes,
            KeyCollection? keyCollection = null) {
        var reader = new VDareEnvelopeReader(bytes);
        return reader.GetEnveloped();
        }

    /// <summary>Return an envelope from the reader.</summary>
    /// <returns></returns>
    public Enveloped GetEnveloped() {


        var contentMetaBytes = ReadBlock();
        var buffer = new MemoryStream();
        while (CopyPayload(buffer)) {
            }

        var enveloped = new Enveloped() {
            Header = new DareHeader() {
                // Hack, should actually populate ContentMetaBytes here
                ContentMeta = JsonObject.StreamParseTag<ContentMeta>(contentMetaBytes, false),
                ContentMetaData = contentMetaBytes
                },
            Body = buffer.ToArray()
            };

        if (Version == 1) {
            var trailer = ReadBlock();
            // Hack: We are chopping off the signatures here because DARE signatures currently
            // use a different format.
            
            // enveloped.Trailer = JsonObject.StreamParseTag<Unprotected>(trailer, false);
            }




        return enveloped;
        }

    /// <summary>
    /// Parse the data contained in <paramref name="bytes"/> using the key collection
    /// <paramref name="keyCollection"/> to verify signatures.
    /// </summary>
    /// <param name="bytes">The bytes to read.</param>
    /// <param name="keyCollection">Key collection to verify signatures.</param>
    /// <returns>The parsed content metadata and the payload plaintext.</returns>
    public static (ContentMeta, byte[]) Parse(byte[] bytes,
            KeyCollection? keyCollection=null) {

        var reader = new VDareEnvelopeReader(bytes);
        reader.ReadMetadata();

        var buffer = new MemoryStream();
        while (reader.CopyPayload(buffer)) {
            }

        reader.Verify(keyCollection).AssertTrue(NYI.Throw);

        return (reader.SignedHeader, buffer.ToArray());
        }

    /// <summary>
    /// ReadMetadata from the stream.
    /// </summary>  
    /// <returns></returns>
    public ContentMeta ReadMetadata() {
        if (Version == 1) {
            var unprotectedHeader = ReadBlock();
            if (unprotectedHeader.Length > 0) {
                UnsignedHeader = JsonObject.StreamParseTag<Unprotected>(unprotectedHeader, false);
                if (UnsignedHeader.DigestAlgorithm is not null) {
                    DigestId = UnsignedHeader.DigestAlgorithm.ToCryptoAlgorithmID();
                    Digest = DigestId.CreateDigest();
                    }
                }
            }
        var contentMeta = ReadBlock();
        if (contentMeta.Length > 0) {
            SignedHeader = JsonObject.StreamParseTag<ContentMeta>(contentMeta, false);
            }
        if (Digest is not null) {
            var metaDigest = DigestId.CreateDigest();
            MetadataDigest = metaDigest.ComputeHash(contentMeta);
            }
        return SignedHeader;
        }

    /// <summary>
    /// Copy payload bytes to <paramref name="output"/>. 
    /// </summary>
    /// <param name="output">Destination for the payload bytes.</param>
    /// <returns>True if there is more payload to be read</returns>
    public bool CopyPayload(Stream output) {
        var length = Stream.ReadVarint();
        if (length == 0) {
            return false;
            }

        if (Digest is null) {
            Stream.CopyTo(output, length);
            }
        else {
            Stream.HashCopyTo(output, length, Digest);
            }

        return Version == 1;
        }

    /// <summary>
    /// Verify the header/trailer signatures against the keys in <paramref name="keyCollection"/>.
    /// </summary>
    /// <param name="keyCollection">Key collection to verify signatures.</param>
    /// <returns></returns>
    public bool Verify(
            KeyCollection? keyCollection = null) {
        if (Version == 0) {
            return true;
            }

        var trailer = ReadBlock();
        if (trailer.Length > 0) {
            Trailer = JsonObject.StreamParseTag<Unprotected>(trailer, false);
            }

        var signatures = UnsignedHeader?.Signatures ?? Trailer?.Signatures;
        if (signatures is null & UnsignedHeader?.Signers is null) {
            return true; // There are no signatures to verify.
            }

        // Check that there is exactly one Signatures property.
        (Trailer?.Signatures is null | UnsignedHeader?.Signatures is null).AssertTrue(NYI.Throw);

        if (UnsignedHeader?.Signers is not null) {
            (UnsignedHeader.Signers.Count == Trailer.Signatures.Count).AssertTrue(NYI.Throw);

            foreach (var signature in signatures) {
                var signer = Find(UnsignedHeader.Signers, signature.KeyIdentifier);
                signature.Alg ??= signer.Alg;
                }
            }

        // Check that we computed a digest.
        (Digest is not null).AssertTrue(NYI.Throw);

        var value = Digest.GetValue();
        //Console.WriteLine($"Digest Value = {value.ToStringBase16FormatHex()}");

        var manifest = VDareEnvelopeWriter.GetManifest(DigestId, MetadataDigest, value);
        //Console.WriteLine($"Manifest Value = {manifest.ToStringBase16FormatHex()}");

        SignedHeader.VerifiedSignatures = [];
        foreach (var signature in signatures) {
            if (signature?.Value is null) {
                return false;
                }
            if (!keyCollection.TryFindPublicKey(signature.KeyIdentifier, out var key)) {
                // unknown key.
                return false;
                }
            if (!key.VerifyManifest(manifest, signature.Value)) {
                return false;
                }

            SignedHeader.VerifiedSignatures.Add(signature);
            }

        return true;
        }


    EarlSignature Find(IEnumerable<EarlSignature> signers, string keyId) {
        foreach (var signer in signers) {
            if (signer.KeyIdentifier == keyId) {
                return signer;
                }
            }

        throw new NYI();
        }









    }
