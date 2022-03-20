
//  This file was automatically generated at 19-Mar-22 2:58:11 PM
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


// Goedel.Cryptography.KeyFile
namespace Goedel.Cryptography.KeyFile;


// Prototypes for the actions. These must be implemented in 
// the plus class

/*
public partial class KeyFileLex {
    public virtual void Reset (int c) {
		}
    public virtual void Count1 (int c) {
		}
    public virtual void Begin (int c) {
		}
    public virtual void Tag1 (int c) {
		}
    public virtual void Count2 (int c) {
		}
    public virtual void Base64 (int c) {
		}
    public virtual void StartHeader (int c) {
		}
    public virtual void HeaderAdd (int c) {
		}
    public virtual void CopyHeader (int c) {
		}
    public virtual void Count3 (int c) {
		}
    public virtual void End (int c) {
		}
    public virtual void Tag2 (int c) {
		}
    public virtual void Count4 (int c) {
		}
    public virtual void AddTag (int c) {
		}
    public virtual void Abort (int c) {
		}
	}
*/

public partial class KeyFileLex : global::Goedel.FSR.Lexer {
    /// <summary>
    /// Create and initialize a lexical analyzer.
    /// </summary>
    /// <param name="Reader">The input source.</param>
    public  KeyFileLex(LexReader Reader) : base (Reader) {
        }

    /// <summary>
    /// Create and initialize a lexical analyzer.
    /// </summary>
    /// <param name="Stream">The input source.</param>
    public  KeyFileLex(Stream Stream) : base(new LexReader(Stream)) {
        }

    /// <summary>
    /// Create and initialize a lexical analyzer.
    /// </summary>
    /// <param name="TextReader">The input source.</param>
    public  KeyFileLex(TextReader TextReader) : base(new LexReader(TextReader)) {
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
		/// <summary>FileStart</summary>
        FileStart = 0,
		/// <summary>ArmorStart1</summary>
        ArmorStart1 = 1,
		/// <summary>TagStartBegin</summary>
        TagStartBegin = 2,
		/// <summary>TagStart</summary>
        TagStart = 3,
		/// <summary>ArmorStart2</summary>
        ArmorStart2 = 4,
		/// <summary>Base64Data</summary>
        Base64Data = 5,
		/// <summary>IsHeader</summary>
        IsHeader = 6,
		/// <summary>HeaderData</summary>
        HeaderData = 7,
		/// <summary>HeaderEnd</summary>
        HeaderEnd = 8,
		/// <summary>ArmorEnd1</summary>
        ArmorEnd1 = 9,
		/// <summary>TagEndEnd</summary>
        TagEndEnd = 10,
		/// <summary>TagEnd</summary>
        TagEnd = 11,
		/// <summary>ArmorEnd2</summary>
        ArmorEnd2 = 12,
		/// <summary>StartTag</summary>
        StartTag = 13,
		/// <summary>Fail</summary>
        Fail = 14
		};

	/// <summary>Token Types</summary>
	public enum Token {
		/// <summary>Could not find a valid token.</summary>
		INVALID = -1,
		/// <summary>Empty</summary>
        Empty = 0,
		/// <summary>Tag</summary>
        Tag = 1,
		/// <summary>Armor</summary>
        Armor = 2,
		/// <summary>Data</summary>
        Data = 3
		};


	/// <summary>Mapping of characters to character groups</summary>
	readonly static byte [] Character_Mapping   =  new byte [] {
		0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 2 , 0 , 0 , 0 , 0 , 0 , 
		0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 
		3 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 0 , 4 , 0 , 1 , 
		5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 6 , 0 , 0 , 1 , 0 , 0 , 
		0 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 
		5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 0 , 0 , 0 , 0 , 0 , 
		0 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 
		5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 0 , 0 , 0 , 0 , 0 };

	readonly static short [,]  Compressed_Transitions  = new short [,]  {
		{-2 , -2 , 14 , -2 , 1 , -2 , -2 },
		{-2 , -2 , -2 , 2 , 1 , 2 , -2 },
		{-2 , -2 , -2 , 3 , -2 , 2 , -2 },
		{-2 , -2 , -2 , 3 , 4 , 3 , -2 },
		{-2 , -2 , 5 , -2 , 4 , -2 , -2 },
		{-2 , 5 , 5 , 5 , 9 , 5 , 6 },
		{7 , 7 , 8 , 7 , 7 , 7 , 7 },
		{7 , 7 , 8 , 7 , 7 , 7 , 7 },
		{-2 , 5 , 5 , 5 , 9 , 5 , 6 },
		{-2 , -2 , -2 , 10 , 9 , 10 , -2 },
		{-2 , -2 , -2 , 11 , -2 , 10 , -2 },
		{-2 , -2 , -2 , 11 , 12 , 11 , -2 },
		{-2 , -2 , 5 , -2 , 12 , -2 , -2 },
		{-2 , -2 , -2 , -2 , -2 , -2 , -2 },
		{-2 , -2 , -2 , -2 , -2 , -2 , -2 }
	};


	readonly static Token [] Tokens = new Token [] {
		Token.Empty,
		Token.Armor,
		Token.Armor,
		Token.Data,
		Token.Tag,
		Token.Data,
		Token.Data,
		Token.Data,
		Token.Data,
		Token.Data,
		Token.Armor,
		Token.Data,
		Token.Data,
		Token.Tag,
		Token.Empty
		};

	/// <summary>Generated initialization method, is called automatically 
	/// the FSR to reset </summary>
    public override void Init () =>
        Actions = new ActionDelegate[] {
			Reset,
			Count1,
			Begin,
			Tag1,
			Count2,
			Base64,
			StartHeader,
			HeaderAdd,
			CopyHeader,
			Count3,
			End,
			Tag2,
			Count4,
			AddTag,
			Abort
		};
	}


