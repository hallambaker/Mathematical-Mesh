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

using Goedel.Cryptography.Nist;

using System.IO;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Goedel.Cryptography.Dare;


/// <summary>
/// Extension methods
/// </summary>
public static partial class Extensions {

    public static List<T> Decode<T>(this List<Enveloped<T>> enveloped) where T : JsonObject{
        var result = new List<T>();

        foreach (var item in enveloped) {
            result.Add(item.Decode());
            }

        return result;
        }


    public static long TaggedLength(this byte[] data) => 
        data == null ? TagLength(0) : data.Length + TagLength(data.Length);

    public static int TagLength(
                    long value) {
        if (value < 64) {
            return 1;
            }
        if (value < 16383) {
            return 2;
            }
        if (value < 1073741823) {
            return 4;
            }
        if (value < 4611686018427387903) {
            return 8;
            }
        throw new InvalidLength();
        }

    /// <summary>
    /// Write <paramref name="value"/> to <paramref name="stream"/> as a QUIC 
    /// varint.
    /// </summary>
    /// <param name="stream">The stream to write to.</param>
    /// <param name="value">The value to write.</param>
    /// <exception cref="InvalidLength"></exception>
    public static void WriteVarint(
                this Stream stream,
                long value) {

        if (value < 64) {
            stream.Write((byte)value);
            return;
            }

        if (value < 16383) {
            var v2 = (value >> 8);

            stream.Write((byte)(v2 | 0b0100_0000));
            stream.Write((byte)value);
            return;
            }

        if (value < 1073741823) {
            var v2 = (value >> 8);
            var v3 = (v2 >> 8);
            var v4 = (v3 >> 8);

            stream.Write((byte)(v4 | 0b1000_0000));
            stream.Write((byte)v3);
            stream.Write((byte)v2);
            stream.Write((byte)value);
            return;
            }

        if (value < 4611686018427387903) {
            var v2 = (value >> 8);
            var v3 = (v2 >> 8);
            var v4 = (v3 >> 8);
            var v5 = (v4 >> 8);
            var v6 = (v5 >> 8);
            var v7 = (v6 >> 8);
            var v8 = (v7 >> 8);

            stream.Write((byte)(v8 | 0b1100_0000));
            stream.Write((byte)v7);
            stream.Write((byte)v6);
            stream.Write((byte)v5);
            stream.Write((byte)v4);
            stream.Write((byte)v3);
            stream.Write((byte)v2);
            stream.Write((byte)value);
            return;
            }

        else throw new InvalidLength();

        }


    /// <summary>
    /// Write <paramref name="value"/> to <paramref name="stream"/> as a QUIC 
    /// varint.
    /// </summary>
    /// <param name="stream">The stream to write to.</param>
    /// <param name="value">The value to write.</param>
    /// <exception cref="InvalidLength"></exception>
    public static async Task WriteVarintAsync(
                this Stream stream,
                long value) {

        var buffer = new byte[8];
        int index = 0;

        if (value < 64) {
            buffer[index++] =(byte)value;
            }
        else if (value < 16383) {
            var v2 = (value >> 8);

            buffer[index++] = ((byte)(v2 | 0b0100_0000));
            buffer[index++] = ((byte)value);
            }
        else if(value < 1073741823) {
            var v2 = (value >> 8);
            var v3 = (v2 >> 8);
            var v4 = (v3 >> 8);

            buffer[index++] = ((byte)(v4 | 0b1000_0000));
            buffer[index++] = ((byte)v3);
            buffer[index++] = ((byte)v2);
            buffer[index++] = ((byte)value);
            }
        else if(value < 4611686018427387903) {
            var v2 = (value >> 8);
            var v3 = (v2 >> 8);
            var v4 = (v3 >> 8);
            var v5 = (v4 >> 8);
            var v6 = (v5 >> 8);
            var v7 = (v6 >> 8);
            var v8 = (v7 >> 8);

            buffer[index++] = ((byte)(v8 | 0b1100_0000));
            buffer[index++] = ((byte)v7);
            buffer[index++] = ((byte)v6);
            buffer[index++] = ((byte)v5);
            buffer[index++] = ((byte)v4);
            buffer[index++] = ((byte)v3);
            buffer[index++] = ((byte)v2);
            buffer[index++] = ((byte)value);
            }
        else throw new InvalidLength();

        await stream.WriteAsync(buffer, 0, index);

        }





