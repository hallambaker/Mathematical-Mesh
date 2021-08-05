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
using System.IO;

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
        Create = Overwrite,
        /// <summary>Open existing file, abort if file does not exist</summary>
        Existing,
        /// <summary>Open existing file or create new if it does not exist</summary>
        OpenOrCreate,
        /// <summary>Open existing file or create new if it does not exist with shared write permission</summary>
        ConcurrentLocked
        }

    /// <summary>
    /// Extension methods to simplify file operations. While there 
    /// is a combinatorial explosion of file access modes and sharing
    /// permissions, only a few of these combinations make sense.
    /// </summary>
    public static partial class Extension {

        /// <summary>
        /// Delegate method for processing a block of data. The data block is limited in 
        /// size to a 32 bit length.
        /// </summary>
        /// <param name="data">The data to be processed</param>
        /// <param name="offset">Byte offset from the start of the data block.</param>
        /// <param name="count">The number of bytes to process</param>
        public delegate void ProcessBlock32PutDelegate(byte[] data, int offset, int count);

        /// <summary>
        /// Delegate method for processing a block of data. The data block is limited in 
        /// size to a 32 bit length.
        /// </summary>
        /// <param name="data">The data to be processed</param>
        /// <param name="offset">Byte offset from the start of the data block.</param>
        /// <param name="count">The number of bytes to process</param>
        public delegate int ProcessBlock32GetDelegate(byte[] data, int offset, int count);


        /// <summary>
        /// Process data read from the input stream using the specified delegate.
        /// </summary>
        /// <param name="input">The input stream to be read</param>
        /// <param name="process">The delegate to call</param>
        /// <param name="bufferSize">The suggested buffer size.</param>
        public static void ProcessRead(this Stream input, ProcessBlock32PutDelegate process,
                    int bufferSize = 4096) {

            var buffer = new byte[bufferSize];
            var length = input.Read(buffer, 0, bufferSize);
            while (length > 0) {
                process(buffer, 0, length);
                length = input.Read(buffer, 0, bufferSize);
                }

            }

        /// <summary>
        /// Process data read from the input stream using the specified delegate.
        /// </summary>
        /// <param name="output">The input stream to be read</param>
        /// <param name="process">The delegate to call</param>
        /// <param name="bufferSize">The suggested buffer size.</param>
        public static void ProcessWrite(this Stream output, ProcessBlock32GetDelegate process,
                    int bufferSize = 4096) {

            var buffer = new byte[bufferSize];
            var length = process(buffer, 0, bufferSize);
            while (length > 0) {
                output.Write(buffer, 0, length);
                length = process(buffer, 0, bufferSize);
                }

            }

        /// <summary>
        /// Write the specified number of spaces to the output stream
        /// </summary>
        /// <param name="output">Stream to write to</param>
        /// <param name="spaces">Number of spaces to write</param>
        public static void WriteSpaces(this TextWriter output, int spaces) {
            for (var i = 0; i < spaces; i++) {
                output.Write(' ');
                }
            }

        /// <summary>
        /// Open a file stream with the specified file name and status
        /// </summary>
        /// <param name="fileName">The file name</param>
        /// <param name="fileStatus">The file status</param>
        /// <returns>The result</returns>
        public static FileStream FileStream(this string fileName, FileStatus fileStatus) =>
            new(fileName, fileStatus.FileMode(), fileStatus.FileAccess(),
                fileStatus.FileShare());

        /// <summary>
        /// Return the file mode corresponding to the specified status.
        /// </summary>
        /// <param name="fileStatus">Status to translate</param>
        /// <returns>The result</returns>
        public static FileMode FileMode(this FileStatus fileStatus) {
            switch (fileStatus) {
                case FileStatus.Append: {
                    return System.IO.FileMode.Append;
                    }
                case FileStatus.New: {
                    return System.IO.FileMode.CreateNew;
                    }
                case FileStatus.Overwrite: {
                    return System.IO.FileMode.Create;
                    }
                case FileStatus.OpenOrCreate:
                case FileStatus.ConcurrentLocked: {
                    return System.IO.FileMode.OpenOrCreate;
                    }

                case FileStatus.Read:
                break;
                case FileStatus.Existing:
                break;
                default:
                break;
                }
            return System.IO.FileMode.Open;
            }

        /// <summary>
        /// Return the file access mode corresponding to the specified status.
        /// </summary>
        /// <param name="fileStatus">Status to translate</param>
        /// <returns>The result</returns>
        public static FileAccess FileAccess(this FileStatus fileStatus) {
            switch (fileStatus) {
                case FileStatus.Read: {
                    return System.IO.FileAccess.Read;
                    }
                case FileStatus.Append: {
                    return System.IO.FileAccess.Write;
                    }

                case FileStatus.New:
                break;
                case FileStatus.Overwrite:
                break;
                case FileStatus.Existing:
                break;
                case FileStatus.OpenOrCreate:
                break;
                case FileStatus.ConcurrentLocked:
                break;
                default:
                break;
                }
            return System.IO.FileAccess.ReadWrite;
            }


        /// <summary>
        /// Return the file sharing mode corresponding to the specified status.
        /// </summary>
        /// <param name="fileStatus">Status to translate</param>
        /// <returns>The result</returns>
        public static FileShare FileShare(this FileStatus fileStatus) {
            switch (fileStatus) {
                case FileStatus.Read:
                case FileStatus.ConcurrentLocked: {
                    return System.IO.FileShare.ReadWrite;
                    }

                case FileStatus.Append:
                break;
                case FileStatus.New:
                break;
                case FileStatus.Overwrite:
                break;
                case FileStatus.Existing:
                break;
                case FileStatus.OpenOrCreate:
                break;
                default:
                break;
                }
            return System.IO.FileShare.Read;
            }

        /// <summary>
        /// Open a file for read access allowing other processes to read the file..
        /// </summary>
        /// <param name="filename">The file name</param>
        /// <returns>A file stream</returns>
        public static FileStream OpenFileRead(this string filename) =>
                new(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);

        /// <summary>
        /// Open a file for read access in shared mode, allowing concurrent 
        /// reads and writes.
        /// </summary>
        /// <param name="filename">The file name</param>
        /// <returns>A file stream</returns>
        public static FileStream OpenFileReadShared(this string filename) =>
            new(filename, System.IO.FileMode.Open,
                System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite);

        /// <summary>
        /// Create a text reader on a file stream.
        /// </summary>
        /// <param name="fileStream">The base file.</param>
        /// <returns>The text reader.</returns>
        public static TextReader OpenTextReader(this FileStream fileStream) => new StreamReader(fileStream);

        /// <summary>
        /// Create a text reader for a file permitting other processes to
        /// perform concurrent reads.
        /// </summary>
        /// <param name="filename">The file to read.</param>
        /// <returns>The text reader.</returns>
        public static TextReader OpenTextReader(this string filename) {
            var fileStream = filename.OpenFileRead();
            return new StreamReader(fileStream);
            }


        /// <summary>
        /// Create a text reader for a file permitting other processes to
        /// perform concurrent reads.
        /// </summary>
        /// <param name="filename">The file to read.</param>
        /// <returns>The text reader.</returns>
        public static string OpenReadToEnd(this string filename) {
            using var fileStream = filename.OpenFileRead();
            using var reader = new StreamReader(fileStream);
            return reader.ReadToEnd();
            }


        /// <summary>
        /// Create a text reader for a file permitting other processes to
        /// perform concurrent reads.
        /// </summary>
        /// <param name="filename">The file to read.</param>
        /// <param name="data">The data that was read</param>
        /// <returns>The text reader.</returns>
        public static void OpenReadToEnd(this string filename, out byte[] data) {
            using var fileStream = filename.OpenFileRead();
            data = new byte[fileStream.Length];
            fileStream.Read(data, 0, (int)fileStream.Length); // NYI support, test 64 bit file lengths
            }

        /// <summary>
        /// Create a new file for exclusive write access, overwriting 
        /// any existing file.
        /// </summary>
        /// <param name="filename">The new file name.</param>
        /// <returns>File stream to write to the file.</returns>
        public static FileStream OpenFileNew(this string filename) =>
            new(filename, System.IO.FileMode.Create, System.IO.FileAccess.Write);

        /// <summary>
        /// Open an existing file for exclusive write access, or create new file.
        /// </summary>
        /// <param name="filename">The file to write to.</param>
        /// <returns>File stream to write to the file.</returns>
        public static FileStream OpenFileWrite(this string filename) =>
            new(filename, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);

        /// <summary>
        /// Open an existing file for exclusive write access, or create new file.
        /// </summary>
        /// <param name="filename">The file to write to.</param>
        /// <returns>File stream to write to the file.</returns>
        public static FileStream OpenFileReadWrite(this string filename) =>
            new(filename, System.IO.FileMode.OpenOrCreate,
                System.IO.FileAccess.ReadWrite);

        /// <summary>
        /// Open an existing file for exclusive write access, or create new file.
        /// </summary>
        /// <param name="filename">The file to write to.</param>
        /// <returns>File stream to write to the file.</returns>
        public static FileStream OpenFileWriteShare(this string filename) =>
            new(filename, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write,
                System.IO.FileShare.Read);

        /// <summary>
        /// Open a new or existing file for append only write access. Permit
        /// concurrent reads but not writes.
        /// </summary>
        /// <param name="filename">The file to write to.</param>
        /// <returns>File stream to write to the file.</returns>
        public static FileStream OpenFileAppend(this string filename) =>
            new(filename, System.IO.FileMode.Append, System.IO.FileAccess.Write,
                System.IO.FileShare.Read);

        /// <summary>
        /// Open a new or existing file for append only write access. Permit
        /// concurrent reads and writes.
        /// </summary>
        /// <param name="Filename">The file to write to.</param>
        /// <returns>File stream to write to the file.</returns>
        public static FileStream OpenFileAppendShare(this string Filename) =>
            new(Filename, System.IO.FileMode.Append, System.IO.FileAccess.Write,
                System.IO.FileShare.ReadWrite);

        /// <summary>
        /// Open a text writer to the specified file stream.
        /// </summary>
        /// <param name="fileStream">The file stream to write to.</param>
        /// <returns>The text writer.</returns>
        public static TextWriter OpenTextWriter(this FileStream fileStream) => new StreamWriter(fileStream);

        /// <summary>
        /// Open a text writer to the specified file in append mode permitting
        /// shared reads but not writes.
        /// </summary>
        /// <param name="filename">The file to write to.</param>
        /// <returns>The text writer.</returns>
        public static TextWriter OpenTextWriter(this string filename) {
            var fileStream = filename.OpenFileAppend();
            return new StreamWriter(fileStream);
            }
        /// <summary>
        /// Open a text writer to the specified file in append mode permitting
        /// shared reads but not writes.
        /// </summary>
        /// <param name="filename">The file to write to.</param>
        /// <returns>The text writer.</returns>
        public static TextWriter OpenTextWriterNew(this string filename) {
            var fileStream = filename.OpenFileNew();
            return new StreamWriter(fileStream);
            }

        /// <summary>
        /// Create a new file for exclusive write access, overwriting 
        /// any existing file.
        /// </summary>
        /// <param name="filename">The new file name.</param>
        /// <param name="text">Text to write to file.</param>
        /// <returns>File stream to write to the file.</returns>
        public static void WriteFileNew(this string filename, string text) {
            using var outStream = filename.OpenFileNew();
            using var textWriter = new StreamWriter(outStream);
            textWriter.Write(text);
            }

        /// <summary>
        /// Create a new file for exclusive write access, overwriting 
        /// any existing file.
        /// </summary>
        /// <param name="filename">The new file name.</param>
        /// <param name="data">Data to write to file</param>
        /// <returns>File stream to write to the file.</returns>
        public static void WriteFileNew(this string filename, byte[] data) {
            using var outStream = filename.OpenFileNew();
            outStream.Write(data, 0, data.Length);
            }

        /// <summary>
        /// Write binary data to filestream.
        /// </summary>
        /// <param name="FileStream">Filestream to write to</param>
        /// <param name="Data">Data to write.</param>
        public static void Write(this FileStream FileStream, byte[] Data) => FileStream.Write(Data, 0, Data.Length);


        /// <summary>
        /// Create a file with the name <paramref name="fileName"/> and read data from the
        /// stream <paramref name="input"/> and write it to the file.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="fileName"></param>
        public static void CopyToFile(this Stream input, string fileName) {
            using var outputStream = fileName.OpenFileWrite();
            input.CopyTo(outputStream);
            }
        }
    }
