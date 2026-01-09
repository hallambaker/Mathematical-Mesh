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



#pragma warning disable IDE1006

using Goedel.Cryptography.Nist;

using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Text.Json;
using System.Xml.Linq;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Goedel.Protocol;



/// <summary>
/// Factory delegate that returns a JSONObject.
/// </summary>
/// <returns>Object of the specified type</returns>
public delegate JsonObject JsonFactoryDelegate();

/// <summary>
/// Method dispatch delegate
/// </summary>
/// <param name="request">The request data.</param>
/// <param name="session">The connection session.</param>
/// <returns>The result.</returns>
public delegate JsonObject JsonDispatchDelegate(
                JsonObject request, IJpcSession session);


/// <summary>
/// Record describing a method.
/// </summary>
/// <param name="JsonFactoryDelegate">Delegate returning object of the request type.</param>
/// <param name="JsonDispatchDelegate">Dispatch method</param>
public readonly record struct JsonMethodDescription(
    JsonFactoryDelegate JsonFactoryDelegate,
    JsonDispatchDelegate JsonDispatchDelegate);


/// <summary>
/// Base class for JSON Objects.
/// </summary>
public abstract partial class JsonObject : IBinding {

    /// <summary>
    /// Primary key to use for the object.
    /// </summary>
    public virtual string _PrimaryKey => null;

    /// <summary>State of the object in a collection.</summary>
    public virtual SequenceEvent _State { get; set; }

    ///<summary>The enveloped object data.</summary> 
    public object Envelope;

    ///<summary>Key collection to be used to decrypt enveloped data within the object.</summary> 
    public object KeyLocate;

    ///<summary>The IANA content type to use for encoding</summary> 
    public virtual string? IanaMediaType => null;

    /// <summary>
    /// Secondary key/values pairs describing the object
    /// </summary>
    public virtual List<KeyValuePair<string, string>> _KeyValues => null;

    /// <summary>
    /// Tag values used as substitute for reflection internally.
    /// </summary>
    public virtual string _Tag => __Tag;

    /// <summary>
    /// Tag values used as substitute for reflection internally.
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

    /*
    ///<summary>The tag dictionary for decoding entries.</summary>
    public static Dictionary<string, JsonFactoryDelegate> TagDictionary => tagDictionary ??
        new Dictionary<string, JsonFactoryDelegate>().CacheValue(out tagDictionary);
    static Dictionary<string, JsonFactoryDelegate> tagDictionary;
    */

    ///<summary>Dictionary mapping types to binding definitions.</summary> 
    public static Dictionary<Type, Binding> BindingDictionary = [];

    ///<summary>Dictionary mapping types to binding definitions.</summary> 
    public static Dictionary<string, Binding> BindingNameDictionary = [];


    /*
    /// <summary>
    /// Add a dictionary to the persistence store decoder.
    /// </summary>
    /// <param name="dictionary">The dictionary to add</param>
    public static void AddDictionary(
                Dictionary<string, JsonFactoryDelegate> dictionary) => Append(TagDictionary, dictionary);
    */

    /// <summary>
    /// Append the values from the tag dictionary of this type to <paramref name="dictionary"/>.
    /// </summary>
    /// <param name="dictionary">The dictionary to append the values to.</param>
    public static void AddDictionary(
                    ref Dictionary<string, JsonFactoryDelegate> dictionary) {
        /*
        if (dictionary != TagDictionary) {
            Append(TagDictionary, dictionary);
            dictionary = TagDictionary;
            }

        */
        }


    /// <summary>
    /// Append the values from the tag dictionary of this type to <paramref name="dictionary"/>.
    /// </summary>
    /// <param name="dictionary">The dictionary to append the values to.</param>
    public static void AddDictionary(
                    ref Dictionary<Type, Binding> dictionary) {

        
        foreach (var pair in dictionary) {
            var binding = pair.Value;
            //Console.WriteLine($"Add {binding.Tag}");

            if (!BindingDictionary.ContainsKey(pair.Key)) {
                BindingDictionary.Add (pair.Key, binding);
                }

            if (!BindingNameDictionary.ContainsKey(binding.Tag)) {
                BindingNameDictionary.Add(binding.Tag, binding);
                }


            binding.TypeDictionary.Add(binding.Tag, binding);
            AddToParents(binding, binding.Parent);
            }
        }

    static void AddToParents(Binding binding, Binding parent) {

        if (parent is null) {
            return;
            }
        if (parent.TypeDictionary.ContainsKey(binding.Tag)) {
            return;
            }
        parent.TypeDictionary.Add(binding.Tag, binding);
        AddToParents(binding, parent.Parent);
        }



