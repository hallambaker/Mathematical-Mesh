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
using System.IO;
using System.Reflection.Emit;
using System.Security.Cryptography;

using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.IO;
using Goedel.Protocol;
using Goedel.Utilities;

namespace Goedel.Mesh.Server {
    /// <summary>
    /// The Mathematical Mesh persistence store.
    /// </summary>
    public class MeshPersist : Disposable {


        #region // Properties
        ///<summary>The underlying persistence store for the account catalog.</summary>
        public PersistenceStore Container;

        ///<summary>The root directory in which the files are stored.</summary>
        public string DirectoryRoot;

        ///<summary>The service encryption key.</summary>  
        public static CryptoKey ServiceEncryptionKey => null;

        ///<summary>The service signature key.</summary> 
        public static CryptoKey ServiceSignatureKey => null;

        ///<summary>The key collection.</summary> 
        public IKeyCollection KeyCollection { get; }

        #endregion


        #region // Disposing
        ///<inheritdoc/>
        protected override void Disposing() {

            base.Disposing();
            Container.Dispose();

            }

        #endregion

        #region // Constructors

        /// <summary>
        /// Open or create the accounts persistence container.
        /// </summary>
        /// <param name="keyCollection">The key collection to be used for decrypting data.</param>
        /// <param name="directory">The directory in which all the service data is stored.</param>
        /// <param name="fileStatus">Specifies whether to create the file if it doesn't exist.</param>
        public MeshPersist(IKeyCollection keyCollection, string directory, FileStatus fileStatus) {
            KeyCollection = keyCollection;
            // Load/create the accounts catalog
            DirectoryRoot = directory;
            Directory.CreateDirectory(directory);
            var fileName = Path.Combine(directory, "Master.cat");
            Container = new PersistenceStore(fileName, "application/mmm-catalog",
                fileStatus: fileStatus,
                containerType: SequenceType.Merkle
                );
            }
        #endregion






        #region // Account maintenance AccountBind/AccountUnbind


        /// <summary>
        /// Add a new account. The account name must be unique.
        /// </summary>
        /// <param name="accountEntry">Account data to add.</param>
        /// <param name="storeEntries">Updates to be prepopulated to the account stores.</param>
        public void AccountBind(
                        AccountEntry accountEntry,
                        List<ContainerUpdate> storeEntries) {
            StoreEntry containerEntry;

            accountEntry.AccountAddress = accountEntry.AccountAddress.CannonicalAccountAddress();

            var directory = Path.Combine(DirectoryRoot, accountEntry.Directory);
            accountEntry.Directory = directory;

            // Lock the container so that we can create the new account entry without 
            // causing contention.
            lock (Container) {
                containerEntry = Container.New(accountEntry) as StoreEntry;
                }

            // Lock the container entry so that we can initialize it.
            lock (containerEntry) {
                Directory.CreateDirectory(directory);
                if (storeEntries != null) {
                    foreach (var entry in storeEntries) {
                        Store.Append(directory, null, entry.Envelopes, entry.Container);
                        }
                    }
                new Spool(directory, SpoolInbound.Label).Dispose();
                }
            }

        /// <summary>
        /// Update an account record. There must be an existing record and the request must
        /// be appropriately authenticated.
        /// </summary>
        /// <param name="jpcSession">The session connection data.</param>
        /// <param name="accountAddress">The account address.</param>
        public bool AccountUnbind(IJpcSession jpcSession, string accountAddress) {

            using var accountHandle = GetAccountHandleLocked(jpcSession, AccountPrivilege.Unbind);
            accountAddress.AssertEqual(accountHandle.AccountAddress, NYI.Throw);

            lock (Container) {
                return Container.Delete(accountHandle.AccountAddress);
                }
            }



        #endregion
        #region // Connect

