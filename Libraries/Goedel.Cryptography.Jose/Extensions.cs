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
namespace Goedel.Cryptography.Jose {

    /// <summary>Static class containing convenience functions</summary>
    public static class Extensions {

        /// <summary>
        /// Calculate the digest value of the contents of <paramref name="fileName"/> using the algorithm
        /// specified by <paramref name="algID"/>.
        /// </summary>
        /// <param name="fileName">The file containing the data to digest.</param>
        /// <param name="algID">The JOSE digest algorithm identifier.</param>
        /// <returns>The digest value.</returns>
        public static byte[] GetDigestOfFile(this string fileName, string algID) =>
             CryptoStreamFromID.GetDigestOfFile(fileName, algID.ToCryptoAlgorithmID(CryptoAlgorithmId.SHA_2_512));

        }
    }
