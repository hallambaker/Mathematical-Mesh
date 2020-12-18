
//using System;
//using Goedel.Utilities;



#pragma warning disable IDE1006 // Naming Styles
namespace Goedel.Mesh.Server {




    /// <summary>
    /// Generic Mesh Service Error
    /// </summary>
    [global::System.Serializable]
	public partial class MeshServerException : global::Goedel.Utilities.GoedelException {

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
		public MeshServerException  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (ExceptionFormatDelegate(description, Templates,
					null, args), inner) {
			}





		/// <summary>
        /// The public fatory delegate
        /// </summary>
        /// public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

        static System.Exception _Throw(object reasons) => new MeshServerException(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;


        }


    /// <summary>
    /// Generic Mesh Service Error
    /// </summary>
    [global::System.Serializable]
	public partial class MeshServerResponse : MeshServerException {

        ///<summary>The exception formatting delegate. May be overriden 
		///locally or globally to implement different exception formatting.</summary>
		public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
				global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


		///<summary></summary>
		public static new System.Collections.Generic.List<string> Templates = 
				new System.Collections.Generic.List<string> {

				"Mesh message response exception"
				};

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshServerResponse  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (ExceptionFormatDelegate(description, Templates,
					null, args), inner) {
			}





		/// <summary>
        /// The public fatory delegate
        /// </summary>
        /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

        static System.Exception _Throw(object reasons) => new MeshServerResponse(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;


        }


    /// <summary>
    /// The responseId was not found
    /// </summary>
    [global::System.Serializable]
	public partial class MeshResponseNotFound : MeshServerResponse {

        ///<summary>The exception formatting delegate. May be overriden 
		///locally or globally to implement different exception formatting.</summary>
		public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
				global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


		///<summary></summary>
		public static new System.Collections.Generic.List<string> Templates = 
				new System.Collections.Generic.List<string> {

				"The responseId was not found"
				};

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshResponseNotFound  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (ExceptionFormatDelegate(description, Templates,
					null, args), inner) {
			}





		/// <summary>
        /// The public fatory delegate
        /// </summary>
        /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

        static System.Exception _Throw(object reasons) => new MeshResponseNotFound(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;


        }


    /// <summary>
    /// The respondent replied that they refused to accept the request
    /// </summary>
    [global::System.Serializable]
	public partial class MeshResponseRefused : MeshServerResponse {

        ///<summary>The exception formatting delegate. May be overriden 
		///locally or globally to implement different exception formatting.</summary>
		public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
				global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


		///<summary></summary>
		public static new System.Collections.Generic.List<string> Templates = 
				new System.Collections.Generic.List<string> {

				"The respondent refused to accept the request"
				};

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshResponseRefused  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (ExceptionFormatDelegate(description, Templates,
					null, args), inner) {
			}





		/// <summary>
        /// The public fatory delegate
        /// </summary>
        /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

        static System.Exception _Throw(object reasons) => new MeshResponseRefused(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;


        }


    /// <summary>
    /// The request message expired before the respondent replied
    /// </summary>
    [global::System.Serializable]
	public partial class MeshResponseExpired : MeshServerResponse {

        ///<summary>The exception formatting delegate. May be overriden 
		///locally or globally to implement different exception formatting.</summary>
		public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
				global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


		///<summary></summary>
		public static new System.Collections.Generic.List<string> Templates = 
				new System.Collections.Generic.List<string> {

				"The request message expired before the respondent replied"
				};

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshResponseExpired  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (ExceptionFormatDelegate(description, Templates,
					null, args), inner) {
			}





		/// <summary>
        /// The public fatory delegate
        /// </summary>
        /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

        static System.Exception _Throw(object reasons) => new MeshResponseExpired(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;


        }


    /// <summary>
    /// The service request message is larger than permitted by the service policy
    /// </summary>
    [global::System.Serializable]
	public partial class MeshRequestSize : MeshServerException {

        ///<summary>The exception formatting delegate. May be overriden 
		///locally or globally to implement different exception formatting.</summary>
		public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
				global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


		///<summary></summary>
		public static new System.Collections.Generic.List<string> Templates = 
				new System.Collections.Generic.List<string> {

				"The service request message is larger than permitted by the service policy"
				};

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshRequestSize  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (ExceptionFormatDelegate(description, Templates,
					null, args), inner) {
			}





		/// <summary>
        /// The public fatory delegate
        /// </summary>
        /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

        static System.Exception _Throw(object reasons) => new MeshRequestSize(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;


        }


