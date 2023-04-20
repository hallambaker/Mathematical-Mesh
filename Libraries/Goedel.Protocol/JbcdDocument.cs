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
/// Class representing a Json DOM.
/// </summary>
public abstract class JbcdDocument : IJcbdDocument {

    ///<inheritdoc/>
    public JbcdValue Root { get; set; }

    ///<summary>The reader used to traverse the document.</summary> 
    protected JsonBcdReader Reader { get; set; }

    ///<inheritdoc/>
    public byte Overwrite { get; } = 32;

    ///<summary>The starting point for the document within the byte stream</summary> 
    protected long Start { get; init; }

    ///<summary>The length the document within the byte stream</summary> 
    protected long Length { get; init; }

    ///<summary>Position in the document stream</summary> 
    protected abstract long Position { get; }

    ///<inheritdoc/>
    public abstract void Erase(long start, int length, byte[] data = null);

    ///<inheritdoc/>
    public abstract string TryReadString(long position);

    long positionStart;
    long positionEnd;
    long tokenLength => positionEnd - positionStart;
    Token GetToken() {

        positionStart = Position;
        Reader.GetToken();

        if (Reader.TokenType == Token.Binary) {
            Reader.ReadBinaryData();
            }
        positionEnd = Position;

        return Reader.TokenType;
        }

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
    public void Parse(
                    bool lazy = false,
                    Dictionary<string, Property> properties = null) {
        var start = Position;

        var token = GetToken();
        switch (token) {
            case Token.StartArray: {
                Root = GetArray();
                break;
                }
            case Token.StartObject: {
                Root = GetObject();
                break;
                }
            default: throw new NYI();
            }
        Root.DataStartPosition = start;
        Root.DataLength = Position - start;
        }


    JbcdValueObject GetObject() {
        var result = new JbcdValueObject() { 
            DataStartPosition = Position
            };
        var token = GetToken();
        if (token == Token.EndObject) {
            return result;
            }

        while (true) {
            var value = GetElement(token);
            result.Elements.Add(value);

            token = GetToken();
            switch (token) {
                case Token.EndObject: {
                    result.DataLength = (int) (Position - result.DataStartPosition);
                    return result;
                    }
                case Token.Comma: {
                    token = GetToken();
                    break;
                    }
                default: {
                    throw new NYI();
                    }
                }
            }
        }

    JbcdValueArray GetArray() {

        var result = new JbcdValueArray() {
            DataStartPosition = Position
            };

        var token = GetToken();
        if (token == Token.EndArray) {
            return result;
            }

        while (true) {
            var value = GetValue(token);
            result.Values.Add(value);

            token = GetToken();
            switch (token) {
                case Token.EndArray: {
                    result.DataLength = (int)(Position - result.DataStartPosition);
                    return result;
                    }
                case Token.Comma: {
                    token = GetToken();
                    break;
                    }
                default: {
                    throw new NYI();
                    }
                }
            }
        }


    JbcdElement GetElement(Token token) {

        switch (token) {
            case Token.Tag: 
            case Token.String: {

                var start = positionStart;
                var tag = Reader.ResultString;

                token = GetToken();
                (token == Token.Colon).AssertTrue(NYI.Throw);


                token = GetToken();
                var value = GetValue(token);

                return new JbcdElement() { 
                    Name = tag,
                    Value = value,
                    ElementStartPosition = start,
                    ElementLength = Position - start};
                }
            default: {
                throw new NYI();
                }
            }


        }


    JbcdValue GetValue(Token token) {
        switch (token) {
            case Token.StartArray: {
                return GetArray();
                }
            case Token.StartObject: {
                return GetObject();
                }
            case Token.Integer: {
                return new JbcdValueNumber() {
                    Integer = Reader.ResultInt64,
                    Precision = NumberPrecision.Integer,
                    DataStartPosition = positionStart,
                    DataLength = tokenLength
                    };
                }
            case Token.True: {
                return new JbcdValueLiteral(true) {
                    DataStartPosition = positionStart,
                    DataLength = tokenLength
                    };
                }
            case Token.False: {
                return new JbcdValueLiteral(false) {
                    DataStartPosition = positionStart,
                    DataLength = tokenLength
                    };
                }
            case Token.Null: {
                return new JbcdValueLiteral(null) {
                    DataStartPosition = positionStart,
                    DataLength = tokenLength
                    };
                }
            case Token.String: {
                return new JbcdValueString(Reader.ResultString) {
                    DataStartPosition = positionStart,
                    DataLength = tokenLength
                    };
                }
            case Token.Binary: {
                return new JbcdValueBinary(Reader.ResultBinary) {
                    DataStartPosition = positionStart,
                    DataLength = tokenLength
                    };
                }
            default: {
                throw new NYI();
                }

            }
        }


    }



/// <summary>
/// A document containing a JSON or JSON-BCD file. The naming is purposefully 
/// different to avoid conflict with the .NET JSON parser clases.
/// </summary>
public class JbcdDocumentFile : JbcdDocument {

    ///<summary>The backing file.</summary> 
    public FileStream File { get; }

    ///<inheritdoc/>
    protected override long Position => File.Position;


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
        length = length < 0 ? file.Length : length;

        var boundedReader = new CharacterStreamSeekBoundedReader(File, start, length);

        Reader = new JsonBcdReader(boundedReader);
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

        File.Position = start;
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

    //long index;

    ///<inheritdoc/>
    protected override long Position => throw new NYI();

    ///<summary>The data buffer.</summary> 
    public byte[] Data { get; }

    /// <summary>
    /// Constructor returning an instance from the file <paramref queries="file"/>
    /// which must allow write access for the values modification functions to work.
    /// </summary>
    /// <param queries="file">The file to be read.</param>
    public JbcdDocumentMemory(
                byte[] data,
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
/// Parsed DARE envelope.
/// </summary>
public class JcbdEnvelope {


    ///<summary>DARE Header</summary> 
    public JbcdValueObject Header;

    ///<summary>DARE Body</summary> 
    public JbcdValueBinary Body;

    ///<summary>DARE Trailer</summary> 
    public JbcdValueObject Trailer;

    /// <summary>
    /// Constructor, return the envelope contained in <paramref name="document"/>.
    /// </summary>
    /// <param name="document">The parsed document.</param>
    public JcbdEnvelope(JbcdDocument document) {

        var array = document.Root as JbcdValueArray;
        array.AssertNotNull(NYI.Throw);
        (array.Values.Count >=2).AssertTrue(NYI.Throw);

        Header = array.Values[0] as JbcdValueObject;
        Body = array.Values[1] as JbcdValueBinary;

        if (array.Values.Count > 2) {
            Trailer = array.Values[2] as JbcdValueObject;
            }


        }







    }