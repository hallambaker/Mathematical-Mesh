

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Goedel.Protocol;
using Goedel.Utilities;

namespace Goedel.Persistence {
    // A persistence store consists of a set of DataItems which are
    // indexed via multiple indexes.

    // The persistence store provides ACID guarantees but does not 
    // support the entity-relational data model or SQL.

    // Currently, locking is performed at the global level. This is 
    // overly restrictive for the type of operations required in a 
    // service oriented architecture.

    // Each store may be indexed through multiple indicies as follows
    //     Type.Tag.Value
    // E.g. 
    //     A store has types "acc" and "udf" for account and fingerprint
    //     The "acc" Type has Tags "alice@example.com", "bob@example.com"
    //     The "alice@example.com" Tag has a set of values

    // ToDo: Audit the locking strategy properly


    /// <summary>
    /// A collection of data items. 
    /// </summary>
    public class DataCollection {
        /// <summary>
        /// The items in the collection.
        /// </summary>
        public List<DataItem> DataItems = new List<DataItem> ();

        /// <summary>
        /// Construct a data collection with the specified member.
        /// </summary>
        /// <param name="DataItem">Initial member</param>
        public DataCollection(DataItem DataItem) {
            Add(DataItem);
            }

        /// <summary>
        /// Add the specified member to the collection.
        /// </summary>
        /// <param name="DataItem">Data item to add</param>
        public void Add(DataItem DataItem) {
            DataItems.Add (DataItem);
            }
        }

    /// <summary>
    /// Tracks persistent objects by unique identifier
    /// </summary>
    public class PersistenceObjectIndex {

        /// <summary>
        /// Dictionary mapping keys to object instances.
        /// </summary>
        public SortedDictionary<string, DataItem> Dictionary =
            new SortedDictionary<string, DataItem>();

        /// <summary>
        /// Default constructor
        /// </summary>
        public PersistenceObjectIndex () {

            }

        /// <summary>
        /// Add data item to the dictonary, overwriting the existing version
        /// if any.
        /// </summary>
        /// <param name="DataItem">Data item to add.</param>
        public virtual void Add(DataItem DataItem) {
            Dictionary.Remove(DataItem.PrimaryKey);
            Dictionary.AddSafe(DataItem.PrimaryKey, DataItem); // NYI check if null

            return;
            }

        /// <summary>
        /// Find the data collection with the specified key value.
        /// </summary>
        /// <param name="Value">Key value to find.</param>
        /// <returns>True if key found, otherwise false.</returns>
        public virtual bool Contains(string Value) {
            return Dictionary.ContainsKey(Value);
            }

        /// <summary>
        /// Find the data collection with the specified key value.
        /// </summary>
        /// <param name="Value">Key value to find.</param>
        /// <returns>Data item if found.</returns>
        public virtual DataItem Get(string Value) {

            if (Dictionary.TryGetValue(Value, out var Result)) {
                return Result;
                }

            return null;
            }

        }



    /// <summary>
    /// Index to data in a persistence store using in-memory index.
    /// </summary>
    public class PersistenceIndex {
        /// <summary>
        /// Persistence store this index belongs to.
        /// </summary>
        public PersistenceStore Parent;

        /// <summary>
        /// Type of data being indexed
        /// </summary>
        public string Type;

        /// <summary>
        /// Dictionary mapping keys to data collections.
        /// </summary>
        public SortedDictionary<string, DataCollection> DictionaryKeyId =
                new SortedDictionary<string, DataCollection>();

        /// <summary>
        /// Construct a new index for the specified store to index data of the
        /// specified type.
        /// </summary>
        /// <param name="Parent">Persistence store to be indexed.</param>
        /// <param name="Type">Type of data to index.</param>
        public PersistenceIndex(PersistenceStore Parent, string Type) {
            this.Parent = Parent;
            this.Type = Type;
            }

        /// <summary>
        /// Find the data collection with the specified key value.
        /// </summary>
        /// <param name="Value">Key value to find.</param>
        /// <returns>True if value found, otherwise null.</returns>
        public virtual bool Contains(string Value) {
            return DictionaryKeyId.ContainsKey(Value);
            }


        /// <summary>
        /// Find the data collection with the specified key value.
        /// </summary>
        /// <param name="Value">Key value to find.</param>
        /// <returns>The data collection if found, null otherwise.</returns>
        public virtual DataCollection Get(string Value) {


            if (DictionaryKeyId.TryGetValue (Value, out var Result))  {
                return Result;
                }

            return null;
            }

        /// <summary>
        /// Get the most recently added value with a specified key.
        /// </summary>
        /// <param name="Value">Key value to find.</param>
        /// <returns>The data collection if found, null otherwise.</returns>
        public virtual DataItem GetLast (string Value) {
            var Collection = Get(Value);
            if (Collection == null) {
                return null;
                }

            return Collection.DataItems.Last();
            }


        }

    }
