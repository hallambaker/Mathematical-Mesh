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
using Goedel.IO;
using Goedel.Protocol;
using Goedel.Utilities;

using System.Collections.Generic;
using System.IO;
using System;

namespace Goedel.Mesh.Server {
    public partial class CatalogItem {

        ///<summary>Initialization property. Access this property to force initialization 
        ///of the static method.</summary>
        public static object Initialize => null;

        static CatalogItem() => AddDictionary(ref _TagDictionary);
        }

    /// <summary>
    /// The Mathematical Mesh persistence store.
    /// </summary>
    public class MeshPersist {

        ///<summary>The mesh service provider.</summary>
        protected PublicMeshServiceProvider Provider;

        ///<summary>The underlying persistence store for the account catalog.</summary>
        public PersistenceStore Container;

        ///<summary>The root directory in which the files are stored.</summary>
        public string DirectoryRoot;

        static MeshPersist() {
            _ = MeshItem.Initialize;
            _ = CatalogItem.Initialize;
            _ = MeshProtocol.Initialize;
            }

        /// <summary>
        /// Open or create the accounts persistence container.
        /// </summary>
        /// <param name="directory">The directory in which all the service data is stored.</param>
        /// <param name="provider">The Mesh service provider.</param>
        public MeshPersist(PublicMeshServiceProvider provider, string directory) {

            Provider = provider;

            // Load/create the accounts catalog
            DirectoryRoot = directory;
            Directory.CreateDirectory(directory);
            var fileName = Path.Combine(directory, "Master.cat");
            Container = new PersistenceStore(fileName, "application/mmm-catalog",
                fileStatus: FileStatus.OpenOrCreate,
                containerType: ContainerType.MerkleTree
                );
            }

