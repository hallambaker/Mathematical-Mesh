using Goedel.Cryptography;
using Goedel.Cryptography.Dare;

using System;
using System.Collections;
using System.Collections.Generic;

namespace Goedel.Mesh {


    /// <summary>
    /// Bookmark catalog. Describes the bookmarks in the user's Mesh account.
    /// </summary>
    public class CatalogBookmark : Catalog {
        
        ///<summary>The canonical label for the catalog</summary>
        public const string Label = "mmm/Bookmark";

        ///<summary>The catalog label</summary>
        public override string ContainerDefault => Label;

        ///<summary>Enumerate the catalog as CatalogedBookmark instances.</summary>
        public AsCatalogEntryBookmark AsCatalogEntryBookmark => new AsCatalogEntryBookmark(this);

        /// <summary>
        /// Constructor for a catalog named <paramref name="storeName"/> in directory
        /// <paramref name="directory"/> using the cryptographic parameters <paramref name="cryptoParameters"/>
        /// and key collection <paramref name="keyCollection"/>.
        /// </summary>
        /// <param name="create">Create a new persistence store on disk if it does not already exist.</param>
        /// <param name="decrypt">Attempt to decrypt the contents of the catalog if encrypted.</param>
        /// <param name="directory">The directory in which the catalog persistence container is stored.</param>
        /// <param name="storeName">The catalog persistence container file name.</param>
        /// <param name="cryptoParameters">The default cryptographic enhancements to be applied to container entries.</param>
        /// <param name="keyCollection">The key collection to be used to resolve keys when reading entries.</param>

        public CatalogBookmark(
                    string directory, 
                    string storeName = null,
                    CryptoParameters cryptoParameters = null,
                    KeyCollection keyCollection = null,
                    bool decrypt = true,
                    bool create = true) :
            base(directory, storeName ?? Label, 
                cryptoParameters, keyCollection, decrypt: decrypt, create: create) {
            }

        }


    public partial class CatalogedBookmark {
        ///<summary>The primary key is protocol:site </summary>
        public override string _PrimaryKey => Path;

        //public override string ToString() {
        //    throw new NYI();


        //    }

        }

    #region // Enumerators and associated classes

    /// <summary>
    /// Enumerator class for sequences of <see cref="CatalogedBookmark"/> over a persistence
    /// store.
    /// </summary>
    public class EnumeratorCatalogEntryBookmark : IEnumerator<CatalogedBookmark> {
        IEnumerator<ContainerStoreEntry> baseEnumerator;

        ///<summary>The current item in the enumeration.</summary>
        public CatalogedBookmark Current => baseEnumerator.Current.JsonObject as CatalogedBookmark;
        object IEnumerator.Current => Current;

        /// <summary>
        /// Disposal method.
        /// </summary>
        public void Dispose() => baseEnumerator.Dispose();

        /// <summary>
        /// Move to the next item in the enumeration.
        /// </summary>
        /// <returns>The next item in the enumeration</returns>
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
        public EnumeratorCatalogEntryBookmark(PersistenceStore persistenceStore) =>
            baseEnumerator = persistenceStore.GetEnumerator();
        }

    /// <summary>
    /// Enumerator class for sequences of <see cref="CatalogedBookmark"/> over a Catalog
    /// </summary>
    public class AsCatalogEntryBookmark : IEnumerable<CatalogedBookmark> {
        CatalogBookmark catalog;

        /// <summary>
        /// Construct enumerator from <see cref="CatalogBookmark"/>,
        /// <paramref name="catalog"/>.
        /// </summary>
        /// <param name="catalog">The catalog to enumerate.</param>
        public AsCatalogEntryBookmark(CatalogBookmark catalog) => this.catalog = catalog;

        /// <summary>
        /// Return an enumerator for the catalog.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator<CatalogedBookmark> GetEnumerator() =>
                    new EnumeratorCatalogEntryBookmark(catalog.PersistenceStore);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();
        private IEnumerator GetEnumerator1() => this.GetEnumerator();
        }

    #endregion


    }
