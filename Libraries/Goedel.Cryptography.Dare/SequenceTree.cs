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
    /// Dictionary of frame index to frame position. OBSOLETE REMOVE
    /// </summary>
    public Dictionary<long, long> FrameIndexToPositionDictionary =
        new();


    /// <summary>
    /// Get or set the read position in the stream.
    /// </summary>
    protected new long PositionRead {
        get => JbcdStream.PositionRead;
        set {
            JbcdStream.PositionRead = value;
            }
        }




    /// <summary>
    /// Default constructor
    /// </summary>
    public SequenceTree() {
        }



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

    /// <summary>
    /// Register a frame in the Sequence access dictionaries.
    /// </summary>
    /// <param name="sequenceInfo">First headerData</param>
    /// <param name="position">PositionRead of the frame</param>
    protected virtual void RegisterFrame(SequenceInfo sequenceInfo, long position) {
        var index = sequenceInfo.LIndex;
        FrameIndexToPositionDictionary.AddSafe(index, position);
        }




    ///// <summary>
    ///// Get the frame position.
    ///// </summary>
    ///// <param name="frame">The frame index</param>
    ///// <returns>The frame position.</returns>
    //public virtual long GetFramePosition(long frame) {
    //    FrameIndexToPositionDictionary.TryGetValue(frame, out var position);
    //    return position;
    //    }

    #region // Sequence navigation

    SequenceIndexEntry GetPrevious(SequenceIndexEntry entry) {
        var previous = PreviousFrame(entry.Index);

        if (FrameIndexToEntry.TryGetValue(previous, out var result)) {
            return result;
            }
        return ReadAtPosition(entry.TreePosition ?? 0);
        }

    ///<inheritdoc/>
    public override SequenceIndexEntry Frame(long index) {
        if (FrameIndexToEntry.TryGetValue(index, out var entry)) {
            return entry;
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

        var index = SequenceIndexEntryLast.Index;
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

    ///// <summary>
    ///// Move to the specified frame index.
    ///// </summary>
    ///// <param name="index">First index to move to</param>
    ///// <returns>If the move to the specified index succeeded, returns <code>true</code>.
    ///// Otherwise, returns <code>false</code>.</returns>
    //public bool Move(long index) {
    //    MoveToIndex(index);
    //    return Next();
    //    }

    /// <summary>
    /// Move to the frame with index PositionRead in the file. 
    /// </summary>
    /// <param name="index">The frame index to move to</param>
    /// <returns>If success, the frame index.</returns>
    public virtual bool MoveToIndex(long index) {
        if (index == FrameCount) {
            JbcdStream.PositionRead = JbcdStream.Length;
            return false;
            }

        if (FrameIndexToPositionDictionary.TryGetValue(index, out var position)) {
            JbcdStream.PositionRead = position;
            return true;
            //return Next();
            }

        //Obtain the position of the very last record in the file, this must be known.
        var Record = FrameCount - 1;
        Assert.AssertTrue(FrameIndexToPositionDictionary.TryGetValue(Record, out position), SequenceDataCorrupt.Throw);

        long nextRecord;
        bool found = true;

        //Console.WriteLine("Move to {0}", Index);

        while (Record > index) {
            DareHeader frameHeader;
            long nextPosition;

            if (PreviousFrame(Record) < index) {
                // The record we want is the one before the current frame
                nextRecord = Record - 1;

                if (!FrameIndexToPositionDictionary.TryGetValue(nextRecord, out nextPosition)) {
                    // we do not know the position of the next frame
                    if (!found) {
                        JbcdStream.PositionRead = position;
                        frameHeader = JbcdStream.ReadFrameHeader();
                        RegisterFrame(frameHeader.SequenceInfo, position);
                        }

                    PositionRead = position;
                    JbcdStream.Previous();
                    nextPosition = JbcdStream.PositionRead;

                    frameHeader = JbcdStream.ReadFrameHeader();
                    Assert.AssertTrue(frameHeader.SequenceInfo.LIndex == nextRecord, SequenceDataCorrupt.Throw);

                    found = false;
                    }
                else {
                    found = true;
                    }

                }
            else {
                nextRecord = PreviousFrame(Record);
                if (!FrameIndexToPositionDictionary.TryGetValue(nextRecord, out nextPosition)) {
                    // we do not know the position of the next frame

                    PositionRead = position;
                    frameHeader = JbcdStream.ReadFrameHeader();
                    nextPosition = frameHeader.SequenceInfo.TreePosition ??0;

                    if (!found) {
                        RegisterFrame(frameHeader.SequenceInfo, position);
                        }
                    found = false;
                    }
                else {
                    found = true;
                    }

                }

            position = nextPosition;
            Record = nextRecord;

            //Console.WriteLine("    {0}: {1}", Record, PositionRead);
            }

        PositionRead = position;
        return true;
        //return Next();
        }


    /// <summary>
    /// Get the frame position.
    /// </summary>
    /// <param name="frame">The frame index</param>
    /// <returns>The frame position.</returns>
    public  long GetFramePosition(long frame) {
        //var Found2 = FrameIndexToPositionDictionary.TryGetValue(frame, out var Position);

        var Found = FrameIndexToEntry.TryGetValue(frame, out var entry);
        var Position = entry.FramePosition;

        if (!Found) {

            }

        return Position;

        }


    /// <summary>
    /// Returns the start position of the prior frame in the tree.
    /// </summary>
    /// <param name="frameIndex">The First Index</param>
    /// <returns>The position of the frame.</returns>
    public long PreviousFramePosition(long frameIndex) {
        var Previous = PreviousFrame(frameIndex);

        //Console.WriteLine($"  Previous {FrameIndex} = {Previous}");

        return GetFramePosition(Previous);
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
            var Position = JbcdStream.PositionRead;
            header = JbcdStream.ReadFrameHeader();
            headerDictionary.Add(Position, header);

            Assert.AssertTrue(header.SequenceInfo.LIndex == index, SequenceDataCorrupt.Throw);
            if (index > 1) {
                var Previous = PreviousFrame(index);
                Assert.AssertTrue(headerDictionary.TryGetValue(
                            header.SequenceInfo.TreePosition ?? 0, out var PreviousHeader),
                    SequenceDataCorrupt.Throw);
                Assert.AssertTrue(PreviousHeader.SequenceInfo.LIndex == Previous,
                    SequenceDataCorrupt.Throw);
                }


            index++;
            }


        }

    #endregion
    }