    /// <summary>
    /// </summary>
    [global::System.Serializable]
	public partial class MeshUnknownAccount : MeshServerException {

        ///<summary>The exception formatting delegate. May be overriden 
		///locally or globally to implement different exception formatting.</summary>
		public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
				global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


		///<summary></summary>
		public static new System.Collections.Generic.List<string> Templates = 
				new System.Collections.Generic.List<string> {

				"The specified account is unknown"
				};

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshUnknownAccount  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (ExceptionFormatDelegate(description, Templates,
					null, args), inner) {
			}





		/// <summary>
        /// The public fatory delegate
        /// </summary>
        /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

        static System.Exception _Throw(object reasons) => new MeshUnknownAccount(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;


        }


    /// <summary>
    /// </summary>
    [global::System.Serializable]
	public partial class MeshAccountAlreadyRegistered : MeshServerException {

        ///<summary>The exception formatting delegate. May be overriden 
		///locally or globally to implement different exception formatting.</summary>
		public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
				global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


		///<summary></summary>
		public static new System.Collections.Generic.List<string> Templates = 
				new System.Collections.Generic.List<string> {

				"The specified account is already registered"
				};

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshAccountAlreadyRegistered  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (ExceptionFormatDelegate(description, Templates,
					null, args), inner) {
			}





		/// <summary>
        /// The public fatory delegate
        /// </summary>
        /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

        static System.Exception _Throw(object reasons) => new MeshAccountAlreadyRegistered(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;


        }


    /// <summary>
    /// </summary>
    [global::System.Serializable]
	public partial class MeshRedirect : MeshServerException {

        ///<summary>The exception formatting delegate. May be overriden 
		///locally or globally to implement different exception formatting.</summary>
		public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
				global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


		///<summary></summary>
		public static new System.Collections.Generic.List<string> Templates = 
				new System.Collections.Generic.List<string> {

				"The specified account has been transfered to another service"
				};

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshRedirect  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (ExceptionFormatDelegate(description, Templates,
					null, args), inner) {
			}





		/// <summary>
        /// The public fatory delegate
        /// </summary>
        /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

        static System.Exception _Throw(object reasons) => new MeshRedirect(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;


        }


    /// <summary>
    /// </summary>
    [global::System.Serializable]
	public partial class MeshOperationFailed : MeshServerException {

        ///<summary>The exception formatting delegate. May be overriden 
		///locally or globally to implement different exception formatting.</summary>
		public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
				global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


		///<summary></summary>
		public static new System.Collections.Generic.List<string> Templates = 
				new System.Collections.Generic.List<string> {

				"A requested cryptographic operation failed."
				};

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshOperationFailed  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (ExceptionFormatDelegate(description, Templates,
					null, args), inner) {
			}





		/// <summary>
        /// The public fatory delegate
        /// </summary>
        /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

        static System.Exception _Throw(object reasons) => new MeshOperationFailed(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;


        }


    /// <summary>
    /// </summary>
    [global::System.Serializable]
	public partial class MeshMessageControl : MeshServerException {

        ///<summary>The exception formatting delegate. May be overriden 
		///locally or globally to implement different exception formatting.</summary>
		public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
				global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


		///<summary></summary>
		public static new System.Collections.Generic.List<string> Templates = 
				new System.Collections.Generic.List<string> {

				"Mesh message control exception"
				};

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshMessageControl  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (ExceptionFormatDelegate(description, Templates,
					null, args), inner) {
			}





		/// <summary>
        /// The public fatory delegate
        /// </summary>
        /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

        static System.Exception _Throw(object reasons) => new MeshMessageControl(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;


        }


    /// <summary>
    /// </summary>
    [global::System.Serializable]
	public partial class MeshServiceBlockedSender : MeshMessageControl {

        ///<summary>The exception formatting delegate. May be overriden 
		///locally or globally to implement different exception formatting.</summary>
		public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
				global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


		///<summary></summary>
		public static new System.Collections.Generic.List<string> Templates = 
				new System.Collections.Generic.List<string> {

				"The request was ignored because the sending account is blocked by the service"
				};

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshServiceBlockedSender  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (ExceptionFormatDelegate(description, Templates,
					null, args), inner) {
			}





		/// <summary>
        /// The public fatory delegate
        /// </summary>
        /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

        static System.Exception _Throw(object reasons) => new MeshServiceBlockedSender(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;


        }


    /// <summary>
    /// </summary>
    [global::System.Serializable]
	public partial class MeshServiceBlockedService : MeshMessageControl {

