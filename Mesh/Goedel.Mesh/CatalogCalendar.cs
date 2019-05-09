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

    public class EnumeratorCatalogEntryTask : IEnumerator<CatalogEntryTask> {
        IEnumerator<ContainerStoreEntry> BaseEnumerator;

        public CatalogEntryTask Current => BaseEnumerator.Current.JsonObject as CatalogEntryTask;
        object IEnumerator.Current => Current;
        public void Dispose() => BaseEnumerator.Dispose();
        public bool MoveNext() => BaseEnumerator.MoveNext();
        public void Reset() => throw new NotImplementedException();

        public EnumeratorCatalogEntryTask(ContainerPersistenceStore container) =>
            BaseEnumerator = container.GetEnumerator();
        }

    public class AsCatalogEntryTask : IEnumerable<CatalogEntryTask> {
        CatalogCalendar Catalog;

        public AsCatalogEntryTask(CatalogCalendar catalog) => Catalog = catalog;

        public IEnumerator<CatalogEntryTask> GetEnumerator() =>
                    new EnumeratorCatalogEntryTask(Catalog.ContainerPersistence);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();
        private IEnumerator GetEnumerator1() => this.GetEnumerator();
        }

    #endregion



    public class CatalogCalendar : Catalog {
        public const string Label = "CatalogCalendar";

        public override string ContainerDefault => Label;

        public AsCatalogEntryTask AsCatalogEntryContact => new AsCatalogEntryTask(this);


        public CatalogEntryTask LocateBySite(string Key) => Locate(Key) as CatalogEntryTask;


        public CatalogCalendar(string directory, string ContainerName = null,
            CryptoParameters cryptoParameters = null,
                    KeyCollection keyCollection = null) :
            base(directory, ContainerName, cryptoParameters, keyCollection) {
            }
        public static Store Factory(string directory, string containerName = null) =>
        new CatalogCalendar(directory, containerName);
        }

    // NYI should all be DareMessages to allow them to be signed.
    public partial class CatalogEntryTask {


        public override string _PrimaryKey => Key;

        public CatalogEntryTask() => Key = UDF.Nonce();

        public CatalogEntryTask(DareMessage task) : this() => Task = task;

        public CatalogEntryTask(Task task) : this() => Task = DareMessage.Encode(task.GetBytes(tag: true),
                    contentType: "application/mmm");
        }

    }
