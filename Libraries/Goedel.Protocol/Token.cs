﻿#region // Copyright - MIT License
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


namespace Goedel.Protocol;



public interface IBinding {

    Binding Binding { get; }
    }

public record Binding(
            Dictionary<string, Property> Properties,
            Binding Parent = null
            ) {
    }



/// <summary>
/// Metadate record representing a property.
/// </summary>
/// <param name="TokenType">The token type (consider removing).</param>
/// <param name="Multiple">If true, represents a list of entries.</param>
/// <param name="Factory">Factory generating an instance of the node (if required).</param>
/// <param name="IFactory">Factory generating an instance of a list member (if required).</param>
/// <param name="Tagged">If true, structures are to be represented as a tagged structure.</param>
///// <param name="tagDictionary">Tag dictionary to be used to deserialize the property.</param>
public record Property(

            Type TokenType,
            bool Multiple,
            Func<object> Factory=null,
            Func<object> IFactory=null,
            bool Tagged=false,
            //Dictionary<string, JsonFactoryDelegate> tagDictionary=null,
            string Tag = null) {
     }


public record PropertyBoolean(
            string Tag,
            Action<IBinding, bool?> Set,
            Func<IBinding, bool?> Get) : Property(typeof(TokenValueBoolean), false, Tag:Tag) {
    }

public record PropertyListBoolean(
            string Tag,
            Action<IBinding, List<bool?>> Set,
            Func<IBinding, List<bool?>> Get) : Property(typeof(TokenValueListBoolean), true, Tag: Tag) {
    }

public record PropertyString (
            string Tag,
            Action<IBinding, string?> Set,
            Func<IBinding, string?> Get):  Property(typeof(TokenValueString), false, Tag: Tag) {
    }

public record PropertyListString(
            string Tag,
            Action<IBinding, List<string>?> Set,
            Func<IBinding, List<string>?> Get) : Property(typeof(TokenValueListString), true, Tag: Tag) {
    }

public record PropertyBinary(
            string Tag,
            Action<IBinding, byte[]?> Set,
            Func<IBinding, byte[]?> Get) : Property(typeof(TokenValueBinary), false, Tag: Tag) {
    }

public record PropertyListBinary(
            string Tag,
            Action<IBinding, List<byte[]?>> Set,
            Func<IBinding, List<byte[]?>> Get) : Property(typeof(TokenValueListBinary), true, Tag: Tag) {
    }


public record PropertyDateTime(
            string Tag,
            Action<IBinding, DateTime?> Set,
            Func<IBinding, DateTime?> Get) : Property(typeof(TokenValueDateTime), false, Tag: Tag) {
    }

public record PropertyListDateTime(
            string Tag,
            Action<IBinding, List<DateTime?>> Set,
            Func<IBinding, List<DateTime?>> Get) : Property(typeof(TokenValueListDateTime), true, Tag: Tag) {
    }


public record PropertyInteger32(
            string Tag,
            Action<IBinding, int?> Set,
            Func<IBinding, int?> Get) : Property(typeof(TokenValueInteger32), false, Tag: Tag) {
    }

public record PropertyListInteger32(
            string Tag,
            Action<IBinding, List<int?>> Set,
            Func<IBinding, List<int?>> Get) : Property(typeof(TokenValueListInteger32), true, Tag: Tag) {
    }


public record PropertyInteger64(
            string Tag,
            Action<IBinding, long?> Set,
            Func<IBinding, long?> Get) : Property(typeof(TokenValueInteger64), false, Tag: Tag) {
    }

public record PropertyListInteger64(
            string Tag,
            Action<IBinding, List<long?>> Set,
            Func<IBinding, List<long?>> Get) : Property(typeof(TokenValueListInteger64), true, Tag: Tag) {
    }


public record PropertyReal32(
            string Tag,
            Action<IBinding, float?> Set,
            Func<IBinding, float?> Get) : Property(typeof(TokenValueReal32), false, Tag: Tag) {
    }

public record PropertyListReal32(
            string Tag,
            Action<IBinding, List<float?>> Set,
            Func<IBinding, List<float?>>? Get) : Property(typeof(TokenValueListReal32), true, Tag: Tag) {
    }
public record PropertyReal64(
            string Tag,
            Action<IBinding, double?> Set,
            Func<IBinding, double> Get) : Property(typeof(TokenValueReal64), false, Tag: Tag) {
    }

public record PropertyListReal64(
            string Tag,
            Action<IBinding, List<double?>> Set,
            Func<IBinding, List<double?>> Get) : Property(typeof(TokenValueListReal64), true, Tag: Tag) {
    }
