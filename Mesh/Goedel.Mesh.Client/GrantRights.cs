using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Mesh;
using System;
using System.Collections.Generic;
using System.IO;
using Goedel.Protocol;
using System.Diagnostics;
using System.Runtime.Serialization;
using Goedel.IO;

namespace Goedel.Mesh.Client {

    /// <summary>
    /// Context for interacting with a Mesh Account
    /// </summary>
    public partial class ContextUser : ContextAccount {




        private ActivationAccount MakeActivationAccount(
            ProfileDevice profileDevice,
            KeyPair keyPairOnlineSignature,
                List<string> roles = null) {


            // Grant the ability to decrypt data encrypted under the account encryption key
            // Grant the abiility to authenticate under the account profile.
            var activationAccount = new ActivationAccount(KeyCollection, profileDevice,
                        keyPairOnlineSignature, roles) {
                //CryptographicCapabilities = new List<CryptographicCapability>()


                //AccountEncryption = AddCapability(PrivateAccountEncryption, profileDevice),
                //AccountAuthentication = AddCapability(PrivateAccountAuthentication, profileDevice)
                };






            //// Grant administrator privilege if keyPairOnlineSignature is not null.
            //if (keyPairOnlineSignature != null) {
            //    activationAccount.AccountOnlineSignature = AddCapability(keyPairOnlineSignature, profileDevice);
            //    }


            //var access = new List<Right>();

            //if (roles == null) {
            //    }
            //else {
            //    foreach (var role in roles) {
            //        var rights = Rights.GetRights(role, out var subresource);
            //        access.Concat(rights);
            //        }
            //    }

            //foreach (var right in access) {
            //    Grant(activationAccount, profileDevice, right, keyPairOnlineSignature);
            //    }


            return activationAccount;
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




        /**** Code deriving keys from a seed
            SecretSeed = secretSeed ?? new PrivateKeyUDF(
                UdfAlgorithmIdentifier.MeshProfileDevice, null, null,
                algorithmEncrypt, algorithmSign, algorithmAuthenticate,
                bits: bits);

            var meshKeyType = MeshKeyType.DeviceProfile;
            var keySign = SecretSeed.BasePrivate(meshKeyType | MeshKeyType.Sign);

        /***** Code creating a threshold merge (public key combination)

            var keyEncryption = profileDevice.KeyEncryption.ActivatePublic(ActivationKey,
                    MeshKeyType | MeshKeyType.Encrypt);
            var keyAuthentication = profileDevice.KeyAuthentication.ActivatePublic(ActivationKey,
                    MeshKeyType | MeshKeyType.Authenticate);



        /***** Code creating a threshold split

            // Pull the contact information from the user's contact catalog
            var networkProtocolEntry = ContextAccount.GetNetworkEntry(memberAddress);
            var userEncryptionKey = networkProtocolEntry.MeshKeyEncryption;
            var serviceEncryptionKey = ContextAccount.ProfileUser.ProfileService.KeyEncryption.CryptoKey;


            // Create the capability 
            var capabilityService = new CapabilityDecryptServiced() {
                AuthenticationId = ContextAccount.ProfileUser.UDF,
                KeyDataEncryptionKey = serviceEncryptionKey
                };

            var capabilityMember = new CapabilityDecryptPartial() {
                Id = ProfileGroup.AccountEncryption.UDF,
                SubjectId = ProfileGroup.AccountEncryption.UDF,
                ServiceAddress = AccountAddress,
                KeyDataEncryptionKey = userEncryptionKey
                };

            var keyGenerate = transactInvitation.GetCatalogCapability().TryFindKeyGenerate(
                            ProfileGroup.AccountEncryption.UDF);
            keyGenerate.CreateShares(capabilityService, capabilityMember);  
         */


        /// <summary>
        /// Generate a capability for the key <paramref name="keyPair"/>.
        /// add the service portion to the capabilities catalog.
        /// </summary>
        /// <param name="keyPair">Keypair from which the capability is to be derrived.</param>
        /// <param name="profileDevice">The profile of the device to which the capability
        /// is being granted.</param>
        public KeyData AddCapability(CryptoKey keyPair, ProfileDevice profileDevice) {
            "**** MUST add keys to devices as shared capabilities".TaskFunctionality();

            //var catalogCapability = GetCatalogCapability();

            return new KeyData(keyPair, true);
            }


        void Grant(ActivationAccount activationAccount, ProfileDevice profileDevice, Right right,
            KeyPair keyPairOnlineSignature) {

            switch (right.Resource) {
                case Resource.ProfileRoot: {
                    GrantProfileRoot(activationAccount, profileDevice, right);
                    break;
                    }
                case Resource.ProfileAdmin: {
                    GrantProfileAdmin(activationAccount, profileDevice, right, keyPairOnlineSignature);
                    break;
                    }
                case Resource.Store: {
                    GrantStore(activationAccount, profileDevice, right);
                    break;
                    }
                case Resource.Account: {
                    GrantAccount(activationAccount, profileDevice, right);
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
        void GrantProfileRoot(ActivationAccount activationAccount, ProfileDevice profileDevice, Right right) {
            activationAccount.AccountOfflineSignature = AddCapability(
                        PrivateAccountOfflineSignature, profileDevice);
            }


        void GrantProfileAdmin(ActivationAccount 
                            activationAccount, 
                            ProfileDevice profileDevice, 
                            Right right,
                            KeyPair keyPairOnlineSignature) {

            keyPairOnlineSignature ??= DeviceBindSignature(profileDevice, KeyCollection);
            activationAccount.AccountOnlineSignature = AddCapability(
                        keyPairOnlineSignature, profileDevice);
            }

        void GrantStore(ActivationAccount activationAccount, ProfileDevice profileDevice, Right right) {
            }


        void GrantAccount(ActivationAccount activationAccount, ProfileDevice profileDevice, Right right) {
            }

        }
    }