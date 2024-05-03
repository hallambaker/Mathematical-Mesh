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


using System.Collections;

namespace Goedel.Protocol;


/// <summary>
/// Interface of a bindable object.
/// </summary>
public interface IBinding {

    ///<summary>The binding of the object.</summary> 
    Binding _Binding { get; }
    }

/// <summary>
/// Binding specification.
/// </summary>
/// <param name="Properties">Dictionary mapping the property tag to the field specification.</param>
/// <param name="Tag">JSON tag for this object.</param>
/// <param name="Factory">Factory returning a new instance of this object.</param>
/// <param name="Parent">Parent the object inherits from.</param>
public record Binding(
            Dictionary<string, Property> Properties,
            string Tag,
            Func<object> Factory,
            Binding Parent = null
            ) {
    }



/// <summary>
/// Metadate record representing a property.
/// </summary>
/// <param name="Multiple">If true, represents a list of entries.</param>
/// <param name="Tagged">If true, structures are to be represented as a tagged structure.</param>
/// <param name="Tag">Tag identifying this property in JSON serialization</param>
///// <param name="tagDictionary">Tag dictionary to be used to deserialize the property.</param>
public abstract record Property(
            string Tag,
            bool Multiple,
            bool Tagged=false) {


    /// <summary>
    /// Serialize a token to the writer <paramref name="writer"/>.
    /// </summary>
    /// <param name="writer">The writer to emit the structured data to.</param>
    /// <param name="data">The data to serialize.</param>
    public virtual void Serialize(IBinding data, Writer writer) {
        }

    /// <summary>
    /// Return true if and only if the property in <paramref name="data"/> is null.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public abstract bool IsNull(IBinding data);
    }

/// <summary>
/// Metadata record representing a property.
/// </summary>
/// <param name="Tag">Tag identifying this property in JSON serialization</param>
/// <param name="Set">Set the property to the specified value.</param>
/// <param name="Get">Return the value of the property.</param>
public record PropertyBoolean(
            string Tag,
            Action<IBinding, bool?> Set,
            Func<IBinding, bool?> Get) : Property(Tag, false) {


    ///<inheritdoc/>
    public override void Serialize(IBinding data, Writer writer) {
        var value = Get(data);
        if (value != null) {
            writer.WriteBoolean(value);
            }
        }

    ///<inheritdoc/>
    public override bool IsNull(IBinding data) => Get(data) == null;
    }

/// <summary>
/// Metadata record representing a property.
/// </summary>
/// <param name="Tag">Tag identifying this property in JSON serialization</param>
/// <param name="Set">Set the property to the specified value.</param>
/// <param name="Get">Return the value of the property.</param>
public record PropertyListBoolean(
            string Tag,
            Action<IBinding, List<bool>?> Set,
            Func<IBinding, List<bool>?> Get) :  Property(Tag, true) {

    ///<inheritdoc/>
    public override void Serialize(IBinding data, Writer writer) {
        var value = Get(data);
        if (value != null) {
            var first = true;

            writer.WriteArrayStart();
            foreach (var entry in value) {
                writer.WriteArraySeparator(ref first);
                writer.WriteBoolean(entry);
                }
            writer.WriteArrayEnd();
            }
        }

    ///<inheritdoc/>
    public override bool IsNull(IBinding data) => Get(data) == null;
    }

/// <summary>
/// Metadata record representing a property.
/// </summary>
/// <param name="Tag">Tag identifying this property in JSON serialization</param>
/// <param name="Set">Set the property to the specified value.</param>
/// <param name="Get">Return the value of the property.</param>
public record PropertyString (
            string Tag,
            Action<IBinding, string?> Set,
            Func<IBinding, string?> Get): Property(Tag, false) {


    ///<inheritdoc/>
    public override void Serialize(IBinding data, Writer writer) {
        var value = Get(data);
        if (value != null) {
            writer.WriteString(value);
            }
        }

    ///<inheritdoc/>
    public override bool IsNull(IBinding data) => Get(data) == null;
    }

/// <summary>
/// Metadata record representing a property.
/// </summary>
/// <param name="Tag">Tag identifying this property in JSON serialization</param>
/// <param name="Set">Set the property to the specified value.</param>
/// <param name="Get">Return the value of the property.</param>
public record PropertyListString(
            string Tag,
            Action<IBinding, List<string>?> Set,
            Func<IBinding, List<string>?> Get) : Property(Tag, true) {
    ///<inheritdoc/>
    public override void Serialize(IBinding data, Writer writer) {
        var value = Get(data);
        if (value != null) {
            var first = true;

            writer.WriteArrayStart();
            foreach (var entry in value) {
                writer.WriteArraySeparator(ref first);
                writer.WriteString(entry);
                }
            writer.WriteArrayEnd();
            }
        }

    ///<inheritdoc/>
    public override bool IsNull(IBinding data) => Get(data) == null;
    }

