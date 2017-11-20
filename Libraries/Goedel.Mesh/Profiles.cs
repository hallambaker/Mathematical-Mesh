//   Copyright © 2015 by Comodo Group Inc.
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
//  
//  

using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Registry;
using Goedel.Protocol;
using Goedel.Persistence;
using Goedel.Cryptography;
using Goedel.Cryptography.PKIX;
using Goedel.Utilities;
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
        /// <param name="PersistenceStore">Store to add index term to.</param>
        public MeshIndexTerm(PersistenceStore PersistenceStore) {
            this.PersistenceStore = PersistenceStore;
            UserProfilesByAccount = PersistenceStore.GetIndex(KeyUserProfile);
            IndexUniqueID = PersistenceStore.GetIndex(UniqueID);
            }

        /// <summary>
        /// Set index terms for a unique identifier.
        /// </summary>
        /// <param name="KeyDatas">Keys to set</param>
        /// <param name="ID">Identifier target.</param>
        public static void SetUnique(List<IndexTerm> KeyDatas, string ID) {
            throw new Goedel.Utilities.NYI();
            }

        }

    /// <summary>
    /// Base class for all profiles.
    /// </summary>
    public partial class Profile {

        /// <summary>
        /// List of all the index terms this profile can be retrieved through.
        /// </summary>
        public List<IndexTerm> IndexTerms  => GetIndex(); 


        /// <summary>
        /// Get the unique identifier for this object.
        /// </summary>
        public string UniqueID  => Identifier; 


        /// <summary>
        /// Get a list of indexes for this profile.
        /// </summary>
        /// <returns>The list of indexes</returns>
        public virtual List<IndexTerm> GetIndex () {
            var Result = new List<IndexTerm>() {
                new IndexTerm(MeshIndexTerm.UniqueID, UniqueID), // as uniqueID
                new IndexTerm(Tag(), Identifier) // as profile type
                };
            return Result;
            }

        /// <summary>
        /// Every profile has a unique UDF identifier.
        /// </summary>
        public virtual string UDF {
            get => Identifier; 
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


        /// <summary>
        /// Sign the current profile. 
        /// </summary>
        /// <param name="UDF">Specify the signature key by identifier</param>
        /// <param name="KeyPair">Specify the signature key by key handle</param>
        /// <param name="Encoding">The encoding for the inner data</param>
        /// <returns>The signed profile.</returns>
        public virtual SignedProfile Sign(string UDF=null,  KeyPair KeyPair = null,
                        DataEncoding Encoding = DataEncoding.JSON) {
            throw new NYI();
            }

        }



    }