public record PropertyStruct<T>(
            string Tag,
            Action<IBinding, T?> Set,
            Func<IBinding, T?> Get,
            bool Tagged = false,
            Func<object> Factory = null,
            Func<object> IFactory = null) : Property(typeof(TokenValueStruct), false, Tag: Tag) {
    }

public record PropertyListStruct<T>(
            string Tag,
            Action<IBinding, List<T>?> Set,
            Func<IBinding, List<T>?> Get,
            bool Tagged = false,
            Func<object> Factory = null,
            Func<object> IFactory = null) : Property(typeof(TokenValueListStruct), true, Factory, IFactory, Tag: Tag) {
    }


/// <summary>
/// Base record representing the values at a node in a JSON tree.
/// </summary>
public abstract record TokenValue () {

    ///<summary>Static pointer to a single instance of the unknown token.</summary> 
    public static readonly TokenValue Unknown = new TokenValueUnknown();

    ///<summary></summary> 
    public abstract bool IsEmpty { get; }
    
    ///<summary>The parse token (consider removing)</summary> 
    public abstract Token Token { get; }


    /// <summary>
    /// Serialize this token to the writer <paramref name="writer"/>.
    /// </summary>
    /// <param name="writer">The writer to emit the structured data to.</param>
    /// 
    /// 
    public virtual void Serialize(Writer writer) {
        }


    }

/// <summary>
/// Record returned to respresent an unknown entry.
/// </summary>
public record TokenValueUnknown() : TokenValue {

    ///<inheritdoc/>
    public override bool IsEmpty => true;

    ///<inheritdoc/>
    public override Token Token => Token.Invalid;
    }

/// <summary>
/// Record representing a boolean values in a JSON tree.
/// </summary>
/// <param name="Value">The values.</param>
public record TokenValueBoolean(bool? Value) : TokenValue {
    ///<inheritdoc/>
    public override bool IsEmpty => Value == null;

    ///<inheritdoc/>
    public override Token Token => Value switch {
        true => Token.True,
        false => Token.False,
        _ => Token.Null
        };

    ///<inheritdoc/>
    public override void Serialize(Writer writer) {
        writer.WriteBoolean(Value);
        }


    }

/// <summary>
/// Record representing a boolean values in a JSON tree.
/// </summary>
/// <param name="Value">The values.</param>
public record TokenValueString(string? Value) : TokenValue {
    ///<inheritdoc/>
    public override bool IsEmpty => Value == null;

    ///<inheritdoc/>
    public override Token Token => Token.String;

    ///<inheritdoc/>
    public override void Serialize(Writer writer) {
        writer.WriteString(Value);
        }

    }

/// <summary>
/// Record representing a boolean values in a JSON tree.
/// </summary>
/// <param name="Value">The values.</param>
public record TokenValueBinary(byte[] Value) : TokenValue {
    ///<inheritdoc/>
    public override bool IsEmpty => Value == null;

    ///<inheritdoc/>
    public override Token Token => Token.Binary;
    ///<inheritdoc/>
    public override void Serialize(Writer writer) {
        writer.WriteBinary(Value);
        }
    }

/// <summary>
/// Record representing a boolean values in a JSON tree.
/// </summary>
/// <param name="Value">The values.</param>
public record TokenValueDateTime(System.DateTime? Value) : TokenValue {
    ///<inheritdoc/>
    public override bool IsEmpty => Value == null;

    ///<inheritdoc/>
    public override Token Token => Token.DateTime;
    ///<inheritdoc/>
    public override void Serialize(Writer writer) {
        writer.WriteDateTime(Value);
        }
    }

/// <summary>
/// Record representing a boolean values in a JSON tree.
/// </summary>
/// <param name="Value">The values.</param>
public record TokenValueInteger32(int? Value) : TokenValue {
    ///<inheritdoc/>
    public override bool IsEmpty => Value == null;

    ///<inheritdoc/>
    public override Token Token => Token.Integer;
    ///<inheritdoc/>
    public override void Serialize(Writer writer) {
        writer.WriteInteger32(Value);
        }
    }

/// <summary>
/// Record representing a boolean values in a JSON tree.
/// </summary>
/// <param name="Value">The values.</param>
public record TokenValueInteger64(long? Value) : TokenValue {
    ///<inheritdoc/>
    public override bool IsEmpty => Value == null;

    ///<inheritdoc/>
    public override Token Token => Token.Integer;
    ///<inheritdoc/>
    public override void Serialize(Writer writer) {
        writer.WriteInteger64(Value);
        }
    }

/// <summary>
/// Record representing a boolean values in a JSON tree.
/// </summary>
/// <param name="Value">The values.</param>
public record TokenValueReal32(float? Value) : TokenValue {
    ///<inheritdoc/>
    public override bool IsEmpty => Value == null;

