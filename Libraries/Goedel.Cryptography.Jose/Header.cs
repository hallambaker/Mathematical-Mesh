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
using System.Text;
using Goedel.Protocol;
using Goedel.Cryptography;

namespace Goedel.Cryptography.Jose {


    public partial class Header {

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Header () { }

        /// <summary>
        /// Initialize the alg parameter to match the specified provider.
        /// </summary>
        /// <param name="Provider">The encryption provider</param>
        public Header(CryptoProviderEncryption Provider) {
            Alg = Provider.CryptoAlgorithmID.ToJoseID();
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
        /// <param name="SignatureProvider">The signature provider.</param>
        public SignatureHeader(CryptoProviderSignature SignatureProvider) {
            Kid = SignatureProvider.UDF;
            Alg = SignatureProvider.CryptoAlgorithmID.ToJoseID();

            }

        /// <summary>
        /// Initialize the alg and kid parameters to match the specified 
        /// signature provider.
        /// </summary>
        /// <param name="Signature">The signature to add.</param>
        public SignatureHeader(CryptoDataSignature Signature) {
            Kid = Signature.Meta.UDF;
            Alg = Signature.Meta.CryptoAlgorithmID.ToJoseID();

            }


        }
    
    }
