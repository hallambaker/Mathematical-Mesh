using System;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using Goedel.Utilities;
using Goedel.IO;
namespace Goedel.Test {
    public static class Files {

        static int FileCount= 0;
        public static string ToFileUnique(this object data, string prefix = "TestData-", string suffix = ".txt") {
            var fileCount = Interlocked.Increment(ref FileCount);
            var filename = prefix + fileCount.ToString() + suffix;

            filename.WriteFileNew(data.ToString());
            return filename;
            }


        public static void CheckFilesEqual(this string File1, string File2) {

            using (var FileStream1 = File1.OpenFileRead()) {
                using (var FileStream2 = File2.OpenFileRead()) {
                    Assert.True(FileStreamEquals(FileStream1, FileStream2));
                    }
                }
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

            Assert.True(Files1.Length == Files2.Length);
            Assert.True(Sub1.Length == Sub2.Length);

            //Check the files in the directories
            foreach (var File in Files1) {
                FileDictionary.Add(File.Name, File);
                }
            foreach (var File2 in Files2) {
                Assert.True(FileDictionary.TryGetValue(File2.Name, out var File1));
                CheckFilesEqual(File1.FullName, File2.FullName);
                FileDictionary.Remove(File1.Name);
                }

            // Check the subdirectories
            foreach (var File in Sub1) {
                DirectoryDictionary.Add(File.Name, File);
                }
            foreach (var File2 in Sub2) {
                Assert.True(DirectoryDictionary.TryGetValue(File2.Name, out var File1));
                CheckDirectroriesEqual(File1.FullName, File2.FullName);
                FileDictionary.Remove(File1.Name);
                }
            }

        public static bool FileStreamEquals(Stream Stream1, Stream Stream2) {
            using (BufferedStream BufferedStream1 = new BufferedStream(Stream1)) {
                using (BufferedStream BufferedStream2 = new BufferedStream(Stream2)) {
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
            }


        }
    }
