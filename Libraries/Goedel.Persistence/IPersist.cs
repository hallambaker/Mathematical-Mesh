using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Goedel.Protocol;
using Goedel.Utilities;

namespace Goedel.Persistence {

    /// <summary>
    /// 
    /// </summary>
    public interface IPersistenceStoreRead {

        /// <summary>
        /// Return an index for the specified key, creating it if necessary.
        /// </summary>
        /// <param name="Key">The key for which the index is requested.</param>
        /// <param name="Create">If true, will create an index if none is found.</param>
        /// <returns>The index.</returns>
        IPersistenceIndex GetIndex (string Key, bool Create = true);

        /// <summary>
        /// Get object instance by unique identifier
        /// </summary>
        /// <param name="UniqueID">The unique identifier of the object instance to locate.</param>
        /// <returns>True if found, otherwise false.</returns>
        IPersistenceEntry Get (string UniqueID);

        /// <summary>
        /// Determines if a object instance with the specified unique identifier is registered.
        /// </summary>
        /// <param name="UniqueID">The unique identifier of the object instance to locate.</param>
        /// <returns>True if found, otherwise false.</returns>
        bool Contains (string UniqueID);


        /// <summary>
        /// The last object instance that matches the specified key/value condition.
        /// </summary>
        /// <param name="Key">The key</param>
        /// <param name="Value">The value to match</param>
        /// <returns>The object instance if found, otherwise false.</returns>
        IPersistenceIndexEntry Last (string Key, string Value);

        }

    /// <summary>
    /// 
    /// </summary>
    public interface IPersistenceStoreWrite : IPersistenceStoreRead {



        /// <summary>
        /// Add new JSON object to the store with the specified identifier, unique ID and keys.
        /// </summary>
        /// <param name="Object">Object to add.</param>
        IPersistenceEntry New (JSONObject Object);


        /// <summary>
        /// Add new JSON object to the store with the specified identifier, unique ID and keys.
        /// </summary>
        /// <param name="Object">Object to add.</param>
        /// <param name="Create">If true, create a new value if one does not already exist</param>
        IPersistenceEntry Update (JSONObject Object, bool Create = true);

        /// <summary>
        /// Delete a persistence entry
        /// </summary>
        /// <threadsafety static="true" instance="true"/>
        /// <param name="UniqueID">The UniqueID of the object to delete</param>
        /// <returns>True if the object was updated, otherwise false.</returns>
        bool Delete (string UniqueID);



        }


    /// <summary>
    /// Persistence store index
    /// </summary>
    public interface IPersistenceIndex {


        /// <summary>
        /// Return an IPersistenceIndexEntry index entry to the last object instance that matches 
        /// the specified value. Additional values may be obtained by calling an enumerator
        /// on the index entry.
        /// </summary>
        /// <param name="Value">The value to match</param>
        /// <returns>The index entry to the object instance if found, otherwise false.</returns>
        IPersistenceIndexEntry Last (string Value);

        }

    /// <summary>
    /// Persistence store index result. Contains a link to the current value and an 
    /// iterator over future values.
    /// </summary>
    public interface IPersistenceIndexEntry : IEnumerable<IPersistenceIndexEntry> {


        /// <summary>
        /// The Data Entry.
        /// </summary>
        IPersistenceEntry Data { get; }

        /// <summary>
        /// Insert a new Index entry to a list of index entries.
        /// </summary>
        /// <param name="Existing">The entry that will becomd the Previous entry,
        /// if null, starts a new list.</param>
        /// <param name="EntryData">The entry data for the new index value.</param>
        /// <returns>The new entry.</returns>
        IPersistenceIndexEntry Insert (IPersistenceIndexEntry Existing, IPersistenceEntry EntryData);


        /// <summary>
        /// Remove an entry from a list of index entries.
        /// </summary>
        /// <param name="Entry"></param>
        void Remove (IPersistenceIndexEntry Entry);

        }



    /// <summary>
    /// Persistence store entry
    /// </summary>
    public interface IPersistenceEntry {

        /// <summary>
        /// Unique identifier of entry;
        /// </summary>
        string UniqueID { get; }

        /// <summary>
        /// If true the object haws been deleted and cannot be further modified.
        /// </summary>
        bool Deleted { get; }

        /// <summary>
        /// The time at which the object instance was created.
        /// </summary>
        DateTime Created { get; }

        /// <summary>
        /// The time at which the object instance value was created. 
        /// </summary>
        DateTime Modified { get; }

        /// <summary>
        /// The binary data
        /// </summary>
        byte[] Data { get; }

        /// <summary>
        /// A deserialization reader for the data according to the encoding specified by 
        /// the container header.
        /// </summary>
        JSONReader JSONReader { get; }

        /// <summary>
        /// The previous object instance value for this object instance.
        /// </summary>
        IPersistenceEntry Previous { get; }

        /// <summary>
        /// The first object instance value for this object instance.
        /// </summary>
        IPersistenceEntry First { get; }





        }


    }
