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
using System.Security.Cryptography;
using Goedel.Cryptography;
using Goedel.ASN1;

namespace Goedel.Cryptography.PKIX {


    public partial class SubjectPublicKeyInfo : Goedel.ASN1.Root {


        /// <summary>
        /// Construct from algorithm identifier and key data.
        /// </summary>
        /// <param name="OID">Algorithm identifier.</param>
        /// <param name="KeyData">Key Data.</param>

        public SubjectPublicKeyInfo(string OID, byte[] KeyData) {
            this.Algorithm = new AlgorithmIdentifier(OID);
            this.SubjectPublicKey = KeyData;

            }
        }


    public partial class AlgorithmIdentifier : Goedel.ASN1.Root {
        string OIDString;

        /// <summary>
        /// Construct from OID identifier string.
        /// </summary>
        /// <param name="ID"></param>
        public AlgorithmIdentifier(string ID) {
            OIDString = ID;
            this.Algorithm = Goedel.ASN1.ASN.OIDToArray(ID);
            }

        /// <summary>
        /// Create an Algorithm Identifier from an integer array.
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Numbers"></param>
        public AlgorithmIdentifier (string Text, int [] Numbers) {
            OIDString = Text;
            Algorithm = Numbers;
            }

        }
    }