/// <summary>
/// Metadata record representing a property.
/// </summary>
/// <param name="Tag">Tag identifying this property in JSON serialization</param>
/// <param name="Set">Set the property to the specified value.</param>
/// <param name="Get">Return the value of the property.</param>
public record PropertyBinary(
            string Tag,
            Action<IBinding, byte[]?> Set,
            Func<IBinding, byte[]?> Get) : Property(Tag, false) {
    ///<inheritdoc/>
    public override void Serialize(IBinding data, Writer writer) {
        var value = Get(data);
        if (value != null) {
            writer.WriteBinary(value);
            }
        }

    ///<inheritdoc/>
    public override bool IsNull(IBinding data) => Get(data) == null;
    }

/// <summary>
/// Metadata record representing a property.
/// </summary>
/// <param name="Tag">Tag identifying this property in JSON serialization</param>
/// <param name="Set">Set the property to the specified value.</param>
/// <param name="Get">Return the value of the property.</param>
public record PropertyListBinary(
            string Tag,
            Action<IBinding, List<byte[]>?> Set,
            Func<IBinding, List<byte[]>?> Get) : Property(Tag, true) {
    ///<inheritdoc/>
    public override void Serialize(IBinding data, Writer writer) {
        var value = Get(data);
        if (value != null) {
            var first = true;

            writer.WriteArrayStart();
            foreach (var entry in value) {
                writer.WriteArraySeparator(ref first);
                writer.WriteBinary(entry);
                }
            writer.WriteArrayEnd();
            }
        }

    ///<inheritdoc/>
    public override bool IsNull(IBinding data) => Get(data) == null;
    }

/// <summary>
/// Metadata record representing a property.
/// </summary>
/// <param name="Tag">Tag identifying this property in JSON serialization</param>
/// <param name="Set">Set the property to the specified value.</param>
/// <param name="Get">Return the value of the property.</param>
public record PropertyDateTime(
            string Tag,
            Action<IBinding, DateTime?> Set,
            Func<IBinding, DateTime?> Get) : Property(Tag, false) {
    ///<inheritdoc/>
    public override void Serialize(IBinding data, Writer writer) {
        var value = Get(data);
        if (value != null) {
            writer.WriteDateTime(value);
            }
        }

    ///<inheritdoc/>
    public override bool IsNull(IBinding data) => Get(data) == null;
    }

/// <summary>
/// Metadata record representing a property.
/// </summary>
/// <param name="Tag">Tag identifying this property in JSON serialization</param>
/// <param name="Set">Set the property to the specified value.</param>
/// <param name="Get">Return the value of the property.</param>
public record PropertyListDateTime(
            string Tag,
            Action<IBinding, List<DateTime>?> Set,
            Func<IBinding, List<DateTime>?> Get) : Property(Tag, true) {
    ///<inheritdoc/>
    public override void Serialize(IBinding data, Writer writer) {
        var value = Get(data);
        if (value != null) {
            var first = true;

            writer.WriteArrayStart();
            foreach (var entry in value) {
                writer.WriteArraySeparator(ref first);
                writer.WriteDateTime(entry);
                }
            writer.WriteArrayEnd();
            }
        }

    ///<inheritdoc/>
    public override bool IsNull(IBinding data) => Get(data) == null;
    }

/// <summary>
/// Metadata record representing a property.
/// </summary>
/// <param name="Tag">Tag identifying this property in JSON serialization</param>
/// <param name="Set">Set the property to the specified value.</param>
/// <param name="Get">Return the value of the property.</param>
public record PropertyInteger32(
            string Tag,
            Action<IBinding, int?> Set,
            Func<IBinding, int?> Get) : Property(Tag, false) {
    ///<inheritdoc/>
    public override void Serialize(IBinding data, Writer writer) {
        var value = Get(data);
        if (value != null) {
            writer.WriteInteger32(value);
            }
        }

    ///<inheritdoc/>
    public override bool IsNull(IBinding data) => Get(data) == null;
    }

