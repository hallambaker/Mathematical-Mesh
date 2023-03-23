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

using Goedel.IO;
using System.IO;
using System.Runtime;
using System.Runtime.InteropServices;

namespace Goedel.Cryptography.Dare;

public class ArchiveIndexEntry : PersistentIndexEntry {

    public ContentMeta ContentMeta  => Header?.ContentMeta;

    public FileEntry FileEntry => ContentMeta?.FileEntry;
    public override bool IsDeleted => IsErased | Event == DareConstants.SequenceEventDeleteTag;

    public override bool IsErased => Event == DareConstants.SequenceEventEraseTag;
    ///<inheritdoc/>
    public override JsonObject JsonObject {
        get => Header.ContentMeta;
        set => _ = value;
        }


    /// <summary>
    /// Factory method implementing <see cref="SequenceIndexEntryFactoryDelegate"/>.
    /// </summary>
    /// <inheritdoc cref="SequenceIndexEntryFactoryDelegate"/>
    public static new SequenceIndexEntry Factory(
            Sequence sequence,
            long framePosition,
            long frameLength,
            long dataPosition,
            long dataLength,
            DareHeader header,
            DareTrailer trailer = null,
            JsonObject jsonObject = null
            ) => new ArchiveIndexEntry(sequence) {
                FramePosition = framePosition,
                FrameLength = frameLength,
                DataPosition = dataPosition,
                DataLength = dataLength,
                Header = header,
                Trailer = trailer
                };


    /// <summary>
    /// Constructor returning a in instance bound to the sequence <paramref name="sequence"/>
    /// </summary>
    /// <param name="sequence">The sequence the index is bound to.</param>
    ArchiveIndexEntry(Sequence sequence) {
        (sequence?.Store as DareArchive).AssertNotNull(NYI.Throw);
        Sequence = sequence;
        }

    }


public class DareArchive : PersistenceStore {

    public static string ContentType => "mmm-tbs";
    public override SequenceIndexEntryFactoryDelegate SequenceIndexEntryFactory =>
                ArchiveIndexEntry.Factory;

    public DareArchive(
                string fileName,
                FileStatus fileStatus = FileStatus.OpenOrCreate,
                SequenceType sequenceType = SequenceType.Merkle,
                DarePolicy policy = null,
                DataEncoding dataEncoding = DataEncoding.JSON,
                IKeyLocate keyLocate = null,
                bool read = true) : base(fileName, ContentType, fileStatus, sequenceType,
                    policy, dataEncoding, keyLocate, read, false) {
        }



    public override void Intern(SequenceIndexEntry indexEntry) {
        var entry = indexEntry as ArchiveIndexEntry;

        base.Intern(indexEntry);



        }


    public ArchiveIndexEntry AddFile(
                string diskPath,
                string directoryPath,
                string fileName,
                ContentMeta contentMeta = null) {
        var file = Path.Combine(diskPath, directoryPath, fileName);
        var fileInfo = new FileInfo(file);

        return AddFile(directoryPath, fileInfo, contentMeta);
        }

    /// <summary>
    /// Add the file <paramref name="fileInfo"/> into the archive with the directory 
    /// path prefix <paramref name="directoryPath"/>.
    /// </summary>
    /// <param name="directoryPath"></param>
    /// <param name="fileInfo"></param>
    public ArchiveIndexEntry AddFile(
                string directoryPath,
                FileInfo fileInfo,
                ContentMeta contentMeta = null) {

        // here we build the ContentMeta entry
        contentMeta ??= new();
        contentMeta.Filename = fileInfo.Name;
        contentMeta.FileEntry = new FileEntry() {
            Path = directoryPath,
            CreationTime= fileInfo.CreationTime,
            LastAccessTime= fileInfo.LastAccessTime,
            LastWriteTime= fileInfo.LastWriteTime,
            Attributes = (int) fileInfo.Attributes
            };
        contentMeta.UniqueId = Path.Combine(directoryPath, fileInfo.Name);
        contentMeta.Event = DareConstants.SequenceEventNewTag;

        using var stream = fileInfo.FullName.OpenFileReadShared();
        return AddFile(stream, stream.Length, contentMeta);
        }



    public ArchiveIndexEntry AddFile(
                Stream data,
                long length,
                ContentMeta contentMeta = null) {

        var result = Sequence.AppendFromStream(data, length, contentMeta) as
                    ArchiveIndexEntry;

        return result;
        }

    public void AddIndex(
                bool incremental = false) {
        throw new NYI();
        }


    public void AddDirectory(
                        string diskPath,
                        string directoryPath) {
        var path = Path.Combine(diskPath, directoryPath);
        var directoryInfo = new DirectoryInfo (path);


        AddDirectory(directoryPath, directoryInfo);
        }



