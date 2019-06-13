﻿using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Mesh;
using Goedel.Cryptography;
using Goedel.Cryptography.Core;
using Goedel.Cryptography.PKIX;
using Goedel.Utilities;
using Goedel.Mesh.Client;
using Goedel.Mesh.Server;
using Goedel.Protocol;


namespace Goedel.Test.Core {


    /// <summary>
    /// Test machine. The cryptographic keys and persistence stores are only 
    /// stored as in-memory structures and never written to disk.
    /// </summary>
    public class MeshMachineTest : MeshMachineCore {


        TestEnvironmentCommon TestEnvironmentCommon;

        public string Name;
        public string Path => System.IO.Path.Combine(TestEnvironmentCommon.Path, Name);



        /// <summary>
        /// Return a MeshService client for the service ID <paramref name="serviceID"/>
        /// using the authentication key <paramref name="keyAuthentication"/> and credential
        /// <paramref name="assertionAccountConnection"/>. 
        /// </summary>
        /// <param name="serviceID">The service identifier to connect to.</param>
        /// <param name="keyAuthentication">The private key to be used for authentication
        /// (encryption).</param>
        /// <param name="assertionAccountConnection">The credential binding the device
        /// to the account.</param>
        /// <param name="profileMaster">The master profile. This is required when requesting
        /// an inbound connection or requesting that a new account be created and optional
        /// otherwise.</param>
        /// <returns></returns>
        public override MeshService GetMeshClient(
                string serviceID,
            KeyPair keyAuthentication,
            AssertionAccountConnection assertionAccountConnection,
            Profile profile = null) =>
                TestEnvironmentCommon.MeshPortalDirect.GetService(serviceID);



        public readonly static Contact ContactAlice = new Contact() {
            FullName = "Alice Aardvark",
            First = "Alice",
            Last = "Aardvark",
            Addresses = new List<Address>() {
                    new Address () {
                        URI = "mailto:alice@example.com"
                        }
                    }
            };

        public readonly static Contact ContactBob = new Contact() {
            FullName = "Bob Baker",
            First = "Bob",
            Last = "Baker",
            Addresses = new List<Address>() {
                    new Address () {
                        URI = "mailto:bob@example.com"
                        }
                    }
            };


        // Convenience routines 
        public ContextAccountService GetContextAccount(string localName=null, string accountName = null) {
            var machine = new MeshMachineTest(TestEnvironmentCommon, DirectoryMaster);
            var contextMesh = machine.GetContextMesh(localName);
            return contextMesh.GetContextAccountService (localName, accountName);
            }

        public static MeshMachineTest GenerateMasterAccount(
                    TestEnvironmentCommon testEnvironmentCommon,
                    string machineName,
                    string localName,
                    out ContextAccount contextAccount) {

            var result = new MeshMachineTest(testEnvironmentCommon, machineName);
            var contextAdmin = ContextMeshAdmin.CreateMesh(result);
            contextAccount = contextAdmin.CreateAccount(localName);
            return result;
            }

        public static MeshMachineTest GenerateMasterAccount(
                    TestEnvironmentCommon testEnvironmentCommon,
                    string machineName,
                    string localName,
                    out ContextAccountService contextAccountService,
                    string accountId) {

            var result = new MeshMachineTest(testEnvironmentCommon, machineName);
            var contextAdmin = ContextMeshAdmin.CreateMesh(result);
            var contextAccount = contextAdmin.CreateAccount(localName);
            contextAccountService = contextAccount.AddService(accountId);

            return result;
            }

        public static ContextMeshPending Connect(
            TestEnvironmentCommon testEnvironmentCommon,
            string machineName,
            string accountId,
            string localName =null,
            string PIN=null) {

            var machine = new MeshMachineTest(testEnvironmentCommon, machineName);
            return machine.Connect(accountId, PIN: PIN);
            }

        public static ContextAccountService Connect(
            TestEnvironmentCommon testEnvironmentCommon,
            string machineName,
            ContextAccountService contextAccountAdmin,
            string localName = null) {

            var PIN = contextAccountAdmin.GetPIN();

            var machine = new MeshMachineTest(testEnvironmentCommon, machineName);
            //return machine.Connect(contextAccountAdmin.AccountId, PIN: PIN);

            throw new NYI();
            }



        Dictionary<string, KeyPair> DictionaryKeyPairByUDF = new Dictionary<string, KeyPair>();



        public override KeyCollection GetKeyCollection() => new KeyCollectionTest(this);


        public MeshMachineTest(TestEnvironmentCommon testEnvironmentPerTest, string name = "Test") :
            base(testEnvironmentPerTest.MachinePath(name)) =>
                TestEnvironmentCommon = testEnvironmentPerTest;


        public MeshMachineTest(MeshMachineTest existing) :
            base (existing.DirectoryMaster) =>
            TestEnvironmentCommon = existing.TestEnvironmentCommon;


        public void Persist(KeyPair keyPair) {
            DictionaryKeyPairByUDF.Remove(keyPair.UDF);
            DictionaryKeyPairByUDF.Add(keyPair.UDF, keyPair);
            }


        public KeyPair GetPrivate(string UDF) {
            DictionaryKeyPairByUDF.TryGetValue(UDF, out var Result);
            return Result;
            }


        public override void OpenCatalog(Catalog catalog, string Name) {




            }

        //public static void GetContext(
        //            TestEnvironmentCommon testEnvironmentService,
        //            string nameAccount,
        //            string nameMachine,
        //            out MeshMachineTest machine,
        //            out ContextDevice contextDevice) {

        //    machine = new MeshMachineTest(testEnvironmentService, nameMachine);
        //    contextDevice = ContextDevice.Generate(machine);
        //    }


        //public static void GetContext(
        //        TestEnvironmentCommon testEnvironmentCommon,
        //        string nameMachine,
        //        out MeshMachineTest machine) {

        //    machine = new MeshMachineTest(testEnvironmentCommon, nameMachine);
        //    }


        //public static void GetContextMaster(
        //        string nameAccount,
        //        string nameMachine,
        //        out MeshMachineTest machine,
        //        out ContextDevice contextDevice) {
        //    var testEnvironmentService = new TestEnvironmentCommon();

        //    GetContext(testEnvironmentService, nameAccount, nameMachine, out machine, out contextDevice);
        //    contextDevice.GenerateMaster();
        //    }


        //public static void GetContextMaster(
        //        TestEnvironmentCommon testEnvironmentService,
        //        string nameAccount,
        //        string nameMachine,
        //        out MeshMachineTest machine,
        //        out ContextDevice contextDevice) {


        //    GetContext(testEnvironmentService, nameAccount, nameMachine, out machine, out contextDevice);
        //    contextDevice.GenerateMaster();
        //    }

        }


    public class KeyCollectionTest : KeyCollectionCore {
        MeshMachineTest MeshMachine;

        public override string DirectoryKeys => MeshMachine.DirectoryKeys;


        public KeyCollectionTest(MeshMachineTest meshMachine) => MeshMachine = meshMachine;



       }

    }
