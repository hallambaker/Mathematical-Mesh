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


    public partial class Assertion {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Assertion() {
            }


        }

    public partial class Profile {


        ///<summary>The key contribution type</summary> 
        public virtual MeshKeyType MeshKeyType => Goedel.Mesh.MeshKeyType.Base;

        ///<summary>The actor type</summary> 
        public virtual MeshActor MeshActor => throw new NYI();

        ///<summary>The key identifier</summary> 
        public virtual UdfAlgorithmIdentifier UdfAlgorithmIdentifier =>
            MeshActor switch
                {
                    MeshActor.Device => UdfAlgorithmIdentifier.MeshProfileDevice,
                    MeshActor.Host => UdfAlgorithmIdentifier.MeshProfileDevice,
                    MeshActor.Account => UdfAlgorithmIdentifier.MeshProfileAccount,
                    MeshActor.Service => UdfAlgorithmIdentifier.MeshProfileService,
                    //MeshActor.Host => UdfAlgorithmIdentifier.MeshProfileHost,
                    _ => throw new NYI()
                    };


        ///<summary>The primary key value.</summary>
        public override string _PrimaryKey => Udf;

        ///<summary>The UDF of the profile, that is the UDF of the offline signature.</summary>
        public string Udf => ProfileSignature.Udf;

        ///<summary>The secret seed value used to derrive the private keys.</summary>
        public PrivateKeyUDF SecretSeed { get; }

        /// <summary>
        /// Base constructor used for deserialization
        /// </summary>
        public Profile() {
            }

        /// <summary>
        /// Construct a Profile Host instance  from a <see cref="PrivateKeyUDF"/>
        /// </summary>
        /// <param name="secretSeed">The secret seed value.</param>
        /// <param name="keyCollection">The keyCollection to manage and persist the generated keys.</param>
        /// <param name="persist">If <see langword="true"/> persist the secret seed value to
        /// <paramref name="keyCollection"/>.</param>
        public Profile(
                    PrivateKeyUDF secretSeed,
                    IKeyCollection keyCollection=null,
                    bool persist = false) {
            SecretSeed = secretSeed ?? new PrivateKeyUDF(UdfAlgorithmIdentifier);

            // We always have a profile signature key in a profile.
            var profileSign = SecretSeed.GenerateContributionKeyPair(
                MeshKeyType, MeshActor, MeshKeyOperation.Profile);
            ProfileSignature = new KeyData(profileSign.KeyPairPublic());

            if (persist) {
                keyCollection.Persist(ProfileSignature.Udf, secretSeed, false);
                }

            // Generate profile specific keys
            Generate();

            // sign the profile.
            Envelope(profileSign);

            }

        /// <summary>
        /// Generate profile specific keys, is overriden in child classes.
        /// </summary>
        protected virtual void Generate() {
            }

        /// <summary>
        /// Verify the profile to check that it is correctly signed and consistent.
        /// </summary>
        /// <returns></returns>
        public virtual bool Validate() => Verify(DareEnvelope);

        /// <summary>
        /// Verify that the assertion contained in <paramref name="envelopedAssertion"/>
        /// has a valid signature under this profile.
        /// </summary>
        /// <param name="envelopedAssertion">Envelope containing the assertion 
        /// to be verified.</param>
        /// <returns>True if there is a valid signature under this profile, otherwise false.</returns>
        public bool Verify(DareEnvelope envelopedAssertion) {
            envelopedAssertion.Future();
            "Need to implement pathmath".TaskValidate();
            return false;
            }
        }
    }
