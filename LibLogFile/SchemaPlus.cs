using System;
using System.Collections.Generic;

namespace Goedel.Persistence {
    public partial class IndexTerm {

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
        /// 
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="Data"></param>
        public void AddKey (string Key, string Data) {
            if (Keys == null) Keys = new List<IndexTerm>();
            var IndexTerm = new IndexTerm(Key, Data);
            Keys.Add(IndexTerm);
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Index"></param>
        /// <param name="Data"></param>
        public void AddKey(PersistenceIndex Index, string Data) {
            if (Keys == null) Keys = new List<IndexTerm>();
            var IndexTerm = new IndexTermExtended(Index, Data);
            Keys.Add(IndexTerm);
            }

        }

    }
