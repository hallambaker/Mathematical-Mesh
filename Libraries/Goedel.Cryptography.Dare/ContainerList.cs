using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Utilities;
using Goedel.Protocol;
using Goedel.IO;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;

namespace Goedel.Cryptography.Dare {



    /// <summary>
    /// Simple container that supports the append and index functions but does not 
    /// provide for linked cryptographic integrity.
    /// </summary>
    /// <threadsafety static="true" instance="false"/>
    public class ContainerList : Container {

        /// <summary>
        /// The label for the container type for use in header declarations
        /// </summary>
        public const string Label = "List";


        ///// <summary>
        ///// The digest provider used to calculate the tree value. [OBSOLETE, to be removed]
        ///// </summary>
        //public CryptoProviderDigest DigestProvider { get; set; } = null;



        /// <summary>
        /// Create a new container file of the specified type and write the initial
        /// data record
        /// </summary>
        /// <param name="JBCDStream">The underlying JBCDStream stream. This MUST be opened
        /// in a read access mode and should have exclusive read access. All existing
        /// content in the file will be overwritten.</param>
        /// <returns>The newly constructed container.</returns>

        public static Container MakeNewContainer(
                        JBCDStream JBCDStream) {

            var containerInfo = new ContainerInfo() {
                ContainerType = Label,
                Index = 0
                };


            var containerHeader = new DareHeader() {
                ContainerInfo = containerInfo
                };

            var container = new ContainerList() {
                JBCDStream = JBCDStream,
                ContainerHeaderFirst = containerHeader
                };

            return container;
            }




        // The high and low boundaries of the unknown region.
        long FrameLowUnknown = 0;
        long FrameHighUnknown = 0;

        /// <summary>
        /// Initialize the dictionaries used to manage the tree by registering the set
        /// of values leading up to the apex value.
        /// </summary>
        /// <param name="containerInfo">Final frame header container information.</param>
        /// <param name="firstPosition">Position of frame 1</param>
        /// <param name="positionLast">Position of the last frame</param>
        protected override void FillDictionary(ContainerInfo containerInfo, long firstPosition, long positionLast) {


            FrameIndexToPositionDictionary.Add(0, 0);
            if (containerInfo.Index == 0) {
                FrameLowUnknown = 0;
                FrameHighUnknown = 0;
                return;
                }

            FrameIndexToPositionDictionary.Add(1, firstPosition);
            FrameLowUnknown = 1;

            if (containerInfo.Index == 1) {
                FrameHighUnknown = 1;
                return;
                }

            FrameHighUnknown = containerInfo.Index;
            RegisterFrame(containerInfo, positionLast);
            }



        /// <summary>
        /// Prepare the data to be incorporated into the header.
        /// </summary>
        public override void PrepareFrame(ContainerWriter contextWrite) { }

