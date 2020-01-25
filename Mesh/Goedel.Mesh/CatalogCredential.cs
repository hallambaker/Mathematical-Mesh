using Goedel.Cryptography;
using Goedel.Cryptography.Dare;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Goedel.Mesh {

    #region // Enumerators and associated classes

    public class EnumeratorCatalogEntryCredential : IEnumerator<CatalogedCredential> {
        IEnumerator<ContainerStoreEntry> BaseEnumerator;

        public CatalogedCredential Current => BaseEnumerator.Current.JsonObject as CatalogedCredential;
        object IEnumerator.Current => Current;
        public void Dispose() => BaseEnumerator.Dispose();
        public bool MoveNext() => BaseEnumerator.MoveNext();
        public void Reset() => throw new NotImplementedException();

        public EnumeratorCatalogEntryCredential(ContainerPersistenceStore container) =>
            BaseEnumerator = container.GetEnumerator();
        }

    public class AsCatalogEntryCredential : IEnumerable<CatalogedCredential> {
        CatalogCredential Catalog;

        public AsCatalogEntryCredential(CatalogCredential catalog) => Catalog = catalog;

        public IEnumerator<CatalogedCredential> GetEnumerator() =>
                    new EnumeratorCatalogEntryCredential(Catalog.ContainerPersistence);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();
        private IEnumerator GetEnumerator1() => this.GetEnumerator();
        }

    #endregion



    public class CatalogCredential : Catalog {

        public const string Label = "mmm_Credential";

        public override string ContainerDefault => Label;
        public AsCatalogEntryCredential AsCatalogEntryCredential => new AsCatalogEntryCredential(this);

        protected override void Dispose(bool disposing) => base.Dispose(disposing);


        /// <summary>
        /// Locate credential matching the specified service name, ignoring the protocol value.
        /// </summary>
        /// <param name="key">The service to be matched.</param>
        /// <returns>If a match is found, returns the matching entry, otherwise null.</returns>
        public CatalogedCredential LocateByService(string key) {
            foreach (var Credential in AsCatalogEntryCredential) {
                if (Credential.Service == key) {
                    return Credential;
                    }
                }
            return null;
            }



        //Locate(Key) as CatalogEntryCredential;


        public CatalogCredential(string directory, string ContainerName = null,
            CryptoParameters cryptoParameters = null,
                    KeyCollection keyCollection = null,
                    bool create = true) :
            base(directory, ContainerName, cryptoParameters, keyCollection, create: create) {
            }

        public static Store Factory(string directory, string containerName = null) =>
                new CatalogCredential(directory, containerName);

        }


    public partial class CatalogedCredential {
        ///<summary>The primary key is protocol:site </summary>
        public override string _PrimaryKey => $"{Protocol ?? ""}:{Service ?? ""}";

        //public override List<string> _Keys => base._Keys;
        //List<string> keys = new List<string> { "Service" };

        //public override List<KeyValuePair<string, string>> _KeyValues => base._KeyValues;

        /// <summary>
        /// Converts the value of this instance to a <see langword="String"/>.
        /// </summary>
        /// <returns>The current string.</returns>
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