    ///<inheritdoc/>
    public override Token Token => Token.Integer;
    ///<inheritdoc/>
    public override void Serialize(Writer writer) {
        writer.WriteFloat32(Value);
        }
    }

/// <summary>
/// Record representing a boolean values in a JSON tree.
/// </summary>
/// <param name="Value">The values.</param>
public record TokenValueReal64(double? Value) : TokenValue {
    ///<inheritdoc/>
    public override bool IsEmpty => Value == null;

    ///<inheritdoc/>
    public override Token Token => Token.Integer;
    ///<inheritdoc/>
    public override void Serialize(Writer writer) {
        writer.WriteFloat64(Value);
        }
    }

/// <summary>
/// Base record representing a structure values at a node in a JSON tree.
/// </summary>
public abstract record TokenValueStruct() : TokenValue {
    ///<inheritdoc/>
    public abstract JsonObject JsonObject { get; }
    ///<inheritdoc/>
    public override Token Token => Token.StartObject;

    ///<inheritdoc/>
    public override void Serialize(Writer writer) => Serialize(writer, false);

    ///<inheritdoc/>
    public void Serialize(Writer writer, bool tagged) {
        JsonObject.Serialize(writer, tagged);
        }
    }

/// <summary>
/// Record representing a boolean values in a JSON tree.
/// </summary>
/// <param name="Value">The values.</param>
/// <typeparam name="T">The type of the node values</typeparam>
public record TokenValueStruct<T>(T Value) : TokenValueStruct where T: JsonObject {
    ///<inheritdoc/>
    public override JsonObject JsonObject => Value;
    ///<inheritdoc/>
    public override bool IsEmpty => Value == null;


    }

/// <summary>
/// Record representing a boolean values in a JSON tree.
/// </summary>
/// <param name="Value">The values.</param>
public record TokenValueStructObject(object Value) : TokenValueStruct {
    ///<inheritdoc/>
    public override JsonObject JsonObject => Value as JsonObject;
    ///<inheritdoc/>
    public override bool IsEmpty => Value == null;

    }


/// <summary>
/// Record representing a boolean values in a JSON tree.
/// </summary>
/// <param name="Value">The values.</param>
public record TokenValueListBoolean(List<bool?> Value) : TokenValue {
    ///<inheritdoc/>
    public override bool IsEmpty => Value == null;

    ///<inheritdoc/>
    public override Token Token => Value switch {
        _ => Token.Null
        };

    ///<inheritdoc/>
    public override void Serialize(Writer writer) {

        bool first = true;

        writer.WriteArrayStart();
        foreach (var entry in Value) {
            writer.WriteArraySeparator(ref first);
            writer.WriteBoolean(entry);
            }
        writer.WriteArrayEnd();
        }

    }

/// <summary>
/// Record representing a boolean values in a JSON tree.
/// </summary>
/// <param name="Value">The values.</param>
public record TokenValueListString(List<string> Value) : TokenValue {
    ///<inheritdoc/>
    public override bool IsEmpty => Value == null;

    ///<inheritdoc/>
    public override Token Token => Token.String;

    ///<inheritdoc/>
    public override void Serialize(Writer writer) {

        bool first = true;

        writer.WriteArrayStart();
        foreach (var entry in Value) {
            writer.WriteArraySeparator(ref first);
            writer.WriteString(entry);
            }
        writer.WriteArrayEnd();
        }
    }

/// <summary>
/// Record representing a boolean values in a JSON tree.
/// </summary>
/// <param name="Value">The values.</param>
public record TokenValueListBinary(List<byte[]> Value) : TokenValue {
    ///<inheritdoc/>
    public override bool IsEmpty => Value == null;

    ///<inheritdoc/>
    public override Token Token => Token.Binary;

    ///<inheritdoc/>
    public override void Serialize(Writer writer) {

        bool first = true;

        writer.WriteArrayStart();
        foreach (var entry in Value) {
            writer.WriteArraySeparator(ref first);
            writer.WriteBinary(entry);
            }
        writer.WriteArrayEnd();
        }
    }

/// <summary>
/// Record representing a boolean values in a JSON tree.
/// </summary>
/// <param name="Value">The values.</param>
public record TokenValueListDateTime(List<System.DateTime?> Value) : TokenValue {
    ///<inheritdoc/>
    public override bool IsEmpty => Value == null;

    ///<inheritdoc/>
    public override Token Token => Token.DateTime;

    ///<inheritdoc/>
    public override void Serialize(Writer writer) {

        bool first = true;

        writer.WriteArrayStart();
        foreach (var entry in Value) {
            writer.WriteArraySeparator(ref first);
            writer.WriteDateTime(entry);
            }
        writer.WriteArrayEnd();
        }
    }

