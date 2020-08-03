//   Copyright © 2015 by Comodo Group Inc.
//   Copyright © 2019 Phillip Hallam-Baker 
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
using Goedel.Cryptography.PKIX;
using Goedel.Utilities;

using System;
using System.Security.Cryptography;

namespace Goedel.Cryptography {


    /// <summary>
    /// RSA Key Pair
    /// </summary>
    public partial class KeyPairRSA : KeyPairBaseRSA {
        /// <summary>
        /// Return the underlying .NET cryptographic provider.
        /// </summary>
        public virtual AsymmetricAlgorithm AsymmetricAlgorithm => provider;
        private RSACryptoServiceProvider provider;
        private RSAParameters publicParameters;


        #region //Properties
        ///<summary>The private key parameters represented in PKIX form</summary>
        public override IPKIXPrivateKey PKIXPrivateKey {
            get {
                Assert.AssertNotNull(PkixPrivateKeyRSA, NotExportable.Throw);
                return PkixPrivateKeyRSA;
                }
            }


        ///<summary>The public key parameters represented in PKIX form</summary>
        public override IPkixPublicKey PkixPublicKey => PkixPublicKeyRsa;

        /// <summary>
        /// Return private key parameters in PKIX structure
        /// </summary>
        public override PkixPrivateKeyRsa PkixPrivateKeyRSA { get; }

        /// <summary>
        /// Return public key parameters in PKIX structure
        /// </summary>
        public override PkixPublicKeyRsa PkixPublicKeyRsa => publicParameters.GetPkixPublicKeyRsa();

        /// <summary>The supported key uses (e.g. signing, encryption)</summary>
        public override KeyUses KeyUses { get; } = Cryptography.KeyUses.Any;

        ///<summary>If true, the key only has access to public key values.</summary>
        public override bool PublicOnly => provider.PublicOnly;

        #endregion


        /// <summary>
        /// Return the CryptoAlgorithmID that would be used with the specified base parameters.
        /// </summary>
        /// <param name="Base">The base algorithm</param>
        /// <returns>The computed CryptoAlgorithmID</returns>
        public override CryptoAlgorithmId SignatureAlgorithmID(CryptoAlgorithmId Base) =>
                CryptoAlgorithmId.RSASign | Base.Bulk();


        /// <summary>
        /// Return a PKIX SubjectPublicKeyInfo structure for the public key.
        /// </summary>
        public override SubjectPublicKeyInfo KeyInfoData =>
                new SubjectPublicKeyInfo(CryptoConfig.MapNameToOID("RSA"),
                        PkixPublicKeyRsa.DER());

        /// <summary>
        /// Return a PKIX SubjectPublicKeyInfo structure for the private key.
        /// </summary>
        public override SubjectPublicKeyInfo PrivateKeyInfoData =>
                new SubjectPublicKeyInfo(CryptoConfig.MapNameToOID("RSA"),
                        PkixPrivateKeyRSA.DER());

        /// <summary>
        /// Generate an ephemeral RSA key with the specified key size.
        /// </summary>
        /// <param name="rsa">The cryptographic provider.</param>
        /// <param name="keyType">The key type.</param>
        /// <param name="keyUses">The permitted key uses.</param>
        public KeyPairRSA(
                    RSACryptoServiceProvider rsa,
                    KeySecurity keyType = KeySecurity.Public,
                    KeyUses keyUses = KeyUses.Any) {
            provider = rsa;
            KeySecurity = keyType;
            KeyUses = keyUses;
            publicParameters = rsa.ExportParameters(false);

            if (keyType.IsExportable()) {
                var PrivateParameters = provider.ExportParameters(true);
                PkixPrivateKeyRSA = PrivateParameters.GetPkixPrivateKeyRSA();
                }
            }

        /// <summary>
        /// Generate a KeyPair from a .NET set of parameters.
        /// </summary>
        /// <param name="RSAParameters">The RSA parameters.</param>
        /// <param name="keyType">The key type.</param>
        /// <param name="keyUses">The permitted key uses.</param>
        public KeyPairRSA(RSAParameters RSAParameters,
                    KeySecurity keyType = KeySecurity.Public,
                    KeyUses keyUses = KeyUses.Any) : this(GetRSA(RSAParameters), keyType, keyUses) {
            }

        /// <summary>
        /// Generate a KeyPair from a .NET set of parameters.
        /// </summary>
        /// <param name="PKIXParameters">The RSA parameters as a PKIX structure</param>
        public KeyPairRSA(PkixPublicKeyRsa PKIXParameters) {
            publicParameters = PKIXParameters.GetRsaParameters();
            provider = new RSACryptoServiceProvider();
            provider.ImportParameters(publicParameters);
            }

        /// <summary>
        /// Generate a KeyPair from a .NET set of parameters.
        /// </summary>
        /// <param name="PKIXParameters">The RSA parameters as a PKIX structure</param>
        public KeyPairRSA(PkixPrivateKeyRsa PKIXParameters) {
            publicParameters = PKIXParameters.GetRsaParameters();

            provider = new RSACryptoServiceProvider();
            provider.ImportParameters(publicParameters);
            }

