using Goedel.Utilities;

using System.Collections.Generic;

namespace Goedel.Cryptography.Dare {



    /// <summary>
    /// Simple container that supports the append and index functions but does not 
    /// provide for linked cryptographic integrity.
    /// </summary>
    /// <threadsafety static="true" instance="false"/>
    public class ContainerDigest : ContainerList {

        public override bool DigestRequired => true;
        /// <summary>
        /// The label for the container type for use in header declarations
        /// </summary>
        public new const string Label = "Digest";


        /// <summary>
        /// Default constructor
        /// </summary>

        public ContainerDigest()  {
            }

        /// <summary>
        /// Create a new container file of the specified type and write the initial
        /// data record
        /// </summary>
        /// <param name="JBCDStream">The underlying JBCDStream stream. This MUST be opened
        /// in a read access mode and should have exclusive read access. All existing
        /// content in the file will be overwritten.</param>
        /// <param name="cryptoParameters">Cryptographic parameters specifying algorithms and keys
        /// for encoding and authentication of data.</param>
        /// <returns>The newly constructed container.</returns>

        public static new Container MakeNewContainer(
                        JbcdStream JBCDStream) {

            var containerInfo = new ContainerInfo() {
                ContainerType = Label,
                Index = 0
                };


            var containerHeader = new DareHeader() {
                ContainerInfo = containerInfo
                };

            var container = new ContainerDigest() {
                JbcdStream = JBCDStream,
                ContainerHeaderFirst = containerHeader
                };

            // initialize the Frame index dictionary

            return container;


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


        /// <summary>
        /// Perform sanity checking on a list of container headers.
        /// </summary>
        /// <param name="Headers">List of headers to check</param>
        public override void CheckContainer(List<DareHeader> Headers) {
            int Index = 1;
            foreach (var Header in Headers) {
                Assert.AssertNotNull(Header.ContainerInfo, ContainerDataCorrupt.Throw);

                Assert.AssertTrue(Header.ContainerInfo.Index == Index, ContainerDataCorrupt.Throw);

                if (ContainerHeaderFirst.ContainerInfo.ContainerType == ContainerList.Label) {
                    Assert.AssertNull(Header.PayloadDigest, ContainerDataCorrupt.Throw);
                    }
                else {
                    Assert.AssertNotNull(Header.PayloadDigest, ContainerDataCorrupt.Throw);
                    }
                Index++;
                }
            }
        }
    }
