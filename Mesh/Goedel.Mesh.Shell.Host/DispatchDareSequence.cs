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
        public override ShellResult DareSequence(DareSequence options) {
            var outputFile = options.Sequence.Value;

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
            var outputFile = options.Sequence.Value;
            var index = options.Index.Value;

            var keyLocate = GetKeyCollection(options);
            var policy = GetPolicy(keyLocate, options);

            DareLogWriter.ArchiveDirectory(outputFile, policy, inputFile, index:index);

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
            var outputFile = options.Sequence.Value;
            var index = options.Index.Value;
            var key = options.Key.Value;

            using (var Writer = new DareLogWriter(
                    outputFile, null, true, fileStatus: FileStatus.Existing)) {

                ContentMeta contentMeta = null;
                if (key != null) {
                    contentMeta = new ContentMeta() {
                        Filename = key
                        };
                    }

                Writer.AddFile("", inputFile, contentMeta);
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
        public override ShellResult DareLog(DareLog options) {

            var outputFile = options.Sequence.Value;
            var Entry = options.Entry.Value;

            using var Writer = new DareLogWriter(
                    outputFile, null, true, fileStatus: FileStatus.Existing);


            var data = Entry.ToUTF8();
            var contentMeta = new ContentMeta() {
                Created = DateTime.Now
                };

            Writer.AddData(data, contentMeta );

            return new ResultLog() {
                Count = (int)Writer.Sequence.FrameCount
                };
            }



        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DareDelete(DareDelete options) {
            var inputFile = options.Filename.Value;
            var outputFile = options.Sequence.Value;


            using (var writer = new DareLogWriter(
                    outputFile, null, true, fileStatus: FileStatus.Existing)) {
                writer.Delete(inputFile);
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
            var inputFile = options.Sequence.Value;
            var contextAccount = GetContextUser(options);

            using (var writer = new DareLogWriter(inputFile, null)) {
                writer.GetIndex();
                writer.AddIndex();
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
        public override ShellResult DareList(DareList options) {
            var inputFile = options.Sequence.Value;
            var outputFile = options.Output.Value;
            var contextAccount = GetContextUser(options);

            using var reader = new DareLogReader(inputFile, contextAccount);
            using var output = outputFile.OpenTextWriterNew();

            var count = reader.List(output);

            var result = new ResultListLog() {
                Filename = outputFile,
                Count = count
                };

            return result;
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DareDir(DareDir options) {
            var inputFile = options.Sequence.Value;
            var contextAccount = GetContextUser(options);

            using var reader = new DareLogReader(inputFile, contextAccount);
            reader.GetIndex();

            var result = new ResultArchive() {
                Entries = new List<FileEntry>(),
                Frames = (int) reader.Sequence.FrameCount,
                //IndexFrame = reader.Sequence.Index,
                //Deleted = reader.Sequence.Deleted
                };

            foreach (var entry in reader.FileCollection.DictionaryByPath) {
                result.Entries.Add(entry.Value);
                }

            return result;
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DareExtract(DareExtract options) {
            var inputFile = options.Sequence.Value;
            var outputFile = options.Output.Value;
            var file = options.Filename.Value;

            var contextAccount = GetContextUser(options);
            using var reader = new DareLogReader(inputFile, contextAccount);
            
            if (file != null) {
                outputFile ??= Path.GetFileName(file);
                reader.ReadToFile(outputFile, path:file);

                return new ResultFile() {
                    Filename = file
                    };
                }
            else {
                reader.UnpackArchive(outputFile);
                return new ResultFile() {
                    Filename = outputFile
                    };
                }

            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DarePurge(DarePurge options) {
            var inputFile = options.Input.Value;
            var outputFile = options.Output.Value;
            var index = options.Index.Value;

            using (var container = Cryptography.Dare.Sequence.Open(
                inputFile, sequenceType: SequenceType.Merkle)) {
                }

            return new ResultFile() {
                Filename = inputFile
                };
            }




        }
    }
