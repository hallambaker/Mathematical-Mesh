using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;
using System.Threading;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography;

namespace Goedel.Mesh {

    #region // Enumerators and associated classes

    public class EnumeratorCatalogEntryNetwork : IEnumerator<CatalogEntryNetwork> {
        IEnumerator<ContainerStoreEntry> BaseEnumerator;

        public CatalogEntryNetwork Current => BaseEnumerator.Current.JsonObject as CatalogEntryNetwork;
        object IEnumerator.Current => Current;
        public void Dispose() => BaseEnumerator.Dispose();
        public bool MoveNext() => BaseEnumerator.MoveNext();
        public void Reset() => throw new NotImplementedException();

        public EnumeratorCatalogEntryNetwork(ContainerPersistenceStore container) =>
            BaseEnumerator = container.GetEnumerator();
        }

    public class AsCatalogEntryNetwork : IEnumerable<CatalogEntryNetwork> {
        CatalogNetwork Catalog;

        public AsCatalogEntryNetwork(CatalogNetwork catalog) => Catalog = catalog;

        public IEnumerator<CatalogEntryNetwork> GetEnumerator() =>
                    new EnumeratorCatalogEntryNetwork(Catalog.ContainerPersistence);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();
        private IEnumerator GetEnumerator1() => this.GetEnumerator();
        }

    #endregion



    public class CatalogNetwork : Catalog {

        public const string Label = "CatalogNetwork";

        public override string ContainerDefault => Label;
        public AsCatalogEntryNetwork AsCatalogEntryNetwork => new AsCatalogEntryNetwork(this);

        /// <summary>
        /// Locate credential matching the specified service name, ignoring the protocol value.
        /// </summary>
        /// <param name="key">The service to be matched.</param>
        /// <returns>If a match is found, returns the matching entry, otherwise null.</returns>
        public CatalogEntryNetwork LocateByService(string key) {
            foreach (var network in AsCatalogEntryNetwork) {
                if (network.Service == key) {
                    return network;
                    }
                }
            return null;
            }
            
            
            
            //Locate(Key) as CatalogEntryCredential;


        public CatalogNetwork(string directory, string ContainerName=null,
            CryptoParameters cryptoParameters = null,
                    KeyCollection keyCollection = null) :
            base(directory, ContainerName, cryptoParameters, keyCollection) {
            }

        public static Store Factory(string directory, string containerName = null) =>
                new CatalogNetwork(directory, containerName);

        }


    public partial class CatalogEntryNetwork {
        ///<summary>The primary key is protocol:site </summary>
        public override string _PrimaryKey => $"{Protocol??""}:{Service??""}";

        //public override List<string> _Keys => base._Keys;
        //List<string> keys = new List<string> { "Service" };

        //public override List<KeyValuePair<string, string>> _KeyValues => base._KeyValues;


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
