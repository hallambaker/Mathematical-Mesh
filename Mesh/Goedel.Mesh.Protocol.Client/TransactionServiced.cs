using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Goedel.Utilities;
using System.Threading;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography;
using Goedel.IO;
using Goedel.Protocol;


namespace Goedel.Mesh.Client {



    public partial class TransactionServiced : Transaction {
        Catalog catalog;
        List<CatalogUpdate> updates = new List<CatalogUpdate>();
        MeshService meshClient;

        public TransactionServiced(Catalog catalog, MeshService meshClient = null) {
            this.meshClient = meshClient;
            this.catalog = catalog;
            }


        public void New(CatalogedEntry catalogEntry) {
            var catalogUpdate = new CatalogUpdate(CatalogAction.New, catalogEntry);
            updates.Add(catalogUpdate);
            }

        public void Update(CatalogedEntry catalogEntry) {
            var catalogUpdate = new CatalogUpdate(CatalogAction.Update, catalogEntry);
            updates.Add(catalogUpdate);
            }

        public void Delete(CatalogedEntry catalogEntry) {
            var catalogUpdate = new CatalogUpdate(catalogEntry._PrimaryKey);
            updates.Add(catalogUpdate);
            }


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
