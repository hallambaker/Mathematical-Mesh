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
/// Simple Sequence that supports the append and index functions but does not 
/// provide for cryptographic integrity.
/// </summary>
/// <threadsafety static="true" instance="false"/>
public class SequenceChain : SequenceDigest {



    /// <summary>
    /// Default constructor
    /// </summary>
    public SequenceChain() {
        }


    /// <summary>
    /// Initialize the dictionaries used to manage the tree by registering the set
    /// of values leading up to the apex value.
    /// </summary>
    /// <param name="header">Final frame header</param>
    /// <param name="firstPosition">PositionRead of frame 1</param>
    /// <param name="positionLast">PositionRead of the last frame</param>
    protected override void FillDictionary(
                    SequenceInfo header,
                    long firstPosition,
                    long positionLast) =>
        base.FillDictionary(header, firstPosition, positionLast);


    /// <summary>
    /// Append the header to the frame. This is called after the payload data
    /// has been passed using AppendPreprocess.
    /// </summary>
    public override void PrepareFrame(
                    SequenceWriter contextWrite
                    ) {

        base.PrepareFrame(contextWrite);
        }

    /// <summary>
    /// Pre-populate the dummy trailer so as to allow the length to be calculated.
    /// </summary>
    /// <returns>The dummy trailer.</returns>
    public override DareTrailer FillDummyTrailer(
                    CryptoStack cryptoStack
                    ) { // should be complete dummy trailer or sommat... 

        var Trailer = cryptoStack.GetDummyTrailer();
        Trailer.ChainDigest = Trailer.PayloadDigest;

        return Trailer;
        }

    /// <summary>
    /// The dummy trailer to add to the end of the frame.
    /// </summary>
    /// <param name="trailer">The trailer to augment.</param>
    public override void MakeTrailer(ref DareTrailer trailer) {
        trailer ??= CryptoParametersSequence.GetNullTrailer();

        if (HeaderFinal != null) {
            trailer.ChainDigest = CryptoParametersSequence.CombineDigest(HeaderFinal.ChainDigest, trailer.PayloadDigest);
            }
        else {
            trailer.ChainDigest = CryptoParametersSequence.CombineDigest(null, trailer.PayloadDigest);
            }
        }


    #region // Verification
    /// <summary>
    /// Perform sanity checking on a list of Sequence headers.
    /// </summary>
    /// <param name="headers">List of headers to check</param>
    public override void CheckSequence(List<DareHeader> headers) {
        int Index = 1;
        foreach (var Header in headers) {
            Assert.AssertNotNull(Header.SequenceInfo, SequenceDataCorrupt.Throw);


            Assert.AssertTrue(Header.SequenceInfo.LIndex == Index, SequenceDataCorrupt.Throw);
            Assert.AssertNotNull(Header.PayloadDigest, SequenceDataCorrupt.Throw);
            Index++;
            }
        }
    #endregion
    }
