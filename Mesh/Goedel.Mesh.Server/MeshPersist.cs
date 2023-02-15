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


using Microsoft.Extensions.Logging;
using System.Net.Sockets;
using System.Security.Principal;

namespace Goedel.Mesh.Server;

/// <summary>
/// Wrapper providing a locked accessor to a CatalogedEntry of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The locked entry</typeparam>
public class LockedCatalogedEntry<T> : Disposable where T:CatalogItem{

    private bool locked;

    ///<summary>The locked account entry</summary> 
    public T CatalogItem { get; }
    ILogger Logger;
    ///<inheritdoc/> 
    protected override void Disposing() {
        if (locked) {
            System.Threading.Monitor.Exit(CatalogItem);
            Logger.LockRelease(CatalogItem._PrimaryKey);
            }
        }

    /// <summary>
    /// Constructor, attempt to acquire the lock 
    /// </summary>
    /// <param name="accountEntry">the entry to lock</param>
    /// <param name="millisecondsTimeout">The number of milliseconds to wait for the lock.</param>
    /// <param name="logger">Loger to output context to.</param>
    public LockedCatalogedEntry(T accountEntry, ILogger logger, int millisecondsTimeout=Timeout.Infinite) {

        Logger = logger ?? Component.Logger;
        CatalogItem = accountEntry;

        logger.LockAttempt(accountEntry._PrimaryKey);

        System.Threading.Monitor.TryEnter(CatalogItem, millisecondsTimeout, ref locked);
        locked.AssertTrue(LockRequestTimeout.Throw);


        logger.LockAcquire(accountEntry._PrimaryKey);
        }

    }

/// <summary>
/// The Mathematical Mesh persistence store.
/// </summary>
public class MeshPersist : Disposable {


    #region // Properties
    ///<summary>The underlying persistence store for the account catalog.</summary>
    public PersistenceStore Container;

    ///<summary>The callsign catalog mapping account names to profiles.</summary> 
    public CatalogCallsign CatalogCallsign { get; init; }

    ///<summary>The root directory in which the files are stored.</summary>
    public string DirectoryRoot;

    ///<summary>The service encryption key.</summary>  
    public static CryptoKey ServiceEncryptionKey => null;

    ///<summary>The service signature key.</summary> 
    public static CryptoKey ServiceSignatureKey => null;

    ///<summary>The key collection.</summary> 
    public IKeyCollection KeyCollection { get; }


    private ILogger Logger { get; }

    IPresence PresenceService { get; }
    #endregion


    #region // Disposing
    ///<inheritdoc/>
    protected override void Disposing() {

        base.Disposing();
        Container.Dispose();
        CatalogCallsign.Dispose();
        }

    #endregion

    #region // Constructors

    /// <summary>
    /// Open or create the accounts persistence container.
    /// </summary>
    /// <param name="keyCollection">The key collection to be used for decrypting data.</param>
    /// <param name="directory">The directory in which all the service data is stored.</param>
    /// <param name="fileStatus">Specifies whether to create the file if it doesn't exist.</param>
    /// <param name="logger">Output logger.</param>
    /// <param name="presenceService">Optional presence service.</param>
    public MeshPersist(
                IKeyCollection keyCollection, 
                string directory, 
                FileStatus fileStatus,
                ILogger logger,
                IPresence presenceService = null) {
        Logger = logger;
        PresenceService = presenceService;

        KeyCollection = keyCollection;
        // Load/create the accounts catalog
        DirectoryRoot = directory;


        Directory.CreateDirectory(directory);
        var fileName = Path.Combine(directory, "Master.cat");
        Container = new PersistenceStore(fileName, "application/mmm-catalog",
            fileStatus: fileStatus,
            sequenceType: SequenceType.Merkle
            );

        CatalogCallsign = new CatalogCallsign(directory);

        }
    #endregion






    #region // Account maintenance AccountBind/AccountUnbind


