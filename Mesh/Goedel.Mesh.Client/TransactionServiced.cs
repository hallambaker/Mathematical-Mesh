using Goedel.Cryptography.Dare;
using Goedel.Utilities;

using System.Collections.Generic;


namespace Goedel.Mesh.Client {


    /// <summary>
    /// Class backing a transaction manager that persists transactions to a Mesh
    /// Service account and the local store.
    /// </summary>
    public partial class TransactionServiced : Transaction {
        List<CatalogUpdate> updates = new List<CatalogUpdate>();
        MeshService MeshClient { get; }

        /// <summary>
        /// Constructor for a transaction manager
        /// </summary>
        /// <param name="meshClient">The Mesh client to use to service the account.</param>
        public TransactionServiced(MeshService meshClient = null) => MeshClient = meshClient;

        /// <summary>
        /// Queue request to create <paramref name="catalogEntry"/> as a new persisted object.
        /// </summary>
        /// <param name="catalogEntry">The object to create.</param>
        /// <param name="catalog">The catalog in which to create the object.</param>
        public void New(ICatalog catalog, CatalogedEntry catalogEntry) {
            var catalogUpdate = new CatalogUpdate(catalog, CatalogAction.New, catalogEntry);
            updates.Add(catalogUpdate);
            }

        /// <summary>
        /// Queue request to create or update <paramref name="catalogEntry"/>.
        /// </summary>
        /// <param name="catalogEntry">The object to update or create.</param>
        /// <param name="catalog">The catalog in which to create the object.</param>
        public void Update(ICatalog catalog, CatalogedEntry catalogEntry) {
            var catalogUpdate = new CatalogUpdate(catalog, CatalogAction.Update, catalogEntry);
            updates.Add(catalogUpdate);
            }

        /// <summary>
        /// Queue request to delete <paramref name="catalogEntry"/>.
        /// </summary>
        /// <param name="catalogEntry">The object to delete.</param>
        /// <param name="catalog">The catalog in which to create the object.</param>
        public void Delete(ICatalog catalog, CatalogedEntry catalogEntry) {
            var catalogUpdate = new CatalogUpdate(catalog, catalogEntry._PrimaryKey);
            updates.Add(catalogUpdate);
            }


        /// <summary>
        /// Commit a set of queued requests.
        /// </summary>
        public void Commit() {
            if (updates.Count == 0) {
                return;
                }

            var catalog = updates[0].Catalog;

            var envelopes = catalog.Prepare(updates);
            if (MeshClient != null) {
                var containerUpdate = new ContainerUpdate() {
                    Container = catalog.ContainerName,
                    Index = (int)catalog.Container.FrameCount,
                    Envelopes = envelopes
                    };
                var uploadRequest = new TransactRequest() {
                    Updates = new List<ContainerUpdate> { containerUpdate }
                    };
                var uploadResponse = MeshClient.Transact(uploadRequest);
                uploadResponse.AssertSuccess();
                }
            catalog.Commit(envelopes, updates);
            }
        }
    }
