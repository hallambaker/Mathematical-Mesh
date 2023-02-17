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
using Goedel.Utilities;
using static System.Net.Mime.MediaTypeNames;

namespace Goedel.Mesh;

/// <summary>
/// Base class for stores of type Spool.
/// </summary>
public class Spool : Store {

    ///<summary>Dictionary of entries by identifier.</summary>
    Dictionary<string, ISpoolItem> SequenceIndexEntryByEnvelopeId { get; } = new();

    ///<summary>The index entry of the last item in the spool.</summary> 
    public SpoolIndexEntry SpoolIndexEntryLast => Sequence.SequenceIndexEntryLast as SpoolIndexEntry;


    ///<inheritdoc/>
    public override SequenceIndexEntryFactoryDelegate SequenceIndexEntryFactory => SpoolIndexEntry.Factory;


    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="directory">Directory of store file on local machine.</param>
    /// <param name="storeId">Store identifier.</param>
    /// <param name="cryptoParameters">Cryptographic parameters for the store.</param>
    /// <param name="policy">The cryptographic policy to be applied to the spool.</param>
    /// <param name="keyCollection">Key collection to be used to resolve keys</param>
    /// <param name="decrypt">If true, attempt decryption of payload contents./</param>
    /// <param name="create">If true, create a new file if none exists.</param>
    /// <param name="meshClient">Parent account context used to obtain a mesh client.</param>
    /// <param name="bitmask">The bitmask to identify the store for filtering purposes.</param>
    public Spool(
                string directory,
                string storeId,
                 DarePolicy policy = null,
                CryptoParameters cryptoParameters = null,
                IKeyCollection keyCollection = null,
                IMeshClient meshClient = null,
                bool decrypt = true,
                bool create = true,
                byte[] bitmask = null) :
            base(directory, storeId, policy, cryptoParameters, keyCollection, meshClient, 
                decrypt, create, bitmask) {
        }

    /// <summary>
    /// Intern the element <paramref name="indexEntry"/> in the store.
    /// </summary>
    /// <param name="indexEntry">The element to intern.</param>
    public override void Intern(
                SequenceIndexEntry indexEntry) => Intern(indexEntry as SpoolIndexEntry);


    ///<inheritdoc/>
    public void Intern(SpoolIndexEntry entry) {

        entry.AssertNotNull(NYI.Throw);

        if (entry.EnvelopeId is null) {
            return;
            }

        // check to see if the item has been added already.
        if (SequenceIndexEntryByEnvelopeId.TryGetValue(entry.EnvelopeId, out var value)) {
            entry.References = value.References;
            entry.MessageStatus = value.MessageStatus;
            return;
            }
        else {
            SequenceIndexEntryByEnvelopeId.Add(entry.EnvelopeId, entry);
            }


        if (entry.MessageType == MessageComplete.__Tag) {
            var message = entry.Message as MessageComplete;
            message.AssertNotNull(InvalidMessage.Throw);  // Hack - need to collect up the errors 

            foreach (var reference in message.References) {
                // Do we already have an entry?
                var envelopeID = reference.EnvelopeId;

                if (SequenceIndexEntryByEnvelopeId.TryGetValue(envelopeID, out var referenceEntry)) {
                    //var referenceEntrySpool = referenceEntry as SpoolIndexEntry;
                    referenceEntry.AddReference(reference, entry.Index);
                    }
                else {
                    var placeholder = new SpoolPlaceholder( reference);
                    SequenceIndexEntryByEnvelopeId.Add(envelopeID, placeholder);
                    }
                }
            }


        //Component.Logger.InternMessage(entry.EnvelopeId, entry.MessageId, entry.MessageStatus);
        }


      



    /// <summary>
    /// Append the envelopes <paramref name="envelope"/> to the
    /// store.
    /// </summary>
    public override SequenceIndexEntry AppendDirect(DareEnvelope envelope, bool updateEnvelope = true) {
        return Sequence.Append(envelope, updateEnvelope);
        //Intern(envelope, null);
        }



    public SpoolIndexEntry GetByMessageId(
                string messageID) => GetById(Message.GetEnvelopeId(messageID));



    public SpoolIndexEntry GetById(
            string envelopeId) {
        if (SequenceIndexEntryByEnvelopeId.TryGetValue(envelopeId, out var value)) {
            if (value is SpoolIndexEntry entry) {
                return entry;
                }
            }

        foreach (var index in Sequence.SelectFromUnread()) {
            if (index.Header.EnvelopeId == envelopeId) {
                return index as SpoolIndexEntry;
                }
            }
        return null;

        }

