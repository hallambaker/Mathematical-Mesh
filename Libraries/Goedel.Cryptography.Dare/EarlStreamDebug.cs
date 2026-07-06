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
namespace Goedel.Cryptography.Dare;

/// <summary>Debugging version of <see cref="VDareStream"/>, emits diagnostic information.</summary>
public class EarlStreamDebug : VDareStream {


    EarlStreamDebug(
            string fileName,
            FileMode fileMode,
            FileAccess fileAccess,
            FileShare fileShare,
                Stream stream = null) : base(fileName, fileMode, fileAccess, fileShare, stream) {
        int data = Stream.ReadByte();
        int count = 0;
        while (data >= 0) {

            Console.Write($"{data} ");

            if ((++count % 16) == 0) {
                Console.WriteLine();
                }
            data = Stream.ReadByte();
            }
        if ((count % 16) != 0) {
            Console.WriteLine();
            }

        Stream.Seek(0, SeekOrigin.Begin);

        }


    /// <summary>Create a new file with name <paramref name="fileName"/> and open an
    /// <see cref="EarlStreamDebug"/> with type identifier <paramref name="typeIdentifier"/>.</summary>
    /// <param name="fileName"></param>
    /// <param name="typeIdentifier"></param>
    /// <returns>The <see cref="EarlStreamDebug"/> created</returns>
    public static new EarlStreamDebug Create(
            string fileName,
            byte[] typeIdentifier) {

        var fileStream = fileName.OpenFileNewRW();

        var stream = new EarlStreamDebug(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.Read, fileStream);
        stream.WriteTypeIdentifier(typeIdentifier);

        return stream;
        }


    /// <summary>Open the file <paramref name="fileName"/> to read as an <see cref="EarlStreamDebug"/>.</summary>
    /// <param name="fileName">The file name.</param>
    /// <returns>The <see cref="EarlStreamDebug"/> created</returns>
    public static new EarlStreamDebug OpenRead(
                string fileName) => new (fileName, FileMode.Open, FileAccess.Read, FileShare.Read);

    /// <summary>Open the file <paramref name="fileName"/> to write as an <see cref="EarlStreamDebug"/>.</summary>
    /// <param name="fileName">The file name.</param>
    /// <returns>The <see cref="EarlStreamDebug"/> created</returns>
    public static new EarlStreamDebug OpenWrite(
            string fileName) => new (fileName, FileMode.Open, FileAccess.Read, FileShare.Read);

    /// <summary>Open the file <paramref name="fileName"/> to read and write as an <see cref="EarlStreamDebug"/>.</summary>
    /// <param name="fileName">The file name.</param>
    /// <returns>The <see cref="EarlStreamDebug"/> created</returns>
    public static new EarlStreamDebug OpenReadWrite(
            string fileName) => new (fileName, FileMode.Open, FileAccess.Read, FileShare.Read);


    /// <inheritdoc/>
    public override ulong ReadVarint() {
        var length = Stream.ReadVarint();
        Console.WriteLine($"ReadVarint: {length}");
        return length;
        }

    /// <inheritdoc/>
    public override byte[] ReadBlock() {
        var length = Stream.ReadVarint();
        var buffer = new byte[length];
        Stream.ReadExactly(buffer, 0, (int)length);


        Console.WriteLine($"ReadBlock: {length}");
        return buffer;


        }


    static void Dump(byte[] bytes) {
        foreach (var b in bytes) {
            Console.Write($"{b} ");
            }

        }

    /// <inheritdoc/>
    public override void WriteTypeIdentifier(byte[] bytes) {
        Dump(bytes);
        Stream.Write(bytes);
        }

    /// <inheritdoc/>
    public override void WriteVarint(long data) => Stream.WriteVarint(data);



    }