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
using System.Runtime.InteropServices;

namespace Goedel.Cryptography.Dare;


public  class EarlSequence : Disposable {

    //Dictionary<string, EarlEntryIndex> DictionaryById = [];

    //Dictionary<long, EarlEntryIndex> DictionaryByFrame = [];

    long UnreadStart { get; set; } = 0;
    long UnreadEnd { get; set; } = long.MaxValue;




    /// <summary>Index record of the first entry in the sequence.</summary>
    public EarlEntryIndex? IndexFirst { get; private set; }


    /// <summary>Index record of the last entry in the sequence.</summary>
    public EarlEntryIndex? IndexLast{ get; private set; }


    public EarlEnvelope FrameFirst { get; private set; }

    public long StartEntries {get; private set; }

    public EarlEnvelope FrameLast { get; private set; }

    public EarlStream Stream { get; }

    public string Filename => Stream.Filename;

    public long NextFrame { get; set; } = 0;


    public DataEncoding DataEncoding { get; set; }

    /// <inheritdoc/>
    protected override void Disposing() {
        Stream.Dispose();
        base.Disposing();
        }



    /// <summary>
    /// Constructor
    /// </summary>
    protected EarlSequence(
                EarlStream stream,
            DataEncoding dataEncoding = DataEncoding.JSON) {
        Stream = stream;
        }


    #region -- Static factory methods Create or open sequence

    public static EarlSequence Create(
                string fileName,
                EarlSequenceIndexType indexType = EarlSequenceIndexType.None) {
        var stream = EarlStream.Create(fileName, DareConstants.TypeIdentifierDareSequence);
        var result = new EarlSequence(stream);

        result.WriteInitial();

        return result;
        }


    public static EarlSequence Open(
            string fileName) {

        var stream = EarlStream.OpenReadWrite(fileName);
        var sequence = new EarlSequence(stream);
        sequence.ReadInitial();

        return sequence;
        }

    protected void WriteInitial() {
        // Create the initial record
        var unprotected = new Unprotected();
        var contentMeta = new ContentMeta();
        var payload = Array.Empty<byte>();
        var trailer = new Unprotected();

        var envelope = new EarlEnvelope(unprotected, contentMeta, null, payload);
        Append(envelope);
        }



    protected void ReadInitial() {
        // read the type identifier
        var version = Stream.ReadTypeIdentifier();
        (version == DareConstants.TypeIdentifierDareSequenceL).AssertTrue(NYI.Throw);

        // read the first record
        FrameFirst = Stream.ReadFrameNext();
        StartEntries = Stream.Position;

        //FrameLast = Stream.EOF ? FrameFirst : Stream.ReadFrameLast();
        }


    #endregion

    #region -- File handling method


    /// <summary>Close the underlying file stream, is used to save file stream 
    /// handles.</summary>
    public void CloseStream() {

        Stream.CloseStream();
        }

    #endregion

    #region -- Append entry methods
    public EarlEntryIndex Append(
                EarlEnvelope entry) => Stream.Append(entry, NextFrame++);


    public EarlEntryIndex<T> Append<T>(
                T? obj,
                ContentMeta contentMeta = null,
                bool index = false,
                DataEncoding dataEncoding = DataEncoding.Default) where T : JsonObject {

        dataEncoding.Default(DataEncoding);
        var bytes = obj == null ? [] : obj.GetBytes(dataEncoding: dataEncoding);

        var append = AppendInner(bytes, contentMeta, index);
        return new EarlEntryIndex<T>(append.Item1, append.Item2, append.Item3,
                append.Item4, bytes.LongLength) { 
            JsonObject = obj
            };
        }


    public EarlEntryIndex Append(
                byte[] entry,
                ContentMeta contentMeta=null,
                bool index = false) {

        var append = AppendInner (entry, contentMeta, index);
        return new(append.Item1, append.Item2, append.Item3,
                append.Item4, entry.LongLength);
        }


    private (long, long, long, long) AppendInner(
            byte[] entry,
            ContentMeta contentMeta = null,
            bool index = false) {

        var result = AppendStart(entry.LongLength, contentMeta, index);
        AppendPayload(entry, 0, entry.Length);
        AppendEnd();

        return result;
        }


    public virtual (long, long, long, long) AppendStart(
            long payloadLength,
            ContentMeta contentMeta = null,
            bool index = false) {

        var unprotected = new Unprotected() {
            Frame = NextFrame++
            };

        return Stream.AppendEntryStartInner(payloadLength, unprotected, contentMeta, 0);

        //return new EarlEntryIndex<T> (frame, start, length, payloadStart, payloadLength);
        }


    public virtual void AppendPayload(
                byte[] payload, int offset, int length) => Stream.AppendEntryPayload(payload, offset, length);

    public virtual void AppendEnd() => Stream.AppendEntryEnd([]);

    #endregion
    #region -- Read Methods

    public EarlEntryIndex? ReadIndexAt (long position, bool includePayload) {
            throw new NYI(); 
        }

    public EarlEnvelope? ReadEntryAt(long position) {
        var index = ReadIndexAt(position, true);
        return index?.EarlEnvelope;
        }



    public EarlEnvelope ReadFirst() {

        return null;
        }

    public EarlEnvelope ReadLast() {

        return null;
        }


    /// <summary>Return entry indicated by <paramref name="index"/>.
    /// <para>If <paramref name="index"/> is zero, the first item in the sequence is returned. </para>
    /// <para>If <paramref name="index"/> is positive, the (<paramref name="index"/>-1)th
    /// entry counting from the first is returned.</para>
    /// <para>If <paramref name="index"/> is negative, the (<paramref name="index"/>+1)th
    /// entry counting from the last and traversing backwards is returned..</para>
    /// </summary>
    /// <param name="index"></param>
    /// <returns>The envelope value.</returns>
    public EarlEnvelope? ReadEntry(long index) {

        return null;
        }

    public EarlEnvelope? ReadNext() {

        return Stream.ReadFrameNext();
        }

    public EarlEnvelope? ReadPrevious() {

        return null;
        }

    public EarlEnvelope Read(EarlEntryIndex index) {

        return null;
        }

    public T GetValue<T>(EarlEntryIndex index) where T : JsonObject{
        // check content meta is this a 

        var bytes = Stream.GetPayload(index);

        //var asChar = bytes.ToUTF8();

        var result = JsonObject.StreamParseTag<T>(bytes, true);
        return result;
        }




    #endregion


    #region -- Indexed retrieval



    public EarlEntryIndex? IndexNext(
                    EarlEntryIndex index,
                    bool forward=true) {

        return null;
        }

    public EarlEntryIndex? IndexPrevious() {

        return null;
        }

    //public virtual bool TryGetEntry(string id, out EarlEntryIndex? index) {

    //    if (DictionaryById.TryGetValue(id, out index)) {
    //        return true;
    //        }

    //    if (UnreadStart >= UnreadEnd) {
    //        index = null;
    //        return false;
    //        }

    //    // sequence not read, abort.
    //    throw new NYI();
    //    }

    //public bool TryGetEntry(string key, string value, out EarlEntryIndex? index) {
    //    index = null;
    //    return false;
    //    }


    #endregion




    #region -- Enumerators

    public virtual IEnumerable<EarlEntryIndex> EntriesForward() => new EarlEntryEnumerator(this);

    public virtual IEnumerable<EarlEntryIndex> EntriesReverse() => new EarlEntryEnumerator(this, false);

    #endregion
    }

