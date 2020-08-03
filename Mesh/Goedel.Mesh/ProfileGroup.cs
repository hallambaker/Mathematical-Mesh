﻿using Goedel.Cryptography;
using Goedel.Utilities;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;

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
        /// <param name="secretSeed">The secret seed value.</param>
        /// <param name="keyCollection">The keyCollection to manage and persist the generated keys.</param>
        /// <param name="persist">If <see langword="true"/> persist the secret seed value to
        /// <paramref name="keyCollection"/>.</param>
        public ProfileGroup(
                    PrivateKeyUDF secretSeed,
                    IKeyCollection keyCollection = null,
                    bool? persist = false) {

            var meshKeyType = MeshKeyType.GroupProfile;
            var keySign = secretSeed.BasePrivate(meshKeyType | MeshKeyType.Sign);
            var keyEncrypt = secretSeed.BasePrivate(meshKeyType | MeshKeyType.Encrypt);

            OfflineSignature = new KeyData(keySign.KeyPairPublic());
            AccountEncryption = new KeyData(keyEncrypt.KeyPairPublic());

            if (persist == true) {
                keyCollection.Persist(OfflineSignature.UDF, secretSeed, false);
                }

            Sign(keySign);
            }




        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="keySign">The signature key.</param>
        /// <param name="keyEncrypt">The encryption key.</param>
        public ProfileGroup(
            KeyPair keySign, KeyPair keyEncrypt) {
            OfflineSignature = new KeyData(keySign.KeyPairPublic());
            AccountEncryption = new KeyData(keyEncrypt.KeyPairPublic());
            }




        /// <summary>
        /// Generate a new <see cref="ProfileGroup"/>
        /// </summary>
        /// <param name="meshMachine">The mesh machine.</param>
        /// <param name="algorithmSign">The signature algorithm.</param>
        /// <param name="algorithmEncrypt">The encryption algorithm.</param>
        /// <param name="persist">If true, the secretSeed is persisted to the local store.</param>
        /// <param name="secret">Specifies the value of the random seed. If null, a new seed 
        /// is generated.</param>
        /// <returns>The group profile and secret seed.</returns>
        public static (ProfileGroup, PrivateKeyUDF) Generate(
                    IMeshMachine meshMachine,
                    CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default,
                    CryptoAlgorithmId algorithmEncrypt = CryptoAlgorithmId.Default,
                    byte[] secret = null,
                    bool? persist = false) {

            var secretSeed = new PrivateKeyUDF(UdfAlgorithmIdentifier.MeshProfileGroup,
                    algorithmEncrypt, algorithmSign, secret:secret);
            var profileGroup =  new ProfileGroup(secretSeed, meshMachine.KeyCollection, persist);

            return (profileGroup, secretSeed);
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


            var key = keyCollection.LocatePrivateKeyPair(AccountEncryption.UDF) as KeyPairAdvanced;
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

        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public DeviceRecryptionKey() {
            }

        //public DeviceRecryptionKey(Contact user, KeyPair serviceKey, KeyPair deviceKey) {
        //    }


        //public GroupInvitation MakeInvitation(Contact user) => throw new NYI();

        }

    }
