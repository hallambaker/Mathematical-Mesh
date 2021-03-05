using Goedel.Protocol;
using Goedel.Test.Core;
using Goedel.Test;
using Goedel.Utilities;
using Goedel.Protocol.Presentation;
using System;
using System.Collections;
using System.Collections.Generic;
using Goedel.Mesh.Test;
using Goedel.Mesh.Client;
using Goedel.Mesh.Server;
using Xunit;

using Goedel.Mesh;

namespace Goedel.XUnit {




    public partial class TestPresentationGeneric {

        public virtual Credential GetInitiatorCredential() => new TestCredential();
        public virtual Credential GetResponderCredential() => new TestCredential();

        public static TestPresentationGeneric Test() => new TestPresentationGeneric();

        static TestPresentationGeneric() => _ = Goedel.Cryptography.Core.Initialization.Initialized;



        //[Fact]
        //public void TestService() {
        //    var TestEnvironmentCommon = new TestEnvironmentCommon();


        //    var testService = new TestService(TestEnvironmentCommon);

        //    }


        byte[] MakePayload(int size = 100) => new byte[size];


        }
    public partial class TestPresentationMesh : TestPresentationGeneric {

        public string DeviceAliceAdmin = "Alice Admin";
        static string AccountAlice = "alice@example.com";


        public ContextUser ContextInitiator { get; }

        public Connection ConnectionInnitiator => ContextInitiator.Connection;
        public ProfileUser ProfileInitiator => ContextInitiator.ProfileUser;



        public PublicMeshService MeshService { get; }

        // we have to set the connection up!
        //public Connection ConnectionResponder => throw new NYI();

        //public ProfileHost ProfileResponder => MeshService.ProfileHost;


        public Enveloped<ProfileService> ServiceProfile { get; }
        public Enveloped<ConnectionHost> ServiceConnection { get; }

        public MeshCredential InitiatorCredential { get; }

        public MeshCredential ResponderCredential { get; }
        public override Credential GetInitiatorCredential() => InitiatorCredential;
        public override Credential GetResponderCredential() => ResponderCredential;


        public static TestPresentationGeneric Test() => new TestPresentationMesh();

        //public KeyCollectionTest KeyCollection  = new KeyCollectionTest ()

        public TestPresentationMesh() {
            var testEnvironmentCommon = new TestEnvironmentCommon();
            var meshMachine = testEnvironmentCommon.GetMeshMachine("test");

            ContextInitiator = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                        DeviceAliceAdmin, AccountAlice, "main");

            // fish out the client credentials here


            ////var testService = new TestService(TestEnvironmentCommon);
            //var profileService = ProfileService.Generate(MeshMachine);
            //var profileHost= ProfileHost.Generate();

            MeshService = testEnvironmentCommon.MeshService;


            // create the client credential
            InitiatorCredential = new MeshCredentialTraced(ContextInitiator);
            ResponderCredential = new MeshCredentialTraced(
                testEnvironmentCommon.MeshService.ConnectionAccount,
                testEnvironmentCommon.MeshService.ActivationDevice.DeviceAuthentication);

            }



        }
    }