    /// <summary>
    /// Add a new account. The account name must be unique.
    /// </summary>
    /// <param name="accountEntry">Account data to add.</param>
    /// <param name="catalogedCallsigns">The catalogued callsigns to bind.</param>
    public void AccountBind(
                    AccountEntry accountEntry,
                    List<CatalogedCallsign> catalogedCallsigns) {
        IPersistenceEntry containerEntry;
        //Console.WriteLine("Start Bind");
        accountEntry.ProfileUdf = accountEntry.ProfileUdf;

        var directory = Path.Combine(DirectoryRoot, accountEntry.Directory);
        accountEntry.Directory = directory;

        // Lock the container so that we can create the new account entry without 
        // causing contention.
        lock (Container) {
            foreach (var catalogedCallsign in catalogedCallsigns) {
                CatalogCallsign.Get(catalogedCallsign.Canonical).AssertNull(NYI.Throw);
                }


            containerEntry = Container.New(accountEntry);
            //Console.WriteLine("Start write");
            foreach (var catalogedCallsign in catalogedCallsigns) {
                //Console.WriteLine($"Callsign {catalogedCallsign.Canonical} -> {catalogedCallsign.ProfileUdf}");
                CatalogCallsign.New(catalogedCallsign);
                }
            //Console.WriteLine("End write");
            }

        // Lock the container entry so that we can initialize it.
        lock (containerEntry) {
            Directory.CreateDirectory(directory);
            //if (storeEntries != null) {
            //    foreach (var entry in storeEntries) {
            //        Store.Append(directory, null, entry.Envelopes, entry.Sequence);
            //        }
            //    }
            new SpoolInbound(directory, SpoolInbound.Label).Dispose();
            new SpoolOutbound(directory, SpoolOutbound.Label).Dispose();
            new SpoolLocal(directory, SpoolLocal.Label).Dispose();
            }
        //Console.WriteLine("End bind");

        }

