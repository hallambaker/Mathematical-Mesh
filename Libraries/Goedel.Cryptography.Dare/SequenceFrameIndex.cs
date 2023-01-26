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

///<summary>Describe the integrity checking to be applied when reading a Sequence.</summary>
public enum SequenceIntegrity {
    ///<summary>Do not perform integrity checks.</summary>
    None,

    ///<summary>Check that the digest values specified in the headers and trailers are
    ///consistent with the payload digest value specified. Do not verify the payload digest 
    ///value.</summary>
    Trailer,

    ///<summary>Check that the digest values specified in the headers and trailers are
    ///consistent with the payload digest value specified and verify the payload digest 
    ///value against the payload contents.</summary>
    Full


    }

///<summary>Delegate called to intern a Sequence entry into a catalog or store.</summary> 
public delegate void InternSequenceIndexEntryDelegate(
        SequenceIndexEntry sequenceIndexEntry);


/// <summary>
/// Sequence index with the decoded head and tail and extent information for
/// the body.
/// </summary>
public partial class SequenceIndexEntry {

    ///<summary>The Sequence that is indexed.</summary> 
    public Sequence Sequence { get; set; }

    ///<summary>The first byte of the data segment (excluding the length indicator)</summary>
    public long FramePosition { get; init; }

    ///<summary>The length of the data segment.</summary>
    public long FrameLength { get; set; }

    ///<summary>The length of the data segment.</summary>
    public long FramePositionNext => FramePosition + FrameLength;

    ///<summary>The first byte of the data segment (excluding the length indicator)</summary>
    public long DataPosition { get; set; }

    ///<summary>The length of the data segment.</summary>
    public long DataLength { get; set; }

    ///<summary>The frame header</summary>
    public DareHeader Header { get; init; }

    ///<summary>The frame index.</summary> 
    public long Index => Header.Index;

    ///<summary>The frame index.</summary> 
    public long? TreePosition => Header.SequenceInfo.TreePosition;

    ///<summary>The frame trailer</summary>
    public DareTrailer Trailer { get; set; }

    ///<summary>If true, the frame has a payload section</summary>
    public bool HasPayload => DataLength > 0;

    ///<summary>The decoded JSONObject</summary>
    public JsonObject JsonObject { get; set; }

    ///<summary>Convenience property, set true iff payload is encrypted.</summary> 
    public bool IsEncrypted => Header?.EncryptionAlgorithm != null;

    ///<summary>Convenience property, set true iff header contains direct key exchange.</summary> 
    public bool KeyExchange => Header?.Recipients != null;


    ///<summary>Convenience accessor for the payload digest</summary> 
    public byte[] PayloadDigest => Trailer?.PayloadDigest ?? Header.PayloadDigest;

    ///<summary>Convenience accessor for the payload digest</summary> 
    public byte[] ChainDigest => Trailer?.ChainDigest ?? Header.ChainDigest;


    //readonly jbcdStream jbcdStream;



    /// <summary>
    /// Return the frame payload.
    /// </summary>
    /// <returns>The frame payload data.</returns>
    public void CopyPayload(Sequence sequence, IKeyLocate keyCollection, Stream output) {



        // failing here because we have encryption but no recipients!!!

        DareHeader exchange = null;
        if (Header?.SequenceInfo?.ExchangePosition is not null) {
            exchange = sequence.GetHeader(Header.SequenceInfo.ExchangePosition ?? 0);
            }

        using var input = Sequence.FramerGetReader(DataPosition, DataLength);
        Header.GetDecoder(input,
            out var Reader, keyCollection: keyCollection, exchange: exchange);


        Reader.CopyTo(output);
        }

    /// <summary>
    /// Constructor returning an instance for the envelope <paramref name="envelope"/>.
    /// </summary>
    /// <param name="envelope">The envelope to return an index for.</param>
    /// <param name="sequence">The Sequence in which the envelope is embedded.</param>
    /// <param name="dataPosition">PositionRead of the envelope in the Sequence.</param>
    public SequenceIndexEntry(Sequence sequence, DareEnvelope envelope, long dataPosition) {
        Header = envelope.Header;
        Trailer = envelope.Trailer;
        JsonObject = envelope.JsonObject;
        Sequence = sequence;
        //jbcdStream = Sequence.jbcdStream;
        DataPosition = dataPosition;

        if (envelope.Body != null) {
            DataLength = envelope.Body.Length;
            }
        }


