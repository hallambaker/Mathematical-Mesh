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

namespace Goedel.Mesh;

/// <summary>
/// Enumerate the envelopes in a DARE store.
/// </summary>
public class StoreEnumerateEnvelope : IEnumerator<DareEnvelope>, IEnumerable<DareEnvelope> {
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
    public StoreEnumerateEnvelope(
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

/// <summary>
/// Enumerator class for sequences of <see cref="CatalogedDevice"/> over a Catalog
/// </summary>
public class CatalogEnumerateItem<T> : IEnumerator<T>, IEnumerable<T> where T : CatalogedEntry {
    #region Properties
    SequenceEnumeratorIndex SequenceEnumeratorIndex { get; }

    ///<inheritdoc/>
    public T Current => SequenceEnumeratorIndex.Current.JsonObject as T;

    ///<inheritdoc/>
    public IEnumerator<T> GetEnumerator() => this;

    ///<inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() => this;

    object IEnumerator.Current => Current;
    #endregion
    #region Constructors

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
    public CatalogEnumerateItem(
                Sequence sequence,
                long start,
                bool reverse = true,
                FilterIndexDelegate evaluateIndex = null,
                bool skip = false) {
        SequenceEnumeratorIndex = new SequenceEnumeratorIndex(sequence, start, reverse,
                    filter: evaluateIndex, skip: skip);
        }





    #endregion
    #region Implementation
    ///<inheritdoc/>
    public bool MoveNext() => SequenceEnumeratorIndex.MoveNext();

    ///<inheritdoc/>
    public void Reset() => SequenceEnumeratorIndex.Reset();

    ///<inheritdoc/>
    public void Dispose() => SequenceEnumeratorIndex.Dispose(); 
    #endregion
    }

/// <summary>
/// Spool enumerator, returns a sequence of <see cref="SpoolIndexEntry"/> instances
/// matching a specified set of conditions.
/// </summary>
public class SpoolEnumerator : IEnumerator<SpoolIndexEntry>, IEnumerable<SpoolIndexEntry> {
    #region Properties
    SequenceEnumeratorIndex SequenceEnumeratorIndex { get; }

    ///<inheritdoc/>
    public SpoolIndexEntry Current => SequenceEnumeratorIndex.Current as SpoolIndexEntry;
    ///<inheritdoc/>
    public IEnumerator<SpoolIndexEntry> GetEnumerator() => this;

    ///<inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() => this;

    object IEnumerator.Current => Current;

    #endregion
    #region Constructors
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
    public SpoolEnumerator(
                Sequence sequence,
                long start,
                bool reverse = true,
                FilterIndexDelegate evaluateIndex = null,
                bool skip = false) {
        SequenceEnumeratorIndex = new SequenceEnumeratorIndex(sequence, start, reverse,
                    filter: evaluateIndex, skip: skip);
        }

    #endregion
    #region Implementation
    ///<inheritdoc/>
    public bool MoveNext() => SequenceEnumeratorIndex.MoveNext();

    ///<inheritdoc/>
    public void Reset() => SequenceEnumeratorIndex.Reset();

    ///<inheritdoc/>
    public void Dispose() => SequenceEnumeratorIndex.Dispose();


    #endregion
    }

/// <summary>
/// Spool enumerator, returns a sequence of <see cref="Message"/> instances
/// matching a specified set of conditions.
/// </summary>
public class SpoolEnumerateMessage : IEnumerator<Message>, IEnumerable<Message> {
    #region Properties
    SequenceEnumeratorIndex SequenceEnumeratorIndex { get; }

    ///<inheritdoc/>
    public Message Current => SequenceEnumeratorIndex.Current.JsonObject as Message;
    ///<inheritdoc/>
    public IEnumerator<Message> GetEnumerator() => this;

    ///<inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() => this;

    object IEnumerator.Current => Current;

    #endregion
    #region Constructors
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
    public SpoolEnumerateMessage(
                Sequence sequence,
                long start,
                bool reverse = true,
                FilterIndexDelegate evaluateIndex = null,
                bool skip = false) {
        SequenceEnumeratorIndex = new SequenceEnumeratorIndex(sequence, start, reverse,
                    filter: evaluateIndex, skip: skip);
        }

    #endregion
    #region Implementation

    ///<inheritdoc/>
    public bool MoveNext() => SequenceEnumeratorIndex.MoveNext();

    ///<inheritdoc/>
    public void Reset() => SequenceEnumeratorIndex.Reset();

    ///<inheritdoc/>
    public void Dispose() => SequenceEnumeratorIndex.Dispose(); 
    #endregion
    }