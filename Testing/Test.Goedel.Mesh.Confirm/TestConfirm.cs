

using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UT = Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Mesh;
using Goedel.Mesh.Platform;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Protocol;
using Test.Common;
using Goedel.Mesh.Portal;
using Goedel.Mesh.Portal.Client;
using Goedel.Mesh.Portal.Server;
using Goedel.Test;
using Goedel.Confirm;
using Goedel.Confirm.Client;
using Goedel.Confirm.Server;
using Goedel.Account.Server;


namespace Test.Goedel.Mesh {


    // Confirm:
    // TTest: Add application to profile - Confirm
    // TTest: Remove confirm profile
    // TTest: Post confirmation request
    // TTest: Retrieve confirmation requests
    // TTest: Accept request
    // TTest: Reject request
    // TTest: Get responses

    [TestClass]
    public class TestConfirm {

        /// <summary>
        /// 
        /// </summary>
        public static void TestDirect () {

            InitializeClass();
            var Instance = new TestConfirm();

            Instance.ConfirmAccept();

            }

        #region // Initialization

        static MeshSession MeshCatalog => MeshProfiles.MeshCatalog;
        static TestConstant TestConstant = MeshProfiles.TestConstant;
        static MeshProfiles MeshProfiles = new MeshProfiles();

        [ClassInitialize]
        public static void InitializeClass (TestContext context) {
            InitializeClass();
            }

        static string ServicePortalDNS = "portal.example.com";
        static string ServiceConfirmDNS = "confirm.example.com";

        static string IDAlice = $"AliceConfirm";
        static string IDBob = $"BobConfirm";


        static string IDPortalAlice = $"{IDAlice}@{ServicePortalDNS}";
        static string IDPortalBob = $"{IDBob}@{ServicePortalDNS}";

        static string IDConfirmAlice = $"{IDAlice}@{ServiceConfirmDNS}";
        static string IDConfirmBob = $"{IDBob}@{ServiceConfirmDNS}";

        static SessionPersonal AliceMeshDevice1;
        static SessionPersonal BobMeshDevice;

        static ConfirmProfile AliceRecryptProfile;
        static ConfirmProfile BobRecryptProfile;

        public static void InitializeClass () {
            MeshConfirm.Initialize();

            var AccountPortal = new AccountPortalDirect(ServiceConfirmDNS);
            global::Goedel.Account.AccountPortal.Default = AccountPortal;
            var ConfirmPortal = new ConfirmPortalDirect(ServiceConfirmDNS);
            global::Goedel.Confirm.ConfirmPortal.Default = ConfirmPortal;

            MakeUser(IDPortalAlice, out AliceMeshDevice1, out AliceRecryptProfile);
            MakeUser(IDPortalBob, out BobMeshDevice, out BobRecryptProfile);
            }

        static void MakeUser (string AccountID, out SessionPersonal SessionPersonal,
                out ConfirmProfile ConfirmProfile) {

            SessionPersonal = MeshProfiles.CreateAndRegister(AccountID);
            ConfirmProfile = new ConfirmProfile(SessionPersonal.PersonalProfile, AccountID);

            // Add all devices as administrator devices
            foreach (var Device in SessionPersonal.PersonalProfile.Devices) {
                ConfirmProfile.AddDevice(Device.DeviceProfile, true);
                }

            var ConfirmSession = SessionPersonal.Add(ConfirmProfile);
            SessionPersonal.Write();
            ConfirmSession.Write();

            }


        #endregion

        [TestMethod]
        public void ConfirmAccept () {


            // A: Post confirmation Request
            var AliceConfirmSession = AliceMeshDevice1.GetConfirm(IDConfirmAlice);


            var RequestEntry = new RequestEntry() { ResponderAccount = IDConfirmBob };
            var RequestHandle = AliceConfirmSession.PostRequest(RequestEntry);

            // A: Get response - pending
            var Result1 = AliceConfirmSession.CheckStatus(RequestHandle);

            // B: Get pending
            var BobConfirmSession = BobMeshDevice.GetConfirm(IDConfirmBob);
            var Pending = BobConfirmSession.CheckPending();

            // B: Accept
            var AliceRequest = Pending.Select(IDConfirmAlice);
            Pending.Accept(AliceRequest[0]);

            // A: Get response - success accept

            // This is a little complex. Not doing this in detail at this point.
            //var Result2 = AliceConfirmSession.CheckStatus(RequestHandle);
            //UT.Assert.IsTrue(Result2.Status = true);

            throw new NYI();


            }

        [TestMethod]
        public void ConfirmReject () {
            //// A: Post confirmation Request
            //var AliceConfirmSession = AliceMeshDevice1.SessionConfirm(IDConfirmAlice);
            //var RequestHandle = AliceConfirmSession.PostRequest(IDConfirmBob);

            //// A: Get response - pending
            //var Result1 = AliceConfirmSession.CheckStatus(RequestHandle);

            //// B: Get pending
            //var BobConfirmSession = BobMeshDevice.SessionConfirm(IDConfirmBob);
            //var Pending = BobConfirmSession.CheckPending();

            //// B: Accept
            //var AliceRequest = Pending.Select(IDConfirmAlice);
            //AliceRequest.Reject();

            //// A: Get response - success accept
            //var Result2 = AliceConfirmSession.CheckStatus(RequestHandle);
            //UT.Assert.IsTrue(Result2.Status = Accepted);

            throw new NYI();

            }


        [TestMethod]
        public void ConfirmAcceptMultipleDevice () {

            // Create profile
            // Add device

            // A: Post confirmation Request

            // A: Get response - pending

            // B: Get pending

            // B: Accept

            // A: Get response - success accept


            }


        [TestMethod]
        public void ConfirmMuli () {
            TestMultiple(20, 10, 10);

            }

        void TestMultiple (int Requesters, int Responders, int Messages) {
            throw new NYI();
            // generate Responders


            // set off multiple threads

            }


        void TestRequester (List<SessionConfirm> Responders, int Messages) {

            throw new NYI();
            }

        }
    }
