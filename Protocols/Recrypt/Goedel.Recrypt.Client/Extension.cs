using System;
using System.Collections.Generic;
using Goedel.Utilities;
using Goedel.Mesh;
using Goedel.Mesh.Portal.Client;
using Goedel.Recrypt;
using Goedel.Utilities;

namespace Goedel.Recrypt.Client {

    /// <summary>
    /// Extensions class
    /// </summary>
    public static partial class Extension {

        public static RecryptionKey GetEncryptionKey (
                this SessionPersonal SessionPersonal,
                string RecrytionGroup) {

            // create a client 
            var Client = new RecryptClient(RecrytionGroup);

            // request the recryption key
            var Response = Client.RecryptKey(RecrytionGroup);

            var RecryptionKey = Response.RecryptionKey;

            RecryptionKey.RecrytionGroup = RecrytionGroup;

            return RecryptionKey;
            }
        }

    }
