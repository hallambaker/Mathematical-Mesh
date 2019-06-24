using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;
using Goedel.Protocol;

namespace Goedel.Mesh.Client {
    public class MeshClientSession : JpcSession {
        PublicKey AuthenticationKey;

        public MeshClientSession(string serviceID) : base (serviceID) {
            throw new NYI();

            //AuthenticationKey = contextDevice?.ProfileDevice.KeyAuthentication;
            //UDF = contextDevice?.ProfileDevice.KeyAuthentication.UDF;
            //Account = contextDevice?.AssertionAccount?.Account[0];
            }

        public override bool Authenticate(string UDF) => UDF == AuthenticationKey.UDF;
        }
    }
