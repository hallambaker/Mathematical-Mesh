//  Copyright © 2020 Threshold Secrets llc
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

using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Utilities;

namespace Goedel.Mesh {
    public partial class ProfileService {

        ///<summary>The actor type</summary> 
        public override MeshActor MeshActor => MeshActor.Service;

        ///<summary>Typed enveloped data</summary> 
        public Enveloped<ProfileService> EnvelopedProfileService =>
            envelopedProfileService ?? new Enveloped<ProfileService>(DareEnvelope).
                    CacheValue(out envelopedProfileService);
        Enveloped<ProfileService> envelopedProfileService;



        /// <summary>
        /// Blank constructor for use by deserializers.
        /// </summary>
        public ProfileService() { }

        /// <summary>
        /// Construct a Profile Host instance  from a <see cref="PrivateKeyUDF"/>
        /// </summary>
        /// <param name="secretSeed">The secret seed value.</param>
        ProfileService(
                    IKeyCollection keyCollection,
                    PrivateKeyUDF secretSeed,
                    bool persist = false) : base(secretSeed, keyCollection, persist) {
            }


        /// <summary>
        /// Generate profile specific keys.
        /// </summary>
        protected override void Generate() {
            KeyAuthentication = SecretSeed.GenerateContributionKeyData(
                    MeshKeyType, MeshActor, MeshKeyOperation.Authenticate);
            KeyEncryption = SecretSeed.GenerateContributionKeyData(
                    MeshKeyType, MeshActor, MeshKeyOperation.Encrypt);
            }

        /// <summary>
        /// Construct a new ProfileDevice instance from a <see cref="PrivateKeyUDF"/>
        /// seed.
        /// </summary>
        /// <param name="secretSeed">The secret seed value.</param>
        /// <param name="algorithmEncrypt">The encryption algorithm.</param>
        /// <param name="algorithmSign">The signature algorithm</param>
        /// <param name="algorithmAuthenticate">The signature algorithm</param>
        /// <param name="bits">The size of key to generate in bits/</param>
        /// <param name="keyCollection">The keyCollection to manage and persist the generated keys.</param>
        /// <param name="persist">If <see langword="true"/> persist the secret seed value to
        /// <paramref name="keyCollection"/>.</param>
        /// <returns>The created profile.</returns>
        public static ProfileService Generate(
                    IKeyCollection keyCollection,
                    CryptoAlgorithmId algorithmEncrypt = CryptoAlgorithmId.Default,
                    CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default,
                    CryptoAlgorithmId algorithmAuthenticate = CryptoAlgorithmId.Default,
                    int bits = 256,
                    PrivateKeyUDF secretSeed = null,
                    bool persist = false) {
            secretSeed ??= new PrivateKeyUDF(
                UdfAlgorithmIdentifier.MeshProfileAccount, null, algorithmEncrypt,
                algorithmSign, algorithmAuthenticate, bits: bits);
            return new ProfileService(keyCollection, secretSeed, persist);
            }



        /// <summary>
        /// Constructor create service with the signature key <paramref name="keySign"/>
        /// </summary>
        /// <param name="keySign">The offline signature key.</param>
        /// <param name="keyEncrypt">The service encryption key.</param>
        public ProfileService(KeyPair keySign, KeyPair keyEncrypt) {
            ProfileSignature = new KeyData(keySign.KeyPairPublic());
            KeyEncryption = new KeyData(keyEncrypt.KeyPairPublic());
            }



        /// <summary>
        /// Generate a new <see cref="ProfileService"/>
        /// </summary>
        /// <param name="meshMachine">The mesh machine</param>
        /// <param name="algorithmSign">The signature algorithm.</param>
        /// <param name="algorithmEncrypt">The encryption algorithm.</param>
        /// <returns>The service profile.</returns>
        public static ProfileService Generate(
            IMeshMachine meshMachine,
            CryptoAlgorithmId algorithmEncrypt = CryptoAlgorithmId.Default,
            CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default) {

            algorithmSign = algorithmSign.DefaultAlgorithmSign();
            algorithmEncrypt = algorithmEncrypt.DefaultAlgorithmEncrypt();

            var keySign = meshMachine.CreateKeyPair(algorithmSign, KeySecurity.ExportableStored, keyUses: KeyUses.Sign);
            var keyEncrypt = meshMachine.CreateKeyPair(algorithmEncrypt, KeySecurity.ExportableStored, keyUses: KeyUses.Encrypt);
            //var keyAuthenticate = meshMachine.CreateKeyPair(algorithmSign, KeySecurity.Device, keyUses: KeyUses.KeyAgreement);


            var result = new ProfileService(keySign, keyEncrypt);
            result.Envelope(keySign);
            return result;
            }


        /// <summary>
        /// Create a host under this service.
        /// </summary>
        /// <param name="meshMachine">The machine.</param>
        /// <param name="algorithmSign">The signature algorithm.</param>
        /// <returns>The host profile.</returns>
        public ProfileHost CreateHost(IMeshMachine meshMachine,
                    CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default) => 
                        ProfileHost.Generate(algorithmSign);

        }


    }
