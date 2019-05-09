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
using Goedel.Cryptography.PKIX;
using Goedel.Cryptography.Algorithms;
using Goedel.Utilities;
using Goedel.Protocol;

namespace Goedel.Cryptography.Jose {

    public partial class Key {

        /// <summary>Convert to Goedel.Cryptography.KeyPair</summary>
        public virtual KeyPair KeyPair => GetKeyPair (KeySecurity.Bound);


        /// <summary>
        /// Extract a KeyPair object from the JOSE data structure.
        /// </summary>
        /// <param name="keySecurity">The key security requirements. If KeySecurity.NULL is specified,
        /// the key security setting is ignored.</param>
        /// <param name="keyCollection">The key collection to add the key to.</param>
        /// <returns>The extracted key pair</returns>
        public virtual KeyPair GetKeyPair(
                    KeySecurity keySecurity, 
                    KeyCollection keyCollection = null) => 
            throw new InternalError("GetKeyPair method not implemented in child class");


        /// <summary>
        /// Return the public portion of the key pair.
        /// </summary>
        /// <param name="keyPair">The key pair.</param>
        /// <returns>Public portion.</returns>
        public static Key GetPublic(KeyPair keyPair) {
            switch (keyPair) {
                case KeyPairBaseRSA keyPairBaseRSA:
                    return new PublicKeyRSA(keyPairBaseRSA);
                case KeyPairBaseDH keyPairBaseDH:
                    return new PublicKeyDH(keyPairBaseDH);
                case KeyPairECDH keyPairECDH:
                    return new PublicKeyECDH(keyPairECDH);
                }
            throw new NYI();
            }

        /// <summary>
        /// Return the private portion of the keypair.
        /// </summary>
        /// <param name="keyPair">The key pair.</param>
        /// <returns>The private data.</returns>
        public static Key GetPrivate(KeyPair keyPair) {
            switch (keyPair) {
                case KeyPairBaseRSA keyPairBaseRSA:
                    return new PrivateKeyRSA(keyPairBaseRSA);
                case KeyPairBaseDH keyPairBaseDH:
                    return new PrivateKeyDH(keyPairBaseDH);
                case KeyPairECDH keyPairECDH:
                    return new PrivateKeyECDH(keyPairECDH);
                }
            throw new NYI();
            }

        /// <summary>
        /// Convert PKIX parameters to JSON structure.
        /// </summary>
        /// <param name="pkixKey">The PKIX key parameters</param>
        /// <returns>The JOSE key</returns>
        public static Key Factory (IPKIXPublicKey pkixKey) {

            switch (pkixKey) {
                case PKIXPrivateKeyRSA PKIXPrivateKeyRSA:   return new PrivateKeyRSA(PKIXPrivateKeyRSA);
                case PKIXPrivateKeyDH PKIXPrivateKeyDH:     return new PrivateKeyDH(PKIXPrivateKeyDH);
                case PKIXPrivateKeyECDH PKIXPrivateKeyECDH: return new PrivateKeyECDH(PKIXPrivateKeyECDH);
                case PKIXPublicKeyRSA PKIXPublicKeyRSA:     return new PublicKeyRSA(PKIXPublicKeyRSA);
                case PKIXPublicKeyDH PKIXPublicKeyDH:       return new PublicKeyDH(PKIXPublicKeyDH);
                case PKIXPublicKeyECDH PKIXPublicKeyECDH:   return new PublicKeyECDH(PKIXPublicKeyECDH);
                }
            return null;
            }

        /// <summary>
        /// Convert PKIX parameters to JSON structure.
        /// </summary>
        /// <param name="pkixKey">The PKIX key parameters</param>
        /// <returns>The JOSE key</returns>
        public static Key Factory(IPKIXPrivateKey pkixKey) {

            switch (pkixKey) {
                case PKIXPrivateKeyRSA privateKey:
                    return new PrivateKeyRSA(privateKey);
                case PKIXPrivateKeyDH privateKey:
                    return new PrivateKeyDH(privateKey);
                case PKIXPrivateKeyECDH privateKey:
                    return new PrivateKeyECDH(privateKey);
                }

            return null;
            }

