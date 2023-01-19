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
/// Log reader
/// </summary>
public class DareLogReader : Disposable, IEnumerable<SequenceIndexEntry> {

    ///<summary>The underlying Sequence</summary> 
    public Sequence Sequence { get; protected set; }


    /// <summary>
    /// The class specific disposal routine.
    /// </summary>
    protected override void Disposing() => Sequence?.Dispose();

    /// <summary>
    /// The number of entries in the Sequence. Note that this will have to be 
    /// changed when entries spanning multiple frames are supported.
    /// </summary>
    public long Count => Sequence.FrameCount;

    /// <summary>
    /// Enumerate over the archive contents.
    /// </summary>
    /// <returns>The enumerator</returns>
    public IEnumerator<SequenceIndexEntry> GetEnumerator() => Sequence.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();


    ///<summary>The archive index</summary> 
    public FileCollection FileCollection = new();

    ///<summary>The index position of the first file in the dictionary.</summary> 
    public long DictionaryStart { get; protected set; }


    ///<summary>Base constructor</summary> 
    protected DareLogReader() {
        }


    /// <summary>
    /// Open an existing file Sequence in read mode.
    /// </summary>
    /// <param name="fileName">The file name to read</param>
    /// <param name="fileStatus">The mode to open the file in, this must be a mode
    /// that permits read access.</param>
    /// <param name="keyCollection">Key collection to be used to resolve private key references.</param>
    /// <param name="decrypt">If true attempt to decrypt the Sequence contents.</param>
    /// <returns>File Sequence instance</returns>
    public DareLogReader(
            string fileName,
            IKeyLocate keyCollection = null,
            FileStatus fileStatus = FileStatus.Read, bool decrypt = true) {
        Sequence = Sequence.OpenExisting(fileName, fileStatus, keyCollection, decrypt);
        DictionaryStart = Sequence.FrameIndexLast;
        }

    /// <summary>
    /// Compile an index over the Sequence.
    /// </summary>
    public void GetIndex() {
        foreach (var entry in Sequence) {
            FileCollection.Add(entry.Header, entry.FramePosition);
            }
        }


    /// <summary>
    /// Write the latest entries that match the search criteria to <paramref name="output"/>.
    /// </summary>
    /// <param name="output">Stream to write the matching entries to.</param>
    /// <returns>The number of entries written.</returns>
    public int List(TextWriter output) {
        Sequence.Start();

        int count = 0;
        foreach (var frame in Sequence) {
            var data = frame.GetPayload(Sequence, Sequence.KeyLocate).ToUTF8();
            var created = frame.Header.ContentMeta?.Created;
            output.WriteLine($"[{created}],{data}");
            count++;
            }
        return count;

        }


    /// <summary>
    /// Open a file Sequence and then read and return the last entry in the file.
    /// </summary>
    /// <param name="FileName">The file name to create</param>
    /// <param name="Data">The content data</param>
    /// <param name="ContentMeta">The content metadata</param>
    /// <param name="KeyCollection">Key collection to be used to resolve private key references.</param>
    public static void File(
            string FileName,
            IKeyLocate KeyCollection,
            out byte[] Data,
            out ContentMeta ContentMeta) {

        using var reader = new DareLogReader(FileName, KeyCollection);

        var sequence = reader.Sequence;
        var dataReader = sequence.FrameLast();
        Data = dataReader.GetPayload(sequence, KeyCollection);
        ContentMeta = dataReader?.Header.ContentMeta;
        }


