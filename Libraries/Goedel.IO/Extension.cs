using System;
using System.IO;
using System.Collections.Generic;

namespace Goedel.IO {

    /// <summary>Specify the file status</summary>
    public enum FileStatus {
        /// <summary>Open existing file for read only access</summary>
        Read,
        /// <summary>If file exists, use it, otherwise create a new file</summary>
        Append,
        /// <summary>If file exists, throw an error, otherwise create a new file.</summary>
        New,
        /// <summary>If file exists, throw an error, otherwise create a new file.</summary>
        CreateNew = New,
        /// <summary>Create new file overwriting any existing file. (Alias for New.)</summary>
        Overwrite,
        /// <summary>Create new file overwriting any existing file. (Alias for Overwrite.)</summary>
        Create=Overwrite,
        /// <summary>Open existing file, abort if file does not exist</summary>
        Existing
        }

    /// <summary>
    /// Extension methods to simplify file operations. While there 
    /// is a combinatorial explosion of file access modes and sharing
    /// permissions, only a few of these combinations make sense.
    /// </summary>
    public  static partial class Extension {

        /// <summary>
        /// Return the file mode corresponding to the specified status.
        /// </summary>
        /// <param name="FileStatus">Status to translate</param>
        /// <returns>The result</returns>
        public static FileMode FileMode (this FileStatus FileStatus) {
            switch (FileStatus) {
                case FileStatus.Append: {
                    return System.IO.FileMode.Append;
                    }
                case FileStatus.New: {
                    return System.IO.FileMode.CreateNew;
                    }
                case FileStatus.Overwrite: {
                    return System.IO.FileMode.Create;
                    }
                }
            return System.IO.FileMode.Open;
            }

        /// <summary>
        /// Open a file stream with the specified file name and status
        /// </summary>
        /// <param name="FileName">The file name</param>
        /// <param name="FileStatus">The file status</param>
        /// <returns>The result</returns>
        public static FileStream FileStream (this string FileName, FileStatus FileStatus) {
            return new FileStream(FileName, FileStatus.FileMode(), FileStatus.FileAccess(),
                FileStatus.FileShare());
            }

        /// <summary>
        /// Return the file access mode corresponding to the specified status.
        /// </summary>
        /// <param name="FileStatus">Status to translate</param>
        /// <returns>The result</returns>
        public static FileAccess FileAccess (this FileStatus FileStatus) {
            return (FileStatus == FileStatus.Read) ? System.IO.FileAccess.Read : System.IO.FileAccess.ReadWrite;
            }

        /// <summary>
        /// Return the file sharing mode corresponding to the specified status.
        /// </summary>
        /// <param name="FileStatus">Status to translate</param>
        /// <returns>The result</returns>
        public static FileShare FileShare (this FileStatus FileStatus) {
            return (FileStatus == FileStatus.Read) ? System.IO.FileShare.ReadWrite : System.IO.FileShare.Write;
            }

