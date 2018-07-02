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

        [MT.TestMethod]
        public void TestContainerSerial() {

            var SerialContainer = "TestContainerSerial.dcon";
            File.Delete(SerialContainer);
            ShellDispatchCommon.ContainerCreate(SerialContainer);
            

            ShellDispatchCommon.ContainerAppend(SerialContainer, Source(FileTest1));
            ShellDispatchCommon.ContainerAppend(SerialContainer, Source(FileTest2));
            ShellDispatchCommon.ContainerAppend(SerialContainer, Source(FileTest3));
            ShellDispatchCommon.ContainerAppend(SerialContainer, Source(FileTest4));
            ShellDispatchCommon.ContainerAppend(SerialContainer, Source(FileTest5));

            ShellDispatchCommon.ContainerVerify(SerialContainer);

            ShellDispatchCommon.ContainerExtract(SerialContainer, Target(FileTest1), 1);
            Source(FileTest1).CheckFilesEqual(Target(FileTest1));
            ShellDispatchCommon.ContainerExtract(SerialContainer, Target(FileTest2), 2);
            Source(FileTest2).CheckFilesEqual(Target(FileTest2));
            ShellDispatchCommon.ContainerExtract(SerialContainer, Target(FileTest3), 3);
            Source(FileTest3).CheckFilesEqual(Target(FileTest3));
            ShellDispatchCommon.ContainerExtract(SerialContainer, Target(FileTest4), 4);
            Source(FileTest4).CheckFilesEqual(Target(FileTest4));
            ShellDispatchCommon.ContainerExtract(SerialContainer, Target(FileTest5), 5);
            Source(FileTest5).CheckFilesEqual(Target(FileTest5));
            }



        [MT.TestMethod]
        [MT.ExpectedException(typeof(System.IO.IOException))]
        public void TestContainerFail() {

            var FailContainer = "TestContainerFail.dcon";
            File.Delete(FailContainer);
            ShellDispatchCommon.ContainerCreate(FailContainer);


            ShellDispatchCommon.ContainerCreate(FailContainer);
            }


        [MT.TestMethod]
        public void TestContainerArchive() {

            var ArchiveContainer = "TestContainerArchive.dcon";
            var ArchiveContainerCopy = "TestContainerArchiveCopy.dcon";

            ShellDispatchCommon.ContainerArchive(ArchiveContainer, DirectorySource);
            ShellDispatchCommon.ContainerExtract(ArchiveContainer, DirectoryArchive);

            DirectorySource.CheckDirectroriesEqual(DirectoryArchive);

            ShellDispatchCommon.ContainerCopy(ArchiveContainer, ArchiveContainerCopy);
            ShellDispatchCommon.ContainerExtract(ArchiveContainer, DirectoryArchiveCopy);

            DirectorySource.CheckDirectroriesEqual(DirectoryArchiveCopy);

            ShellDispatchCommon.ContainerVerify(DirectoryArchiveCopy);
            // note, we do not currently check the Decrypt, Index or purge options.
            }


        }
    }
