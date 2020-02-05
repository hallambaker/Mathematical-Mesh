using Goedel.Cryptography;
using Goedel.Utilities;
using Goedel.Cryptography.Jose;

namespace Goedel.Mesh {




    public partial class ProfileGroup {


        //public byte[] UDFBytes => ProfileMaster.UDFBytes;


        //public ProfileMaster ProfileMaster => profileMaster ??
        //    ProfileMaster.Decode(MasterProfile).CacheValue(out profileMaster);
        //ProfileMaster profileMaster = null;



        /// <summary>
        /// Blank constructor for use by deserializers.
        /// </summary>
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


        /// <summary>
        /// Add a member to the group.
        /// </summary>
        /// <param name="keyCollection">Key collection to acquire the group private key(s) from
        /// </param>
        /// <param name="user">The user to add.</param>
        /// <returns>The group activation record for the user.</returns>
        public DeviceRecryptionKey AddMember(
                    KeyCollection keyCollection,
                    Contact user) {


            var key = keyCollection.LocatePrivateKeyPair(KeyEncryption.UDF) as KeyPairAdvanced;
            throw new NYI();

            //key.GenerateRecryptionPair(out var serviceKey, out var deviceKey);

            ////var keyComposite = new KeyComposite(deviceKey);
            //var deviceRecryptionKey = new DeviceRecryptionKey(user, serviceKey, deviceKey);


            //// need to encrypt to the user's encryption key

            //return deviceRecryptionKey;
            }

        }

    /// <summary>
    /// Remove and replace with activation/connection records.
    /// </summary>
    public partial class DeviceRecryptionKey {
        public DeviceRecryptionKey() {
            }

        public DeviceRecryptionKey(Contact user, KeyPair serviceKey, KeyPair deviceKey) {
            }


        public GroupInvitation MakeInvitation(Contact user) => throw new NYI();

        }

    }
