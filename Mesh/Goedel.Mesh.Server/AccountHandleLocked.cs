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



using System;
using System.Collections.Generic;

using Goedel.Cryptography.Dare;
using Goedel.Protocol;
using Goedel.Protocol.Presentation;
using Goedel.Utilities;
namespace Goedel.Mesh.Server {

    /// <summary>
    /// Account privileges
    /// </summary>
    [Flags]
    public enum AccountPrivilege {
        Unbind      = 0b0000_0001,
        Connected   = 0b0000_0010,
        Pending     = 0b0000_0100,
        Device      = 0b0000_1000,
        Post        = 0b0001_0000,
        Local       = 0b0010_0000,

        ///<summary>All privileges.</summary> 
        All         = 0xFFF
        }

    public class AccountContext {

        DateTime Created;
        DateTime Accessed;
        public AccountEntry AccountEntry { get; init; }

        public Dictionary <string, Store> DictionaryStores = new ();


        public AccountContext() {
            Created = Accessed = DateTime.Now;
            }

        Store GetStore() {
            throw new NYI();
            }

        /// <summary>
        /// Called just before a caller unlocks the file, Updates the 
        /// last access timestamp to allow intelligent cache management.
        /// </summary>
        public void Close() {
            Accessed = DateTime.Now;
            }


        public bool Authenticate(
                    IJpcSession session, 
                    AccountPrivilege accountPrivilege) {
            switch (session.Credential) {
                case KeyCredentialPublic keyCredentialPublic: {
                    return Authenticate(keyCredentialPublic, accountPrivilege);
                    }
                }
            return false;
            }

        public bool Authenticate(
                    KeyCredentialPublic credential,
                    AccountPrivilege accountPrivilege) {

            var profileAccount = (AccountEntry as AccountUser).GetProfileAccount();

            // To operate under the account authentication key, the request must be
            // authenticated under the AccountAuthenticationKey
            (profileAccount.AccountAuthenticationKey.MatchKeyIdentifier(
                    credential.AuthenticationKeyId)).AssertTrue (NotAuthorized.Throw);

            return true;
            }

        }


    public class AccountHandleLocked : Disposable {



        public string Provider;


        public AccountPrivilege AccountPrivilege { get; init; }

        /// <summary>
        /// The account description. This is only accessible through the account handle.
        /// </summary>
        protected AccountContext AccountContext { get; }

        public string AccountAddress => AccountContext.AccountEntry.AccountAddress;


        protected AccountUser AccountUser => AccountContext.AccountEntry as AccountUser;

        public ProfileAccount ProfileAccount => AccountUser.GetProfileAccount();


        string Directory => AccountContext.AccountEntry.Directory;

        protected override void Disposing() {
            AccountContext.Close();
            System.Threading.Monitor.Exit(AccountContext);
            }



        public AccountHandleLocked(IJpcSession session, AccountContext accountContext) {
            accountContext = AccountContext;
            }


        /// <summary>
        /// Return the status of the catalog <paramref name="label"/>.
        /// </summary>
        /// <param name="label">Catalog to return status on.</param>
        /// <returns>The status vector.</returns>
        public ContainerStatus GetStatusStore(string label) =>
            Store.Status(Directory, label);


        /// <summary>
        /// Open the store <paramref name="label"/> and return an accessor.
        /// </summary>
        /// <param name="label">The store to open</param>
        /// <returns></returns>
        public Store GetStore(string label) =>
            new(Directory, label);


        /// <summary>
        /// Return the publication catalog. This is a catalog that the service MUST have
        /// read access to. Not clear that the clients need access though.
        /// </summary>
        /// <returns></returns>
        public CatalogAccess GetCatalogCapability() =>
            new(Directory);

        /// <summary>
        /// Return the publication catalog. This is a catalog that the service MUST have
        /// read access to. Not clear that the clients need access though.
        /// </summary>
        /// <returns></returns>
        public CatalogPublication GetCatalogPublication() =>
            new(Directory);


        /// <summary>
        /// Post a message to the spool associated with the account. This is the only operation
        /// that is supported for a device that is not connected to the account profile.
        /// </summary>
        /// <param name="dareMessage">The message to post.</param>
        public void PostInbound(DareEnvelope dareMessage) {
            AccountPrivilege.HasFlag(AccountPrivilege.Post).AssertTrue(NotAuthorized.Throw);

            using var container = new Spool(Directory, SpoolInbound.Label);
            container.Add(dareMessage);

            }

        /// <summary>
        /// Post a message to the spool associated with the account. This is the only operation
        /// that is supported for a device that is not connected to the account profile.
        /// </summary>
        /// <param name="envelope">The message to post.</param>
        public void PostLocal(DareEnvelope envelope) {
            AccountPrivilege.HasFlag(AccountPrivilege.Local).AssertTrue(NotAuthorized.Throw);

            using var container = new Spool(Directory, SpoolLocal.Label);
            container.Add(envelope);

            }

        /// <summary>
        /// Append the envelopes <paramref name="envelopes"/> to the store named
        /// <paramref name="label"/>.
        /// </summary>
        /// <param name="label">The store to add the envelopes to.</param>
        /// <param name="envelopes">The envelopes to append.</param>
        public void StoreAppend(string label, List<DareEnvelope> envelopes) {
            AccountPrivilege.HasFlag(AccountPrivilege.Connected).AssertTrue(NotAuthorized.Throw);
            Store.Append(Directory, null, envelopes, label);
            }






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

            switch (AccountContext.AccountEntry) {
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

        /// <summary>
        /// Return the message with identifier <paramref name="messageId"/> from the local spool.
        /// </summary>
        /// <param name="messageId">Message to return.</param>
        /// <returns>The message (if found).</returns>
        public DareEnvelope GetLocal(string messageId) {
            var envelopeId = Message.GetEnvelopeId(messageId);

            using var spoolLocal = GetStore(SpoolLocal.Label);

            foreach (var message in spoolLocal.Select(0, reverse: true)) {
                if (message?.EnvelopeId == envelopeId) {
                    return message;
                    }

                }
            return null;
            }


        }
    }
