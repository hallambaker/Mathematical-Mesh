using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Protocol;

namespace Goedel.Mesh {
    public partial class ProfileMaster {

        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public ProfileMaster() {
            }

        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public ProfileMaster(DareMessage dareMessage) {
            }


        /// <summary>
        /// Create a new master profile.
        /// </summary>
        /// <param name="algorithmSign"></param>
        /// <param name="algorithmEncrypt"></param>
        public static ProfileMaster Generate(
                        
                        CryptoAlgorithmID algorithmSign=CryptoAlgorithmID.Default,
                        CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default) => throw new NYI();




        }
    }
