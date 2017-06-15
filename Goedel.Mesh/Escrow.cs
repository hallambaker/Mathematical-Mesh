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
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Utilities;
using Goedel.Protocol;

namespace Goedel.Mesh {
    public partial class OfflineEscrowEntry {
        private KeyShare[] _KeyShares;
        /// <summary>
        /// Default Constructor
        /// </summary>
        public OfflineEscrowEntry () { }

        /// <summary>
        /// Creates an offline escrow entry for the master keys in the profile.
        /// </summary>
        /// <param name="Profile">The profile to create offline escrow entries for.</param>
        /// <param name="Shares">The total number of key shares to be created.</param>
        /// <param name="Quorum">The number of key shares required to recover the keys.</param>
        /// <returns></returns>

        public OfflineEscrowEntry(PersonalProfile Profile, int Shares, int Quorum) {
            var Master = Profile.MasterProfile;

            var EscrowedKeySet = new EscrowedKeySet() {
                MasterEscrowKeys = new List<Key>()
                };

            EscrowedKeySet.MasterSignatureKey = (GetEscrow(
                Profile.MasterProfile.MasterSignatureKey.UDF));

            foreach (var Escrow in Profile.MasterProfile.MasterEscrowKeys) {
                EscrowedKeySet.MasterEscrowKeys.Add(GetEscrow (Escrow.UDF));
                }

            var Plaintext = EscrowedKeySet.GetBytes(true);

            var Secret = new Secret(128);
            _KeyShares = Secret.Split(Shares, Quorum);

            var share1 = KeyShares[0].Text;
            var share2 = KeyShares[1].Text;

            // Get recovery data
            string[] TestShares = { share1, share2 };
            var RecoveryKey = new Secret(TestShares);

            EncryptedData = new JoseWebEncryption (Plaintext, Secret.Key, 
                        EncryptID:CryptoAlgorithmID.AES256CBC);

            Identifier = UDF.ToString (UDF.FromEscrowed(Secret.Key, 150));
            }

        /// <summary>
        /// Recover the encrypted profile.
        /// </summary>
        /// <param name="Secret"></param>
        /// <returns></returns>
        public EscrowedKeySet Decrypt(Secret Secret) {

            var Decrypt = EncryptedData.Decrypt(Secret.Key);
            // Decrypt here

            var Plaintext = Decrypt.ToUTF8();

            var Result = EscrowedKeySet.FromJSON(new JSONReader(Decrypt));


            return Result;
            }


        Key GetEscrow (string UDF) {
            var KP = KeyPair.FindLocal(UDF);
            return Key.GetPrivate(KP);
            }

        /// <summary>
        /// The associated key shares for reconstructing the key.
        /// </summary>
        public KeyShare[] KeyShares {
            get => _KeyShares;
            }



        }
    }
