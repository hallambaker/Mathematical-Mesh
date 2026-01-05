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

using Goedel.Protocol;

namespace Goedel.Cryptography.Dare;



/// <summary>
/// Envelope Reader
/// </summary>
public partial class EarlEnvelopeReader : Disposable {
    protected EarlStream Stream { get; }

    ///<summary>The envelope version (0 or 1).</summary> 
    public ulong Version { get; private set; }

    ///<summary>The parsed unprotected header.</summary> 
    public Unprotected? UnsignedHeader { get; private set; } = null;

    ///<summary>The parsed content metadata header.</summary> 
    public ContentMeta? SignedHeader { get; private set; } = null;

    ///<summary>The parsed trailer.</summary> 
    public Unprotected? Trailer { get; private set; } = null;

    HashAlgorithm? Digest = null;
    CryptoAlgorithmId DigestId;
    byte[]? MetadataDigest = null;


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
    EarlEnvelopeReader(
                EarlStream stream) {
        Stream = stream;
        Version = Stream.ReadTypeIdentifier();

        (Version == DareConstants.TypeIdentifierDareEnvelopeL).AssertTrue(NYI.Throw);

        // read the unsigned header
        UnsignedHeader = ReadJson<Unprotected>();

        // read the signed header
        SignedHeader = ReadJson<ContentMeta>();
        }


    public EarlEnvelope Close () {
        Trailer = ReadJson<Unprotected>();

        // read the trailer
        return new EarlEnvelope(UnsignedHeader, SignedHeader, Trailer);

        }


    public T ReadJson<T>() where T : JsonObject => Stream.ReadJson<T>();


    public virtual byte[] ReadBlock() => Stream.ReadBlock();


    public static EarlEnvelope Read(string fileName,
                TextWriter output = null) {
        var stream = output == null ? EarlStream.OpenRead(fileName) : EarlStreamDebug.OpenRead(fileName);
        using var reader = new EarlEnvelopeReader(stream);

        var payload = reader.ReadBlock();
        var result = reader.Close();
        result.Payload = payload;

        return result;
        }





    /// <summary>
    /// Constructor returning an instance reading from <paramref name="bytes"/>.
    /// Only the initial version number is read from the stream.
    /// </summary>
    /// <param name="bytes">The data to read.</param>
    public EarlEnvelopeReader(byte[] bytes) : this(new EarlStream(bytes)) {
        }


    public static Enveloped GetEnveloped(byte[] bytes,
            KeyCollection? keyCollection = null) {
        var reader = new EarlEnvelopeReader(bytes);
        return reader.GetEnveloped();
        }

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

        var reader = new EarlEnvelopeReader(bytes);
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

        var manifest = EarlEnvelopeWriter.GetManifest(DigestId, MetadataDigest, value);
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
