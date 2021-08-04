#region // Copyright
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
using System.IO;
using System.Text;

namespace Goedel.Utilities {
    public static partial class Extension {

        /// <summary>
        /// Parse file path and return canonical unix path. Relative directory references will
        /// be consolidated if possible thus a\..\..\b will become ..\b.
        /// </summary>
        /// <param name="Path">The path to transform</param>
        /// <returns>The transformed path.</returns>
        public static string UnixCanonicalPath(this string Path) {
            var Directories = Path.Split('\\');

            for (var i = 0; i < Directories.Length; i++) {
                if (Directories[i] == "." | Directories[i] == "") {
                    Directories[i] = null;
                    }
                else if (Directories[i] == "..") {
                    if (StrikeDirectory(Directories, i)) {
                        Directories[i] = null;
                        }
                    }

                }

            var Builder = new StringBuilder();
            foreach (var Directory in Directories) {
                if (Directory != null) {
                    Builder.Append(Directory);
                    Builder.Append('/');
                    }
                }

            return Builder.ToString();
            }


        static bool StrikeDirectory(string[] Directories, int Index) {
            for (var i = Index - 1; i >= 0; i--) {
                if (Directories[i] != null) {
                    Directories[i] = null;
                    return true;
                    }
                }
            return false;

            }

        /// <summary>
        /// Combine a base file path and sujbdirectory path and return a unix file path.
        /// </summary>
        /// <param name="File">The base file path.</param>
        /// <param name="Sub">The subdirectory</param>
        /// <returns>The combined file path</returns>
        public static string UnixPath(this string File, string Sub) {
            var FilePath = Path.Combine(File, Sub);
            var Directory = Path.GetDirectoryName(FilePath);
            return Directory.Replace('\\', '/'); ;
            }

        /// <summary>
        /// Return the path for a file as a unix file path.
        /// </summary>
        /// <param name="File">The windows file path</param>
        /// <returns>The corresponding unix path.</returns>
        public static string UnixPath(this string File) {
            var Directory = Path.GetDirectoryName(File);
            return Directory.Replace('\\', '/'); ;
            }

        /// <summary>
        /// Convert Windows file path to Unix.
        /// </summary>
        /// <param name="File">Windows file path</param>
        /// <returns>Unix file path.</returns>
        public static string UnixFile(this string File) {
            return File.Replace('\\', '/'); ;
            }

        /// <summary>
        /// Combine a base file path and sujbdirectory path and return a unix path for the file.
        /// </summary>
        /// <param name="File">The base file path.</param>
        /// <param name="Sub">The subdirectory</param>
        /// <returns>The combined file path</returns>
        public static string UnixFile(this string File, string Sub) {
            var FilePath = Path.Combine(File, Sub);
            return FilePath.Replace('\\', '/'); ;
            }
        }
    }
