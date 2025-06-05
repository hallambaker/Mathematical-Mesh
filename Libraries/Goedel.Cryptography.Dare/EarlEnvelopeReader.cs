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
namespace Goedel.Cryptography.Dare;

/// <summary>
/// Envelope Reader
/// </summary>
public partial class EarlEnvelopeReader {
    Stream Stream { get; }

    ///<summary>The envelope version (0 or 1).</summary> 
    public int Version { get; private set; }

    ///<summary>The parsed unprotected header.</summary> 
    public Unprotected? UnprotectedHeader { get; private set; } = null;

    ///<summary>The parsed content metadata header.</summary> 
    public ContentMeta? ContentMeta { get; private set; } = null;

    ///<summary>The parsed trailer.</summary> 
    public Unprotected? Trailer { get; private set; } = null;

    HashAlgorithm? Digest = null;
    CryptoAlgorithmId DigestId;
    byte[]? MetadataDigest = null;

    /// <summary>
    /// Constructor returning an instance reading from <paramref name="stream"/>.
    /// Only the initial version number is read from the stream.
    /// </summary>
    /// <param name="stream">The stream to read from.</param>
    public EarlEnvelopeReader(Stream stream) {
        Stream = stream;
        Version = (int)Stream.ReadVarint();
        }

    /// <summary>
    /// Constructor returning an instance reading from <paramref name="bytes"/>.
    /// Only the initial version number is read from the stream.
    /// </summary>
    /// <param name="bytes">The data to read.</param>
    public EarlEnvelopeReader(byte[] bytes) : this(new MemoryStream(bytes)) {

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

        return (reader.ContentMeta, buffer.ToArray());
        }

    /// <summary>
    /// ReadMetadata from the stream.
    /// </summary>  
    /// <returns></returns>
    public ContentMeta ReadMetadata() {
        if (Version == 1) {
            var unprotectedHeader = ReadBlock(Stream);
            if (unprotectedHeader.Length > 0) {
                UnprotectedHeader = JsonObject.StreamParseTag<Unprotected>(unprotectedHeader, false);
                if (UnprotectedHeader.DigestAlgorithm is not null) {
                    DigestId = UnprotectedHeader.DigestAlgorithm.ToCryptoAlgorithmID();
                    Digest = DigestId.CreateDigest();
                    }
                }
            }
        var contentMeta = ReadBlock(Stream);
        if (contentMeta.Length > 0) {
            ContentMeta = JsonObject.StreamParseTag<ContentMeta>(contentMeta, false);
            }
        if (Digest is not null) {
            var metaDigest = DigestId.CreateDigest();
            MetadataDigest = metaDigest.ComputeHash(contentMeta);
            }
        return ContentMeta;
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

        var trailer = ReadBlock(Stream);
        if (trailer.Length > 0) {
            Trailer = JsonObject.StreamParseTag<Unprotected>(trailer, false);
            }

        var signatures = UnprotectedHeader?.Signatures ?? Trailer?.Signatures;
        if (signatures is null & UnprotectedHeader?.Signers is null) {
            return true; // There are no signatures to verify.
            }

        // Check that there is exactly one Signatures property.
        (Trailer?.Signatures is null | UnprotectedHeader?.Signatures is null).AssertTrue(NYI.Throw);

        if (UnprotectedHeader?.Signers is not null) {
            (UnprotectedHeader.Signers.Count == Trailer.Signatures.Count).AssertTrue(NYI.Throw);

            foreach (var signature in signatures) {
                var signer = Find(UnprotectedHeader.Signers, signature.KeyIdentifier);
                signature.Alg ??= signer.Alg;
                }
            }

        // Check that we computed a digest.
        (Digest is not null).AssertTrue(NYI.Throw);

        var value = Digest.GetValue();
        Console.WriteLine($"Digest Value = {value.ToStringBase16FormatHex()}");

        var manifest = EarlEnvelopeWriter.GetManifest(DigestId, MetadataDigest, value);
        Console.WriteLine($"Manifest Value = {manifest.ToStringBase16FormatHex()}");

        ContentMeta.VerifiedSignatures = [];
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

            ContentMeta.VerifiedSignatures.Add(signature);
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

    /// <summary>
    /// Read chunk of payload bytes from <paramref name="stream"/> and return as an array.
    /// </summary>
    /// <param name="stream">The stream to read.</param>
    /// <returns>The bytes read.</returns>
    public static byte[] ReadBlock(Stream stream) {
        var length = stream.ReadVarint();
        var buffer = new byte[length];
        stream.ReadExactly(buffer, 0, (int) length);
        return buffer;
        }






    }
