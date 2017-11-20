using System;
using Goedel.Utilities;



namespace Goedel.Registry {


    /// <summary>
    /// The user command could not be parsed
    /// </summary>
    public class ParserException : global::System.Exception {

		/// <summary>
        /// Construct instance for exception "The user command could not be parsed"
        /// </summary>		
		public ParserException () : base ("The user command could not be parsed") {
			}
        
		/// <summary>
        /// Construct instance for exception "The user command could not be parsed"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public ParserException (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public ParserException (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}

		/// <summary>
        /// User data associated with the exception.
        /// </summary>	
		public object UserData;



		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new ParserException(Reason as string);
				}
			else {
				return new ParserException();
				}
            }
        }


    /// <summary>
    /// The file could not be read.
    /// </summary>
    public class FileReadError : ParserException {

		/// <summary>
        /// Construct instance for exception "The file could not be read"
        /// </summary>		
		public FileReadError () : base ("The file could not be read") {
			}
        
		/// <summary>
        /// Construct instance for exception "The file could not be read"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public FileReadError (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public FileReadError (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}


		/// <summary>
        /// Construct instance for exception using a userdata parameter of
		/// type ExceptionData and the format string "The file {0} could not be read"
        /// </summary>		
        /// <param name="Object">User data</param>	
		public FileReadError (ExceptionData Object) : 
				base (global::System.String.Format ("The file {0} could not be read",
					Object.String					)) {
			UserData = Object;
			}

		/// <summary>
        /// Construct instance for exception using a userdata parameter of
		/// type ExceptionData and the format string "The file {0} could not be read"
        /// </summary>		
        /// <param name="Object">User data</param>	
		/// <param name="Inner">Inner Exception</param>	
		public FileReadError (ExceptionData Object, System.Exception Inner) : 
				base (global::System.String.Format ("The file {0} could not be read",
					Object.String					), Inner) {
			UserData = Object;
			}



		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new FileReadError(Reason as string);
				}
			else if (Reason as ExceptionData != null) {
				return new FileReadError(Reason as ExceptionData);
				}
			else {
				return new FileReadError();
				}
            }
        }


    /// <summary>
    /// User entered an unknown command
    /// </summary>
    public class UnknownCommand : ParserException {

		/// <summary>
        /// Construct instance for exception "Unknown command"
        /// </summary>		
		public UnknownCommand () : base ("Unknown command") {
			}
        
		/// <summary>
        /// Construct instance for exception "Unknown command"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public UnknownCommand (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public UnknownCommand (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}


		/// <summary>
        /// Construct instance for exception using a userdata parameter of
		/// type ExceptionData and the format string "The command {0} is not known."
        /// </summary>		
        /// <param name="Object">User data</param>	
		public UnknownCommand (ExceptionData Object) : 
				base (global::System.String.Format ("The command {0} is not known.",
					Object.String					)) {
			UserData = Object;
			}

		/// <summary>
        /// Construct instance for exception using a userdata parameter of
		/// type ExceptionData and the format string "The command {0} is not known."
        /// </summary>		
        /// <param name="Object">User data</param>	
		/// <param name="Inner">Inner Exception</param>	
		public UnknownCommand (ExceptionData Object, System.Exception Inner) : 
				base (global::System.String.Format ("The command {0} is not known.",
					Object.String					), Inner) {
			UserData = Object;
			}



		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new UnknownCommand(Reason as string);
				}
			else if (Reason as ExceptionData != null) {
				return new UnknownCommand(Reason as ExceptionData);
				}
			else {
				return new UnknownCommand();
				}
            }
        }


    /// <summary>
    /// User entered an unknown option
    /// </summary>
    public class UnknownOption : ParserException {

		/// <summary>
        /// Construct instance for exception "Unknown option"
        /// </summary>		
		public UnknownOption () : base ("Unknown option") {
			}
        
		/// <summary>
        /// Construct instance for exception "Unknown option"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public UnknownOption (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public UnknownOption (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}


		/// <summary>
        /// Construct instance for exception using a userdata parameter of
		/// type ExceptionData and the format string "The option {0} is not known."
        /// </summary>		
        /// <param name="Object">User data</param>	
		public UnknownOption (ExceptionData Object) : 
				base (global::System.String.Format ("The option {0} is not known.",
					Object.String					)) {
			UserData = Object;
			}

		/// <summary>
        /// Construct instance for exception using a userdata parameter of
		/// type ExceptionData and the format string "The option {0} is not known."
        /// </summary>		
        /// <param name="Object">User data</param>	
		/// <param name="Inner">Inner Exception</param>	
		public UnknownOption (ExceptionData Object, System.Exception Inner) : 
				base (global::System.String.Format ("The option {0} is not known.",
					Object.String					), Inner) {
			UserData = Object;
			}



		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new UnknownOption(Reason as string);
				}
			else if (Reason as ExceptionData != null) {
				return new UnknownOption(Reason as ExceptionData);
				}
			else {
				return new UnknownOption();
				}
            }
        }


    /// <summary>
    /// No command specified
    /// </summary>
    public class NoCommand : ParserException {

		/// <summary>
        /// Construct instance for exception "No command specified"
        /// </summary>		
		public NoCommand () : base ("No command specified") {
			}
        
		/// <summary>
        /// Construct instance for exception "No command specified"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public NoCommand (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public NoCommand (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new NoCommand(Reason as string);
				}
			else {
				return new NoCommand();
				}
            }
        }


    /// <summary>
    /// Schema parsing exception
    /// </summary>
    public class SchemaParse : global::System.Exception {

		/// <summary>
        /// Construct instance for exception "The schema could not be parsed"
        /// </summary>		
		public SchemaParse () : base ("The schema could not be parsed") {
			}
        
		/// <summary>
        /// Construct instance for exception "The schema could not be parsed"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public SchemaParse (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public SchemaParse (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}

		/// <summary>
        /// User data associated with the exception.
        /// </summary>	
		public object UserData;



		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new SchemaParse(Reason as string);
				}
			else {
				return new SchemaParse();
				}
            }
        }


    /// <summary>
    /// A reserved word was expected but a different token was encountered.
    /// </summary>
    public class NotFoundReserved : SchemaParse {

		/// <summary>
        /// Construct instance for exception "An error occurred"
        /// </summary>		
		public NotFoundReserved () : base ("An error occurred") {
			}
        
		/// <summary>
        /// Construct instance for exception "An error occurred"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public NotFoundReserved (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public NotFoundReserved (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}


		/// <summary>
        /// Construct instance for exception using a userdata parameter of
		/// type ExceptionData and the format string "Expected reserved word, token {0} was not found"
        /// </summary>		
        /// <param name="Object">User data</param>	
		public NotFoundReserved (ExceptionData Object) : 
				base (global::System.String.Format ("Expected reserved word, token {0} was not found",
					Object.String					)) {
			UserData = Object;
			}

		/// <summary>
        /// Construct instance for exception using a userdata parameter of
		/// type ExceptionData and the format string "Expected reserved word, token {0} was not found"
        /// </summary>		
        /// <param name="Object">User data</param>	
		/// <param name="Inner">Inner Exception</param>	
		public NotFoundReserved (ExceptionData Object, System.Exception Inner) : 
				base (global::System.String.Format ("Expected reserved word, token {0} was not found",
					Object.String					), Inner) {
			UserData = Object;
			}



		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new NotFoundReserved(Reason as string);
				}
			else if (Reason as ExceptionData != null) {
				return new NotFoundReserved(Reason as ExceptionData);
				}
			else {
				return new NotFoundReserved();
				}
            }
        }


    /// <summary>
    /// An internal parser error occured, this code should not have been reached.
    /// </summary>
    public class InternalError : SchemaParse {

		/// <summary>
        /// Construct instance for exception "An internal parser error occurred"
        /// </summary>		
		public InternalError () : base ("An internal parser error occurred") {
			}
        
		/// <summary>
        /// Construct instance for exception "An internal parser error occurred"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public InternalError (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public InternalError (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new InternalError(Reason as string);
				}
			else {
				return new InternalError();
				}
            }
        }


    /// <summary>
    /// The input token was not valid.
    /// </summary>
    public class InvalidToken : SchemaParse {

		/// <summary>
        /// Construct instance for exception "An invalid token was encountered"
        /// </summary>		
		public InvalidToken () : base ("An invalid token was encountered") {
			}
        
		/// <summary>
        /// Construct instance for exception "An invalid token was encountered"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public InvalidToken (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public InvalidToken (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new InvalidToken(Reason as string);
				}
			else {
				return new InvalidToken();
				}
            }
        }


    /// <summary>
    /// Expected a block start token.
    /// </summary>
    public class ExpectedStart : SchemaParse {

		/// <summary>
        /// Construct instance for exception "Start token expected"
        /// </summary>		
		public ExpectedStart () : base ("Start token expected") {
			}
        
		/// <summary>
        /// Construct instance for exception "Start token expected"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public ExpectedStart (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public ExpectedStart (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new ExpectedStart(Reason as string);
				}
			else {
				return new ExpectedStart();
				}
            }
        }


    /// <summary>
    /// A class token was expected.
    /// </summary>
    public class ExpectedClass : SchemaParse {

		/// <summary>
        /// Construct instance for exception "Parser Error Expected [Class]"
        /// </summary>		
		public ExpectedClass () : base ("Parser Error Expected [Class]") {
			}
        
		/// <summary>
        /// Construct instance for exception "Parser Error Expected [Class]"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public ExpectedClass (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public ExpectedClass (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new ExpectedClass(Reason as string);
				}
			else {
				return new ExpectedClass();
				}
            }
        }


    /// <summary>
    /// A token was expected.
    /// </summary>
    public class Expected : SchemaParse {

		/// <summary>
        /// Construct instance for exception "Parser Error Expected [Class]"
        /// </summary>		
		public Expected () : base ("Parser Error Expected [Class]") {
			}
        
		/// <summary>
        /// Construct instance for exception "Parser Error Expected [Class]"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public Expected (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public Expected (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new Expected(Reason as string);
				}
			else {
				return new Expected();
				}
            }
        }


    /// <summary>
    /// More block close tokens were encountered than open tokens.
    /// </summary>
    public class TooManyClose : SchemaParse {

		/// <summary>
        /// Construct instance for exception "Too Many Closing Braces"
        /// </summary>		
		public TooManyClose () : base ("Too Many Closing Braces") {
			}
        
		/// <summary>
        /// Construct instance for exception "Too Many Closing Braces"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public TooManyClose (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public TooManyClose (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new TooManyClose(Reason as string);
				}
			else {
				return new TooManyClose();
				}
            }
        }


    /// <summary>
    /// Unreachable code was encountered.
    /// </summary>
    public class UnreachableCode : SchemaParse {

		/// <summary>
        /// Construct instance for exception "Unreachable code reached"
        /// </summary>		
		public UnreachableCode () : base ("Unreachable code reached") {
			}
        
		/// <summary>
        /// Construct instance for exception "Unreachable code reached"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public UnreachableCode (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public UnreachableCode (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new UnreachableCode(Reason as string);
				}
			else {
				return new UnreachableCode();
				}
            }
        }


	}
