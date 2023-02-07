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

using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace Goedel.Cryptography.Dare;






/// <summary>
/// Enumerator for frames in a Sequence beginning with frame 1.
/// </summary>
public class SequenceEnumeratorIndex : IEnumerator<SequenceIndexEntry>, IEnumerable<SequenceIndexEntry> {
    Sequence Sequence { get; }

    long First { get; }

    long Last { get; }

    SequenceIndexEntry Next { get; set; }



    ///<inheritdoc/>
    public SequenceIndexEntry Current { get; private set; }

    ///<inheritdoc/>
    public IEnumerator<SequenceIndexEntry> GetEnumerator() => this;

    ///<inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() => this;

    object IEnumerator.Current => Current;




    /// <summary>
    /// Constructor, returns an enumerator on the sequence <paramref name="sequence"/>, starting
    /// with the frame numbered <paramref name="start"/>. If <paramref name="reverse"/> is true, 
    /// results are returned from the last match first.
    /// </summary>
    /// <param name="sequence">The sequence to enumerate.</param>
    /// <param name="start">The starting point for the enumeration. If it matches, this will 
    /// be the first result returned.</param>
    /// <param name="reverse">If true, return results in the reverse order.</param>
    /// <param name="filter">If not null, specifies a filtering function on the 
    /// store entries.</param>
    /// <param name="skip">If true, the search MAY optimize search time by performing a binary
    /// search on the records. Note however that since this will cause entry update entries to
    /// be skipped, the status might be affected by one or more skipped records.</param>
    /// <param name="count">Maximum number of records to return.</param>
    public SequenceEnumeratorIndex(
                Sequence sequence,
                long start,
                bool reverse = true,
                long count = -1,
                FilterIndexDelegate filter = null,
                bool skip = false) {
        Sequence = sequence;

        throw new NYI();
        }


    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    /// 
    public void Dispose() {
        GC.SuppressFinalize(this);
        }

    /// <summary>
    /// Advances the enumerator to the next element of the collection.
    /// </summary>
    /// <returns><code>true</code> if the enumerator was successfully advanced to the next element; 
    /// <code>false</code> if the enumerator has passed the end of the collection.</returns>
    public bool MoveNext() {
        Current = (Next is not null) && (Last < 0 | Next.Index < Last) ? Next : null;
        if (Current is not null) {
            Next = Sequence.Next(Next);
            }
        return Current != null;
        }

    bool Forward() {
        Current = (Next is not null) && (Last < 0 | Next.Index < Last) ? Next : null;
        if (Current is not null) {
            Next = Sequence.Next(Next);
            }
        return Current != null;
        }

    bool Reverse() {

        Current = (Next is not null) && (Last < 0 | Next.Index < Last) ? Next : null;
        if (Current is not null) {
            Next = Sequence.Previous(Next);
            }
        return Current != null;


        }


    /// <summary>
    /// Sets the enumerator to its initial position, which is before the first element in the collection.
    /// </summary>
    public void Reset() {
        Next = Sequence.Frame(First);
        }
    }


/// <summary>
/// Enumerate the envelopes in a DARE store.
/// </summary>
public class SequenceEnumerateEnvelope : IEnumerator<DareEnvelope>, IEnumerable<DareEnvelope> {
    #region // Properties
    SequenceEnumeratorIndex SequenceEnumeratorIndex { get; }

    ///<inheritdoc/>
    public DareEnvelope Current => SequenceEnumeratorIndex.Current.GetEnvelope();

    ///<inheritdoc/>
    public IEnumerator<DareEnvelope> GetEnumerator() => this;

    ///<inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() => this;

    object IEnumerator.Current => Current;
    #endregion
    #region // Constructors
    /// <summary>
    /// Constructor, returns an enumerator on the sequence <paramref name="sequence"/>, starting
    /// with the frame numbered <paramref name="start"/>. If <paramref name="reverse"/> is true, 
    /// results are returned from the last match first.
    /// </summary>
    /// <param name="sequence">The sequence to enumerate.</param>
    /// <param name="start">The starting point for the enumeration. If it matches, this will 
    /// be the first result returned.</param>
    /// <param name="reverse">If true, return results in the reverse order.</param>
    /// <param name="evaluateIndex">If not null, specifies a filtering function on the 
    /// store entries.</param>
    /// <param name="skip">If true, the search MAY optimize search time by performing a binary
    /// search on the records. Note however that since this will cause entry update entries to
    /// be skipped, the status might be affected by one or more skipped records.</param>
    public SequenceEnumerateEnvelope(
                Sequence sequence,
                long start,
                bool reverse = true,
                FilterIndexDelegate evaluateIndex = null,
                bool skip = false) {
        SequenceEnumeratorIndex = new SequenceEnumeratorIndex(sequence, start, reverse,
                    filter: evaluateIndex, skip: skip);
        }
    #endregion
    #region // Implementation
    ///<inheritdoc/>
    public bool MoveNext() => SequenceEnumeratorIndex.MoveNext();

    ///<inheritdoc/>
    public void Reset() => SequenceEnumeratorIndex.Reset();

    ///<inheritdoc/>
    public void Dispose() => SequenceEnumeratorIndex.Dispose();
    #endregion
    }


