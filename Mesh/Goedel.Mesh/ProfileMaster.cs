using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Protocol;

namespace Goedel.Mesh {
    public partial class ProfileMaster {

        public string UDF => KeySignature.UDF;
        public byte[] UDFBytes => KeySignature.KeyPair.PKIXPublicKey.UDFBytes(512);

        public override string _PrimaryKey => KeySignature.UDF;



        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public ProfileMaster() {
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

            var profileMaster = new ProfileMaster() {
                KeySignature = new PublicKey(keyPublicSign.KeyPairPublic()),
                MasterEscrowKeys = masterEscrowKeys
                };

            var bytes = profileMaster.GetBytes(tag: true);

            profileMaster.DareMessage = DareMessage.Encode(bytes,
                    signingKey: keyPublicSign, contentType: "application/mmm");
            return profileMaster;
            }

        public static ProfileMaster Generate(
                    IMeshMachine meshMachine,
                    CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                    CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default) {

            algorithmSign = algorithmSign.DefaultAlgorithmSign();
            algorithmEncrypt = algorithmEncrypt.DefaultAlgorithmEncrypt();
            var keySign = meshMachine.CreateKeyPair(algorithmSign, KeySecurity.Device, keyUses: KeyUses.Sign);
            var keyEncrypt = meshMachine.CreateKeyPair(algorithmEncrypt, KeySecurity.Device, keyUses: KeyUses.Encrypt);
            return new ProfileMaster() {
                KeySignature = new PublicKey(keySign.KeyPairPublic()),
                MasterEscrowKeys = new List<PublicKey> { new PublicKey(keyEncrypt.KeyPairPublic()) }
                    };
            }


        public DareMessage Sign(KeyPair SignatureKey) {
            DareMessage = DareMessage.Encode(GetBytes(true), signingKey: SignatureKey);
            return DareMessage;
            }

        public static new ProfileMaster Decode(DareMessage message) {
            var result = FromJSON(message.GetBodyReader(), true);
            result.DareMessage = message;
            return result;
            }




        // ***************   Old stuff to be deleted.
        public CatalogEntryDevice Add(IMeshMachine meshMachine, ProfileDevice profileDevice, bool Administrator) {

            var catalogEntryDevice = new CatalogEntryDevice(meshMachine, profileDevice);

            if (Administrator) {
                catalogEntryDevice.ActivateAdmin(null);
                OnlineSignatureKeys = OnlineSignatureKeys ?? new List<PublicKey>();
                OnlineSignatureKeys.Add(profileDevice.KeySignature);
                }

            return catalogEntryDevice;
            }

        public bool IsAdministrator(string UDF) {
            Assert.NotNull(OnlineSignatureKeys, InvalidProfile.Throw);

            foreach (var admin in OnlineSignatureKeys) {
                if (admin.UDF == UDF) {
                    return true;
                    }
                }
            return false;
            }







        }

    }
