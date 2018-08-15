using System;
using System.IO;
using MT=Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Mesh.Shell;
using Goedel.Protocol;
using Goedel.Utilities;
using System.Collections.Generic;

namespace Goedel.Catalog.Test {

    public partial class CatalogTests {
        static EntryCalendar Calendar1 = new EntryCalendar {
            ID = "alice@example.com"
            };

        static EntryCalendar Calendar2 = new EntryCalendar {
            ID = "alice2@example.net"
            };

        static CatalogCalendar CatalogCalendar1 = new CatalogCalendar {
            Entries = new List<EntryCalendar> { Calendar1 }
            };

        static CatalogCalendar CatalogCalendar2 = new CatalogCalendar {
            Entries = new List<EntryCalendar> { Calendar1, Calendar2 }
            };

        static CatalogCalendar CatalogCalendar3 = new CatalogCalendar {
            Entries = new List<EntryCalendar> { Calendar2 }
            };

        [MT.TestMethod]
        public void TestBasicCalendar() {
            var Filename = "TestBasicCalendar.dcon";
            File.Delete(Filename);
            ShellDispatch ShellDispatch = new ShellDispatch (Catalog: Filename);

            ShellDispatch.CalendarAdd(Calendar1.ID);
            var Dump1 = ShellDispatch.CalendarDump();
            TestDump(CatalogCalendar1, Dump1.Data);

            ShellDispatch.CalendarAdd(Calendar2.ID);
            var Dump2 = ShellDispatch.CalendarDump();
            TestDump(CatalogCalendar2, Dump2.Data);

            ShellDispatch.CalendarDelete(Calendar2.ID);
            var Dump3 = ShellDispatch.CalendarDump();
            TestDump(CatalogCalendar3, Dump3.Data);


            }


        void TestDump(CatalogCalendar Reference, string Test) {
            var Parsed = CatalogCalendar.FromJSON(Test.JSONReader(), true);
            Assert.True(Parsed.GetJson()==Reference.GetJson());
            }

        void TestCredential(EntryCalendar First, CatalogEntry Second) {
            var SecondEntry = Second as EntryCalendar;
            Assert.NotNull(SecondEntry);

            }

        }
    }
