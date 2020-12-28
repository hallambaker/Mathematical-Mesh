using Goedel.Utilities;

using System;
using System.Collections.Generic;
using System.IO;

namespace Goedel.Cryptography.Dare {

    /// <summary>
    /// Record tracking a file in an archive.
    /// </summary>
    public record FileEntry {

        ///<summary>The file path in canonical form.</summary> 
        public string Path;

        ///<summary>The creation time.</summary> 
        public DateTime? CreationTimeUtc;

        ///<summary>The last access time.</summary> 
        public DateTime? LastAccessTimeUtc;

        ///<summary>The last write time.</summary> 
        public DateTime? LastWriteTimeUtc;

        ///<summary>The file attributes mask.</summary> 
        public int Attributes;

        ///<summary>The index in the log.</summary> 
        public long Index;

        ///<summary>The position within the container.</summary> 
        public long Position;

        ///<summary>The index of the previous version of this file in the log.</summary> 
        public long Previous;

        ///<summary>The previous position within the container.</summary> 
        public long PreviousPosition;


        public FileEntry() {
            }

        public FileEntry(DareHeader dareHeader, long position) {
            var contentMeta = dareHeader.ContentMeta;
            Path = contentMeta?.Filename;
            CreationTimeUtc = contentMeta?.Created;
            LastWriteTimeUtc = contentMeta?.Modified;
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
        public SortedDictionary<string, FileEntry> DictionaryByPath = new ();
        ///<summary>Dictionary mapping full names to file entries.</summary> 
        public SortedDictionary<long, FileEntry> DictionaryByIndex = new();
        /// <summary>
        /// Add an entry described by <paramref name="fileInfo"/> to the collection using
        /// <paramref name="relativeTo"/> as the relative path.
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
                CreationTimeUtc = fileInfo.CreationTimeUtc,
                LastAccessTimeUtc = fileInfo.LastAccessTimeUtc,
                LastWriteTimeUtc = fileInfo.LastWriteTimeUtc,
                Attributes = (int)fileInfo.Attributes,
                Index = index,
                Position = position
                };




            return Add(fileEntry);
            }

        public FileEntry Add(DareHeader dareHeader, long position) {
            if (DictionaryByIndex.TryGetValue(dareHeader.Index, out var previous)) {
                return previous; // already exists, do nothing
                }
            if (dareHeader.ContentMeta?.Filename == null) {
                return null; // not a file entry.
                }


            var fileEntry = new FileEntry(dareHeader, position);

            Add(fileEntry);

            return (fileEntry);
            }


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


            DictionaryByPath.Add(fileEntry.Path, fileEntry);
            DictionaryByIndex.Add(fileEntry.Index, fileEntry);

            return fileEntry;
            }


        /// <summary>
        /// Delete the file entry <paramref name="path"/> from the sequence.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public FileEntry Delete(string path) {
            if (DictionaryByPath.TryGetValue(path, out var entry)) {
                DictionaryByPath.Remove(path);
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

            Screen.WriteLine($"Start index {DictionaryByPath.Count} items");
            foreach (var item in DictionaryByPath) {
                var entry = item.Value;
                Screen.WriteLine($"    {entry.Index} {entry.Path}");

                var position = new IndexPosition() {
                    Index = (int) entry.Index,
                    Position = (int)entry.Position,
                    UniqueId = entry.Path
                    };
                index.Positions.Add(position);
                }

            return index;
            }

        }

    }