        /// <summary>
        /// Generate a new RSA KeyPair with the specified parameters.
        /// </summary>
        /// <param name="keySize">The Key size</param>
        /// <param name="keySecurity">The key security model</param>
        /// <param name="keyUses">The permitted uses (signing, exchange) for the key.</param>
        /// <param name="algorithmID">The key algorithm (ignored).</param>
        /// <returns>The created key pair</returns>
        public static KeyPairRSA Generate(
                    int keySize = 0,
                    KeySecurity keySecurity = KeySecurity.Bound,
                    KeyUses keyUses = KeyUses.Any,
                    CryptoAlgorithmId algorithmID = CryptoAlgorithmId.NULL) {
            keySize = keySize == 0 ? 2048 : keySize;

            var cspParameters = new CspParameters() { Flags = CspProviderFlags.CreateEphemeralKey };
            var rsa = new RSACryptoServiceProvider(keySize, cspParameters);
            return new KeyPairRSA(rsa, keySecurity, keyUses);
            }


        static RSACryptoServiceProvider GetRSA(RSAParameters RSAParameters) {
            var rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(RSAParameters);
            return rsa;
            }


        /// <summary>
        /// Persist key to <paramref name="keyCollection"/>.
        /// </summary>
        /// <param name="keyCollection">Key Collection the key is to be persisted to.</param>
        public override void Persist(KeyCollection keyCollection) {
            Assert.AssertTrue(PersistPending, CryptographicException.Throw);
            var privateParameters = provider.ExportParameters(true);
            var pkix = privateParameters.GetPkixPrivateKeyRSA();
            keyCollection.Persist(KeyIdentifier, pkix, KeySecurity.IsExportable());
            }

        /// <summary>
        /// Returns a new KeyPair instance which only has the public values.
        /// </summary>
        /// <returns></returns>
        public override KeyPair KeyPairPublic() {
            var result = new KeyPairRSA(provider.ExportParameters(false), KeySecurity.Public, KeyUses.Sign);
            Assert.AssertTrue(result.PublicOnly, CryptographicException.Throw);
            return result;
            }

        /// <summary>
        /// Locate key by fingerprint.
        /// </summary>
        /// <param name="UDF">Fingerprint of key to be located.</param>
        /// <returns>The located key (if found).</returns>
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

        /// <summary>
        /// Factory method.
        /// </summary>
        /// <param name="keySecurity">The key security model</param>
        /// <param name="keyUses">The permitted uses (signing, exchange) for the key.</param>
        /// <param name="algorithmID">The type of keypair to create.</param>
        /// <param name="keySize">The key size</param>
        /// <returns>The created key pair</returns>
        public static KeyPair KeyPairFactory(
                    KeySecurity keySecurity = KeySecurity.Public,
                    KeyUses keyUses = KeyUses.Any,
                    CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
                    int keySize = 2048) =>
                    throw new NotImplementedException();

        /// <summary>
        /// Delegate to create a key pair base
        /// </summary>
        /// <param name="pkixParameters">The parameters to construct from</param>
        /// <returns>The created key pair</returns>
        public static new KeyPair KeyPairPublicFactory(PkixPublicKeyRsa pkixParameters) {
            var rsaParameters = pkixParameters.GetRsaParameters();
            return new KeyPairRSA(rsaParameters);
            }

        /// <summary>
        /// Delegate to create a key pair base
        /// </summary>
        /// <param name="PKIXParameters">The parameters to construct from</param>
        /// <param name="keySecurity">The key security model</param>
        /// <param name="keyCollection">The key collection that keys are to be persisted to (dependent on 
        /// the value of <paramref name="keySecurity"/></param>/// <returns>The created key pair</returns>
        public static new KeyPair KeyPairPrivateFactory(
                PkixPrivateKeyRsa PKIXParameters,
        KeySecurity keySecurity, KeyCollection keyCollection) {
            var RSAParameters = PKIXParameters.GetRsaParameters();
            return new KeyPairRSA(RSAParameters, keySecurity);
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
            Exchange = provider.Encrypt(Key, RSAEncryptionPadding.Pkcs1);
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
                CryptoAlgorithmId AlgorithmID = CryptoAlgorithmId.Default,
                KeyAgreementResult Partial = null,
                byte[] Salt = null) => provider.Decrypt(EncryptedKey, RSAEncryptionPadding.Pkcs1);

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
                CryptoAlgorithmId AlgorithmID = CryptoAlgorithmId.Default,
                byte[] Context = null) => provider.SignHash(Data, AlgorithmID.ToHashAlgorithmName(), RSASignaturePadding.Pkcs1);

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
                CryptoAlgorithmId AlgorithmID = CryptoAlgorithmId.Default, byte[] Context = null) => provider.VerifyHash(Digest, Signature, AlgorithmID.ToHashAlgorithmName(), RSASignaturePadding.Pkcs1);
        #endregion
        }

    }
