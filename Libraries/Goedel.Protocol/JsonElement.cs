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
/// Interface to a document allowing certain read/write operations.
/// </summary>
public interface IJcbdDocument {

    ///<summary>The root result.</summary> 
    public JbcdValueObject Root { get; set; }

    ///<summary>The character to be used to overwrite data being erased.</summary> 
    public byte Overwrite { get; }


    



    /// <summary>
    /// Erase the data in the range beinging at <paramref query="start"/> and
    /// continuing for <paramref query="length"/> bytes. The first bytes are 
    /// replaced by <paramref query="data"/> unless null.
    /// </summary>
    /// <param query="start">The first byte to erase.</param>
    /// <param query="length">The number of bytes to erase.</param>
    /// <param query="data">The </param>
    public void Erase(
                long start,
                int length,
                byte[] data = null);

    /// <summary>
    /// Read a string values begining at the position <paramref name="position"/>.
    /// </summary>
    /// <param name="position">The position to begin reading from.</param>
    /// <returns>The string values read</returns>
    public string TryReadString(
            long position);


    /// <summary>
    /// Gets a <see cref="JbcdElement"/> representing the values of a required property identified by 
    /// the path <paramref queries="queries"/>
    /// <para>
    /// The objective is to allow easy access to elements within a document using queries of
    /// the form: <code>document.TryGetPath(out result, "First", "Second", 1, "Fourth")</code> 
    /// to obtain the values at <code>First.Second[1].Fourth.</code>.
    /// </para>
    /// </summary>
    /// <param queries="queries">The list of property queries defining the path whose values is to be returned.</param>
    /// <returns>A <see cref="JbcdElement"/> representing the values of the requested property.</returns>
    public bool TryGetPath(out JbcdValue value, params object[] path) {
        if (path == null || path.Length == 0) {
            value = Root;
            return true;
            }

        var element = Root.GetProperty(path[0] as string);
        return TryGetPath(element.Value, out value, 1, path);
        }

    private static bool TryGetPath(JbcdValue valueIn, out JbcdValue value, int start, params object[] path) {
        value = valueIn;
        for (var i = start; i < path.Length; i++) {
            var query = path[i];

            switch (value) {
                case JbcdValueObject elementObject: {
                    if (query is string name) {
                        value = elementObject.GetProperty(name).Value;
                        }
                    else {
                        return false;
                        }
                    break;
                    }
                case JbcdValueArray elementArray: {
                    if (query is int index) {
                        value = elementArray.Values[index];
                        }
                    else {
                        return false;
                        }
                    break;
                    }
                default: {
                    return false;
                    }
                }
            }
        return true;
        }
    }

/// <summary>
/// Interface for memory saving lazy evaluation result inmplementations.
/// </summary>
public interface ICachable {
    
    /// <summary>
    /// Load the cahced values.
    /// </summary>
    void Load();

    /// <summary>
    /// Unload the cahced values.
    /// </summary>
    void Unload();
    }

/// <summary>
/// Number types that can be returned when parsing.
/// </summary>
public enum NumberPrecision {
    ///<summary>The number is an integer with no decimal point specified.</summary> 
    Integer,

    ///<summary>The number is an decimal with a decimal point specified but no exponent.</summary> 
    Decimal,

    ///<summary>The number is a floating point values.</summary> 
    Double

    }

public abstract class JbcdDocument : IJcbdDocument {

    ///<inheritdoc/>
    public JbcdValueObject Root { get; set; }

    ///<inheritdoc/>
    public byte Overwrite { get; } = 32;

    ///<summary>The starting point for the document within the byte stream</summary> 
    protected long Start { get; init; }

    ///<summary>The length the document within the byte stream</summary> 
    protected long Length { get; init; }

    ///<inheritdoc/>
    public abstract void Erase(long start, int length, byte[] data = null);

    ///<inheritdoc/>
    public abstract string TryReadString(long position);

    /// <summary>
    /// Parse data from the stream <paramref name="file"/> in the interval
    /// <paramref name="start"/> through <paramref name="length"/> to return a 
    /// <see cref="JbcdDocument"/>.
    /// </summary>
    /// <param name="file">The file to read data from.</param>
    /// <param name="start">The first byte in the file to parse.</param>
    /// <param name="length">The number of bytes to parse.</param>
    /// <param name="lazy">If true, lazy evaluation should be used.</param>
    /// <returns>The parsed data.</returns>
    public static JbcdDocument Parse(
                FileStream file,
                long start = 0,
                long length = -1,
                bool lazy = false) {
        var result = new JbcdDocumentFile(file) {
            Start= start,
            Length= length
            };
        result.Parse(lazy);
        return result;
        }

