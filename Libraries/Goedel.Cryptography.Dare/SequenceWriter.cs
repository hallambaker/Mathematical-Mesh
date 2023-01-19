#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion

namespace Goedel.Cryptography.Dare;

/// <summary>
/// Base class for Sequence writers.
/// </summary>
public class SequenceWriter {

    ///<summary>The Sequence to be written to.</summary>
    protected Sequence Sequence;

    ///<summary>Property allowing access to the crypto parameters and policy governing
    ///the Sequence.</summary> 
    public CryptoParametersSequence CryptoParametersSequence =>
            Sequence.CryptoParametersSequence;

    ///<summary>The last Sequence header written</summary>
    public DareHeader SequenceHeader;




    ///<summary>SequenceInfo element of last Sequence header written.</summary>
    public SequenceInfo SequenceInfo => SequenceHeader.SequenceInfo;

    ///<summary>The trailer of the envelope currently being written.</summary>
    public DareTrailer DareTrailer;

    ///<summary>PositionRead of the frame start.</summary>
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

    ///<summary>PositionRead of the frame start.</summary>
    public override long FrameStart => frameStart;

    readonly long frameStart;

    /// <summary>
    /// Main constructor.
    /// </summary>
    /// <param name="sequence">The Sequence to be written</param>
    /// <param name="header">The Sequence header???</param>
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

    ///<summary>A list of encryption keys to which additional recipient entries
    ///are to be created.</summary> 
    public List<KeyPair> AdditionalRecipients { get; set; }

    ///<summary>The apex digest value of the Sequence as written to the file.</summary>
    public byte[] Digest => DareTrailer.TreeDigest ?? DareTrailer.ChainDigest;


    // set up at the start of the transaction and allow multiple 'cached writes'

    /// <summary>
    /// Main constructor
    /// </summary>
    /// <param name="sequence">The Sequence to be written</param>
    public SequenceWriterDeferred(Sequence sequence) {
        Sequence = sequence;
        frameCount = sequence.FrameCount;
        }

    /// <summary>
    /// Prepare the Sequence information for a new frame to be added to the Sequence.
    /// </summary>
    /// <returns>The new Sequence information</returns>
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
