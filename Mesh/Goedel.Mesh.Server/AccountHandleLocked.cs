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
        ///<summary>Unbind the account from the service permitting it to be deleted.</summary> 
        Unbind      = 0b0000_0001,
        ///<summary>Operations requiring a connection to the account</summary> 
        Connected   = 0b0000_0010,
        ///<summary>Device in a pending state, authenticated by key alone.</summary> 
        Pending     = 0b0000_0100,
        ///<summary>???</summary> 
        Device      = 0b0000_1000,
        ///<summary>???</summary> 
        Post        = 0b0001_0000,
        ///<summary>???</summary> 
        Local       = 0b0010_0000,
        ///<summary>???</summary> 
        Operate     = 0b0100_0000,

        ///<summary>All privileges.</summary> 
        All         = 0xFFF
        }

    /// <summary>
    /// Wrapper for the AccountEntry permitting the context in which the account entry
    /// is used to be cached and shared between operations.
    /// </summary>
    public class AccountContext : Disposable {

        #region // Public and private properties

        ///<summary>Timestamp of context creation.</summary> 
        public DateTime Created { get; }

        ///<summary>Timestamp of context last accessed</summary> 
        public DateTime Accessed { get; private set; }

        ///<summary>The account entry from the host store.</summary> 
        public AccountEntry AccountEntry { get; init; }

        ///<summary>The directory in which all the account data is stored.</summary> 
        public string Directory => AccountEntry.Directory;

        public AccessCapability AccessCapability => CatalogedAccess?.Capability as AccessCapability;


        public CatalogedAccess CatalogedAccess { get; set; }

        Dictionary <string, Store> DictionaryStores = new ();

        #endregion
        #region // Dispose

        protected override void Disposing() {
            }

        #endregion
        #region // Constructors
        /// <summary>
        /// Return a new instance.
        /// </summary>
        public AccountContext() => Created = Accessed = DateTime.Now;

        #endregion
        #region // Methods
        Store GetStore() {



            throw new NYI();
            }

        /// <summary>
        /// Return the publication catalog. This is a catalog that the service MUST have
        /// read access to. Not clear that the clients need access though.
        /// </summary>
        /// <returns></returns>
        public CatalogAccess GetCatalogCapability() =>
            new(Directory);


        /// <summary>
        /// Called just before a caller unlocks the file, Updates the 
        /// last access timestamp to allow intelligent cache management.
        /// </summary>
        public void Close() {
            Accessed = DateTime.Now;
            }

        /// <summary>
        /// Verify that the request <paramref name="session"/> has the 
        /// privileges <paramref name="accountPrivilege"/>.
        /// </summary>
        /// <param name="session">The request session.</param>
        /// <param name="accountPrivilege">The privileges required to perform the operation.</param>
        /// <returns>True if all the privileges are granted, otherwise false.</returns>
        public bool Authenticate(
                    IJpcSession session, 
                    AccountPrivilege accountPrivilege) {
            switch (session.Credential) {
                case KeyCredentialPublic keyCredentialPublic: {
                    return Authenticate(keyCredentialPublic, accountPrivilege);
                    }
                case MeshCredential meshCredential: {
                    return Authenticate(meshCredential, accountPrivilege);
                    }
                }
            return false;
            }

        bool Authenticate(
                    KeyCredentialPublic credential,
                    AccountPrivilege accountPrivilege) {

            var profileAccount = (AccountEntry as AccountUser).GetProfileAccount();

            // To operate under the account authentication key, the request must be
            // authenticated under the AccountAuthenticationKey

            switch (accountPrivilege) {
                case AccountPrivilege.Device: {
                    break;
                    }
                default: {
                    (profileAccount.AccountAuthenticationKey.MatchKeyIdentifier(
                            credential.AuthenticationKeyId)).AssertTrue(NotAuthorized.Throw);
                    break;
                    }
                }




            return true;
            }

        bool Authenticate(
            MeshCredential credential,
            AccountPrivilege accountPrivilege) {

            var profileAccount = (AccountEntry as AccountUser).GetProfileAccount();

            using var catalogCapability = GetCatalogCapability();

            CatalogedAccess = catalogCapability.Locate(credential.AuthenticationKeyId);

            switch (accountPrivilege) {
                case AccountPrivilege.Post:
                case AccountPrivilege.Device: {
                    break;
                    }
                default: {
                    (AccessCapability?.Active == true).AssertTrue(NotAuthorized.Throw);
                    break;
                    }
                }



            //if (AccessCapability?.Active != true) {
            //    (accountPrivilege == AccountPrivilege.Device).AssertTrue(NotAuthorized.Throw);

            //    }


            "Need to validate the client credential to the account here.".TaskFunctionality(Assert.HaltPhase1);
            //AccessCapability.AssertNotNull(NotAuthorized.Throw);
            //AccessCapability.Active.AssertTrue(NotAuthorized.Throw);

            //// To operate under the account authentication key, the request must be
            //// authenticated under the AccountAuthenticationKey
            //(profileAccount.AccountAuthenticationKey.MatchKeyIdentifier(
            //        credential.AuthenticationKeyId)).AssertTrue(NotAuthorized.Throw);

            return true;
            }

        #endregion
        }


    /// <summary>
    /// Account handle, implements the security monitor mediating all access to 
    /// account stores.
    /// </summary>
    public class AccountHandleLocked : Disposable {

        #region // Public and private properties
        ///<summary>The service provider.</summary> 
        public string Provider;

        ///<summary>The privilege granted to the client.</summary> 
        public AccountPrivilege AccountPrivilege { get; init; }

        /// <summary>
        /// The account description. This is only accessible through the account handle.
        /// </summary>
        protected AccountContext AccountContext { get; }


        ///<summary>Convenience accessor for the account address</summary> 
        public string AccountAddress => AccountContext.AccountEntry.AccountAddress;

        ///<summary>The account entry in the service catalog.</summary> 
        protected AccountUser AccountUser => AccountContext.AccountEntry as AccountUser;

        ///<summary>The account profile</summary> 
        public ProfileAccount ProfileAccount => AccountUser.GetProfileAccount();

        ///<summary>The directory in which all the account data is stored.</summary> 
        string Directory => AccountContext.Directory;


        public Enveloped<CatalogedDevice> EnvelopedCatalogedDevice =>
                    AccountContext.AccessCapability?.EnvelopedCatalogedDevice;

        public string CatalogedDeviceDigest =>
                            AccountContext.AccessCapability?.CatalogedDeviceDigest;


        #endregion
        #region // Disposal

        ///<inheritdoc/>
        protected override void Disposing() {
            //AccountContext.Close();
            System.Threading.Monitor.Exit(AccountContext.AccountEntry);
            AccountContext.Dispose();
            }

        #endregion
        #region // Constructors

        /// <summary>
        /// Return an account handle for the account context <paramref name="accountContext"/>.
        /// </summary>
        /// <param name="accountContext">The account context.</param>
        /// 
        public AccountHandleLocked(AccountContext accountContext) => 
                    AccountContext = accountContext;

        #endregion
        #region // Methods
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

            "Implement fine grain access control".TaskFunctionality(suppress: Assert.HaltPhase1);

            //AccountPrivilege.HasFlag(AccountPrivilege.Post).AssertTrue(NotAuthorized.Throw);

            using var container = new Spool(Directory, SpoolInbound.Label);
            container.Add(dareMessage);

            }

        /// <summary>
        /// Post a message to the spool associated with the account. This is the only operation
        /// that is supported for a device that is not connected to the account profile.
        /// </summary>
        /// <param name="envelope">The message to post.</param>
        public void PostLocal(DareEnvelope envelope) {
            //AccountPrivilege.HasFlag(AccountPrivilege.Local).AssertTrue(NotAuthorized.Throw);

            "Implement fine grain access control".TaskFunctionality(suppress: Assert.HaltPhase1);

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
            "Implement fine grain access control".TaskFunctionality(suppress: Assert.HaltPhase1);

            //AccountPrivilege.HasFlag(AccountPrivilege.Connected).AssertTrue(NotAuthorized.Throw);
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


        #endregion
        }
    }
