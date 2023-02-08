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

public partial class PersistentIndexEntry : SequenceIndexEntry {

    ///<summary>The underlying spool.</summary> 
    public PersistenceStore PersistenceStore => Sequence.Store as PersistenceStore;


    /// <summary>
    /// Factory method implementing <see cref="SequenceIndexEntryFactoryDelegate"/>.
    /// </summary>
    /// <inheritdoc cref="SequenceIndexEntryFactoryDelegate"/>
    public static new SequenceIndexEntry Factory(
            Sequence sequence,
            long framePosition,
            long frameLength,
            long dataPosition,
            long dataLength,
            DareHeader header,
            DareTrailer trailer = null,
            JsonObject jsonObject = null
            ) => new PersistentIndexEntry(sequence) {
                FramePosition = framePosition,
                FrameLength = frameLength,
                DataPosition = dataPosition,
                DataLength = dataLength,
                Header = header,
                Trailer = trailer,
                JsonObject = jsonObject
                };

    /// <summary>
    /// Constructor returning a in instance bound to the sequence <paramref name="sequence"/>
    /// </summary>
    /// <param name="sequence">The sequence the index is bound to.</param>
    PersistentIndexEntry(Sequence sequence) {
        (sequence?.Store as PersistenceStore).AssertNotNull(NYI.Throw);
        Sequence = sequence;
        }

    ///<inheritdoc/>
    public override void Intern() => PersistenceStore.Intern(this);

    }
