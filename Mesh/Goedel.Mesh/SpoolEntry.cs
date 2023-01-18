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


namespace Goedel.Mesh;

///<summary>Message entry in spool catalog</summary>
public class SpoolEntry {


    ///<summary>The spool the message is enrolled in.</summary>
    public Spool Spool { get; }

    ///<summary>The unique envelope identifier.</summary>
    public string EnvelopeID { get; private set; }

    ///<summary>The envelope from the spool.</summary>
    public DareEnvelope DareEnvelope { get; private set; }

    ///<summary>The next entry in the spool.</summary>
    public SpoolEntry Next { get; private set; }

    ///<summary>The previous entry in the spool.</summary>
    public SpoolEntry Previous { get; private set; }

    ///<summary>Returns true iff message status is Closed.</summary>
    public bool Closed => (MessageStatus & MessageStatus.Closed) == MessageStatus.Closed;

    ///<summary>Returns true iff message status is Open.</summary>
    public bool Open => (MessageStatus & MessageStatus.Open) == MessageStatus.Open;

    ///<summary>The list of references to the message, most recently added first.</summary>
    public List<Reference> References;

    ///<summary>Returns the message</summary>
    public Message Message => message ?? Decode().CacheValue(out message);
    Message message;

    ///<summary>Convenience accessor for the envelope index number.</summary>
    public long Index => DareEnvelope.Index;

    ///<summary>The message status value.</summary>
    public MessageStatus MessageStatus;


    /// <summary>
    /// Construct a Spool entry for the previously unregistered envelope
    /// <paramref name="envelope"/>.
    /// </summary>
    /// <param name="spool">The spool the entry is created for.</param>
    /// <param name="envelope">The envelope value.</param>
    /// <param name="next">The next entry in the spool.</param>
    public SpoolEntry(Spool spool, DareEnvelope envelope, SpoolEntry next) {
        Spool = spool;
        MessageStatus = MessageStatus.Open;
        EnvelopeID = envelope.EnvelopeId;
        AddEnvelope(envelope, next);
        }


    /// <summary>
    /// Construct a Spool entry for an envelope that has not yet been registered
    /// that has been referenced by <paramref name="reference"/>.
    /// </summary>
    /// <param name="spool">The spool the entry is created for.</param>
    /// <param name="reference">The reference.</param>
    public SpoolEntry(Spool spool, Reference reference) {
        Spool = spool;
        EnvelopeID = reference.MessageId;
        MessageStatus = reference.MessageStatus;
        }


    /// <summary>
    /// Add an envelope to an existing entry created because a status value was reported.
    /// </summary>
    /// <param name="envelope">The envelope to add.</param>
    /// <param name="next">The next entry in the spool.</param>
    public void AddEnvelope(DareEnvelope envelope, SpoolEntry next) {
        DareEnvelope = envelope;
        Link(next);
        }

    /// <summary>
    /// Link the spool entry <paramref name="next"/> to this entry as the next
    /// entry in the chain.
    /// </summary>
    /// <param name="next">The next entry to link.</param>
    public void Link(SpoolEntry next) {
        if (next == null) {
            return;
            }
        Next = next;
        next.Previous = this;
        }



    /// <summary>
    /// Add a reference to this entry. The reference will cause the message status to be 
    /// updated if either this is the first reference to be added or the 
    /// <paramref name="force"/> parameter is true.
    /// </summary>
    /// <param name="reference">The reference to add.</param>
    /// <param name="force">Force updating of the status.</param>
    public void AddReference(Reference reference, bool force) {
        if ((References == null) | force) {
            References ??= new List<Reference>();
            References.Insert(0, reference);
            MessageStatus = reference.MessageStatus;
            // Message.MessageStatus = MessageStatus;
            "Handle the message status properly".TaskFunctionality();
            }
        else {
            References.Add(reference);
            }
        }


    /// <summary>
    /// Decode the envelope as a DARE Message using the current
    /// KeyCollection and return the result.
    /// </summary>
    /// <returns>The decoded message</returns>
    Message Decode() {



        if (DareEnvelope.JsonObject != null) {
            return DareEnvelope.JsonObject as Message;
            }
        try {

            DareEnvelope.JsonObject = Message.Decode(DareEnvelope, Spool.KeyCollection);
            return DareEnvelope.JsonObject as Message;
            }
        catch (NoAvailableDecryptionKey) {
            return null;
            }

        }


    }
