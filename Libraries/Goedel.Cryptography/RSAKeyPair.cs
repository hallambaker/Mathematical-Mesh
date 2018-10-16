//   Copyright © 2015 by Comodo Group Inc.
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
//  
//  
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Goedel.Utilities;
using Goedel.Cryptography.PKIX;

namespace Goedel.Cryptography {


    /// <summary>
    /// RSA Key Pair
    /// </summary>
    public partial class KeyPairRSA : KeyPairBaseRSA {
        /// <summary>
        /// Return the underlying .NET cryptographic provider.
        /// </summary>
        public AsymmetricAlgorithm AsymmetricAlgorithm => Provider;
        private RSA Provider;
        private RSAParameters PublicParameters;


        #region //Properties
        ///<summary>The private key parameters represented in PKIX form</summary>
        public override IPKIXPrivateKey PKIXPrivateKey {
            get {
                Assert.NotNull(PKIXPrivateKeyRSA, NotExportable.Throw);
                return PKIXPrivateKeyRSA;
                }
            }


        ///<summary>The public key parameters represented in PKIX form</summary>
        public override IPKIXPublicKey PKIXPublicKey => PKIXPublicKeyRSA;

        /// <summary>
        /// Return private key parameters in PKIX structure
        /// </summary>
        public override PKIXPrivateKeyRSA PKIXPrivateKeyRSA { get; }

        /// <summary>
        /// Return public key parameters in PKIX structure
        /// </summary>
        public override PKIXPublicKeyRSA PKIXPublicKeyRSA => PublicParameters.RSAPublicKey();

        /// <summary>The supported key uses (e.g. signing, encryption)</summary>
        public override KeyUses KeyUses { get; } = Cryptography.KeyUses.Any;

        public override KeyStorage KeyType { get; } = KeyStorage.Public;

        ///<summary>If true, the key only has access to public key values.</summary>
        public override bool PublicOnly { get; }

        #endregion


        /// <summary>
        /// Return the CryptoAlgorithmID that would be used with the specified base parameters.
        /// </summary>
        /// <param name="Base">The base algorithm</param>
        /// <returns>The computed CryptoAlgorithmID</returns>
        public override CryptoAlgorithmID SignatureAlgorithmID(CryptoAlgorithmID Base) =>
                CryptoAlgorithmID.RSASign | Base.Bulk();


        /// <summary>
        /// Return a PKIX SubjectPublicKeyInfo structure for the public key.
        /// </summary>
        public override SubjectPublicKeyInfo KeyInfoData =>
                new SubjectPublicKeyInfo(CryptoConfig.MapNameToOID("RSA"),
                        PKIXPublicKeyRSA.DER());

        /// <summary>
        /// Return a PKIX SubjectPublicKeyInfo structure for the private key.
        /// </summary>
        public override SubjectPublicKeyInfo PrivateKeyInfoData =>
                new SubjectPublicKeyInfo(CryptoConfig.MapNameToOID("RSA"),
                        PKIXPrivateKeyRSA.DER());

        KeyStorage keyStorage = KeyStorage.Public;

        /// <summary>
        /// Generate an ephemeral RSA key with the specified key size.
        /// </summary>
        /// <param name="rsa">The cryptographic provider.</param>
        /// <param name="keyType">The key type.</param>
        /// <param name="keyUses">The permitted key uses.</param>
        public KeyPairRSA(
                    RSA rsa,
                    KeyStorage keyType = KeyStorage.Public,
                    KeyUses keyUses = KeyUses.Any) {
            Provider = rsa;
            KeyType = keyType;
            KeyUses = keyUses;
            PublicParameters = rsa.ExportParameters(false);


            if (keyType.IsExportable()) {
                var PrivateParameters = Provider.ExportParameters(true);
                PKIXPrivateKeyRSA= PrivateParameters.RSAPrivateKey();
                }

            //switch (keyType) {
            //    case KeyStorage.Bound: {
            //        PersistKey(ref rsa, CspProviderFlags.UseNonExportableKey);
            //        break;
            //        }
            //    case KeyStorage.Persistable: {
            //        PersistKey(ref rsa, CspProviderFlags.UseNonExportableKey);
            //        keyType = KeyStorage.Bound;
            //        break;
            //        }
            //    case KeyStorage.Exportable: {
            //        PersistKey(ref rsa, CspProviderFlags.UseArchivableKey);
            //        break;
            //        }
            //    }
            //Provider = rsa;
            }

