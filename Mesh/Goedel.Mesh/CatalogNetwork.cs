using Goedel.Cryptography;
using Goedel.Cryptography.Dare;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Goedel.Mesh {

    #region // Enumerators and associated classes

    public class EnumeratorCatalogEntryNetwork : IEnumerator<CatalogedNetwork> {
        IEnumerator<ContainerStoreEntry> BaseEnumerator;

        public CatalogedNetwork Current => BaseEnumerator.Current.JsonObject as CatalogedNetwork;
        object IEnumerator.Current => Current;
        public void Dispose() => BaseEnumerator.Dispose();
        public bool MoveNext() => BaseEnumerator.MoveNext();
        public void Reset() => throw new NotImplementedException();

        public EnumeratorCatalogEntryNetwork(ContainerPersistenceStore container) =>
            BaseEnumerator = container.GetEnumerator();
        }

    public class AsCatalogEntryNetwork : IEnumerable<CatalogedNetwork> {
        CatalogNetwork Catalog;

        public AsCatalogEntryNetwork(CatalogNetwork catalog) => Catalog = catalog;

        public IEnumerator<CatalogedNetwork> GetEnumerator() =>
                    new EnumeratorCatalogEntryNetwork(Catalog.ContainerPersistence);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();
        private IEnumerator GetEnumerator1() => this.GetEnumerator();
        }

    #endregion



    public class CatalogNetwork : Catalog {

        public const string Label = "mmm_Network";

        public override string ContainerDefault => Label;
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


        public CatalogNetwork(string directory, string ContainerName = null,
            CryptoParameters cryptoParameters = null,
                    KeyCollection keyCollection = null,
                    bool create = true) :
            base(directory, ContainerName, cryptoParameters, keyCollection, create: create) {
            }

        public static Store Factory(string directory, string containerName = null) =>
                new CatalogNetwork(directory, containerName);

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
    }
