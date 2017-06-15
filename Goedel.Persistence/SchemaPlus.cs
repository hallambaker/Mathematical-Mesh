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
using System.Collections.Generic;
using Goedel.Protocol;

namespace Goedel.Persistence {
    public partial class IndexTerm {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public IndexTerm () { }

        /// <summary>
        /// An index term
        /// </summary>
        /// <param name="Type">The term type</param>
        /// <param name="Term">The term value</param>
        public IndexTerm(string Type, string Term) {
            this.Type = Type;
            this.Term = Term;
            }

        }

    /// <summary>
    /// An index term that specifies the index it is linked to.
    /// </summary>
    public partial class IndexTermExtended : IndexTerm {
        /// <summary>
        /// The parent index.
        /// </summary>
        public PersistenceIndex PersistenceIndex;

        /// <summary>
        /// Construct a class with the specified index and term.
        /// </summary>
        /// <param name="PersistenceIndex">The parent index.</param>
        /// <param name="Term">The term.</param>
        public IndexTermExtended(PersistenceIndex PersistenceIndex, string Term) {
            this.PersistenceIndex = PersistenceIndex;
            this.Type = PersistenceIndex.Type;
            this.Term = Term;
            }
        }


    public partial class DataItem {


        private bool persisted = false;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DataItem () { }

        /// <summary>
        /// Returns a new JSONReader for the data entry.
        /// </summary>
        public JSONReader JSONReader { get => new JSONReader(Data); }

        /// <summary>
        /// Construct a data item with the specified transaction identifier, uniqueID, text data and keys.
        /// </summary>
        /// <param name="TransactionID">The transation identifier.</param>
        /// <param name="UniqueId">The unique identifier of the data entry.</param>
        /// <param name="Text">The data.</param>
        /// <param name="Keys">Index terms.</param>
        public DataItem(string TransactionID, string UniqueId, string Text, List<IndexTerm> Keys) {
            this.TransactionID = TransactionID;
            this.Text = Text;
            this.Keys = Keys;
            this.PrimaryKey = UniqueId;
            }

        /// <summary>
        /// Has the data item been written to persistent store?
        /// </summary>
        public bool Persisted {
            get {
                return persisted;
                }

            set {
                persisted = value;
                }
            }

        /// <summary>
        ///  Add a key to the persistence store index
        /// </summary>
        /// <param name="Key">Key to add entry to</param>
        /// <param name="Data">Data to add.</param>
        public void AddKey (string Key, string Data) {
            Keys = Keys ?? new List<IndexTerm>();
            var IndexTerm = new IndexTerm(Key, Data);
            Keys.Add(IndexTerm);
            }

        /// <summary>
        /// Add a key to the persistence store index
        /// </summary>
        /// <param name="Index">Index to add key to</param>
        /// <param name="Data">Data to add.</param>
        public void AddKey(PersistenceIndex Index, string Data) {
            Keys = Keys ?? new List<IndexTerm>();
            var IndexTerm = new IndexTermExtended(Index, Data);
            Keys.Add(IndexTerm);
            }

        }

    }
