using Goedel.Utilities;

using System.Collections.Generic;

namespace Goedel.Cryptography.Dare {



    /// <summary>
    /// Simple container that supports the append and index functions but does not 
    /// provide for linked cryptographic integrity.
    /// </summary>
    /// <threadsafety static="true" instance="false"/>
    public class ContainerDigest : ContainerList {

        ///<summary>If true, the Container type requires a digest calculated on the payload.</summary> 
        public override bool DigestRequired => true;


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
        /// <returns>The newly constructed container.</returns>

        public static new Sequence MakeNewContainer(
                        JbcdStream JBCDStream) {

            var containerInfo = new SequenceInfo() {
                ContainerType = DareConstants.SequenceTypeDigestTag,
                Index = 0
                };


            var containerHeader = new DareHeader() {
                SequenceInfo = containerInfo
                };

            var container = new ContainerDigest() {
                JbcdStream = JBCDStream,
                HeaderFirst = containerHeader
                };

            // initialize the Frame index dictionary

            return container;


            }




        /// <summary>
        /// Perform sanity checking on a list of container headers.
        /// </summary>
        /// <param name="Headers">List of headers to check</param>
        public override void CheckSequence(List<DareHeader> Headers) {
            int Index = 1;
            foreach (var Header in Headers) {
                Assert.AssertNotNull(Header.SequenceInfo, SequenceDataCorrupt.Throw);

                Assert.AssertTrue(Header.SequenceInfo.Index == Index, SequenceDataCorrupt.Throw);

                if (HeaderFirst.SequenceInfo.ContainerType == DareConstants.SequenceTypeListTag) {
                    Assert.AssertNull(Header.PayloadDigest, SequenceDataCorrupt.Throw);
                    }
                else {
                    Assert.AssertNotNull(Header.PayloadDigest, SequenceDataCorrupt.Throw);
                    }
                Index++;
                }
            }
        }
    }
