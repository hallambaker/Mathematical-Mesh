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
///// Enumerator class for sequences of <see cref="CatalogedDevice"/> over a Catalog
///// </summary>
//public class AsCatalogedType<T> : IEnumerable<T> where T : CatalogedEntry {
//    PersistenceStore PersistenceStore { get; }

//    /// <summary>
//    /// Construct enumerator from <see cref="CatalogDevice"/>,
//    /// <paramref name="catalog"/>.
//    /// </summary>
//    /// <param name="catalog">The catalog to enumerate.</param>
//    public AsCatalogedType(PersistenceStore catalog) => this.PersistenceStore = catalog;

//    /// <summary>
//    /// Return an enumerator for the catalog.
//    /// </summary>
//    /// <returns>The enumerator.</returns>
//    public IEnumerator<T> GetEnumerator() =>
//                new EnumeratorAsCatalogedType<T>(PersistenceStore) as IEnumerator<T>;

//    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();
//    private IEnumerator GetEnumerator1() => this.GetEnumerator();
//    }


///// <summary>
///// Enumerator class for sequences of <see cref="CatalogedDevice"/> over a persistence
///// store.
///// </summary>
//public class EnumeratorAsCatalogedType<T> : IEnumerator<T> where T : CatalogedEntry {
//    readonly IEnumerator<StoreEntry> baseEnumerator;

//    ///<summary>The current item in the enumeration.</summary>
//    public T Current => baseEnumerator.Current.JsonObject as T;

//    object IEnumerator.Current => Current;

//    /// <summary>
//    /// Disposal method.
//    /// </summary>
//    public void Dispose() => baseEnumerator.Dispose();

//    /// <summary>
//    /// Move to the next item in the enumeration.
//    /// </summary>
//    /// <returns><see langword="true"/> if there was a next item to return, otherwise,
//    /// <see langword="false"/>.</returns>
//    public bool MoveNext() => baseEnumerator.MoveNext();

//    /// <summary>
//    /// Restart the enumeration.
//    /// </summary>
//    public void Reset() => throw new NotImplementedException();

//    /// <summary>
//    /// Construct enumerator from <see cref="PersistenceStore"/>,
//    /// <paramref name="persistenceStore"/>.
//    /// </summary>
//    /// <param name="persistenceStore">The persistence store to enumerate.</param>
//    public EnumeratorAsCatalogedType(PersistenceStore persistenceStore) =>
//                baseEnumerator = persistenceStore.GetEnumerator();
//    }
