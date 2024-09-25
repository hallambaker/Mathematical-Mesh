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
    public virtual DareEnvelope DareEnvelope {
        get => Enveloped as DareEnvelope;
        set => Enveloped = value;
        }





    ///<summary>The key collection that was used to decode this object instance.</summary>
    public virtual IKeyCollection KeyCollection {
        get => KeyLocate as IKeyCollection;
        set => KeyLocate = value;
        }


    ///<summary>The envelope Identifier.</summary> 
    public virtual string EnvelopeId => _PrimaryKey;

    /// <summary>
    /// Sign the profile under <paramref name="signingKey"/>.
    /// </summary>
    /// <param name="signingKey">Optional signature key.</param>
    /// <param name="encryptionKey">Optional encryption key.</param>
    /// <param name="objectEncoding">The encoding to use to compute the inner object.</param>
    /// <returns>Envelope containing the signed profile. Also updates the property
    /// <see cref="DareEnvelope"/></returns>
    public virtual DareEnvelope Envelope(
                CryptoKey signingKey = null,
                CryptoKey encryptionKey = null,
                ObjectEncoding objectEncoding = ObjectEncoding.JSON
                ) {

        var contentMeta = new ContentMeta() {
            //UniqueId = base._PrimaryKey,
            UniqueId = _PrimaryKey,
            Created = System.DateTime.Now,
            ContentType = MeshConstants.IanaTypeMeshObject,
            MessageType = _Tag
            };

        Enveloped = new Enveloped<MeshItem>(this,
                    signingKey: signingKey, encryptionKey: encryptionKey, contentMeta: contentMeta,
                    objectEncoding: objectEncoding);
        DareEnvelope.Header.EnvelopeId = EnvelopeId;

        return DareEnvelope;
        }

    /// <summary>
    /// Sign the profile under <paramref name="signingKeys"/>.
    /// </summary>
    /// <param name="signingKeys">Optional list of signature keys.</param>
    /// <param name="encryptionKeys">Optional list of encryption keys.</param>
    /// <param name="objectEncoding">The encoding to use to compute the inner object.</param>
    /// <returns>Envelope containing the signed profile. Also updates the property
    /// <see cref="DareEnvelope"/></returns>
    public virtual DareEnvelope Envelope(
                List<CryptoKey> signingKeys,
                List<CryptoKey> encryptionKeys = null,
                ObjectEncoding objectEncoding = ObjectEncoding.JSON,
                bool includeSignatureKey = false
                ) {

        var contentMeta = new ContentMeta() {
            //UniqueId = base._PrimaryKey,
            UniqueId = _PrimaryKey,
            Created = System.DateTime.Now,
            ContentType = MeshConstants.IanaTypeMeshObject,
            MessageType = _Tag
        };

        var cryptoParameters = new CryptoParameters(encryptionKeys, signingKeys) {
            IncludeSignatureKey = includeSignatureKey
            };

        Enveloped = new Enveloped<MeshItem>(this, cryptoParameters, contentMeta: contentMeta,
                    objectEncoding: objectEncoding);
        DareEnvelope.Header.EnvelopeId = EnvelopeId;

        return DareEnvelope;
        }




    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="JSONReader">The input stream</param>
    /// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new MeshItem FromJson(JsonReader JSONReader, bool Tagged = true) {
        if (JSONReader == null) {
            return null;
            }
        if (Tagged) {
            var Out = JSONReader.ReadTaggedObject(_TagDictionary);
            return Out as MeshItem;
            }
        throw new CannotCreateAbstract();
        }


    /// <summary>
    /// Decode and parse the data 
    /// </summary>
    /// <param name="envelope">The enveloped data.</param>
    /// <param name="keyCollection">The key collaecion to use to find the decryption key.</param>
    /// <returns>The decoded data item</returns>
    public static MeshItem Decode(DareEnvelope envelope, IKeyCollection keyCollection = null) {

        if (envelope == null) {
            return null;
            }

        var plaintext = envelope.GetPlaintext(keyCollection);

        //Console.WriteLine(plaintext.ToUTF8());

        var reader = new JsonBcdReader(plaintext);

        var result = FromJson(reader, true);
        result.Enveloped = envelope;
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
