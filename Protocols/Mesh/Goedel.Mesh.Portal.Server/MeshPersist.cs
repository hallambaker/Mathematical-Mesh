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
using System.Diagnostics;
using System.Collections.Generic;
using Goedel.Persistence;
using Goedel.Utilities;
using Goedel.Mesh;
using Goedel.Protocol;
using Goedel.Cryptography.Dare;

namespace Goedel.Mesh.Portal.Server {


    /// <summary>
    /// The Mathematical Mesh persistence store.
    /// </summary>
    public class MeshPersist {
        const string UniqueID = "UniqueID";
        const string KeyUserProfile = "UserProfile";
        const string DefaultMesh = "mmm.jlog";
        const string DefaultPortal = "portal.jlog";
        const string StoreType = "application/mesh";
        const string StoreComment = "Persistence store for Mathematical Mesh";
        const string PortalType = "application/mesh-portal";
        const string PortalComment = "Persistence store for Mesh Portal";

        /// <summary>
        /// The DNS name of this service.
        /// </summary>
        public string Domain;

        IPersistenceStoreWrite PortalStore;
        IPersistenceStoreWrite MeshStore;

        /// <summary>
        /// Construct a persistence store for the specified domain, with the
        /// specified store and portal stores.
        /// </summary>
        /// <param name="Domain">Domain name of the service</param>
        /// <param name="Store">store name for the profile persistence store.</param>
        /// <param name="Portal">Store name for the portal persistence store.</param>
        public MeshPersist(string Domain, string Store= DefaultMesh, string Portal= DefaultPortal) {
            this.Domain = Domain;
            MeshStore = new ContainerPersistenceStore(Store, StoreType, StoreComment);
            PortalStore = new ContainerPersistenceStore(Portal, PortalType, PortalComment);
            }


        /// <summary>Test to see if an account name is available. Note that 
        /// a subsequence CreateAccount request can fail even if a previous call 
        /// to CheckAccount succeeded as the account name may have been issued in the 
        /// interim or may fail for other reasons.
        /// </summary>
        /// <param name="AccountID">The requested account name</param>
        /// <returns>True is the name is available, otherwise false.</returns>
        public bool CheckAccount (string AccountID) {
            return !PortalStore.Contains(AccountID);
            }


        /// <summary>
        /// Create an account with the specified account name and profile.
        /// <para>The profile is validated for consistency and rejected if 
        /// validation fails.</para>
        /// <para>The new account is registered in the Portal log under  
        /// AccountName@Domain as the unique identifier. The profile is 
        /// registered in the mesh under the </para>
        /// </summary>
        /// <param name="AccountID">The requested account name.</param>
        /// <param name="Profile">A signed Personal Profile.</param>
        /// <returns>True if the transaction was successful, otherwise false.  </returns>
        public bool CreateAccount(string AccountID, SignedProfile Profile) {

            // Validate the signed profile
            Assert.True(Profile.Validate(), ProfileInvalid.Throw);

            var Now = DateTime.Now;
            // Create the new account on the portal (fail if already exists)
            var Account = new Account() {
                AccountID = AccountID,
                Status = "Open",
                Created = Now,
                Modified = Now,
                UserProfileUDF = Profile.Identifier
                };
            //// Allow accounts to be searched by the profile they link to:
            //var KeyData = new IndexTerm(KeyUserProfile, Account.UniqueID);
            //var KeyDatas = new List<IndexTerm> { KeyData };

            PortalStore.New(Account);

            // Push the profile out to the Mesh
            MeshStore.New(Profile);

            return true;
            }


        /// <summary>
        /// Create an account with the specified account name and profile.
        /// <para>The profile is validated for consistency and rejected if 
        /// validation fails.</para>
        /// <para>The new account is registered in the Portal log under  
        /// AccountName@Domain as the unique identifier. The profile is 
        /// registered in the mesh under the </para>
        /// </summary>
        /// <param name="AccountID">The requested account name.</param>
        /// <returns>True if the transaction was successful, otherwise false.  </returns>
        public bool DeleteAccount (string AccountID) {
            var KeyAccountID = Account.PrimaryKey(AccountID);
            return PortalStore.Delete(KeyAccountID);
            }


        /// <summary>
        /// Get Account with the specified identifier.
        /// </summary>
        /// <param name="AccountId">Identifier to retrieve.</param>
        /// <returns>The account object.</returns>
        public Account GetAccount(string AccountId) {

            var AccountDataItem = PortalStore.Get(Account.PrimaryKey(AccountId));
            if (AccountDataItem == null) {
                return null;
                }

            var AccountObject = Account.FromJSON(AccountDataItem.JSONReader);
            return AccountObject;
            }

        /// <summary>
        /// Get the list of connections pending on an account.
        /// </summary>
        /// <param name="Account">The account identifier to get the connections pending for.</param>
        /// <returns>The pendiong connections.</returns>
        public ConnectionsPending GetPending(Account Account) {
            // Get the pending connections record for the account
            var ConnectionsDataItem = PortalStore.Get(
                ConnectionsPending.PrimaryKey(Account.AccountID));

            if (ConnectionsDataItem == null) {
                return null;
                }

            var Result  = ConnectionsPending.FromJSON(ConnectionsDataItem.JSONReader);
            return Result;
            }


        /// <summary>
        /// Check the specified personal profile and add it to the mesh.
        /// </summary>
        /// <param name="Profile">The profile to add.</param>
        public void AddProfile(SignedProfile Profile) {
            Assert.True(Profile.Validate(), ProfileInvalid.Throw);
            MeshStore.New(Profile);
            }


