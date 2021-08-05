#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion



using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Utilities;

namespace Goedel.Mesh {


    public static partial class Extensions {

        /// <summary>
        /// Return the mesh key group from <paramref name="udfAlgorithmIdentifier"/>.
        /// </summary>
        /// <param name="udfAlgorithmIdentifier">The UDF key type identifier.</param>
        /// <returns>The Mesh key group identifier.</returns>
        public static (MeshActor, MeshKeyType) GetMeshKeyType(this UdfAlgorithmIdentifier udfAlgorithmIdentifier) =>
            udfAlgorithmIdentifier switch {
                UdfAlgorithmIdentifier.MeshProfileDevice => (MeshActor.Device, MeshKeyType.Base),
                UdfAlgorithmIdentifier.MeshActivationDevice => (MeshActor.Device, MeshKeyType.Activation),
                UdfAlgorithmIdentifier.MeshProfileAccount => (MeshActor.Account, MeshKeyType.Complete),
                UdfAlgorithmIdentifier.MeshActivationAccount => (MeshActor.Account, MeshKeyType.Activation),
                UdfAlgorithmIdentifier.MeshProfileService => (MeshActor.Service, MeshKeyType.Base),
                UdfAlgorithmIdentifier.MeshActivationService => (MeshActor.Service, MeshKeyType.Activation),

                _ => throw new NYI()
                };

        /// <summary>
        /// Return the <see cref="CryptoAlgorithmId"/> identifier for the mesh key type
        /// <paramref name="operation"/> derrived from the seed <paramref name="secretSeed"/>.
        /// </summary>
        /// <param name="operation">The Mesh Key identifier.</param>
        /// <param name="secretSeed">The secret seed.</param>
        /// <returns>The  <see cref="CryptoAlgorithmId"/> identifier.</returns>
        public static CryptoAlgorithmId GetCryptoAlgorithmID(this MeshKeyOperation operation,
                            IActivate secretSeed) => operation switch {
                                MeshKeyOperation.Authenticate => secretSeed.AlgorithmAuthenticateID,
                                MeshKeyOperation.Encrypt => secretSeed.AlgorithmEncryptID,
                                MeshKeyOperation.Escrow => secretSeed.AlgorithmEncryptID,
                                MeshKeyOperation.Sign => secretSeed.AlgorithmSignID,
                                MeshKeyOperation.Profile => secretSeed.AlgorithmSignID,
                                MeshKeyOperation.AdminEncrypt => secretSeed.AlgorithmEncryptID,
                                MeshKeyOperation.AdminSign => secretSeed.AlgorithmSignID,
                                _ => secretSeed.AlgorithmSignID
                                };


        /// <summary>
        /// Return the <see cref="KeyUses"/> for the Mesh key operation <paramref name="operation"/>.
        /// </summary>
        /// <param name="operation">The Mesh Key operation.</param>
        public static KeyUses GetMeshKeyType(this MeshKeyOperation operation) =>

            operation switch {
                MeshKeyOperation.Authenticate => KeyUses.KeyAgreement,
                MeshKeyOperation.Encrypt => KeyUses.Encrypt,
                MeshKeyOperation.Escrow => KeyUses.Encrypt,
                MeshKeyOperation.Sign => KeyUses.Sign,
                MeshKeyOperation.Profile => KeyUses.Sign,
                MeshKeyOperation.AdminEncrypt => KeyUses.Encrypt,
                MeshKeyOperation.AdminSign => KeyUses.Sign,
                _ => KeyUses.Any
                };


        /// <summary>
        /// Derive a base private key of type <paramref name="type"/> for the
        /// actor <paramref name="actor"/> for the key use <paramref name="operation"/> from the 
        /// secret seed value <paramref name="secretSeed"/> and register the private component
        /// in <paramref name="keyCollection"/> under the key security model
        /// <paramref name="keySecurity"/>. 
        /// </summary>
        /// <param name="secretSeed">The secret seed value.</param>
        /// <param name="actor">The actor that will use the key</param>
        /// <param name="operation">The operation for which the key will be used.</param>
        /// <param name="type">The contribuition type</param>
        /// <param name="keyCollection">The key collection to register the private key to
        /// (the key is always generated as ephemeral.)</param>
        /// <param name="keySecurity">The key security model of the derrived key.</param>
        /// <returns>KeyData for the public parameters of the derrived key.</returns>
        public static (KeyPair, KeyData) GenerateContributionKey(
                    this PrivateKeyUDF secretSeed,
                    MeshKeyType type,
                    MeshActor actor,
                    MeshKeyOperation operation,
                    IKeyCollection keyCollection = null,
                    KeySecurity keySecurity = KeySecurity.Ephemeral) {
            var keyPair = GenerateContributionKeyPair(secretSeed, type, actor, operation,
                keyCollection, keySecurity);
            var keyData = new KeyData(keyPair, false);

            return (keyPair, keyData);
            }



        /// <summary>
        /// Derive a base private key of type <paramref name="type"/> for the
        /// actor <paramref name="actor"/> for the key use <paramref name="operation"/> from the 
        /// secret seed value <paramref name="secretSeed"/> and register the private component
        /// in <paramref name="keyCollection"/> under the key security model
        /// <paramref name="keySecurity"/>. 
        /// </summary>
        /// <param name="secretSeed">The secret seed value.</param>
        /// <param name="actor">The actor that will use the key</param>
        /// <param name="operation">The operation for which the key will be used.</param>
        /// <param name="type">The contribuition type</param>
        /// <param name="keyCollection">The key collection to register the private key to
        /// (the key is always generated as ephemeral.)</param>
        /// <param name="keySecurity">The key security model of the derrived key.</param>
        /// <returns>KeyData for the public parameters of the derrived key.</returns>
        public static KeyData GenerateContributionKeyData(
                    this PrivateKeyUDF secretSeed,
                    MeshKeyType type,
                    MeshActor actor,
                    MeshKeyOperation operation,
                    IKeyCollection keyCollection = null,
                    KeySecurity keySecurity = KeySecurity.Ephemeral) {
            return new KeyData(GenerateContributionKeyPair(secretSeed, type, actor, operation,
                keyCollection, keySecurity));
            }

