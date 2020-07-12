
//using System;
//using Goedel.Utilities;



namespace Goedel.Mesh.Server {


    /// <summary>
    /// Generic Mesh Service Error
    /// </summary>
    [global::System.Serializable]
	public partial class MeshServerException : global::Goedel.Utilities.GoedelException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Unknown error occured.";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshServerException  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new MeshServerException(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new MeshServerException(reason as string);
				}
			else {
				return new MeshServerException();
				}
            }
        }


    /// <summary>
    /// Generic Mesh Service Error
    /// </summary>
    [global::System.Serializable]
	public partial class MeshServerResponse : MeshServerException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Mesh message response exception";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshServerResponse  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new MeshServerResponse(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new MeshServerResponse(reason as string);
				}
			else {
				return new MeshServerResponse();
				}
            }
        }


    /// <summary>
    /// The responseId was not found
    /// </summary>
    [global::System.Serializable]
	public partial class MeshResponseNotFound : MeshServerResponse {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The responseId was not found";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshResponseNotFound  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new MeshResponseNotFound(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new MeshResponseNotFound(reason as string);
				}
			else {
				return new MeshResponseNotFound();
				}
            }
        }


    /// <summary>
    /// The respondent replied that they refused to accept the request
    /// </summary>
    [global::System.Serializable]
	public partial class MeshResponseRefused : MeshServerResponse {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The respondent refused to accept the request";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshResponseRefused  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new MeshResponseRefused(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new MeshResponseRefused(reason as string);
				}
			else {
				return new MeshResponseRefused();
				}
            }
        }


    /// <summary>
    /// The request message expired before the respondent replied
    /// </summary>
    [global::System.Serializable]
	public partial class MeshResponseExpired : MeshServerResponse {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The request message expired before the respondent replied";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshResponseExpired  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new MeshResponseExpired(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new MeshResponseExpired(reason as string);
				}
			else {
				return new MeshResponseExpired();
				}
            }
        }


    /// <summary>
    /// The service request message is larger than permitted by the service policy
    /// </summary>
    [global::System.Serializable]
	public partial class MeshRequestSize : MeshServerException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The service request message is larger than permitted by the service policy";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshRequestSize  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new MeshRequestSize(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new MeshRequestSize(reason as string);
				}
			else {
				return new MeshRequestSize();
				}
            }
        }


    /// <summary>
    /// </summary>
    [global::System.Serializable]
	public partial class MeshUnknownAccount : MeshServerException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The specified account is unknown";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshUnknownAccount  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new MeshUnknownAccount(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new MeshUnknownAccount(reason as string);
				}
			else {
				return new MeshUnknownAccount();
				}
            }
        }


    /// <summary>
    /// </summary>
    [global::System.Serializable]
	public partial class MeshAccountAlreadyRegistered : MeshServerException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The specified account is already registered";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshAccountAlreadyRegistered  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new MeshAccountAlreadyRegistered(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new MeshAccountAlreadyRegistered(reason as string);
				}
			else {
				return new MeshAccountAlreadyRegistered();
				}
            }
        }


    /// <summary>
    /// </summary>
    [global::System.Serializable]
	public partial class MeshRedirect : MeshServerException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The specified account has been transfered to another service";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshRedirect  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new MeshRedirect(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new MeshRedirect(reason as string);
				}
			else {
				return new MeshRedirect();
				}
            }
        }


    /// <summary>
    /// </summary>
    [global::System.Serializable]
	public partial class MeshMessageControl : MeshServerException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Mesh message control exception";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshMessageControl  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new MeshMessageControl(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new MeshMessageControl(reason as string);
				}
			else {
				return new MeshMessageControl();
				}
            }
        }


    /// <summary>
    /// </summary>
    [global::System.Serializable]
	public partial class MeshServiceBlockedSender : MeshMessageControl {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The request was ignored because the sending account is blocked by the service";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshServiceBlockedSender  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new MeshServiceBlockedSender(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new MeshServiceBlockedSender(reason as string);
				}
			else {
				return new MeshServiceBlockedSender();
				}
            }
        }


    /// <summary>
    /// </summary>
    [global::System.Serializable]
	public partial class MeshServiceBlockedService : MeshMessageControl {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The request was ignored because the requesting service is blocked by the service";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshServiceBlockedService  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new MeshServiceBlockedService(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new MeshServiceBlockedService(reason as string);
				}
			else {
				return new MeshServiceBlockedService();
				}
            }
        }


    /// <summary>
    /// </summary>
    [global::System.Serializable]
	public partial class MeshRecipientBlockedSender : MeshMessageControl {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The request was ignored because the sending account is blocked by the recipient";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshRecipientBlockedSender  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new MeshRecipientBlockedSender(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new MeshRecipientBlockedSender(reason as string);
				}
			else {
				return new MeshRecipientBlockedSender();
				}
            }
        }


    /// <summary>
    /// </summary>
    [global::System.Serializable]
	public partial class MeshRecipientBlockedService : MeshMessageControl {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The request was ignored because the requesting service is blocked by the recipient";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshRecipientBlockedService  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new MeshRecipientBlockedService(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new MeshRecipientBlockedService(reason as string);
				}
			else {
				return new MeshRecipientBlockedService();
				}
            }
        }


    /// <summary>
    /// </summary>
    [global::System.Serializable]
	public partial class MeshMessageInsufficientPrivilege : MeshMessageControl {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The request was refused because the sender has insufficient privileges";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshMessageInsufficientPrivilege  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new MeshMessageInsufficientPrivilege(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new MeshMessageInsufficientPrivilege(reason as string);
				}
			else {
				return new MeshMessageInsufficientPrivilege();
				}
            }
        }


    /// <summary>
    /// </summary>
    [global::System.Serializable]
	public partial class MeshMessageInvalid : MeshMessageControl {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The request was refused because it was invalid";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshMessageInvalid  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new MeshMessageInvalid(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new MeshMessageInvalid(reason as string);
				}
			else {
				return new MeshMessageInvalid();
				}
            }
        }


    /// <summary>
    /// </summary>
    [global::System.Serializable]
	public partial class MeshMessageUnsupported : MeshMessageControl {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The request was refused because the message type is not supported";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MeshMessageUnsupported  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new MeshMessageUnsupported(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new MeshMessageUnsupported(reason as string);
				}
			else {
				return new MeshMessageUnsupported();
				}
            }
        }


	}
