using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Cryptography.Jose;
using Goedel.Utilities;

namespace Goedel.Mesh {
    public class MeshUri {

        public static string ConnectUri (string account, string pin) =>
             $"{Constants.MeshConnectURI}://{account}/{pin}";


        public static string GetConnectPin(PrivateKeyUDF privateKeyUDF, string accountAddress) =>
            throw new NYI();


        }
    }
