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
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net.WebSockets;
using System.Security.Cryptography;

using Goedel.ASN;
using Goedel.Cryptography.Jose;
using Goedel.Protocol;
using Goedel.Utilities;

using static System.Runtime.InteropServices.JavaScript.JSType;
using static Goedel.Discovery.ServiceAddressSplitLex;

namespace Goedel.Cryptography.Dare;

public partial class DareConstants {

    /// <summary>Type identifier for envelopes.</summary>
    public static readonly byte[] TypeIdentifierDareEnvelope = { 248 };

    /// <summary>Type identifier for envelopes.</summary>
    public static readonly ulong TypeIdentifierDareEnvelopeL =
            MakeLong(TypeIdentifierDareEnvelope);

    /// <summary>Type identifier for sequences.</summary>
    public static readonly byte[] TypeIdentifierDareSequence = { 249, 00 };

    /// <summary>Type identifier for sequences.</summary>
    public static readonly ulong TypeIdentifierDareSequenceL = 
            MakeLong(TypeIdentifierDareSequence);



    static ulong MakeLong(byte[] identifier) {
        ulong result = 0;
        foreach (var item in identifier) {
            result = (result <<8) + item;
            }
        return result;
        }
    }

/// <summary>A DARE envelope with varint framing.</summary>
/// <param name="UnsignedHeader">The unsigned header.</param>
/// <param name="SignedHeader">The signed header</param>
/// <param name="Trailer">The trailer</param>
/// <param name="payload">The payload data.</param>
public record EarlEnvelope (
            Unprotected UnsignedHeader,
            ContentMeta SignedHeader,
            Unprotected Trailer,
            byte[]? payload = null
        ) {

    /// <summary>The payload value.</summary>
    public byte[] Payload { get; set; } = payload;
    }



/// <summary>
/// EARL Envelope Writer
/// </summary>
public partial class VDareEnvelopeWriter {


    VDareStream Stream { get; set; }

    bool closeOutput = false;


    IEnumerable<KeyPair> Signers;


    ///<summary>The parsed unprotected header.</summary> 
    public Unprotected? Unprotected { get; private set; }

    ///<summary>The parsed trailer.</summary>
    public Unprotected? Trailer { get; private set; }

    ///<summary>The envelope type, 0 or 1.</summary>
    int Type { get; }

    ///<summary>The writer state.</summary> 
    int State { get; set; }

    HashAlgorithm Digest = null;
    CryptoAlgorithmId DigestId;


    ///<summary>The metadata digest.</summary>
    public byte[]? MetadataDigest { get; private set; } = null;

    ///<summary>The payload digest.</summary>
    public byte[]? PayloadDigest { get; private set; } = null;


    ///<summary>The envelope manifest</summary>
    public byte[]? Manifest { get; private set; } = null;

    #region // Constructors

    /// <summary>DARE Envelope Writer.</summary>
    /// <param name="output"></param>
    public VDareEnvelopeWriter(Stream output) : this(new VDareStream(output)) {
        }

    /// <summary>DARE Envelope Writer opening with the unsigned and signed headers 
    /// as specified by <paramref name="signers"/> and <paramref name="protectedHeader"/>.</summary>
    /// <param name="output"></param>
    /// <param name="protectedHeader">The content metadata describing the payload.</param>
    /// <param name="signers">The set of signers.</param>
    public VDareEnvelopeWriter(Stream output,
            ContentMeta protectedHeader,
            IEnumerable<KeyPair> signers = null) : 
                this(new VDareStream(output), protectedHeader, signers) {
        }



    /// <summary>
    /// Constructor creating an instance for an envelope of type 1 (i.e. indeterminate length chunks).
    /// </summary>
    public VDareEnvelopeWriter(VDareStream output) {
        Stream = output;
        //Stream.Write(DareConstants.TypeIdentifierDareEnvelope);
        State = 0;
        }

