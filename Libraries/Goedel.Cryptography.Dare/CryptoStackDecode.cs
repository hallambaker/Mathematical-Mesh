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
using System.Collections.Generic;

using Goedel.Utilities;

namespace Goedel.Cryptography.Dare {
    /// <summary>
    /// Cryptographic stack to decode an envelope.
    /// </summary>
    public partial class CryptoStackDecode : CryptoStack {

        /// <summary>
        /// The Keys to be used to sign the message. 
        /// </summary>
        public override List<CryptoKey> SignerKeys { get; }


        /// <summary>
        /// The base seed provided as a verbatim value or provided through a key exchange to be 
        /// used together with the salt data to derive the keys and initialization data for 
        /// cryptographic operations.
        /// </summary>
        public override byte[] BaseSeed => baseSeed;
        byte[] baseSeed;

        /// <summary>The authentication algorithm to use</summary>
        public override CryptoAlgorithmId DigestId { get; }

        /// <summary>The encryption algorithm to use</summary>
        public override CryptoAlgorithmId EncryptId { get; }

        ///<summary>The block size in bytes.</summary> 
        protected override int BlockSizeByte { get; }

        ///<summary>The key size in bits determined by the value of <see cref="EncryptId"/></summary> 
        public override int KeySize { get; }

        ///<summary>The block size in bits determined by the value of <see cref="EncryptId"/></summary> 
        public override int BlockSize { get; }

        /// <summary>
        /// Create a CryptoStack Instance to decode data with the specified cryptographic
        /// parameters.
        /// </summary>
        /// <param name="encryptID">The keyed cryptographic enhancement to be applied to the content.</param>
        /// <param name="digest">The digest algorithm to be applied to the message.</param>
        /// <param name="recipients">The recipient information</param>
        /// <param name="signatures">The message signatures.</param>
        /// <param name="keyCollection">The key collection to be used to resolve private keys.</param>
        /// <param name="decrypt">If true, prepare to decrypt the payload.</param>
        public CryptoStackDecode(
                CryptoAlgorithmId encryptID = CryptoAlgorithmId.NULL,
                CryptoAlgorithmId digest = CryptoAlgorithmId.NULL,
                List<DareRecipient> recipients = null,
                List<DareSignature> signatures = null,
                IKeyLocate keyCollection = null,
                bool decrypt = true) {

            EncryptId = encryptID;
            DigestId = digest;
            (KeySize, BlockSize) = encryptID.GetKeySize();

            keyCollection ??= Cryptography.KeyCollection.Default;

            if (recipients != null & decrypt) {
                baseSeed = keyCollection.Decrypt(recipients, encryptID);
                }

            signatures.Future(); // Build a list of the verified signatures??
            }


        }
    }