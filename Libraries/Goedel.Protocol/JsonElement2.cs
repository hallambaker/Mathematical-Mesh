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



/// <summary>Base record for Json deserialization output.</summary>
public abstract record JsonElement2 {

    /// <summary>Parse the stream from <paramref name="jsonReader"/>.</summary>
    /// <param name="jsonReader">The reader.</param>
    /// <returns>An element tree.</returns>
    public static JsonElement2? Parse(
                    JsonReader jsonReader) {
        jsonReader.GetToken();


        switch (jsonReader.TokenType) {
            case Token.StartObject: {
                jsonReader.PeekToken();
                if (jsonReader.TokenType == Token.EndObject) {
                    jsonReader.GetToken();
                    return null;
                    }
                return new JsonElementObject(jsonReader);
                }
            case Token.StartArray: {
                jsonReader.PeekToken();
                if (jsonReader.TokenType == Token.EndArray) {
                    jsonReader.GetToken();
                    return null;
                    }
                return new JsonElementArray(jsonReader);
                }

            }

        return null;
        }



    }

/// <summary>Null element</summary>
public record JsonElementNull() : JsonElement2 {

    }

/// <summary>JSON boolean element value</summary>
/// <param name="Value">The value of the element.</param>
public record JsonElementBoolean (
            bool Value) : JsonElement2 {
        }

/// <summary>JSON string element value</summary>
/// <param name="Value">The value of the element.</param>
public record JsonElementString(
            string Value) : JsonElement2 {

    /// <summary>Convert the element value to an RFC 3339 date time.</summary>
    /// <returns>The result of the conversion.</returns>
    public DateTime GetDateTime() => Value.FromRFC3339();

    /// <summary>Convert the element value to binary encoded as base64url encoding.</summary>
    /// <returns>The result of the conversion.</returns>
    public byte[] GetBinary() => Value.FromBase64();
    }

/// <summary>JSON DateTime element value</summary>
/// <param name="Value">The value of the element.</param>
public record JsonElementDateTime(
            DateTime Value) : JsonElement2 {

    }

/// <summary>JSON binary element value</summary>
/// <param name="Value">The value of the element.</param>
public record JsonElementBinary(
            byte[] Value) : JsonElement2 {

    }

/// <summary>JSON number element value</summary>
/// <param name="Value">The string value of the element.</param>
public record JsonElementNumber(
            string? Value) : JsonElement2 {

    /// <summary>Return the value of the number as a signed 32 bit integer.</summary>
    /// <returns>The value of the number as a signed 32 bit integer.</returns>
    public virtual int GetInt32() => Int32.Parse(Value);

    /// <summary>Return the value of the number as a signed 64 bit integer.</summary>
    /// <returns>The value of the number as a signed 64 bit integer.</returns>
    public virtual long GetInt64() => Int64.Parse(Value);

    /// <summary>Return the value of the number as a signed 32 bit real.</summary>
    /// <returns>The value of the number as a signed 32 bit real.</returns>
    public virtual Single GetReal32() => Single.Parse(Value);

    /// <summary>Return the value of the number as a signed 64 bit real.</summary>
    /// <returns>The value of the number as a signed 64 bit real.</returns>
    public virtual Double GetReal64() => Double.Parse(Value);
    }

/// <summary>JSON 64 bit integer number element value</summary>
/// <param name="intValue">The string value of the element.</param>
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


/// <summary>JSON 32 bit real number element value</summary>
/// <param name="floatValue">The string value of the element.</param>
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

/// <summary>JSON 64 bit real number element value</summary>
/// <param name="doubleValue">The string value of the element.</param>
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





/// <summary>JSON object value.</summary>
public record JsonElementObject() : JsonElement2 {

    /// <summary>Attempt to return a property with tag <paramref name="tag"/></summary>
    /// <param name="tag"></param>
    /// <param name="element">The element corresponding to the tag.</param>
    /// <returns>True if the property is present, otherwise false.</returns>
    public bool TryGetProperty (string tag, out JsonElement2 element) =>
        Properties.TryGetValue (tag, out element);

    /// <summary>Returns the first property in the object.</summary>
    /// <returns>The peoperty tag and element.</returns>
    public KeyValuePair<string,JsonElement2> SoloProperty() {
        var enumerator = Properties.GetEnumerator();
        if (!enumerator.MoveNext()) {
            throw new NYI();
            }
        return enumerator.Current;
        }
    
    /// <summary>Dictionary of properties contained in the object.</summary>
    public Dictionary<string, JsonElement2> Properties = [];

    /// <summary>Constructor, generates an instance by parsing the stream 
    /// <paramref name="jsonReader"/></summary>
    /// <param name="jsonReader">The stream to parse.</param>

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

/// <summary>JSON array element.</summary>
public record JsonElementArray() : JsonElement2 {

    /// <summary>The items contained in the array.</summary>
    public List<JsonElement2> Items = [];

    /// <summary>Constructor, generates an instance by parsing the stream 
    /// <paramref name="jsonReader"/></summary>
    /// <param name="jsonReader">The stream to parse.</param>
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


