using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Utilities;
using Goedel.Mesh;
using Goedel.Protocol;
using Goedel.Mesh.Portal;
using Goedel.Mesh.Portal.Client;
using Goedel.Mesh.Portal.Server;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using UT = Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Test;

namespace Test.Common {
    /// <summary>
    /// 
    /// </summary>
    public class MeshProfiles {

        public static MeshMachine MeshCatalog = MeshMachine.Current;
        public static TestConstant TestConstant = new TestConstant();


        static MeshProfiles () {
            Mesh.Initialize(true);

            // List of all the accounts on the current machine
            MeshCatalog.EraseTest(); // remove previous test data

            // Delete the server logs to reset system
            File.Delete(TestConstant.LogMesh);
            File.Delete(TestConstant.LogPortal);

            // Connect to a direct, in process portal.
            var Portal = new MeshPortalDirect(TestConstant.NameService, TestConstant.LogMesh, TestConstant.LogPortal);
            MeshPortal.Default = Portal;

            }


        /// <summary>
        /// This illustrates how we manage profiles using the catalog.
        /// </summary>

        public void NewDevice () {
            var DeviceRegistration = MeshCatalog.GetDevice(DeviceNew: true,
                        DeviceID: TestConstant.Device1,
                        DeviceDescription: TestConstant.Device1Description);

            var UDF = DeviceRegistration.DeviceProfile.UDF;

            var DeviceRegistration2 = MeshCatalog.GetDevice(DeviceUDF: UDF);
            var DeviceProfile1 = DeviceRegistration.DeviceProfile;
            var DeviceProfile2 = DeviceRegistration2.DeviceProfile;

            UT.Assert.AreEqual(DeviceProfile1.UDF, DeviceProfile2.UDF);
            UT.Assert.AreEqual(DeviceProfile1.DeviceAuthenticationKey.UDF, DeviceProfile2.DeviceAuthenticationKey.UDF);
            UT.Assert.AreEqual(DeviceProfile1.DeviceEncryptiontionKey.UDF, DeviceProfile2.DeviceEncryptiontionKey.UDF);
            UT.Assert.AreEqual(DeviceProfile1.DeviceSignatureKey.UDF, DeviceProfile2.DeviceSignatureKey.UDF);
            UT.Assert.AreEqual(DeviceProfile1.Description, DeviceProfile2.Description);
            UT.Assert.IsTrue(DeviceProfile1.Valid);
            UT.Assert.IsTrue(DeviceProfile2.Valid);
            }



        /// <summary>
        /// This illustrates how we manage profiles using the catalog.
        /// </summary>
        public void NewPersonal () {
            var DeviceRegistration = MeshCatalog.GetDevice(DeviceNew: true,
                        DeviceID: TestConstant.Device1,
                        DeviceDescription: TestConstant.Device1Description);
            var AccountID = TestConstant.AccountID.MakeUnique();

            var PersonalProfile1 = new PersonalProfile(DeviceRegistration.DeviceProfile);
            var PersonalRegistration = MeshCatalog.CreateAccount(AccountID, PersonalProfile1);

            UT.Assert.IsNotNull(PersonalRegistration);
            UT.Assert.IsNotNull(PersonalRegistration.SignedPersonalProfile);

            var MeshCatalog2 = NewCatalog();


            var PersonalMesh = MeshCatalog2.GetPersonal(AccountID);
            var PersonalProfile2 = PersonalMesh.PersonalProfile;

            UT.Assert.AreEqual(PersonalProfile1.UDF, PersonalProfile2.UDF);
            UT.Assert.AreEqual(PersonalProfile1.AdministrationKey.UDF, PersonalProfile2.AdministrationKey.UDF);
            UT.Assert.AreEqual(PersonalProfile1.DeviceProfile.UDF, PersonalProfile2.DeviceProfile.UDF);
            UT.Assert.IsTrue(PersonalProfile1.Valid);
            UT.Assert.IsTrue(PersonalProfile2.Valid);
            }




        public PersonalProfile FromData (PersonalProfile PersonalProfile) {
            var Bytes = PersonalProfile.SignedPersonalProfile.GetBytes();
            return SignedPersonalProfile.FromJSON(Bytes.JSONReader()).PersonalProfile;
            }

        public MeshMachine NewCatalog() => new MeshMachineCached();


        public SessionPersonal CreateAndRegister (string AccountID) {
            var BaseCatalog = NewCatalog();
            var MeshClient = new MeshClient(TestConstant.Service);
            return CreateAndRegister(BaseCatalog, MeshClient, "TestDevice",
                    "Just a test", AccountID);
            }

        public SessionPersonal CreateAndRegister (MeshMachine MeshCatalog, MeshClient MeshClient,
                    string DeviceID, string DeviceDescription, string AccountID) {

            var DeviceRegistration = MeshCatalog.GetDevice(DeviceNew: true,
                    DeviceID: DeviceID, DeviceDescription: DeviceDescription);

            var PersonalProfile1 = new PersonalProfile(DeviceRegistration.DeviceProfile);
            return MeshCatalog.CreateAccount(AccountID, PersonalProfile1, MeshClient);
            }

        /// <summary>
        /// Connect a simulated device.
        /// </summary>
        /// <param name="AdminClient">The administration client</param>
        /// <param name="AccountID">The account ID to bind to</param>
        /// <returns>The registration context for the new device.</returns>
        public SessionPersonal ConnectDevice (SessionPersonal Admin, string AccountID) {


            var AdminClient = Admin.MeshClient;
            var DeviceCatalog = NewCatalog();
            var DeviceRegistration = MeshCatalog.GetDevice(DeviceNew: true,
                        DeviceID: TestConstant.Device2,
                        DeviceDescription: TestConstant.Device2Description);
            var Personal = DeviceRegistration.BeginConnect(AccountID);

            var Requests = AdminClient.ConnectPending();
            var Request = Requests.Match(DeviceRegistration.UDF);

            Admin.PersonalProfile.Add(Request.Device.DeviceProfile);
            Admin.WriteToPortal();

            AdminClient.ConnectClose(Request.SignedConnectionRequest, ConnectionStatus.Accepted);

            Personal.CompleteConnect();

            return Personal;
            }


        public void ConnectApplications (SessionPersonal Personal) {

            }

        public void CheckApplications (List<SessionPersonal> Personal, int Connected) {

            }


        }

    }
