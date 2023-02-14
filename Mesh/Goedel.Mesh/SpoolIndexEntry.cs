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

/// <summary>
/// An index entry or a placeholder for one that has not been read yet.
/// </summary>
public interface ISpoolItem {
    ///<summary>The message status value.</summary>
    public StateSpoolMessage MessageStatus { get;  }

    ///<summary>The list of references to the message, most recently added first.</summary>
    List<Reference> References { get; } 

    ///<summary>Add a reference entry.</summary> 
    void AddReference(Reference reference, long index);
    }

///<summary>Placehoolder for a referenced but not yet read item.</summary> 
public class SpoolPlaceholder : ISpoolItem {

    ///<inheritdoc/>
    public List<Reference> References { get; } = new();

    ///<summary>The message status value.</summary>
    public StateSpoolMessage MessageStatus { get; set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="reference"></param>
    public SpoolPlaceholder (Reference reference) { 
        }

    ///<inheritdoc/>
    public void AddReference(Reference reference, long force) => throw new NYI();
    }




/// <summary>
/// Index entry for a spool element.
/// </summary>
public class SpoolIndexEntry : SequenceIndexEntry, ISpoolItem {


    ///<summary>The underlying spool.</summary> 
    public Spool Spool => Sequence.Store as Spool;


    ///<summary>The list of references to the message, most recently added first.</summary>
    public List<Reference> References { get; set; }


    ///<summary>Returns the message</summary>
    public Message Message => JsonObject as Message;


    ///<summary>The message status value.</summary>
    public StateSpoolMessage MessageStatus { get; set; } = StateSpoolMessage.Initial;

    ///<inheritdoc/>
    public override bool IsOpen { get; set; } = true;

    ///<summary>The decoded JSONObject</summary>
    public override JsonObject JsonObject {
        get => jsonObject ?? GetJSONObject().CacheValue(out jsonObject);
        set => jsonObject = value;
        }
    JsonObject jsonObject = null;

    ///<summary>Index of the frame in which the status was set;</summary> 
    long messageStatusIndex = 0;

    ///<summary>Convenience accessor for the message identifier.</summary> 
    public string MessageId => Message?.MessageId;

    ///<summary>Convenience accessor for the message type.</summary> 
    public string MessageType => Header?.ContentMeta?.MessageType;




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
            ) => new SpoolIndexEntry(sequence) {
                FramePosition = framePosition,
                FrameLength = frameLength,
                DataPosition = dataPosition,
                DataLength = dataLength,
                Header = header,
                Trailer = trailer,
                JsonObject = jsonObject
                };

    /// <summary>
    /// Constructor returning a in instance bound to the sequence <paramref name="sequence"/>
    /// </summary>
    /// <param name="sequence">The sequence the index is bound to.</param>
    SpoolIndexEntry(Sequence sequence) {
        //(sequence?.Store as Spool).AssertNotNull(NYI.Throw);
        Sequence = sequence;
        }

    ///<summary>Return the index of the previous item in the sequence.</summary> 
    public new SpoolIndexEntry Previous() => Sequence.Previous(this) as SpoolIndexEntry;

    ///<summary>Return the index of the next item in the sequence.</summary> 
    public new SpoolIndexEntry Next() => Sequence.Next(this) as SpoolIndexEntry;


    /// <summary>
    /// Add a reference to this entry. The reference will cause the message status to be 
    /// updated if either this is the first reference to be added or the 
    /// <paramref name="force"/> parameter is true.
    /// </summary>
    /// <param name="reference">The reference to add.</param>
    /// <param name="force">Force updating of the status.</param>
    public void AddReference(Reference reference, long index) {
        References ??= new();

        if (index >= messageStatusIndex) {
            References.Insert(0, reference);
            MessageStatus = reference.MessageStatus;
            IsOpen = MessageStatus.IsOpen();
            }
        else {
            References.Add(reference);
            }

        }


    }




