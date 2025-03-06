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

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Goedel.Cryptography.Dare;

/// <summary>
/// Extension methods
/// </summary>
public static partial class Extension {

    /// <summary>
    /// Serialize <paramref name="jsonObject"/> as JSON and return the result as a 
    /// data: URI.
    /// </summary>
    /// <param name="jsonObject">The object to serialize.</param>
    /// <returns>The constructed URI.</returns>
    public static string DataUri(this JsonObject jsonObject) {

        var enveloped = jsonObject.Enveloped as DareEnvelope;
        enveloped.AssertNotNull(NYI.Throw);


        var builder = new StringBuilder();

        builder.Append("data:");
        builder.Append(jsonObject.IanaMediaType);
        builder.Append(";base64,");

        //var bytes = enveloped.GetBytes();
        builder.Append(enveloped.GetBytes().ToStringBase64url());


        return builder.ToString();
        }


    

    /// <summary>
    /// Sign and encrypt the JsonObject under <paramref name="signingKey"/> and
    /// <paramref name="encryptionKey"/>..
    /// </summary>
    /// <param name="jsonObject">The object to sign.</param>
    /// <param name="signingKey">Optional signature key.</param>
    /// <param name="encryptionKey">Optional encryption key.</param>
    /// <param name="objectEncoding">The encoding to use to compute the inner object.</param>
    /// <returns>Envelope containing the signed profile. Also updates the property
    /// <see cref="DareEnvelope"/></returns>
    public static DareEnvelope Envelope(
                this JsonObject jsonObject,
                CryptographicKey signingKey = null,
                CryptographicKey encryptionKey = null,
                ObjectEncoding objectEncoding = ObjectEncoding.JSON
                ) {

        var cryptoParameters = new CryptoParameters(signer: signingKey, recipient: encryptionKey);
        return Envelope(jsonObject, cryptoParameters, objectEncoding);
        }
        


    /// <summary>
    /// Sign and encrypt the object <paramref name="jsonObject"/> under 
    /// <paramref name="signingKeys"/> and <paramref name="encryptionKeys"/>.
    /// </summary>
    /// <param name="jsonObject">The object to sign.</param>
    /// <param name="signingKeys">Optional list of signature keys.</param>
    /// <param name="encryptionKeys">Optional list of encryption keys.</param>
    /// <param name="objectEncoding">The encoding to use to compute the inner object.</param>
    /// <param name="includeSignatureKey">If true include the public key parameters in the
    /// signature.</param>
    /// <returns>Envelope containing the signed profile. Also updates the property
    /// <see cref="DareEnvelope"/></returns>
    public static DareEnvelope Envelope(
                this JsonObject jsonObject,
                List<CryptographicKey> signingKeys,
                List<CryptographicKey> encryptionKeys = null,
                ObjectEncoding objectEncoding = ObjectEncoding.JSON,
                bool includeSignatureKey = false
                ) {
        var cryptoParameters = new CryptoParameters(encryptionKeys, signingKeys) {
            IncludeSignatureKey = includeSignatureKey
            };
        return Envelope( jsonObject, cryptoParameters, objectEncoding );

        }


    /// <summary>
    /// Sign and encrypt the object <paramref name="jsonObject"/> under 
    /// <paramref name="cryptoParameters"/>.
    /// </summary>
    ///  <param name="jsonObject">The object to sign.</param>
    /// <param name="cryptoParameters">The cryptographic parameters.</param>
    /// <param name="objectEncoding">The encoding to use to compute the inner object.</param>
    /// <returns>Envelope containing the signed profile. Also updates the property
    /// <see cref="DareEnvelope"/></returns>
    public static DareEnvelope Envelope(
                this JsonObject jsonObject,
                CryptoParameters cryptoParameters,
                ObjectEncoding objectEncoding = ObjectEncoding.JSON
                ) {
        jsonObject.Normalize();

        var contentMeta = new ContentMeta() {
            UniqueId = jsonObject._PrimaryKey,
            Created = System.DateTime.Now,
            ContentType = jsonObject.IanaMediaType,
            MessageType = jsonObject._Tag
            };

        var bytes = jsonObject.GetBytes(objectEncoding: objectEncoding);

        var enveloped = new DareEnvelope(cryptoParameters, bytes, contentMeta: contentMeta);
        enveloped.Header.EnvelopeId = jsonObject._PrimaryKey;
        jsonObject.Enveloped = enveloped;

        return enveloped;
        }





    /// <summary>
    /// Returns a new typed envelope containing the object <paramref name="data"/>
    /// optionally encrypted under <paramref name="encryptionKey"/> and signed under
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data">The object to be enveloped.</param>
    /// <param name="signingKey">The signature key.</param>
    /// <param name="encryptionKey">The encryption key.</param>
    /// <param name="contentMeta">The value of the ContentMeta Header tag.</param>
    /// <param name="objectEncoding">The object encoding to use for the envelope payload.</param>
    /// <returns>The enveloped data</returns>
    public static Enveloped<T> Envelope<T>(this T data,
                CryptographicKey signingKey = null,
                CryptographicKey encryptionKey = null,
                ContentMeta contentMeta = null,
                ObjectEncoding objectEncoding = ObjectEncoding.JSON) where T : JsonObject =>
        new Enveloped<T>(data, signingKey, encryptionKey, contentMeta, objectEncoding);


    /// <summary>
    /// Return the algorithm class of an algorithm identifier.
    /// </summary>
    /// <param name="cryptoAlgorithmID">The algorithm identifier to categorize.</param>
    /// <returns>The class of algorithm specified by <paramref name="cryptoAlgorithmID"/></returns>
    public static CryptoAlgorithmClass Class(
                this CryptoAlgorithmId cryptoAlgorithmID) =>
        (cryptoAlgorithmID & CryptoAlgorithmId.BulkTagMask) switch {
            CryptoAlgorithmId.Digest => CryptoAlgorithmClass.Digest,
            CryptoAlgorithmId.Encryption => CryptoAlgorithmClass.Encryption,
            CryptoAlgorithmId.MAC => CryptoAlgorithmClass.MAC,
            _ => (cryptoAlgorithmID & CryptoAlgorithmId.MetaTagMask) switch {
                CryptoAlgorithmId.Signature => CryptoAlgorithmClass.SignHash,
                CryptoAlgorithmId.Exchange => CryptoAlgorithmClass.Exchange,
                _ => CryptoAlgorithmClass.NULL,
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
