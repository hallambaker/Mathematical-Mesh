//   Copyright © 2018 Phillip Hallam-Baker
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
using Goedel.Utilities;
using Goedel.Mesh;
using Goedel.Protocol;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography;
using Goedel.IO;
namespace Goedel.Mesh.Server {

    /// <summary>
    /// Provides a means of accessing an account mediated by the permissions specified
    /// in the corresponding AccountEntry. This class and its descendants implement the
    /// security monitor for enforcing access control at the account level.
    /// </summary>
    public class AccountHandle : Disposable {

        public ProfileMesh ProfileMesh => AccountEntry.ProfileMesh;


        public ProfileAccount AssertionAccount => AccountEntry.AssertionAccount;


        /// <summary>
        /// The account description. This is only accessible through the account handle.
        /// </summary>
        protected AccountEntry AccountEntry { get; }

        /// <summary>
        /// Free resources associated with the handle. In particular the lock on the account entry.
        /// </summary>
        protected override void Disposing() => System.Threading.Monitor.Exit(AccountEntry);

        /// <summary>
        /// Base constructor.
        /// </summary>
        /// <param name="accountEntry">The account entry to create a handle for.</param>
        public AccountHandle(AccountEntry accountEntry) => AccountEntry = accountEntry;

        }

    /// <summary>
    /// Unverified account accessor, only has access to spools
    /// </summary>
    public class AccountHandleUnverified : AccountHandle {

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="accountEntry">The account entry to create a handle for.</param>
        public AccountHandleUnverified(AccountEntry accountEntry) : base(accountEntry) {
            }

        /// <summary>
        /// Post a message to the spool associated with the account. This is the only operation
        /// that is supported for a device that is not connected to the account profile.
        /// </summary>
        /// <param name="dareMessage">The message to post.</param>
        public void Post(DareEnvelope dareMessage) {

            // here we should perform an authorization operation against the store.

            using (var container = new Spool(AccountEntry.Directory, Spool.SpoolInbound)) {

                container.Add(dareMessage);
                }

            }

        public DareEnvelope GetCatalogEntryDevice(string deviceUDF) {
            // NYI: pull up the device catalog for the account
            // Identify the relevant device record
            // return it.

            Container.ToConsole(Store.FileName(AccountEntry.Directory, CatalogDevice.Label));

            using (var container = new CatalogBlind(AccountEntry.Directory, CatalogDevice.Label)) {
                return container.Get(deviceUDF);
                }


            throw new NYI();
            }
        }

    /// <summary>
    /// Verified account accessor, has access to spools and to catalogues
    /// </summary>
    public class AccountHandleVerified : AccountHandleUnverified {

        //public string Directory => AccountEntry.Directory;


        public AccountHandleVerified(AccountEntry accountEntry) : base(accountEntry) {

            }


        public ContainerStatus GetStatusCatalog(string Label) =>
            Catalog.Status(AccountEntry.Directory, Label);

        public ContainerStatus GetStatusSpool(string Label) =>
            Spool.Status(AccountEntry.Directory, Label);

        public Store GetStore(string Label) =>
            new Store(AccountEntry.Directory, Label);

        public Catalog GetCatalog(string Label) =>
            new Catalog(AccountEntry.Directory, Label);


        public void StoreAppend(string Label, List<DareEnvelope> envelopes) =>
            Store.Append(AccountEntry.Directory, envelopes, Label);


        }
    }
