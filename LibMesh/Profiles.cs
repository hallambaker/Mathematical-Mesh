using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Registry;
using Goedel.Persistence;
using Goedel.LibCrypto;
using Goedel.LibCrypto.PKIX;
using Goedel.Debug;
using Goedel.Cryptography.Jose;

namespace Goedel.Mesh {

    /// <summary>
    /// Index term for retrieving mesh profiles.
    /// </summary>
    public class MeshIndexTerm {

        /// <summary>
        /// Prefix for unique ID terms
        /// </summary>
        public const string UniqueID = "UniqueID";

        /// <summary>
        /// Prefix for user profile terms.
        /// </summary>
        public const string KeyUserProfile = "UserProfile";
        
        /// <summary>
        /// Persistence store where terms are to be interned.
        /// </summary>
        public PersistenceStore PersistenceStore;

        /// <summary>
        /// Index of objects by unique ID
        /// </summary>
        public PersistenceIndex IndexUniqueID;

        /// <summary>
        /// Index of objects by account name.
        /// </summary>
        public PersistenceIndex UserProfilesByAccount;

        /// <summary>
        /// Construct a new index term for the specified persistence store.
        /// </summary>
        /// <param name="PersistenceStore"></param>
        public MeshIndexTerm(PersistenceStore PersistenceStore) {
            this.PersistenceStore = PersistenceStore;
            UserProfilesByAccount = PersistenceStore.GetIndex(KeyUserProfile);
            IndexUniqueID = PersistenceStore.GetIndex(UniqueID);
            }

        /// <summary>
        /// Set index terms for a unique identifier.
        /// </summary>
        /// <param name="KeyDatas"></param>
        /// <param name="ID"></param>
        public static void SetUnique(List<IndexTerm> KeyDatas, string ID) {
            }

        }

    /// <summary>
    /// Base class for all profiles.
    /// </summary>
    public partial class Profile {

        /// <summary>
        /// List of all the index terms this profile can be retrieved through.
        /// </summary>
        public List<IndexTerm> IndexTerms {
            get { return GetIndex(); }
            }

        /// <summary>
        /// Get the unique identifier for this object.
        /// </summary>
        public string UniqueID {
            get { return Identifier; }
            }

        /// <summary>
        /// Get a list of indexes for this profile.
        /// </summary>
        /// <returns></returns>
        public virtual List<IndexTerm> GetIndex() {
            List<IndexTerm> Result = new List<IndexTerm>();

            Result.Add(new IndexTerm(MeshIndexTerm.UniqueID, UniqueID)); // as uniqueID
            Result.Add(new IndexTerm(Tag(), Identifier)); // as profile type

            return Result;
            }

        /// <summary>
        /// Every profile has a unique UDF identifier.
        /// </summary>
        public virtual string UDF {
            get { return null; }
            }


        /// <summary>
        /// Prepare the profile for export.
        /// </summary>
        public virtual void Package() {
            // Do nothing.
            }


        /// <summary>
        /// Unpack the profile and signed sub profiles.
        /// </summary>
        public virtual void Unpack() {
            // Do nothing.
            }

        }



    }
