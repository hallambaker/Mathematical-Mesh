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

    public SequenceList(bool decrypt) : base(decrypt) {
        }




    // The lowest 
    long frameIndexUnknownLow = 0;
    long frameHighUnknown = 0;


    protected override void FillDictionary() {
        }


    /// <summary>
    /// Initialize the dictionaries used to manage the tree by registering the set
    /// of values leading up to the apex value.
    /// </summary>
    /// <param name="containerInfo">Final frame header Sequence information.</param>
    /// <param name="firstPosition">PositionRead of frame 1</param>
    /// <param name="positionLast">PositionRead of the last frame</param>
    protected override void FillDictionary(SequenceInfo containerInfo, long firstPosition, long positionLast) {


        FrameIndexToPositionDictionary.Add(0, 0);
        if (containerInfo.LIndex == 0) {
            frameIndexUnknownLow = 0;
            frameHighUnknown = 0;
            return;
            }

        FrameIndexToPositionDictionary.Add(1, firstPosition);
        frameIndexUnknownLow = 1;

        if (containerInfo.LIndex == 1) {
            frameHighUnknown = 1;
            return;
            }

        frameHighUnknown = containerInfo.LIndex;
        RegisterFrame(containerInfo, positionLast);
        }



    /// <summary>
    /// Prepare the data to be incorporated into the header.
    /// </summary>
    public override void PrepareFrame(SequenceWriter contextWrite) { }

    /// <summary>
    /// Commit the header data to the Sequence.
    /// </summary>
    public override void CommitHeader(DareHeader containerHeader, SequenceWriter contextWrite) =>
        FrameIndexToPositionDictionary.Add(containerHeader.SequenceInfo.LIndex,
                contextWrite.FrameStart);


    /// <summary>
    /// The number of bytes to be reserved for the trailer.
    /// </summary>
    /// <returns>The number of bytes to reserve</returns>
    public override DareTrailer FillDummyTrailer(CryptoStack cryptoStack) =>
        cryptoStack?.GetDummyTrailer();


    /// <summary>If positive, specifies the file position of the next frame.
    /// This is used to store an index to be applied to the file pointer before 
    /// a Next or Previous method operates on the stream.</summary>
    long frameReadStartPosition = -1;

    /// <summary>
    /// Get or set the read position in the stream.
    /// </summary>
    protected long PositionRead {
        get => JbcdStream.PositionRead;
        set {
            frameReadStartPosition = -1;
            JbcdStream.PositionRead = value;
            }
        }

    void PositionStream() {
        if (frameReadStartPosition >= 0) {
            JbcdStream.PositionRead = frameReadStartPosition;
            frameReadStartPosition = -1;
            }
        }

    long frameRemaining;

    #region // Sequence navigation





    ///// <summary>
    ///// Read the next frame in the file.
    ///// </summary>
    ///// <returns>True if a next frame exists, otherwise false</returns>
    //public override bool NextFrame() => JbcdStream.FramerNext();

    ///// <summary>
    ///// Read the next frame in the file.
    ///// </summary>
    ///// <returns>True if a next frame exists, otherwise false</returns>
    //public override bool PreviousFrame() => JbcdStream.FramerPrevious();


    /// <summary>
    /// Read the next frame in the file.
    /// </summary>
    /// <returns>True if a next frame exists, otherwise false</returns>
    protected virtual bool Next() {
        PositionStream();

        var RecordStart = PositionRead;

        //_FrameData = null;
        frameRemaining = JbcdStream.ReadFrame(out var FrameHeader);
        frameReadStartPosition = PositionRead;

        this.HeaderBytes = FrameHeader;


        if (FrameHeader != null) {
            var Index = Header.SequenceInfo.LIndex;
            if (!FrameIndexToPositionDictionary.TryGetValue(Index, out _)) {
                FrameIndexToPositionDictionary.Add(Index, RecordStart);
                }
            }


        return frameRemaining >= 0;
        }

    /// <summary>
    /// Read the previous frame in the file and leave the read pointer positioned at the start
    /// of the frame just read.
    /// </summary>
    /// <returns>True if a previous frame exists, otherwise false</returns>
    public override bool Previous() {
        PositionStream();

        frameRemaining = JbcdStream.ReadFrameReverse(out var FrameHeader);
        frameReadStartPosition = PositionRead;

        this.HeaderBytes = FrameHeader;
        if (FrameHeader != null) {
            var Index = Header.SequenceInfo.LIndex;
            if (!FrameIndexToPositionDictionary.TryGetValue(Index, out _)) {
                FrameIndexToPositionDictionary.Add(Index, frameReadStartPosition);
                }
            }

        return frameRemaining >= 0;
        }

    /// <summary>
    /// Move to the frame with index PositionRead in the file. 
    /// <para>Since the file format only supports sequential access, this is slow.</para>
    /// </summary>
    /// <param name="index">The frame index to move to</param>
    /// <returns>If success, the frame index.</returns>
    public override bool MoveToIndex(long index) {

        if (FrameIndexToPositionDictionary.TryGetValue(index, out var position)) {
            PositionRead = position;
            }
        else {
            Assert.AssertTrue(index > frameIndexUnknownLow & index < frameHighUnknown, SequenceDataCorrupt.Throw);

            if (index - frameIndexUnknownLow <= frameHighUnknown - index) {
                Assert.AssertTrue(FrameIndexToPositionDictionary.TryGetValue(
                    frameIndexUnknownLow, out position), SequenceDataCorrupt.Throw);
                PositionRead = position;
                var Last = PositionRead;
                Next();
                while (SequenceInfo != null && SequenceInfo.LIndex < index) {
                    Last = PositionRead;
                    Next();
                    }
                PositionRead = Last;
                frameIndexUnknownLow = SequenceInfo.LIndex;
                return SequenceInfo.LIndex == index;
                }

            else {
                Assert.AssertTrue(
                    FrameIndexToPositionDictionary.TryGetValue(frameHighUnknown, out position),
                    SequenceDataCorrupt.Throw);
                PositionRead = position;

                Previous();
                while (SequenceInfo != null && (SequenceInfo.LIndex > index)) {
                    Previous();
                    }

                frameHighUnknown = SequenceInfo.LIndex;
                return SequenceInfo.LIndex == index;
                }
            }
        return true;
        //return Next();

        }

    #endregion

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
