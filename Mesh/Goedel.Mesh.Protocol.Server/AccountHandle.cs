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

using Goedel.Cryptography.Dare;
using Goedel.Utilities;

using System.Collections.Generic;
namespace Goedel.Mesh.Server {

    /// <summary>
    /// Provides a means of accessing an account mediated by the permissions specified
    /// in the corresponding AccountEntry. This class and its descendants implement the
    /// security monitor for enforcing access control at the account level.
    /// </summary>
    public class AccountHandle : Disposable {

        ///<summary>Convenience accessor to the Mesh Profile.</summary>
        public ProfileMesh ProfileMesh => AccountEntry.ProfileMesh;

        ///<summary>Convenience accessor to the Account assertion.</summary>
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

            using var container = new Spool(AccountEntry.Directory, Spool.SpoolInbound);
            container.Add(dareMessage);

            }


        //public DareEnvelope GetCatalogEntryDevice(string deviceUDF) {
        //    // NYI: pull up the device catalog for the account
        //    // Identify the relevant device record
        //    // return it.

        //    Container.ToConsole(Store.FileName(AccountEntry.Directory, CatalogDevice.Label));

        //    using (var container = new CatalogBlind(AccountEntry.Directory, CatalogDevice.Label)) {
        //        return container.Get(deviceUDF);
        //        }


        //    throw new NYI();
        //    }
        }

    /// <summary>
    /// Verified account accessor, has access to spools and to catalogues
    /// </summary>
    public class AccountHandleVerified : AccountHandleUnverified {

        //public string Directory => AccountEntry.Directory;

        /// <summary>
        /// Constructor returning a verified account handle for <paramref name="accountEntry"/>.
        /// </summary>
        /// <param name="accountEntry"></param>
        public AccountHandleVerified(AccountEntry accountEntry) : base(accountEntry) {

            }

        /// <summary>
        /// Return the status of the catalog <paramref name="label"/>.
        /// </summary>
        /// <param name="label">Catalog to return status on.</param>
        /// <returns>The status vector.</returns>
        public ContainerStatus GetStatusCatalog(string label) =>
            Catalog.Status(AccountEntry.Directory, label);

        /// <summary>
        /// Return the status of the spool <paramref name="label"/>.
        /// </summary>
        /// <param name="label">Spool to return status on.</param>
        /// <returns>The status vector.</returns>
        public ContainerStatus GetStatusSpool(string label) =>
            Spool.Status(AccountEntry.Directory, label);

        /// <summary>
        /// Open the store <paramref name="label"/> and return an accessor.
        /// </summary>
        /// <param name="label">The store to open</param>
        /// <returns></returns>
        public Store GetStore(string label) =>
            new Store(AccountEntry.Directory, label);

        /// <summary>
        /// Append the envelopes <paramref name="envelopes"/> to the store named
        /// <paramref name="label"/>.
        /// </summary>
        /// <param name="label">The store to add the envelopes to.</param>
        /// <param name="envelopes">The envelopes to append.</param>
        public void StoreAppend(string label, List<DareEnvelope> envelopes) =>
            Store.Append(AccountEntry.Directory, envelopes, label);



        /// <summary>
        /// Post a message to the spool associated with the account. This is the only operation
        /// that is supported for a device that is not connected to the account profile.
        /// </summary>
        /// <param name="dareMessage">The message to post.</param>
        public void PostLocal(DareEnvelope dareMessage) {

            // here we should perform an authorization operation against the store.

            using var container = new Spool(AccountEntry.Directory, Spool.SpoolLocal);
            container.Add(dareMessage);

            }

        /// <summary>
        /// Return the message with identifier <paramref name="id"/> from the local spool.
        /// </summary>
        /// <param name="id">Message to return.</param>
        /// <returns>The message (if found).</returns>
        public DareEnvelope GetLocal(string id) {
            using var spoolLocal = GetStore(Spool.SpoolLocal);

            foreach (var message in spoolLocal.Select(0, reverse:true)) {
                if (message?.Header?.ContentMeta?.UniqueID == id) {
                    return message;
                    }

                }


            throw new NYI();
            }
        }
    }
