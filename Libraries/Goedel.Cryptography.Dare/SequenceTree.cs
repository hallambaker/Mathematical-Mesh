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

using System;

namespace Goedel.Cryptography.Dare;

/// <summary>
/// Simple Sequence that supports the append and index functions but does not 
/// provide for cryptographic integrity.
/// </summary>
/// <threadsafety static="true" instance="false"/>
public class SequenceTree : SequenceList {


    /// <summary>
    /// Default constructor
    /// </summary>
    public SequenceTree() {
        }


    ///<inheritdoc/>
    public override void PrepareFrame(DareHeader header, long framePosition) {
        header.SequenceInfo ??= MakeSequenceInfo();
        PrepareFrame(header.SequenceInfo);
        }


    /// <summary>
    /// Append the header to the frame. This is called after the payload data
    /// has been passed using AppendPreprocess.
    /// </summary>
    public override void PrepareFrame(SequenceWriter contextWrite) {
        PrepareFrame(contextWrite.SequenceInfo);
        base.PrepareFrame(contextWrite);
        }

    /// <summary>
    /// Prepare the ContainerInfo data for the frame.
    /// </summary>
    /// <param name="containerInfo">The frame to prepare.</param>
    protected override void PrepareFrame(SequenceInfo containerInfo) {
        if (containerInfo.LIndex > 0) {
            containerInfo.TreePosition =
                (int)PreviousFramePosition(containerInfo.LIndex);
            }
        //Console.WriteLine($"Prepare #{containerInfo.Index} @{JBCDStream.PositionWrite} Tree={containerInfo.TreePosition}");

        }

    #region // Sequence navigation

    SequenceIndexEntry GetPrevious(SequenceIndexEntry entry) {
        var previous = PreviousFrame(entry.Index);

        if (FrameIndexToEntry.TryGetValue(previous, out var result)) {
            return result;
            }
        return ReadAtPosition(entry.TreePosition ?? 0);
        }

    ///<inheritdoc/>
    public override SequenceIndexEntry Frame(long index, bool skip = true) {
        if (FrameIndexToEntry.TryGetValue(index, out var entry)) {
            return entry;
            }
        if (index >= FrameCount) {
            return null;
            }


        entry = SequenceIndexEntryLast;
        while (entry.Index > index) {
            var previous = GetPrevious(entry);

            if (previous.Index < index) {
                entry = entry.Previous();
                }
            else {
                entry = previous;
                }
            }

        return entry;


        }


    ///<inheritdoc/>
    protected override void FillDictionary() {
        base.FillDictionary();

        if (SequenceIndexEntryLast.Index <= 1) {
            return;
            }
        var position = SequenceIndexEntryLast;

        while (!IsApex(position.Index)) {
            var treePosition = position.TreePosition;
            if (treePosition is not null) {
                position = ReadAtPosition((long)treePosition);
                }
            }

        }



    static bool IsApex(long index) {
        if (index == 0) {
            return true;
            }

        while (index != 1) {
            if ((index & 1) == 0) {
                return false;
                }
            index >>= 1;
            }

        return true;
        }



    /// <summary>
    /// Get the frame position.
    /// </summary>
    /// <param name="frame">The frame index</param>
    /// <returns>The frame position.</returns>
    public  long GetFramePosition(long frame) {
        var Found = FrameIndexToEntry.TryGetValue(frame, out var entry);
        var position = entry.FramePosition;

        if (!Found) {

            }

        return position;

        }


    /// <summary>
    /// Returns the start position of the prior frame in the tree.
    /// </summary>
    /// <param name="frameIndex">The First Index</param>
    /// <returns>The position of the frame.</returns>
    public long PreviousFramePosition(long frameIndex) {
        var previous = PreviousFrame(frameIndex);

        //Console.WriteLine($"  previous {FrameIndex} = {previous}");

        return GetFramePosition(previous);
        }

    /// <summary>
    /// Returns the index of the prior frame in the tree.
    /// </summary>
    /// <param name="frame">The frame index</param>
    /// <returns>The preceding frame index.</returns>
    public static long PreviousFrame(long frame) {
        long x2 = frame + 1;
        long d = 1;

        while (x2 > 0) {
            if ((x2 & 1) == 1) {
                return x2 == 1 ? (d / 2) - 1 : frame - d;
                }
            d *= 2;
            x2 /= 2;
            }
        return 0;
        }

    #endregion

    #region // Verification
    /// <summary>
    /// Perform sanity checking on a list of Sequence headers.
    /// </summary>
    /// <param name="headers">List of headers to check</param>
    public override void CheckSequence(List<DareHeader> headers) {
        var index = 1;
        foreach (var Header in headers) {
            Assert.AssertTrue(Header.SequenceInfo.LIndex == index,
                    SequenceDataCorrupt.Throw);
            Assert.AssertNotNull(Header.PayloadDigest,
                    SequenceDataCorrupt.Throw);

            index++;
            }
        }


    /// <summary>
    /// Verify Sequence contents by reading every frame starting with the first and checking
    /// for integrity. This is likely to take a very long time.
    /// </summary>
    public override void VerifySequence() {

        SortedDictionary<long, DareHeader> headerDictionary = new();

        // Check the first frame
        JbcdStream.PositionRead = 0;
        var header = JbcdStream.ReadFirstFrameHeader();
        Assert.AssertTrue(header.SequenceInfo.LIndex == 0, SequenceDataCorrupt.Throw);
        headerDictionary.Add(0, header);

        // Check subsequent frames
        int index = 1;
        while (!JbcdStream.EOF) {
            var position = JbcdStream.PositionRead;
            header = JbcdStream.ReadFrameHeader();
            headerDictionary.Add(position, header);

            Assert.AssertTrue(header.SequenceInfo.LIndex == index, SequenceDataCorrupt.Throw);
            if (index > 1) {
                var previous = PreviousFrame(index);
                Assert.AssertTrue(headerDictionary.TryGetValue(
                            header.SequenceInfo.TreePosition ?? 0, out var PreviousHeader),
                    SequenceDataCorrupt.Throw);
                Assert.AssertTrue(PreviousHeader.SequenceInfo.LIndex == previous,
                    SequenceDataCorrupt.Throw);
                }


            index++;
            }


        }

    #endregion
    }
