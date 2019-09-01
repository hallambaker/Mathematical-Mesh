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
    public class ContainerDigest : ContainerList {


        /// <summary>
        /// The label for the container type for use in header declarations
        /// </summary>
        public new const string Label = "Digest";

        /// <summary>
        /// Create a new container file of the specified type and write the initial
        /// data record
        /// </summary>
        /// <param name="JBCDStream">The underlying JBCDStream stream. This MUST be opened
        /// in a read access mode and should have exclusive read access. All existing
        /// content in the file will be overwritten.</param>
        /// <returns>The newly constructed container.</returns>

        public static new Container MakeNewContainer(
                        JBCDStream JBCDStream) {

            var ContainerHeader = new ContainerHeaderFirst {
                ContainerType = Label
                };

            var Container = new ContainerDigest() {
                JBCDStream = JBCDStream,
                ContainerHeaderFirst = ContainerHeader
                };

            // initialize the Frame index dictionary

            return Container;


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
        public override void CheckContainer (List<ContainerHeader> Headers) {
            int Index = 1;
            foreach (var Header in Headers) {
                Assert.True(Header.Index == Index);

                if (ContainerHeaderFirst.ContainerType == ContainerList.Label) {
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
