using System;
using System.IO;
using MT=Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Mesh.Shell;
using Goedel.Protocol;
using Goedel.Utilities;
using System.Collections.Generic;
using Goedel.Test;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;

namespace Goedel.Catalog.Test {

    public partial class CatalogTests {




        [MT.TestMethod]

        public void TestContainerSerial() => TestContainerSerial("TestContainerSerial");


        public void TestContainerSerial(
                    string FileTest = "TestContainerSerial",
                    List<string> Recipients = null,
                    List<string> Signers = null) {

            var CryptoParameters = new CryptoParametersTest(
                        Recipients: Recipients,
                        Signers: Signers);
            var KeyCollection = CryptoParameters.KeyCollection;

            var SerialContainer = FileTest + "dcon";

            File.Delete(SerialContainer);
            ShellDispatchCommon.ContainerCreate(SerialContainer, CryptoParameters);
            

            ShellDispatchCommon.ContainerAppend(CryptoParameters, SerialContainer, Source(FileTest1));
            ShellDispatchCommon.ContainerAppend(CryptoParameters, SerialContainer, Source(FileTest2));
            ShellDispatchCommon.ContainerAppend(CryptoParameters, SerialContainer, Source(FileTest3));
            ShellDispatchCommon.ContainerAppend(CryptoParameters, SerialContainer, Source(FileTest4));
            ShellDispatchCommon.ContainerAppend(CryptoParameters, SerialContainer, Source(FileTest5));

            ShellDispatchCommon.ContainerVerify(KeyCollection, SerialContainer);

            ShellDispatchCommon.ContainerExtract( KeyCollection, SerialContainer,  Target(FileTest1), Record: 1);
            Source(FileTest1).CheckFilesEqual(Target(FileTest1));
            ShellDispatchCommon.ContainerExtract(KeyCollection,  SerialContainer,  Target(FileTest2), Record: 2);
            Source(FileTest2).CheckFilesEqual(Target(FileTest2));
            ShellDispatchCommon.ContainerExtract(KeyCollection,  SerialContainer,  Target(FileTest3), Record: 3);
            Source(FileTest3).CheckFilesEqual(Target(FileTest3));
            ShellDispatchCommon.ContainerExtract(KeyCollection,  SerialContainer,  Target(FileTest4), Record: 4);
            Source(FileTest4).CheckFilesEqual(Target(FileTest4));
            ShellDispatchCommon.ContainerExtract(KeyCollection,  SerialContainer,  Target(FileTest5), Record: 5);
            Source(FileTest5).CheckFilesEqual(Target(FileTest5));
            }



        [MT.TestMethod]
        [MT.ExpectedException(typeof(System.IO.IOException))]
        public void TestContainerFail() {

            var CryptoParameters = new CryptoParametersTest();

            var FailContainer = "TestContainerFail.dcon";
            File.Delete(FailContainer);
            ShellDispatchCommon.ContainerCreate(FailContainer, CryptoParameters);


            ShellDispatchCommon.ContainerCreate(FailContainer, CryptoParameters);
            }


        [MT.TestMethod]
        public void TestContainerArchiveBase() => TestContainerArchive("TestContainerArchive");
        public void TestContainerArchive(
                    string FileTest,
                    List<string> Recipients = null,
                    List<string> Signers = null) {

            var CryptoParameters = new CryptoParametersTest(
                        Recipients: Recipients,
                        Signers: Signers);
            var KeyCollection = CryptoParameters.KeyCollection;

            var ArchiveContainer = FileTest + ".dcon";
            var ArchiveContainerCopy = FileTest + "_copy.dcon";

            ShellDispatchCommon.ContainerArchive(CryptoParameters, 
                ArchiveContainer, DirectorySource);
            ShellDispatchCommon.ContainerExtract(KeyCollection, 
                ContainerName: ArchiveContainer, 
                Output: DirectoryArchive);

            DirectorySource.CheckDirectroriesEqual(DirectoryArchive);

            // Defer these tests to later on, that is after we can read a container
            // record in a single pass.

            //ShellDispatchCommon.ContainerCopy(CryptoParameters, 
            //    Input: ArchiveContainer, 
            //    Output: ArchiveContainerCopy);
            //ShellDispatchCommon.ContainerExtract(KeyCollection, 
            //    ContainerName: ArchiveContainer, 
            //    Output: DirectoryArchiveCopy);

            //DirectorySource.CheckDirectroriesEqual(DirectoryArchiveCopy);

            //ShellDispatchCommon.ContainerVerify(KeyCollection, Input: DirectoryArchiveCopy);
            }


        }
    }