        /// <summary>
        /// Get a profile with the specified UDF key.
        /// </summary>
        /// <param name="UDF">Fingerprint of requested profile.</param>
        /// <returns>The profile (if found).</returns>
        public Entry GetProfile (string UDF) {

            var PEntry = MeshStore.Get(UDF);
            if (PEntry == null) {
                return null;
                }

            var Result = Entry.FromJSON(PEntry.JSONReader);

            return Result;
            }


        /// <summary>
        /// Publish an entry
        /// </summary>
        /// <param name="Profile">The profile to publish</param>
        public void UpdateProfile(Entry Profile) {
            Assert.True(Profile.Valid, ProfileInvalid.Throw);

            MeshStore.Update(Profile);
            }

        /// <summary>
        /// Get the personal profile with the specified ID.
        /// </summary>
        /// <param name="ID">The identifier of the profile to get.</param>
        /// <returns>The profile if found, otherwise null.</returns>
        public PersonalProfile GetPersonalProfile(string ID) {
            var Profile = GetSignedPersonalProfile(ID);
            return Profile.PersonalProfile;
            }

        /// <summary>
        /// Get the signed personal profile with the specified ID.
        /// </summary>
        /// <param name="ID">The identifier of the profile to get.</param>
        /// <returns>The profile if found, otherwise null.</returns>
        public SignedPersonalProfile GetSignedPersonalProfile(string ID) {

            var DataItem = MeshStore.Get(ID);

            var Profile = SignedPersonalProfile.FromJSON(DataItem.JSONReader);
            return Profile;
            }

        /// <summary>
        /// Post a new connection request to the specified account.
        /// </summary>
        /// <param name="SignedConnectionRequest">The request to post</param>
        /// <param name="AccountId">The account to post it to.</param>
        public void PostConnectionRequest(
                SignedConnectionRequest SignedConnectionRequest, string AccountId) {
            var ConnectionRequest = SignedConnectionRequest.Data;


            var Account = GetAccount(AccountId);
            var ConnectionsPending = GetPending(Account);

            if (ConnectionsPending == null) {
                ConnectionsPending = new ConnectionsPending() {
                    AccountID = AccountId,
                    Requests = new List<SignedConnectionRequest>()
                    };

                // Add the pending connection
                ConnectionsPending.Requests.Add(SignedConnectionRequest);

                PortalStore.New(ConnectionsPending);
                }
            else {
                // Delete any expired requests
                ConnectionsPending.Purge();
                // Add the pending connection
                ConnectionsPending.Requests.Add(SignedConnectionRequest);

                PortalStore.Update(ConnectionsPending);
                }

            return;
            }


        /// <summary>
        /// Get the list of signed pending connection requests.
        /// </summary>
        /// <param name="AccountId">The account to query.</param>
        /// <returns>The list of requests.</returns>
        public List<SignedConnectionRequest> GetPendingRequests(string AccountId) {
            var Account = GetAccount(AccountId);

            // Get the pending connections record for the account
            var ConnectionsPending = GetPending(Account);

            if (ConnectionsPending == null) {
                return null;
                }

            return ConnectionsPending.Requests;
            }


        /// <summary>
        /// Close a connection request.
        /// </summary>
        /// <param name="AccountId">The account identifier to close the request on.</param>
        /// <param name="SignedResult">The status to be posted to the close.</param>
        /// <returns>true if the connection request could be found, otherwise false.</returns>
        public bool CloseConnectionRequest(
                string AccountId, SignedConnectionResult SignedResult) {

            var Result = SignedResult.Data;
            // Get the pending connections record for the account

            var Account = GetAccount(AccountId);
            var ConnectionsPending = GetPending(Account);

            if (ConnectionsPending == null) {
                return false;
                }

            SignedConnectionRequest SignedConnectionRequest = null;
            // Remove the specified request
            for (var i =0; (i < ConnectionsPending.Requests.Count) & 
                (SignedConnectionRequest== null); i++) {
                var Request = ConnectionsPending.Requests[i];

                if (Request.Identifier == SignedResult.Identifier) {
                    SignedConnectionRequest = Request;
                    ConnectionsPending.Requests.RemoveAt(i);
                    }
                }
            Assert.NotNull(SignedConnectionRequest, InvalidResponse.Throw);

            // Create a completed notification.
            PortalStore.Update(ConnectionsPending);

            PortalStore.New(SignedResult);

            return true;
            }


        /// <summary>
        /// Get the status of a pending connection request.
        /// </summary>
        /// <param name="AccountId">The account to query.</param>
        /// <param name="DeviceUDF">The device that is attempting to connect.</param>
        /// <returns>Status of the pending request.</returns>
        public SignedConnectionResult GetRequestStatus(string AccountId, string DeviceUDF) {
            //var Account = GetAccount(AccountId);

            // Look for a completed notification
            var DataItem = PortalStore.Get(
                SignedConnectionResult.PrimaryKey(DeviceUDF));
            // Return if found
            if (DataItem == null) { return null; }

            var Result = SignedConnectionResult.FromJSON(DataItem.JSONReader);
            return Result;
            }

        /// <summary>
        /// Get the current chain token for the mesh store for use
        /// in notarized transactions.
        /// </summary>
        /// <returns>The most recent entry in the log chain.</returns>
        public string GetChainToken () {
            return "Chain:Start";

            }

        }

    }
