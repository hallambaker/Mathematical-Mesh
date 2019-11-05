using Goedel.Cryptography;
using Goedel.Cryptography.Dare;

using System;
using System.Collections;
using System.Collections.Generic;

namespace Goedel.Mesh {

    #region // Enumerators and associated classes

    public class EnumeratorCatalogEntryTask : IEnumerator<CatalogedTask> {
        IEnumerator<ContainerStoreEntry> BaseEnumerator;

        public CatalogedTask Current => BaseEnumerator.Current.JsonObject as CatalogedTask;
        object IEnumerator.Current => Current;
        public void Dispose() => BaseEnumerator.Dispose();
        public bool MoveNext() => BaseEnumerator.MoveNext();
        public void Reset() => throw new NotImplementedException();

        public EnumeratorCatalogEntryTask(ContainerPersistenceStore container) =>
            BaseEnumerator = container.GetEnumerator();
        }

    public class AsCatalogEntryTask : IEnumerable<CatalogedTask> {
        CatalogCalendar Catalog;

        public AsCatalogEntryTask(CatalogCalendar catalog) => Catalog = catalog;

        public IEnumerator<CatalogedTask> GetEnumerator() =>
                    new EnumeratorCatalogEntryTask(Catalog.ContainerPersistence);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();
        private IEnumerator GetEnumerator1() => this.GetEnumerator();
        }

    #endregion



    public class CatalogCalendar : Catalog {
        public const string Label = "mmm_Calendar";

        public override string ContainerDefault => Label;

        public AsCatalogEntryTask AsCatalogEntryContact => new AsCatalogEntryTask(this);


        public CatalogedTask LocateBySite(string Key) => Locate(Key) as CatalogedTask;


        public CatalogCalendar(string directory, string ContainerName = null,
            CryptoParameters cryptoParameters = null,
                    KeyCollection keyCollection = null,
                    bool create = true) :
            base(directory, ContainerName, cryptoParameters, keyCollection, create: create) {
            }
        public static Store Factory(string directory, string containerName = null) =>
        new CatalogCalendar(directory, containerName);
        }

    // NYI should all be DareMessages to allow them to be signed.
    public partial class CatalogedTask {


        public override string _PrimaryKey => Key;

        public CatalogedTask() => Key = UDF.Nonce();

        public CatalogedTask(DareEnvelope task) : this() => EnvelopedTask = task;

        public CatalogedTask(Task task) : this() => EnvelopedTask = DareEnvelope.Encode(task.GetBytes(tag: true),
                    contentType: "application/mmm");
        }

    }
