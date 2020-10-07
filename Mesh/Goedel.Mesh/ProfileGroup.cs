//  Copyright © 2020 Threshold Secrets llc
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

using Goedel.Cryptography;
using Goedel.Utilities;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;

namespace Goedel.Mesh {




    public partial class ProfileGroup {

        /// <summary>
        /// Blank constructor for use by deserializers.
        /// </summary>
        public ProfileGroup() {
            }

        /// <summary>
        /// Construct a Profile Host instance  from a <see cref="PrivateKeyUDF"/>
        /// </summary>
        /// <param name="secretSeed">The secret seed value.</param>
        public ProfileGroup(
                    PrivateKeyUDF secretSeed) : base(secretSeed) {
            }


        /// <summary>
        /// Generate profile specific keys.
        /// </summary>
        protected override void Generate() {
            base.Generate();
            AccountEncryption = SecretSeed.GenerateContributionKeyData(
                    MeshKeyType, MeshActor, MeshKeyOperation.Encrypt);
            }

        /// <summary>
        /// Construct a new ProfileDevice instance from a <see cref="PrivateKeyUDF"/>
        /// seed.
        /// </summary>
        /// <param name="secretSeed">The secret seed value.</param>
        /// <param name="algorithmEncrypt">The encryption algorithm.</param>
        /// <param name="algorithmSign">The authentication algorithm</param>
        /// <param name="algorithmAuthenticate">The signature algorithm</param>
        /// <param name="bits">The size of key to generate in bits/</param>
        /// <returns>The created profile.</returns>
        public static ProfileGroup Generate(
                    CryptoAlgorithmId algorithmEncrypt = CryptoAlgorithmId.Default,
                    CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default,
                    CryptoAlgorithmId algorithmAuthenticate = CryptoAlgorithmId.Default,
                    int bits = 256,
                    PrivateKeyUDF secretSeed = null) {
            secretSeed ??= new PrivateKeyUDF(
                UdfAlgorithmIdentifier.MeshProfileAccount, null, algorithmEncrypt,
                algorithmSign, algorithmAuthenticate, bits: bits);
            return new ProfileGroup(secretSeed);
            }



        }

    }
