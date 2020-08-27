﻿using Goedel.Utilities;
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
            Container = catalog.ContainerName;
            Envelopes = new List<DareEnvelope>();
            Catalog = catalog;

            // ToDo: fill in the fields Index and Digest here
            }

        /// <summary>
        /// Commit the transaction to the remote and local copies of the catalog.
        /// </summary>
        public override void Commit() {

            foreach (var envelope in Envelopes) {
                var action = envelope.Header.ContentMeta.Event;

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
                    case PersistenceStore.EventDelete: {
                        Catalog.DeleteEntry(envelope.Header.ContentMeta.UniqueID);
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
            var envelope = Catalog.PersistenceStore.PrepareUpdate(out _, catalogedEntry);
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
        public TransactAccount TransactBegin() => new TransactAccount(this);

        /// <summary>
        /// Perform the transaction described by <paramref name="transact"/>. If the
        /// remote operation succeeds, apply the changes to the local stores.
        /// </summary>
        /// <param name="transact">The transaction to perform.</param>
        /// <returns>Response from the Mesh service.</returns>
        public TransactResponse Transact<TContext>(
                Transaction<TContext> transact) where TContext : ContextAccount {

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
        /// <returns>The transaction handle</returns>
        public new TransactUser TransactBegin() => new TransactUser(this);
        }


    public partial class ContextGroup {

        /// <summary>
        /// Begin a transaction.
        /// </summary>
        /// <returns>The transaction handle</returns>
        public new TransactGroup TransactBegin() => new TransactGroup(this);
        }

    /// <summary>
    /// Transaction on a Mesh account. Provides access to the account catalogs and spools.
    /// </summary>
    public partial class TransactAccount : Transaction<ContextAccount> {
        /// <summary>The account context in which this transaction takes place.</summary>
        public override ContextAccount ContextAccount  { get; }

        /// <summary>
        /// Constructor creating transaction instance under the account context
        /// <paramref name="contextAccount"/>
        /// </summary>
        /// <param name="contextAccount">The account context in which the update
        /// is to be applied.</param>
        public TransactAccount(ContextAccount contextAccount) => ContextAccount = contextAccount;
        }

    /// <summary>
    /// Transaction on a Mesh user account.Provides access to the account catalogs and spools.
    /// </summary>
    public partial class TransactUser : Transaction<ContextUser> {
        /// <summary>The account context in which this transaction takes place.</summary>
        public override ContextUser ContextAccount => ContextUser;
        /// <summary>The account context in which this transaction takes place.</summary>
        public ContextUser ContextUser { get; }

        /// <summary>
        /// Constructor creating transaction instance under the account context
        /// <paramref name="contextUser"/>
        /// </summary>
        /// <param name="contextUser">The account context in which the update
        /// is to be applied.</param>
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

    /// <summary>
    /// Transaction on a Mesh group account. Provides access to the account catalogs and spools.
    /// </summary>
    public partial class TransactGroup : Transaction<ContextGroup> {

        /// <summary>The account context in which this transaction takes place.</summary>
        public override ContextGroup ContextAccount => ContextGroup;

        /// <summary>The account context in which this transaction takes place.</summary>
        public ContextGroup ContextGroup { get; }

        /// <summary>
        /// Constructor creating transaction instance under the account context
        /// <paramref name="contextGroup"/>
        /// </summary>
        /// <param name="contextGroup">The account context in which the update
        /// is to be applied.</param>
        public TransactGroup(ContextGroup contextGroup) => ContextGroup = contextGroup;

        ///<summary>Returns the network catalog for the account</summary>
        public CatalogMember GetCatalogMember() => ContextGroup.GetStore(CatalogMember.Label) as CatalogMember;

        }

    /// <summary>
    /// Transaction on a context of type <typeparamref name="TAccount"/>.
    /// </summary>
    /// <typeparam name="TAccount">The type of the context on which the transaction is to
    /// be performed.</typeparam>
    public abstract class Transaction<TAccount> : Disposable where TAccount : ContextAccount {
        #region // Properties

        /// <summary>The account context in which this transaction takes place.</summary>
        public abstract TAccount ContextAccount { get; }

        ///<summary>Outbound message signature key, the global account signature key</summary> 
        KeyPair SignOutboundMessage => null; // ToDo: set signing key to the account signature key.

        ///<summary>Inbound message signature key, the device account signature key.
        ///This is only used to update message status.</summary> 
        KeyPair SignInboundMessage => null; // ToDo: set signing key to the device account key.

        ///<summary>Inbound message signature key, the device admin signature key</summary> 
        KeyPair SignLocalMessage => null; // ToDo: set signing key to the device admin key.

        CryptoKey TryFindKeyEncryption(string recipient) => ContextAccount.TryFindKeyEncryption(recipient);

        /// <summary>The transaction request message being assembled</summary>
        public TransactRequest TransactRequest = new TransactRequest();

        /// <summary>List of completion references to be added to the local spool</summary>
        public List<Reference> LocalReferences;

        /// <summary>List of completion references to be added to the inbound spool</summary>
        public List<Reference> InboundReferences;


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
        public void LocalMessage(
                Message message) {
            TransactRequest.Local ??= new List<Enveloped<Message>>();
            var envelope = message.Envelope(SignLocalMessage); 
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
                Message response= null
                ) {

            LocalReferences ??= new List<Reference>();
            var reference = new Reference() {
                MessageStatus = messageStatus,
                MessageId = completed.MessageId,
                ResponseId = response?.MessageId
                };
            LocalReferences.Add(reference);

            }


        TransactionUpdate<TEntry> GetContainerUpdate<TEntry>(
                List<ContainerUpdate> containerUpdates,
                Catalog<TEntry> catalog
                ) where TEntry : CatalogedEntry {

            foreach (var update in containerUpdates) {
                if (update.Container == catalog.ContainerName) {
                    return update as TransactionUpdate<TEntry>;
                    }
                }

            
            var result = new TransactionUpdate<TEntry>(catalog);

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
            TransactRequest.Updates.Add(update);
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
            TransactRequest.Updates.Add(update);
            }
        #endregion

        /// <summary>
        /// Apply the transaction and return the response.
        /// </summary>
        /// <returns></returns>
        public TransactResponse Transact() => ContextAccount.Transact(this);
        }
    }
