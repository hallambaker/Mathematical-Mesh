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

/// <summary>Sequence access support.</summary>
public  class VDareSequence : Disposable {

    long UnreadStart { get; set; } = 0;

    long UnreadEnd { get; set; } = long.MaxValue;




    /// <summary>Index record of the first entry in the sequence.</summary>
    public virtual VDareEntryIndex? IndexFirst { get; private set; }


    /// <summary>Index record of the last entry in the sequence.</summary>
    public virtual VDareEntryIndex? IndexLast{ get; private set; }

    /// <summary>The first frame in the sequence.</summary>
    public EarlEnvelope FrameFirst { get; private set; }

    /// <summary>The first byte of the sequence entries (after the first frame).</summary>
    public long StartEntries {get; private set; }

    /// <summary>The last frame in the sequence.</summary>
    public EarlEnvelope FrameLast { get; private set; }

    /// <summary>The underlying stream.</summary>
    public VDareStream Stream { get; }

    /// <summary>The file name bound to the underlying stream.</summary>
    public string Filename => Stream.Filename;

    /// <summary>Position of the next frame.</summary>
    public long NextFrame { get; set; } = 0;

    /// <summary>The data encoding for the frame mestadata.</summary>
    public DataEncoding DataEncoding { get; set; }

    /// <inheritdoc/>
    protected override void Disposing() {
        Stream.Dispose();
        base.Disposing();
        }



    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="stream">The stream for reads and appends.</param>
    /// <param name="dataEncoding">The data encoding for control blocks.</param>
    protected VDareSequence(
                VDareStream stream,
            DataEncoding dataEncoding = DataEncoding.JSON) {
        Stream = stream;
        DataEncoding = dataEncoding;
        }


    #region -- Static factory methods Create or open sequence

    /// <summary>Create a new sequence with file name <paramref name="fileName"/> and of
    /// type <paramref name="typeIdentifier"/>.</summary>
    /// <param name="fileName">The file type.</param>
    /// <param name="typeIdentifier">The type identifier.</param>
    /// <returns>The <see cref="VDareSequence"/> instance.</returns>
    public static VDareSequence Create(
                string fileName,
                EarlSequenceIndexType typeIdentifier = EarlSequenceIndexType.None) {
        var stream = VDareStream.Create(fileName, DareConstants.TypeIdentifierDareSequence);
        var result = new VDareSequence(stream);

        result.WriteInitial();

        return result;
        }

    /// <summary>Open an existing sequene in file <paramref name="fileName"/></summary>
    /// <param name="fileName">The file type.</param>
    /// <returns>The <see cref="VDareSequence"/> instance.</returns>
    public static VDareSequence Open(
            string fileName) {

        var stream = VDareStream.OpenReadWrite(fileName);
        var sequence = new VDareSequence(stream);
        //sequence.ReadInitial(fillIndex);

        return sequence;
        }

    ///// <summary>Initialize a newly opened sequence.</summary>
    //protected virtual void Initialize() {


    //    if (Stream.Length == 0) {
    //        Stream.Write(DareConstants.TypeIdentifierDareSequence);
    //        WriteInitial();
    //        StartEntries = Stream.Position;
    //        }
    //    else {
    //        ReadInitial();
    //        }
    //    }

    /// <summary>Write the initial sequence record.</summary>
    protected virtual void WriteInitial() {
        // Create the initial record
        var unprotected = new Unprotected();
        var contentMeta = GetContentMeta();
        var payload = Array.Empty<byte>();

        FrameFirst = new EarlEnvelope(unprotected, contentMeta, null, payload);
        Append(FrameFirst);
        }


    /// <summary>Read the initial sequence record.</summary>
    protected virtual void ReadInitial() {
        BeginReadInitial();


        if (!Stream.EOF) {
            IndexFirst = Stream.ReadIndexNext();
            }
        if (!Stream.EOF) {
            Stream.SeekEnd();
            IndexLast = Stream.ReadIndexPrevious();
            }

        Stream.Position = StartEntries;
        }