    /// <summary>
    /// Read an entry from a Sequence. 
    /// </summary>
    /// <param name="Data">The data read.</param>
    /// <param name="contentMeta">The metadata of the entry.</param>
    /// <param name="index">Specify the index of the entry to read</param>
    /// <param name="path">Specify a path value of an entry to read.</param>
    /// <param name="keyLocate">Key location instance.</param>
    public void Read(
            IKeyLocate keyLocate,
            out byte[] Data,
            out ContentMeta contentMeta,
            int index = -1,
            string path = null) {
        path.Future();

        var ContainerDataReader = Sequence.Frame(index);
        Data = ContainerDataReader.GetPayload(Sequence, keyLocate);
        contentMeta = ContainerDataReader?.Header.ContentMeta;
        }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="outputFile"></param>
    /// <param name="index"></param>
    /// <param name="path"></param>
    public void ReadToFile(
            string outputFile = null,
            long index = -1,
            string path = null) {
        if (path != null) {
            GetIndex();
            FileCollection.DictionaryByPath.TryGetValue(path, out var entry).AssertTrue(FileNotFound.Throw);
            index = entry.Index;
            }

        var containerDataReader = Sequence.Frame(index);
        containerDataReader.CopyToFile(Sequence, outputFile);
        }

    /// <summary>
    /// Unpack a file archive
    /// </summary>
    /// <param name="outputPath">The output directory path to which the
    /// data is to be written.</param>
    /// <param name="selector">Optional selector to be used for filtering 
    /// (not implemented).</param>
    public void UnpackArchive(
        string outputPath,
        string selector = null) {

        selector.Future();
        GetIndex();
        var outputDirectory = Path.GetFullPath(outputPath) + Path.DirectorySeparatorChar;

        // no, have to iterate over the archive.
        foreach (var entry in FileCollection.DictionaryByPath) {
            var fileEntry = entry.Value;

            // form the path here
            var destination = Path.Combine(outputDirectory, fileEntry.Path);

            var destinationInfo = new FileInfo(destination);
            var destinationDir = destinationInfo.Directory;

            // verify that the destination is a subdirectory of outputDirectory
            destinationDir.FullName.StartsWith(outputDirectory).AssertTrue(NYI.Throw);

            // Create the directory (if needed)
            if (!destinationDir.Exists) {
                Directory.CreateDirectory(destinationDir.FullName);
                }

            // unpack the file
            //Screen.WriteLine($"File: {fileEntry.Path} PositionRead is {fileEntry.Index}");
            var containerDataReader = Sequence.Frame(fileEntry.Index);
            containerDataReader.CopyToFile(Sequence, destination);
            }

        }

    /// <summary>
    /// Copy data from this Sequence to the specified Sequence writer.
    /// </summary>
    /// <param name="fileContainerWriter">The Sequence to be written to.</param>
    public void CopyArchive(DareLogWriter fileContainerWriter) {
        foreach (var ContainerDataReader in Sequence) {
            fileContainerWriter.Add(ContainerDataReader);

            }

        }


    /// <summary>
    /// Perform a Key Exchange
    /// </summary>
    /// <param name="recipients">The list of recipients</param>
    /// <param name="algorithmID">The bulk encryption algorithm</param>
    /// <returns>The result of the key exchange.</returns>
    public virtual byte[] GetExchange(
            List<Recipient> recipients,
            CryptoAlgorithmId algorithmID) => Decrypt(recipients, algorithmID);



    /// <summary>
    /// Attempt to decrypt a decryption blob from a list of recipient entries.
    /// </summary>
    /// <param name="recipients">The recipient entry.</param>
    /// <param name="algorithmID">The symmetric encryption cipher (used to decrypt the wrapped key).</param>
    /// <returns></returns>
    public static byte[] Decrypt(
            List<Recipient> recipients,
            CryptoAlgorithmId algorithmID) {
        foreach (var Recipient in recipients) {

            if (KeyCollection.Default.TryFindKeyDecryption(Recipient.Header.Kid.Trim(), out var DecryptionKey)) {

                // Recipient has the following fields of interest
                // Recipient.EncryptedKey -- The RFC3394 wrapped symmetric key
                // Recipient.Header.Epk  -- The ephemeral public key
                // Recipient.Header.Epk.KeyPair  -- The ephemeral public key

                return DecryptionKey.Decrypt(Recipient.EncryptedKey, Recipient.Header.Epk.KeyPair, algorithmID: algorithmID);
                }
            }


        throw new NoAvailableDecryptionKey();
        }


    }
