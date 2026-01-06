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
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.WebSockets;

using static System.Net.WebRequestMethods;

namespace Goedel.Cryptography.Dare;

public class EarlArchive : EarlSequence {

    public DirectoryIndex? DirectoryIndex { get; set; } = null;
    EarlArchive(
                EarlStream stream) : base(stream) {
        }

    public static EarlArchive Create(
            string fileName) {
        var stream = EarlStreamDebug.Create(fileName, DareConstants.TypeIdentifierDareSequence);
        var result = new EarlArchive(stream);

        result.WriteInitial();

        return result;
        }

    public static EarlArchive OpenRead(
        string fileName) {

        var stream = EarlStreamDebug.OpenRead(fileName);
        var result = new EarlArchive(stream);
        result.ReadInitial();

        return result;
        }


    public override EarlEntryIndex AppendStart(
            long length,
            ContentMeta contentMeta = null,
            bool index = false) {

        // add to the index

        return base.AppendStart(length, contentMeta, index);
        }



    public virtual void AppendDirectory(string path) {
        var directoryInfo = new DirectoryInfo(path);
        AppendDirectory(directoryInfo);
        }

    public virtual void AppendDirectory(DirectoryInfo info, string path = null) {
        DirectoryIndex ??= new();
        foreach (var directory in info.EnumerateDirectories()) {
            var subPath = Path.Combine(path ?? "", directory.Name);
            AppendDirectory(directory, subPath);
            }

        foreach (var file in info.EnumerateFiles()) {
            AppendFile(file, path);


            }
        }
    public virtual void AppendFile(FileInfo file, string path = null) {
        var index = new FileIndex(file, path);
        DirectoryIndex.Files.Add(index.Filename, index);

        using var fileStream = file.FullName.OpenFileReadShared();
        

        var contentMeta = new ContentMeta() {
            Filename = index.Filename

            };

        AppendStart(file.Length, contentMeta);

        var bufferSize = 4096;
        var buffer = new byte[bufferSize];
        
        var bytes = fileStream.Read(buffer, 0, bufferSize);
        while (bytes > 0) {
            AppendPayload(buffer, 0, bytes);
            bytes = fileStream.Read(buffer, 0, bufferSize);
            }

        AppendEnd();

        }

    public virtual void AppendIndex() {
        ReadIndex();
        var index = new TerminalIndex() {
            Entries = []
            };

        foreach (var pair in DirectoryIndex.Files) {
            index.Entries.Add(pair.Value);
            }

        // write an entry...
        var unprotected = new Unprotected() {
            Frame = NextFrame++
            };
        Stream.Append(unprotected, null, index, null);

        }


    //public FileIndex GetFileIndex(EarlEntryIndex index) {


    //    return new FileIndex(index.EarlEnvelope?.UnsignedHeader?.Frame ??0, 
    //        index.EarlEnvelope?.SignedHeader?.Filename);

    //    }





    public virtual void Extract(string path) {

        ReadIndex();

        foreach (var file in DirectoryIndex.Files) {
            var filepath = file.Value.Filename;
            if (filepath != null) {
                ExtractFile(path, filepath, file.Value.PayloadStart ?? 0, file.Value.PayloadLength ?? 0);
                }
            }

        }

    void ExtractFile(string path, string filepath, long start, long length) {
        var full = Path.Combine(path, filepath); // hack: do safe combine
        var directory = Path.GetDirectoryName(full);
        Directory.CreateDirectory(directory);

        var bufferSize = 4096;
        var buffer = new byte[bufferSize];

        using var target = full.OpenFileWrite();

        Stream.Position = start;
        while (length > bufferSize) {
            Stream.ReadBytes(buffer, bufferSize);
            target.Write(buffer, 0, bufferSize);
            }
        Stream.ReadBytes(buffer, (int)length);
        target.Write(buffer, 0, (int)length);
        target.Flush();

        }



    public virtual void ExtractFile(EarlEntryIndex index, string path) {
        }


    public virtual DirectoryIndex ReadIndex() {
        if (DirectoryIndex != null) {
            return DirectoryIndex;
            }
        DirectoryIndex = new();
        foreach (var entry in EntriesForward()) {
            var index = new FileIndex(entry);
            if (index.Filename is not null) {
                DirectoryIndex.Files.Add(index.Filename, index);
                }
            }

        return DirectoryIndex;
        }

    }



public record DirectoryIndex {

    string FilePath { get; set; }

    public SortedList<string,FileIndex> Files { get; } = [];


    public static DirectoryIndex ReadDirectory(string path) {
        var result = new DirectoryIndex();

        var directoryInfo = new DirectoryInfo(path);
        result.ReadDirectory(directoryInfo);

        return result;
        }

    public void ReadDirectory(DirectoryInfo info, string path=null) {

        foreach (var directory in info.EnumerateDirectories()) {
            var subPath = Path.Combine(path ?? "", directory.Name);
            ReadDirectory(directory, subPath);
            }

        foreach (var file in info.EnumerateFiles()) {
            var index = new FileIndex(file, path);
            Files.Add(index.Filename, index);
            }

        }

    public bool IsEqual(DirectoryIndex index) {
        if (index.Files.Count != Files.Count) {
            return false;
            }

        for (var i = 0; i < Files.Count; i++) {
            if (Files.GetValueAtIndex(i).Filename != index.Files.GetValueAtIndex(i).Filename) {
                return false;
                }

            }
        return true;

        }
    }

public partial class FileIndex : IComparable {
    //public long Frame { get; }
    //public long FrameStart { get; }
    //public long FrameLength { get; }
    //public long PayloadStart { get; }
    //public long PayloadLength { get; }
    //public string Filename { get; }



    public FileIndex(EarlEntryIndex index) {

        var unprotected = index.EarlEnvelope?.UnsignedHeader;
        var contentMeta = index.EarlEnvelope?.SignedHeader;

        Frame = unprotected?.Frame ?? -1;
        FrameStart = index.Start;
        FrameLength = index.Length;
        PayloadStart = index.PayloadStart;
        PayloadLength = index.PayloadLength;
        Filename = contentMeta?.Filename;
        }


    public FileIndex() {
        }

    public FileIndex(long length, string filePath) {
        PayloadLength = length;
        Filename = filePath;
        }

    public FileIndex(FileInfo info, string path) {
        PayloadLength = info.Length;

        Filename = Path.Combine (path??"", info.Name);
        }

    public override string ToString() => Filename;

    public int CompareTo(object obj) => Filename.CompareTo(obj?.ToString());




    }