using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Protocol;
using Goedel.Test.Core;
using Goedel.Utilities;
using Goedel.Test;

using System.Collections.Generic;

#pragma warning disable IDE0059

namespace Goedel.Mesh.Test {

    public partial class TestProfiles {

        static string Service = "example.com";
        public static string NextAccountAlice(string Test) => $"alice{Test}@{Service}";
        public static string NextAccountBob(string Test) => $"bob{Test}@{Service}";

        public static TestProfiles Test => new TestProfiles();
        public TestProfiles() => TestEnvironmentCommon.Initialize();

        public void EscrowRecover() {
            var testEnvironmentCommon = new TestEnvironmentCommon();

            var machineAliceAdmin = new MeshMachineTest(testEnvironmentCommon, name: "Alice Admin");
            var machineAliceRecover = new MeshMachineTest(testEnvironmentCommon, name: "Alice Admin Recovered");

            var deviceAdmin = machineAliceAdmin.MeshHost.CreateMesh("main");

            throw new NYI();

            //var shares = deviceAdmin.Escrow(3, 2);
            //var recoverShares = new List<string> { shares[0].UDFKey, shares[2].UDFKey };

            //var deviceAdminRecovered = machineAliceRecover.MeshHost.RecoverMesh("main", shares: recoverShares);

            }

        public void CatalogCredentials() {
            var testEnvironmentCommon = new TestEnvironmentCommon();

            var machineAliceAdmin = new MeshMachineTest(testEnvironmentCommon, name: "Alice");

            var deviceAdmin = machineAliceAdmin.MeshHost.CreateMeshWithAccount("main");

            using var catalog = deviceAdmin.GetStore(CatalogCredential.Label) as CatalogCredential;
            var entry1 = new CatalogedCredential() {
                Service = "example.com",
                Username = "alice",
                Password = "password"
                };
            var entry2 = new CatalogedCredential() {
                Service = "example.net",
                Username = "alice",
                Password = "samepassword"
                };
            var entry3 = new CatalogedCredential() {
                Service = "www.cnn.com",
                Username = "alice1977",
                Password = "EasyToGuess"
                };
            var entry4 = new CatalogedCredential() {
                Service = "www.bank.test",
                Username = "alice1977",
                Password = "EasyToGuess"
                };
            var entry5 = new CatalogedCredential() {
                Service = "example.net",
                Username = "alice",
                Password = "samepassword2"
                };


            CheckCatalog(catalog, new List<CatalogedEntry> { });

            catalog.New(entry1);
            CheckCatalog(catalog, new List<CatalogedEntry> { entry1 });

            catalog.New(entry2);
            CheckCatalog(catalog, new List<CatalogedEntry> { entry1, entry2 });

            catalog.New(entry3);
            CheckCatalog(catalog, new List<CatalogedEntry> { entry1, entry2, entry3 });

            catalog.New(entry4);
            CheckCatalog(catalog, new List<CatalogedEntry> { entry1, entry2, entry3, entry4 });

            catalog.Update(entry5);
            CheckCatalog(catalog, new List<CatalogedEntry> { entry1, entry3, entry4, entry5 });

            catalog.Delete(entry4);
            CheckCatalog(catalog, new List<CatalogedEntry> { entry1, entry3, entry5 });

            CheckCatalogEntry(entry1, catalog.LocateByService(entry1.Service));
            CheckCatalogEntry(entry3, catalog.LocateByService(entry3.Service));
            CheckCatalogEntry(null, catalog.LocateByService(entry4.Service));
            CheckCatalogEntry(entry5, catalog.LocateByService(entry5.Service));


            CheckCatalogEntry(entry1, catalog.Locate(entry1._PrimaryKey));
            }

