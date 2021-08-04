#region // Copyright
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

using Goedel.Cryptography.Jose;

namespace Goedel.Cryptography.Dare {
    /// <summary>
    /// Cryptographic stack to encode an envelope.
    /// </summary>
    public partial class CryptoStackEncode : CryptoStack {
        CryptoParameters CryptoParameters { get; }

        /// <summary>
        /// The Keys to be used to sign the message. 
        /// </summary>
        public override List<CryptoKey> SignerKeys => CryptoParameters.SignerKeys;

        /// <summary>
        /// The base seed provided as a verbatim value or provided through a key exchange to be 
        /// used together with the salt data to derive the keys and initialization data for 
        /// cryptographic operations.
        /// </summary>
        public override byte[] BaseSeed => CryptoParameters.BaseSeed;


        /// <summary>The authentication algorithm to use</summary>
        public override CryptoAlgorithmId DigestId => CryptoParameters.DigestId;


        /// <summary>The encryption algorithm to use</summary>
        public override CryptoAlgorithmId EncryptId => CryptoParameters.EncryptId;

        ///<summary>The block size in bytes.</summary> 
        protected override int BlockSizeByte => CryptoParameters.BlockSizeByte;


        ///<summary>The key size in bits determined by the value of <see cref="EncryptId"/></summary> 
        public override int KeySize => CryptoParameters.KeySize;

        ///<summary>The block size in bits determined by the value of <see cref="EncryptId"/></summary> 
        public override int BlockSize => CryptoParameters.BlockSize;

        /// <summary>
        /// Create a CryptoStack instance to encode data with the specified cryptographic
        /// parameters.
        /// </summary>
        /// <param name="cryptoParameters">The cryptographic parameters to create the stack from.</param>
        /// <param name="header">Header to write the key exchange information to</param>
        /// <param name="cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
        /// <param name="dataSequences">Data sequences to be converted to an EDS and presented 
        ///     as an EDSS header entry.</param>
        public CryptoStackEncode(
                CryptoParameters cryptoParameters,
                DareHeader header,
                byte[] cloaked = null,
                List<byte[]> dataSequences = null) {

            CryptoParameters = cryptoParameters;

            header.CryptoStack = this;

            long saltValue = 0;
            if (cryptoParameters.Encrypt) {
                header.EncryptionAlgorithm = EncryptId.ToJoseID();

                Salt = Platform.GetRandomBits(128);
                header.Salt = Salt;
                header.KeyIdentifier = GetKeyIdentifier();

                if (cryptoParameters is CryptoParametersSequence cryptoParametersContainer) {
                    if (cryptoParametersContainer.ReuseKeyExchange(header.Index, out var keyExchange)) {
                        header.SequenceInfo.ExchangePosition = keyExchange;
                        }
                    else {
                        cryptoParameters.SetKeyExchange(header);
                        }
                    }
                else {
                    cryptoParameters.SetKeyExchange(header);
                    }

                if (cloaked != null) {
                    header.Cloaked = Encode(cloaked, MakeSalt(saltValue++));
                    }

                }
            if (dataSequences != null) {
                header.EDSS = new List<byte[]>();
                foreach (var DataSequence in dataSequences) {
                    header.EDSS.Add(Encode(DataSequence, MakeSalt(saltValue++)));
                    }
                }
            if (DigestId != CryptoAlgorithmId.NULL) {
                header.DigestAlgorithm = DigestId.ToJoseID();
                }
            }


        }
    }