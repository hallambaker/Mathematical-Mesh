using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using Goedel.Utilities;
using Goedel.IO;
using Goedel.Protocol;
using Goedel.Persistence;

namespace Goedel.Cryptography.Container {


    /// <summary>
    /// Index handle for data stored in a ContainerStoreIndex in-memory index.
    /// </summary>
    public class ContainerStoreEntry : IPersistenceEntry {

        /// <summary>
        /// The container header structure
        /// </summary>
        public ContainerHeader ContainerHeader { get; }

        /// <summary>
        /// The container frame
        /// </summary>
        public long FrameCount { get; }

        /// <summary>
        /// The container position
        /// </summary>
        public long Position { get; }

        /// <summary>
        /// Unique identifier of entry;
        /// </summary>
        public string UniqueID => ContainerHeader?.UniqueID;

        /// <summary>
        /// If true the object haws been deleted and cannot be further modified.
        /// </summary>
        public bool Deleted { get; }

        /// <summary>
        /// The time at which the object instance was created.
        /// </summary>
        public DateTime Created => DateTime.MinValue;

        /// <summary>
        /// The time at which the object instance value was created. 
        /// </summary>
        public DateTime Modified => DateTime.MinValue;

        /// <summary>
        /// The binary data
        /// </summary>
        public byte[] Data { get; }

        /// <summary>
        /// A deserialization reader for the data according to the encoding specified by 
        /// the container header.
        /// </summary>
        public JSONReader JSONReader => Data.JSONReader();

        /// <summary>
        /// The previous object instance value for this object instance.
        /// </summary>
        public IPersistenceEntry Previous { get; }

        /// <summary>
        /// The first object instance value for this object instance.
        /// </summary>
        public IPersistenceEntry First { get;  }

        /// <summary>
        /// Constructor, creates an entry for the specified container header, data and previous relationship.
        /// </summary>
        /// <param name="ContainerHeader">Parsed container header from frame</param>
        /// <param name="Data">The binary data</param>
        /// <param name="Previous">Link to previous value of this object</param>
        public ContainerStoreEntry (ContainerHeader ContainerHeader, byte[] Data, 
                    ContainerStoreEntry Previous) {
            this.ContainerHeader = ContainerHeader;
            Deleted = ContainerHeader.Event == ContainerPersistenceStore.EventDelete;
            this.Data = Data;
            this.Previous = Previous;
            First = Previous ?? this;
            }

        }

    }


