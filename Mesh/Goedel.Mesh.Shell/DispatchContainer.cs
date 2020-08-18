using Goedel.Cryptography.Dare;
using Goedel.IO;
using Goedel.Utilities;

using System.IO;

namespace Goedel.Mesh.Shell {
    public partial class Shell {

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ContainerCreate(ContainerCreate options) {
            var outputFile = options.Container.Value;

            var CryptoParameters = new CryptoParameters();
            using (var Writer = new FileContainerWriter(
                    outputFile, CryptoParameters, true, fileStatus: FileStatus.Overwrite)) {
                }

            return new ResultFile() {
                Filename = outputFile
                };
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ContainerArchive(ContainerArchive options) {
            var inputFile = options.Input.Value;
            var outputFile = options.Container.Value;

            var CryptoParameters = new CryptoParameters();

            // should create an archive class as a subset of store.

            using (var Writer = new FileContainerWriter(
                    outputFile, CryptoParameters, true, fileStatus: FileStatus.Overwrite)) {

                // Hack: This functionality should be pushed into FileContainerWriter and made recursive, etc.

                var directoryInfo = new DirectoryInfo(inputFile);
                if (directoryInfo.Exists) {
                    foreach (var fileInfo in directoryInfo.EnumerateFiles()) {
                        Writer.Add(fileInfo, path: fileInfo.Name);
                        }
                    }
                // Hack: is not currently indexed.
                // Need to design a proper index!

                Writer.AddIndex(); 
                }

            return new ResultFile() {
                Filename = outputFile
                };
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ContainerAppend(ContainerAppend options) {
            var inputFile = options.File.Value;
            var outputFile = options.Container.Value;

            var CryptoParameters = new CryptoParameters();
            using (var Writer = new FileContainerWriter(
                    outputFile, CryptoParameters, true, fileStatus: FileStatus.Overwrite)) {
                Writer.Add(inputFile, path: inputFile);
                }

            return new ResultFile() {
                Filename = inputFile
                };
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ContainerDelete(ContainerDelete options) {
            var inputFile = options.Filename.Value;
            var outputFile = options.Container.Value;

            var CryptoParameters = new CryptoParameters();
            using (var Writer = new FileContainerWriter(
                    outputFile, CryptoParameters, true, fileStatus: FileStatus.Overwrite)) {
                Writer.Delete(inputFile);
                }

            return new ResultFile() {
                Filename = inputFile
                };
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ContainerIndex(ContainerIndex options) {
            var inputFile = options.Container.Value;

            using (var container = Cryptography.Dare.Container.Open(
                inputFile, containerType: ContainerType.MerkleTree)) {
                }

            return new ResultFile() {
                Filename = inputFile
                };
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ContainerExtract(ContainerExtract options) {
            var inputFile = options.Container.Value;
            var outputFile = options.Output.Value;

            Directory.CreateDirectory(outputFile);

            throw new NYI();

            //using (var reader = new FileContainerReader (inputFile)) {
            //    foreach (var entry in reader) {
            //        var path = Path.Combine(outputFile, entry.Header.Filename);

            //        entry.CopyToFile(path);


            //        }

            //    }

            //return new ResultFile() {
            //    Filename = inputFile
            //    };
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ContainerCopy(ContainerCopy options) {
            var inputFile = options.Input.Value;
            var outputFile = options.Output.Value;

            using (var container = Cryptography.Dare.Container.Open(
                inputFile, containerType: ContainerType.MerkleTree)) {
                }

            return new ResultFile() {
                Filename = inputFile
                };
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ContainerVerify(ContainerVerify options) {
            var inputFile = options.Container.Value;

            using (var container = Cryptography.Dare.Container.Open(
                inputFile, containerType: ContainerType.MerkleTree)) {
                }

            return new ResultFile() {
                Filename = inputFile
                };
            }




        }
    }
