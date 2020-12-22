using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Mesh.Client;
using Goedel.IO;
using Goedel.Utilities;

using System;
using System.Collections.Generic;
using System.IO;


namespace Goedel.Mesh.Shell {
    public partial class Shell {
        static DarePolicy GetPolicy(IKeyLocate keyCollection, IEncodeOptions Options) {
            List<string> recipients = null;
            List<string> signers = null;


            // ToDo: enable specification of multiple recipients in COMMAND
            if (Options.Encrypt != null) {
                if (Options.Encrypt.Value != null) {
                    recipients = new List<string> {
                        Options.Encrypt.Value
                        };
                    }

                }

            // ToDo: enable specification of multiple signers in COMMAND
            if (Options.Sign != null) {
                if (Options.Sign.Value != null) {
                    signers = new List<string> {
                        Options.Sign.Value
                        };
                    }
                }


            var policy = new DarePolicy(keyCollection,
                signers, recipients);

            return policy;
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DareLog(DareLog options) {
            var outputFile = options.Container.Value;

            var keyLocate = GetKeyCollection(options);
            var policy = GetPolicy(keyLocate, options);


            using (var Writer = new DareLogWriter(
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

            var keyLocate = GetKeyCollection(options);
            var policy = GetPolicy(keyLocate, options);

            // should create an archive class as a subset of store.

            DareLogWriter.ArchiveDirectory(outputFile, policy,
                inputFile);


            //using (var Writer = new DareLogWriter(
            //        outputFile, policy, true, fileStatus: FileStatus.Overwrite)) {

            //    // Hack: This functionality should be pushed into FileContainerWriter and made recursive, etc.

            //    var directoryInfo = new DirectoryInfo(inputFile);
            //    if (directoryInfo.Exists) {
            //        foreach (var fileInfo in directoryInfo.EnumerateFiles()) {
            //            Writer.AddFile(relativePath: fileInfo);
            //            }
            //        }
            //    // Hack: is not currently indexed.
            //    // Need to design a proper index!

            //    Writer.AddIndex(); 
            //    }

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

            
            using (var Writer = new DareLogWriter(
                    outputFile, null, true, fileStatus: FileStatus.Existing)) {
                Writer.AddFile("", inputFile);
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


            using (var Writer = new DareLogWriter(
                    outputFile, null, true, fileStatus: FileStatus.Existing)) {
                DareLogWriter.Delete(inputFile);
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

            using (var container = Cryptography.Dare.Sequence.Open(
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

            using (var container = Cryptography.Dare.Sequence.Open(
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
