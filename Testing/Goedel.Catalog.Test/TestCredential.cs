using System;
using System.IO;
using MT=Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Mesh.Shell;
using Goedel.Protocol;
using Goedel.Utilities;
using System.Collections.Generic;

namespace Goedel.Catalog.Test {

    public partial class CatalogTests {
        [MT.TestMethod]
        public void TestBasicCredential() {
            var Filename = "TestBasicCredential.dcon";
            File.Delete(Filename);
            ShellDispatch ShellDispatch = new ShellDispatch (Catalog: Filename);

            var Credential1 = new EntryCredential() {
                Site = "example.com",
                Username = "alice",
                Password = "password"
                };

            var Credential2 = new EntryCredential() {
                Site = "example.net",
                Username = "bob",
                Password = "secret"
                };

            var Catalog1 = new CatalogCredential() {
                Entries = new List<EntryCredential> {
                    Credential1, Credential2
                    }
                };

            var Catalog2 = new CatalogCredential() {
                Entries = new List<EntryCredential> {
                    Credential2
                    }
                };

            ShellDispatch.PasswordAdd(Credential1.Site, Credential1.Username, Credential1.Password);

            var Result1 = ShellDispatch.PasswordGet(Credential1.Site) as ResultCredential;
            TestCredential(Credential1, Result1.Entry);

            var Result2 = ShellDispatch.PasswordGet(Credential2.Site) as ResultCredential;
            Assert.Null(Result2.Entry);

            ShellDispatch.PasswordAdd(Credential2.Site, Credential2.Username, Credential2.Password);
            var Result3 = ShellDispatch.PasswordGet(Credential2.Site) as ResultCredential;
            TestCredential(Credential2, Result3.Entry);

            var Dump1 = ShellDispatch.PasswordDump();
            TestDump(Catalog1, Dump1.Data);

            ShellDispatch.PasswordDelete(Credential1.Site);
            var Result4 = ShellDispatch.PasswordGet(Credential1.Site) as ResultCredential;
            Assert.Null(Result4.Entry);

            var Dump2 = ShellDispatch.PasswordDump();
            TestDump(Catalog2, Dump2.Data);


            }


        void TestDump(CatalogCredential Reference, string Test) {
            var Parsed = CatalogCredential.FromJSON(Test.JSONReader(), true);
            Assert.True(Parsed.GetJson()==Reference.GetJson());
            }

        void TestCredential(EntryCredential First, CatalogEntry Second) {
            var SecondEntry = Second as EntryCredential;
            Assert.NotNull(SecondEntry);
            Assert.True(First.Site == SecondEntry.Site);
            Assert.True(First.Username == SecondEntry.Username);
            Assert.True(First.Password == SecondEntry.Password);
            }

        }
    }
