using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Mesh;

namespace Goedel.Mesh.Client {
    public partial class ProfileEntry {


        public ProfileDevice ProfileDevice => profileDevice ??
                ProfileDevice.Decode(EncodedProfileDevice).CacheValue(out profileDevice);
        ProfileDevice profileDevice;


        }

    public partial class AdminEntry {
        /// <summary>
        /// Default constructor used for deserialization.
        /// </summary>
        public AdminEntry() {
            }

        /// <summary>
        /// Generate a new Admin Entry
        /// </summary>
        /// <param name="profileDevice"></param>
        /// <param name="algorithmSign"></param>
        /// <param name="algorithmEncrypt"></param>
        /// <returns></returns>
        public static AdminEntry Generate(
                IMeshMachine meshMachine,
                CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default) {

            var profileMaster = ProfileMaster.Generate(meshMachine, algorithmSign, algorithmEncrypt);


            return Generate(meshMachine, profileMaster);
            }

        public static AdminEntry Generate(
                IMeshMachine meshMachine,
                ProfileMaster profileMaster ) {
            return new AdminEntry() {

                };

            }


        }

    public partial class AccountEntry {


        }


    public partial class PendingEntry {


        }

    }