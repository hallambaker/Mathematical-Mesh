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
using System.IO.IsolatedStorage;
using System.Text.Json;

namespace Goedel.Protocol;





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

    ///<summary>The enveloped object data.</summary> 
    public object Enveloped;

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

    ///<summary>The tag dictionary for decoding entries.</summary>
    public static Dictionary<string, JsonFactoryDelegate> TagDictionary => tagDictionary ??
        new Dictionary<string, JsonFactoryDelegate>().CacheValue(out tagDictionary);
    static Dictionary<string, JsonFactoryDelegate> tagDictionary;


    ///<summary>Dictionary mapping types to binding definitions.</summary> 
    public static Dictionary<Type, Binding> BindingDictionary = [];

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
    /// Append the values from the tag dictionary of this type to <paramref name="dictionary"/>.
    /// </summary>
    /// <param name="dictionary">The dictionary to append the values to.</param>
    public static void AddDictionary(
                    ref Dictionary<Type, Binding> dictionary) {
        foreach (var pair in dictionary) {
            var binding = pair.Value;


            if (!BindingDictionary.ContainsKey(pair.Key)) {
                BindingDictionary.Add (pair.Key, binding);
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

        second.AllProperties = Combine(first.FullProperties, second.Properties);

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


    /// <summary>The properties of the JsonObject instance.</summary>
    public virtual Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    /// <summary>The properties of the JsonObject instance.</summary>
    public virtual Dictionary<string, Property> _Properties => _StaticProperties;

    /// <summary>The properties of the parent JsonObject instance.</summary>
    public virtual Dictionary<string, Property> _ParentProperties => null;

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

        Serialize(_JSONWriter, tag);    // Hack: Point back to Serialize...
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
    /// <param name="tagged">If true, serialization is tagged with the object type.</param>
    public virtual void Serialize(Writer writer, bool tagged = false) {
        //int indent = 1;
        bool first = true;
        if (tagged) {
            writer.WriteObjectStart();
            writer.WriteToken(_Tag, 0);
            }
        writer.WriteObjectStart();
        foreach (var entry in _AllProperties) {
            var tag = entry.Key;
            var property = entry.Value;

            if (!property.IsNull(this)) {
                writer.WriteObjectSeparator(ref first);
                writer.WriteToken(tag, 1);
                property.Serialize(this, writer);
                }

            }

        //Serialize(writer, true, ref first);
        writer.WriteObjectEnd();
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
    public void Deserialize(string input) {
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
                DeserializeToken3(jsonReader, Token);

                going = jsonReader.NextObject();
                }
            }
        PostDecode();
        }


    /// <summary>
    /// Deserialize the input stream to populate this object having recieved the specified tag.
    /// </summary>
    /// <param name="jsonReader">Input data</param>
    /// <param name="tag">Input tag</param>
    public void DeserializeToken3(JsonReader jsonReader, string tag) {

        if (_AllProperties.TryGetValue(tag, out var property)) {
            switch (property) {
                // Boolean
                case PropertyBoolean propertyTyped: {
                    var value = jsonReader.ReadBoolean();
                    propertyTyped.Set(this, value);
                    break;
                    }
                case PropertyListBoolean propertyTyped: {
                    bool going = jsonReader.StartArray();
                    var array = new List<bool>();
                    while (going) {
                        var value = jsonReader.ReadBoolean();
                        array.Add(value);
                        going = jsonReader.NextArray();
                        }
                    propertyTyped.Set(this, array);
                    break;
                    }
                case PropertyDictionaryBoolean propertyTyped: {
                    var dictionary = new Dictionary<string, bool>();
                    bool going = jsonReader.StartObject();
                    while (going) {
                        string Token = jsonReader.ReadToken();
                        var value = jsonReader.ReadBoolean();
                        dictionary.Add(Token, value);
                        going = jsonReader.NextObject();
                        }
                    propertyTyped.Set(this, dictionary);
                    break;
                    }


                // String
                case PropertyString propertyTyped: {
                    var value = jsonReader.ReadString();
                    propertyTyped.Set(this, value);
                    break;
                    }
                case PropertyListString propertyTyped: {
                    bool going = jsonReader.StartArray();
                    var array = new List<string>();
                    while (going) {
                        var value = jsonReader.ReadString();
                        array.Add(value);
                        going = jsonReader.NextArray();
                        }
                    propertyTyped.Set(this, array);
                    break;
                    }
                case PropertyDictionaryString propertyTyped: {
                    var dictionary = new Dictionary<string, string>();
                    bool going = jsonReader.StartObject();
                    while (going) {
                        string Token = jsonReader.ReadToken();
                        var value = jsonReader.ReadString();
                        dictionary.Add(Token, value);
                        going = jsonReader.NextObject();
                        }
                    propertyTyped.Set(this, dictionary);
                    break;
                    }

                // Binary
                case PropertyBinary propertyTyped: {
                    var value = jsonReader.ReadBinary();
                    propertyTyped.Set(this, value);
                    break;
                    }
                case PropertyListBinary propertyTyped: {
                    bool going = jsonReader.StartArray();
                    var array = new List<byte[]>();
                    while (going) {
                        var value = jsonReader.ReadBinary();
                        array.Add(value);
                        going = jsonReader.NextArray();
                        }
                    propertyTyped.Set(this, array);
                    break;
                    }
                case PropertyDictionaryBinary propertyTyped: {
                    var dictionary = new Dictionary<string, byte[]>();
                    bool going = jsonReader.StartObject();
                    while (going) {
                        string Token = jsonReader.ReadToken();
                        var value = jsonReader.ReadBinary();
                        dictionary.Add(Token, value);
                        going = jsonReader.NextObject();
                        }
                    propertyTyped.Set(this, dictionary);
                    break;
                    }

                // DateTime
                case PropertyDateTime propertyTyped: {
                    var value = jsonReader.ReadDateTime();
                    propertyTyped.Set(this, value);
                    break;
                    }
                case PropertyListDateTime propertyTyped: {
                    bool going = jsonReader.StartArray();
                    var array = new List<System.DateTime>();
                    while (going) {
                        var value = jsonReader.ReadDateTime();
                        array.Add(value);
                        going = jsonReader.NextArray();
                        }
                    propertyTyped.Set(this, array);
                    break;
                    }
                case PropertyDictionaryDateTime propertyTyped: {
                    var dictionary = new Dictionary<string, System.DateTime>();
                    bool going = jsonReader.StartObject();
                    while (going) {
                        string Token = jsonReader.ReadToken();
                        var value = jsonReader.ReadDateTime();
                        dictionary.Add(Token, value);
                        going = jsonReader.NextObject();
                        }
                    propertyTyped.Set(this, dictionary);
                    break;
                    }

                // Integer32
                case PropertyInteger32 propertyTyped: {
                    var value = jsonReader.ReadInteger32();
                    propertyTyped.Set(this, value);
                    break;
                    }
                case PropertyListInteger32 propertyTyped: {
                    bool going = jsonReader.StartArray();
                    var array = new List<int>();
                    while (going) {
                        var value = jsonReader.ReadInteger32();
                        array.Add(value);
                        going = jsonReader.NextArray();
                        }
                    propertyTyped.Set(this, array);
                    break;
                    }
                case PropertyDictionaryInteger32 propertyTyped: {
                    var dictionary = new Dictionary<string, int>();
                    bool going = jsonReader.StartObject();
                    while (going) {
                        string Token = jsonReader.ReadToken();
                        var value = jsonReader.ReadInteger32();
                        dictionary.Add(Token, value);
                        going = jsonReader.NextObject();
                        }

                    break;
                    }

                // Integer64
                case PropertyInteger64 propertyTyped: {
                    var value = jsonReader.ReadInteger64();
                    propertyTyped.Set(this, value);
                    break;
                    }
                case PropertyListInteger64 propertyTyped: {
                    bool going = jsonReader.StartArray();
                    var array = new List<long>();
                    while (going) {
                        var value = jsonReader.ReadInteger64();
                        array.Add(value);
                        going = jsonReader.NextArray();
                        }
                    propertyTyped.Set(this, array);
                    break;
                    }
                case PropertyDictionaryInteger64 propertyTyped: {
                    var dictionary = new Dictionary<string, long>();
                    bool going = jsonReader.StartObject();
                    while (going) {
                        string Token = jsonReader.ReadToken();
                        var value = jsonReader.ReadInteger64();
                        dictionary.Add(Token, value);
                        going = jsonReader.NextObject();
                        }
                    propertyTyped.Set(this, dictionary);
                    break;
                    }

                // Real32
                case PropertyReal32 propertyTyped: {
                    var value = jsonReader.ReadFloat32();
                    propertyTyped.Set(this, value);
                    break;
                    }
                case PropertyListReal32 propertyTyped: {
                    bool going = jsonReader.StartArray();
                    var array = new List<float>();
                    while (going) {
                        var value = jsonReader.ReadFloat32();
                        array.Add(value);
                        going = jsonReader.NextArray();
                        }
                    propertyTyped.Set(this, array);
                    break;
                    }
                case PropertyDictionaryReal32 propertyTyped: {
                    var dictionary = new Dictionary<string, float>();
                    bool going = jsonReader.StartObject();
                    while (going) {
                        string Token = jsonReader.ReadToken();
                        var value = jsonReader.ReadFloat32();
                        dictionary.Add(Token, value);
                        going = jsonReader.NextObject();
                        }
                    propertyTyped.Set(this, dictionary);
                    break;
                    }

                // Real64
                case PropertyReal64 propertyTyped: {
                    var value = jsonReader.ReadFloat64();
                    propertyTyped.Set(this, value);
                    break;
                    }
                case PropertyListReal64 propertyTyped: {
                    bool going = jsonReader.StartArray();
                    var array = new List<double>();
                    while (going) {
                        var value = jsonReader.ReadFloat64();
                        array.Add(value);
                        going = jsonReader.NextArray();
                        }
                    propertyTyped.Set(this, array);
                    break;
                    }
                case PropertyDictionaryReal64 propertyTyped: {
                    var dictionary = new Dictionary<string, double>();
                    bool going = jsonReader.StartObject();
                    while (going) {
                        string Token = jsonReader.ReadToken();
                        var value = jsonReader.ReadFloat64();
                        dictionary.Add(Token, value);
                        going = jsonReader.NextObject();
                        }
                    propertyTyped.Set(this, dictionary);
                    break;
                    }

                // Struct
                case PropertyStruct propertyTyped: {
                    if (property.Tagged) {
                        var value = jsonReader.ReadTaggedObject(TagDictionary);
                        propertyTyped.Set(this, value);
                        }
                    else {
                        var value = propertyTyped.Factory() as JsonObject;
                        value.Deserialize(jsonReader);
                        propertyTyped.Set(this, value);
                        }

                    break;
                    }
                case PropertyListStruct propertyTyped: {
                    var array = propertyTyped.Factory() as System.Collections.IList;
                    bool going = jsonReader.StartArray();
                    while (going) {
                        if (property.Tagged) {
                            var value = jsonReader.ReadTaggedObject(TagDictionary);
                            array.Add(value);
                            }
                        else {

                            var value = propertyTyped.IFactory() as JsonObject;
                            value.Deserialize(jsonReader);
                            array.Add(value);
                            }
                        going = jsonReader.NextArray();
                        }
                    propertyTyped.Set(this, array);
                    break;
                    }
                case PropertyDictionaryStruct propertyTyped: {
                    var dictionary = propertyTyped.Factory();
                    bool going = jsonReader.StartObject();
                    while (going) {
                        string Token = jsonReader.ReadToken();
                        var value = propertyTyped.IFactory() as JsonObject;
                        value.Deserialize(jsonReader);

                        propertyTyped.Add(dictionary, Token, value);

                        going = jsonReader.NextObject();
                        }
                    propertyTyped.Set(this, dictionary);
                    break;
                    }

                default: {
                    break;
                    }
                }
            }
        else {
            throw new UnknownTag(); // NYI: should modify this to allow arbitrary values
            }

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
    /// Parse the JSON document <paramref name="document"/> returning an
    /// object instance of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">Type of the object to return.</typeparam>
    /// <param name="document">The document to parse.</param>
    /// <param name="collectUparsed">If true, collect up unknown elements in the 
    /// returned instance.</param>
    /// <returns>The parsed object.</returns>
    public static T? Parse<T>(
                    JsonDocument document,
                    bool collectUparsed = false) where T : JsonObject, new() =>
        Parse<T>(document.RootElement, collectUparsed);

    /// <summary>
    /// Parse the JSON element <paramref name="element"/> returning an
    /// object instance of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">Type of the object to return.</typeparam>
    /// <param name="element">The document to parse.</param>
    /// <param name="collectUparsed">If true, collect up unknown elements in the 
    /// returned instance.</param>
    /// <returns>The parsed object.</returns>
    public static T? Parse<T>(
                JsonElement element,
                bool collectUparsed = false) where T : JsonObject, new() {
        if (element.ValueKind != JsonValueKind.Object) {
            return null;
            }

        var type = typeof(T);
        if (!BindingDictionary.TryGetValue(type, out var binding)) {
            return null;
            }

        return Parse(element, binding, collectUparsed) as T;
        }


    /// <summary>
    /// Parse the JSON element <paramref name="element"/> returning a JsonObject
    /// of the type specified by <paramref name="binding"/>.
    /// </summary>

    /// <param name="element">The document to parse.</param>
    /// <param name="binding">The type binding describing the object class.</param>
    /// <param name="collectUparsed">If true, collect up unknown elements in the 
    /// returned instance.</param>
    /// <returns>The parsed object.</returns>
    public static JsonObject Parse (
                JsonElement element,
                Binding binding,
                bool collectUparsed = false) {

        JsonObject? template = null;
        if (binding.TypeTag == null) {
            template = (JsonObject)binding.Factory();
            }
        else {
            if (element.TryGetProperty(binding.TypeTag, out var typeField)) {
                if (typeField.ValueKind == JsonValueKind.String) {
                    if (binding.TypeDictionary.TryGetValue(typeField.GetString(), out var subBinding)) {
                        template = (JsonObject)subBinding.Factory();
                        }
                    }
                }
            else {
                template = (JsonObject)binding.Factory();
                }
            }

        foreach (var property in element.EnumerateObject()) {
            var collect = collectUparsed;
            if (template._AllProperties.TryGetValue(property.Name, out var propertyValue)) {
                collect &= MapProperty (template, property.Value, propertyValue);
                }
            if (collect) {
                template.UnparsedProperties ??= [];
                template.UnparsedProperties.Add(property.Name, property.Value);
                }
            }

        return template;
        }

    /// <summary>
    /// Map the JSON element <paramref name="element"/> onto the object <paramref name="target"/>
    /// under the property description <paramref name="specifier"/>.
    /// </summary>
    /// <param name="target"></param>
    /// <param name="element"></param>
    /// <param name="specifier"></param>
    /// <returns>True if successful, otherwise false.</returns>
    public static bool MapProperty(
                JsonObject target,
                JsonElement element,
                Property specifier) {

        switch (specifier) {
            #region // Boolean
            case PropertyBoolean subProperty: {
                if (element.ValueKind == JsonValueKind.True) {
                    subProperty.Set(target, true);
                    return true;
                    }
                if (element.ValueKind == JsonValueKind.False) {
                    subProperty.Set(target, false);
                    return false;
                    }
                return false;
                }
            case PropertyListBoolean subProperty: {
                if (element.ValueKind == JsonValueKind.Array) {
                    var collected = true;
                    var array = new List<bool>();
                    subProperty.Set(target, array);

                    foreach (var member in element.EnumerateArray()) {
                        if (member.ValueKind == JsonValueKind.True) {
                            array.Add(true);
                            }
                        else if (member.ValueKind == JsonValueKind.False) {
                            array.Add(false);
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            case PropertyDictionaryBoolean subProperty: {
                if (element.ValueKind == JsonValueKind.Object) {
                    var collected = true;
                    var array = new Dictionary<string, bool>();
                    subProperty.Set(target, array);

                    foreach (var member in element.EnumerateObject()) {
                        if (member.Value.ValueKind == JsonValueKind.True) {
                            array.Add(member.Name, true);
                            }
                        else if (member.Value.ValueKind == JsonValueKind.False) {
                            array.Add(member.Name, false);
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            #endregion
            #region // String

            case PropertyString subProperty: {
                if (element.ValueKind == JsonValueKind.String) {
                    subProperty.Set(target, element.GetString());
                    return true;
                    }
                return false;
                }
            case PropertyListString subProperty: {
                if (element.ValueKind == JsonValueKind.Array) {
                    var collected = true;
                    var array = new List<string>();
                    subProperty.Set(target, array);

                    foreach (var member in element.EnumerateArray()) {
                        if (member.ValueKind == JsonValueKind.String) {
                            array.Add(member.GetString());
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            case PropertyDictionaryString subProperty: {
                if (element.ValueKind == JsonValueKind.Object) {
                    var collected = true;
                    var array = new Dictionary<string, string>();
                    subProperty.Set(target, array);

                    foreach (var member in element.EnumerateObject()) {
                        if (member.Value.ValueKind == JsonValueKind.String) {
                            array.Add(member.Name, member.Value.GetString());
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            #endregion
            #region // Int32
            case PropertyInteger32 subProperty: {
                if (element.ValueKind == JsonValueKind.Number) {
                    subProperty.Set(target, element.GetInt32());
                    return true;
                    }
                return false;
                }
            case PropertyListInteger32 subProperty: {
                if (element.ValueKind == JsonValueKind.Array) {
                    var collected = true;
                    var array = new List<int>();
                    subProperty.Set(target, array);

                    foreach (var member in element.EnumerateArray()) {
                        if (member.ValueKind == JsonValueKind.Number) {
                            array.Add(member.GetInt32());
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            case PropertyDictionaryInteger32 subProperty: {
                if (element.ValueKind == JsonValueKind.Object) {
                    var collected = true;
                    var array = new Dictionary<string, int>();
                    subProperty.Set(target, array);

                    foreach (var member in element.EnumerateObject()) {
                        if (member.Value.ValueKind == JsonValueKind.Number) {
                            array.Add(member.Name, member.Value.GetInt32());
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            #endregion
            #region // Int64
            case PropertyInteger64 subProperty: {
                if (element.ValueKind == JsonValueKind.Number) {
                    subProperty.Set(target, element.GetInt64());
                    return true;
                    }
                return false;
                }
            case PropertyListInteger64 subProperty: {
                if (element.ValueKind == JsonValueKind.Array) {
                    var collected = true;
                    var array = new List<long>();
                    subProperty.Set(target, array);

                    foreach (var member in element.EnumerateArray()) {
                        if (member.ValueKind == JsonValueKind.Number) {
                            array.Add(member.GetInt64());
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            case PropertyDictionaryInteger64 subProperty: {
                if (element.ValueKind == JsonValueKind.Object) {
                    var collected = true;
                    var array = new Dictionary<string, long>();
                    subProperty.Set(target, array);

                    foreach (var member in element.EnumerateObject()) {
                        if (member.Value.ValueKind == JsonValueKind.Number) {
                            array.Add(member.Name, member.Value.GetInt64());
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            #endregion
            #region // Real32
            case PropertyReal32 subProperty: {
                if (element.ValueKind == JsonValueKind.Number) {
                    subProperty.Set(target, element.GetSingle());
                    return true;
                    }
                return false;
                }
            case PropertyListReal32 subProperty: {
                if (element.ValueKind == JsonValueKind.Array) {
                    var collected = true;
                    var array = new List<float>();
                    subProperty.Set(target, array);

                    foreach (var member in element.EnumerateArray()) {
                        if (member.ValueKind == JsonValueKind.Number) {
                            array.Add(member.GetSingle());
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            case PropertyDictionaryReal32 subProperty: {
                if (element.ValueKind == JsonValueKind.Object) {
                    var collected = true;
                    var array = new Dictionary<string, float>();
                    subProperty.Set(target, array);

                    foreach (var member in element.EnumerateObject()) {
                        if (member.Value.ValueKind == JsonValueKind.Number) {
                            array.Add(member.Name, member.Value.GetSingle());
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            #endregion
            #region // Real64
            case PropertyReal64 subProperty: {
                if (element.ValueKind == JsonValueKind.Number) {
                    subProperty.Set(target, element.GetDouble());
                    return true;
                    }
                return false;
                }
            case PropertyListReal64 subProperty: {
                if (element.ValueKind == JsonValueKind.Array) {
                    var collected = true;
                    var array = new List<double>();
                    subProperty.Set(target, array);

                    foreach (var member in element.EnumerateArray()) {
                        if (member.ValueKind == JsonValueKind.Number) {
                            array.Add(member.GetDouble());
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            case PropertyDictionaryReal64 subProperty: {
                if (element.ValueKind == JsonValueKind.Object) {
                    var collected = true;
                    var array = new Dictionary<string, double>();
                    subProperty.Set(target, array);

                    foreach (var member in element.EnumerateObject()) {
                        if (member.Value.ValueKind == JsonValueKind.Number) {
                            array.Add(member.Name, member.Value.GetDouble());
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            #endregion
            #region // DateTime
            case PropertyDateTime subProperty: {
                if (element.ValueKind == JsonValueKind.String) {
                    subProperty.Set(target, element.GetDateTime());
                    return true;
                    }
                return false;
                }
            case PropertyListDateTime subProperty: {
                if (element.ValueKind == JsonValueKind.Array) {
                    var collected = true;
                    var array = new List<DateTime>();
                    subProperty.Set(target, array);

                    foreach (var member in element.EnumerateArray()) {
                        if (member.ValueKind == JsonValueKind.String) {
                            array.Add(member.GetDateTime());
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            case PropertyDictionaryDateTime subProperty: {
                if (element.ValueKind == JsonValueKind.Object) {
                    var collected = true;
                    var array = new Dictionary<string, DateTime>();
                    subProperty.Set(target, array);

                    foreach (var member in element.EnumerateObject()) {
                        if (member.Value.ValueKind == JsonValueKind.String) {
                            array.Add(member.Name, member.Value.GetDateTime());
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            #endregion
            #region // Binary
            case PropertyBinary subProperty: {
                if (element.ValueKind == JsonValueKind.String) {
                    var value = element.GetString().FromBase64();
                    subProperty.Set(target, value);
                    return true;
                    }
                return false;
                }
            case PropertyListBinary subProperty: {
                if (element.ValueKind == JsonValueKind.Array) {
                    var collected = true;
                    var array = new List<byte[]>();
                    subProperty.Set(target, array);

                    foreach (var member in element.EnumerateArray()) {
                        if (member.ValueKind == JsonValueKind.String) {
                            var value = member.GetString().FromBase64();
                            array.Add(value);
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            case PropertyDictionaryBinary subProperty: {
                if (element.ValueKind == JsonValueKind.Object) {
                    var collected = true;
                    var array = new Dictionary<string, byte[]>();
                    subProperty.Set(target, array);

                    foreach (var member in element.EnumerateObject()) {
                        if (member.Value.ValueKind == JsonValueKind.String) {
                            var value = member.Value.GetString().FromBase64();
                            array.Add(member.Name, value);
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            #endregion
            #region // Struct
            case PropertyStruct subProperty: {
                if (element.ValueKind == JsonValueKind.Object) {
                    if (!BindingDictionary.TryGetValue(subProperty.Type, out var binding)) {
                        return false;
                        }
                    if (subProperty.Tagged) {
                        var item = ParseTagged(element, binding);
                        subProperty.Set(target, item);
                        }
                    else {
                        var item = Parse(element, binding);
                        subProperty.Set(target, item);
                        }
                    }
                return false;
                }
            case PropertyListStruct subProperty: {
                if (element.ValueKind == JsonValueKind.Array) {
                    if (!BindingDictionary.TryGetValue(subProperty.Type, out var binding)) {
                        return false;
                        }
                    var collected = true;
                    var array = binding.ListFactory();
                    subProperty.Set(target, array);

                    foreach (var member in element.EnumerateArray()) {
                        if (member.ValueKind == JsonValueKind.Object) {

                            if (subProperty.Tagged) {
                                var item = ParseTagged(member, binding);
                                binding.ListAdd(array, item);
                                }
                            else {
                                var item = Parse(member, binding);
                                binding.ListAdd(array, item);
                                }
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            case PropertyDictionaryStruct subProperty: {
                if (element.ValueKind == JsonValueKind.Object) {
                    if (!BindingDictionary.TryGetValue(subProperty.Type, out var binding)) {
                        return false;
                        }
                    var collected = true;
                    var array = binding.DictionaryFactory();
                    subProperty.Set(target, array);

                    foreach (var member in element.EnumerateObject()) {
                        if (member.Value.ValueKind == JsonValueKind.Object) {
                            if (subProperty.Tagged) {
                                var item = ParseTagged(member.Value, binding);
                                binding.DictionaryAdd(array, member.Name, item);
                                }
                            else {
                                var item = Parse(member.Value, binding);
                                binding.DictionaryAdd(array, member.Name, item);
                                }
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            #endregion
            }

        return false;

        }


    static JsonObject ParseTagged(
                JsonElement element,
                Binding binding
                ) {
        foreach (var member in element.EnumerateObject()) {
            if (binding.TypeDictionary.TryGetValue(member.Name, out var subBinding)) {
                if (member.Value.ValueKind == JsonValueKind.Object) {
                    return Parse(member.Value, binding);
                    }
                }
            return null;
            }
        return null;
        }

    }
