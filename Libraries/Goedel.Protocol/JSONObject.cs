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
using System.IO;
using System.Text;

using Goedel.IO;
using Goedel.Utilities;

#pragma warning disable IDE1006

namespace Goedel.Protocol {

    /// <summary>
    /// Encoding types for unified encoding
    /// </summary>
    public enum ObjectEncoding {
        /// <summary>JSON encoding</summary>
        JSON,
        /// <summary>JSON-A encoding</summary>
        JSON_A,
        /// <summary>JSON-B encoding</summary>
        JSON_B,
        /// <summary>JSON-C encoding</summary>
        JSON_C,
        /// <summary>JSON-D encoding</summary>
        JSON_D,
        /// <summary>XML encoding</summary>
        XML,
        /// <summary>ASN encoding</summary>
        ASN,
        /// <summary>RFC822 header style encoding</summary>
        RFC822
        }

    /// <summary>
    /// Factory delegate that returns a JSONObject.
    /// </summary>
    /// <returns></returns>
    public delegate JsonObject JsonFactoryDelegate();



    /// <summary>
    /// Base class for JSON Objects.
    /// </summary>
    public abstract partial class JsonObject {

        /// <summary>
        /// Primary key to use for the object.
        /// </summary>
        public virtual string _PrimaryKey => null;

        ///<summary>The enveloped object data.</summary> 
        public object Enveloped;

        ///<summary>Key collection to be used to decrypt enveloped data within the object.</summary> 
        public object KeyLocate;

        /// <summary>
        /// Secondary keys describing the object
        /// </summary>
        public virtual List<string> _Keys => null;

        /// <summary>
        /// Secondary key/values pairs describing the object
        /// </summary>
        public virtual List<KeyValuePair<string, string>> _KeyValues => null;

        /// <summary>
        /// Metadata header describing use in persistence store.
        /// </summary>
        public virtual JsonObject _Metadata { get; set; }

        /// <summary>
        /// Tag value used as substitute for reflection internally.
        /// </summary>
        public virtual string _Tag => __Tag;

        /// <summary>
        /// Tag value used as substitute for reflection internally.
        /// </summary>
        public const string __Tag = null;

        /// <summary>
        /// Factory method. Throws exception as this is an abstract class.
        /// </summary>
        /// <returns>Object of this type</returns>
        public static JsonObject _Factory() => throw new CannotCreateAbstract();

        /// <summary>
        /// Factory method used as default for ToString methods.
        /// </summary>
        public static JSONWriterFactoryDelegate JSONWriterFactory { get; set; } = JsonWriter.JSONWriterFactory;

        ///<summary>The tag dictionary for decoding entries.</summary>
        public static Dictionary<string, JsonFactoryDelegate> TagDictionary => tagDictionary ??
            new Dictionary<string, JsonFactoryDelegate>().CacheValue(out tagDictionary);
        static Dictionary<string, JsonFactoryDelegate> tagDictionary;

        /// <summary>
        /// Add a dictionary to the persistence store decoder.
        /// </summary>
        /// <param name="dictionary">The dictionary to add</param>
        public static void AddDictionary(
                    Dictionary<string, JsonFactoryDelegate> dictionary) => Append(TagDictionary, dictionary);

        /// <summary>
        /// Append the values from the tag dictionary of this type to <paramref name="dictionary"/>.
        /// </summary>
        /// <param name="dictionary">The dictionary to append the values to.</param>
        public static void AddDictionary(
            ref Dictionary<string, JsonFactoryDelegate> dictionary) {
            if (dictionary != TagDictionary) {
                Append(TagDictionary, dictionary);
                dictionary = TagDictionary;
                }
            }



        /// <summary>
        /// Base constructor.
        /// </summary>
        public JsonObject() {
            //_Initialize();
            }



        /// <summary>
        /// If implemented in the child class, performs a deep copy of the structure.
        /// </summary>
        /// <returns>Deep copy of the object with all referenced objects
        /// copied.</returns>
        public virtual JsonObject DeepCopy() => null;

        /// <summary>
        /// Convert object to string in JSON form
        /// </summary>
        /// <returns>Data as string.</returns>
		public override string ToString() {
            var _JSONWriter = JSONWriterFactory();
            Serialize(_JSONWriter, false);
            return _JSONWriter.GetUTF8;
            }

