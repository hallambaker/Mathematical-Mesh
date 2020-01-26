using Goedel.Utilities;



namespace Goedel.Command {


    /// <summary>
    /// The user command could not be parsed
    /// </summary>
    public class ParserException : global::System.Exception {

        /// <summary>
        /// Construct instance for exception "The user command could not be parsed"
        /// </summary>		
        public ParserException() : base("The user command could not be parsed") {
            }

        /// <summary>
        /// Construct instance for exception "The user command could not be parsed"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        public ParserException(string Description) : base(Description) {
            }

        /// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        /// <param name="Inner">Inner Exception</param>	
        public ParserException(string Description, System.Exception Inner) :
                base(Description, Inner) {
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
        public FileReadError() : base("The file could not be read") {
            }

        /// <summary>
        /// Construct instance for exception "The file could not be read"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        public FileReadError(string Description) : base(Description) {
            }

        /// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        /// <param name="Inner">Inner Exception</param>	
        public FileReadError(string Description, System.Exception Inner) :
                base(Description, Inner) {
            }


        /// <summary>
        /// Construct instance for exception using a userdata parameter of
        /// type ExceptionData and the format string "The file {0} could not be read"
        /// </summary>		
        /// <param name="Object">User data</param>	
        public FileReadError(ExceptionData Object) :
                base(global::System.String.Format("The file {0} could not be read",
                    Object.String)) => UserData = Object;

        /// <summary>
        /// Construct instance for exception using a userdata parameter of
        /// type ExceptionData and the format string "The file {0} could not be read"
        /// </summary>		
        /// <param name="Object">User data</param>	
        /// <param name="Inner">Inner Exception</param>	
        public FileReadError(ExceptionData Object, System.Exception Inner) :
                base(global::System.String.Format("The file {0} could not be read",
                    Object.String), Inner) => UserData = Object;




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
        public UnknownCommand() : base("Unknown command") {
            }

        /// <summary>
        /// Construct instance for exception "Unknown command"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        public UnknownCommand(string Description) : base(Description) {
            }

        /// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        /// <param name="Inner">Inner Exception</param>	
        public UnknownCommand(string Description, System.Exception Inner) :
                base(Description, Inner) {
            }


        /// <summary>
        /// Construct instance for exception using a userdata parameter of
        /// type ExceptionData and the format string "The command {0} is not known."
        /// </summary>		
        /// <param name="Object">User data</param>	
        public UnknownCommand(ExceptionData Object) :
                base(global::System.String.Format("The command {0} is not known.",
                    Object.String)) => UserData = Object;

        /// <summary>
        /// Construct instance for exception using a userdata parameter of
        /// type ExceptionData and the format string "The command {0} is not known."
        /// </summary>		
        /// <param name="Object">User data</param>	
        /// <param name="Inner">Inner Exception</param>	
        public UnknownCommand(ExceptionData Object, System.Exception Inner) :
                base(global::System.String.Format("The command {0} is not known.",
                    Object.String), Inner) => UserData = Object;




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
        public UnknownOption() : base("Unknown option") {
            }

        /// <summary>
        /// Construct instance for exception "Unknown option"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        public UnknownOption(string Description) : base(Description) {
            }

        /// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        /// <param name="Inner">Inner Exception</param>	
        public UnknownOption(string Description, System.Exception Inner) :
                base(Description, Inner) {
            }


        /// <summary>
        /// Construct instance for exception using a userdata parameter of
        /// type ExceptionData and the format string "The option {0} is not known."
        /// </summary>		
        /// <param name="Object">User data</param>	
        public UnknownOption(ExceptionData Object) :
                base(global::System.String.Format("The option {0} is not known.",
                    Object.String)) => UserData = Object;

        /// <summary>
        /// Construct instance for exception using a userdata parameter of
        /// type ExceptionData and the format string "The option {0} is not known."
        /// </summary>		
        /// <param name="Object">User data</param>	
        /// <param name="Inner">Inner Exception</param>	
        public UnknownOption(ExceptionData Object, System.Exception Inner) :
                base(global::System.String.Format("The option {0} is not known.",
                    Object.String), Inner) => UserData = Object;




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
        public NoCommand() : base("No command specified") {
            }

        /// <summary>
        /// Construct instance for exception "No command specified"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        public NoCommand(string Description) : base(Description) {
            }

        /// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        /// <param name="Inner">Inner Exception</param>	
        public NoCommand(string Description, System.Exception Inner) :
                base(Description, Inner) {
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
    /// The option value was incorrectly formatted
    /// </summary>
    public class InvalidOption : ParserException {

        /// <summary>
        /// Construct instance for exception "The option value was incorrectly formatted"
        /// </summary>		
        public InvalidOption() : base("The option value was incorrectly formatted") {
            }

        /// <summary>
        /// Construct instance for exception "The option value was incorrectly formatted"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        public InvalidOption(string Description) : base(Description) {
            }

        /// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        /// <param name="Inner">Inner Exception</param>	
        public InvalidOption(string Description, System.Exception Inner) :
                base(Description, Inner) {
            }





        /// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
            if (Reason as string != null) {
                return new InvalidOption(Reason as string);
                }
            else {
                return new InvalidOption();
                }
            }
        }


    }
