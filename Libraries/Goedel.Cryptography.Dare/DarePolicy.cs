using System;
using System.Collections.Generic;
using System.Text;

using Goedel.Cryptography;
using Goedel.Utilities;

namespace Goedel.Cryptography.Dare {


    public partial class DarePolicy {

        public bool Encrypt => EncryptKeys != null;

        public IKeyLocate KeyLocate { get; set; }





        public CryptoParameters GetCryptoParameters() =>
                CryptoParameters ?? MakeCryptoParameters();

        CryptoParameters CryptoParameters { get; set; }

        public DarePolicy() {
            }


        public DarePolicy(IKeyLocate keyLocate,
                List<string> signers=null, 
                List<string> recipients = null,
                CryptoAlgorithmId encrypt=CryptoAlgorithmId.NULL,
                CryptoAlgorithmId digest = CryptoAlgorithmId.NULL) {
            
            KeyLocate = keyLocate;

            if (recipients != null) {
                EncryptKeys = new List<Jose.Key>();

                foreach (var recipient in recipients) {
                    keyLocate.TryFindKeyEncryption(recipient, out var keypair).AssertTrue(KeyNotFound.Throw);

                    EncryptKeys.Add(Jose.Key.FactoryPublic(keypair as KeyPair));
                    }
                }


            }






        public DarePolicy(CryptoParameters cryptoParameters) {
            CryptoParameters = cryptoParameters;
            }

        CryptoParameters MakeCryptoParameters() {

            throw new NYI();

            }



        }

    }
