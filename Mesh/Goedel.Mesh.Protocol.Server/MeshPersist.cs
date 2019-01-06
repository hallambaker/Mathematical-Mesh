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
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using Goedel.Persistence;
using Goedel.Utilities;
using Goedel.Mesh;
using Goedel.Protocol;
using Goedel.Mesh.Protocol;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography;
using Goedel.IO;

namespace Goedel.Mesh.Protocol.Server {


    /// <summary>
    /// The Mathematical Mesh persistence store.
    /// </summary>
    public class MeshPersist {

        public ContainerPersistenceStore Container;

        public string DirectoryRoot;

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
        public void AccountAdd(JpcSession jpcSession, AccountEntry accountEntry) {
            ContainerStoreEntry containerEntry;

            var directory = Path.Combine(DirectoryRoot, accountEntry.Directory);
            accountEntry.Directory = directory;

            // Lock the container so that we can create the new account entry without 
            // causing contention.
            lock (Container) {
                containerEntry = Container.New(accountEntry) as ContainerStoreEntry;
                }

            // 
            lock (containerEntry) {
                Directory.CreateDirectory(directory);

                // Create the pro-forma containers.

                new CatalogCredential(directory).Dispose();
                new CatalogDevice(directory).Dispose();
                new CatalogContact(directory).Dispose();
                new CatalogApplication(directory).Dispose();
                new Spool(directory, Spool.SpoolInbound).Dispose();
                }



            }


        public ProfileMesh Connect(JpcSession jpcSession, DareMessage proposedProfile) {
            //string account, ProfileMesh profileMesh) {

            //JSONReader.Trace = true;
            var profileMesh = ProfileMesh.Decode(proposedProfile);

            using (var accountHandle = GetAccountUnverified(profileMesh.Account)) {
                var result = new ProfileMesh() {
                    Account = profileMesh.Account,
                    DeviceProfile = profileMesh.DeviceProfile,
                    ProfileNonce = CryptoCatalog.GetBits(128)
                    };

                var messageConnectionRequest = new MessageConnectionRequest() {
                    ProfileMesh = result
                    };

                var message = DareMessage.Encode(messageConnectionRequest.GetBytes());

                accountHandle.Post(message);
                return result;
                }


            }





        /// <summary>
        /// Update an account record. There must be an existing record and the request must
        /// be appropriately authenticated.
        /// </summary>
        public List<ContainerStatus> AccountStatus(JpcSession jpcSession, VerifiedAccount account) {
            AccountHandleVerified accountEntry = null;

            using (accountEntry = GetAccountVerified(account, jpcSession)) {
                var result = new List<ContainerStatus> {
                    Catalog.Status(accountEntry.Directory, CatalogCredential.Label),
                    Catalog.Status(accountEntry.Directory, CatalogDevice.Label),
                    Catalog.Status(accountEntry.Directory, CatalogContact.Label),
                    Catalog.Status(accountEntry.Directory, CatalogApplication.Label),
                    Spool.Status(accountEntry.Directory, Spool.SpoolInbound)
                    };

                return result;
                }

            }


        /// <summary>
        /// Update an account record. There must be an existing record and the request must
        /// be appropriately authenticated.
        /// </summary>
        public List<ContainerUpdate> AccountDownload(JpcSession jpcSession, VerifiedAccount account, List<ConstraintsSelect> selections) {
            AccountHandleVerified accountEntry = null;


            try {
                accountEntry = GetAccountVerified(account, jpcSession);
                var updates = new List<ContainerUpdate>();
                foreach (var selection in selections) {
                    using (var store = new Store(accountEntry.Directory, selection.Container)) {
                        var update = new ContainerUpdate() {
                            Container = selection.Container,
                            Message = new List<DareMessage>()
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
        public void AccountUpdate(JpcSession jpcSession, VerifiedAccount account, List<ContainerUpdate> Updates) {
            AccountHandleVerified accountEntry = null;


            try {
                accountEntry = GetAccountVerified(account, jpcSession);
                //Assert.NotNull(accountEntry);
                //using (var catalog = new Catalog(accountEntry.Directory, container)) {
                //    foreach (var message in Messages) {
                //        catalog.Apply(message);
                //        }


                //    }

                }

            finally {
                accountEntry?.Dispose();
                }


            }







        /// <summary>
        /// Update an account record. There must be an existing record and the request must
        /// be appropriately authenticated.
        /// </summary>
        public bool AccountDelete(JpcSession jpcSession, VerifiedAccount account) {
            AccountHandleVerified accountEntry = null;

            try {
                accountEntry = GetAccountVerified(account, jpcSession);
                throw new NYI();
                }

            finally {
                System.Threading.Monitor.Exit(accountEntry);
                }


            }

        /// <summary>
        /// Get access to an account record for an authenticated request.
        /// </summary>
        /// <param name="verifiedAccount"></param>
        /// <returns></returns>
        AccountHandleVerified GetAccountVerified(VerifiedAccount verifiedAccount, JpcSession jpcSession) {
            var accountEntry = GetAccountLocked(verifiedAccount.Account);
            Assert.NotNull(accountEntry);

            if (accountEntry.Profile.ProfileDevice?.DeviceAuthenticationKey?.UDF == jpcSession.UDF) {
                return new AccountHandleVerified(accountEntry);
                }



            // check to see if this is an admin device
            var masterProfile = accountEntry.Profile.MasterProfile.GetProfileMaster();
            if (masterProfile.IsAdministrator(jpcSession.UDF)) {
                return new AccountHandleVerified(accountEntry);
                }

            using (var catalogDevice = new CatalogDevice(accountEntry.Directory)) {




                }
            // here look at the list of devices

            // is the requester on it?


            throw new NotAuthenticated();


            }


        /// <summary>
        /// Get access to an account record for an authenticated request.
        /// </summary>
        /// <param name="verifiedAccount"></param>
        /// <returns></returns>
        AccountHandleUnverified GetAccountUnverified(string account) =>
            new AccountHandleUnverified(GetAccountLocked(account));


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

        public override string _PrimaryKey => Account;
        public  string Account => Profile.Account;

        public AccountEntry() {
            }

        public AccountEntry(CreateRequest request) {
            Profile = request.Profile;
            Verify();
            Directory = Account;
            }


        //public string ConvertAccount() => Account.Replace('@', ':');


        public bool Verify() => true; // NYI: Verification of signed profile.



        }

    public class AccountHandle : Disposable {
        public AccountEntry AccountEntry { get; }


        protected override void Disposing() {
            base.Disposing();
            System.Threading.Monitor.Exit(AccountEntry);
            }

        public AccountHandle(AccountEntry accountEntry) => AccountEntry = accountEntry;

        }

    /// <summary>
    /// Unverified account accessor, only has access to spools
    /// </summary>
    public class AccountHandleUnverified : AccountHandle {


        public AccountHandleUnverified(AccountEntry accountEntry) : base(accountEntry) {

            }

        public void Post(DareMessage dareMessage) {

            // here we should perform an authorization operation against the store.

            using (var container = new Spool(AccountEntry.Directory, Spool.SpoolInbound)) {

                container.Add(dareMessage);
                }

            }


        }

    /// <summary>
    /// Verified account accessor, has access to spools and to catalogues
    /// </summary>
    public class AccountHandleVerified : AccountHandle {

        public string Directory => AccountEntry.Directory;


        public AccountHandleVerified(AccountEntry accountEntry) : base(accountEntry) {

            }
        void PostToCatalog(DareMessage dareMessage) => throw new NYI();

        }

    }
