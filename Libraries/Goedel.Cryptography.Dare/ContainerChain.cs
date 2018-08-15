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
    public class ContainerChain : ContainerSimple {

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
        /// <param name="ContainerType">The container type. This determines whether
        /// a tree index is to be created or not and if so, whether </param>
        /// <param name="DigestAlgorithm">The digest algorithm to be used to calculate the PayloadDigest</param>
        /// <returns>The newly constructed container.</returns>
        public static new Container MakeNewContainer(
                        JBCDStream JBCDStream,
                        CryptoParameters CryptoParameters,
                        ContainerType ContainerType = ContainerType.Chain,
                        CryptoAlgorithmID DigestAlgorithm = CryptoAlgorithmID.Default) {


            var ContainerHeader = new ContainerHeaderFirst() {
                ContainerType = Label,
                Index = 0
                };

            CryptoProviderDigest DigestProvider = CryptoCatalog.Default.GetDigest(DigestAlgorithm);

            Assert.True(ContainerType == ContainerType.Chain, InvalidContainerTypeException.Throw);

            var Container = new ContainerChain() {
                JBCDStream = JBCDStream,
                DigestProvider = DigestProvider,
                ContainerHeaderFirst = ContainerHeader,
                };

            return Container;
            }

        readonly static byte[] EmptyBytes = new byte[0];
        ContainerHeader FinalContainerHeader = null;

        /// <summary>
        /// Initialize the dictionaries used to manage the tree by registering the set
        /// of values leading up to the apex value.
        /// </summary>
        /// <param name="Header">Final frame header</param>
        /// <param name="FirstPosition">Position of frame 1</param>
        /// <param name="PositionLast">Position of the last frame</param>
        protected override void FillDictionary(ContainerHeader Header, long FirstPosition, long PositionLast) {
            FinalContainerHeader = Header;
            base.FillDictionary(Header, FirstPosition, PositionLast);
            }


        /// <summary>
        /// Append the header to the frame. This is called after the payload data
        /// has been passed using AppendPreprocess.
        /// </summary>
        public override void AppendHeader() {
            if (DigestEncoder != null & AppendContainerHeader.PayloadDigest == null) {
                DigestEncoder.Complete();
                var PayloadDigest = DigestEncoder.Integrity;
                AppendContainerHeader.PayloadDigest = DigestEncoder.Integrity;

                var PreviousHeader = FinalContainerHeader ?? ContainerHeaderFirst;
                if (AppendContainerHeader.Index > 0) {
                    AppendContainerHeader.ChainDigest = CombineDigest(
                        PreviousHeader.ChainDigest, PayloadDigest);
                    }
                else {
                    AppendContainerHeader.ChainDigest = CombineDigest(
                        null, PayloadDigest);
                    }
                }
            FinalContainerHeader = AppendContainerHeader;
            base.AppendHeader();
            }



        /// <summary>
        /// Perform sanity checking on a list of container headers.
        /// </summary>
        /// <param name="Headers">List of headers to check</param>
        public override void CheckContainer (List<ContainerHeader> Headers) {
            int Index = 1;
            foreach (var Header in Headers) {
                Assert.True(Header.Index == Index);
                Assert.NotNull(Header.PayloadDigest);
                Index++;
                }
            }

        }
    }
