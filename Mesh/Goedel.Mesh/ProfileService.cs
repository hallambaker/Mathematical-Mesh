﻿using Goedel.Cryptography;
using Goedel.Cryptography.Dare;

namespace Goedel.Mesh {
    public partial class ProfileService {
        public string UDF => KeyOfflineSignature.UDF;

        public ProfileService() { }

        public ProfileService(KeyPair keySign) => KeyOfflineSignature = new PublicKey(keySign.KeyPairPublic());

        public static ProfileService Generate(
            IMeshMachine meshMachine,
            CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default) {



            algorithmSign = algorithmSign.DefaultAlgorithmSign();
            var keySign = meshMachine.CreateKeyPair(algorithmSign, KeySecurity.Device, keyUses: KeyUses.Sign);

            var result = new ProfileService(keySign);
            result.Sign(keySign);
            return result;
            }

        public static new ProfileService Decode(DareEnvelope message) {
            if (message == null) {
                return null;
                }
            var result = FromJSON(message.GetBodyReader(), true);
            result.DareEnvelope = message;
            return result;
            }





        public ProfileHost CreateHost(IMeshMachine meshMachine,
                    CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default) => ProfileHost.Generate(meshMachine, algorithmSign);

        }

    public partial class ProfileHost {

        public string UDF => KeyOfflineSignature.UDF;

        public ProfileHost() { }

        public ProfileHost(KeyPair keySign,
                    KeyPair keyAuth) {
            KeyOfflineSignature = new PublicKey(keySign.KeyPairPublic());
            KeyAuthentication = new PublicKey(keyAuth.KeyPairPublic());
            }

        public static ProfileHost Generate(
            IMeshMachine meshMachine,
            CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default) {

            algorithmSign = algorithmSign.DefaultAlgorithmSign();
            var keyAuth = meshMachine.CreateKeyPair(algorithmSign, KeySecurity.Device, keyUses: KeyUses.KeyAgreement);
            var keySign = meshMachine.CreateKeyPair(algorithmSign, KeySecurity.Device, keyUses: KeyUses.Sign);

            var result = new ProfileHost(keySign, keyAuth);
            result.Sign(keySign);
            return result;
            }

        public static new ProfileHost Decode(DareEnvelope message) {
            if (message == null) {
                return null;
                }
            var result = FromJSON(message.GetBodyReader(), true);
            result.DareEnvelope = message;
            return result;
            }

        }
    }