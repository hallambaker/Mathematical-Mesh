//using Goedel.Cryptography;
//using Goedel.Cryptography.Core;
//using Goedel.Cryptography.Dare;
//using Goedel.Mesh;
//using Goedel.Mesh.Client;
//using Goedel.Utilities;
//using Goedel.IO;
//using Goedel.Protocol;
//using System;
//using System.IO;
//using System.Collections.Generic;


//namespace Goedel.Test.Core {


//    //public class MeshMachineTestWeb : MeshMachineTest {
//    //    public MeshMachineTestWeb(TestEnvironmentCommon testEnvironmentPerTest, string name = "Test") :
//    //        base(testEnvironmentPerTest, name) {
//    //        }

//    //    }


//    /// <summary>
//    /// Test machine. The cryptographic keys and persistence stores are only 
//    /// stored as in-memory structures and never written to disk.
//    /// </summary>
//    public class MeshMachineTest : MeshMachineCore {

//        public List<Trace> MeshProtocolMessages = new();
//        TestEnvironmentCommon testEnvironmentCommon;

//        public string Name;
//        public string Path => System.IO.Path.Combine(testEnvironmentCommon.Path, Name);



//        /// <summary>
//        /// Return a MeshService client for the service ID <paramref name="accountAddress"/>
//        /// using the authentication key <paramref name="keyAuthentication"/> and credential
//        /// <paramref name="assertionAccountConnection"/>. 
//        /// </summary>
//        /// <param name="accountAddress">The service identifier to connect to.</param>
//        /// <param name="keyAuthentication">The private key to be used for authentication
//        /// (encryption).</param>
//        /// <param name="assertionAccountConnection">The credential binding the device
//        /// to the account.</param>
//        /// <param name="profileMaster">The master profile. This is required when requesting
//        /// an inbound connection or requesting that a new account be created and optional
//        /// otherwise.</param>
//        /// <returns></returns>
//        public override MeshServiceClient GetMeshClient(
//                string accountAddress) =>
//                    testEnvironmentCommon.GetMeshClient(accountAddress, MeshProtocolMessages);


//        public static Contact ContactAlice = new ContactPerson(
//            "Alice", "Aardvark", email: "alice@example.com");

//        public static Contact ContactBob = new ContactPerson(
//            "Bob", "Baker", email: "bob@example.com");



//        // Convenience routines 


//        public ContextMeshPreconfigured Install(string filename) {
//            var machine = new MeshMachineTest(testEnvironmentCommon, DirectoryMaster);
//            return machine.MeshHost.Install(filename);
//            }

//        public ContextUser GetContextAccount(string localName = null, string accountName = null) {
//            var machine = new MeshMachineTest(testEnvironmentCommon, DirectoryMaster);
//            return machine.MeshHost.GetContextMesh(localName) as ContextUser;
//            }


//        public static ContextUser GenerateAccountUser(
//                    TestEnvironmentCommon testEnvironmentCommon,
//                    string machineName,
//                    string accountAddress,
//                    string localName = null) {

//            var result = new MeshMachineTest(testEnvironmentCommon, machineName);
//            var contextUser = result.MeshHost.CreateMesh(accountAddress, localName);
//            return contextUser;
//            }

//        public override string ToString() => $"TestMachine:{Name}";


//        public static ContextMeshPending Connect(
//            TestEnvironmentCommon testEnvironmentCommon,
//            string machineName,
//            string accountId,
//            string localName = null,
//            string PIN = null,
//            string connectUri = null) {

//            var machine = new MeshMachineTest(testEnvironmentCommon, machineName);
//            return machine.MeshHost.Connect(accountId, localName, pin: PIN);
//            }


//        Dictionary<string, KeyPair> dictionaryKeyPairByUDF = new Dictionary<string, KeyPair>();



//        public override IKeyCollection GetKeyCollection() => new KeyCollectionTest(this);


//        public MeshMachineTest(TestEnvironmentCommon testEnvironmentPerTest, string name = "Test") :
//                    base(testEnvironmentPerTest.MachinePath(name)) {
//            Name = name;
//            testEnvironmentCommon = testEnvironmentPerTest;
//            }

//        //public MeshMachineTest(MeshMachineTest existing) :
//        //    base(existing.DirectoryMaster) =>
//        //    testEnvironmentCommon = existing.testEnvironmentCommon;


//        public void Persist(KeyPair keyPair) {
//            dictionaryKeyPairByUDF.Remove(keyPair.KeyIdentifier);
//            dictionaryKeyPairByUDF.Add(keyPair.KeyIdentifier, keyPair);
//            }


//        public KeyPair GetPrivate(string UDF) {
//            dictionaryKeyPairByUDF.TryGetValue(UDF, out var Result);
//            return Result;
//            }

//        long checkLength = 0;
//        public void CheckHostCatalogExtended() {
//            var filename = FileNameHost;

//            using var stream = filename.OpenFileReadShared();

//            Console.WriteLine($"Stream {stream.Length}");

//            (stream.Length > checkLength).TestTrue();
//            checkLength = stream.Length;

//            return;
//            }



//        }


//    public class KeyCollectionTest : KeyCollectionCore {
//        MeshMachineTest meshMachine;

//        public override string DirectoryKeys => meshMachine.DirectoryKeys;


//        public KeyCollectionTest(MeshMachineTest meshMachine) => this.meshMachine = meshMachine;



//        }


//    public class KeyCollectionTestEnv : KeyCollectionCore {
//        string path;

//        public override string DirectoryKeys => Path.Combine(path, "Keys");


//        public KeyCollectionTestEnv(string path) => this.path = path;



//        }


//    }
