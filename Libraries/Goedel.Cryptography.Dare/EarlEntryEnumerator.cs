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
using System.Diagnostics;

namespace Goedel.Cryptography.Dare;

public class EarlEntryEnumerator : IEnumerator<EarlEntryIndex> , IEnumerable<EarlEntryIndex> {
    EarlSequence Sequence { get; }
    bool Forward { get; }
    Func<EarlEntryIndex, bool>? Process { get; }

    #region -- Implement IDispose
    /// <inheritdoc/>
    public void Dispose() {
        }
    
    #endregion
    #region --Implement IEnumerator
        /// <summary>Default constructor, return an enumerator on the sequence
    /// <paramref name="sequence"/>. This is also an enumerable returning itself.</summary>
    /// <param name="sequence">The sequence to enumerate.</param>
    public EarlEntryEnumerator(
                EarlSequence sequence, 
                bool forward=true,
                Func<EarlEntryIndex, bool>? process=null
                ) {
        Sequence = sequence;
        Forward = forward;
        Process = process;
        Reset();
        }

    /// <inheritdoc/>
    public EarlEntryIndex? Current { get; set; }
    object IEnumerator.Current => Current;



    /// <inheritdoc/>
    public bool MoveNext() {

        if (Forward) {
            Current = Sequence.Stream.ReadIndexNext();
            }
        else if (Process == null) {
            Current = Sequence.Stream.ReadIndexPrevious(Sequence.StartEntries);
            }
        else {
            Current = Sequence.Stream.ReadIndexPrevious(Sequence.StartEntries);
            while (Current != null && Process(Current)) {
                Current = Sequence.Stream.ReadIndexPrevious(Sequence.StartEntries);
                }
            }

        return Current is not null; ;
        } 


    /// <inheritdoc/>
    public void Reset() {
        if (Forward) {

            Sequence.Stream.Position = Sequence.StartEntries;
            }
        else {
            Sequence.Stream.SeekEnd();
            }
        }

    #endregion
    #region -- Implement IEnumerable
    /// <inheritdoc/>
    public IEnumerator<EarlEntryIndex> GetEnumerator() => this;

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator(); 
    #endregion
    }