        ///<summary>The exception formatting delegate. May be overriden 
		///locally or globally to implement different exception formatting.</summary>
		public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
				global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


		///<summary></summary>
		public static new System.Collections.Generic.List<string> Templates = 
				new System.Collections.Generic.List<string> {

				"The request was ignored because the requesting service is blocked by the service"
				};

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshServiceBlockedService  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (ExceptionFormatDelegate(description, Templates,
					null, args), inner) {
			}





		/// <summary>
        /// The public fatory delegate
        /// </summary>
        /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

        static System.Exception _Throw(object reasons) => new MeshServiceBlockedService(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;


        }


    /// <summary>
    /// </summary>
    [global::System.Serializable]
	public partial class MeshRecipientBlockedSender : MeshMessageControl {

        ///<summary>The exception formatting delegate. May be overriden 
		///locally or globally to implement different exception formatting.</summary>
		public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
				global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


		///<summary></summary>
		public static new System.Collections.Generic.List<string> Templates = 
				new System.Collections.Generic.List<string> {

				"The request was ignored because the sending account is blocked by the recipient"
				};

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshRecipientBlockedSender  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (ExceptionFormatDelegate(description, Templates,
					null, args), inner) {
			}





		/// <summary>
        /// The public fatory delegate
        /// </summary>
        /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

        static System.Exception _Throw(object reasons) => new MeshRecipientBlockedSender(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;


        }


    /// <summary>
    /// </summary>
    [global::System.Serializable]
	public partial class MeshRecipientBlockedService : MeshMessageControl {

        ///<summary>The exception formatting delegate. May be overriden 
		///locally or globally to implement different exception formatting.</summary>
		public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
				global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


		///<summary></summary>
		public static new System.Collections.Generic.List<string> Templates = 
				new System.Collections.Generic.List<string> {

				"The request was ignored because the requesting service is blocked by the recipient"
				};

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshRecipientBlockedService  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (ExceptionFormatDelegate(description, Templates,
					null, args), inner) {
			}





		/// <summary>
        /// The public fatory delegate
        /// </summary>
        /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

        static System.Exception _Throw(object reasons) => new MeshRecipientBlockedService(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;


        }


    /// <summary>
    /// </summary>
    [global::System.Serializable]
	public partial class MeshMessageInsufficientPrivilege : MeshMessageControl {

        ///<summary>The exception formatting delegate. May be overriden 
		///locally or globally to implement different exception formatting.</summary>
		public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
				global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


		///<summary></summary>
		public static new System.Collections.Generic.List<string> Templates = 
				new System.Collections.Generic.List<string> {

				"The request was refused because the sender has insufficient privileges"
				};

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshMessageInsufficientPrivilege  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (ExceptionFormatDelegate(description, Templates,
					null, args), inner) {
			}





		/// <summary>
        /// The public fatory delegate
        /// </summary>
        /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

        static System.Exception _Throw(object reasons) => new MeshMessageInsufficientPrivilege(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;


        }


    /// <summary>
    /// </summary>
    [global::System.Serializable]
	public partial class MeshMessageInvalid : MeshMessageControl {

        ///<summary>The exception formatting delegate. May be overriden 
		///locally or globally to implement different exception formatting.</summary>
		public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
				global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


		///<summary></summary>
		public static new System.Collections.Generic.List<string> Templates = 
				new System.Collections.Generic.List<string> {

				"The request was refused because it was invalid"
				};

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshMessageInvalid  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (ExceptionFormatDelegate(description, Templates,
					null, args), inner) {
			}





		/// <summary>
        /// The public fatory delegate
        /// </summary>
        /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

        static System.Exception _Throw(object reasons) => new MeshMessageInvalid(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;


        }


    /// <summary>
    /// </summary>
    [global::System.Serializable]
	public partial class MeshMessageUnsupported : MeshMessageControl {

        ///<summary>The exception formatting delegate. May be overriden 
		///locally or globally to implement different exception formatting.</summary>
		public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
				global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


		///<summary></summary>
		public static new System.Collections.Generic.List<string> Templates = 
				new System.Collections.Generic.List<string> {

				"The request was refused because the message type is not supported"
				};

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshMessageUnsupported  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (ExceptionFormatDelegate(description, Templates,
					null, args), inner) {
			}





		/// <summary>
        /// The public fatory delegate
        /// </summary>
        /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

        static System.Exception _Throw(object reasons) => new MeshMessageUnsupported(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;


        }


	}
