using Goedel.Cryptography;
using Goedel.Cryptography.Dare;

using System;
using System.Collections;
using System.Collections.Generic;

namespace Goedel.Mesh {


    #region // The data classes CatalogApplication, CatalogedApplication

    /// <summary>
    /// Device catalog. Describes the properties of all devices connected to the user's Mesh account.
    /// </summary>
    public class CatalogApplication : Catalog {
        ///<summary>The canonical label for the catalog</summary>
        public const string Label = "mmm_Application";
        
        ///<summary>The catalog label</summary>
        public override string ContainerDefault => Label;

        //public AsCatalogEntryContact AsCatalogEntryContact => new AsCatalogEntryContact(this);



        /// <summary>
        /// Return the application entry for the site <paramref name="key"/>.
        /// </summary>
        /// <param name="key">Unique identifier of the device to return.</param>
        /// <returns>The <see cref="CatalogedApplication"/> entry.</returns>
        public CatalogedApplication LocateBySite(string key) => Locate(key) as CatalogedApplication;


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

        public CatalogApplication(
                    string directory, 
                    string storeName = null,
                    CryptoParameters cryptoParameters = null,
                    KeyCollection keyCollection = null,
                    bool decrypt = true, bool create = true) :
            base(directory, storeName, cryptoParameters, keyCollection, decrypt: decrypt, create: create) {
            }

        }

    public partial class CatalogedApplication {

        /// <summary>
        /// The primary key used to catalog the entry.
        /// </summary>
        public override string _PrimaryKey => Key;



        }
    #endregion
    #region // Enumerators and associated classes


    /// <summary>
    /// Enumerator class for sequences of <see cref="CatalogedApplication"/> over a Catalog
    /// </summary>
    public class AsCatalogEntryApplication : IEnumerable<CatalogedApplication> {
        CatalogContact catalog;

        /// <summary>
        /// Construct enumerator from <see cref="CatalogDevice"/>,
        /// <paramref name="catalog"/>.
        /// </summary>
        /// <param name="catalog">The catalog to enumerate.</param>
        public AsCatalogEntryApplication(CatalogContact catalog) => this.catalog = catalog;

        /// <summary>
        /// Return an enumerator for the catalog.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator<CatalogedApplication> GetEnumerator() =>
                    new EnumeratorCatalogEntryApplication(catalog.PersistenceStore);


        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();
        private IEnumerator GetEnumerator1() => this.GetEnumerator();

        /// <summary>
        /// Enumerator class for sequences of <see cref="CatalogedApplication"/> over a persistence
        /// store.
        /// </summary>
        // ToDo: Decide if we shouls use this template with the inner enumerator a private accessor or as public.
        private class EnumeratorCatalogEntryApplication : IEnumerator<CatalogedApplication> {
            IEnumerator<StoreEntry> baseEnumerator;

            public CatalogedApplication Current => baseEnumerator.Current.JsonObject as CatalogedApplication;
            object IEnumerator.Current => Current;
            public void Dispose() => baseEnumerator.Dispose();
            public bool MoveNext() => baseEnumerator.MoveNext();
            public void Reset() => throw new NotImplementedException();

            public EnumeratorCatalogEntryApplication(PersistenceStore container) =>
                baseEnumerator = container.GetEnumerator();
            }
        }

    #endregion


    }
