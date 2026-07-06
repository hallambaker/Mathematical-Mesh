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


using Goedel.Cryptography.Jose;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Goedel.Cryptography.Dare;

/// <summary>Sequence index modes.</summary>
public enum SequenceIndexMode {
    /// <summary>Sequence is not indexed.</summary>
    None,

    /// <summary>Index is written to the final terminal record.</summary>
    LastRecord,

    /// <summary>Index is written incrementally.</summary>
    Incremental,

    /// <summary>Index is placed in separate file.</summary>
    IndexFile
    }


/// <summary>Writes a DARE Sequence to the stream specified by the constructor
/// using the QUIC framing.</summary>
public class DareSequenceWriterII {


    Stream Output { get; }


    /// <summary>Constructor, returns a new instance writing to the stream 
    /// <paramref name="output"/>.</summary>
    /// <param name="output">The stream to write to.</param>
    public DareSequenceWriterII(Stream output) {
        Output = output;
        Output.Write(DareSequence.TypeIdentifier);
        }


    /// <summary>Write the sequence of envelopes <paramref name="sequence"/> to the stream.</summary>
    /// <param name="sequence">The sequence to write.</param>
    public void Write(DareSequence sequence) {
        foreach (var item in sequence.Envelopes) {
            WriteEnvelope(item);
            }
        }

    /// <summary>Write the envelope <paramref name="envelope"/> to the stream.</summary>
    /// <param name="envelope">The envelope to write.</param>
    public void WriteEnvelope(DareEnvelope envelope) {

        // hack, not combining the unsigned/trailer components

        var unsigned = envelope.Unsigned is null ? [] : envelope.Unsigned.ToBytes();
        var signed = envelope.Signed ?? [];
        var payload = envelope.Payload ?? [];

        var length = unsigned.Length + Extensions.TagLength(unsigned.Length) +
            signed.Length + Extensions.TagLength(signed.Length) +
            payload.Length + Extensions.TagLength(payload.Length);

        Output.WriteVarint(length);
        Write(unsigned);
        Write(signed);
        Write(payload);
        Output.WriteTnirav(length);
        }


    void Write(byte[]? data) {
        if (data is null) {
            Output.Write(0);
            return;
            }

        Output.WriteVarint(data.Length);
        Output.Write(data);
        }

    }

/// <summary>Write a DARE envelope using the QUIC framing.</summary>
public class DareEnvelopeWriterII {


    Stream Output { get; }

    /// <summary>Constructor, returns a new instance writing to the stream 
    /// <paramref name="output"/>.</summary>
    /// <param name="output">The stream to write to.</param>
    public DareEnvelopeWriterII(Stream output) {
        Output = output;
        Output.Write(DareEnvelope.TypeIdentifier);
        }

    /// <summary>Write the envelope <paramref name="envelope"/> to the stream.</summary>
    /// <param name="envelope">The envelope to write.</param>
    public void Write(DareEnvelope envelope) {
        WriteUnsigned(envelope.Unsigned);
        WriteSigned(envelope.Signed);
        WritePayloadChunk(envelope.Payload);
        WriteTrailer(envelope.Trailer);
        }

    /// <summary>Write the unsigned metadata to the stream.</summary>
    /// <param name="unsigned"></param>
    public void WriteUnsigned(DareHeader unsigned) => Write(unsigned?.ToBytes());

    /// <summary>Write the signed metadata to the stream.</summary>
    /// <param name="signed"></param>
    public void WriteSigned(byte[] signed) => Write(signed);

    /// <summary>Write the payload to the stream.</summary>
    /// <param name="chunk"></param>
    public void WritePayloadChunk(byte[] chunk) => Write(chunk);

    /// <summary>Write the trailer to the stream.</summary>
    /// <param name="trailer">The trailer to write.</param>
    public void WriteTrailer(DareTrailer trailer) {
        Output.Write(0);
        Write(trailer?.ToBytes());
        }

    void Write(byte[]? data) {
        if (data is null) {
            Output.Write(0);
            return;
            }

        Output.WriteVarint (data.Length);
        Output.Write(data);
        }

    }



public partial class DareSequence {