        /// <summary>
        /// Generate a KeyPair from a .NET set of parameters.
        /// </summary>
        /// <param name="RSAParameters">The RSA parameters.</param>
        /// <param name="keyType">The key type.</param>
        /// <param name="keyUses">The permitted key uses.</param>
        public KeyPairRSA(RSAParameters RSAParameters,
                    KeyStorage keyType = KeyStorage.Public,
                    KeyUses keyUses = KeyUses.Any) : this(GetRSA(RSAParameters), keyType, keyUses) {
            }

        /// <summary>
        /// Generate a KeyPair from a .NET set of parameters.
        /// </summary>
        /// <param name="PKIXParameters">The RSA parameters as a PKIX structure</param>
        public KeyPairRSA(PKIXPublicKeyRSA PKIXParameters) {
            PublicParameters = PKIXParameters.RSAParameters();
            Provider = new RSACryptoServiceProvider();
            Provider.ImportParameters(PublicParameters);
            }

        /// <summary>
        /// Generate a KeyPair from a .NET set of parameters.
        /// </summary>
        /// <param name="PKIXParameters">The RSA parameters as a PKIX structure</param>
        public KeyPairRSA(PKIXPrivateKeyRSA PKIXParameters) {
            PublicParameters = PKIXParameters.RSAParameters();

            Provider = new RSACryptoServiceProvider();
            Provider.ImportParameters(PublicParameters);
            }

        public static KeyPairRSA Generate(
                    int keySize = 0,
                    KeyStorage keyType = KeyStorage.Bound,
                    KeyUses keyUses = KeyUses.Any,
                    CryptoAlgorithmID algorithmID = CryptoAlgorithmID.NULL) {
            keySize = keySize == 0 ? 2048 : keySize;

            var cspParameters = new CspParameters() { Flags= CspProviderFlags.CreateEphemeralKey };
            var rsa = new RSACryptoServiceProvider(keySize, cspParameters);
            return new KeyPairRSA(rsa, keyType, keyUses);
            }


        static RSA GetRSA (RSAParameters RSAParameters) {
            var rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(RSAParameters);
            return rsa;
            }

        //// persistence methods
        //void PersistKey(ref RSA rsa, CspProviderFlags cspProviderFlags) {
        //    var privateParameters = rsa.ExportParameters(true);
        //    var cspParameters = new CspParameters() {
        //        Flags = cspProviderFlags,
        //        KeyContainerName = UDF
        //        };
        //    rsa = new RSACryptoServiceProvider(cspParameters);
        //    rsa.ImportParameters(privateParameters);


        //    }

        public override void Persist(KeyCollection keyCollection) {
            Assert.True(KeyType == KeyStorage.Exportable | KeyType == KeyStorage.Persistable);
            var privateParameters = Provider.ExportParameters(true);
            var pkix = privateParameters.RSAPrivateKey();
            keyCollection.Persist(pkix, KeyType.IsExportable());
            }

        /// <summary>
        /// Returns a new KeyPair instance which only has the public values.
        /// </summary>
        /// <returns></returns>
        public override KeyPair KeyPairPublic() {
            var Result = new KeyPairRSA(Provider.ExportParameters(false));
            Assert.True(Result.PublicOnly);
            return Result;
            }


        public static KeyPair Locate(string UDF) {
            var cspParameters = new CspParameters() {
                Flags = CspProviderFlags.UseExistingKey,
                KeyContainerName = UDF
                };
            try {
                var rsa = new RSACryptoServiceProvider(cspParameters);
                return new KeyPairRSA(rsa);
                }
            catch {
                return null;
                }
            }


        public static KeyPair KeyPairFactory(
                    KeyStorage keyType = KeyStorage.Public,
                    KeyUses keyUses = KeyUses.Any,
                    CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.Default,
                    int keySize=2048) =>
                    throw new NotImplementedException();