    /// <summary>Read type identifier and first frame.</summary>
    protected void BeginReadInitial() {
        // read the type identifier
        var version = Stream.ReadTypeIdentifier();
        (version == DareConstants.TypeIdentifierDareSequenceL).AssertTrue(NYI.Throw);

        // read the first record
        FrameFirst = Stream.ReadFrameNext();
        StartEntries = Stream.Position;
        }


    /// <summary>Fill the index immediately after opening the file.</summary>
    protected virtual void FillIndex() {


        


        }


    /// <summary>Return an empty <see cref="ContentMeta"/> instance.</summary>
    /// <returns>The created instance.</returns>
    protected virtual ContentMeta GetContentMeta () => new ();



    #endregion

    #region -- File handling method


    /// <summary>Close the underlying file stream, is used to save file stream 
    /// handles.</summary>
    public void CloseStream() {

        Stream.CloseStream();
        }

    #endregion

    #region -- Append entry methods

    /// <summary>Append the envelope <paramref name="entry"/> to the sequence.</summary>
    /// <param name="entry">The entry to append.</param>
    /// <returns>Index of the entry that was added.</returns>
    public VDareEntryIndex Append(
                EarlEnvelope entry) => Stream.Append(entry, NextFrame++);

    /// <summary>Serialize the object <paramref name="obj"/> as an object of type 
    /// <typeparamref name="T"/> using encoding <paramref name="dataEncoding"/>
    /// and append it to the sequece with content metadata <paramref name="contentMeta"/>.</summary>
    /// <typeparam name="T">The type of the data to add the object as.</typeparam>
    /// <param name="obj">The object to add.</param>
    /// <param name="contentMeta">Content metadata.</param>
    /// <param name="index">If true, index the entry.</param>
    /// <param name="dataEncoding">The data encoding for the object.</param>
    /// <returns>The entry index for the added envelope.</returns>
    public VDareEntryIndex<T> Append<T>(
                T? obj,
                ContentMeta contentMeta = null,
                bool index = false,
                DataEncoding dataEncoding = DataEncoding.Default) where T : JsonObject {

        dataEncoding.Default(DataEncoding);
        var bytes = obj == null ? [] : obj.GetBytes(dataEncoding: dataEncoding);

        var append = AppendInner(bytes, contentMeta, index);
        return new VDareEntryIndex<T>(append.Item1, append.Item2, append.Item3,
                append.Item4, bytes.LongLength) { 
            JsonObject = obj
            };
        }

