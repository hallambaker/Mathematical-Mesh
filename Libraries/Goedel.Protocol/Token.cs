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


namespace Goedel.Protocol;


/// <summary>
/// Metadate record representing a property.
/// </summary>
/// <param name="TokenType">The token type (consider removing).</param>
/// <param name="Multiple">If true, represents a list of entries.</param>
/// <param name="Factory">Factory generating an instance of the node (if required).</param>
/// <param name="IFactory">Factory generating an instance of a list member (if required).</param>
/// <param name="Tagged">If true, structures are to be represented as a tagged structure.</param>
public record Property(

            Type TokenType,
            bool Multiple,
            Func<object> Factory=null,
            Func<object> IFactory=null,
            bool Tagged=false,
            Dictionary<string, JsonFactoryDelegate> tagDictionary=null) {
     }


/// <summary>
/// Base record representing the value at a node in a JSON tree.
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
/// Record representing a boolean value in a JSON tree.
/// </summary>
/// <param name="Value">The value.</param>
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
/// Record representing a boolean value in a JSON tree.
/// </summary>
/// <param name="Value">The value.</param>
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
/// Record representing a boolean value in a JSON tree.
/// </summary>
/// <param name="Value">The value.</param>
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
/// Record representing a boolean value in a JSON tree.
/// </summary>
/// <param name="Value">The value.</param>
public record TokenValueDateTime(DateTime? Value) : TokenValue {
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
/// Record representing a boolean value in a JSON tree.
/// </summary>
/// <param name="Value">The value.</param>
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
/// Record representing a boolean value in a JSON tree.
/// </summary>
/// <param name="Value">The value.</param>
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
/// Record representing a boolean value in a JSON tree.
/// </summary>
/// <param name="Value">The value.</param>
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
/// Record representing a boolean value in a JSON tree.
/// </summary>
/// <param name="Value">The value.</param>
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
/// Base record representing a structure value at a node in a JSON tree.
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
/// Record representing a boolean value in a JSON tree.
/// </summary>
/// <param name="Value">The value.</param>
/// <typeparam name="T">The type of the node value</typeparam>
public record TokenValueStruct<T>(T Value) : TokenValueStruct where T: JsonObject {
    ///<inheritdoc/>
    public override JsonObject JsonObject => Value;
    ///<inheritdoc/>
    public override bool IsEmpty => Value == null;


    }

/// <summary>
/// Record representing a boolean value in a JSON tree.
/// </summary>
/// <param name="Value">The value.</param>
/// <typeparam name="T">The type of the node value</typeparam>
public record TokenValueStructObject(object Value) : TokenValueStruct {
    ///<inheritdoc/>
    public override JsonObject JsonObject => Value as JsonObject;
    ///<inheritdoc/>
    public override bool IsEmpty => Value == null;

    }




/// <summary>
/// Base record representing a structure value at a node in a JSON tree.
/// </summary>
public abstract record TokenValueList() : TokenValue {


    }

/// <summary>
/// Record representing a boolean value in a JSON tree.
/// </summary>
/// <param name="Value">The value.</param>
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
/// Record representing a boolean value in a JSON tree.
/// </summary>
/// <param name="Value">The value.</param>
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
/// Record representing a boolean value in a JSON tree.
/// </summary>
/// <param name="Value">The value.</param>
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
/// Record representing a boolean value in a JSON tree.
/// </summary>
/// <param name="Value">The value.</param>
public record TokenValueListDateTime(List<DateTime?> Value) : TokenValue {
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
/// Record representing a boolean value in a JSON tree.
/// </summary>
/// <param name="Value">The value.</param>
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
/// Record representing a boolean value in a JSON tree.
/// </summary>
/// <param name="Value">The value.</param>
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
/// Record representing a boolean value in a JSON tree.
/// </summary>
/// <param name="Value">The value.</param>
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
/// Record representing a boolean value in a JSON tree.
/// </summary>
/// <param name="Value">The value.</param>
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
/// Base record representing the value of a list of structure at a node in a JSON tree.
/// </summary>
public abstract record TokenValueListStruct() : TokenValue {

    ///<inheritdoc/>
    public override Token Token => Token.StartObject;

    public abstract void Serialize(Writer writer, bool tagged);
    }

/// <summary>
/// Record representing a boolean value in a JSON tree.
/// </summary>
/// <param name="Value">The value.</param>
/// <typeparam name="T">The type of the node value</typeparam>
public record TokenValueListStructObject(object Value) : TokenValueStruct {
    ///<inheritdoc/>
    public override JsonObject JsonObject => Value as JsonObject;
    ///<inheritdoc/>
    public override bool IsEmpty => Value == null;

    }




/// <summary>
/// Record representing a boolean value in a JSON tree.
/// </summary>
/// <param name="Value">The value.</param>
/// <typeparam name="T">The type of the node value</typeparam>
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
    /// <summary>String encoding a DateTime value</summary>
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
