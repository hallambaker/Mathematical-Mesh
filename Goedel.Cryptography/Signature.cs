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
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Goedel.Cryptography {

    /// <summary>
    /// Base class for all public key cryptographic providers.
    /// </summary>
    public abstract class CryptoProviderAsymmetric : CryptoProvider {
        /// <summary>
        /// Generates a new signing key pair with the default key size.
        /// </summary>
        /// <param name="KeySecurity">Specifies the protection level for the key.</param>

        public abstract void Generate(KeySecurity KeySecurity);

        /// <summary>
        /// Locate the privatge key in the local key store.
        /// </summary>
        /// <param name="UDF">Fingerprint of key to locate.</param>
        /// <returns></returns>
        public abstract bool FindLocal(string UDF);

        }


    /// <summary>
    /// Crypto provider for digital signature algorithms.
    /// 
    /// The chief reason this is necessary is the excrable nature of the .NET APIs
    /// in which the base class does not expose methods such as sign.
    /// </summary>
    public abstract class CryptoProviderSignature : CryptoProviderAsymmetric {
        /// <summary>
        /// The type of algorithm
        /// </summary>
        public override CryptoAlgorithmClass AlgorithmClass { get { return CryptoAlgorithmClass.Signature; } }

        /// <summary>
        /// The digest algorithm.
        /// </summary>
        public CryptoAlgorithmID DigestAlgorithm {
            get { return _DigestAlgorithm; }
            set { _DigestAlgorithm = value; }
            }
        private CryptoAlgorithmID _DigestAlgorithm;

        /// <summary>
        /// Return a provider for the current digest algorithm.
        /// </summary>
        /// <returns>Digest provider</returns>
        public CryptoProviderDigest GetDigestProvider() {
            return CryptoCatalog.Default.GetDigest(DigestAlgorithm);
            }



        

        
        /// <summary>
        /// Sign a previously computed digest (requires private key).
        /// </summary>
        /// <param name="Data">Computed digest</param>
        /// <returns>Signature</returns>
        public abstract CryptoData Sign(CryptoData Data);


        /// <summary>
        /// Sign data using the default digest (requires private key).
        /// </summary>
        /// <param name="Data">Data to be signed.</param>
        /// <returns>Signature.</returns>
        public CryptoData Sign(byte[] Data) {
            var DigestProvider = GetDigestProvider();
            var DigestResult = DigestProvider.Process(Data);
            return Sign(DigestResult);
            }




        /// <summary>
        /// Verify signature.
        /// </summary>
        /// <param name="Data">Computed digest</param>
        /// <param name="Signature">Signature</param>
        /// <returns>True if signature verification is successful, otherwise false.</returns>
        public abstract bool Verify(CryptoData Data, byte[] Signature);

        /// <summary>
        /// Verify signature.
        /// </summary>
        /// <param name="Data">Computed digest</param>
        /// <param name="Signature">Signature</param>
        /// <returns>True if signature verification is successful, otherwise false.</returns>
        public virtual bool Verify(CryptoData Data, CryptoData Signature) {
            return Verify(Data, Signature.Integrity);
            }

        /// <summary>
        /// Verify signature.
        /// </summary>
        /// <param name="Data">Computed digest</param>
        /// <param name="Signature">Signature</param>
        /// <returns>True if signature verification is successful, otherwise false.</returns>
        public virtual bool Verify(byte[] Data, byte[] Signature) {
            var DigestProvider = GetDigestProvider();
            var DigestResult = DigestProvider.Process(Data);
            return Verify(DigestResult, Signature);
            }


        /// <summary>
        /// JSON Key use.
        /// </summary>
        public override string JSONKeyUse { get { return "sig"; } }


        }

    /// <summary>
    /// Provider for RSA Signature class.
    /// </summary>
    public class CryptoProviderSignatureRSA : CryptoProviderSignature {
        RSAKeyPair _RSAKeyPair;

        /// <summary>
        /// Return the provider key.
        /// </summary>
        public override KeyPair KeyPair {
            get { return _RSAKeyPair; }
            set { _RSAKeyPair = value as RSAKeyPair; }
            }

        RSACryptoServiceProvider Provider {
            get { return _RSAKeyPair.Provider; }
            }


        /// <summary>
        /// ASN.1 Object Identifier.
        /// </summary>
        public override string OID {
            get {
                switch (DigestAlgorithm) {
                    case CryptoAlgorithmID.SHA_1_DEPRECATED:
                        return PKIX.Constants.OIDS__sha1WithRSAEncryption;
                    case CryptoAlgorithmID.SHA_2_256:
                        return PKIX.Constants.OIDS__sha256WithRSAEncryption;
                    case CryptoAlgorithmID.SHA_2_512:
                        return PKIX.Constants.OIDS__sha512WithRSAEncryption;
                    case CryptoAlgorithmID.SHA_3_256:
                        return PKIX.Constants.OIDS__sha256WithRSAEncryption;
                    case CryptoAlgorithmID.SHA_3_512:
                        return PKIX.Constants.OIDS__sha512WithRSAEncryption;
                    default:
                        return null;
                    }
                }
            }



        private int _KeySize;
        /// <summary>
        /// The default key size.
        /// </summary>
        public int KeySize {
            get { return _KeySize; }
            set { _KeySize = value; }
            }


        /// <summary>
        /// Create an instance of the RSA crypto provider.
        /// </summary>
        /// <param name="KeySize">Default key size.</param>
        public CryptoProviderSignatureRSA(int KeySize) :
            this(KeySize, CryptoAlgorithmID.SHA_2_512) {
            }

        /// <summary>
        /// Create an instance of the RSA crypto provider with specified 
        /// default key size and digest algorithm.
        /// </summary>
        /// <param name="KeySize">Default key size.</param>
        /// <param name="DigestAlgorithm">Default digest algorithm.</param>
        public CryptoProviderSignatureRSA(int KeySize, CryptoAlgorithmID DigestAlgorithm) {
            this.KeySize = KeySize;
            this.DigestAlgorithm = DigestAlgorithm;
            }


        /// <summary>
        /// Create an instance of the RSA crypto provider from an RSA Key Pair.
        /// </summary>
        /// <param name="RSAKeyPair">The RSA Key Pair</param>
        public CryptoProviderSignatureRSA(RSAKeyPair RSAKeyPair)  {
            this._RSAKeyPair = RSAKeyPair;
            this.DigestAlgorithm = CryptoCatalog.Default.AlgorithmDigest;
            }


        /// <summary>
        /// Returns the default crypto provider.
        /// </summary>
        public override GetCryptoProvider GetCryptoProvider {
            get {
                return Factory;
                }
            }

        private static CryptoProvider Factory(int KeySize, CryptoAlgorithmID DigestAlgorithm) {
            return new CryptoProviderSignatureRSA(KeySize, DigestAlgorithm);
            }

        /// <summary>
        /// The CryptoAlgorithmID Identifier.
        /// </summary>
        public override CryptoAlgorithmID CryptoAlgorithmID {
            get {

                if (KeySize == 2048) {
                    return CryptoAlgorithmID.RSASign2048;
                    }
                return CryptoAlgorithmID.RSASign4096;
                }
            }

        /// <summary>
        /// .NET Framework name
        /// </summary>
        public override string Name {
            get {
                return "RSA";
                }
            }
        /// <summary>
        /// JSON Algorithm Name
        /// </summary>
        public override string JSONName {
            get {
                return "RS512"; // NYI placeholder for now
                }
            }


        /// <summary>
        /// JSON Key type.
        /// </summary>
        public override string JSONKeyType { get { return "rsa"; } }


        /// <summary>
        /// Default algorithm key size.
        /// </summary>
        public override int Size {
            get {
                return KeySize;
                }
            }

        /// <summary>
        /// The key fingerprint.
        /// </summary>
        public override string UDF {
            get {
                if (_RSAKeyPair == null) return null;
                return _RSAKeyPair.UDF;
                }
            }

        /// <summary>
        /// Generate a new RSA Key Pair with the Key size specified when the 
        /// instance was created.
        /// </summary>
        public override void Generate(KeySecurity KeySecurity) {
            _RSAKeyPair = new RSAKeyPair(KeySize);
            _RSAKeyPair.Persist(KeySecurity);
            }

        /// <summary>
        /// Locate the private key in the local key store.
        /// </summary>
        /// <param name="UDF">Fingerprint of key to locate.</param>
        /// <returns></returns>
        public override bool FindLocal(string UDF) {
            _RSAKeyPair = new RSAKeyPair(UDF);
            return _RSAKeyPair.Provider != null;
            }

        /// <summary>
        /// Sign a previously computed digest (requires private key).
        /// </summary>
        /// <param name="Data">Computed digest</param>
        /// <returns>Signature</returns>
        public override CryptoData Sign(CryptoData Data) {
            var Signature = Provider.SignHash(Data.Integrity, Data.OID);
            var Result = new CryptoData(CryptoAlgorithmID, OID, Signature);
            return Result;
            }

        /// <summary>
        /// Verify signature.
        /// </summary>
        /// <param name="Data">Computed digest</param>
        /// <param name="Signature">Signature</param>
        /// <returns>True if signature verification is successful, otherwise false.</returns>
        public override bool Verify(CryptoData Data, byte [] Signature) {
            return Provider.VerifyHash(Data.Integrity, Data.OID, Signature);
            }

        }




    }
