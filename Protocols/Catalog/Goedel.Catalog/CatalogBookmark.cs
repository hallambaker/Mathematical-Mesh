using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Goedel.Utilities;
using Goedel.Cryptography.Dare;
using Goedel.Protocol;

namespace Goedel.Catalog {

    public partial class CatalogBookmark {

        public SortedDictionary<string, SortedDictionary<string, EntryBookmark>> DictionaryPathToEntryList =
            new SortedDictionary<string, SortedDictionary<string, EntryBookmark>>();



        public  void ApplyUpdate(EntryBookmark Entry, bool New) {
            Assert.NotNull(Entry.Uri);
            var Path = Entry.Path ?? "";
            if (DictionaryPathToEntryList.TryGetValue(Path, out var EntrySet)) {
                EntrySet.Add(Entry.Uri, Entry);
                }
            else {
                EntrySet = new SortedDictionary<string, EntryBookmark> {
                        { Entry.Uri, Entry }
                    };
                DictionaryPathToEntryList.Add(Path, EntrySet);
                }
            }

        public bool ApplyDelete(string PathURI) {

            PathURI.Separate('#', out var Path, out var URI);
            if (DictionaryPathToEntryList.TryGetValue(Path, out var Folder)) {
                if (Folder.TryGetValue(URI, out var _)) {
                    Folder.Remove(URI);
                    if (Folder.Count <= 0) {
                        DictionaryPathToEntryList.Remove(Path);
                        }
                    return true;
                    }                
                }
            return false;
            }

        public bool Delete(string Uri, string Path = null) {
            Path = Path ?? FindFolder(Uri)?.Uri;
            if (Path == null) {
                return false;
                }

            DeleteByKey(EntryCredential.PrimaryKey(Path, Uri));
            return true;
            }

        EntryBookmark FindFolder(string Uri) {
            foreach (var FolderKV in DictionaryPathToEntryList) {
                foreach (var EntryKV in FolderKV.Value) {
                    if (Uri == EntryKV.Value.Uri) {
                        return EntryKV.Value;
                        }
                    }
                }
            return null;
            }


        public CatalogBookmark() {
            }

        public CatalogBookmark(ContainerPersistenceStore CatalogContainer) :
                base(CatalogContainer) {
            }

        protected override void GetJson(JSONWriter Writer) {
            bool Firstarray = true;
            foreach (var FolderKV in DictionaryPathToEntryList) {
                foreach (var EntryKV in FolderKV.Value) {
                    var Entry = EntryKV.Value;
                    Writer.WriteArraySeparator(ref Firstarray);
                    Entry.Serialize(Writer, true);
                    }
                }
            }

        }

    public partial class EntryBookmark {

        /// <summary>
        /// The entry item
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="Uri"></param>
        /// <returns></returns>
        public static string Key(string Path, string Uri) =>
             Path + "#" + Uri;

        public static string PrimaryKey(string Path, string Uri) =>
             __Tag + "$" + Key(Path, Uri);

        public string SiteProtocol => Key(Path, Uri);

        public override string _PrimaryKey => PrimaryKey(Path, Uri);

        }

    }
