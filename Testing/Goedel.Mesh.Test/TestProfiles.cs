using System;
using System.Collections.Generic;
using Goedel.Mesh;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Mesh.Protocol.Client;
using Goedel.Utilities;
using Goedel.Test.Core;
using Goedel.Protocol;

namespace Goedel.Mesh.Test {

    public partial class TestProfiles {

        static string Service = "example.com";
        static string NextAccountAlice(string Test) => $"alice{Test}@{Service}";
        static string NextAccountBob(string Test) => $"bob{Test}@{Service}";

        public static TestProfiles Test => new TestProfiles();
        public TestProfiles() => TestEnvironmentCommon.Initialize();

        public  void EscrowRecover() {
            var testEnvironmentCommon = new TestEnvironmentCommon();

            var machineAliceAdmin = new MeshMachineTest(testEnvironmentCommon, name: "Alice Admin");
            var machineAliceRecover = new MeshMachineTest(testEnvironmentCommon, name: "Alice Admin Recovered");

            var deviceAdmin = ContextDevice.Generate(machineAliceAdmin);
            deviceAdmin.GenerateMaster();

            var (escrow, shares) = deviceAdmin.Escrow(3, 2);
            var recoverShares = new KeyShare[] { shares[0], shares[2] };

            var deviceAdminRecovered = deviceAdmin.Recover(escrow, recoverShares);

            }

        public void CatalogCredentials() {
            var testEnvironmentCommon = new TestEnvironmentCommon();

            var machineAliceAdmin = new MeshMachineTest(testEnvironmentCommon, name: "Alice");
            var deviceAdmin = ContextDevice.Generate(machineAliceAdmin);
            deviceAdmin.GenerateMaster();


            using (var catalog = deviceAdmin.GetCatalogCredential()) {

                var entry1 = new CatalogEntryCredential() {
                    Service = "example.com",
                    Username = "alice",
                    Password = "password"
                    };
                var entry2 = new CatalogEntryCredential() {
                    Service = "example.net",
                    Username = "alice",
                    Password = "samepassword"
                    };
                var entry3 = new CatalogEntryCredential() {
                    Service = "www.cnn.com",
                    Username = "alice1977",
                    Password = "EasyToGuess"
                    };
                var entry4 = new CatalogEntryCredential() {
                    Service = "www.bank.test",
                    Username = "alice1977",
                    Password = "EasyToGuess"
                    };
                var entry5 = new CatalogEntryCredential() {
                    Service = "example.net",
                    Username = "alice",
                    Password = "samepassword2"
                    };


                CheckCatalog(catalog, new List<CatalogEntry> { });

                catalog.Add(entry1);
                CheckCatalog(catalog, new List<CatalogEntry> { entry1 });

                catalog.Add(entry2);
                CheckCatalog(catalog, new List<CatalogEntry> { entry1, entry2 });

                catalog.Add(entry3);
                CheckCatalog(catalog, new List<CatalogEntry> { entry1, entry2, entry3 });

                catalog.Add(entry4);
                CheckCatalog(catalog, new List<CatalogEntry> { entry1, entry2, entry3, entry4 });

                catalog.Update(entry5);
                CheckCatalog(catalog, new List<CatalogEntry> { entry1, entry3, entry4, entry5 });

                catalog.Delete(entry4);
                CheckCatalog(catalog, new List<CatalogEntry> { entry1, entry3, entry5 });

                CheckCatalogEntry(entry1, catalog.LocateByService(entry1.Service));
                CheckCatalogEntry(entry3, catalog.LocateByService(entry3.Service));
                CheckCatalogEntry(null, catalog.LocateByService(entry4.Service));
                CheckCatalogEntry(entry5, catalog.LocateByService(entry5.Service));


                CheckCatalogEntry(entry1, catalog.Locate(entry1._PrimaryKey));
                }
            }

