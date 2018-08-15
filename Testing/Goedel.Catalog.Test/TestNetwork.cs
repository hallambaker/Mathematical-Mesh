using System;
using System.IO;
using MT=Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Mesh.Shell;
using Goedel.Protocol;
using Goedel.Utilities;
using System.Collections.Generic;

namespace Goedel.Catalog.Test {

    public partial class CatalogTests {

        static EntryNetwork Network1 = new EntryNetwork {
            ID = "alice@example.com"
            };

        static EntryNetwork Network2 = new EntryNetwork {
            ID = "alice2@example.net"
            };

        static CatalogNetwork CatalogNetwork1 = new CatalogNetwork {
            Entries = new List<EntryNetwork> { Network1 }
            };

        static CatalogNetwork CatalogNetwork2 = new CatalogNetwork {
            Entries = new List<EntryNetwork> { Network1, Network2 }
            };

        static CatalogNetwork CatalogNetwork3 = new CatalogNetwork {
            Entries = new List<EntryNetwork> { Network2 }
            };


        [MT.TestMethod]
        public void TestBasicNetwork() {
            var Filename = "TestBasicNetwork.dcon";
            File.Delete(Filename);
            ShellDispatch ShellDispatch = new ShellDispatch (Catalog: Filename);

            ShellDispatch.NetworkAdd(Network1.ID);
            var Dump1 = ShellDispatch.NetworkDump();
            TestDump(CatalogNetwork1, Dump1.Data);

            ShellDispatch.NetworkAdd(Network2.ID);
            var Dump2 = ShellDispatch.NetworkDump();
            TestDump(CatalogNetwork2, Dump2.Data);

            ShellDispatch.NetworkDelete(Network2.ID);
            var Dump3 = ShellDispatch.NetworkDump();
            TestDump(CatalogNetwork3, Dump3.Data);


            }


        void TestDump(CatalogNetwork Reference, string Test) {
            var Parsed = CatalogNetwork.FromJSON(Test.JSONReader(), true);
            Assert.True(Parsed.GetJson()==Reference.GetJson());
            }

        void TestCredential(EntryNetwork First, CatalogEntry Second) {
            var SecondEntry = Second as EntryNetwork;
            Assert.NotNull(SecondEntry);

            }

        }
    }
