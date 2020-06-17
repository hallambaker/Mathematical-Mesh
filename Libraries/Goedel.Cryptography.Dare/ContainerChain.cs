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
                JBCDStream = JBCDStream,
                ContainerHeaderFirst = containerHeader
                };

            return container;
            }

        //readonly static byte[] EmptyBytes = new byte[0];
        //DareHeader DareHeaderFinal = null;

        /// <summary>
        /// Initialize the dictionaries used to manage the tree by registering the set
        /// of values leading up to the apex value.
        /// </summary>
        /// <param name="Header">Final frame header</param>
        /// <param name="FirstPosition">Position of frame 1</param>
        /// <param name="PositionLast">Position of the last frame</param>
        protected override void FillDictionary(ContainerInfo Header, long FirstPosition, long PositionLast) => base.FillDictionary(Header, FirstPosition, PositionLast);


        /// <summary>
        /// Append the header to the frame. This is called after the payload data
        /// has been passed using AppendPreprocess.
        /// </summary>
        public override void PrepareFrame(ContainerWriter contextWrite) {
            DareHeaderFinal = contextWrite.ContainerHeader;
            base.PrepareFrame(contextWrite);
            }

        /// <summary>
        /// Pre-populate the dummy trailer so as to allow the length to be calculated.
        /// </summary>
        /// <returns>The dummy trailer.</returns>
        public override DareTrailer FillDummyTrailer(CryptoStack CryptoStack) { // should be complete dummy trailer or sommat... 

            var Trailer = CryptoStack.GetDummyTrailer();
            Trailer.ChainDigest = Trailer.PayloadDigest;

            return Trailer;
            }

        /// <summary>
        /// The dummy trailer to add to the end of the frame.
        /// </summary>
        /// <returns></returns>
        public override void MakeTrailer(ref DareTrailer Trailer) {
            Trailer ??= CryptoStackContainer.GetNullTrailer();

            if (DareHeaderFinal != null) {
                Trailer.ChainDigest = CryptoStackContainer.CombineDigest(DareHeaderFinal.ChainDigest, Trailer.PayloadDigest);
                }
            else {
                Trailer.ChainDigest = CryptoStackContainer.CombineDigest(null, Trailer.PayloadDigest);
                }
            }


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
