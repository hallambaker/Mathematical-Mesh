//   Copyright © 2015 by Comodo Group Inc.
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
//  
//  

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Goedel.Protocol;

namespace Goedel.Persistence {

    /// <summary>
    /// A persistence store based on an append-only log.
    /// </summary>
    public class LogPersistenceStore : PersistenceStore {

        FileStream FileStream;

        /// <summary>
        /// Open or create a persistence store in read/write mode with 
        /// the specified file name, content type and optional comment.
        /// </summary>
        /// <param name="FileName">Log file.</param>
        /// <param name="Type">Type of data to store (the schema name).</param>
        /// <param name="Comment">Comment to be written to the log.</param>
        public LogPersistenceStore(string FileName,
                string Type, string Comment)
            : this(FileName, false, Type, Comment) {
            }

        /// <summary>
        /// Open a persistence store with the specified file name
        /// in read only mode.
        /// </summary>
        /// <param name="FileName">Log file.</param>
        public LogPersistenceStore(string FileName)
            : this(FileName, true, null, null) {
            }

        /// <summary>
        /// Open or create a persistence store in specified mode with 
        /// the specified file name, content type and optional comment.
        /// </summary>
        /// <param name="FileName">Log file.</param>
        /// <param name="ReadOnly">If true, persistence store must exist
        /// and will be opened in read-only mode. If false, persistence store
        /// is opened in read/write mode and a new store will be created
        /// if none exists.</param>
        /// <param name="Type">Type of data to store (the schema name).</param>
        /// <param name="Comment">Comment to be written to the log.</param>
        public LogPersistenceStore(string FileName, bool ReadOnly,
                string Type, string Comment) {
            Init(FileName, ReadOnly, Type, Comment);
            }


        /// <summary>
        /// Initialization method. May be called by subclasses.
        /// </summary>
        /// <param name="FileName">Log file.</param>
        /// <param name="ReadOnly">If true, persistence store must exist
        /// and will be opened in read-only mode. If false, persistence store
        /// is opened in read/write mode and a new store will be created
        /// if none exists.</param>
        /// <param name="Type">Type of data to store (the schema name).</param>
        /// <param name="Comment">Comment to be written to the log.</param>
        protected void Init(string FileName, bool ReadOnly,
                string Type, string Comment) {
            if (ReadOnly) {
                //Trace.WriteLine("Open store ReadOnly");
                FileStream = new FileStream(FileName, FileMode.Open,
                    FileAccess.Read, FileShare.ReadWrite);
                Read();
                }
            else {
                //Trace.WriteLine("Open store ReadWrite");
                FileStream = new FileStream(FileName, FileMode.OpenOrCreate,
                    FileAccess.ReadWrite, FileShare.Read);
                if (FileStream.Length <= 0) {
                    MakeHeader(Type, Comment);
                    }
                else {
                    Read();
                    }


                //Dump.Write(FileName);
                }
            }

        void MakeHeader(string Type, string Comment) {
            var Header = new Header() {
                Type = "Data",
                Content = Type,
                Comment = Comment
                };
            Write(Header);
            }

        /// <summary>
        /// Virtual method that is called by the management class to 
        /// perform the actual write operation to the store. Note that the caller is
        /// responsible for ensuring all necessary locks are acquired to ensure
        /// thread safety.
        /// </summary>
        /// <param name="DataItem">The data to be written.</param>
        protected override void UnprotectedStore(DataItem DataItem) {
            base.UnprotectedStore(DataItem);
            if (!DataItem.Persisted) {
                Write(DataItem);
                DataItem.Persisted = true;
                }
            }

        private void Write(LogEntry LogEntry) {
            var Data = LogEntry.GetBytes();
            FileStream.Seek(0, SeekOrigin.End);
            FileStream.Write(Data, 0, Data.Length);
            FileStream.Flush(true);
            }

        void Read() {
            var TextReader = new StreamReader(FileStream);
            var JSONReader = new JSONReader(TextReader);

            LogEntry LogEntry ;
            do {
                LogEntry = ReadRecord(JSONReader);
                } while (LogEntry != null);
            }
        
        LogEntry ReadRecord(JSONReader JSONReader) {

            try {
                LogEntry.Deserialize(JSONReader, out var ResultObject);
                if (ResultObject == null) {
                    return null;
                    }

                var Result = ResultObject as LogEntry;

                if (Result.GetType() == typeof(DataItem)) {
                    var DI = (DataItem)Result;
                    DI.Persisted = true;
                    UnprotectedStore(DI);
                    }

                return Result;
                }
            //catch (NullException none) {
            catch  {
                return null;
                }
            }

        }


    }
