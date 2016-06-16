﻿//   Copyright © 2015 by Comodo Group Inc.
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

namespace Goedel.Cryptography {

    /// <summary>
    /// Describes the mechanism that created a cryptographic output.
    /// </summary>
    public enum CryptoOperation {
        /// <summary>
        /// Unknown.
        /// </summary>
        Unknown,

        /// <summary>
        /// Data is plaintext source.
        /// </summary>
        Plaintext,

        /// <summary>
        /// Cryptographic Digest.
        /// </summary>
        Digest,

        /// <summary>
        /// Message Authentication Code,
        /// </summary>
        Authenticate,

        /// <summary>
        /// Public key signature.
        /// </summary>
        Sign,

        /// <summary>
        /// Signature or Authentication Code verification.
        /// </summary>
        Verify,

        /// <summary>
        /// Encryption.
        /// </summary>
        Encrypt,

        /// <summary>
        /// Authenticated Encryption.
        /// </summary>
        AuthenticatedEncrypt,

        /// <summary>
        /// Decryption or decryption with authentication.
        /// </summary>
        Decrypt,

        /// <summary>
        /// Symmetric key wrap.
        /// </summary>
        WrapKey,

        /// <summary>
        /// Symmetric key unwrap.
        /// </summary>
        UnwrapKey,

        /// <summary>
        /// Derive key.
        /// </summary>
        DeriveKey,

        /// <summary>
        /// Derive bits not to be used as a key
        /// </summary>
        DeriveBits

        }
    
    
    
    /// <summary>
    /// Container for data generated by a cryptographic operation
    /// </summary>
    public struct CryptoData {
        CryptoAlgorithmID _Identifier;
        CryptoOperation _CryptoOperation;

        string _OID;
        byte[] _Integrity;
        byte[] _Data;
        byte[] _Key;
        byte[] _IV;

        /// <summary>
        /// Operation that created this data.
        /// </summary>
        public CryptoOperation CryptoOperation {
            get { return _CryptoOperation; }
            set { _CryptoOperation = value; }
            }


        /// <summary>
        /// Symmetric Key
        /// </summary>
        public byte[] Key {
            get { return _Key; }
            set { _Key = value; }
            }

        /// <summary>
        /// Symmetric Key IV
        /// </summary>
        public byte[] IV {
            get { return _IV; }
            set { _IV = value; }
            }

        /// <summary>
        /// Catalog entry
        /// </summary>
        public CryptoAlgorithmID Identifier {
            get { return _Identifier; }
            }

        /// <summary>
        /// Returned integrity code.
        /// </summary>
        public byte[] Integrity {
            get { return _Integrity; }
            }

        /// <summary>
        /// Returned Content
        /// </summary>
        public byte[] Data {
            get { return _Data; }
            }

        /// <summary>
        /// OID of algorithm that produced the result.
        /// </summary>
        public string OID {
            get { return _OID; }
            }

        /// <summary>
        /// Create and populate a result for a digest or MAC algorithm.
        /// </summary>
        /// <param name="Identifier"></param>
        /// <param name="OID"></param>
        /// <param name="Value"></param>
        public CryptoData(CryptoAlgorithmID Identifier, string OID, byte[] Value) {
            _Identifier = Identifier;
            _Integrity = Value;
            _Data = null;
            _Key = null;
            _IV = null;
            _OID = OID;
            _CryptoOperation = CryptoOperation.Unknown;
            }

        /// <summary>
        /// Create and populate a result for an encryption with authentication algorithm.
        /// </summary>
        /// <param name="Identifier"></param>
        /// <param name="OID"></param>
        /// <param name="Value"></param>
        /// <param name="Data"></param>
        public CryptoData(CryptoAlgorithmID Identifier, string OID,
                        byte[] Value, byte[] Data) {
            _Identifier = Identifier;
            _Integrity = Value;
            _Data = Data;
            _OID = OID;
            _Key = null;
            _IV = null;
            _CryptoOperation = CryptoOperation.Unknown;
            }

        /// <summary>
        /// Create and populate a result for an encryption with authentication algorithm.
        /// </summary>
        /// <param name="Identifier"></param>
        /// <param name="OID"></param>
        /// <param name="Integrity"></param>
        /// <param name="Data"></param>
        /// <param name="Key">Key data</param>
        /// <param name="IV">Initialization Vector</param>
        public CryptoData(CryptoAlgorithmID Identifier, string OID,
                        byte[] Integrity, byte[] Data, byte [] Key, byte []IV) {
            _Identifier = Identifier;
            _Integrity = Integrity;
            _Data = Data;
            _OID = OID;
            _Key = Key;
            _IV = IV;
            _CryptoOperation = CryptoOperation.Unknown;
            }

        }

    }
