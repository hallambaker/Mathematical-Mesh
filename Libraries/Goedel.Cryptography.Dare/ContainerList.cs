using Goedel.Utilities;

using System.Collections.Generic;

namespace Goedel.Cryptography.Dare {



    /// <summary>
    /// Simple container that supports the append and index functions but does not 
    /// provide for linked cryptographic integrity.
    /// </summary>
    /// <threadsafety static="true" instance="false"/>
    public class ContainerList : Sequence {

        /// <summary>
        /// Default constructor
        /// </summary>

        public ContainerList() : base () {
            }

        /// <summary>
        /// Create a new container file of the specified type and write the initial
        /// data record
        /// </summary>
        /// <param name="JBCDStream">The underlying JBCDStream stream. This MUST be opened
        /// in a read access mode and should have exclusive read access. All existing
        /// content in the file will be overwritten.</param>
        /// <returns>The newly constructed container.</returns>

        public static Sequence MakeNewContainer(
                        JbcdStream JBCDStream) {


            var containerInfo = new SequenceInfo() {
                ContainerType = DareConstants.SequenceTypeListTag,
                Index = 0
                };

            var containerHeader = new DareHeader() {
                SequenceInfo = containerInfo
                };

            var container = new ContainerList() {
                JbcdStream = JBCDStream,
                HeaderFirst = containerHeader
                };

            return container;
            }




        // The high and low boundaries of the unknown region.
        long frameLowUnknown = 0;
        long frameHighUnknown = 0;

        /// <summary>
        /// Initialize the dictionaries used to manage the tree by registering the set
        /// of values leading up to the apex value.
        /// </summary>
        /// <param name="containerInfo">Final frame header container information.</param>
        /// <param name="firstPosition">Position of frame 1</param>
        /// <param name="positionLast">Position of the last frame</param>
        protected override void FillDictionary(SequenceInfo containerInfo, long firstPosition, long positionLast) {


            FrameIndexToPositionDictionary.Add(0, 0);
            if (containerInfo.Index == 0) {
                frameLowUnknown = 0;
                frameHighUnknown = 0;
                return;
                }

            FrameIndexToPositionDictionary.Add(1, firstPosition);
            frameLowUnknown = 1;

            if (containerInfo.Index == 1) {
                frameHighUnknown = 1;
                return;
                }

            frameHighUnknown = containerInfo.Index;
            RegisterFrame(containerInfo, positionLast);
            }



        /// <summary>
        /// Prepare the data to be incorporated into the header.
        /// </summary>
        public override void PrepareFrame(SequenceWriter contextWrite) { }

        /// <summary>
        /// Commit the header data to the container.
        /// </summary>
        public override void CommitHeader(DareHeader containerHeader, SequenceWriter contextWrite) =>
            FrameIndexToPositionDictionary.Add(containerHeader.SequenceInfo.Index,
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

        #region // Container navigation

        /// <summary>
        /// Obtain a ContainerFrameIndex instance for <paramref name="index"/> if
        /// specified or <paramref name="position"/> otherwise.
        /// </summary>
        /// <param name="index">The container index to obtain the frame index for.</param>
        /// <param name="position">The container position to obtain the frame index for.</param>
        /// <returns>The created ContainerFrameIndex instance,</returns>
        public override SequenceFrameIndex GetSequenceFrameIndex(
                    long index = -1,
                    long position = -1) {
            if (position < 0 & index >= 0) {
                MoveToIndex(index);
                position = PositionRead;
                }
            return new SequenceFrameIndex(JbcdStream, Position: position);


            }



        /// <summary>
        /// Read the next frame in the file.
        /// </summary>
        /// <returns>True if a next frame exists, otherwise false</returns>
        public override bool NextFrame() => JbcdStream.FramerNext();

        /// <summary>
        /// Read the next frame in the file.
        /// </summary>
        /// <returns>True if a next frame exists, otherwise false</returns>
        public override bool PreviousFrame() => JbcdStream.FramerPrevious();


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
                var Index = Header.SequenceInfo.Index;
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
                var Index = Header.SequenceInfo.Index;
                if (!FrameIndexToPositionDictionary.TryGetValue(Index, out _)) {
                    FrameIndexToPositionDictionary.Add(Index, frameReadStartPosition);
                    }
                }

            return frameRemaining >= 0;
            }

        /// <summary>
        /// Move to the frame with index Position in the file. 
        /// <para>Since the file format only supports sequential access, this is slow.</para>
        /// </summary>
        /// <param name="index">The frame index to move to</param>
        /// <returns>If success, the frame index.</returns>
        public override bool MoveToIndex(long index) {

            if (FrameIndexToPositionDictionary.TryGetValue(index, out var position)) {
                PositionRead = position;
                }
            else {
                Assert.AssertTrue(index > frameLowUnknown & index < frameHighUnknown, SequenceDataCorrupt.Throw);

                if (index - frameLowUnknown <= frameHighUnknown - index) {
                    Assert.AssertTrue(FrameIndexToPositionDictionary.TryGetValue(
                        frameLowUnknown, out position), SequenceDataCorrupt.Throw);
                    PositionRead = position;
                    var Last = PositionRead;
                    Next();
                    while (SequenceInfo != null && SequenceInfo.Index < index) {
                        Last = PositionRead;
                        Next();
                        }
                    PositionRead = Last;
                    frameLowUnknown = SequenceInfo.Index;
                    return SequenceInfo.Index == index;
                    }

                else {
                    Assert.AssertTrue(
                        FrameIndexToPositionDictionary.TryGetValue(frameHighUnknown, out position), 
                        SequenceDataCorrupt.Throw);
                    PositionRead = position;

                    Previous();
                    while (SequenceInfo != null && (SequenceInfo.Index > index)) {
                        Previous();
                        }

                    frameHighUnknown = SequenceInfo.Index;
                    return SequenceInfo.Index == index;
                    }
                }
            return true;
            //return Next();

            }

        #endregion 

        #region // Verification
        /// <summary>
        /// Perform sanity checking on a list of container headers.
        /// </summary>
        /// <param name="headers">List of headers to check</param>
        public override void CheckSequence(List<DareHeader> headers) {
            int Index = 1;
            foreach (var Header in headers) {
                Assert.AssertNotNull(Header.SequenceInfo,
                        SequenceDataCorrupt.Throw);

                Assert.AssertTrue(Header.SequenceInfo.Index == Index, 
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
    }
