using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Protocol;
using Goedel.CryptoLibNG;

namespace Goedel.Cryptography.Jose {


    public partial class Header {

        /// <summary>
        /// Initialize the alg parameter to match the specified provider.
        /// </summary>
        /// <param name="Provider"></param>
        public Header(CryptoProviderEncryption Provider) {
            alg = Provider.JSONName;
            }
        }

    /// <summary>
    /// Signature header object
    /// </summary>
    public class SignatureHeader : Header {

        /// <summary>
        /// Initialize the alg and kid parameters to match the specified 
        /// signature provider.
        /// </summary>
        /// <param name="SignatureProvider"></param>
        public SignatureHeader(CryptoProviderSignature SignatureProvider) {
            kid = SignatureProvider.UDF;
            alg = SignatureProvider.JSONName;

            }
        }
    
    }
