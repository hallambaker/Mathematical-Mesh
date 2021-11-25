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

namespace Goedel.Cryptography.Dare;

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
        (cryptoAlgorithmID & CryptoAlgorithmId.BulkTagMask) switch {
            CryptoAlgorithmId.Digest => CryptoAlgorithmClasses.Digest,
            CryptoAlgorithmId.Encryption => CryptoAlgorithmClasses.Encryption,
            CryptoAlgorithmId.MAC => CryptoAlgorithmClasses.MAC,
            _ => (cryptoAlgorithmID & CryptoAlgorithmId.MetaTagMask) switch {
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
