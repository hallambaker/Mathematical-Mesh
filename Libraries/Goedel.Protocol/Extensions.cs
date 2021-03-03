using Goedel.Utilities;

using System.Collections.Generic;
using System.IO;

namespace Goedel.Protocol {

    /// <summary>Data encoding forms</summary>
    public enum DataEncoding {
        /// <summary>JSON encoding in UTF8</summary>
        JSON,
        /// <summary>JSON easy to edit format in UTF8</summary>
        JSON_A,
        /// <summary>JSON-B encoding in UTF8 plus binary extensions</summary>
        JSON_B,
        /// <summary>JSON-C encoding in UTF8 plus binary extensions</summary>
        JSON_C,
        /// <summary>JSON-D encoding in UTF8 plus binary extensions</summary>
        JSON_D,
        /// <summary>ASN-1</summary>
        ASN_1,
        /// <summary>RFC 822 style message header</summary>
        RFC822
        }




    public static partial class Extensions {


        /// <summary>
        /// Report if a protocol status cude indicates success.
        /// </summary>
        /// <param name="Code">The code to be reported on.</param>
        /// <returns>True if the code is in the range 100-299 inclusive, otherwise false.</returns>
        public static bool IsSuccess(this int Code) => (Code >= 100) & (Code < 300);

        /// <summary>
        /// Report if a protocol status cude indicates failure.
        /// </summary>
        /// <param name="Code">The code to be reported on.</param>
        /// <returns>True if the code is in the range 300-499 inclusive, otherwise false.</returns>
        public static bool IsError(this int Code) => (Code >= 400) & (Code < 500);

        /// <summary>Convert object to bytes in specified encoding.</summary>
        /// <param name="jsonObject">The object to convert.</param>
        /// <param name="dataEncoding">The encoding to convert to (defaults to JSON).</param>
        /// <param name="tagged">It true, tag the output value with the object type.</param>
        /// <returns>The encoded data.</returns>
        public static byte[] GetBytes(this JsonObject jsonObject,
                    DataEncoding dataEncoding = DataEncoding.JSON,
                    bool tagged = true) {

            switch (dataEncoding) {
                case DataEncoding.JSON: {
                    return GetJson(jsonObject, tagged);
                    }
                case DataEncoding.JSON_A: {
                    return GetJsonA(jsonObject, tagged);
                    }
                case DataEncoding.JSON_B: {
                    return GetJsonB(jsonObject, tagged);
                    }
                case DataEncoding.JSON_C: {
                    return GetJsonC(jsonObject, tagged);
                    }
                case DataEncoding.JSON_D: {
                    return GetJsonD(jsonObject, tagged);
                    }

                case DataEncoding.ASN_1:
                    break;
                case DataEncoding.RFC822:
                    break;
                default:
                    break;
                }

            throw new NYI();
            }

        /// <summary>
        /// Return the most capable writer available for the specified encoding.
        /// </summary>
        /// <param name="dataEncoding">The encoding to use.</param>
        /// <param name="stream">The stream to be encoded.</param>
        /// <returns></returns>
        public static JsonWriter GetWriter(this DataEncoding dataEncoding, Stream stream) {
            switch (dataEncoding) {
                case DataEncoding.JSON: {
                    return new JsonWriter(stream);
                    }
                case DataEncoding.JSON_A: {
                    return new JSONAWriter(stream);
                    }
                case DataEncoding.JSON_B: {
                    return new JsonBWriter(stream);
                    }
                case DataEncoding.JSON_C: {
                    return new JSONCWriter(stream);
                    }
                case DataEncoding.JSON_D: {
                    return new JSONCWriter(stream);
                    }

                case DataEncoding.ASN_1:
                    break;
                case DataEncoding.RFC822:
                    break;
                default:
                    break;
                }
            throw new NYI();
            }

