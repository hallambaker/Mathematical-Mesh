
//using System;
//using Goedel.Utilities;

using Goedel.FSR;


namespace Goedel.Cryptography.KeyFile {


    /// <summary>
    /// Exception occurred parsing or encoding a key file.
    /// </summary>
    [global::System.Serializable]
	public partial class KeyFileException : global::Goedel.Utilities.GoedelException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Key could not be ready";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public KeyFileException  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new KeyFileException(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new KeyFileException(reason as string);
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
    [global::System.Serializable]
	public partial class NoProviderSpecified : KeyFileException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "No provider specified";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public NoProviderSpecified  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new NoProviderSpecified(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new NoProviderSpecified(reason as string);
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
    [global::System.Serializable]
	public partial class PrivateKeyNotAvailable : KeyFileException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The specified private key could not be found";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public PrivateKeyNotAvailable  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new PrivateKeyNotAvailable(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new PrivateKeyNotAvailable(reason as string);
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
    [global::System.Serializable]
	public partial class UnexpectedEnd : KeyFileException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "File read error, file was incomplete";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public UnexpectedEnd  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new UnexpectedEnd(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new UnexpectedEnd(reason as string);
				}
			else {
				return new UnexpectedEnd();
				}
            }
        }


    /// <summary>
    /// An unidentifier parse error occurred.
    /// </summary>
    [global::System.Serializable]
	public partial class ParseError : KeyFileException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "An error occurred";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public ParseError  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
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
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new ParseError(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new ParseError(reason as string);
				}
			else if (reason as LexReader != null) {
				return new ParseError(reason as LexReader);
				}
			else {
				return new ParseError();
				}
            }
        }


	}
