using System;
using System.IO;
using Goedel.Protocol;
using Goedel.Utilities;
using Goedel.Mesh.Portal.Client;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;
using Goedel.IO;
using System.Collections.Generic;

namespace Goedel.Mesh.Shell {
    public partial class ShellDispatch {

        public void ContainerCreate(
                string ContainerName,
                CryptoParameters CryptoParameters
                ) {
            Result Result = null;

            // stuff

            //using (var C1 = Container.NewContainer(Output, FileStatus.New, ContainerType.Chain)) {
            //    }


            using (var C1 = new FileContainerWriter(ContainerName, CryptoParameters, Archive: true, FileStatus: FileStatus.New,
                    ContainerType: ContainerType.Tree)) {
                }

            Result = new Result() {
                Success = true,
                Reason = "Created new container"
                };

            ReportResult(Result);
            }

        public void ContainerArchive(
                CryptoParameters CryptoParameters,
            string ContainerName,
            string Directory) {
            Result Result = null;

            using (var C1 = new FileContainerWriter(ContainerName, CryptoParameters, Archive: true, 
                        FileStatus: FileStatus.Overwrite,
                    ContainerType: ContainerType.Tree)) {

                var DirectoryInfo = new DirectoryInfo(Directory);
                Assert.NotNull(DirectoryInfo, DirectoryNotFound.Throw);

                var FileInfos = DirectoryInfo.EnumerateFiles("*", SearchOption.AllDirectories);


                foreach (var FileInfo in FileInfos) {
                    var RelativeFile = RelativePath(DirectoryInfo, FileInfo);

                    C1.Add(FileInfo, RelativeFile);
                    }

                }

            Result = new Result() {
                Success = true,
                Reason = "Created Device Profile"
                };

            ReportResult(Result);
            }


        public string RelativePath(DirectoryInfo DirectoryInfo, FileInfo FileInfo) {

            var FileName = FileInfo.FullName;
            var DirectoryName = DirectoryInfo.FullName +"\\";

            Assert.True(FileName.StartsWith(DirectoryName));

            var Result = FileName.Remove(0, DirectoryName.Length);

            return Result;
            }

        public void ContainerAppend(
                CryptoParameters CryptoParameters,
                string ContainerName,
                string File) {
            Result Result = null;

            using (var C1 = new FileContainerWriter(ContainerName, 
                        CryptoParameters, 
                        Archive: true, FileStatus: FileStatus.Existing,
                    ContainerType: ContainerType.Tree)) {
                C1.Add(File);
                }

            Result = new Result() {
                Success = true,
                Reason = "Created Device Profile"
                };

            ReportResult(Result);
            }

        public void ContainerExtract(
            KeyCollection KeyCollection,
            string ContainerName,
            string Output,
            int Record = -1,
            string File = null) {
            Result Result = null;

            using (var FileContainerReader = new FileContainerReader(ContainerName, KeyCollection)) {
                if (Record >= 0 | File != null) {

                    FileContainerReader.ReadToFile(Output, Index: Record);
                    }
                else {
                    FileContainerReader.UnpackArchive(Output);

                    }
                }

            Result = new Result() {
                Success = true,
                Reason = "Unpacked archive"
                };

            ReportResult(Result);
            }



        public void ContainerCopy(
                CryptoParameters CryptoParameters,
            string Input,
            string Output,
            bool Decrypt = false,
            bool Index = false,
            bool Purge = true
                ) {
            Result Result = null;

            using (var FileContainerReader = new FileContainerReader(Input, CryptoParameters.KeyCollection)) {
                using (var FileContainerWriter = new FileContainerWriter(Output, CryptoParameters, Archive: true,
                        FileStatus: FileStatus.Overwrite, ContainerType: ContainerType.Tree)) {

                    FileContainerReader.CopyArchive(FileContainerWriter);
                    }
                }

            Result = new Result() {
                Success = true,
                Reason = "Created Device Profile"
                };

            ReportResult(Result);
            }
        public void ContainerVerify(
                KeyCollection KeyCollection,
                string Input) {
            Result Result = null;

            // stuff

            Result = new Result() {
                Success = true,
                Reason = "Created Device Profile"
                };

            ReportResult(Result);
            }
        }
    }