    /// <summary>
    /// Parse data from the buffer <paramref name="data"/> in the interval
    /// <paramref name="start"/> through <paramref name="length"/> to return a 
    /// <see cref="JbcdDocument"/>.
    /// </summary>
    /// <param name="data">The data to be read.</param>
    /// <param name="start">The first byte in the file to parse.</param>
    /// <param name="length">The number of bytes to parse.</param>
    /// <param name="lazy">If true, lazy evaluation should be used.</param>
    /// <returns>The parsed data.</returns>
    public static JbcdDocument Parse(
                byte[] data, 
                long start = 0, 
                long length = -1,
                bool lazy = false) {
        var result = new JbcdDocumentMemory(data) {
            Start = start,
            Length = length
            };
        result.Parse(lazy);
        return result;
        }


    /// <summary>
    /// Parse the document to create a DOM.
    /// </summary>
    /// <param name="lazy">If true, use lazy evaluation.</param>
    /// <param name="properties">Properties dictionary.</param>
    /// <returns>The parsed <see cref="JsonObject"/></returns>
    public JsonObject Parse(
                    bool lazy = false,
                    Dictionary<string, Property> properties = null) {
        throw new NYI();
        }


    }



/// <summary>
/// A document containing a JSON or JSON-BCD file. The naming is purposefully 
/// different to avoid conflict with the .NET JSON parser clases.
/// </summary>
public class JbcdDocumentFile : JbcdDocument {

    ///<summary>The backing file.</summary> 
    public FileStream File { get; }




    /// <summary>
    /// Constructor returning an instance from the file <paramref queries="file"/>
    /// which must allow write access for the values modification functions to work.
    /// </summary>
    /// <param queries="file">The file to be read.</param>
    public JbcdDocumentFile(
                FileStream file,
                long start = 0,
                long length = -1) {
        File = file;
        }


    ///<inheritdoc/>
    public override string TryReadString(
                long position) {
        throw new NYI();
        }


    ///<inheritdoc/>
    ///<remarks>Since erasure is expected to be an infrequent event, this implementation is
    ///not optimized for speed, each byte in the target file being individually overwritten.</remarks>
    public override void Erase(
                long start,
                int length,
                byte[] data = null) {

        File.Position= start;
        if (data != null) {
            File.Write(data, 0, data.Length);
            }

        for (var i = start; i < length; i++) {
            File.WriteByte(Overwrite);
            }
        }

    }

/// <summary>
/// A document containing a JSON or JSON-BCD file. The naming is purposefully 
/// different to avoid conflict with the .NET JSON parser clases.
/// </summary>
public class JbcdDocumentMemory : JbcdDocument {

    ///<summary>The data buffer.</summary> 
    public byte[] Data { get; }

    /// <summary>
    /// Constructor returning an instance from the file <paramref queries="file"/>
    /// which must allow write access for the values modification functions to work.
    /// </summary>
    /// <param queries="file">The file to be read.</param>
    public JbcdDocumentMemory(
                byte []data,
                long start = 0,
                long length = -1) {
        Data = data;
        }


    ///<inheritdoc/>
    public override string TryReadString(
                long position) {
        throw new NYI();
        }


    ///<inheritdoc/>
    ///<remarks>Since erasure is expected to be an infrequent event, this implementation is
    ///not optimized for speed, each byte in the target file being individually overwritten.</remarks>
    public override void Erase(
                long start,
                int length,
                byte[] data = null) {

        throw new NYI();
        }

    }



/// <summary>
/// Record describing a parsed Jbcd result.
/// </summary>
public abstract record JbcdElement {

    ///<summary>Enclosing document.</summary> 
    public IJcbdDocument Document { get; init; }

    ///<summary>The result name.</summary> 
    public virtual string Name { get; init; }

    ///<summary>The result query.</summary> 
    public virtual JbcdValue Value { get; set; }

    ///<summary>The first byte of the result in the document. For a JSON document, this
    ///is always the initial double quote character.</summary> 
    public long ElementStartPosition { get; set; }

    ///<summary>The length of the result in bytes from the first byte of the result
    ///to the following separator character if present or the enclosing array or 
    ///object closure character.</summary> 
    public long ElementLength { get; set; }

    /// <summary>
    /// Erase the result data from the backing store.
    /// </summary>
    public void Erase() {
        Document.Erase(ElementStartPosition, (int)ElementLength, null);
        }

