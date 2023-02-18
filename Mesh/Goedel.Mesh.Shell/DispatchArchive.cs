#region // Copyright - MIT License
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
    public override ShellResult DareArchiveC(DareArchiveC options) {
        var inputFile = options.Input.Value;
        var outputFile = options.Sequence.Value;
        var index = options.Index.Value;

        var keyLocate = GetKeyCollection(options);
        var policy = GetPolicy(keyLocate, options);

        DareArchive.ArchiveDirectory(outputFile, policy, inputFile, index: index);

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
        var id = options.Id.Value;
        var keyLocate = GetKeyCollection(options);

        using (var archive = new DareArchive(
                inputFile, fileStatus: FileStatus.Existing, keyLocate: keyLocate)) {

            ContentMeta contentMeta = null;
            if (id != null) {
                contentMeta = new ContentMeta() {
                    Filename = id
                    };
                }

            archive.AddFile("", inputFile, contentMeta);

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
    public override ShellResult DareDelete(DareDelete options) {
        var inputFile = options.Filename.Value;
        var outputFile = options.Sequence.Value;
        var keyLocate = GetKeyCollection(options);
        var erase = options.Erase.Value;


        using (var archive = new DareArchive(
                inputFile, fileStatus: FileStatus.Existing, keyLocate: keyLocate)) {
            archive.Delete(inputFile, erase:erase);
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
        var keyLocate = GetKeyCollection(options);

        using (var archive = new DareArchive(
                inputFile, fileStatus: FileStatus.Existing, keyLocate: keyLocate)) {
            archive.AddIndex();
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
    public override ShellResult DareDir(DareDir options) {
        var inputFile = options.Sequence.Value;
        var keyLocate = GetKeyCollection(options);

        using (var archive = new DareArchive(
                inputFile, fileStatus: FileStatus.Existing, keyLocate: keyLocate)) {

            var result = new ResultArchive() {
                Entries = new List<FileEntry>(),
                Frames = (int)archive.FrameCount,
                //IndexFrame = reader.Sequence.Index,
                //Deleted = reader.Sequence.Deleted
                };

            foreach (var entry in archive.ObjectIndex) {
                throw new NYI();
                //result.Entries.Add(entry.Value);
                }

            return result;
            }
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
        var recover = options.Recover.Value;

        var keyLocate = GetKeyCollection(options);

        using (var archive = new DareArchive(
                inputFile, fileStatus: FileStatus.Existing, keyLocate: keyLocate)) {

            if (file != null) {
                outputFile ??= Path.GetFileName(file);
                archive.GetFile(file, outputFile, recover);

                return new ResultFile() {
                    Filename = file
                    };
                }
            else {
                archive.GetFiles(outputFile);
                return new ResultFile() {
                    Filename = outputFile
                    };
                }
            }
        }


    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult DareCopy(DareCopy options) {
        var inputFile = options.Input.Value;
        var outputFile = options.Output.Value;
        var index = options.Index.Value;
        var keyLocate = GetKeyCollection(options);

        using (var archive = new DareArchive(
                inputFile, fileStatus: FileStatus.Existing, keyLocate: keyLocate)) {

            archive.Copy(inputFile);


            return new ResultFile() {
                Filename = inputFile
                };
            }


        }

    }
