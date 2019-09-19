

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

        static CatalogItem() => AddDictionary(ref _TagDictionary);
        }

    /// <summary>
    /// The Mathematical Mesh persistence store.
    /// </summary>
    public class MeshPersist {

        protected PublicMeshServiceProvider Provider;

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
        public MeshPersist(PublicMeshServiceProvider provider, string directory) {

            Provider = provider;

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
        public ConnectResponse Connect(JpcSession jpcSession, 
                        RequestConnection messageConnectionRequestClient) {

            using (var accountHandle = GetAccountUnverified(messageConnectionRequestClient.ServiceID)) {

                var serviceNonce = CryptoCatalog.GetBits(128);

                var MeshUDF = accountHandle.ProfileMesh.KeyOfflineSignature.KeyPair.UDFBytes;
                var DeviceUDF = messageConnectionRequestClient.ProfileDevice.KeyOfflineSignature.KeyPair.UDFBytes;

                var witness = UDF.MakeWitnessString(MeshUDF, serviceNonce, DeviceUDF, 
                    messageConnectionRequestClient.ClientNonce);

                var messageConnectionRequest = new AcknowledgeConnection() {
                    EnvelopedRequestConnection = messageConnectionRequestClient.DareEnvelope,
                    ServerNonce = serviceNonce,
                    Witness = witness,
                    MessageID = UDF.Nonce ()
                    };

                // Bug: should authenticate the envelope under the service key and also encrypt it under the device key.

                var message = Envelope(messageConnectionRequest);
                accountHandle.Post(message);


                var connectResponse = new ConnectResponse() {
                    EnvelopedConnectionResponse = message,
                    EnvelopedProfileMaster = accountHandle.ProfileMesh.DareEnvelope,
                    EnvelopedAccountAssertion = accountHandle.AssertionAccount.DareEnvelope
                    };

                return connectResponse;
                }
            }

        /// <summary>
        /// Update an account record. There must be an existing record and the request must
        /// be appropriately authenticated.
        /// </summary>
        /// <param name="jpcSession">The session connection data.</param>
        /// <param name="account">The account for which the status is requested..</param>
        public StatusResponse AccountComplete(JpcSession jpcSession, CompleteRequest completeRequest) {

            using (var accountHandle = GetAccountUnverified(completeRequest.ServiceID)) {

                var catalogEntry = accountHandle.GetCatalogEntryDevice(completeRequest.DeviceUDF);

                var statusResponse = new StatusResponse() {
                    //ContainerStatus = containerStatus,
                    EnvelopedProfileMaster = accountHandle.ProfileMesh.DareEnvelope,
                    EnvelopedAccountAssertion = accountHandle.AssertionAccount.DareEnvelope,
                    EnvelopedCatalogEntryDevice = catalogEntry.DareEnvelope
                    };


                return statusResponse;
                }

            }


        /// <summary>
        /// Update an account record. There must be an existing record and the request must
        /// be appropriately authenticated.
        /// </summary>
        /// <param name="jpcSession">The session connection data.</param>
        /// <param name="account">The account for which the status is requested..</param>
        public StatusResponse AccountStatus(JpcSession jpcSession, VerifiedAccount account) {
            AccountHandleVerified accountHandle = null;

            using (accountHandle = GetAccountVerified(account, jpcSession)) {

                var containerStatus = new List<ContainerStatus> {
                    accountHandle.GetStatusSpool (Spool.SpoolInbound),
                    accountHandle.GetStatusCatalog (CatalogCredential.Label),
                    accountHandle.GetStatusCatalog (CatalogDevice.Label),
                    accountHandle.GetStatusCatalog (CatalogContact.Label),
                    accountHandle.GetStatusCatalog (CatalogApplication.Label),
                    accountHandle.GetStatusCatalog (CatalogCredential.Label)
                    };

                var statusResponse = new StatusResponse() {
                    ContainerStatus = containerStatus,
                    EnvelopedProfileMaster = accountHandle.ProfileMesh.DareEnvelope,
                    EnvelopedAccountAssertion = accountHandle.AssertionAccount.DareEnvelope,
                    EnvelopedCatalogEntryDevice = null
                    };

                // summarize the status here.

                statusResponse.ToConsole();

                return statusResponse;
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

            using (var accountEntry = GetAccountVerified(account, jpcSession)) {

                var updates = new List<ContainerUpdate>();
                foreach (var selection in selections) {
                    using (var store = accountEntry.GetStore(selection.Container)) {
                        var update = new ContainerUpdate() {
                            Container = selection.Container,
                            Envelopes = new List<DareEnvelope>()
                            };


                        foreach (var message in store.Select(selection.IndexMin)) {
                            update.Envelopes.Add(message);
                            }

                        updates.Add(update);
                        }
                    }
                return updates;
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

            // report the updates to be applied here


            using (var accountEntry = GetAccountVerified(account, jpcSession)) {
                Assert.NotNull(accountEntry);
                if (selfs != null) {
                    foreach (var self in selfs) {
                        accountEntry.Post(self);
                        }
                    }

                if (updates != null) {
                    foreach (var update in updates) {
                        update.ToConsole();
                        accountEntry.StoreAppend(update.Container, update.Envelopes);
                        }
                    }
                }

            // report the final status of the containers here.


            }

        /// <summary>
        /// Update an account record. There must be an existing record and the request must
        /// be appropriately authenticated.
        /// </summary>
        /// <param name="jpcSession">The session connection data.</param>
        /// <param name="account">The account to be deleted.</param> 
        public bool AccountDelete(JpcSession jpcSession, VerifiedAccount account) {
            lock (Container) {
                return Container.Delete(account.ServiceID);
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
                throw new NYI();
                //// calculate the identifier her
                //var identifier = "fred";
                //dareMessage.Header.UniqueID = identifier;
                //Assert.NotNull(accountUnverified);
                //accountUnverified.Post(dareMessage);
                //return identifier;
                }
            }


        /// <summary>
        /// Get access to an account record for an authenticated request.
        /// </summary>
        /// <param name="jpcSession">The session connection data.</param>      
        /// <param name="verifiedAccount">The account for which the data is requested.</param>
        /// <returns></returns>
        AccountHandleVerified GetAccountVerified(VerifiedAccount verifiedAccount, JpcSession jpcSession) {
            var accountEntry = GetAccountLocked(verifiedAccount.ServiceID);
            Assert.NotNull(accountEntry);

            //using (var catalogDevice = new CatalogDevice(accountEntry.Directory, create:false)) {
            //    if (catalogDevice?.ContainerPersistence != null) {

            //        foreach (var entry in catalogDevice.AsCatalogEntryDevice) {
            //            //if (entry.AuthUDF == jpcSession.UDF) {
            //            //    return new AccountHandleVerified(accountEntry);
            //            //    }
            //            }
            //        }
            //    }
            // Goal: Allow an administrator device to regain control of the account
            // by creating Device entry public for itself.

            if (jpcSession is DirectSession ) {
                return new AccountHandleVerified(accountEntry);
                }
            if (jpcSession is LocalRemoteSession ) {
                return new AccountHandleVerified(accountEntry);
                }
            // At this point we need to examine the actual information presented and the 
            // AssertionDeviceConnection value from the session.

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



        /// <summary>
        /// Create a message envelope for a message originated by the service. The message is
        /// always signed under the service key and encrypted under the keys of at least
        /// one recipient.
        /// </summary>
        /// <param name="message">The message to be wrapped by the envelope</param>
        /// <returns>The signed message.</returns>
        DareEnvelope Envelope(Message message) {




            return DareEnvelope.Encode(message.GetBytes());


            }




        }



    public partial class AccountEntry {




        public override string _PrimaryKey => ServiceID;

        public ProfileMesh ProfileMesh => profileMesh ??
                ProfileMesh.Decode(SignedProfileMesh).CacheValue(out profileMesh);
        ProfileMesh profileMesh;


        public ProfileAccount AssertionAccount => assertionAccount ?? 
            ProfileAccount.Decode(SignedAssertionAccount).CacheValue(out assertionAccount);
        ProfileAccount assertionAccount;

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