    /// <summary>Convenience constructor, begin writing envelope to 
    /// <paramref name="output"/> with signed header <paramref name="protectedHeader"/>
    /// and signers <paramref name="signers"/>.
    /// </summary>
    /// <param name="output"></param>
    /// <param name="protectedHeader"></param>
    /// <param name="signers"></param>
    public VDareEnvelopeWriter(
            VDareStream output,
            ContentMeta protectedHeader,
            IEnumerable<KeyPair> signers=null) : this(output) {
        Begin(protectedHeader, signers);
        }


    #endregion
    /// <summary>
    /// Begin writing the envelope data.
    /// </summary>
    /// <param name="contentMeta">The content metadata.</param>
    /// <param name="signers">Optional signature keys to be used to sign the envelope data.. MUST match the
    /// list given in <see cref="End"/></param>
    /// <param name="digestId">The digest algorithm to use.</param>
    public void Begin(
            ContentMeta contentMeta,
            IEnumerable<KeyPair> signers=null,
            CryptoAlgorithmId digestId = CryptoAlgorithmId.Default) {


        signers ??= [];
        Signers = signers;

        foreach (KeyPair pair in signers) {
            if (pair.CryptoAlgorithmId == CryptoAlgorithmId.Ed448) {
                digestId = CryptoAlgorithmId.SHA_3_512;
                }

            else if (digestId == CryptoAlgorithmId.Default) {
                digestId = CryptoAlgorithmId.SHA_3_256;
                }
            }

        DigestId = digestId;
        var metadataBytes = contentMeta.GetBytes(false);
        if (signers.Count() > 0) {
            var metaDigest = DigestId.CreateDigest();
            MetadataDigest = metaDigest.ComputeHash(metadataBytes);

            Digest = DigestId.CreateDigest();

            Unprotected = new Unprotected() {
                DigestAlgorithm = DigestId.ToJoseID(),
                Signers = []
                };
            foreach (var key in signers) {
                var signer = new EarlSignature(key);
                Unprotected.Signers.Add(signer);
                }
            WriteUnsigned(Unprotected);
            }
        else {
            // No signers, no unprotected header.
            WriteUnsigned();
            }

        WriteSigned(metadataBytes);

        }

    /// <summary>
    /// Write the bytes <paramref name="chunk"/> to the envelope.
    /// </summary>
    /// <param name="chunk">The bytes to write.</param>
    public void Write(
            byte[] chunk) {
        if (Digest is not null) {
            Digest.Digest(chunk);
            }
        WritePayload(chunk);

        }

    /// <summary>
    /// Write the string <paramref name="chunk"/> to the envelope.
    /// </summary>
    /// <param name="chunk">The string to write.</param>
    public void Write(
        string chunk) => Write (chunk.ToUTF8());

    /// <summary>
    /// Complete writing the envelope using the optional signature keys specified when it was opened.
    /// </summary>
    public void End() {

        if (Digest is not null) {
            Trailer = new Unprotected();

            PayloadDigest = Digest.GetValue();
            Manifest = GetManifest(DigestId, MetadataDigest, PayloadDigest);

            foreach (var key in Signers.IfEnumerable()) {
                Trailer.Signatures ??= [];

                var signer = new EarlSignature(key, Manifest);
                Trailer.Signatures.Add(signer);
                }

            WriteTrailer(Trailer);
            }
        else {
            WriteTrailer();
            }

        }

    #region // Write chunks

    /// <summary>
    /// Write the unprotected header bytes <paramref name="unprotectedHeader"/> to the envelope.
    /// </summary>
    /// <param name="unprotectedHeader">The bytes to write.</param>
    public void WriteUnsigned(
                Unprotected unprotectedHeader = null) {
        (State == 0).AssertTrue(NYI.Throw);
        Stream.Write(unprotectedHeader);
        State = 1;
        }

