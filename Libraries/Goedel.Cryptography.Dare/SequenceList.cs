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
/// Simple Sequence that supports the append and index functions but does not 
/// provide for linked cryptographic integrity.
/// </summary>
/// <threadsafety static="true" instance="false"/>
public class SequenceList : Sequence {

    /// <summary>
    /// Default constructor
    /// </summary>

    public SequenceList() {
        }





    ///<inheritdoc/>
    protected override void FillDictionary() {
        IndexedFromStart = SequenceIndexEntryFirst;
        IndexedFromEnd = SequenceIndexEntryLast;
        Intern(SequenceIndexEntryFirst);
        if (SequenceIndexEntryFirst.Index != SequenceIndexEntryLast.Index) {
            Intern(SequenceIndexEntryLast);
            }
        }

    ///<inheritdoc/>
    public override SequenceIndexEntry Frame(long index, bool skip = true) {
        if (FrameIndexToEntry.TryGetValue(index, out var entry)) {
            return entry;
            }

        // check to see if we are trying to read past the end of the sequence.
        if (index > SequenceIndexEntryLast.Index) {
            return null;
            }


        var fromStart = index - IndexedFromStart.Index;
        var fromEnd = IndexedFromEnd.Index - index;

        if (fromStart <= fromEnd) {
            do {
                entry = IndexedFromStart.Next();
                if (entry.Index == index) {
                    return entry;
                    }
                }
            while (entry != null && entry.Index < index);
            }
        else {
            do {
                entry = IndexedFromEnd.Previous();
                if (entry.Index == index) {
                    return entry;
                    }
                }
            while (entry != null && entry.Index > index);
            }

        return null;
        }

    ///<inheritdoc/>
    public override SequenceIndexEntry FrameLast() => SequenceIndexEntryLast;

    ///<inheritdoc/>
    public override SequenceIndexEntry Position(long position) {
        if (SequencePositionStartToEntry.TryGetValue(position, out var entry)) {
            return entry;
            }
        return ReadAtPosition(position);
        }

    ///<inheritdoc/>
    protected override void Intern(SequenceIndexEntry indexEntry, bool previous) {
        base.Intern(indexEntry);

        if (previous) {
            if (indexEntry.Index < IndexedFromEnd.Index) {
                IndexedFromEnd = indexEntry;
                }
            }
        else {
            if (indexEntry.Index > IndexedFromStart.Index) {
                IndexedFromStart = indexEntry;
                }
            }
        }



    /// <summary>
    /// Initialize the dictionaries used to manage the tree by registering the set
    /// of values leading up to the apex value.
    /// </summary>
    /// <param name="containerInfo">Final frame header Sequence information.</param>
    /// <param name="firstPosition">PositionRead of frame 1</param>
    /// <param name="positionLast">PositionRead of the last frame</param>
    protected override void FillDictionary(SequenceInfo containerInfo, long firstPosition, long positionLast) {
        //FrameIndexToPositionDictionary.Add(0, 0);
        //if (containerInfo.LIndex == 0) {
        //    frameIndexUnknownLow = 0;
        //    frameHighUnknown = 0;
        //    return;
        //    }

        //FrameIndexToPositionDictionary.Add(1, firstPosition);
        //frameIndexUnknownLow = 1;

        //if (containerInfo.LIndex == 1) {
        //    frameHighUnknown = 1;
        //    return;
        //    }

        //frameHighUnknown = containerInfo.LIndex;
        //RegisterFrame(containerInfo, positionLast);
        }

    /// <summary>
    /// Prepare the data to be incorporated into the header.
    /// </summary>
    public override void PrepareFrame(SequenceWriter contextWrite) { }

    ///// <summary>
    ///// Commit the header data to the Sequence.
    ///// </summary>
    //public override void CommitHeader(DareHeader containerHeader, SequenceWriter contextWrite) =>
    //            throw new NYI();

    //FrameIndexToPositionDictionary.Add(containerHeader.SequenceInfo.LIndex,
    //        contextWrite.FrameStart);


    /// <summary>
    /// The number of bytes to be reserved for the trailer.
    /// </summary>
    /// <returns>The number of bytes to reserve</returns>
    public override DareTrailer FillDummyTrailer(CryptoStack cryptoStack) =>
        cryptoStack?.GetDummyTrailer();







    #region // Verification
    /// <summary>
    /// Perform sanity checking on a list of Sequence headers.
    /// </summary>
    /// <param name="headers">List of headers to check</param>
    public override void CheckSequence(List<DareHeader> headers) {
        int Index = 1;
        foreach (var Header in headers) {
            Assert.AssertNotNull(Header.SequenceInfo,
                    SequenceDataCorrupt.Throw);

            Assert.AssertTrue(Header.SequenceInfo.LIndex == Index,
                    SequenceDataCorrupt.Throw);

            if (HeaderFirst.SequenceInfo.ContainerType == DareConstants.SequenceTypeListTag) {
                Assert.AssertNull(Header.PayloadDigest, SequenceDataCorrupt.Throw);
                }
            else {
                Assert.AssertNotNull(Header.PayloadDigest, SequenceDataCorrupt.Throw);
                }
            Index++;
            }
        }
    #endregion
    }
