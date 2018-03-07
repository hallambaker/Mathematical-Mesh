

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

            Instance.TestRecryptCreate();

            }

        #region // Initialization

        static MeshSession MeshCatalog => MeshProfiles.MeshCatalog;
        static TestConstant TestConstant = MeshProfiles.TestConstant;
        static MeshProfiles MeshProfiles = new MeshProfiles();

        [ClassInitialize]
        public static void InitializeClass (TestContext context) {
            InitializeClass();
            }

        static string AccountServiceDNS = "example.com";

        static string AliceAccountID = $"AliceRecrypt@{AccountServiceDNS}";
        static string BobAccountID = $"BobRecrypt@{AccountServiceDNS}";
        static string CarolAccountID = $"CarolRecrypt@{AccountServiceDNS}";


        static SessionPersonal AliceRecrypt;
        static SessionPersonal BobRecrypt;
        static SessionPersonal CarolRecrypt;

        static ConfirmProfile AliceRecryptProfile;
        static ConfirmProfile BobRecryptProfile;
        static ConfirmProfile CarolRecryptProfile;

        public static void InitializeClass () {
            MeshConfirm.Initialize();


            var AccountPortal = new AccountPortalDirect(AccountServiceDNS);
            global::Goedel.Account.AccountPortal.Default = AccountPortal;
            var ConfirmPortal = new ConfirmPortalDirect(AccountServiceDNS);
            global::Goedel.Confirm.ConfirmPortal.Default = ConfirmPortal;

            //MeshConfirm.Initialize();

            MakeUser(AliceAccountID, out AliceRecrypt, out AliceRecryptProfile);
            MakeUser(BobAccountID, out BobRecrypt, out BobRecryptProfile);
            MakeUser(CarolAccountID, out CarolRecrypt, out CarolRecryptProfile);
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
        /*
         
        public override void AccountCreate (AccountCreate Options) {
            var AccountID = Options.AccountID.Value;
            var PersonalSession = GetPersonal(Options);
            var PersonalProfile = PersonalSession.PersonalProfile;

            // Create the empty profiles
            var RecryptProfile = new RecryptProfile(PersonalSession.PersonalProfile, AccountID);
            var ConfirmProfile = new ConfirmProfile(PersonalSession.PersonalProfile, AccountID);

            // Because we are lazy, make every device an administrator device for both apps.
            foreach (var Device in PersonalProfile.Devices) {
                RecryptProfile.AddDevice(Device.DeviceProfile, true);
                ConfirmProfile.AddDevice(Device.DeviceProfile, true);
                }

            var RecryptSession = PersonalSession.Add(RecryptProfile);
            var ConfirmSession = PersonalSession.Add(ConfirmProfile);
            PersonalSession.Write();
            RecryptSession.Write();
            ConfirmSession.Write();

            var AccountClient = new AccountClient(AccountID);

            var Response = AccountClient.Create(
                AccountID, 
                PersonalProfile.UDF,
                DefaultMeshPortalAccount,
                Options.PIN.Value);

            LastResult = new ResultAccountCreate() {
                Response = Response,
                AccountID = AccountID
                };
            LastResult.Display(Options);
            }


                    public override void ConfirmPost (ConfirmPost Options) {
            var AccountID = Options.AccountID.Value;
            var ConfirmClient = new ConfirmClient(AccountID);


            var UnsignedRequest = new TBSRequest() {
                FromID = DefaultMeshPortalAccount,
                ToID = Options.AccountID.Value,
                Text = ConfirmClient.ToRequestText (Options.Text.Value)
                };

            var SignedRequest = new JoseWebSignature(UnsignedRequest, 
                        SigningKey: DeviceProfile.DeviceSignatureKey.KeyPair);

            var RequestEntry = new RequestEntry() {
                ResponderAccount = Options.AccountID.Value,
                Request = SignedRequest,
                Expire = DateTime.UtcNow.AddHours(4)
                };

            var Response = ConfirmClient.Enquire(RequestEntry);

            LastID = Response.BrokerID;
            LastResult = new ResultAccountCreate() {
                Response = Response
                };
            LastResult.Display(Options);
            }
         */

        [TestMethod]
        public void TestRecryptCreate () {
            }


        //[TestMethod]
        //public void TestEncryption () {
        //    }

        //[TestMethod]
        //public void TestRecryption () {
        //    }


        //[TestMethod]
        //public void TestRecryptionRefused () {
        //    }

        //[TestMethod]
        //public void FailRecryptionNeverAuthorized () {
        //    }

        //[TestMethod]
        //public void FailRecryptionAuthorizationWithdrawn () {
        //    }
        }
    }
