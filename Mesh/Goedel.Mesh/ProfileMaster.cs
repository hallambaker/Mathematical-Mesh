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


        public ProfileMaster(
                    KeyPair keySign, KeyPair keyEscrow, KeyPair keyEncrypt) {
            KeySignature = new PublicKey(keySign.KeyPairPublic());
            KeyEncryption = new PublicKey(keyEncrypt.KeyPairPublic());
            //MasterEscrowKeys = new List<PublicKey> { new PublicKey(keyEscrow.KeyPairPublic()) };
            }

        public static ProfileMaster Generate(
                    IMeshMachine meshMachine,
                    CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                    CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default) {

            algorithmSign = algorithmSign.DefaultAlgorithmSign();
            algorithmEncrypt = algorithmEncrypt.DefaultAlgorithmEncrypt();
            var keySign = meshMachine.CreateKeyPair(algorithmSign, KeySecurity.Device, keyUses: KeyUses.Sign);
            var keyEscrow = meshMachine.CreateKeyPair(algorithmEncrypt, KeySecurity.Device, keyUses: KeyUses.Encrypt);
            var keyEncrypt = meshMachine.CreateKeyPair(algorithmEncrypt, KeySecurity.Device, keyUses: KeyUses.Encrypt);
            return new ProfileMaster(keySign, keyEscrow, keyEncrypt);
            }




        public static new ProfileMaster Decode(DareEnvelope message) {
            if (message == null) {
                return null;
                }
            var result = FromJSON(message.GetBodyReader(), true);
            result.DareEnvelope = message;
            return result;
            }

        }

    }
