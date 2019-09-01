//   Copyright © 2015 by Comodo Group Inc.
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
//  
//  

using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;
using Goedel.IO;

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
    public delegate JSONObject JSONFactoryDelegate ();



    /// <summary>
    /// Base class for JSON Objects.
    /// </summary>
    public abstract partial class JSONObject {

        /// <summary>
        /// Primary key to use for the object.
        /// </summary>
        public virtual string _PrimaryKey  => null;

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
        public virtual JSONObject _Metadata { get; set; }

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
        public static JSONObject _Factory() => throw new CannotCreateAbstract();

        /// <summary>
        /// Factory method used as default for ToString methods.
        /// </summary>
        public static JSONWriterFactoryDelegate JSONWriterFactory = JSONWriter.JSONWriterFactory;

        ///<summary>The tag dictionary for decoding entries.</summary>
        public static Dictionary<string, JSONFactoryDelegate> TagDictionary = tagDictionary ??
            new Dictionary<string, JSONFactoryDelegate>().CacheValue(out tagDictionary);
        static Dictionary<string, JSONFactoryDelegate> tagDictionary;

        /// <summary>
        /// Add a dictionary to the persistence store decoder.
        /// </summary>
        /// <param name="dictionary">The dictionary to add</param>
        public void AddDictionary(
                    Dictionary<string, JSONFactoryDelegate> dictionary) => Append(TagDictionary, dictionary);

        public static void AddDictionary(
            ref Dictionary<string, JSONFactoryDelegate> dictionary) {
            if (dictionary != TagDictionary) {
                Append(TagDictionary, dictionary);
                dictionary = TagDictionary;
                }
            }


        /// <summary>
        /// Base constructor.
        /// </summary>
		public JSONObject () {
            //_Initialize();
            }

        /// <summary>
        /// If implemented in the child class, performs a deep copy of the structure.
        /// </summary>
        /// <returns>Deep copy of the object with all referenced objects
        /// copied.</returns>
        public virtual JSONObject DeepCopy() => null;

        /// <summary>
        /// Convert object to string in JSON form
        /// </summary>
        /// <returns>Data as string.</returns>
		public override string ToString () {
            var _JSONWriter = JSONWriterFactory();
            Serialize(_JSONWriter, false);
            return _JSONWriter.GetUTF8;
            }

        /// <summary>
        /// Convert object to string in JSON form.
        /// </summary>
        /// <returns>Data as string.</returns>
		public virtual string GetUTF8 () {
            var _JSONWriter = new JSONWriter();
            Serialize(_JSONWriter, true);
            return _JSONWriter.GetUTF8;
            }

        /// <summary>
        /// Convert object to byte sequence in JSON form.
        /// </summary>
        /// <param name="tag">If true, serialization is tagged with the object type.</param>
        /// <returns>Data as byte sequence.</returns>
        public virtual byte[] GetBytes (bool tag = true) {
            var _JSONWriter = new JSONWriter();
            Serialize(_JSONWriter, tag);
            return _JSONWriter.GetBytes;
            }

        /// <summary>
        /// Serialize to the specified Writer.
        /// </summary>
        /// <param name="writer">Writer to serialize the data to</param>
        /// <param name="tag">If true, serialization is tagged with the object type.</param>
        public virtual void Serialize (Writer writer, bool tag = false) {
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


        public virtual void PreEncode() {
            }
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
        /// <param name="Writer">Writer to serialize the data to</param>
        /// <param name="first">This is the first field in the object being serialized. This 
        /// value is set to false on exit.</param>
        /// <param name="wrap">Wrap the objects for formatting.</param>
		public void SerializeX(Writer Writer, bool wrap, ref bool first) {
            }

        /// <summary>
        /// Factory method to construct object from byte data.
        /// </summary>
        /// <param name="data">Source</param>
        /// <returns>Constructed object</returns>
        public static JSONObject From(byte[] data) =>
                FromJSON(data.JSONReader(), true);

        /// <summary>
        /// Factory method to construct object from string data.
        /// </summary>
        /// <param name="input">Source</param>
        /// <returns>Constructed object</returns>
        public static JSONObject From(string input) =>
                FromJSON(input.JSONReader(), true);

        /// <summary>
        /// Deserialize a tagged stream. This method should never be called.
        /// </summary>
        /// <param name="input">The input stream</param>
        /// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static JSONObject FromJSON(JSONReader input, bool tagged) {
            tagged.AssertTrue(Internal.Throw);
            return input.ReadTaggedObject(TagDictionary);
            }

        /// <summary>
        /// Deserialize the input string to populate this object
        /// </summary>
        /// <param name="_Input">Input string</param>
        public virtual void Deserialize (string _Input) {
            StringReader _Reader = new StringReader(_Input);
            JSONReader JSONReader = new JSONReader(_Reader);
            Deserialize(JSONReader);
            }

        /// <summary>
        /// Deserialize the input string to populate this object
        /// </summary>
        /// <param name="JSONReader">Input data</param>
        public virtual void Deserialize (JSONReader JSONReader) {

            bool Going = JSONReader.StartObject();
            while (Going) {
                string Token = JSONReader.ReadToken();
                if (Token == null) {
                    Going = false;
                    }
                else {
                    DeserializeToken(JSONReader, Token);
                    }
                Going = JSONReader.NextObject();
                }
            // JSONReader.EndObject (); Implicit 
            }


        /// <summary>
        /// Deserialize the input stream to populate this object having recieved the specified tag.
        /// </summary>
        /// <param name="JSONReader">Input data</param>
        /// <param name="Tag">Input tag</param>
        public virtual void DeserializeToken (JSONReader JSONReader, string Tag) {
            }


        /// <summary>
        /// Write the object out to a file.
        /// </summary>
        /// <param name="fileName">Name of the file to create.</param>
        /// <param name="dataEncoding">The encoding to use</param>
        /// <param name="tagged">If true, tag the output with the object type</param>
        public void ToFile(string fileName, DataEncoding dataEncoding= DataEncoding.JSON, bool tagged=false) {
            using (var outputStream = fileName.OpenFileNew()) {
                using (var writer = dataEncoding.GetWriter(outputStream)) {
                    Serialize(writer, tagged);
                    }
                }
            }



        /// <summary>
        /// Merge two or more token dictionaries to produce a combined dictionary.
        /// </summary>
        /// <param name="Dictionary1">First dictionary to merge</param>
        /// <param name="Dictionary2">Second dictionary to merge</param>
        /// <param name="Dictionary3">Third dictionary to merge</param>
        /// <returns>Merged dictionaries</returns>
        public static Dictionary<string, JSONFactoryDelegate> Merge (
                    Dictionary<string, JSONFactoryDelegate> Dictionary1,
                    Dictionary<string, JSONFactoryDelegate> Dictionary2=null,
                    Dictionary<string, JSONFactoryDelegate> Dictionary3 = null) {
            var Result = new Dictionary<string, JSONFactoryDelegate>();

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
        public static void Append (Dictionary<string, JSONFactoryDelegate> Base,
                    Dictionary<string, JSONFactoryDelegate> Dictionary) {
            foreach (var Entry in Dictionary) {
                Base.AddSafe(Entry.Key, Entry.Value);
                }
            }




        }
    }
