using Goedel.Utilities;

using System;
using System.Collections.Generic;

namespace Goedel.Cryptography.Dare {

    /// <summary>
    /// Simple container that supports the append and index functions but does not 
    /// provide for cryptographic integrity.
    /// </summary>
    /// <threadsafety static="true" instance="false"/>
    public class ContainerTree : ContainerList {

        /// <summary>
        /// The label for the container type for use in header declarations
        /// </summary>
        public new const string Label = "Tree";


        /// <summary>
        /// Create a new container file of the specified type and write the initial
        /// data record
        /// </summary>
        /// <param name="jbcdStream">The underlying JBCDStream stream. This MUST be opened
        /// in a read access mode and should have exclusive read access. All existing
        /// content in the file will be overwritten.</param>
        /// <returns>The newly constructed container.</returns>
        public static new Container MakeNewContainer(
                        JbcdStream jbcdStream) {

            var containerInfo = new ContainerInfo() {
                ContainerType = Label,
                Index = 0
                };


            var containerHeader = new DareHeader() {
                ContainerInfo = containerInfo
                };


            var container = new ContainerTree() {
                JBCDStream = jbcdStream,
                ContainerHeaderFirst = containerHeader
                };

            return container;
            }

        //readonly static byte[] EmptyBytes = new byte[0];

        /// <summary>
        /// Append the header to the frame. This is called after the payload data
        /// has been passed using AppendPreprocess.
        /// </summary>
        public override void PrepareFrame(ContainerWriter contextWrite) {


            PrepareFrame(contextWrite.ContainerInfo);


            base.PrepareFrame(contextWrite);
            }

        /// <summary>
        /// Prepare the ContainerInfo data for the frame.
        /// </summary>
        /// <param name="containerInfo">The frame to prepare.</param>
        protected override void PrepareFrame(ContainerInfo containerInfo) {
            if (containerInfo.Index == 0) {
                containerInfo.ContainerType = Label;
                }
            else {
                containerInfo.TreePosition =
                    (int)PreviousFramePosition(containerInfo.Index);
                }



            //Console.WriteLine($"Prepare #{containerInfo.Index} @{JBCDStream.PositionWrite} Tree={containerInfo.TreePosition}");


            }




        #region // Container navigation

        /// <summary>
        /// Initialize the dictionaries used to manage the tree by registering the set
        /// of values leading up to the apex value.
        /// </summary>
        /// <param name="containerInfo">Final frame header</param>
        /// <param name="firstPosition">Position of frame 1</param>
        /// <param name="positionLast">Position of the last frame</param>
        protected override void FillDictionary(ContainerInfo containerInfo, long firstPosition, long positionLast) {
            FrameIndexToPositionDictionary.Add(0, 0);
            if (containerInfo.Index == 0) {
                return;
                }

            FrameIndexToPositionDictionary.Add(1, firstPosition);
            if (containerInfo.Index == 1) {
                return;
                }

            var position = positionLast;
            var index = containerInfo.Index;
            var treePosition = containerInfo.TreePosition;

            while (!IsApex(index)) {
                RegisterFrame(containerInfo, position);

                // Calculate position of previous node in tree.
                position = treePosition;
                index = (int)PreviousFrame(index);

                // 
                JBCDStream.PositionRead = treePosition;
                containerInfo = JBCDStream.ReadFrameHeader().ContainerInfo;

                if (index != containerInfo.Index) {

                    }


                // This is failing because the container index is set to 2 when it should be 1.
                Assert.True(index == containerInfo.Index);
                treePosition = containerInfo.TreePosition;
                }
            if (containerInfo.Index != 1) {
                RegisterFrame(containerInfo, position);
                }
            }

