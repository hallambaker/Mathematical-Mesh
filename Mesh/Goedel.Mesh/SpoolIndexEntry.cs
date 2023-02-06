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


public interface ISpoolItem {

    List<Reference> References { get; } 
    void AddReference(Reference reference, bool force);
    }


public class SpoolPlaceholder : ISpoolItem {

    ///<summary>The list of references to the message, most recently added first.</summary>
    public List<Reference> References { get; } = new();

    public SpoolPlaceholder (Reference reference) { 
        }

    public void AddReference(Reference reference, bool force) => throw new NYI();
    }


public class SpoolIndexEntry : SequenceIndexEntry, ISpoolItem {

    ///<summary>The list of references to the message, most recently added first.</summary>
    public List<Reference> References { get; set; }

    /// <summary>
    /// Factory method implementing <see cref="SequenceIndexEntryFactoryDelegate"/>.
    /// </summary>
    /// <inheritdoc cref="SequenceIndexEntryFactoryDelegate"/>
    public static new SequenceIndexEntry Factory(
            Sequence sequence,
            long framePosition,
            long frameLength,
            long dataPosition,
            long dataLength,
            DareHeader header,
            DareTrailer trailer = null,
            JsonObject jsonObject = null
            ) => new SpoolIndexEntry() {
                Sequence = sequence,
                FramePosition = framePosition,
                FrameLength = frameLength,
                DataPosition = dataPosition,
                DataLength = dataLength,
                Header = header,
                Trailer = trailer,
                JsonObject = jsonObject
                };


    ///<summary>Returns the message</summary>
    public Message Message => throw new NYI();


    ///<summary>The message status value.</summary>
    public MessageStatus MessageStatus => throw new NYI();
    //public Message Message => message ?? Decode().CacheValue(out message);
    //Message message;


    public string MessageId => Message?.MessageId;

    public string MessageType => Header?.ContentMeta?.MessageType;


    /// <summary>
    /// Add a reference to this entry. The reference will cause the message status to be 
    /// updated if either this is the first reference to be added or the 
    /// <paramref name="force"/> parameter is true.
    /// </summary>
    /// <param name="reference">The reference to add.</param>
    /// <param name="force">Force updating of the status.</param>
    public void AddReference(Reference reference, bool force=true) {
        throw new NYI();

        //if ((References == null) | force) {
        //    References ??= new List<Reference>();
        //    References.Insert(0, reference);
        //    MessageStatus = reference.MessageStatus;
        //    // Message.MessageStatus = MessageStatus;
        //    "Handle the message status properly".TaskFunctionality();
        //    }
        //else {
        //    References.Add(reference);
        //    }
        }



    }

/// <summary>
/// Class constructing a delegate for evaluating a <see cref="SequenceIndexEntry"/> in
/// searches.
/// </summary>
public class Evaluate {

    ///<summary>Set the flag <see cref="ItemResult.Earlier"/> if the envelope has an
    ///added date before this date.</summary> 
    public DateTime NotBefore { get; set; } = DateTime.MinValue;

    ///<summary>Set the flag <see cref="ItemResult.Later"/> if the envelope has an
    ///added date on or after this date.</summary>
    public DateTime NotOnOrAfter { get; set; } = DateTime.MaxValue;

    ///<summary>Set the flag <see cref="ItemResult.Earlier"/> if the envelope has an
    ///index less than this.</summary>
    public long FrameFirst { get; set; } = 0;

    ///<summary>Set the flag <see cref="ItemResult.Later"/> if the envelope has an
    ///index greater than this.</summary>
    public long FrameLast { get; set; } = long.MaxValue;

    ///<summary>If not null, set the flag <see cref="ItemResult.Match"/> if the 
    ///payload does not match this message type.</summary>
    public Type ObjectType { get; set; } = null;

    ///<summary>If not null, set the flag <see cref="ItemResult.Match"/> if the 
    ///entry <see cref="SequenceIndexEntry.IsOpen"/> property does not return
    ///a matching value.</summary>
    public bool? IsOpen { get; set; } = null;

    ///<summary>If not null, set the flag <see cref="ItemResult.Deleted"/> if the 
    ///entry <see cref="SequenceIndexEntry.IsDeleted"/> property does not return
    ///a matching value.</summary>
    public bool? IsDeleted { get; set; } = null;

    ///<summary>If not null, set the flag <see cref="ItemResult.Erased"/> if the 
    ///entry <see cref="SequenceIndexEntry.IsErased"/> property does not return
    ///a matching value.</summary>
    public bool? IsErased { get; set; } = null;


    /// <summary>
    /// Returns the result of evaluating <paramref name="sequenceIndexEntry"/> against
    /// for matching the specified criteria.
    /// </summary>
    /// <param name="sequenceIndexEntry"></param>
    /// <returns></returns>
    public ItemResult Get(SequenceIndexEntry sequenceIndexEntry) {
        var result = ItemResult.Match;

        if (FrameFirst > sequenceIndexEntry.Index) {
            result |= ItemResult.Earlier;
            }
        if (FrameLast < sequenceIndexEntry.Index) {
            result |= ItemResult.Later;
            }

        var datetime = sequenceIndexEntry.DateTime;
        if (datetime != null) {
            if (datetime < NotBefore) {
                result |= ItemResult.Earlier;
                }
            if (datetime >= NotOnOrAfter) {
                result |= ItemResult.Later;
                }
            }

        if (IsOpen is not null && IsOpen != sequenceIndexEntry.IsOpen) {
            result |= ItemResult.NotMatch;
            }
        if (IsDeleted is not null && IsDeleted != sequenceIndexEntry.IsDeleted) {
            result |= ItemResult.Deleted;
            }
        if (IsErased is not null && IsErased != sequenceIndexEntry.IsErased) {
            result |= ItemResult.Earlier;
            }
        return result;
        }


    static readonly Evaluate EvaluateIsOpen = new Evaluate() { 
            IsOpen = true
            };
    public static EvaluateIndexDelegate GetOpen => EvaluateIsOpen.Get;



    }


/// <summary>
/// Spool enumerator, returns a sequence of <see cref="SpoolIndexEntry"/> instances
/// matching a specified set of conditions.
/// </summary>
public class SpoolEnumerator : IEnumerable<SpoolIndexEntry> {

    ///<inheritdoc/><
    public IEnumerator<SpoolIndexEntry> GetEnumerator() {
        throw new NotImplementedException();
        }

    IEnumerator IEnumerable.GetEnumerator() {
        throw new NotImplementedException();
        }


    /// <summary>
    /// Constructor, returns an enumerator on the sequence <paramref name="sequence"/> matching
    /// the conditions specified beginning with the entry <paramref name="start"/>.
    /// </summary>
    /// <param name="sequence">The sequence to enumerate.</param>
    /// <param name="start">The first item to evaluate.</param>
    /// <param name="reverse">Return entries in reverse order.</param>
    /// <param name="evaluateIndex">The enumerator.</param>

    public SpoolEnumerator (
                Sequence sequence,
                SpoolIndexEntry start,
                bool reverse = true,
                EvaluateIndexDelegate evaluateIndex = null) {
        throw new NYI(); 
        }



    }