        /// <summary>
        /// Add a new account. The account name must be unique.
        /// </summary>
        public void AccountAdd(JpcSession jpcSession,
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
        /// <param name="messageConnectionRequestClient">TThe message connection request.</param>
        /// <returns>The connection response.</returns>
        public ConnectResponse Connect(JpcSession jpcSession,
                        RequestConnection messageConnectionRequestClient) {
            jpcSession.Future();

            using var accountHandle = GetAccountUnverified(messageConnectionRequestClient.AccountAddress);
            var serviceNonce = CryptoCatalog.GetBits(128);

            var MeshUDF = accountHandle.ProfileMesh.KeyOfflineSignature.KeyPair.UDFBytes;
            var DeviceUDF = messageConnectionRequestClient.ProfileDevice.KeyOfflineSignature.KeyPair.UDFBytes;

            var witness = UDF.MakeWitnessString(MeshUDF, serviceNonce, DeviceUDF,
                messageConnectionRequestClient.ClientNonce);

            //var messageID = UDF.Nonce();
            //Console.WriteLine($"The AcknowledgeConnection.MessageID = {messageID}");

            var messageConnectionRequest = new AcknowledgeConnection() {
                EnvelopedRequestConnection = messageConnectionRequestClient.DareEnvelope,
                ServerNonce = serviceNonce,
                Witness = witness,
                MessageID = witness
                };

            //Console.WriteLine($"The AcknowledgeConnection.MessageID = {messageConnectionRequest.MessageID}");
            //Console.WriteLine($"The AcknowledgeConnection Response ID = {messageConnectionRequest.GetResponseID()}");


            // Bug: should authenticate the envelope under the service key and also encrypt it under the device key.

            var envelope = messageConnectionRequest.Encode();
            accountHandle.Post(envelope);


            var connectResponse = new ConnectResponse() {
                EnvelopedConnectionResponse = envelope,
                EnvelopedProfileMaster = accountHandle.ProfileMesh.DareEnvelope,
                EnvelopedAccountAssertion = accountHandle.AssertionAccount.DareEnvelope
                };

            return connectResponse;
            }

        /// <summary>
        /// Complete an account connection request.
        /// </summary>
        /// <param name="jpcSession">The session connection data.</param>
        /// <param name="account">The account for which the status is requested..</param>
        /// <param name="completeRequest">The completion request.</param>
        public CompleteResponse AccountComplete(JpcSession jpcSession,
                    VerifiedAccount account,
                    CompleteRequest completeRequest) {

            using var accountHandle = GetAccountVerified(account, jpcSession);

            // pull the request off SpoolLocal
            var message = accountHandle.GetLocal(completeRequest.ResponseID);

            var response = new CompleteResponse() {
                SignedResponse = message

                };
            return response;

            }


        /// <summary>
        /// Update an account record. There must be an existing record and the request must
        /// be appropriately authenticated.
        /// </summary>
        /// <param name="jpcSession">The session connection data.</param>
        /// <param name="account">The account for which the status is requested..</param>
        public StatusResponse AccountStatus(JpcSession jpcSession, VerifiedAccount account) {


            using var accountHandle = GetAccountVerified(account, jpcSession);



            var containerStatus = new List<ContainerStatus> {
                    accountHandle.GetStatusSpool (SpoolInbound.Label),
                    accountHandle.GetStatusSpool (SpoolOutbound.Label),
                    accountHandle.GetStatusSpool (SpoolLocal.Label),
                    accountHandle.GetStatusCatalog (CatalogCredential.Label),
                    accountHandle.GetStatusCatalog (CatalogDevice.Label),
                    accountHandle.GetStatusCatalog (CatalogContact.Label),
                    accountHandle.GetStatusCatalog (CatalogApplication.Label),
                    accountHandle.GetStatusCatalog (CatalogBookmark.Label),
                    accountHandle.GetStatusCatalog (CatalogCalendar.Label)
                    };

            var statusResponse = new StatusResponse() {
                ContainerStatus = containerStatus,
                EnvelopedProfileMaster = accountHandle.ProfileMesh.DareEnvelope,
                EnvelopedCatalogEntryDevice = null
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
                    JpcSession jpcSession,
                    VerifiedAccount account,
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
        /// <param name="selfs">Entries to be added to the user's inbound store.</param>
        public void AccountUpdate(
                    JpcSession jpcSession,
                    VerifiedAccount account,
                    List<ContainerUpdate> updates,
                    List<DareEnvelope> selfs) {
            //AccountHandleVerified accountEntry = null;

            // report the updates to be applied here


            using var accountEntry = GetAccountVerified(account, jpcSession);
            Assert.NotNull(accountEntry);
            if (selfs != null) {
                foreach (var self in selfs) {
                    accountEntry.Post(self);
                    }
                }

            if (updates != null) {
                foreach (var update in updates) {
                    update.ToConsole();
                    accountEntry.StoreAppend(update.Container, update.Envelopes);
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
        public bool AccountDelete(JpcSession jpcSession, VerifiedAccount account) {
            jpcSession.Future();


            lock (Container) {
                return Container.Delete(account.AccountAddress);
                }
            }

        /// <summary>
        /// Service a publication request. Note that at present the mechanism does not
        /// support handling of external publication data.
        /// </summary>
        /// <param name="jpcSession">The session connection data.</param>
        /// <param name="account">The account to publish to.</param> 
        /// <param name="publications">The publications to be published.</param>
        public void Publish(
                    JpcSession jpcSession,
                    VerifiedAccount account,
                    List<CatalogedPublication> publications) {

            using var accountEntry = GetAccountVerified(account, jpcSession);
            using var store = accountEntry.GetCatalogPublication();

            foreach (var publication in publications) {
                store.New(publication);

                }

            }

        /// <summary>
        /// Verify a claim to a publication and return the value if accepted.
        /// </summary>
        /// <param name="jpcSession">The Mesh session.</param>
        /// <param name="dareEnvelope">Envelope containing the MessageClaim</param>
        /// <returns>The claim response.</returns>
        public ClaimResponse Claim(
                    JpcSession jpcSession,
                    DareEnvelope dareEnvelope) {

            var messageClaim = MeshItem.Decode(dareEnvelope) as MessageClaim;
            using var accountEntry = GetAccountUnverified(messageClaim.Recipient);
            using var store = accountEntry.GetCatalogPublication();


            // Fetch the record by request.ID
            var id = messageClaim.PublicationId;
            var publicationEntry = store.GetEntry(id);

            if (!(publicationEntry.JsonObject is CatalogedPublication publication)) {
                return null;
                }

            // verify the claim.
            if (!publication.VerifyService(messageClaim.Sender,
                        messageClaim.ServiceAuthenticate)) {
                return null;
                }

            // Post the claim to the local spool. The unique identifier is the
            // publication identifier.
            dareEnvelope.Header.EnvelopeID = Message.GetEnvelopeId(id);
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
                    JpcSession jpcSession,
                    string targetAccount,
                    string id) {

            using var accountEntry = GetAccountUnverified(targetAccount);
            var message = accountEntry.GetLocal(id);

            // return the message if found (otherwise null)
            var response = new PollClaimResponse() {
                EnvelopedMessageClaim = message
                };


            return response;


            }

        /// <summary>
        /// Create a recryption group.
        /// </summary>
        /// <param name="jpcSession">The Mesh client session.</param>
        /// <param name="subjectAccount">The owner of the group.</param>
        /// <param name="profileGroup">The group profile.</param>
        /// <returns>The result of the transaction.</returns>
        public CreateGroupResponse CreateGroup(
                    JpcSession jpcSession,
                    string subjectAccount,
                    ProfileGroup profileGroup) {

            // create account entry

            // initialize member store

            // create admin entry



            var response = new CreateGroupResponse() {
                };


            return response;
            }

        /// <summary>
        /// Respond to a decryption request.
        /// <para>This involves the steps of resolving the group, resolving the membership
        /// record of the group member, authenticating and authorizing the request, and
        /// if authorized, performing the relevant recovery request and logging the 
        /// relevant records.</para>
        /// </summary>
        /// <param name="jpcSession">The Mesh client session.</param>
        /// <param name="groupAccount">The address of the group.</param>
        /// <param name="ephemeral">The ephemeral key.</param>
        /// <param name="partialId">The partial key identifier.</param>
        /// <returns>Result of the decryption request.</returns>
        public DecryptResponse Decrypt(
                    JpcSession jpcSession,
                    string groupAccount,
                    KeyPair ephemeral,
                    string partialId) {

            // Fetch the account 

            // Different stores depending on user or group account


            // is the request authorized?


            // partial decrypt

            var response = new DecryptResponse() {
                };


            return response;
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
                    VerifiedAccount account, List<string> accounts, DareEnvelope dareMessage) => 
            accounts == null ? MessagePostSelf(jpcSession, account, dareMessage) :
                 MessagePostOther(jpcSession, account, accounts, dareMessage);

        /// <summary>
        /// Post message to the local pickup spool.
        /// </summary>
        /// <param name="jpcSession">The session connection data.</param>
        /// <param name="account">The verified sending account.</param>
        /// <param name="dareMessage">The message.</param>
        /// <returns>Identifier of the message posted.</returns>
        public string MessagePostSelf(JpcSession jpcSession, VerifiedAccount account, DareEnvelope dareMessage) {

            var identifier = dareMessage.Header?.ContentMeta?.UniqueID;

            identifier.AssertNotNull(InvalidMessageID.Throw, "Messages must have an identifier");

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
                JpcSession jpcSession,
                VerifiedAccount senderAccount,
                List<string> accounts,
                DareEnvelope dareMessage) {

            jpcSession.Future();

            var identifier = dareMessage.Header?.ContentMeta?.UniqueID;
            identifier.AssertNotNull(InvalidMessageID.Throw, "Messages must have an identifier");

            var senderService = senderAccount.AccountAddress.GetService();

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
            recipientAccount.Post(dareMessage);

            return true;
            }

        bool MessagePostRemote(string recipient, DareEnvelope dareMessage) {
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
        AccountHandleVerified GetAccountVerified(VerifiedAccount verifiedAccount, JpcSession jpcSession) {
            var accountEntry = GetAccountLocked(verifiedAccount.AccountAddress);
            Assert.NotNull(accountEntry);

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

            if (jpcSession is DirectSession) {
                return new AccountHandleVerified(accountEntry);
                }
            if (jpcSession is LocalRemoteSession) {
                return new AccountHandleVerified(accountEntry);
                }
            // At this point we need to examine the actual information presented and the 
            // AssertionDeviceConnection value from the session.

            throw new NotAuthenticated();
            }

        /// <summary>
        /// Get access to an account record for an authenticated request.
        /// </summary>
        /// <param name="account">The account to access.</param>
        /// <returns>The access handle.</returns>
        AccountHandleUnverified GetAccountUnverified(string account) =>
            new AccountHandleUnverified(GetAccountLocked(account));


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

        ///<summary>The primary key</summary>
        public override string _PrimaryKey => AccountAddress;

        ///<summary>Cached convenience accessor for <see cref="ProfileMesh"/></summary>
        public ProfileMesh ProfileMesh => profileMesh ??
                ProfileMesh.Decode(SignedProfileMesh).CacheValue(out profileMesh);
        ProfileMesh profileMesh;

        ///<summary>Cached convenience accessor for <see cref="AssertionAccount"/></summary>
        public ProfileAccount AssertionAccount => assertionAccount ??
            ProfileAccount.Decode(SignedAssertionAccount).CacheValue(out assertionAccount);
        ProfileAccount assertionAccount;

        /// <summary>
        /// Default constructor for serialization.
        /// </summary>
        public AccountEntry() {
            }

        /// <summary>
        /// Constructor creating an Account entry from the request <paramref name="request"/>.
        /// </summary>
        /// <param name="request">The account creation request.</param>
        public AccountEntry(CreateRequest request) {
            AccountAddress = request.AccountAddress;
            SignedProfileMesh = request.SignedProfileMesh;
            SignedAssertionAccount = request.SignedAssertionAccount;
            Verify();
            Directory = AccountAddress;
            }

        /// <summary>
        /// Verification function.
        /// </summary>
        /// <returns>True if the account entry is properly formatted.</returns>
        public bool Verify() => true; // NYI: Verification of signed profile.

        }



    }