        /// <summary>
        /// Returns true if <paramref name="jpcConnection"/> is a direct (i.e. not networked) connection type.
        /// </summary>
        /// <param name="jpcConnection">The connection to test.</param>
        /// <returns>Returns true if <paramref name="jpcConnection"/> is a direct (i.e. not networked) connection type,
        /// otherwise false.</returns>
        public static bool IsDirect(this JpcConnection jpcConnection) =>
            (jpcConnection == JpcConnection.Direct) | (jpcConnection == JpcConnection.Serialized);




        /// <summary>
        /// Create a JSONReader for the specified data
        /// </summary>
        /// <param name="Data">The data to be read as a UTF8 data stream.</param>
        /// <returns>The JSONReader</returns>
        public static JsonReader JsonReader(this byte[] Data) => new JsonReader(Data);


        /// <summary>
        /// Create a JSONReader for the specified data
        /// </summary>
        /// <param name="Data">The data to be read as a UTF8 data stream.</param>
        /// <returns>The JSONReader</returns>
        public static JsonReader JsonReader(this string Data) => new JsonReader(Data);

        /// <summary>
        /// Convert object to byte sequence in JSON form.
        /// </summary>
        /// <param name="Object">The object to convert</param>
        /// <param name="Tagged">If true, serialization is tagged with the object type.</param>
        /// <returns>Data as byte sequence.</returns>
        public static byte[] GetJson(this JsonObject Object, bool Tagged = true) => Object.GetBytes(Tagged);

        /// <summary>
        /// Convert object to byte sequence in JSON form.
        /// </summary>
        /// <param name="Object">The object to convert</param>
        /// <param name="Tagged">If true, serialization is tagged with the object type.</param>
        /// <returns>Data as byte sequence.</returns>
        public static byte[] GetJsonA(this JsonObject Object, bool Tagged = true) {
            JsonWriter JSONWriter = new JSONAWriter();
            Object.Serialize(JSONWriter, Tagged);
            return JSONWriter.GetBytes;
            }

        /// <summary>
        /// Convert object to byte sequence in JSON form.
        /// </summary>
        /// <param name="Object">The object to convert</param>
        /// <param name="Tagged">If true, serialization is tagged with the object type.</param>
        /// <returns>Data as byte sequence.</returns>
        public static byte[] GetJsonB(this JsonObject Object, bool Tagged = true) {
            JsonWriter JSONWriter = new JsonBWriter();
            Object.Serialize(JSONWriter, Tagged);
            return JSONWriter.GetBytes;
            }

        /// <summary>
        /// Convert object to byte sequence in JSON form.
        /// </summary>
        /// <param name="Object">The object to convert</param>
        /// <param name="Tagged">If true, serialization is tagged with the object type.</param>
        /// <param name="TagDictionary">Tag dictionary to use to decode type tags.</param>
        /// <returns>Data as byte sequence.</returns>
        public static byte[] GetJsonC(this JsonObject Object, bool Tagged = true,
                    Dictionary<string, int> TagDictionary = null) {
            JsonWriter JSONWriter = new JSONCWriter(TagDictionary: TagDictionary);
            Object.Serialize(JSONWriter, Tagged);
            return JSONWriter.GetBytes;
            }

        /// <summary>
        /// Convert object to byte sequence in JSON form using JSON-D encoding
        /// </summary>
        /// <param name="Object">The object to convert</param>
        /// <param name="Tagged">If true, serialization is tagged with the object type.</param>
        /// <param name="TagDictionary">Tag dictionary to use to decode type tags.</param>
        /// <returns>Data as byte sequence.</returns>
        public static byte[] GetJsonD(this JsonObject Object, bool Tagged = true,
                    Dictionary<string, int> TagDictionary = null) {
            // NYI: Implement the JSON D format.
            JsonWriter JSONWriter = new JSONCWriter(TagDictionary: TagDictionary);
            Object.Serialize(JSONWriter, Tagged);
            return JSONWriter.GetBytes;
            }


        }
    }
