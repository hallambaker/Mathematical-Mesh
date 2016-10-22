
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
	public partial class AuthKeysFileLex {
        public virtual void Ignore (char c) {
			}
        public virtual void AddAlgorithm (char c) {
			}
        public virtual void AddData (char c) {
			}
        public virtual void AddComment (char c) {
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
            LineStart = 0,
            AlgRead = 1,
            AlgSpace = 2,
            DataRead = 3,
            CommentSpace = 4,
            Comment = 5,
            Finished = 6
			};

		public enum Token {
			INVALID = -1,
            Empty = 0,
            Data = 1,
            Algorithm = 2
			};



		//#define Goedel.Cryptography.KeyFile_Action__Count  4
		//#define Goedel.Cryptography.KeyFile_Token__Count  3
		//#define Goedel.Cryptography.KeyFile_State__Count  7


		static byte [] Character_Mapping   =  new byte [] {
			0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 0 , 0 , 0 , 0 , 0 , 
			0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 
			2 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 3 , 0 , 4 , 0 , 3 , 
			4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 0 , 0 , 0 , 5 , 0 , 0 , 
			0 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 
			4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 0 , 0 , 0 , 0 , 3 , 
			0 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 
			4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 4 , 0 , 0 , 0 , 0 , 0   };

		static short [,]  Compressed_Transitions  = new short [,]  {
			{-2 , 0 , -2 , -2 , 1 , -2 },
			{-2 , -2 , 2 , -2 , 1 , -2 },
			{-2 , -2 , 2 , 3 , 3 , -2 },
			{-2 , 6 , 4 , 3 , 3 , 3 },
			{5 , 6 , 4 , 5 , 5 , 5 },
			{5 , 6 , 5 , 5 , 5 , 5 },
			{-2 , -2 , -2 , -2 , -2 , -2 }
		};


		static Token [] Tokens = new Token [] {
			Token.Empty,
			Token.Algorithm,
			Token.Algorithm,
			Token.Data,
			Token.Data,
			Token.Data,
			Token.Data
			};

        public override void Init () {
            Actions = new Action[] {
				Ignore,
				AddAlgorithm,
				Ignore,
				AddData,
				Ignore,
				AddComment,
				Ignore
				};
			}
		}
	}

