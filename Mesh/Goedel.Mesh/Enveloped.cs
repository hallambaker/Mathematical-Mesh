using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Cryptography.Jose;
using Goedel.Protocol;

using System.Numerics;
using System.Collections.Generic;
using System.IO;


namespace Goedel.Mesh {

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


    public partial class Enveloped<T> : DareEnvelope where T : MeshItem {


        T EnvelopedObject => JsonObject as T;

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
        /// Create a < 
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
        /// <paramref name="signingKey"/>. The constructor does not update the field
        /// <see cref="MeshItem.DareEnvelope"/>.
        /// </summary>
        /// <param name="data">The object to be enveloped.</param>
        /// <param name="signingKey">The signature key.</param>
        /// <param name="encryptionKey">The encryption key.</param>
        public Enveloped(
                    T data,
                    CryptoKey signingKey = null,
                    CryptoKey encryptionKey = null) : base(
                        new CryptoParameters(signer: signingKey, recipient: encryptionKey), 
                        data.GetBytes()) {
            }

        /// <summary>
        /// Convenience accessor
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Enveloped<T> Envelope(T data) => new Enveloped<T>(data.DareEnvelope);


        /// <summary>
        /// Decrypt and deserialize the envelope to obtain the typed contents and set the value of 
        /// <see cref="MeshItem.DareEnvelope"/> to this.
        /// </summary>
        /// <param name="keyCollection">Key collection to be used to find decryption keys and
        /// roots of trust for verification keys.</param>
        /// <returns>The decoded data.</returns>
        public T Decode(IKeyCollection keyCollection = null, 
                    EnvelopeValidation validation = EnvelopeValidation.None) {
            if (JsonObject != null) {
                return EnvelopedObject;
                }

            var result = MeshItem.Decode(this, keyCollection);
            result.DareEnvelope = this;

            return result as T;
            }
        }

    }
