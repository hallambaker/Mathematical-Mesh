using Goedel.Utilities;

namespace Goedel.Cryptography.Dare {

    /// <summary>
    /// Base class for container writers.
    /// </summary>
    public class SequenceWriter {

        ///<summary>The container to be written to.</summary>
        protected Sequence Sequence;

        ///<summary>Property allowing access to the crypto parameters and policy governing
        ///the container.</summary> 
        public CryptoParametersSequence CryptoParametersSequence =>
                Sequence.CryptoParametersSequence;

        ///<summary>The last container header written</summary>
        public DareHeader SequenceHeader;




        ///<summary>SequenceInfo element of last container header written.</summary>
        public SequenceInfo SequenceInfo => SequenceHeader.SequenceInfo;

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
    /// Sequence writer to write direct to a file.
    /// </summary>
    public class SequenceWriterFile : SequenceWriter {

        ///<summary>Position of the frame start.</summary>
        public override long FrameStart => frameStart;
        long frameStart;

        /// <summary>
        /// Main constructor.
        /// </summary>
        /// <param name="sequence">The sequence to be written</param>
        /// <param name="header">The sequence header???</param>
        /// <param name="JBCDStream">The stream???</param>
        public SequenceWriterFile(Sequence sequence, DareHeader header, JbcdStream JBCDStream) {
            base.Sequence = sequence;
            frameStart = JBCDStream.PositionWrite;
            SequenceHeader = header;
            }

        /// <summary>
        /// Finish writing the frame
        /// </summary>
        /// <param name="dareTrailer">The trailer to write.</param>
        public override void CommitFrame(DareTrailer dareTrailer = null) {
            DareTrailer = dareTrailer;
            Sequence.CommitHeader(SequenceHeader, this);
            Sequence.Digest = DareTrailer?.TreeDigest ?? DareTrailer?.ChainDigest;
            }

        }

    /// <summary>
    /// Sequence writer to write in defered mode so that the updates can be applied in one transaction.
    /// </summary>
    public class SequenceWriterDeferred : SequenceWriter {

        long frameCount;


        ///<summary>The apex digest value of the container as written to the file.</summary>
        public byte[] Digest => DareTrailer.TreeDigest ?? DareTrailer.ChainDigest;


        // set up at the start of the transaction and allow multiple 'cached writes'

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="sequence">The container to be written</param>
        public SequenceWriterDeferred(Sequence sequence) {
            Sequence = sequence;
            frameCount = sequence.FrameCount;
            }

        /// <summary>
        /// Prepare the sequence information for a new frame to be added to the sequence.
        /// </summary>
        /// <returns>The new sequence information</returns>
        public SequenceInfo PrepareSequenceInfo() => new() {
            Index = (int)frameCount++
            };


        /// <summary>
        /// Open a write stream
        /// </summary>
        public void StreamOpen() {
            Sequence.PrepareFrame(this);
            DareTrailer = null;
            return;
            }

        /// <summary>
        /// Close the write stream.
        /// </summary>
        public void StreamClose() => SequenceHeader.CloseBodyWriter(out DareTrailer);

        /// <summary>
        /// Write a fixed length body.
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public DareEnvelope End(byte[] body) {


            Sequence.MakeTrailer(ref DareTrailer);


            return new DareEnvelope() {
                Header = SequenceHeader,
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
