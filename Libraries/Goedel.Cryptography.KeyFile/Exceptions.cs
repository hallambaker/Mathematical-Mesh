using System;
using Goedel.Utilities;

using Goedel.FSR;


namespace Goedel.Cryptography.KeyFile {


    /// <summary>
    /// Exception occurred parsing or encoding a key file.
    /// </summary>
    [Serializable]
	public class KeyFileException : global::System.Exception {

		/// <summary>
        /// Construct instance for exception "Key could not be ready"
        /// </summary>		
		public KeyFileException () : base ("Key could not be ready") {
			}
        
		/// <summary>
        /// Construct instance for exception "Key could not be ready"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public KeyFileException (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public KeyFileException (string Description, System.Exception Inner) : 
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
				return new KeyFileException(Reason as string);
				}
			else {
				return new KeyFileException();
				}
            }
        }


    /// <summary>
    /// The specified key did not have a valid cryptographic
    /// provider. This may be because the key algorithm is 
    /// not supported or the key parameters were found to be invalid.
    /// </summary>
    [Serializable]
	public class NoProviderSpecified : KeyFileException {

		/// <summary>
        /// Construct instance for exception "No provider specified"
        /// </summary>		
		public NoProviderSpecified () : base ("No provider specified") {
			}
        
		/// <summary>
        /// Construct instance for exception "No provider specified"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public NoProviderSpecified (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public NoProviderSpecified (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new NoProviderSpecified(Reason as string);
				}
			else {
				return new NoProviderSpecified();
				}
            }
        }


    /// <summary>
    /// An attempt was made to perform a private key operation
    /// and the private key parameters could not be found.
    /// </summary>
    [Serializable]
	public class PrivateKeyNotAvailable : KeyFileException {

		/// <summary>
        /// Construct instance for exception "The specified private key could not be found"
        /// </summary>		
		public PrivateKeyNotAvailable () : base ("The specified private key could not be found") {
			}
        
		/// <summary>
        /// Construct instance for exception "The specified private key could not be found"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public PrivateKeyNotAvailable (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public PrivateKeyNotAvailable (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new PrivateKeyNotAvailable(Reason as string);
				}
			else {
				return new PrivateKeyNotAvailable();
				}
            }
        }


    /// <summary>
    /// An attempt to read a file failed because data was
    /// missing or corrupted.
    /// </summary>
    [Serializable]
	public class UnexpectedEnd : KeyFileException {

		/// <summary>
        /// Construct instance for exception "File read error, file was incomplete"
        /// </summary>		
		public UnexpectedEnd () : base ("File read error, file was incomplete") {
			}
        
		/// <summary>
        /// Construct instance for exception "File read error, file was incomplete"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public UnexpectedEnd (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public UnexpectedEnd (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new UnexpectedEnd(Reason as string);
				}
			else {
				return new UnexpectedEnd();
				}
            }
        }


    /// <summary>
    /// An unidentifier parse error occurred.
    /// </summary>
    [Serializable]
	public class ParseError : KeyFileException {

		/// <summary>
        /// Construct instance for exception "An error occurred"
        /// </summary>		
		public ParseError () : base ("An error occurred") {
			}
        
		/// <summary>
        /// Construct instance for exception "An error occurred"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public ParseError (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public ParseError (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}


		/// <summary>
        /// Construct instance for exception using a userdata parameter of
		/// type LexReader and the format string "The file {0} could not be read"
        /// </summary>		
        /// <param name="Object">User data</param>	
		public ParseError (LexReader Object) : 
				base (global::System.String.Format ("The file {0} could not be read",
					Object.FilePath					)) => UserData = Object;


		/// <summary>
        /// Construct instance for exception using a userdata parameter of
		/// type LexReader and the format string "The file {0} could not be read"
        /// </summary>		
        /// <param name="Object">User data</param>	
		/// <param name="Inner">Inner Exception</param>	
		public ParseError (LexReader Object, System.Exception Inner) : 
				base (global::System.String.Format ("The file {0} could not be read",
					Object.FilePath					), Inner) => UserData = Object;



		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new ParseError(Reason as string);
				}
			else if (Reason as LexReader != null) {
				return new ParseError(Reason as LexReader);
				}
			else {
				return new ParseError();
				}
            }
        }


	}
