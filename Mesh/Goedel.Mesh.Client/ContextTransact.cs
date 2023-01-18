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


namespace Goedel.Mesh.Client;


/// <summary>
/// Untyped transaction update.
/// </summary>
public abstract class TransactionUpdate : ContainerUpdate {

    /// <summary>
    /// Commit the transaction to the remote and local copies of the catalog.
    /// </summary>
    public abstract void Commit();
    }

/// <summary>
/// Typed transaction update
/// </summary>
/// <typeparam name="TEntry">A type inheriting from <see cref="CatalogedEntry"/> which
/// specifies the type of the contents of the catalog.</typeparam>
public class TransactionUpdate<TEntry> : TransactionUpdate where TEntry : CatalogedEntry {
    ///<summary>Catalog of type </summary> 
    public Catalog<TEntry> Catalog;

    /// <summary>
    /// Constructor, return a new update transaction for the catalog <paramref name="catalog"/>.
    /// </summary>
    /// <param name="catalog">The catalog on which the transaction is to be performed.</param>
    public TransactionUpdate(Catalog<TEntry> catalog) {
        Container = catalog.StoreName;
        Envelopes = new List<DareEnvelope>();
        Catalog = catalog;

        // ToDo: fill in the fields Index and Bitmask here
        }

    /// <summary>
    /// Commit the transaction to the remote and local copies of the catalog.
    /// </summary>
    public override void Commit() {

        foreach (var envelope in Envelopes) {
            var action = envelope.Header.ContentMeta.Event;


            // update in memory structure
            switch (action) {
                case PersistenceStore.EventDelete: {
                        Catalog.DeleteEntry(envelope.Header.ContentMeta.UniqueId);
                        break;
                        }
                }
            // persist update
            Catalog.Apply(envelope);

            // update in memory structure
            switch (action) {
                case PersistenceStore.EventNew: {
                        Catalog.NewEntry(envelope.JsonObject as TEntry);
                        break;
                        }
                case PersistenceStore.EventUpdate: {
                        Catalog.UpdateEntry(envelope.JsonObject as TEntry);
                        break;
                        }
                }
            }
        }

    /// <summary>
    /// Add a task to update to the entry <paramref name="catalogedEntry"/> to the transaction
    /// update.
    /// </summary>
    /// <param name="catalogedEntry">The new value of the catalog entry.</param>
    /// <returns>The enveloped update value.</returns>
    public DareEnvelope Update(TEntry catalogedEntry) {

        // ToDo: need to seriously revise this to get the interlock stuff right.
        var envelope = Catalog.PersistenceStore.PrepareUpdate(out _, catalogedEntry, additionalRecipients: catalogedEntry.AdditionalRecipients);
        envelope.JsonObject = catalogedEntry;
        Envelopes.Add(envelope);

        return envelope;

        }

    /// <summary>
    /// Add a task to delete the entry <paramref name="catalogedEntry"/> to the transaction
    /// update.
    /// </summary>
    /// <param name="catalogedEntry">The catalog entry to delete.</param>
    /// <returns>The enveloped update value.</returns>
    public DareEnvelope Delete(TEntry catalogedEntry) {

        // ToDo: need to seriously revise this to get the interlock stuff right.
        var envelope = Catalog.PersistenceStore.PrepareDelete(out _, catalogedEntry._PrimaryKey);

        Envelopes.Add(envelope);

        return envelope;
        }

    }

public partial class ContextAccount {

    /// <summary>
    /// Begin a transaction.
    /// </summary>
    /// <returns></returns>
    public TransactAccount TransactBegin() => new(this);

