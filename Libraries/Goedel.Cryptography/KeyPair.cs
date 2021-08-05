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
using Goedel.Cryptography.PKIX;
using Goedel.Utilities;

namespace Goedel.Cryptography {
    /// <summary>
    /// Base class for all cryptographic key pairs.
    /// </summary>
    public abstract partial class KeyPair : CryptoKey, IKeyDecrypt {

        /// <summary>
        /// The key locator, an Internet name in username@domain format. This is used as the basis 
        /// for constructing the Strong Internet Name.
        /// </summary>
        public string Locator { get; set; }

        /// <summary>
        /// The strong internet name for the key.
        /// </summary>
        public string StrongInternetName => Locator + ".mm--" + KeyIdentifier;

        /// <summary>The supported key uses (e.g. signing, encryption)</summary>
        public abstract KeyUses KeyUses { get; }


        ///<summary>The key security model</summary>
        public virtual KeySecurity KeySecurity { get; protected set; } = KeySecurity.Public;

        /// <summary>
        /// If true, keys will be created in containers prefixed with the name
        /// "test:" to allow them to be easily identified and cleaned up.
        /// </summary>
        public static bool TestMode { get; set; } = false;

        /// <summary>
        /// If true, the key has been written to persistent storage and will be 
        /// locatable by UDF after the application instance has terminated.
        /// </summary>
        public bool IsPersisted { get; set; } = false;

        /// <summary>
        /// If true, the KeySecurity model marks the key to be persisted but the key has not
        /// (yet) been stored.
        /// </summary>
        public bool PersistPending => (KeySecurity.IsPersistable() & !IsPersisted);


        ///<summary>If true, a signature generated using this key will always include the
        ///full public key parameters.</summary>
        public bool ForcePublicParameters { get; set; } = false;


        ///<summary>The length of a signature in bytes.</summary> 
        public abstract int LengthSignature { get; }

        /// <summary>
        /// Sign a precomputed digest
        /// </summary>
        /// <param name="data">The data to sign.</param>
        /// <param name="algorithmID">The algorithm to use.</param>
        /// <param name="context">Additional data added to the signature scope
        /// for protocol isolation.</param>
        /// <returns>The signature data</returns>
        public virtual byte[] Sign(byte[] data,
                CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
                byte[] context = null) {

            var hash = algorithmID.Bulk().GetDigest(data);
            return SignHash(hash, algorithmID, context);
            }


        /// <summary>
        /// Verify a signature over the purported data.
        /// </summary>
        /// <param name="signature">The signature blob value.</param>
        /// <param name="algorithmID">The signature and hash algorithm to use.</param>
        /// <param name="context">Additional data added to the signature scope
        /// for protocol isolation.</param>
        /// <param name="data">The data to be digested and verified.</param>
        /// <returns>True if the signature is valid, otherwise false.</returns>
        public virtual bool Verify(byte[] data, byte[] signature,
                CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default, byte[] context = null) {
            var hash = algorithmID.Bulk().GetDigest(data);
            return VerifyHash(hash, signature, algorithmID, context);
            }




        /// <summary>
        /// Factory method to generate a keypair of a type specified by <paramref name="algorithmID"/>
        /// and the specified parameters using the default implementation registered with the
        /// KeyPair type.
        /// </summary>
        /// <param name="algorithmID">The type of keypair to create.</param>
        /// <param name="keySize">The key size (ignored if the algorithm supports only one key size)</param>
        /// <param name="keySecurity">The key security model</param>
        /// <param name="keyCollection">The key collection that keys are to be persisted to (dependent on 
        /// the value of <paramref name="keySecurity"/></param>
        /// <param name="keyUses">The permitted uses (signing, exchange) for the key.</param>
        /// <returns>The created key pair</returns>
        public static KeyPair Factory(
                    CryptoAlgorithmId algorithmID,
                    KeySecurity keySecurity,
                    IKeyLocate keyCollection = null,
                    int keySize = 0,
                    KeyUses keyUses = KeyUses.Any) {

            KeyPair keyPair = null;

            switch (algorithmID) {
                case CryptoAlgorithmId.RSAExch: {
                    keyPair = KeyPairFactoryRSA(keySize, keySecurity, KeyUses.Encrypt, algorithmID);
                    break;
                    }

                case CryptoAlgorithmId.RSASign: {
                    keyPair = KeyPairFactoryRSA(keySize, keySecurity, KeyUses.Sign, algorithmID);
                    break;
                    }
                case CryptoAlgorithmId.DH: {
                    keyPair = KeyPairFactoryDH(keySize, keySecurity, keyUses, algorithmID);
                    break;
                    }
                case CryptoAlgorithmId.X25519:
                case CryptoAlgorithmId.Ed25519:
                case CryptoAlgorithmId.X448:
                case CryptoAlgorithmId.Ed448: {
                    keyPair = KeyPairFactoryECDH(keySize, keySecurity, keyUses, algorithmID);
                    break;
                    }

                default:
                break;
                }

            Register(keyPair, keySecurity, keyCollection);
            return keyPair;

            }


