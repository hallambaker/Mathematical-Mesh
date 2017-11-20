using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Utilities;
using Goedel.Protocol;
using Goedel.IO;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;

namespace Goedel.Cryptography.Container {

    /// <summary>
    /// Simple container that supports the append and index functions but does not 
    /// provide for cryptographic integrity.
    /// </summary>
    /// <threadsafety static="true" instance="false"/>
    public class ContainerMerkleTree : ContainerTree {

        /// <summary>
        /// Create a new container file of the specified type and write the initial
        /// data record
        /// </summary>
        /// <param name="JBCDStream">The underlying JBCDStream stream. This MUST be opened
        /// in a read access mode and should have exclusive read access. All existing
        /// content in the file will be overwritten.</param>
        /// <param name="Payload">Optional data payload. </param>
        /// <param name="DataEncoding">The data encoding.</param>
        /// <param name="ContentType">Content type of the optional data payload</param>
        /// <param name="ContainerType">The container type. This MUST be either List or Digest</param>
        /// <param name="DigestAlgorithm">The digest algorithm to be used to calculate the PayloadDigest</param>
        /// <param name="EncryptedKey">Key used to encrypt the payload.</param>
        /// <param name="Signatures">List of JWS signatures. Since this is the first block, the signature
        /// is always over the payload data only.</param>
        /// <param name="Recipients">List of JWE recipient decryption entries.</param>
        /// <returns>The newly constructed container.</returns>

        public static new Container NewContainer (
                        JBCDStream JBCDStream,
                        ContainerType ContainerType = ContainerType.Chain,
                        byte[] Payload = null,
                        string ContentType = null,
                        DataEncoding DataEncoding = DataEncoding.JSON,
                        CryptoAlgorithmID DigestAlgorithm = CryptoAlgorithmID.Default,
                        byte[] EncryptedKey = null,
                        List<Signature> Signatures = null,
                        List<Recipient> Recipients = null
                        ) {

            var ContainerHeader = new ContainerHeader() {
                };

            CryptoProviderDigest DigestProvider = CryptoCatalog.Default.GetDigest(DigestAlgorithm);

            Assert.True(ContainerType == ContainerType.MerkleTree, InvalidContainerTypeException.Throw);

            var Container = new ContainerMerkleTree() {
                JBCDStream = JBCDStream,
                DataEncoding = DataEncoding,
                FrameIndex = 0,
                FrameCount = 0,
                FramePayload = Payload,
                DigestProvider = DigestProvider
                };
            Container._ContainerHeader = ContainerHeader;
            Container.Append(Payload, ContainerHeader);

            return Container;
            }

        readonly static byte[] EmptyBytes = new byte[0];
        ContainerHeader FinalContainerHeader = null;

        /// <summary>
        /// Append a new data frame payload to the end of the file.
        /// </summary>
        /// <param name="Data">Data to append.</param>
        /// <param name="Header">The container header value</param>
        /// <returns>The number of bytes written.</returns>
        public override long Append (byte[] Data, ContainerHeader Header = null) {
            Header = Header ?? new ContainerHeader();
            Header.Index = (int)FrameCount++;
            Header.TreePosition = (int)PreviousFramePosition(Header.Index);
            var DigestData = Data ?? EmptyBytes;
            Header.PayloadDigest = DigestProvider.ProcessData(DigestData);


            if (Header.Index > 0) {
                Header.TreeDigest = GetTreeDigest (Header.Index, Header.PayloadDigest);
                }
            else {
                Header.TreeDigest = CombineDigest(null, Header.PayloadDigest);
                }

            Data = Data ?? Header?.Payload;

            FinalContainerHeader = Header;

            //// Get the container header in the specified data encoding 
            //// for the container without a type tag prefix.
            //var HeaderBytes = Header.GetBytes(DataEncoding, false);

            //return AppendFrame(HeaderBytes, Data);
            return AppendFrame(Data, Header);
            }


        /// <summary>
        /// Dictionary mapping the frame index to the corresponding digest value.
        /// </summary>
        public Dictionary<long, byte[]> FrameDigestDictionary = new Dictionary<long, byte[]>();


        /// <summary>
        /// Append a new data frame payload to the end of the file.
        /// </summary>
        /// <param name="Data">Data to append.</param>
        /// <param name="ContainerHeader">The container header value</param>
        /// <returns>The number of bytes written.</returns>
        public override long AppendFrame (byte[] Data, ContainerHeader ContainerHeader = null) {


            FrameDigestDictionary.Add(ContainerHeader.Index, ContainerHeader.TreeDigest);
            return base.AppendFrame(Data, ContainerHeader);
            }

        /// <summary>
        /// Calculate the digest of the specified tree node
        /// </summary>
        /// <param name="Frame">The frame number</param>
        /// <param name="ContentDigest">The content digest</param>
        /// <returns>The calculated digest</returns>
        public virtual byte[] GetTreeDigest (long Frame, byte[] ContentDigest) {
            long x2 = Frame + 1;
            long d = 1;

            while (x2 > 0) {
                if ((x2 & 1) == 1) {
                    return DigestFrame (x2 == 1 ? (d / 2) - 1 : Frame - d, ContentDigest);
                    }
                else {
                    ContentDigest = DigestFrame(Frame - d, ContentDigest);
                    }
                d = d * 2;
                x2 = x2 / 2;
                }
            return CombineDigest(null, ContentDigest);
            }

        /// <summary>
        /// Obtain the digest value for a frame.
        /// </summary>
        /// <param name="Frame">The frame index.</param>
        /// <param name="Right">The digest of the rightmost component.</param>
        /// <returns>The calculated digest.</returns>
        public byte[] DigestFrame (long Frame, byte[] Right) {
            var Left = GetFrameDigest(Frame);
            return CombineDigest(Left, Right);
            }


        /// <summary>
        /// Get the digest value of the specified frame.
        /// </summary>
        /// <param name="Frame">The frame index.</param>
        /// <returns>The digest value.</returns>
        public virtual byte[] GetFrameDigest (long Frame) {
            var Found = FrameDigestDictionary.TryGetValue(Frame, out var Digest);
            return Digest;
            }
        }

    }
