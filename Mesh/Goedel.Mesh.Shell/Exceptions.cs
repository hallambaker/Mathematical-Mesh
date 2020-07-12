
//using System;
//using Goedel.Utilities;



namespace Goedel.Mesh.Shell {


    /// <summary>
    /// Generic error in Mesh Shell library
    /// </summary>
    [global::System.Serializable]
	public partial class MeshShellException : global::Goedel.Utilities.GoedelException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Unknown error occured.";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshShellException  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new MeshShellException(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new MeshShellException(reason as string);
				}
			else {
				return new MeshShellException();
				}
            }
        }


    /// <summary>
    /// The calculated fingerprint did not match the expected value.
    /// </summary>
    [global::System.Serializable]
	public partial class DidNotMatchExpectedValue : MeshShellException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The calculated fingerprint did not match the expected value.";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public DidNotMatchExpectedValue  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new DidNotMatchExpectedValue(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new DidNotMatchExpectedValue(reason as string);
				}
			else {
				return new DidNotMatchExpectedValue();
				}
            }
        }


    /// <summary>
    /// Account not valid
    /// </summary>
    [global::System.Serializable]
	public partial class AccountNotFound : MeshShellException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Profile not found";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public AccountNotFound  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new AccountNotFound(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new AccountNotFound(reason as string);
				}
			else {
				return new AccountNotFound();
				}
            }
        }


    /// <summary>
    /// Account not valid
    /// </summary>
    [global::System.Serializable]
	public partial class ProfileNotFound : MeshShellException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "No profile defined.";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public ProfileNotFound  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new ProfileNotFound(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new ProfileNotFound(reason as string);
				}
			else {
				return new ProfileNotFound();
				}
            }
        }


    /// <summary>
    /// The directory could not be found
    /// </summary>
    [global::System.Serializable]
	public partial class DirectoryNotFound : MeshShellException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The directory could not be found";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public DirectoryNotFound  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new DirectoryNotFound(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new DirectoryNotFound(reason as string);
				}
			else {
				return new DirectoryNotFound();
				}
            }
        }


    /// <summary>
    /// The directory could not be found
    /// </summary>
    [global::System.Serializable]
	public partial class FileNotFound : MeshShellException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The file could not be found";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public FileNotFound  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new FileNotFound(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new FileNotFound(reason as string);
				}
			else {
				return new FileNotFound();
				}
            }
        }


	}
