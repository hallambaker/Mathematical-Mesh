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

using System.Formats.Asn1;

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
public abstract partial class JsonObject {

    /// <summary>
    /// Primary key to use for the object.
    /// </summary>
    public virtual string _PrimaryKey => null;

    ///<summary>The enveloped object data.</summary> 
    public object Enveloped;

    ///<summary>Key collection to be used to decrypt enveloped data within the object.</summary> 
    public object KeyLocate;


    ///<summary>The parser data binding.</summary> 
    public JbcdValueObject JbcdElementObject { get; set; }    

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


    ///<summary>Link to the parent metadata dictionary.</summary> 
    public virtual Dictionary<string, MetaData> _MetaDataParent => null;


    /// <summary>
    /// The Metadata dictionary for the serializable data.
    /// </summary>
    public virtual Dictionary<string, MetaData> _MetaData => new() { };



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


    public virtual Binding Binding => _binding;
    protected static Binding _binding = null;



    /// <summary>
    /// Sets the values of the property <paramref name="tag"/> to the values specified
    /// by <paramref name="value"/>.
    /// </summary>
    /// <param name="tag">The string representation of the tag.</param>
    /// <param name="value">The tokenized values.</param>
    public virtual void Setter(
            string tag, TokenValue value) => _Unregistered[tag] = value;


    /// <summary>
    /// Gets the values of the property <paramref name="tag"/>;
    /// </summary>
    /// <param name="tag">The string representation of the tag.</param>
    /// <returns>The values of the property with tag <paramref name="tag"/>.</returns>
    public virtual TokenValue Getter(
                string tag) => _unregistered == null ? TokenValue.Unknown :
                    _unregistered.ContainsKey(tag) ? _unregistered[tag] : TokenValue.Unknown;

    /// <summary>
    /// Dictionary of unregistered tags encountered when attempting to deserialize a
    /// document.
    /// </summary>
    public Dictionary<string, TokenValue> _Unregistered => _unregistered ??
        new Dictionary<string, TokenValue>().CacheValue(out _unregistered);
    Dictionary<string, TokenValue> _unregistered;


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static Dictionary<string, Property> _StaticProperties = new() {
        };

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static Dictionary<string, Property> _StaticAllProperties = new() {
        };

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

            var value = Getter(tag);

            //Console.WriteLine($"Tag {tag} = {values.IsEmpty}");


