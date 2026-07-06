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

using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;
using Goedel.Protocol;
using Goedel.Utilities;

using System.Collections;

namespace Goedel.Debug;

/// <summary>
/// Class containing static helper methods.
/// </summary>
public static partial class Extension {


    /// <summary>Write <paramref name="example"/> to the writer <paramref name="example"/>
    /// with the set of included properties <paramref name="includedProperties"/></summary>
    /// <param name="output"></param>
    /// <param name="example"></param>
    /// <param name="includedProperties"></param>
    /// <param name="filter"></param>
    public static void Write(
        this TextWriter output,
        JsonObject example,
        List<string> includedProperties,
        Func<JsonObject, bool>? filter=null) {

        var include = new HashSet<string>();
        foreach (var entry in includedProperties) {
            include.Add(entry);
            }

        var buffer = new MemoryStream();
        var writer = new JSONDebugWriter(buffer);

        writer.WriteObjectStart();
        var last = false;
        var first = true;
        foreach (var property in example._Binding.AllProperties) {
            // Check if first
            if (include.Contains(property.Key)) {
                writer.WriteToken(property.Key, 0);
                if (property.Value is PropertyDictionaryStruct propertyDictionary) {
                    if (filter is not null) {
                        WriteFiltered(writer, propertyDictionary, example, filter);
                        }
                    else {
                        property.Value.Serialize(example, writer);
                        }
                    }
                else {
                    property.Value.Serialize(example, writer);
                    }
                first = false;
                }
            else if (first) {
                writer.WriteEllipsis();
                first = false;
                }
            else {
                last = true;
                }
            }
        // check if trailing
        if (last) {
            writer.WriteEllipsis();
            }
        buffer.Write("\r\n");
        writer.WriteObjectEnd();
        output.Write(buffer.ToArray().ToUTF8());
        output.WriteLine();
        }

    /// <summary>Write the data <paramref name="data"/> to <paramref name="writer"/>
    /// </summary>
    /// <param name="writer">The writer to output data to.</param>
    /// <param name="property">The property dictionary.</param>
    /// <param name="data">The data to write.</param>
    /// <param name="filter">Filter.</param>
    static void WriteFiltered(
                    JSONDebugWriter writer,
                    PropertyDictionaryStruct property,
                    IBinding data,
                    Func<JsonObject, bool> filter) {

        if (property.Get(data) is IEnumerable value) {
            var first = true;
            writer.WriteObjectStart();

            if (property.Enumerator is not null) {
                var firstTry = true;
                var lastTry = false;
                foreach (var entry in property.Enumerator(data)) {
                    if (entry.Value is JsonObject typed) {
                        if (filter(typed)) {
                            writer.WriteObjectSeparator(ref first);
                            writer.WriteToken(entry.Key, 1);
                            typed.Serialize(writer, property.Tagged);
                            }
                        }
                    else if (firstTry) {
                        writer.WriteEllipsis();
                        firstTry = false;
                        }
                    else {
                        lastTry = true;
                        }

                    }
                if (lastTry) {
                    writer.WriteEllipsis();
                    }
                }

            writer.WriteObjectEnd();
            }

        }



    /// <summary>
    /// Generate an invalidated version of the key <paramref name="keyPair"/> and add it
    /// to <paramref name="keyCollection"/>.
    /// </summary>
    /// <param name="keyPair">The key to modify.</param>
    /// <param name="keyCollection">The key collection to add it to.</param>
    /// <returns>The corrupted key</returns>
    public static KeyPair InvalidateKey(this KeyPair keyPair, KeyCollection keyCollection) {
        KeyPair result;
        switch (keyPair) {
            case KeyPairX448 keyPairX448: {
                result = new KeyPairX448Corrupt(keyPairX448);
                break;
                }
            case KeyPairEd448 keyPairEd448: {
                result = new KeyPairEd448Corrupt(keyPairEd448);
                break;
                }
            default: throw new ArgumentException($"Keypair type {nameof(keyPair)}");
            }

        keyCollection.Add(result);
        return result;
        }



    }


/// <summary>
/// Corruptable form of <see cref="KeyPairX448"/>
/// </summary>
public class KeyPairX448Corrupt : KeyPairX448 {



    /// <summary>
    /// Constructor returning a corrupted version of 
    /// </summary>
    /// <param name="keyPair"></param>
    public KeyPairX448Corrupt(KeyPairX448 keyPair) :
            base(Corrupt(keyPair.PrivateKey)) {

        }

    /// <summary>
    /// Return a corrupted private scalar derived from <paramref name="curvePrivate"/>.
    /// </summary>
    /// <param name="curvePrivate">The uncorrupted private key value.</param>
    /// <returns>The corrupted scalar.</returns>
    public static CurveX448Private Corrupt(CurveX448Private curvePrivate) {
        var privateKey = curvePrivate.SecretKey + 1;


        var result = new CurveX448Private(privateKey, true);
        result.PublicKey = curvePrivate.PublicKey;

        return result;
        }
    }



/// <summary>
/// Corruptable form of <see cref="KeyPairEd448"/>
/// </summary>
public class KeyPairEd448Corrupt : KeyPairEd448 {


    /// <summary>
    /// Constructor returning a corrupted version of 
    /// </summary>
    /// <param name="keyPair"></param>
    public KeyPairEd448Corrupt(KeyPairEd448 keyPair) :
            base(Corrupt(keyPair.PrivateKey)) {
        }

    /// <summary>
    /// Return a corrupted private scalar derived from <paramref name="curvePrivate"/>.
    /// </summary>
    /// <param name="curvePrivate">The uncorrupted private key value.</param>
    /// <returns>The corrupted scalar.</returns>
    public static CurveEdwards448Private Corrupt(CurveEdwards448Private curvePrivate) {
        var privateKey = curvePrivate.SecretKey + 1;

        var result = new CurveEdwards448Private(privateKey, true);
        result.Public = curvePrivate.Public;

        return result;
        }
    }