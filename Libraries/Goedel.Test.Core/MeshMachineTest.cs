using Goedel.Cryptography;
using Goedel.Cryptography.Core;
using Goedel.Mesh;
using Goedel.Mesh.Client;
using Goedel.Utilities;
using Goedel.IO;

using System;
using System.Collections.Generic;


namespace Goedel.Test.Core {


    /// <summary>
    /// Test machine. The cryptographic keys and persistence stores are only 
    /// stored as in-memory structures and never written to disk.
    /// </summary>
    public class MeshMachineTest : MeshMachineCore {


        TestEnvironmentCommon testEnvironmentCommon;

        public string Name;
        public string Path => System.IO.Path.Combine(testEnvironmentCommon.Path, Name);



        /// <summary>
        /// Return a MeshService client for the service ID <paramref name="accountAddress"/>
        /// using the authentication key <paramref name="keyAuthentication"/> and credential
        /// <paramref name="assertionAccountConnection"/>. 
        /// </summary>
        /// <param name="accountAddress">The service identifier to connect to.</param>
        /// <param name="keyAuthentication">The private key to be used for authentication
        /// (encryption).</param>
        /// <param name="assertionAccountConnection">The credential binding the device
        /// to the account.</param>
        /// <param name="profileMaster">The master profile. This is required when requesting
        /// an inbound connection or requesting that a new account be created and optional
        /// otherwise.</param>
        /// <returns></returns>
        public override MeshService GetMeshClient(
                string accountAddress,
                CryptoKey keyAuthentication,
                ConnectionAccount assertionAccountConnection,
                Profile profile = null) =>
            testEnvironmentCommon.MeshLocalPortal.GetService(accountAddress);


        public static Contact ContactAlice = new ContactPerson(
            "Alice", "Aardvark", email: "alice@example.com");

        public static Contact ContactBob = new ContactPerson(
            "Bob", "Baker", email: "bob@example.com");



        // Convenience routines 
        public ContextAccount GetContextAccount(string localName = null, string accountName = null) {
            var machine = new MeshMachineTest(testEnvironmentCommon, DirectoryMaster);
            var contextMesh = machine.MeshHost.GetContextMesh(localName);
            return contextMesh.GetContextAccount(localName, accountName);
            }

        public static MeshMachineTest GenerateMasterAccount(
                    TestEnvironmentCommon testEnvironmentCommon,
                    string machineName,
                    string localName,
                    out ContextAccount contextAccount) {

            var result = new MeshMachineTest(testEnvironmentCommon, machineName);
            var contextAdmin = ContextMeshAdmin.CreateMesh(result.MeshHost);
            contextAccount = contextAdmin.CreateAccount(localName);
            return result;
            }

        public static MeshMachineTest GenerateMasterAccount(
                    TestEnvironmentCommon testEnvironmentCommon,
                    string machineName,
                    string localName,
                    out ContextAccount contextAccount,
                    string accountId) {

            var result = new MeshMachineTest(testEnvironmentCommon, machineName);
            var contextAdmin = ContextMeshAdmin.CreateMesh(result.MeshHost);

            Console.WriteLine("Created new Mesh");
            Console.WriteLine(contextAdmin.CatalogedDevice.ToString());

            contextAccount = contextAdmin.CreateAccount(localName);

            Console.WriteLine("Device Catalog");


            var catalogDevice = contextAccount.GetCatalogDevice();
            Console.WriteLine(catalogDevice.Report());

            //Console.WriteLine("Added Account");
            //Console.WriteLine(contextAdmin.CatalogedDevice.ToString());
            contextAccount.AddService(accountId);

            Console.WriteLine("Bound account to Service");
            Console.WriteLine(contextAdmin.CatalogedDevice.ToString());

            return result;
            }

        public override string ToString() => $"TestMachine:{Name}";


        public static ContextMeshPending Connect(
            TestEnvironmentCommon testEnvironmentCommon,
            string machineName,
            string accountId,
            string localName = null,
            string PIN = null) {

            var machine = new MeshMachineTest(testEnvironmentCommon, machineName);
            return machine.MeshHost.Connect(accountId, PIN: PIN);
            }

        public static ContextAccount Connect(
            TestEnvironmentCommon testEnvironmentCommon,
            string machineName,
            ContextAccount contextAccountAdmin,
            string localName = null) {

            var PIN = contextAccountAdmin.GetPIN();

            var machine = new MeshMachineTest(testEnvironmentCommon, machineName);
            //return machine.Connect(contextAccountAdmin.AccountId, PIN: PIN);

            throw new NYI();
            }



        Dictionary<string, KeyPair> dictionaryKeyPairByUDF = new Dictionary<string, KeyPair>();



        public override KeyCollection GetKeyCollection() => new KeyCollectionTest(this);


        public MeshMachineTest(TestEnvironmentCommon testEnvironmentPerTest, string name = "Test") :
                    base(testEnvironmentPerTest.MachinePath(name)) {
            Name = name;
            testEnvironmentCommon = testEnvironmentPerTest;
            }

        public MeshMachineTest(MeshMachineTest existing) :
            base(existing.DirectoryMaster) =>
            testEnvironmentCommon = existing.testEnvironmentCommon;


        public void Persist(KeyPair keyPair) {
            dictionaryKeyPairByUDF.Remove(keyPair.KeyIdentifier);
            dictionaryKeyPairByUDF.Add(keyPair.KeyIdentifier, keyPair);
            }


        public KeyPair GetPrivate(string UDF) {
            dictionaryKeyPairByUDF.TryGetValue(UDF, out var Result);
            return Result;
            }

        long checkLength = 0;
        public void CheckHostCatalogExtended() {
            var filename = FileNameHost;

            using var stream = filename.OpenFileReadShared();

            Console.WriteLine($"Stream {stream.Length}");

            (stream.Length > checkLength).AssertTrue();
            checkLength = stream.Length;

            return;
            }



        }


    public class KeyCollectionTest : KeyCollectionCore {
        MeshMachineTest meshMachine;

        public override string DirectoryKeys => meshMachine.DirectoryKeys;


        public KeyCollectionTest(MeshMachineTest meshMachine) => this.meshMachine = meshMachine;



        }

    }