/// <summary>
/// Metadata record representing a property.
/// </summary>
/// <param name="Tag">Tag identifying this property in JSON serialization</param>
/// <param name="Set">Set the property to the specified value.</param>
/// <param name="Get">Return the value of the property.</param>
public record PropertyListInteger32(
            string Tag,
            Action<IBinding, List<int>?> Set,
            Func<IBinding, List<int>?> Get) : Property(Tag, true) {
    ///<inheritdoc/>
    public override void Serialize(IBinding data, Writer writer) {
        var value = Get(data);
        if (value != null) {
            var first = true;

            writer.WriteArrayStart();
            foreach (var entry in value) {
                writer.WriteArraySeparator(ref first);
                writer.WriteInteger32(entry);
                }
            writer.WriteArrayEnd();
            }
        }

    ///<inheritdoc/>
    public override bool IsNull(IBinding data) => Get(data) == null;
    }

/// <summary>
/// Metadata record representing a property.
/// </summary>
/// <param name="Tag">Tag identifying this property in JSON serialization</param>
/// <param name="Set">Set the property to the specified value.</param>
/// <param name="Get">Return the value of the property.</param>
public record PropertyInteger64(
            string Tag,
            Action<IBinding, long?> Set,
            Func<IBinding, long?> Get) : Property(Tag, false) {
    ///<inheritdoc/>
    public override void Serialize(IBinding data, Writer writer) {
        var value = Get(data);
        if (value != null) {
            writer.WriteInteger64(value);
            }
        }

    ///<inheritdoc/>
    public override bool IsNull(IBinding data) => Get(data) == null;
    }

/// <summary>
/// Metadata record representing a property.
/// </summary>
/// <param name="Tag">Tag identifying this property in JSON serialization</param>
/// <param name="Set">Set the property to the specified value.</param>
/// <param name="Get">Return the value of the property.</param>
public record PropertyListInteger64(
            string Tag,
            Action<IBinding, List<long>?> Set,
            Func<IBinding, List<long>?> Get) : Property(Tag, true) {
    ///<inheritdoc/>
    public override void Serialize(IBinding data, Writer writer) {
        var value = Get(data);
        if (value != null) {
            var first = true;

            writer.WriteArrayStart();
            foreach (var entry in value) {
                writer.WriteArraySeparator(ref first);
                writer.WriteInteger64(entry);
                }
            writer.WriteArrayEnd();
            }
        }

    ///<inheritdoc/>
    public override bool IsNull(IBinding data) => Get(data) == null;
    }

/// <summary>
/// Metadata record representing a property.
/// </summary>
/// <param name="Tag">Tag identifying this property in JSON serialization</param>
/// <param name="Set">Set the property to the specified value.</param>
/// <param name="Get">Return the value of the property.</param>
public record PropertyReal32(
            string Tag,
            Action<IBinding, float?> Set,
            Func<IBinding, float?> Get) : Property(Tag, false) {
    ///<inheritdoc/>
    public override void Serialize(IBinding data, Writer writer) {
        var value = Get(data);
        if (value != null) {
            writer.WriteFloat32(value);
            }
        }

    ///<inheritdoc/>
    public override bool IsNull(IBinding data) => Get(data) == null;
    }

/// <summary>
/// Metadata record representing a property.
/// </summary>
/// <param name="Tag">Tag identifying this property in JSON serialization</param>
/// <param name="Set">Set the property to the specified value.</param>
/// <param name="Get">Return the value of the property.</param>
public record PropertyListReal32(
            string Tag,
            Action<IBinding, List<float>?> Set,
            Func<IBinding, List<float>?>? Get) : Property(Tag, true) {
    ///<inheritdoc/>
    public override void Serialize(IBinding data, Writer writer) {
        var value = Get(data);
        if (value != null) {
            var first = true;

            writer.WriteArrayStart();
            foreach (var entry in value) {
                writer.WriteArraySeparator(ref first);
                writer.WriteFloat32(entry);
                }
            writer.WriteArrayEnd();
            }
        }

    ///<inheritdoc/>
    public override bool IsNull(IBinding data) => Get(data) == null;
    }

/// <summary>
/// Metadata record representing a property.
/// </summary>
/// <param name="Tag">Tag identifying this property in JSON serialization</param>
/// <param name="Set">Set the property to the specified value.</param>
/// <param name="Get">Return the value of the property.</param>
public record PropertyReal64(
            string Tag,
            Action<IBinding, double?> Set,
            Func<IBinding, double?> Get) : Property(Tag, false) {
    ///<inheritdoc/>
    public override void Serialize(IBinding data, Writer writer) {
        var value = Get(data);
        if (value != null) {
            writer.WriteFloat64(value);
            }
        }

    ///<inheritdoc/>
    public override bool IsNull(IBinding data) => Get(data) == null;
    }

