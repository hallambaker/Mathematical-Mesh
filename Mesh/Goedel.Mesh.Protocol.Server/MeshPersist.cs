

using System.Collections.Generic;
using System.IO;

using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.IO;
using Goedel.Protocol;
using Goedel.Utilities;

namespace Goedel.Mesh.Server {
    public partial class CatalogItem {

        ///<summary>Initialization property. Access this property to force initialization 
        ///of the static method.</summary>
        public static object Initialize => null;

        static CatalogItem() => ContainerPersistenceStore.AddDictionary(_TagDictionary);
        }

    /// <summary>
    /// The Mathematical Mesh persistence store.
    /// </summary>
    public class MeshPersist {

        ///<summary>The underlying persistence store for the account catalog.</summary>
        public ContainerPersistenceStore Container;

        ///<summary>The root directory in which the files are stored.</summary>
        public string DirectoryRoot;


        static MeshPersist() {
            _ = MeshItem.Initialize;
            _ = CatalogItem.Initialize;
            _ = MeshProtocol.Initialize;
            }

        /// <summary>
        /// Open or create the accounts persistence container.
        /// </summary>
        /// <param name="directory">The directory in which all the service data is stored.</param>
        public MeshPersist(string directory) {
            // Load/create the accounts catalog
            DirectoryRoot = directory;
            Directory.CreateDirectory(directory);
            var fileName = Path.Combine(directory, "Master.cat");
            Container = new ContainerPersistenceStore(fileName, "application/mmm-catalog",
                fileStatus: FileStatus.OpenOrCreate,
                containerType: ContainerType.MerkleTree
                );
            }

        /// <summary>
        /// Add a new account. The account name must be unique.
        /// </summary>
        public void AccountAdd(JpcSession jpcSession, 
                        AccountEntry accountEntry) {
            ContainerStoreEntry containerEntry;

            var directory = Path.Combine(DirectoryRoot, accountEntry.Directory);
            accountEntry.Directory = directory;

            // Lock the container so that we can create the new account entry without 
            // causing contention.
            lock (Container) {
                containerEntry = Container.New(accountEntry) as ContainerStoreEntry;
                }

            lock (containerEntry) {
                Directory.CreateDirectory(directory);

                // Create the pro-forma containers.
                new CatalogCredential(directory).Dispose();
                new CatalogContact(directory).Dispose();
                new CatalogApplication(directory).Dispose();
                new Spool(directory, Spool.SpoolInbound).Dispose();

                }
            }

        /// <summary>
        /// Process a connection request.
        /// </summary>
        /// <param name="jpcSession">The session connection data.</param>
        /// <param name="account">The account that the device requests connection to.</param>
        /// <param name="deviceProfile">Profile of the device requesting connection.</param>
        /// <param name="clientNonce">Client nonce to mask the device profile fingerprint.</param>
        /// <returns>The connection response.</returns>
        public ConnectResponse Connect(JpcSession jpcSession) {



            throw new NYI();


            //var messageConnectionRequest = new MessageConnectionRequest() {
            //    MessageID = UDF.Nonce(200),
            //    Account = account,
            //    DeviceProfile = deviceProfile,
            //    ClientNonce = clientNonce,
            //    ServerNonce = CryptoCatalog.GetBits(128),
            //    PinID = PinID
            //    };

            //var connectResponse = new ConnectResponse() {
            //    ServerNonce = messageConnectionRequest.ServerNonce,
            //    };

            //using (var accountHandle = GetAccountUnverified(messageConnectionRequest.Account)) {
                
            //    //var witness = UDF.MakeWitnessString(
            //    //        accountHandle.AssertionAccount.UDFBytes, messageConnectionRequest.ServerNonce,
            //    //        profileDevice.UDFBytes, clientNonce);
            //    //messageConnectionRequest.Witness = witness;
            //    //connectResponse.Witness = witness;



            //    //connectResponse.ProfileMesh = accountHandle.MeshProfile;

            //    //var message = DareEnvelope.Encode(messageConnectionRequest.GetBytes());

            //    //accountHandle.Post(message);
            //    //return connectResponse;
            //    }
            }

        /// <summary>
        /// Update an account record. There must be an existing record and the request must
        /// be appropriately authenticated.
        /// </summary>
        /// <param name="jpcSession">The session connection data.</param>
        /// <param name="account">The account for which the status is requested..</param>
        public List<ContainerStatus> AccountStatus(JpcSession jpcSession, VerifiedAccount account) {
            AccountHandleVerified accountEntry = null;

            using (accountEntry = GetAccountVerified(account, jpcSession)) {
                var result = new List<ContainerStatus> {
                    accountEntry.GetStatusSpool (Spool.SpoolInbound),
                    accountEntry.GetStatusCatalog (CatalogCredential.Label),
                    accountEntry.GetStatusCatalog (CatalogDevice.Label),
                    accountEntry.GetStatusCatalog (CatalogContact.Label),
                    accountEntry.GetStatusCatalog (CatalogApplication.Label),
                    accountEntry.GetStatusCatalog (CatalogCredential.Label)
                    };

                return result;
                }

            }


