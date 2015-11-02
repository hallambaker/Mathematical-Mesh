using System;
using System.Collections.Generic;
using Goedel.Protocol;
using Goedel.CryptoLibNG;

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