    /// <summary>
    /// Write <paramref name="value"/> to <paramref name="stream"/> as a reversed QUIC 
    /// varint.
    /// </summary>
    /// <param name="stream">The stream to write to.</param>
    /// <param name="value">The value to write.</param>
    /// <exception cref="InvalidLength"></exception>
    public static void WriteTnirav(
                this Stream stream,
                long value) {

        if (value < 64) {
            stream.Write((byte)value);
            return;
            }

        if (value < 16383) {
            var v2 = (value >> 8);

            stream.Write((byte)value);
            stream.Write((byte)(v2 | 0b0100_0000));

            return;
            }

        if (value < 1073741823) {
            var v2 = (value >> 8);
            var v3 = (v2 >> 8);
            var v4 = (v3 >> 8);

            stream.Write((byte)value);
            stream.Write((byte)v2);
            stream.Write((byte)v3);
            stream.Write((byte)(v4 | 0b1000_0000));



            return;
            }

        if (value < 4611686018427387903) {
            var v2 = (value >> 8);
            var v3 = (v2 >> 8);
            var v4 = (v3 >> 8);
            var v5 = (v4 >> 8);
            var v6 = (v5 >> 8);
            var v7 = (v6 >> 8);
            var v8 = (v7 >> 8);

            stream.Write((byte)value);
            stream.Write((byte)v2);
            stream.Write((byte)v3);
            stream.Write((byte)v4);
            stream.Write((byte)v5);
            stream.Write((byte)v6);
            stream.Write((byte)v7);
            stream.Write((byte)(v8 | 0b1100_0000));
            return;
            }

        else throw new InvalidLength();

        }

    public static ulong ReadTypeIdentifier(this Stream stream) {
        ulong result = 0;
        var length = 0;

        while (true) {
            var read = ReadByteExact(stream);
            if (length < 8) {
                result = (result << 8) + read;
                length++;
                }

            if ((read & 1) == 0) {
                return result;
                }
            }

        }


    /// <summary>
    /// Read a varint from <paramref name="stream"/> and return as an unsigned 64 bit integer.
    /// </summary>
    /// <param name="stream">The stream to read.</param>
    /// <returns>The value read.</returns>
    /// <exception cref="EndOfStreamException"></exception>
    public static ulong ReadVarint(this Stream stream) {
        ulong result;

        var read = ReadByteExact(stream);
        var type = read & 0b1100_0000;
        result = (ulong)read & 0b0011_1111;

        var count = type switch {
            0 => 0,
            0b0100_0000 => 1,
            0b1000_0000 => 3,
            0b1100_0000 => 7,
            _ => throw new NYI()
            };

        for (var i = 0; i < count; i++) {
            read = ReadByteExact(stream);
            result <<= 8;
            if (read < 0) {
                throw new EndOfStreamException();
                }

            result |= (byte)read;
            }

        return result;
        }

    /// <summary>
    /// Read a varint from <paramref name="stream"/> and return as an unsigned 64 bit integer.
    /// </summary>
    /// <param name="stream">The stream to read.</param>
    /// <returns>The value read.</returns>
    /// <exception cref="EndOfStreamException"></exception>
    public static ulong ReadVarint(this Stream stream, out int codeLength) {
        ulong result;

        var read = ReadByteExact(stream);
        var type = read & 0b1100_0000;
        result = (ulong)read & 0b0011_1111;

        var count = type switch {
            0 => 0,
            0b0100_0000 => 1,
            0b1000_0000 => 3,
            0b1100_0000 => 7,
            _ => throw new NYI()
            };

        for (var i = 0; i < count; i++) {
            read = ReadByteExact(stream);
            result <<= 8;
            if (read < 0) {
                throw new EndOfStreamException();
                }

            result |= (byte)read;
            }

        codeLength = count + 1;
        return result;
        }


    /// <summary>
    /// Read a byte from the stream <paramref name="stream"/> throwing the exception 
    /// <see cref="EndOfStreamException"/> if there is no more data to be read.
    /// </summary>
    /// <param name="stream">The stream to read.</param>
    /// <returns>The byte read.</returns>
    /// <exception cref="EndOfStreamException"></exception>
    public static byte ReadByteExact(Stream stream) {
        var read = stream.ReadByte();
        if (read < 0) {
            throw new EndOfStreamException();
            }

        return (byte)read;
        }


