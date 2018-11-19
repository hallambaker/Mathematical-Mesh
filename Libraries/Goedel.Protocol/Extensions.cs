using System;
using System.Collections.Generic;
using Goedel.Utilities;

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
        /// <param name="Object">The object to convert.</param>
        /// <param name="Encoding">The encoding to convert to (defaults to JSON).</param>
        /// <param name="Tagged">It true, tag the output value with the object type.</param>
        /// <returns>The encoded data.</returns>
        public static byte[] GetBytes (this JSONObject Object, 
                    DataEncoding Encoding = DataEncoding.JSON, 
                    bool Tagged = true) {

            switch (Encoding) {
                case DataEncoding.JSON: {
                    return GetJson(Object, Tagged);
                    }
                case DataEncoding.JSON_A: {
                    return GetJsonA(Object, Tagged);
                    }
                case DataEncoding.JSON_B: {
                    return GetJsonB(Object, Tagged);
                    }
                case DataEncoding.JSON_C: {
                    return GetJsonC(Object, Tagged);
                    }
                case DataEncoding.JSON_D: {
                    return GetJsonD(Object, Tagged);
                    }
                }

            throw new NYI();
            }


        //public static string ToWrapped (this JSONObject Object, bool Tag=false) {
        //    var JSONDebugWriter = new JSONDebugWriter();
        //    Object.Serialize(JSONDebugWriter, Tag);
        //    return JSONDebugWriter.GetUTF8;
        //    }

        /// <summary>
        /// Create a JSONReader for the specified data
        /// </summary>
        /// <param name="Data">The data to be read as a UTF8 data stream.</param>
        /// <returns>The JSONReader</returns>
        public static JSONReader JSONReader (this byte[] Data) => new JSONReader(Data);


        /// <summary>
        /// Create a JSONReader for the specified data
        /// </summary>
        /// <param name="Data">The data to be read as a UTF8 data stream.</param>
        /// <returns>The JSONReader</returns>
        public static JSONReader JSONReader (this string Data) => new JSONReader(Data);

        /// <summary>
        /// Convert object to byte sequence in JSON form.
        /// </summary>
        /// <param name="Object">The object to convert</param>
        /// <param name="Tagged">If true, serialization is tagged with the object type.</param>
        /// <returns>Data as byte sequence.</returns>
        public static byte[] GetJson(this JSONObject Object, bool Tagged = true) => Object.GetBytes(Tagged);

        /// <summary>
        /// Convert object to byte sequence in JSON form.
        /// </summary>
        /// <param name="Object">The object to convert</param>
        /// <param name="Tagged">If true, serialization is tagged with the object type.</param>
        /// <returns>Data as byte sequence.</returns>
        public static byte[] GetJsonA (this JSONObject Object, bool Tagged = true) {
            JSONWriter JSONWriter = new JSONAWriter();
            Object.Serialize(JSONWriter, Tagged);
            return JSONWriter.GetBytes;
            }

        /// <summary>
        /// Convert object to byte sequence in JSON form.
        /// </summary>
        /// <param name="Object">The object to convert</param>
        /// <param name="Tagged">If true, serialization is tagged with the object type.</param>
        /// <returns>Data as byte sequence.</returns>
        public static byte[] GetJsonB (this JSONObject Object, bool Tagged = true) {
            JSONWriter JSONWriter = new JSONBWriter();
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
        public static byte[] GetJsonC (this JSONObject Object, bool Tagged = true,
                    Dictionary<string, int> TagDictionary = null) {
            JSONWriter JSONWriter = new JSONCWriter(TagDictionary: TagDictionary);
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
        public static byte[] GetJsonD (this JSONObject Object, bool Tagged = true,
                    Dictionary<string, int> TagDictionary = null) {
            // NYI: Implement the JSON D format.
            JSONWriter JSONWriter = new JSONCWriter(TagDictionary: TagDictionary);
            Object.Serialize(JSONWriter, Tagged);
            return JSONWriter.GetBytes;
            }


        }
    }
