using System;
using System.Collections.Generic;
using System.IO;
using Goedel.Utilities;
using Goedel.IO;
namespace Goedel.Test {
    public static class Files {

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

            var Files1 = DirInfo1.GetFiles();
            var Files2 = DirInfo2.GetFiles();
            var Sub1 = DirInfo1.GetDirectories();
            var Sub2 = DirInfo2.GetDirectories();

            Assert.True(Files1.Length == Files2.Length);
            Assert.True(Sub1.Length == Sub2.Length);

            Array.Sort(Files1);
            Array.Sort(Files2);
            Array.Sort(Sub1);
            Array.Sort(Sub2);


            for (var i = 0; i < Files1.Length; i++) {
                Assert.True(Files1[i].Name == Files2[i].Name);
                CheckFilesEqual(
                        Path.Combine(DirInfo1.FullName, Files1[i].Name),
                        Path.Combine(DirInfo2.FullName, Files1[i].Name));
                }

            for (var i = 0; i < Sub1.Length; i++) {
                CheckDirectroriesEqual(Sub1[i], Sub2[i]);
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
