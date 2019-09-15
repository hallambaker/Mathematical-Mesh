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
        Container Container;

        /////<summary>The enveloped data</summary>
        //public DareEnvelope DareEnvelope;

        ///<summary>The envelope header</summary>
        public DareHeader ContainerHeader; //=> DareEnvelope.Header as ContainerHeader;

        ///<summary>The envelope metadata</summary>
        public ContentMeta ContentInfo => ContainerHeader.ContentMeta;

        ///<summary>Unique identifier of entry;</summary>
        public string UniqueID => ContentInfo?.UniqueID;

        ///<summary>The container frame</summary>
        public long FrameCount => ContainerHeader.ContainerInfo.Index;

        ///<summary>If true the object haws been deleted and cannot be further modified.</summary>

        public bool Deleted => ContentInfo?.Event == ContainerPersistenceStore.EventDelete;

        ///<summary>The JSONObject.</summary>
        public JSONObject JsonObject => jsonObject ?? FrameIndex.GetJSONObject(Container).CacheValue(out jsonObject);
        JSONObject jsonObject;

        ///<summary>The frame index within the container</summary>
        public ContainerFrameIndex FrameIndex;
        
        #endregion
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
        /// <param name="dareEnvelope">The envelope entry.</param>
        /// <param name="previous">Link to previous value of this object</param>
        /// <param name="item">The JSONObject representation.</param>
        public ContainerStoreEntry(Container container, 
                    DareEnvelope dareEnvelope, 
                    ContainerStoreEntry previous, 
                    JSONObject item=null) {
            Container = container;
            jsonObject = item;

            ContainerHeader = dareEnvelope.Header as DareHeader;
            //DareEnvelope = dareEnvelope;

            Previous = previous;
            First = previous?.First ?? this;
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frameIndex">The position of the entry within the container frame.</param>
        /// <param name="previous">Link to previous value of this object</param>
        /// <param name="container"></param>
        /// <param name="item">The JSONObject representation.</param>
        public ContainerStoreEntry(
                    ContainerFrameIndex frameIndex, 
                    ContainerStoreEntry previous, 
                    Container container,
                    JSONObject item = null) {
            Container = container;
            ContainerHeader = frameIndex.Header;



            FrameIndex = frameIndex;
            jsonObject = item;

            Previous = previous;
            First = previous?.First ?? this;
            }


        }

    }


