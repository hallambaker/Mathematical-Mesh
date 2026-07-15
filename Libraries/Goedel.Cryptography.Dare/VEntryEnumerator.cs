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


/// <summary>Typed enumerator for catalog entries.</summary>
/// <typeparam name="T">The type of the catalog entry.</typeparam>
/// <remarks>Constructor, returns a new instance.</remarks>
/// <param name="catalog">The catalog to enumerate.</param>
/// 
public class VCatalogEnumerator<T>(VDareCatalog<T> catalog) : Disposable,
            IEnumerator<VDareEntryIndex<T>>, IEnumerable<VDareEntryIndex<T>> 
                where T : JsonObject, new() {

    IDictionaryEnumerator DictionaryEnumerator { get; set; }

    VDareCatalog<T> Catalog { get; } = catalog;


    /// <inheritdoc/>
    public VDareEntryIndex<T>? Current => (VDareEntryIndex<T>)DictionaryEnumerator.Value;

    /// <inheritdoc/>
    object IEnumerator.Current => Current;

    //bool Forward { get; } = forward;
    bool first=true;

    /// <inheritdoc/>
    public IEnumerator<VDareEntryIndex<T>> GetEnumerator() => this;

    /// <inheritdoc/>
    public bool MoveNext() {

        if (first) {
            DictionaryEnumerator = Catalog.EntriesById.GetEnumerator();
            first = false;
            }

        var next = DictionaryEnumerator.MoveNext();
        while (next) {
            if (next && Current?.Deleted != true) {
                return true;
                }
            next = DictionaryEnumerator.MoveNext();
            }

        return false;
        }

    /// <inheritdoc/>
    public void Reset() {
        first = true;

        }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
        }
    }



/// <summary>Untyped enumerator for untyped catalog index entries.</summary>
public class VEntryEnumerator : IEnumerator<VDareEntryIndex> , IEnumerable<VDareEntryIndex> {
    VDareSequence Sequence { get; }
    bool Forward { get; }
    Func<VDareEntryIndex, bool>? Process { get; }

    #region -- Implement IDispose
    /// <inheritdoc/>
    public void Dispose() {
        }

    #endregion
    #region --Implement IEnumerator
    /// <summary>Default constructor, return an enumerator on the sequence
    /// <paramref name="sequence"/>. This is also an enumerable returning itself.</summary>
    /// <param name="sequence">The sequence to enumerate.</param>
    /// <param name="forward">If true, enumerate in the forward direction,
    /// otherwise enumerate in reverse.</param>
    /// <param name="process">Processing delegate, if present and the value of <paramref name="forward"/>
    /// is false, the delegate is executed for each entry. If the delegate returns the value 
    /// false, the entry index is returned, otherwise it is ignored and the previous entry is
    /// processed.</param>
    public VEntryEnumerator(
                VDareSequence sequence, 
                bool forward=true,
                Func<VDareEntryIndex, bool>? process=null
                ) {
        Sequence = sequence;
        Forward = forward;
        Process = process;
        Reset();
        }

    /// <inheritdoc/>
    public VDareEntryIndex? Current { get; set; }
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
    public IEnumerator<VDareEntryIndex> GetEnumerator() => this;

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator(); 
    #endregion
    }

/// <summary>Untyped enumerator for catalog index entries of type <typeparamref name="T"/>.</summary>
/// <typeparam name="T"></typeparam>
public class VEntryEnumerator<T> : IEnumerator<VDareEntryIndex<T>>, IEnumerable<VDareEntryIndex<T>>
        where T : JsonObject {
    VDareSequence Sequence { get; }
    bool Forward { get; }
    Func<VDareEntryIndex<T>, bool>? Process { get; }

    #region -- Implement IDispose
    /// <inheritdoc/>
    public void Dispose() {
        }

    #endregion
    #region --Implement IEnumerator
    /// <summary>Default constructor, return an enumerator on the sequence
    /// <paramref name="sequence"/>. This is also an enumerable returning itself.</summary>
    /// <param name="sequence">The sequence to enumerate.</param>
    /// <param name="forward">If true, enumerate in the forward direction,
    /// otherwise enumerate in reverse.</param>
    /// <param name="process">Processing delegate, if present and the value of <paramref name="forward"/>
    /// is false, the delegate is executed for each entry. If the delegate returns the value 
    /// false, the entry index is returned, otherwise it is ignored and the previous entry is
    /// processed.</param>
    public VEntryEnumerator(
                VDareSequence sequence,
                bool forward = true,
                Func<VDareEntryIndex<T>, bool>? process = null
                ) {
        Sequence = sequence;
        Forward = forward;
        Process = process;
        Reset();
        }

    /// <inheritdoc/>
    public VDareEntryIndex<T>? Current { get; set; }
    object IEnumerator.Current => Current;



    /// <inheritdoc/>
    public bool MoveNext() {

        if (Forward) {
            Current = Sequence.Stream.ReadIndexNext<T>();
            }
        else if (Process == null) {
            Current = Sequence.Stream.ReadIndexPrevious<T>(Sequence.StartEntries);
            }
        else {
            Current = Sequence.Stream.ReadIndexPrevious<T>(Sequence.StartEntries);
            while (Current != null && Process(Current)) {
                Current = Sequence.Stream.ReadIndexPrevious<T>(Sequence.StartEntries);
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
    public IEnumerator<VDareEntryIndex<T>> GetEnumerator() => this;

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    #endregion
    }