    ///<summary>The binding of the object.</summary> 
    public virtual Property[] _Properties { get; } = null;
    ///<inheritdoc/>
    public virtual Binding _Binding => _binding;

    ///<summary>Binding specification.</summary> 
    public static readonly Binding<JsonObject> _binding = null;


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static Dictionary<string, Property> _StaticProperties = new() {
        };

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static Dictionary<string, Property> _StaticAllProperties = new() {
        };

    ///<summary>Adcditional unparsed properties.</summary> 
    public Dictionary<string, JsonElement> UnparsedProperties { get; set; }


    /// <summary>
    /// Combine contents of the properties dictionaries <paramref name="first"/> and
    /// <paramref name="second"/>.
    /// </summary>
    /// <param name="first">The first dictionary to add.</param>
    /// <param name="second">The second dictionary to add.</param>
    /// <returns>The combined dictionary.</returns>
    public static Dictionary<string, Property> Combine(Binding first,
            Binding second) {

        // attach the description of the child to the parent.
        first.ChildClasses ??= new();
        first.ChildClasses.Add(second.Tag, second);

        //second.AllProperties = Combine(first.FullProperties, second.Properties);

        return second.AllProperties;
        }



    /// <summary>
    /// Combine contents of the properties dictionaries <paramref name="first"/> and
    /// <paramref name="second"/>.
    /// </summary>
    /// <param name="first">The first dictionary to add.</param>
    /// <param name="second">The second dictionary to add.</param>
    /// <returns>The combined dictionary.</returns>
    public static Dictionary<string, Property> Combine(Dictionary<string, Property> first,
            Dictionary<string, Property> second) {
        var result = new Dictionary<string, Property>();
        foreach (var entry in first) {
            result.Add(entry.Key, entry.Value);
            }
        foreach (var entry in second) {
            result.Add(entry.Key, entry.Value);
            }
        return result;
        }


    ///// <summary>The properties of the JsonObject instance.</summary>
    //public virtual Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///// <summary>The properties of the JsonObject instance.</summary>
    //public virtual Dictionary<string, Property> _Properties => _StaticProperties;

    ///// <summary>The properties of the parent JsonObject instance.</summary>
    //public virtual Dictionary<string, Property> _ParentProperties => null;

    /// <summary>
    /// Base constructor.
    /// </summary>
    public JsonObject() {
        //_Initialize();
        }

