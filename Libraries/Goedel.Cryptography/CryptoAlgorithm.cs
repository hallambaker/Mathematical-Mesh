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
using System.Text;

using Goedel.Utilities;

namespace Goedel.Cryptography {

    /// <summary>
    /// Factory method for creating crypto providers
    /// </summary>
    /// <param name="KeySize">Key size. If zero, the default key size for the
    /// algorithm is used.</param>
    /// <param name="Bulk">Bulk cipher, if required.</param>
    /// 
    /// <returns>The cryptographic provider created.</returns>
    public delegate CryptoProvider CryptoProviderFactoryDelegate(
                int KeySize = 0,
                CryptoAlgorithmId Bulk = CryptoAlgorithmId.Default);


    ///// <summary>
    ///// Factory method for creating key pairs.
    ///// </summary>
    ///// <param name="KeySize">The key </param>
    ///// <param name="CryptoAlgorithmID"></param>
    ///// <returns></returns>
    //public delegate KeyPair KeyPairFactoryDelegate(
    //            KeySecurity KeySecurity = KeySecurity.Exportable, int KeySize = 0,
    //            bool Signature = true, bool Exhange = true,
    //            CryptoAlgorithmID CryptoAlgorithmID= CryptoAlgorithmID.NULL);


    /// <summary>
    /// A cryptographic algorithm.
    /// </summary>
    public class CryptoAlgorithm {

        /// <summary>
        /// The enumerated cryptographic algorithm identifier.
        /// </summary>
        public CryptoAlgorithmId CryptoAlgorithmID { get; }

        /// <summary>
        /// .NET Framework name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Return the type of algorithm.
        /// </summary>
        public CryptoAlgorithmClasses AlgorithmClass { get; set; }

        /// <summary>
        /// ASN.1 Object Identifier
        /// </summary>
        public string OID { get; }

        /// <summary>Default algorithm key  or output size.</summary>
        public int KeySize { get; }


        /// <summary>Factory method to create providers</summary>
        public CryptoProviderFactoryDelegate CryptoProviderFactory { get; }

        ///// <summary>Factory method to create keypairs</summary>
        //public KeyPairFactoryDelegate KeyPairFactory { get; }

        /// <summary>
        /// Create an instance with the specified property values.
        /// </summary>
        /// <param name="CryptoAlgorithmID">CryptoAlgorithmID Identifier.</param>
        /// <param name="AlgorithmClass">Algorithm type.</param>
        /// <param name="CryptoProviderFactory">Delegate returning the default crypto provider.</param>
        /// <param name="KeySize">Default algorithm key size.</param>
        public CryptoAlgorithm(
                    CryptoAlgorithmId CryptoAlgorithmID,
            CryptoAlgorithmClasses AlgorithmClass,
            CryptoProviderFactoryDelegate CryptoProviderFactory,
            int KeySize = 0) {
            this.CryptoAlgorithmID = CryptoAlgorithmID;
            this.KeySize = KeySize;
            this.AlgorithmClass = AlgorithmClass;
            this.CryptoProviderFactory = CryptoProviderFactory;
            //this.KeyPairFactory = KeyPairFactory;
            }

        /// <summary>
        /// Return an encryption provider.
        /// </summary>
        /// <param name="KeySize">Key size. If zero, the default key size for the
        /// algorithm is used.</param>
        /// <returns>An encryption provider.</returns>
        public CryptoProviderEncryption CryptoProviderEncryption(int KeySize = 0) {
            KeySize = KeySize == 0 ? this.KeySize : KeySize;

            Assert.AssertTrue(AlgorithmClass == CryptoAlgorithmClasses.Encryption,
                    CryptographicException.Throw);
            return CryptoProviderFactory(KeySize, CryptoAlgorithmId.NULL) as
                CryptoProviderEncryption;
            }

        /// <summary>
        /// Return an authentication provider.
        /// </summary>
        /// <param name="KeySize">Key size. If zero, the default key size for the
        /// algorithm is used.</param>
        /// <returns>An authentication provider.</returns>
        public CryptoProviderAuthentication CryptoProviderAuthentication(int KeySize = 0) {
            KeySize = KeySize == 0 ? this.KeySize : KeySize;
            Assert.AssertTrue(AlgorithmClass == CryptoAlgorithmClasses.MAC,
                    CryptographicException.Throw);
            return CryptoProviderFactory(KeySize, CryptoAlgorithmId.NULL) as
                CryptoProviderAuthentication;
            }

        /// <summary>
        /// Return an authentication provider.
        /// </summary>
        /// <param name="OutputSize">Digest algorithm output size</param>
        /// <returns>An authentication provider.</returns>
        public CryptoProviderDigest CryptoProviderDigest(int OutputSize = 0) {
            OutputSize = OutputSize == 0 ? this.KeySize : OutputSize;
            Assert.AssertTrue(AlgorithmClass == CryptoAlgorithmClasses.Digest,
                    CryptographicException.Throw);
            return CryptoProviderFactory(0, CryptoAlgorithmId.NULL) as
                CryptoProviderDigest;
            }


        /// <summary>
        /// Convenience function, create bulk provider and apply to data.
        /// </summary>
        /// <param name="Buffer">Data to apply digest to.</param>
        /// /// <param name="Key">The key to apply</param>
        /// <returns>Result of digest operation.</returns>
        public byte[] Process(byte[] Buffer, byte[] Key = null) {
            Assert.AssertTrue(AlgorithmClass == CryptoAlgorithmClasses.Digest,
                    CryptographicException.Throw);
            var Provider = CryptoProviderFactory(0, CryptoAlgorithmId.NULL) as CryptoProviderDigest;
            Assert.AssertNotNull(Provider, CryptographicException.Throw);
            var Result = Provider.Process(Buffer, Key);
            return Result.Integrity;
            }



        /// <summary>
        /// Convenience function, create bulk provider and apply to data.
        /// </summary>
        /// <param name="Text">Text to apply digest to.</param>
        /// <param name="Key">The key to apply</param>
        /// <returns>Result of digest operation.</returns>
        public byte[] Process(string Text, byte[] Key = null) => Process(Encoding.UTF8.GetBytes(Text), Key);
        }

    }
