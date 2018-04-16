using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Goedel.Recrypt;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Persistence;

namespace Goedel.Recrypt.Server {

    /// <summary>Recryption persistence store.</summary>
    public class RecryptStore {

        /// <summary>The default store file name</summary>
        const string DefaultStore = "Recrypt.jlog";

        const string KeyUserProfile = "AccountID";
        const string StoreType = "application/goedel-account";
        const string StoreComment = "Persistence store for Account data";

        PersistenceStore Recrypt;
        PersistenceObjectIndex IndexAccountID;


        // Data is indexed for two operations
        //
        // Group management operations - all retrieve the RecryptionGroup record by GroupName
        // Recryption operations - retrieve the CombinedToGroup record by EncryptionKeyUDF, MemberKeyUDF
        //     This in turn locates the Recryption group from which the Member and user entries 
        //     are obtained.

        DataItem GetGroupData (string GroupName) =>
            IndexAccountID.Get(RecryptionGroup.PrimaryKey(GroupName));
        //DataItem GetMemberData (string GroupKey, string MemberKey) =>
        //    GetMemberData(CombinedToGroup.PrimaryKey(GroupKey, MemberKey));
        DataItem GetMemberData (string CombinedKey) =>
            IndexAccountID.Get(CombinedKey);


        RecryptionGroup GetGroupEntry (string AccountID) =>
            RecryptionGroup.FromJSON(GetGroupData(AccountID)?.JSONReader);



        //CombinedToGroup GetCombinedToGroup (string GroupKey, string MemberKey) =>
        //    GetCombinedToGroup (CombinedToGroup.PrimaryKey(GroupKey, MemberKey));
        //CombinedToGroup GetCombinedToGroup (string CombinedKey) =>
        //    CombinedToGroup.FromJSON(GetMemberData(CombinedKey)?.JSONReader);


        void New (RecryptionGroup RecryptionGroup) {
            Recrypt.New(RecryptionGroup);
            }
        void Update (RecryptionGroup RecryptionGroup) {
            Recrypt.Update(RecryptionGroup);
            }

        /// <summary>
        /// The DNS name of this service.
        /// </summary>
        public string Domain { get; }

        /// <summary>
        /// Construct a persistence store for the specified domain, with the
        /// specified store and portal stores.
        /// </summary>
        /// <param name="Domain">Domain name of the service</param>
        /// <param name="Store">store name for the account persistence store.</param>
        public RecryptStore (string Domain, string Store = DefaultStore) {
            this.Domain = Domain;
            Recrypt = new LogPersistenceStore(Store, StoreType, StoreComment);

            //Accounts are kept in the portal store and indexed by the account
            IndexAccountID = Recrypt.ObjectIndex;
            }


        /// <summary>
        /// Create a new recryption group
        /// </summary>
        /// <param name="RecryptionGroup">The parameters of the group to create</param>
        public void CreateGroup (RecryptionGroup RecryptionGroup) {
            Recrypt.New(RecryptionGroup);
            }

        /// <summary>
        /// Replace recryption group definition.
        /// </summary>
        /// <param name="RecryptionGroup">The parameters of the group to update</param>
        public void UpdateGroup (RecryptionGroup RecryptionGroup) {
            Recrypt.Update(RecryptionGroup);
            }

        /// <summary>
        /// Return group data by group name
        /// </summary>
        /// <param name="GroupName">The group name.</param>
        /// <returns>The group name</returns>
        public RecryptionGroup GetGroup (string GroupName) {
            return GetGroupEntry(GroupName);
            }


        public RecryptionGroup GetGroupByKey (string KeyUDF) {
            var DataCollection = Recrypt.Get(RecryptionGroup.EncryptionIndexTerm, KeyUDF.ToUpper());
            if (DataCollection == null || DataCollection?.DataItems.Count == 0) {
                return null;
                }

            return RecryptionGroup.FromJSON(DataCollection.DataItems[0].JSONReader);

            }


        ///// <summary>
        ///// Get the member with the specified UDF
        ///// </summary>
        ///// <param name="RecryptionGroup">The recryption group to search</param>
        ///// <param name="MemberID">The member identifier.</param>
        ///// <returns>The member entry.</returns>
        //public MemberEntry GetDecryptionEntry (RecryptionGroup RecryptionGroup, string MemberID) {
        //    return RecryptionGroup.Members?.Find(x => x.UDF.CompareUDF(MemberID));
        //    }


        /// <summary>
        /// Get the member with the specified UDF
        /// </summary>
        /// <param name="MemberEntry">The member entry.</param>
        /// <param name="EncryptionKeyUDF">The encryption key fingerprint.</param>
        /// <param name="MemberKeyUDF">List of member key fingerprints.</param>
        /// <returns>Decryption information for the specified user.</returns>
        public UserDecryptionEntry GetUserDecryptionEntry (
                        RecryptionGroup RecryptionGroup,
                    string EncryptionKeyUDF, List<string> MemberKeyUDFs) {

            // Hack: Need to completely reorganize the Recryption group store so that this is efficient.
            if (RecryptionGroup.Members == null) {
                return null;
                }

            foreach (var Member in RecryptionGroup.Members) {
                foreach (var Entry in Member.Entries) {
                    if (Entry.EncryptionKeyUDF.CompareUDF(EncryptionKeyUDF)) {
                        foreach (var MemberKeyUDF in MemberKeyUDFs) {
                            if (Entry.MemberKeyUDF.CompareUDF(MemberKeyUDF)) {
                                return Entry;
                                }
                            }
                        }
                    }
                }

            return null;
            }

