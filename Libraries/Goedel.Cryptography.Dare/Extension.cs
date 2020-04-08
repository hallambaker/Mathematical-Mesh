using System.Collections.Generic;

namespace Goedel.Cryptography.Dare {

    /// <summary>
    /// Extension methods
    /// </summary>
    public static partial class Extension {

        /// <summary>
        /// Return the algorithm class of an algorithm identifier.
        /// </summary>
        /// <param name="cryptoAlgorithmID">The algorithm identifier to categorize.</param>
        /// <returns>The class of algorithm specified by <paramref name="cryptoAlgorithmID"/></returns>
        public static CryptoAlgorithmClasses Class(
                    this CryptoAlgorithmId cryptoAlgorithmID) =>
            (cryptoAlgorithmID & CryptoAlgorithmId.BulkTagMask) switch
                {
                    CryptoAlgorithmId.Digest => CryptoAlgorithmClasses.Digest,
                    CryptoAlgorithmId.Encryption => CryptoAlgorithmClasses.Encryption,
                    CryptoAlgorithmId.MAC => CryptoAlgorithmClasses.MAC,
                    _ => (cryptoAlgorithmID & CryptoAlgorithmId.MetaTagMask) switch
                        {
                            CryptoAlgorithmId.Signature => CryptoAlgorithmClasses.Signature,
                            CryptoAlgorithmId.Exchange => CryptoAlgorithmClasses.Exchange,
                            _ => CryptoAlgorithmClasses.NULL,
                            },
                    };


        /// <summary>
        /// Convert list of index terms to key value pairs.
        /// </summary>
        /// <param name="Input">List of index terms to convert</param>
        /// <returns>The input list as a KeyValue pair.</returns>
        public static List<KeyValuePair<string, string>> ToKeyValuePairs(
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
        public static List<KeyValue> ToKeyValues(
                this List<KeyValuePair<string, string>> Input) {
            if (Input == null) {
                return null;
                }

            var Result = new List<KeyValue>();

            foreach (var Entry in Input) {
                Result.Add(new KeyValue() { Key = Entry.Key, Value = Entry.Value });
                }

            return Result;
            }

        }

    }
