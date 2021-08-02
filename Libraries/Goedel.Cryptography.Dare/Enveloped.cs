//  Copyright © 2020 Threshold Secrets llc
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

using System.Collections.Generic;

using Goedel.Protocol;


namespace Goedel.Cryptography.Dare {

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
    public partial class Enveloped<T> : DareEnvelope where T : JsonObject {

        ///<summary>The enveloped object cast to the generic type.</summary> 
        public T EnvelopedObject => JsonObject as T;

        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public Enveloped() {
            }

        /// <summary>
        /// Construct a typed copy of the envelope <paramref name="enveloped"/> with the same
        /// Header, Body, Trailer and JSONObject.
        /// </summary>
        /// <param name="enveloped">The envelope to copy.</param>
        public Enveloped(DareEnvelope enveloped) {
            Header = enveloped.Header;
            Body = enveloped.Body;
            Trailer = enveloped.Trailer;
            JsonObject = enveloped.JsonObject;
            }


        /// <summary>
        /// Constructor returning a typed envelope. 
        /// </summary>
        /// <param name="cryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <param name="contentMeta">The content metadata</param>
        /// <param name="plaintext">The payload plaintext. If specified, the plaintext will be used to
        /// create the message body. Otherwise the body is specified by calls to the Process method.</param>
        /// <param name="cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
        /// <param name="dataSequences">Data sequences to be converted to an EDS and presented 
        ///     as an EDSS header entry.</param>
        public Enveloped(
                    CryptoParameters cryptoParameters,
                    byte[] plaintext,
                    ContentMeta contentMeta = null,
                    byte[] cloaked = null,
                    List<byte[]> dataSequences = null
                    ) : base(cryptoParameters, plaintext, contentMeta, cloaked, dataSequences) {
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
                    T data,
                    CryptoKey signingKey = null,
                    CryptoKey encryptionKey = null,
                    ContentMeta contentMeta = null,
                    ObjectEncoding objectEncoding = ObjectEncoding.JSON) : base(
                        new CryptoParameters(signer: signingKey, recipient: encryptionKey),
                        data.GetBytes(objectEncoding: objectEncoding), contentMeta: contentMeta) {
            data.Enveloped = this;
            //this.JsonObject = data;
            }

        /// <summary>
        /// Convenience accessor creating an envelope around <paramref name="data"/> encoded in
        /// encoding <paramref name="objectEncoding"/>. If present, the data is signed under 
        /// <paramref name="signingKey"/>. If present, the data is encrypted under 
        /// <paramref name="encryptionKey"/>.
        /// </summary>
        /// <param name="data">The object to be enveloped.</param>
        /// <param name="signingKey">The signature key.</param>
        /// <param name="encryptionKey">The encryption key.</param>
        /// <param name="contentMeta">The value of the ContentMeta Header tag.</param>
        /// <param name="objectEncoding">The object encoding to use for the envelope payload.</param>
        /// <returns></returns>
        public static Enveloped<T> Envelope(T data,
                    CryptoKey signingKey = null,
                    CryptoKey encryptionKey = null,
                    ContentMeta contentMeta = null,
                    ObjectEncoding objectEncoding = ObjectEncoding.JSON) =>
            new(data, signingKey, encryptionKey, contentMeta, objectEncoding);


        /// <summary>
        /// Decrypt and deserialize the envelope to obtain the typed contents and set the value of 
        /// <see cref="JsonObject.Enveloped"/> to the original envelope data.
        /// </summary>
        /// <param name="keyCollection">Key collection to be used to find decryption keys and
        /// roots of trust for verification keys.</param>
        /// <param name="validation">Validation to be performed after decoding.</param>
        /// <returns>The decoded data.</returns>
        public T Decode(IKeyCollection keyCollection = null,
                    EnvelopeValidation validation = EnvelopeValidation.None) {
            if (JsonObject != null) {
                return EnvelopedObject;
                }

            //var result = MeshItem.Decode(this, keyCollection);

            var plaintext = GetPlaintext(keyCollection);
            //var reader = new JsonBcdReader(plaintext);
            var result = DecodeJsonObject(keyCollection);

            result.KeyLocate = keyCollection;

            result.Enveloped = this;

            return result as T;
            }
        }

    }