        /// <summary>
        /// Process a connection request.
        /// </summary>
        /// <param name="jpcSession">The session connection data.</param>
        /// <param name="requestConnection">TThe message connection request.</param>
        /// <returns>The connection response.</returns>
        public ConnectResponse Connect(IJpcSession jpcSession,
                        RequestConnection requestConnection) {
            jpcSession.Future();

            using var accountHandle = GetAccountHandleLocked(jpcSession, AccountPrivilege.Device);
            //using var accountHandle = GetAccountUnverified(requestConnection.AccountAddress);
            var serviceNonce = CryptoCatalog.GetBits(128);

            var MeshUDF = accountHandle.ProfileAccount.ProfileSignature.CryptoKey.UDFBytes;
            var DeviceUDF = requestConnection.ProfileDevice.ProfileSignature.CryptoKey.UDFBytes;

            var witness = UDF.MakeWitnessString(MeshUDF, serviceNonce, DeviceUDF,
                requestConnection.ClientNonce);

            var messageID = UDF.Nonce();
            //Console.WriteLine($"The AcknowledgeConnection.MessageID = {messageID}");

            var acknowledgeConnection = new AcknowledgeConnection() {
                EnvelopedRequestConnection = requestConnection.EnvelopedRequestConnection,
                ServerNonce = serviceNonce,
                Witness = witness,
                MessageId = witness
                };

            //Screen.WriteLine($"The AcknowledgeConnection.MessageID = {acknowledgeConnection.MessageId}");
            //Screen.WriteLine($"The AcknowledgeConnection Response ID = {acknowledgeConnection.GetResponseId()}");

            // Sign the envelope under the service key.
            // Encrypt: We should probably encrypt here to the device key and the account key.

            // the key isn't being filled in on the envelope ???
            acknowledgeConnection.Envelope(ServiceSignatureKey);
            accountHandle.PostInbound(acknowledgeConnection.DareEnvelope);

            var connectResponse = new ConnectResponse() {
                EnvelopedAcknowledgeConnection = acknowledgeConnection.GetEnvelopedAcknowledgeConnection(),
                EnvelopedProfileAccount = accountHandle.ProfileAccount.GetEnvelopedProfileAccount()
                };

            return connectResponse;
            }

        /// <summary>
        /// Complete an account connection request.
        /// </summary>
        /// <param name="jpcSession">The session connection data.</param>
        /// <param name="completeRequest">The completion request.</param>
        public CompleteResponse AccountComplete(IJpcSession jpcSession,
                    CompleteRequest completeRequest) {

            //using var accountHandle = GetAccountUnverified(completeRequest.AccountAddress);
            using var accountHandle = GetAccountHandleLocked(jpcSession, AccountPrivilege.Device);


            // pull the request off SpoolLocal
            var envelope = accountHandle.GetLocal(completeRequest.ResponseID);

            if (envelope == null) {
                return new CompleteResponse() {
                    StatusCode = 400,
                    StatusDescriptionCode = "MeshResponseNotFound",
                    StatusExtended = 2
                    };
                }

            return new CompleteResponse() {
                EnvelopedRespondConnection = new Enveloped<RespondConnection>(envelope)
                };
            }
        #endregion
        #region // Store maintenance methods
        /// <summary>
        /// Update an account record. There must be an existing record and the request must
        /// be appropriately authenticated.
        /// </summary>
        /// <param name="jpcSession">The session connection data.</param>
        public StatusResponse AccountStatus(
                        IJpcSession jpcSession, 
                        string catalogedDeviceDigest) {

            using var accountHandle = GetAccountHandleLocked(jpcSession, AccountPrivilege.Connected);


            //var access = catalogCapability.Locate (


            //using var accountHandle = GetAccountVerified(account, jpcSession);

            var containerStatus = accountHandle.GetContainerStatuses();




            var statusResponse = new StatusResponse() {
                ContainerStatus = containerStatus,
                //EnvelopedProfileAccount = accountHandle.EnvelopedProfileAccount,
                EnvelopedCatalogedDevice = null
                };

            if (accountHandle.EnvelopedCatalogedDevice != null) {
                statusResponse.EnvelopedCatalogedDevice =
                    accountHandle.EnvelopedCatalogedDevice; // Hack: should allow this to be cached.
                statusResponse.CatalogedDeviceDigest = accountHandle.CatalogedDeviceDigest;

                Screen.WriteLine($"Status update:  {accountHandle.CatalogedDeviceDigest}");



                //if ((deviceConnection == null) || (deviceConnection.IsEqualTo(
                //        accountHandle.EnvelopedCatalogedDevice.PayloadDigest))) {
                //    statusResponse.EnvelopedCatalogedDevice =
                //                accountHandle.EnvelopedCatalogedDevice;
                //    }
                }



            // summarize the status here.
            statusResponse.ToConsole();

            return statusResponse;
            }


