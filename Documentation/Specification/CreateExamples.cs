using System;
using static System.Console;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Goedel.Mesh;
using Goedel.Cryptography;
using Goedel.Protocol.Debug;
using Goedel.Mesh.Server;

namespace ExampleGenerator {
    public partial class CreateExamples {


        void Go(string Output1, string Output2) {
            StartService();

            CreateProfile();
            PublishProfile();
            ConnectDevice();
            AddApplicationWeb();
            KeyRecovery();

            Traces = Portal.Traces;

            using (var Writer = new StreamWriter (Output1)) {
                var ExampleGenerator = new ExampleGenerator(Writer);
                ExampleGenerator.MeshExamples(this);
                }

            using (var Writer = new StreamWriter(Output2)) {
                var ExampleGenerator = new ExampleGenerator(Writer);
                ExampleGenerator.MeshExamplesWeb(this);
                }

            }

        public static string NameAccount = "alice";
        public static string NameService = "example.com";
        public readonly string AccountID = Account.ID(NameAccount, NameService);

        //public Mesh Mesh;

        MeshClient MeshClient;
        MeshPortalTraced Portal;
        /// <summary>
        /// Start the Mesh as a direct service
        /// </summary>
        void StartService() {
            // Create test Mesh
            File.Delete(LogMesh);
            File.Delete(LogPortal);


            Portal = new MeshPortalTraced(NameService, LogMesh, LogPortal);
            MeshPortal.Default = Portal;

            MeshClient = new MeshClient(PortalAccount: NameService);
            }

        public string Device1 = "Alice Desktop";
        public string Device1Description = 
            "A desktop computer built by Acme Computer Co.";

        public string Device2 = "Alice Ring";
        public string Device2Description =
            "A wearable ring computer bought.";

        public SignedDeviceProfile SignedDeviceProfile1, SignedDeviceProfile2;
        public PersonalProfile PersonalProfile;
        public SignedPersonalProfile SignedPersonalProfile;

        /// <summary>
        /// Create a new profile for alice@example.com
        /// </summary>
        void CreateProfile() {
            // Create device profile
            var DeviceProfile1 = new DeviceProfile(Device1, Device1Description);
            SignedDeviceProfile1 = DeviceProfile1.SignedDeviceProfile;
            // Create master profile

            PersonalProfile = new PersonalProfile(DeviceProfile1);
            SignedPersonalProfile = PersonalProfile.SignedPersonalProfile;
            }


        public string LabelValidate = "Validate";
        public string LabelCreatePersonal = "CreatePersonal";
        /// <summary>
        /// Publish profile
        /// </summary>
        void PublishProfile() {
            Portal.Label(LabelValidate);
            // Check that Portal Account ID is available
            MeshClient.Validate(AccountID);

            Portal.Label(LabelCreatePersonal);
            // Publish to the Portal
            MeshClient.CreatePortalAccount(NameAccount, SignedPersonalProfile);
            }


        public string LabelConnectRequest = "Connect Request";
        public string LabelConnectPending = "Connect Pending";
        public string LabelConnectPublish = "Connect Publish";
        public string LabelConnectAccept = "Connect Accept";
        public string LabelConnectStatus = "Connect Status";
        /// <summary>
        /// Add a second device
        /// </summary>
        void ConnectDevice() {
            
            //// Create device profile
            //SignedDeviceProfile2 = new SignedDeviceProfile(Device2, Device2Description);

            //Portal.Label(LabelConnectRequest);
            //// Post connection request
            //MeshClient.ConnectRequest (SignedDeviceProfile2);

            //Portal.Label(LabelConnectPending);
            //// Poll for list of connection requests
            //var ConnectPendingResult = MeshClient.ConnectPending();


            //var FirstRequest = ConnectPendingResult.Pending[0];

            //// Publish the updated profile to the Mesh.
            //Portal.Label(LabelConnectPublish);
            //PersonalProfile.Add(FirstRequest.Data.Device);
            //SignedPersonalProfile = PersonalProfile.SignedPersonalProfile;
            //MeshClient.Publish(SignedPersonalProfile);

            //Portal.Label(LabelConnectAccept);
            //// Post acceptance for first request
            //MeshClient.ConnectClose(FirstRequest, ConnectionStatus.Accepted);
            //Portal.Label(LabelConnectStatus);
            //// Retrieve acceptance
            //MeshClient.ConnectStatus(SignedDeviceProfile2.UDF);
            }


        public string LabelApplicationPublish = "Publish application";
        public string LabelApplicationProfile = "Publish update profile";

        public PasswordProfile PasswordProfile;
        public string PasswordProfilePrivate1;
        public string PasswordProfilePrivate2;
        public string PasswordProfilePrivate3;

        /// <summary>
        /// Create a Web credential profile.
        /// </summary>
        void AddApplicationWeb() {

            //// Create basic application
            //PasswordProfile = new PasswordProfile(true);
            //var ApplicationProfileEntry = PersonalProfile.Add(PasswordProfile);


            //// Add decryption blobs for each device granted access
            //PasswordProfile.AddDevice(SignedDeviceProfile1);
            //PasswordProfile.AddDevice(SignedDeviceProfile2);

            //Portal.Label(LabelApplicationPublish);
            //// Publish the application profile to the Mesh
            //MeshClient.Publish(PasswordProfile.SignedApplicationProfile);

            //Portal.Label(LabelApplicationProfile);
            //// Publish the user profile to the Mesh
            ////PersonalProfile.Add(SignedPasswordProfile);
            //MeshClient.Publish(SignedPersonalProfile);


            //PasswordProfile.Add("example.com", "alice", "secret");
            //PasswordProfile.Add("cnn.com", "alice1", "secret");

            //PasswordProfilePrivate1 = PasswordProfile.Private.ToString();
            //PasswordProfile.Private.AutoGenerate = true;

            //PasswordProfilePrivate2 = PasswordProfile.Private.ToString();

            //PasswordProfile.Private.NeverAsk = new List<string> { "bank.com" };

            //PasswordProfilePrivate3 = PasswordProfile.Private.ToString();
            }

        SSHProfile SSHProfile;

        /// <summary>
        /// Create a SSH credential profile.
        /// </summary>
        void AddApplicationSSH() {

            // Create basic application
            SSHProfile = new SSHProfile();
            var ApplicationProfileEntry = PersonalProfile.Add(SSHProfile);



            }



        /// <summary>
        /// The offline escrow entry data.
        /// </summary>
        public OfflineEscrowEntry OfflineEscrowEntry;


        public string LabelEscrow = "Publish escrow";
        public string LabelRecover = "Recover";

        /// <summary>
        /// Create and recover profile.
        /// </summary>
        void KeyRecovery() {

            // Create escrow keyshares for 2 our of 3
            OfflineEscrowEntry = new OfflineEscrowEntry(PersonalProfile, 3, 2);

            Portal.Label(LabelEscrow);
            // Publish key escrow to the Mesh
            MeshClient.Publish(OfflineEscrowEntry);

            // Recover encryption key from two shares
            var share1 = OfflineEscrowEntry.KeyShares[0].Text;
            var share2 = OfflineEscrowEntry.KeyShares[1].Text;

            // Get recovery data
            string[] TestShares = { share1, share2 };
            var RecoveryKey = new Secret (TestShares);

            // Determine identifier
            var Identifier = UDF.ToString(UDF.FromEscrowed(
                RecoveryKey.Key, 150));

            // Here need a call to pull the data
            Portal.Label(LabelRecover);

            MeshClient.Recover(Identifier);
            }

        }
    }
