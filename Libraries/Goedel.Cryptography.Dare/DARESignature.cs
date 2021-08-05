#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
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
#endregion
using Goedel.Cryptography.Jose;

namespace Goedel.Cryptography.Dare {
    public partial class DareSignature {

        /// <summary>
        /// Default constructor for use in deserialization.
        /// </summary>
        public DareSignature() {
            }

        /// <summary>
        /// Sign the digest value <paramref name="DigestValue"/> with 
        /// <paramref name="signerKey"/> and create a DARESignature
        /// instance with the resulting values.
        /// </summary>
        /// <param name="signerKey">The signature key.</param>
        /// <param name="DigestValue">The digest value.</param>
        /// <param name="digestId">The digest algorithm used to calculate 
        /// <paramref name="DigestValue"/>.</param>
        /// <param name="keyDerive">Key derivation function used to calculate a signature witness 
        /// value (if required).</param>
        public DareSignature(CryptoKey signerKey, byte[] DigestValue,
                    CryptoAlgorithmId digestId, KeyDerive keyDerive = null) {

            SignatureValue = signerKey.SignHash(DigestValue, digestId);
            KeyIdentifier = signerKey.KeyIdentifier;
            Alg = signerKey.SignatureAlgorithmID(digestId).ToJoseID();

            if (keyDerive != null) {
                WitnessValue = keyDerive.Derive(SignatureValue);
                }


            }
        }

    }
