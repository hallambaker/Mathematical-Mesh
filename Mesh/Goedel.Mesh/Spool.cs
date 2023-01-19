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
/// Base class for stores of type Spool.
/// </summary>
public class Spool : Store {

    ///<summary>The first spool entry.</summary>
    public SpoolEntry SpoolEntryFirst { get; set; } = null;

    ///<summary>The last spool entry.</summary>
    public SpoolEntry SpoolEntryLast { get; set; } = null;

    ///<summary>Dictionary of entries by identifier.</summary>
    Dictionary<string, SpoolEntry> SpoolEntryById { get; } = new Dictionary<string, SpoolEntry>();


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
    /// Add an envelope to the spool. All information provided in the ContainerInfo
    /// field is discarded. The trailer, if present must be rewritten for the 
    /// purposes of the container.
    /// </summary>
    /// <param name="envelope"></param>
    public SpoolEntry Add(DareEnvelope envelope) {
        Sequence.Append(envelope, true);
        return Intern(envelope, null);
        }

    /// <summary>
    /// Append the envelopes <paramref name="envelope"/> to the
    /// store.
    /// </summary>
    public override void AppendDirect(DareEnvelope envelope, bool updateEnvelope = false) {
        Sequence.Append(envelope, updateEnvelope);
        Intern(envelope, null);
        }



    /// <summary>
    /// Check that the time value <paramref name="dateTime"/> is within the boundaries
    /// defined by <paramref name="maxTicks"/>, <paramref name="notBefore"/> and
    /// <paramref name="notOnOrAfter"/>.
    /// </summary>
    /// <param name="dateTime">The time to test.</param>
    /// <param name="maxTicks">If greater or equal to zero, return <code>false</code> if 
    /// <paramref name="dateTime"/> is more than
    /// this number of ticks earlier than the current time.</param>
    /// <param name="notBefore">If not null, return <code>false</code> if <paramref name="dateTime"/>
    /// is earlier than this time.</param>
    /// <param name="notOnOrAfter">If not null, return <code>false</code> if <paramref name="dateTime"/>
    /// is later than or the same as this time.</param>
    /// <returns><code>true</code> unless one of the conditions defined by <paramref name="maxTicks"/>, 
    /// <paramref name="notBefore"/> or <paramref name="notOnOrAfter"/> </returns> is not
    /// met in which case return <code>false</code>.
    public static bool CheckTime(
                System.DateTime? dateTime,
                long maxTicks = -1,
                System.DateTime? notBefore = null,
                System.DateTime? notOnOrAfter = null) {
        dateTime.AssertNotNull(InvalidDate.Throw);

        var dateTime1 = (System.DateTime)dateTime;

        if ((maxTicks >= 0) && ((System.DateTime.Now.Ticks - dateTime1.Ticks) > maxTicks)) {
            return false;
            }

        if ((notBefore != null) && (dateTime1 < notBefore)) {
            return false;
            }
        if ((notOnOrAfter != null) && (dateTime1 >= notOnOrAfter)) {
            return false;
            }
        return true;
        }


    /// <summary>
    /// Retrieve a message by message ID. 
    /// </summary>
    /// <param name="messageID"></param>
    /// <param name="select"></param>
    /// <param name="notBefore"></param>
    /// <param name="notOnOrAfter"></param>
    /// <param name="maxSearch"></param>
    /// <returns></returns>
    public SpoolEntry GetByMessageId(
                string messageID,
                MessageStatus select = MessageStatus.All,
                System.DateTime? notBefore = null,
                System.DateTime? notOnOrAfter = null,
                long maxSearch = -1) => GetByEnvelopeId(Message.GetEnvelopeId(messageID),
                    select, notBefore, notOnOrAfter, maxSearch);


    /// <summary>
    /// Retrieve a message by message ID. 
    /// </summary>
    /// <param name="envelopeId"></param>
    /// <param name="select"></param>
    /// <param name="notBefore"></param>
    /// <param name="notOnOrAfter"></param>
    /// <param name="maxSearch"></param>
    /// <returns></returns>
    public SpoolEntry GetByEnvelopeId(
                string envelopeId,
                MessageStatus select = MessageStatus.All,
                System.DateTime? notBefore = null,
                System.DateTime? notOnOrAfter = null,
                long maxSearch = -1) {


        if (SpoolEntryById.TryGetValue(envelopeId, out var spoolEntry)) {
            return spoolEntry;
            }

        foreach (var spoolEntry2 in GetMessages(select, notBefore, notOnOrAfter,
                    SpoolEntryLast, maxSearch)) {
            if (spoolEntry2.EnvelopeID == envelopeId) {
                return spoolEntry2;
                }
            }
        return null;
        }



