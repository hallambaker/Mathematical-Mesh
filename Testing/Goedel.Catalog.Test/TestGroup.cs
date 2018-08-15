using System;
using System.IO;
using MT=Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Mesh.Shell;
using Goedel.Protocol;
using Goedel.Utilities;
using System.Collections.Generic;

namespace Goedel.Catalog.Test {
    public partial class CatalogTests {
        static EntryGroup Group1 = new EntryGroup {
            ID = "alice@example.com"
            };

        static EntryGroup Group2 = new EntryGroup {
            ID = "alice2@example.net"
            };

        static CatalogGroup CatalogGroup1 = new CatalogGroup {
            Entries = new List<EntryGroup> { Group1 }
            };

        static CatalogGroup CatalogGroup2 = new CatalogGroup {
            Entries = new List<EntryGroup> { Group1, Group2 }
            };

        static CatalogGroup CatalogGroup3 = new CatalogGroup {
            Entries = new List<EntryGroup> { Group2 }
            };


        [MT.TestMethod]
        public void TestBasicGroup() {
            var Filename = "TestBasicGroup.dcon";
            File.Delete(Filename);
            ShellDispatch ShellDispatch = new ShellDispatch(Catalog: Filename);

            ShellDispatch.GroupAdd(Mail1.ID);
            var Dump1 = ShellDispatch.GroupDump();
            TestDump(CatalogGroup1, Dump1.Data);

            ShellDispatch.MailAdd(Mail2.ID);
            var Dump2 = ShellDispatch.GroupDump();
            TestDump(CatalogGroup2, Dump2.Data);

            ShellDispatch.MailDelete(Mail2.ID);
            var Dump3 = ShellDispatch.GroupDump();
            TestDump(CatalogGroup2, Dump3.Data);


            }


        void TestDump(CatalogGroup Reference, string Test) {
            var Parsed = CatalogGroup.FromJSON(Test.JSONReader(), true);
            Assert.True(Parsed.GetJson() == Reference.GetJson());
            }

        void TestCredential(EntryGroup First, CatalogEntry Second) {
            var SecondEntry = Second as EntryGroup;
            Assert.NotNull(SecondEntry);

            }

        }
    }