    /// <summary>
    /// Return an enumerator returning a sequence of <see cref="SpoolIndexEntry"/> entries
    /// matching the criteria specified by <paramref name="evaluateIndex"/>.
    /// </summary>
    /// <param name="start">The starting point for the search.</param>
    /// <param name="reverse">Return items in reverse order, i.e. most recently received
    /// first.</param>
    /// <param name="evaluateIndex">Evaluation delegate specifying if the item is a match.</param>
    /// <returns>The enumeration.</returns>
    public IEnumerable<SpoolIndexEntry> GetMessages(
                SpoolIndexEntry start = null,
                bool reverse = true,
                bool open = true,
                FilterIndexDelegate evaluateIndex = null) =>
            new SpoolEnumerator(Sequence, start?.Index?? -1, reverse, evaluateIndex ?? FilterSequenceIndex.GetOpen);




    }

#region // Predefined Mesh spools

/// <summary>
/// Class for the local spool
/// </summary>
public class SpoolLocal : Spool {
    #region // Properties

    ///<summary>Canonical name for local spool</summary>
    public const string Label = MeshConstants.StoreTypeLocalTag;

    ///<inheritdocs/>
    public override StoreType StoreType => StoreType.Local;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="disposing"></param>
    protected override void Dispose(bool disposing) =>
        base.Dispose(disposing);

    #endregion
    #region // Factory methods and constructors

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
    public static new Store Factory(
            string directory,
                string storeId,
                IMeshClient meshClient,
                                    DarePolicy policy = null,
                CryptoParameters cryptoParameters = null,
                IKeyCollection keyCollection = null,
                bool decrypt = true,
                bool create = true,
                byte[] bitmask = null) =>
        new SpoolLocal(directory, storeId, policy, cryptoParameters, keyCollection, meshClient,
            decrypt, create, bitmask: bitmask);

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="directory">The directory in which the spool is stored.</param>
    /// <param name="storeId">The store name.</param>
    /// <param name="cryptoParameters">The cryptographic parameters.</param>
    /// <param name="policy">The cryptographic policy to be applied to the container.</param>
    /// <param name="keyCollection">The key collection to fetch keys from.</param>
    /// <param name="decrypt">If true, attempt decryption of payload contents./</param>
    /// <param name="create">If true, create a new file if none exists.</param>
    /// <param name="meshClient">Parent account context used to obtain a mesh client.</param>
    /// <param name="bitmask">The bitmask to identify the store for filtering purposes.</param>
    public SpoolLocal(
                string directory,
                string storeId,
                DarePolicy policy = null,
                CryptoParameters cryptoParameters = null,
                IKeyCollection keyCollection = null,
                IMeshClient meshClient = null,
                bool decrypt = true,
                bool create = true,
                byte[] bitmask = null) :
            base(directory, storeId, policy, cryptoParameters, keyCollection, meshClient,
                decrypt, create, bitmask: bitmask) {
        }

    #endregion
    #region // Class methods

    /// <summary>
    /// Check the spool for a matching unexpired PIN identifier and return the plaintext of the
    /// first unexpired message.
    /// </summary>
    /// <param name="pinId">The identifier of the corresponding PIN value.</param>
    /// <param name="maxTicks">Maximum message age in ticks (-1 = check all).</param>
    /// <param name="maxSearch">Maximum number of records to check (-1 = check all).</param>
    /// <returns>The plaintext message.</returns>
    public SpoolIndexEntry CheckPIN(string pinId,
                long maxTicks = -1,
                long maxSearch = -1) {
        maxTicks.Future();
        maxTicks.Future();
        maxSearch.Future();

        // The pinId is the same as the MessageID of the MessagePIN.
        // MessageID = RequestConnection.GetPinUDF(pin, accountUDF);
        "Should split the Local and Admin spools".TaskFunctionality();
        "Check for pin age etc, limit search".TaskFunctionality();

        return GetByMessageId(pinId) as SpoolIndexEntry;
        }
    #endregion
    }

/// <summary>
/// Class for the inbound spool
/// </summary>
public class SpoolInbound : Spool {
    #region // Properties
    ///<summary>Canonical name for inbound spool</summary>
    public const string Label = MeshConstants.StoreTypeInboundTag;

    ///<inheritdocs/>
    public override StoreType StoreType => StoreType.Inbound;

