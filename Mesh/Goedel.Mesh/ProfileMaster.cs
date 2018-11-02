using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Protocol;

namespace Goedel.Mesh {
    public partial class ProfileMaster {


        public override string _PrimaryKey => MasterSignatureKey.UDF;

        /// <summary>
        /// The signed device profile
        /// </summary>
        public DareMessage ProfileMasterSigned { get; private set; }

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
                        ProfileDevice profileDevice,
                        KeyPair keyPublicSign,
                        KeyPair keyPublicEncrypt) {

            List<PublicKey> masterEscrowKeys=null;
            if (keyPublicEncrypt != null) {
                masterEscrowKeys = new List<PublicKey> {
                    new PublicKey(keyPublicEncrypt.KeyPairPublic()) };
                }

            var ProfileMaster = new ProfileMaster() {
                MasterSignatureKey = new PublicKey(keyPublicSign.KeyPairPublic()),
                MasterEscrowKeys = masterEscrowKeys
                };
            ProfileMaster.Add(profileDevice);

            var bytes = profileDevice.GetBytes(tag: true);

            ProfileMaster.ProfileMasterSigned = DareMessage.Encode(bytes,
                    SigningKey: keyPublicSign, ContentType: "application/mmm");
            return ProfileMaster;
            }


        public void Add(ProfileDevice profileDevice) {
            OnlineSignatureKeys = OnlineSignatureKeys ?? new List<PublicKey>();
            OnlineSignatureKeys.Add(profileDevice.DeviceSignatureKey);
            }

        }

    }
