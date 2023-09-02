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


namespace Goedel.FSR;


/// <summary>
/// String builder stripping leading and trailing whitespace.
/// </summary>
public class Accumulate {
    readonly StringBuilder current = new();
    readonly StringBuilder whiteSpace = new();


    bool haveCharacter = false;
    bool startQuote = false;

    /// <summary>
    /// Reset all buffers.
    /// </summary>
    public void Clear() {
        current.Clear();
        whiteSpace.Clear();
        haveCharacter = false;
        }

    /// <summary>
    /// Add character to the accumulator stripping leading and trailing whitespace.
    /// </summary>
    /// <param name="c">Character to add</param>
    public void AddCurrent(int c) {
        var Character = c.ToASCII();
        if (Character == ' ' | Character == '\t') {
            if (haveCharacter) {
                whiteSpace.Append(Character);
                }
            }
        else {
            if (!haveCharacter & Character == '\"') {
                startQuote = true;
                }
            else if (!(startQuote & Character == '\"')) {
                current.Append(whiteSpace);
                whiteSpace.Clear();
                current.Append(Character);
                }
            haveCharacter = true;
            }
        }

    /// <summary>
    /// Get the value of the current item and clear the input buffers.
    /// </summary>
    /// <returns>The current item as a string.</returns>
    public string CurrentItem() {

        var Value = current.ToString();
        Clear();
        return Value;

        }
    }



/// <summary>
/// Lexical analyzer using table generated by FSRGen.
/// </summary>
public abstract class Lexer : Disposable {
    /// <summary>
    /// The lexical reader
    /// </summary>
    protected LexReader Reader { get; set; } = null;


    /// <summary>Maps characters to character groups.</summary>
    public abstract byte[] CharacterMappings { get; }
    /// <summary>Compresset transition table maps character group to next state</summary>
    public abstract short[,] CompressedTransitions { get; }
    /// <summary>Actions to perform on transition into specified state.</summary>
    public ActionDelegate[] Actions;
    /// <summary>The state before the current token was read.</summary>
    public int StateInt;
    /// <summary>The state to transition to. This can be overriden in an action
    /// to change the state table</summary>
    public int NextState = -1;

    /// <summary>
    /// If set true, debug tracing is enabled
    /// </summary>
    public static bool Trace { get; set; } = false;

    /// <summary>
    /// Get the next token calling all token actions while the
    /// stream is read.
    /// </summary>
    /// <param name="StartState">The initial state</param>
    /// <returns>The value of the token recognized.</returns>
    public virtual int GetTokenInt(int StartState) {
        StateInt = StartState;

        //Note that we call Reset() after setting the initial state
        //This allows a reset method to take different actions depending
        //on which type of data is being parsed.
        Reset();

        bool Going = Reader.Get();

        while (Going) {

            //Trace.Write(Reader.LastChar);

            int c = Reader.LastInt;
            int ct = ((c >= 0) & (c < CharacterMappings.Length)) ?
                CharacterMappings[c] : 0;

            if (Trace) {
                Debug.WriteLine("  {0} {1}:{3} {2}", StateInt, c, ct, (char)c);
                }

            NextState = CompressedTransitions[StateInt, ct];

            if (NextState >= 0) {
                ActionDelegate Action = Actions[NextState];
                Action(Reader.LastInt);
                Going = Reader.Get();
                StateInt = NextState;
                }
            else {
                Going = false;
                Reader.UnGet();
                }
            }

        return StateInt;
        }


    /// <summary>
    /// Process a character of text
    /// </summary>
    /// <param name="c">Character to process</param>
    /// <returns>True if the character was accepted, otherwise must retry</returns>
    public virtual bool Push(int c) {
        int ct = ((c >= 0) & (c < CharacterMappings.Length)) ? CharacterMappings[c] : 0;

        if (Trace) {
            Debug.WriteLine("  {0} {1}:{3} {2}", StateInt, c, ct, (char)c);
            }

        NextState = CompressedTransitions[StateInt, ct];

        if (NextState >= 0) {
            ActionDelegate Action = Actions[NextState];
            Action(c);
            StateInt = NextState;
            return true;
            }

        StateInt = 0;
        return false;
        }

    /// <summary>
    /// Process a string of text, a character at a time.
    /// </summary>
    /// <param name="Text">Text to process</param>
    public virtual void Push(string Text) {
        foreach (var c in Text) {
            var Accepted = Push(c);
            if (!Accepted) {
                StateInt = 0;
                Actions[0](-1); // call the reset
                Push(c);
                }
            }
        }

    /// <summary>
    /// Called at the start of a Push parser session. May be overriden in subclasses to 
    /// initialize output.
    /// </summary>
    public virtual void PushStart() {
        StateInt = 0;
        Actions[0](-1); // call the reset
        }

    /// <summary>
    /// Called at the end of a Push parser session. May be overriden in subclasses to 
    /// flush output.
    /// </summary>
    /// <param name="Text">Text to push into the parser.</param>
    public virtual void PushEnd(string Text = null) {
        if (Text != null) {
            Push(Text);
            }
        }



    /// <summary>
    /// FSR action
    /// </summary>
    /// <param name="c">Character that was read to cause the transition.</param>
    public delegate void ActionDelegate(int c);

    /// <summary>
    /// Initialization method called when Lexer is created.
    /// </summary>
    public abstract void Init();



    /// <summary>
    /// Create new instance for the specified reader.
    /// </summary>
    /// <param name="Reader">Input data</param>
    public Lexer(LexReader Reader) : this() => this.Reader = Reader;

    /// <summary>
    /// Create new instance for the specified reader.
    /// </summary>
    public Lexer() => Init();

    /// <summary>
    /// Reset method. Is called at the start of each
    /// call to GetTokenInt.
    /// </summary>
    public virtual void Reset() {
        }


    /// <summary>
    /// The class specific disposal routine.
    /// </summary>
    protected override void Disposing() {
        Reader?.Dispose();
        Reader = null;
        }

    }
