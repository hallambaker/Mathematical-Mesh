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

using Goedel.Utilities;

using System;
using System.Collections.Generic;
using System.Text;

namespace Goedel.Mesh {

    ///<summary>Encrypted Authenticated Resource Locator support.</summary>
    public class EARL {

        /// <summary>
        /// Encode an EARL
        /// </summary>
        /// <param name="input"></param>
        /// <param name="outputDirectory"></param>
        /// <param name="outputFile"></param>
        /// <param name="domain"></param>
        /// <param name="log"></param>
        /// <param name="recipient">The recipient account under which the </param>
        /// <returns>The EARL</returns>
        public static string Encode(
                    string input,
                    out string outputFile,
                    string domain = null,
                    string outputDirectory = null,
                    string log = null,
                    string recipient = null) {

            throw new NYI();
            }


        }
    }
