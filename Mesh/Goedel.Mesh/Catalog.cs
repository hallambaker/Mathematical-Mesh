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



using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using System.Collections;

namespace Goedel.Mesh;

#region // The data classes Catalog, CatalogedEntry

/// <summary>
/// Base class for catalogs.
/// </summary>
public abstract class Catalog<T> : Store, IEnumerable<T>  where T : CatalogedEntry {

    ///<summary>Class exposing the Mesh Client locate interface.</summary>
    public IMeshClient MeshClient;

    ///<summary>The persistence store.</summary>
    public PersistenceStore PersistenceStore { get; set; } = null;


    ///<summary>Return an enumeration over the object collection.</summary> 
    public IEnumerable<T> GetEntries => 
            new PersistenceStoreEnumerateObject<T>(PersistenceStore.ObjectIndex);

    bool InternEntry { get; } = false;

    /// <summary>
    /// Returns an enumerator over the catalog entries. Most catalog classes offer typed
    /// enumerators as an alternative.
    /// </summary>
    /// <returns>The enumerator.</returns>
    public IEnumerator<T> GetEnumerator() => 
                new PersistenceStoreEnumerateObject<T>(PersistenceStore.ObjectIndex);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();
    private IEnumerator GetEnumerator1() => this.GetEnumerator();

    ///<inheritdoc/>
    public override SequenceIndexEntryFactoryDelegate SequenceIndexEntryFactory => CatalogIndexEntry<T>.Factory;

    ///<summary>Dictionary mapping local names to the corresponding catalog entries.</summary> 
    public Dictionary<string, T> DictionaryByLocalName { get; } = new();


    /// <summary>
    /// Disposal method, disposes the underlying persistence store if defined.
    /// </summary>
    protected override void Disposing() {
        PersistenceStore?.Dispose();
        base.Disposing();
        }

    /// <summary>
    /// Base constuctor.
    /// </summary>
    /// <param name="directory">Directory to create the catalog in.</param>
    /// <param name="containerName">Sequence name.</param>
    /// <param name="cryptoParameters">Cryptographic parameters.</param>
    /// <param name="policy">The cryptographic policy to be applied to the container.</param>
    /// <param name="keyCollection">Key collection to use for decryption.</param>
    /// <param name="meshClient">Parent account context used to obtain a mesh client.</param>
    /// <param name="read">If true, read the container.</param>
    /// <param name="decrypt">If true, attempt decryption of bodies to payloads.</param>
    /// <param name="create">If true, create a container if it does not already exist.</param>
    /// <param name="bitmask">The bitmask to identify the store for filtering purposes.</param>
    public Catalog(string directory, string containerName,
                 DarePolicy? policy = null,
                CryptoParameters? cryptoParameters = null,
                IKeyCollection? keyCollection = null,
                IMeshClient? meshClient = null,
                bool read = true,
                bool decrypt = true,
                bool create = true,
                byte[] bitmask = null) :
            base(directory, containerName, policy, cryptoParameters, keyCollection, 
                decrypt: decrypt, create: create, bitmask: bitmask) {

        if (!create & Sequence == null) {
            return;
            }
        MeshClient = meshClient;

        PersistenceStore = new PersistenceStore(Sequence, keyCollection, read);
        Intern(Sequence.SequenceIndexEntryFirst);
        if (Sequence.SequenceIndexEntryFirst !=  Sequence.SequenceIndexEntryLast) {
            Intern(Sequence.SequenceIndexEntryLast);
            }

        if (read) {
            PersistenceStore.Read();
            }

        Complete();
        InternEntry = true;
       }

    #region // Update entries in the catalog
    ///<inheritdoc/>
    public override void Intern(
                SequenceIndexEntry indexEntry) {
        PersistenceStore?.Intern(indexEntry);
        if (InternEntry) {
            InternCatalog(indexEntry as CatalogIndexEntry<T>);
            }
        }


