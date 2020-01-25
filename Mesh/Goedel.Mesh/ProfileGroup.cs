using Goedel.Cryptography;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Protocol;
using Goedel.Utilities;

namespace Goedel.Mesh {




    public partial class ProfileGroup {


        //public byte[] UDFBytes => ProfileMaster.UDFBytes;


        //public ProfileMaster ProfileMaster => profileMaster ??
        //    ProfileMaster.Decode(MasterProfile).CacheValue(out profileMaster);
        //ProfileMaster profileMaster = null;




        public ProfileGroup() {
            }

        /// <summary>
        /// Construct a new ProfileDevice instance from a <see cref="PrivateKeyUDF"/>
        /// seed.
        /// </summary>
        /// <param name="keyCollection">The keyCollection to manage and persist the generated keys.</param>
        /// <param name="secretSeed">The secret seed value.</param>
        /// <param name="persist">If <see langword="true"/> persist the secret seed value to
        /// <paramref name="keyCollection"/>.</param>
        public ProfileGroup(
                    KeyCollection keyCollection,
                    PrivateKeyUDF secretSeed,
                    bool persist = false) {

            var keyEncrypt = Derive(keyCollection, secretSeed, Constants.UDFMeshKeySufixEncrypt);
            var keySign = Derive(keyCollection, secretSeed, Constants.UDFMeshKeySufixSign);

            KeyOfflineSignature = new PublicKey(keySign.KeyPairPublic());
            KeyEncryption = new PublicKey(keyEncrypt.KeyPairPublic());

            if (persist) {
                keyCollection.Persist(KeyOfflineSignature.UDF, secretSeed, false);
                }
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


        public DeviceRecryptionKey AddMember(
                    IMeshMachine meshMachine,
                    Contact user) {


            var key = meshMachine.KeyCollection.LocatePrivateKeyPair(KeyEncryption.UDF) as KeyPairAdvanced;
            throw new NYI();

            //key.GenerateRecryptionPair(out var serviceKey, out var deviceKey);

            ////var keyComposite = new KeyComposite(deviceKey);
            //var deviceRecryptionKey = new DeviceRecryptionKey(user, serviceKey, deviceKey);


            //// need to encrypt to the user's encryption key

            //return deviceRecryptionKey;
            }

        }


    public partial class DeviceRecryptionKey {
        public DeviceRecryptionKey() {
            }

        public DeviceRecryptionKey(Contact user, KeyPair serviceKey, KeyPair deviceKey) {
            }


        public GroupInvitation MakeInvitation(Contact user) => throw new NYI();

        }

    }
