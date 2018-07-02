using System;
using System.IO;
using MT=Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Mesh.Shell;
using Goedel.Protocol;
using Goedel.Utilities;
using System.Collections.Generic;
using Goedel.Test;

namespace Goedel.Catalog.Test {

    public partial class CatalogTests {



        string Source(string File) => DirectorySource + @"\" + File;
        string Encrypted(string File) => DirectoryEncrypted + @"\" + File;
        string Decrypted(string File) => DirectoryDecrypted + @"\" + File;
        List<string> Recipients = new List<string>();
        List<string> Signers = new List<string>();

        [MT.TestMethod]
        public void TestFile() => TestFile("");

        [MT.TestMethod]
        public void TestFileEncrypt() => TestFile("", Recipients: Recipients);

        [MT.TestMethod]
        public void TestFileSign() => TestFile("", Signers: Signers);

        [MT.TestMethod]
        public void TestFileSignEncrypt() => TestFile("", Recipients: Recipients, Signers: Signers);

        [MT.TestMethod]
        public void TestFileMulti() {
            FileMulti(FileTest1);
            FileMulti(FileTest2);
            FileMulti(FileTest3);
            FileMulti(FileTest4);
            FileMulti(FileTest5);
            }


        public void FileMulti(string FileTest) {
            TestFile("", FileTest);
            TestFile("", FileTest, Signers: Signers);
            TestFile("", FileTest, Recipients: Recipients, Signers: Signers);
            }

        [MT.TestMethod]
        public void TestFileRecrypt() => TestFile("");


        public void TestFile(string Prefix, string FileTest= FileTest1,
                    List<string> Recipients = null,
                    List<string> Signers = null) {
            Assert.Null(Recipients);     // NYI: so fail this test immediately// NYI: so fail this test immediately
            Assert.Null(Signers);        // NYI: so fail this test immediately

            // encrypt file
            ShellDispatchCommon.FileEncrypt(Source(FileTest), Encrypted(Prefix+FileTest));
            // decrypt file
            ShellDispatchCommon.FileDecrypt(Encrypted(Prefix+FileTest), Decrypted(Prefix+FileTest));
            Source(FileTest).CheckFilesEqual(Decrypted(Prefix+FileTest));

            }



        }
    }
