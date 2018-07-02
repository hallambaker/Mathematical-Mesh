using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Goedel.Utilities;
using Goedel.Cryptography.Dare;
using Goedel.Protocol;

namespace Goedel.Catalog {

    public partial class CatalogContact {

        public SortedDictionary<string, EntryContact> DictionaryIdToEntry =
            new SortedDictionary<string, EntryContact>();


        public  void ApplyUpdate(EntryContact Entry, bool New) {
            Assert.NotNull(Entry.LocalKey);
            DictionaryIdToEntry.ReplaceSafe(Entry.LocalKey, Entry);
            }

        public  void ApplyDelete(string UniqueID) {
            Assert.NotNull(UniqueID);
            DictionaryIdToEntry.Remove(UniqueID);
            }
        public EntryContact GetById(string Id) {
            var Found = DictionaryIdToEntry.TryGetValue(
                        EntryContact.Key(Id), out var Entry);
            return Entry;

            }

        public void Delete(string Id) => DeleteByKey(EntryContact.PrimaryKey(Id));

        public CatalogContact() {
            }

        public CatalogContact(ContainerPersistenceStore CatalogContainer) :
                base(CatalogContainer) {
            }

        protected override void GetJson(JSONWriter Writer) {
            bool Firstarray = true;
            foreach (var KeyValue in DictionaryIdToEntry) {
                var Entry = KeyValue.Value;
                Writer.WriteArraySeparator(ref Firstarray);
                Entry.Serialize(Writer, true);
                }
            }


        }

    public partial class EntryContact {

        public static string Key(string ID) => ID;

        public static string PrimaryKey(string ID) =>
             __Tag + "$" + Key(ID);

        public string LocalKey => Key(ID);

        public override string _PrimaryKey => PrimaryKey(ID);

        }

    }