    /// <summary>
    /// Perform the transaction described by <paramref name="transact"/>. If the
    /// remote operation succeeds, apply the changes to the local stores.
    /// </summary>
    /// <param name="transact">The transaction to perform.</param>
    /// <returns>Response from the Mesh service.</returns>
    public TransactResponse Transact<TContext>(
            Transaction<TContext> transact) where TContext : ContextAccount {

        transact.ContextAccount.AssertEqual(this, NYI.Throw);





        TransactResponse response = null;
        var transactRequest = transact.TransactRequest;

        //if (transactRequest.Updates != null) {
        //    foreach (var update in transactRequest.Updates) {
        //        if (update.Sequence == CatalogAccess.Label) {
        //            if (update.Envelopes != null) {
        //                foreach (var envelope in update.Envelopes) {
        //                    if (envelope.Header?.Recipients?.Count != 2) {
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //    }

        if (!transact.Local) {

            if (transact.InboundReferences != null) {
                var message = new MessageComplete() {
                    References = transact.InboundReferences
                    };
                transact.InboundMessage(message);
                }
            if (transact.LocalReferences != null) {
                var message = new MessageComplete() {
                    References = transact.LocalReferences
                    };
                transact.LocalMessage(message, null);
                // Hack: should completion messages be encrypted or not?

                }

            response = MeshClient.Transact(transactRequest);
            response.Success().AssertTrue(NYI.Throw);
            }

        if (transactRequest.Updates != null) {
            // Perform local updates to each store.
            foreach (var update in transactRequest.Updates) {
                var catalogUpdate = update as TransactionUpdate;
                catalogUpdate.Commit();
                }
            }
        if (transactRequest.Inbound != null) {
            var spoolInbound = GetStore(SpoolInbound.Label) as SpoolInbound;
            foreach (var envelope in transactRequest.Inbound) {
                spoolInbound.Add(envelope);
                }
            }
        if (transactRequest.Local != null) {
            var spoolLocal = GetStore(SpoolLocal.Label) as SpoolLocal;
            foreach (var envelope in transactRequest.Local) {
                spoolLocal.Add(envelope);
                }
            }



        return response;
        }



    }


public partial class ContextUser {




    /// <summary>
    /// Begin a transaction.
    /// </summary>
    /// <returns>The transaction handle</returns>
    public TransactUser TransactBegin(bool local = false) => new(this) {
        Local = local
        };
    }


public partial class ContextGroup {

    /// <summary>
    /// Begin a transaction.
    /// </summary>
    /// <returns>The transaction handle</returns>
    public new TransactGroup TransactBegin() => new(this);
    }

/// <summary>
/// Transaction on a Mesh account. Provides access to the account catalogs and spools.
/// </summary>
public partial class TransactAccount : Transaction<ContextAccount> {
    /// <summary>The account context in which this transaction takes place.</summary>
    public override ContextAccount ContextAccount { get; }


    /// <summary>
    /// Constructor creating transaction instance under the account context
    /// <paramref name="contextAccount"/>
    /// </summary>
    /// <param name="contextAccount">The account context in which the update
    /// is to be applied.</param>
    public TransactAccount(ContextAccount contextAccount) => ContextAccount = contextAccount;
    }

