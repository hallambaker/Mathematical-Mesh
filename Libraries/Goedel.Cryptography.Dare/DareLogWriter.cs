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

namespace Goedel.Cryptography.Dare;

/// <summary>
/// 
/// </summary>
public class DareLogWriter : DareLogReader {


    /// <summary>
    /// The class specific disposal routine.
    /// </summary>
    protected override void Disposing() => Sequence?.Dispose();


    /// <summary>
    /// Open a new file container for write access.
    /// </summary>
    /// <param name="fileName">The file name to create</param>
    /// <param name="archive">If true, the container is intended to be used to create a multi-file
    /// archive.</param>
    /// <param name="digest">If true, construct a digest </param>
    /// <param name="fileStatus">The mode to open the file in, this must be a mode
    /// that permits write access.</param>
    /// <param name="containerType">The container type to use. If unspecified,
    /// a type appropriate for the type of use will be selected.</param>
    /// <returns>File Sequence instance</returns>
    /// <param name="policy">The cryptographic policy to be applied to the container.</param>
    /// <returns>The newly constructed container.</returns>
    public DareLogWriter(
            string fileName,
            DarePolicy policy,
            bool archive = false,
            bool digest = true,
            FileStatus fileStatus = FileStatus.Overwrite,
            SequenceType containerType = SequenceType.Unknown) :
                    this(new JbcdStream(fileName, fileStatus), archive, digest, containerType) => 
        Sequence.DisposeStream = true;


    /// <summary>
    /// Open a new file container for write access.
    /// </summary>
    /// <param name="jbcdStream">The stream to use to write the container.</param>
    /// <param name="archive">If true, the container is intended to be used to create a multi-file
    /// archive.</param>
    /// <param name="digest">If true, construct a digest </param>
    /// <param name="containerType">The container type to use. If unspecified,
    /// a type appropriate for the type of use will be selected.</param>
    /// <returns>File Sequence instance</returns>
    public DareLogWriter(
            JbcdStream jbcdStream,
            bool archive = false,
            bool digest = true,
            SequenceType containerType = SequenceType.Unknown) {

        if (containerType == SequenceType.Unknown) {
            containerType = digest ? archive ? SequenceType.Merkle : SequenceType.Chain :
                archive ? SequenceType.Tree : SequenceType.List;
            }

        if (jbcdStream.Length == 0) {

            Sequence = Sequence.NewContainer(jbcdStream, sequenceType: containerType);
            DictionaryStart = 0;
            }
        else {
            Sequence = Sequence.Open(jbcdStream, null);
            DictionaryStart = Sequence.FrameIndexLast;
            }

        }


    /// <summary>
    /// Append a file entry.
    /// </summary>
    /// <param name="data">The content data</param>
    /// <param name="contentInfo">The content metadata</param>
    public void AddData(
            byte[] data,
            ContentMeta contentInfo = null) => Sequence.Append(data, contentInfo);

    /// <summary>
    /// Add a file entry
    /// </summary>
    /// <param name="basePath">The base path of the file.</param>
    /// <param name="relativePath">The path of the file within the archive.</param>
    /// <param name="contentMeta">Metadata describing the content.</param>
    public void AddFile(
            string basePath,
            string relativePath,
            ContentMeta contentMeta = null) {
        var path = Path.Combine(basePath, relativePath);
        var fileinfo = new FileInfo(path);
        AddFile(basePath, fileinfo, contentMeta);
        }

    /// <summary>
    /// Add a file entry
    /// </summary>
    /// <param name="file">The file to add</param>
    /// <param name="path">The path name attribute to give the file in the container</param>
    /// <param name="contentMeta">Metadata describing the content.</param>
    public void AddFile(
            string path,
            FileInfo file,
            ContentMeta contentMeta = null) {

        var filename = Path.Combine(path, file.Name);
        contentMeta ??= new ContentMeta() {
            Filename = filename,
            };

        var index = Sequence.FrameCount;
        var position = Sequence.PositionWrite;

        Sequence.AppendFile(file.FullName, contentMeta);


        FileCollection.Add(file, contentMeta.Filename, index, position);
        }

