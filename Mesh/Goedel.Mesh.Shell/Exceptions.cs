
//using System;
//using Goedel.Utilities;



namespace Goedel.Mesh.Shell {

	partial class AllExeptions {
		System.Collections.Generic.List<global::Goedel.Utilities.ThrowNewDelegate> All = 
			new System.Collections.Generic.List<global::Goedel.Utilities.ThrowNewDelegate> () {
				null,
				MeshShellException.ThrowNew,
				DidNotMatchExpectedValue.ThrowNew,
				AccountNotFound.ThrowNew,
				ProfileNotFound.ThrowNew,
				DirectoryNotFound.ThrowNew,
				FileNotFound.ThrowNew				};
		}


    /// <summary>
    /// Generic error in Mesh Shell library
    /// </summary>
    [global::System.Serializable]
	public partial class MeshShellException : global::Goedel.Utilities.GoedelException {

        ///<summary>The exception formatting delegate. May be overriden 
		///locally or globally to implement different exception formatting.</summary>
		public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
				global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


		///<summary></summary>
		public static new System.Collections.Generic.List<string> Templates = 
				new System.Collections.Generic.List<string> {

				"Unknown error occured."
				};

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshShellException  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (ExceptionFormatDelegate(description, Templates,
					null, args), inner) {
			}





		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

        static System.Exception _Throw(object reasons) => new MeshShellException(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;


        }


    /// <summary>
    /// The calculated fingerprint did not match the expected value.
    /// </summary>
    [global::System.Serializable]
	public partial class DidNotMatchExpectedValue : MeshShellException {

        ///<summary>The exception formatting delegate. May be overriden 
		///locally or globally to implement different exception formatting.</summary>
		public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
				global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


		///<summary></summary>
		public static new System.Collections.Generic.List<string> Templates = 
				new System.Collections.Generic.List<string> {

				"The calculated fingerprint did not match the expected value."
				};

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public DidNotMatchExpectedValue  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (ExceptionFormatDelegate(description, Templates,
					null, args), inner) {
			}





		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

        static System.Exception _Throw(object reasons) => new DidNotMatchExpectedValue(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;


        }


    /// <summary>
    /// Account not valid
    /// </summary>
    [global::System.Serializable]
	public partial class AccountNotFound : MeshShellException {

        ///<summary>The exception formatting delegate. May be overriden 
		///locally or globally to implement different exception formatting.</summary>
		public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
				global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


		///<summary></summary>
		public static new System.Collections.Generic.List<string> Templates = 
				new System.Collections.Generic.List<string> {

				"Profile not found"
				};

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public AccountNotFound  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (ExceptionFormatDelegate(description, Templates,
					null, args), inner) {
			}





		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

        static System.Exception _Throw(object reasons) => new AccountNotFound(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;


        }


    /// <summary>
    /// Account not valid
    /// </summary>
    [global::System.Serializable]
	public partial class ProfileNotFound : MeshShellException {

        ///<summary>The exception formatting delegate. May be overriden 
		///locally or globally to implement different exception formatting.</summary>
		public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
				global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


		///<summary></summary>
		public static new System.Collections.Generic.List<string> Templates = 
				new System.Collections.Generic.List<string> {

				"No profile defined."
				};

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public ProfileNotFound  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (ExceptionFormatDelegate(description, Templates,
					null, args), inner) {
			}





		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

        static System.Exception _Throw(object reasons) => new ProfileNotFound(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;


        }


    /// <summary>
    /// The directory could not be found
    /// </summary>
    [global::System.Serializable]
	public partial class DirectoryNotFound : MeshShellException {

        ///<summary>The exception formatting delegate. May be overriden 
		///locally or globally to implement different exception formatting.</summary>
		public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
				global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


		///<summary></summary>
		public static new System.Collections.Generic.List<string> Templates = 
				new System.Collections.Generic.List<string> {

				"The directory could not be found"
				};

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public DirectoryNotFound  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (ExceptionFormatDelegate(description, Templates,
					null, args), inner) {
			}





		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

        static System.Exception _Throw(object reasons) => new DirectoryNotFound(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;


        }


    /// <summary>
    /// The directory could not be found
    /// </summary>
    [global::System.Serializable]
	public partial class FileNotFound : MeshShellException {

        ///<summary>The exception formatting delegate. May be overriden 
		///locally or globally to implement different exception formatting.</summary>
		public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
				global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


		///<summary></summary>
		public static new System.Collections.Generic.List<string> Templates = 
				new System.Collections.Generic.List<string> {

				"The file could not be found"
				};

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public FileNotFound  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (ExceptionFormatDelegate(description, Templates,
					null, args), inner) {
			}





		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

        static System.Exception _Throw(object reasons) => new FileNotFound(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;


        }


	}
