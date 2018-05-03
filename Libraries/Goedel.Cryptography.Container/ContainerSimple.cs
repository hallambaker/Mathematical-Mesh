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
    public class ContainerSimple : Container {

        /// <summary>
        /// The label for the container type for use in header declarations
        /// </summary>
        public const string Label = "List";

        /// <summary>
        /// The label for the container type for use in header declarations
        /// </summary>
        public const string LabelDigest = "Digest";

        /// <summary>
        /// The digest provider used to calculate the tree value.
        /// </summary>
        public CryptoProviderDigest DigestProvider { get; set; } = null;

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
                };

            CryptoProviderDigest DigestProvider = null;
            switch (ContainerType) {
                case ContainerType.List: {
                    ContainerHeader.ContainerType = Label;
                    break;
                    }
                case ContainerType.Digest: {
                    ContainerHeader.ContainerType = LabelDigest;
                    DigestProvider = CryptoCatalog.Default.GetDigest(DigestAlgorithm);
                    break;
                    }
                default: {
                    throw new InvalidContainerTypeException();
                    }
                }

            var Container = new ContainerSimple() {
                JBCDStream = JBCDStream,
                FrameCount = 0,
                DigestProvider = DigestProvider,
                ContainerHeaderFirst = ContainerHeader,
                };

            // initialize the Frame index dictionary

            return Container;


            }

        // The high and low boundaries of the unknown region.
        long FrameLowUnknown=0;
        long FrameHighUnknown=0;

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
        /// Append a new data frame payload to the end of the file.
        /// </summary>
        /// <param name="Data">Data to append.</param>
        /// <param name="ContainerHeader">The container header value</param>
        /// <returns>The number of bytes written.</returns>
        public override long AppendFrame (byte[] Data, ContainerHeader ContainerHeader = null) {
            ContainerHeader = ContainerHeader ?? new ContainerHeader();
            ContainerHeader.Index = (int)FrameCount++;

            if (DigestProvider != null& Data != null) {
                ContainerHeader.PayloadDigest = DigestProvider.ProcessData(Data);
                }

            Data = Data ?? ContainerHeader?.Payload;

            var Header = ContainerHeader.GetBytes(DataEncoding, false);

            FrameIndexToPositionDictionary.Add(ContainerHeader.Index, JBCDStream.Length);
            return AppendFrame(Header, Data);
            }

        /// <summary>
        /// Read the next frame in the file.
        /// </summary>
        /// <returns>True if a next frame exists, otherwise false</returns>
        public override bool Next () {
            var Read = JBCDStream.ReadFrame(out var FrameHeader, out var FrameData);

            // NB the order here is critical because we want to bind the payload value into the constructed header.
            this.FrameData = FrameData;
            this.FrameHeader = FrameHeader;

            return Read;
            }

        /// <summary>
        /// Read the previous frame in the file.
        /// </summary>
        /// <returns>True if a previous frame exists, otherwise false</returns>
        public override bool Previous () {
            var Read = JBCDStream.ReadFrameReverse(out var FrameHeader, out var FrameData);

            // NB the order here is critical because we want to bind the payload value into the constructed header.
            this.FrameData = FrameData;
            this.FrameHeader = FrameHeader;

            return Read;
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
                }
            else {
                Assert.True(Index > FrameLowUnknown & Index < FrameHighUnknown);

                if (Index - FrameLowUnknown <= FrameHighUnknown - Index) {
                    Assert.True(FrameIndexToPositionDictionary.TryGetValue(FrameLowUnknown, out Position));
                    JBCDStream.PositionRead = Position;
                    JBCDStream.Next();
                    for (var Record = FrameLowUnknown + 1; Record < Index; Record++) {
                        FrameIndexToPositionDictionary.Add(Record, JBCDStream.PositionRead);
                        JBCDStream.Next();
                        }
                    FrameIndexToPositionDictionary.Add(Index, JBCDStream.PositionRead);
                    FrameLowUnknown = Index;

                    }

                else {
                    Assert.True(FrameIndexToPositionDictionary.TryGetValue(FrameHighUnknown, out Position));
                    JBCDStream.PositionRead = Position;
                    for (var Record = FrameHighUnknown - 1; Record >= Index; Record--) {
                        JBCDStream.Previous();
                        FrameIndexToPositionDictionary.Add(Record, JBCDStream.PositionRead);
                        }
                    FrameHighUnknown = Index;

                    }
                }
            return Next();

            }

        /// <summary>
        /// Combine digests to produce the digest for a node.
        /// </summary>
        /// <param name="First">The left hand digest.</param>
        /// <param name="Second">The right hand digest.</param>
        /// <returns>The digest value.</returns>
        public byte[] CombineDigest (byte[] First, byte[] Second) {
            var Length = DigestProvider.Size / 8;

            var Buffer = new byte[Length*2];
            if (First != null) {
                Assert.True(Length == First.Length);
                Array.Copy(First, Buffer, Length);
                }
            if (Second != null) {
                Assert.True(Length == Second.Length);
                Array.Copy(Second, 0, Buffer, Length, Length);
                }
            

            return DigestProvider.ProcessData(Buffer); ;
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
