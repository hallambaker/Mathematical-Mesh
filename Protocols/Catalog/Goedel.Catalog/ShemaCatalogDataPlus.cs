using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Goedel.Utilities;
using Goedel.Cryptography.Dare;
using Goedel.Protocol;

namespace Goedel.Catalog {
    public partial class CatalogMeta {

        protected ContainerPersistenceStore CatalogContainer { get; }



        public CatalogMeta() {
            }

        public CatalogMeta(ContainerPersistenceStore CatalogContainer) => 
            this.CatalogContainer = CatalogContainer;


        /// <summary>
        /// Update a catalog entry in the local and remote catalog.
        /// </summary>
        /// <param name="Entry">The entry to update</param>
        /// <param name="Create">If true, create a new entry if none already exists.</param>
        public virtual void Update(CatalogEntry Entry, bool Create = true) =>
            CatalogContainer.Update(Entry, Create);

        /// <summary>
        /// Delete an entry in the local and remote catalog
        /// </summary>
        /// <param name="UniqueID">The primary key of the item to be deleted.</param>
        public void DeleteByKey(string UniqueID) =>
            CatalogContainer.Delete(UniqueID);


        public string GetJson(bool Tagged = true) {
            var Writer = new JSONWriter();

            if (Tagged) {
                Writer.WriteObjectStart();
                Writer.WriteToken(_Tag, 0);
                }

            Writer.WriteObjectStart();
            var First = true;
            Writer.WriteObjectSeparator(ref First);
            Writer.WriteToken("Entries", 1);
            Writer.WriteArrayStart();
            GetJson(Writer);
            Writer.WriteArrayEnd();
            Writer.WriteObjectEnd();

            if (Tagged) {
                Writer.WriteObjectEnd();
                }

            return Writer.GetUTF8;
            }

        protected virtual void GetJson(JSONWriter Writer) {
            }


        ///// <summary>
        ///// Update a catalog entry in the local catalog
        ///// </summary>
        ///// <param name="Entry">The entry to update</param>
        ///// <param name="Create">If true, create a new entry if none already exists.</param>
        //public virtual void ApplyUpdate(CredentialEntry Entry, bool New) {
        //    throw new NYI();
        //    }

        ///// <summary>
        ///// Delete an entry in the local catalog
        ///// </summary>
        ///// <param name="UniqueID">The primary key of the item to be deleted.</param>
        //public virtual void ApplyDelete(string UniqueID) {
        //    throw new NYI();
        //    }

        }


    //public partial class BookmarkCatalog {

    //    public SortedList<string, BookmarkEntry> Bookmarks = new SortedList<string, BookmarkEntry>();

    //    public void New(BookmarkEntry BookmarkEntry) {
    //        Bookmarks.Add(BookmarkEntry.SortKey, BookmarkEntry);
    //        }

    //    }

    //public partial class BookmarkEntry {
    //    public static string MakePrimary(string Uri) => "BookmarkEntry:" + Uri;
    //    public string SortKey => Path + ":" + Title;

    //    public override string _PrimaryKey => MakePrimary(Uri);
    //    }





    }
