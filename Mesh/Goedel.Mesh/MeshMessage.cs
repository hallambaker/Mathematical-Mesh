using Goedel.Cryptography;
using Goedel.Protocol;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;

using System.Collections.Generic;
using System;

namespace Goedel.Mesh {
    public partial class Message {

        public DareEnvelope Encode(KeyPair signingKey) {
            var data = this.GetBytes();
            DareEnvelope = DareEnvelope.Encode(data, signingKey: signingKey);
            return DareEnvelope;
            }
        }

    public partial class MessageComplete {

        public const string Accept = "Accept";
        public const string Reject = "Reject";
        public const string Read = "Read";
        public const string Unread = "Unread";


        public MessageComplete() { }

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

        public RequestConnection MessageConnectionRequest => messageConnectionRequest ??
            RequestConnection.Decode(EnvelopedRequestConnection).CacheValue(out messageConnectionRequest);
        RequestConnection messageConnectionRequest;

        public static new AcknowledgeConnection Decode(DareEnvelope dareEnvelope) =>
            MeshItem.Decode(dareEnvelope) as AcknowledgeConnection;
        }


    public partial class RequestConnection {

        public static new RequestConnection Decode(DareEnvelope dareEnvelope) =>
            MeshItem.Decode(dareEnvelope) as RequestConnection;

        public ProfileDevice ProfileDevice => profileDevice ??
            ProfileDevice.Decode(EnvelopedProfileDevice).CacheValue(out profileDevice);
        ProfileDevice profileDevice;


        public static RequestConnection Verify(DareEnvelope dareEnvelope) {
            var result = Decode(dareEnvelope) as RequestConnection;

            // ToDo: put the verification code in here.


            return result;
            }
        }

    public partial class RespondConnection {
        KeyCollection keyCollection;

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



        public void Validate(ProfileDevice profileDevice, KeyCollection keyCollection) {

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
