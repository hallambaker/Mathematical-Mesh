using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;

namespace Goedel.Mesh {


    public partial class Assertion {

  

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Assertion() {
            }



        public KeyPairAdvanced Combine (
                KeyCollection keyCollection,
                PublicKey baseKey,
                string secret,
                string salt1,
                string salt)  {
            throw new NYI();

            }

        public KeyPair Derive (
                KeyCollection keyCollection,
                PrivateKeyUDF secretSeed,
                string suffix) {

            KeyUses keyUses = KeyUses.Sign;
            CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.NULL;
            switch (suffix) {
                case Constants.UDFMeshKeySufixEncrypt: {
                    keyUses = KeyUses.Encrypt;
                    cryptoAlgorithmID = secretSeed.AlgorithmEncryptID;
                    break;
                    }
                case Constants.UDFMeshKeySufixSign: {
                    keyUses = KeyUses.Sign;
                    cryptoAlgorithmID = secretSeed.AlgorithmSignID;
                    break;
                    }
                case Constants.UDFMeshKeySufixAuthenticate: {
                    keyUses = KeyUses.KeyAgreement;
                    cryptoAlgorithmID = secretSeed.AlgorithmAuthenticateID;
                    break;
                    }
                }

            return Cryptography.UDF.DeriveKey(secretSeed.PrivateValue, keyCollection,
               KeySecurity.Ephemeral, keyUses: keyUses, cryptoAlgorithmID, suffix);
            }



        }

    public partial class Profile {

        ///<summary>The primary key value.</summary>
        public override string _PrimaryKey => UDF;

        ///<summary>The UDF of the profile, that is the UDF of the offline signature.</summary>
        public string UDF => KeyOfflineSignature.UDF;

        ///<summary>The full UDF binary key value.</summary>
        public byte[] UDFBytes => KeyOfflineSignature.KeyPair.PKIXPublicKey.UDFBytes(512);


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
            "Need to implement pathmath".TaskValidate();
            return false;
            }

        }

    public partial class Activation {
        ///<summary>The aggregate signature key</summary>
        public KeyPairAdvanced KeySignature;

        /// <summary>
        /// Base constructor.
        /// </summary>
        public Activation() {
            }


        /// <summary>
        /// Default Constructor
        /// </summary>
        public Activation(
                Profile profile,
                KeyCollection keyCollection,
                UdfAlgorithmIdentifier udfAlgorithmIdentifier,
                string salt,
                byte[] masterSecret = null,
                int bits = 256) {
            masterSecret ??= Platform.GetRandomBits(bits);
            ActivationKey = Cryptography.UDF.DerivedKey(
                    UdfAlgorithmIdentifier.MeshProfileDevice, data: masterSecret);

            KeySignature = Combine(keyCollection, profile.KeyOfflineSignature,
                ActivationKey, Constants.UDFActivationDevice, Constants.UDFMeshKeySufixSign);


            }
        }
    }