    protected virtual void InternCatalog(CatalogIndexEntry<T> catalogIndexEntry) {
        var catalogedEntry = catalogIndexEntry.JsonObject as T;

        switch (catalogIndexEntry.SequenceEvent) {
            case SequenceEvent.New: {
                NewEntry(catalogedEntry);
                break;
                }
            case SequenceEvent.Update: {
                UpdateEntry(catalogedEntry);
                break;
                }
            case SequenceEvent.Delete: {
                DeleteEntry(catalogedEntry._PrimaryKey);
                break;
                }
            }
        }

    public virtual void Complete() {
        foreach (var entry in PersistenceStore.ObjectIndex) {
            InternCatalog(entry.Value as CatalogIndexEntry<T>);
            }
        }

    #endregion
    #region // Public interfaces to Add/Update/Delete typed catalog entry to the catalog
    /// <summary>
    /// Add <paramref name="catalogEntry"/> to the catalog as a new entry.
    /// </summary>
    /// <param name="catalogEntry">The entry to add.</param>
    public void New(T catalogEntry) {
        var envelope = PersistenceStore.PrepareNew(catalogEntry);
        PersistenceStore.Apply(envelope);
        }

    /// <summary>
    /// Update <paramref name="catalogEntry"/> in the catalog.
    /// </summary>
    /// <param name="catalogEntry">The entry to update.</param>
    /// <param name="encryptionKey">Key under which the item is to be encrypted.</param>
    public void Update(T catalogEntry, CryptoKey encryptionKey = null) {
        var envelope = PersistenceStore.PrepareUpdate(out _, catalogEntry, encryptionKey: encryptionKey);
        PersistenceStore.Apply(envelope);
        }

    /// <summary>
    /// Delete <paramref name="catalogEntry"/> from the catalog.
    /// </summary>
    /// <param name="catalogEntry">The entry to delete.</param>
    public void Delete(T catalogEntry) {
        var envelope = PersistenceStore.PrepareDelete(out _, catalogEntry._PrimaryKey);
        PersistenceStore.Apply(envelope);
        }
    #endregion
    #region // Protected interfaces that perform the actual Add/Update/Delete function.

    /// <summary>
    /// Callback called before adding a new entry to the catalog. May be overriden in 
    /// derrived classes to update local indexes.
    /// </summary>
    /// <param name="catalogedEntry">The entry being added.</param>
    protected virtual void NewEntry(T catalogedEntry) => UpdateEntry(catalogedEntry);

    /// <summary>
    /// Callback called before updating an entry in the catalog. May be overriden in 
    /// derrived classes to update local indexes.
    /// </summary>
    /// <param name="catalogedEntry">The entry being updated.</param>
    protected virtual void UpdateEntry(T catalogedEntry) {
        if (catalogedEntry.LocalName != null) {
            DictionaryByLocalName.Remove(catalogedEntry.LocalName);
            DictionaryByLocalName.Add(catalogedEntry.LocalName, catalogedEntry);
            }
        }

    /// <summary>
    /// Callback called before deleting an entry from the catalog. May be overriden in 
    /// derrived classes to update local indexes.
    /// </summary>
    /// <param name="key">The entry being deleted.</param>
    protected virtual void DeleteEntry(string key) {
        var entry = PersistenceStore.Get(key)?.JsonObject as T;
        if (entry?.LocalName != null) {
            DictionaryByLocalName.Remove(entry.LocalName);
            }
        }



    #endregion
    #region Query functions
    /// <summary>
    /// Return the catalogued entry with key <paramref name="key"/> as the catalogued type.
    /// </summary>
    /// <param name="key">Unique identifier of the device to return.</param>
    /// <returns>The <see cref="CatalogedDevice"/> entry.</returns>
    public virtual T Get(string key) => Locate(key) as T;

