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

    public class EnumeratorCatalogEntryBookmark : IEnumerator<CatalogEntryBookmark> {
        IEnumerator<ContainerStoreEntry> BaseEnumerator;

        public CatalogEntryBookmark Current => BaseEnumerator.Current.JsonObject as CatalogEntryBookmark;
        object IEnumerator.Current => Current;
        public void Dispose() => BaseEnumerator.Dispose();
        public bool MoveNext() => BaseEnumerator.MoveNext();
        public void Reset() => throw new NotImplementedException();

        public EnumeratorCatalogEntryBookmark(ContainerPersistenceStore container) =>
            BaseEnumerator = container.GetEnumerator();
        }

    public class AsCatalogEntryBookmark : IEnumerable<CatalogEntryBookmark> {
        CatalogBookmark Catalog;

        public AsCatalogEntryBookmark(CatalogBookmark catalog) => Catalog = catalog;

        public IEnumerator<CatalogEntryBookmark> GetEnumerator() =>
                    new EnumeratorCatalogEntryBookmark(Catalog.ContainerPersistence);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();
        private IEnumerator GetEnumerator1() => this.GetEnumerator();
        }

    #endregion



    public class CatalogBookmark : Catalog {

        public const string Label = "CatalogBookmark";

        public override string ContainerDefault => Label;
        public AsCatalogEntryBookmark AsCatalogEntryBookmark => new AsCatalogEntryBookmark(this);

        ///// <summary>
        ///// Locate credential matching the specified service name, ignoring the protocol value.
        ///// </summary>
        ///// <param name="key">The service to be matched.</param>
        ///// <returns>If a match is found, returns the matching entry, otherwise null.</returns>
        //public CatalogEntryBookmark LocateByService(string key) {
        //    foreach (var Credential in AsCatalogEntryCredential) {
        //        if (Credential.Service == key) {
        //            return Credential;
        //            }
        //        }
        //    return null;
        //    }
            
            
            
            //Locate(Key) as CatalogEntryCredential;


        public CatalogBookmark(string directory, string ContainerName=null,
            CryptoParameters cryptoParameters = null,
                    KeyCollection keyCollection = null) :
            base(directory, ContainerName, cryptoParameters, keyCollection) {
            }

        public static Store Factory(string directory, string containerName = null) =>
                new CatalogBookmark(directory, containerName);

        }


    public partial class CatalogEntryBookmark {
        ///<summary>The primary key is protocol:site </summary>
        public override string _PrimaryKey => Uri;

        //public override List<string> _Keys => base._Keys;
        //List<string> keys = new List<string> { "Service" };

        //public override List<KeyValuePair<string, string>> _KeyValues => base._KeyValues;


        public override string ToString() {
            throw new NYI();
            //var stringBuilder = new StringBuilder();
            //if (Protocol != null) {
            //    stringBuilder.Append("{Protocol}:");
            //    }
            //stringBuilder.Append("{Username}@{Service} = [{Password}]");

            //return stringBuilder.ToString();

            }

        }
    }
