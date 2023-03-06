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


using Goedel.Test.Core;

[assembly: CollectionBehavior(DisableTestParallelization = true)]


namespace Goedel.XUnit;



public partial class TestDareArchive {


    public static TestDareArchive Test() => new();

    [Fact]
    public void ArchiveTest() {
        TestArchiveCore(false, false, false);

        }


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
