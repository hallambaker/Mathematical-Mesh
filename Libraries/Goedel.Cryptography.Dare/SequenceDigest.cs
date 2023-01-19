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
/// provide for linked cryptographic integrity.
/// </summary>
/// <threadsafety static="true" instance="false"/>
public class SequenceDigest : SequenceList {

    ///<summary>If true, the Sequence type requires a digest calculated on the payload.</summary> 
    public override bool DigestRequired => true;


    /// <summary>
    /// Default constructor
    /// </summary>

    public SequenceDigest(bool decrypt) : base(decrypt) {
        }


    /// <summary>
    /// Perform sanity checking on a list of Sequence headers.
    /// </summary>
    /// <param name="Headers">List of headers to check</param>
    public override void CheckSequence(List<DareHeader> Headers) {
        int Index = 1;
        foreach (var Header in Headers) {
            Assert.AssertNotNull(Header.SequenceInfo, SequenceDataCorrupt.Throw);

            Assert.AssertTrue(Header.SequenceInfo.LIndex == Index, SequenceDataCorrupt.Throw);

            if (HeaderFirst.SequenceInfo.ContainerType == DareConstants.SequenceTypeListTag) {
                Assert.AssertNull(Header.PayloadDigest, SequenceDataCorrupt.Throw);
                }
            else {
                Assert.AssertNotNull(Header.PayloadDigest, SequenceDataCorrupt.Throw);
                }
            Index++;
            }
        }
    }