    /// <summary>
    /// Constructor
    /// </summary>

    public SequenceIndexEntry() {
        //Sequence = Sequence;

        //jsonStream.FramerOpen(Position);
        //var headerBytes = jsonStream.FramerGetData();
        //Header = DareHeader.FromJson(headerBytes.JsonReader(), false);

        //Sequence.FramerGetFrameIndex(out DataPosition, out DataLength);

        //var TrailerBytes = jsonStream.FramerGetData();
        //if (TrailerBytes != null && TrailerBytes.Length > 0) {
        //    var TrailerText = TrailerBytes.ToUTF8();
        //    Trailer = DareTrailer.FromJson(TrailerText.JsonReader(), false);
        //    }
        }

    /// <summary>
    /// Constructor returning an instance by reading <paramref name="jbcdStream"/>
    /// at the position specified by <paramref name="position"/>. If 
    /// <paramref name="previous"/> is true, the previous record is read, 
    /// otherwise the next record is read.
    /// </summary>
    /// <param name="jbcdStream">The stream to read.</param>
    /// <param name="position">The starting point for the read operation.</param>
    /// <param name="previous">If true, read the previous frame, otherwise 
    /// return the next frame.</param>
    private SequenceIndexEntry(
                    JbcdStream jbcdStream,
                    long position,
                    bool previous = false) {

        var frameLength = jbcdStream.FramerOpen(position, previous);
        var headerBytes = jbcdStream.FramerGetData();
        var header = DareHeader.FromJson(headerBytes.JsonReader(), false);

        jbcdStream.FramerGetFrameIndex(out var dataPosition, out var dataLength);

        var TrailerBytes = jbcdStream.FramerGetData();
        DareTrailer trailer = null;
        if (TrailerBytes != null && TrailerBytes.Length > 0) {
            var TrailerText = TrailerBytes.ToUTF8();
            trailer = DareTrailer.FromJson(TrailerText.JsonReader(), false);
            }

        FramePosition = previous ? position - frameLength : position;
        FrameLength = frameLength;
        DataPosition = dataPosition;
        DataLength = dataLength;
        Header = header;
        Trailer = trailer;
        }


    public SequenceIndexEntry Previous() => Sequence.Previous(this);

    public SequenceIndexEntry Next() => Sequence.Next(this);


    /// <summary>
    /// Read a frame from <paramref name="jbcdStream"/> at the position 
    /// specified by <paramref name="position"/>. 
    /// </summary>
    /// <param name="jbcdStream">The stream to read.</param>
    /// <param name="position">The starting point for the read operation.</param>
    /// <returns>The index entry.</returns>
    public static SequenceIndexEntry Read(
                    JbcdStream jbcdStream,
                    long position,
                    bool previous = false,
                    Sequence sequence = null) =>
         PositionInvalid(jbcdStream, jbcdStream.Length) ? null :
            new SequenceIndexEntry(jbcdStream, position, previous) {
                Sequence = sequence
                };

    /// <summary>
    /// Read the last frame from <paramref name="jbcdStream"/>. 
    /// </summary>
    /// <param name="jbcdStream">The stream to read.</param>
    /// <returns>The index entry.</returns>
    public static SequenceIndexEntry ReadLast(
                    JbcdStream jbcdStream,
                    Sequence sequence = null) =>
        PositionInvalid(jbcdStream, jbcdStream.Length) ? null :
            new SequenceIndexEntry(jbcdStream, jbcdStream.Length, true) {
                Sequence = sequence
                };

    static bool PositionInvalid(JbcdStream jbcdStream,
                    long position,
                    bool previous = true) =>
        previous ? position < 0 : position <= jbcdStream.Length;

    /// <summary>
    /// Return an envelope for the index data.
    /// </summary>
    /// <returns></returns>
    public DareEnvelope GetEnvelope() {
        return new DareEnvelopeLazy(GetBody) {
            Header = Header,
            Trailer = Trailer,
            };
        }


    /// <summary>
    /// Return the raw body bytes.
    /// </summary>
    /// <returns></returns>
    public byte[] GetBody() {
        using var input = Sequence.FramerGetReader(DataPosition, DataLength);
        using var output = new MemoryStream();
        input.CopyTo(output);
        return output.ToArray();
        }

