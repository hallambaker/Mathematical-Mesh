using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using Goedel.IO;
using Goedel.Protocol;
using Goedel.Utilities;

namespace Goedel.Cryptography.Dare {


    public class ContainerWriter {
        protected Container Container;

        public ContainerHeader ContainerHeader;


        public DareTrailer DareTrailer;

        public virtual long FrameStart => throw new NYI();
        public virtual void CommitFrame(DareTrailer dareTrailer = null) {
            }

        }


    public class ContainerWriterFile: ContainerWriter {

        public override long FrameStart => frameStart;
        long frameStart;

        public ContainerWriterFile(Container container, ContainerHeader containerHeader, JBCDStream JBCDStream) {
            Container = container;
            frameStart = JBCDStream.PositionWrite;
            ContainerHeader = containerHeader;
            }

        public override void CommitFrame(DareTrailer dareTrailer = null) {
            DareTrailer = dareTrailer;
            Container.CommitHeader(ContainerHeader, this);
            Container.Digest = DareTrailer?.TreeDigest ?? DareTrailer?.ChainDigest;
            }

        }

    public class ContainerWriterDeferred: ContainerWriter {

        long FrameCount;


        ///<summary>The apex digest value of the container as written to the file.</summary>
        public byte[] Digest => DareTrailer.TreeDigest ?? DareTrailer.ChainDigest;


        // set up at the start of the transaction and allow multiple 'cached writes'

        public ContainerWriterDeferred(Container container) {
            Container = container;
            FrameCount = container.FrameCount;
            }



        public Stream StreamOpen(
                    Stream output,
                    ContentInfo contentInfo,
                    CryptoStack cryptoStack,
                    byte[] cloaked = null,
                        List<byte[]> dataSequences = null

            ) {
            ContainerHeader = new ContainerHeader() {
                Index = (int)FrameCount++,
                ContentInfo = contentInfo
                };
            ContainerHeader.ApplyCryptoStack(cryptoStack, cloaked, dataSequences);



            Container.PrepareFrame(this);

            DareTrailer = null;

            return ContainerHeader.BodyWriter(output);
            }

        public void StreamClose() {
            ContainerHeader.CloseBodyWriter(out DareTrailer);
            }


        public DareEnvelope End(byte[] body) {

            
            Container.MakeTrailer(ref DareTrailer);


            return new DareEnvelope() {
                Header = ContainerHeader,
                Body = body,
                Trailer = DareTrailer
                };

            }


        public override void CommitFrame(DareTrailer dareTrailer = null) {



            }

        }
    }