        /// <summary>
        /// Delegate to create a key pair base
        /// </summary>
        /// <param name="PKIXParameters">The parameters to construct from</param>
        /// <returns>The created key pair</returns>
        public static new KeyPair KeyPairPublicFactory (PKIXPublicKeyRSA PKIXParameters) {
            var RSAParameters = PKIXParameters.RSAParameters();
            return new KeyPairRSA(RSAParameters);
            }

        /// <summary>
        /// Delegate to create a key pair base
        /// </summary>
        /// <param name="PKIXParameters">The parameters to construct from</param>
        /// <returns>The created key pair</returns>
        public static new KeyPair KeyPairPrivateFactory (
                PKIXPrivateKeyRSA PKIXParameters,
        KeyStorage keyStorage, KeyCollection keyCollection) {
            var RSAParameters = PKIXParameters.RSAParameters();
            return new KeyPairRSA(RSAParameters, keyStorage);
            }


        #region // operations

        /// <summary>
        /// Encrypt a bulk key.
        /// </summary>
        /// <returns>The encoder</returns>
        /// <param name="Key">The key to encrypt.</param>
        /// <param name="Ephemeral">The ephemeral key to use for the exchange (if used)</param>
        /// <param name="Exchange">The private key to use for the exchange.</param>
        /// <param name="Salt">Optional salt value for use in key derivation.</param>
        public override void Encrypt(byte[] Key, out byte[] Exchange, out KeyPair Ephemeral, byte[] Salt = null) {
            Ephemeral = null;
            Exchange = Provider.Encrypt(Key, RSAEncryptionPadding.Pkcs1); 
                    // HACK: Should get the padding mode from the algorithm.
            }

        /// <summary>
        /// Perform a key exchange to encrypt a bulk or wrapped key under this one.
        /// </summary>
        /// <param name="EncryptedKey">The encrypted session</param>
        /// <param name="Ephemeral">Ephemeral key input (required for DH)</param>
        /// <param name="AlgorithmID">The algorithm to use.</param>
        /// <param name="Partial">Partial key agreement carry in (for recryption)</param>
        /// <param name="Salt">Optional salt value for use in key derivation. If specified
        /// must match the salt used to encrypt.</param>        
        /// <returns>The decoded data instance</returns>
        public override byte[] Decrypt(
                byte[] EncryptedKey,
                KeyPair Ephemeral = null,
                CryptoAlgorithmID AlgorithmID = CryptoAlgorithmID.Default,
                KeyAgreementResult Partial = null,
                byte[] Salt = null) => Provider.Decrypt(EncryptedKey, RSAEncryptionPadding.Pkcs1);

        /// <summary>
        /// Sign a precomputed digest
        /// </summary>
        /// <param name="Data">The data to sign.</param>
        /// <param name="AlgorithmID">The algorithm to use.</param>
        /// <param name="Context">Additional data added to the signature scope
        /// for protocol isolation.</param>
        /// <returns>The signature data</returns>
        public override byte[] SignHash(
                byte[] Data,
                CryptoAlgorithmID AlgorithmID = CryptoAlgorithmID.Default,
                byte[] Context = null) => Provider.SignHash(Data, AlgorithmID.ToHashAlgorithmName(), RSASignaturePadding.Pkcs1);

        /// <summary>
        /// Verify a signature over the purported data digest.
        /// </summary>
        /// <param name="Signature">The signature blob value.</param>
        /// <param name="AlgorithmID">The signature and hash algorithm to use.</param>
        /// <param name="Context">Additional data added to the signature scope
        /// for protocol isolation.</param>
        /// <param name="Digest">The digest value to be verified.</param>
        /// <returns>True if the signature is valid, otherwise false.</returns>
        public override bool VerifyHash(byte[] Digest, byte[] Signature,
                CryptoAlgorithmID AlgorithmID = CryptoAlgorithmID.Default, byte[] Context = null) => Provider.VerifyHash(Digest, Signature, AlgorithmID.ToHashAlgorithmName(), RSASignaturePadding.Pkcs1);
        #endregion
        }

    }
