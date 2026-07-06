#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Goedel.Cryptography.Dare;

/// <summary>DARE Catalog using the EARL encoding scheme.</summary>
public abstract class EarlCatalog : VDareSequence {

    /// <summary>Constructor, read from the stream <paramref name="stream"/></summary>
    /// <param name="stream">The stream to read.</param>
    protected EarlCatalog(
        VDareStream stream) : base(stream) {

        }

    /// <summary>Create a new catalog of type <typeparamref name="T"/></summary>
    /// <typeparam name="T">The type of the catalog data.</typeparam>
    /// <param name="fileName">The name of the catalog on disk.</param>
    /// <returns>The created catalog instance.</returns>
    public static EarlCatalog<T> Create<T>(
    string fileName) where T : JsonObject, new() {
        var stream = VDareStream.Create(fileName, DareConstants.TypeIdentifierDareSequence);
        var result = new EarlCatalog<T>(stream);

        result.WriteInitial();

        return result;
        }

    /// <summary>Open a catalog of type <typeparamref name="T"/></summary>
    /// <typeparam name="T">The type of the catalog data.</typeparam>
    /// <param name="fileName">The name of the catalog on disk.</param>
    /// <returns>The created catalog instance.</returns>
    public static EarlCatalog<T> Open<T>(
            string fileName) where T : JsonObject, new() {

        var stream = VDareStream.OpenReadWrite(fileName);
        var spool = new EarlCatalog<T>(stream);
        spool.ReadInitial();


        return spool;
        }

    }

/// <summary>Typed DARE Catalog using the EARL encoding scheme.</summary>
public class EarlCatalog<T> : EarlCatalog where T : JsonObject, new() {

    /// <summary>The content tag for type <typeparam>T</typeparam>.</summary>
    public readonly string ContentType = GetContentType();

    /// <summary>The entries by the primary key.</summary>
    public Dictionary<string, VDareEntryIndex<T>> EntriesById { get; } = [];

    /// <summary>The entries by the secondary key.</summary>
    public Dictionary<string, VDareEntryIndex<T>> EntriesBySecondaryId { get; } = [];

    /// <summary>The entry descriptors.</summary>
    public LinkedList<VDareEntryIndex<T>> Entries { get; } = [];

    /// <summary>Constructor, return a new catalog reading and writing to 
    /// <paramref name="stream"/>.</summary>
    /// <param name="stream">The reader/writer stream.</param>
    public EarlCatalog(
                VDareStream stream) : base(stream) {
        }


    /// <inheritdoc/>
    protected override void Initialize() {

        base.Initialize();

        foreach (var item in new VEntryEnumerator<T>(this, false, ProcessEntry)) {
            Entries.AddFirst(item);
            }
        }

    private static string GetContentType() {
        var item = new T();
        return item._Tag;
        }

    /// <summary>Return the value of the catalog entry with index <paramref name="index"/>.</summary>
    /// <param name="index">The index of the entry to return.</param>
    /// <returns>The value of the index entry.</returns>
    public T GetValue(VDareEntryIndex index) {

        // If we already have it, we can return
        if (index.JsonObject is not null) {
            return index.JsonObject as T;
            }

        var result = GetValue<T>(index);
        index.JsonObject = result;

        return result;
        }

    /// <summary>Delete keys associated with index entry <paramref name="index"/></summary>
    /// <param name="index">The index entry whose keys are to be deleted.</param>
    protected virtual void DeleteKeys(VDareEntryIndex<T> index) {
        //GetMeta(index);

        EntriesById.Replace(index.PrimaryKey, index);
        if (index.SecondaryKeys != null) {
            foreach (var key in index.SecondaryKeys) {
                EntriesBySecondaryId.Remove(index.PrimaryKey);
                }
            }
        }

    /// <summary>Update the index with keys from <paramref name="index"/>.</summary>
    /// <param name="index">The index entry specifying the keys.</param>
    protected virtual void UpdateKeys(VDareEntryIndex<T> index) {
        if (EntriesById.ContainsKey(index.PrimaryKey)) {
            foreach (var key in index.SecondaryKeys) {
                EntriesBySecondaryId.Remove(key);
                }
            }
        CreateKeys(index);
        }


    /// <summary>Create keys for <paramref name="index"/></summary>
    /// <param name="index">The index entry specifying the keys.</param>
    protected virtual void CreateKeys(VDareEntryIndex<T> index) {

        EntriesById.Replace(index.PrimaryKey, index);

        if (index.SecondaryKeys != null) {
            foreach (var key in index.SecondaryKeys) {
                EntriesBySecondaryId.Add(key, index);
                }
            }
        }

