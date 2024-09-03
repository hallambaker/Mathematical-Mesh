
//  This file was automatically generated at 9/3/2024 1:25:55 PM
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


// Goedel.Discovery
namespace Goedel.Discovery;


// Prototypes for the actions. These must be implemented in 
// the plus class

/*
public partial class ServiceAddressSplitLex {
    public virtual void Start (int c) {
		}
    public virtual void AddToken (int c) {
		}
    public virtual void IsAt (int c) {
		}
    public virtual void Terminal (int c) {
		}
	}
*/

public partial class ServiceAddressSplitLex : global::Goedel.FSR.Lexer {
    /// <summary>
    /// Create and initialize a lexical analyzer.
    /// </summary>
    /// <param name="Reader">The input source.</param>
    public  ServiceAddressSplitLex(LexReader Reader) : base (Reader) {
        }

    /// <summary>
    /// Create and initialize a lexical analyzer.
    /// </summary>
    /// <param name="Stream">The input source.</param>
    public  ServiceAddressSplitLex(Stream Stream) : base(new LexReader(Stream)) {
        }

    /// <summary>
    /// Create and initialize a lexical analyzer.
    /// </summary>
    /// <param name="TextReader">The input source.</param>
    public  ServiceAddressSplitLex(TextReader TextReader) : base(new LexReader(TextReader)) {
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
		/// <summary>ReadNumeric</summary>
        ReadNumeric = 1,
		/// <summary>ReadHex</summary>
        ReadHex = 2,
		/// <summary>ReadLabel</summary>
        ReadLabel = 3,
		/// <summary>GotAt</summary>
        GotAt = 4,
		/// <summary>GotDot</summary>
        GotDot = 5,
		/// <summary>GotColon</summary>
        GotColon = 6,
		/// <summary>GotLeft</summary>
        GotLeft = 7,
		/// <summary>GotRight</summary>
        GotRight = 8
		};

	/// <summary>Token Types</summary>
	public enum Token {
		/// <summary>Could not find a valid token.</summary>
		INVALID = -1,
		/// <summary>Numeric</summary>
        Numeric = 0,
		/// <summary>Hexadecimal</summary>
        Hexadecimal = 1,
		/// <summary>Label</summary>
        Label = 2,
		/// <summary>Mesh</summary>
        Mesh = 3,
		/// <summary>At</summary>
        At = 4,
		/// <summary>Dot</summary>
        Dot = 5,
		/// <summary>Colon</summary>
        Colon = 6,
		/// <summary>Left</summary>
        Left = 7,
		/// <summary>Right</summary>
        Right = 8,
		/// <summary>NYI</summary>
        NYI = 9,
		/// <summary>Empty</summary>
        Empty = 10
		};


	/// <summary>Mapping of characters to character groups</summary>
	readonly static byte [] Character_Mapping   =  new byte [] {
		0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 
		0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 
		0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 0 , 
		2 , 2 , 2 , 2 , 2 , 2 , 2 , 2 , 2 , 2 , 3 , 0 , 0 , 0 , 0 , 0 , 
		4 , 5 , 5 , 5 , 5 , 5 , 5 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 
		0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 6 , 0 , 7 , 0 , 0 , 
		0 , 5 , 5 , 5 , 5 , 5 , 5 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 
		0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 };

	readonly static short [,]  Compressed_Transitions  = new short [,]  {
		{3 , 5 , 1 , 6 , 4 , 2 , 7 , 8 },
		{3 , -1 , 1 , -1 , -1 , 2 , -1 , -1 },
		{3 , -1 , 3 , -1 , -1 , 2 , -1 , -1 },
		{3 , -1 , 3 , -1 , -1 , 3 , -1 , -1 },
		{-1 , -1 , -1 , -1 , -1 , -1 , -1 , -1 },
		{-1 , -1 , -1 , -1 , -1 , -1 , -1 , -1 },
		{-1 , -1 , -1 , -1 , -1 , -1 , -1 , -1 },
		{-1 , -1 , -1 , -1 , -1 , -1 , -1 , -1 },
		{-1 , -1 , -1 , -1 , -1 , -1 , -1 , -1 }
	};


	readonly static Token [] Tokens = new Token [] {
		Token.Empty,
		Token.Numeric,
		Token.Hexadecimal,
		Token.Label,
		Token.At,
		Token.Dot,
		Token.Colon,
		Token.Left,
		Token.Right
		};

	/// <summary>Generated initialization method, is called automatically 
	/// the FSR to reset </summary>
    public override void Init () =>
        Actions = new ActionDelegate[] {
			Start,
			AddToken,
			AddToken,
			AddToken,
			IsAt,
			Terminal,
			Terminal,
			Terminal,
			Terminal
		};
	}


