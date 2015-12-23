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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Mesh;
using System;
using System.Collections.Generic;
using Goedel.Debug;

namespace Goedel.Mesh.Tests {
    [TestClass()]
    public class PersonalCurrentProfileTests {

        public static string Service = "example.com";

        public string UserName = "Alice";
        
        public string Device1 = "Voodoo";
        public string Device1Description = "Windows Desktop";

        public string App1 = "Password";
        public string App2 = "Mail";

        public string MailAccount = "alice@example.com";

        public static List<string> STARTTLS = new List<string> { "STARTTLS" };
        public static List<string> TLS = new List<string> { "TLS" };
        public Connection ConnectionSubmit = new Connection(
            "smtp.example.com", 587, "_submission._tcp", STARTTLS);
        public Connection ConnectionIMAP = new Connection(
            "imap.example.com", 993, "_imap4._tcp", TLS);

        public string Device2 = "Phone";
        public string Device2Description = "Apple iPhone";

        public string Device3 = "Watch";
        public string Device3Description = "Android Watch";

        public string PWDSite = "www.example.com";
        public string PWDUser = "Alice";
        public string PWDPassword = "Secret1";

        public string PWDUserResult, PWDPasswordResult;

        public Connection DNS1 = new Connection(
            "10.10.10.10", 53, "_dns._udp", null);
        public Connection DNS2 = new Connection(
            "10.10.5.5", 53, "_dns._udp", null);

        public int shares = 5;
        public int quorum = 3;

        static Mesh Mesh;

        [ClassInitialize()]
        public static void InitializeClass(TestContext context) {
            Mesh = new Mesh(Service);  // connect to the mesh
            }

        [TestInitialize()]
        public void InitializeTest() {
            }


        /// <summary>
        /// Generate a Personal Profile, serialize to an in-memory mesh then read back
        /// </summary>

        [TestMethod()]
        public void CheckValid () {
            var DevProfile = new  SignedDeviceProfile(Device1, Device1Description);
            var UserProfile = new PersonalProfile(DevProfile);
            var PasswordProfile = new PasswordProfile(UserProfile);
            var SignedProfile = new SignedPersonalProfile(UserProfile);
            //PasswordProfile.AddDevice(DevProfile);

            Mesh.AddProfile(SignedProfile);

            var UserProfile2 = Mesh.GetPersonalProfile(UserName);
            }

        /// <summary>
        /// Generate a Personal Profile, serialize to an in-memory mesh then read back.
        /// Signature on Master Profile is corrupted.
        /// </summary>

        [TestMethod()]
        public void CheckInValidMasterProfileSignature() {
            Assert.Fail();
            }

        /// <summary>
        /// Generate a Personal Profile, serialize to an in-memory mesh then read back.
        /// UDF on Master Profile is corrupted.
        /// </summary>

        [TestMethod()]
        public void CheckInValidMasterProfileUDF() {
            Assert.Fail();
            }

        /// <summary>
        /// Generate a Personal Profile, serialize to an in-memory mesh then read back.
        /// Signature on Admin Profile is corrupted.
        /// </summary>

        [TestMethod()]
        public void CheckInValidAdminProfileSignature() {
            Assert.Fail();
            }

        /// <summary>
        /// Generate a Personal Profile, serialize to an in-memory mesh then read back.
        /// UDF on Admin Profile is corrupted.
        /// </summary>

        [TestMethod()]
        public void CheckInValidAdminProfileUDF() {
            Assert.Fail();
            }

        /// <summary>
        /// Generate a Personal Profile, serialize to an in-memory mesh then read back.
        /// Admin profile is not signed by a valid POSK
        /// </summary>

        [TestMethod()]
        public void CheckInValidAdminProfileNotAuthorized() {
            Assert.Fail();
            }

        /// <summary>
        /// Generate a Personal Profile, serialize to an in-memory mesh then read back.
        /// Device is not authorized to sign profiles
        /// </summary>

        [TestMethod()]
        public void CheckInValidSignerNotAdmin() {
            Assert.Fail();
            }

        /// <summary>
        /// Generate a Personal Profile, serialize to an in-memory mesh then read back.
        /// Device is not authorized to sign profiles
        /// </summary>

        [TestMethod()]
        public void CheckInValidBadProfileSignature() {
            CheckInValidBadProfileSignature(Mesh);
            }

        public void CheckInValidBadProfileSignature(Mesh Mesh) {
            var DevProfile = new SignedDeviceProfile(Device1, Device1Description);
            var UserProfile = new PersonalProfile(DevProfile);
            var PasswordProfile = new PasswordProfile(UserProfile);
            //PasswordProfile.AddDevice(DevProfile);

            var SignedProfile = new SignedPersonalProfile(UserProfile);

            Mesh.AddProfile(SignedProfile);
            
            var SignedProfile2 = Mesh.GetSignedPersonalProfile(UserName);
            Trace.Spoil(SignedProfile2.SignedData.Signature, SignedProfile2.SignedData.Signature);
            var FoundError = CheckProfileFails(SignedProfile2, typeof(System.Exception));

            Debug.Trace.Assert("Missed error", FoundError);
            }


        [TestMethod()]
        public void CheckInValidBadProfileSignature100() {
            for (var i = 0; i < 10; i++) {
                CheckInValidBadProfileSignature(Mesh);
                }
            }


        private bool CheckProfile(SignedPersonalProfile Profile) {
            try {
                var TheProfile = Profile.Signed;
                return true;
                }
            catch {
                return false;
                }
            }

        private bool CheckProfileFails(SignedPersonalProfile Profile, Type ShouldThrow) {
            try {
                var TheProfile = Profile.Signed;
                return false;
                }
            catch (Exception ex) {
                if (ex.GetType() == ShouldThrow) {
                    return true;
                    }
                return false;
                }
            }

        }
    }