    /// <summary>
    /// Returns an enumerator over the messages in the spool that match the
    /// constraints specified by <paramref name="select"/>, <paramref name="notBefore"/>, 
    /// <paramref name="notOnOrAfter"/> and <paramref name="maxResults"/>.
    /// </summary>
    /// <param name="select">Message status selection mask.</param>
    /// <param name="notBefore">Exclude messages sent before this time.</param>
    /// <param name="notOnOrAfter">Exclude messages sent after this time.</param>
    /// <param name="last">The point from which to begin the enumeration (exclusive).</param>
    /// <param name="maxResults">Maximum number of records to check (-1 = check all).</param>
    /// <returns>The enumerator.</returns>
    public SpoolEnumeratorRaw GetMessages(
                MessageStatus select = MessageStatus.All,
                System.DateTime? notBefore = null,
                System.DateTime? notOnOrAfter = null,
                SpoolEntry last = null,
                long maxResults = -1,
                bool reverse=true) => new(this,
                    select, notBefore, notOnOrAfter, last, maxResults, reverse);



    SpoolEntry Intern(SequenceIndexEntry indexEntry, SpoolEntry next) {

        throw new NYI();
        }

    /// <summary>
    /// Intern <paramref name="envelope"/> with the following envelope 
    /// <paramref name="next"/>.
    /// </summary>
    /// <param name="envelope"></param>
    /// <param name="next">The next frame number</param>
    /// <returns>The interned envelope instance.</returns>
    SpoolEntry Intern(DareEnvelope envelope, SpoolEntry next) {
        
        if (envelope == null) {
            return null;
            }

        if (SpoolEntryById.TryGetValue(envelope.EnvelopeId, out var spoolEntry)) {
            spoolEntry.AddEnvelope(envelope, next);

            }
        else {
            spoolEntry = new SpoolEntry(this, envelope, next);
            SpoolEntryById.Add(spoolEntry.EnvelopeID, spoolEntry);

            // If this is the last entry in the spool, set the high water mark.
            if (next == null) {
                if (SpoolEntryLast != null) {
                    SpoolEntryLast.Link(spoolEntry);
                    }
                SpoolEntryLast = spoolEntry;
                }
            }

        Component.Logger.InternMessage(spoolEntry.EnvelopeID, spoolEntry.Message?.MessageId,
            spoolEntry.MessageStatus);
        //Screen.WriteLine($"Intern EnvelopeID {spoolEntry.EnvelopeID}, " +
        //    $"Message {spoolEntry.Message?.MessageId} " +
        //    $"Status {spoolEntry.MessageStatus}");


        if (KeyCollection == null) {
            // do nothing, we can't read the contents of the message
            }
        else if (envelope.Header.ContentMeta.MessageType == MessageComplete.__Tag) {
            var message = spoolEntry.Message as MessageComplete;
            message.AssertNotNull(InvalidMessage.Throw);  // Hack - need to collect up the errors 
            foreach (var reference in message.References) {
                //Screen.WriteLine($"    Reference {reference.EnvelopeId}/{reference.MessageId}/{reference.MessageStatus}");


                // Do we already have an entry?
                var envelopeID = reference.EnvelopeId;
                if (SpoolEntryById.TryGetValue(envelopeID, out var referenceEntry)) {
                    referenceEntry.AddReference(reference, next == null);
                    }
                else {
                    referenceEntry = new SpoolEntry(this, reference);
                    SpoolEntryById.Add(envelopeID, referenceEntry);
                    }
                }
            }

        return spoolEntry;

        }



    /// <summary>
    /// Return the spool entry previous to <paramref name="current"/>.
    /// </summary>
    /// <param name="current">The entry to return the prior entry for.</param>
    /// <returns>The spool entry if found, otherwise, null.</returns>
    public SpoolEntry GetPrevious(SpoolEntry current) {
        var previousIndex = current.SequenceFrameIndex.Previous();
        return Intern(previousIndex, current);
        }


    public SpoolEntry GetNext(SpoolEntry current) {
        var nextIndex = current.SequenceFrameIndex.Next();
        return Intern(nextIndex, current);

        }


    /// <summary>
    /// Apply the list of message status updates specified in <paramref name="references"/>.
    /// </summary>
    /// <param name="references">List of message status values to be updated.</param>
    public static void SetStatus(List<Reference> references) {
        if (references == null || references.Count == 0) {
            return;
            }
        var messageComplete = new MessageComplete() {
            References = references
            };

        throw new NYI();
        }




    }


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
    public SpoolEntry CheckPIN(string pinId,
                long maxTicks = -1,
                long maxSearch = -1) {
        maxTicks.Future();
        maxTicks.Future();
        maxSearch.Future();

        // The pinId is the same as the MessageID of the MessagePIN.
        // MessageID = RequestConnection.GetPinUDF(pin, accountUDF);
        "Should split the Local and Admin spools".TaskFunctionality();
        "Check for pin age etc, limit search".TaskFunctionality();

        return GetByMessageId(pinId);
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
