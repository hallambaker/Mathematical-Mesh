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
//  

using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Mesh.Client;
using Goedel.Protocol;
using Goedel.Utilities;

using System;
using System.Collections.Generic;
using System.IO;


namespace Goedel.Mesh.Host {
    public partial class Shell : _Shell {

        #region // Properties
        #endregion

        #region // Destructor
        #endregion

        #region // Constructors
        #endregion

        #region // Implement Interface: Ixxx
        #endregion

        #region // Methods 

        /// <summary>
        /// Perform post processing of the result of the shell operation.
        /// </summary>
        /// <param name="shellResult">The result returned by the operation.</param>
        public virtual void _PostProcess(HostResult shellResult) {
            //if (Json) {
            //    // Only report the results in JSON format and without
            //    // additional text.
            //    output.Write(shellResult.GetJson(false));
            //    }
            //else if (Verbose) {
            //    output.Write(shellResult.Verbose());
            //    }
            //else {
            //    output.Write(shellResult.ToString());
            //    }
            }

        #endregion 
        }

    }