        /// <summary>
        /// Pretty print the object to the string builder <paramref name="builder"/>
        /// prefixed by <paramref name="indent"/> indent units.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="indent">Number of indentation units.</param>
        public virtual void ToBuilder(StringBuilder builder, int indent = 0) {
            }

        /// <summary>
        /// Write the object to the console using the method defined by ToBuilder.
        /// </summary>
        /// <param name="indent">Number of indentation units.</param>
        public void ToConsole(int indent = 0) {
            var StringBuilder = new StringBuilder();

            ToBuilder(StringBuilder, indent);

            //Console.WriteLine(StringBuilder.ToString());
            }


        /// <summary>
        /// Convert object to string in JSON form.
        /// </summary>
        /// <returns>Data as string.</returns>
        public virtual string GetUTF8() {
            var _JSONWriter = new JsonWriter();
            Serialize(_JSONWriter, true);
            return _JSONWriter.GetUTF8;
            }

        /// <summary>
        /// Convert object to byte sequence in JSON form.
        /// </summary>
        /// <param name="tag">If true, serialization is tagged with the object type.</param>
        /// <param name="objectEncoding">The object encoding to use for serialization.</param>
        /// <returns>Data as byte sequence.</returns>
        public virtual byte[] GetBytes(bool tag = true,
                    ObjectEncoding objectEncoding = ObjectEncoding.JSON) {



            var _JSONWriter = GetJsonWriter(objectEncoding);




            Serialize(_JSONWriter, tag);
            return _JSONWriter.GetBytes;
            }

        /// <summary>
        /// Return a JsonWriter for the encoding <paramref name="objectEncoding"/>.
        /// </summary>
        /// <param name="objectEncoding">The object encoding to use for serialization.</param>
        /// <param name="output">The output stream.</param>
        /// <returns>The JsonWriter.</returns>
        public static JsonWriter GetJsonWriter(ObjectEncoding objectEncoding, Stream output = null) => objectEncoding switch {
            ObjectEncoding.JSON_B => new JsonBWriter(output),
            ObjectEncoding.JSON_C => new JsonBWriter(output),
            ObjectEncoding.JSON_D => new JsonBWriter(output),
            _ => new JsonWriter(output)
            };



        /// <summary>
        /// Serialize to the specified Writer.
        /// </summary>
        /// <param name="writer">Writer to serialize the data to</param>
        /// <param name="tag">If true, serialization is tagged with the object type.</param>
        public virtual void Serialize(Writer writer, bool tag = false) {
            bool first = true;
            if (tag) {
                writer.WriteObjectStart();
                writer.WriteToken(_Tag, 0);
                }

            Serialize(writer, true, ref first);

            if (tag) {
                writer.WriteObjectEnd();
                }
            }

        /// <summary>
        /// Routine called before serializing the data structure. This may be used to perform
        /// tasks such as serializing a sub-field to a byte array and/or signing subfields.
        /// </summary>
        /// <remarks>There is a potential for conflict between PostDecode and PreEncode, particularly
        /// when debugging. </remarks>
        public virtual void PreEncode() {
            }

        /// <summary>
        /// Routine called afer deserializing the wire form. This may be used to cause deserialization
        /// of nested binary fields.
        /// </summary>
        /// <remarks>There is a potential for conflict between PostDecode and PreEncode, particularly
        /// when debugging. </remarks>
        public virtual void PostDecode() {
            }

        /// <summary>
        /// Serialize to the specified Writer.
        /// </summary>
        /// <param name="writer">Writer to serialize the data to</param>
        /// <param name="first">This is the first field in the object being serialized. This 
        /// value is set to false on exit.</param>
        /// <param name="wrap">Wrap the objects for formatting.</param>
		public abstract void Serialize(Writer writer, bool wrap, ref bool first);

        /// <summary>
        /// Serialize to the specified Writer. This is a dummy routine
        /// whose sole purpose is to prevent 'new' causing issues in derived
        /// classes.
        /// </summary>
        /// <param name="writer">Writer to serialize the data to</param>
        /// <param name="first">This is the first field in the object being serialized. This 
        /// value is set to false on exit.</param>
        /// <param name="wrap">Wrap the objects for formatting.</param>
		public static void SerializeX(Writer writer, bool wrap, ref bool first) {
            writer.Keep();
            wrap.Keep();
            first.Keep();
            }

