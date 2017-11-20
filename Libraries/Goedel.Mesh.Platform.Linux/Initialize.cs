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
using System.Linq;
using System.IO;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Discovery;


namespace Goedel.Mesh {

    /// <summary>Initialization class for Mesh libraries on the Windows platform.</summary>
    public static class MeshLinux {

        /// <summary>
        /// Initialize the cryptography, platform and Mesh machine libraries to
        /// use the Windows native platform features. This library is only supported
        /// on the Windows platform.
        /// </summary>
        /// <param name="TestMode">If true, use the test directory and registry key and
        /// key store. This allows the machine to be reset after testing is complete
        /// without risk to production data.</param>
        public static void Initialize(bool TestMode = false) {
            KeyPair.TestMode = TestMode;

            //CryptographyLinux.Initialize(TestMode);
            //PlatformFramework.Initialize(TestMode);
            //RegistrationMachineLinux.Initialize(TestMode);
            }

        }


    }

