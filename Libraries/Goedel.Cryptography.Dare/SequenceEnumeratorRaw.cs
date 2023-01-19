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
/// Enumerator that returns the raw, unencrypted Sequence data.
/// </summary>
public class SequenceEnumeratorRaw : IEnumerator<DareEnvelope> {
    Sequence Sequence { get; }
    long LowIndex { get; }
    bool Reverse { get; }


    /// <summary>
    /// Gets the element in the collection at the current position of the enumerator.
    /// </summary>
    public DareEnvelope Current { get; private set; } = null;

    SequenceIndexEntry indexEntry;


    /// <summary>
    /// Create an enumerator for <paramref name="sequence"/>.
    /// </summary>
    /// <param name="lowIndex">The lowest index to be returned.</param>
    /// <param name="reverse">If true, enumeratre from the last item to <paramref name="lowIndex"/> (inclusive).
    /// otherwise, enumerate from <paramref name="lowIndex"/> to the first.</param>
    /// <param name="sequence">The Sequence to enumerate.</param>
    public SequenceEnumeratorRaw(Sequence sequence, long lowIndex = 0, bool reverse = false) {
        Sequence = sequence;
        LowIndex = lowIndex;
        Reverse = reverse;

        Reset();
        }

    /// <summary>
    /// When called on an instance of this class, returns the instance. Thus allowing
    /// selectors to be used in sub classes.
    /// </summary>
    /// <returns>This instance</returns>
    public SequenceEnumeratorRaw GetEnumerator() => this;

    object IEnumerator.Current => Current;

    /// <summary>
    /// Dispose method.
    /// </summary>
    public void Dispose() {
        GC.SuppressFinalize(this);
        }

    /// <summary>
    /// Move to the next item in the enumeration.
    /// </summary>
    /// <returns>If true, the next item was found. Otherwise, the end of the enumeration 
    /// was reached.</returns>
    public bool MoveNext() {
        if (Reverse) {
            Current = indexEntry?.GetEnvelope();
            indexEntry = Sequence.Previous(indexEntry);
            }
        else {
            indexEntry = Sequence.Next(indexEntry);
            Current = indexEntry?.GetEnvelope();
            }
        return Current.Index >= LowIndex;
        }

    /// <summary>
    /// Sets the enumerator to its initial position, which is before the first element 
    /// in the collection.
    /// </summary>
    public void Reset() {
        indexEntry = Reverse ? Sequence.FrameLast() : Sequence.Frame(LowIndex);
        }
    }
