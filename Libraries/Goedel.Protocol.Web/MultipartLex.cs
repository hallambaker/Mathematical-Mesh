
//  This file was automatically generated at 10/15/2024 6:53:51 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  fsrgen version 3.0.0.865
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2021
//  
//  Build Platform: Win32NT 10.0.22631.0
//  
//  
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Goedel.FSR;


// Goedel.Protocol.Web
namespace Goedel.Protocol.Web;


// Prototypes for the actions. These must be implemented in 
// the plus class

/*
public partial class MultipartLex {
    public virtual void Reset (int c) {
		}
    public virtual void AddTag (int c) {
		}
    public virtual void GotTag (int c) {
		}
    public virtual void Ignore (int c) {
		}
    public virtual void AddValue (int c) {
		}
    public virtual void GotValue (int c) {
		}
    public virtual void AddParameter (int c) {
		}
    public virtual void GotParameter (int c) {
		}
    public virtual void AddPValue (int c) {
		}
    public virtual void GotPValue (int c) {
		}
    public virtual void End (int c) {
		}
    public virtual void Abort (int c) {
		}
	}
*/

public partial class MultipartLex : global::Goedel.FSR.Lexer {
    /// <summary>
    /// Create and initialize a lexical analyzer.
    /// </summary>
    /// <param name="Reader">The input source.</param>
    public  MultipartLex(LexReader Reader) : base (Reader) {
        }

    /// <summary>
    /// Create and initialize a lexical analyzer.
    /// </summary>
    /// <param name="Stream">The input source.</param>
    public  MultipartLex(Stream Stream) : base(new LexReader(Stream)) {
        }

    /// <summary>
    /// Create and initialize a lexical analyzer.
    /// </summary>
    /// <param name="TextReader">The input source.</param>
    public  MultipartLex(TextReader TextReader) : base(new LexReader(TextReader)) {
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
		/// <summary>Tag</summary>
        Tag = 1,
		/// <summary>TagColon</summary>
        TagColon = 2,
		/// <summary>TagWS</summary>
        TagWS = 3,
		/// <summary>Value</summary>
        Value = 4,
		/// <summary>ValueSemi</summary>
        ValueSemi = 5,
		/// <summary>ParameterWS</summary>
        ParameterWS = 6,
		/// <summary>Parameter</summary>
        Parameter = 7,
		/// <summary>PValueStart</summary>
        PValueStart = 8,
		/// <summary>PValueQuote</summary>
        PValueQuote = 9,
		/// <summary>PValue</summary>
        PValue = 10,
		/// <summary>PValueComplete</summary>
        PValueComplete = 11,
		/// <summary>Complete</summary>
        Complete = 12,
		/// <summary>Fail</summary>
        Fail = 13
		};

	/// <summary>Token Types</summary>
	public enum Token {
		/// <summary>Could not find a valid token.</summary>
		INVALID = -1,
		/// <summary>Error</summary>
        Error = 0,
		/// <summary>Empty</summary>
        Empty = 1,
		/// <summary>Header</summary>
        Header = 2
		};


	/// <summary>Mapping of characters to character groups</summary>
	readonly static byte [] Character_Mapping   =  new byte [] {
		0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 0 , 0 , 0 , 0 , 0 , 0 , 
		0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 
		1 , 0 , 2 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 3 , 0 , 0 , 
		4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 5 , 6 , 0 , 7 , 0 , 0 , 
		0 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 
		4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 0 , 0 , 0 , 0 , 0 , 
		0 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 
		4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 0 , 0 , 0 , 0 , 0 };

	readonly static short [,]  Compressed_Transitions  = new short [,]  {
		{-2 , -2 , -2 , -2 , 1 , -2 , -2 , -2 },
		{-2 , -2 , -2 , 1 , 1 , 2 , -2 , -2 },
		{-2 , 3 , -2 , -2 , -2 , -2 , -2 , -2 },
		{4 , 3 , 4 , 4 , 4 , 4 , 4 , 4 },
		{4 , 4 , 4 , 4 , 4 , 4 , 5 , 4 },
		{-2 , 6 , -2 , 7 , 7 , -2 , -2 , -2 },
		{-2 , 6 , -2 , 7 , 7 , -2 , -2 , -2 },
		{-2 , -2 , -2 , 7 , 7 , -2 , -2 , 8 },
		{-2 , -2 , 9 , -2 , -2 , -2 , -2 , -2 },
		{10 , 10 , 11 , 10 , 10 , 10 , 10 , 10 },
		{10 , 10 , 11 , 10 , 10 , 10 , 10 , 10 },
		{-2 , -2 , -2 , -2 , -2 , -2 , 6 , -2 },
		{-2 , -2 , -2 , -2 , -2 , -2 , -2 , -2 },
		{-2 , -2 , -2 , -2 , -2 , -2 , -2 , -2 }
	};


	readonly static Token [] Tokens = new Token [] {
		Token.Error,
		Token.Empty,
		Token.Header,
		Token.Header,
		Token.Header,
		Token.Empty,
		Token.Empty,
		Token.Empty,
		Token.Empty,
		Token.Empty,
		Token.Header,
		Token.Header,
		Token.Header,
		Token.Error
		};

	/// <summary>Generated initialization method, is called automatically 
	/// the FSR to reset </summary>
    public override void Init () =>
        Actions = new ActionDelegate[] {
			Reset,
			AddTag,
			GotTag,
			Ignore,
			AddValue,
			GotValue,
			Ignore,
			AddParameter,
			GotParameter,
			Ignore,
			AddPValue,
			GotPValue,
			End,
			Abort
		};
	}


