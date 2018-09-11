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

            var ContainerHeader = new ContainerHeaderFirst {
                ContainerType = Label
                };

            var Container = new ContainerList() {
                JBCDStream = JBCDStream,
                ContainerHeaderFirst = ContainerHeader
                };

            // initialize the Frame index dictionary

            return Container;


            }




        // The high and low boundaries of the unknown region.
        long FrameLowUnknown = 0;
        long FrameHighUnknown = 0;

        /// <summary>
        /// Initialize the dictionaries used to manage the tree by registering the set
        /// of values leading up to the apex value.
        /// </summary>
        /// <param name="Header">Final frame header</param>
        /// <param name="FirstPosition">Position of frame 1</param>
        /// <param name="PositionLast">Position of the last frame</param>
        protected override void FillDictionary(ContainerHeader Header, long FirstPosition, long PositionLast) {

            FrameIndexToPositionDictionary.Add(0, 0);
            if (Header.Index == 0) {
                FrameLowUnknown = 0;
                FrameHighUnknown = 0;
                return;
                }

            FrameIndexToPositionDictionary.Add(1, FirstPosition);
            FrameLowUnknown = 1;

            if (Header.Index == 1) {
                FrameHighUnknown = 1;
                return;
                }

            FrameHighUnknown = Header.Index;
            RegisterFrame(Header, PositionLast);
            }


        /// <summary>
        /// Append the header to the frame. This is called after the payload data
        /// has been passed using AppendPreprocess.
        /// </summary>
        public override void CompleteHeader() => FrameIndexToPositionDictionary.Add(AppendContainerHeader.Index,
                    JBCDStream.PositionWrite);

        /// <summary>
        /// The number of bytes to be reserved for the trailer.
        /// </summary>
        /// <returns>The number of bytes to reserve</returns>
        public override DARETrailer GetDummyTrailer() {
            if (CryptoParameters==null) {
                return null; // no trailer if no crypto!
                }
            return CryptoStack.GetDummyTrailer();
            }


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
        long PayloadData;


        ///// <summary>
        ///// Read the frame data and return as an array.
        ///// </summary>
        ///// <returns>The data that was read</returns>
        //public override byte[] ReadFrameData() {

        //    using ( var FrameReader = new JBCDRecordDataReader(JBCDStream, ref FrameRemaining)) {

        //        using (var Buffer = new MemoryStream()) {
        //            var Decoder = ContainerHeader.GetDecoder(
        //                    FrameReader, out var Reader,
        //                    KeyCollection: KeyCollection);
        //            Reader.CopyTo(Buffer);
        //            Decoder.Close();
        //            return Buffer.ToArray();
        //            }
        //        }
        //    }


        /// <summary>
        /// Obtain a reader stream for the current frame data.
        /// </summary>
        /// <returns>The reader stream created.</returns>
        public override ContainerFramerReader GetFrameDataReader(
                long Index = -1, long Position = -1) {

            if (Position < 0 & Index >= 0) {
                MoveToIndex(Index);
                Position = PositionRead;
                }

            return new ContainerFramerReader(JBCDStream, KeyCollection, Position);
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

        /// <summary>
        /// Begin reading record data. This method is called before ReadData
        /// to move the read pointer to the start of the payload data.
        /// </summary>
        /// <returns></returns>
        public override long ReadDataBegin() {
            PayloadData = JBCDStream.ReadRecordBegin(ref FrameRemaining);
            return PayloadData;
            }


        /// <summary>
        /// Read the next frame in the file.
        /// </summary>
        /// <returns>True if a next frame exists, otherwise false</returns>
        protected override bool Next () {
            PositionStream();

            var RecordStart = PositionRead;

            //_FrameData = null;
            FrameRemaining = JBCDStream.ReadFrame(out var FrameHeader);
            FrameReadStartPosition = PositionRead;

            this.FrameHeader = FrameHeader;


            if (FrameHeader != null) {
                var Index = ContainerHeader.Index;
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
                var Index = ContainerHeader.Index;
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
        /// <param name="Index">The frame index to move to</param>
        /// <returns>If success, the frame index.</returns>
        public override bool MoveToIndex (long Index) {

            if (FrameIndexToPositionDictionary.TryGetValue(Index, out var Position)) {
                PositionRead = Position;
                }
            else {
                Assert.True(Index > FrameLowUnknown & Index < FrameHighUnknown);

                if (Index - FrameLowUnknown <= FrameHighUnknown - Index) {
                    Assert.True(FrameIndexToPositionDictionary.TryGetValue(FrameLowUnknown, out Position));
                    PositionRead = Position;
                    var Last = PositionRead;
                    Next();
                    while (ContainerHeader!= null && ContainerHeader.Index < Index) {
                        Last = PositionRead;
                        Next();
                        }
                    PositionRead = Last;
                    FrameLowUnknown = ContainerHeader.Index;
                    return ContainerHeader.Index == Index;
                    }

                else {
                    Assert.True(FrameIndexToPositionDictionary.TryGetValue(FrameHighUnknown, out Position));
                    PositionRead = Position;

                    Previous();
                    while (ContainerHeader != null && (ContainerHeader.Index > Index)) {
                        Previous();
                        }

                    FrameHighUnknown = ContainerHeader.Index;
                    return ContainerHeader.Index == Index;
                    }
                }
            return true;
            //return Next();

            }




        /// <summary>
        /// Perform sanity checking on a list of container headers.
        /// </summary>
        /// <param name="Headers">List of headers to check</param>
        public override void CheckContainer (List<ContainerHeader> Headers) {
            int Index = 1;
            foreach (var Header in Headers) {
                Assert.True(Header.Index == Index);

                if (ContainerHeaderFirst.ContainerType == Label) {
                    Assert.Null(Header.PayloadDigest);
                    }
                else {
                    Assert.NotNull(Header.PayloadDigest);
                    }
                Index++;
                }
            }
        }
    }
