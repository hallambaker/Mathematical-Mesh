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
using Goedel.Registry;
using Goedel.Persistence;
using Goedel.LibCrypto;
using Goedel.Cryptography.Jose;
using Goedel.Debug;

namespace Goedel.Mesh {
    public partial class OfflineEscrowEntry {
        private KeyShare[] _KeyShares;


        /// <summary>
        /// Creates an offline escrow entry for the master keys in the profile.
        /// </summary>
        /// <param name="Profile">The profile to create offline escrow entries for.</param>
        /// <param name="Shares">The total number of key shares to be created.</param>
        /// <param name="Quorum">The number of key shares required to recover the keys.</param>
        /// <returns></returns>

        public OfflineEscrowEntry(PersonalProfile Profile, int Shares, int Quorum) {
            var Master = Profile.PersonalMasterProfile;

            var EscrowedKeySet = new EscrowedKeySet();
            EscrowedKeySet.PrivateKeys = new List<Key>();

            EscrowedKeySet.PrivateKeys.Add(GetEscrow(
                Profile.PersonalMasterProfile.MasterSignatureKey.UDF));

            foreach (var Escrow in Profile.PersonalMasterProfile.MasterEscrowKeys) {
                EscrowedKeySet.PrivateKeys.Add(GetEscrow (Escrow.UDF));
                }




            var Encryptor = CryptoCatalog.Default.GetEncryption(
                            CryptoAlgorithmID.AES128CBC);

            var Secret = new Secret(Encryptor.Size);
            _KeyShares = Secret.Split(Shares, Quorum);

            //Trace.WriteHex("MasterKey", Secret.Key);
            //foreach (var share in _KeyShares) {
            //    Trace.WriteHex("Share", share.Key);
            //    }

            Encryptor.Key = Secret.Key;
            EncryptedData = new JoseWebEncryption (EscrowedKeySet.GetBytes(), Encryptor);


            Identifier = UDF.ToString (UDF.FromEscrowed(Secret.Key, 150));
            }


        Key GetEscrow (string UDF) {
            var KP = KeyPair.FindLocal(UDF);
            return Key.GetPrivate(KP);
            }

        /// <summary>
        /// The associated key shares for reconstructing the key.
        /// </summary>
        public KeyShare[] KeyShares {
            get {
                return _KeyShares;
                }
            }
        }
    }