    /// <summary>
    /// Update an account record. There must be an existing record and the request must
    /// be appropriately authenticated.
    /// </summary>
    /// <param name="jpcSession">The session connection data.</param>
    /// <param name="accountAddress">The account address.</param>
    public bool AccountUnbind(IJpcSession jpcSession, string accountAddress) {

        using var accountHandle = GetAccountHandleLocked(jpcSession, AccountPrivilege.Unbind);
        //accountAddress.CannonicalAccountAddress().AssertEqual(accountHandle.AccountAddress, NYI.Throw);

        lock (Container) {
            return Container.Delete(jpcSession.TargetAccount);
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


        var bitmask = new Bitmask();
        accountHandle.PostInbound(acknowledgeConnection.DareEnvelope, bitmask);

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
        Console.WriteLine($"AccountComplete {jpcSession.Credential.AuthenticationKeyId}");
        //using var accountHandle = GetAccountUnverified(completeRequest.AccountAddress);
        using var accountHandle = GetAccountHandleLocked(jpcSession, AccountPrivilege.Device);

        Console.WriteLine($"AccountComplete Got handle, find message {completeRequest.ResponseID}");
        // pull the request off SpoolLocal
        var envelope = accountHandle.GetLocal(completeRequest.ResponseID);

        if (envelope == null) {
            Console.WriteLine($"Not found");
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
    /// <param name="catalogedDeviceDigest">The digest version identifier of the device catalog
    /// </param>
    /// <param name="catalogs">The list of catalogs for which status is requested.</param>
    /// <param name="services">List of services requested.</param>
    /// <param name="deviceStatus">If true return the device status vector from the presence service.</param>
    public StatusResponse AccountStatus(
                    IJpcSession jpcSession,
                    string catalogedDeviceDigest,
                    List<string> catalogs,
                    List<string> services,
                    bool deviceStatus) {


        using var accountHandle = GetAccountHandleLocked(jpcSession, AccountPrivilege.Read);

        var containerStatus = accountHandle.GetContainerStatuses(catalogs);


        var statusResponse = new StatusResponse() {
            ContainerStatus = containerStatus,
            EnvelopedCatalogedDevice = null
            };

        //Screen.Write($"Enveloped???");
        if (accountHandle.EnvelopedCatalogedDevice != null) {
            if (accountHandle.CatalogedDeviceDigest != catalogedDeviceDigest) {
                statusResponse.EnvelopedCatalogedDevice =
                    accountHandle.EnvelopedCatalogedDevice; // Hack: should allow this to be cached.
                statusResponse.CatalogedDeviceDigest = accountHandle.CatalogedDeviceDigest;
                }
            }

        if (services != null) {
            foreach (var service in services) {
                if (service == MeshConstants.MeshPresenceService & PresenceService is not null) {
                    statusResponse.Services ??= new();

                    var serviceAccessToken = PresenceService.GetEndPoint(accountHandle);


                    statusResponse.Services.Add (serviceAccessToken);

                    // add the connectionId to the locked account handle here.
                    }

                }


            }
        if (deviceStatus & PresenceService is not null) {
            statusResponse.DeviceStatuses = PresenceService?.GetDevices(accountHandle.AccountAddress);
            }

        //Screen.Write($"Status complete");
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

        using var accountHandle = GetAccountHandleLocked(session, AccountPrivilege.Read);

        //using var accountEntry = GetAccountVerified(account, jpcSession);
        var updates = new List<ContainerUpdate>();
        foreach (var selection in selections) {
            using var store = accountHandle.GetSequence(selection.Container);

            var update = new ContainerUpdate() {
                Container = selection.Container,
                Envelopes = new List<DareEnvelope>()
                };

            foreach (var message in store.SelectEnvelope(selection.IndexMin??0)) {
                message.LoadBody();
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
    public byte[] AccountTransact(
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

        var bitmask = new Bitmask();
        if (updates != null) {
            foreach (var update in updates) {
                //Screen.WriteLine(update.ToString());
                accountHandle.StoreAppend(update.Container, update.Envelopes, bitmask);
                }
            }
        if (inbound != null) {
            foreach (var envelope in inbound) {
                accountHandle.PostInbound(envelope, bitmask);
                }
            }
        if (local != null) {
            foreach (var envelope in local) {
                accountHandle.PostLocal(envelope, bitmask);
                }
            }

        // we always do these last
        if (outbound != null) {
            foreach (var envelope in outbound) {
                MessagePostOther(jpcSession, accountHandle, accounts, envelope);
                }
            }

        // report the final status of the containers here.
        var bits = bitmask.GetBits;
        Notify(accountHandle, bits);
        return bits;

        }

    void Notify(AccountHandleLocked accountHandle, byte[] bitmask) {
        PresenceService?.Notify(accountHandle.AccountAddress, bitmask);

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
            var recipientUdf = CatalogCallsign.Get(recipient);

            if (recipientUdf is null) {
                MessagePostRemote(recipient, dareMessage);
                }
            else {
                MessagePostLocal(jpcSession, recipient, dareMessage);
                }

            }
        return identifier;
        }

    bool MessagePostLocal(
        IJpcSession jpcSession,
        string recipient, DareEnvelope dareMessage) {


        // ToDo: refactor mapping of callsigns/Udfs to account records and returning a handle.


        using var recipientAccount = GetAccountHandleLocked(recipient, jpcSession, AccountPrivilege.Local);

        var bitmask = new Bitmask();

        recipientAccount.PostInbound(dareMessage, bitmask);

        Notify(recipientAccount, bitmask.GetBits);



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

        //Console.WriteLine("Begin operate");

        using var accountHandle = GetAccountHandleLocked(accountAddress,
                            jpcSession, AccountPrivilege.Operate);
        using var catalogCapability = accountHandle.GetCatalogCapability();

        var results = new List<CryptographicResult>();

        // Phase2: validate right to access...

        // Different stores depending on user or group account
        foreach (var operation in operations) {
            //Console.WriteLine("Try operation");

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
        //Console.WriteLine("Threahold operation");

        Logger.ThresholdKeyAgreement(accountAddress);
        var keyId = cryptographicOperation.KeyId ?? accountAddress.CannonicalAccountAddress();
        // Phase2: validate the access to this key id


        Logger.ThresholdKeyIdentifier(accountAddress, keyId);
        catalogCapability.DictionaryDecryptByKeyId.TryGetValue(
            keyId, out var capability).AssertTrue(MeshOperationFailed.Throw);

        Logger.ThresholdAuthorization(accountAddress, capability.Active == true);
        capability.Active.AssertTrue(NotAuthorized.Throw);


        var publicEphemeral = cryptographicOperation.PublicKey.GetKeyPair(KeySecurity.Exportable);

        var share = capability.DecryptShare(KeyCollection);


        var keyAgreement = share.Agreement(publicEphemeral);

        var cryptographicResultKeyAgreement = new CryptographicResultKeyAgreement() {
            KeyAgreement = KeyAgreement.Factory(keyAgreement)
            };

        //Console.WriteLine("Threahold Complete");

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

        var bitmask = new Bitmask();
        accountHandle.PostLocal(dareEnvelope, bitmask);

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
        targetAccount.Future();

        // return the message if found (otherwise null)
        var response = message == null ? null : new PollClaimResponse() {
            EnvelopedMessage = new Enveloped<Message>(message)
            };
        return response;
        }

    #endregion
    #region // Account handle management
    /// <summary>
    /// Get the account record and lock it. The entry must be disposed properly 
    /// to prevent access to the account being blocked from other threads.
    /// </summary>
    /// <param name="account">The account to get.</param>
    /// <returns>The locked account entry if found, otherwise null.</returns>
    LockedCatalogedEntry<AccountEntry> GetAccountLocked(string account) {
        AccountEntry result = null;


        lock (Container) {
            var containerEntry = Container.Get(account) as PersistentIndexEntry;

            if (containerEntry is null) {
                var profileUdf = GetProfileUdf(account);
                containerEntry = Container.Get(profileUdf) as PersistentIndexEntry;
                }

            result = containerEntry?.JsonObject as AccountEntry;
            result.AssertNotNull(MeshUnknownAccount.Throw);

            return new LockedCatalogedEntry<AccountEntry>(result, Logger);
            }
        }


    AccountHandleLocked GetAccountHandleLocked(string account,
                IJpcSession session,
                AccountPrivilege accountPrivilege) {

        session.Future();
        accountPrivilege.Future();

        LockedCatalogedEntry<AccountEntry> accountEntry = null;

        try {
            var profileUdf = GetProfileUdf(account);

            accountEntry = GetAccountLocked(profileUdf);
            var accountContext = new AccountContext(accountEntry, KeyCollection);

            return new AccountHandleLocked(accountContext, Logger) {
                AccountPrivilege = AccountPrivilege.Post
                };
            }
        catch (Exception) {
            accountEntry?.Dispose();
            throw;
            }
        }



    AccountHandleLocked GetAccountHandleLocked(IJpcSession session,
            AccountPrivilege accountPrivilege) {

        Console.WriteLine($"Request to access {session.TargetAccount} for {accountPrivilege}");


        LockedCatalogedEntry<AccountEntry> accountEntry = null;

        try {
            //


            accountEntry = GetAccountLocked(session.TargetAccount);
            var accountContext = new AccountContext(accountEntry, KeyCollection);
            accountContext.Authenticate(
                session, accountPrivilege).AssertTrue(NotAuthenticated.Throw);

            return new AccountHandleLocked(accountContext, Logger) {
                AccountPrivilege = accountPrivilege
                };
            }
        catch (Exception) {
            Console.WriteLine($"Refused {session.TargetAccount} for {accountPrivilege}");
            accountEntry?.Dispose();
            throw;
            }
        }

    string GetProfileUdf(string accountIn) {
        var account = accountIn.CannonicalAccountAddress();
        return CatalogCallsign.Get(account)?.ProfileUdf;
        }

    #endregion

    }