/// <summary>
/// Record representing a boolean values in a JSON tree.
/// </summary>
/// <param name="Value">The values.</param>
public record TokenValueListInteger32(List<int?> Value) : TokenValue {
    ///<inheritdoc/>
    public override bool IsEmpty => Value == null;

    ///<inheritdoc/>
    public override Token Token => Token.Integer;

    ///<inheritdoc/>
    public override void Serialize(Writer writer) {

        bool first = true;

        writer.WriteArrayStart();
        foreach (var entry in Value) {
            writer.WriteArraySeparator(ref first);
            writer.WriteInteger32(entry);
            }
        writer.WriteArrayEnd();
        }
    }

/// <summary>
/// Record representing a boolean values in a JSON tree.
/// </summary>
/// <param name="Value">The values.</param>
public record TokenValueListInteger64(List<long?> Value) : TokenValue {
    ///<inheritdoc/>
    public override bool IsEmpty => Value == null;

    ///<inheritdoc/>
    public override Token Token => Token.Integer;

    ///<inheritdoc/>
    public override void Serialize(Writer writer) {

        bool first = true;

        writer.WriteArrayStart();
        foreach (var entry in Value) {
            writer.WriteArraySeparator(ref first);
            writer.WriteInteger64(entry);
            }
        writer.WriteArrayEnd();
        }
    }

/// <summary>
/// Record representing a boolean values in a JSON tree.
/// </summary>
/// <param name="Value">The values.</param>
public record TokenValueListReal32(List<float?> Value) : TokenValue {
    ///<inheritdoc/>
    public override bool IsEmpty => Value == null;

    ///<inheritdoc/>
    public override Token Token => Token.Integer;

    ///<inheritdoc/>
    public override void Serialize(Writer writer) {

        bool first = true;

        writer.WriteArrayStart();
        foreach (var entry in Value) {
            writer.WriteArraySeparator(ref first);
            writer.WriteFloat32(entry);
            }
        writer.WriteArrayEnd();
        }
    }

/// <summary>
/// Record representing a boolean values in a JSON tree.
/// </summary>
/// <param name="Value">The values.</param>
public record TokenValueListReal64(List<double?> Value) : TokenValue {
    ///<inheritdoc/>
    public override bool IsEmpty => Value == null;

    ///<inheritdoc/>
    public override Token Token => Token.Integer;

    ///<inheritdoc/>
    public override void Serialize(Writer writer) {

        bool first = true;

        writer.WriteArrayStart();
        foreach (var entry in Value) {
            writer.WriteArraySeparator(ref first);
            writer.WriteFloat64(entry);
            }
        writer.WriteArrayEnd();
        }
    }

/// <summary>
/// Base record representing the values of a list of structure at a node in a JSON tree.
/// </summary>
public abstract record TokenValueListStruct() : TokenValue {

    ///<inheritdoc/>
    public override Token Token => Token.StartObject;

    /// <summary>
    /// Serialize the values by calling methods on the writer <paramref name="writer"/>.
    /// </summary>
    /// <param name="writer">The writer to serialize the values to.</param>
    /// <param name="tagged">If true, structured values to be written as a tagged
    /// structure.</param>
    public abstract void Serialize(Writer writer, bool tagged);
    }

/// <summary>
/// Record representing a boolean values in a JSON tree.
/// </summary>
/// <param name="Value">The values.</param>
public record TokenValueListStructObject(object Value) : TokenValueStruct {
    ///<inheritdoc/>
    public override JsonObject JsonObject => Value as JsonObject;
    ///<inheritdoc/>
    public override bool IsEmpty => Value == null;

    }




/// <summary>
/// Record representing a boolean values in a JSON tree.
/// </summary>
/// <param name="Value">The values.</param>
/// <typeparam name="T">The type of the node values</typeparam>
public record TokenValueListStruct<T>(List<T> Value) : TokenValueListStruct where T : JsonObject {
    ///<inheritdoc/>
    public override bool IsEmpty => Value == null;

    ///<summary>Gets or sets the element at the specified index.</summary> 
    public T this[int index] { get => Value[index]; set => Value[index] = value; }

    ///<summary>Gets the number of elements contained in the List&lt;T>.</summary> 
    public int Count => Value.Count;

    ///<summary>Returns an enumerator that iterates through the List&lt;T>.</summary> 
    public List<T>.Enumerator GetEnumerator() => Value.GetEnumerator();

    ///<inheritdoc/>
    public override void Serialize(Writer writer, bool tagged) {
        bool first = true;

        writer.WriteArrayStart();
        foreach (var entry in Value) {
            var jsonObject = entry as JsonObject;
            writer.WriteArraySeparator(ref first);
            jsonObject.Serialize(writer, tagged);
            }
        writer.WriteArrayEnd();
        }
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