    /// <summary>
    /// Return the frame payload.
    /// </summary>
    /// <returns>The frame payload data.</returns>
    public byte[] GetPayload() {
        using var output = new MemoryStream();
        CopyPayload(Sequence, Sequence.KeyLocate, output);
        return output.ToArray();
        }






    /// <summary>
    /// Read the payload data from the specified position in <paramref name="sequence"/>
    /// and deserialize to return the corresponding object.
    /// </summary>
    /// <param name="sequence">The Sequence that was indexed.</param>
    /// <returns>The deserialized object.</returns>
    public JsonObject GetJSONObject(Sequence sequence) {
        if (JsonObject != null) {
            return JsonObject;
            }
        if (IsEncrypted & !sequence.Decrypt) {
            return null;
            }


        var bytes = GetPayload(sequence, sequence.KeyLocate);
        //var text = bytes.ToUTF8();
        return bytes.JsonReader().ReadTaggedObject(JsonObject.TagDictionary);

        }
    //=> JsonObject ??
    //    GetPayload(Sequence.KeyLocate).JsonReader().ReadTaggedObject(JsonObject.TagDictionary);


    /// <summary>
    /// Return the frame payload verbatim (i.e. ciphertext if encrypted).
    /// </summary>
    /// <param name="sequence">The indexed Sequence.</param>
    /// <returns>The frame payload</returns>
    public byte[] GetBody(Sequence sequence) {
        using var input = sequence.FramerGetReader(DataPosition, DataLength);
        using var output = new MemoryStream();
        input.CopyTo(output);
        return output.ToArray();

        }


    /// <summary>
    /// Return a DareEnvelope wrapping the fnewrame.
    /// </summary>
    /// <param name="sequence">The indexed Sequence.</param>
    /// <param name="detatched">If true, </param>
    /// <returns>The frame payload</returns>      
    public DareEnvelope GetEnvelope(Sequence sequence, bool detatched = false) {
        var envelope = new DareEnvelope() {
            Header = Header,
            Trailer = Trailer,
            Body = GetBody(sequence)
            };

        if (!detatched | Header?.SequenceInfo?.ExchangePosition is null) {
            Header.Recipients = GetRecipients(sequence);
            }


        return envelope;

        }

    List<DareRecipient> GetRecipients(Sequence sequence) {
        if (Header?.SequenceInfo?.ExchangePosition is null) {
            return Header.Recipients;
            }
        var exchangeHeader = sequence.GetHeader(Header.SequenceInfo.ExchangePosition ?? 0);

        if (Header.Recipients == null) {
            return exchangeHeader.Recipients;
            }
        else {
            // Not yet decided if it should be permissable to specify a previous exchange
            // and a current one.
            throw new NYI();
            }

        }

    /// <summary>
    /// Copy the payload data to file.
    /// </summary>
    /// <param name="file">The file to write the payload to.</param>
    /// <param name="sequence">The Sequence in which the payload is recorded.</param>
    public void CopyToFile(Sequence sequence, string file) {

        using var output = file.OpenFileNew();
        CopyPayload(sequence, sequence.KeyLocate, output);
        }

    /// <summary>
    /// Return the frame payload.
    /// </summary>
    /// <returns>The frame payload data.</returns>
    public byte[] GetPayload(Sequence sequence, IKeyLocate keyCollection) {


        using var output = new MemoryStream();
        CopyPayload(sequence, keyCollection, output);
        return output.ToArray();
        }




    }


/// <summary>
/// Delegate returning the body of a DARE envelope.
/// </summary>
/// <returns>The body of the envelope.</returns>
public delegate byte[] GetBodyDelegate();

/// <summary>
/// Lazy evaluation version of <see cref="DareEnvelope"/>, only reads the
/// body part when needed.
/// </summary>
public class DareEnvelopeLazy : DareEnvelope {

    ///<inheritdoc/>
    public override byte[] Body {
        get => body ?? GetBodyDelegate().CacheValue(out body);
        set => throw new NYI(); }
    byte[] body = null;

    GetBodyDelegate GetBodyDelegate { get; }

    /// <summary>
    /// Constructor, returns an envelope that will only read the body when needed
    /// using the <paramref name="getbody"/> delegate.
    /// </summary>
    /// <param name="getbody">Delegate returning the body of the envelope.</param>
    public DareEnvelopeLazy(GetBodyDelegate getbody) {
        GetBodyDelegate = getbody;
        }


    }