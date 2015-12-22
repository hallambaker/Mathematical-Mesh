//Sample license text.
using System;
using System.Collections.Generic;
using Goedel.Registry;
using Goedel.Persistence;
using Goedel.LibCrypto;
using Goedel.LibCrypto.PKIX;

namespace Goedel.Mesh {
    public partial class MasterProfile : Profile {

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

            var OnlineSignatureKey = PublicKey.Generate(KeyType.POSK, SignatureAlgorithmID);
            OnlineSignatureKey.SignCertificate(Application.CA, MasterSignatureKey);

            OnlineSignatureKeys = new List<PublicKey>();
            OnlineSignatureKeys.Add(OnlineSignatureKey);

            var MasterEscrowKey = PublicKey.Generate(KeyType.PMEK, ExchangeAlgorithmID);
            MasterEscrowKey.SignCertificate(Application.DataEncryption, MasterSignatureKey);

            MasterEscrowKeys = new List<PublicKey>();
            MasterEscrowKeys.Add(MasterEscrowKey);

            Identifier = MasterSignatureKey.UDF;
            }


        }

    }
