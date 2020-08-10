using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;
using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Protocol;

namespace Goedel.Mesh.Client {


    public class TransactionUpdate<T> : ContainerUpdate where T : CatalogedEntry {

        public Catalog<T> Catalog;


        public TransactionUpdate(Catalog<T> catalog) {
            Container = catalog.ContainerName;
            Envelopes = new List<DareEnvelope>();
            Catalog = catalog;

            // ToDo: fill in the fields Index and Digest here
            }


        public DareEnvelope Update(T catalogedEntry) {

            // ToDo: need to seriously revise this to get the interlock stuff right.
            var envelope = Catalog.PersistenceStore.PrepareUpdate(out _, catalogedEntry);

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
        /// Add the message <paramref name="message"/> to <paramref name="recipient"/> as an
        /// outbound message of <paramref name="transactRequest"/>.
        /// </summary>
        /// <param name="transactRequest">The transaction request being built</param>
        /// <param name="recipient">The message recipient</param>
        /// <param name="message">The message to send</param>
        public void OutboundMessage(
                TransactRequest transactRequest,
                string recipient,
                Message message) {
            transactRequest.Outbound ??= new List<Cryptography.Dare.DareEnvelope>();
            transactRequest.Accounts ??= new List<string>();

            var envelope = message.Encode(); // Todo: Sign, encrypt
            transactRequest.Outbound.Add(envelope);
            if (recipient != null) {
                transactRequest.Accounts.Add(recipient);
                }
            }

        /// <summary>
        /// Add the message <paramref name="message"/> as an
        /// inbound message of <paramref name="transactRequest"/>.
        /// </summary>
        /// <param name="transactRequest">The transaction request being built</param>
        /// <param name="message">The message to append to the inbound spool.</param>
        public void InboundMessage(
                TransactRequest transactRequest,
                Message message) {
            transactRequest.Inbound ??= new List<Cryptography.Dare.DareEnvelope>();
            var envelope = message.Encode(); // Todo: Sign, encrypt
            transactRequest.Inbound.Add(envelope);
            }

        /// <summary>
        /// Add the message <paramref name="message"/> as a
        /// local message of <paramref name="transactRequest"/>.
        /// </summary>
        /// <param name="transactRequest">The transaction request being built</param>
        /// <param name="message">The message to append to the local spool.</param>
        public void LocalMessage(
                TransactRequest transactRequest,
                Message message) {
            transactRequest.Local ??= new List<Cryptography.Dare.DareEnvelope>();
            var envelope = message.Encode(); // Todo: Sign, encrypt
            transactRequest.Local.Add(envelope);
            }

        /// <summary>
        /// Mark the message <paramref name="completed"/> on the inbound spool as having status 
        /// <paramref name="messageStatus"/> on <paramref name="transactRequest"/>. If 
        /// <paramref name="response"/> is not null, mark it as the response.
        /// </summary>
        /// <param name="transactRequest">The transaction request being built</param>
        /// <param name="messageStatus">The new message status.</param>
        /// <param name="completed">The message whose status is being changed.</param>
        /// <param name="response">The message generated in response.</param>
        public void InboundComplete(
                TransactRequest transactRequest,
                MessageStatus messageStatus,
                Message completed,
                Message response=null
                ) {

            transactRequest.InboundReferences ??= new List<Reference>();
            var reference = new Reference() {
                MessageStatus =messageStatus,
                MessageID = completed.MessageID,
                ResponseID = response?.MessageID
                };
            transactRequest.InboundReferences.Add(reference);
            }

        /// <summary>
        /// Mark the message <paramref name="completed"/> on the local spool as having status 
        /// <paramref name="messageStatus"/> on <paramref name="transactRequest"/>. If 
        /// <paramref name="response"/> is not null, mark it as the response.
        /// </summary>
        /// <param name="transactRequest">The transaction request being built</param>
        /// <param name="messageStatus">The new message status.</param>
        /// <param name="completed">The message whose status is being changed.</param>
        /// <param name="response">The message generated in response.</param>
        public void LocalComplete(
                TransactRequest transactRequest,
                MessageStatus messageStatus,
                Message completed,
                Message response= null
                ) {

            transactRequest.LocalReferences ??= new List<Reference>();
            var reference = new Reference() {
                MessageStatus = messageStatus,
                MessageID = completed.MessageID,
                ResponseID = response?.MessageID
                };
            transactRequest.LocalReferences.Add(reference);

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
        /// <paramref name="catalog"/> to the transaction <paramref name="transactRequest"/>.
        /// </summary>
        /// <param name="transactRequest">The transaction request being built</param>
        /// <param name="catalog">The catalog to be updated</param>
        /// <param name="catalogedEntry">The entry to add as an update.</param>
        public void CatalogUpdate<T>(
                TransactRequest transactRequest,
                Catalog<T> catalog,
                T catalogedEntry) where T : CatalogedEntry {
            transactRequest.Updates ??= new List<ContainerUpdate>();
            var update = GetContainerUpdate(transactRequest.Updates, catalog);

            update.Update(catalogedEntry);
            }

        /// <summary>
        /// Append a request to delete <paramref name="catalogedEntry"/> from the catalog
        /// <paramref name="catalog"/> to the transaction <paramref name="transactRequest"/>.
        /// </summary>
        /// <param name="transactRequest">The transaction request being built</param>
        /// <param name="catalog">The catalog to be updated</param>
        /// <param name="catalogedEntry">The entry to add as an update.</param>
        public void CatalogDelete<T>(
                TransactRequest transactRequest,
                Catalog<T> catalog,
                T catalogedEntry) where T : CatalogedEntry {
            transactRequest.Updates ??= new List<ContainerUpdate>();
            var update = GetContainerUpdate(transactRequest.Updates, catalog);

            update.Delete(catalogedEntry);
            }


        /// <summary>
        /// Perform the transaction described by <paramref name="transactRequest"/>. If the
        /// remote operation succeeds, apply the changes to the local stores.
        /// </summary>
        /// <param name="transactRequest">The transaction to perform.</param>
        /// <returns>Response from the Mesh service.</returns>
        public TransactResponse Transact(
                TransactRequest transactRequest) {
            Connect();

            if (transactRequest.InboundReferences != null) {
                var message = new MessageComplete() {
                    References = transactRequest.InboundReferences
                    };
                LocalMessage(transactRequest, message);
                }
            if (transactRequest.LocalReferences != null) {
                var message = new MessageComplete() {
                    References = transactRequest.LocalReferences
                    };
                LocalMessage(transactRequest, message);
                }

            var response = MeshClient.Transact(transactRequest);


            if (response.Success()) {
                // Perform local updates to each store.
                foreach (var update in transactRequest.Updates) {
                    var catalogUpdate = update as TransactionUpdate<CatalogedEntry>;
                    var catalog = catalogUpdate.Catalog;

                    foreach (var envelope in catalogUpdate.Envelopes) {

                        var action = envelope.Header.ContentMeta.Event;

                        // persist update
                        catalog.Apply(envelope); 
                        
                        // update in memory structure
                        switch (action) {
                            case PersistenceStore.EventNew: {
                                catalog.NewEntry(envelope.JSONObject as CatalogedEntry);
                                break;
                                }
                            case PersistenceStore.EventUpdate: {
                                catalog.UpdateEntry(envelope.JSONObject as CatalogedEntry);
                                break;
                                }
                            case PersistenceStore.EventDelete: {
                                catalog.DeleteEntry((envelope.JSONObject as CatalogedEntry)._PrimaryKey);
                                break;
                                }
                            }
                        }
                    }
                }

            return response;
            }


        }
    }
