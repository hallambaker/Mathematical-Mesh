using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.IO;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;

namespace Goedel.Mesh.Shell {
    public partial class Shell {

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ContainerCreate(ContainerCreate Options) {
            var outputFile = Options.Container.Value;

            var CryptoParameters = new CryptoParameters();
            using (var Writer = new FileContainerWriter(
                    outputFile, CryptoParameters, true, FileStatus: FileStatus.Overwrite)) {
                }

            return new ResultFile() {
                Filename = outputFile
                };
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ContainerArchive(ContainerArchive Options) {
            var inputFile = Options.Input.Value;
            var outputFile = Options.Container.Value;

            var CryptoParameters = new CryptoParameters();

            using (var Writer = new FileContainerWriter(
                    outputFile, CryptoParameters, true, FileStatus: FileStatus.Overwrite)) {

                // Hack: This functionality should be pushed into FileContainerWriter and made recursive, etc.

                var directoryInfo = new DirectoryInfo(inputFile);
                if (directoryInfo.Exists) {
                    foreach (var fileInfo in directoryInfo.EnumerateFiles()) {
                        Writer.Add(fileInfo, Path: fileInfo.Name);
                        }
                    }
                Writer.AddIndex(); // Hack: is not currently indexed.
                }

            return new ResultFile() {
                Filename = outputFile
                };
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ContainerAppend(ContainerAppend Options) {
            var inputFile = Options.File.Value;
            var outputFile = Options.Container.Value;

            var CryptoParameters = new CryptoParameters();
            using (var Writer = new FileContainerWriter(
                    outputFile, CryptoParameters, true, FileStatus: FileStatus.Overwrite)) {
                Writer.Add(inputFile, Path: inputFile);
                }

            return new ResultFile() {
                Filename = inputFile
                };
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ContainerDelete(ContainerDelete Options) {
            var inputFile = Options.File.Value;
            var outputFile = Options.Container.Value;

            var CryptoParameters = new CryptoParameters();
            using (var Writer = new FileContainerWriter(
                    outputFile, CryptoParameters, true, FileStatus: FileStatus.Overwrite)) {
                Writer.Delete(inputFile);
                }

            return new ResultFile() {
                Filename = inputFile
                };
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ContainerIndex(ContainerIndex Options) {
            var inputFile = Options.Container.Value;

            using (var container = Container.Open(
                inputFile, containerType: ContainerType.MerkleTree)) {
                }

            return new ResultFile() {
                Filename = inputFile
                };
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ContainerExtract(ContainerExtract Options) {
            var inputFile = Options.Container.Value;
            var outputFile = Options.Output.Value;

            Directory.CreateDirectory(outputFile);

            using (var reader = new FileContainerReader (inputFile)) {
                foreach (var entry in reader) {
                    var path = Path.Combine(outputFile, entry.Header.Filename);

                    entry.CopyToFile(path);


                    }

                }

            return new ResultFile() {
                Filename = inputFile
                };
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ContainerCopy(ContainerCopy Options) {
            var inputFile = Options.Input.Value;
            var outputFile = Options.Output.Value;

            using (var container = Container.Open(
                inputFile, containerType: ContainerType.MerkleTree)) {
                }

            return new ResultFile() {
                Filename = inputFile
                };
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ContainerVerify(ContainerVerify Options) {
            var inputFile = Options.Container.Value;

            using (var container = Container.Open(
                inputFile, containerType: ContainerType.MerkleTree)) {
                }

            return new ResultFile() {
                Filename = inputFile
                };
            }




        }
    }
