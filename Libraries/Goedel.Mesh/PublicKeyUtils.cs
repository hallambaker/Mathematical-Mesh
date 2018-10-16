using System;
using System.Collections.Generic;
using Goedel.Utilities;
using Goedel.Persistence;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Protocol;

namespace Goedel.Mesh {

    /// <summary>
    /// Extension class containing convenience routines for locating keys.
    /// </summary>
    public static class Extensions {

        /// <summary>
        /// Search a list of encrypted data blobs and return the first keypair that
        /// can be decrypted and the coresponding key
        /// </summary>
        /// <param name="JWEs">Keypairs to search</param>
        /// <param name="KeyPair">Matching keypair.</param>
        /// <param name="JoseWebEncryption">Matching encrypted data</param>
        /// <returns>True if found, otherwise false.</returns>
        public static bool GetKey (this List<JoseWebEncryption> JWEs,
                    out KeyPair KeyPair,
                    out JoseWebEncryption JoseWebEncryption) {
            foreach (var JWE in JWEs) {
                KeyPair = GetKey(JWE);
                if (KeyPair != null) {
                    JoseWebEncryption = JWE;
                    return true;
                    }
                }
            JoseWebEncryption = null;
            KeyPair = null;
            return false;
            }

        /// <summary>
        /// Attempt to find a key on the local machine that can decrypt the 
        /// encrypted data supplied.
        /// </summary>
        /// <param name="JWE">The encrypted data</param>
        /// <returns>The decryption key (if found)</returns>
        public static KeyPair GetKey (this JoseWebEncryption JWE) => throw new NYI();
        //{
        //foreach (var Recipient in JWE.Recipients) {
        //    var KeyPair = Cryptography.KeyPair.FindLocal(Recipient.Header.Kid);
        //    if (KeyPair != null) {
        //        return KeyPair;
        //        }
        //    }

        //return null;
        //}


        /// <summary>
        /// Search the local key store for keys matching a list of fingerprints
        /// and return the first key in the list.
        /// </summary>
        /// <param name="UDFs">list of key fingerprints</param>
        /// <returns>First match in the list or null if not found.</returns>
        public static KeyPair GetLocal(this List<string> UDFs) => throw new NYI();
            //{
            //foreach (var UDF in UDFs) {
            //    var KeyPair = Cryptography.KeyPair.FindLocal(UDF);
            //    if (KeyPair != null) {
            //        return KeyPair;
            //        }
            //    }
            //return null;
            //}



        }
    }
