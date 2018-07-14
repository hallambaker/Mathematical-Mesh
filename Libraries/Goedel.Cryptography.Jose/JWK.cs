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
using Goedel.Protocol;
using Goedel.Cryptography;
using Goedel.Cryptography.PKIX;


namespace Goedel.Cryptography.Jose {

    /// <summary>
    /// Represents a JOSE KeyData structure
    /// </summary>
    public partial class KeyData {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public KeyData () { }

        /// <summary>
        /// Build a KeyData object from a reference to a key. This may be a certificate,
        /// a certificate reference (URL and hash), a UDF value, etc.
        /// </summary>
        /// <param name="KeyHandle">The key handle</param>
        public KeyData(KeyHandle KeyHandle) => Kid = KeyHandle.UDF; // The Key identifier is always the UDF of the key.

        /// <summary>
        /// Builds a KeyData object from a key.
        /// </summary>
        /// <param name="CryptoKey">The input data</param>
        public KeyData(CryptoKey CryptoKey) {
            }


        /// <summary>
        /// Returns a key handle for the specified Key Data.
        /// </summary>
        public KeyHandle KeyHandle => GetKeyHandle();

        KeyHandle GetKeyHandle() => null;
        }

    }
