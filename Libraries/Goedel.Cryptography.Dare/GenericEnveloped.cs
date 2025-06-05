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


namespace Goedel.Cryptography.Dare;

/// <summary>
/// Envelope validation levels
/// </summary>
public enum EnvelopeValidation {
    ///<summary>Perform no validation of the envelope or its contents.</summary> 
    None,
    ///<summary>Verify that the calculated payload digest matches the purported
    ///digest.</summary> 
    Digest,
    ///<summary>Verify that the signature is valid according to the specified 
    ///public key parameters.</summary> 
    Signature,
    ///<summary>Verify that the signature is valid according to the specified 
    ///public key parameters and that there is a valid chain of trust under a 
    ///specified root of trust.</summary> 
    Trusted
    }


/// <summary>
/// Typed DareEnvelope.
/// </summary>
/// <typeparam name="T">The type of the wrapped data item.</typeparam>
public partial class Enveloped<T> : Enveloped where T : JsonObject {


    //public override JsonObject JsonObject { 
    //    get => jsonObject ?? StreamParse<T>().CacheValue(out jsonObject); 
    //    set => jsonObject = value; }
    //JsonObject jsonObject;

    //public T JsonObjectAsType => JsonObject as T;



    /// <summary>
    /// Constructor for use by deserializers.
    /// </summary>
    public Enveloped() {
        }

    /// <summary>
    /// Construct a typed copy of the envelope <paramref name="enveloped"/> with the same
    /// Header, Trailer and JSONObject but omitting the body data.
    /// </summary>
    /// <param name="enveloped">The envelope to copy.</param>
    public Enveloped(Enveloped enveloped) {
        Header = enveloped.Header;
        Trailer = enveloped.Trailer;
        Body = enveloped.Body;
        JsonObject = enveloped.JsonObject;
        }



    /// <summary>
    /// Constructor returining an envelope containing the object <paramref name="data"/>
    /// optionally encrypted under <paramref name="encryptionKey"/> and signed under
    /// <paramref name="signingKey"/>.
    /// </summary>
    /// <param name="data">The object to be enveloped.</param>
    /// <param name="signingKey">The signature key.</param>
    /// <param name="encryptionKey">The encryption key.</param>
    /// <param name="contentMeta">The value of the ContentMeta Header tag.</param>
    /// <param name="objectEncoding">The object encoding to use for the envelope payload.</param>
    public Enveloped(
                JsonObject data,
                CryptographicKey signingKey = null,
                CryptographicKey encryptionKey = null,
                ContentMeta contentMeta = null,
                ObjectEncoding objectEncoding = ObjectEncoding.JSON) : base (
                    data, signingKey, encryptionKey, contentMeta, objectEncoding) {
        
        //base(
        //            new CryptoParameters(signer: signingKey, recipient: encryptionKey),
        //            data.GetBytes(objectEncoding: objectEncoding), contentMeta: contentMeta) 

        }


    /// <summary>
    /// Decrypt and deserialize the envelope to obtain the typed contents and set the value of 
    /// <see cref="JsonObject.Envelope"/> to the original envelope data.
    /// </summary>
    /// <param name="keyCollection">Key collection to be used to find decryption keys and
    /// roots of trust for verification keys.</param>
    /// <param name="validation">Validation to be performed after decoding.</param>
    /// <returns>The decoded data.</returns>
    public T Decode(IKeyCollection keyCollection = null,
                EnvelopeValidation validation = EnvelopeValidation.None) {

        var result = StreamParseTag<T>(keyCollection);
        result.Envelope = this;
        return result;

        }
    }
