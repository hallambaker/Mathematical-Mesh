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
/// PersistentIndexEntry for a catalog entry.
/// </summary>
/// <typeparam name="T">The cataloged type.</typeparam>
public class CatalogIndexEntry<T> : PersistentIndexEntry where T : CatalogedEntry {


    ///<summary>The underlying spool.</summary> 
    public override PersistenceStore PersistenceStore => Catalog.PersistenceStore;

    ///<summary>The underlying spool.</summary> 
    public Catalog<T> Catalog => Sequence.InternDelegate as Catalog<T>;

    ///<summary>Convenience property returning the cataloged entry in its native type.</summary> 
    public T CatalogedEntry => JsonObject as T;

    /// <summary>
    /// Constructor, returns a catalog index entry in the sequence <paramref name="sequence"/>.
    /// </summary>
    /// <param name="sequence">The sequence to which the entry is bound.</param>
    public CatalogIndexEntry(Sequence sequence): base() {
        (sequence?.InternDelegate as Catalog<T>).AssertNotNull(NYI.Throw);
        Sequence = sequence;
        }

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
            ) => new CatalogIndexEntry<T>(sequence) {
                FramePosition = framePosition,
                FrameLength = frameLength,
                DataPosition = dataPosition,
                DataLength = dataLength,
                Header = header,
                Trailer = trailer,
                JsonObject = jsonObject
                };

    }