    /// <summary>
    /// Read a varint from <paramref name="stream"/> and return as an unsigned 64 bit integer.
    /// </summary>
    /// <param name="stream">The stream to read.</param>
    /// <returns>The value read.</returns>
    /// <exception cref="EndOfStreamException"></exception>
    public static ulong ReadTnirav(this Stream stream, int codeLength) {
        ulong result = 0;
        ulong index = 1;

        for (var i = 0; i < codeLength-1; i++) {
            var read = ReadByteExact(stream);
            if (read < 0) {
                throw new EndOfStreamException();
                }
            result |= (byte)read * index;
            index <<= 8;
            }

        var lastread = ReadByteExact(stream);
        var type = lastread & 0b1100_0000;
        result |= ((ulong)lastread & 0b0011_1111) * index;

        var count = type switch {
            0 => 0,
            0b0100_0000 => 1,
            0b1000_0000 => 3,
            0b1100_0000 => 7,
            _ => throw new NYI()
            };

        (codeLength == count+1).AssertTrue(NYI.Throw);
        return result;
        }



    /// <summary>
    /// Read a varint from <paramref name="stream"/> in the forwared direction and return 
    /// as an unsigned 64 bit integer.
    /// </summary>
    /// <param name="stream">The stream to read.</param>
    /// <returns>The value read.</returns>
    /// <exception cref="EndOfStreamException"></exception>
    public static ulong ReadTnirav(this Stream stream, out int codeLength) {
        ulong result;

        var read = ReadByteExactPrior(stream);
        var type = read & 0b1100_0000;
        result = (ulong)read & 0b0011_1111;

        var count = type switch {
            0 => 0,
            0b0100_0000 => 1,
            0b1000_0000 => 3,
            0b1100_0000 => 7,
            _ => throw new NYI()
            };

        for (var i = 0; i < count; i++) {
            read = ReadByteExactPrior(stream);
            result <<= 8;
            if (read < 0) {
                throw new EndOfStreamException();
                }

            result |= (byte)read;
            }
        codeLength = count + 1;
        return result;
        }






    /// <summary>
    /// Read a byte from the stream <paramref name="stream"/> throwing the exception 
    /// <see cref="EndOfStreamException"/> if there is no more data to be read.
    /// </summary>
    /// <param name="stream">The stream to read.</param>
    /// <returns>The byte read.</returns>
    /// <exception cref="EndOfStreamException"></exception>
    public static byte ReadByteExactPrior(Stream stream) {
        var mark = --stream.Position;

        var read = stream.ReadByte();
        stream.Position = mark;

        return (byte)read;
        }




    /// <summary>
    /// Serialize <paramref name="jsonObject"/> as JSON and return the result as a 
    /// data: URI.
    /// </summary>
    /// <param name="jsonObject">The object to serialize.</param>
    /// <returns>The constructed URI.</returns>
    public static string DataUri(this JsonObject jsonObject) {

        var enveloped = jsonObject.Envelope as Enveloped;
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
    /// <see cref="Enveloped"/></returns>
    public static Enveloped Envelope(
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
    /// <see cref="Enveloped"/></returns>
    public static Enveloped Envelope(
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
    /// <see cref="Enveloped"/></returns>
    public static Enveloped Envelope(
                this JsonObject jsonObject,
                CryptoParameters cryptoParameters,
                ObjectEncoding objectEncoding = ObjectEncoding.JSON
                ) {
        jsonObject.Normalize();

        var contentMeta = new ContentMeta() {
            UniqueId = jsonObject._PrimaryKey,
            Created = System.DateTime.UtcNow,
            ContentType = jsonObject.IanaMediaType,
            MessageType = jsonObject._Tag
            };

        var bytes = jsonObject.GetBytes(objectEncoding: objectEncoding);

        var enveloped = new Enveloped(cryptoParameters, bytes, contentMeta: contentMeta);
        enveloped.Header.EnvelopeId = jsonObject._PrimaryKey;
        jsonObject.Envelope = enveloped;

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
