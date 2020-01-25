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

namespace Goedel.Cryptography {


    /// <summary>
    /// Extension methods to extract algorithm sub types
    /// </summary>
    public static class CryptoID {


        /// <summary>
        /// Return the MAC algorithm from a possibly composite ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>The digest algorithm</returns>
        static CryptoAlgorithmID ExtractMAC(this CryptoAlgorithmID ID) => (ID.Bulk()) switch
            {
                CryptoAlgorithmID.AES128HMAC => CryptoAlgorithmID.HMAC_SHA_2_256,
                CryptoAlgorithmID.AES256HMAC => CryptoAlgorithmID.HMAC_SHA_2_512,
                _ => ID.Bulk(),
                };

        /// <summary>
        /// Return the encryption algorithm from a possibly composite ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>The encryption algorithm</returns>
        static CryptoAlgorithmID ExtractEncryption(this CryptoAlgorithmID ID) => (ID.Bulk()) switch
            {
                CryptoAlgorithmID.AES128HMAC => CryptoAlgorithmID.AES128CBC,
                CryptoAlgorithmID.AES256HMAC => CryptoAlgorithmID.AES256CBC,
                _ => ID.Bulk(),
                };

        internal static object Type(CryptoAlgorithmID bulk, int v) => throw new NotImplementedException();


        /// <summary>
        /// Get the bulk algorithm
        /// </summary>
        /// <param name="ID">Composite identifier</param>
        /// <returns>The bulk component.</returns>
        public static CryptoAlgorithmID Bulk(this CryptoAlgorithmID ID) => ID < 0 ? ID : ID & CryptoAlgorithmID.BulkMask;

        /// <summary>
        /// Get the Meta algorithm
        /// </summary>
        /// <param name="ID">Composite identifier</param>
        /// <returns>The meta component.</returns>
        public static CryptoAlgorithmID Meta(this CryptoAlgorithmID ID) => ID < 0 ? ID : ID & CryptoAlgorithmID.MetaMask;

        /// <summary>
        /// Set algorithm defaults
        /// </summary>
        /// <param name="ID">The specified algorithm</param>
        /// <param name="BulkDefault">The default bulk algorithm to apply</param>
        /// <param name="MetaDefault">The default meta algorithm to apply</param>
        /// <returns>The defaulted algorithm</returns>
        public static CryptoAlgorithmID Default(
                    this CryptoAlgorithmID ID,
                    CryptoAlgorithmID BulkDefault = CryptoAlgorithmID.Default,
                    CryptoAlgorithmID MetaDefault = CryptoAlgorithmID.Default) {
            var Meta = ID.Meta();
            var Bulk = ID.Bulk();
            Meta = Meta == CryptoAlgorithmID.Default ? MetaDefault : Meta;
            Bulk = Bulk == CryptoAlgorithmID.Default ? BulkDefault : Bulk;
            return Meta | Bulk;
            }


        /// <summary>
        /// Set algorithm defaults for key exchange / public algorithm.
        /// </summary>
        /// <param name="ID">The specified algorithm</param>
        /// <param name="Default">The default to apply</param>
        /// <returns>The defaulted algorithm</returns>
        public static CryptoAlgorithmID DefaultMeta(
                    this CryptoAlgorithmID ID,
                    CryptoAlgorithmID Default = CryptoAlgorithmID.Default) {
            var DefaultedID = ID.Meta();
            DefaultedID = DefaultedID == CryptoAlgorithmID.Default ?
                Default.Meta() : DefaultedID;
            return DefaultedID;
            }

        /// <summary>
        /// Set algorithm defaults for bulk algorithm
        /// </summary>
        /// <param name="ID">The specified algorithm</param>
        /// <param name="Default">The default to apply</param>
        /// <returns>The defaulted algorithm</returns>
        public static CryptoAlgorithmID DefaultBulk(
                    this CryptoAlgorithmID ID,
                    CryptoAlgorithmID Default = CryptoAlgorithmID.Default) {
            var DefaultedID = ID.Bulk();
            DefaultedID = DefaultedID == CryptoAlgorithmID.Default ?
                    Default.Bulk() : DefaultedID;
            return DefaultedID;
            }


