using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Mesh;
using Goedel.Cryptography;
using Goedel.Cryptography.Core;
using Goedel.Cryptography.PKIX;
using Goedel.Utilities;
using Goedel.Mesh.Protocol.Client;
using Goedel.Mesh.Protocol;
using Goedel.Mesh.Protocol.Server;
using Goedel.Protocol;


namespace Goedel.Test.Core {


    /// <summary>
    /// Test machine. The cryptographic keys and persistence stores are only 
    /// stored as in-memory structures and never written to disk.
    /// </summary>
    public class MeshMachineTest : MeshMachineCore {




        public override MeshService GetMeshClient(string address) => 
            MachineEnvironment.MeshPortalDirect.GetService(address);



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


        Dictionary<string, KeyPair> DictionaryKeyPairByUDF = new Dictionary<string, KeyPair>();


        public TestEnvironmentMachine MachineEnvironment;


        public override KeyCollection GetKeyCollection() => new KeyCollectionTest(this);

        /// <summary>
        /// Construct a unique test machine with the specified class name.
        /// Separate persistence stores will be created.
        /// </summary>
        /// <param name="Name"></param>
        public MeshMachineTest(TestEnvironmentMachine machineEnvironment, string name = "Test") :
            base(Path.Combine(machineEnvironment.Path,name)) => 
                MachineEnvironment = machineEnvironment;


        //public MeshMachineTest(string name="Default") : this (new MachineEnvironment(name)) {
        //    }


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



        public static void GetContext(
                TestEnvironmentCommon testEnvironmentCommon,
                string nameAccount,
                string nameMachine,
                out MeshMachineTest machine,
                out ContextDevice contextDevice) {

            var machineEnvironment = new TestEnvironmentMachine(testEnvironmentCommon, "nameMachine");
            machine = new MeshMachineTest(machineEnvironment, nameMachine);
            contextDevice = ContextDevice.Generate(machine);
            }

        public static void GetContext(
                TestEnvironmentCommon testEnvironmentCommon,
                string nameAccount,
                string nameMachine,
                out MeshMachineTest machine,
                out ContextDevice contextDevice,
                out ContextMaster contextMaster) {
            GetContext(testEnvironmentCommon, nameAccount, nameMachine, out machine, out contextDevice);
            contextMaster = contextDevice.GenerateMaster();
            }

        public static void GetContext(
                string nameAccount,
                string nameMachine,
                out MeshMachineTest machine,
                out ContextDevice contextDevice,
                out ContextMaster contextMaster) {
            var testEnvironmentCommon = new TestEnvironmentCommon();
            GetContext(testEnvironmentCommon, nameAccount, nameMachine, out machine, out contextDevice);
            contextMaster = contextDevice.GenerateMaster();
            }

        }


    public class KeyCollectionTest : KeyCollectionCore {
        MeshMachineTest MeshMachine;

        public override string DirectoryKeys => MeshMachine.DirectoryKeys;


        public KeyCollectionTest(MeshMachineTest meshMachine) => MeshMachine = meshMachine;


        /// <summary>
        /// Add a keypair and bind it to the persistence store.
        /// </summary>
        /// <param name="keyPair">The key pair to add.</param>
        public override void Add(KeyPair keyPair) {
            if (keyPair.PersistPending) {
                MeshMachine.Persist(keyPair);
                keyPair.Persist(this);
                base.Add(keyPair);
                }
            }


       }

    }
