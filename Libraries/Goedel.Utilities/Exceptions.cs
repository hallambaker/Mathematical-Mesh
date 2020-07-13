
//using System;
//using Goedel.Utilities;



namespace Goedel.Utilities {


    /// <summary>
    /// This feature has not been implemented
    /// </summary>
    [global::System.Serializable]
	public partial class NYI : global::Goedel.Utilities.GoedelException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The feature has not been implemented";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public NYI  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new NYI(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new NYI(reason as string);
				}
			else {
				return new NYI();
				}
            }
        }


    /// <summary>
    /// An internal assertion check failed.
    /// </summary>
    [global::System.Serializable]
	public partial class AssertionFail : global::Goedel.Utilities.GoedelException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Assertion check failed";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public AssertionFail  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new AssertionFail(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new AssertionFail(reason as string);
				}
			else {
				return new AssertionFail();
				}
            }
        }


    /// <summary>
    /// An internal assertion check failed.
    /// </summary>
    [global::System.Serializable]
	public partial class Internal : global::Goedel.Utilities.GoedelException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "An internal error occurred";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public Internal  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new Internal(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new Internal(reason as string);
				}
			else {
				return new Internal();
				}
            }
        }


    /// <summary>
    /// The file could not be read.
    /// </summary>
    [global::System.Serializable]
	public partial class FileReadError : global::Goedel.Utilities.GoedelException {


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
        public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new FileReadError(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

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
    /// A call was made to a routine that has not yet been made
    /// 64 bit clean with a value that exceeds the Int32 limits.
    /// </summary>
    [global::System.Serializable]
	public partial class Not64Bit : global::Goedel.Utilities.GoedelException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Item too large";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public Not64Bit  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new Not64Bit(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new Not64Bit(reason as string);
				}
			else {
				return new Not64Bit();
				}
            }
        }


    /// <summary>
    /// </summary>
    [global::System.Serializable]
	public partial class EnvironmentVariableRequired : global::Goedel.Utilities.GoedelException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "A required environment variable is undefined.";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public EnvironmentVariableRequired  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}


		/// <summary>
        /// Construct instance for exception using a userdata parameter of
		/// type ExceptionData and the format string "The environment variable {0} must be defined"
        /// </summary>		
        /// <param name="Object">User data</param>	
		public EnvironmentVariableRequired (ExceptionData Object) : 
				base (global::System.String.Format ("The environment variable {0} must be defined",
					Object.String					)) => UserData = Object;


		/// <summary>
        /// Construct instance for exception using a userdata parameter of
		/// type ExceptionData and the format string "The environment variable {0} must be defined"
        /// </summary>		
        /// <param name="Object">User data</param>	
		/// <param name="Inner">Inner Exception</param>	
		public EnvironmentVariableRequired (ExceptionData Object, System.Exception Inner) : 
				base (global::System.String.Format ("The environment variable {0} must be defined",
					Object.String					), Inner) => UserData = Object;



		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new EnvironmentVariableRequired(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new EnvironmentVariableRequired(reason as string);
				}
			else if (reason as ExceptionData != null) {
				return new EnvironmentVariableRequired(reason as ExceptionData);
				}
			else {
				return new EnvironmentVariableRequired();
				}
            }
        }


    /// <summary>
    /// </summary>
    [global::System.Serializable]
	public partial class ExpectedSuccess : global::Goedel.Utilities.GoedelException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Service request failed when it should have succeded";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public ExpectedSuccess  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new ExpectedSuccess(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new ExpectedSuccess(reason as string);
				}
			else {
				return new ExpectedSuccess();
				}
            }
        }


    /// <summary>
    /// </summary>
    [global::System.Serializable]
	public partial class ExpectedError : global::Goedel.Utilities.GoedelException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Service request succeeded when it should have returned an error";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public ExpectedError  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new ExpectedError(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new ExpectedError(reason as string);
				}
			else {
				return new ExpectedError();
				}
            }
        }


	}
