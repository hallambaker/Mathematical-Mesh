using System;

using Goedel.FSR;


namespace Goedel.Cryptography.KeyFile {


    /// <summary>
    /// </summary>
    public class KeyFileException : global::System.Exception {

		/// <summary>
        /// Create an instance of the exception.
        /// </summary>		
		public KeyFileException () : base () {
			}
        
		/// <summary>
        /// Create an instance of the exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public KeyFileException (string Description) : base (Description) {
			}

		/// <summary>
        /// Create an instance of the exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public KeyFileException (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}

		public object UserData;



		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new KeyFileException(Reason as string);
				}


			else {
				return new KeyFileException("Key could not be read");
				}
            }
        }


    /// <summary>
    /// The specified key did not have a valid cryptographic
    /// provider. This may be because the key algorithm is 
    /// not supported or the key parameters were found to be invalid.
    /// </summary>
    public class NoProviderSpecified : KeyFileException {

		/// <summary>
        /// Create an instance of the exception.
        /// </summary>		
		public NoProviderSpecified () : base () {
			}
        
		/// <summary>
        /// Create an instance of the exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public NoProviderSpecified (string Description) : base (Description) {
			}

		/// <summary>
        /// Create an instance of the exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public NoProviderSpecified (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new NoProviderSpecified(Reason as string);
				}


			else {
				return new NoProviderSpecified("No provider specified");
				}
            }
        }


    /// <summary>
    /// An attempt was made to perform a private key operation
    /// and the private key parameters could not be found.
    /// </summary>
    public class PrivateKeyNotAvailable : KeyFileException {

		/// <summary>
        /// Create an instance of the exception.
        /// </summary>		
		public PrivateKeyNotAvailable () : base () {
			}
        
		/// <summary>
        /// Create an instance of the exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public PrivateKeyNotAvailable (string Description) : base (Description) {
			}

		/// <summary>
        /// Create an instance of the exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public PrivateKeyNotAvailable (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new PrivateKeyNotAvailable(Reason as string);
				}


			else {
				return new PrivateKeyNotAvailable("The specified private key could not be found");
				}
            }
        }


    /// <summary>
    /// An attempt to read a file failed because data was
    /// missing or corrupted.
    /// </summary>
    public class UnexpectedEnd : KeyFileException {

		/// <summary>
        /// Create an instance of the exception.
        /// </summary>		
		public UnexpectedEnd () : base () {
			}
        
		/// <summary>
        /// Create an instance of the exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public UnexpectedEnd (string Description) : base (Description) {
			}

		/// <summary>
        /// Create an instance of the exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public UnexpectedEnd (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new UnexpectedEnd(Reason as string);
				}


			else {
				return new UnexpectedEnd("File read error, file was incomplete");
				}
            }
        }


    /// <summary>
    /// </summary>
    public class ParseError : KeyFileException {

		/// <summary>
        /// Create an instance of the exception.
        /// </summary>		
		public ParseError () : base () {
			}
        
		/// <summary>
        /// Create an instance of the exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public ParseError (string Description) : base (Description) {
			}

		/// <summary>
        /// Create an instance of the exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public ParseError (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}


		/// <summary>
        /// Create an instance of the exception.
        /// </summary>		
        /// <param name="Object">User data</param>	
		/// <param name="Inner">Inner Exception</param>	
		public ParseError (LexReader Object) : 
				base (String.Format ("The file {0} could not be read",
					Object.FilePath					)) {
			UserData = Object;
			}

		/// <summary>
        /// Create an instance of the exception.
        /// </summary>		
        /// <param name="Object">User data</param>	
		/// <param name="Inner">Inner Exception</param>	
		public ParseError (LexReader Object, System.Exception Inner) : 
				base (String.Format ("The file {0} could not be read",
					Object.FilePath					), Inner) {
			UserData = Object;
			}



		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new ParseError(Reason as string);
				}


			else {
				return new ParseError("An error occurred");
				}
            }
        }


	}
