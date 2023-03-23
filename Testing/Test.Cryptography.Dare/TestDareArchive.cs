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
using Goedel.Test.Core;

[assembly: CollectionBehavior(DisableTestParallelization = true)]


namespace Goedel.XUnit;



public partial class TestDareArchive {


    public static TestDareArchive Test() => new();

    [Fact]
    public void ArchiveTest() {
        TestArchiveCore(false, false, false);

        }


    [Fact]
    public void ArchiveRelativeDirectory() {
        var seed = DeterministicSeed.AutoClean();
        var archiveFile = seed.GetTempFilePath();
        var sourceDir = TestEnvironmentBase.CommonData;
        var sourcePath = TestArchive.Archive1;

        using (var archive = new DareArchive(archiveFile)) {


            Xunit.Assert.Throws<RelativeDirectoryInvalid>(() =>
                    AttemptAddRelativeDirectory(archive, sourceDir));
            ForceAddRelativeDirectory(archive, sourceDir);
            }

        // attempting to unpack should throw error
        Xunit.Assert.Throws<RelativeDirectoryInvalid>(() => DareArchive.UnpackArchive(archiveFile));


        }

    static void AttemptAddRelativeDirectory(DareArchive archive, string sourceDir) {
        var directory = "../CommonDate" ;
        archive.AddDirectory(sourceDir, directory);
        }

    static void ForceAddRelativeDirectory(DareArchive archive, string sourceDir) {
        var directory = "../CommonDate";
        AddDirectoryForce(archive, sourceDir, directory);

        }

    #region // Forced add file to archive without checking directory path is valid.

    static void AddDirectoryForce(
                    DareArchive archive,
                    string diskPath,
                    string directoryPath) {
        var path = Path.Combine(diskPath, directoryPath);
        var directoryInfo = new DirectoryInfo(diskPath);


        AddDirectoryForce(archive, directoryPath, directoryInfo);
        }

    static void AddDirectoryForce(
            DareArchive archive,
            string directoryPath,
            DirectoryInfo directoryInfo
            ) {

        foreach (var fileInfo in directoryInfo.EnumerateFiles()) {
            AddFileForce(archive, directoryPath, fileInfo);
            }

        foreach (var subDirectoryInfo in directoryInfo.EnumerateDirectories()) {
            var subpath = Path.Combine(directoryPath, subDirectoryInfo.Name);
            AddDirectoryForce(archive, subpath, subDirectoryInfo);
            }
        }

    /// <summary>
    /// Add the file <paramref name="fileInfo"/> into the archive with the directory 
    /// path prefix <paramref name="directoryPath"/>.
    /// </summary>
    /// <param name="directoryPath"></param>
    /// <param name="fileInfo"></param>
    static ArchiveIndexEntry AddFileForce(
                DareArchive archive,
                string directoryPath,
                FileInfo fileInfo,
                ContentMeta contentMeta = null) {

        // here we build the ContentMeta entry
        contentMeta ??= new();
        contentMeta.Filename = fileInfo.Name;
        contentMeta.FileEntry = new FileEntry() {
            Path = directoryPath,
            CreationTime = fileInfo.CreationTime,
            LastAccessTime = fileInfo.LastAccessTime,
            LastWriteTime = fileInfo.LastWriteTime,
            Attributes = (int)fileInfo.Attributes
            };
        contentMeta.UniqueId = Path.Combine(directoryPath, fileInfo.Name);
        contentMeta.Event = DareConstants.SequenceEventNewTag;

        using var stream = fileInfo.FullName.OpenFileReadShared();
        return AddFileForce(archive, stream, stream.Length, contentMeta);
        }

    static ArchiveIndexEntry AddFileForce(
            DareArchive archive,
            Stream data,
            long length,
            ContentMeta contentMeta = null) {

        var result = archive.Sequence.AppendFromStream(data, length, contentMeta) as
                    ArchiveIndexEntry;

        return result;
        }

    #endregion

    static void TestArchiveCore(
                    bool encrypt,
                    bool sign,
                    bool notarize,
                    int length = 1000,
                    bool every = false) {
        var seed = DeterministicSeed.AutoClean(encrypt, sign, notarize, length);
        var sourceDir = TestEnvironmentBase.CommonData;
        var sourcePath = TestArchive.Archive1;
        var deleteFile = Path.Combine(sourcePath, "Test_Key_RSA_Alice.prv");
        var eraseFile = Path.Combine(sourcePath, "Test_Key_RSA_Bob.prv");

        var archiveFile = seed.GetTempFilePath();

        var testArchive = new TestArchive() {
            Filename = archiveFile,
            Encrypt = encrypt,
            Sign = sign,
            Notarize = notarize,
            };

        var archive = new DareArchive(archiveFile);

        archive.AddDirectory(sourceDir, sourcePath);
        testArchive.Add(sourceDir, sourcePath);
        archive = CheckArchive(archive, testArchive, every);

        // check one file individually
        //testArchive.CheckFile(deleteFile);

        // add a file
        var testFile = seed.GetTempFileName();
        seed.MakeTestFile(testFile, length);
        archive.AddFile("", "", testFile);
        testArchive.AddFile(testFile, "");
        archive = CheckArchive(archive, testArchive, every);

        var testFileRecover = seed.GetTempFilePath();
        archive.GetFile(testFile, testFileRecover);
        seed.CheckTestFile(testFile, length);
        seed.CheckTestFile(testFileRecover, length);

        // delete a file
        archive.Delete(deleteFile);
        testArchive.Delete(deleteFile);
        archive = CheckArchive(archive, testArchive, every);

        // check file recovery works

        if (encrypt) {
            // Erasure only works when we are using an encrypted file.

            archive.Delete(eraseFile, erase: true);
            testArchive.Erase(eraseFile);
            archive = CheckArchive(archive, testArchive, every);

            // check file recovery fails


            // Erase the previously deleted file
            archive.Delete(deleteFile, erase: true);
            testArchive.Erase(deleteFile);

            // check file recovery fails


            }

        archive.Dispose();
        testArchive.CheckArchive();
        }


    static DareArchive CheckArchive(DareArchive archive, TestArchive shaddow, bool every =true) {
        if (!every) {
            return archive;
            }
        archive.Dispose();

        shaddow.CheckArchive();

        return new DareArchive(shaddow.Filename);
        }
    }
