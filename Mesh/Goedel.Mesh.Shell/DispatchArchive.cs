﻿#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion


using Goedel.Cryptography;
using Goedel.Mesh.Client;

namespace Goedel.Mesh.Shell;

public partial class Shell {
    static DarePolicy GetPolicy(IKeyLocate keyCollection, IEncodeOptions Options) {
        List<string> recipients = null;
        List<string> signers = null;


        // ToDo: enable specification of multiple recipients in COMMAND

        if (Options.Encrypt?.Value != null) {
            recipients = new List<string> {
                        Options.Encrypt.Value
                        };
            }


        if (Options.Self?.Value != null) {
            recipients ??= new List<string>();
            recipients.Add(Options.Self.Value);
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
    public override ShellResult ArchiveCreate(ArchiveCreate options) {
        var inputFile = options.Input.Value;
        var archiveFile = options.Archive.Value;
        var index = options.Index.Value;

        var keyLocate = GetKeyCollection(options);
        var policy = GetPolicy(keyLocate, options);

        if (inputFile == null) {
            _ = new DareArchive(
                inputFile, fileStatus: FileStatus.New, keyLocate: keyLocate, policy:policy);
            }
        else {
            var sourceDirectory = Path.GetFileName(inputFile);
            var sourcePath = Path.GetDirectoryName(inputFile);

            DareArchive.ArchiveDirectory(archiveFile, policy, sourceDirectory,
                            sourcePath, index: index);
            }



        return new ResultFile() {
            Filename = archiveFile
            };
        }

    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult ArchiveAppend(ArchiveAppend options) {
        var archiveFile = options.Archive.Value;
        var inputFile = options.File.Value;
        var index = options.Index.Value;
        var id = options.Id.Value;
        var keyLocate = GetKeyCollection(options);

        using (var archive = new DareArchive(
                archiveFile, fileStatus: FileStatus.Existing, keyLocate: keyLocate)) {

            var fileInfo = new FileInfo(inputFile);

            //var inputFileName = Path.GetFileName(inputFile);

            archive.AddFile(fileInfo.Directory.FullName, "", fileInfo.Name);

            if (index) {
                archive.AddIndex();
                }
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
    public override ShellResult ArchiveDelete(ArchiveDelete options) {
        var inputFile = options.Filename.Value;
        var archiveFile = options.Archive.Value;
        var keyLocate = GetKeyCollection(options);
        var erase = options.Erase.Value;


        using (var archive = new DareArchive(
                archiveFile, fileStatus: FileStatus.Existing, keyLocate: keyLocate)) {
            archive.Delete(inputFile, erase:erase);
            }

        return new ResultFile() {
            Filename = archiveFile
            };
        }

    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult ArchiveIndex(ArchiveIndex options) {
        var archiveFile = options.Archive.Value;
        var keyLocate = GetKeyCollection(options);

        using (var archive = new DareArchive(
                archiveFile, fileStatus: FileStatus.Existing, keyLocate: keyLocate)) {
            archive.AddIndex();
            }

        return new ResultFile() {
            Filename = archiveFile
            };
        }

    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult ArchiveDir(ArchiveDir options) {
        var archiveFile = options.Archive.Value;
        var keyLocate = GetKeyCollection(options);

        using (var archive = new DareArchive(
                archiveFile, fileStatus: FileStatus.Existing, keyLocate: keyLocate)) {

            var result = new ResultArchive() {
                Entries = new List<FileEntry>(),
                Frames = (int)archive.FrameCount,
                IndexFrame = (int) archive.Sequence.FrameCount,
                };

            foreach (var entry in archive.ObjectIndex) {
                var archiveEntry = entry.Value as ArchiveIndexEntry;
                result.Entries.Add(archiveEntry.FileEntry);
                }

            return result;
            }
        }

    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult ArchiveExtract(ArchiveExtract options) {
        var archiveFile = options.Archive.Value;

        var file = options.File.Value;
        var output = options.Out.Value;




        var recover = options.Recover.Value;

        var keyLocate = GetKeyCollection(options);

        using (var archive = new DareArchive(
                archiveFile, fileStatus: FileStatus.Existing, keyLocate: keyLocate)) {

            if (file != null) {
                output ??= Path.GetFileName(file);
                archive.GetFile(file, output, recover);

                return new ResultFile() {
                    Filename = file
                    };
                }
            else {
                archive.UnpackArchive(output);
                return new ResultFile() {
                    Filename = output
                    };
                }
            }
        }


    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult ArchiveCopy(ArchiveCopy options) {
        var archiveFile = options.Archive.Value;
        var outputFile = options.Output.Value;
        var index = options.Index.Value;
        var keyLocate = GetKeyCollection(options);

        using (var archive = new DareArchive(
                archiveFile, fileStatus: FileStatus.Existing, keyLocate: keyLocate)) {

            archive.Copy(outputFile);


            return new ResultFile() {
                Filename = outputFile
                };
            }


        }

    }