    /// <summary>Append the entry data <paramref name="entry"/> to the sequence
    /// with content metadata <paramref name="contentMeta"/>.</summary>
    /// <param name="entry">The payload to add.</param>
    /// <param name="contentMeta">Content metadata.</param>
    /// <param name="index">If true, index the entry.</param>
    /// <returns>The entry index for the added envelope.</returns>
    public VDareEntryIndex Append(
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

    /// <summary>Begin appending an envelope.</summary>
    /// <param name="payloadLength">The length of the payload section.</param>
    /// <param name="contentMeta">The content metadata.</param>
    /// <param name="index">If true, index the entry.</param>
    /// <returns>The frame number, position of first byte of the frame, total length, position of 
    /// the first byte of the content.</returns>
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

    /// <summary>Append the payload after beginning a frame with <see cref="AppendStart"/>.</summary>
    /// <param name="payload">The data to append.</param>
    /// <param name="offset">Offset within the data.</param>
    /// <param name="length">Number of bytes to append.</param>
    public virtual void AppendPayload(
                byte[] payload, int offset, int length) => Stream.AppendEntryPayload(payload, offset, length);

    /// <summary>Close an entry.</summary>
    public virtual void AppendEnd() => Stream.AppendEntryEnd([]);

    #endregion
    #region -- Read Methods










    //public EarlEntryIndex? ReadIndexAt (long position, bool includePayload) {
    //        throw new NYI(); 
    //    }

    //public EarlEnvelope? ReadEntryAt(long position) {
    //    var index = ReadIndexAt(position, true);
    //    return index?.EarlEnvelope;
    //    }



    //public EarlEnvelope ReadFirst() {

    //    return null;
    //    }

    //public EarlEnvelope ReadLast() {

    //    return null;
    //    }


    ///// <summary>Return entry indicated by <paramref name="index"/>.
    ///// <para>If <paramref name="index"/> is zero, the first item in the sequence is returned. </para>
    ///// <para>If <paramref name="index"/> is positive, the (<paramref name="index"/>-1)th
    ///// entry counting from the first is returned.</para>
    ///// <para>If <paramref name="index"/> is negative, the (<paramref name="index"/>+1)th
    ///// entry counting from the last and traversing backwards is returned..</para>
    ///// </summary>
    ///// <param name="index"></param>
    ///// <returns>The envelope value.</returns>
    //public EarlEnvelope? ReadEntry(long index) {

    //    return null;
    //    }

    /// <summary>Read the next entry in the sequence.</summary>
    /// <returns></returns>
    public EarlEnvelope? ReadNext() {

        return Stream.ReadFrameNext();
        }




    //public EarlEnvelope? ReadPrevious() {

    //    return null;
    //    }

    //public EarlEnvelope Read(EarlEntryIndex index) {

    //    return null;
    //    }

    /// <summary>Return the payload data for the entry described by <paramref name="index"/>
    /// parsing it as data of type <typeparamref name="T"/></summary>
    /// <typeparam name="T">The type to parse the data as.</typeparam>
    /// <param name="index">The index describing the entry position.</param>
    /// <returns>The parse result.</returns>
    public T GetValue<T>(VDareEntryIndex index) where T : JsonObject{
        // check content meta is this a 

        var bytes = Stream.GetPayload(index);

        //var asChar = bytes.ToUTF8();

        var result = JsonObject.StreamParseTag<T>(bytes, true);
        return result;
        }




    #endregion


    #region -- Indexed retrieval



    //public EarlEntryIndex? IndexNext(
    //                EarlEntryIndex index,
    //                bool forward=true) {

    //    return null;
    //    }

    //public EarlEntryIndex? IndexPrevious() {

    //    return null;
    //    }

    #endregion




    #region -- Enumerators

    /// <summary>Return an enumerator over the sequence in the forward direction.</summary>
    /// <returns>The enumerator.</returns>
    public virtual IEnumerable<VDareEntryIndex> EntriesForward() => new VEntryEnumerator(this);

    /// <summary>Return an enumerator over the sequence in the reverse direction.</summary>
    /// <returns>The enumerator.</returns>
    public virtual IEnumerable<VDareEntryIndex> EntriesReverse() => new VEntryEnumerator(this, false);

    #endregion
    }


/// <summary>Typed sequence.</summary>
/// <typeparam name="T"></typeparam>
public class VDareSequence<T> : VDareSequence where T : JsonObject {


    /// <summary>Index record of the first entry in the sequence.</summary>
    public override VDareEntryIndex? IndexFirst => IndexFirstT;

    /// <summary>Index record of the first entry in the sequence.</summary>
    public VDareEntryIndex<T>? IndexFirstT { get; protected set; }


    /// <summary>Index record of the last entry in the sequence.</summary>
    public override VDareEntryIndex? IndexLast => IndexLastT;


    /// <summary>Index record of the first entry in the sequence.</summary>
    public VDareEntryIndex<T>? IndexLastT { get; protected set; }


    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="stream">The stream for reads and appends.</param>
    /// <param name="dataEncoding">The data encoding for control blocks.</param>
    protected VDareSequence(
                VDareStream stream,
            DataEncoding dataEncoding = DataEncoding.JSON) : base (stream, dataEncoding) {

        }

    /// <summary>Read the initial sequence record.</summary>
    protected override void ReadInitial() {
        BeginReadInitial();

        if (!Stream.EOF) {
            IndexFirstT = Stream.ReadIndexNext<T>();
            }
        if (!Stream.EOF) {
            Stream.SeekEnd();
            IndexLastT = Stream.ReadIndexPrevious<T>();
            }
        else {
            IndexLastT = IndexFirstT;
            }

        Stream.Position = StartEntries;
        }


    //protected void FillIndex() {
    //    BeginReadInitial();


    //    }


    }