using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using Goedel.Utilities;
using Goedel.IO;
using Goedel.Protocol;
using Goedel.Persistence;

namespace Goedel.Cryptography.Dare {


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

        ///<summary>The JSONObject.</summary>
        public JSONObject JsonObject => jsonObject ?? 
            JSONReader.ReadTaggedObject(ContainerPersistenceStore.TagDictionary).CacheValue(out jsonObject);
        JSONObject jsonObject;

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
        /// <param name="containerHeader">Parsed container header from frame</param>
        /// <param name="previous">Link to previous value of this object</param>
        /// <param name="data">The binary data</param>
        /// <param name="item">The JSONObject serialized by <paramref name="data"/>.</param>
        public ContainerStoreEntry(ContainerHeader containerHeader, ContainerStoreEntry previous,
                    byte[] data=null, JSONObject item=null) {
            jsonObject = item;
            this.ContainerHeader = containerHeader;
            Deleted = containerHeader.Event == ContainerPersistenceStore.EventDelete;
            this.Data = data ;
            this.Previous = previous;
            First = previous ?? this;
            }

        }

    }


