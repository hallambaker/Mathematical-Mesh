
//  This file was automatically generated at 3/5/2024 5:00:54 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  fsrgen version 3.0.0.865
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2021
//  
//  Build Platform: Win32NT 10.0.22621.0
//  
//  
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Goedel.FSR;


// Goedel.Cryptography.KeyFile
namespace Goedel.Cryptography.KeyFile;


// Prototypes for the actions. These must be implemented in 
// the plus class

/*
public partial class AuthKeysFileLex {
    public virtual void Ignore (int c) {
		}
    public virtual void AddAlgorithm (int c) {
		}
    public virtual void AddData (int c) {
		}
    public virtual void AddComment (int c) {
		}
	}
*/

public partial class AuthKeysFileLex : global::Goedel.FSR.Lexer {
    /// <summary>
    /// Create and initialize a lexical analyzer.
    /// </summary>
    /// <param name="Reader">The input source.</param>
    public  AuthKeysFileLex(LexReader Reader) : base (Reader) {
        }

    /// <summary>
    /// Create and initialize a lexical analyzer.
    /// </summary>
    /// <param name="Stream">The input source.</param>
    public  AuthKeysFileLex(Stream Stream) : base(new LexReader(Stream)) {
        }

    /// <summary>
    /// Create and initialize a lexical analyzer.
    /// </summary>
    /// <param name="TextReader">The input source.</param>
    public  AuthKeysFileLex(TextReader TextReader) : base(new LexReader(TextReader)) {
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
		/// <summary>LineStart</summary>
        LineStart = 0,
		/// <summary>AlgRead</summary>
        AlgRead = 1,
		/// <summary>AlgSpace</summary>
        AlgSpace = 2,
		/// <summary>DataRead</summary>
        DataRead = 3,
		/// <summary>CommentSpace</summary>
        CommentSpace = 4,
		/// <summary>Comment</summary>
        Comment = 5,
		/// <summary>Finished</summary>
        Finished = 6
		};

	/// <summary>Token Types</summary>
	public enum Token {
		/// <summary>Could not find a valid token.</summary>
		INVALID = -1,
		/// <summary>Empty</summary>
        Empty = 0,
		/// <summary>Data</summary>
        Data = 1,
		/// <summary>Algorithm</summary>
        Algorithm = 2
		};


	/// <summary>Mapping of characters to character groups</summary>
	readonly static byte [] Character_Mapping   =  new byte [] {
		0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 0 , 0 , 0 , 0 , 0 , 
		0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 
		2 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 3 , 0 , 4 , 0 , 3 , 
		4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 0 , 0 , 0 , 5 , 0 , 0 , 
		0 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 
		4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 0 , 0 , 0 , 0 , 3 , 
		0 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 
		4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 0 , 0 , 0 , 0 , 0 };

	readonly static short [,]  Compressed_Transitions  = new short [,]  {
		{-2 , 0 , -2 , -2 , 1 , -2 },
		{-2 , -2 , 2 , -2 , 1 , -2 },
		{-2 , -2 , 2 , 3 , 3 , -2 },
		{-2 , 6 , 4 , 3 , 3 , 3 },
		{5 , 6 , 4 , 5 , 5 , 5 },
		{5 , 6 , 5 , 5 , 5 , 5 },
		{-2 , -2 , -2 , -2 , -2 , -2 }
	};


	readonly static Token [] Tokens = new Token [] {
		Token.Empty,
		Token.Algorithm,
		Token.Algorithm,
		Token.Data,
		Token.Data,
		Token.Data,
		Token.Data
		};

	/// <summary>Generated initialization method, is called automatically 
	/// the FSR to reset </summary>
    public override void Init () =>
        Actions = new ActionDelegate[] {
			Ignore,
			AddAlgorithm,
			Ignore,
			AddData,
			Ignore,
			AddComment,
			Ignore
		};
	}


