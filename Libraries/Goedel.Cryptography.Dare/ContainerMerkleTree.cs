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
/// Simple container that supports the append and index functions but does not 
/// provide for cryptographic integrity.
/// </summary>
/// <threadsafety static="true" instance="false"/>
public class ContainerMerkleTree : ContainerTree {


    ///<summary>If true, the Container type requires a digest calculated on the payload.</summary> 
    public override bool DigestRequired => true;

    /// <summary>
    /// Default constructor
    /// </summary>

    public ContainerMerkleTree(bool decrypt=true) : base(decrypt) {
        }

    /// <summary>
    /// Create a new container file of the specified type and write the initial
    /// data record
    /// </summary>
    /// <param name="jbcdStream">The underlying JBCDStream stream. This MUST be opened
    /// in a read access mode and should have exclusive read access. All existing
    /// content in the file will be overwritten.</param>
    /// <returns>The newly constructed container.</returns>
    /// <param name="decrypt">If true, decrypt the container payload contents.</param>
    public static new Sequence MakeNewContainer(
                    JbcdStream jbcdStream,
                    bool decrypt=true) {

        var containerInfo = new SequenceInfo() {
            ContainerType = DareConstants.SequenceTypeMerkleTag,
            Index = 0
            };


        var containerHeader = new DareHeader() {
            SequenceInfo = containerInfo
            };

        var container = new ContainerMerkleTree(decrypt) {
            JbcdStream = jbcdStream,
            HeaderFirst = containerHeader
            };

        return container;
        }

    /// <summary>
    /// Prepare the ContainerInfo data for the frame.
    /// </summary>
    /// <param name="containerInfo">The frame to prepare.</param>
    protected override void PrepareFrame(SequenceInfo containerInfo) {
        if (containerInfo.Index == 0) {
            containerInfo.ContainerType = DareConstants.SequenceTypeMerkleTag;
            }
        else {
            containerInfo.TreePosition =
                (int)PreviousFramePosition(containerInfo.Index);
            }
        }




    //readonly static byte[] EmptyBytes = new byte[0];

    /// <summary>
    /// Register a frame in the container access dictionaries.
    /// </summary>
    /// <param name="containerInfo">Frame header</param>
    /// <param name="position">Position of the frame</param>
    protected override void RegisterFrame(SequenceInfo containerInfo, long position) {
        var Index = containerInfo.Index;
        FrameIndexToPositionDictionary.Add(Index, position);
        //FrameDigestDictionary.Add(Index, ContainerInfo.TreeDigest);
        }

    /// <summary>
    /// Dictionary mapping the frame index to the corresponding digest value.
    /// </summary>
    public Dictionary<long, byte[]> FrameDigestDictionary = new();


    /// <summary>
    /// Pre-populate the dummy trailer so as to allow the length to be calculated.
    /// </summary>
    /// <returns>The dummy trailer.</returns>
    public override DareTrailer FillDummyTrailer(CryptoStack cryptoStack) {

        var Trailer = cryptoStack.GetDummyTrailer();
        Trailer.TreeDigest = Trailer.PayloadDigest;

        return Trailer;
        }

    /// <summary>
    /// The dummy trailer to add to the end of the frame.
    /// </summary>
    ///<param name="trailer">The trailer to augment.</param>
    public override void MakeTrailer(ref DareTrailer trailer) {

        trailer ??= CryptoParametersSequence.GetNullTrailer();

        if (FrameCount > 0) {
            trailer.TreeDigest = GetTreeDigest(FrameCount, trailer.PayloadDigest);
            }
        else {
            trailer.TreeDigest = CryptoParametersSequence.CombineDigest(null, trailer.PayloadDigest);
            }
        }

    #region // Construct tree digest

    /// <summary>
    /// Calculate the digest of the specified tree node
    /// </summary>
    /// <param name="frame">The frame number</param>
    /// <param name="contentDigest">The content digest</param>
    /// <returns>The calculated digest</returns>
    public virtual byte[] GetTreeDigest(long frame, byte[] contentDigest) {
        long x2 = frame + 1;
        long d = 1;

        while (x2 > 0) {
            if ((x2 & 1) == 1) {
                return DigestFrame(x2 == 1 ? (d / 2) - 1 : frame - d, contentDigest);
                }
            else {
                contentDigest = DigestFrame(frame - d, contentDigest);
                }
            d *= 2;
            x2 /= 2;
            }
        return CryptoParametersSequence.CombineDigest(null, contentDigest);
        }

    /// <summary>
    /// Obtain the digest value for a frame.
    /// </summary>
    /// <param name="frame">The frame index.</param>
    /// <param name="right">The digest of the rightmost component.</param>
    /// <returns>The calculated digest.</returns>
    public byte[] DigestFrame(long frame, byte[] right) {
        var left = GetFrameDigest(frame);
        return CryptoParametersSequence.CombineDigest(left, right);
        }


    /// <summary>
    /// Get the digest value of the specified frame.
    /// </summary>
    /// <param name="Frame">The frame index.</param>
    /// <returns>The digest value.</returns>
    public virtual byte[] GetFrameDigest(long Frame) {
        FrameDigestDictionary.TryGetValue(Frame, out var digest);
        return digest;
        }

    #endregion
    #region // Verification
    /// <summary>
    /// Perform sanity checking on a list of container headers.
    /// </summary>
    /// <param name="headers">List of headers to check</param>
    public override void CheckSequence(List<DareHeader> headers) {
        int index = 1;
        foreach (var header in headers) {
            Assert.AssertNotNull(header.SequenceInfo,
                    SequenceDataCorrupt.Throw);

            Assert.AssertTrue(header.SequenceInfo.Index == index, SequenceDataCorrupt.Throw);
            Assert.AssertNotNull(header.PayloadDigest,
                    SequenceDataCorrupt.Throw);

            index++;
            }
        }

    #endregion
    }
