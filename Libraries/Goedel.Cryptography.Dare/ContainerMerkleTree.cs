using Goedel.Utilities;

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
        /// <param name="jbcdStream">The underlying JBCDStream stream. This MUST be opened
        /// in a read access mode and should have exclusive read access. All existing
        /// content in the file will be overwritten.</param>
        /// <param name="keyLocate">Key collection to be used to resolve keys</param>
        /// <returns>The newly constructed container.</returns>

        public static new Container MakeNewContainer(
                        JbcdStream jbcdStream,
                        IKeyLocate keyLocate) {

            var containerInfo = new ContainerInfo() {
                ContainerType = Label,
                Index = 0
                };


            var containerHeader = new DareHeader() {
                ContainerInfo = containerInfo
                };

            var container = new ContainerMerkleTree(keyLocate) {
                JBCDStream = jbcdStream,
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
        /// <param name="cryptoParameters">The cryptographic algorithms to use</param>
        /// <returns>The master parameters.</returns>
        protected override CryptoStack GetCryptoStack(CryptoParameters cryptoParameters) {
            var Result = cryptoParameters.GetCryptoStack();
            Result.Digest = true;
            return Result;
            }

        //readonly static byte[] EmptyBytes = new byte[0];

        /// <summary>
        /// Register a frame in the container access dictionaries.
        /// </summary>
        /// <param name="containerInfo">Frame header</param>
        /// <param name="position">Position of the frame</param>
        protected override void RegisterFrame(ContainerInfo containerInfo, long position) {
            var Index = containerInfo.Index;
            FrameIndexToPositionDictionary.Add(Index, position);
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
        public override DareTrailer FillDummyTrailer(CryptoStack cryptoStack) {

            var Trailer = cryptoStack.GetDummyTrailer();
            Trailer.TreeDigest = Trailer.PayloadDigest;

            return Trailer;
            }

        /// <summary>
        /// The dummy trailer to add to the end of the frame.
        /// </summary>
        ///<param name="trailer">The trailer to augment.</param>
        public override void MakeTrailer(ref DareTrailer trailer) {

            trailer ??= CryptoStackContainer.GetNullTrailer();

            if (FrameCount > 0) {
                trailer.TreeDigest = GetTreeDigest(FrameCount, trailer.PayloadDigest);
                }
            else {
                trailer.TreeDigest = CryptoStackContainer.CombineDigest(null, trailer.PayloadDigest);
                }
            }

        #region // Construct tree digest

        /// <summary>
        /// Calculate the digest of the specified tree node
        /// </summary>
        /// <param name="frame">The frame number</param>
        /// <param name="contentDigest">The content digest</param>
        /// <returns>The calculated digest</returns>
        public virtual byte[] GetTreeDigest(long frame, byte[] contentDigest) {
            long x2 = frame + 1;
            long d = 1;

            while (x2 > 0) {
                if ((x2 & 1) == 1) {
                    return DigestFrame(x2 == 1 ? (d / 2) - 1 : frame - d, contentDigest);
                    }
                else {
                    contentDigest = DigestFrame(frame - d, contentDigest);
                    }
                d *= 2;
                x2 /= 2;
                }
            return CryptoStackContainer.CombineDigest(null, contentDigest);
            }

        /// <summary>
        /// Obtain the digest value for a frame.
        /// </summary>
        /// <param name="frame">The frame index.</param>
        /// <param name="right">The digest of the rightmost component.</param>
        /// <returns>The calculated digest.</returns>
        public byte[] DigestFrame(long frame, byte[] right) {
            var left = GetFrameDigest(frame);
            return CryptoStackContainer.CombineDigest(left, right);
            }


        /// <summary>
        /// Get the digest value of the specified frame.
        /// </summary>
        /// <param name="Frame">The frame index.</param>
        /// <returns>The digest value.</returns>
        public virtual byte[] GetFrameDigest(long Frame) {
            FrameDigestDictionary.TryGetValue(Frame, out var digest);
            return digest;
            }

        #endregion
        #region // Verification
        /// <summary>
        /// Perform sanity checking on a list of container headers.
        /// </summary>
        /// <param name="headers">List of headers to check</param>
        public override void CheckContainer(List<DareHeader> headers) {
            int index = 1;
            foreach (var header in headers) {
                Assert.AssertNotNull(header.ContainerInfo,
                        ContainerDataCorrupt.Throw);

                Assert.AssertTrue(header.ContainerInfo.Index == index, ContainerDataCorrupt.Throw);
                Assert.AssertNotNull(header.PayloadDigest,
                        ContainerDataCorrupt.Throw);

                index++;
                }
            }

        #endregion 
        }

    }
