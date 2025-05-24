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
using System.Text.Json;

namespace Goedel.Protocol;


//public enum JsonValueKind2 {
//    ///<summary>There is no value (as distinct from Null).</summary> 
//    Undefined = 0,

//    ///<summary>A JSON object.</summary> 
//    Object = 1,

//    ///<summary>A JSON array.</summary> 
//    Array = 2,

//    ///<summary>A JSON string.</summary> 
//    String = 3,

//    ///<summary>A JSON number.</summary> 
//    Number = 4,

//    ///<summary>The JSON value true.</summary> 
//    True = 5,

//    ///<summary>The JSON value false.</summary> 
//    False = 6,

//    ///<summary>The JSON value null.</summary> 
//    Null = 7,

//    ///<summary>Binary data</summary> 
//    Binary = 8,

//    }


public abstract record JsonElement2 {


    public static JsonElementObject? Parse(
                    JsonReader jsonReader) {
        //JsonReader.Trace = true;
        bool going = jsonReader.StartObject();
        return going ? new JsonElementObject(jsonReader) : null;
        }



    }
public record JsonElementNull() : JsonElement2 {

    }
public record JsonElementBoolean (
            bool Value) : JsonElement2 {

    }

public record JsonElementString(
            string Value) : JsonElement2 {

    public DateTime GetDateTime() => Value.FromRFC3339();


    public byte[] GetBinary() => Value.FromBase64();
    }

public record JsonElementDateTime(
            DateTime Value) : JsonElement2 {

    }
public record JsonElementBinary(
            byte[] Value) : JsonElement2 {

    }

public record JsonElementNumber(
            string? Value) : JsonElement2 {

    public virtual int GetInt32() => Int32.Parse(Value);

    public virtual long GetInt64() => Int64.Parse(Value);


    public virtual Single GetReal32() => Single.Parse(Value);


    public virtual Double GetReal64() => Double.Parse(Value);
    }


public record JsonElementInt64(
            long intValue) : JsonElementNumber("") {

    /// <inheritdoc/>
    public override int GetInt32() => (int)intValue;

    /// <inheritdoc/>
    public override long GetInt64() => intValue;

    /// <inheritdoc/>
    public override Single GetReal32() => intValue;

    /// <inheritdoc/>
    public override Double GetReal64() => intValue;

    }


public record JsonElementReal32(
            float floatValue) : JsonElementNumber("") {

    /// <inheritdoc/>
    public override int GetInt32() => (int)floatValue;

    /// <inheritdoc/>
    public override long GetInt64() => (long)floatValue;

    /// <inheritdoc/>
    public override Single GetReal32() => floatValue;

    /// <inheritdoc/>
    public override Double GetReal64() => floatValue;

    }


public record JsonElementReal64(
            double doubleValue) : JsonElementNumber("") {

    /// <inheritdoc/>
    public override int GetInt32() => (int)doubleValue;

    /// <inheritdoc/>
    public override long GetInt64() => (long)doubleValue;

    /// <inheritdoc/>
    public override Single GetReal32() => (float)doubleValue;

    /// <inheritdoc/>
    public override Double GetReal64() => doubleValue;

    }






public record JsonElementObject() : JsonElement2 {
    public bool TryGetProperty (string tag, out JsonElement2 element) =>
        Properties.TryGetValue (tag, out element);

    public KeyValuePair<string,JsonElement2> SoloProperty() {
        var enumerator = Properties.GetEnumerator();
        if (!enumerator.MoveNext()) {
            throw new NYI();
            }
        return enumerator.Current;
        }



    public Dictionary<string, JsonElement2> Properties = [];

    public JsonElementObject(
                JsonReader jsonReader) : this() {
        var going = true;
        while (going) {
            string tag = jsonReader.ReadToken();
            if (tag == null) {
                going = false;
                }
            else {
                //AddProperty(jsonReader, tag);
                jsonReader.GetToken();
                switch (jsonReader.TokenType) {
                    case Token.Null: {
                        Properties.Add(tag, new JsonElementNull());
                        break;
                        }
                    case Token.True: {
                        Properties.Add(tag, new JsonElementBoolean(true));
                        break;
                        }
                    case Token.False: {
                        Properties.Add(tag, new JsonElementBoolean(false));
                        break;
                        }
                    case Token.Number: {
                        Properties.Add(tag, new JsonElementNumber(jsonReader.ResultString));
                        break;
                        }
                    case Token.String: {
                        Properties.Add(tag, new JsonElementString(jsonReader.ResultString));
                        break;
                        }
                    case Token.DateTime: {
                        Properties.Add(tag, new JsonElementDateTime(jsonReader.ResultDateTime));
                        break;
                        }
                    case Token.Binary: {
                        jsonReader.ReadBinaryData();
                        Properties.Add(tag, new JsonElementBinary(jsonReader.ResultBinary));
                        break;
                        }
                    case Token.StartObject: {
                        Properties.Add(tag, new JsonElementObject(jsonReader));
                        break;
                        }
                    case Token.StartArray: {
                        Properties.Add(tag, new JsonElementArray(jsonReader));
                        break;
                        }

                    case Token.Integer: {
                        Properties.Add(tag, new JsonElementInt64(jsonReader.ResultInt64));
                        break;
                        }
                    case Token.Real32: {
                        Properties.Add(tag, new JsonElementReal32(jsonReader.ResultFloat));
                        break;
                        }
                    case Token.Real64: {
                        Properties.Add(tag, new JsonElementReal64(jsonReader.ResultDouble));
                        break;
                        }


                    default: {
                        break;
                        }
                    }

                going = jsonReader.NextObject();
                }
            }
        }
    }

public record JsonElementArray() : JsonElement2 {

    public List<JsonElement2> Items = [];
    public JsonElementArray(
        JsonReader jsonReader) : this() {
        var going = true;
        while (going) {
            //AddProperty(jsonReader, tag);
            jsonReader.GetToken();
            switch (jsonReader.TokenType) {
                case Token.Null: {
                    Items.Add(new JsonElementNull());
                    break;
                    }
                case Token.True: {
                    Items.Add(new JsonElementBoolean(true));
                    break;
                    }
                case Token.False: {
                    Items.Add(new JsonElementBoolean(false));
                    break;
                    }
                case Token.Number: {
                    Items.Add(new JsonElementNumber(jsonReader.ResultString));
                    break;
                    }
                case Token.String: {
                    Items.Add(new JsonElementString(jsonReader.ResultString));
                    break;
                    }
                case Token.Binary: {
                    jsonReader.ReadBinaryData();
                    Items.Add(new JsonElementBinary(jsonReader.ResultBinary));
                    break;
                    }
                case Token.StartObject: {
                    Items.Add(new JsonElementObject(jsonReader));
                    break;
                    }
                case Token.StartArray: {
                    Items.Add(new JsonElementArray(jsonReader));
                    break;
                    }
                case Token.EndArray: {
                    going = false;
                    break;
                    }
                default: {
                    break;
                    }
                }
            if (going) {
                jsonReader.GetToken();
                going = jsonReader.TokenType == Token.Comma;
                }
            }
        }
    }


