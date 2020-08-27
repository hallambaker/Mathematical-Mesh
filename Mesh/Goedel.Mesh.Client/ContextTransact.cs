using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;
using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Protocol;
using System.Transactions;

namespace Goedel.Mesh.Client {

    /// <summary>
    /// Untyped transaction update.
    /// </summary>
    public abstract class TransactionUpdate : ContainerUpdate {


        public abstract void Commit();
        }

    /// <summary>
    /// Typed transaction update
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TransactionUpdate<T> : TransactionUpdate where T : CatalogedEntry {

        public Catalog<T> Catalog;

        public TransactionUpdate(Catalog<T> catalog) {
            Container = catalog.ContainerName;
            Envelopes = new List<DareEnvelope>();
            Catalog = catalog;

            // ToDo: fill in the fields Index and Digest here
            }


        public override void Commit() {

            foreach (var envelope in Envelopes) {
                var action = envelope.Header.ContentMeta.Event;

                // persist update
                Catalog.Apply(envelope);

                // update in memory structure
                switch (action) {
                    case PersistenceStore.EventNew: {
                        Catalog.NewEntry(envelope.JsonObject as T);
                        break;
                        }
                    case PersistenceStore.EventUpdate: {
                        Catalog.UpdateEntry(envelope.JsonObject as T);
                        break;
                        }
                    case PersistenceStore.EventDelete: {
                        Catalog.DeleteEntry(envelope.Header.ContentMeta.UniqueID);
                        break;
                        }
                    }
                }
            }


        public DareEnvelope Update(T catalogedEntry) {

            // ToDo: need to seriously revise this to get the interlock stuff right.
            var envelope = Catalog.PersistenceStore.PrepareUpdate(out _, catalogedEntry);
            envelope.JsonObject = catalogedEntry;
            Envelopes.Add(envelope);

            return envelope;

            }


        public DareEnvelope Delete(T catalogedEntry) {

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
        public new TransactAccount TransactBegin() => new TransactAccount(this);

        /// <summary>
        /// Perform the transaction described by <paramref name="transactRequest"/>. If the
        /// remote operation succeeds, apply the changes to the local stores.
        /// </summary>
        /// <param name="transactRequest">The transaction to perform.</param>
        /// <returns>Response from the Mesh service.</returns>
        public TransactResponse Transact<T>(
                Transaction<T> transact) where T : ContextAccount {

            var transactRequest = transact.TransactRequest;
            Connect();

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
                transact.LocalMessage(message);
                }

            var response = MeshClient.Transact(transactRequest);


            if (response.Success()) {
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

                }

            return response;
            }



        }

    public partial class ContextUser {

        /// <summary>
        /// Begin a transaction.
        /// </summary>
        /// <returns></returns>
        public new TransactUser TransactBegin() => new TransactUser(this);
        }


    public partial class ContextGroup {

        /// <summary>
        /// Begin a transaction.
        /// </summary>
        /// <returns></returns>
        public new TransactGroup TransactBegin() => new TransactGroup(this);
        }

    public partial class TransactAccount : Transaction<ContextAccount> {
        /// <summary>The account context in which this transaction takes place.</summary>
        public override ContextAccount ContextAccount  { get; }

        public TransactAccount(ContextAccount contextAccount) => ContextAccount = contextAccount;




        }


    public partial class TransactUser : Transaction<ContextUser> {
        /// <summary>The account context in which this transaction takes place.</summary>
        public override ContextUser ContextAccount => ContextUser;
        /// <summary>The account context in which this transaction takes place.</summary>
        public ContextUser ContextUser { get; }

        public TransactUser(ContextUser contextUser) => ContextUser = contextUser;


        ///<summary>Returns the application catalog for the account</summary>
        public CatalogApplication GetCatalogApplication() => ContextUser.GetStore(CatalogApplication.Label) as CatalogApplication;

        ///<summary>Returns the contacts catalog for the account</summary>
        public CatalogDevice GetCatalogDevice() => ContextUser.GetStore(CatalogDevice.Label) as CatalogDevice;

        ///<summary>Returns the contacts catalog for the account</summary>
        public CatalogContact GetCatalogContact() => ContextUser.GetStore(CatalogContact.Label) as CatalogContact;

        ///<summary>Returns the credential catalog for the account</summary>
        public CatalogCredential GetCatalogCredential() => ContextUser.GetStore(CatalogCredential.Label) as CatalogCredential;

        ///<summary>Returns the bookmark catalog for the account</summary>
        public CatalogBookmark GetCatalogBookmark() => ContextUser.GetStore(CatalogBookmark.Label) as CatalogBookmark;

        ///<summary>Returns the calendar catalog for the account</summary>
        public CatalogCalendar GetCatalogCalendar() => ContextUser.GetStore(CatalogCalendar.Label) as CatalogCalendar;

        ///<summary>Returns the network catalog for the account</summary>
        public CatalogNetwork GetCatalogNetwork() => ContextUser.GetStore(CatalogNetwork.Label) as CatalogNetwork;

        ///<summary>Returns the inbound spool for the account</summary>
        public SpoolInbound GetSpoolInbound() => ContextUser.GetStore(SpoolInbound.Label) as SpoolInbound;



        }


    public partial class TransactGroup : Transaction<ContextGroup> {

        /// <summary>The account context in which this transaction takes place.</summary>
        public override ContextGroup ContextAccount => ContextGroup;

        /// <summary>The account context in which this transaction takes place.</summary>
        public ContextGroup ContextGroup { get; }

