using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;
using Goedel.Cryptography.Dare;
using Goedel.Protocol;
using Goedel.IO;

namespace Goedel.Catalog.Client {

    /// <summary>
    /// 
    /// </summary>
    public enum ContainerResult {
        /// <summary></summary>
        Success,
        /// <summary></summary>
        Exists,
        /// <summary></summary>
        Deleted,
        /// <summary></summary>
        Unknown
        }

    public class CatalogSession : ContainerPersistenceStore {

        public CatalogClient CatalogClient;

        //protected ContainerPersistenceStore CatalogContainer { get; }

        public CatalogCredential CatalogCredential =>
            (_CatalogCredential ?? new CatalogCredential(this)).CacheValue(out _CatalogCredential);
        CatalogCredential _CatalogCredential;

        public CatalogBookmark CatalogBookmark => 
            (_CatalogBookmark ?? new CatalogBookmark(this)).CacheValue(out _CatalogBookmark);
        CatalogBookmark _CatalogBookmark;

        public CatalogContact CatalogContact =>
            (_CatalogContact ?? new CatalogContact(this)).CacheValue(out _CatalogContact);
        CatalogContact _CatalogContact;

        public CatalogCalendar CatalogCalendar =>
            (_CatalogCalendar ?? new CatalogCalendar(this)).CacheValue(out _CatalogCalendar);
        CatalogCalendar _CatalogCalendar;

        public CatalogNetwork CatalogNetwork =>
            (_CatalogNetwork ?? new CatalogNetwork(this)).CacheValue(out _CatalogNetwork);
        CatalogNetwork _CatalogNetwork;

        public CatalogSSH CatalogSSH => 
            (_CatalogSSH ?? new CatalogSSH(this)).CacheValue(out _CatalogSSH);
        CatalogSSH _CatalogSSH;

        public CatalogMail CatalogMail =>
            (_CatalogMail ?? new CatalogMail(this)).CacheValue(out _CatalogMail);
        CatalogMail _CatalogMail;

        public CatalogGroup CatalogGroup =>
            (_CatalogGroup ?? new CatalogGroup(this)).CacheValue(out _CatalogGroup);
        CatalogGroup _CatalogGroup;






        //// Different....
        //public MessageSession MessageSession =>
        //    (_MessageSession ?? new MessageSession(this)).CacheValue(out _MessageSession);
        //MessageSession _MessageSession;

        public CatalogSession(CatalogSession CatalogSession): base(null) => throw new NYI();

        public CatalogSession(
                    string FileName,
                    string Comment = null, bool ReadOnly = false,
                    FileStatus FileStatus = FileStatus.OpenOrCreate,
                    ContainerType ContainerType = ContainerType.Chain,
                    DataEncoding DataEncoding = DataEncoding.JSON) : base(
                       FileName ?? "CatalogContainer.dcon",
                       "CatalogEntry", Comment, ReadOnly, FileStatus, ContainerType, DataEncoding) {


            }

        public virtual void Synchronize() {
            //// pull the catalog entries from the client
            //foreach (var Frame in CatalogFrames) {
            //    }

            }

        public override void Update(JSONObject Object, bool Create = true) {
            // Attempt remote update.


            // Write out to the local log
            base.Update(Object, Create);

            // Update the in-memory representation.
            switch (Object) {
                case EntryCredential CredentialEntry: {
                    CatalogCredential.ApplyUpdate(CredentialEntry, Create);
                    break;
                    }
                case EntryBookmark BookmarkEntry: {
                    CatalogBookmark.ApplyUpdate(BookmarkEntry, Create);
                    break;
                    }
                case EntryContact ContactEntry: {
                    CatalogContact.ApplyUpdate(ContactEntry, Create);
                    break;
                    }
                case EntryCalendar CalendarEntry: {
                    CatalogCalendar.ApplyUpdate(CalendarEntry, Create);
                    break;
                    }
                case EntryNetwork NetworkEntry: {
                    CatalogNetwork.ApplyUpdate(NetworkEntry, Create);
                    break;
                    }
                case EntrySSH Entry: {
                    CatalogSSH.ApplyUpdate(Entry, Create);
                    break;
                    }
                case EntryMail Entry: {
                    CatalogMail.ApplyUpdate(Entry, Create);
                    break;
                    }
                case EntryGroup Entry: {
                    CatalogGroup.ApplyUpdate(Entry, Create);
                    break;
                    }
                }
            }

        public override bool Delete(string Identifier) {

            if (!base.Delete(Identifier)) {
                return false;
                }
            
            Identifier.Separate('$', out var Type, out var ID);

            switch (Type) {
                case EntryCredential.__Tag: {
                    CatalogCredential.ApplyDelete(ID);
                    break;
                    }
                case EntryBookmark.__Tag: {
                    CatalogBookmark.ApplyDelete(ID);
                    break;
                    }
                case EntryContact.__Tag: {
                    CatalogContact.ApplyDelete(ID);
                    break;
                    }
                case EntryCalendar.__Tag: {
                    CatalogCalendar.ApplyDelete(ID);
                    break;
                    }
                case EntryNetwork.__Tag: {
                    CatalogNetwork.ApplyDelete(ID);
                    break;
                    }
                case EntrySSH.__Tag: {
                    CatalogSSH.ApplyDelete(ID);
                    break;
                    }
                case EntryMail.__Tag: {
                    CatalogMail.ApplyDelete(ID);
                    break;
                    }
                case EntryGroup.__Tag: {
                    CatalogGroup.ApplyDelete(ID);
                    break;
                    }
                }

            return true;
            }


        }


