using Goedel.Utilities;

using System.Collections.Generic;

namespace Goedel.Cryptography.Dare {

    /// <summary>
    /// Base class for container writers.
    /// </summary>
    public class ContainerWriter {

        ///<summary>The container to be written to.</summary>
        protected Container Container;

        ///<summary>The last container header written</summary>
        public DareHeader ContainerHeader;

        ///<summary>ContainerInfo element of last container header written.</summary>
        public ContainerInfo ContainerInfo => ContainerHeader.ContainerInfo;

        ///<summary>The trailer of the envelope currently being written.</summary>
        public DareTrailer DareTrailer;

        ///<summary>Position of the frame start.</summary>
        public virtual long FrameStart => throw new NYI();

        /// <summary>
        /// Finish writing the frame
        /// </summary>
        /// <param name="dareTrailer">The trailer to write.</param>
        public virtual void CommitFrame(DareTrailer dareTrailer = null) {
            }

        }

    /// <summary>
    /// Container writer to write direct to a file.
    /// </summary>
    public class ContainerWriterFile : ContainerWriter {

        ///<summary>Position of the frame start.</summary>
        public override long FrameStart => frameStart;
        long frameStart;

        /// <summary>
        /// Main constructor.
        /// </summary>
        /// <param name="container">The container to be written</param>
        /// <param name="containerHeader">The container header???</param>
        /// <param name="JBCDStream">The stream???</param>
        public ContainerWriterFile(Container container, DareHeader containerHeader, JBCDStream JBCDStream) {
            Container = container;
            frameStart = JBCDStream.PositionWrite;
            ContainerHeader = containerHeader;
            }

        /// <summary>
        /// Finish writing the frame
        /// </summary>
        /// <param name="dareTrailer">The trailer to write.</param>
        public override void CommitFrame(DareTrailer dareTrailer = null) {
            DareTrailer = dareTrailer;
            Container.CommitHeader(ContainerHeader, this);
            Container.Digest = DareTrailer?.TreeDigest ?? DareTrailer?.ChainDigest;
            }

        }

    /// <summary>
    /// Container writer to write in defered mode so that the updates can be applied in one transaction.
    /// </summary>
    public class ContainerWriterDeferred : ContainerWriter {

        long frameCount;


        ///<summary>The apex digest value of the container as written to the file.</summary>
        public byte[] Digest => DareTrailer.TreeDigest ?? DareTrailer.ChainDigest;


        // set up at the start of the transaction and allow multiple 'cached writes'

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="container">The container to be written</param>
        public ContainerWriterDeferred(Container container) {
            Container = container;
            frameCount = container.FrameCount;
            }


        /// <summary>
        /// Open a write stream
        /// </summary>
        /// <param name="contentMeta"></param>
        /// <param name="cryptoStack"></param>
        /// <param name="cloaked"></param>
        /// <param name="dataSequences"></param>
        public void StreamOpen(
                    ContentMeta contentMeta,
                    CryptoStack cryptoStack,
                    byte[] cloaked = null,
                    List<byte[]> dataSequences = null) {

            var containerInfo = new ContainerInfo() {
                Index = (int)frameCount++
                };

            ContainerHeader = new DareHeader() {
                ContainerInfo = containerInfo,
                ContentMeta = contentMeta
                };

            ContainerHeader.ApplyCryptoStack(cryptoStack, cloaked, dataSequences);



            Container.PrepareFrame(this);

            DareTrailer = null;

            return;
            }

        /// <summary>
        /// Close the write stream.
        /// </summary>
        public void StreamClose() => ContainerHeader.CloseBodyWriter(out DareTrailer);

        /// <summary>
        /// Write a fixed length body.
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public DareEnvelope End(byte[] body) {


            Container.MakeTrailer(ref DareTrailer);


            return new DareEnvelope() {
                Header = ContainerHeader,
                Body = body,
                Trailer = DareTrailer
                };

            }

        /// <summary>
        /// Finish writing the frame
        /// </summary>
        /// <param name="dareTrailer">The trailer to write.</param>
        public override void CommitFrame(DareTrailer dareTrailer = null) {



            }

        }
    }
