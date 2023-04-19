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


/// <summary>
/// Oersistent index of an archive entry.
/// </summary>
public class ArchiveIndexEntry : PersistentIndexEntry {

    ///<summary>The content metadata.</summary> 
    public ContentMeta ContentMeta  => Header?.ContentMeta;

    ///<summary>The file entry data.</summary> 
    public FileEntry FileEntry => ContentMeta?.FileEntry;

    ///<summary>If true, the item has been deleted from the archive. It may be 
    ///possible to recover it if it has not been erased.</summary> 
    public override bool IsDeleted => IsErased | Event == DareConstants.SequenceEventDeleteTag;

    ///<summary>If true, the item has been deleted and erased from the archive and 
    ///cannot be recovered.</summary> 
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
        (sequence?.InternDelegate as DareArchive).AssertNotNull(NYI.Throw);
        Sequence = sequence;
        }

    }

/// <summary>
/// A DARE archive handle.
/// </summary>
public class DareArchive : PersistenceStore {

    ///<summary>The IANA content type of the archive.</summary> 
    public static string ContentType => "mmm-tbs";

    ///<inheritdoc/>
    public override SequenceIndexEntryFactoryDelegate SequenceIndexEntryFactory =>
                ArchiveIndexEntry.Factory;

    /// <summary>
    /// Constructor returning an instance from <paramref name="fileName"/>.
    /// </summary>
    /// <param name="fileName">The file name.</param>
    /// <param name="fileStatus">The file status.</param>
    /// <param name="sequenceType">The sequence type (usually Merkle Tree).</param>
    /// <param name="policy">The default security policy.</param>
    /// <param name="dataEncoding">The data encoding for headers and trailers.</param>
    /// <param name="keyLocate">Key location instance.</param>
    /// <param name="read">If true, load the entire archive contents on opening.</param>
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

    ///<inheritdoc/>
    public override void Intern(SequenceIndexEntry indexEntry) {
        var entry = indexEntry as ArchiveIndexEntry;

        base.Intern(indexEntry);
        }

    /// <summary>
    /// Add the file <paramref name="fileName"/> in disk directory <paramref name="diskPath"/>
    /// to the archive at archive directory <paramref name="directoryPath"/> with content
    /// metadata <paramref name="contentMeta"/>
    /// </summary>
    /// <param name="diskPath">The source path directory.</param>
    /// <param name="directoryPath">The archive directory path.</param>
    /// <param name="fileName">The file name.</param>
    /// <param name="contentMeta">The content metadata to associate with the file.</param>
    /// <returns>The archive index entry.</returns>
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
    /// <param name="directoryPath">The archive directory path.</param>
    /// <param name="fileInfo">The source file.</param>
    /// <param name="contentMeta">The content metadata to associate with the file.</param>
    /// <returns>The archive index entry.</returns>
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


    /// <summary>
    /// Add data from the stream <paramref name="dataStream"/> of length <paramref name="length"/>
    /// into the archive with content metadata <paramref name="contentMeta"/>.
    /// </summary>
    /// <param name="dataStream">The data stream.</param>
    /// <param name="length">Length of the data stream. This must be known in advance as there
    /// is (currently) no provision for indefinite length archive entries.</param>
    /// <param name="contentMeta">The content metadata to associate with the file.</param>
    /// <returns>The archive index entry.</returns>
    public ArchiveIndexEntry AddFile(
                Stream dataStream,
                long length,
                ContentMeta contentMeta = null) {

        var result = Sequence.AppendFromStream(dataStream, length, contentMeta) as
                    ArchiveIndexEntry;

        return result;
        }

    /// <summary>
    /// Add an index to the end of the archive.
    /// </summary>
    /// <param name="incremental">If true, write an incremental archive.</param>
    /// <exception cref="NYI">Not currently implemented.</exception>
    public void AddIndex(
                bool incremental = false) {
        throw new NYI();
        }

