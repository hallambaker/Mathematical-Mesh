using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UT=Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Mesh;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Protocol;


namespace Test.Goedel.Mesh {

    //[TestFixture]
    [TestClass]
    public class TestProfile {


        [ClassInitialize()]
        public static void InitializeClass(TestContext context) {
            global::Goedel.Mesh.Mesh.Initialize(true);

            DeviceProfile = new DeviceProfile(Device1, Device1Description);
            PersonalProfile = new PersonalProfile(DeviceProfile);

            }


        static DeviceProfile DeviceProfile;
        static PersonalProfile PersonalProfile;

        [TestInitialize()]
        public void InitializeTest() {

            }


        // Profile
        // TTest: Create new personal profile
        // TTest: Escrow master keys
        // TTest: Recover master keys


        public static string Service = "example.com";

        public static string UserName = "Alice";

        public static string Device1 = "Voodoo";
        public static string Device1Description = "Windows Desktop";
        public static string Device1DescriptionBad = "Windows Desktap";

        public static string App1 = "Password";
        public static string App2 = "Mail";

        public static string MailAccount = "alice@example.com";

        public static List<string> STARTTLS = new List<string> { "STARTTLS" };
        public static List<string> TLS = new List<string> { "TLS" };
        public static Connection ConnectionSubmit = new Connection(
            "smtp.example.com", 587, "_submission._tcp", STARTTLS);
        public static Connection ConnectionIMAP = new Connection(
            "imap.example.com", 993, "_imap4._tcp", TLS);

        public static string Device2 = "Phone";
        public static string Device2Description = "Apple iPhone";

        public static string Device3 = "Watch";
        public static string Device3Description = "Android Watch";

        public static string PWDSite = "www.example.com";
        public static string PWDUser = "Alice";
        public static string PWDPassword = "Secret1";

        public static string PWDUserResult, PWDPasswordResult;


        static DeviceProfile Copy (DeviceProfile DeviceProfile) {
            var Signed = DeviceProfile.SignedDeviceProfile;
            var Text = Signed.GetBytes(true);
            var Signed2 = SignedDeviceProfile.FromJSON(Text.JSONReader());
            return Signed2.DeviceProfile;
            }


        static SignedDeviceProfile WrapBadData(DeviceProfile DeviceProfile) {
            var Signed1 = DeviceProfile.SignedDeviceProfile;
            Signed1.SignedData.Data = DeviceProfile.GetBytes(true);
            var Text = Signed1.GetBytes(true);
            var Signed2 = SignedDeviceProfile.FromJSON(Text.JSONReader());

            return Signed2;
            }


        static PersonalProfile Copy(PersonalProfile PersonalProfile) {
           var Signed = PersonalProfile.SignedPersonalProfile;
            var Text = Signed.GetBytes(true);
            var Signed2 = SignedPersonalProfile.FromJSON(Text.JSONReader());
            return Signed2.PersonalProfile;
            }


        static SignedPersonalProfile WrapBadData(PersonalProfile PersonalProfile) {
            var Signed1 = PersonalProfile.SignedPersonalProfile;
            Signed1.SignedData.Data = PersonalProfile.GetBytes(true);
            var Text = Signed1.GetBytes(true);
            var Signed2 = SignedPersonalProfile.FromJSON(Text.JSONReader());

            return Signed2;
            }

        static SignedMasterProfile WrapBadData(MasterProfile MasterProfile) {
            var Signed1 = MasterProfile.SignedMasterProfile;
            Signed1.SignedData.Data = MasterProfile.GetBytes(true);
            var Text = Signed1.GetBytes(true);
            var Signed2 = SignedMasterProfile.FromJSON(Text.JSONReader());

            return Signed2;
            }


        static void Invalidate (Key Key) {

            if (Key as PublicKeyRSA != null) {
                var PublicKeyRSA = Key as PublicKeyRSA;
                PublicKeyRSA.N[0] ^= (byte)1;
                return;
                }
            throw new Exception();

            }






        // Do the signed versions!!!

