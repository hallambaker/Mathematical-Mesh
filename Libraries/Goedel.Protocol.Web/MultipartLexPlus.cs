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



using Goedel.FSR;

using static System.Net.Mime.MediaTypeNames;



namespace Goedel.Protocol.Web;



/// <summary>
/// Lexical analyzer for command line parsing.
/// </summary>
public partial class MultipartLex {


    readonly StringBuilder builder = new();
    string? Tag { get;  set; } = null;
    string? Value { get;  set; } = null;
    string? PTag { get;  set; } = null;
    string? PValue { get;  set; } = null;

    State state = 0;

    FieldData FieldData;

    /// <summary>
    /// Construct a parser to read from a string to be specified in GetToken (data)
    /// </summary>
    public MultipartLex() {
        //LexStringReader = new LexStringReader(data);
        //Reader = LexStringReader;
        }


    /// <summary>
    /// Process the byte <paramref name="data"/>.
    /// </summary>
    /// <param name="data">The byte to process.</param>
    /// <returns>True if the data parsed correctly, otherwise false.</returns>
    public bool Process(int data) {
        if (state < 0 | data < 0 | data >255) {
            Console.WriteLine("Error");
            return false;
            }
        var mapping = Character_Mapping[data];
        var nextState = Compressed_Transitions[(int)state, mapping];
        if (nextState < 0) {
            //Console.WriteLine($"Error {state}->{nextState}  [{(char)data}]");
            }
        else {
            //Console.WriteLine($"{state} {(char)data}  {mapping}");

            var action = Actions[nextState];

            action(data);
            state = (State)nextState;
            }

        return true;
        }

    /// <summary>
    /// Reset the value buffers to start a new parse and set the template to be filled
    /// to <paramref name="fieldData"/>.
    /// </summary>
    public void Reset(FieldData fieldData) {
        FieldData = fieldData;
        Reset();
        }


    /// <summary>
    /// Reset the value buffers to start a new parse.
    /// </summary>
    public override void Reset() {
        state = 0;
        builder.Clear();
        }

    /// <summary>
    /// Reset the value buffers to start a new parse.
    /// </summary>
    /// <param name="c">The character read</param>
    public virtual void Reset(int c) => Reset();

    /// <summary>
    /// Do nothing
    /// </summary>
    /// <param name="c">The character read</param>
    public virtual void Ignore(int c) {
        }

    /// <summary>
    /// Add to the buffer.
    /// </summary>
    /// <param name="c">The character read</param>
    public virtual void AddTag(int c) {
        builder.Append((char)c);
        }

    /// <summary>
    /// Register the header tag.
    /// </summary>
    /// <param name="c">The character read</param>
    public virtual void GotTag(int c) {
        Tag = builder.ToString();
        builder.Clear();
        }

    /// <summary>
    /// Add to the buffer.
    /// </summary>
    /// <param name="c">The character read</param>
    public virtual void AddValue(int c) {
        builder.Append((char)c);
        }

    /// <summary>
    /// Register the header primary value.
    /// </summary>
    /// <param name="c">The character read</param>
    public virtual void GotValue(int c) {
        Value = builder.ToString();
        builder.Clear();

        if (Tag == "Content-Type") {
            FieldData.ContentType = Value;
            }
        }

    /// <summary>
    /// Add to the buffer.
    /// </summary>
    /// <param name="c">The character read</param>
    public virtual void AddParameter(int c) {
        builder.Append((char)c);
        }

    /// <summary>
    /// Register a parameter tag.
    /// </summary>
    /// <param name="c">The character read</param>
    public virtual void GotParameter(int c) {
        PTag = builder.ToString();
        builder.Clear();
        }

    /// <summary>
    /// Add to the buffer.
    /// </summary>
    /// <param name="c">The character read</param>
    public virtual void AddPValue(int c) {
        builder.Append((char)c);
        }

    /// <summary>
    /// Register a parameter value.
    /// </summary>
    /// <param name="c">The character read</param>
    public virtual void GotPValue(int c) {
        PValue = builder.ToString();
        builder.Clear();

        if (Tag == "Content-Disposition") {
            if (PTag == "filename") {
                FieldData.Filename = PValue;
                }
            else if (PTag == "name") {
                FieldData.Name = PValue;
                }
            }
        }

    /// <summary>
    /// End the parse
    /// </summary>
    /// <param name="c">The character read</param>
    public virtual void End(int c) {
        //Have completed the header, don't read any more.
        }

    /// <summary>
    /// Abort the parse
    /// </summary>
    /// <param name="c">The character read</param>
    public virtual void Abort(int c) {

        }

    }