    /// <summary>
    /// Normalize the structure prior to signature or encryption operations.
    /// </summary>
    public virtual void Normalize () {
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
    /// Convert object to string in JSON form and return as a byte array.
    /// </summary>
    /// <returns>The data as a byte array.</returns>
    public byte[] ToBytes() => ToString().ToUTF8();

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
    /// Convert object to byte sequence in JSON form.
    /// </summary>
    /// <param name="tag">If true, serialization is tagged with the object type.</param>
    /// <param name="objectEncoding">The object encoding to use for serialization.</param>
    /// <returns>Data as byte sequence.</returns>
    public virtual byte[] GetBytes(bool tag = true,
                DataEncoding objectEncoding = DataEncoding.JSON) {

        var _JSONWriter = GetJsonWriter(objectEncoding);

        Serialize(_JSONWriter, tag);    // Hack: Point back to Serialize...
        return _JSONWriter.GetBytes;
        }

    /// <summary>
    /// Return a JsonWriter for the encoding <paramref name="objectEncoding"/>.
    /// </summary>
    /// <param name="objectEncoding">The object encoding to use for serialization.</param>
    /// <param name="output">The output stream.</param>
    /// <returns>The JsonWriter.</returns>
    public static JsonWriter GetJsonWriter(DataEncoding objectEncoding, Stream output = null) => objectEncoding switch {
        DataEncoding.JSON_B => new JsonBWriter(output),
        DataEncoding.JSON_C => new JsonBWriter(output),
        DataEncoding.JSON_D => new JsonBWriter(output),
        _ => new JsonWriter(output)
        };


    /// <summary>
    /// Serialize to the specified Writer.
    /// </summary>
    /// <param name="writer">Writer to serialize the data to</param>
    /// <param name="tagged">If true, serialization is tagged with the object type.</param>
    public virtual void Serialize(Writer writer, bool tagged = false) {
        //int indent = 1;
        bool first = true;
        if (tagged) {
            writer.WriteObjectStart();
            writer.WriteToken(_Tag, 0);
            }

        if (_Binding.Generic) {
            writer.WriteArrayStart();
            foreach (var entry in _Binding.AllProperties) {
                var tag = entry.Key;
                var property = entry.Value;

                if (!property.IsNull(this)) {
                    writer.WriteArraySeparator(ref first);
                    property.Serialize(this, writer);
                    }
                else if (property is PropertyStringTag) {
                    // This is going to have to be the first item to work.
                    writer.WriteArraySeparator(ref first);
                    property.Serialize(this, writer);
                    }
                else {
                    writer.WriteArraySeparator(ref first);
                    writer.WriteNull();
                    }
                }
            writer.WriteArrayEnd();
            }
        else {
            writer.WriteObjectStart();
            foreach (var entry in _Binding.AllProperties) {
                var tag = entry.Key;
                var property = entry.Value;

                if (!property.IsNull(this)) {
                    writer.WriteObjectSeparator(ref first);
                    writer.WriteToken(tag, 1);
                    property.Serialize(this, writer);
                    }
                else if (property is PropertyStringTag) {
                    writer.WriteObjectSeparator(ref first);
                    writer.WriteToken(tag, 1);
                    property.Serialize(this, writer);
                    }
                }
            writer.WriteObjectEnd();
            }
        if (tagged) {
            writer.WriteObjectEnd();
            }
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
    /// Write the object out to a file.
    /// </summary>
    /// <param name="fileName">Name of the file to create.</param>
    /// <param name="dataEncoding">The encoding to use</param>
    /// <param name="tagged">If true, tag the output with the object type</param>
    public long ToFile(string fileName, DataEncoding dataEncoding = DataEncoding.JSON, bool tagged = false) {
        using var outputStream = fileName.OpenFileNew();
        using var writer = dataEncoding.GetWriter(outputStream);
        Serialize(writer, tagged);
        outputStream.Flush();
        var length = outputStream.Length;
        outputStream.Close();
        return length;

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





    /// <summary>
    /// Perform a one pass streaming parse on data read from the file <paramref name="filename"/> 
    /// returning an object of type <paramref name="type"/>. This
    /// parser does not (currently) support schemas in which a variant object type is
    /// specified by the object property.
    /// </summary>
    /// <param name="type">The type of the object to return.</param>
    /// <param name="filename">The data to parse</param>
    /// <param name="tagged">If true, the data object has a typed wrapper.</param>
    /// <param name="collectUparsed">If true, collect unparseable items during the
    /// parse.</param>
    /// <returns>The typed, parsed object.</returns>
    public static T? StreamParse<T>(
                string filename,
                bool tagged = true,
                bool collectUparsed = false) where T : JsonObject {
        using var inputStream = filename.OpenFileRead();
        return StreamParseCore(typeof(T), new JsonBcdReader(inputStream), tagged, collectUparsed) as T;
        }


    /// <summary>
    /// Perform a one pass streaming parse on the data <paramref name="jsonReader"/>. This
    /// parser does not (currently) support schemas in which a variant object type is
    /// specified by the object property.
    /// </summary>
    /// <typeparam name="T">The type of the object to be returned.</typeparam>
    /// <param name="jsonReader">The data to parse</param>
    /// <param name="tagged">If true, the data object has a typed wrapper.</param>
    /// <param name="collectUparsed">If true, collect unparseable items during the
    /// parse.</param>
    /// <returns>The typed, parsed object.</returns>
    public static T? StreamParse<T>(
                    JsonReader jsonReader,
                    bool tagged = true,
                    bool collectUparsed = false) where T : JsonObject =>
                        StreamParseCore(typeof(T), jsonReader, tagged, collectUparsed) as T;

    /// <summary>
    /// Perform a one pass streaming parse on the data <paramref name="stream"/>. This
    /// parser does not (currently) support schemas in which a variant object type is
    /// specified by the object property.
    /// </summary>
    /// <typeparam name="T">The type of the object to be returned.</typeparam>
    /// <param name="stream">The data to parse</param>
    /// <param name="tagged">If true, the data object has a typed wrapper.</param>
    /// <param name="collectUparsed">If true, collect unparseable items during the
    /// parse.</param>
    /// <returns>The typed, parsed object.</returns>
    public static T? StreamParse<T>(
                    Stream stream,
                    bool tagged = true,
                    bool collectUparsed = false) where T : JsonObject =>
                        StreamParseCore(typeof(T), new JsonBcdReader(stream), tagged, collectUparsed) as T;

    /// <summary>
    /// Perform a one pass streaming parse on the data <paramref name="data"/>. This
    /// parser does not (currently) support schemas in which a variant object type is
    /// specified by the object property.
    /// </summary>
    /// <typeparam name="T">The type of the object to be returned.</typeparam>
    /// <param name="data">The data to parse</param>
    /// <param name="tagged">If true, the data object has a typed wrapper.</param>
    /// <param name="collectUparsed">If true, collect unparseable items during the
    /// parse.</param>
    /// <returns>The typed, parsed object.</returns>
    public static T? StreamParseTag<T>(
                    byte[] data,
                    bool tagged = true,
                    bool collectUparsed = false) where T : JsonObject =>
                        StreamParseCore(typeof(T), new JsonBcdReader(data), tagged, collectUparsed) as T;




    /// <summary>
    /// Perform a one pass streaming parse on the data <paramref name="data"/>. This
    /// parser does not (currently) support schemas in which a variant object type is
    /// specified by the object property.
    /// </summary>
    /// <typeparam name="T">The type of the object to be returned.</typeparam>
    /// <param name="data">The data to parse</param>
    /// <param name="tagged">If true, the data object has a typed wrapper.</param>
    /// <param name="collectUparsed">If true, collect unparseable items during the
    /// parse.</param>
    /// <returns>The typed, parsed object.</returns>
    public static T? StreamParseTag<T>(
                    byte[] data,
                    JpcInterface service,
                    bool collectUparsed = false) where T : JsonObject =>
                        StreamParseCore(typeof(T), new JsonBcdReader(data), true, collectUparsed,
                            service: service) as T;


    /// <summary>
    /// Perform a one pass streaming parse on the data <paramref name="data"/>. This
    /// parser does not (currently) support schemas in which a variant object type is
    /// specified by the object property.
    /// </summary>
    /// <typeparam name="T">The type of the object to be returned.</typeparam>
    /// <param name="data">The data to parse</param>
    /// <param name="tagged">If true, the data object has a typed wrapper.</param>
    /// <param name="collectUparsed">If true, collect unparseable items during the
    /// parse.</param>
    /// <returns>The typed, parsed object.</returns>
    public static T? StreamParse<T>(
                    byte[] data,
                    bool collectUparsed = false) where T : JsonObject =>
                        StreamParseCore(typeof(T), new JsonBcdReader(data), false, collectUparsed) as T;

    public static JsonObject ParseTagged(
            byte[] data,
            bool collectUparsed = false) => ParseTagged(new JsonBcdReader(data), collectUparsed);

    public static JsonObject ParseTagged(
                JsonReader reader,
                bool collectUparsed = false) {

        //var reader = new JsonBcdReader(data);
        var element = JsonElement2.Parse(reader) as JsonElementObject;

        //var document = JsonDocument.Parse(data);




        (element.Properties.Count == 1).AssertTrue(NYI.Throw);
        var p1 = element.SoloProperty();

        var typename = p1.Key;

        if (!BindingNameDictionary.TryGetValue(typename, out var binding)) {
            throw new NYI();
            }
        if (p1.Value is JsonElementObject jsonElementObject) {
            return Binding.Parse(jsonElementObject, binding, collectUparsed);
            }

        throw new NYI();
        }

    /// <summary>
    /// Perform a one pass streaming parse on the stream read using <paramref name="jsonReader"/> 
    /// returning an object of type <paramref name="type"/>. This
    /// parser does not (currently) support schemas in which a variant object type is
    /// specified by the object property.
    /// </summary>
    /// <param name="type">The type of the object to return.</param>
    /// <param name="jsonReader">A reader for the data.</param>
    /// <param name="tagged">If true, the data object has a typed wrapper.</param>
    /// <param name="collectUparsed">If true, collect unparseable items during the
    /// parse.</param>
    /// <returns>The typed, parsed object.</returns>
    /// <param name="service"></param>
    public static JsonObject? StreamParseCore(
                Type type,
                JsonReader jsonReader,
                bool tagged = true,
                bool collectUparsed = false, JpcInterface service = null) {

        if (!BindingDictionary.TryGetValue (type, out var binding)) {
            Console.WriteLine($"Type {type.FullName} not registered");
            throw new NYI();
            }

        // read the next object in the stream
        var element = JsonElement2.Parse(jsonReader);

        if (element is null) {
            return binding.Factory() as JsonObject;
            }

        if (element is JsonElementArray array) {
            var template = binding.Factory() as JsonObject;
            return Binding.Parse(array, binding, template, collectUparsed);
            }
        if (tagged) {
            return Binding.ParseTagged(element as JsonElementObject, binding, collectUparsed, service: service);
            }
        else {
            return Binding.Parse(element as JsonElementObject, binding, collectUparsed);
            }
        }

    }
