using System;
using System.Collections.Generic;
using Goedel.Utilities;

namespace Goedel.Cryptography.Dare {

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
            this List<KeyValue> Input) {

            if (Input == null) {
                return null;
                }

            var Result = new List<KeyValuePair<string, string>>();

            foreach (var Entry in Input) {
                Result.Add(new KeyValuePair<string, string>(Entry.Key, Entry.Value));
                }

            return Result;
            }

        /// <summary>
        /// Convert list of key value pairs to index terms.
        /// </summary>
        /// <param name="Input">List of key valye pairs to convert</param>
        /// <returns>The input list as a KeyValue Pair.</returns>
        public static List<KeyValue> ToKeyValues (
                this List<KeyValuePair<string, string>> Input) {
            if (Input == null) {
                return null;
                }

            var Result = new List<KeyValue>();

            foreach (var Entry in Input) {
                Result.Add(new KeyValue() { Key = Entry.Key, Value = Entry.Value} );
                }

            return Result;
            }

        }

    }
