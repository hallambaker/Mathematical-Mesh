﻿using Goedel.Cryptography.Dare;
using Goedel.Utilities;

using System.Collections.Generic;


namespace Goedel.Mesh.Client {


    /// <summary>
    /// Class backing a transaction manager that persists transactions to a Mesh
    /// Service account and the local store.
    /// </summary>
    public partial class TransactionServiced : Transaction {
        Catalog catalog;
        List<CatalogUpdate> updates = new List<CatalogUpdate>();
        MeshService meshClient;

        /// <summary>
        /// Constructor for a transaction manager
        /// </summary>
        /// <param name="catalog">The catalog to persist.</param>
        /// <param name="meshClient">The Mesh client to use to service the account.</param>
        public TransactionServiced(Catalog catalog, MeshService meshClient = null) {
            this.meshClient = meshClient;
            this.catalog = catalog;
            }

        /// <summary>
        /// Queue request to create <paramref name="catalogEntry"/> as a new persisted object.
        /// </summary>
        /// <param name="catalogEntry">The object to create.</param>
        public void New(CatalogedEntry catalogEntry) {
            var catalogUpdate = new CatalogUpdate(CatalogAction.New, catalogEntry);
            updates.Add(catalogUpdate);
            }

        /// <summary>
        /// Queue request to create or update <paramref name="catalogEntry"/>.
        /// </summary>
        /// <param name="catalogEntry">The object to update or create.</param>
        public void Update(CatalogedEntry catalogEntry) {
            var catalogUpdate = new CatalogUpdate(CatalogAction.Update, catalogEntry);
            updates.Add(catalogUpdate);
            }

        /// <summary>
        /// Queue request to delete <paramref name="catalogEntry"/>.
        /// </summary>
        /// <param name="catalogEntry">The object to delete.</param>
        public void Delete(CatalogedEntry catalogEntry) {
            var catalogUpdate = new CatalogUpdate(catalogEntry._PrimaryKey);
            updates.Add(catalogUpdate);
            }


        /// <summary>
        /// Commit a set of queued requests.
        /// </summary>
        public void Commit() {

            var envelopes = catalog.Prepare(updates);
            if (meshClient != null) {
                var containerUpdate = new ContainerUpdate() {
                    Container = catalog.ContainerName,
                    Index = (int)catalog.Container.FrameCount,
                    Envelopes = envelopes
                    };
                var uploadRequest = new UploadRequest() {
                    Updates = new List<ContainerUpdate> { containerUpdate }
                    };
                var uploadResponse = meshClient.Upload(uploadRequest);
                uploadResponse.Success().AssertTrue(SyncFailed.Throw);
                }
            catalog.Commit(envelopes);
            }
        }
    }