        public TransactGroup(ContextGroup contextGroup) => ContextGroup = contextGroup;

        ///<summary>Returns the network catalog for the account</summary>
        public CatalogMember GetCatalogMember() => ContextGroup.GetStore(CatalogMember.Label) as CatalogMember;

        }

    public abstract class Transaction<T> : Disposable where T : ContextAccount {
        #region // Properties

        /// <summary>The account context in which this transaction takes place.</summary>
        public abstract T ContextAccount { get; }

        KeyPair SignOutboundMessage => null;
        KeyPair SignInboundMessage => null;
        KeyPair SignLocalMessage => null;

        CryptoKey TryFindKeyEncryption(string recipient) => ContextAccount.TryFindKeyEncryption(recipient);


        /// <summary>The transaction request message being assembled</summary>
        public TransactRequest TransactRequest = new TransactRequest();

        /// <summary>List of completion references to be added to the local spool</summary>
        public List<Reference> LocalReferences;

        /// <summary>List of completion references to be added to the inbound spool</summary>
        public List<Reference> InboundReferences;


        //public Transaction<T>() {
        //    }

        #endregion
        #region // Operations
        ///<summary>Returns the network catalog for the account</summary>
        public CatalogPublication GetCatalogPublication() => 
            ContextAccount.GetStore(CatalogPublication.Label) as CatalogPublication;


        ///<summary>Returns the network catalog for the account</summary>
        public CatalogCapability GetCatalogCapability() => 
            ContextAccount.GetStore(CatalogCapability.Label) as CatalogCapability;





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
            var recipientEncryptionKey = TryFindKeyEncryption(recipientAddress);
            OutboundMessage(recipientAddress, recipientEncryptionKey,
                message);
            }


        /// <summary>
        /// Add the message <paramref name="message"/> to <paramref name="recipient"/> as an
        /// outbound message of <paramref name="transactRequest"/>.
        /// </summary>
        /// <param name="recipient">The message recipient</param>
        /// <param name="message">The message to send</param>
        public void OutboundMessage(
                NetworkProtocolEntry recipient,
                Message message) {

            var recipientAddress = recipient.NetworkAddress.Address;
            var recipientEncryptionKey = recipient.MeshKeyEncryption;

            OutboundMessage(recipientAddress, recipientEncryptionKey,
                message);
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

            //var envelope = message.Encode(signingKey: SignOutboundMessage,
            //        encryptionKey: recipientEncryptionKey); // Todo: Sign, encrypt

            var envelope = message.Envelope(); // Todo: Sign, encrypt
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
            var envelope = message.Envelope(); // Todo: Sign, encrypt
            envelope.JsonObject = message;
            TransactRequest.Inbound.Add(new Enveloped<Message>(envelope));
            }

        /// <summary>
        /// Add the message <paramref name="message"/> as a
        /// local message.
        /// </summary>
        /// <param name="message">The message to append to the local spool.</param>
        public void LocalMessage(
                Message message) {
            TransactRequest.Local ??= new List<Enveloped<Message>>();
            var envelope = message.Envelope(); // Todo: Sign, encrypt
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
                Message response=null
                ) {

            InboundReferences ??= new List<Reference>();
            var reference = new Reference() {
                MessageStatus =messageStatus,
                MessageID = completed.MessageID,
                ResponseID = response?.MessageID
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
                Message response= null
                ) {

            LocalReferences ??= new List<Reference>();
            var reference = new Reference() {
                MessageStatus = messageStatus,
                MessageID = completed.MessageID,
                ResponseID = response?.MessageID
                };
            LocalReferences.Add(reference);

            }


        TransactionUpdate<T> GetContainerUpdate<T>(
                List<ContainerUpdate> containerUpdates,
                Catalog<T> catalog
                ) where T : CatalogedEntry {

            foreach (var update in containerUpdates) {
                if (update.Container == catalog.ContainerName) {
                    return update as TransactionUpdate<T>;
                    }
                }

            
            var result = new TransactionUpdate<T>(catalog);

            return result;
            }

        /// <summary>
        /// Append a request to append <paramref name="catalogedEntry"/> to the catalog
        /// <paramref name="catalog"/> to the transaction.
        /// </summary>
        /// <param name="catalog">The catalog to be updated</param>
        /// <param name="catalogedEntry">The entry to add as an update.</param>
        public void CatalogUpdate<T>(
                Catalog<T> catalog,
                T catalogedEntry) where T : CatalogedEntry {
            TransactRequest.Updates ??= new List<ContainerUpdate>();
            var update = GetContainerUpdate(TransactRequest.Updates, catalog);
            update.Update(catalogedEntry);
            TransactRequest.Updates.Add(update);
            }

        /// <summary>
        /// Append a request to delete <paramref name="catalogedEntry"/> from the catalog
        /// <paramref name="catalog"/> to the transaction.
        /// </summary>
        /// <param name="catalog">The catalog to be updated</param>
        /// <param name="catalogedEntry">The entry to add as an update.</param>
        public void CatalogDelete<T>(
                Catalog<T> catalog,
                T catalogedEntry) where T : CatalogedEntry {
            TransactRequest.Updates ??= new List<ContainerUpdate>();
            var update = GetContainerUpdate(TransactRequest.Updates, catalog);
            update.Delete(catalogedEntry);
            TransactRequest.Updates.Add(update);
            }
        #endregion

        public TransactResponse Transact() => ContextAccount.Transact(this);
        }
    }