        /// <summary>
        /// Update an account record. There must be an existing record and the request must
        /// be appropriately authenticated.
        /// </summary>
        /// <param name="jpcSession">The session connection data.</param>
        /// <param name="account">The account for which the status is requested..</param>
        /// <param name="selections">The selection criteria.</param>
        public List<ContainerUpdate> AccountDownload(
                    JpcSession jpcSession, 
                    VerifiedAccount account, 
                    List<ConstraintsSelect> selections) {
            AccountHandleVerified accountEntry = null;

            try {
                accountEntry = GetAccountVerified(account, jpcSession);
                var updates = new List<ContainerUpdate>();
                foreach (var selection in selections) {
                    using (var store = accountEntry.GetStore(selection.Container)) {
                        var update = new ContainerUpdate() {
                            Container = selection.Container,
                            Message = new List<DareEnvelope>()
                            };


                        foreach (var message in store.Select(selection.IndexMin)) {
                            update.Message.Add(message);
                            }

                        updates.Add(update);
                        }
                    }
                return updates;
                }

            finally {
                accountEntry?.Dispose();
                }
            }



        /// <summary>
        /// Update an account record. There must be an existing record and the request must
        /// be appropriately authenticated.
        /// </summary>
        /// <param name="jpcSession">The session connection data.</param>
        /// <param name="account">The account for which the status is requested.</param>
        /// <param name="updates">Entries to be added to catalogs.</param>
        /// <param name="selfs">Entries to be added to the user's inbound store.</param>
        public void AccountUpdate(
                    JpcSession jpcSession, 
                    VerifiedAccount account, 
                    List<ContainerUpdate> updates,
                    List<DareEnvelope> selfs) {
            //AccountHandleVerified accountEntry = null;

            using (var accountEntry = GetAccountVerified(account, jpcSession)) {
                Assert.NotNull(accountEntry);
                if (selfs != null) {
                    foreach (var self in selfs) {
                        accountEntry.Post(self);
                        }
                    }

                if (updates != null) {
                    foreach (var update in updates) {
                        using (var catalog = accountEntry.GetCatalog(update.Container)) {
                            foreach (var message in update.Message) {
                                catalog.Apply(message);
                                }
                            }
                        }
                    }
                }
            }

        /// <summary>
        /// Update an account record. There must be an existing record and the request must
        /// be appropriately authenticated.
        /// </summary>
        /// <param name="jpcSession">The session connection data.</param>
        /// <param name="account">The account to be deleted.</param> 
        public bool AccountDelete(JpcSession jpcSession, VerifiedAccount account) {
            lock (Container) {
                return Container.Delete(account.Account);
                }
            }

        /// <summary>
        /// Process an inbound message to an account.
        /// </summary>
        /// <param name="jpcSession">The session connection data.</param>
        /// <param name="account">The account to which the message is directed.</param>
        /// <param name="dareMessage">The message</param>
        public string MessagePost(JpcSession jpcSession, string account, DareEnvelope dareMessage) {

            using (var accountUnverified = GetAccountUnverified(account)) {

                // calculate the identifier her
                var identifier = "fred";
                dareMessage.Header.UniqueID = identifier;
                Assert.NotNull(accountUnverified);
                accountUnverified.Post(dareMessage);
                return identifier;
                }
            }


        /// <summary>
        /// Get access to an account record for an authenticated request.
        /// </summary>
        /// <param name="jpcSession">The session connection data.</param>      
        /// <param name="verifiedAccount">The account for which the data is requested.</param>
        /// <returns></returns>
        AccountHandleVerified GetAccountVerified(VerifiedAccount verifiedAccount, JpcSession jpcSession) {
            var accountEntry = GetAccountLocked(verifiedAccount.Account);
            Assert.NotNull(accountEntry);

            using (var catalogDevice = new CatalogDevice(accountEntry.Directory)) {
                foreach (var entry in catalogDevice.AsCatalogEntryDevice) {
                    //if (entry.AuthUDF == jpcSession.UDF) {
                    //    return new AccountHandleVerified(accountEntry);
                    //    }
                    }
                }
            // Goal: Allow an administrator device to regain control of the account
            // by creating Device entry public for itself.

            throw new NotAuthenticated();
            }

        /// <summary>
        /// Get access to an account record for an authenticated request.
        /// </summary>
        /// <param name="verifiedAccount"></param>
        /// <returns></returns>
        AccountHandleUnverified GetAccountUnverified(string account) =>
            new AccountHandleUnverified(GetAccountLocked(account));


        /// <summary>
        /// Get the account record and lock it. The entry must be disposed properly 
        /// to prevent access to the account being blocked from other threads.
        /// </summary>
        /// <param name="account">The account to get.</param>
        /// <returns>The locked account entry if found, otherwise null.</returns>
        AccountEntry GetAccountLocked(string account) {
            AccountEntry result = null;
            bool locked = false;

            try {
                lock (Container) {
                    var containerEntry = Container.Get(account) as ContainerStoreEntry;
                    result = containerEntry?.JsonObject as AccountEntry;
                    Assert.NotNull(result);

                    System.Threading.Monitor.Enter(result, ref locked);
                    return result;
                    }
                }
            catch {
                if (locked) {
                    System.Threading.Monitor.Exit(result);
                    }
                return null;
                }
            }
        }



    public partial class AccountEntry {

        public override string _PrimaryKey => ServiceID;

        public AssertionAccount AssertionAccount => assertionAccount ?? 
            AssertionAccount.Decode(SignedAssertionAccount).CacheValue(out assertionAccount);
        AssertionAccount assertionAccount;

        public AccountEntry() {
            }

        public AccountEntry(CreateRequest request) {
            ServiceID = request.ServiceID;
            SignedProfileMesh = request.SignedProfileMesh;
            SignedAssertionAccount = request.SignedAssertionAccount;
            Verify();
            Directory = ServiceID;
            }

        public bool Verify() => true; // NYI: Verification of signed profile.

        }



    }
