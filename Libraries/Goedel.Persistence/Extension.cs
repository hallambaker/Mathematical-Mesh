using System;
using System.Collections.Generic;
using Goedel.Persistence;
using Goedel.Utilities;

namespace Goedel.Persistence {

    /// <summary>
    /// Extension methods
    /// </summary>
    public static partial class Extension {

        /// <summary>
        /// Convert list of index terms to key value pairs.
        /// </summary>
        /// <param name="Input">List of index terms to convert</param>
        /// <returns>The input list as a KeyValue pair.</returns>
        public static List<KeyValuePair<string, string>> ToKeyValuePairs (
            this List<IndexTerm> Input) {

            var Result = new List<KeyValuePair<string, string>>();

            foreach (var Entry in Input) {
                Result.Add(new KeyValuePair<string, string>(Entry.Type, Entry.Term));
                }

            return Result;
            }

        /// <summary>
        /// Convert list of key value pairs to index terms.
        /// </summary>
        /// <param name="Data">List of key valye pairs to convert</param>
        /// <returns>The input list as a KeyValue Pair.</returns>
        public static List<IndexTerm> ToIndexTerms (
                this List<KeyValuePair<string, string>> Data) {
            var Result = new List<IndexTerm>();

            foreach (var Entry in Data) {
                Result.Add(new IndexTerm() { Type = Entry.Key, Term = Entry.Value} );
                }

            return Result;
            }

        }

    }
