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


namespace Goedel.Protocol.Web;

/// <summary>
/// Parser for MIME/Multipart specialized to reading HTTP form data.
/// </summary>
public class ParsedMultipart {

    const byte dash = (byte)'-';
    const byte dot = (byte)'.';
    const byte cr = (byte)'\r';
    const byte lf = (byte)'\n';
    const byte tab = (byte)'\t';
    const byte space = (byte)' ';


    byte[] boundary = new byte[74];
    int length = 0;

    ///<summary>If true, the parse failed.</summary> 
    public bool Error { get; set; } = false;

    bool complete = false;

    StreamLookaheadReader Stream { get; }
    MultipartLex Lexer { get; }
    ParsedMultipart(Stream data) {
        Stream = new StreamLookaheadReader(data);
        Lexer = new MultipartLex();
        }

    /// <summary>
    /// Parse data presented in the stream <paramref name="data"/> and record items to
    /// <paramref name="formData"/>.
    /// </summary>
    /// <param name="data">The stream to read.</param>
    /// <param name="formData">Instance to receive the parsed data.</param>
    /// <returns>The parser context.</returns>
    public static ParsedMultipart Parse(
            Stream data,
            FormData formData) {

        var result = new ParsedMultipart(data);
        result.Error = !result.ParseSteam(data, formData);

        return result;
        }


    bool ParseSteam(Stream Stream,
            FormData formData) {

        var b0 = Stream.ReadByte();
        var b1 = Stream.ReadByte();

        if (b0 != dash | b1 != dash) {
            return false;
            }
        if (!GetBoundary()) { 
            return false; 
            }

        while (!complete) {
            var fieldData = new FieldData();

            if (!GetHeaders(fieldData)) {
                return false;
                }

            var item = formData.GetFormItem (fieldData.Name);
            switch (item?.FormEntryType) {
                case FormEntryType.String: {
                    if (!GetContent(out var content)) {
                        return false;
                        }
                    var text = content.ToUTF8 ();
                    item.Setter(formData, text);
                    break;
                    }
                case FormEntryType.File: {
                    if (!GetContent(out var content)) {
                        return false;
                        }
                    var file = new FileField(null, 
                            fieldData?.Filename, fieldData?.ContentType, content);
                    item.Setter(formData, file);
                    break;
                    }
                case FormEntryType.Binary: {
                    if (!GetContent(out var content)) {
                        return false;
                        }
                    item.Setter(formData, content!);
                    break;
                    }
                default: {
                    // Ignore the data
                    if (!GetContent(out var content)) {
                        return false;
                        }
                    break;
                    }
                }


            if (!CheckContentEnd()) {
                return false;
                }


            Console.WriteLine($"{fieldData.Name}: {fieldData.Filename} {fieldData.ContentType}");
            }

        return true;
        }

    bool GetHeaders(FieldData fieldData) {
        var (result, more) = GetHeader(fieldData);
        if (result != true) { 
            return false; 
            }

        while (more) {
            (result, more) = GetHeader(fieldData);
            if (result != true) {
                return false;
                }
            }

        return true;
        }

    static bool NotWhite(int c) => (c != '\t' & c != ' ');

    (bool,bool) GetHeader(FieldData fieldData) {
        Stream.Start(256);
        Lexer.Reset(fieldData);
        var c = Stream.ReadByte();
        if (c == cr) {
            c = Stream.ReadByte();
            }
        if (c == lf) {
            return (true, false);
            }

        while (Stream.ValidLength) {
            if (!Lexer.Process(c)) {
                return (false, true);
                }

            c = Stream.ReadByte();
            if (c == cr) {
                c = Stream.ReadByte();
                }
            if (c == lf) {
                var p = Stream.Peek();
                if (NotWhite(p)) {
                    Lexer.Process((int)';');
                    return (true, true);
                    }
                c = Stream.ReadByte();
                while (Stream.ValidLength & NotWhite(c)) {
                    c = Stream.ReadByte();
                    }
                }
            }



        return (false, false);
        }


    //void Output(int b) {
    //    var c = b switch {
    //        lf => "LF",
    //        cr => "CR",
    //        -1 => "EOF",
    //        _ => ((char)b).ToString()
    //        };

    //    Console.Write(c);
    //    }

    bool GetContent(out byte[]? content) {
        content = null;

        var memoryStream = new MemoryStream();
        var i = 0;


        while (true) {
            var c = Stream.ReadByte();

            //Output(c);
            if (c < 0) {
                return false;
                }
            if (c == boundary[i]) {
                i++;
                if (i == length) {
                    content = memoryStream.ToArray();
                    return true;
                    }
                }
            else {
                if (i > 0) {
                    for (var ii = 0; ii < i; ii++) {
                        memoryStream.WriteByte(boundary[ii]);
                        }
                    }
                if (c == boundary[0]) {
                    i = 1;
                    }
                else {
                    i = 0;
                    memoryStream.WriteByte((byte)c);
                    }
                }

            }

        }

    bool CheckContentEnd() {
        var c = Stream.ReadByte();

        if (c == dash) {
            c = Stream.ReadByte();
            if (c == dash) {
                complete = true;
                return true;
                }
            return false;
            }
        else if (c == cr) {
            c = Stream.ReadByte();
            if (c == lf) {
                return true;
                }
            }
        else if (c == lf) {
            return true;
            }

        return false;
        }

    bool GetBoundary() {
        var i = 0;
        boundary[i++] = cr;
        boundary[i++] = lf;
        boundary[i++] = dash;
        boundary[i++] = dash;

        while (i < boundary.Length) {
            var c = Stream.ReadByte();
            if (c == cr) {
                c = Stream.ReadByte();
                }
            if (c == lf) {
                length = i;
                return true;
                }
            if (c < 0) { 
                return false; 
                }

            boundary[i++] = (byte)c;
            }

        return false;
        }


    }
