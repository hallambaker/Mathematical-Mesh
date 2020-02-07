using Goedel.Cryptography;
using Goedel.Protocol;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;

using System.Collections.Generic;
using System;

namespace Goedel.Mesh {
    public partial class Message {

        /// <summary>
        /// Encode the message using the signature key <paramref name="signingKey"/>.
        /// </summary>
        /// <param name="signingKey">The signature key.</param>
        /// <returns>The enveloped, signed message.</returns>
        public DareEnvelope Encode(KeyPair signingKey) {
            var data = this.GetBytes();
            DareEnvelope = DareEnvelope.Encode(data, signingKey: signingKey);
            return DareEnvelope;
            }
        }

    public partial class MessageComplete {

        ///<summary>Constant for the response Accept.</summary>
        public const string Accept = "Accept";

        ///<summary>Constant for the response Reject.</summary>
        public const string Reject = "Reject";

        ///<summary>Constant for the response Read.</summary>
        public const string Read = "Read";

        ///<summary>Constant for the response Unread.</summary>
        public const string Unread = "Unread";

        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public MessageComplete() { }


        /// <summary>
        /// Constructor for a completion message.
        /// </summary>
        /// <param name="messageID">The message the completion message completes.</param>
        /// <param name="relationship">Relationship to the message.</param>
        /// <param name="responseID">The response code.</param>
        public MessageComplete(
                    string messageID, string relationship, string responseID = null) {
            var reference = new Reference() {
                MessageID = messageID,
                Relationship = relationship,
                ResponseID = responseID
                };
            References = new List<Reference>() { reference };

            }

        }



    public partial class AcknowledgeConnection {

        ///<summary>Convenience accessor for the inner <see cref="RequestConnection"/></summary>
        public RequestConnection MessageConnectionRequest => messageConnectionRequest ??
            RequestConnection.Decode(EnvelopedRequestConnection).CacheValue(out messageConnectionRequest);
        RequestConnection messageConnectionRequest;

        /// <summary>
        /// Decode <paramref name="envelope"/> and return the inner <see cref="AcknowledgeConnection"/>
        /// </summary>
        /// <param name="envelope">The envelope to decode.</param>
        /// <returns>The decoded profile.</returns>
        public static new AcknowledgeConnection Decode(DareEnvelope envelope) =>
            MeshItem.Decode(envelope) as AcknowledgeConnection;
        }


    public partial class RequestConnection {


        ///<summary>Convenience accessor for the inner <see cref="ProfileDevice"/></summary>
        public ProfileDevice ProfileDevice => profileDevice ??
            ProfileDevice.Decode(EnvelopedProfileDevice).CacheValue(out profileDevice);
        ProfileDevice profileDevice;

        /// <summary>
        /// Decode <paramref name="envelope"/> and return the inner <see cref="RequestConnection"/>
        /// </summary>
        /// <param name="envelope">The envelope to decode.</param>
        /// <returns>The decoded profile.</returns>
        public static new RequestConnection Decode(DareEnvelope envelope) =>
            MeshItem.Decode(envelope) as RequestConnection;

        /// <summary>
        /// Verified decoding of the enveloped request <paramref name="envelope"/>
        /// </summary>
        /// <param name="envelope">The envelope to decode.</param>
        /// <returns>The decoded profile (if signature verification succeeds).</returns>
        public static RequestConnection Verify(DareEnvelope envelope) {
            var result = Decode(envelope) as RequestConnection;

            // ToDo: put the verification code in here.


            return result;
            }
        }

    public partial class RespondConnection {
        KeyCollection keyCollection;

        /// <summary>
        /// Decode <paramref name="envelope"/> and return the inner <see cref="RespondConnection"/>
        /// </summary>
        /// <param name="envelope">The envelope to decode.</param>
        /// <param name="keyCollection">Key collection to use to obtain decryption keys.</param>
        /// <returns>The decoded profile.</returns>
        public static RespondConnection Decode(DareEnvelope envelope, 
                    KeyCollection keyCollection=null) {

            if (envelope == null) {
                return null;
                }

            var plaintext = envelope.GetPlaintext(keyCollection);

            Console.WriteLine(plaintext.ToUTF8());
            var result = FromJSON(plaintext.JSONReader(), true);
            result.DareEnvelope = envelope;
            result.keyCollection = keyCollection;
            return result;
            }


        /// <summary>
        /// Validate the RespondConnection message in the context of <paramref name="profileDevice"/>
        /// and <paramref name="keyCollection"/>.
        /// </summary>
        /// <param name="profileDevice">The profile device.</param>
        /// <param name="keyCollection">Key collection to use to obtain decryption keys.</param>
        public void Validate(ProfileDevice profileDevice, KeyCollection keyCollection) {
            profileDevice.Future();
            keyCollection ??= this.keyCollection;
            keyCollection.Future();
            
            // Validate the chain for the device to master

            // Profile Master is self Signed
            // Device Profile connection is valid under Profile Master
            // Device Activation for master is valid


            // Foreach Account 
            //  // Validate the chain for the device to account

            //  // Profile Account is self Signed
            //  // Account connection is valid under Profile Master
            //  // Device Account connection is valid under Profile Account
            //  // Device Activation for Account is valid

            }

        }
    }
