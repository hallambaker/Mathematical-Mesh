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


using Goedel.Cryptography.Jose;

namespace Goedel.Mesh;


public partial class AccountHostAssignment {
    ///<summary>Typed enveloped data</summary> 
    public Enveloped<AccountHostAssignment> GetEnvelopedAccountHostAssignment() => new(DareEnvelope);

    }


public partial class MeshItem {

    /// <summary>
    /// The DareEnvelope encapsulation of this object instance.
    /// </summary>
    public virtual Enveloped DareEnvelope {
        get => Envelope as Enveloped;
        set => Envelope = value;
        }


    ///<summary>The key collection that was used to decode this object instance.</summary>
    public virtual IKeyCollection KeyCollection {
        get => KeyLocate as IKeyCollection;
        set => KeyLocate = value;
        }

    ///<inheritdoc/>
    public override string? IanaMediaType => MeshConstants.IanaTypeMeshObject;

    ///<summary>The envelope Identifier.</summary> 
    public virtual string EnvelopeId => _PrimaryKey;

    /// <summary>
    /// Decode and parse the data 
    /// </summary>
    /// <param name="envelope">The enveloped data.</param>
    /// <param name="keyCollection">The key collaecion to use to find the decryption key.</param>
    /// <returns>The decoded data item</returns>
    public static MeshItem Decode(Enveloped envelope, IKeyCollection keyCollection = null) {
        if (envelope == null) {
            return null;
            }
        
        var plaintext = envelope.GetPlaintext(keyCollection);

        var result = StreamParseTag<MeshItem>(plaintext, true);
        result.Envelope = envelope;
        result.KeyCollection = keyCollection;
        return result;

        }


    /// <summary>
    /// Append a description of the instance to the StringBuilder <paramref name="builder"/> with
    /// a leading indent of <paramref name="indent"/> units. The cryptographic context from
    /// thekey collection <paramref name="keyCollection"/> is used to decrypt any encrypted data.
    /// </summary>
    /// <param name="builder">The string builder to write to.</param>
    /// <param name="indent">The number of units to indent the presentation.</param>
    /// <param name="keyCollection">The key collection to use to obtain decryption keys.</param>
    public virtual void ItemToBuilder(StringBuilder builder, int indent = 0, IKeyCollection keyCollection = null) =>
        _ = builder.AppendLine($"[{_Tag}]");


    }



public partial class MessageError {
    /////<summary>Always false for an error result.</summary>
    //public override bool Success => false;

    /////<summary>The error report code</summary>
    //public override string ErrorReport => ErrorCode;
    }