    /// <summary>The type identifier for a DARE sequence.</summary>
    public static readonly byte[] TypeIdentifier = [249, 0];

    /// <summary>Read <paramref name="data"/> as a DARE sequence and return the result.</summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static DareSequence Decode(byte[] data) {
        return null;
        }


    //static public byte[] GetBytes() {
    //    return null;
    //    }

    /// <summary>Add the envelope <paramref name="item"/> to the sequence.</summary>
    /// <param name="item"></param>
    public void Add (DareEnvelope item) {
        // collapse the trailer and unsigned headers here

        Envelopes ??= [];
        Envelopes.Add (item);

        }

    /// <inheritdoc/>
    public override void Serialize(Writer writer, bool tagged = false) {
        bool first = true;
        writer.WriteArrayStart();
        foreach (var item in Envelopes.IfEnumerable()) {
            writer.WriteArraySeparator(ref first);
            item.Serialize(writer);
            }
        writer.WriteArrayEnd();
        }

    /// <inheritdoc/>
    public override string ToString() {
        var writer = new JSONDebugWriter();
        Serialize(writer, false);
        return writer.GetUTF8;
        }

    /// <inheritdoc/>
    public byte[] ToArray() {
        var buffer = new MemoryStream();
        var writer = new DareSequenceWriterII(buffer);
        writer.Write(this);
        return buffer.ToArray();
        }

    }



/// <summary>
/// Base class for DARE Envelopes. These are encoded using the QUIC varint
/// encoding with the ContentType broken out as a separate header item.
/// </summary>
public partial class DareEnvelope  {

    /// <summary>The type identifier for a DARE envelope.</summary>
    public static readonly byte[] TypeIdentifier = [248];


    /// <summary>Constructor, returns a new empty instance.</summary>
    public DareEnvelope() {
        }


    #region // Static creation methods

    /// <summary>Factory method, returns a new instance with the segments 
    /// <paramref name="unsignedHeader"/>, <paramref name="signedHeader"/>,
    /// <paramref name="payload"/> and <paramref name="trailer"/>.</summary>
    /// <param name="payload">The payload bytes.</param>
    /// <param name="unsignedHeader">The unsigned metadata.</param>
    /// <param name="signedHeader">The content metadata.</param>
    /// <param name="trailer">The trailer</param>
    /// <returns></returns>
    public static DareEnvelope Create(
        byte[] payload,
        DareHeader unsignedHeader = null,
        byte[] signedHeader = null,
        DareTrailer trailer = null) => new() {
            Payload = payload,
            Unsigned = unsignedHeader,
            Signed = signedHeader,
            Trailer = trailer
            };

    /// <summary></summary>
    /// <param name="contentMeta">The content metadata.</param>
    /// <param name="payload">The payload bytes.</param>
    /// <param name="unsignedHeader">The unsigned metadata.</param>
    /// <param name="trailer">The trailer</param>
    /// <returns></returns>
    public static DareEnvelope Create(
                ContentMeta contentMeta,
                byte[] payload,
                DareHeader unsignedHeader = null,
                DareTrailer trailer = null) => Create(payload, unsignedHeader,
                    contentMeta.ToBytes(), trailer);


    //public static DareEnvelope Decode(byte[] data) {
    //    return null;
    //    }



    #endregion
    #region // Conversion methods

    /// <summary>Parse the contents of the unsigned frame and return as 
    /// content metadata.</summary>
    /// <returns></returns>
    public ContentMeta GetSigned() => StreamParse<ContentMeta>(Signed);

    /// <summary>Write the envelope to a byte array.</summary>
    /// <returns>The encoded envelope.</returns>
    public byte[] ToArray() {
        var buffer = new MemoryStream();
        var writer = new DareEnvelopeWriterII(buffer);
        writer.Write(this);
        return buffer.ToArray();
        }


    //static public void WriteBytes(Stream output) {

    //    }

    /// <inheritdoc/>
    public override string ToString() {
        var writer = new JSONDebugWriter();
        Serialize(writer, false);
        return writer.GetUTF8;
        }

    #endregion







    }

public partial class DareHeader {


    //public static DareHeader Create(ContentMeta contentMeta) => new() {
    //    ContentMeta = contentMeta
    //    };

    }