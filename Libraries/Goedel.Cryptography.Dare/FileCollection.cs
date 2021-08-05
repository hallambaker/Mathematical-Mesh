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
using System.Collections.Generic;
using System.IO;

using Goedel.Utilities;

namespace Goedel.Cryptography.Dare {

    /// <summary>
    /// Record tracking a file in an archive.
    /// </summary>
    public partial class FileEntry {

        ///<summary>The index in the log.</summary> 
        public long Index;

        ///<summary>The position within the container.</summary> 
        public long Position;

        ///<summary>The index of the previous version of this file in the log.</summary> 
        public long Previous;

        ///<summary>The previous position within the container.</summary> 
        public long PreviousPosition;




        /// <summary>
        /// Base constructor for serialization.
        /// </summary>
        public FileEntry() {
            }

        /// <summary>
        /// Constructor to create an instance for the header <paramref name="dareHeader"/>
        /// located at file sequence position <paramref name="position"/>.
        /// </summary>
        /// <param name="dareHeader">The header describing the file entry.</param>
        /// <param name="position">The position of the entry in the file.</param>
        public FileEntry(DareHeader dareHeader, long position) {
            var contentMeta = dareHeader.ContentMeta;
            Path = contentMeta?.Filename;
            CreationTime = contentMeta?.Created;
            LastWriteTime = contentMeta?.Modified;
            Index = dareHeader.Index;
            Position = position;
            Previous = -1;
            PreviousPosition = -1;
            }

        }



    /// <summary>
    /// Class tracking a set of files in a sequence.
    /// </summary>
    public class FileCollection {

        ///<summary>Dictionary mapping full names to file entries.</summary> 
        public SortedDictionary<string, FileEntry> DictionaryByPath = new();

        ///<summary>Dictionary mapping full names to file entries.</summary> 
        public SortedDictionary<string, long> DictionaryDeleted = new();

        ///<summary>Dictionary mapping full names to file entries.</summary> 
        public SortedDictionary<long, FileEntry> DictionaryByIndex = new();

        ///<summary>Count of the number of deleted entries</summary> 
        public long CountDeleted = 0;

        /// <summary>
        /// Add an entry described by <paramref name="fileInfo"/> to the collection.
        /// </summary>
        /// <param name="fileInfo">File information block.</param>
        /// <param name="path">The path to be recorded.</param>
        /// <param name="index">Index of the frame in the sequence.</param>
        /// <param name="position">Position of the first byte of the frame.</param>
        /// <returns>The file entry created. This will contain relative links to the
        /// previous entry (if it exists).</returns>
        public FileEntry Add(FileInfo fileInfo, string path, long index, long position) {
            if (DictionaryByIndex.TryGetValue(index, out var previous)) {
                return previous; // already exists, do nothing
                }


            var fileEntry = new FileEntry() {
                Path = path,
                CreationTime = fileInfo.CreationTimeUtc,
                LastAccessTime = fileInfo.LastAccessTimeUtc,
                LastWriteTime = fileInfo.LastWriteTimeUtc,
                Attributes = (int)fileInfo.Attributes,
                Index = index,
                Position = position
                };




            return Add(fileEntry);
            }

        /// <summary>
        /// Add a file to the collection.
        /// </summary>
        /// <param name="dareHeader">DARE header describing the entry.</param>
        /// <param name="position">Position within the sequence file.</param>
        /// <returns></returns>
        public FileEntry Add(DareHeader dareHeader, long position) {
            var filename = dareHeader.ContentMeta?.Filename;
            if (filename == null) {
                return null; // not a file entry.
                }

            if (dareHeader.ContentMeta?.Event == DareConstants.SequenceEventDeleteTag) {
                DictionaryDeleted.AddSafe(filename, position);
                CountDeleted++;
                return null; // add to the list of deleted entries;
                }

            if (DictionaryByIndex.TryGetValue(dareHeader.Index, out var previous)) {
                return previous; // already exists, do nothing
                }

            if (DictionaryDeleted.ContainsKey(filename)) {
                return Delete(filename, position);
                }

            var fileEntry = new FileEntry(dareHeader, position);
            Add(fileEntry);

            return (fileEntry);
            }


        FileEntry Remove(DareHeader dareHeader, long position) {
            if (!DictionaryByPath.TryGetValue(dareHeader.ContentMeta?.Filename, out var previous)) {
                return null; // didn't exist, return null
                }

            DictionaryByPath.Remove(dareHeader.ContentMeta?.Filename);


            return previous;
            }



        /// <summary>
        /// Add a file entry.
        /// </summary>
        /// <param name="fileEntry">The entry to add</param>
        /// <returns>The entry created.</returns>
        public FileEntry Add(FileEntry fileEntry) {
            if (DictionaryByIndex.TryGetValue(fileEntry.Index, out var previous)) {
                return previous; // already exists
                }
            if (fileEntry.Path == null) {
                return null;
                }

            // If the file path is already entered, then overwrite.
            if (DictionaryByPath.TryGetValue(fileEntry.Path, out previous)) {
                if (fileEntry.Index > previous.Index) {
                    fileEntry.Previous = previous.Index;
                    fileEntry.PreviousPosition = previous.Position;
                    DictionaryByPath.Remove(fileEntry.Path);
                    }
                else {
                    }
                }


            DictionaryByPath.AddSafe(fileEntry.Path, fileEntry);
            DictionaryByIndex.Add(fileEntry.Index, fileEntry);

            return fileEntry;
            }


        /// <summary>
        /// Delete the file entry <paramref name="path"/> from the sequence.
        /// </summary>
        /// <param name="path">The unique identifier of the entry to delete.</param>
        /// <param name="position">The index position of the entry.</param>
        /// <returns>The file entry of the deleted file.</returns>
        public FileEntry Delete(string path, long position) {
            position.Future(); // keep for later use
            // future: add to a list of deleted files.

            if (DictionaryByPath.TryGetValue(path, out var entry)) {
                DictionaryByPath.Remove(path);
                DictionaryByIndex.Remove(entry.Index);
                return entry;
                }
            else {
                return null;
                }

            }

        /// <summary>
        /// Make a sequence index from the specified values.
        /// </summary>
        /// <returns>The created index.</returns>
        public SequenceIndex MakeIndex() {

            var index = new SequenceIndex() {
                Positions = new List<IndexPosition>(),
                };

            //Screen.WriteLine($"Start index {DictionaryByPath.Count} items");
            foreach (var item in DictionaryByPath) {
                var entry = item.Value;
                //Screen.WriteLine($"    {entry.Index} {entry.Path}");

                var position = new IndexPosition() {
                    Index = (int)entry.Index,
                    Position = (int)entry.Position,
                    UniqueId = entry.Path
                    };
                index.Positions.Add(position);
                }

            return index;
            }

        }

    }
