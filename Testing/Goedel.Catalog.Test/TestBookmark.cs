using System;
using System.IO;
using MT=Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Mesh.Shell;
using Goedel.Protocol;
using Goedel.Utilities;
using System.Collections.Generic;

namespace Goedel.Catalog.Test {

    public partial class CatalogTests {
        

        static EntryBookmark Bookmark1 = new EntryBookmark() {
            Title = "A sample Web site",
            Uri = "http://www.example.com/"
            };

        static EntryBookmark Bookmark2 = new EntryBookmark() {
            Title = "A sample Web site 2",
            Uri = "http://www.example.com/2"
            };

        static EntryBookmark Bookmark3 = new EntryBookmark() {
            Title = "A sample Web site 3",
            Path = "Examples",
            Uri = "http://www.example.com/3"
            };

        static EntryBookmark Bookmark4 = new EntryBookmark() {
            Title = "A sample Web site 3",
            Path = "Examples",
            Uri = "http://www.example.com/4"
            };

        static CatalogBookmark CatalogBookmark1 = new CatalogBookmark {
            Entries = new List<EntryBookmark> { Bookmark1 }
            };

        static CatalogBookmark CatalogBookmark2 = new CatalogBookmark {
            Entries = new List<EntryBookmark> { Bookmark1, Bookmark2, Bookmark3, Bookmark4 }
            };

        static CatalogBookmark CatalogBookmark3 = new CatalogBookmark {
            Entries = new List<EntryBookmark> { Bookmark1, Bookmark3, Bookmark4 }
            };

        static CatalogBookmark CatalogBookmark4 = new CatalogBookmark {
            Entries = new List<EntryBookmark> { Bookmark1, Bookmark3 }
            };

        [MT.TestMethod]
        public void TestBasicBookMark() {
            var Filename = "TestBasicBookMark.dcon";
            File.Delete(Filename);
            ShellDispatch ShellDispatch = new ShellDispatch (Catalog: Filename);


            ShellDispatch.BookmarkAdd(Bookmark1.Uri, Bookmark1.Title, Bookmark1.Path);
            var Dump1 = ShellDispatch.BookmarkDump();
            TestDump(CatalogBookmark1, Dump1.Data);

            ShellDispatch.BookmarkAdd(Bookmark2.Uri, Bookmark2.Title, Bookmark2.Path);
            ShellDispatch.BookmarkAdd(Bookmark3.Uri, Bookmark3.Title, Bookmark3.Path);
            ShellDispatch.BookmarkAdd(Bookmark4.Uri, Bookmark4.Title, Bookmark4.Path);
            var Dump2 = ShellDispatch.BookmarkDump();
            TestDump(CatalogBookmark2, Dump2.Data);

            ShellDispatch.BookmarkDelete(Bookmark2.Uri);
            var Dump3 = ShellDispatch.BookmarkDump();
            TestDump(CatalogBookmark3, Dump3.Data);

            ShellDispatch.BookmarkDelete(Bookmark4.Uri, Bookmark4.Path);
            var Dump4 = ShellDispatch.BookmarkDump();
            TestDump(CatalogBookmark4, Dump4.Data);
            }


        void TestDump(CatalogBookmark Reference, string Test) {
            var Parsed = CatalogBookmark.FromJSON(Test.JSONReader(), true);
            Assert.True(Parsed.GetJson()==Reference.GetJson());
            }

        void TestCredential(EntryBookmark First, CatalogEntry Second) {
            var SecondEntry = Second as EntryBookmark;
            Assert.NotNull(SecondEntry);

            }

        }
    }
