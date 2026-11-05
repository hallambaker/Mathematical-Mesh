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
    public static readonly byte[] TypeIdentifierDareEnvelope = [248];

    /// <summary>Type identifier for envelopes.</summary>
    public static readonly ulong TypeIdentifierDareEnvelopeL =
            MakeLong(TypeIdentifierDareEnvelope);

    /// <summary>Type identifier for sequences.</summary>
    public static readonly byte[] TypeIdentifierDareSequence = [249, 00];

    /// <summary>Type identifier for sequences.</summary>
    public static readonly ulong TypeIdentifierDareSequenceL = 
            MakeLong(TypeIdentifierDareSequence);


    /// <summary>Type identifier for sequences.</summary>
    public static readonly byte[] TypeIdentifierDareSequenceGuarded = [249, 02];


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
/// <param name="Payload">The payload data.</param>
public record EarlEnvelope (
            Unprotected UnsignedHeader,
            ContentMeta SignedHeader,
            Unprotected Trailer,
            byte[]? Payload = null
        ) {

    /// <summary>The payload value.</summary>
    public byte[] Payload { get; set; } = Payload;
    }


/// <summary>
/// EARL Envelope Writer
/// </summary>
/// <remarks>
/// Constructor creating an instance for an envelope of type 1 (i.e. indeterminate length chunks).
/// </remarks>
public partial class VDareEnvelopeWriter(VDareStream output) : VDareWriter{



    protected VDareStream Stream { get; set; } = output;



    ///<summary>The envelope type, 0 or 1.</summary>
    int Type { get; }

    ///<summary>The writer state.</summary> 
    int State { get; set; } = 0;




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
    /// <param name="recipients"></param>
    public VDareEnvelopeWriter(Stream output,
            ContentMeta protectedHeader,
            Unprotected unprotected=null,
            IEnumerable<CryptographicKey> recipients = null,
            IEnumerable<CryptographicKey> signers = null) : 
                this(new VDareStream(output), protectedHeader, unprotected, recipients, signers) {
        }

    /// <summary>Convenience constructor, begin writing envelope to 
    /// <paramref name="output"/> with signed header <paramref name="protectedHeader"/>
    /// and signers <paramref name="signers"/>.
    /// </summary>
    /// <param name="output"></param>
    /// <param name="protectedHeader"></param>
    /// <param name="signers"></param>
    /// <param name="recipients"></param>
    public VDareEnvelopeWriter(
            VDareStream output,
            ContentMeta protectedHeader,
            Unprotected unprotected,
            IEnumerable<CryptographicKey> recipients = null,
            IEnumerable<CryptographicKey> signers = null) : this(output) {
        Begin(protectedHeader, unprotected, recipients, signers);
        }


    #endregion

    public void Write(
        ContentMeta contentMeta,
        byte[] data,
        CryptoParameters cryptoParameters,
        Unprotected unprotected = null,
        CryptoAlgorithmId digestId = CryptoAlgorithmId.Default,
        CryptoAlgorithmId encryptionId = CryptoAlgorithmId.Default) =>
        Write(ContentMeta, data, unprotected, cryptoParameters.EncryptionKeys,
            cryptoParameters.SignerKeys, cryptoParameters.DigestId, cryptoParameters.EncryptId);



    /// <summary>Write an envelope as a single shot.</summary>
    /// <param name="output"></param>
    /// <param name="contentMeta"></param>
    /// <param name="data"></param>
    /// <param name="unprotected"></param>
    /// <param name="recipients"></param>
    /// <param name="signers"></param>
    /// <param name="digestId"></param>
    /// <param name="encryptionId"></param>
    public void Write(
            ContentMeta contentMeta,
            byte[] data,
            Unprotected unprotected=null,
            IEnumerable<CryptographicKey> recipients = null,
            IEnumerable<CryptographicKey> signers = null,
            CryptoAlgorithmId digestId = CryptoAlgorithmId.Default,
            CryptoAlgorithmId encryptionId = CryptoAlgorithmId.Default) {

        Initialize(contentMeta, unprotected, recipients, signers, digestId, encryptionId);

        var payload = GetPayload(data);
        PayloadDigest = Digest?.ComputeHash(payload);
        MakeTrailer();

        WriteUnsigned(Unprotected);
        WriteSigned(MetadataBytes);
        WritePayload(payload);
        WriteTrailer(Trailer);
        }




    /// <summary>
    /// Begin writing the envelope data.
    /// </summary>
    /// <param name="contentMeta">The content metadata.</param>
    /// <param name="recipients"></param>
    /// <param name="signers">Optional signature keys to be used to sign the envelope data.. MUST match the
    /// list given in <see cref="End"/></param>
    /// <param name="digestId">The digest algorithm to use.</param>
    public void Begin(
            ContentMeta contentMeta,
            Unprotected unprotected=null,
            IEnumerable<CryptographicKey> recipients = null,
            IEnumerable<CryptographicKey> signers = null, 
            CryptoAlgorithmId digestId = CryptoAlgorithmId.Default,
            CryptoAlgorithmId encryptionId = CryptoAlgorithmId.Default,
            int chunkSize = 0) {

        Initialize(contentMeta, unprotected, recipients, signers, digestId, encryptionId);
        WriteUnsigned(Unprotected);
        WriteSigned(MetadataBytes);

        }

    /// <summary>
    /// Write the bytes <paramref name="chunk"/> to the envelope.
    /// </summary>
    /// <param name="chunk">The bytes to write.</param>
    public void Write(
            byte[] chunk) {
        Digest?.Digest(chunk);
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



        if (Sign) {
            PayloadDigest = Digest.GetValue();

            foreach (var key in Signers.IfEnumerable()) {
                Trailer.Signatures ??= [];

                var signer = new EarlSignature(key, Manifest);
                Trailer.Signatures.Add(signer);
                }
            }


        WriteTrailer(Trailer);

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
    /// Return an envelope containing the content metadata <paramref name="contentMeta"/> 
    /// and payload <paramref name="payload"/>
    /// </summary>
    /// <param name="contentMeta">The content metadata.</param>
    /// <param name="payload">The payload.</param>
    /// <param name="signers">The set of signing keys.</param>
    /// <returns>The enveloped bytes</returns>
    public static byte[]? GetBytes(
            byte[] payload,
            IEnumerable<CryptographicKey> recipients = null,
            IEnumerable<CryptographicKey> signers = null, ContentMeta? contentMeta = null,
            CryptoParameters cryptoParameters = null) {

        using var buffer = new MemoryStream();
        using var stream = new VDareStream(buffer);
        var writer = new VDareEnvelopeWriter(stream);

        writer.Write(contentMeta, payload, signers: signers);

        return buffer.ToArray();
        }


    #endregion
    #region

    /// <summary>Write <paramref name="data"/> to <paramref name="file"/> in a DARE
    /// envelope with content metadate <paramref name="contentType"/></summary>
    /// <param name="file">The filename.</param>
    /// <param name="data">The file data</param>
    /// <param name="cryptoParameters"></param>
    /// <param name="contentType">The content metadata.</param>
    public static void Write(
        string file,
        byte[] data,
        CryptoParameters cryptoParameters = null, 
        string contentType = null,
        int chunkSize = 4096) {





        using var stream = VDareStream.Create(file, DareConstants.TypeIdentifierDareEnvelope);
        var contentMeta = new ContentMeta() {
            Nonce = Udf.Nonce(),
            ContentType = contentType
            };


        var writer = new VDareEnvelopeWriter(stream);
        writer.Write(contentMeta, data, cryptoParameters);

        }


    #endregion
    }
