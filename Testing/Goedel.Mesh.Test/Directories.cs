#region // Copyright - MIT License
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

using System.IO;

namespace Goedel.Mesh.Test {
    public class Directories {




        /// <summary>
        /// Directory for test output data
        /// </summary>
        public static string Results = @"Results\";


        public static string TestKey_SSH2 => Path.Combine(TestEnvironmentCommon.CommonData, "TestKey_ssh2.pub");
        public static string TestKey_OpenSSH => Path.Combine(TestEnvironmentCommon.CommonData, "TestKey_OpenSSH.pub");
        public static string TestKey_OpenSSH_Private => Path.Combine(TestEnvironmentCommon.CommonData, "TestKey_OpenSSH.prv");
        public static string TestKey_PuTTY_Private => Path.Combine(TestEnvironmentCommon.CommonData, "TestKey_PuTTY.ppk");
        public static string TestKey_Bitvise_Private => Path.Combine(TestEnvironmentCommon.CommonData, "TestKey_Bitvise.bkp");


        public static string TestKey_Alice_Sign => Path.Combine(TestEnvironmentCommon.CommonData, "TestKey_RSA_Alice.prv");
        public static string TestKey_Bob_Encrypt => Path.Combine(TestEnvironmentCommon.CommonData, "TestKey_RSA_Bob.prv");




        }
    }
