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


#pragma warning disable IDE0060

using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;

namespace Goedel.Mesh.Test;
public record TestDareFile {
    public string Filename { get; set; }


    public bool Encrypt { get; set; }
    public bool Sign { get; set; }
    public bool Notarize { get; set; }




    public void CheckFiles(
            string file1,
            string file2) {
        }

    public void CheckNotExist(
            string file1) {
        }


    }



public record TestArchive : TestDareFile {

    public static string Archive1 = "Archive1";
    public static readonly List<string> Archive1Files = new List<string>() {
        "DigestSample.txt",
        "Test_Key_RSA_Alice.prv",
        "Test_Key_RSA_Bob.prv",
        "TestKey_Bitvise.bkp",
        "TestKey_OpenSSH.prv",
        "TestKey_OpenSSH.pub"
        };

    public Dictionary<string, TestArchiveEntry> Files { get; set; } = new();

    int tempFile = 0;

    protected string GetTemp() => $"CheckTemp{tempFile++}";

    public void AddFile(string file, string directory) {
        var filename = Path.GetFileName(file);
        var id = Path.Combine(directory, filename);
        var digest = file.Sha3_512();

        var entry = new TestArchiveEntry() {
            Disk = file,
            Filename = filename,
            Directory = directory,
            Deleted = false,
            Erased = false,
            Digest= digest
            };
        Files.Add(id, entry);
        }

    public void Add(string path, string directory) {

        var dirpath = Path.Combine(path, directory);

        foreach (var file in Directory.EnumerateFiles(dirpath)) {
            AddFile(file, directory);
            }


        }

    public void Delete(string file) {
        Files.TryGetValue(file, out var entry).TestTrue();
        entry.Deleted = true;
        }


    public void Erase(string file) {
        Files.TryGetValue(file, out var entry).TestTrue();
        entry.Deleted = true;
        entry.Erased = true;
        }




    public void UnpackDirect(string source, string directory) {
        
        
        }


    public void CheckFile(
                    string file) {
        Files.TryGetValue (file, out var entry).TestTrue();
        CheckFile(entry);
        }

    public virtual void CheckFile(
                    TestArchiveEntry entry) {


        var digest = entry.FullFilename.Sha3_512();
        digest.TestEqual(entry.Digest);
        }

    public virtual void CheckArchive(IKeyLocate keyLocate=null) {
        var directory = Directory.GetCurrentDirectory();

        // create temporary directory
        var tempDirectory = GetTemp();
        Directory.CreateDirectory(tempDirectory);
        Directory.SetCurrentDirectory(tempDirectory);



        // unpack the archive
        DareArchive.UnpackArchive(Filename, keyLocate);

        // check each file.
        foreach (var entry in Files) {
            if (!entry.Value.Deleted) {
                CheckFile(entry.Value);
                }


            }


        Directory.SetCurrentDirectory(directory);
        }


    public void CheckDirectory() {
        var directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
        var count = CheckDirectory("", directoryInfo);

        var check = 0;
        foreach (var file in Files) {
            if (!file.Value.Deleted) {
                check++;
                }
            }

        (check == count).TestTrue();
        }


    int CheckDirectory(
                string directoryPath,
                DirectoryInfo directoryInfo
                ) {
        var count = 0;
        foreach (var fileInfo in directoryInfo.EnumerateFiles()) {
            var filePath = Path.Combine(directoryPath, fileInfo.Name);
            CheckFile(filePath);
            count++;
            }
        foreach (var subDirectoryInfo in directoryInfo.EnumerateDirectories()) {
            var subpath = Path.Combine(directoryPath, subDirectoryInfo.Name);
            count += CheckDirectory(subpath, subDirectoryInfo);
            }



        return count;
        }

    //static void CheckFile(
    //        FileInfo fileInfo,
    //        string path) {
    //    var diskpath = Path.Combine();


    //    }



    public void CheckDirectoryEmpty() {
        throw new NYI();
        }

    }



public record TestArchiveShell : TestArchive {

    public TestCLI Alice { get; set; }
    public TestCLI Bob { get; set; }
    public TestCLI Mallet { get; set; }


    public override void CheckFile(
                    TestArchiveEntry entry) {

        var file = entry.Filename;

        if (!entry.Deleted) {
            var outFile = GetTemp();
            Alice.Dispatch($"archive extract {Filename} {file} /out=${outFile}");
            CheckFiles(file, outFile);
            }
        else {
            var outFile = GetTemp();
            Alice.Dispatch($"archive extract {Filename} {file} /file=${outFile}");
            CheckNotExist(outFile);
            Alice.Dispatch($"archive extract {Filename} {file} /file=${outFile} /recover");
            if (!entry.Erased) {
                CheckFiles(file, outFile);
                }
            else {
                CheckNotExist(outFile);
                }
            }

        }


    public override void CheckArchive(IKeyLocate keyLocate = null) {
        var current = Directory.GetCurrentDirectory();

        // Unpack as Alice - success
        var aliceDir = GetTemp();
        Directory.CreateDirectory(aliceDir);
        Directory.SetCurrentDirectory(aliceDir);
        Alice.Dispatch($"archive extract {Filename}");
        CheckDirectory();
        Directory.SetCurrentDirectory(current);


        // Unpack as Bob - success
        var bobDir = GetTemp();
        Directory.CreateDirectory(bobDir);
        Directory.SetCurrentDirectory(bobDir);
        Bob.Dispatch($"archive extract {Filename}");
        CheckDirectory();
        Directory.SetCurrentDirectory(current);
        if (Encrypt) {
            // Unpack as Mallet - fail

            var malletDir = GetTemp();
            Directory.CreateDirectory(malletDir);
            Directory.SetCurrentDirectory(malletDir);
            Mallet.Dispatch($"archive extract {Filename}", fail: true);
            CheckDirectoryEmpty();
            Directory.SetCurrentDirectory(current);
            }

        }



    }



public record TestArchiveEntry {

    public string FullFilename => Path.Combine(Directory, Filename);

    public string Disk { get; set; }
    public string Filename { get; set; }

    public string Directory { get; set; }

    public bool Deleted { get; set; }

    public bool Erased { get; set; }


    public byte[] Digest { get; set; }
    }
