using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;

using System.Collections.Generic;

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


    }
