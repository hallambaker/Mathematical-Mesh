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

//using System;
//using Xunit;
//using Goedel.Mesh;
//using Goedel.Cryptography;
//using Goedel.Cryptography.Dare;
//using Goedel.Mesh.Protocol.Client;
//using Goedel.Mesh.Test;
//using Goedel.Test.Core;
//using Goedel.Utilities;

//namespace Goedel.XUnit {

//    public class CustomTestTypeAttribute : System.Attribute { }

//    /// <summary>
//    /// Perform unit tests on profiles using the .NET Core framework. 
//    /// </summary>
//    /// <remarks>These tests are stubs to the tests in the shared library so that the
//    /// same tests can be run using the .NET Framework testing.</remarks>
//    public partial class TestProfilesXunit {

//        public static TestProfilesXunit Test() => new TestProfilesXunit();
//        public TestProfilesXunit() {
//            TestEnvironmentCommon.Initialize();
//            Goedel.Mesh.Mesh.Initialize();
//            }


//        //static string Service = "example.com";
//        //static string AccountAlice = $"alice@{Service}";


//        [Fact]
//        public void EscrowRecover() => TestProfiles.Test.EscrowRecover();

//        [Fact]
//        public void CatalogCredentials() => TestProfiles.Test.CatalogCredentials();

//        [Fact]
//        public void CatalogDevices() => TestProfiles.Test.CatalogDevices();

//        [Fact]
//        public void CatalogContacts() => TestProfiles.Test.CatalogContacts();



//        [Fact(Skip = "Decode a device profile")]
//        public void DecodeProfileDevice() => throw new NYI();

//        [Fact(Skip = "Check a valid device profile signature")]
//        public void DecodeProfileSignatureFail() => throw new NYI();

//        [Fact(Skip = "Check an invalid device profile signature")]
//        public void DecodeProfileSignatureValid() => throw new NYI();

//        }
//    }
