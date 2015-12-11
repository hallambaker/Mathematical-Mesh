using System;
using System.Collections.Generic;
using Goedel.Persistence;
using Goedel.Debug;

namespace Goedel.Mesh {


    public partial class Connection {
        /// <summary>
        /// Convenience constructor, create instance from the principal fields.
        /// </summary>
        /// <param name="DNS">DNS Name</param>
        /// <param name="Port">IP Port Number</param>
        /// <param name="Prefix">DNS service prefix</param>
        /// <param name="Security">Security enhancements</param>
        public Connection(string DNS, int Port, string Prefix, List<string> Security) {
            this.ServiceName = DNS;
            this.Port = Port;
            this.Prefix = Prefix;
            this.Security = Security;
            }

        //public string Server;
        //public int Port;

        //public string UserName;
        //public string Password;


        //public int TimeOut;
        //public int Polling;

        public TLSMode TLSMode;
        public bool SecureAuth;


        /// <summary>
        /// Convenience accessor for the Prefix property.
        /// </summary>
        public AppProtocol AppProtocol {
            get {
                return _AppProtocol;
                }

            set {
                _AppProtocol = value;
                }
            }
        AppProtocol _AppProtocol;

        public virtual void Dump() {
            Trace.WriteLine("    Server {0} : Port {1} : Protocol", ServiceName, Port, _AppProtocol);
            Trace.WriteLine("        Username {0}/{1}", UserName, Password);
            Trace.WriteLine("        Timeout {0} : Poll {1}", TimeOut, Polling);
            }

        //public MailConnection() { }

        public Connection(string Server, int Port, AppProtocol AppProtocol,
            string Account, string Password, TLSMode TLSMode, bool SecureAuth) {

            this.ServiceName = Server;
            this.Port = Port;
            this.AppProtocol = AppProtocol;
            this.UserName = Account;
            this.Password = Password;
            this.TLSMode = TLSMode;
            this.SecureAuth = SecureAuth;

            }
        }




    public class Mesh {
        const string UniqueID = "UniqueID";
        const string KeyUserProfile = "UserProfile";
        const string DefaultMesh = "mmm.jlog";
        const string DefaultPortal = "portal.jlog";
        const string StoreType = "application/mesh";
        const string StoreComment = "Persistence store for Magic Mathematical Mesh";
        const string PortalType = "application/mesh-portal";
        const string PortalComment = "Persistence store for Mesh Portal";

        string Domain;

        PersistenceStore PortalStore;
        PersistenceStore MeshStore;

        PersistenceObjectIndex IndexUniqueID;
        PersistenceObjectIndex PortalByPrimary;



        public Mesh(string Domain) : this (Domain, DefaultMesh, DefaultPortal) {
            }


        public Mesh(string Domain, string Store, string Portal) {
            this.Domain = Domain;
            MeshStore = new LogPersistenceStore(Store, StoreType, StoreComment);
            PortalStore = new LogPersistenceStore(Portal, PortalType, PortalComment);

            //Accounts are kept in the portal store and indexed by 
            //the account
            PortalByPrimary = PortalStore.ObjectIndex;

            //Profiles are kept in the Mesh and are indexed by the UDF of the 
            //master signature key.
            IndexUniqueID = MeshStore.ObjectIndex;
            }


        /// <summary>
        /// Test to see if an account name is available. Note that 
        /// a subsequence CreateAccount request can fail even if a previous call 
        /// to CheckAccount succeeded as the account name may have been issued in the 
        /// interim or may fail for other reasons.
        /// </summary>
        /// <param name="Account">The requested account name</param>
        /// <returns>True is the name is available, otherwise false.</returns>
        public bool CheckAccount (string AccountID) {
            return !PortalByPrimary.Contains(AccountID);
            }


        /// <summary>
        /// Create an account with the specified account name and profile.
        /// <para>The profile is validated for consistency and rejected if 
        /// validation fails.</para>
        /// <para>The new account is registered in the Portal log under  
        /// AccountName@Domain as the unique identifier. The profile is 
        /// registered in the mesh under the </para>
        /// </summary>
        /// <param name="AccountName">The requested account name.</param>
        /// <param name="Profile">A signed Personal Profile.</param>
        /// <returns>True if the transaction was successful, otherwise false.  </returns>
        public bool CreateAccount(string AccountID, SignedProfile Profile) {

            // Validate the signed profile
            if (!Profile.Validate()) throw new Throw ("Profile not valid");

            // Create the new account on the portal (fail if already exists)
            var Account = new Account();
            Account.AccountID = AccountID;
            Account.Status = "Open";
            Account.Created = DateTime.Now;
            Account.Modified = Account.Created;
            Account.UserProfileUDF = Profile.Identifier;

            //// Allow accounts to be searched by the profile they link to:
            //var KeyData = new IndexTerm(KeyUserProfile, Account.UniqueID);
            //var KeyDatas = new List<IndexTerm> { KeyData };

            PortalStore.New(Account, Account.PrimaryKey(Account.UniqueID), null);

            // Push the profile out to the Mesh
            MeshStore.New(Profile, Profile.Identifier, null);

            return true;
            }

