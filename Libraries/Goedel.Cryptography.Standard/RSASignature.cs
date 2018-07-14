////   Copyright © 2015 by Comodo Group Inc.
////  
////  Permission is hereby granted, free of charge, to any person obtaining a copy
////  of this software and associated documentation files (the "Software"), to deal
////  in the Software without restriction, including without limitation the rights
////  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
////  copies of the Software, and to permit persons to whom the Software is
////  furnished to do so, subject to the following conditions:
////  
////  The above copyright notice and this permission notice shall be included in
////  all copies or substantial portions of the Software.
////  
////  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
////  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
////  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
////  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
////  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
////  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
////  THE SOFTWARE.
////  
////  
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Text;
//using System.Threading.Tasks;
//using System.Security.Cryptography;
//using Goedel.Utilities;

//namespace Goedel.Cryptography.Standard {

//    /// <summary>
//    /// Provider for RSA Signature class.
//    /// </summary>
//    public class CryptoProviderSignatureRSA : CryptoProviderSignature {


//        /// <summary>
//        /// The CryptoAlgorithmID Identifier.
//        /// </summary>
//        public override CryptoAlgorithmID CryptoAlgorithmID => Goedel.Cryptography.CryptoAlgorithmID.RSASign;

//        /// <summary>
//        /// Return a CryptoAlgorithm structure with properties describing this provider.
//        /// </summary>
//        public override CryptoAlgorithm CryptoAlgorithm  => CryptoAlgorithmAny; 


//        static CryptoAlgorithm CryptoAlgorithmAny = new CryptoAlgorithm(
//                    Goedel.Cryptography.CryptoAlgorithmID.RSASign, _AlgorithmClass, Factory, 2048);

//        /// <summary>
//        /// Register this provider in the specified crypto catalog. A provider may 
//        /// register itself multiple times to describe different configurations that 
//        /// are supported.
//        /// </summary>
//        /// <param name="Catalog">The catalog to register the provider to, if
//        /// null, the default catalog is used.</param>
//        /// <returns>Description of the principal algorithm registration.</returns>
//        public static CryptoAlgorithm Register(CryptoCatalog Catalog = null) {
//            Catalog = Catalog ?? CryptoCatalog.Default;
//            return Catalog.Add(CryptoAlgorithmAny);
//            }




//        KeyPairRSA _RSAKeyPair;

//        /// <summary>
//        /// Return the provider key.
//        /// </summary>
//        public override Goedel.Cryptography.KeyPair KeyPair {
//            get => _RSAKeyPair; 
//            set => _RSAKeyPair = value as KeyPairRSA; 
//            }

//        RSACryptoServiceProvider Provider  => _RSAKeyPair.Provider;
//        /// <summary>
//        /// The default key size.
//        /// </summary>
//        public int KeySize { get; set; }


//        /// <summary>
//        /// Create an instance of the RSA crypto provider.
//        /// </summary>
//        /// <param name="KeySize">Default key size.</param>
//        public CryptoProviderSignatureRSA(int KeySize) :
//            this(KeySize, Goedel.Cryptography.CryptoAlgorithmID.SHA_2_512) {
//            }

//        /// <summary>
//        /// Create an instance of the RSA crypto provider with specified 
//        /// default key size and digest algorithm.
//        /// </summary>
//        /// <param name="KeySize">Default key size.</param>
//        /// <param name="DigestAlgorithm">Default digest algorithm.</param>
//        public CryptoProviderSignatureRSA(int KeySize, 
//                    CryptoAlgorithmID DigestAlgorithm = CryptoAlgorithmID.Default) {
//            this.KeySize = KeySize;
//            this.BulkAlgorithmDefault = DigestAlgorithm.DefaultBulk (BulkAlgorithmDefault);
//            }


//        /// <summary>
//        /// Create an instance of the RSA crypto provider from an RSA Key Pair.
//        /// </summary>
//        /// <param name="RSAKeyPair">The RSA Key Pair</param>
//        public CryptoProviderSignatureRSA(KeyPairRSA RSAKeyPair)  {
//            this._RSAKeyPair = RSAKeyPair;
//            this.BulkAlgorithmDefault = CryptoCatalog.Default.AlgorithmDigest;
//            }