        [TestMethod]
        public void CheckDeviceUnpack() {
            var DevProfile2 = Copy (DeviceProfile);

            UT.Assert.IsTrue(DevProfile2.Valid);
            UT.Assert.AreEqual(DeviceProfile.UDF, DevProfile2.UDF);
            UT.Assert.AreEqual(DeviceProfile.Description, DevProfile2.Description);
            UT.Assert.AreEqual(DeviceProfile.DeviceAuthenticationKey.UDF, DevProfile2.DeviceAuthenticationKey.UDF);
            UT.Assert.AreEqual(DeviceProfile.DeviceSignatureKey.UDF, DevProfile2.DeviceSignatureKey.UDF);
            UT.Assert.AreEqual(DeviceProfile.DeviceEncryptiontionKey.UDF, DevProfile2.DeviceEncryptiontionKey.UDF);

            }

        [TestMethod]
        [ExpectedException(typeof(InvalidProfileSignature))]
        public void CheckDeviceUnpackBadData() {
            var Bad = Copy(DeviceProfile);
            Bad.Description = Device1DescriptionBad;
            var SignedDevProfile2 = WrapBadData(Bad);
            var Fail = SignedDevProfile2.DeviceProfile;
            }


        [TestMethod]
        [ExpectedException(typeof(KeyFingerprintMismatch))]
        public void CheckDeviceUnpackBadKey() {
            var Bad = Copy(DeviceProfile);
            Invalidate(Bad.DeviceSignatureKey.PublicParameters);
            var SignedDevProfile2 = WrapBadData(Bad);
            var Fail = SignedDevProfile2.DeviceProfile;
            }

        [TestMethod]
        public void CheckDeviceUpdate() {
            var New = Copy(DeviceProfile);
            New.Description = Device2Description;
            New.Sign();
            var Test = Copy(New);
            UT.Assert.AreEqual(Test.Description, Device2Description);
            }




        // Do the signed versions!!!

        [TestMethod]
        public void CheckPersonalUnpack() {
            var PersonalProfile2 = Copy(PersonalProfile);

            UT.Assert.IsTrue(PersonalProfile2.Valid);
            UT.Assert.AreEqual(PersonalProfile.UDF, PersonalProfile2.UDF);

            // TTest: Add in checks for consistency

            }


        [TestMethod]
        [ExpectedException(typeof(FingerprintMatchFailed))]
        public void CheckPersonalBadMasterSignature() {
            var Bad = Copy(PersonalProfile);
            Invalidate(Bad.MasterProfile.MasterSignatureKey.PublicParameters);
            Bad.SignedMasterProfile = WrapBadData(Bad.MasterProfile);

            Bad.Sign();
            var SignedPersonal = WrapBadData(Bad);
            var Fail = SignedPersonal.PersonalProfile;
            }


        [TestMethod]
        [ExpectedException(typeof(InvalidProfileSignature))]
        public void CheckPersonalBadSignature() {
            var Bad = Copy(PersonalProfile);
            Bad.Names = new List<string>() { "Bad" };
            var SignedPersonal = WrapBadData(Bad);
            var Fail = SignedPersonal.PersonalProfile;
            }


        [TestMethod]
        public void CheckAddPasswordSign() {
            //var PasswordProfile = new PasswordProfile();
            //PersonalProfile.Add(PasswordProfile);
            //var SignedProfile = PersonalProfile.SignedPersonalProfile;
            }

        [TestMethod]
        public void CheckConnect() {
            var DeviceProfile1 = new DeviceProfile(Device1, Device1Description);
            var DeviceProfile2 = new DeviceProfile(Device2, Device2Description);
            PersonalProfile = new PersonalProfile(DeviceProfile1);
            PersonalProfile.Add(DeviceProfile2);

            var SignedPersonal2 = SignedPersonalProfile.FromJSON(
                        PersonalProfile.SignedPersonalProfile.GetBytes().JSONReader());


            UT.Assert.IsTrue(PersonalProfile.Devices.Count == 2);
            UT.Assert.IsTrue(SignedPersonal2.PersonalProfile.Devices.Count == 2);
            }

        // add email 
        // delete key
        // recover key
        // Add S/MIME

        // add password
        // delete key
        // recover key
        // create / update / delete / lookup entry


        // add SSH
        // add client
        // add host
        // update authhosts

        // add Confirm
        // delete confirm

        // add Recrypt
        // delete key / recover from escrow

        // Test Master Escrow
        // Escrow key
        // Delete key 
        // Recover key


        }
    }