    ///<inheritdoc/>
    protected override void Disposing() {
        base.Disposing();
        //Console.WriteLine($"Dispose SpoolInbound");
        }
    #endregion
    #region // Factory methods and constructors

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
    public static new Store Factory(
            string directory,
                string storeId,
                IMeshClient meshClient,
                DarePolicy policy = null,
                CryptoParameters cryptoParameters = null,
                IKeyCollection keyCollection = null,
                bool decrypt = true,
                bool create = true,
                byte[] bitmask = null) =>
        new SpoolInbound(directory, storeId, policy, cryptoParameters, keyCollection, meshClient,
            decrypt, create, bitmask: bitmask);

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="directory">The directory in which the spool is stored.</param>
    /// <param name="storeId">The store name.</param>
    /// <param name="cryptoParameters">The cryptographic parameters.</param>
    /// <param name="policy">The cryptographic policy to be applied to the container.</param>
    /// <param name="keyCollection">The key collection to fetch keys from.</param>
    /// <param name="decrypt">If true, attempt decryption of payload contents./</param>
    /// <param name="create">If true, create a new file if none exists.</param>
    /// <param name="meshClient">Parent account context used to obtain a mesh client.</param>
    /// <param name="bitmask">The bitmask to identify the store for filtering purposes.</param>
    public SpoolInbound(
                string directory,
                string storeId,
                DarePolicy policy = null,
                CryptoParameters cryptoParameters = null,
                IKeyCollection keyCollection = null,
                IMeshClient meshClient = null,
                bool decrypt = true,
                bool create = true,
                byte[] bitmask = null) :
            base(directory, storeId, policy, cryptoParameters, keyCollection, meshClient,
                decrypt, create, bitmask: bitmask) {
        //Console.WriteLine($"Create SpoolInbound");
        }

    #endregion
    }

/// <summary>
/// Class for the outbound spool
/// </summary>
public class SpoolOutbound : Spool {
    #region // Properties
    ///<summary>Canonical name for outbound spool</summary>
    public const string Label = MeshConstants.StoreTypeOutboundTag;

    ///<inheritdocs/>
    public override StoreType StoreType => StoreType.Outbound;
    #endregion
    #region // Factory methods and constructors
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
    public static new Store Factory(
            string directory,
                string storeId,
                IMeshClient meshClient,
                DarePolicy policy = null,
                CryptoParameters cryptoParameters = null,
                IKeyCollection keyCollection = null,
                bool decrypt = true,
                bool create = true,
                byte[] bitmask = null) =>
        new SpoolOutbound(directory, storeId, policy, cryptoParameters, keyCollection, meshClient,
            decrypt, create, bitmask: bitmask);


    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="directory">The directory in which the spool is stored.</param>
    /// <param name="storeName">The store name.</param>
    /// <param name="cryptoParameters">The cryptographic parameters.</param>
    /// <param name="policy">The cryptographic policy to be applied to the container.</param>
    /// <param name="keyCollection">The key collection to fetch keys from.</param>
    /// <param name="decrypt">If true, attempt decryption of payload contents./</param>
    /// <param name="create">If true, create a new file if none exists.</param>
    /// <param name="meshClient">Parent account context used to obtain a mesh client.</param>
    /// <param name="bitmask">The bitmask to identify the store for filtering purposes.</param>
    public SpoolOutbound(string directory, string storeName,
        DarePolicy policy = null,
        CryptoParameters cryptoParameters = null,
                IKeyCollection keyCollection = null,
                IMeshClient meshClient = null,
                bool decrypt = true,
                bool create = true,
                byte[] bitmask = null) :
            base(directory, storeName, policy, cryptoParameters, keyCollection, meshClient,
                decrypt, create, bitmask: bitmask) {

        }
    #endregion
    }

/// <summary>
/// Class for the outbound spool
/// </summary>
public class SpoolArchive : Spool {
    #region // Properties
    ///<summary>Canonical name for outbound spool</summary>
    public const string Label = MeshConstants.StoreTypeArchiveTag;

    ///<inheritdocs/>
    public override StoreType StoreType => StoreType.Archive;

    #endregion
    #region // Factory methods and constructors
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
    public static new Store Factory(
            string directory,
                string storeId,
                IMeshClient meshClient,
                                    DarePolicy policy = null,
                CryptoParameters cryptoParameters = null,
                IKeyCollection keyCollection = null,
                bool decrypt = true,
                bool create = true,
                byte[] bitmask = null) =>
        new SpoolArchive(directory, storeId, policy, cryptoParameters, keyCollection, meshClient,
            decrypt, create, bitmask: bitmask);

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="directory">The directory in which the spool is stored.</param>
    /// <param name="storeId">The store name.</param>
    /// <param name="cryptoParameters">The cryptographic parameters.</param>
    /// <param name="policy">The cryptographic policy to be applied to the container.</param>
    /// <param name="keyCollection">The key collection to fetch keys from.</param>
    /// <param name="decrypt">If true, attempt decryption of payload contents./</param>
    /// <param name="create">If true, create a new file if none exists.</param>
    /// <param name="meshClient">Parent account context used to obtain a mesh client.</param>
    /// <param name="bitmask">The bitmask to identify the store for filtering purposes.</param>
    public SpoolArchive(
                string directory,
                string storeId,
                                    DarePolicy policy = null,
                CryptoParameters cryptoParameters = null,
                IKeyCollection keyCollection = null,
                IMeshClient meshClient = null,
                bool decrypt = true,
                bool create = true,
                byte[] bitmask = null) :
            base(directory, storeId, policy, cryptoParameters, keyCollection, meshClient,
                decrypt, create, bitmask: bitmask) {

        }
    #endregion
    }

#endregion