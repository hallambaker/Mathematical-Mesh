using System;
using System.Collections.Generic;
using System.Text;

namespace Goedel.Cryptography.Dare {
    public partial class DARESignature {

        public DARESignature() {
            }


        public DARESignature(KeyPair SignerKey, byte[] DigestValue,
                    CryptoAlgorithmID DigestId) {
            SignatureValue = SignerKey.SignHash(DigestValue, DigestId);
            }
        }


    public partial class DARESigner {

        public DARESigner() {
            }


        public DARESigner(KeyPair SignerKey, CryptoAlgorithmID DigestId) {

            var Alg = SignerKey.SignatureAlgorithmID(DigestId);

            }
        }


    }
