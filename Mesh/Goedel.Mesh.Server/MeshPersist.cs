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

using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.IO;
using Goedel.Protocol;
using Goedel.Protocol.Presentation;
using Goedel.Utilities;

using System.Collections.Generic;
using System.IO;
using System;

namespace Goedel.Mesh.Server {
    public partial class CatalogItem {

        /////<summary>Initialization property. Access this property to force initialization 
        /////of the static method.</summary>
        //public static object Initialize => null;

        //static CatalogItem() => AddDictionary(ref _TagDictionary);
        }

    /// <summary>
    /// The Mathematical Mesh persistence store.
    /// </summary>
    public class MeshPersist {



        ///<summary>The underlying persistence store for the account catalog.</summary>
        public PersistenceStore Container;

        ///<summary>The root directory in which the files are stored.</summary>
        public string DirectoryRoot;

        ///<summary>The service encryption key.</summary>  
        public static CryptoKey ServiceEncryptionKey => null;

        ///<summary>The service signature key.</summary> 
        public static CryptoKey ServiceSignatureKey => null;

        //static MeshPersist() {
        //    _ = MeshItem.Initialize;
        //    _ = CatalogItem.Initialize;
        //    _ = MeshProtocol.Initialize;
        //    }

        /// <summary>
        /// Open or create the accounts persistence container.
        /// </summary>
        /// <param name="directory">The directory in which all the service data is stored.</param>
        public MeshPersist(string directory) {

            // Load/create the accounts catalog
            DirectoryRoot = directory;
            Directory.CreateDirectory(directory);
            var fileName = Path.Combine(directory, "Master.cat");
            Container = new PersistenceStore(fileName, "application/mmm-catalog",
                fileStatus: FileStatus.OpenOrCreate,
                containerType: SequenceType.Merkle
                );
            }

        /// <summary>
        /// Add a new account. The account name must be unique.
        /// </summary>
        /// <param name="account">The verified account data.</param>
        /// <param name="accountEntry">Account data to add.</param>
        /// <param name="jpcSession">The session connection data.</param>
        public void AccountAdd(IJpcSession jpcSession,
            MeshVerifiedAccount account,
                        AccountEntry accountEntry) {

            jpcSession.Future();
            StoreEntry containerEntry;

            var directory = Path.Combine(DirectoryRoot, accountEntry.Directory);
            accountEntry.Directory = directory;

            // Lock the container so that we can create the new account entry without 
            // causing contention.
            lock (Container) {
                containerEntry = Container.New(accountEntry) as StoreEntry;
                }

            lock (containerEntry) {
                Directory.CreateDirectory(directory);
                // Create the pro-forma containers.
                new Spool(directory, SpoolInbound.Label).Dispose();

                }
            }

        /// <summary>
        /// Process a connection request.
        /// </summary>
        /// <param name="jpcSession">The session connection data.</param>
        /// <param name="requestConnection">TThe message connection request.</param>
        /// <param name="account">The verified account data.</param>
        /// <returns>The connection response.</returns>
        public ConnectResponse Connect(IJpcSession jpcSession,
            MeshVerifiedAccount account,
                        RequestConnection requestConnection) {
            jpcSession.Future();

            using var accountHandle = GetAccountUnverified(requestConnection.AccountAddress);
            var serviceNonce = CryptoCatalog.GetBits(128);

            var MeshUDF = accountHandle.ProfileUser.ProfileSignature.CryptoKey.UDFBytes;
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

            Screen.WriteLine($"The AcknowledgeConnection.MessageID = {acknowledgeConnection.MessageId}");
            Screen.WriteLine($"The AcknowledgeConnection Response ID = {acknowledgeConnection.GetResponseId()}");

            // Sign the envelope under the service key.
            // Encrypt: We should probably encrypt here to the device key and the account key.

            // the key isn't being filled in on the envelope ???
            acknowledgeConnection.Envelope(ServiceSignatureKey); 
            accountHandle.PostInbound(acknowledgeConnection.DareEnvelope);

            var connectResponse = new ConnectResponse() {
                EnvelopedAcknowledgeConnection = acknowledgeConnection.EnvelopedAcknowledgeConnection,
                EnvelopedProfileAccount = accountHandle.ProfileUser.EnvelopedProfileAccount
                };

            return connectResponse;
            }

