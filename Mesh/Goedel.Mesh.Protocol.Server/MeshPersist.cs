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
        public void AccountAdd(AccountEntry accountEntry) {
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
                new SpoolAccount(directory).Dispose();
                }



            }

        /// <summary>
        /// Update an account record. There must be an existing record and the request must
        /// be appropriately authenticated.
        /// </summary>
        public List<ContainerStatus> AccountStatus(string account) {

            var entry = GetAccount(account);
            var accountEntry = entry.JsonObject as AccountEntry;

            var result = new List<ContainerStatus>();

            result.Add(Catalog.Status(accountEntry.Directory, CatalogCredential.Label));
            result.Add(Catalog.Status(accountEntry.Directory, CatalogDevice.Label));
            result.Add(Catalog.Status(accountEntry.Directory, CatalogContact.Label));
            result.Add(Catalog.Status(accountEntry.Directory, CatalogApplication.Label));
            result.Add(Spool.Status(accountEntry.Directory, SpoolAccount.Label));
            return result;
            }

        /// <summary>
        /// Update an account record. There must be an existing record and the request must
        /// be appropriately authenticated.
        /// </summary>
        public void AccountUpdate() {
            }

        /// <summary>
        /// Update an account record. There must be an existing record and the request must
        /// be appropriately authenticated.
        /// </summary>
        public bool AccountDelete(string account) => Container.Delete(account);


        //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/lock-statement
        //System.Threading.Monitor.Enter(__lockObj, ref __lockWasTaken);
        ContainerStoreEntry GetAccount(string account) =>
            Container.Get(account) as ContainerStoreEntry;




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


    }
