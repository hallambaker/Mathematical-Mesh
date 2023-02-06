//#region // Copyright - MIT License
////  © 2021 by Phill Hallam-Baker
////  
////  Permission is hereby granted, free of charge, to any person obtaining a copy
////  of this software and associated documentation files (the "Software"), to deal
////  in the Software without restriction, including without limitation the rights
////  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
////  copies of the Software, and to permit persons to whom the Software is
////  furnished to do so, subject to the following conditions:
////  
////  The above copyright notice and this permission notice shall be included in
////  all copies or substantial portions of the Software.
////  
////  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
////  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
////  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
////  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
////  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
////  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
////  THE SOFTWARE.
//#endregion



//using System.Collections;

//namespace Goedel.Mesh;

///// <summary>
///// Enumerator that returns the raw, unencrypted container data.
///// </summary>
//public class SpoolEnumeratorRaw : IEnumerator<SpoolEntry> {

//    // Parameters passed in from search criteria.
//    private readonly Spool spool;
//    private readonly MessageStatus select;

//    private readonly long maxResults;
//    private readonly SpoolEntry last;


//    bool Reverse {get; set;}

//    // Mask parameters.
//    private readonly bool checkMaxResults;


//    // Local variables
//    private long results;

//    ///<summary>The current enumerated value.</summary>
//    public SpoolEntry Current { get; private set; } = null;

//    /// <summary>
//    /// When called on an instance of this class, returns the instance. Thus allowing
//    /// selectors to be used in sub classes.
//    /// </summary>
//    /// <returns>This instance</returns>
//    public SpoolEnumeratorRaw GetEnumerator() => this;

//    object IEnumerator.Current => Current;

//    /// <summary>
//    /// Constructor for an enumerator on the store <paramref name="spool"/> with search constraints.
//    /// 
//    /// 
//    /// </summary>
//    /// <remarks>This enumerator is NOT currently thread safe though it should be.</remarks>
//    /// <param name="spool"></param>
//    /// <param name="select"></param>
//    /// <param name="notBefore"></param>
//    /// <param name="notOnOrAfter"></param>
//    /// <param name="last"></param>

//    /// <param name="maxResults"></param>
//    public SpoolEnumeratorRaw(
//                Spool spool,
//                MessageStatus select = MessageStatus.All,
//                System.DateTime? notBefore = null,
//                System.DateTime? notOnOrAfter = null,
//                SpoolEntry last = null,
//                long maxResults = -1,
//                bool reverse = true) {
//        notBefore.Future();
//        notOnOrAfter.Future();


//        this.spool = spool;
//        this.select = select;
//        this.last = last;
//        this.maxResults = maxResults;

//        this.select.Future();
//        Reverse = reverse;

//        checkMaxResults = maxResults >= 0;

//        Reset();

//        }

//    /// <summary>
//    /// Disposal method.
//    /// </summary>
//    public void Dispose() => GC.SuppressFinalize(this);

//    /// <summary>
//    /// Move to the next value in the enumeration.
//    /// </summary>
//    /// <returns>True if successful, otherwise false.</returns>
//    public bool MoveNext() {
//        while (true) {

//            if (Current is null) {
//                return false;
//                }

//            // Check the conditions for continuing to search
//            if (checkMaxResults && (results >= maxResults)) {
//                Current = null;
//                return false;
//                }


//            // move to the next item
//            Current = Reverse? spool.GetPrevious(Current) : spool.GetNext(Current);

//            // do we meet the selection criteria?
//            if (Current != null) {
//                results++;
//                return true;
//                }
//            return false;
//            }
//        }

//    /// <summary>
//    /// Reset the enumeration to the origin of the search.
//    /// </summary>
//    public void Reset() {
//        results = 0;
//        Current = last;
//        }



//    }
