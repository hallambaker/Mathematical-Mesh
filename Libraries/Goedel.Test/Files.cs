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
using System.Threading;
namespace Goedel.Test;

public static class Files {

    static int FileCount = 0;

    public static string GetFilenameUnique(string prefix = "TestData-", string suffix = ".txt") {
        var fileCount = Interlocked.Increment(ref FileCount);
        return prefix + fileCount.ToString() + suffix;
        }

    public static string ToFileUnique(this object data, string prefix = "TestData-", string suffix = ".txt") {
        var filename = GetFilenameUnique(prefix, suffix);
        filename.WriteFileNew(data.ToString());
        return filename;
        }




    public static void CheckFilesEqual(this string File1, string File2) {

        using var FileStream1 = File1.OpenFileRead();
        using var FileStream2 = File2.OpenFileRead();
        FileStreamEquals(FileStream1, FileStream2).TestTrue();
        }

    public static void CheckDirectroriesEqual(this string Directory1, string Directory2) {
        var DirInfo1 = new DirectoryInfo(Directory1);
        var DirInfo2 = new DirectoryInfo(Directory2);
        CheckDirectroriesEqual(DirInfo1, DirInfo2);
        }


    public static void CheckDirectroriesEqual(DirectoryInfo DirInfo1, DirectoryInfo DirInfo2) {

        var FileDictionary = new Dictionary<string, FileInfo>();
        var DirectoryDictionary = new Dictionary<string, DirectoryInfo>();

        var Files1 = DirInfo1.GetFiles();
        var Files2 = DirInfo2.GetFiles();
        var Sub1 = DirInfo1.GetDirectories();
        var Sub2 = DirInfo2.GetDirectories();

        (Files1.Length == Files2.Length).TestTrue();
        (Sub1.Length == Sub2.Length).TestTrue();

        //Check the files in the directories
        foreach (var File in Files1) {
            FileDictionary.Add(File.Name, File);
            }
        foreach (var File2 in Files2) {
            FileDictionary.TryGetValue(File2.Name, out var File1).TestTrue();
            CheckFilesEqual(File1.FullName, File2.FullName);
            FileDictionary.Remove(File1.Name);
            }

        // Check the subdirectories
        foreach (var File in Sub1) {
            DirectoryDictionary.Add(File.Name, File);
            }
        foreach (var File2 in Sub2) {
            DirectoryDictionary.TryGetValue(File2.Name, out var File1).TestTrue();
            CheckDirectroriesEqual(File1.FullName, File2.FullName);
            FileDictionary.Remove(File1.Name);
            }
        }

    public static bool FileStreamEquals(Stream Stream1, Stream Stream2) {
        using BufferedStream BufferedStream1 = new(Stream1);
        using BufferedStream BufferedStream2 = new(Stream2);
        while (true) {
            var B1 = BufferedStream1.ReadByte();
            var B2 = BufferedStream2.ReadByte();

            if (B1 != B2) {
                return false;
                }
            if (B1 < 0) {
                return true;
                }
            }
        }


    }
