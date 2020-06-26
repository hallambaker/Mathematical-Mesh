using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace Goedel.Mesh {

    public partial class KeyComposite {

        ///<summary>Convenience accessor for the composite UDF.</summary>
        public string UDF => KeyPair.KeyIdentifier;

        ///<summary>The composite key pair.</summary>
        public KeyPairAdvanced KeyPair => keyPair ?? (Public.KeyPair as KeyPairAdvanced).CacheValue(out keyPair);
        KeyPairAdvanced keyPair = null;

        /// <summary>
        /// Default constructor for deserialization.
        /// </summary>
        public KeyComposite() {

            }

        /// <summary>
        /// Constructor from base key <paramref name="baseKey"/> with decryption service 
        /// <paramref name="service"/>.
        /// </summary>
        /// <param name="baseKey">The base key.</param>
        /// <param name="service">The decryption service.</param>
        public KeyComposite(KeyData baseKey, string service) :
                    this(baseKey.KeyPair as KeyPairAdvanced, service) {
            }

        /// <summary>
        /// Constructor from base key <paramref name="baseKey"/> with decryption service 
        /// <paramref name="service"/>.
        /// </summary>
        /// <param name="baseKey">The base key.</param>
        /// <param name="service">The decryption service.</param>
        public KeyComposite(KeyPairAdvanced baseKey, string service = null) {
            Public = Cryptography.Jose.Key.GetPublic(baseKey);
            if (service == null) {
                Part = Cryptography.Jose.Key.GetPrivate(baseKey);

                }
            else {
                throw new NYI(); // ToDo: implement service for split keys
                }
            }


        }



    public static partial class Extensions {

        /// <summary>
        /// Return the mesh key group from <paramref name="udfAlgorithmIdentifier"/>.
        /// </summary>
        /// <param name="udfAlgorithmIdentifier">The UDF key type identifier.</param>
        /// <returns>The Mesh key group identifier.</returns>
        public static MeshKeyType GetMeshKeyType(this UdfAlgorithmIdentifier udfAlgorithmIdentifier) =>
            udfAlgorithmIdentifier switch {
                UdfAlgorithmIdentifier.MeshProfileMaster => MeshKeyType.MasterProfile,
                UdfAlgorithmIdentifier.MeshProfileDevice => MeshKeyType.DeviceProfile,
                UdfAlgorithmIdentifier.MeshProfileAccount => MeshKeyType.AccountProfile,
                UdfAlgorithmIdentifier.MeshProfileGroup => MeshKeyType.GroupProfile,
                UdfAlgorithmIdentifier.MeshProfileService => MeshKeyType.ServiceProfile,
                UdfAlgorithmIdentifier.MeshActivationDevice => MeshKeyType.DeviceProfile,
                UdfAlgorithmIdentifier.MeshActivationAccount => MeshKeyType.AccountProfile,
                UdfAlgorithmIdentifier.MeshActivationGroup => MeshKeyType.GroupProfile,
                UdfAlgorithmIdentifier.MeshActivationService => MeshKeyType.ServiceProfile,
                _ => throw new NYI()
                };

        /// <summary>
        /// Return the <see cref="CryptoAlgorithmId"/> identifier for the mesh key type
        /// <paramref name="meshKeyType"/> derrived from the seed <paramref name="secretSeed"/>.
        /// </summary>
        /// <param name="meshKeyType">The Mesh Key identifier.</param>
        /// <param name="secretSeed">The secret seed.</param>
        /// <returns>The  <see cref="CryptoAlgorithmId"/> identifier.</returns>
        public static CryptoAlgorithmId GetCryptoAlgorithmID(this MeshKeyType meshKeyType,
            PrivateKeyUDF secretSeed) => (meshKeyType & MeshKeyType.MaskKeyUse) switch
                {
                    MeshKeyType.Sign => secretSeed.AlgorithmSignID,
                    MeshKeyType.OnlineSign => secretSeed.AlgorithmSignID,
                    MeshKeyType.Authenticate => secretSeed.AlgorithmAuthenticateID,
                    _ => secretSeed.AlgorithmEncryptID
                    };

        /// <summary>
        /// Return the <see cref="KeyUses"/> and salt suffix values for the Mesh key type 
        /// <paramref name="meshKeyType"/>.
        /// </summary>
        /// <param name="meshKeyType">The Mesh Key identifier.</param>
        /// <param name="keyUses">The PKIX key uses.</param>
        /// <param name="suffix">The salt suffix to apply.</param>
        /// <param name="activate">If true return the activation value (currently unused.)</param>
        public static void ParseMeshKeyType(this MeshKeyType meshKeyType,
                out KeyUses keyUses,
                out string suffix, bool activate = false) {

            var meshSeedType = meshKeyType & MeshKeyType.MaskSeedType;
            var meshKeyUse = meshKeyType & MeshKeyType.MaskKeyUse;

            suffix = meshKeyUse.ToString();

            //udfAlgorithmIdentifier = meshSeedType switch
            //    {
            //        MeshKeyType.MasterProfile => UdfAlgorithmIdentifier.MeshProfileMaster,
            //        MeshKeyType.DeviceProfile => activate ?
            //            UdfAlgorithmIdentifier.MeshActivationDevice : UdfAlgorithmIdentifier.MeshProfileDevice,
            //        MeshKeyType.AccountProfile => activate ?
            //            UdfAlgorithmIdentifier.MeshActivationAccount : UdfAlgorithmIdentifier.MeshProfileAccount,
            //        _ => throw new NYI()
            //        };

            keyUses = meshKeyUse switch
                {
                    MeshKeyType.OnlineSign => KeyUses.Sign,
                    MeshKeyType.Sign => KeyUses.Sign,

                    _ => KeyUses.Encrypt
                    };


            }

        /// <summary>
        /// Derive a base private key of type <paramref name="meshKeyType"/> from the 
        /// secret seed value <paramref name="secretSeed"/> and register the private component
        /// in <paramref name="keyCollection"/>.
        /// </summary>
        /// <param name="secretSeed">The secret seed value.</param>
        /// <param name="meshKeyType">The mesh key type.</param>
        /// <param name="keyCollection">The key collection to register the private key to
        /// (the key is always generated as ephemeral.)</param>
        /// <returns>The derrived key.</returns>
        public static KeyPair BasePrivate(this PrivateKeyUDF secretSeed,
                    MeshKeyType meshKeyType, KeyCollection keyCollection = null) {

            meshKeyType.ParseMeshKeyType(out var keyUses, out var saltSuffix);
            var cryptoAlgorithmID = GetCryptoAlgorithmID(meshKeyType, secretSeed);

            return UDF.DeriveKey(secretSeed.PrivateValue, keyCollection,
                    KeySecurity.Ephemeral, keyUses: keyUses, cryptoAlgorithmID, saltSuffix);
            }

        /// <summary>
        /// Derive an activation private key of type <paramref name="meshKeyType"/> from the 
        /// secret seed value <paramref name="baseSeed"/>, activation value 
        /// <paramref name="activationSeed"/> and register the private component
        /// in <paramref name="keyCollection"/>.
        /// </summary>
        /// <param name="activationSeed">The activation seed value.</param>
        /// <param name="baseSeed">The secret seed value.</param>
        /// <param name="meshKeyType">The mesh key type.</param>
        /// <param name="keyCollection">The key collection to register the private key to
        /// (the key is always generated as ephemeral.)</param>
        /// <returns>The derrived key.</returns>
        public static KeyPair ActivatePrivate(this PrivateKeyUDF activationSeed,
            PrivateKeyUDF baseSeed, MeshKeyType meshKeyType, IKeyCollection keyCollection = null) =>
                ActivatePrivate(baseSeed, activationSeed.PrivateValue, meshKeyType, keyCollection);



        /// <summary>
        /// Derive an activation private key of type <paramref name="meshKeyType"/> from the 
        /// secret seed value <paramref name="baseSeed"/>, activation value 
        /// <paramref name="activationSeed"/> and register the private component
        /// in <paramref name="keyCollection"/>.
        /// </summary>
        /// <param name="activationSeed">The activation seed value.</param>
        /// <param name="baseSeed">The secret seed value.</param>
        /// <param name="meshKeyType">The mesh key type.</param>
        /// <param name="keyCollection">The key collection to register the private key to
        /// (the key is always generated as ephemeral.)</param>
        /// <returns>The derrived key.</returns>
        public static KeyPair ActivatePrivate(this PrivateKeyUDF baseSeed,
            string activationSeed, MeshKeyType meshKeyType, IKeyCollection keyCollection = null) {

            meshKeyType.ParseMeshKeyType(out var keyUses, out var saltSuffix);
            var cryptoAlgorithmID = GetCryptoAlgorithmID(meshKeyType, baseSeed);

            var baseKey = UDF.DeriveKey(baseSeed.PrivateValue, keyCollection,
                    KeySecurity.Ephemeral, keyUses: keyUses, cryptoAlgorithmID, saltSuffix) as KeyPairAdvanced;

            //Console.WriteLine($"Private: Base-{baseKey.UDF} Seed-{activationSeed} Type-{meshKeyType}");

            var activationKey = UDF.DeriveKey(activationSeed, keyCollection,
                    KeySecurity.Ephemeral, keyUses: keyUses, cryptoAlgorithmID, saltSuffix) as KeyPairAdvanced;

            

            var combinedKey = activationKey.Combine(baseKey, keyUses: keyUses);

            //Console.WriteLine($"   result {combinedKey}");

            return combinedKey;
            }


        /// <summary>
        /// Derive an activation public key of type <paramref name="meshKeyType"/> 
        /// activation value <paramref name="activationSeed"/> and base key 
        /// <paramref name="baseKey"/>.
        /// </summary>
        /// <param name="baseKey">The base public key</param>
        /// <param name="activationSeed">The activation seed value.</param>
        /// <param name="meshKeyType">The mesh key type.</param>
        /// <returns>The derrived key.</returns>
        public static KeyPairAdvanced ActivatePublic(this KeyData baseKey,
                string activationSeed, MeshKeyType meshKeyType) =>
            ActivatePublic(baseKey.KeyPair as KeyPairAdvanced, activationSeed, meshKeyType);



        /// <summary>
        /// Derive an activation public key of type <paramref name="meshKeyType"/> 
        /// activation value <paramref name="activationSeed"/> and base key 
        /// <paramref name="baseKey"/>.
        /// </summary>
        /// <param name="baseKey">The base public key</param>
        /// <param name="activationSeed">The activation seed value.</param>
        /// <param name="meshKeyType">The mesh key type.</param>
        /// <param name="keyCollection">The key collection to register the private key to
        /// (the key is always generated as ephemeral.)</param>
        /// <returns>The derrived key.</returns>
        public static KeyPairAdvanced ActivatePublic(this KeyPair baseKey,
            string activationSeed, MeshKeyType meshKeyType, KeyCollection keyCollection = null) {
            //Console.WriteLine($"Public: Base-{baseKey.UDF} Seed-{activationSeed} Type-{meshKeyType}");

            meshKeyType.ParseMeshKeyType(out var keyUses, out var saltSuffix);
            var activationKey = UDF.DeriveKey(activationSeed, keyCollection,
                    KeySecurity.Ephemeral, keyUses: keyUses, baseKey.CryptoAlgorithmId, saltSuffix) as KeyPairAdvanced;

            var combinedKey = activationKey.CombinePublic(baseKey as KeyPairAdvanced, keyUses: keyUses);
            //Console.WriteLine($"   result {combinedKey}");

            return combinedKey;

            }

        }

    }