    /// <summary>
    /// Get default instance of type <typeparamref name="TT"/>
    /// </summary>
    /// <typeparam name="TT">The parameter type to return.</typeparam>
    /// <returns>The instance if found, otherwise null.</returns>
    public virtual TT GetDefault<TT>() where TT : class {

        foreach (var entry in this) {
            if (entry is TT result) {
                return result;
                }
            }

        return default;
        }

    /// <summary>
    /// Locate the entry with key <paramref name="key"/>.
    /// </summary>
    /// <param name="key">Unique identifier of the entry to locate.</param>
    /// <returns>The entry (if found).</returns>
    public T Locate(string key) {
        if (DictionaryByLocalName.TryGetValue(key, out var value)) {
            return value as T;
            }
        return PersistenceStore.Get(key)?.JsonObject as T;
        }

    #endregion
    #region // Methods to add from other syntaxes

    /// <summary>
    /// 
    /// </summary>
    /// <param name="stream">The stream to fetch the contact data from.</param>
    /// <param name="format">The file format to write the output in.</param>
    /// <returns>The catalog entry</returns>
    public virtual T ReadFromStream(
                Stream stream,
                CatalogedEntryFormat format = CatalogedEntryFormat.Unknown) {
        switch (format) {
            case CatalogedEntryFormat.Unknown:
            case CatalogedEntryFormat.Default: {
                using var reader = new JsonBcdReader(stream);
                var result = CatalogedEntry.FromJson(reader, true);
                return result as T;
                }
            }

        // here do the dare format

        // format is not supported

        throw new NYI();
        }


    #endregion
    #region // Debugging

    /// <summary>
    /// Write the 
    /// </summary>
    public void Dump(TextWriter output = null) {
        output ??= Console.Out;

        // Dump the title
        output.WriteLine($"Catalog: {SequenceDefault}");

        foreach (var envelope in Sequence) {
            var header = envelope.Header;
            var trailer = envelope.Trailer;
            var signatures = trailer?.Signatures ?? header?.Signatures;

            // give the status
            if (header?.SequenceInfo is var containerInfo) {
                output.WriteLine($"   Index: {containerInfo.LIndex} Tree: {containerInfo.TreePosition}");
                }
            else {
                output.WriteLine("    ############ Invalid");
                }

            if (header?.EncryptionAlgorithm != null) {
                output.WriteLine($"       Encrypted: {header?.EncryptionAlgorithm}");

                if (header?.Recipients != null) {
                    foreach (var recipient in header?.Recipients) {
                        output.WriteLine($"       Recipient: {recipient.KeyIdentifier}");
                        }

                    }
                }
            if (header?.DigestAlgorithm != null) {
                output.WriteLine($"       Digest: {header?.DigestAlgorithm}");

                if (signatures != null) {
                    foreach (var recipient in signatures) {
                        output.WriteLine($"       Signer: {recipient.KeyIdentifier}");
                        }
                    }
                }
            }
        }

    #endregion

    #region // Hot Mess

    /// <summary>
    /// Append the envelopes <paramref name="envelope"/> to the
    /// store.
    /// </summary>
    public override SequenceIndexEntry AppendDirect(DareEnvelope envelope, bool updateEnvelope = false) {

        return Sequence.Append(envelope, updateEnvelope);

        //// This is not viable because the envelope that is applied has to be the container
        //// envelope;
        //var storeEntry = Apply(envelope);
        //if (storeEntry.JsonObject != null) {
        //    UpdateLocal(storeEntry.JsonObject as T);
        //    }
        //else {
        //    }
        }




    /// <summary>
    /// Return the entry with unique identifier <paramref name="key"/>.
    /// </summary>
    /// <param name="key">Unique identifier of entry to return.</param>
    /// <returns>The entry.</returns>
    public CatalogIndexEntry<T> GetEntry(string key) => PersistenceStore.Get(key) as CatalogIndexEntry<T>;

    #endregion

    }



#endregion