        /// <summary>
        /// Get the base part of an algorithm
        /// </summary>
        /// <param name="ID">The identifier to process.</param>
        /// <returns>The base part.</returns>
        public static CryptoAlgorithmID Base(this CryptoAlgorithmID ID) => ID < 0 ? ID : ID & CryptoAlgorithmID.BaseMask;

        /// <summary>
        /// Get the bulk algorithm
        /// </summary>
        /// <param name="ID">Composite identifier</param>
        /// <returns>The bulk component.</returns>
        public static CryptoAlgorithmID Digest(this CryptoAlgorithmID ID) {
            var Bulk = ID.Bulk();
            return Bulk >= (CryptoAlgorithmID.Digest) & (Bulk <= CryptoAlgorithmID.MaxDigest) ?
                Bulk : CryptoAlgorithmID.Default;
            }


        /// <summary>
        /// Get the bulk algorithm
        /// </summary>
        /// <param name="ID">Composite identifier</param>
        /// <returns>The bulk component.</returns>
        public static CryptoAlgorithmID MAC(this CryptoAlgorithmID ID) {
            var Bulk = ID.ExtractMAC();
            return Bulk >= (CryptoAlgorithmID.MAC) & (Bulk <= CryptoAlgorithmID.MaxMAC) ?
                Bulk : CryptoAlgorithmID.Default;
            }


        /// <summary>
        /// Get the bulk algorithm
        /// </summary>
        /// <param name="ID">Composite identifier</param>
        /// <returns>The bulk component.</returns>
        public static CryptoAlgorithmID Encryption(this CryptoAlgorithmID ID) {
            var Bulk = ID.ExtractEncryption();
            return Bulk >= (CryptoAlgorithmID.Encryption) & (Bulk <= CryptoAlgorithmID.MaxEncryption) ?
                Bulk : CryptoAlgorithmID.Default;
            }

        /// <summary>
        /// Get the bulk algorithm
        /// </summary>
        /// <param name="ID">Composite identifier</param>
        /// <returns>The bulk component.</returns>
        public static CryptoAlgorithmID Mode(this CryptoAlgorithmID ID) {
            var Encryption = ID.Encryption();
            return (Encryption > 0) ? Encryption & ((CryptoAlgorithmID)0x7) : Encryption;
            }


        /// <summary>
        /// Get the bulk algorithm
        /// </summary>
        /// <param name="ID">Composite identifier</param>
        /// <returns>The bulk component.</returns>
        public static CryptoAlgorithmID Signature(this CryptoAlgorithmID ID) {
            var Meta = ID.Meta();
            return Meta >= (CryptoAlgorithmID.Signature) & (Meta <= CryptoAlgorithmID.MaxSignature) ?
                Meta : CryptoAlgorithmID.Default;
            }

        /// <summary>
        /// Get the bulk algorithm
        /// </summary>
        /// <param name="ID">Composite identifier</param>
        /// <returns>The bulk component.</returns>
        public static CryptoAlgorithmID Exchange(this CryptoAlgorithmID ID) {
            var Meta = ID.Meta();
            return Meta >= (CryptoAlgorithmID.Exchange) & (Meta <= CryptoAlgorithmID.MaxExchange) ?
                Meta : CryptoAlgorithmID.Default;
            }

        /// <summary>
        /// Get the bulk algorithm
        /// </summary>
        /// <param name="ID">Composite identifier</param>
        /// <returns>The bulk component.</returns>
        public static CryptoAlgorithmID Wrap(this CryptoAlgorithmID ID) {
            var Meta = ID.Meta();
            return Meta >= (CryptoAlgorithmID.Wrap) & (Meta <= CryptoAlgorithmID.MaxWrap) ?
                Meta : CryptoAlgorithmID.Default;
            }

        ///// <summary>
        ///// Calculate the digest value of <paramref name="data"/> using the algorithm
        ///// specified by <paramref name="cryptoAlgorithmID"/>.
        ///// </summary>
        ///// <param name="data">The data to digest.</param>
        ///// <param name="cryptoAlgorithmID">The digest algorithm.</param>
        ///// <returns>The digest value.</returns>
        //public static byte[] GetDigest(this byte[] data,
        //        CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.SHA_2_512) {
        //    var hashProvider = cryptoAlgorithmID.CreateDigest();
        //    return hashProvider.ComputeHash(data);
        //    }



        }

    }
