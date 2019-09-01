using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using Goedel.Utilities;
using Goedel.IO;
using Goedel.Protocol;

namespace Goedel.Cryptography.Dare {


    /// <summary>
    /// Index handle for data stored in a ContainerStoreIndex in-memory index.
    /// </summary>
    public class ContainerStoreEntry : IPersistenceEntry {


        #region // Propeties and fields

        ///<summary>The container the store entry belongs to</summary>
        public Container Container;

        ///<summary>The enveloped data</summary>
        public DareEnvelope DareEnvelope;

        ///<summary>The envelope header</summary>
        public ContainerHeader ContainerHeader => DareEnvelope.Header as ContainerHeader;

        //public ContentInfo ContentInfo => DareHeader.ContentInfo;


        ///<summary>The envelope metadata</summary>
        public ContentInfo ContentInfo => ContainerHeader.ContentInfo;

        ///<summary>Unique identifier of entry;</summary>
        public string UniqueID => ContentInfo?.UniqueID;

        ///<summary>The container frame</summary>
        public long FrameCount => ContainerHeader.Index;

        ///<summary>If true the object haws been deleted and cannot be further modified.</summary>

        public bool Deleted { get; }

        /// <summary>
        /// The binary data. This should probably be removed and a system set up to allow 
        /// for the contents of the frame to only be read if needed. So in place of the
        /// envelope there would be an index into the container file.
        /// </summary>
        public byte[] Data => DareEnvelope.Body;


        #endregion


        /// <summary>
        /// A deserialization reader for the data according to the encoding specified by 
        /// the container header.
        /// </summary>
        public JSONReader JSONReader => Data.JSONReader();

        ///<summary>The JSONObject.</summary>
        public JSONObject JsonObject => jsonObject ??
            JSONReader.ReadTaggedObject(JSONObject.TagDictionary).CacheValue(out jsonObject);

        JSONObject jsonObject;



        #region // Related records
        /// <summary>
        /// The previous object instance value for this object instance.
        /// </summary>
        public IPersistenceEntry Previous { get; }

        /// <summary>
        /// The first object instance value for this object instance.
        /// </summary>
        public IPersistenceEntry First { get;  }

        #endregion

        /// <summary>
        /// Constructor, creates an entry for the specified container header, data and previous relationship.
        /// </summary>
        /// <param name="containerHeader">Parsed container header from frame</param>
        /// <param name="previous">Link to previous value of this object</param>
        /// <param name="data">The binary data</param>
        /// <param name="item">The JSONObject serialized by <paramref name="data"/>.</param>
        public ContainerStoreEntry(Container container, DareEnvelope dareEnvelope, ContainerStoreEntry previous, JSONObject item=null) {
            Container = container;
            jsonObject = item;
            DareEnvelope = dareEnvelope;

            Deleted = ContentInfo.Event == ContainerPersistenceStore.EventDelete;

            Previous = previous;
            First = previous ?? this;
            }

        }

    }


