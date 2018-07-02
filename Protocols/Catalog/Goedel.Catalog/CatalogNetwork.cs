using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Goedel.Utilities;
using Goedel.Cryptography.Dare;
using Goedel.Protocol;

namespace Goedel.Catalog {

    public partial class CatalogNetwork {

        public SortedDictionary<string, EntryNetwork> DictionaryIdToEntry =
            new SortedDictionary<string, EntryNetwork>();


        public  void ApplyUpdate(EntryNetwork Entry, bool New) {
            Assert.NotNull(Entry.ID);
            DictionaryIdToEntry.ReplaceSafe(Entry.LocalKey, Entry);
            }

        public void ApplyDelete(string UniqueID) {
            Assert.NotNull(UniqueID);
            DictionaryIdToEntry.Remove(UniqueID);
            }
        public EntryNetwork GetById(string Id) {
            var Found = DictionaryIdToEntry.TryGetValue(
                        EntryNetwork.Key(Id), out var Entry);
            return Entry;

            }

        public void Delete(string Id) => DeleteByKey(EntryNetwork.PrimaryKey(Id));

        public CatalogNetwork() {
            }

        public CatalogNetwork(ContainerPersistenceStore CatalogContainer) :
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

    public partial class EntryNetwork {

        public static string Key(string ID) => ID;

        public static string PrimaryKey(string ID) =>
             __Tag + "$" + Key(ID);

        public string LocalKey => Key(ID);

        public override string _PrimaryKey => PrimaryKey(ID);

        }

    }