        /// <summary>
        /// Update an account record. There must be an existing record and the request must
        /// be appropriately authenticated.
        /// </summary>
        /// <param name="session">The session connection data.</param>
        /// <param name="selections">The selection criteria.</param>
        public List<ContainerUpdate> AccountDownload(
                    IJpcSession session,

                    List<ConstraintsSelect> selections) {
            
            using var accountHandle = GetAccountHandleLocked(session, AccountPrivilege.Connected);

            //using var accountEntry = GetAccountVerified(account, jpcSession);
            var updates = new List<ContainerUpdate>();
            foreach (var selection in selections) {
                using var store = accountHandle.GetStore(selection.Container);
                var update = new ContainerUpdate() {
                    Container = selection.Container,
                    Envelopes = new List<DareEnvelope>()
                    };

                foreach (var message in store.Select(selection.IndexMin)) {
                    update.Envelopes.Add(message);
                    }

                updates.Add(update);
                }
            return updates;
            }


        /// <summary>
        /// Update an account record. There must be an existing record and the request must
        /// be appropriately authenticated.
        /// </summary>
        /// <param name="jpcSession">The session connection data.</param>
        /// <param name="updates">Entries to be added to catalogs.</param>
        /// <param name="inbound">Entries to be added to the user's inbound store.</param>
        /// <param name="outbound">Entries to be added to the user's outbound store.</param>
        /// <param name="local">Entries to be added to the user's local store.</param>
        /// <param name="accounts">Accounts to which outbound messages are to be sent.</param>
        public void AccountTransact(
                    IJpcSession jpcSession,
                    List<ContainerUpdate> updates,
                    List<Enveloped<Message>> inbound,
                    List<Enveloped<Message>> outbound,
                    List<Enveloped<Message>> local,
                    List<string> accounts) {
            // ToDo: This should be subject to a full multi stage commit process.

            /*
            1) Check all the envelopes meet the catalog/spool security policy and size constraint. 

            2) lock all the required catalogs (probably lock the account)

            3) Check that all the updates are consistent with the state of the catalog

            4) Perform all the updates

            5) Append all the messages to the relevant spools

            6) Release all the locks.

            */

                // report the updates to be applied here
            using var accountHandle = GetAccountHandleLocked(jpcSession, AccountPrivilege.Connected);

            //using var accountEntry = GetAccountVerified(account, jpcSession);
            //accountEntry.AssertNotNull(MeshUnknownAccount.Throw);


            if (updates != null) {
                foreach (var update in updates) {
                    //Screen.WriteLine(update.ToString());
                    accountHandle.StoreAppend(update.Container, update.Envelopes);
                    }
                }
            if (inbound != null) {
                foreach (var envelope in inbound) {
                    accountHandle.PostInbound(envelope);
                    }
                }
            if (local != null) {
                foreach (var envelope in local) {
                    accountHandle.PostLocal(envelope);
                    }
                }

            // we always do these last
            if (outbound != null) {
                foreach (var envelope in outbound) {
                    MessagePostOther(jpcSession, accountHandle, accounts, envelope);
                    }
                }

            // report the final status of the containers here.


            }

        #endregion
        #region // Post

        ///// <summary>
        ///// Post message to the local pickup spool.
        ///// </summary>
        ///// <param name="jpcSession">The session connection data.</param>
        ///// <param name="account">The verified sending account.</param>
        ///// <param name="dareMessage">The message.</param>
        ///// <returns>Identifier of the message posted.</returns>
        //public string MessagePostSelf(JpcSession jpcSession, MeshVerifiedAccount account, DareEnvelope dareMessage) {

        //    var identifier = dareMessage.Header?.ContentMeta?.UniqueId;
        //    identifier.AssertNotNull(InvalidMessageID.Throw);
        //    using var accountHandle = GetAccountHandleLocked(jpcSession, AccountPrivilege.Connected);
        //    //using var accountEntry = GetAccountVerified(account, jpcSession);
        //    dareMessage.Header.ContentMeta = dareMessage.Header.ContentMeta ?? new ContentMeta();
        //    accountHandle.PostLocal(dareMessage);

        //    return identifier;
        //    }

