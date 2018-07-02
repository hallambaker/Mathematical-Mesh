using System;
using System.IO;
using Goedel.Protocol;
using Goedel.Utilities;
using Goedel.Mesh.Portal.Client;
using Goedel.Cryptography.Dare;
using Goedel.IO;
using System.Collections.Generic;

namespace Goedel.Mesh.Shell {
    public partial class ShellDispatch {

        public void ContainerCreate(
                string Output,
                List<string> Recipients = null,
                List<string> Signers = null
                ) {
            Result Result = null;

            // stuff

            using (var C1 = Container.NewContainer(Output, FileStatus.New, ContainerType.Chain)) {
                }

            Result = new Result() {
                Success = true,
                Reason = "Created new container"
                };

            ReportResult(Result);
            }

        public void ContainerArchive(
                string Container,
                string Directory,
                List<string> Recipients = null,
                List<string> Signers = null) {
            Result Result = null;

            // stuff

            Result = new Result() {
                Success = true,
                Reason = "Created Device Profile"
                };

            ReportResult(Result);
            }

        public void ContainerAppend(
                string ContainerName,
                string File,
                List<string> Recipients = null,
                List<string> Signers = null
                ) {
            Result Result = null;

            using (var ContainerInstance = Container.Open(ContainerName, FileStatus.Existing)) {
                ContainerInstance.AppendFile(File);
                }

            Result = new Result() {
                Success = true,
                Reason = "Created Device Profile"
                };

            ReportResult(Result);
            }

        public void ContainerExtract(
                string ContainerName,
                string Output,
                int     Record=-1,
                string File = null
                ) {
            Result Result = null;
            Assert.True(Record >= 0 | File != null, NYI.Throw);

            using (var ContainerInstance = Container.Open(ContainerName, FileStatus.Existing)) {
                if (Record >= 1) {
                    ExtractFile(ContainerInstance, Output, Record);

                    }
                else {
                    throw new NYI(); // extract particular file by name 
                    }


                }



            // stuff

            Result = new Result() {
                Success = true,
                Reason = "Created Device Profile"
                };

            ReportResult(Result);
            }

        void ExtractFile(Container Container, string Output, int Record) {
            var Buffer = new byte[4096];

            Container.Move(Record);
            var TotalLength = Container.ReadDataBegin();

            using (var Filestream = Output.OpenFileWrite()) {

                var Length = Container.ReadData(Buffer, 0, 4096);
                while (Length > 0) {
                    TotalLength -= Length;
                    Filestream.Write(Buffer, 0, Length);
                    Length = Container.ReadData(Buffer, 0, 4096);
                    }
                Assert.True(TotalLength == 0);
                }

            }


        public void ContainerCopy(
                string Input,
                string Output,
                List<string> Recipients = null,
                List<string> Signers = null,
                bool Decrypt=false,
                bool Index=false,
                bool Purge=true
                ) {
            Result Result = null;

            // stuff

            Result = new Result() {
                Success = true,
                Reason = "Created Device Profile"
                };

            ReportResult(Result);
            }
        public void ContainerVerify(
                string Input
                ) {
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