//        private static CryptoProvider Factory(int KeySize, CryptoAlgorithmID DigestAlgorithm) => new CryptoProviderSignatureRSA(KeySize, DigestAlgorithm);


//        /// <summary>
//        /// Default algorithm key size.
//        /// </summary>
//        public override int Size  => KeySize;


//        /// <summary>
//        /// The key fingerprint.
//        /// </summary>
//        public override string UDF  => _RSAKeyPair?.UDF;


//        /// <summary>
//        /// Generate a new RSA Key Pair with the Key size specified when the 
//        /// instance was created.
//        /// </summary>
//        /// <param name="KeySecurity">The key security level.</param>
//        /// <param name="Size">The key size (2048 or 4096), if zero the default is used.</param>
//        public override void Generate(KeySecurity KeySecurity, int Size = 0) {
//            KeySize = (Size == 0) ? KeySize : Size;
//            _RSAKeyPair = new KeyPairRSA(KeySecurity, KeySize);
//            //_RSAKeyPair.Persist(KeySecurity);
//            }

//        /// <summary>
//        /// Locate the private key in the local key store.
//        /// </summary>
//        /// <param name="UDF">Fingerprint of key to locate.</param>
//        /// <returns>True if key is found, otherwise false.</returns>
//        public override bool FindLocal(string UDF) {
//            _RSAKeyPair = new KeyPairRSA(UDF);
//            return _RSAKeyPair.Provider != null;
//            }

//        ///// <summary>
//        ///// Verify signature.
//        ///// </summary>
//        ///// <param name="Data">Computed digest</param>
//        ///// <param name="Signature">Signature</param>
//        ///// <returns>True if signature verification is successful, otherwise false.</returns>
//        //public override bool Verify(CryptoData Data, byte [] Signature) {
//        //    return Provider.VerifyHash(Data.Integrity, Data.OID, Signature);
//        //    }



//        /// <summary>
//        /// Sign the integrity value specified in the CryptoDataEncoder
//        /// </summary>
//        /// <param name="Data">Data to sign.</param>
//        public override void Sign(CryptoDataSignature Data) {


//            KeyPair.GetPrivate();

//            switch (Data.BulkData.BulkID) {
//                case CryptoAlgorithmID.SHA_2_256: {
//                    Data.Signature = Provider.SignHash(Data.BulkData.Integrity, 
//                        HashAlgorithmName.SHA256,
//                        RSASignaturePadding.Pkcs1);
//                    break;
//                    }
//                case CryptoAlgorithmID.SHA_2_512: {
//                    Data.Signature = Provider.SignHash(Data.BulkData.Integrity, 
//                        HashAlgorithmName.SHA512,
//                        RSASignaturePadding.Pkcs1);
//                    break;
//                    }

//                }
//            return ;
//            }

//        /// <summary>
//        /// Verify the signature value
//        /// </summary>
//        /// <param name="Bulk">The provider to wrap.</param>
//        /// <param name="Signature">The signature blob value.</param>
//        /// <param name="AlgorithmID">The algorithm used.</param>
//        /// <returns>True if the verification operation succeeded, otherwise false</returns>
//        public override bool Verify(CryptoData Bulk, Byte[] Signature,
//                CryptoAlgorithmID AlgorithmID = CryptoAlgorithmID.Default) {

//            switch (Bulk.BulkID) {
//                case CryptoAlgorithmID.SHA_2_256: {
//                    return Provider.VerifyHash(Bulk.Integrity, Signature,
//                        HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
//                    }
//                case CryptoAlgorithmID.SHA_2_512: {
//                    return Provider.VerifyHash(Bulk.Integrity, Signature,
//                        HashAlgorithmName.SHA512, RSASignaturePadding.Pkcs1);
//                    }

//                }


//            throw new NYI("To do");
//            }

//        }




//    }
