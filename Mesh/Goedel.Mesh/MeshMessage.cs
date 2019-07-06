using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;

namespace Goedel.Mesh {
    public partial class Message {

        public DareEnvelope Encode(KeyPair signingKey) {
            var data = this.GetBytes();
            DareEnvelope = DareEnvelope.Encode (data, signingKey: signingKey);
            return DareEnvelope;
            }
        }

    public partial class MessageComplete  {

        public const string Accept = "Accept";
        public const string Reject = "Reject";
        public const string Read = "Read";
        public const string Unread = "Unread";


        public MessageComplete() { }

        public MessageComplete(
                    string messageID, string relationship, string responseID=null) {
            var reference = new Reference() {
                MessageID = messageID,
                Relationship = relationship,
                ResponseID = responseID
                };
            References = new List<Reference>() { reference };

            }

        }



    public partial class MessageConnectionResponse {

        public MessageConnectionRequest MessageConnectionRequest => messageConnectionRequest ??
            MessageConnectionRequest.Decode(EnvelopedMessageConnectionRequest).CacheValue(out messageConnectionRequest);
        MessageConnectionRequest messageConnectionRequest;

        public static new MessageConnectionResponse Decode(DareEnvelope dareEnvelope) =>
            MeshItem.Decode(dareEnvelope) as MessageConnectionResponse;
        }


    public partial class MessageConnectionRequest {

        public static new MessageConnectionRequest Decode(DareEnvelope dareEnvelope) =>
            MeshItem.Decode(dareEnvelope) as MessageConnectionRequest;

        public ProfileDevice ProfileDevice => profileDevice ??
            ProfileDevice.Decode(EnvelopedProfileDevice).CacheValue(out profileDevice);
        ProfileDevice profileDevice;


        public static MessageConnectionRequest Verify(DareEnvelope dareEnvelope) {
            var result = Decode(dareEnvelope) as MessageConnectionRequest;

            // ToDo: put the verification code in here.


            return result;
            }
        }


    }
