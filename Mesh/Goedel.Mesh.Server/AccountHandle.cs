//   Copyright © 2020 Phillip Hallam-Baker
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
    public class AccountHandleGroup : AccountHandle {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="accountEntry">The account entry to create a handle for.</param>
        public AccountHandleGroup(AccountGroup accountEntry) : base(accountEntry) {
            }
        }

    /// <summary>
    /// Unverified account accessor, only has access to spools
    /// </summary>
    public class AccountHandleUnverified : AccountHandle {

        ///<summary>Convenience accessor to the Account assertion.</summary>
        public ProfileAccount AssertionAccount => AccountPersonal.AssertionAccount;

        /// <summary>
        /// The account description. This is only accessible through the account handle.
        /// </summary>
        protected AccountPersonal AccountPersonal => AccountEntry as AccountPersonal;

        ///<summary>Convenience accessor to the Mesh Profile.</summary>
        public ProfileMesh ProfileMesh => AccountPersonal?.ProfileMesh;


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

            using var container = new Spool(AccountEntry.Directory, SpoolInbound.Label);
            container.Add(dareMessage);

            }


        /// <summary>
        /// Return the publication catalog. This is a catalog that the service MUST have
        /// read access to. Not clear that the clients need access though.
        /// </summary>
        /// <returns></returns>
        public CatalogPublication GetCatalogPublication() =>
            new CatalogPublication(AccountEntry.Directory);


        /// <summary>
        /// Return the publication catalog. This is a catalog that the service MUST have
        /// read access to. Not clear that the clients need access though.
        /// </summary>
        /// <returns></returns>
        public CatalogCapability GetCatalogCapability() =>
            new CatalogCapability(AccountEntry.Directory);


        /// <summary>
        /// Post a message to the spool associated with the account. This is the only operation
        /// that is supported for a device that is not connected to the account profile.
        /// </summary>
        /// <param name="dareMessage">The message to post.</param>
        public void PostLocal(DareEnvelope dareMessage) {

            // here we should perform an authorization operation against the store.

            using var container = new Spool(AccountEntry.Directory, SpoolLocal.Label);
            container.Add(dareMessage);

            }

        /// <summary>
        /// Return the message with identifier <paramref name="messageId"/> from the local spool.
        /// </summary>
        /// <param name="messageId">Message to return.</param>
        /// <returns>The message (if found).</returns>
        public DareEnvelope GetLocal(string messageId) {

            // Hack: should be get spool here.
            // and look for the envelope values

            var envelopeId = Message.GetEnvelopeId(messageId);

            using var spoolLocal = GetStoreLocal();

            foreach (var message in spoolLocal.Select(0, reverse: true)) {
                if (message?.EnvelopeID == envelopeId) {
                    return message;
                    }

                }
            // this is currently failing because on connect, the connecting device is looking
            // for a different message ID to the one specified by the admin device in the response.

            return null;
            }

        /// <summary>
        /// Open the store SpoolLocal and return an accessor.
        /// </summary>
        /// <returns>The store handle</returns>
        public Store GetStoreLocal() =>
            new Store(AccountEntry.Directory, SpoolLocal.Label);
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
        /// Obtain status values for all the stores associated with an account.
        /// </summary>
        /// <returns>The list of container status entries.</returns>
        public List<ContainerStatus> GetContainerStatuses() {
            var result = new List<ContainerStatus> {
                    GetStatusSpool (SpoolInbound.Label),
                    GetStatusSpool (SpoolOutbound.Label),
                    GetStatusSpool (SpoolLocal.Label),
                    GetStatusCatalog (CatalogCapability.Label)

                };

            switch (AccountEntry) {
                case AccountGroup _: {
                    result.Add(GetStatusCatalog(CatalogMember.Label));
                    break;
                    }

                case Goedel.Mesh.Server.AccountPersonal _: {
                    result.Add(GetStatusCatalog(CatalogCredential.Label));
                    result.Add(GetStatusCatalog(CatalogDevice.Label));
                    result.Add(GetStatusCatalog(CatalogContact.Label));
                    result.Add(GetStatusCatalog(CatalogApplication.Label));
                    result.Add(GetStatusCatalog(CatalogBookmark.Label));
                    result.Add(GetStatusCatalog(CatalogCalendar.Label));
                    break;
                    }
                }

            return result;
            }

        }
    }