    public void AddDirectory(
                string directoryPath,
                DirectoryInfo directoryInfo
                ) {

        CheckPathIsValid(directoryPath);

        foreach (var fileInfo in directoryInfo.EnumerateFiles()) {
            AddFile(directoryPath, fileInfo);
            }

        foreach (var subDirectoryInfo in directoryInfo.EnumerateDirectories()) {
            var subpath = Path.Combine(directoryPath, subDirectoryInfo.Name);
            AddDirectory(subpath, subDirectoryInfo);
            }
        }


    public byte[] GetBytes(
                string archivePath,
                bool recover = false) {

        using var input = GetStream(archivePath);
        using var output = new MemoryStream();


        input.CopyTo(output);
        return output.ToArray();
        }


    public bool GetFile(
                string archivePath,
                string outputPath,
                bool recover = false
                ) {
        try {
            using var input = GetStream(archivePath);
            input.CopyToFile(outputPath);
            return true;
            }
        catch {
            return false;
            }
        }

    public bool GetFiles(
                string outputPath
                ) {



        throw new NYI();
        }

    public Stream GetStream(
                string archivePath
                ) {
        ObjectIndex.TryGetValue( archivePath, out var entry ).AssertTrue(NYI.Throw);

        var stream = entry.GetPayloadStreamn(Sequence, KeyLocate);

        return stream;

        }


    public void Copy(
                string archivePath,
                bool purge = true
                ) {
        throw new NYI();
        }


    public override bool Delete(string uniqueID, Transaction transaction = null, bool erase = false) {
        var envelope = PrepareDelete(out var Previous, uniqueID);
        if (envelope == null) {
            return false;
            }
        Sequence.Append(envelope);

        if (erase) {
            // here we are going to parse the header and erase the salt value.
            throw new NYI();
            }

        return true;
        }



    /// <summary>
    /// Open a new file Sequence for write access and write a single file entry.
    /// </summary>
    /// <param name="archiveName">The file name to create</param>
    /// <param name="fileName">The file name to create</param>
    /// <param name="data">The content data</param>
    /// <param name="contentMeta">The content metadata</param>
    /// <param name="fileStatus">The mode to open the file in, this must be a mode
    /// that permits write access.</param>
    /// <param name="policy">The cryptographic policy to be applied to the Sequence.</param>
    /// <returns>File Sequence instance</returns>
    public static void ArchiveFile(
            string archiveName,
            string fileName,
            DarePolicy policy,
            ContentMeta contentMeta = null,
            FileStatus fileStatus = FileStatus.Append
            ) {

        "Fix here".TaskFunctionality(true);
        //using var writer = new DareArchive(archiveName, fileStatus, SequenceType.Digest, policy);
        //writer.AddFile("", fileName, contentMeta);
        }

    /// <summary>
    /// Open a new file Sequence for write access and append all the files in the directory 
    /// <paramref name="directory"/>.
    /// </summary>
    /// <param name="archiveName">The file name to create</param>
    /// <param name="directory">The directory to append files from.</param>
    /// <param name="contentMeta">The content metadata</param>
    /// <param name="fileStatus">The mode to open the file in, this must be a mode
    /// that permits write access.</param>
    /// <param name="policy">The cryptographic policy to be applied to the Sequence.</param>
    /// <param name="index">If true add an index record to the end of the archive.</param>
    /// <returns>File Sequence instance</returns>
    public static void ArchiveDirectory(
            string archiveName,
            DarePolicy policy,
            string directory,
            string sourceDir = null,
            ContentMeta contentMeta = null,
            FileStatus fileStatus = FileStatus.Overwrite,
            bool index = true
            ) {
        sourceDir ??= "";
        using var archive = new DareArchive(archiveName, policy: policy);
        archive.AddDirectory(sourceDir, directory);
        }


    readonly static char[] SplitChars = new[] {
        Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar
        };

    void CheckPathIsValid(string path) {
        if (Path.IsPathRooted(path)) {
            throw new RelativeDirectoryInvalid();
            }
        var split = path.Split(SplitChars);
        foreach (var element in split) {
            if (element == "..") {
                throw new RelativeDirectoryInvalid();
                }
            }

        }

    void Unpack(ArchiveIndexEntry index) {
        var contentMeta = index.JsonObject as ContentMeta;
        var fileEntry = contentMeta.FileEntry;

        CheckPathIsValid(index.UniqueID);


        if (fileEntry.Path is not null && fileEntry.Path != "") {
            Directory.CreateDirectory(fileEntry.Path);
            }

        var stream = index.GetPayloadStreamn(Sequence, KeyLocate);
        stream.CopyToFile(index.UniqueID);
        // create the directory


        }

    public void UnpackArchive() {
        foreach (var file in ObjectIndex) {
            var index = file.Value as ArchiveIndexEntry;


            if (!index.IsDeleted) {
                Unpack(index);
                }

            }
        }


    public static void UnpackArchive (
                    string archiveName,
                    IKeyLocate keyLocate=null) {
        using var reader = new DareArchive(archiveName);

        reader.UnpackArchive();


        }


    }