        /// <summary>
        /// Factory method to generate a signature keypair of a type specified by <paramref name="algorithmID"/>
        /// and the specified parameters using the default implementation registered with the
        /// KeyPair type.
        /// </summary>
        /// <param name="algorithmID">The type of keypair to create.</param>
        /// <param name="keySize">The key size (ignored if the algorithm supports only one key size)</param>
        /// <param name="keySecurity">The key security model</param>
        /// <param name="keyCollection">The key collection that keys are to be persisted to (dependent on 
        /// the value of <paramref name="keySecurity"/></param>
        /// <returns>The created key pair</returns>
        public static KeyPair FactorySignature(
                    CryptoAlgorithmId algorithmID,
                    KeySecurity keySecurity,
                    IKeyLocate keyCollection = null,
                    int keySize = 0) =>
                Factory(algorithmID.DefaultSignature(), keySecurity, keyCollection, keySize, KeyUses.Sign);

        /// <summary>
        /// Factory method to generate an encryption keypair of a type specified by <paramref name="algorithmID"/>
        /// and the specified parameters using the default implementation registered with the
        /// KeyPair type.
        /// </summary>
        /// <param name="algorithmID">The type of keypair to create.</param>
        /// <param name="keySize">The key size (ignored if the algorithm supports only one key size)</param>
        /// <param name="keySecurity">The key security model</param>
        /// <param name="keyCollection">The key collection that keys are to be persisted to (dependent on 
        /// the value of <paramref name="keySecurity"/></param>
        /// <returns>The created key pair</returns>
        public static KeyPair FactoryExchange(
            CryptoAlgorithmId algorithmID,
            KeySecurity keySecurity,
            IKeyLocate keyCollection = null,
            int keySize = 0) =>
                Factory(algorithmID.DefaultExchange(), keySecurity, keyCollection, keySize, KeyUses.Encrypt);


        /// <summary>
        /// Factory creating a key pair of the type specified by <paramref name="algorithmID"/>
        /// using the data provided by a UDF identifier. 
        /// </summary>
        /// <param name="algorithmID">The type of key to create.</param>
        /// <param name="keyCollection">The key collection to add the key to.</param>
        /// <param name="keySecurity">The key security model.</param>
        /// <param name="keyUses">The allowed key uses.</param>
        /// <param name="ikm">Initial keying material for the key.</param>
        /// <param name="keySpecifier">Key specifier material for the key.</param>
        /// <param name="keyName">Optional key name used to specify generation of multiple keys from 
        /// a single seed.</param>
        /// <param name="keySize">The size of the key in bits.</param>
        /// <returns>the derrived key.</returns>
        public static KeyPair Factory(
            CryptoAlgorithmId algorithmID,
            KeySecurity keySecurity,
            byte[] ikm,
            byte[] keySpecifier,
            string keyName,
            IKeyLocate keyCollection = null,
            int keySize = 0,
            KeyUses keyUses = KeyUses.Any) {

            KeyPair keyPair;

            switch (algorithmID) {
                case CryptoAlgorithmId.RSAExch: {
                    var bits = keySize / 2;
                    var seedp = KeySeed(bits, ikm, keySpecifier, keyName, "p");
                    var seedq = KeySeed(bits, ikm, keySpecifier, keyName, "q");
                    "Implement RSA generation from seed".TaskFunctionality(true);

                    keyPair = KeyPairFactoryRSA(keySize, keySecurity, KeyUses.Encrypt, algorithmID);
                    break;
                    }
                case CryptoAlgorithmId.RSASign: {
                    var bits = keySize / 2;
                    var seedp = KeySeed(bits, ikm, keySpecifier, keyName, "p");
                    var seedq = KeySeed(bits, ikm, keySpecifier, keyName, "q");
                    "Implement RSA generation from seed".TaskFunctionality(true);

                    keyPair = KeyPairFactoryRSA(keySize, keySecurity, KeyUses.Sign, algorithmID);
                    break;
                    }
                case CryptoAlgorithmId.DH: {
                    var bits = keySize;
                    var binaryData = KeySeed(bits, ikm, keySpecifier, keyName);
                    "Implement DH generation from seed".TaskFunctionality(true);

                    keyPair = KeyPairFactoryDH(keySize, keySecurity, keyUses, algorithmID);
                    break;
                    }
                case CryptoAlgorithmId.X25519: {

                    var binaryData = KeySeed(256, ikm, keySpecifier, keyName);
                    keyPair = new KeyPairX25519(binaryData, keySecurity, keyUses);
                    break;
                    }
                case CryptoAlgorithmId.Ed25519: {
                    var binaryData = KeySeed(256, ikm, keySpecifier, keyName);
                    keyPair = new KeyPairEd25519(binaryData, keySecurity, keyUses);
                    break;
                    }
                case CryptoAlgorithmId.X448: {
                    var binaryData = KeySeed(448, ikm, keySpecifier, keyName);
                    keyPair = new KeyPairX448(binaryData, keySecurity, keyUses);
                    break;
                    }
                case CryptoAlgorithmId.Ed448: {
                    var binaryData = KeySeed(448, ikm, keySpecifier, keyName);
                    keyPair = new KeyPairEd448(binaryData, keySecurity, keyUses);
                    break;
                    }
                default: {
                    throw new NYI();
                    }
                }
            Register(keyPair, keySecurity, keyCollection);
            return keyPair;
            }

