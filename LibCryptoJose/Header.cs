using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Protocol;
using Goedel.CryptoLibNG;

namespace Goedel.Cryptography.Jose {
    public partial class Header {

        public Header(CryptoProviderEncryption Provider) {
            alg = Provider.JSONName;
            }
        }


    public class SignatureHeader : Header {
        public SignatureHeader(CryptoProviderSignature SignatureProvider) {
            kid = SignatureProvider.UDF;
            alg = SignatureProvider.JSONName;

            }
        }
    
    }