    /// <summary>Add the new entry <paramref name="item"/>.</summary>
    /// <param name="item">The entry to add.</param>
    /// <returns>The index of the created item.</returns>
    public virtual VDareEntryIndex<T> Add(T item) {


        var contentMeta = new ContentMeta() {
            UniqueId = item._PrimaryKey,
            Event = "Add",
            Labels = item._SecondaryKeys

            };

        var result = Append(item, contentMeta);
        Entries.AddLast(result);
        CreateKeys(result);

        return result;
        }

    /// <summary>Update the entry <paramref name="item"/>.</summary>
    /// <param name="item">The entry to update.</param>
    /// <returns>The index of the created item.</returns>
    public virtual VDareEntryIndex<T> Update(T item) {
        var contentMeta = new ContentMeta() {
            UniqueId = item._PrimaryKey,
            Event = "Add"
            };
        var result = Append(item, contentMeta);
        Entries.AddLast(result);

        UpdateKeys(result);

        return result;
        }

    /// <summary>Delete the entry <paramref name="id"/>.</summary>
    /// <param name="id">The primary key of the entry to delete.</param>
    /// <returns>The index of the deletion entry.</returns>
    public virtual VDareEntryIndex<T> Delete(string id) {
        if (!TryGetMeta(id, out var index)) {
            return null;
            }
        var meta = index.JsonObject as T;

        var contentMeta = new ContentMeta() {
            UniqueId = id,
            Event = ProtocolConstants.SequenceEventDeleteTag
            };

        var result = Append<T>(null, contentMeta);
        Entries.AddLast(result);
        result.Deleted = true;

        DeleteKeys(index);

        return result;
        }

    /// <summary>Attempt to return the index entry for a catalog entry with primary key 
    /// <paramref name="id"/> returning true if and only if the entry is found.</summary>
    /// <param name="id">The primary key to find.</param>
    /// <param name="index">The matching entry if found, otherwise null.</param>
    /// <returns>true if the entry was found, otherwise null/</returns>
    public bool TryGetMeta(
                string id, 
                [NotNullWhen(true)] out VDareEntryIndex<T>? index) {

        if (!EntriesById.TryGetValue(id, out index)) {
            return false;
            }
        if (index.Deleted) {
            return false;
            }

        GetValue(index);
        return true;
        }



    /// <summary>Attempt to return the entry for a catalog entry with primary key 
    /// <paramref name="id"/> returning true if and only if the result is found.</summary>
    /// <param name="id">The primary key to find.</param>
    /// <param name="result">The matching entry if found, otherwise null.</param>
    /// <returns>true if the entry was found, otherwise null/</returns>
    public bool TryGetById(
                string id, 
                [NotNullWhen(true)] out T? result) {
        result = null;
        if (!EntriesById.TryGetValue(id, out var index)) {
            return false;
            }
        if (index.Deleted) {
            return false;
            }
        result = GetValue(index);
        return true;

        }

    /// <summary>Attempt to return the  entry for a catalog entry with secondary key 
    /// <paramref name="id"/> returning true if and only if the result is found.</summary>
    /// <param name="id">The primary key to find.</param>
    /// <param name="result">The matching entry if found, otherwise null.</param>
    /// <returns>true if the entry was found, otherwise null/</returns>
    public bool TryGetBySecondaryId(string id, [NotNullWhen(true)] out T? result) {
        result = null;
        if (!EntriesBySecondaryId.TryGetValue(id, out var index)) {
            return false;
            }
        if (index.Deleted) {
            return false;
            }
        result = GetValue(index);
        return true;
        }


    /// <summary>Process the catalog index entry <paramref name="index"/>.</summary>
    /// <param name="index">The entry to process..</param>
    /// <returns>True.</returns>
    public bool ProcessEntry(VDareEntryIndex<T> index) {

        var id = index.EarlEnvelope.SignedHeader.UniqueId;
        if (id is not null) {
            // Keep searching unless this is the occurrence in the index and not deleted.
            if (EntriesById.TryGetValue(id, out var entry)) {
                return entry.Deleted | entry != index;
                }
            UpdateKeys(index);
            //EntriesById.Add(id, index);
            index.Deleted = index.EarlEnvelope?.SignedHeader?.Event == ProtocolConstants.SequenceEventDeleteTag;
            return index.Deleted;
            }
        if (index.EarlEnvelope.SignedHeader.Event ==
                    ProtocolConstants.SequenceEventUpdatesTag) {
            }
        return true;
        }

    /// <inheritdoc/>
    public override IEnumerable<VDareEntryIndex<T>> EntriesForward() => 
           new VCatalogEnumerator<T>(this, true);

    /// <inheritdoc/>
    public override IEnumerable<VDareEntryIndex<T>> EntriesReverse() =>
           new VCatalogEnumerator<T>(this, false);


    }