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
using Goedel.Protocol;
using Goedel.LibCrypto;

namespace Goedel.Cryptography.Jose {

    ///// <summary>
    ///// Represents a JWE data structure.
    ///// </summary>
    //public partial class JoseWebEncryption {



    //    Header ProtectedHeader = null;
    //    Header UnprotectedHeader = null;
    //    CryptoData EncryptedData;
    //    CryptoProviderEncryption BulkEncryptor;

    //    /// <summary>
    //    /// Create a JOSE encryption provider for the specified list of 
    //    /// recipients.
    //    /// </summary>
    //    public JoseWebEncryption(List<KeyHandle> KeyHandles, byte[] Plaintext, CryptoSuite CryptoSuite) {

            
    //        Create(KeyHandles, Plaintext, CryptoSuite);

    //        }

    //    void Create(List <KeyHandle> KeyHandles, byte[] Plaintext, CryptoSuite CryptoSuite) {
    //        ProtectedHeader = new Header();

    //        // Get the bulk provider (this will create the IV and Key)
    //        BulkEncryptor = CryptoCatalog.Default.GetEncryption(CryptoSuite.Encryption);
    //        ProtectedHeader.enc = CryptoSuite.JOSE;

    //        // Create a CryptoData structure containig the plaintext, Key and IV
    //        var PlaintextData = new CryptoData(CryptoAlgorithmID.NULL, null, null,
    //            Plaintext, BulkEncryptor.Key, BulkEncryptor.IV);

    //        foreach (var KeyHandle in KeyHandles) {
    //            AddRecipient(KeyHandle);
    //            }

    //        // Encrypt the bulk data to the encryption blob
    //        EncryptedData = BulkEncryptor.Encrypt(Plaintext);

    //        CipherText = EncryptedData.Data;
    //        IV = EncryptedData.IV;
    //        JTag = EncryptedData.Integrity;

    //        Package();
    //        }

    //    //Only key identification method currently supported is 
    //    //UDF key identifier.
    //    void AddRecipient(KeyHandle KeyHandle) {
    //        var Recipient = new Recipient ();
    //        Recipient.Header = new Header ();
    //        Recipient.Header.kid = KeyHandle.UDF;
    //        }

    //    void Package() {
    //        if (ProtectedHeader != null) {
    //            Protected = ProtectedHeader.ToJson();
    //            }
    //        if (UnprotectedHeader != null) {
    //            Unprotected = UnprotectedHeader.ToJson();
    //            }
    //        }

    //    }

    //public partial class Header {

    //    public Header(KeyHandle KeyHandle) {


    //        }
    //    }


    }
