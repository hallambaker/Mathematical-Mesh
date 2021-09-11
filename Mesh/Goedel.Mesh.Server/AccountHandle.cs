#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
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
#endregion



using System.Collections.Generic;

using Goedel.Cryptography.Dare;
using Goedel.Protocol;
using Goedel.Utilities;
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


    ///// <summary>
    ///// Unverified account accessor, only has access to spools
    ///// </summary>
    //public class AccountHandleGroup : AccountHandle {
    //    /// <summary>
    //    /// Constructor.
    //    /// </summary>
    //    /// <param name="accountEntry">The account entry to create a handle for.</param>
    //    public AccountHandleGroup(AccountGroup accountEntry) : base(accountEntry) {
    //        }
    //    }

    /// <summary>
    /// Unverified account accessor, only has access to spools
    /// </summary>
    public class AccountHandleUnverified : AccountHandle {



        /// <summary>
        /// The account description. This is only accessible through the account handle.
        /// </summary>
        protected AccountUser AccountUser => AccountEntry as AccountUser;

        ///<summary>Convenience accessor to the Account assertion.</summary>
        public ProfileUser ProfileUser => AccountUser.ProfileUser;

        ///<summary>Convenience accessor for DareEnvelope returning a typed envelope.</summary> 
        public Enveloped<ProfileAccount> EnvelopedProfileAccount =>
                new(AccountUser.EnvelopedProfileUser);

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="accountEntry">The account entry to create a handle for.</param>
        public AccountHandleUnverified(AccountEntry accountEntry) : base(accountEntry) {
            }




        /// <summary>
        /// Return the publication catalog. This is a catalog that the service MUST have
        /// read access to. Not clear that the clients need access though.
        /// </summary>
        /// <returns></returns>
        public CatalogPublication GetCatalogPublication() =>
            new(AccountEntry.Directory);


        /// <summary>
        /// Return the publication catalog. This is a catalog that the service MUST have
        /// read access to. Not clear that the clients need access though.
        /// </summary>
        /// <returns></returns>
        public CatalogAccess GetCatalogCapability() =>
            new(AccountEntry.Directory);

        /// <summary>
        /// Post a message to the spool associated with the account. This is the only operation
        /// that is supported for a device that is not connected to the account profile.
        /// </summary>
        /// <param name="dareMessage">The message to post.</param>
        public void PostInbound(DareEnvelope dareMessage) {

            // here we should perform an authorization operation against the store.

            using var container = new Spool(AccountEntry.Directory, SpoolInbound.Label);
            container.Add(dareMessage);

            }

        /// <summary>
        /// Post a message to the spool associated with the account. This is the only operation
        /// that is supported for a device that is not connected to the account profile.
        /// </summary>
        /// <param name="envelope">The message to post.</param>
        public void PostLocal(DareEnvelope envelope) {

            // here we should perform an authorization operation against the store.

            using var container = new Spool(AccountEntry.Directory, SpoolLocal.Label);
            container.Add(envelope);

            }

        /// <summary>
        /// Return the message with identifier <paramref name="messageId"/> from the local spool.
        /// </summary>
        /// <param name="messageId">Message to return.</param>
        /// <returns>The message (if found).</returns>
        public DareEnvelope GetLocal(string messageId) {
            var envelopeId = Message.GetEnvelopeId(messageId);

            using var spoolLocal = GetStoreLocal();

            foreach (var message in spoolLocal.Select(0, reverse: true)) {
                if (message?.EnvelopeId == envelopeId) {
                    return message;
                    }

                }
            return null;
            }

        /// <summary>
        /// Open the store SpoolLocal and return an accessor.
        /// </summary>
        /// <returns>The store handle</returns>
        public Store GetStoreLocal() =>
            new(AccountEntry.Directory, SpoolLocal.Label);
        }

    /// <summary>
    /// Verified account accessor, has access to spools and to catalogues
    /// </summary>
    public class AccountHandleVerified : AccountHandleUnverified {
        CatalogAccess CatalogAccess { get; }

        /// <summary>
        /// Disposing method.
        /// </summary>
        protected override void Disposing() {
            base.Disposing();
            CatalogAccess?.Dispose();
            }

        /// <summary>
        /// Constructor returning a verified account handle for <paramref name="accountEntry"/>.
        /// </summary>
        /// <param name="accountEntry">The account entry from the catalog.</param>
        /// <param name="credential">The credential used to claim the account.</param>
        public AccountHandleVerified(AccountEntry accountEntry, ICredential credential) : base(accountEntry) {


            CatalogAccess= new CatalogAccess(AccountEntry.Directory);
            VerifyAccess(credential as MeshCredential);
            }


        void VerifyAccess(MeshCredential credential) {
            if (CatalogAccess != null) {

                foreach (var access in CatalogAccess.AsCatalogedType) {
                    if (access.Capability is AccessCapability accessCapability) {
                        if (credential?.ConnectionDevice?.AuthenticationPublic?.MatchKeyIdentifier(
                            accessCapability.Id) == true) {
                            accessCapability.Active.AssertTrue (NotAuthorized.Throw);
                            return;
                            }

                        }
                    }
                }
            credential.ConnectionDevice.Active.AssertTrue(NotAuthorized.Throw);

            }


        /// <summary>
        /// Return the status of the catalog <paramref name="label"/>.
        /// </summary>
        /// <param name="label">Catalog to return status on.</param>
        /// <returns>The status vector.</returns>
        public ContainerStatus GetStatusStore(string label) =>
            Store.Status(AccountEntry.Directory, label);

        /// <summary>
        /// Open the store <paramref name="label"/> and return an accessor.
        /// </summary>
        /// <param name="label">The store to open</param>
        /// <returns></returns>
        public Store GetStore(string label) =>
            new(AccountEntry.Directory, label);

        /// <summary>
        /// Append the envelopes <paramref name="envelopes"/> to the store named
        /// <paramref name="label"/>.
        /// </summary>
        /// <param name="label">The store to add the envelopes to.</param>
        /// <param name="envelopes">The envelopes to append.</param>
        public void StoreAppend(string label, List<DareEnvelope> envelopes) =>
            Store.Append(AccountEntry.Directory, null, envelopes, label);



        /// <summary>
        /// Obtain status values for all the stores associated with an account.
        /// </summary>
        /// <returns>The list of container status entries.</returns>
        public List<ContainerStatus> GetContainerStatuses() {
            var result = new List<ContainerStatus> {
                    GetStatusStore (SpoolInbound.Label),
                    GetStatusStore (SpoolOutbound.Label),
                    GetStatusStore (SpoolLocal.Label),
                    GetStatusStore (CatalogAccess.Label)

                };

            switch (AccountEntry) {
                //case AccountGroup _: {
                //    result.Add(GetStatusStore(CatalogMember.Label));
                //    break;
                //    }

                case Goedel.Mesh.Server.AccountUser _: {
                    result.Add(GetStatusStore(CatalogCredential.Label));
                    result.Add(GetStatusStore(CatalogDevice.Label));
                    result.Add(GetStatusStore(CatalogContact.Label));
                    result.Add(GetStatusStore(CatalogApplication.Label));
                    result.Add(GetStatusStore(CatalogPublication.Label));
                    result.Add(GetStatusStore(CatalogBookmark.Label));
                    result.Add(GetStatusStore(CatalogTask.Label));
                    break;
                    }
                }

            return result;
            }

        }
    }
