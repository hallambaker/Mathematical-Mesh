
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Goedel.FSR;


// Goedel.Cryptography.KeyFile
namespace Goedel.Cryptography.KeyFile{


	// Prototypes for the actions. These must be implemented in 
	// the plus class

	/*
	public partial class KeyFileLex {
        public virtual void Reset (char c) {
			}
        public virtual void Count1 (char c) {
			}
        public virtual void Begin (char c) {
			}
        public virtual void Tag1 (char c) {
			}
        public virtual void Count2 (char c) {
			}
        public virtual void Base64 (char c) {
			}
        public virtual void Count3 (char c) {
			}
        public virtual void End (char c) {
			}
        public virtual void Tag2 (char c) {
			}
        public virtual void Count4 (char c) {
			}
        public virtual void AddTag (char c) {
			}
        public virtual void Abort (char c) {
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
        public override byte[] CharacterMappings { get { return Character_Mapping; }  }

        /// <summary>
        /// State transitions in response to character set
        /// </summary>
        public override short[,] CompressedTransitions { get { return Compressed_Transitions; } }

        /// <summary>
        /// Get the next token from the stream
        /// </summary>
        /// <param name="StartState">The initial starting state</param>
        /// <returns>The token detected or -1 if an error occurred</returns>
        public Token GetToken(State StartState) {
            return Tokens [GetTokenInt((int)StartState)];
            }

        /// <summary>
        /// Get the next token from the stream
        /// </summary>
        /// <returns>The token detected or -1 if an error occurred</returns>
        public Token GetToken () {
            return GetToken (0);
            }

		public enum State {
            FileStart = 0,
            ArmorStart1 = 1,
            TagStartBegin = 2,
            TagStart = 3,
            ArmorStart2 = 4,
            Base64Data = 5,
            ArmorEnd1 = 6,
            TagEndEnd = 7,
            TagEnd = 8,
            ArmorEnd2 = 9,
            StartTag = 10,
            Fail = 11
			};

		public enum Token {
			INVALID = -1,
            Empty = 0,
            Tag = 1,
            Armor = 2,
            Data = 3
			};



		//#define Goedel.Cryptography.KeyFile_Action__Count  12
		//#define Goedel.Cryptography.KeyFile_Token__Count  4
		//#define Goedel.Cryptography.KeyFile_State__Count  12


		static byte [] Character_Mapping   =  new byte [] {
			0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 2 , 0 , 0 , 0 , 0 , 0 , 
			0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 
			3 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 0 , 4 , 0 , 1 , 
			5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 0 , 0 , 0 , 1 , 0 , 0 , 
			0 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 
			5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 0 , 0 , 0 , 0 , 0 , 
			0 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 
			5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 5 , 0 , 0 , 0 , 0 , 0   };

		static short [,]  Compressed_Transitions  = new short [,]  {
			{-2 , -2 , 11 , -2 , 1 , -2 },
			{-2 , -2 , -2 , 3 , 1 , 2 },
			{-2 , -2 , -2 , 3 , -2 , 2 },
			{-2 , -2 , -2 , 3 , 4 , 3 },
			{-2 , -2 , 5 , -2 , 4 , -2 },
			{-2 , 5 , 5 , 5 , 6 , 5 },
			{-2 , -2 , -2 , 8 , 6 , 7 },
			{-2 , -2 , -2 , 8 , -2 , 7 },
			{-2 , -2 , -2 , 8 , 9 , 8 },
			{-2 , -2 , 5 , -2 , 9 , -2 },
			{-2 , -2 , -2 , -2 , -2 , -2 },
			{-2 , -2 , -2 , -2 , -2 , -2 }
		};


		static Token [] Tokens = new Token [] {
			Token.Empty,
			Token.Armor,
			Token.Armor,
			Token.Data,
			Token.Tag,
			Token.Data,
			Token.Data,
			Token.Armor,
			Token.Data,
			Token.Data,
			Token.Tag,
			Token.Empty
			};

        public override void Init () {
            Actions = new Action[] {
				Reset,
				Count1,
				Begin,
				Tag1,
				Count2,
				Base64,
				Count3,
				End,
				Tag2,
				Count4,
				AddTag,
				Abort
				};
			}
		}
	}

