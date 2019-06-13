using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;

namespace Goedel.Mesh {
    public partial class MeshMessage {

        public DareEnvelope Encode(KeyPair keyPair) {
            throw new NYI();
            DareEnvelope = null;
            return DareEnvelope;
            }
        }

    public partial class MeshMessageComplete  {

        public const string Accept = "Accept";
        public const string Reject = "Reject";
        public const string Read = "Read";
        public const string Unread = "Unread";


        public MeshMessageComplete() { }

        public MeshMessageComplete(
                    string messageID, string relationship, string responseID=null) {
            var reference = new Reference() {
                MessageID = messageID,
                Relationship = relationship,
                ResponseID = responseID
                };
            References = new List<Reference>() { reference };

            }

        }



    public partial class MessageConnectionRequest {

        //ProfileDevice ProfileDevice => profileDevice ??
        //    ProfileDevice.Decode(DeviceProfile).CacheValue(out profileDevice);
        //ProfileDevice profileDevice;


        //public string MakeWitness(byte[] meshProfileUDF) {
        //    var s1 = UDF.MakeWitness(meshProfileUDF, ServerNonce);
        //    var s2 = UDF.MakeWitness(ProfileDevice.UDFBytes, ClientNonce);

        //    return UDF.MakeWitnessString(s1, s2);
        //    }
        }
    }
