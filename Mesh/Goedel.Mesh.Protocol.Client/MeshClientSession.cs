﻿using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Mesh;
using Goedel.Protocol;

namespace Goedel.Mesh.Protocol.Client {
    public class MeshClientSession : JpcSession {
        PublicKey AuthenticationKey;

        public MeshClientSession(ContextDevice contextDevice=null) {
            AuthenticationKey = contextDevice?.ProfileDevice.AuthenticationKey;
            UDF = contextDevice?.ProfileDevice.AuthenticationKey.UDF;
            Account = contextDevice?.AssertionAccount?.Account;
            }

        public override bool Authenticate(string UDF) => UDF == AuthenticationKey.UDF;
        }
    }
