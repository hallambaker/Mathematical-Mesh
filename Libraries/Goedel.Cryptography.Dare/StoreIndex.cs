using System;
using System.Collections;
using System.Collections.Generic;

using Goedel.Utilities;

namespace Goedel.Cryptography.Dare {

    /// <summary>
    /// Index entry for Item.
    /// </summary>
    public class ContainerStoreIndexEntry : IPersistenceIndexEntry {

        /// <summary>
        /// The associated persistence data.
        /// </summary>
        public IPersistenceEntry Data { get; private set; }

        ContainerStoreIndexEntry Previous;
        ContainerStoreIndexEntry Next;

        /// <summary>
        /// If true, this is the only entry in the list.
        /// </summary>
        public bool Singleton => Previous == null & Next == null;


        /// <summary>
        /// Implement the enumeration interface
        /// </summary>
        /// <returns>The enumerator</returns>
        public IEnumerator<IPersistenceIndexEntry> GetEnumerator() => throw new NotImplementedException();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Enumerator class. 
        /// </summary>
        class Enumerator : IEnumerator<IPersistenceIndexEntry> {

            ContainerStoreIndexEntry First;
            public IPersistenceIndexEntry Current { get; private set; }

            object IEnumerator.Current => Current;

            public Enumerator(IPersistenceIndexEntry First) {
                this.First = (ContainerStoreIndexEntry)First;
                Current = (ContainerStoreIndexEntry)First;
                }

            public void Dispose() {
                }

            public bool MoveNext() {
                Current = ((ContainerStoreIndexEntry)Current)?.Next;
                return Current != null;
                }

            public void Reset() => Current = First;
            }

        /// <summary>
        /// Insert a new Index entry to a list of index entries
        /// </summary>
        /// <param name="Existing">The entry that will becomd the Previous entry,
        /// if null, starts a new list.</param>
        /// <param name="EntryData">The entry data for the new index value.</param>
        public ContainerStoreIndexEntry(ContainerStoreIndexEntry Existing, IPersistenceEntry EntryData) {
            Data = EntryData;

            Previous = Existing;
            if (Existing == null) {
                Next = null;
                }
            else if (Existing.Next == null) {
                Next = null;
                Previous = Existing;
                }
            else {
                Previous = Existing;
                Next = Existing.Next;
                Existing.Next = this;
                if (Next != null) {
                    Next.Previous = this;
                    }
                }
            }

        /// <summary>
        /// Insert a new Index entry to a list of index entries.
        /// </summary>
        /// <param name="Existing">The entry that will becomd the Previous entry,
        /// if null, starts a new list.</param>
        /// <param name="EntryData">The entry data for the new index value.</param>
        /// <returns>The new entry.</returns>
        public IPersistenceIndexEntry Insert(IPersistenceIndexEntry Existing, IPersistenceEntry EntryData) =>
                new ContainerStoreIndexEntry((ContainerStoreIndexEntry)Existing, EntryData);


        /// <summary>
        /// Remove an entry from a list of index entries.
        /// </summary>
        /// <param name="Entry"></param>
        public void Remove(IPersistenceIndexEntry Entry) {
            if (Next != null) {
                Next.Previous = Previous;
                }
            if (Previous != null) {
                Previous.Next = Next;
                }


            }

        }


    /// <summary>
    /// In-memory index structure for container data store. This offers the best performance
    /// but at a significantly higher memory overhead than an index-on disk approach.
    /// </summary>
    public class StoreIndex : IPersistenceIndex {

        Dictionary<string, ContainerStoreIndexEntry> Dictionary =
                    new();


        /// <summary>
        /// The set of object instances that match the specified value.
        /// </summary>
        /// <param name="Value">The value to match</param>
        /// <returns>The object instance if found, otherwise false.</returns>
        public IPersistenceIndexEntry Last(string Value) {
            var Found = Dictionary.TryGetValue(Value, out var Result);
            return Result;
            }


        /// <summary>
        /// Add an entry to the index.
        /// </summary>
        /// <param name="ContainerStoreEntry">The entry to add.</param>
        /// <param name="Value">The value to add it to</param>
        public void Add(StoreEntry ContainerStoreEntry, string Value) {
            var Found = Dictionary.TryGetValue(Value, out var Existing);
            var New = new ContainerStoreIndexEntry(Existing, ContainerStoreEntry);

            if (Found) {
                Dictionary.Remove(Value);
                }
            Dictionary.Add(Value, New);
            }

        /// <summary>
        /// Remove an entry from the index.
        /// </summary>
        /// <param name="ContainerStoreEntry">The entry to remove.</param>
        /// <param name="Value">The value to remove it from</param>
        public void Delete(StoreEntry ContainerStoreEntry, string Value) {
            var Found = Dictionary.TryGetValue(Value, out var Existing);
            if (!Found) {
                return;
                }

            if (Existing.Singleton) {
                Dictionary.Remove(Value);
                }
            else {
                // find the location of the specific entry
                throw new NYI();
                }

            }

        }

    }


