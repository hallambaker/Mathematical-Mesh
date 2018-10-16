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
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.PKIX;

namespace Goedel.Mesh {
    public partial class MasterProfile : Profile {

        /// <summary>
        /// The Signed Master Profile.
        /// </summary>
        public SignedMasterProfile SignedMasterProfile { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MasterProfile () { }

        /// <summary>
        /// Create a MasterProfile using the default signature and exchange
        /// algorithms.
        /// </summary>
        /// <param name="CryptoCatalog">Catalog to take the default algorithms from.</param>
        public MasterProfile(CryptoCatalog CryptoCatalog)
            : this(CryptoCatalog.AlgorithmSignature,
                   CryptoCatalog.AlgorithmExchange) {
            }

        /// <summary>
        /// Create a MasterProfile using the specified signature and exchange
        /// algorithms.
        /// </summary>
        /// <param name="SignatureAlgorithmID">The signature algorithm to be used for
        /// the master signature key and the online signature key.</param>
        /// <param name="ExchangeAlgorithmID">The exchange a</param>
        public MasterProfile(CryptoAlgorithmID SignatureAlgorithmID,
                        CryptoAlgorithmID ExchangeAlgorithmID) {

            MasterSignatureKey = PublicKey.Generate(KeyType.PMSK, SignatureAlgorithmID);
            MasterSignatureKey.SelfSignCertificate(Application.PersonalMaster);

            var MasterEscrowKey = PublicKey.Generate(KeyType.PMEK, ExchangeAlgorithmID);
            MasterEscrowKey.SignCertificate(Application.DataEncryption, MasterSignatureKey);
            MasterEscrowKeys = new List<PublicKey>() { MasterEscrowKey };

            var OnlineSignatureKey = PublicKey.Generate(KeyType.POSK, SignatureAlgorithmID);
            OnlineSignatureKey.SignCertificate(Application.CA, MasterSignatureKey);
            OnlineSignatureKeys = new List<PublicKey>() { OnlineSignatureKey };

            Identifier = MasterSignatureKey.UDF;

            SignedMasterProfile = new SignedMasterProfile(this);
            }

        /// <summary>
        /// Rereate a MasterProfile from the specified escrow data
        /// </summary>
        /// <param name="EscrowedKeySet">Escrowed key set to create from.</param>
        public MasterProfile(EscrowedKeySet EscrowedKeySet) {
            var MasterSignatureKeyPair =  EscrowedKeySet.MasterSignatureKey.GetKeyPair(KeyStorage.Bound);
            MasterSignatureKey = new PublicKey(MasterSignatureKeyPair);
            MasterSignatureKey.SelfSignCertificate(Application.PersonalMaster);

            MasterEscrowKeys = new List<PublicKey>();
            foreach (var EscrowKeyEntry in EscrowedKeySet.MasterEscrowKeys) {
                var EscrowKeyPair = EscrowKeyEntry.GetKeyPair(KeyStorage.Bound);
                var EscrowKey = new PublicKey(EscrowKeyPair);
                EscrowKey.SignCertificate(Application.DataEncryption, MasterSignatureKey);
                MasterEscrowKeys.Add(EscrowKey);
                }

            var OnlineSignatureKey = PublicKey.Generate(KeyType.POSK, MasterSignatureKeyPair.CryptoAlgorithmID);
            OnlineSignatureKey.SignCertificate(Application.CA, MasterSignatureKey);
            OnlineSignatureKeys = new List<PublicKey>() { OnlineSignatureKey };

            Identifier = MasterSignatureKey.UDF;
            SignedMasterProfile = new SignedMasterProfile(this);
            }


        /// <summary>
        /// Test to see if the key is an administration key authorized by this master profile.
        /// </summary>
        /// <param name="KeyId">The Key Identifier.</param>
        /// <returns>The KeyID.</returns>
        public KeyPair AdministrationKeyPair (string KeyId) {
            foreach (var AdminKey in OnlineSignatureKeys) {
                if (AdminKey.UDF == KeyId) {
                    return AdminKey.KeyPair;
                    }
                }
            return null;
            }

        /// <summary>
        /// Get the administration key (if available).
        /// </summary>
        public KeyPair AdministrationKey {
            get {
                _AdministrationKey = _AdministrationKey ?? GetAdministrationKey();
                return _AdministrationKey;
                }
            }
        KeyPair _AdministrationKey;

        /// <summary>
        /// Get the administration key (if available).
        /// </summary>
        /// <returns>The administration key.</returns>
        public KeyPair GetAdministrationKey() => throw new NYI();
            //{
            //foreach (var OnlineKey in OnlineSignatureKeys) => throw new NYI();
            ////    {
            //    var Key = KeyPair.FindLocal(OnlineKey.UDF);
            //    if (Key != null) {
            //        return Key;
            //        }
            //    }
            //return null;
            //}


        }

    }