        /// <summary>Create private key from Goedel.Cryptography.KeyPair.</summary>
        /// <param name="keyPair">Key pair to convert</param>
        /// <returns>JOSE private Key value</returns>
        public static Key FactoryPrivate (KeyPair keyPair) {
            var PKIX = keyPair?.PKIXPrivateKey;
            return Factory(PKIX);
            }

        /// <summary>Create public key from Goedel.Cryptography.KeyPair.</summary>
        /// <param name="keyPair">Key pair to convert</param>
        /// <returns>JOSE public Key value</returns>
        public static Key FactoryPublic (KeyPair keyPair) {
            var PKIX = keyPair?.PKIXPublicKey;
            return Factory(PKIX);
            }

        }

    public partial class KeyContainer {

        /// <summary>
        /// The Key data
        /// </summary>
        public Key Key => Key.FromJSON(new JSONReader (KeyData.ToUTF8()));

        string KeyText  => KeyData.ToUTF8(); 

        /// <summary>
        /// Default Constructor
        /// </summary>
        public KeyContainer () { }

        /// <summary>
        /// Construct a Key Container with the specified Key security level.
        /// </summary>
        /// <param name="key">The key to constrruct the container for.</param>
        /// <param name="keySecurity">The key security level.</param>
        public KeyContainer(Key key, KeySecurity keySecurity) :
                    this (key.ToJson(true), keySecurity){
            }


        /// <summary>
        /// Construct a Key Container with the specified Key security level.
        /// </summary>
        /// <param name="keyData">The key to constrruct the container for.</param>
        /// <param name="keySecurity">The key security level.</param>
        public KeyContainer (byte[] keyData, KeySecurity keySecurity) {
            Exportable = keySecurity.IsExportable();
            this.KeyData = keyData;
            }

        }

    /// <summary>Base class for JOSE key agreement result.</summary>
    public partial class KeyAgreement {

        /// <summary>
        /// Return the Goedel.Cryptography result.
        /// </summary>
        public virtual KeyAgreementResult KeyAgreementResult { get;}

        /// <summary>
        /// Obtain a Key agreement provider for the specified key agreement result.
        /// </summary>
        /// <param name="keyAgreementResult">The result to return a provider for.</param>
        /// <returns>The provider (if found).</returns>
        public static KeyAgreement Factory (KeyAgreementResult keyAgreementResult) {
            switch (keyAgreementResult) {
                case ResultDiffieHellman result: {
                    return new KeyAgreementDH(result);
                    }
                case ResultECDH result: {
                    return new KeyAgreementECDH(result);
                    }
                }
            return null;
            }
        }

    /// <summary>
    /// Base class for JOSE Diffie-Hellman key agreement result.
    /// </summary>
    public partial class KeyAgreementDH {

        /// <summary>
        /// Return the Goedel.Cryptography result.
        /// </summary>
        public override KeyAgreementResult KeyAgreementResult =>
              new ResultDiffieHellman() {
                  Agreement = Result.BigIntegerLittleEndian ()
                  };

        /// <summary>
        /// Default constructor
        /// </summary>
        public KeyAgreementDH () {
            }

        /// <summary>
        /// Constructor from the specified Goedel.Cryptography result.
        /// </summary>
        /// <param name="DiffieHellmanResult">The Goedel.Cryptography result.</param>
        public KeyAgreementDH(ResultDiffieHellman DiffieHellmanResult) => Result = DiffieHellmanResult.Agreement.ToByteArray();
        }

    /// <summary>
    /// Base class for JOSE Diffie-Hellman key agreement result.
    /// </summary>
    public partial class KeyAgreementECDH {

        /// <summary>
        /// Return the Goedel.Cryptography result.
        /// </summary>
        public override KeyAgreementResult KeyAgreementResult => throw new NYI();
              //new ResultECDH() {
              //    Agreement = Result.BigIntegerLittleEndian()
              //    };

        /// <summary>
        /// Default constructor
        /// </summary>
        public KeyAgreementECDH() {
            }

        /// <summary>
        /// Constructor from the specified Goedel.Cryptography result.
        /// </summary>
        /// <param name="result">The Goedel.Cryptography result.</param>
        public KeyAgreementECDH(ResultECDH result) => throw new NYI();
        //Result = result.Agreement.ToByteArray();
        }



    }
