using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Goedel.Utilities;
using Goedel.Cryptography.Dare;
using Goedel.Protocol;

namespace Goedel.Catalog {

    public partial class CatalogCredential {

        public SortedDictionary<string, EntryCredential> DictionarySiteToEntry =
            new SortedDictionary<string, EntryCredential>();


        public  void ApplyUpdate(EntryCredential Entry, bool New) {
            Assert.NotNull(Entry.Site);
            DictionarySiteToEntry.ReplaceSafe(Entry.LocalKey, Entry);
            }

        public  void ApplyDelete(string UniqueID) {
            Assert.NotNull(UniqueID);
            DictionarySiteToEntry.Remove(UniqueID);
            }

        public EntryCredential GetBySite(string Site, string Protocol) {
            var Found = DictionarySiteToEntry.TryGetValue(
                        EntryCredential.Key(Site, Protocol), out var Entry);
            return Entry;

            }

        public void Delete(string Site, string Protocol) => DeleteByKey(EntryCredential.PrimaryKey(Site, Protocol));

        public CatalogCredential() {
            }

        public CatalogCredential(ContainerPersistenceStore CatalogContainer) :
                base(CatalogContainer) {
            }

        protected override void GetJson(JSONWriter Writer) {
            bool Firstarray = true;
            foreach (var KeyValue in DictionarySiteToEntry) {
                var Entry = KeyValue.Value;
                Writer.WriteArraySeparator(ref Firstarray);
                Entry.Serialize(Writer, true);
                }
            }

        }

    public partial class EntryCredential {

        public static string Key(string Site, string Protocol) =>
             Protocol ?? "http" + "://" + Site;

        public static string PrimaryKey(string Site, string Protocol) =>
             __Tag + "$" + Key(Site, Protocol);

        public string LocalKey => Key(Site, Protocol);

        public override string _PrimaryKey => PrimaryKey(Site, Protocol);

        }

    }
