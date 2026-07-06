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

/// <summary>Earl archive class</summary>
public class VDareArchive : VDareSequence {

    /// <summary>Directory index</summary>
    public DirectoryIndex? DirectoryIndex { get; set; } = null;
    VDareArchive(
                VDareStream stream) : base(stream) {
        }

    /// <summary>Create a new archive in file <paramref name="fileName"/>.</summary>
    /// <param name="fileName">Name of the file to create.</param>
    /// <returns>The archive instance.</returns>
    public static VDareArchive Create(
            string fileName) {
        var stream = VDareStream.Create(fileName, DareConstants.TypeIdentifierDareSequence);
        var result = new VDareArchive(stream);

        result.WriteInitial();

        return result;
        }

    /// <summary>Open the file to read.</summary>
    /// <param name="fileName">Name of the file to read.</param>
    /// <returns>The archive instance.</returns>
    public static VDareArchive OpenRead(
        string fileName) {

        var stream = VDareStream.OpenRead(fileName);
        var result = new VDareArchive(stream);
        result.ReadInitial();

        return result;
        }

    /// <inheritdoc/>
    public override (long, long, long, long) AppendStart(
            long length,
            ContentMeta contentMeta = null,
            bool index = false) {


        return base.AppendStart(length, contentMeta, index);
        }


    /// <summary>Append all files in the directory <paramref name="path"/></summary>
    /// <param name="path">The directory path of the files to include.</param>
    public virtual void AppendDirectory(string path) {
        var directoryInfo = new DirectoryInfo(path);
        AppendDirectory(directoryInfo);
        }

    /// <summary>Append all files in the directory <paramref name="info"/> at
    /// <paramref name="path"/></summary>
    /// <param name="info">The directory to include.</param>
    /// <param name="path">The directory path of the files to include.</param>
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


    /// <summary>Append the file <paramref name="file"/> at path <paramref name="path"/>.</summary>
    /// <param name="file">The file to append.</param>
    /// <param name="path">The file path.</param>
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

    /// <summary>Append the archive index.</summary>
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

    /// <summary>Extract the file <paramref name="path"/>.</summary>
    /// <param name="path"></param>
    public virtual void Extract(string path) {

        ReadIndex();

        foreach (var file in DirectoryIndex.Files) {
            var filepath = file.Value.Filename;
            if (filepath != null) {
                ExtractFile(path, filepath, file.Value.PayloadStart ?? 0, file.Value.PayloadLength ?? 0);
                }
            }

        }

    /// <summary>Extract the file <paramref name="path"/>, writing the result to 
    /// <paramref name="filepath"/>, reading the payload data starting at byte <paramref name="start"/>
    /// for <paramref name="length"/> bytes.</summary>
    /// <param name="filepath">The archive path.</param>
    /// <param name="path">The destination path.</param>
    /// <param name="start">First payload byte</param>
    /// <param name="length">Number of payload bytes.</param>
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


    /// <summary>Extract the file at <paramref name="index"/> to <paramref name="path"/></summary>
    /// <param name="index"></param>
    /// <param name="path"></param>
    public virtual void ExtractFile(VDareEntryIndex index, string path) {
        }


    /// <summary>Read the archive index.</summary>
    /// <returns></returns>
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


/// <summary>An archive directory.</summary>
public record DirectoryIndex {

    string FilePath { get; set; }

    /// <summary>The file indexes by filename.</summary>
    public SortedList<string,FileIndex> Files { get; } = [];

    /// <summary>Construct a directory index from the disk path <paramref name="path"/>.</summary>
    /// <param name="path">The path to search for files.</param>
    /// <returns>The constructed directory.</returns>
    public static DirectoryIndex ReadDirectory(string path) {
        var result = new DirectoryIndex();

        var directoryInfo = new DirectoryInfo(path);
        result.ReadDirectory(directoryInfo);

        return result;
        }

    /// <summary>Read the disk directory <paramref name="info"/> and
    /// add to the index as <paramref name="path"/></summary>
    /// <param name="info">The disk directory to read.</param>
    /// <param name="path">The path.</param>
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

    /// <summary>Read the disk directory <paramref name="index"/> and verify if it
    /// is equal.</summary>
    /// <param name="index">The disk directory to read.</param>
    /// <returns>True if the directories are equal.</returns>
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

    /// <summary>Constructor, returns a new instance.</summary>
    public FileIndex() {
        }


    /// <summary>Constructor, return a new instance with parameters from
    /// <paramref name="index"/>.</summary>
    /// <param name="index">The entry parameters.</param>
    public FileIndex(VDareEntryIndex index) {

        var unprotected = index.EarlEnvelope?.UnsignedHeader;
        var contentMeta = index.EarlEnvelope?.SignedHeader;

        Frame = unprotected?.Frame ?? -1;
        FrameStart = index.Start;
        FrameLength = index.Length;
        PayloadStart = index.PayloadStart;
        PayloadLength = index.PayloadLength;
        Filename = contentMeta?.Filename;
        }



    /// <summary>Add an entry for the file <paramref name="filePath"/> of length
    /// <paramref name="length"/>.</summary>
    /// <param name="length">The file length.</param>
    /// <param name="filePath">The file path.</param>
    public FileIndex(long length, string filePath) {
        PayloadLength = length;
        Filename = filePath;
        }

    /// <summary>Add an entry for the file <paramref name="info"/> with path
    /// <paramref name="path"/>.</summary>
    /// <param name="info">The file information.</param>
    /// <param name="path">The file path.</param>
    public FileIndex(FileInfo info, string path) {
        PayloadLength = info.Length;

        Filename = Path.Combine (path??"", info.Name);
        }

    /// <inheritdoc/>
    public override string ToString() => Filename;

    /// <inheritdoc/>
    public int CompareTo(object obj) => Filename.CompareTo(obj?.ToString());

    }