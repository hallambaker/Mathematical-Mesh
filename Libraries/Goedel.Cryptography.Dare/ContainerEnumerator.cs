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
public class ContainerEnumerator : IEnumerator<SequenceIndexEntry> {
    Sequence Sequence { get; }

    long First { get; }

    long Last { get; }

    /// <summary>
    /// Gets the element in the collection at the current position of the enumerator.
    /// </summary>
    public SequenceIndexEntry Current { get; set; }

    SequenceIndexEntry Next { get; set; }


    /// <summary>
    /// Create an enumerator for <paramref name="sequence"/>.
    /// </summary>
    /// <param name="sequence">The Sequence to enumerate.</param>
    public ContainerEnumerator(Sequence sequence, long frame = 1, long first = -1) {
        Sequence = sequence;
        First = frame;
        Last = first;
        Reset();
        }

    /// <summary>
    /// When called on an instance of this class, returns the instance. Thus allowing
    /// selectors to be used in sub classes.
    /// </summary>
    /// <returns>This instance</returns>
    public ContainerEnumerator GetEnumerator() => this;


    object IEnumerator.Current => Current;

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


    /// <summary>
    /// Sets the enumerator to its initial position, which is before the first element in the collection.
    /// </summary>
    public void Reset() {
        Next = Sequence.Frame(First);
        }
    }