    /// <summary>
    /// Gets a <see cref="JbcdElement"/> representing the values of a required property identified by 
    /// the path <paramref queries="queries"/>
    /// </summary>
    /// <param queries="queries">The list of property queries defining the path whose values is to be returned.</param>
    /// <returns>A <see cref="JbcdElement"/> representing the values of the requested property.</returns>
    public bool TryGetPath(out JbcdElement element, params object[] queries) {
        if (queries.Length == 0) {
            element = this;
            return true;
            }
        element = this;
        for (var i = 0; i < queries.Length; i++) {
            var query = queries[i];
            switch (element.Value) {
                case JbcdValueObject elementObject: {
                    if (query is string name) {
                        element = elementObject.GetProperty(name);
                        }
                    else {
                        return false;
                        }
                    break;
                    }
                case JbcdValueArray elementArray: {
                    if (query is int index) {
                        "Work out array indexing...".TaskFunctionality(true);
                        //result = elementArray.GetProperty(start);
                        }
                    else {
                        return false;
                        }
                    break;
                    }
                default: {
                    return false;
                    }
                }
            }
        return true;
        }

    }


/// <summary>
/// Record describing a parsed Jbcd values result.
/// </summary>
public abstract record JbcdValue  {

    ///<summary></summary> 
    public long DataStartPosition { get; set; }

    ///<summary></summary> 
    public int DataLength { get; set; }
    }

/// <summary>
/// Record describing a parsed Jbcd object result.
/// </summary>
/// <remarks>The property <see cref="Elements"/>is specified as an enumerable.
/// If an implementation requires use of objects with a very large number of 
/// elements requiring random access by result name, a dictionary implementation 
/// may be substituted.</remarks> 
public record JbcdValueObject : JbcdValue {

    ///<summary>The elements.</summary> 
    public virtual IEnumerable<JbcdElement> Elements { get; init; }

    /// <summary>
    /// Gets a <see cref="JbcdElement"/> representing the values of a required property identified by 
    /// <paramref queries="query"/>
    /// </summary>
    /// <param queries="query">The queries of the property whose values is to be returned.</param>
    /// <returns>A <see cref="JbcdElement"/> representing the values of the requested property.</returns>
    public virtual JbcdElement GetProperty(string name) {
        foreach (var element in Elements) {
            if (element.Name == name) {
                return element;
                }
            }

        return null;
        }
    }


/// <summary>
/// Record describing a parsed Jbcd array result.
/// </summary>
public record JbcdValueArray : JbcdValue {

    ///<summary>The array of elements.</summary> 
    public virtual IList<JbcdValue> Values { get; set; }

    /// <summary>
    /// Gets a <see cref="JbcdElement"/> representing the values of a required property identified by 
    /// <paramref queries="query"/>
    /// </summary>
    /// <param queries="query">The queries of the property whose values is to be returned.</param>
    /// <returns>A <see cref="JbcdElement"/> representing the values of the requested property.</returns>
    public JbcdValue GetProperty(int index) {
        return Values[index];
        }

    }

/// <summary>
/// Record describing a parsed Jbcd string result.
/// </summary>
public record JbcdValueString : JbcdValue {
    
    ///<summary>The string values</summary> 
    public virtual string? Value { get; }

    /// <summary>
    /// Constructor for use by derrived records.
    /// </summary>
    protected JbcdValueString () { 
        }

    /// <summary>
    /// Constructor returning an instance for the values <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The values of the string.</param>
    public JbcdValueString(string value) {
        Value = value;
        }

    /// <summary>
    /// Attempt to parse <see cref="Value"/> as an RFC3339 encoded 
    /// values and return <code>true</code> if successful, otherwise false.
    /// The parsed values is returned in in <paramref name="dateTime"/>.
    /// </summary>
    /// <param name="dateTime">The parsed values if successful, otherwise 
    /// the default values for the type.</param>
    /// <returns>True if the parse succeeded, otherwise false.</returns>
    public virtual bool TryGetDate(out DateTime dateTime) => Value.TryParseRFC3339(out dateTime);

    /// <summary>
    /// Attempt to parse <see cref="Value"/> as Base64 encoded 
    /// data and return <code>true</code> if successful, otherwise false.
    /// The parsed values is returned in in <paramref name="binary"/>.
    /// </summary>
    /// <param name="binary">The parsed values if successful, otherwise 
    /// the default values for the type.</param>
    /// <returns>True if the parse succeeded, otherwise false.</returns>
    public virtual bool TryGetBinary(out byte[] binary) {
        throw new NYI();
        }

    }


/// <summary>
/// Record describing a parsed Jbcd values result. The values itself
/// is kept in string form to allow 
/// </summary>
public record JbcdValueNumber : JbcdValue {


    ///<summary>The number values</summary> 
    public virtual string Value { get; init; }

    ///<summary>The number precision</summary> 
    public virtual NumberPrecision Precision { get; init; }

