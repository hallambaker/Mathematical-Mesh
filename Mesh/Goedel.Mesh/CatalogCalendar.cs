using Goedel.Cryptography;
using Goedel.Cryptography.Dare;

using System;
using System.Collections;
using System.Collections.Generic;

namespace Goedel.Mesh {


    #region // The data classes CatalogCalendar, CatalogedTask

    /// <summary>
    /// Calendar catalog. Describes the tasks in a Mesh account.
    /// </summary>
    public class CatalogCalendar : Catalog {

        ///<summary>The canonical label for the catalog</summary>
        public const string Label = "mmm_Calendar";

        ///<summary>The catalog label</summary>
        public override string ContainerDefault => Label;

        ///<summary>Enumerate the catalog as CatalogedTask instances.</summary>
        public AsCatalogEntryTask AsCatalogEntryContact => new AsCatalogEntryTask(this);


        //public CatalogedTask LocateBySite(string Key) => Locate(Key) as CatalogedTask;

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
        public CatalogCalendar(
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

    // NYI should all be DareMessages to allow them to be signed.


    public partial class CatalogedTask {

        /// <summary>
        /// The primary key used to catalog the entry. 
        /// </summary>
        public override string _PrimaryKey => Key;

        /// <summary>
        /// Default constructor
        /// </summary>
        public CatalogedTask() => Key = UDF.Nonce();

        /// <summary>
        /// Constructor creating a task from the enveloped task <paramref name="task"/>.
        /// </summary>
        /// <param name="task">The task to create.</param>
        public CatalogedTask(DareEnvelope task) : this() => EnvelopedTask = task;

        /// <summary>
        /// Constructor creating a task from the task <paramref name="task"/>.
        /// </summary>
        /// <param name="task">The task to create.</param>
        public CatalogedTask(Task task) : this() => EnvelopedTask = DareEnvelope.Encode(task.GetBytes(tag: true),
                    contentType: "application/mmm");
        }
    #endregion
    #region // Enumerators and associated classes

    /// <summary>
    /// Enumerator class for sequences of <see cref="CatalogedTask"/> over a persistence
    /// store.
    /// </summary>
    public class EnumeratorCatalogEntryTask : IEnumerator<CatalogedTask> {
        
        IEnumerator<StoreEntry> baseEnumerator;

        ///<summary>The current item in the enumeration.</summary>
        public CatalogedTask Current => baseEnumerator.Current.JsonObject as CatalogedTask;
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
        public EnumeratorCatalogEntryTask(PersistenceStore persistenceStore) =>
            baseEnumerator = persistenceStore.GetEnumerator();
        }


    /// <summary>
    /// Enumerator class for sequences of <see cref="CatalogCalendar"/> over a Catalog
    /// </summary>
    public class AsCatalogEntryTask : IEnumerable<CatalogedTask> {
        CatalogCalendar catalog;

        /// <summary>
        /// Construct enumerator from <see cref="CatalogCalendar"/>,
        /// <paramref name="catalog"/>.
        /// </summary>
        /// <param name="catalog">The catalog to enumerate.</param>
        public AsCatalogEntryTask(CatalogCalendar catalog) => this.catalog = catalog;

        /// <summary>
        /// Return an enumerator for the catalog.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator<CatalogedTask> GetEnumerator() =>
                    new EnumeratorCatalogEntryTask(catalog.PersistenceStore);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();
        private IEnumerator GetEnumerator1() => this.GetEnumerator();
        }

    #endregion


    }
