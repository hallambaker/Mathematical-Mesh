using Goedel.Cryptography.Dare;
using Goedel.IO;
using Goedel.Utilities;

using System.IO;

namespace Goedel.Mesh.Shell {
    public partial class Shell {
        static DarePolicy GetPolicy(Goedel.Command.Dispatch Options) => throw new NYI();

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DareLog(DareLog options) {
            var outputFile = options.Container.Value;

            var policy = GetPolicy(options);


            using (var Writer = new FileContainerWriter(
                    outputFile, policy, true, fileStatus: FileStatus.Overwrite)) {
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
        public override ShellResult DareArchive(DareArchive options) {
            var inputFile = options.Input.Value;
            var outputFile = options.Container.Value;

            var policy = GetPolicy(options);

            // should create an archive class as a subset of store.

            using (var Writer = new FileContainerWriter(
                    outputFile, policy, true, fileStatus: FileStatus.Overwrite)) {

                // Hack: This functionality should be pushed into FileContainerWriter and made recursive, etc.

                var directoryInfo = new DirectoryInfo(inputFile);
                if (directoryInfo.Exists) {
                    foreach (var fileInfo in directoryInfo.EnumerateFiles()) {
                        Writer.Add(fileInfo, path: fileInfo.Name);
                        }
                    }
                // Hack: is not currently indexed.
                // Need to design a proper index!

                FileContainerWriter.AddIndex(); 
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
        public override ShellResult DareAppend(DareAppend options) {
            var inputFile = options.File.Value;
            var outputFile = options.Container.Value;

            
            using (var Writer = new FileContainerWriter(
                    outputFile, null, true, fileStatus: FileStatus.Existing)) {
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
        public override ShellResult DareDelete(DareDelete options) {
            var inputFile = options.Filename.Value;
            var outputFile = options.Container.Value;


            using (var Writer = new FileContainerWriter(
                    outputFile, null, true, fileStatus: FileStatus.Existing)) {
                FileContainerWriter.Delete(inputFile);
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
        public override ShellResult DareIndex(DareIndex options) {
            var inputFile = options.Container.Value;

            using (var container = Cryptography.Dare.Container.Open(
                inputFile, containerType: ContainerType.Merkle)) {
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
        public override ShellResult DareExtract(DareExtract options) {
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
        public override ShellResult DareCopy(DareCopy options) {
            var inputFile = options.Input.Value;
            var outputFile = options.Output.Value;

            using (var container = Cryptography.Dare.Container.Open(
                inputFile, containerType: ContainerType.Merkle)) {
                }

            return new ResultFile() {
                Filename = inputFile
                };
            }


        ///// <summary>
        ///// Dispatch method
        ///// </summary>
        ///// <param name="options">The command line options.</param>
        ///// <returns>Mesh result instance</returns>
        //public override ShellResult DareVerify(ContainerVerify options) {
        //    var inputFile = options.Container.Value;

        //    using (var container = Cryptography.Dare.Container.Open(
        //        inputFile, containerType: ContainerType.MerkleTree)) {
        //        }

        //    return new ResultFile() {
        //        Filename = inputFile
        //        };
        //    }




        }
    }