        /// <summary>
        /// Factory method to construct object from byte data.
        /// </summary>
        /// <param name="data">Source</param>
        /// <returns>Constructed object</returns>
        public static JsonObject From(byte[] data) {
            using var reader = data.JsonReader();
            return FromJson(reader, true);
            }

        /// <summary>
        /// Factory method to construct object from string data.
        /// </summary>
        /// <param name="input">Source</param>
        /// <returns>Constructed object</returns>
        public static JsonObject From(string input) {
            using var reader = input.JsonReader();
            return FromJson(reader, true);
            }


        /// <summary>
        /// Deserialize a tagged stream.
        /// </summary>
        /// <param name="input">The input stream</param>
        /// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static JsonObject FromJson(JsonReader input, bool tagged) {
            tagged.AssertTrue(TagRequired.Throw);
            return input.ReadTaggedObject(TagDictionary);
            }

        /// <summary>
        /// Deserialize the input string to populate this object
        /// </summary>
        /// <param name="input">Input string</param>
        public virtual void Deserialize(string input) {
            var reader = new StringReader(input);
            var jsonReader = new JsonReader(reader);
            Deserialize(jsonReader);
            }

        /// <summary>
        /// Deserialize the input string to populate this object
        /// </summary>
        /// <param name="jsonReader">Input data</param>
        public virtual void Deserialize(JsonReader jsonReader) {

            bool going = jsonReader.StartObject();
            while (going) {
                string Token = jsonReader.ReadToken();
                if (Token == null) {
                    going = false;
                    }
                else {
                    DeserializeToken(jsonReader, Token);
                    going = jsonReader.NextObject();
                    }
                }
            PostDecode();

            // JSONReader.EndObject (); Implicit 
            }


        /// <summary>
        /// Deserialize the input stream to populate this object having recieved the specified tag.
        /// </summary>
        /// <param name="jsonReader">Input data</param>
        /// <param name="Tag">Input tag</param>
        public virtual void DeserializeToken(JsonReader jsonReader, string Tag) {
            }


        /// <summary>
        /// Write the object out to a file.
        /// </summary>
        /// <param name="fileName">Name of the file to create.</param>
        /// <param name="dataEncoding">The encoding to use</param>
        /// <param name="tagged">If true, tag the output with the object type</param>
        public void ToFile(string fileName, DataEncoding dataEncoding = DataEncoding.JSON, bool tagged = false) {
            using var outputStream = fileName.OpenFileNew();
            using var writer = dataEncoding.GetWriter(outputStream);
            Serialize(writer, tagged);
            }



        /// <summary>
        /// Merge two or more token dictionaries to produce a combined dictionary.
        /// </summary>
        /// <param name="Dictionary1">First dictionary to merge</param>
        /// <param name="Dictionary2">Second dictionary to merge</param>
        /// <param name="Dictionary3">Third dictionary to merge</param>
        /// <returns>Merged dictionaries</returns>
        public static Dictionary<string, JsonFactoryDelegate> Merge(
                    Dictionary<string, JsonFactoryDelegate> Dictionary1,
                    Dictionary<string, JsonFactoryDelegate> Dictionary2 = null,
                    Dictionary<string, JsonFactoryDelegate> Dictionary3 = null) {
            var Result = new Dictionary<string, JsonFactoryDelegate>();

            foreach (var Entry in Dictionary1) {
                Result.Add(Entry.Key, Entry.Value);
                }
            if (Dictionary2 != null) {
                Append(Result, Dictionary2);
                }
            if (Dictionary3 != null) {
                Append(Result, Dictionary3);
                }
            return Result;
            }

        /// <summary>
        /// Append elements of one dictionary to another.
        /// </summary>
        /// <param name="Base">Base dictionary to merge into</param>
        /// <param name="Dictionary">Second dictionary to merge</param>
        public static void Append(Dictionary<string, JsonFactoryDelegate> Base,
                    Dictionary<string, JsonFactoryDelegate> Dictionary) {
            foreach (var Entry in Dictionary) {
                Base.AddSafe(Entry.Key, Entry.Value);
                }
            }
        }
    }