        /// <summary>
        /// Complete an account connection request.
        /// </summary>
        /// <param name="jpcSession">The session connection data.</param>
        /// <param name="account">The account for which the status is requested..</param>
        /// <param name="completeRequest">The completion request.</param>
        public CompleteResponse AccountComplete(IJpcSession jpcSession,
                    MeshVerifiedAccount account,
                    CompleteRequest completeRequest) {

            using var accountHandle = GetAccountVerified(account, jpcSession);

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


        /// <summary>
        /// Update an account record. There must be an existing record and the request must
        /// be appropriately authenticated.
        /// </summary>
        /// <param name="jpcSession">The session connection data.</param>
        /// <param name="account">The account for which the status is requested..</param>
        public StatusResponse AccountStatus(IJpcSession jpcSession, MeshVerifiedAccount account) {


            using var accountHandle = GetAccountVerified(account, jpcSession);



            var containerStatus = accountHandle.GetContainerStatuses();

            var statusResponse = new StatusResponse() {
                ContainerStatus = containerStatus,
                EnvelopedProfileAccount = accountHandle.EnvelopedProfileAccount,
                EnvelopedCatalogedDevice = null
                };

            // summarize the status here.

            statusResponse.ToConsole();

            return statusResponse;

            }


        /// <summary>
        /// Update an account record. There must be an existing record and the request must
        /// be appropriately authenticated.
        /// </summary>
        /// <param name="jpcSession">The session connection data.</param>
        /// <param name="account">The account for which the status is requested..</param>
        /// <param name="selections">The selection criteria.</param>
        public List<ContainerUpdate> AccountDownload(
                    IJpcSession jpcSession,
                    MeshVerifiedAccount account,
                    List<ConstraintsSelect> selections) {

            using var accountEntry = GetAccountVerified(account, jpcSession);
            var updates = new List<ContainerUpdate>();
            foreach (var selection in selections) {
                using var store = accountEntry.GetStore(selection.Container);
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
        /// <param name="account">The account for which the status is requested.</param>
        /// <param name="updates">Entries to be added to catalogs.</param>
        /// <param name="inbound">Entries to be added to the user's inbound store.</param>
        /// <param name="outbound">Entries to be added to the user's outbound store.</param>
        /// <param name="local">Entries to be added to the user's local store.</param>
        /// <param name="accounts">Accounts to which outbound messages are to be sent.</param>
        public void AccountUpdate(
                    IJpcSession jpcSession,
                    MeshVerifiedAccount account,
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


            using var accountEntry = GetAccountVerified(account, jpcSession);
            accountEntry.AssertNotNull(MeshUnknownAccount.Throw);


            if (updates != null) {
                foreach (var update in updates) {
                    //update.ToConsole();
                    accountEntry.StoreAppend(update.Container, update.Envelopes);
                    }
                }
            if (inbound != null) {
                foreach (var envelope in inbound) {
                    accountEntry.PostInbound(envelope);
                    }
                }
            if (local != null) {
                foreach (var envelope in local) {
                    accountEntry.PostLocal(envelope);
                    }
                }

            // we always do these last
            if (outbound != null) {
                foreach (var envelope in outbound) {
                    MessagePostOther(jpcSession, account, accounts, envelope);
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
        public bool AccountDelete(IJpcSession jpcSession, MeshVerifiedAccount account,
                string accountAddress) {
            jpcSession.Future();


            lock (Container) {
                return Container.Delete(accountAddress);
                }
            }


        /// <summary>
        /// Verify a claim to a publication and return the value if accepted.
        /// </summary>
        /// <param name="jpcSession">The Mesh session.</param>
        /// <param name="dareEnvelope">Envelope containing the MessageClaim</param>
        /// <returns>The claim response.</returns>
        public ClaimResponse Claim(
                    IJpcSession jpcSession,
                    DareEnvelope dareEnvelope) {

            var messageClaim = MeshItem.Decode(dareEnvelope) as MessageClaim;
            using var accountEntry = GetAccountUnverified(messageClaim.Recipient);
            using var store = accountEntry.GetCatalogPublication();


            // Fetch the record by request.ID
            var id = messageClaim.PublicationId;
            var publicationEntry = store.GetEntry(id);

            if (publicationEntry.JsonObject is not CatalogedPublication publication) {
                return null;
                }

            // verify the claim.
            if (!publication.VerifyService(messageClaim.Sender,
                        messageClaim.ServiceAuthenticate)) {
                return null;
                }

            // Post the claim to the local spool. The unique identifier is the
            // publication identifier.
            dareEnvelope.Header.EnvelopeId = Message.GetEnvelopeId(id);
            accountEntry.PostLocal(dareEnvelope);

            // Hack: Allow for the possibility of multiple claims on the same item.
            // Test: Multiple claims on the same item functions correctly.

            var response = new ClaimResponse() {
                CatalogedPublication = publication
                };

            return response;

            }

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
            using var accountEntry = GetAccountUnverified(targetAccount);
            var message = accountEntry.GetLocal(id);

            // return the message if found (otherwise null)
            var response = message == null ? null : new PollClaimResponse() {
                EnvelopedMessage = new Enveloped<Message>(message)
                };
            return response;
            }


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
            using var accountEntry = GetAccountUnverified(accountAddress);

            using var catalogCapability = accountEntry.GetCatalogCapability();

            var results = new List<CryptographicResult>();
            // Different stores depending on user or group account
            foreach (var operation in operations) {
                results.Add(Operate(catalogCapability, operation));
                }

            var response = new OperateResponse() {
                Results = results
                };


            return response;
            }


        CryptographicResult Operate(
                        CatalogAccess catalogCapability,
                        CryptographicOperation cryptographicOperation) {

            switch (cryptographicOperation) {
                case CryptographicOperationKeyAgreement operationKeyAgreement: {
                    return Operate(catalogCapability, operationKeyAgreement);
                    }
                }


            throw new NYI();
            }

        static CryptographicResult Operate(
                CatalogAccess catalogCapability,
                CryptographicOperationKeyAgreement cryptographicOperation) {

            catalogCapability.TryFindKeyDecryption(
                cryptographicOperation.KeyId, out var capability).AssertTrue(MeshOperationFailed.Throw);
            var keypair = cryptographicOperation.PublicKey.GetKeyPair(KeySecurity.Exportable);

            var keyAgreement = capability.Agreement(keypair);

            var cryptographicResultKeyAgreement = new CryptographicResultKeyAgreement() {
                KeyAgreement = KeyAgreement.Factory(keyAgreement)
                };


            return cryptographicResultKeyAgreement;


            }


        /// <summary>
        /// Process an inbound message to an account.
        /// </summary>
        /// <param name="jpcSession">The session connection data.</param>
        /// <param name="account">The verified sending account.</param>
        /// <param name="accounts">The account to which the message is directed.</param>
        /// <param name="dareMessage">The message.</param>
        /// <returns>Identifier of the message posted.</returns>
        public string MessagePost(
                    JpcSession jpcSession,
                    MeshVerifiedAccount account, List<string> accounts, DareEnvelope dareMessage) =>
            accounts == null ? MessagePostSelf(jpcSession, account, dareMessage) :
                 MessagePostOther(jpcSession, account, accounts, dareMessage);

        /// <summary>
        /// Post message to the local pickup spool.
        /// </summary>
        /// <param name="jpcSession">The session connection data.</param>
        /// <param name="account">The verified sending account.</param>
        /// <param name="dareMessage">The message.</param>
        /// <returns>Identifier of the message posted.</returns>
        public string MessagePostSelf(JpcSession jpcSession, MeshVerifiedAccount account, DareEnvelope dareMessage) {

            var identifier = dareMessage.Header?.ContentMeta?.UniqueId;

            identifier.AssertNotNull(InvalidMessageID.Throw);

            using var accountEntry = GetAccountVerified(account, jpcSession);
            dareMessage.Header.ContentMeta = dareMessage.Header.ContentMeta ?? new ContentMeta();

            accountEntry.PostLocal(dareMessage);

            return identifier;
            }

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
                MeshVerifiedAccount senderAccount,
                List<string> accounts,
                DareEnvelope dareMessage) {

            jpcSession.Future();

            var identifier = dareMessage.Header?.ContentMeta?.UniqueId;
            identifier.AssertNotNull(InvalidMessageID.Throw);

            var senderService = senderAccount.MeshCredential.Provider;

            foreach (var recipient in accounts) {
                var recipientService = recipient.GetService();
                if (recipientService == senderService) {
                    // Is the message for delivery to a local user?
                    MessagePostLocal(recipient, dareMessage);
                    }
                else {
                    // Post to the outbound spool
                    MessagePostRemote(recipient, dareMessage);
                    }
                }
            return identifier;
            }

        bool MessagePostLocal(string recipient, DareEnvelope dareMessage) {

            var recipientAccount = GetAccountUnverified(recipient);
            recipientAccount.PostInbound(dareMessage);

            return true;
            }

        static bool MessagePostRemote(string recipient, DareEnvelope dareMessage) {
            recipient.Future();
            dareMessage.Future();


            throw new NYI();
            }



        /// <summary>
        /// Get access to an account record for an authenticated request.
        /// </summary>
        /// <param name="jpcSession">The session connection data.</param>      
        /// <param name="verifiedAccount">The account for which the data is requested.</param>
        /// <returns></returns>
        AccountHandleVerified GetAccountVerified(MeshVerifiedAccount verifiedAccount, IJpcSession jpcSession) {
            var accountEntry = GetAccountLocked(verifiedAccount.AccountAddress);
            
            accountEntry.AssertNotNull(MeshUnknownAccount.Throw);

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

            switch (jpcSession) {
                case JpcSessionDirect:
                case JpcSessionSerialized:
                case RudStreamService: {
                    return new AccountHandleVerified(accountEntry);
                    }
                }



            throw new NotAuthenticated();
            }

        /// <summary>
        /// Get access to an account record for an authenticated request.
        /// </summary>
        /// <param name="account">The account to access.</param>
        /// <returns>The access handle.</returns>
        AccountHandleUnverified GetAccountUnverified(string account) =>
            new(GetAccountLocked(account));


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
                    var containerEntry = Container.Get(account) as StoreEntry;
                    result = containerEntry?.JsonObject as AccountEntry;
                    result.AssertNotNull(MeshUnknownAccount.Throw);

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



    public abstract partial class AccountEntry {

        ///<summary>The primary key</summary>
        public override string _PrimaryKey => AccountAddress;



        /// <summary>
        /// Default constructor for serialization.
        /// </summary>
        public AccountEntry() {
            }

        /// <summary>
        /// Verification function.
        /// </summary>
        /// <returns>True if the account entry is properly formatted.</returns>
        public static bool Verify() => true; // NYI: Verification of signed profile.

        }

    public partial class AccountUser {


        ///<summary>Cached convenience accessor for <see cref="ProfileUser"/></summary>
        public ProfileUser ProfileUser => EnvelopedProfileUser.Decode() as ProfileUser;


        /// <summary>
        /// Default constructor for serialization.
        /// </summary>
        public AccountUser() {
            }

        /// <summary>
        /// Constructor creating an Account entry from the request <paramref name="request"/>.
        /// </summary>
        /// <param name="request">The account creation request.</param>
        public AccountUser(BindRequest request) {
            AccountAddress = request.AccountAddress;
            EnvelopedProfileUser = request.EnvelopedProfileAccount;
            Verify();
            Directory = AccountAddress;
            }
        }

    public partial class AccountGroup {

        /// <summary>
        /// Default constructor for serialization.
        /// </summary>
        public AccountGroup() {
            }
        /// <summary>
        /// Constructor creating an Account entry from the request <paramref name="request"/>.
        /// </summary>
        /// <param name="request">The account creation request.</param>
        public AccountGroup(BindRequest request) {
            AccountAddress = request.AccountAddress;
            EnvelopedProfileGroup = request.EnvelopedProfileAccount;
            Verify();
            Directory = AccountAddress;
            }
        }
    }
