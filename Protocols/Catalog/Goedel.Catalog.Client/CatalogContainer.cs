using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;
using Goedel.IO;
using Goedel.Protocol;
using Goedel.Persistence;
using Goedel.Cryptography.Dare;

namespace Goedel.Catalog.Client {
    class CatalogContainer : ContainerPersistenceStore {
        CatalogSession CatalogSession;
        /// <summary>
        /// Open or create a persistence store in specified mode with 
        /// the specified file name, content type and optional comment.
        /// </summary>
        /// <param name="FileName">Log file.</param>
        /// <param name="ReadOnly">If true, persistence store must exist
        /// and will be opened in read-only mode. If false, persistence store
        /// is opened in read/write mode and a new store will be created
        /// if none exists.</param>
        /// <param name="Type">Type of data to store (the schema name).</param>
        /// <param name="Comment">Comment to be written to the log.</param>
        /// <param name="ContainerType">The Container type.</param>
        /// <param name="DataEncoding">The data encoding.</param>
        /// <param name="FileStatus">The file status in which to open the container.</param>
        public CatalogContainer(
                    CatalogSession CatalogSession,
                    string FileName, string Type = null,
                    string Comment = null, bool ReadOnly = false,
                    FileStatus FileStatus = FileStatus.OpenOrCreate,
                    ContainerType ContainerType = ContainerType.Chain,
                    DataEncoding DataEncoding = DataEncoding.JSON) : base(
                       FileName, Type, Comment, ReadOnly, FileStatus, ContainerType, DataEncoding) => this.CatalogSession = CatalogSession;


        public override void CommitTransaction(ContainerHeader ContainerHeader, byte[] Data) => 
            base.CommitTransaction(ContainerHeader, Data);

        //public override void Update(JSONObject Object, bool Create = true) => 
        //        base.Update(Object, Create);

        //public override bool Delete(out ContainerHeader ContainerHeader, 
        //        out ContainerStoreEntry Previous, 
        //        string UniqueID) => base.Delete(out ContainerHeader, out Previous, UniqueID);

        }
    }