        /// <summary>
        /// Post message to a remote user.
        /// </summary>
        /// <param name="jpcSession">The session connection data.</param>
        /// <param name="senderAccount">The verified sending account.</param>
        /// <param name="accounts">The account to which the message is directed.</param>
        /// <param name="dareMessage">The message.</param>
        /// <returns>Identifier of the message posted.</returns>
        public string MessagePostOther(
            IJpcSession jpcSession,
                AccountHandleLocked senderAccount,
                List<string> accounts,
                DareEnvelope dareMessage) {

            var identifier = dareMessage.Header?.ContentMeta?.UniqueId;
            identifier.AssertNotNull(InvalidMessageID.Throw);

            var senderService = senderAccount.AccountAddress.GetService();

            foreach (var recipient in accounts) {
                var recipientService = recipient.GetService();
                if (recipientService == senderService) {
                    // Is the message for delivery to a local user?
                    MessagePostLocal(jpcSession, recipient, dareMessage);
                    }
                else {
                    // Post to the outbound spool
                    MessagePostRemote(recipient, dareMessage);
                    }
                }
            return identifier;
            }

        bool MessagePostLocal(
            IJpcSession jpcSession,
            string recipient, DareEnvelope dareMessage) {

            using var recipientAccount = GetAccountHandleLocked(recipient, jpcSession, AccountPrivilege.Local);
            recipientAccount.PostInbound(dareMessage);

            return true;
            }

        static bool MessagePostRemote(string recipient, DareEnvelope dareMessage) {
            recipient.Future();
            dareMessage.Future();


            throw new NYI();
            }

        #endregion
        #region // Operate

        /// <summary>
        /// Respond to a set of cryptographic operations.
        /// </summary>
        /// <param name="jpcSession">The Mesh client session.</param>
        /// <param name="accountAddress">The account to which the capabilities are attached.</param>
        /// <param name="operations">The operations requested.</param>
        /// <returns>Result of the decryption request.</returns>
        public OperateResponse Operate(
                    IJpcSession jpcSession,
                    string accountAddress,
                    List<CryptographicOperation> operations) {

            // Fetch the account 
            //using var accountEntry = GetAccountUnverified(accountAddress);

            

            using var accountHandle = GetAccountHandleLocked(accountAddress, 
                                jpcSession, AccountPrivilege.Operate);
            using var catalogCapability = accountHandle.GetCatalogCapability();

            var results = new List<CryptographicResult>();

            // Phase2: validate right to access...

            // Different stores depending on user or group account
            foreach (var operation in operations) {
                results.Add(Operate(catalogCapability, operation, 
                            jpcSession.Credential.Account));
                }

            var response = new OperateResponse() {
                Results = results
                };


            return response;
            }


        CryptographicResult Operate(
                 CatalogAccess catalogCapability,
                 CryptographicOperation cryptographicOperation,
                 string accountAddress) {

            switch (cryptographicOperation) {
                case CryptographicOperationKeyAgreement operationKeyAgreement: {
                    return Operate(catalogCapability, operationKeyAgreement, accountAddress);
                    }
                }


            throw new NYI();
            }

        CryptographicResult Operate(
                CatalogAccess catalogCapability,
                CryptographicOperationKeyAgreement cryptographicOperation, string accountAddress) {

            var keyId = cryptographicOperation.KeyId ?? accountAddress.CannonicalAccountAddress();
            // Phase2: validate the access to this key id

            catalogCapability.DictionaryDecryptByKeyId.TryGetValue(
                keyId, out var capability).AssertTrue(MeshOperationFailed.Throw);


            var publicEphemeral = cryptographicOperation.PublicKey.GetKeyPair(KeySecurity.Exportable);


            capability.Active.AssertTrue(NotAuthorized.Throw);
            var share = capability.DecryptShare(KeyCollection);

            var keyAgreement = share.Agreement(publicEphemeral);

            var cryptographicResultKeyAgreement = new CryptographicResultKeyAgreement() {
                KeyAgreement = KeyAgreement.Factory(keyAgreement)
                };


            return cryptographicResultKeyAgreement;


            }


        #endregion
        #region // External

