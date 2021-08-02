using Goedel.Cryptography;
using Goedel.Mesh;
using Goedel.Mesh.Client;
using Goedel.Mesh.Server;
using Goedel.Mesh.Test;
using Goedel.Protocol.Presentation;
using Goedel.Utilities;

namespace Goedel.XUnit {




    public partial class TestPresentationMesh : TestPresentationGeneric {

        public string DeviceAliceAdmin = "Alice Admin";
        static string AccountAlice = "alice@example.com";
        static string AccountMallet = "mallet@example.com";
        public string DeviceBobAdmin = "Bob Admin";
        static string AccountBob = "bob@example.com";
        static string AccountGroup = "groupw@example.com";
        public ContextUser ContextInitiator { get; set; }

        public Mesh.Connection ConnectionInnitiator => ContextInitiator.Connection;
        public ProfileUser ProfileInitiator => ContextInitiator.ProfileUser;



        public PublicMeshService MeshService { get; set; }


        public ICredentialPrivate GetInitiatorCredential() {
            var profileDevice = ProfileDevice.Generate();
            return new MeshCredentialPrivate(profileDevice, null, null,
                    profileDevice.KeyAuthentication as KeyPairAdvanced);
            }
        public ICredentialPrivate GetResponderCredential() =>
            new MeshCredentialPrivate(null, MeshService.ConnectionDevice, null,
                MeshService.ActivationDevice.DeviceAuthentication);


        public static TestPresentationMesh Test() => new();

        //public KeyCollectionTest KeyCollection  = new KeyCollectionTest ()





        public TestPresentationMesh() {


            }


        public TestEnvironmentCommon SetTestEnvironment(TestEnvironmentCommon testEnvironmentCommon = null) {
            testEnvironmentCommon ??= new TestEnvironmentRdp();

            //var meshMachine = testEnvironmentCommon.GetMeshMachine("test");
            //Console.Write("");

            //ContextInitiator = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
            //            DeviceAliceAdmin, AccountAlice, "main");

            // fish out the client credentials here


            ////var testService = new TestService(TestEnvironmentCommon);
            //var profileService = ProfileService.Generate(MeshMachine);
            //var profileHost= ProfileHost.Generate();

            MeshService = testEnvironmentCommon.MeshService;


            //// create the client credential
            //InitiatorCredential = new MeshCredentialTraced(ContextInitiator);
            //ResponderCredential = new MeshCredentialTraced(
            //    testEnvironmentCommon.MeshService.ConnectionAccount,
            //    testEnvironmentCommon.MeshService.ActivationDevice.DeviceAuthentication);

            return testEnvironmentCommon;
            }


        public Listener CreateMeshListener() {

            // Service is MeshService
            // 


            throw new NYI();
            }

        }
    }
