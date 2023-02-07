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
    public MessageStatus MessageStatus { get;  }

    ///<summary>The list of references to the message, most recently added first.</summary>
    List<Reference> References { get; } 

    ///<summary>Add a reference entry.</summary> 
    void AddReference(Reference reference, bool force);
    }

///<summary>Placehoolder for a referenced but not yet read item.</summary> 
public class SpoolPlaceholder : ISpoolItem {

    ///<inheritdoc/>
    public List<Reference> References { get; } = new();

    ///<summary>The message status value.</summary>
    public MessageStatus MessageStatus { get; set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="reference"></param>
    public SpoolPlaceholder (Reference reference) { 
        }

    ///<inheritdoc/>
    public void AddReference(Reference reference, bool force) => throw new NYI();
    }

/// <summary>
/// Index entry for a spool element.
/// </summary>
public class SpoolIndexEntry : SequenceIndexEntry, ISpoolItem {

    ///<summary>The list of references to the message, most recently added first.</summary>
    public List<Reference> References { get; set; }


    ///<summary>Returns the message</summary>
    public Message Message => JsonObject as Message;


    ///<summary>The message status value.</summary>
    public MessageStatus MessageStatus { get; set; }
    //public Message Message => message ?? Decode().CacheValue(out message);
    //Message message;

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




    /// <summary>
    /// Add a reference to this entry. The reference will cause the message status to be 
    /// updated if either this is the first reference to be added or the 
    /// <paramref name="force"/> parameter is true.
    /// </summary>
    /// <param name="reference">The reference to add.</param>
    /// <param name="force">Force updating of the status.</param>
    public void AddReference(Reference reference, bool force=true) {
        //throw new NYI();

        if ((References == null) | force) {
            References ??= new ();
            References.Insert(0, reference);
            MessageStatus = reference.MessageStatus;
            // Message.MessageStatus = MessageStatus;
            //"Handle the message status properly".TaskFunctionality();
            }
        else {
            References.Add(reference);
            }
        }



    }




