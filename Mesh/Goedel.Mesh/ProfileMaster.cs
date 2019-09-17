using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Protocol;

namespace Goedel.Mesh {
    public partial class ProfileMesh {

        public string UDF => KeyOfflineSignature.UDF;
        public byte[] UDFBytes => KeyOfflineSignature.KeyPair.PKIXPublicKey.UDFBytes(512);

        public override string _PrimaryKey => KeyOfflineSignature.UDF;



        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public ProfileMesh() {
            }


        public ProfileMesh(
                    KeyPair keySign, KeyPair keyEscrow, KeyPair keyEncrypt) {
            KeyOfflineSignature = new PublicKey(keySign.KeyPairPublic());
            KeyEncryption = new PublicKey(keyEncrypt.KeyPairPublic());
            //MasterEscrowKeys = new List<PublicKey> { new PublicKey(keyEscrow.KeyPairPublic()) };
            }

        public static ProfileMesh Generate(
                    IMeshMachine meshMachine,
                    CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                    CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default) {

            algorithmSign = algorithmSign.DefaultAlgorithmSign();
            algorithmEncrypt = algorithmEncrypt.DefaultAlgorithmEncrypt();
            var keySign = meshMachine.CreateKeyPair(algorithmSign, KeySecurity.Device, keyUses: KeyUses.Sign);
            var keyEscrow = meshMachine.CreateKeyPair(algorithmEncrypt, KeySecurity.Device, keyUses: KeyUses.Encrypt);
            var keyEncrypt = meshMachine.CreateKeyPair(algorithmEncrypt, KeySecurity.Device, keyUses: KeyUses.Encrypt);
            return new ProfileMesh(keySign, keyEscrow, keyEncrypt);
            }




        public static new ProfileMesh Decode(DareEnvelope message) {
            if (message == null) {
                return null;
                }
            var result = FromJSON(message.GetBodyReader(), true);
            result.DareEnvelope = message;
            return result;
            }

        }

    }