        static byte[] KeySeed(
                int bits,
                byte[] ikm,
                byte[] keySpecifier,
                string keyName,
                string parameter = null) {

            keyName ??= "";
            parameter ??= "";

            var suffix = (keyName + parameter).ToBytes();
            var info = keySpecifier.Concatenate(suffix);

            return KeyDeriveHKDF.Derive(ikm, null, info, bits, CryptoAlgorithmId.HMAC_SHA_2_512);
            }

        /// <summary>
        /// Register the key pair <paramref name="keyPair"/> in the collection 
        /// <paramref name="keyCollection"/> and persist according to the key
        /// security model <paramref name="keySecurity"/>.
        /// </summary>
        /// <param name="keyPair">The key pair to persist.</param>
        /// <param name="keyCollection">The key collection to add the key to.</param>
        /// <param name="keySecurity">The key security model.</param>
        public static void Register(KeyPair keyPair,
                KeySecurity keySecurity,
                IKeyLocate keyCollection) {
            Assert.AssertNotNull(keyPair, NoProviderSpecified.Throw);
            keyPair.KeySecurity = keySecurity;

            if (keySecurity == KeySecurity.Ephemeral) {
                return;
                }
            keyCollection ??= Cryptography.KeyCollection.Default;
            keyCollection.Add(keyPair);

            if ((keySecurity & KeySecurity.Persistable) != KeySecurity.Persistable) {
                return;
                }
            keyCollection.Persist(keyPair);
            }

        /// <summary>
        /// Generate a new keypair. Initialized by the cryptographic
        /// platform provider.
        /// </summary>
        public static FactoryKeyPairDelegate KeyPairFactoryRSA { get; set; } = KeyPairRSA.Generate;

        /// <summary>
        /// Generate a new keypair. Initialized by the cryptographic
        /// platform provider.
        /// </summary>
        public static FactoryKeyPairDelegate KeyPairFactoryDH { get; set; } = KeyPairDH.Generate;

        /// <summary>
        /// Generate a new keypair. Initialized by the cryptographic
        /// platform provider.
        /// </summary>
        public static FactoryKeyPairDelegate KeyPairFactoryECDH { get; set; } = KeyPairECDH.KeyPairFactory;



        /// <summary>
        /// String presentation of the key pair
        /// </summary>
        /// <returns></returns>
        public override string ToString() =>
                CryptoAlgorithmId.ToString() + (PublicOnly ? ":Public:" : ":Private:") + KeyIdentifier;

        #region // Abstract Methods

        /// <summary>
        /// The public key data formatted as a PKIX KeyInfo data blob.
        /// </summary>
        public abstract SubjectPublicKeyInfo KeyInfoData { get; }


        /// <summary>
        /// The private key data formatted as a PKIX KeyInfo data blob.
        /// </summary>
        public abstract SubjectPublicKeyInfo PrivateKeyInfoData { get; }


        /// <summary>
        /// The private key data formatted as a PKIX KeyInfo data blob.
        /// </summary>
        public abstract IPKIXPrivateKey PKIXPrivateKey { get; }


        /// <summary>
        /// The private key data formatted as a PKIX KeyInfo data blob.
        /// </summary>
        public abstract IPkixPublicKey PkixPublicKey { get; }


        ///<summary>The raw UDF fingerprint.</summary>
        public override byte[] UDFBytes => udfBytes ??
                PkixPublicKey.UDFBytes(512).CacheValue(out udfBytes);
        byte[] udfBytes = null;



        /// <summary>
        /// Returns the UDF fingerprint of the current key as a string.
        /// </summary>
        public override string KeyIdentifier => udf ?? UDF.PresentationBase32(UDFBytes).CacheValue(out udf);
        string udf = null;

        ///<summary>The UDF fingerprint of this key pair.</summary>
        public string UDFValue => Cryptography.UDF.OID(this);



        /// <summary>
        /// Returns a new KeyPair instance which only has the public values.
        /// </summary>
        /// <returns></returns>
        public abstract KeyPair KeyPairPublic();

        /// <summary>
        /// If true, the provider only provides the public key values.
        /// </summary>
        public abstract bool PublicOnly { get; }

        /// <summary>
        /// Persist key to the key collection <paramref name="keyCollection"/>.
        /// </summary>
        /// <param name="keyCollection"></param>
        public abstract void Persist(KeyCollection keyCollection);



        #endregion

        }




    }
