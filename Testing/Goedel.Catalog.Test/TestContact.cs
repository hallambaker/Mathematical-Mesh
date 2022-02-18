using System;
using System.IO;
using MT=Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Mesh.Shell;
using Goedel.Protocol;
using Goedel.Utilities;
using System.Collections.Generic;

namespace Goedel.Catalog.Test {

    public partial class CatalogTests {

        static EntryContact Contact1 = new EntryContact {
            ID = "alice@example.com"
            };

        static EntryContact Contact2 = new EntryContact {
            ID = "alice2@example.net"
            };

        static CatalogContact CatalogContact1 = new CatalogContact {
            Entries = new List<EntryContact> { Contact1 }
            };

        static CatalogContact CatalogContact2 = new CatalogContact {
            Entries = new List<EntryContact> { Contact1, Contact2 }
            };

        static CatalogContact CatalogContact3 = new CatalogContact {
            Entries = new List<EntryContact> { Contact2 }
            };

        [MT.TestMethod]
        public void TestBasicContact() {
            var Filename = "TestBasicContact.dcon";
            File.Delete(Filename);
            ShellDispatch ShellDispatch = new ShellDispatch (Catalog: Filename);

            ShellDispatch.ContactAdd(Contact1.ID);
            var Dump1 = ShellDispatch.ContactDump();
            TestDump(CatalogContact1, Dump1.Data);

            ShellDispatch.ContactAdd(Contact2.ID);
            var Dump2 = ShellDispatch.ContactDump();
            TestDump(CatalogContact2, Dump2.Data);

            ShellDispatch.ContactDelete(Contact2.ID);
            var Dump3 = ShellDispatch.ContactDump();
            TestDump(CatalogContact3, Dump3.Data);

            }


        void TestDump(CatalogContact Reference, string Test) {
            var Parsed = CatalogContact.FromJSON(Test.JSONReader(), true);
            Assert.True(Parsed.GetJson()==Reference.GetJson());
            }

        void TestCredential(EntryContact First, CatalogEntry Second) {
            var SecondEntry = Second as EntryContact;
            Assert.NotNull(SecondEntry);

            }

        }
    }
