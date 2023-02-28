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

namespace Goedel.Mesh.Test;
public record TestDareFile {
    public string Filename { get; set; }
    public bool Encrypt { get; set; }
    public bool Sign { get; set; }
    public bool Notarize { get; set; }


    public TestCLI Alice { get; set; }
    public TestCLI Bob { get; set; }
    public TestCLI Mallet { get; set; }

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

    public Dictionary<string, TestArchiveEntry> Files { get; set; }

    int tempFile = 0;

    string GetTemp() => $"Temp{tempFile++}";

    public void AddFile(string file) {
        var entry = new TestArchiveEntry() {
            Filename = file,
            Deleted = false,
            Erased = false
            };
        Files.Add(file, entry);
        }

    public void Add(string directory) {
        foreach (var file in Directory.EnumerateFiles(directory)) {
            AddFile(file);
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





    public void CheckFile(
                string file) {


        Files.TryGetValue(file, out var entry).TestTrue();

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


    public void CheckArchive() {
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


    public void CheckDirectory() {
        throw new NYI();
        }

    public void CheckDirectoryEmpty() {
        throw new NYI();
        }

    }


public record TestArchiveEntry {
    public string Filename { get; set; }
    public bool Deleted { get; set; }


    public bool Erased { get; set; }
    }
