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
using Goedel.Mesh.Credential;
using Xunit;
using Goedel.Cryptography.Dare;

using Goedel.Mesh;

namespace Goedel.XUnit {




    public partial class TestPresentationMesh : TestPresentationGeneric {

        public string DeviceAliceAdmin = "Alice Admin";
        static string AccountAlice = "alice@example.com";
        static string AccountMallet = "mallet@example.com";

        public ContextUser ContextInitiator { get; set;  }

        public Mesh.Connection ConnectionInnitiator => ContextInitiator.Connection;
        public ProfileUser ProfileInitiator => ContextInitiator.ProfileUser;



        public PublicMeshService MeshService { get; set; }


        public MeshCredential InitiatorCredential { get; set; }

        public MeshCredential ResponderCredential { get; set; }
        public  Credential GetInitiatorCredential() => InitiatorCredential;
        public  Credential GetResponderCredential() => ResponderCredential;


        public static new TestPresentationMesh Test() => new();

        //public KeyCollectionTest KeyCollection  = new KeyCollectionTest ()





        public TestPresentationMesh() {


            }


        public TestEnvironmentCommon SetTestEnvironment(TestEnvironmentCommon testEnvironmentCommon=null) {
            testEnvironmentCommon ??= new TestEnvironmentRdp();

            var meshMachine = testEnvironmentCommon.GetMeshMachine("test");
            Console.Write("");

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

            return testEnvironmentCommon;
            }


        public Listener CreateMeshListener() {

            // Service is MeshService
            // 


            throw new NYI();
            }

        }
    }