        /// <summary>
        /// Verify a claim to a publication and return the value if accepted.
        /// </summary>
        /// <param name="jpcSession">The Mesh session.</param>
        /// <param name="dareEnvelope">Envelope containing the MessageClaim</param>
        /// <returns>The claim response.</returns>
        public ClaimResponse Claim(
                    IJpcSession jpcSession,
                    DareEnvelope dareEnvelope
                    ) {

            var messageClaim = MeshItem.Decode(dareEnvelope) as MessageClaim;
            var targetAccount = messageClaim.Recipient;

            using var accountHandle = GetAccountHandleLocked(targetAccount, jpcSession, AccountPrivilege.Post);
            //using var accountEntry = GetAccountUnverified(messageClaim.Recipient);
            using var store = accountHandle.GetCatalogPublication();


            // Fetch the record by request.ID
            var id = messageClaim.PublicationId;
            var publicationEntry = store.GetEntry(id);

            if (publicationEntry?.JsonObject is not CatalogedPublication publication) {
                throw new NYI();
                }

            // verify the claim.
            if (!publication.VerifyService(messageClaim.Sender,
                        messageClaim.ServiceAuthenticate)) {
                throw new NYI();
                }

            // Post the claim to the local spool. The unique identifier is the
            // publication identifier.
            dareEnvelope.Header.EnvelopeId = Message.GetEnvelopeId(id);
            accountHandle.PostLocal(dareEnvelope);

            // Hack: Allow for the possibility of multiple claims on the same item.
            // Test: Multiple claims on the same item functions correctly.

            var response = new ClaimResponse() {
                CatalogedPublication = publication
                };

            return response;

            }

        #endregion
        #region // Obsolete Methods

        /// <summary>
        /// Poll service to see if a claim has been made for a given publication and
        /// if so return the latest claim made.
        /// </summary>
        /// <param name="jpcSession">The Mesh session.</param>
        /// <param name="targetAccount"></param>
        /// <param name="id"></param>
        /// <returns>The result of the transaction.</returns>
        public PollClaimResponse PollClaim(
                    IJpcSession jpcSession,
                    string targetAccount,
                    string id) {
            using var accountEntry = GetAccountHandleLocked(jpcSession, AccountPrivilege.Post);
            var message = accountEntry.GetLocal(id);

            // return the message if found (otherwise null)
            var response = message == null ? null : new PollClaimResponse() {
                EnvelopedMessage = new Enveloped<Message>(message)
                };
            return response;
            }

        ///// <summary>
        ///// Get access to an account record for an authenticated request.
        ///// </summary>
        ///// <param name="jpcSession">The session connection data.</param>      
        ///// <param name="verifiedAccount">The account for which the data is requested.</param>
        ///// <returns></returns>
        //AccountHandleVerified GetAccountVerified(MeshVerifiedAccount verifiedAccount, IJpcSession jpcSession) {
        //    var accountEntry = GetAccountLocked(jpcSession.TargetAccount);

        //    accountEntry.AssertNotNull(MeshUnknownAccount.Throw);
        //    accountEntry.Verify(jpcSession);
        //    return new AccountHandleVerified(jpcSession);
        //    }

        ///// <summary>
        ///// Get access to an account record for an authenticated request.
        ///// </summary>
        ///// <param name="account">The account to access.</param>
        ///// <returns>The access handle.</returns>
        //AccountHandleUnverified GetAccountUnverified(string account) =>
        //    new(GetAccountLocked(account));

        #endregion
        #region // Account handle management
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
                    var containerEntry = Container.Get(account.CannonicalAccountAddress()) as StoreEntry;
                    result = containerEntry?.JsonObject as AccountEntry;
                    result.AssertNotNull(MeshUnknownAccount.Throw);

                    //Screen.WriteLine($"LOCK {result.AccountAddress}");


                    System.Threading.Monitor.Enter(result, ref locked);
                    return result;
                    }
                }
            catch {
                if (locked) {
                    //Screen.WriteLine($"UNLOCK {result.AccountAddress}");
                    System.Threading.Monitor.Exit(result);

                    }
                return null;
                }
            }

        AccountHandleLocked GetAccountHandleLocked(string Account,
                    IJpcSession session,
                    AccountPrivilege accountPrivilege) {

            session.Future();
            accountPrivilege.Future();
            // Bug/Phase2: Need to have a means of revoking devices performing foreign operations.

            var accountEntry = GetAccountLocked(Account);
            var accountContext = new AccountContext() {
                AccountEntry = accountEntry
                };

            return new AccountHandleLocked(accountContext) {
                AccountPrivilege = AccountPrivilege.Post
                };
            }


        AccountHandleLocked GetAccountHandleLocked(IJpcSession session,
                AccountPrivilege accountPrivilege) {

            var accountEntry = GetAccountLocked(session.TargetAccount);

            // Performance: Cache the account context to permit reuse.
            var accountContext = new AccountContext() {
                AccountEntry = accountEntry
                };
            accountContext.Authenticate(
                session, accountPrivilege).AssertTrue(NotAuthenticated.Throw);

            return new AccountHandleLocked(accountContext) { 
                AccountPrivilege = accountPrivilege};
            }



        #endregion 

        }



    }
