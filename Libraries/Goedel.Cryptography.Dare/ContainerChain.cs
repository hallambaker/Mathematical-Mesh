using Goedel.Utilities;

using System.Collections.Generic;


namespace Goedel.Cryptography.Dare {


    /// <summary>
    /// Simple container that supports the append and index functions but does not 
    /// provide for cryptographic integrity.
    /// </summary>
    /// <threadsafety static="true" instance="false"/>
    public class ContainerChain : ContainerDigest {

        /// <summary>
        /// The label for the container type for use in header declarations
        /// </summary>
        public new const string Label = "Chain";


        /// <summary>
        /// Default constructor
        /// </summary>
        public ContainerChain() {
            }


        /// <summary>
        /// Create a new container file of the specified type and write the initial
        /// data record
        /// </summary>
        /// <param name="JBCDStream">The underlying JBCDStream stream. This MUST be opened
        /// in a read access mode and should have exclusive read access. All existing
        /// content in the file will be overwritten.</param>
        public static new Container MakeNewContainer(
                        JbcdStream JBCDStream) {


            var containerInfo = new ContainerInfo() {
                ContainerType = Label,
                Index = 0
                };

            var containerHeader = new DareHeader() {
                ContainerInfo = containerInfo
                };

            var container = new ContainerChain() {
                JbcdStream = JBCDStream,
                ContainerHeaderFirst = containerHeader
                };

            return container;
            }

        /// <summary>
        /// Initialize the dictionaries used to manage the tree by registering the set
        /// of values leading up to the apex value.
        /// </summary>
        /// <param name="header">Final frame header</param>
        /// <param name="firstPosition">Position of frame 1</param>
        /// <param name="positionLast">Position of the last frame</param>
        protected override void FillDictionary(
                        ContainerInfo header, 
                        long firstPosition, 
                        long positionLast) => 
            base.FillDictionary(header, firstPosition, positionLast);


        /// <summary>
        /// Append the header to the frame. This is called after the payload data
        /// has been passed using AppendPreprocess.
        /// </summary>
        public override void PrepareFrame(
                        ContainerWriter contextWrite
                        ) {
            DareHeaderFinal = contextWrite.ContainerHeader;
            base.PrepareFrame(contextWrite);
            }

        /// <summary>
        /// Pre-populate the dummy trailer so as to allow the length to be calculated.
        /// </summary>
        /// <returns>The dummy trailer.</returns>
        public override DareTrailer FillDummyTrailer(
                        CryptoStack cryptoStack
                        ) { // should be complete dummy trailer or sommat... 

            var Trailer = cryptoStack.GetDummyTrailer();
            Trailer.ChainDigest = Trailer.PayloadDigest;

            return Trailer;
            }

        /// <summary>
        /// The dummy trailer to add to the end of the frame.
        /// </summary>
        /// <param name="trailer">The trailer to augment.</param>
        public override void MakeTrailer(ref DareTrailer trailer) {
            trailer ??= CryptoStackContainer.GetNullTrailer();

            if (DareHeaderFinal != null) {
                trailer.ChainDigest = CryptoStackContainer.CombineDigest(DareHeaderFinal.ChainDigest, trailer.PayloadDigest);
                }
            else {
                trailer.ChainDigest = CryptoStackContainer.CombineDigest(null, trailer.PayloadDigest);
                }
            }


        #region // Verification
        /// <summary>
        /// Perform sanity checking on a list of container headers.
        /// </summary>
        /// <param name="headers">List of headers to check</param>
        public override void CheckContainer(List<DareHeader> headers) {
            int Index = 1;
            foreach (var Header in headers) {
                Assert.AssertNotNull(Header.ContainerInfo, ContainerDataCorrupt.Throw);


                Assert.AssertTrue(Header.ContainerInfo.Index == Index, ContainerDataCorrupt.Throw);
                Assert.AssertNotNull(Header.PayloadDigest, ContainerDataCorrupt.Throw);
                Index++;
                }
            }
        #endregion 
        }
    }
