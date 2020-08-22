using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Mesh;
using System;
using System.Collections.Generic;
using System.IO;
using Goedel.Protocol;
using System.Text;

namespace Goedel.Mesh {
    public partial class ActivationAccount {

        /////<summary>Used to build cryptographic capabilities</summary> 
        //public List<CryptographicCapability> CryptographicCapabilities;

        IKeyCollection KeyCollection;

        // Properties providing access to account-wide keys.

        ///<summary>The account offline signature key</summary>
        public KeyPair PrivateAccountOfflineSignature { get; private set; }

        ///<summary>The account online signature key</summary>
        public KeyPair PrivateAccountOnlineSignature { get; private set; }

        ///<summary>The account encryption key</summary>
        public KeyPair PrivateAccountEncryption { get; private set; }

        ///<summary>The account authentication key</summary>
        public KeyPair PrivateAccountAuthentication { get; private set; }

        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public ActivationAccount() {
            }

        /// <summary>
        /// Construct a new <see cref="ActivationDevice"/> instance for the profile
        /// <paramref name="profileDevice"/>. The property <see cref="Activation.ActivationKey"/> is
        /// calculated from the values specified for the activation type.
        /// If the value <paramref name="masterSecret"/> is
        /// specified, it is used as the seed value. Otherwise, a seed value of
        /// length <paramref name="bits"/> is generated.
        /// The public key value is calculated for the public key pairs and the corresponding
        /// <see cref="ConnectionUser"/> generated for the public values.
        /// </summary>
        /// <param name="profileDevice">The base profile that the activation activates.</param>
        /// <param name="masterSecret">If not null, specifies the seed value. Otherwise,
        /// a seed value of <paramref name="bits"/> length is generated.</param>
        /// <param name="bits">The size of the seed to be generated if <paramref name="masterSecret"/>
        /// is null.</param>
        public ActivationAccount(
                    ProfileDevice profileDevice,
                    byte[] masterSecret = null,
                    int bits = 256) : base(
                        profileDevice, UdfAlgorithmIdentifier.MeshActivationUser, masterSecret, bits) {
            ProfileDevice = profileDevice;
            }





        public ActivationAccount(
                    IKeyCollection keyCollection,
                    ProfileDevice profileDevice, 
                    KeyPair keyPairOnlineSignature,
                    List<string> roles,
                    PrivateKeyUDF secretSeed=null) : base(
                        profileDevice, UdfAlgorithmIdentifier.MeshActivationUser) {

            if (secretSeed != null) {
                // Generate the private keys
                PrivateAccountOfflineSignature = secretSeed.BasePrivate(
                    MeshKeyType.UserSign, keyCollection, KeySecurity.Exportable);
                PrivateAccountEncryption = secretSeed.BasePrivate(
                    MeshKeyType.UserEncrypt, keyCollection, KeySecurity.Exportable);
                PrivateAccountAuthentication = secretSeed.BasePrivate(
                    MeshKeyType.UserAuthenticate, keyCollection, KeySecurity.Exportable);
                PrivateAccountOnlineSignature = keyPairOnlineSignature;
                }
            else {
                // Attempt to pull private keys from storage
                Activate();
                }

            if (keyPairOnlineSignature != null) {
                AccountOnlineSignature = AddCapability(keyPairOnlineSignature, profileDevice);
                }


            var access = new List<Right>();

            if (roles == null) {
                }
            else {
                foreach (var role in roles) {
                    var rights = Rights.GetRights(role, out var subresource);
                    access.Concat(rights);
                    }
                }

            foreach (var right in access) {
                Grant(profileDevice, right, keyPairOnlineSignature);
                }

            }





        /// <summary>
        /// Create a key pair bound to the private key <paramref name="profileDevice.KeyEncryption"/>
        /// The public parameters of the returned key represent the combined parameters, the 
        /// private parameters represent the offset from the device key.
        /// </summary>
        /// <param name="profileDevice">Profile providing the base key.</param>
        /// <param name="keyCollection">Key collection in which the resulting key is to be stored.</param>
        /// <returns>The bound key pair.</returns>
        public static KeyPair DeviceBindEncryption(
                    ProfileDevice profileDevice,
                    IKeyCollection keyCollection) {
            return KeyPair.FactorySignature(profileDevice.KeyEncryption.CryptoKey.CryptoAlgorithmId,
                            KeySecurity.ExportableStored, keyCollection);
            }

        /// <summary>
        /// Create a key pair bound to the private key <paramref name="profileDevice.OfflineSignature"/>
        /// The public parameters of the returned key represent the combined parameters, the 
        /// private parameters represent the offset from the device key.
        /// </summary>
        /// <param name="profileDevice">Profile providing the base key.</param>
        /// <param name="keyCollection">Key collection in which the resulting key is to be stored.</param>
        /// <returns>The bound key pair.</returns>
        public static KeyPair DeviceBindSignature(
                    ProfileDevice profileDevice,
                    IKeyCollection keyCollection) {
            return KeyPair.FactorySignature(profileDevice.OfflineSignature.CryptoKey.CryptoAlgorithmId,
                            KeySecurity.ExportableStored, keyCollection);
            }