/// <summary>
/// Metadata record representing a property.
/// </summary>
/// <param name="Tag">Tag identifying this property in JSON serialization</param>
/// <param name="Set">Set the property to the specified value.</param>
/// <param name="Get">Return the value of the property.</param>
public record PropertyListReal64(
            string Tag,
            Action<IBinding, List<double>?> Set,
            Func<IBinding, List<double>?> Get) : Property(Tag, true) {
    ///<inheritdoc/>
    public override void Serialize(IBinding data, Writer writer) {
        var value = Get(data);
        if (value != null) {
            var first = true;

            writer.WriteArrayStart();
            foreach (var entry in value) {
                writer.WriteArraySeparator(ref first);
                writer.WriteFloat64(entry);
                }
            writer.WriteArrayEnd();
            }
        }

    ///<inheritdoc/>
    public override bool IsNull(IBinding data) => Get(data) == null;
    }

/// <summary>
/// Metadata record representing a property.
/// </summary>
/// <param name="Tag">Tag identifying this property in JSON serialization</param>
/// <param name="Set">Set the property to the specified value.</param>
/// <param name="Get">Return the value of the property.</param>
/// <param name="Factory">Factory returning an instance of the object.</param>
/// <param name="IFactory">For a collection object, factory returning an instance of an
/// object in the collection.</param>
/// <param name="Tagged">If true, the property should be tagged.</param>
public record PropertyStruct(
            string Tag,
            Action<IBinding, object?> Set,
            Func<IBinding, object?> Get,
            bool Tagged = false,
            Func<object> Factory = null,
            Func<object> IFactory = null) : Property(Tag, false, Tagged) {
    ///<inheritdoc/>
    public override void Serialize(IBinding data, Writer writer) {
        JsonObject value = Get(data) as JsonObject;
        value?.Serialize(writer, Tagged);
        }

    ///<inheritdoc/>
    public override bool IsNull(IBinding data) => Get(data) == null;
    }

/// <summary>
/// Metadata record representing a property.
/// </summary>
/// <param name="Tag">Tag identifying this property in JSON serialization</param>
/// <param name="Set">Set the property to the specified value.</param>
/// <param name="Get">Return the value of the property.</param>
/// <param name="Factory">Factory returning an instance of the object.</param>
/// <param name="IFactory">For a collection object, factory returning an instance of an
/// object in the collection.</param>
/// <param name="Tagged">If true, the property should be tagged.</param>
public record PropertyListStruct(
            string Tag,
            Action<IBinding, object?> Set,
            Func<IBinding, object?> Get,
            bool Tagged = false,
            Func<object> Factory = null,
            Func<object> IFactory = null) : Property(Tag, true, Tagged) {
    ///<inheritdoc/>
    public override void Serialize(IBinding data, Writer writer) {
        if (Get(data) is IEnumerable value) {
            var first = true;

            writer.WriteArrayStart();
            foreach (var entry in value) {
                var typed = entry as JsonObject;
                if (typed is null) {
                    writer.WriteNull();
                    }
                else {

                    writer.WriteArraySeparator(ref first);
                    typed.Serialize(writer, Tagged);
                    }
                }
            writer.WriteArrayEnd();
            }
        }

    ///<inheritdoc/>
    public override bool IsNull(IBinding data) => Get(data) == null;
    }



/// <summary>Tokens to return.</summary>
public enum Token {
    /// <summary>The token is invalid</summary>
    Invalid,
    /// <summary>Start object token '{' </summary>
    StartObject,
    /// <summary>End object token '}' </summary>
    EndObject,
    /// <summary>Start array token '{'</summary>
    StartArray,
    /// <summary>End array token '}'</summary>
    EndArray,
    /// <summary>Colon</summary>
    Colon,
    /// <summary>Comma</summary>
    Comma,
    /// <summary>String (UTF8)</summary>
    String,
    /// <summary>String encoding a DateTime values</summary>
    DateTime,
    /// <summary>String Tag(UTF8)</summary>
    Tag,

    /// <summary>Number</summary>
    Number,

    /// <summary>An Integer Number</summary>
    Integer,
    /// <summary>A Real32 Number</summary>
    Real32,
    /// <summary>A Real64 Number</summary>
    Real64,

    /// <summary>A string litteral, for internal use.</summary>
    Litteral,
    /// <summary>The string litteral true</summary>
    True,
    /// <summary>The string litteral false</summary>
    False,
    /// <summary>The string litteral null</summary>
    Null,
    /// <summary>End of record</summary>
    EndRecord,
    /// <summary>Binary data</summary>
    Binary,
    /// <summary>JSON-BCD extended tag, for internal use</summary>
    JSONBCD,
    /// <summary>Byte Order Mark</summary>
    BOM,
    /// <summary></summary>
    Empty
    }