        bool IsApex(long index) {
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
        /// Move to the specified frame index.
        /// </summary>
        /// <param name="index">Frame index to move to</param>
        /// <returns>If the move to the specified index succeeded, returns <code>true</code>.
        /// Otherwise, returns <code>false</code>.</returns>
        public bool Move(long index) {
            MoveToIndex(index);
            return Next();
            }

        /// <summary>
        /// Move to the frame with index Position in the file. 
        /// <para>Since the file format only supports sequential access, this is slow.</para>
        /// </summary>
        /// <param name="index">The frame index to move to</param>
        /// <returns>If success, the frame index.</returns>
        public override bool MoveToIndex(long index) {
            if (index == FrameCount) {
                JBCDStream.PositionRead = JBCDStream.Length;
                return false;
                }

            if (FrameIndexToPositionDictionary.TryGetValue(index, out var Position)) {
                JBCDStream.PositionRead = Position;
                return true;
                //return Next();
                }

            //Obtain the position of the very last record in the file, this must be known.
            var Record = FrameCount - 1;
            Assert.True(FrameIndexToPositionDictionary.TryGetValue(Record, out Position));
            // Bug: this is failing because the position dictionary is not being updated.
            // check that commit frame is being properly called on deferred writes.
            // Also check every operation on the device catalog

            // ContainerHeader is not being properly updated.
            // Also check on the calculation of the trailer.

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
                            JBCDStream.PositionRead = Position;
                            frameHeader = JBCDStream.ReadFrameHeader();
                            RegisterFrame(frameHeader.ContainerInfo, Position);
                            }

                        PositionRead = Position;
                        JBCDStream.Previous();
                        nextPosition = JBCDStream.PositionRead;

                        frameHeader = JBCDStream.ReadFrameHeader();
                        Assert.True(frameHeader.ContainerInfo.Index == nextRecord);

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

                        PositionRead = Position;
                        frameHeader = JBCDStream.ReadFrameHeader();
                        nextPosition = frameHeader.ContainerInfo.TreePosition;

                        if (!found) {
                            RegisterFrame(frameHeader.ContainerInfo, Position);
                            }
                        found = false;
                        }
                    else {
                        found = true;
                        }

                    }

                Position = nextPosition;
                Record = nextRecord;

                //Console.WriteLine("    {0}: {1}", Record, Position);
                }

            PositionRead = Position;
            return true;
            //return Next();
            }


        /// <summary>
        /// Get the frame position.
        /// </summary>
        /// <param name="frame">The frame index</param>
        /// <returns>The frame position.</returns>
        public override long GetFramePosition(long frame) {


            var Found = FrameIndexToPositionDictionary.TryGetValue(frame, out var Position);

            if (!Found) {

                }

            return Position;

            }


        /// <summary>
        /// Returns the start position of the prior frame in the tree.
        /// </summary>
        /// <param name="frameIndex">The Frame Index</param>
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
        public long PreviousFrame(long frame) {
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
        /// Perform sanity checking on a list of container headers.
        /// </summary>
        /// <param name="headers">List of headers to check</param>
        public override void CheckContainer(List<DareHeader> headers) {
            var index = 1;
            foreach (var Header in headers) {
                Assert.True(Header.ContainerInfo.Index == index);
                Assert.NotNull(Header.PayloadDigest);

                index++;
                }
            }


        /// <summary>
        /// Verify container contents by reading every frame starting with the first and checking
        /// for integrity. This is likely to take a very long time.
        /// </summary>
        public override void VerifyContainer() {

            SortedDictionary<long, DareHeader> headerDictionary = new SortedDictionary<long, DareHeader>();

            // Check the first frame
            JBCDStream.PositionRead = 0;
            var header = JBCDStream.ReadFirstFrameHeader();
            Assert.True(header.ContainerInfo.Index == 0);
            headerDictionary.Add(0, header);

            // Check subsequent frames
            int index = 1;
            while (!JBCDStream.EOF) {
                var Position = JBCDStream.PositionRead;
                header = JBCDStream.ReadFrameHeader();
                headerDictionary.Add(Position, header);

                Assert.True(header.ContainerInfo.Index == index);
                if (index > 1) {
                    var Previous = PreviousFrame(index);
                    Assert.True(headerDictionary.TryGetValue(header.ContainerInfo.TreePosition, out var PreviousHeader));
                    Assert.True(PreviousHeader.ContainerInfo.Index == Previous);
                    }


                index++;
                }


            }

        #endregion 
        }


    }
