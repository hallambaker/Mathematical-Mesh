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
using System;
using System.Data;

using static Goedel.Discovery.ServiceAddressSplitLex;

namespace Goedel.Cryptography.Dare;

/// <summary>Dare spool containing an append only list of messages.</summary>
public class VDareSpool : VDareSequence {


    /// <summary>Constructor from <paramref name="stream"/></summary>
    /// <param name="stream">The stream to read the spool data from.</param>
    protected VDareSpool(
        VDareStream stream) : base(stream) {
        }

    /// <summary>Create a new instance for a spool of type <typeparamref name="T"/>,
    /// writing to <paramref name="fileName"/></summary>
    /// <typeparam name="T">The typed log contents.</typeparam>
    /// <param name="fileName">The file to write to.</param>
    /// <returns>The instance.</returns>
    public static VDareSpool<T> Create<T>(
    string fileName) where T : JsonObject {
        var stream = VDareStream.Create(fileName, DareConstants.TypeIdentifierDareSequence);
        var result = new VDareSpool<T>(stream);

        result.WriteInitial();

        return result;
        }

    /// <summary>Open an instance for a spool of type <typeparamref name="T"/>,
    /// writing to <paramref name="fileName"/></summary>
    /// <typeparam name="T">The typed log contents.</typeparam>
    /// <param name="fileName">The file to write to.</param>
    /// <returns>The instance.</returns>
    public static VDareSpool<T> Open<T>(
            string fileName) where T : JsonObject {

        var stream = VDareStream.OpenReadWrite(fileName);
        var spool = new VDareSpool<T>(stream);
        spool.ReadInitial();

        return spool;
        }

    }

/// <summary>Provides a view on a data spool containing a sequence items of 
/// type T, each oif which has a unique primary key. Each item has an associated 
/// state which MAY be modified by subsequent entries.</summary>
/// <typeparam name="T">The type of item stored.</typeparam>
public class VDareSpool<T> : VDareSpool where T : JsonObject {

    /// <summary>Disctionary returning the message status.</summary>
    public Dictionary<string, SequenceEvent> StatusDictionary { get; } = [];

    internal VDareSpool(
                VDareStream stream) : base(stream) {
        }

    /// <summary>Append an entry to the log constructing the appropriate
    /// unprotected and protected headers.</summary>
    /// <param name="item"></param>
    /// <param name="state">State to append the item in.</param>
    /// <returns>The entry index.</returns>
    public VDareEntryIndex Add(T item,
                SequenceEvent state = SequenceEvent.Initial) {
        var contentMeta = new ContentMeta() {
            UniqueId = item._PrimaryKey,
            Event = state.ToLabel()
            };
        item._State = state;
        return Append(item, contentMeta);
        }

    /// <summary>Perform a set of status updates <paramref name="updates"/></summary>
    /// <param name="updates">The updates to perform.</param>
    /// <returns>The entry index.</returns>
    public VDareEntryIndex Update(List<EntryUpdate> updates) {
        var contentMeta = new ContentMeta() {
            UniqueId = null,
            Event = ProtocolConstants.SequenceEventUpdatesTag
            };

        foreach (var update in updates) {
            if (StatusDictionary.ContainsKey(update.Id)) {
                StatusDictionary.Remove(update.Id);
                }
            StatusDictionary.Add(update.Id, update.SequenceEvent);
            }

        var updateSet = new EntryUpdateSet() {
            Entries = updates
            };
        return Append(updateSet, contentMeta);
        }


    /// <summary>Get the value of the spool entry <paramref name="index"/></summary>
    /// <param name="index">Index of the entry to return.</param>
    /// <returns>The value.</returns>
    public T GetValue(VDareEntryIndex index) {
        var result = GetValue<T>(index);
        if (StatusDictionary.TryGetValue(result._PrimaryKey, out var value)) {
            result._State = value;
            }
        else {
            result._State = SequenceEvent.Initial;
            }

        return result;
        }

    /// <summary>Process the spool entry <paramref name="entry"/> to
    /// eliminate status updates.</summary>
    /// <param name="entry">The entry to process</param>
    /// <returns>The result of processing.</returns>
    public bool ProcessEntry(VDareEntryIndex entry) {
        if (entry.EarlEnvelope.SignedHeader.UniqueId is not null) {
            return false;
            }

        if (entry.EarlEnvelope.SignedHeader.Event ==
                    ProtocolConstants.SequenceEventUpdatesTag) {
            var bytes = Stream.GetPayload(entry);
            //var bytesAs = bytes.ToUTF8();
            var updateSet = JsonObject.StreamParseTag<EntryUpdateSet>(bytes, true);

            // we only update the status if this is a new entry
            foreach (var update in updateSet.Entries) {
                if (!StatusDictionary.ContainsKey(update.Id)) {
                    StatusDictionary.Add(update.Id, update.SequenceEvent);
                    }

                }

            }



        return true;

        }

    /// <summary>Enumeration over the spool in the reverse order.</summary>
    /// <returns>The enumeration.</returns>
    public override IEnumerable<VDareEntryIndex> EntriesReverse() => 
        new VEntryEnumerator(this, false, ProcessEntry);



    }