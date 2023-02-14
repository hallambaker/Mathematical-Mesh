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

namespace Goedel.Mesh;


/// <summary>
/// Factory delegate
/// </summary>
/// <param name="directory">Directory of store file on local machine.</param>
/// <param name="storeId">Store identifier.</param>
/// <param name="cryptoParameters">Cryptographic parameters for the store.</param>
/// <param name="policy">The cryptographic policy to be applied to the container.</param>
/// <param name="keyCollection">Key collection to be used to resolve keys</param>
/// <param name="decrypt">If true, attempt decryption of payload contents./</param>
/// <param name="create">If true, create a new file if none exists.</param>
/// <param name="meshClient">Parent account context used to obtain a mesh client.</param>
/// <param name="bitmask">The bitmask to identify the store for filtering purposes.</param>
public delegate Store StoreFactoryDelegate(
                string directory,
                string storeId,
                IMeshClient meshClient,
                DarePolicy policy = null,
                CryptoParameters cryptoParameters = null,
                IKeyCollection keyCollection = null,
                bool decrypt = true,
                bool create = true,
                byte[] bitmask = null);

/// <summary>
/// Base class for managing Mesh stores (catalogs, spools).
/// </summary>
/// 
public class Store : Disposable, IInternSequenceIndexEntry {
    ///<summary>The default name for the sequence</summary>
    public virtual string SequenceDefault => throw new NYI();

    ///<summary>The sequence</summary>
    public virtual Sequence Sequence { get; }

    ///<summary>The frame count (returns -1 if no container has been created)</summary>
    public long FrameCount => Sequence == null ? -1 : Sequence.FrameCount;


    //protected override void Disposing() => Sequence?.Dispose();

    /////<summary>The cryptographic parameters</summary>
    //protected CryptoParameters CryptoParameters { get; set; }

    ///<summary>The key collection used for decryption</summary>
    public IKeyCollection? KeyCollection { get; set; }

    ///<summary>The store identifier. Must be unique within a given account.</summary>
    public string StoreName { get; set; }

    ///<summary>The disposal routing</summary>
    protected override void Disposing() => Sequence?.Dispose();


    ///<summary>The default bitmask identifier for update notification.</summary> 
    public virtual StoreType StoreType => StoreType.Any;

    ///<inheritdoc/>
    public virtual SequenceIndexEntryFactoryDelegate SequenceIndexEntryFactory => SpoolIndexEntry.Factory;
 


    int BitmaskSizeBytes => 4;


    /// <summary>
    /// Constructor, returns an enumerator on the sequence <paramref name="sequence"/>, starting
    /// with the frame numbered <paramref name="start"/>. If <paramref name="reverse"/> is true, 
    /// results are returned from the last match first.
    /// </summary>
    /// <param name="sequence">The sequence to enumerate.</param>
    /// <param name="start">The starting point for the enumeration. If it matches, this will 
    /// be the first result returned.</param>
    /// <param name="reverse">If true, return results in the reverse order.</param>
    /// <param name="filter">If not null, specifies a filtering function on the 
    /// store entries.</param>
    /// <param name="skip">If true, the search MAY optimize search time by performing a binary
    /// search on the records. Note however that since this will cause entry update entries to
    /// be skipped, the status might be affected by one or more skipped records.</param>
    /// <param name="count">Maximum number of records to return.</param>
    public virtual IEnumerable<SequenceIndexEntry> Select(
                long start,
                bool reverse = true,
                long count = -1, 
                FilterIndexDelegate filter = null,
                bool skip = false) => new SequenceEnumeratorIndex(
                    Sequence, start, reverse, count, filter, skip);


    /// <summary>
    /// Factory delegate
    /// </summary>
    /// <param name="directory">Directory of store file on local machine.</param>
    /// <param name="storeId">Store identifier.</param>
    /// <param name="cryptoParameters">Cryptographic parameters for the store.</param>
    /// <param name="policy">The cryptographic policy to be applied to the container.</param>
    /// <param name="keyCollection">Key collection to be used to resolve keys</param>
    /// <param name="decrypt">If true, attempt decryption of payload contents./</param>
    /// <param name="create">If true, create a new file if none exists.</param>
    /// <param name="meshClient">Parent account context used to obtain a mesh client.</param>
    /// <param name="bitmask">The bitmask to identify the store for filtering purposes.</param>
    public static Store Factory(
                string directory,
                string storeId,
                IMeshClient meshClient,
                DarePolicy? policy = null,
                CryptoParameters? cryptoParameters = null,
                IKeyCollection? keyCollection = null,
                bool decrypt = true,
                bool create = true,
                byte[] bitmask = null) => throw new NYI();
        //new(directory, storeId, policy, cryptoParameters, keyCollection, meshClient, bitmask: bitmask);


