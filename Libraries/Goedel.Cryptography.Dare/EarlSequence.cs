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





public record EarlEntryIndex(
        long Frame,
        long Start,
        long Length,
        long PayloadStart,
        long PayloadEnd,
        string Id) {

    public EarlEnvelope? EarlEnvelope { get; set; } = null;

    }


public  class EarlSequence  {

    Dictionary<string, EarlEntryIndex> DictionaryById = [];

    Dictionary<long, EarlEntryIndex> DictionaryByFrame = [];

    long UnreadStart { get; set; } = 0;
    long UnreadEnd { get; set; } = long.MaxValue;


    /// <summary>Index record of the first entry in the sequence.</summary>
    public EarlEntryIndex? IndexFirst { get; private set; }


    /// <summary>Index record of the last entry in the sequence.</summary>
    public EarlEntryIndex? IndexLast{ get; private set; }

    public string Filename { get; init; }

    Stream Stream => stream ?? OpenStream().CacheValue(out stream);
    Stream? stream = null;



    /// <summary>
    /// Constructor
    /// </summary>
    EarlSequence(
                string fileName) {
        Filename = fileName;
        }


    #region -- Static factory methods Create or open sequence

    public static EarlSequence Create(
                string fileName,
                EarlSequenceIndexType indexType = EarlSequenceIndexType.None) {

        var result = new EarlSequence(fileName);
        result.Stream.Write(DareConstants.TypeIdentifierDareSequence);

        // Create the initial record

        return result;
        }


    public static EarlSequence Open(
            string fileName) {

        return null;
        }

    #endregion

    #region -- File handling method

    private Stream OpenStream() => Filename.OpenFileReadWrite();


    /// <summary>Close the underlying file stream, is used to save file stream 
    /// handles.</summary>
    public void CloseStream() {
        stream?.Close();
        stream = null;
        }

    #endregion

    #region -- Append entry methods
    public EarlEntryIndex Append(
                EarlEnvelope entry) {
        
        // save for later.
        throw new NYI();
        }

    public EarlEntryIndex Append(
                ContentMeta contentMeta,
                byte[] entry,
                bool index = false) {

        var result = AppendStart(contentMeta, entry.LongLength, index);
        AppendPayload(entry);
        AppendEnd();

        return null;
        }

    public EarlEntryIndex AppendStart(
                ContentMeta contentMeta,
                long length,
                bool index = false) {

        return null;
        }


    public long AppendPayload(
                byte[] payload) {

        return -1;
        }

    public long AppendEnd() {

        return -1;
        }
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

        return null;
        }

    public EarlEnvelope? ReadPrevious() {

        return null;
        }

    public EarlEnvelope Read(EarlEntryIndex index) {

        return null;
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

    public virtual bool TryGetEntry(string id, out EarlEntryIndex? index) {

        if (DictionaryById.TryGetValue(id, out index)) {
            return true;
            }

        if (UnreadStart >= UnreadEnd) {
            index = null;
            return false;
            }

        // sequence not read, abort.
        throw new NYI();
        }

    //public bool TryGetEntry(string key, string value, out EarlEntryIndex? index) {
    //    index = null;
    //    return false;
    //    }


    #endregion


    }


