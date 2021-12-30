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

///<summary>Describe the integrity checking to be applied when reading a sequence.</summary>
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

/// <summary>
/// Sequence index with the decoded head and tail and extent information for
/// the body.
/// </summary>
public partial class SequenceFrameIndex {

    ///<summary>The frame header</summary>
    public DareHeader Header;

    ///<summary>The frame trailer</summary>
    public DareTrailer Trailer;

    ///<summary>The first byte of the data segment (excluding the length indicator)</summary>
    public long DataPosition;

    ///<summary>The length of the data segment.</summary>
    public long DataLength;

    ///<summary>If true, the frame has a payload section</summary>
    public bool HasPayload => DataLength > 0;

    ///<summary>The decoded JSONObject</summary>
    public JsonObject JsonObject;

    ///<summary>Convenience property, set true iff payload is encrypted.</summary> 
    public bool IsEncrypted => Header?.EncryptionAlgorithm != null;

    ///<summary>Convenience property, set true iff header contains direct key exchange.</summary> 
    public bool KeyExchange => Header?.Recipients != null;

    readonly JbcdStream jbcdStream;

    /// <summary>
    /// Return the frame payload.
    /// </summary>
    /// <returns>The frame payload data.</returns>
    public void CopyPayload(Sequence sequence, IKeyLocate keyCollection, Stream output) {



        // failing here because we have encryption but no recipients!!!

        DareHeader exchange = null;
        if (Header?.HasExchangePosition == true) {
            exchange = sequence.GetHeader(Header.SequenceInfo.ExchangePosition);
            }

        using var input = jbcdStream.FramerGetReader(DataPosition, DataLength);
        Header.GetDecoder(input,
            out var Reader, keyCollection: keyCollection, exchange: exchange);


        Reader.CopyTo(output);
        }

    /// <summary>
    /// Constructor returning an instance for the envelope <paramref name="envelope"/>.
    /// </summary>
    /// <param name="envelope">The envelope to return an index for.</param>
    /// <param name="sequence">The sequence in which the envelope is embedded.</param>
    /// <param name="dataPosition">Position of the envelope in the sequence.</param>
    public SequenceFrameIndex(Sequence sequence, DareEnvelope envelope, long dataPosition) {
        Header = envelope.Header;
        Trailer = envelope.Trailer;
        JsonObject = envelope.JsonObject;
        jbcdStream = sequence.JbcdStream;
        DataPosition = dataPosition;

        if (envelope.Body != null) {
            DataLength = envelope.Body.Length;
            }
        }


    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="jsonStream">Stream reader positioned to the start of the frame.</param>
    /// <param name="Position">The position in the file.</param>
    public SequenceFrameIndex(JbcdStream jsonStream, long Position = -1) {
        jbcdStream = jsonStream;

        jsonStream.FramerOpen(Position);
        var headerBytes = jsonStream.FramerGetData();
        Header = DareHeader.FromJson(headerBytes.JsonReader(), false);

        jsonStream.FramerGetFrameIndex(out DataPosition, out DataLength);

        var TrailerBytes = jsonStream.FramerGetData();
        if (TrailerBytes != null && TrailerBytes.Length > 0) {
            var TrailerText = TrailerBytes.ToUTF8();
            Trailer = DareTrailer.FromJson(TrailerText.JsonReader(), false);
            }
        }

    /// <summary>
    /// Read the payload data from the specified position in <paramref name="sequence"/>
    /// and deserialize to return the corresponding object.
    /// </summary>
    /// <param name="sequence">The container that was indexed.</param>
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
    //    GetPayload(container.KeyLocate).JsonReader().ReadTaggedObject(JsonObject.TagDictionary);


    /// <summary>
    /// Return the frame payload verbatim (i.e. ciphertext if encrypted).
    /// </summary>
    /// <param name="sequence">The indexed sequence.</param>
    /// <returns>The frame payload</returns>
    public byte[] GetBody(Sequence sequence) {
        using var input = sequence.JbcdStream.FramerGetReader(DataPosition, DataLength);
        using var output = new MemoryStream();
        input.CopyTo(output);
        return output.ToArray();

        }


    /// <summary>
    /// Return a DareEnvelope wrapping the fnewrame.
    /// </summary>
    /// <param name="sequence">The indexed container.</param>
    /// <param name="detatched">If true, </param>
    /// <returns>The frame payload</returns>      
    public DareEnvelope GetEnvelope(Sequence sequence, bool detatched = false) {
        var envelope = new DareEnvelope() {
            Header = Header,
            Trailer = Trailer,
            Body = GetBody(sequence)
            };

        if (!detatched | !Header.HasExchangePosition) {
            Header.Recipients = GetRecipients(sequence);
            }


        return envelope;

        }

    List<DareRecipient> GetRecipients(Sequence sequence) {
        if (!Header.HasExchangePosition) {
            return Header.Recipients;
            }
        var exchangeHeader = sequence.GetHeader(Header.SequenceInfo.ExchangePosition);

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
    /// <param name="sequence">The sequence in which the payload is recorded.</param>
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
