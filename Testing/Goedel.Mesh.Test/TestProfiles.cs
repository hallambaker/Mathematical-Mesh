using System;
using System.Collections.Generic;
using Goedel.Mesh;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Mesh.Protocol.Client;
using Goedel.Utilities;
using Goedel.Test.Core;


namespace Goedel.Mesh.Test {

    public partial class TestProfiles {

        static string Service = "example.com";
        static string NextAccountAlice(string Test) => $"alice{Test}@{Service}";


        public static TestProfiles Test => new TestProfiles();
        public TestProfiles() => TestEnvironment.Initialize();

        public  void EscrowRecover() {
            var MachineAliceAdmin = new MeshMachineTest(name:"Alice Admin");
            var MachineAliceRecover = new MeshMachineTest(name: "Alice Admin Recovered");

            var DeviceAdmin = ContextDevice.Generate(MachineAliceAdmin);
            var MasterAdmin = DeviceAdmin.GenerateMaster();

            var (Escrow, Shares) = MasterAdmin.Escrow(3, 2);
            var RecoverShares = new KeyShare[] { Shares[0], Shares[2] };

            var DeviceAdminRecovered = DeviceAdmin.Recover(Escrow, RecoverShares);

            }

        public void CatalogCredentials() {
            var MachineAliceAdmin = new MeshMachineTest(name: "Alice");
            var DeviceAdmin = ContextDevice.Generate(MachineAliceAdmin);
            var MasterAdmin = DeviceAdmin.GenerateMaster();


            var catalog = MasterAdmin.GetCatalogCredential();

            var Entry1 = new CatalogEntryCredential() {
                Service = "example.com",
                Username = "alice",
                Password = "password"
                };
            var Entry2 = new CatalogEntryCredential() {
                Service = "example.net",
                Username = "alice",
                Password = "samepassword"
                };
            var Entry3 = new CatalogEntryCredential() {
                Service = "www.cnn.com",
                Username = "alice1977",
                Password = "EasyToGuess"
                };
            var Entry4 = new CatalogEntryCredential() {
                Service = "www.bank.test",
                Username = "alice1977",
                Password = "EasyToGuess"
                };
            var Entry5 = new CatalogEntryCredential() {
                Service = "example.net",
                Username = "alice",
                Password = "samepassword2"
                };


            CheckCatalog(catalog, new List<CatalogEntry> { });

            catalog.Add(Entry1);
            CheckCatalog(catalog, new List<CatalogEntry> { Entry1 });

            catalog.Add(Entry2);
            CheckCatalog(catalog, new List<CatalogEntry> { Entry1 , Entry2 });

            catalog.Add(Entry3);
            CheckCatalog(catalog, new List<CatalogEntry> { Entry1, Entry2, Entry3 });

            catalog.Add(Entry4);
            CheckCatalog(catalog, new List<CatalogEntry> { Entry1, Entry2, Entry3, Entry4 });

            catalog.Update(Entry5);
            CheckCatalog(catalog, new List<CatalogEntry> { Entry1, Entry3, Entry4, Entry5 });

            catalog.Delete(Entry4);
            CheckCatalog(catalog, new List<CatalogEntry> { Entry1, Entry3, Entry5 });

            CheckCatalogEntry(Entry1, catalog.LocateByService(Entry1.Service));
            CheckCatalogEntry(Entry3, catalog.LocateByService(Entry3.Service));
            CheckCatalogEntry(null, catalog.LocateByService(Entry4.Service));
            CheckCatalogEntry(Entry5, catalog.LocateByService(Entry5.Service));


            CheckCatalogEntry(Entry1, catalog.Locate(Entry1._PrimaryKey));
            }

        /// <summary>
        /// Test device addition/removal at the device level.
        /// </summary>
        public void CatalogDevices() {
            }

        public void CatalogContacts() {
            }

        void CheckCatalog(Catalog catalog, List<CatalogEntry> entries) {

            var sorted = new SortedDictionary<string, CatalogEntry>();
            foreach (var entry in entries) {
                sorted.Add(entry._PrimaryKey, entry);
                }
            foreach (var entry in catalog) {
                sorted.TryGetValue(entry._PrimaryKey, out var test).AssertTrue();
                CheckCatalogEntry(entry, test);
                sorted.Remove(entry._PrimaryKey).AssertTrue();
                }
            sorted.Count.AssertEqual(0);

            }


        void CheckCatalogEntry(CatalogEntry Test1, CatalogEntry Test2) {
            if (Test1 == null) {
                Test2.AssertNull();
                }
            else {
                Test1.ToString().AssertEqual(Test2.ToString());
                }
            }

        public  void GenerateDevice() {
            var TestName = Unique.Next();
            var AccountAlice = NextAccountAlice(TestName);

            var MachineAliceAdmin = new MeshMachineTest(name: "Alice Admin");
            var MachineAliceSecond = new MeshMachineTest(name: "Alice 2");

            var DeviceAdmin = ContextDevice.Generate(MachineAliceAdmin);
            var MasterAdmin = DeviceAdmin.GenerateMaster();
            MasterAdmin.Register(AccountAlice);

            var DeviceSecond = ContextDevice.Generate(MachineAliceSecond);
            var Fingerprint = DeviceSecond.Connect(AccountAlice);

            var Connected = DeviceSecond.Complete(AccountAlice);
            Assert.False(Connected);
            MasterAdmin.ConnectionResponse(Fingerprint, ConnectionState.Connected);

            Connected = DeviceSecond.Complete(AccountAlice);
            Assert.True(Connected);
            }

        }
    }