        /// <summary>
        /// Test direct addition/removal of devices without going through the services or inbound spool
        /// </summary>
        public void CatalogDevices() {
            var testEnvironmentCommon = new TestEnvironmentCommon();

            var machineAliceAdmin = new MeshMachineTest(testEnvironmentCommon, name: "Alice");
            var machineAliceLaptop = new MeshMachineTest(testEnvironmentCommon, name: "Alice Laptop");
            var machineAlicePhone = new MeshMachineTest(testEnvironmentCommon, name: "Alice Phone");
            var deviceAdmin = ContextDevice.Generate(machineAliceAdmin);
            deviceAdmin.GenerateMaster();

            var catalog = deviceAdmin.GetCatalogDevice();

            var keySign = machineAliceAdmin.KeyCollection.LocatePrivate(deviceAdmin.ProfileDevice.SignatureKey.UDF);
            var Entry1 = MakeCatalogEntryDevice(deviceAdmin.ProfileDevice, keySign);

            var Device2 = ContextDevice.Generate(machineAliceLaptop);
            var Entry2 = MakeCatalogEntryDevice(Device2.ProfileDevice, keySign);
            var Device3 = ContextDevice.Generate(machineAlicePhone);
            var Entry3 = MakeCatalogEntryDevice(Device3.ProfileDevice, keySign);

            catalog.Add(Entry1);
            CheckCatalog(catalog, new List<CatalogEntry> { Entry1 });
            catalog.Add(Entry2);
            CheckCatalog(catalog, new List<CatalogEntry> { Entry1, Entry2 });

            catalog.Add(Entry3);
            CheckCatalog(catalog, new List<CatalogEntry> { Entry1, Entry2, Entry3 });
            }

        protected DareMessage Sign(JSONObject data, KeyPair keySign) =>
                    DareMessage.Encode(data.GetBytes(tag: true),
                        signingKey: keySign, contentType: "application/mmm");

        public CatalogEntryDevice MakeCatalogEntryDevice(ProfileDevice profileDevice, KeyPair keySign) {

            var profileMeshDevicePublic = new AssertionDeviceConnection() {
                //DeviceProfile = profileDevice.DareMessage
                };

            var ProfileMeshDevicePrivate = new AssertionDevicePrivate() {
                };

            var catalogEntryDevice = new CatalogEntryDevice() {
                UDF = profileDevice.UDF,
                SignedDeviceConnection = Sign(profileMeshDevicePublic, keySign),
                EncryptedDevicePrivate = Sign(ProfileMeshDevicePrivate, keySign)
                };


            return catalogEntryDevice;
            }


        /// <summary>
        /// Test addition/deletion of contacts
        /// </summary>
        public void CatalogContacts() {
            var testEnvironmentCommon = new TestEnvironmentCommon();

            var MachineAliceAdmin = new MeshMachineTest(testEnvironmentCommon, name: "Alice");
            var deviceAdmin = ContextDevice.Generate(MachineAliceAdmin);
            deviceAdmin.GenerateMaster();


            var catalog = deviceAdmin.GetCatalogContact();

            var Contact1 = new Contact() {
                FullName = "Alice Example",
                First = "Alice",
                Last = "Example"
                };
            var Entry1 = new CatalogEntryContact(Contact1);

            var Contact2 = new Contact() {
                FullName = "Bob Example",
                First = "Bob",
                Last = "Example"
                };
            var Entry2 = new CatalogEntryContact(Contact2);

            var Contact3 = new Contact() {
                FullName = "Carol Example",
                First = "Carol",
                Last = "Example"
                };
            var Entry3 = new CatalogEntryContact(Contact3);

            var Contact4 = new Contact() {
                FullName = "Mallet Example",
                First = "Mallet",
                Last = "Example"
                };
            var Entry4 = new CatalogEntryContact(Contact4);

            catalog.Add(Entry1);
            CheckCatalog(catalog, new List<CatalogEntry> { Entry1 });

            catalog.Add(Entry2);
            CheckCatalog(catalog, new List<CatalogEntry> { Entry1, Entry2 });

            catalog.Add(Entry3);
            CheckCatalog(catalog, new List<CatalogEntry> { Entry1, Entry2, Entry3 });

            catalog.Add(Entry4);
            CheckCatalog(catalog, new List<CatalogEntry> { Entry1, Entry2, Entry3, Entry4 });
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



        }
    }