        /// <summary>
        /// Test direct addition/removal of devices without going through the services or inbound spool
        /// </summary>
        public void CatalogDevices() {
            var testEnvironmentCommon = new TestEnvironmentCommon();

            var machineAliceAdmin = new MeshMachineTest(testEnvironmentCommon, name: "Alice");
            var machineAliceLaptop = new MeshMachineTest(testEnvironmentCommon, name: "Alice Laptop");
            var machineAlicePhone = new MeshMachineTest(testEnvironmentCommon, name: "Alice Phone");

            var deviceAdmin = machineAliceAdmin.MeshHost.CreateMeshWithAccount("main");

            var catalog = deviceAdmin.GetStore(CatalogDevice.Label) as CatalogDevice;

            //var keySign = machineAliceAdmin.KeyCollection.LocatePrivate(deviceAdmin.ProfileDevice.KeySignature.UDF);
            //var Entry1 = MakeCatalogEntryDevice(deviceAdmin.ProfileDevice, keySign);


            // Punt on these for now. Need to know what the export format is for direct connection.
            throw new NYI();




            //var Device2 = ContextDevice.Generate(machineAliceLaptop);
            //var Entry2 = MakeCatalogEntryDevice(Device2.ProfileDevice, keySign);
            //var Device3 = ContextDevice.Generate(machineAlicePhone);
            //var Entry3 = MakeCatalogEntryDevice(Device3.ProfileDevice, keySign);

            //catalog.Add(Entry1);
            //CheckCatalog(catalog, new List<CatalogEntry> { Entry1 });
            //catalog.Add(Entry2);
            //CheckCatalog(catalog, new List<CatalogEntry> { Entry1, Entry2 });

            //catalog.Add(Entry3);
            //CheckCatalog(catalog, new List<CatalogEntry> { Entry1, Entry2, Entry3 });
            }

        protected DareEnvelope Sign(JsonObject data, KeyPair keySign) =>
                    DareEnvelope.Encode(data.GetBytes(tag: true),
                        signingKey: keySign);

        public CatalogedDevice MakeCatalogEntryDevice(ProfileDevice profileDevice, KeyPair keySign) {

            var profileMeshDevicePublic = new ConnectionUser() {
                //DeviceProfile = profileDevice.DareEnvelope
                };

            var ProfileMeshDevicePrivate = new ActivationUser() {
                };

            var catalogEntryDevice = new CatalogedDevice() {
                UDF = profileDevice.UDF,
                EnvelopedConnectionUser = Sign(profileMeshDevicePublic, keySign),
                EnvelopedActivationUser = Sign(ProfileMeshDevicePrivate, keySign)
                };


            return catalogEntryDevice;
            }


        /// <summary>
        /// Test addition/deletion of contacts
        /// </summary>
        public void CatalogContacts() {
            var testEnvironmentCommon = new TestEnvironmentCommon();

            var machineAliceAdmin = new MeshMachineTest(testEnvironmentCommon, name: "Alice");
            var deviceAdmin = machineAliceAdmin.MeshHost.CreateMeshWithAccount("main");

            var catalog = deviceAdmin.GetStore(CatalogContact.Label) as CatalogContact;

            var Contact1 = new ContactPerson("Alice", "Example");
            var Entry1 = new CatalogedContact(Contact1);

            var Contact2 = new ContactPerson("Bob", "Example");
            var Entry2 = new CatalogedContact(Contact2);

            var Contact3 = new ContactPerson("Carol", "Example");
            var Entry3 = new CatalogedContact(Contact3);

            var Contact4 = new ContactPerson("Mallet", "Example");
            var Entry4 = new CatalogedContact(Contact4);

            catalog.New(Entry1);
            CheckCatalog(catalog, new List<CatalogedEntry> { Entry1 });

            catalog.New(Entry2);
            CheckCatalog(catalog, new List<CatalogedEntry> { Entry1, Entry2 });

            catalog.New(Entry3);
            CheckCatalog(catalog, new List<CatalogedEntry> { Entry1, Entry2, Entry3 });

            catalog.New(Entry4);
            CheckCatalog(catalog, new List<CatalogedEntry> { Entry1, Entry2, Entry3, Entry4 });
            }




        void CheckCatalog<T>(Catalog<T> catalog, List<CatalogedEntry> entries)
                    where T: CatalogedEntry{

            var sorted = new SortedDictionary<string, CatalogedEntry>();
            foreach (var entry in entries) {
                sorted.Add(entry._PrimaryKey, entry);
                }
            foreach (var entry in catalog) {
                sorted.TryGetValue(entry._PrimaryKey, out var test).TestTrue();
                CheckCatalogEntry(entry, test);
                sorted.Remove(entry._PrimaryKey).TestTrue();
                }
            sorted.Count.TestEqual(0);

            }


        void CheckCatalogEntry(CatalogedEntry Test1, CatalogedEntry Test2) {
            if (Test1 == null) {
                Test2.TestNull();
                }
            else {
                Test1.ToString().TestEqual(Test2.ToString());
                }
            }



        }
    }
