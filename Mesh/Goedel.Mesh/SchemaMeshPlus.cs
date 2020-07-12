using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Protocol;
using Goedel.Utilities;

using System;
using System.Text;
namespace Goedel.Mesh {



    public partial class MeshItem {

        /// <summary>
        /// The DareEnvelope encapsulation of this object instance.
        /// </summary>
        public virtual DareEnvelope DareEnvelope { get; protected set; }


        ///<summary>The key collection that was used to decode this object instance.</summary>
        public IKeyLocate KeyCollection;


        ///<summary>Initialization property, used to force initialization of the 
        ///Json parser dictionaries.</summary>
        public static object Initialize => null;

        ///<summary>Reports the status of the item. </summary>
        public bool? Status = null;

        ///<summary>Reports true if the item status is open </summary>
        public bool Open => Status == true;


        ///<summary>Reports true if the item status is closed </summary>
        public bool Closed => Status == true;

        static MeshItem() => AddDictionary(ref _TagDictionary);


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

        ///// <summary>
        ///// Decode the specified <paramref name="dareEnvelope"/>>
        ///// </summary>
        ///// <param name="dareEnvelope">The envelope to decode.</param>
        ///// <returns>The decoded <see cref="MeshItem"/></returns>
        //public static MeshItem Decode(DareEnvelope dareEnvelope) {
        //    var result = FromJSON(dareEnvelope.GetBodyReader(), true);
        //    result.DareEnvelope = dareEnvelope;
        //    return result;
        //    }

        /// <summary>
        /// Decode and parse the data 
        /// </summary>
        /// <param name="envelope">The enveloped data.</param>
        /// <param name="keyCollection">The key collaecion to use to find the decryption key.</param>
        /// <returns>The decoded data item</returns>
        public static MeshItem Decode(DareEnvelope envelope, IKeyLocate keyCollection =null) {

            if (envelope == null) {
                return null;
                }

            var plaintext = envelope.GetPlaintext(keyCollection);

            //Console.WriteLine(plaintext.ToUTF8());
            var result = FromJson(plaintext.JsonReader(), true);
            result.DareEnvelope = envelope;
            result.KeyCollection = keyCollection;
            return result;

            }

        /// <summary>
        /// Encode the message using the signature key <paramref name="signingKey"/>.
        /// </summary>
        /// <param name="signingKey">The signature key.</param>
        /// <param name="encryptionKey">The encryption key.</param>
        /// <returns>The enveloped, signed message.</returns>
        public virtual DareEnvelope Encode(CryptoKey signingKey = null, CryptoKey encryptionKey = null) {

            var data = this.GetBytes();
            var contentMeta = new ContentMeta() {
                UniqueID = _PrimaryKey,
                Created = DateTime.Now,
                ContentType = Constants.IanaTypeMeshObject,
                MessageType = _Tag
                };

            DareEnvelope = DareEnvelope.Encode(data, contentMeta: contentMeta,
                signingKey: signingKey, encryptionKey: encryptionKey);

            DareEnvelope.Header.EnvelopeID = _PrimaryKey;

            return DareEnvelope;
            }


        /// <summary>
        /// Append a description of the instance to the StringBuilder <paramref name="builder"/> with
        /// a leading indent of <paramref name="indent"/> units. The cryptographic context from
        /// thekey collection <paramref name="keyCollection"/> is used to decrypt any encrypted data.
        /// </summary>
        /// <param name="builder">The string builder to write to.</param>
        /// <param name="indent">The number of units to indent the presentation.</param>
        /// <param name="keyCollection">The key collection to use to obtain decryption keys.</param>
        public virtual void ToBuilder(StringBuilder builder, int indent = 0, IKeyCollection keyCollection = null) =>
            _ = builder.AppendLine($"[{_Tag}]");


        }


    public partial class Assertion {

        /// <summary>
        /// Create an envelope with the signed assertion.
        /// </summary>
        /// <param name="SignatureKey">The key to sign the assertion under.</param>
        /// <returns>The signed assertion.</returns>
        public DareEnvelope Sign(CryptoKey SignatureKey) {
            DareEnvelope = DareEnvelope.Encode(GetBytes(true), signingKey: SignatureKey);
            return DareEnvelope;
            }

        /// <summary>
        /// Decode <paramref name="envelope"/> and return the inner <see cref="Assertion"/>
        /// </summary>
        /// <param name="envelope">The envelope to decode.</param>
        /// <param name="keyCollection">Key collection to use to obtain decryption keys.</param>
        /// <returns>The decoded profile.</returns>
        public static new Assertion Decode(DareEnvelope envelope,
                    IKeyLocate keyCollection = null) =>
                        MeshItem.Decode(envelope, keyCollection) as Assertion;

        }

    public partial class Message : IProcessResult {


        ///<summary>Always false for an error result.</summary>
        public virtual bool Success => true;

        ///<summary>The error report code</summary>
        public virtual string ErrorReport => null;


        /// <summary>
        /// Return the identifier for a response to this message.
        /// </summary>
        /// <returns>The response identifier.</returns>
        public string GetResponseID() => MakeResponseID(MessageID);

        /// <summary>
        /// Generate the response identifier as a deterministic function of the request
        /// identifier <paramref name="udf"/>
        ///  using the digest algorithm specified in the request identifier (if known
        /// and supported), otherwise using SHA_3_512.
        /// </summary>
        /// <param name="udf">The request identifier to construct the response from.</param>
        /// <returns>The response identifier.</returns>
        public static string MakeResponseID(string udf) {
            var buffer = udf.FromBase32();
            var length = (buffer.Length).Minimum(128);
            switch ((UdfTypeIdentifier)buffer[0]) {
                case (UdfTypeIdentifier.DigestSHA_3_512): {
                    return UDF.ContentDigestOfUDF(udf, length, CryptoAlgorithmId.SHA_3_512);
                    }

                default: {
                    return UDF.ContentDigestOfUDF(udf, length);
                    }
                }
            }

        }
    public partial class MessageError {
        ///<summary>Always false for an error result.</summary>
        public override bool Success => false;

        ///<summary>The error report code</summary>
        public override string ErrorReport => ErrorCode;
        }
    }
