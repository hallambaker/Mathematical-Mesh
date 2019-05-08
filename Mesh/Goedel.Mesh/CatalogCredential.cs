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

    public class EnumeratorCatalogEntryCredential : IEnumerator<CatalogEntryCredential> {
        IEnumerator<ContainerStoreEntry> BaseEnumerator;

        public CatalogEntryCredential Current => BaseEnumerator.Current.JsonObject as CatalogEntryCredential;
        object IEnumerator.Current => Current;
        public void Dispose() => BaseEnumerator.Dispose();
        public bool MoveNext() => BaseEnumerator.MoveNext();
        public void Reset() => throw new NotImplementedException();

        public EnumeratorCatalogEntryCredential(ContainerPersistenceStore container) =>
            BaseEnumerator = container.GetEnumerator();
        }

    public class AsCatalogEntryCredential : IEnumerable<CatalogEntryCredential> {
        CatalogCredential Catalog;

        public AsCatalogEntryCredential(CatalogCredential catalog) => Catalog = catalog;

        public IEnumerator<CatalogEntryCredential> GetEnumerator() =>
                    new EnumeratorCatalogEntryCredential(Catalog.ContainerPersistence);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();
        private IEnumerator GetEnumerator1() => this.GetEnumerator();
        }

    #endregion



    public class CatalogCredential : Catalog {

        public const string Label = "CatalogCredential";

        public override string ContainerDefault => Label;
        public AsCatalogEntryCredential AsCatalogEntryCredential => new AsCatalogEntryCredential(this);

        /// <summary>
        /// Locate credential matching the specified service name, ignoring the protocol value.
        /// </summary>
        /// <param name="key">The service to be matched.</param>
        /// <returns>If a match is found, returns the matching entry, otherwise null.</returns>
        public CatalogEntryCredential LocateByService(string key) {
            foreach (var Credential in AsCatalogEntryCredential) {
                if (Credential.Service == key) {
                    return Credential;
                    }
                }
            return null;
            }
            
            
            
            //Locate(Key) as CatalogEntryCredential;


        public CatalogCredential(string directory, string ContainerName=null,
            CryptoParameters cryptoParameters = null,
                    keyCollection keyCollection = null) :
            base(directory, ContainerName, cryptoParameters, keyCollection) {
            }

        public static Store Factory(string directory, string containerName = null) =>
                new CatalogCredential(directory, containerName);

        }


    public partial class CatalogEntryCredential {
        ///<summary>The primary key is protocol:site </summary>
        public override string _PrimaryKey => $"{Protocol??""}:{Service??""}";

        //public override List<string> _Keys => base._Keys;
        //List<string> keys = new List<string> { "Service" };

        //public override List<KeyValuePair<string, string>> _KeyValues => base._KeyValues;


        public override string ToString() {
            var stringBuilder = new StringBuilder();
            if (Protocol != null) {
                stringBuilder.Append($"{Protocol}:");
                }
            stringBuilder.AppendLine($"{Username}@{Service} = [{Password}]");

            return stringBuilder.ToString();

            }

        }
    }
