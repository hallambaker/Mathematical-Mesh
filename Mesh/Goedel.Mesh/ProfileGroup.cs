using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography;

namespace Goedel.Mesh {




    public partial class ProfileGroup {


        //public byte[] UDFBytes => ProfileMaster.UDFBytes;


        //public ProfileMaster ProfileMaster => profileMaster ??
        //    ProfileMaster.Decode(MasterProfile).CacheValue(out profileMaster);
        //ProfileMaster profileMaster = null;




        public ProfileGroup() {
            }


        public ProfileGroup(
            KeyPair keySign, KeyPair keyEncrypt) {
            KeyOfflineSignature = new PublicKey(keySign.KeyPairPublic());
            KeyEncryption = new PublicKey(keyEncrypt.KeyPairPublic());
            }


        public static ProfileGroup Generate(
                    IMeshMachine meshMachine,
                    CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                    CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default) {
            algorithmSign = algorithmSign.DefaultAlgorithmSign();
            algorithmEncrypt = algorithmEncrypt.DefaultAlgorithmEncrypt();
            var keySign = meshMachine.CreateKeyPair(algorithmSign, KeySecurity.Device, keyUses: KeyUses.Sign);
            var keyEncrypt = meshMachine.CreateKeyPair(algorithmEncrypt, KeySecurity.Device, keyUses: KeyUses.Encrypt);
            return new ProfileGroup(keySign, keyEncrypt);
            }


        public void AddMember(
                    IMeshMachine meshMachine, 
                    out ConnectionGroup connectionGroup,
                    out ActivationGroup activationGroup) {


            meshMachine.KeyCollection.LocatePrivate(KeyEncryption.UDF);

            connectionGroup = new ConnectionGroup() {
                };

            activationGroup = new ActivationGroup() {
                };

            }

        }
    }