    /// <summary>
    /// Add files from the directory <paramref name="diskPath"/> to the archive at
    /// directory <paramref name="directoryPath"/>.
    /// </summary>
    /// <param name="diskPath">The source path directory.</param>
    /// <param name="directoryPath">The archive directory path.</param>
    public void AddDirectory(
                        string diskPath,
                        string directoryPath) {
        var path = Path.Combine(diskPath, directoryPath);
        var directoryInfo = new DirectoryInfo (path);


        AddDirectory(directoryPath, directoryInfo);
        }


    /// <summary>
    /// Add files from the directory <paramref name="directoryInfo"/> to the archive at
    /// directory <paramref name="directoryPath"/>.
    /// </summary>
    /// <param name="directoryInfo">The source path directory.</param>
    /// <param name="directoryPath">The archive directory path.</param>
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

    /// <summary>
    /// Extract the file <paramref name="archivePath"/> from the archive and
    /// write to <paramref name="outputPath"/>.
    /// </summary>
    /// <param name="archivePath">The path of the file within the archive.</param>
    /// <param name="outputPath">Destination to write the file to.</param>
    /// <param name="recover">If true, attempt to recover a file marked as deleted.</param>
    /// <returns>True if the file is found, otherwise false.</returns>
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

    /// <summary>
    /// Locate the file <paramref name="archivePath"/> from the archive and
    /// return a stream reading it.
    /// </summary>
    /// <param name="archivePath">The path of the file within the archive.</param>
    /// <returns>Stream reader reading the file.</returns>
    public Stream GetStream(
                string archivePath
                ) {
        ObjectIndex.TryGetValue( archivePath, out var entry ).AssertTrue(NYI.Throw);

        var stream = entry.GetPayloadStreamn(Sequence, KeyLocate);

        return stream;

        }


    /// <summary>
    /// Copy the contents of the archive to a newly created archive <paramref name="outputPath"/>.
    /// If <paramref name="purge"/> is true, remove deleted items.
    /// </summary>
    /// <param name="outputPath">The new archive file to be created.</param>
    /// <param name="purge">If true, do not copy deleted items.</param>
    /// <exception cref="NYI"></exception>
    public void Copy(
                string outputPath,
                bool purge = true
                ) {
        throw new NYI();
        }


    ///<inheritdoc/>
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
    /// <paramref name="sourceDir"/>.
    /// </summary>
    /// <param name="archiveName">The file name to create</param>
    /// <param name="sourceDir">The directory to append files from.</param>
    /// <param name="directory">The directory in the archive.</param>
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

    void Unpack(ArchiveIndexEntry index,
                string directory = null) {
        var contentMeta = index.JsonObject as ContentMeta;
        var fileEntry = contentMeta.FileEntry;

        CheckPathIsValid(index.UniqueID);

        var targetDir = directory == null? Directory.GetCurrentDirectory() : directory;
        targetDir = fileEntry.Path.IsBlank() ? targetDir: Path.Combine(targetDir, fileEntry.Path);
        Directory.CreateDirectory(targetDir);

        var destination = Path.Combine (targetDir, contentMeta.Filename);
        

        using var stream = index.GetPayloadStreamn(Sequence, KeyLocate);
        stream.CopyToFile(destination);
        // create the directory


        }

    /// <summary>
    /// Unpack the archive.
    /// </summary>
    /// <param name="directory">Directory to extract the archive to.</param>
    public void UnpackArchive(
                string directory = null) {
        foreach (var file in ObjectIndex) {
            var index = file.Value as ArchiveIndexEntry;

            if (!index.IsDeleted) {
                Unpack(index, directory);
                }

            }
        }

    /// <summary>
    /// Unpack the archive, <paramref name="archiveName"/>, 
    /// </summary>
    /// <param name="archiveName">Archive filename.</param>
    /// <param name="keyLocate">The key collection to use for decryption of the contents.</param>
    /// <param name="directory">Directory to extract the archive to.</param>
    public static void UnpackArchive (
                    string archiveName,
                    IKeyLocate keyLocate=null,
                    string directory = null) {
        using var reader = new DareArchive(archiveName);

        reader.UnpackArchive(directory);


        }


    }