    /// <summary>
    /// Constructor returning an instance for the values <paramref name="value"/>
    /// with specified precision <paramref name="precision"/>.
    /// </summary>
    /// <param name="value">The values of the string.</param>
    /// <param name="precision">The number precision.</param>
    public JbcdValueNumber (
                string value,
                NumberPrecision precision ) { 
        Value = value;
        Precision = precision;
        }

    /// <summary>
    /// Attempt to parse <see cref="Value"/> as an int32 integer
    /// and return <code>true</code> if successful, otherwise false.
    /// The parsed values is returned in in <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The parsed values if successful, otherwise 
    /// the default values for the type.</param>
    /// <returns>True if the parse succeeded, otherwise false.</returns>
    public virtual bool TryGetInt(out int value) => Int32.TryParse(Value, out value);

    /// <summary>
    /// Attempt to parse <see cref="Value"/> as an int64 integer
    /// and return <code>true</code> if successful, otherwise false.
    /// The parsed values is returned in in <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The parsed values if successful, otherwise 
    /// the default values for the type.</param>
    /// <returns>True if the parse succeeded, otherwise false.</returns>
    public virtual bool TryGetLong(out long value) => Int64.TryParse(Value, out value);

    /// <summary>
    /// Attempt to parse <see cref="Value"/> as a double floating point number
    /// and return <code>true</code> if successful, otherwise false.
    /// The parsed values is returned in in <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The parsed values if successful, otherwise 
    /// the default values for the type.</param>
    /// <returns>True if the parse succeeded, otherwise false.</returns>
    public virtual bool TryGetDouble(out double value) => Double.TryParse(Value, out value);

    /// <summary>
    /// Attempt to parse <see cref="Value"/> as a a decimal number
    /// and return <code>true</code> if successful, otherwise false.
    /// The parsed values is returned in in <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The parsed values if successful, otherwise 
    /// the default values for the type.</param>
    /// <returns>True if the parse succeeded, otherwise false.</returns>
    public virtual bool TryGetDecimal(out Decimal value) => Decimal.TryParse(Value, out value);

    }

/// <summary>
/// Record describing a parsed Jbcd values result. The values itself
/// is kept in string form to allow 
/// </summary>
public record JbcdValueLiteral : JbcdValue {

    ///<summary>The parsed values of the literal.  </summary>
    public bool? Value;

    /// <summary>
    /// Constructor, return an instance with the values <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The values of the result.</param>
    public JbcdValueLiteral(bool? value) {
        Value = value;
        }

    }

#region // Lazy evaluation variants.

/// <summary>
/// Record describing a Jbcd array values for lazy evaluation.
/// </summary>
public record JbcdValueObjectLazy : JbcdValueObject, ICachable {
    ///<summary>Enclosing document.</summary> 
    public IJcbdDocument Document { get; init; }

    ///<inheritdoc/>
    public override IEnumerable<JbcdElement> Elements {
        get {
            if (read) {
                return value;
                }
            Load();
            return value;
            }
        }
    bool read = false;
    IEnumerable<JbcdElement> value;

    ///<inheritdoc/>
    public void Load() {
        read = true;
        throw new NotImplementedException();
        }

    ///<inheritdoc/>
    public void Unload() {
        read = false;
        throw new NotImplementedException();
        }
    }


/// <summary>
/// Record describing a Jbcd array values for lazy evaluation.
/// </summary>
public record JbcdValueArrayLazy : JbcdValueArray, ICachable {
    ///<summary>Enclosing document.</summary> 
    public IJcbdDocument Document { get; init; }

    ///<inheritdoc/>
    public override IList<JbcdValue> Values {
        get {
            if (read) {
                return values;
                }
            Load();
            return values;
            }
        }
    bool read = false;
    IList<JbcdValue> values;

    ///<inheritdoc/>
    public void Load() {
        read = true;
        throw new NotImplementedException();
        }

    ///<inheritdoc/>
    public void Unload() {
        read = false;
        throw new NotImplementedException();
        }
    }

/// <summary>
/// Record describing a Jbcd string result for lazy evaluation.
/// </summary>
public record JbcdValueStringLazy : JbcdValueString, ICachable {

    ///<summary>Enclosing document.</summary> 
    public IJcbdDocument Document { get; init; }

    ///<inheritdoc/>
    public override string? Value {
        get {
            if (read) {
                return value;
                }
            Load();
            return value;
            }
        }
    bool read = false;
    string? value;


    /// <summary>
    /// Constructor returning an instance that only allocates memory for a string values
    /// when required..
    /// </summary>
    protected JbcdValueStringLazy() {
        }

    ///<inheritdoc/>
    public void Load() {
        value = Document.TryReadString(DataStartPosition);
        read = true;
        }

    ///<inheritdoc/>
    public void Unload() {
        read = false;
        value = null;
        }
    }

#endregion