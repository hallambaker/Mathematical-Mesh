using System;
using System.Collections.Generic;
using System.Text;

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

        public DarePolicy(CryptoParameters cryptoParameters) {
            CryptoParameters = cryptoParameters;
            }

        CryptoParameters MakeCryptoParameters() {

            throw new NYI();

            }



        }

    }