/// <summary>
/// Transaction on a context of type <typeparamref name="TAccount"/>.
/// </summary>
/// <typeparam name="TAccount">The type of the context on which the transaction is to
/// be performed.</typeparam>
public abstract class Transaction<TAccount> : Disposable
            where TAccount : ContextAccount {
    #region // Properties

    /// <summary>The account context in which this transaction takes place.</summary>
    public abstract TAccount ContextAccount { get; }

    ///<summary>Outbound message signature key, the global account signature key</summary> 
    static KeyPair SignOutboundMessage => null; // ToDo: set signing key to the account signature key.

    ///<summary>Inbound message signature key, the device account signature key.
    ///This is only used to update message status.</summary> 
    static KeyPair SignInboundMessage => null; // ToDo: set signing key to the device account key.

    ///<summary>Inbound message signature key, the device admin signature key</summary> 
    static KeyPair SignLocalMessage => null; // ToDo: set signing key to the device admin key.

    ///<summary>The account identifier.</summary> 
    public string AccountId => ContextAccount.AccountAddress;

    ///<summary>The service profile.</summary> 
    public ProfileService ProfileService => ContextAccount.ProfileService;

    ///<summary>The full device connection.</summary> 
    public ConnectionDevice ConnectionDevice => (ContextAccount as ContextUser)?.ConnectionAccount;


    bool TryFindKeyEncryption(string recipient, out CryptoKey cryptoKey) =>
            ContextAccount.TryFindKeyEncryption(recipient, out cryptoKey);

    /// <summary>The transaction request message being assembled</summary>
    public TransactRequest TransactRequest = new();

    /// <summary>List of completion references to be added to the local spool</summary>
    public List<Reference> LocalReferences;

    /// <summary>List of completion references to be added to the inbound spool</summary>
    public List<Reference> InboundReferences;

    ///<summary>If true, only perform the transaction to the local stores.</summary> 
    public bool Local { get; init; } = false;
    #endregion
    #region // Operations
    ///<summary>Returns the publication catalog for the account</summary>
    public CatalogPublication GetCatalogPublication() =>
        ContextAccount.GetStore(CatalogPublication.Label) as CatalogPublication;


    ///<summary>Returns the capability catalog for the account</summary>
    public CatalogAccess GetCatalogAccess() =>
        ContextAccount.GetStore(CatalogAccess.Label, decrypt:true) as CatalogAccess;





    #endregion



    #region // Operations
    /// <summary>
    /// Add the message <paramref name="message"/> to <paramref name="recipientAddress"/> as an
    /// outbound message.
    /// </summary>
    /// <param name="recipientAddress">The message recipient</param>
    /// <param name="message">The message to send</param>
    public void OutboundMessage(
            string recipientAddress,
            Message message) {
        TryFindKeyEncryption(recipientAddress, out var recipientEncryptionKey);
        OutboundMessage(recipientAddress, recipientEncryptionKey, message);
        }


    /// <summary>
    /// Add the message <paramref name="message"/> to <paramref name="recipient"/> as an
    /// outbound message the transaction request.
    /// </summary>
    /// <param name="recipient">The message recipient</param>
    /// <param name="message">The message to send</param>
    public void OutboundMessage(
            NetworkProtocolEntry recipient,
            Message message) {

        var recipientAddress = recipient.NetworkAddress.Address;
        var recipientEncryptionKey = recipient.MeshKeyEncryption;

        OutboundMessage(recipientAddress, recipientEncryptionKey, message);
        }

    /// <summary>
    /// Add the message <paramref name="message"/> to <paramref name="recipientAddress"/> 
    /// encrypted under <paramref name="recipientEncryptionKey"/> as an
    /// outbound message.
    /// </summary>
    /// <param name="recipientAddress">The message recipient address</param>
    /// <param name="recipientEncryptionKey">The message recipient encryption key</param>
    /// <param name="message">The message to send</param>
    public void OutboundMessage(
            string recipientAddress,
            CryptoKey recipientEncryptionKey,
            Message message) {
        TransactRequest.Outbound ??= new List<Enveloped<Message>>();
        TransactRequest.Accounts ??= new List<string>();

        message.Sender ??= ContextAccount.AccountAddress;

        var envelope = message.Envelope(SignOutboundMessage, recipientEncryptionKey);
        envelope.JsonObject = message;

        TransactRequest.Outbound.Add(new Enveloped<Message>(envelope));
        if (recipientAddress != null) {
            TransactRequest.Accounts.Add(recipientAddress);
            }
        }


    /// <summary>
    /// Add the message <paramref name="message"/> as an inbound message.
    /// </summary>
    /// <param name="message">The message to append to the inbound spool.</param>
    public void InboundMessage(
            Message message) {
        TransactRequest.Inbound ??= new List<Enveloped<Message>>();
        var envelope = message.Envelope(SignInboundMessage); // Todo: Sign, encrypt
        envelope.JsonObject = message;
        TransactRequest.Inbound.Add(new Enveloped<Message>(envelope));
        }

    /// <summary>
    /// Add the message <paramref name="message"/> to the local pickup spool.
    /// local message.
    /// </summary>
    /// <param name="message">The message to append to the local spool.</param>
    /// <param name="keyEncrypt">The message encryption key.</param>
    public void LocalMessage(
            Message message,
            CryptoKey keyEncrypt) {
        TransactRequest.Local ??= new List<Enveloped<Message>>();

        //"Fix the encryption of local messages".TaskFunctionality(true);

        var envelope = message.Envelope(SignLocalMessage, keyEncrypt);
        envelope.JsonObject = message;
        TransactRequest.Local.Add(new Enveloped<Message>(envelope));
        }

    /// <summary>
    /// Mark the message <paramref name="completed"/> on the inbound spool as having status 
    /// <paramref name="messageStatus"/>. If 
    /// <paramref name="response"/> is not null, mark it as the response.
    /// </summary>
    /// <param name="messageStatus">The new message status.</param>
    /// <param name="completed">The message whose status is being changed.</param>
    /// <param name="response">The message generated in response.</param>
    public void InboundComplete(
            MessageStatus messageStatus,
            Message completed,
            Message response = null
            ) {
        //Console.WriteLine($"Mark status {completed.MessageId}  {messageStatus}");
        InboundReferences ??= new List<Reference>();
        var reference = new Reference() {
            MessageStatus = messageStatus,
            MessageId = completed.MessageId,
            ResponseId = response?.MessageId
            };
        InboundReferences.Add(reference);
        }

    /// <summary>
    /// Mark the message <paramref name="completed"/> on the local spool as having status 
    /// <paramref name="messageStatus"/>. If 
    /// <paramref name="response"/> is not null, mark it as the response.
    /// </summary>
    /// <param name="messageStatus">The new message status.</param>
    /// <param name="completed">The message whose status is being changed.</param>
    /// <param name="response">The message generated in response.</param>
    public void LocalComplete(
            MessageStatus messageStatus,
            Message completed,
            Message response = null
            ) {

        LocalReferences ??= new List<Reference>();
        var reference = new Reference() {
            MessageStatus = messageStatus,
            MessageId = completed.MessageId,
            ResponseId = response?.MessageId
            };
        LocalReferences.Add(reference);

        }

    static TransactionUpdate<TEntry> GetContainerUpdate<TEntry>(
            List<ContainerUpdate> containerUpdates,
            Catalog<TEntry> catalog
            ) where TEntry : CatalogedEntry {

        foreach (var update in containerUpdates) {
            if (update.Container == catalog.StoreName) {
                return update as TransactionUpdate<TEntry>;
                }
            }


        var result = new TransactionUpdate<TEntry>(catalog);
        containerUpdates.Add(result);
        return result;
        }

    /// <summary>
    /// Append a request to append <paramref name="catalogedEntry"/> to the catalog
    /// <paramref name="catalog"/> to the transaction.
    /// </summary>
    /// <param name="catalog">The catalog to be updated</param>
    /// <param name="catalogedEntry">The entry to add as an update.</param>
    /// <typeparam name="TEntry">The entry type.</typeparam>
    public void CatalogUpdate<TEntry>(
            Catalog<TEntry> catalog,
            TEntry catalogedEntry) where TEntry : CatalogedEntry {
        TransactRequest.Updates ??= new List<ContainerUpdate>();
        var update = GetContainerUpdate(TransactRequest.Updates, catalog);
        update.Update(catalogedEntry);
        }

    /// <summary>
    /// Append a request to append <paramref name="contact"/> to the catalog
    /// <paramref name="catalog"/> to the transaction.
    /// </summary>
    /// <param name="catalog">The catalog to be updated</param>
    /// <param name="contact">The contact to add as an update.</param>
    public void CatalogUpdate(
            CatalogContact catalog,
            Contact contact) {
        var cataloged = new CatalogedContact(contact);
        CatalogUpdate(catalog, cataloged);
        }


    /// <summary>
    /// Append a request to delete <paramref name="catalogedEntry"/> from the catalog
    /// <paramref name="catalog"/> to the transaction.
    /// </summary>
    /// <param name="catalog">The catalog to be updated</param>
    /// <param name="catalogedEntry">The entry to add as an update.</param>
    /// <typeparam name="TEntry">The entry type.</typeparam>
    public void CatalogDelete<TEntry>(
            Catalog<TEntry> catalog,
            TEntry catalogedEntry) where TEntry : CatalogedEntry {
        TransactRequest.Updates ??= new List<ContainerUpdate>();
        var update = GetContainerUpdate(TransactRequest.Updates, catalog);
        update.Delete(catalogedEntry);
        }

    #endregion

    /// <summary>
    /// Apply the transaction and return the response.
    /// </summary>
    /// <returns></returns>
    public TransactResponse Transact() =>
                ContextAccount.Transact(this);
    }