        /// <summary>
        /// Create a key pair bound to the private key <paramref name="profileDevice.KeyAuthentication"/>
        /// The public parameters of the returned key represent the combined parameters, the 
        /// private parameters represent the offset from the device key.
        /// </summary>
        /// <param name="profileDevice">Profile providing the base key.</param>
        /// <param name="keyCollection">Key collection in which the resulting key is to be stored.</param>
        /// <returns>The bound key pair.</returns>
        public static KeyPair DeviceBindAuthentication(
                    ProfileDevice profileDevice,
                    IKeyCollection keyCollection) {
            return KeyPair.FactorySignature(profileDevice.KeyAuthentication.CryptoKey.CryptoAlgorithmId,
                            KeySecurity.ExportableStored, keyCollection);
            }




        /// <summary>
        /// Generate a capability for the key <paramref name="keyPair"/>.
        /// add the service portion to the capabilities catalog.
        /// </summary>
        /// <param name="keyPair">Keypair from which the capability is to be derrived.</param>
        /// 
        public KeyData AddCapability(CryptoKey keyPair, ProfileDevice profileDevice) {
            "**** MUST add keys to devices as shared capabilities".TaskFunctionality();

            //var catalogCapability = GetCatalogCapability();

            return new KeyData(keyPair, true);
            }


        void Grant(ProfileDevice profileDevice, Right right,
            KeyPair keyPairOnlineSignature) {

            switch (right.Resource) {
                case Resource.ProfileRoot: {
                    GrantProfileRoot(profileDevice, right);
                    break;
                    }
                case Resource.ProfileAdmin: {
                    GrantProfileAdmin(profileDevice, right, keyPairOnlineSignature);
                    break;
                    }
                case Resource.Store: {
                    GrantStore(profileDevice, right);
                    break;
                    }
                case Resource.Account: {
                    GrantAccount(profileDevice, right);
                    break;
                    }
                }

            }

        /// <summary>
        /// Grant super administrator access.
        /// </summary>
        /// <param name="activationAccount"></param>
        /// <param name="profileDevice"></param>
        /// <param name="right"></param>
        void GrantProfileRoot( ProfileDevice profileDevice, Right right) {
            AccountOfflineSignature = AddCapability(
                        PrivateAccountOfflineSignature, profileDevice);
            }


        void GrantProfileAdmin(
                            ProfileDevice profileDevice,
                            Right right,
                            KeyPair keyPairOnlineSignature) {

            keyPairOnlineSignature ??= DeviceBindSignature(profileDevice, KeyCollection);
            AccountOnlineSignature = AddCapability(
                        keyPairOnlineSignature, profileDevice);
            }

        void GrantStore(ProfileDevice profileDevice, Right right) {
            }


        void GrantAccount(ProfileDevice profileDevice, Right right) {
            }


        /// <summary>
        /// Activate the keys bound to this activation record using keys derived from 
        /// <paramref name="deviceKeySeed"/>.
        /// </summary>
        /// <param name="keyCollection">Key collection to register keys in.</param>
        /// <param name="deviceKeySeed">Generator for the private key contributions.</param>
        public void Activate() {

            PrivateAccountOfflineSignature = AccountOnlineSignature?.GetKeyPair(KeySecurity.Exportable);
            PrivateAccountOnlineSignature = AccountOfflineSignature?.GetKeyPair(KeySecurity.Exportable);
            PrivateAccountEncryption = AccountEncryption?.GetKeyPair(KeySecurity.Exportable);
            PrivateAccountAuthentication = AccountAuthentication?.GetKeyPair(KeySecurity.Exportable);

            }



        /// <summary>
        /// Decode <paramref name="envelope"/> and return the inner <see cref="ActivationDevice"/>
        /// </summary>
        /// <param name="envelope">The envelope to decode.</param>
        /// <param name="keyCollection">Key collection to use to obtain decryption keys.</param>
        /// <returns>The decoded profile.</returns>
        public static new ActivationAccount Decode(DareEnvelope envelope,
                    IKeyLocate keyCollection = null) =>
                        MeshItem.Decode(envelope, keyCollection) as ActivationAccount;


        /// <summary>
        /// Append a description of the instance to the StringBuilder <paramref name="builder"/> with
        /// a leading indent of <paramref name="indent"/> units. The key collection 
        /// <paramref name="keyCollection"/> is used to decrypt any encrypted data.
        /// </summary>
        /// <param name="builder">The string builder to write to.</param>
        /// <param name="indent">The number of units to indent the presentation.</param>
        /// <param name="keyCollection">The Key collection.</param>
        public override void ToBuilder(StringBuilder builder, int indent = 0, IKeyCollection keyCollection = null) {

            builder.AppendIndent(indent, $"Activation Account");
            indent++;
            DareEnvelope.Report(builder, indent);
            indent++;


            }
        }

    }