            if (!value.IsEmpty) {
                writer.WriteObjectSeparator(ref first);
                writer.WriteToken(tag, 1);
                if (value is TokenValueStruct x) {
                    x.Serialize(writer, property.Tagged);
                    }
                else if(value is TokenValueListStruct lx) {
                    lx.Serialize(writer, property.Tagged);
                    }
                else {
                    value.Serialize(writer);
                    }
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
                DeserializeToken2(jsonReader, Token);
                
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
    public void DeserializeToken2(JsonReader jsonReader, string tag) {

        if (_AllProperties.TryGetValue(tag, out var property)) {
            if (property.Multiple) {
                if (property.TokenType == typeof(TokenValueListBoolean)) {
                    bool going = jsonReader.StartArray();
                    var array = new List<bool?>();
                    while (going) {
                        var value = jsonReader.ReadBoolean();
                        array.Add(value);
                        going = jsonReader.NextArray();
                        }
                    Setter(tag, new TokenValueListBoolean(array));
                    }
                else if (property.TokenType == typeof(TokenValueListString)) {
                    bool going = jsonReader.StartArray();
                    var array = new List<string?>();
                    while (going) {
                        var value = jsonReader.ReadString();
                        array.Add(value);
                        going = jsonReader.NextArray();
                        }
                    Setter(tag, new TokenValueListString(array));
                    }
                else if (property.TokenType == typeof(TokenValueListBinary)) {
                    bool going = jsonReader.StartArray();
                    var array = new List<byte[]>();
                    while (going) {
                        var value = jsonReader.ReadBinary();
                        array.Add(value);
                        going = jsonReader.NextArray();
                        }
                    Setter(tag, new TokenValueListBinary(array));
                    }
                else if (property.TokenType == typeof(TokenValueListDateTime)) {
                    bool going = jsonReader.StartArray();
                    var array = new List<System.DateTime?>();
                    while (going) {
                        var value = jsonReader.ReadDateTime();
                        array.Add(value);
                        going = jsonReader.NextArray();
                        }
                    Setter(tag, new TokenValueListDateTime(array));
                    }
                else if (property.TokenType == typeof(TokenValueListInteger32)) {
                    bool going = jsonReader.StartArray();
                    var array = new List<int?>();
                    while (going) {
                        var value = jsonReader.ReadInteger32();
                        array.Add(value);
                        going = jsonReader.NextArray();
                        }
                    Setter(tag, new TokenValueListInteger32(array));
                    }
                else if (property.TokenType == typeof(TokenValueListInteger64)) {
                    bool going = jsonReader.StartArray();
                    var array = new List<long?>();
                    while (going) {
                        var value = jsonReader.ReadInteger64();
                        array.Add(value);
                        going = jsonReader.NextArray();
                        }
                    Setter(tag, new TokenValueListInteger64(array));
                    }
                else if (property.TokenType == typeof(TokenValueListReal32)) {
                    bool going = jsonReader.StartArray();
                    var array = new List<float?>();
                    while (going) {
                        var value = jsonReader.ReadFloat32();
                        array.Add(value);
                        going = jsonReader.NextArray();
                        }
                    Setter(tag, new TokenValueListReal32(array));
                    }
                else if (property.TokenType == typeof(TokenValueListReal64)) {
                    bool going = jsonReader.StartArray();
                    var array = new List<double?>();
                    while (going) {
                        var value = jsonReader.ReadFloat64();
                        array.Add(value);
                        going = jsonReader.NextArray();
                        }
                    Setter(tag, new TokenValueListReal64(array));
                    }
                else if (property.TokenType == typeof(TokenValueListStruct)) {
                    var array = property.Factory() as System.Collections.IList;
                    bool going = jsonReader.StartArray();
                    while (going) {
                        if (property.Tagged) {
                            var value = jsonReader.ReadTaggedObject(TagDictionary);
                            array.Add(value);
                            }
                        else {
                            var value = property.IFactory() as JsonObject;
                            value.Deserialize(jsonReader);
                            array.Add(value);
                            }
                        going = jsonReader.NextArray();
                        }
                    Setter(tag, new TokenValueListStructObject(array));
                    }
                }
            else {
                if (property.TokenType == typeof(TokenValueBoolean)) {
                    var value = jsonReader.ReadBoolean();
                    Setter(tag, new TokenValueBoolean(value));
                    }
                else if (property.TokenType == typeof(TokenValueString)) {
                    var value = jsonReader.ReadString();
                    Setter(tag, new TokenValueString(value));
                    }
                else if (property.TokenType == typeof(TokenValueBinary)) {
                    var value = jsonReader.ReadBinary();
                    Setter(tag, new TokenValueBinary(value));
                    }
                else if (property.TokenType == typeof(TokenValueDateTime)) {
                    var value = jsonReader.ReadDateTime();
                    Setter(tag, new TokenValueDateTime(value));
                    }
                else if (property.TokenType == typeof(TokenValueInteger32)) {
                    var value = jsonReader.ReadInteger32();
                    Setter(tag, new TokenValueInteger32(value));
                    }
                else if (property.TokenType == typeof(TokenValueInteger64)) {
                    var value = jsonReader.ReadInteger64();
                    Setter(tag, new TokenValueInteger64(value));
                    }
                else if (property.TokenType == typeof(TokenValueReal32)) {
                    var value = jsonReader.ReadFloat32();
                    Setter(tag, new TokenValueReal32(value));
                    }
                else if (property.TokenType == typeof(TokenValueReal64)) {
                    var value = jsonReader.ReadFloat64();
                    Setter(tag, new TokenValueReal64(value));
                    }
                else if (property.TokenType == typeof(TokenValueStruct)) {
                    if (property.Tagged) {
                        var value = jsonReader.ReadTaggedObject(TagDictionary);
                        Setter(tag, new TokenValueStructObject(value));
                        }
                    else {
                        var value = property.Factory() as JsonObject;
                        value.Deserialize(jsonReader);
                        Setter(tag, new TokenValueStructObject(value));
                        }
                    }
                }
            }
        else {
            throw new UnknownTag(); // NYI: should modify this to allow arbitrary values
            }

        }


    /// <summary>
    /// Deserialize the input stream to populate this object having recieved the specified tag.
    /// </summary>
    /// <param name="jsonReader">Input data</param>
    /// <param name="tag">Input tag</param>
    public virtual void DeserializeToken(JsonReader jsonReader, string tag) {
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
