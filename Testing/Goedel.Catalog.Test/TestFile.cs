using System;
using System.IO;
using MT=Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Mesh.Shell;
using Goedel.Protocol;
using Goedel.Utilities;
using System.Collections.Generic;
using Goedel.Test;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;

namespace Goedel.Catalog.Test {

    public partial class CatalogTests {



        string Source(string File) => DirectorySource + @"\" + File;
        string Encrypted(string File) => DirectoryEncrypted + @"\" + File;
        string Decrypted(string File) => DirectoryDecrypted + @"\" + File;
        List<string> Recipients = new List<string>();
        List<string> Signers = new List<string>();



        //KeyCollection MakeKeyCollection(
        //                    List<string> Recipients,
        //                    List<string> Signers) {

        //    var KeyCollection = new KeyCollection();

        //    return KeyCollection;
        //    }


        //CryptoStack MakeCryptoStack(
        //                    KeyCollection Known,
        //                    KeyCollection Unknown,
        //                    List<string> Recipients,
        //                    List<string> Signers) {
        //    var CryptoStack = new CryptoStack();

        //    return CryptoStack;
        //    }


        [MT.TestMethod]
        public void TestFile() => TestFile("Plaintext");

        [MT.TestMethod]
        public void TestFileEncrypt() => TestFile("Encrypted", Recipients: Recipients);

        [MT.TestMethod]
        public void TestFileSign() => TestFile("Signed", Signers: Signers);

        [MT.TestMethod]
        public void TestFileSignEncrypt() => TestFile("SignedEncrypted", Recipients: Recipients, Signers: Signers);

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

            var CryptoParameters = new CryptoParametersTest(
                        Recipients: Recipients,
                        Signers: Signers);

            var Original = Source(FileTest);
            var Encoded = Encrypted(Prefix + FileTest);
            var Decoded = Decrypted(Prefix + FileTest);


            // encrypt file
            ShellDispatchCommon.FileEncrypt(CryptoParameters, Original, Encrypted(Prefix + FileTest));
            // decrypt file
            ShellDispatchCommon.FileDecrypt(CryptoParameters.KeyCollection,
                Encoded, Decoded);
            Original.CheckFilesEqual(Decoded);

            }



        }
    }
