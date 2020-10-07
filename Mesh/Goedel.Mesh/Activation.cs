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

using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;

namespace Goedel.Mesh {
    public partial class Activation {


        ///<summary>The key contribution type</summary> 
        public virtual MeshKeyType MeshKeyType => Goedel.Mesh.MeshKeyType.Activation;

        ///<summary>The key identifier</summary> 
        public virtual UdfAlgorithmIdentifier UdfAlgorithmIdentifier =>
            throw new NYI();


        ///<summary>The <see cref="ProfileDevice"/> that this activation activates.</summary>
        public ProfileDevice ProfileDevice { get; set; }

        ///<summary>The aggregate signature key</summary>
        protected KeyPairAdvanced ProfileSignature { get; set; }

        ///<summary>The UDF identifier</summary>
        public string UDF => ProfileSignature.KeyIdentifier;

        ///<summary>The connection value.</summary>
        public virtual Connection Connection => throw new NYI();

        ///<summary>The activation seed key.</summary> 
        public PrivateKeyUDF ActivationSeed { get; set; }

        /// <summary>
        /// Base constructor.
        /// </summary>
        public Activation() {
            }


        /// <summary>
        /// Constructor creating a new <see cref="Activation"/> for a profile of type
        /// <paramref name="profile"/>. The property <see cref="ActivationUdf"/> is
        /// calculated from the values <paramref name="udfAlgorithmIdentifier"/>. 
        /// If the value <paramref name="masterSecret"/> is
        /// specified, it is used as the seed value. Otherwise, a seed value of
        /// length <paramref name="bits"/> is generated.
        /// The <see cref="ProfileSignature"/> public key value is calculated for the specified 
        /// parameters. Other key pair properties should be populated by the caller.
        /// </summary>
        /// <param name="profile">The base profile that the activation activates.</param>
        /// <param name="udfAlgorithmIdentifier">The UDF key derivation specifier.</param>
        /// <param name="masterSecret">If not null, specifies the seed value. Otherwise,
        /// a seed value of <paramref name="bits"/> length is generated.</param>
        /// <param name="bits">The size of the seed to be generated if 
        /// <paramref name="masterSecret"/> is null.</param>
        protected Activation(
                Profile profile,
                UdfAlgorithmIdentifier udfAlgorithmIdentifier,
                byte[] masterSecret = null,
                int bits = 256) {
            (var actor, var keytype) = udfAlgorithmIdentifier.GetMeshKeyType();
            ActivationKey = Cryptography.UDF.DerivedKey(udfAlgorithmIdentifier, data: masterSecret, bits);
            ActivationSeed = new PrivateKeyUDF(ActivationKey);

            ProfileSignature = ActivationSeed.ActivatePublic(
                    profile.ProfileSignature.GetKeyPairAdvanced(), actor, MeshKeyOperation.Profile);
            }


        /// <summary>
        /// Encrypt this activation under the ProfileDevice encryption key.
        /// </summary>
        /// <returns>The actrivation profile encrypted under the encryption key of
        /// the corresponding <see cref="ProfileDevice"/>.</returns>
        public DareEnvelope Package(CryptoKey SignatureKey) => 
                Envelope(SignatureKey, ProfileDevice.BaseEncryption.CryptoKey);

        }
    }
