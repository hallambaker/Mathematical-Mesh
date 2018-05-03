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
    /// provide for cryptographic integrity.
    /// </summary>
    /// <threadsafety static="true" instance="false"/>
    public class ContainerTree : ContainerSimple {

        /// <summary>
        /// The label for the container type for use in header declarations
        /// </summary>
        public new const string Label= "Tree";


        /// <summary>
        /// Create a new container file of the specified type and write the initial
        /// data record
        /// </summary>
        /// <param name="JBCDStream">The underlying JBCDStream stream. This MUST be opened
        /// in a read access mode and should have exclusive read access. All existing
        /// content in the file will be overwritten.</param>
        /// <param name="ContainerType">The container type. This determines whether
        /// a tree index is to be created or not and if so, whether </param>
        /// <param name="DigestAlgorithm">The digest algorithm to be used to calculate the PayloadDigest</param>
        /// <returns>The newly constructed container.</returns>
        public static new Container MakeNewContainer (
                        JBCDStream JBCDStream,
                        ContainerType ContainerType = ContainerType.Chain,
                        CryptoAlgorithmID DigestAlgorithm = CryptoAlgorithmID.Default) {

            var ContainerHeader = new ContainerHeaderFirst() {
                ContainerType = Label,
                };

            CryptoProviderDigest DigestProvider = CryptoCatalog.Default.GetDigest(DigestAlgorithm);

            Assert.True(ContainerType == ContainerType.Tree, InvalidContainerTypeException.Throw);

            var Container = new ContainerTree() {
                JBCDStream = JBCDStream,
                FrameCount = 0,
                DigestProvider = DigestProvider,
                ContainerHeaderFirst = ContainerHeader
                };

            return Container;
            }

        readonly static byte[] EmptyBytes = new byte[0];

        /// <summary>
        /// Initialize the dictionaries used to manage the tree by registering the set
        /// of values leading up to the apex value.
        /// </summary>
        /// <param name="Header">Final frame header</param>
        /// <param name="FirstPosition">Position of frame 1</param>
        /// <param name="PositionLast">Position of the last frame</param>
        protected override void FillDictionary (ContainerHeader Header, long FirstPosition, long PositionLast) {
            FrameIndexToPositionDictionary.Add(0, 0);
            if (Header.Index == 0) {
                return;
                }

            FrameIndexToPositionDictionary.Add(1, FirstPosition);
            if (Header.Index == 1) {
                return;
                }

            var Position = PositionLast;
            var Index = Header.Index;
            var TreePosition = Header.TreePosition;

            while (!IsApex(Index)) {
                RegisterFrame(Header, Position);

                // Calculate position of previous node in tree.
                Position = TreePosition;
                Index = (int)PreviousFrame(Index);

                // 
                JBCDStream.PositionRead = TreePosition;
                Header = JBCDStream.ReadFrameHeader();
                Assert.True(Index == Header.Index);
                TreePosition = Header.TreePosition;
                }
            RegisterFrame(Header, Position);
            }

        bool IsApex (long Index) {
            if (Index == 0) {
                return true;
                }

            while (Index != 1) {
                if ((Index & 1) == 0) {
                    return false;
                    }
                Index >>= 1;
                }

            return true;
            }

        /// <summary>
        /// Move to the frame with index Position in the file. 
        /// <para>Since the file format only supports sequential access, this is slow.</para>
        /// </summary>
        /// <param name="Index">The frame index to move to</param>
        /// <returns>If success, the frame index.</returns>
        public override bool Move (long Index) {

            if (FrameIndexToPositionDictionary.TryGetValue(Index, out var Position)) {
                JBCDStream.PositionRead = Position;
                return Next();
                }

            //Obtain the position of the very last record in the file, this must be known.
            var Record = FrameCount-1;
            Assert.True(FrameIndexToPositionDictionary.TryGetValue(Record, out Position));

            long NextRecord;
            bool Found = true;

            Console.WriteLine ("Move to {0}", Index);

            while (Record > Index) {
                ContainerHeader FrameHeader=null;
                long NextPosition;

                if (PreviousFrame(Record) < Index) {
                    // The record we want is the one before the current frame
                    NextRecord = Record - 1;

                    if (!FrameIndexToPositionDictionary.TryGetValue(NextRecord, out NextPosition)) {
                        // we do not know the position of the next frame
                        if (!Found) {
                            JBCDStream.PositionRead = Position;
                            FrameHeader = JBCDStream.ReadFrameHeader();
                            RegisterFrame(FrameHeader, Position);
                            }

                        JBCDStream.PositionRead = Position;
                        JBCDStream.Previous();
                        NextPosition = JBCDStream.PositionRead;

                        FrameHeader = JBCDStream.ReadFrameHeader();
                        Assert.True(FrameHeader.Index == NextRecord);

                        Found = false;
                        }
                    else {
                        Found = true;
                        }

                    }
                else {
                    NextRecord = PreviousFrame(Record);
                    if (!FrameIndexToPositionDictionary.TryGetValue(NextRecord, out NextPosition)) {
                        // we do not know the position of the next frame

                        JBCDStream.PositionRead = Position;
                        FrameHeader = JBCDStream.ReadFrameHeader();
                        NextPosition = FrameHeader.TreePosition;

                        if (!Found) {
                            RegisterFrame(FrameHeader, Position);
                            }
                        Found = false;
                        }
                    else {
                        Found = true;
                        }

                    }

                Position = NextPosition;
                Record = NextRecord;

                Console.WriteLine("    {0}: {1}", Record, Position);
                }

            JBCDStream.PositionRead = Position;
            return Next();
            }

        /// <summary>
        /// Append a new data frame payload to the end of the file.
        /// </summary>
        /// <param name="Data">Data to append.</param>
        /// <param name="ContainerHeader">The container header value</param>
        /// <returns>The number of bytes written.</returns>
        public override long AppendFrame (byte[] Data, ContainerHeader ContainerHeader = null) {
            ContainerHeader = ContainerHeader ?? new ContainerHeader();
            ContainerHeader.Index = (int)FrameCount++;
            //Header.TreeFrame = (int)PreviousFrame(Header.Index);

            if (ContainerHeader.Index > 0) {
                ContainerHeader.TreePosition = (int)PreviousFramePosition(ContainerHeader.Index);
                }

            Data = Data ?? ContainerHeader?.Payload;
            var Header = ContainerHeader.GetBytes(DataEncoding, false);

            RegisterFrame(ContainerHeader, JBCDStream.Length);
            return AppendFrame(Header, Data);
            }


        /// <summary>
        /// Get the frame position.
        /// </summary>
        /// <param name="Frame">The frame index</param>
        /// <returns>The frame position.</returns>
        public override long GetFramePosition (long Frame) {


            var Found = FrameIndexToPositionDictionary.TryGetValue(Frame, out var Position);

            if (!Found) {

                }

            return Position;

            }


        /// <summary>
        /// Returns the start position of the prior frame in the tree.
        /// </summary>
        /// <param name="FrameIndex">The Frame Index</param>
        /// <returns>The position of the frame.</returns>
        public long PreviousFramePosition (long FrameIndex) {
            var Previous = PreviousFrame(FrameIndex);
            return GetFramePosition(Previous);
            }

        /// <summary>
        /// Returns the index of the prior frame in the tree.
        /// </summary>
        /// <param name="Frame">The frame index</param>
        /// <returns>The preceding frame index.</returns>
        public long PreviousFrame (long Frame) {
            long x2 = Frame + 1;
            long d = 1;

            while (x2 > 0) {
                if ((x2 & 1) == 1) {
                    return x2 == 1 ? (d / 2) - 1 : Frame - d;
                    }
                d = d * 2;
                x2 = x2 / 2;
                }
            return 0;
            }

        /// <summary>
        /// Perform sanity checking on a list of container headers.
        /// </summary>
        /// <param name="Headers">List of headers to check</param>
        public override void CheckContainer (List<ContainerHeader> Headers) {
            int Index = 1;
            foreach (var Header in Headers) {
                Assert.True(Header.Index == Index);
                Assert.Null(Header.PayloadDigest);

                Index++;
                }
            }
        }


    }
