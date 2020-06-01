using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;
using Goedel.Cryptography.Jose;
using Goedel.IO;
using Goedel.Protocol;
namespace Goedel.Mesh {
    public partial class DevicePreconfiguration {

        ///<summary>Base constructor for deserialization.</summary>
        public DevicePreconfiguration() {
            }


        /// <summary>
        /// Constructor to generate and populate the assertion using values derrived
        /// from <paramref name="privateKey"/> and <paramref name="connectUri"/>.
        /// </summary>
        /// <param name="privateKey"></param>
        /// <param name="connectUri"></param>
        public DevicePreconfiguration(
                    Key privateKey, 
                    string connectUri) {
            
            PrivateKey = privateKey;
            ConnectUri = connectUri;
            }



        public static DevicePreconfiguration FromFile(string filename) {
            using var inputStream = filename.OpenFileRead();
            using var reader = new JSONReader(inputStream);

            return FromJSON(reader, tagged: true);

            }


        }
    }
