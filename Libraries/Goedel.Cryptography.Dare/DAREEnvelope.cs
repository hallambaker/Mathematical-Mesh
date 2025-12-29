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



public class DareSequenceWriterII {


    Stream Output { get; }

    public DareSequenceWriterII(Stream output) {
        Output = output;
        Output.Write(DareSequence.TypeIdentifier);
        }

    public void Write(DareSequence sequence) {
        foreach (var item in sequence.Envelopes) {
            WriteEnvelope(item);
            }
        }

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


public class DareEnvelopeWriterII {


    Stream Output { get; }

    public DareEnvelopeWriterII(Stream output) {
        Output = output;
        Output.Write(DareEnvelope.TypeIdentifier);
        }


    public void Write(DareSequence sequence) {
        }


    public void Write(DareEnvelope envelope) {
        WriteUnsigned(envelope.Unsigned);
        WriteSigned(envelope.Signed);
        WritePayloadChunk(envelope.Payload);
        WriteTrailer(envelope.Trailer);
        }


    public void WriteUnsigned(DareHeader unsigned) => Write(unsigned?.ToBytes());

    public void WriteSigned(byte[] signed) => Write(signed);

    public void WritePayloadChunk(byte[] chunk) => Write(chunk);

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
    public static readonly byte[] TypeIdentifier = [249, 0];

    public static DareSequence Decode(byte[] data) {
        return null;
        }


    public byte[] GetBytes() {
        return null;
        }


    public void Add (DareEnvelope item) {
        // collapse the trailer and unsigned headers here

        Envelopes ??= new();
        Envelopes.Add (item);

        }

    public override void Serialize(Writer writer, bool tagged = false) {
        bool first = true;
        writer.WriteArrayStart();
        foreach (var item in Envelopes.IfEnumerable()) {
            writer.WriteArraySeparator(ref first);
            item.Serialize(writer);
            }
        writer.WriteArrayEnd();
        }
    public override string ToString() {
        var writer = new JSONDebugWriter();
        Serialize(writer, false);
        return writer.GetUTF8;
        }
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


    public static readonly byte[] TypeIdentifier = [248];
    public DareEnvelope() {
        }


    #region // Static creation methods
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

    public static DareEnvelope Create(
                ContentMeta contentMeta,
                byte[] payload,
                DareHeader unsignedHeader = null,
                DareTrailer trailer = null) => Create(payload, unsignedHeader,
                    contentMeta.ToBytes(), trailer);
    public static DareEnvelope Decode(byte[] data) {
        return null;
        }



    #endregion
    #region // Conversion methods

    public ContentMeta GetSigned() => StreamParse<ContentMeta>(Signed);


    public byte[] ToArray() {
        var buffer = new MemoryStream();
        var writer = new DareEnvelopeWriterII(buffer);
        writer.Write(this);
        return buffer.ToArray();
        }


    public void WriteBytes(Stream output) {

        }


    public override string ToString() {
        var writer = new JSONDebugWriter();
        Serialize(writer, false);
        return writer.GetUTF8;
        }

    #endregion







    }

public partial class DareHeader {


    public static DareHeader Create(ContentMeta contentMeta) => new() {
        ContentMeta = contentMeta
        };

    }