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

namespace Goedel.Cryptography.Dare;

public class DareArchive : PersistenceStore {

    public static string ContentType => "mmm-tbs";



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

    public void AddFile(
                string directoryPath,
                string fileName,
                ContentMeta contentMeta = null) {
        throw new NYI();
        }

    public void AddFile(
                Stream data,
                string fileName,
                ContentMeta contentMeta = null) {
        throw new NYI();
        }

    public void AddIndex(
                bool incremental = false) {
        throw new NYI();
        }

    public void AddDirectory(
                string directoryPath,
                DirectoryInfo directoryInfo,
                ContentMeta contentMeta
                ) {
        foreach (var fileInfo in directoryInfo.EnumerateFiles()) {
            AddFile(directoryPath, fileInfo.FullName, contentMeta);
            }
        foreach (var directgoryInfo in directoryInfo.EnumerateDirectories()) {
            AddDirectory(Path.Combine(directoryPath, directgoryInfo.Name), directgoryInfo, contentMeta);
            }
        }


    public void DeleteFile (
                string archivePath
                ) {
        throw new NYI(); 
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
        throw new NYI();
        }


    public void Copy(
                string archivePath,
                bool purge = true
                ) {
        throw new NYI();
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
        using var writer = new DareArchive(archiveName, fileStatus, SequenceType.Digest, policy);
        writer.AddFile("", fileName, contentMeta);
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
            ContentMeta contentMeta = null,
            FileStatus fileStatus = FileStatus.Overwrite,
            bool index = true
            ) {

        using var writer = new DareArchive(archiveName, fileStatus, SequenceType.Merkle, policy);

        var directoryInfo = new DirectoryInfo(directory);
        directoryInfo.Exists.AssertTrue(DirectoryNotFound.Throw);
        writer.AddDirectory(directoryInfo.Name, directoryInfo, contentMeta);

        if (index) {
            writer.AddIndex();
            }
        }

    }
