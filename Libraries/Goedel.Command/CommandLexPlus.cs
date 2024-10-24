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


using Goedel.FSR;



namespace Goedel.Command;

/// <summary>
/// Lexical analyzer for command line parsing.
/// </summary>
public partial class CommandLex {
    readonly LexStringReader LexStringReader;

    /// <summary>
    /// Construct a parser to read from a string to be specified in GetToken (data)
    /// </summary>
    public CommandLex() {
        LexStringReader = new LexStringReader(null);
        Reader = LexStringReader;
        }

    /// <summary>
    /// Parse the specified string. Note, this is only valid if no LexReader
    /// was specified in the constructor.
    /// </summary>
    /// <param name="Data">The data to parse</param>
    /// <returns>The token value.</returns>
    public Token GetToken(string Data) {
        LexStringReader.String = Data;
        Reset();
        return GetToken();
        }


    /// <summary>
    /// Return the resulting string value
    /// </summary>
    public string Value => BuildValue.ToString();

    /// <summary>
    /// Return the resulting string value
    /// </summary>
    public string Flag => BuildFlag.ToString();

    /// <summary>
    /// If true, flag was negated.
    /// </summary>
    public bool Not { get; set; }

    readonly StringBuilder BuildValue = new();
    readonly StringBuilder BuildFlag = new();

    /// <summary>
    /// Reset the value buffers to start a new parse.
    /// </summary>
    public override void Reset() {
        BuildValue.Clear();
        BuildFlag.Clear();
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
    /// Add a character to the value buffer
    /// </summary>
    /// <param name="c">The character read</param>
    public virtual void AddValue(int c) => BuildValue.Append((char)c);

    /// <summary>
    /// Add a character to the flag buffer
    /// </summary>
    /// <param name="c">The character read</param>
    public virtual void AddFlag(int c) => BuildFlag.Append((char)c);

    /// <summary>
    /// N of possible NO flag
    /// </summary>
    /// <param name="c">The character read</param>
    public virtual void AddFlagN(int c) => BuildFlag.Append((char)c);

    /// <summary>
    /// O of possible NO flag
    /// </summary>
    /// <param name="c">The character read</param>
    public virtual void AddFlagNo(int c) {
        BuildFlag.Clear(); // delete 'no' prefix
        Not = true;
        }
    /// <summary>
    /// Abort parsing, the command cannot be read.
    /// </summary>
    /// <param name="c">The character read</param>
    public virtual void Abort(int c) {
        }



    }