    /// <summary>
    /// The constructor
    /// </summary>
    /// <param name="directory">Directory of store file on local machine.</param>
    /// <param name="storeId">Store identifier.</param>
    /// <param name="cryptoParameters">Cryptographic parameters for the store.</param>
    /// <param name="policy">The cryptographic policy to be applied to the container.</param>
    /// <param name="keyCollection">Key collection to be used to resolve keys</param>
    /// <param name="decrypt">If true, attempt decryption of payload contents./</param>
    /// <param name="create">If true, create a new file if none exists.</param>
    /// <param name="meshClient">Parent account context used to obtain a mesh client.</param>
    /// <param name="bitmask">The bitmask to identify the store for filtering purposes.</param>
    public Store(string directory,
                string? storeId = null,
                DarePolicy? policy = null,
                CryptoParameters? cryptoParameters = null,
                IKeyCollection? keyCollection = null,
                IMeshClient? meshClient = null,
                bool decrypt = true,
                bool create = true,
                byte[] bitmask = null) {

        bitmask ??= MakeMask();

        StoreName = storeId ?? SequenceDefault;
        var fileName = FileName(directory, StoreName);

        Sequence = Sequence.Open(
            fileName,
            FileStatus.ConcurrentLocked,
            keyCollection ?? cryptoParameters?.KeyLocate,
            SequenceType.Merkle,
            policy,
            "application/mmm-catalog",
            decrypt: decrypt,
            create: create,
            bitmask: bitmask,
            store:this
            );
        //Sequence.Store = this;

        KeyCollection = keyCollection;
        //CryptoParameters = cryptoParameters;
        }


    /// <summary>
    /// Return the frame count of the sequence in the file store <paramref name="storeId"/> in
    /// directory <paramref name="directory"/>.
    /// </summary>
    /// <param name="directory">Directory of store file on local machine.</param>
    /// <param name="storeId">Store identifier.</param>
    /// <returns>The value of the last frame index plus 1.</returns>
    public static long GetFrameCount(
                    string directory,
                    string? storeId) => Sequence.GetFrameCount(FileName(directory, storeId));



    byte[] MakeMask() {
        var bitmask = new byte[BitmaskSizeBytes];

        var index = (int)StoreType;
        bitmask[index / 8] = (byte)(0x1 << (index & 0b0111));
        return bitmask;
        }

    ///<inheritdoc/>
    public virtual void Intern(
                SequenceIndexEntry indexEntry) {
        }




    /// <summary>
    /// Append the list of envelopes <paramref name="envelopes"/> to the
    /// container <paramref name="containerName"/> in <paramref name="directory"/>.
    /// </summary>
    /// <param name="directory">Directory in which the containers are kept.</param>
    /// <param name="envelopes">The envelopes to add.</param>
    /// <param name="containerName">The name of the container.</param>
    /// <param name="keyLocate">The key location context.</param>
    public static void Append(string directory,
            IKeyLocate keyLocate, List<DareEnvelope> envelopes, string containerName = null) {
        envelopes.AssertNotNull(Internal.Throw);
        if (envelopes.Count == 0) {
            return;
            }

        var fileName = FileName(directory, containerName);

        if (envelopes[0].Header.SequenceInfo.LIndex == 0) {
            using var container = Sequence.MakeNewSequence(fileName, keyLocate, envelopes);
            }
        else {
            // here open the existing container.
            using var container = Sequence.OpenExisting(fileName, FileStatus.ConcurrentLocked, decrypt: false);
            container.Append(envelopes);
            }

        }

    /// <summary>
    /// Compute the filename for the container <paramref name="containerName"/> 
    /// in <paramref name="directory"/>.
    /// </summary>
    /// <param name="directory">Directory in which the containers are kept.</param>
    /// <param name="containerName">The name of the container.</param>
    /// <returns></returns>
    public static string FileName(string directory, string containerName = null) => Path.Combine(directory, Path.ChangeExtension(containerName, ".dcat"));

    /// <summary>
    /// Append the envelopes <paramref name="envelope"/> to the
    /// store.
    /// </summary>
    public virtual SequenceIndexEntry AppendDirect(DareEnvelope envelope, bool updateEnvelope = true) {
        return Sequence.Append(envelope, updateEnvelope);
        }

    /// <summary>
    /// Returns an enumerator for traversing the store. If <paramref name="reverse"/>
    /// is true, the enumeration begins at the end of the container and envelopes
    /// with index values greater or equal to <paramref name="minIndex"/> are returned.
    /// Otherwise the first envelope returned is the one at index value <paramref name="minIndex"/>
    /// and the enumeration continues to the end.
    /// </summary>
    /// <param name="minIndex">The lowest index value to return.</param>
    /// <param name="reverse">If true, begin enumeration at the end of the container and
    /// work backwards. Otherwise begin at <paramref name="minIndex"/> and move
    /// forwards.</param>
    /// <returns></returns>
    public virtual IEnumerable<DareEnvelope> Select(int minIndex, bool reverse = false) =>
        Sequence.SelectEnvelope(minIndex, reverse);




    }