    //public class CredentialSession : CatalogSession {
    //    public SortedDictionary<string, EntryCredential> DictionarySiteToEntry =
    //        new SortedDictionary<string, EntryCredential>();


    //    public void ApplyUpdate(EntryCredential Entry, bool New) {
    //        Assert.NotNull(Entry.Site);
    //        DictionarySiteToEntry.ReplaceSafe(Entry.Site, Entry);
    //        }

    //    public void ApplyDelete(string Site) {
    //        Assert.NotNull(Site);
    //        DictionarySiteToEntry.Remove(Site);
    //        }

    //    public EntryCredential GetBySite(string Site) {
    //        var Found = DictionarySiteToEntry.TryGetValue(Site, out var Entry);
    //        return Entry;
    //        }


    //    public CredentialSession(CatalogSession CatalogSession) : base(CatalogSession) { }


    //    public string GetJson(bool Tagged = true) {
    //        var Writer = new JSONWriter();

    //        if (Tagged) {
    //            Writer.WriteObjectStart();
    //            Writer.WriteToken("CredentialCatalog", 0);
    //            }
    //        foreach (var KeyValue in DictionarySiteToEntry) {
    //            var Entry = KeyValue.Value;
    //            Entry.Serialize(Writer, true);
    //            }
    //        if (Tagged) {
    //            Writer.WriteObjectEnd();
    //            }

    //        return Writer.GetUTF8;
    //        }


    //    }

    //public class BookmarkSession: CatalogSession {




    //    public BookmarkSession(CatalogSession CatalogSession) : base(CatalogSession) { }

    //    public void ApplyUpdate(EntryBookmark Entry, bool New) {
    //        throw new NYI();
    //        }

    //    public void ApplyDelete(string Site) {
    //        throw new NYI();
    //        }
    //    }

    //public class ContactSession : CatalogSession {



    //    public ContactSession(CatalogSession CatalogSession) : base(CatalogSession) { }

    //    public void ApplyUpdate(EntryContact Entry, bool New) {
    //        throw new NYI();
    //        }

    //    public void ApplyDelete(string Site) {
    //        throw new NYI();
    //        }
    //    }


    //public class CalendarSession : CatalogSession {

    //    public CalendarSession(CatalogSession CatalogSession) : base(CatalogSession) { }

    //    public void ApplyUpdate(EntryCalendar Entry, bool New) {
    //        throw new NYI();
    //        }

    //    public void ApplyDelete(string Site) {
    //        throw new NYI();
    //        }


    //    }


    //public class NetworkSession : CatalogSession {

    //    public CatalogNetwork NetworkCatalog;



    //    public NetworkSession(CatalogSession CatalogSession) : base(CatalogSession) { }

    //    public void ApplyUpdate(EntryNetwork Entry, bool New) {
    //        throw new NYI();
    //        }

    //    public void ApplyDelete(string Site) {
    //        throw new NYI();
    //        }


    //    }

    ///**************************************/

    //public class MessageSession : CatalogSession {
    //    //public MessageCatalog MessageCatalog;
    //    //BookmarkCatalog BookmarkCatalog;



    //    public MessageSession(CatalogSession CatalogSession) : base(CatalogSession) { }

    //    //public void ApplyUpdate(MessageEntry Entry, bool New) {
    //    //    throw new NYI();
    //    //    }

    //    //public void ApplyDelete(string Site) {
    //    //    throw new NYI();
    //    //    }


    //    }

    //public class GroupSession : CatalogSession {

    //    //BookmarkCatalog BookmarkCatalog;



    //    public GroupSession(CatalogSession CatalogSession) : base(CatalogSession) { }

    //    //public void ApplyUpdate(BookmarkEntry Entry, bool New) {
    //    //    throw new NYI();
    //    //    }

    //    //public void ApplyDelete(string Site) {
    //    //    throw new NYI();
    //    //    }


    //    }

    //public class MailSession : CatalogSession {

    //    //BookmarkCatalog BookmarkCatalog;



    //    public MailSession(CatalogSession CatalogSession) : base(CatalogSession) { }

    //    //public void ApplyUpdate(BookmarkEntry Entry, bool New) {
    //    //    throw new NYI();
    //    //    }

    //    //public void ApplyDelete(string Site) {
    //    //    throw new NYI();
    //    //    }


    //    }


    //public class SSHSession : CatalogSession {

    //    //BookmarkCatalog BookmarkCatalog;



    //    public SSHSession(CatalogSession CatalogSession) : base(CatalogSession) { }

    //    //public void ApplyUpdate(BookmarkEntry Entry, bool New) {
    //    //    throw new NYI();
    //    //    }

    //    //public void ApplyDelete(string Site) {
    //    //    throw new NYI();
    //    //    }


    //    }






    }
