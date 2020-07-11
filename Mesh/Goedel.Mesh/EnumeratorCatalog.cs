using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Protocol;
using Goedel.Utilities;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Goedel.Mesh {
    /// <summary>
    /// Enumerator class for sequences of <see cref="CatalogedDevice"/> over a Catalog
    /// </summary>
    public class AsCatalogedType<T> : IEnumerable<T> where T : CatalogedEntry  {
        PersistenceStore PersistenceStore { get; }

        /// <summary>
        /// Construct enumerator from <see cref="CatalogDevice"/>,
        /// <paramref name="catalog"/>.
        /// </summary>
        /// <param name="catalog">The catalog to enumerate.</param>
        public AsCatalogedType(PersistenceStore catalog) => this.PersistenceStore = catalog;

        /// <summary>
        /// Return an enumerator for the catalog.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator<T> GetEnumerator() =>
                    new EnumeratorAsCatalogedType<T>(PersistenceStore) as IEnumerator<T>;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();
        private IEnumerator GetEnumerator1() => this.GetEnumerator();
        }


    /// <summary>
    /// Enumerator class for sequences of <see cref="CatalogedDevice"/> over a persistence
    /// store.
    /// </summary>
    public class EnumeratorAsCatalogedType<T> : IEnumerator<T> where T : CatalogedEntry {
        IEnumerator<StoreEntry> baseEnumerator;

        ///<summary>The current item in the enumeration.</summary>
        public T Current => baseEnumerator.Current.JsonObject as T;

        object IEnumerator.Current => Current;

        /// <summary>
        /// Disposal method.
        /// </summary>
        public void Dispose() => baseEnumerator.Dispose();

        /// <summary>
        /// Move to the next item in the enumeration.
        /// </summary>
        /// <returns><see langword="true"/> if there was a next item to return, otherwise,
        /// <see langword="false"/>.</returns>
        public bool MoveNext() => baseEnumerator.MoveNext();

        /// <summary>
        /// Restart the enumeration.
        /// </summary>
        public void Reset() => throw new NotImplementedException();

        /// <summary>
        /// Construct enumerator from <see cref="PersistenceStore"/>,
        /// <paramref name="persistenceStore"/>.
        /// </summary>
        /// <param name="persistenceStore">The persistence store to enumerate.</param>
        public EnumeratorAsCatalogedType(PersistenceStore persistenceStore) => 
                    baseEnumerator = persistenceStore.GetEnumerator();
        }



    }
