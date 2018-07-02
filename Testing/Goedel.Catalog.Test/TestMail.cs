using System;
using System.IO;
using MT=Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Mesh.Shell;
using Goedel.Protocol;
using Goedel.Utilities;
using System.Collections.Generic;

namespace Goedel.Catalog.Test {

    public partial class CatalogTests {

        static EntryMail Mail1 = new EntryMail {
            ID = "alice@example.com"
            };

        static EntryMail Mail2 = new EntryMail {
            ID = "alice2@example.net"
            };

        static CatalogMail CatalogMail1 = new CatalogMail {
            Entries = new List<EntryMail> { Mail1 }
            };

        static CatalogMail CatalogMail2 = new CatalogMail {
            Entries = new List<EntryMail> { Mail1, Mail2 }
            };

        static CatalogMail CatalogMail3 = new CatalogMail {
            Entries = new List<EntryMail> { Mail2 }
            };


        [MT.TestMethod]
        public void TestBasicMail() {
            var Filename = "TestBasicMail.dcon";
            File.Delete(Filename);
            ShellDispatch ShellDispatch = new ShellDispatch(Catalog: Filename);

            ShellDispatch.MailAdd(Mail1.ID);
            var Dump1 = ShellDispatch.BookmarkDump();
            TestDump(CatalogMail1, Dump1.Data);

            ShellDispatch.MailAdd(Mail2.ID);
            var Dump2 = ShellDispatch.BookmarkDump();
            TestDump(CatalogMail2, Dump2.Data);

            ShellDispatch.MailDelete(Mail2.ID);
            var Dump3 = ShellDispatch.BookmarkDump();
            TestDump(CatalogMail3, Dump3.Data);
            }


        void TestDump(CatalogMail Reference, string Test) {
            var Parsed = CatalogCredential.FromJSON(Test.JSONReader(), true);
            Assert.True(Parsed.GetJson() == Reference.GetJson());
            }

        void TestCredential(EntryMail First, CatalogEntry Second) {
            var SecondEntry = Second as EntryMail;
            Assert.NotNull(SecondEntry);
            }

        }
    }
