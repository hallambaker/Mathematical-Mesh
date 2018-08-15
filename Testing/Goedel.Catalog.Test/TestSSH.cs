using System;
using System.IO;
using MT=Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Mesh.Shell;
using Goedel.Protocol;
using Goedel.Utilities;
using System.Collections.Generic;

namespace Goedel.Catalog.Test {
    public partial class CatalogTests {
        static EntrySSH SSH1 = new EntrySSH {
            ID = "alice@example.com"
            };

        static EntrySSH SSH2 = new EntrySSH {
            ID = "alice2@example.net"
            };

        static CatalogSSH CatalogSSH1 = new CatalogSSH {
            Entries = new List<EntrySSH> { SSH1 }
            };

        static CatalogSSH CatalogSSH2 = new CatalogSSH {
            Entries = new List<EntrySSH> { SSH1, SSH2 }
            };

        static CatalogSSH CatalogSSH3 = new CatalogSSH {
            Entries = new List<EntrySSH> { SSH2 }
            };

        [MT.TestMethod]
        public void TestBasicSSH() {
            var Filename = "TestBasicSSH.dcon";
            File.Delete(Filename);
            ShellDispatch ShellDispatch = new ShellDispatch(Catalog: Filename);

            ShellDispatch.SSHAddClient(SSH1.ID);
            var Dump1 = ShellDispatch.SSHDump();
            TestDump(CatalogSSH1, Dump1.Data);

            ShellDispatch.SSHAddClient(SSH2.ID);
            var Dump2 = ShellDispatch.SSHDump();
            TestDump(CatalogSSH2, Dump2.Data);

            ShellDispatch.SSHAddClient(SSH2.ID);
            var Dump3 = ShellDispatch.SSHDump();
            TestDump(CatalogSSH3, Dump3.Data);

            }


        void TestDump(CatalogSSH Reference, string Test) {
            var Parsed = CatalogSSH.FromJSON(Test.JSONReader(), true);
            Assert.True(Parsed.GetJson() == Reference.GetJson());
            }

        void TestCredential(EntrySSH First, CatalogEntry Second) {
            var SecondEntry = Second as EntrySSH;
            Assert.NotNull(SecondEntry);

            }

        }

    }