        /// <summary>
        /// Open a file for read access allowing other processes to read the file..
        /// </summary>
        /// <param name="Filename">The file name</param>
        /// <returns>A file stream</returns>
        public static FileStream OpenFileRead(this string Filename) {
            return new FileStream(Filename, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
            }

        /// <summary>
        /// Open a file for read access in shared mode, allowing concurrent 
        /// reads and writes.
        /// </summary>
        /// <param name="Filename">The file name</param>
        /// <returns>A file stream</returns>
        public static FileStream OpenFileReadShared(this string Filename) {
            return new FileStream(Filename, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite);
            }

        /// <summary>
        /// Create a text reader on a file stream.
        /// </summary>
        /// <param name="FileStream">The base file.</param>
        /// <returns>The text reader.</returns>
        public static TextReader OpenTextReader(this FileStream FileStream) {
            return new StreamReader(FileStream);
            }

        /// <summary>
        /// Create a text reader for a file permitting other processes to
        /// perform concurrent reads.
        /// </summary>
        /// <param name="Filename">The file to read.</param>
        /// <returns>The text reader.</returns>
        public static TextReader OpenTextReader (this string Filename) {
            var FileStream = Filename.OpenFileRead();
            return new StreamReader(FileStream);
            }


        /// <summary>
        /// Create a text reader for a file permitting other processes to
        /// perform concurrent reads.
        /// </summary>
        /// <param name="Filename">The file to read.</param>
        /// <returns>The text reader.</returns>
        public static string OpenReadToEnd (this string Filename) {
            var FileStream = Filename.OpenFileRead();
            return new StreamReader(FileStream).ReadToEnd();
            }


        /// <summary>
        /// Create a text reader for a file permitting other processes to
        /// perform concurrent reads.
        /// </summary>
        /// <param name="Filename">The file to read.</param>
        /// <param name="Data">The data that was read</param>
        /// <returns>The text reader.</returns>
        public static void OpenReadToEnd (this string Filename, out byte[] Data) {
            var FileStream = Filename.OpenFileRead();
            Data = new byte[FileStream.Length];
            FileStream.Read(Data, 0, (int)FileStream.Length); // NYI support, test 64 bit file lengths
            }

        /// <summary>
        /// Create a new file for exclusive write access, overwriting 
        /// any existing file.
        /// </summary>
        /// <param name="Filename">The new file name.</param>
        /// <returns>File stream to write to the file.</returns>
        public static FileStream OpenFileNew(this string Filename) {
            return new FileStream(Filename, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            }

        /// <summary>
        /// Open an existing file for exclusive write access, or create new file.
        /// </summary>
        /// <param name="Filename">The file to write to.</param>
        /// <returns>File stream to write to the file.</returns>
        public static FileStream OpenFileWrite(this string Filename) {
            return new FileStream(Filename, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
            }

        /// <summary>
        /// Open an existing file for exclusive write access, or create new file.
        /// </summary>
        /// <param name="Filename">The file to write to.</param>
        /// <returns>File stream to write to the file.</returns>
        public static FileStream OpenFileWriteShare(this string Filename) {
            return new FileStream(Filename, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write,
                System.IO.FileShare.Read);
            }

        /// <summary>
        /// Open a new or existing file for append only write access. Permit
        /// concurrent reads but not writes.
        /// </summary>
        /// <param name="Filename">The file to write to.</param>
        /// <returns>File stream to write to the file.</returns>
        public static FileStream OpenFileAppend(this string Filename) {
            return new FileStream(Filename, System.IO.FileMode.Append, System.IO.FileAccess.Write,
                System.IO.FileShare.Read);
            }

        /// <summary>
        /// Open a new or existing file for append only write access. Permit
        /// concurrent reads and writes.
        /// </summary>
        /// <param name="Filename">The file to write to.</param>
        /// <returns>File stream to write to the file.</returns>
        public static FileStream OpenFileAppendShare(this string Filename) {
            return new FileStream(Filename, System.IO.FileMode.Append, System.IO.FileAccess.Write,
                System.IO.FileShare.ReadWrite);
            }

        /// <summary>
        /// Open a text writer to the specified file stream.
        /// </summary>
        /// <param name="FileStream">The file stream to write to.</param>
        /// <returns>The text writer.</returns>
        public static TextWriter OpenTextWriter(this FileStream FileStream) {
            return new StreamWriter(FileStream);
            }

        /// <summary>
        /// Open a text writer to the specified file in append mode permitting
        /// shared reads but not writes.
        /// </summary>
        /// <param name="Filename">The file to write to.</param>
        /// <returns>The text writer.</returns>
        public static TextWriter OpenTextWriter(this string Filename) {
            var FileStream = Filename.OpenFileAppend();
            return new StreamWriter(FileStream);
            }
        /// <summary>
        /// Open a text writer to the specified file in append mode permitting
        /// shared reads but not writes.
        /// </summary>
        /// <param name="Filename">The file to write to.</param>
        /// <returns>The text writer.</returns>
        public static TextWriter OpenTextWriterNew (this string Filename) {
            var FileStream = Filename.OpenFileNew();
            return new StreamWriter(FileStream);
            }

        /// <summary>
        /// Create a new file for exclusive write access, overwriting 
        /// any existing file.
        /// </summary>
        /// <param name="Filename">The new file name.</param>
        /// <param name="Text">Text to write to file.</param>
        /// <returns>File stream to write to the file.</returns>
        public static void WriteFileNew(this string Filename, string Text) {
            using (var OutStream = Filename.OpenFileNew()) {
                using (var TextWriter = new StreamWriter(OutStream)) {
                    TextWriter.Write(Text);
                    }
                }
            }

        /// <summary>
        /// Create a new file for exclusive write access, overwriting 
        /// any existing file.
        /// </summary>
        /// <param name="Filename">The new file name.</param>
        /// <param name="Data">Data to write to file</param>
        /// <returns>File stream to write to the file.</returns>
        public static void WriteFileNew(this string Filename, byte[] Data) {
            using (var OutStream = Filename.OpenFileNew()) {
                OutStream.Write(Data, 0, Data.Length);
                }
            }

        /// <summary>
        /// Write binary data to filestream.
        /// </summary>
        /// <param name="FileStream">Filestream to write to</param>
        /// <param name="Data">Data to write.</param>
        public static void Write (this FileStream FileStream, byte[] Data) {
            FileStream.Write(Data, 0, Data.Length);
            }
        }
    }