    /// <summary>
    /// Write the content metadata bytes <paramref name="contentMeta"/> to the envelope.
    /// </summary>
    /// <param name="contentMeta">The bytes to write.</param>
    public void WriteSigned(
            byte[]? contentMeta = null) {
        (State < 2).AssertTrue(NYI.Throw);
        if (State == 0) {
            WriteUnsigned();
            }
        Stream.WriteBytes(contentMeta);
        State = 2;
        }

    /// <summary>
    /// Write the payload bytes <paramref name="payload"/> to the envelope.
    /// </summary>
    /// <param name="payload">The bytes to write.</param>
    public void WritePayload(
            byte[] payload) {
        (State < 3).AssertTrue(NYI.Throw);
        if (State < 2) {
            WriteSigned();
            }
        Stream.WritePayloadBytes(payload);
        }

    /// <summary>
    /// Write the trailer bytes <paramref name="trailer"/> to the envelope.
    /// </summary>
    /// <param name="trailer">The bytes to write.</param>
    public void WriteTrailer(
            Unprotected? trailer = null) {
        (State < 3).AssertTrue(NYI.Throw);
        if (State < 2) {
            WriteSigned();
            }
        Stream.Write([0]); // last payload chunk
        Stream.Write(trailer);
        State = 3;
        }

    #endregion
    #region // Static convenience routines.
    
    /// <summary>
    /// Compute the manifest of  <paramref name="contentMetadataDigest"/>, 
    /// <paramref name="payloadDigest"/> and optional <paramref name="protectedData"/> using
    /// the digest algorithm <paramref name="digest"/>
    /// </summary>
    /// <param name="digest">The digest algorithm.</param>
    /// <param name="contentMetadataDigest">Digest of the Content Metadata.</param>
    /// <param name="payloadDigest">Digest of the payload.</param>
    /// <param name="protectedData">Optional additional protected data.</param>
    /// <returns>The manifest bytes.</returns>
    public static byte[] GetManifest(
                CryptoAlgorithmId digest,
                byte[] contentMetadataDigest,
                byte[] payloadDigest,
                byte[]? protectedData = null) {
        var oid = digest.ToOID().ParseOid();
        var stream = new MemoryStream();

        stream.Write(oid);
        stream.Write(contentMetadataDigest);
        stream.Write(payloadDigest);
        if (protectedData != null) {
            stream.Write(protectedData);
            }

        return stream.ToArray();
        }

    /// <summary>
    /// Return an envelope containing the content metadata <paramref name="contentMeta"/> 
    /// and payload <paramref name="payload"/>
    /// </summary>
    /// <param name="contentMeta">The content metadata.</param>
    /// <param name="payload">The payload.</param>
    /// <param name="signers">The set of signing keys.</param>
    /// <returns>The enveloped bytes</returns>
    public static byte[]? GetBytes(
            byte[] payload,
            ContentMeta? contentMeta=null,
            IEnumerable<KeyPair> signers=null) {

        using var buffer = new MemoryStream();
        using var stream = new VDareStream(buffer);
        var writer = new VDareEnvelopeWriter (stream);
        writer.Begin (contentMeta, signers);
        writer.Write (payload);
        writer.End ();

        return buffer.ToArray ();
        }


    #endregion
    #region

    /// <summary>Write <paramref name="data"/> to <paramref name="file"/> in a DARE
    /// envelope with content metadate <paramref name="contentType"/></summary>
    /// <param name="file">The filename.</param>
    /// <param name="data">The file data</param>
    /// <param name="contentType">The content metadata.</param>
    public static void Write(
        string file,
        byte[] data,
        string contentType=null) {

        using var stream = VDareStream.Create(file, DareConstants.TypeIdentifierDareEnvelope);
        var contentMeta = new ContentMeta() {
            Nonce = Udf.Nonce (),
            ContentType = contentType
            };

        var writer = new VDareEnvelopeWriter(stream, contentMeta);
        writer.Write(data);
        writer.End();

        }


    #endregion
    }