    /// <summary>
    /// Delete a file entry
    /// </summary>
    /// <param name="path">The path name attribute to give the file in the container</param>
    public bool Delete(string path) {
        GetIndex();

        if (!FileCollection.DictionaryByPath.TryGetValue(path, out var fileEntry)) {
            return false;
            }

        var contentMeta = new ContentMeta() {
            Filename = path,
            Event = DareConstants.SequenceEventDeleteTag
            };
        var index = Sequence.FrameCount;

        Sequence.Append(contentMeta: contentMeta);

        FileCollection.Delete(path, index);

        return true;
        }

    /// <summary>
    /// Read a container data entry from one container and add it to this one.
    /// </summary>Add 
    /// <param name="containerDataReader">Frame reader from which the
    /// container data is to be read.</param>
    /// <param name="cryptoParameters">The new crypto parameters to be used to 
    /// write the container data.</param>
    public void Add(SequenceFrameIndex containerDataReader,
            CryptoParameters cryptoParameters = null) {
        containerDataReader.Future();
        cryptoParameters.Future();
        this.Future();

        throw new NYI();
        }

    /// <summary>
    /// Append an archive frame to the container.
    /// </summary>
    /// <param name="signatures">List of JWS signatures. Since this is the first block, the signature
    /// is always over the payload data only.</param>
    public void AddIndex(List<KeyPair> signatures = null) {

        GetIndex();
        var index = FileCollection.MakeIndex();

        Sequence.Append(index);


        signatures.Future();
        //throw new NYI();
        }





    /// <summary>
    /// Open a new file container for write access and write a single file entry.
    /// </summary>
    /// <param name="fileName">The file name to create</param>
    /// <param name="data">The content data</param>
    /// <param name="contentMeta">The content metadata</param>
    /// <param name="fileStatus">The mode to open the file in, this must be a mode
    /// that permits write access.</param>
    /// <param name="policy">The cryptographic policy to be applied to the container.</param>
    /// <returns>File Sequence instance</returns>
    public static void ArchiveFile(
            string fileName,
            DarePolicy policy,
            byte[] data,
            ContentMeta contentMeta = null,
            FileStatus fileStatus = FileStatus.Overwrite
            ) {
        using var writer = new DareLogWriter(fileName, policy, true, true, fileStatus, SequenceType.Digest);
        writer.AddData(data, contentMeta);
        }

    /// <summary>
    /// Open a new file container for write access and append all the files in the directory 
    /// <paramref name="directory"/>.
    /// </summary>
    /// <param name="fileName">The file name to create</param>
    /// <param name="directory">The directory to append files from.</param>
    /// <param name="contentMeta">The content metadata</param>
    /// <param name="fileStatus">The mode to open the file in, this must be a mode
    /// that permits write access.</param>
    /// <param name="policy">The cryptographic policy to be applied to the container.</param>
    /// <param name="index">If true add an index record to the end of the archive.</param>
    /// <returns>File Sequence instance</returns>
    public static void ArchiveDirectory(
            string fileName,
            DarePolicy policy,
            string directory,
            ContentMeta contentMeta = null,
            FileStatus fileStatus = FileStatus.Overwrite,
            bool index = true
            ) {

        using var writer = new DareLogWriter(fileName, policy, true, true, fileStatus, SequenceType.Merkle);

        var directoryInfo = new DirectoryInfo(directory);
        directoryInfo.Exists.AssertTrue(DirectoryNotFound.Throw);
        writer.AddDirectory(directoryInfo.Name, directoryInfo, contentMeta);

        if (index) {
            writer.AddIndex();
            }
        }

    /// <summary>
    /// Append all the files in the directory 
    /// <paramref name="directory"/>.
    /// </summary>
    /// <param name="directory">The directory to append files from.</param>
    /// <param name="directoryInfo">The directory descriptor.</param>
    /// <param name="contentMeta">The content metadata</param>
    public void AddDirectory(string directory, DirectoryInfo directoryInfo, ContentMeta contentMeta) {
        foreach (var fileInfo in directoryInfo.EnumerateFiles()) {
            AddFile(directory, fileInfo, contentMeta);

            }
        foreach (var directgoryInfo in directoryInfo.EnumerateDirectories()) {

            AddDirectory(Path.Combine(directory, directgoryInfo.Name), directgoryInfo, contentMeta);

            }
        }
    }
