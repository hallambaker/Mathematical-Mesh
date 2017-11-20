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
    /// provide for linked cryptographic integrity.
    /// </summary>
    /// <threadsafety static="true" instance="false"/>
    public class ContainerSimple : Container {

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
        /// <param name="Payload">Optional data payload. </param>
        /// <param name="ContentType">Content type of the optional data payload</param>
        /// <param name="DataEncoding">The data encoding algorithm (defaults to JSON).</param>
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

            CryptoProviderDigest DigestProvider = null;
            switch (ContainerType) {
                case ContainerType.List:  {
                    ContainerHeader.ContainerType = "List";
                    break;
                    }
                case ContainerType.Digest: {
                    ContainerHeader.ContainerType = "Digest";
                    DigestProvider = CryptoCatalog.Default.GetDigest(DigestAlgorithm);
                    break;
                    }
                default: {
                    throw new InvalidContainerTypeException();
                    }
                }

            var Container = new ContainerSimple() {
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



        /// <summary>
        /// Append a new data frame payload to the end of the file.
        /// </summary>
        /// <param name="Data">Data to append.</param>
        /// <param name="Header">The container header value</param>
        /// <returns>The number of bytes written.</returns>
        public override long Append (byte[] Data, ContainerHeader Header = null) {
            Header = Header ?? new ContainerHeader();
            Header.Index = (int)FrameCount++;

            if (DigestProvider != null& Data != null) {
                Header.PayloadDigest = DigestProvider.ProcessData(Data);
                }

            Data = Data ?? Header?.Payload;

            //// Get the container header in the specified data encoding 
            //// for the container without a type tag prefix.
            //var HeaderBytes = Header.GetBytes(DataEncoding, false);

            //return AppendFrame(HeaderBytes, Data);
            return AppendFrame(Data, Header);
            }

        /// <summary>
        /// Read the next frame in the file.
        /// </summary>
        /// <returns>True if a next frame exists, otherwise false</returns>
        public override bool Next () {
            var Read = JBCDStream.ReadWrappedFrame(out var FrameHeader, out var FrameData);
            EOF = !Read;

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
            var Read = JBCDStream.ReadWrappedFrameReverse(out var FrameHeader, out var FrameData);

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
            throw new NYI();
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


        }

    }
