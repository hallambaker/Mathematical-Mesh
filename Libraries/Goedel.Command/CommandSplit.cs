
//  This file was automatically generated at 19-Dec-22 10:55:52 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  fsrgen version 3.0.0.865
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2021
//  
//  Build Platform: Win32NT 10.0.19042.0
//  
//  
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Goedel.FSR;


// Goedel.Command
namespace Goedel.Command;


// Prototypes for the actions. These must be implemented in 
// the plus class

/*
public partial class CommandSplitLex {
    public virtual void AddParam (int c) {
		}
    public virtual void BeginValue (int c) {
		}
    public virtual void AddValue (int c) {
		}
    public virtual void Ignore (int c) {
		}
    public virtual void AddEscape (int c) {
		}
    public virtual void AddEscapedValue (int c) {
		}
	}
*/

public partial class CommandSplitLex : global::Goedel.FSR.Lexer {
    /// <summary>
    /// Create and initialize a lexical analyzer.
    /// </summary>
    /// <param name="Reader">The input source.</param>
    public  CommandSplitLex(LexReader Reader) : base (Reader) {
        }

    /// <summary>
    /// Create and initialize a lexical analyzer.
    /// </summary>
    /// <param name="Stream">The input source.</param>
    public  CommandSplitLex(Stream Stream) : base(new LexReader(Stream)) {
        }

    /// <summary>
    /// Create and initialize a lexical analyzer.
    /// </summary>
    /// <param name="TextReader">The input source.</param>
    public  CommandSplitLex(TextReader TextReader) : base(new LexReader(TextReader)) {
        }

    /// <summary>
    /// Maps characters to character sets
    /// </summary>
    public override byte[] CharacterMappings  => Character_Mapping; 

    /// <summary>
    /// State transitions in response to character set
    /// </summary>
    public override short[,] CompressedTransitions  => Compressed_Transitions; 

    /// <summary>
    /// Get the next token from the stream
    /// </summary>
    /// <param name="StartState">The initial starting state</param>
    /// <returns>The token detected or -1 if an error occurred</returns>
    public Token GetToken(State StartState) => Tokens [GetTokenInt((int)StartState)];


    /// <summary>
    /// Get the next token from the stream
    /// </summary>
    /// <returns>The token detected or -1 if an error occurred</returns>
    public Token GetToken () => GetToken (0);

	/// <summary>State types</summary>
	public enum State {
		/// <summary>ItemStart</summary>
        ItemStart = 0,
		/// <summary>StartQuoted</summary>
        StartQuoted = 1,
		/// <summary>Quoted</summary>
        Quoted = 2,
		/// <summary>QuotedQuote</summary>
        QuotedQuote = 3,
		/// <summary>QuotedEscape</summary>
        QuotedEscape = 4,
		/// <summary>QuotedEscapeReturn</summary>
        QuotedEscapeReturn = 5,
		/// <summary>Unquoted</summary>
        Unquoted = 6,
		/// <summary>UnquotedQuote</summary>
        UnquotedQuote = 7,
		/// <summary>UnquotedEscape</summary>
        UnquotedEscape = 8,
		/// <summary>UnquotedEscapeReturn</summary>
        UnquotedEscapeReturn = 9
		};

	/// <summary>Token Types</summary>
	public enum Token {
		/// <summary>Could not find a valid token.</summary>
		INVALID = -1,
		/// <summary>Empty</summary>
        Empty = 0,
		/// <summary>Value</summary>
        Value = 1
		};


	/// <summary>Mapping of characters to character groups</summary>
	readonly static byte [] Character_Mapping   =  new byte [] {
		0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 1 , 0 , 0 , 0 , 0 , 0 , 
		0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 
		1 , 0 , 2 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 
		0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 
		0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 
		0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 3 , 0 , 0 , 0 , 
		0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 
		0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 };

	readonly static short [,]  Compressed_Transitions  = new short [,]  {
		{6 , 0 , 1 , 8 },
		{2 , 2 , 3 , 4 },
		{2 , 2 , 3 , 4 },
		{2 , 0 , 2 , 4 },
		{5 , 5 , 5 , 4 },
		{2 , 2 , 3 , 4 },
		{6 , 0 , 7 , 8 },
		{6 , 0 , 7 , 8 },
		{9 , 0 , 9 , 8 },
		{6 , 6 , 7 , 8 }
	};


	readonly static Token [] Tokens = new Token [] {
		Token.Empty,
		Token.Value,
		Token.Value,
		Token.Value,
		Token.Value,
		Token.Value,
		Token.Value,
		Token.Value,
		Token.Value,
		Token.Value
		};

	/// <summary>Generated initialization method, is called automatically 
	/// the FSR to reset </summary>
    public override void Init () =>
        Actions = new ActionDelegate[] {
			AddParam,
			BeginValue,
			AddValue,
			Ignore,
			AddEscape,
			AddEscapedValue,
			AddValue,
			Ignore,
			AddEscape,
			AddEscapedValue
		};
	}


