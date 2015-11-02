using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Goedel.Protocol;

namespace Goedel.Persistence {

    // Stub class to be used to create an indexed version of the
    // key store at a later date.

    // This is not currently necessary as reading a simulated 
    // keystore with 100K keys only takes 13 seconds.

    // If the key store gets to 10 million entries, keeping the 
    // entire index in memorey starts to become impractical.
    // In this situation it is better to keep only the index
    // and a cache in-memory and read entries from disk on cache
    // misses.

    // The indexed version of the key store would be produced by
    // a separate process that reads in the keystore and emits the
    // indicies. Such a process can scan the log incrementally, 
    // avoiding the need to keep the entire log in memory at once.

    // If the size of the log became enormous, even the need to 
    // keep the entire index in memory can be avoided. The scanner
    // could compile separate indexes for each value of the first
    // n bits.
    

    /// <summary>
    /// Currently a placeholder class for an version of the keystore that
    /// potentially makes use of indexes appended to the log file increments
    /// to avoid the need to hold the entire structure in-memory.
    /// </summary>
    public class IndexedKeyStore : LogPersistenceStore {

        /// <summary>
        /// Open an existing store in read only mode.
        /// </summary>
        /// <param name="FileName">The base file name.</param>
        public IndexedKeyStore(string FileName)
            : this(FileName, true, null, null) {
            }

        /// <summary>
        /// Open or create a persistence store in read/write mode with 
        /// the specified file name, content type and optional comment.
        /// </summary>
        /// <param name="FileName">Log file.</param>
        /// <param name="Type">Type of data to store (the schema name).</param>
        /// <param name="Comment">Comment to be written to the log.</param>
        public IndexedKeyStore(string FileName,
                string Type, string Comment)
            : this(FileName, false, Type, Comment) {
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
        public IndexedKeyStore(string FileName, bool ReadOnly,
                string Type, string Comment)
            : base(FileName, ReadOnly, Type, Comment) {
            }

        /// <summary>
        /// Start writing to a new log file and close out the current log
        /// by writing termination records, closure indexes etc. Note 
        /// that these are concurrent operations.
        /// </summary>
        public void RollOver () {
            }

        /// <summary>
        /// Produce a consolidated log file containing all the data in the log.
        /// </summary>
        public void Consolidate() {
            }

        }
    }