        /// <summary>
        /// Get the member with the specified identifiers.
        /// </summary>
        /// <param name="GroupKeyID">The group key.</param>
        /// <param name="MemberID">The member identifier</param>
        /// <param name="MemberKeyUDF">The member key fingerprint.</param>
        /// <returns>Decryption information for the specified user.</returns>
        public UserDecryptionEntry GetUserDecryptionEntry (string GroupKeyID,
                    string MemberID, List<string> MemberKeyUDF) {

            GroupKeyID.SplitAccountID (out var Service, out var KeyName);

            var NastyHack = GetGroupByKey(KeyName);   // HACK: the indexing is done wrong.
            var RecryptionGroup = GetGroup(NastyHack.GroupName);

            if (RecryptionGroup == null) {
                return null;
                }


            //var MemberEntry = GetDecryptionEntry(RecryptionGroup, MemberID);
            //if (MemberEntry == null) {
            //    return null;
            //    }

            var UserDecryptionEntry = GetUserDecryptionEntry(RecryptionGroup, KeyName, MemberKeyUDF);
            return UserDecryptionEntry;
            }


        /*
         * Currently unused, untested.
         * 
         * 
         */



        ///// <summary>
        ///// Add a member to a recryption group
        ///// </summary>
        ///// <param name="GroupID"></param>
        ///// <param name="Entries"></param>
        //public void AddMember (string GroupID, List<MemberEntry> Entries) {
        //    var RecryptionGroup = GetGroupEntry(GroupID);
        //    foreach (var Member in Entries) {
        //        Update(RecryptionGroup, Member);
        //        }
        //    }

        ///// <summary>
        ///// Replace recryption group definition.
        ///// </summary>
        ///// <param name="RecryptionGroup"></param>
        //public void UpdateGroup (RecryptionGroup RecryptionGroup) {
        //    Recrypt.Update(RecryptionGroup);
        //    foreach (var Member in RecryptionGroup.Members) {
        //        Update(RecryptionGroup, Member);
        //        }
        //    }

        ///// <summary>
        ///// Update individual members
        ///// </summary>
        ///// <param name="GroupID"></param>
        ///// <param name="Entries"></param>
        //public void UpdateMember (string GroupID, List<MemberEntry> Entries) {
        //    var RecryptionGroup = GetGroupEntry(GroupID);
        //    foreach (var Member in RecryptionGroup.Members) {
        //        Update(RecryptionGroup, Member);
        //        }
        //    }

        ///// <summary>
        ///// Create a member entry in a recryption group.
        ///// </summary>
        ///// <param name="RecryptionGroup"></param>
        ///// <param name="MemberEntry"></param>
        //void Create (RecryptionGroup RecryptionGroup, MemberEntry MemberEntry) {
        //    RecryptionGroup.Members.Add(MemberEntry);
        //    // create the index entries
        //    //foreach (var Entry in MemberEntry.Entries) {
        //    //    Create(RecryptionGroup, MemberEntry, Entry);
        //    //    }
        //    }

        ///// <summary>
        ///// Create a index entry
        ///// </summary>
        ///// <param name="RecryptionGroup"></param>
        ///// <param name="MemberEntry"></param>
        //void Create (RecryptionGroup RecryptionGroup, MemberEntry MemberEntry, UserDecryptionEntry Entry) {
        //    var CombinedToGroup = new CombinedToGroup() {
        //        EncryptionKeyUDF = Entry.EncryptionKeyUDF,
        //        MemberKeyUDF = Entry.MemberKeyUDF,
        //        MemberUDF = MemberEntry.UDF,
        //        GroupName = RecryptionGroup.GroupName,
        //        };
        //    Recrypt.New(CombinedToGroup);
        //    }


        ///// <summary>
        ///// Update the list of members
        ///// </summary>
        ///// <param name="RecryptionGroup"></param>
        ///// <param name="MemberEntry"></param>
        //void Update (RecryptionGroup RecryptionGroup, MemberEntry MemberEntry) {
        //    var Index = RecryptionGroup.Members.FindIndex(x => x.UDF == MemberEntry.UDF);
        //    if (Index < 0) {
        //        // Create new record 
        //        Create(RecryptionGroup, MemberEntry);
        //        }
        //    else {
        //        // Update the existing record.
        //        UpdateMerge(RecryptionGroup, RecryptionGroup.Members[Index], MemberEntry);
        //        RecryptionGroup.Members[Index] = MemberEntry;
        //        }
        //    }

        ///// <summary>
        ///// Update the list of DecryptionEntries.
        ///// </summary>
        ///// <param name="Old"></param>
        ///// <param name="New"></param>
        //void UpdateMerge (RecryptionGroup RecryptionGroup, MemberEntry Old, MemberEntry New) {
        //    Dictionary<string, UserDecryptionEntry> ProcessingDecryption =
        //        new Dictionary<string, UserDecryptionEntry>();

        //    foreach (var Entry in Old.Entries) {
        //        ProcessingDecryption.Add(Entry._PrimaryKey, Entry);
        //        }
        //    foreach (var Entry in New.Entries) {
        //        if (!ProcessingDecryption.Remove(Entry._PrimaryKey)) {
        //            // add the new combined id
        //            Create(RecryptionGroup, New, Entry);
        //            }
        //        }
        //    foreach (var Entry in ProcessingDecryption) {
        //        // remove the combined id
        //        var DataEntry = GetMemberData(Entry.Key); // NO!
        //        Recrypt.Delete(DataEntry);
        //        }
        //    }

        //public RecryptionGroup GetRecryptEntry (
        //            string EncryptionKeyUDF, string MemberKeyUDF) {
        //    var CombinedToGroup = GetCombinedToGroup(EncryptionKeyUDF, MemberKeyUDF);
        //    Assert.NotNull(CombinedToGroup, NoRecryptionRecord.Throw);
        //    return GetGroupEntry(CombinedToGroup.GroupName);
        //    }

        }


    }
