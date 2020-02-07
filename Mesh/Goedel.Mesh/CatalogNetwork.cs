using Goedel.Cryptography;
using Goedel.Cryptography.Dare;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Goedel.Mesh {

    #region // The data classes CatalogNetwork, CatalogedNetwork
    /// <summary>
    /// Device catalog. Describes the network entries in a Mesh account.
    /// </summary>
    public class CatalogNetwork : Catalog {
        ///<summary>The canonical label for the catalog</summary>
        public const string Label = "mmm/Network";
        
        ///<summary>The catalog label</summary>
        public override string ContainerDefault => Label;

        ///<summary>Enumerate the catalog as CatalogedNetwork instances.</summary>
        public AsCatalogEntryNetwork AsCatalogEntryNetwork => new AsCatalogEntryNetwork(this);

        /// <summary>
        /// Locate credential matching the specified service name, ignoring the protocol value.
        /// </summary>
        /// <param name="key">The service to be matched.</param>
        /// <returns>If a match is found, returns the matching entry, otherwise null.</returns>
        public CatalogedNetwork LocateByService(string key) {
            foreach (var network in AsCatalogEntryNetwork) {
                if (network.Service == key) {
                    return network;
                    }
                }
            return null;
            }



        //Locate(Key) as CatalogEntryCredential;

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

        public CatalogNetwork(
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


    public partial class CatalogedNetwork {
        ///<summary>The primary key is protocol:site </summary>
        public override string _PrimaryKey => PrimaryKey(Protocol, Service);

        /// <summary>
        /// Compute a primary key from the values <paramref name="protocol"/> and
        /// <paramref name="service"/>
        /// </summary>
        /// <param name="protocol">The protocol name.</param>
        /// <param name="service">The service name</param>
        /// <returns>The computed primary key.</returns>
        public static string PrimaryKey(string protocol, string service) =>
            $"{protocol ?? ""}:{service ?? ""}";


        /// <summary>
        /// Converts the value of this instance to a <see langword="String"/>.
        /// </summary>
        /// <returns>The current string.</returns>
        public override string ToString() {
            var stringBuilder = new StringBuilder();
            if (Protocol != null) {
                stringBuilder.Append("{Protocol}:");
                }
            stringBuilder.Append("{Username}@{Service} = [{Password}]");

            return stringBuilder.ToString();

            }

        }

    #endregion
    #region // Enumerators and associated classes

    /// <summary>
    /// Enumerator class for sequences of <see cref="CatalogedNetwork"/> over a persistence
    /// store.
    /// </summary>
    public class EnumeratorCatalogEntryNetwork : IEnumerator<CatalogedNetwork> {
        IEnumerator<StoreEntry> BaseEnumerator;

        ///<summary>The current item in the enumeration.</summary>
        public CatalogedNetwork Current => BaseEnumerator.Current.JsonObject as CatalogedNetwork;
        object IEnumerator.Current => Current;

        /// <summary>
        /// Disposal method.
        /// </summary>
        public void Dispose() => BaseEnumerator.Dispose();

        /// <summary>
        /// Move to the next item in the enumeration.
        /// </summary>
        /// <returns>The next item in the enumeration</returns>
        public bool MoveNext() => BaseEnumerator.MoveNext();

        /// <summary>
        /// Restart the enumeration.
        /// </summary>
        public void Reset() => throw new NotImplementedException();
        /// <summary>
        /// Construct enumerator from <see cref="PersistenceStore"/>,
        /// <paramref name="persistenceStore"/>.
        /// </summary>
        /// <param name="persistenceStore">The persistence store to enumerate.</param>
        public EnumeratorCatalogEntryNetwork(PersistenceStore persistenceStore) =>
            BaseEnumerator = persistenceStore.GetEnumerator();
        }

    /// <summary>
    /// Enumerator class for sequences of <see cref="CatalogedNetwork"/> over a Catalog
    /// </summary>
    public class AsCatalogEntryNetwork : IEnumerable<CatalogedNetwork> {
        CatalogNetwork catalog;

        /// <summary>
        /// Construct enumerator from <see cref="CatalogNetwork"/>,
        /// <paramref name="catalog"/>.
        /// </summary>
        /// <param name="catalog">The catalog to enumerate.</param>
        public AsCatalogEntryNetwork(CatalogNetwork catalog) => this.catalog = catalog;

        /// <summary>
        /// Return an enumerator for the catalog.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator<CatalogedNetwork> GetEnumerator() =>
                    new EnumeratorCatalogEntryNetwork(catalog.PersistenceStore);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();
        private IEnumerator GetEnumerator1() => this.GetEnumerator();
        }

    #endregion


    }
