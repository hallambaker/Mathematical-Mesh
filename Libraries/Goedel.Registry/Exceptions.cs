
//using System;
//using Goedel.Utilities;



namespace Goedel.Registry {


    /// <summary>
    /// The user command could not be parsed
    /// </summary>
    [global::System.Serializable]
	public partial class ParserException : global::Goedel.Utilities.GoedelException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The user command could not be parsed";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public ParserException  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new ParserException(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new ParserException(reason as string);
				}
			else {
				return new ParserException();
				}
            }
        }


    /// <summary>
    /// The file could not be read.
    /// </summary>
    [global::System.Serializable]
	public partial class FileReadError : ParserException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The file could not be read";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public FileReadError  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}


		/// <summary>
        /// Construct instance for exception using a userdata parameter of
		/// type ExceptionData and the format string "The file {0} could not be read"
        /// </summary>		
        /// <param name="Object">User data</param>	
		public FileReadError (ExceptionData Object) : 
				base (global::System.String.Format ("The file {0} could not be read",
					Object.String					)) => UserData = Object;


		/// <summary>
        /// Construct instance for exception using a userdata parameter of
		/// type ExceptionData and the format string "The file {0} could not be read"
        /// </summary>		
        /// <param name="Object">User data</param>	
		/// <param name="Inner">Inner Exception</param>	
		public FileReadError (ExceptionData Object, System.Exception Inner) : 
				base (global::System.String.Format ("The file {0} could not be read",
					Object.String					), Inner) => UserData = Object;



		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new FileReadError(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new FileReadError(reason as string);
				}
			else if (reason as ExceptionData != null) {
				return new FileReadError(reason as ExceptionData);
				}
			else {
				return new FileReadError();
				}
            }
        }


    /// <summary>
    /// User entered an unknown command
    /// </summary>
    [global::System.Serializable]
	public partial class UnknownCommand : ParserException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Unknown command";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public UnknownCommand  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}


		/// <summary>
        /// Construct instance for exception using a userdata parameter of
		/// type ExceptionData and the format string "The command {0} is not known."
        /// </summary>		
        /// <param name="Object">User data</param>	
		public UnknownCommand (ExceptionData Object) : 
				base (global::System.String.Format ("The command {0} is not known.",
					Object.String					)) => UserData = Object;


		/// <summary>
        /// Construct instance for exception using a userdata parameter of
		/// type ExceptionData and the format string "The command {0} is not known."
        /// </summary>		
        /// <param name="Object">User data</param>	
		/// <param name="Inner">Inner Exception</param>	
		public UnknownCommand (ExceptionData Object, System.Exception Inner) : 
				base (global::System.String.Format ("The command {0} is not known.",
					Object.String					), Inner) => UserData = Object;



		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new UnknownCommand(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new UnknownCommand(reason as string);
				}
			else if (reason as ExceptionData != null) {
				return new UnknownCommand(reason as ExceptionData);
				}
			else {
				return new UnknownCommand();
				}
            }
        }


    /// <summary>
    /// User entered an unknown option
    /// </summary>
    [global::System.Serializable]
	public partial class UnknownOption : ParserException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Unknown option";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public UnknownOption  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}


		/// <summary>
        /// Construct instance for exception using a userdata parameter of
		/// type ExceptionData and the format string "The option {0} is not known."
        /// </summary>		
        /// <param name="Object">User data</param>	
		public UnknownOption (ExceptionData Object) : 
				base (global::System.String.Format ("The option {0} is not known.",
					Object.String					)) => UserData = Object;


		/// <summary>
        /// Construct instance for exception using a userdata parameter of
		/// type ExceptionData and the format string "The option {0} is not known."
        /// </summary>		
        /// <param name="Object">User data</param>	
		/// <param name="Inner">Inner Exception</param>	
		public UnknownOption (ExceptionData Object, System.Exception Inner) : 
				base (global::System.String.Format ("The option {0} is not known.",
					Object.String					), Inner) => UserData = Object;



		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new UnknownOption(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new UnknownOption(reason as string);
				}
			else if (reason as ExceptionData != null) {
				return new UnknownOption(reason as ExceptionData);
				}
			else {
				return new UnknownOption();
				}
            }
        }


    /// <summary>
    /// No command specified
    /// </summary>
    [global::System.Serializable]
	public partial class NoCommand : ParserException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "No command specified";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public NoCommand  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new NoCommand(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new NoCommand(reason as string);
				}
			else {
				return new NoCommand();
				}
            }
        }


    /// <summary>
    /// Schema parsing exception
    /// </summary>
    [global::System.Serializable]
	public partial class SchemaParse : global::Goedel.Utilities.GoedelException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The schema could not be parsed";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public SchemaParse  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new SchemaParse(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new SchemaParse(reason as string);
				}
			else {
				return new SchemaParse();
				}
            }
        }


    /// <summary>
    /// A reserved word was expected but a different token was encountered.
    /// </summary>
    [global::System.Serializable]
	public partial class NotFoundReserved : SchemaParse {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "An error occurred";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public NotFoundReserved  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}


		/// <summary>
        /// Construct instance for exception using a userdata parameter of
		/// type ExceptionData and the format string "Expected reserved word, token {0} was not found"
        /// </summary>		
        /// <param name="Object">User data</param>	
		public NotFoundReserved (ExceptionData Object) : 
				base (global::System.String.Format ("Expected reserved word, token {0} was not found",
					Object.String					)) => UserData = Object;


		/// <summary>
        /// Construct instance for exception using a userdata parameter of
		/// type ExceptionData and the format string "Expected reserved word, token {0} was not found"
        /// </summary>		
        /// <param name="Object">User data</param>	
		/// <param name="Inner">Inner Exception</param>	
		public NotFoundReserved (ExceptionData Object, System.Exception Inner) : 
				base (global::System.String.Format ("Expected reserved word, token {0} was not found",
					Object.String					), Inner) => UserData = Object;



		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new NotFoundReserved(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new NotFoundReserved(reason as string);
				}
			else if (reason as ExceptionData != null) {
				return new NotFoundReserved(reason as ExceptionData);
				}
			else {
				return new NotFoundReserved();
				}
            }
        }


    /// <summary>
    /// An internal parser error occured, this code should not have been reached.
    /// </summary>
    [global::System.Serializable]
	public partial class InternalError : SchemaParse {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "An internal parser error occurred";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public InternalError  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new InternalError(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new InternalError(reason as string);
				}
			else {
				return new InternalError();
				}
            }
        }


    /// <summary>
    /// The input token was not valid.
    /// </summary>
    [global::System.Serializable]
	public partial class InvalidToken : SchemaParse {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "An invalid token was encountered";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public InvalidToken  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new InvalidToken(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new InvalidToken(reason as string);
				}
			else {
				return new InvalidToken();
				}
            }
        }


    /// <summary>
    /// Expected a block start token.
    /// </summary>
    [global::System.Serializable]
	public partial class ExpectedStart : SchemaParse {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Start token expected";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public ExpectedStart  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new ExpectedStart(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new ExpectedStart(reason as string);
				}
			else {
				return new ExpectedStart();
				}
            }
        }


    /// <summary>
    /// A class token was expected.
    /// </summary>
    [global::System.Serializable]
	public partial class ExpectedClass : SchemaParse {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Parser Error Expected [Class]";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public ExpectedClass  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new ExpectedClass(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new ExpectedClass(reason as string);
				}
			else {
				return new ExpectedClass();
				}
            }
        }


    /// <summary>
    /// A token was expected.
    /// </summary>
    [global::System.Serializable]
	public partial class Expected : SchemaParse {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Parser Error Expected [Class]";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public Expected  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new Expected(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new Expected(reason as string);
				}
			else {
				return new Expected();
				}
            }
        }


    /// <summary>
    /// More block close tokens were encountered than open tokens.
    /// </summary>
    [global::System.Serializable]
	public partial class TooManyClose : SchemaParse {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Too Many Closing Braces";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public TooManyClose  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new TooManyClose(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new TooManyClose(reason as string);
				}
			else {
				return new TooManyClose();
				}
            }
        }


    /// <summary>
    /// Unreachable code was encountered.
    /// </summary>
    [global::System.Serializable]
	public partial class UnreachableCode : SchemaParse {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Unreachable code reached";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public UnreachableCode  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new UnreachableCode(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new UnreachableCode(reason as string);
				}
			else {
				return new UnreachableCode();
				}
            }
        }


	}