        public Account GetAccount(string AccountId) {

            var AccountDataItem = PortalByPrimary.Get(Account.PrimaryKey(AccountId));
            if (AccountDataItem == null) {
                return null;
                }

            var AccountObject = Account.FromTagged(AccountDataItem.Text);
            return AccountObject;
            }


        public ConnectionsPending GetPending(Account Account) {
            // Get the pending connections record for the account
            var ConnectionsDataItem = PortalByPrimary.Get(
                ConnectionsPending.PrimaryKey(Account.UserProfileUDF));

            if (ConnectionsDataItem == null) return null;

            var Result  = ConnectionsPending.FromTagged(ConnectionsDataItem.Text);
            return Result;
            }


        /// <summary>
        /// Check the specified personal profile and add it to the mesh.
        /// </summary>
        /// <param name="Profile"></param>
        public void AddProfile(SignedProfile Profile) {
            // Validate the signed profile
            if (!Profile.Valid) throw new Throw("Profile not valid");

            //var KeyData = new IndexTerm(UniqueID, Profile.Identifier);
            //var KeyDatas = new List<IndexTerm> { KeyData };

            var UniqueID = Profile.UniqueID;
            var IndexTerms = Profile.IndexTerms;

            MeshStore.New(Profile, UniqueID, IndexTerms);
            }


        /// <summary>
        /// Get a profile with the specified UDF key.
        /// </summary>
        /// <param name="UDF"></param>
        /// <returns></returns>
        public SignedProfile GetProfile (string UDF) {

            var Entry = IndexUniqueID.Get(UDF);
            if (Entry == null) {
                return null;
                }

            var Result = SignedProfile.FromTagged(Entry.Text);

            return Result;
            }


        /// <summary>
        /// Publish an entry
        /// </summary>
        /// <param name="Entry"></param>
        public void UpdateProfile(Entry Profile) {
            if (!Profile.Valid) throw new Throw("Profile not valid");

            MeshStore.Update(Profile, Profile.Identifier, Profile.Keys);
            }


        public PersonalProfile GetPersonalProfile(string ID) {
            var Profile = GetSignedPersonalProfile(ID);
            return Profile.Signed;
            }

        public SignedPersonalProfile GetSignedPersonalProfile(string ID) {

            var DataItem = IndexUniqueID.Get(ID);

            var Profile = SignedPersonalProfile.FromTagged(DataItem.Text);
            return Profile;
            }


        public string PostConnectionRequest (
                SignedConnectionRequest SignedConnectionRequest, string AccountId) {
            var ConnectionRequest = SignedConnectionRequest.Data;


            var Account = GetAccount(AccountId);
            var ConnectionsPending = GetPending(Account);

            if (ConnectionsPending == null) {
                ConnectionsPending = new ConnectionsPending(AccountId);
                }

            // Delete any expired requests
            ConnectionsPending.Purge();

            // Add the pending connection
            ConnectionsPending.Requests.Add(SignedConnectionRequest);

            PortalStore.Update(ConnectionsPending, 
                ConnectionsPending.PrimaryKey(Account.UserProfileUDF), null);

            return null;
            }



        public List<SignedConnectionRequest> GetPendingRequests(string AccountId) {
            var Account = GetAccount(AccountId);

            // Get the pending connections record for the account
            var ConnectionsPending = GetPending(Account);

            if (ConnectionsPending == null) return null;

            return ConnectionsPending.Requests;
            }



        public bool CloseConnectionRequest(
                string AccountId, SignedConnectionResult SignedResult) {

            var Result = SignedResult.Data;
            // Get the pending connections record for the account

            var Account = GetAccount(AccountId);
            var ConnectionsPending = GetPending(Account);

            if (ConnectionsPending == null) return false;

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

            if (SignedConnectionRequest == null) throw new Throw ("Bad");

            // Create a completed notification.
            PortalStore.Update(ConnectionsPending,
                ConnectionsPending.PrimaryKey(Account.UserProfileUDF), null);

            PortalStore.New(SignedResult,
                SignedConnectionResult.PrimaryKey(SignedConnectionRequest.Identifier), null);

            return true;
            }



        public SignedConnectionResult GetRequestStatus(string AccountId, string DeviceUDF) {
            var Account = GetAccount(AccountId);

            // Look for a completed notification
            var DataItem = PortalByPrimary.Get(
                SignedConnectionResult.PrimaryKey(DeviceUDF));
            // Return if found
            if (DataItem == null) { return null; }

            var Result = SignedConnectionResult.FromTagged(DataItem.Text);
            return Result;
            }


        public string GetChainToken () {
            return "Chain:Start";

            }

        }

    }
