﻿using Goedel.Utilities;

using System.Collections.Generic;

namespace Goedel.Cryptography.Dare {

    /// <summary>
    /// Simple container that supports the append and index functions but does not 
    /// provide for cryptographic integrity.
    /// </summary>
    /// <threadsafety static="true" instance="false"/>
    public class ContainerMerkleTree : ContainerTree {

        /// <summary>
        /// The label for the container type for use in header declarations
        /// </summary>
        public new const string Label = "Merkle";

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="keyLocate">Key collection to be used to resolve public keys</param>
        public ContainerMerkleTree(IKeyLocate keyLocate) : base(keyLocate) {
            }

        /// <summary>
        /// Create a new container file of the specified type and write the initial
        /// data record
        /// </summary>
        /// <param name="JBCDStream">The underlying JBCDStream stream. This MUST be opened
        /// in a read access mode and should have exclusive read access. All existing
        /// content in the file will be overwritten.</param>
        /// <returns>The newly constructed container.</returns>

        public static new Container MakeNewContainer(
                        JbcdStream JBCDStream,
                        IKeyLocate keyLocate) {

            var containerInfo = new ContainerInfo() {
                ContainerType = Label,
                Index = 0
                };


            var containerHeader = new DareHeader() {
                ContainerInfo = containerInfo
                };

            var container = new ContainerMerkleTree(keyLocate) {
                JBCDStream = JBCDStream,
                ContainerHeaderFirst = containerHeader
                };

            return container;
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
            }



        /// <summary>
        /// Create a set of master keys and other cryptographic parameters from the
        /// specified profile.
        /// </summary>
        /// <param name="CryptoParameters">The cryptographic algorithms to use</param>
        /// <returns>The master parameters.</returns>
        protected override CryptoStack GetCryptoStack(CryptoParameters CryptoParameters) {
            var Result = CryptoParameters.GetCryptoStack();
            Result.Digest = true;
            return Result;
            }

        //readonly static byte[] EmptyBytes = new byte[0];

        /// <summary>
        /// Register a frame in the container access dictionaries.
        /// </summary>
        /// <param name="ContainerInfo">Frame header</param>
        /// <param name="Position">Position of the frame</param>
        protected override void RegisterFrame(ContainerInfo ContainerInfo, long Position) {
            var Index = ContainerInfo.Index;
            FrameIndexToPositionDictionary.Add(Index, Position);
            //FrameDigestDictionary.Add(Index, ContainerInfo.TreeDigest);
            }

        /// <summary>
        /// Dictionary mapping the frame index to the corresponding digest value.
        /// </summary>
        public Dictionary<long, byte[]> FrameDigestDictionary = new Dictionary<long, byte[]>();


        /// <summary>
        /// Pre-populate the dummy trailer so as to allow the length to be calculated.
        /// </summary>
        /// <returns>The dummy trailer.</returns>
        public override DareTrailer FillDummyTrailer(CryptoStack CryptoStack) {

            var Trailer = CryptoStack.GetDummyTrailer();
            Trailer.TreeDigest = Trailer.PayloadDigest;

            return Trailer;
            }

        /// <summary>
        /// The dummy trailer to add to the end of the frame.
        /// </summary>
        /// <returns></returns>
        public override void MakeTrailer(ref DareTrailer Trailer) {

            Trailer ??= CryptoStackContainer.GetNullTrailer();

            if (FrameCount > 0) {
                Trailer.TreeDigest = GetTreeDigest(FrameCount, Trailer.PayloadDigest);
                }
            else {
                Trailer.TreeDigest = CryptoStackContainer.CombineDigest(null, Trailer.PayloadDigest);
                }
            }

        #region // Construct tree digest

        /// <summary>
        /// Calculate the digest of the specified tree node
        /// </summary>
        /// <param name="Frame">The frame number</param>
        /// <param name="ContentDigest">The content digest</param>
        /// <returns>The calculated digest</returns>
        public virtual byte[] GetTreeDigest(long Frame, byte[] ContentDigest) {
            long x2 = Frame + 1;
            long d = 1;

            while (x2 > 0) {
                if ((x2 & 1) == 1) {
                    return DigestFrame(x2 == 1 ? (d / 2) - 1 : Frame - d, ContentDigest);
                    }
                else {
                    ContentDigest = DigestFrame(Frame - d, ContentDigest);
                    }
                d *= 2;
                x2 /= 2;
                }
            return CryptoStackContainer.CombineDigest(null, ContentDigest);
            }

        /// <summary>
        /// Obtain the digest value for a frame.
        /// </summary>
        /// <param name="Frame">The frame index.</param>
        /// <param name="Right">The digest of the rightmost component.</param>
        /// <returns>The calculated digest.</returns>
        public byte[] DigestFrame(long Frame, byte[] Right) {
            var Left = GetFrameDigest(Frame);
            return CryptoStackContainer.CombineDigest(Left, Right);
            }


        /// <summary>
        /// Get the digest value of the specified frame.
        /// </summary>
        /// <param name="Frame">The frame index.</param>
        /// <returns>The digest value.</returns>
        public virtual byte[] GetFrameDigest(long Frame) {
            var Found = FrameDigestDictionary.TryGetValue(Frame, out var Digest);
            return Digest;
            }

        #endregion
        #region // Verification
        /// <summary>
        /// Perform sanity checking on a list of container headers.
        /// </summary>
        /// <param name="Headers">List of headers to check</param>
        public override void CheckContainer(List<DareHeader> Headers) {
            int Index = 1;
            foreach (var Header in Headers) {
                Assert.NotNull(Header.ContainerInfo);

                Assert.True(Header.ContainerInfo.Index == Index);
                Assert.NotNull(Header.PayloadDigest);

                Index++;
                }
            }

        #endregion 
        }

    }