        /// <summary>
        /// Commit the header data to the container.
        /// </summary>
        public override void CommitHeader(DareHeader containerHeader, ContainerWriter contextWrite) =>
            FrameIndexToPositionDictionary.Add(containerHeader.ContainerInfo.Index,
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
        long FrameReadStartPosition = -1;

        /// <summary>
        /// Get or set the read position in the stream.
        /// </summary>
        protected long PositionRead {
            get => JBCDStream.PositionRead;
            set {
                FrameReadStartPosition = -1;
                JBCDStream.PositionRead = value;
                }
            }

        void PositionStream() {
            if (FrameReadStartPosition >=0) {
                JBCDStream.PositionRead = FrameReadStartPosition;
                FrameReadStartPosition = -1;
                }
            }

        long FrameRemaining;

        #region // Container navigation

        /// <summary>
        /// Obtain a ContainerFrameIndex instance for <paramref name="index"/> if
        /// specified or <paramref name="position"/> otherwise.
        /// </summary>
        /// <param name="index">The container index to obtain the frame index for.</param>
        /// <param name="position">The container position to obtain the frame index for.</param>
        /// <returns>The created ContainerFrameIndex instance,</returns>
        public override ContainerFrameIndex GetContainerFrameIndex(
                    long index = -1, 
                    long position = -1) {
            if (position < 0 & index >= 0) {
                MoveToIndex(index);
                position = PositionRead;
                }
            return new ContainerFrameIndex(JBCDStream, KeyCollection, Position: position);


            }



        /// <summary>
        /// Read the next frame in the file.
        /// </summary>
        /// <returns>True if a next frame exists, otherwise false</returns>
        public override bool NextFrame() => JBCDStream.FramerNext();

        /// <summary>
        /// Read the next frame in the file.
        /// </summary>
        /// <returns>True if a next frame exists, otherwise false</returns>
        public override bool PreviousFrame() => JBCDStream.FramerPrevious();

        ///// <summary>
        ///// Begin reading record data. This method is called before ReadData
        ///// to move the read pointer to the start of the payload data.
        ///// </summary>
        ///// <returns></returns>
        //public override long ReadDataBegin() {
        //    PayloadData = JBCDStream.ReadRecordBegin(ref FrameRemaining);
        //    return PayloadData;
        //    }


        /// <summary>
        /// Read the next frame in the file.
        /// </summary>
        /// <returns>True if a next frame exists, otherwise false</returns>
        protected virtual bool Next () {
            PositionStream();

            var RecordStart = PositionRead;

            //_FrameData = null;
            FrameRemaining = JBCDStream.ReadFrame(out var FrameHeader);
            FrameReadStartPosition = PositionRead;

            this.FrameHeader = FrameHeader;


            if (FrameHeader != null) {
                var Index = ContainerHeader.ContainerInfo.Index;
                if (!FrameIndexToPositionDictionary.TryGetValue(Index, out _)) {
                    FrameIndexToPositionDictionary.Add(Index, RecordStart);
                    }
                }


            return FrameRemaining >= 0;
            }

        /// <summary>
        /// Read the previous frame in the file and leave the read pointer positioned at the start
        /// of the frame just read.
        /// </summary>
        /// <returns>True if a previous frame exists, otherwise false</returns>
        public override bool Previous () {
            PositionStream();

            FrameRemaining = JBCDStream.ReadFrameReverse(out var FrameHeader);
            FrameReadStartPosition = PositionRead;

            this.FrameHeader = FrameHeader;
            if (FrameHeader != null) {
                var Index = ContainerHeader.ContainerInfo.Index;
                if (!FrameIndexToPositionDictionary.TryGetValue(Index, out _)) {
                    FrameIndexToPositionDictionary.Add(Index, FrameReadStartPosition);
                    }
                }

            return FrameRemaining >= 0;
            }

        /// <summary>
        /// Move to the frame with index Position in the file. 
        /// <para>Since the file format only supports sequential access, this is slow.</para>
        /// </summary>
        /// <param name="index">The frame index to move to</param>
        /// <returns>If success, the frame index.</returns>
        public override bool MoveToIndex (long index) {

            if (FrameIndexToPositionDictionary.TryGetValue(index, out var Position)) {
                PositionRead = Position;
                }
            else {
                Assert.True(index > FrameLowUnknown & index < FrameHighUnknown);

                if (index - FrameLowUnknown <= FrameHighUnknown - index) {
                    Assert.True(FrameIndexToPositionDictionary.TryGetValue(FrameLowUnknown, out Position));
                    PositionRead = Position;
                    var Last = PositionRead;
                    Next();
                    while (ContainerInfo != null && ContainerInfo.Index < index) {
                        Last = PositionRead;
                        Next();
                        }
                    PositionRead = Last;
                    FrameLowUnknown = ContainerInfo.Index;
                    return ContainerInfo.Index == index;
                    }

                else {
                    Assert.True(FrameIndexToPositionDictionary.TryGetValue(FrameHighUnknown, out Position));
                    PositionRead = Position;

                    Previous();
                    while (ContainerInfo != null && (ContainerInfo.Index > index)) {
                        Previous();
                        }

                    FrameHighUnknown = ContainerInfo.Index;
                    return ContainerInfo.Index == index;
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
        public override void CheckContainer (List<DareHeader> headers) {
            int Index = 1;
            foreach (var Header in headers) {
                Assert.NotNull(Header.ContainerInfo);

                Assert.True(Header.ContainerInfo.Index == Index);

                if (ContainerHeaderFirst.ContainerInfo.ContainerType == Label) {
                    Assert.Null(Header.PayloadDigest);
                    }
                else {
                    Assert.NotNull(Header.PayloadDigest);
                    }
                Index++;
                }
            }
        #endregion 
        }
    }
