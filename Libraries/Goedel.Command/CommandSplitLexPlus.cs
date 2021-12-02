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



namespace Goedel.Command;

/// <summary>
/// Split a command line into parts.
/// </summary>
public partial class CommandSplitLex {

    /// <summary>
    /// Split a commandline into entries.
    /// </summary>
    /// <param name="Text">The command line to split.</param>
    /// <returns>The command line split into entries.</returns>
    public static string[] Split(string Text) {
        using var CommandSplitLex = new CommandSplitLex();
        CommandSplitLex.GetToken(Text);
        return CommandSplitLex.Value.ToArray();
        }

    LexStringReader lexStringReader;

    /// <summary>
    /// Construct a parser to read from a string to be specified in GetToken (data)
    /// </summary>
    public CommandSplitLex() {
        lexStringReader = new LexStringReader(null);
        Reader = lexStringReader;
        }

    /// <summary>
    /// Parse the specified string. Note, this is only valid if no LexReader
    /// was specified in the constructor.
    /// </summary>
    /// <param name="Data">The string to parse.</param>
    /// <returns>The token value.</returns>
    public Token GetToken(string Data) {
        lexStringReader.String = Data;
        Reset();
        return GetToken();
        }


    /// <summary>
    /// Return the resulting string value
    /// </summary>
    public List<string> Value {
        get {
            if (pending) {
                AddParam();
                pending = false;
                }
            return arguments;
            }
        }

    // Private variables
    bool pending = false; // if true, there is an incomplete value to be added.
    int escapeCount = 0;
    List<string> arguments = new();
    StringBuilder buildValue = new();

    /// <summary>
    /// Reset the value buffers to start a new parse.
    /// </summary>
    public override void Reset() {
        arguments.Clear();
        buildValue.Clear();
        pending = false;
        escapeCount = 0;
        }

    /// <summary>
    /// Reset the value buffers to start a new parse.
    /// </summary>
    /// <param name="c">The character read</param>
    public virtual void AddParam(int c) => AddParam();

    void AddParam() {
        // Add any pending escape characters
        for (var i = 0; i < escapeCount; i++) {
            buildValue.Append('\\');
            }
        // Add the parameter to the build string
        var Text = buildValue.ToString();
        if (pending) {
            arguments.Add(Text);
            }
        // Reset all buffers
        escapeCount = 0;
        buildValue.Clear();
        }

    /// <summary>
    /// Do nothing
    /// </summary>
    /// <param name="c">The character read</param>
    public virtual void Ignore(int c) {
        }


    /// <summary>
    /// Start a quoted parameter, this can be null
    /// </summary>
    /// <param name="c">The character read</param>
    public virtual void BeginValue(int c) => pending = true;

    /// <summary>
    /// Add a character to the value buffer
    /// </summary>
    /// <param name="c">The character read</param>
    public virtual void AddValue(int c) {
        escapeCount = 0;
        pending = true;
        buildValue.Append((char)c);
        }

    /// <summary>
    /// Add a character to the value buffer
    /// </summary>
    /// <param name="c">The character read</param>
    public virtual void AddEscape(int c) {
        pending = true;
        escapeCount++;
        }

    /// <summary>
    /// Add a sequence of escape characters to the value buffer. If the final character is not
    /// a double quote, the escape characters are simply added. Otherwise, each pair of escape
    /// characters results in a single escape character and a double quote is added if the number
    /// of escape characters is odd.
    /// </summary>
    /// <param name="c">The character read</param>
    public virtual void AddEscapedValue(int c) {

        if (c == '\"') {
            while (escapeCount > 1) {
                escapeCount -= 2;
                buildValue.Append('\\');
                }
            if (escapeCount == 1) {
                buildValue.Append('\"');
                }
            }
        else {
            for (var i = 0; i < escapeCount; i++) {
                buildValue.Append('\\');
                }
            buildValue.Append((char)c);
            }
        escapeCount = 0;

        }

    }
