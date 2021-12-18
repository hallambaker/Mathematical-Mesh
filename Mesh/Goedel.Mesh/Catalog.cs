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



using System.Collections;

namespace Goedel.Mesh;

#region // The data classes Catalog, CatalogedEntry

/// <summary>
/// Base class for catalogs.
/// </summary>
public abstract class Catalog<T> : Store, IEnumerable<CatalogedEntry>
            where T : CatalogedEntry {

    ///<summary>Class exposing the Mesh Client locate interface.</summary>
    public IMeshClient MeshClient;


    ///<summary>The persistence store.</summary>
    public PersistenceStore PersistenceStore { get; set; } = null;


    ///<summary>Enumerate the catalog as the cataloged type.</summary>
    public AsCatalogedType<T> AsCatalogedType =>
            new(PersistenceStore);


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
    /// <param name="containerName">Container name.</param>
    /// <param name="cryptoParameters">Cryptographic parameters.</param>
    /// <param name="policy">The cryptographic policy to be applied to the container.</param>
    /// <param name="keyCollection">Key collection to use for decryption.</param>
    /// <param name="meshClient">Parent account context used to obtain a mesh client.</param>
    /// <param name="readContainer">If true, read the container.</param>
    /// <param name="decrypt">If true, attempt decryption of bodies to payloads.</param>
    /// <param name="create">If true, create a container if it does not already exist.</param>
    public Catalog(string directory, string containerName,
                 DarePolicy policy = null,
                CryptoParameters cryptoParameters = null,
                IKeyCollection keyCollection = null,
                IMeshClient meshClient = null,
                bool readContainer = true,
                bool decrypt = true,
                bool create = true) :
            base(directory, containerName, policy, cryptoParameters, keyCollection, decrypt: decrypt, create: create) {

        if (!create & Container == null) {
            return;
            }
        MeshClient = meshClient;

        PersistenceStore = new PersistenceStore(Container, keyCollection, readContainer);

        if (readContainer) {
            foreach (var indexEntry in PersistenceStore.ObjectIndex) {
                var objectData = indexEntry.Value.JsonObject as T;
                NewEntry(objectData);
                }
            }

        }

    /// <summary>
    /// Append the envelopes <paramref name="envelope"/> to the
    /// store.
    /// </summary>
    public override void AppendDirect(DareEnvelope envelope, bool updateEnvelope = false) {
        //var index = Container.Append(envelope, updateEnvelope);

        // This is not viable because the envelope that is applied has to be the container
        // envelope;
        Apply(envelope);

        }


    /// <summary>
    /// Callback called before adding a new entry to the catalog. May be overriden in 
    /// derrived classes to update local indexes.
    /// </summary>
    /// <param name="catalogedEntry">The entry being added.</param>
    public virtual void NewEntry(T catalogedEntry) { }

    /// <summary>
    /// Callback called before updating an entry in the catalog. May be overriden in 
    /// derrived classes to update local indexes.
    /// </summary>
    /// <param name="catalogedEntry">The entry being updated.</param>
    public virtual void UpdateEntry(T catalogedEntry) { }

    /// <summary>
    /// Callback called before deleting an entry from the catalog. May be overriden in 
    /// derrived classes to update local indexes.
    /// </summary>
    /// <param name="Key">The entry being deleted.</param>
    public virtual void DeleteEntry(string Key) { }


    // Test: Check what happens when an attempt is made to perform conflicting updates to a store.

    /// <summary>
    /// Apply the update in <paramref name="dareMessage"/> to the persistence store.
    /// </summary>
    /// <param name="dareMessage">The update to apply.</param>
    public void Apply(DareEnvelope dareMessage) => PersistenceStore.Apply(dareMessage);



    /// <summary>
    /// Add <paramref name="catalogEntry"/> to the catalog as a new entry.
    /// </summary>
    /// <param name="catalogEntry">The entry to add.</param>
    public void New(T catalogEntry) {
        var envelope = PersistenceStore.PrepareNew(catalogEntry);
        PersistenceStore.Apply(envelope);
        NewEntry(catalogEntry);
        }


    /// <summary>
    /// Update <paramref name="catalogEntry"/> in the catalog.
    /// </summary>
    /// <param name="catalogEntry">The entry to update.</param>
    /// <param name="encryptionKey">Key under which the item is to be encrypted.</param>
    public void Update(T catalogEntry, CryptoKey encryptionKey = null) {
        var envelope = PersistenceStore.PrepareUpdate(out _, catalogEntry, encryptionKey: encryptionKey);
        PersistenceStore.Apply(envelope);
        UpdateEntry(catalogEntry);
        }

    /// <summary>
    /// Delete <paramref name="catalogEntry"/> from the catalog.
    /// </summary>
    /// <param name="catalogEntry">The entry to delete.</param>
    public void Delete(T catalogEntry) {
        var envelope = PersistenceStore.PrepareDelete(out _, catalogEntry._PrimaryKey);
        PersistenceStore.Apply(envelope);
        DeleteEntry(catalogEntry._PrimaryKey);
        }

    /// <summary>
    /// Return the catalogued entry with key <paramref name="key"/> as the catalogued type.
    /// </summary>
    /// <param name="key">Unique identifier of the device to return.</param>
    /// <returns>The <see cref="CatalogedDevice"/> entry.</returns>
    public virtual T Get(string key) => Locate(key) as T;

    /// <summary>
    /// Add the catalog entry data speficied in the stream <paramref name="stream"/>. If 
    /// <paramref name="merge"/> is true, merge this contact information.
    /// </summary>
    /// <param name="stream">The stream to fetch the contact data from.</param>
    /// <param name="format">The file format to write the output in.</param>
    /// <param name="localName">Short name for the contact to distinguish it from
    /// others.</param>
    /// <param name="merge">Add this data to the existing contact.</param>
    /// <returns>The catalog entry</returns>
    public T AddFromStream(
                Stream stream,
                CatalogedEntryFormat format = CatalogedEntryFormat.Unknown,
                bool merge = true,
                string localName = null) {
        merge.Future();
        localName.Future();

        if (ReadFromStream(stream, format).NotNull(out var entry)) {
            UpdateEntry(entry);
            return entry;
            }
        throw new NYI();
        }

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

        // here do the json format

        // format is not supported


        throw new NYI();
        }

    /// <summary>
    /// Read list of catalog entries from the file <paramref name="fileName"/> in format <paramref name="format"/>.
    /// </summary>
    /// <param name="fileName">The file to read from.</param>
    /// <param name="format">The file format</param>
    /// <returns>The list of entries read from the file.</returns>
    public virtual List<T> ReadListFromFile(
        string fileName,
        CatalogedEntryFormat format = CatalogedEntryFormat.Unknown) {
        fileName.Future();
        format.Future();

        // here do the dare format

        // here do the json format

        // format is not supported


        throw new NYI();
        }


    /// <summary>
    /// Locate the entry with key <paramref name="key"/>.
    /// </summary>
    /// <param name="key">Unique identifier of the entry to locate.</param>
    /// <returns>The entry (if found).</returns>
    public T Locate(string key) =>
        (PersistenceStore.Get(key) as StoreEntry)?.JsonObject as T;


    /// <summary>
    /// Return the entry with unique identifier <paramref name="key"/>.
    /// </summary>
    /// <param name="key">Unique identifier of entry to return.</param>
    /// <returns>The entry.</returns>
    public StoreEntry GetEntry(string key) => PersistenceStore.Get(key) as StoreEntry;


    /// <summary>
    /// Returns an enumerator over the catalog entries. Most catalog classes offer typed
    /// enumerators as an alternative.
    /// </summary>
    /// <returns>The enumerator.</returns>
    public IEnumerator<CatalogedEntry> GetEnumerator() => new EnumeratorCatalogEntry(PersistenceStore);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();
    private IEnumerator GetEnumerator1() => this.GetEnumerator();


    /// <summary>
    /// Write the 
    /// </summary>
    public void Dump(TextWriter output = null) {

        output ??= Console.Out;


        // Dump the title
        output.WriteLine($"Catalog: {ContainerDefault}");

        foreach (var envelope in Container) {
            var header = envelope.Header;
            var trailer = envelope.Trailer;
            var signatures = trailer?.Signatures ?? header?.Signatures;

            // give the status
            if (header?.SequenceInfo is var containerInfo) {
                output.WriteLine($"   Index: {containerInfo.Index} Tree: {containerInfo.TreePosition}");
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


    }



#endregion

#region // Enumerators and associated classes

/// <summary>
/// Enumerator class for sequences of <see cref="CatalogedEntry"/> over a persistence
/// store.
/// </summary>
public class EnumeratorCatalogEntry : IEnumerator<CatalogedEntry> {
    readonly IEnumerator<StoreEntry> baseEnumerator;

    ///<summary>The current item in the enumeration.</summary>
    public CatalogedEntry Current => baseEnumerator.Current.JsonObject as CatalogedEntry;
    object IEnumerator.Current => Current;

    /// <summary>
    /// Disposal method.
    /// </summary>
    public void Dispose() => baseEnumerator.Dispose();

    /// <summary>
    /// Move to the next item in the enumeration.
    /// </summary>
    /// <returns>The next item in the enumeration</returns>
    public bool MoveNext() => baseEnumerator.MoveNext();

    /// <summary>
    /// Restart the enumeration.
    /// </summary>
    public void Reset() => throw new NotImplementedException();

    /// <summary>
    /// Construct enumerator from <see cref="PersistenceStore"/>,
    /// <paramref name="persistenceStore"/>.
    /// </summary>
    /// <param name="persistenceStore">The persistence store to enumerate.</param>
    public EnumeratorCatalogEntry(PersistenceStore persistenceStore) =>
        baseEnumerator = persistenceStore.GetEnumerator();
    }
#endregion
