﻿
//  This file was automatically generated at 03-May-22 4:53:00 PM
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
public partial class CommandLex {
    public virtual void Reset (int c) {
		}
    public virtual void AddValue (int c) {
		}
    public virtual void Ignore (int c) {
		}
    public virtual void AddFlag (int c) {
		}
    public virtual void AddFlagN (int c) {
		}
    public virtual void AddFlagNo (int c) {
		}
    public virtual void Abort (int c) {
		}
	}
*/

public partial class CommandLex : global::Goedel.FSR.Lexer {
    /// <summary>
    /// Create and initialize a lexical analyzer.
    /// </summary>
    /// <param name="Reader">The input source.</param>
    public  CommandLex(LexReader Reader) : base (Reader) {
        }

    /// <summary>
    /// Create and initialize a lexical analyzer.
    /// </summary>
    /// <param name="Stream">The input source.</param>
    public  CommandLex(Stream Stream) : base(new LexReader(Stream)) {
        }

    /// <summary>
    /// Create and initialize a lexical analyzer.
    /// </summary>
    /// <param name="TextReader">The input source.</param>
    public  CommandLex(TextReader TextReader) : base(new LexReader(TextReader)) {
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
		/// <summary>IsValue</summary>
        IsValue = 1,
		/// <summary>StartFlag</summary>
        StartFlag = 2,
		/// <summary>IsFlag</summary>
        IsFlag = 3,
		/// <summary>IsFlagN</summary>
        IsFlagN = 4,
		/// <summary>IsFlagNo</summary>
        IsFlagNo = 5,
		/// <summary>StartFlagValue</summary>
        StartFlagValue = 6,
		/// <summary>IsFlagValue</summary>
        IsFlagValue = 7,
		/// <summary>Fail</summary>
        Fail = 8
		};

	/// <summary>Token Types</summary>
	public enum Token {
		/// <summary>Could not find a valid token.</summary>
		INVALID = -1,
		/// <summary>Empty</summary>
        Empty = 0,
		/// <summary>Value</summary>
        Value = 1,
		/// <summary>Flag</summary>
        Flag = 2,
		/// <summary>FlagValue</summary>
        FlagValue = 3
		};


	/// <summary>Mapping of characters to character groups</summary>
	readonly static byte [] Character_Mapping   =  new byte [] {
		0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 1 , 0 , 0 , 0 , 0 , 0 , 
		0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 
		1 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 2 , 0 , 2 , 
		0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 3 , 0 , 0 , 3 , 0 , 0 , 
		0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 4 , 5 , 
		0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 
		0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 4 , 5 , 
		0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 };

	readonly static short [,]  Compressed_Transitions  = new short [,]  {
		{1 , 8 , 2 , 1 , 1 , 1 },
		{1 , 1 , 1 , 1 , 1 , 1 },
		{3 , 3 , 3 , 3 , 4 , 3 },
		{3 , 3 , 3 , 6 , 3 , 3 },
		{3 , 3 , 3 , 6 , 3 , 5 },
		{3 , 3 , 3 , 6 , 3 , 3 },
		{7 , 7 , 7 , 7 , 7 , 7 },
		{7 , 7 , 7 , 7 , 7 , 7 },
		{-2 , -2 , -2 , -2 , -2 , -2 }
	};


	readonly static Token [] Tokens = new Token [] {
		Token.Empty,
		Token.Value,
		Token.Flag,
		Token.Flag,
		Token.Flag,
		Token.Flag,
		Token.FlagValue,
		Token.FlagValue,
		Token.Empty
		};

	/// <summary>Generated initialization method, is called automatically 
	/// the FSR to reset </summary>
    public override void Init () =>
        Actions = new ActionDelegate[] {
			Reset,
			AddValue,
			Ignore,
			AddFlag,
			AddFlagN,
			AddFlagNo,
			Ignore,
			AddValue,
			Abort
		};
	}


