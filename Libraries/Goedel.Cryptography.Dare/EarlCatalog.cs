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
using System.Runtime.CompilerServices;

namespace Goedel.Cryptography.Dare;

public class EarlCatalog : EarlSequence {

    protected EarlCatalog(
        EarlStream stream) : base(stream) {
        }


    public static EarlCatalog<T> Create<T>(
    string fileName) where T : JsonObject, new() {
        var stream = EarlStream.Create(fileName, DareConstants.TypeIdentifierDareSequence);
        var result = new EarlCatalog<T>(stream);

        result.WriteInitial();

        return result;
        }

    public static EarlCatalog<T> Open<T>(
            string fileName) where T : JsonObject, new() {

        var stream = EarlStream.OpenReadWrite(fileName);
        var spool = new EarlCatalog<T>(stream);
        spool.ReadInitial();

        return spool;
        }





    }


public class EarlCatalog<T> : EarlCatalog where T : JsonObject, new() {

    /// <summary>The content tag for type <typeparam>T</typeparam>.</summary>
    public readonly string ContentType = GetContentType();

    public Dictionary<string, EarlEntryIndex<T>> EntriesById { get; } = [];

    public Dictionary<string, EarlEntryIndex<T>> EntriesBySecondaryId { get; } = [];

    public EarlCatalog(
                EarlStream stream) : base(stream) {
        }

    public static EarlCatalog<T> Create(
            string fileName) {
        var stream = EarlStream.Create(fileName, DareConstants.TypeIdentifierDareSequence);
        var result = new EarlCatalog<T>(stream);

        result.WriteInitial();

        return result;
        }

    private static string GetContentType() {
        var item = new T();
        return item._Tag;
        }


    public void GetMeta(EarlEntryIndex index) => GetValue(index);

    public T GetValue(EarlEntryIndex index) {

        // If we already have it, we can return
        if (index.JsonObject is not null) {
            return index.JsonObject as T;
            }

        var result = GetValue<T>(index);
        index.JsonObject = result;

        return result;
        }


    protected virtual void DeleteKeys(EarlEntryIndex<T> index) {
        EntriesById.Replace(index.PrimaryKey, index);
        if (index.SecondaryKeys != null) {
            foreach (var key in index.SecondaryKeys) {
                EntriesBySecondaryId.Remove(index.PrimaryKey);
                }
            }
        }

    protected virtual void UpdateKeys(EarlEntryIndex<T> index) {
        if (EntriesById.ContainsKey(index.PrimaryKey)) {
            foreach (var key in index.SecondaryKeys) {
                EntriesBySecondaryId.Remove(key);
                }
            }
        CreateKeys(index);
        }



    protected virtual void CreateKeys(EarlEntryIndex<T> index) {
        EntriesById.Replace(index.PrimaryKey, index);

        if (index.SecondaryKeys != null) {
            foreach (var key in index.SecondaryKeys) {
                EntriesBySecondaryId.Add(key, index);
                }
            }
        }

    public virtual EarlEntryIndex<T> Add(T item) {
        var contentMeta = new ContentMeta() {
            UniqueId = item._PrimaryKey,
            Event = "Add",
            Labels = item._SecondaryKeys

            };

        var result = Append(item, contentMeta);
        CreateKeys(result);

        //EntriesById.Add(item._PrimaryKey, result);

        //if (item._SecondaryKeys != null) {
        //    foreach (var key in item._SecondaryKeys) {
        //        EntriesBySecondaryId.Add(key, result);
        //        }
        //    }

        return result;
        }

    public virtual EarlEntryIndex<T> Update(T item) {
        var contentMeta = new ContentMeta() {
            UniqueId = item._PrimaryKey,
            Event = "Add"
            };
        var result = Append(item, contentMeta);

        UpdateKeys(result);

        //// Remove the old keys
        //if (TryGetMeta(item._PrimaryKey, out var index)) {
        //    foreach (var key in index.SecondaryKeys) {
        //        EntriesBySecondaryId.Remove(key);
        //        }
        //    }

        //// Add the new keys
        //EntriesById.Replace(item._PrimaryKey, result);
        //if (item._SecondaryKeys != null) {
        //    foreach (var key in item._SecondaryKeys) {
        //        EntriesBySecondaryId.Add(key, result);
        //        }
        //    }


        return result;
        }

    public virtual EarlEntryIndex<T> Delete(string id) {
        if (!TryGetMeta(id, out var index)) {
            return null;
            }
        var meta = index.JsonObject as T;

        var contentMeta = new ContentMeta() {
            UniqueId = id,
            Event = ProtocolConstants.SequenceEventDeleteTag
            };

        var result = Append<T>(null, contentMeta);
        result.Deleted = true;

        DeleteKeys(result);

        return result;
        }

    public bool TryGetMeta(string id, out EarlEntryIndex<T> index) {

        if (!EntriesById.TryGetValue(id, out index)) {
            return false;
            }
        if (index.Deleted) {
            return false;
            }

        GetValue(index);
        return true;
        }




    public bool TryGetById(string id, out T? result) {
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

    public bool TryGetBySecondaryId(string id, out T? result) {
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



    public bool ProcessEntry(EarlEntryIndex<T> index) {

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
    public override IEnumerable<EarlEntryIndex<T>> EntriesForward() => 
            new EarlEntryEnumerator<T>(this);

    /// <inheritdoc/>
    public override IEnumerable<EarlEntryIndex<T>> EntriesReverse() =>
        new EarlEntryEnumerator<T>(this, false, ProcessEntry);

    /// <summary>Read the entries in the sequence to fill the index.</summary>
    public void FillIndex() {
        foreach (var item in EntriesForward()) {
            }
        }


    }