        /// <summary>
        /// Derive a base private key of type <paramref name="type"/> for the
        /// actor <paramref name="actor"/> for the key use <paramref name="operation"/> from the 
        /// secret seed value <paramref name="secretSeed"/> and register the private component
        /// in <paramref name="keyCollection"/> under the key security model
        /// <paramref name="keySecurity"/>. 
        /// </summary>
        /// <param name="secretSeed">The secret seed value.</param>
        /// <param name="actor">The actor that will use the key</param>
        /// <param name="operation">The operation for which the key will be used.</param>
        /// <param name="type">The contribuition type</param>
        /// <param name="keyCollection">The key collection to register the private key to
        /// (the key is always generated as ephemeral.)</param>
        /// <param name="keySecurity">The key security model of the derrived key.</param>
        /// <returns>The derrived key.</returns>
        public static KeyPairAdvanced GenerateContributionKeyPair(

                this PrivateKeyUDF secretSeed,
                MeshKeyType type,
                MeshActor actor,
                MeshKeyOperation operation,
                IKeyCollection keyCollection = null,
                KeySecurity keySecurity = KeySecurity.Ephemeral) {
            //Screen.WriteLine($"{type}=={actor}-{operation}::{secretSeed}");


            var keyName = type.ToLabel() + actor.ToLabel() + operation.ToLabel();
            var keyUses = GetMeshKeyType(operation);
            var cryptoAlgorithmID = GetCryptoAlgorithmID(operation, secretSeed);

            return UDF.DeriveKey(secretSeed.PrivateValue, keyCollection,
                    keySecurity, keyUses: keyUses, cryptoAlgorithmID, keyName) as KeyPairAdvanced;
            }

        /// <summary>
        /// Derrive the public key from the activation seed <paramref name="activationSeed"/>
        /// and base key <paramref name="baseKey"/> for a key to be used by an actor
        /// <paramref name="actor"/> for the cryptoraphic operation <paramref name="operation"/>.
        /// </summary>
        /// <param name="activationSeed">The activation seed.</param>
        /// <param name="baseKey">The base key specifying the public parameters.</param>
        /// <param name="actor">The actor for whom the key is generated.</param>
        /// <param name="operation">The operation for which the key is to be used.</param>
        /// <returns>The derrived public key</returns>
        public static KeyPairAdvanced ActivatePublic(
               this PrivateKeyUDF activationSeed,
               KeyPair baseKey,
               MeshActor actor,
               MeshKeyOperation operation) {
            var activationKey = activationSeed.GenerateContributionKeyPair(
                        MeshKeyType.Activation, actor, operation) as KeyPairAdvanced;
            var combinedKey = activationKey.CombinePublic(baseKey as KeyPairAdvanced, keyUses: baseKey.KeyUses);
            return combinedKey;
            }

        /// <summary>
        /// Derrive the private key from the activation seed <paramref name="activationSeed"/>
        /// and base seed <paramref name="baseSeed"/> for a key to be used by an actor
        /// <paramref name="actor"/> for the cryptoraphic operation <paramref name="operation"/>.
        /// </summary>
        /// <param name="activationSeed">The activation seed.</param>
        /// <param name="baseSeed">The base seed used to derive the private parameters..</param>
        /// <param name="actor">The actor for whom the key is generated.</param>
        /// <param name="operation">The operation for which the key is to be used.</param>
        /// <returns>The derrived private key</returns>
        public static KeyPairAdvanced ActivatePrivate(
                this PrivateKeyUDF activationSeed,
                PrivateKeyUDF baseSeed,
                MeshActor actor,
                MeshKeyOperation operation) {

            //Screen.WriteLine($"{MeshKeyType.Base}==={actor}-{operation}::{activationSeed.PrivateValue}");

            var baseKey = baseSeed.GenerateContributionKeyPair(
                MeshKeyType.Base, actor, operation) as KeyPairAdvanced;

            return activationSeed.ActivatePrivate(baseKey, actor, operation);
            }

        /// <summary>
        /// Derrive the private key from the activation seed <paramref name="activationSeed"/>
        /// and base key <paramref name="baseKey"/> for a key to be used by an actor
        /// <paramref name="actor"/> for the cryptoraphic operation <paramref name="operation"/>.
        /// </summary>
        /// <param name="activationSeed">The activation seed.</param>
        /// <param name="baseKey">The base key specifying the private parameters.</param>
        /// <param name="actor">The actor for whom the key is generated.</param>
        /// <param name="operation">The operation for which the key is to be used.</param>
        /// <returns>The derrived private key</returns>
        public static KeyPairAdvanced ActivatePrivate(
                this PrivateKeyUDF activationSeed,
                KeyPair baseKey,
                MeshActor actor,
                MeshKeyOperation operation) {
            var activationKey = activationSeed.GenerateContributionKeyPair(
                        MeshKeyType.Activation, actor, operation) as KeyPairAdvanced;
            var combinedKey = activationKey.Combine(baseKey as KeyPairAdvanced, keyUses: baseKey.KeyUses);
            return combinedKey;
            }


        }

    }
