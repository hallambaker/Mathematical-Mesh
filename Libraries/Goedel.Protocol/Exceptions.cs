
//using System;
//using Goedel.Utilities;



namespace Goedel.Protocol {


    /// <summary>
    /// A dechunking exception occurred.
    /// </summary>
    [global::System.Serializable]
	public partial class Dechunking : global::Goedel.Utilities.GoedelException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Key could not be read.";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public Dechunking  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new Dechunking(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new Dechunking(reason as string);
				}
			else {
				return new Dechunking();
				}
            }
        }


    /// <summary>
    /// The requested operation is not known to this server.
    /// </summary>
    [global::System.Serializable]
	public partial class UnknownOperation : Dechunking {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The requested operation is not known to this server.";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public UnknownOperation  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new UnknownOperation(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new UnknownOperation(reason as string);
				}
			else {
				return new UnknownOperation();
				}
            }
        }


    /// <summary>
    /// Message exceeds permitted size limit
    /// </summary>
    [global::System.Serializable]
	public partial class MessageTooBig : Dechunking {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Message is too big";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MessageTooBig  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new MessageTooBig(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new MessageTooBig(reason as string);
				}
			else {
				return new MessageTooBig();
				}
            }
        }


    /// <summary>
    /// Could not reach the specified host
    /// </summary>
    [global::System.Serializable]
	public partial class ConnectionFail : global::Goedel.Utilities.GoedelException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Connection to host [{0}] Failed.";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public ConnectionFail  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new ConnectionFail(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new ConnectionFail(reason as string);
				}
			else {
				return new ConnectionFail();
				}
            }
        }


    /// <summary>
    /// A serialized data stream contains a type tag describing an abstract type that cannot be constructed.
    /// </summary>
    [global::System.Serializable]
	public partial class CannotCreateAbstract : global::Goedel.Utilities.GoedelException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Deserialzer encountered tag describing abstract type";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public CannotCreateAbstract  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new CannotCreateAbstract(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new CannotCreateAbstract(reason as string);
				}
			else {
				return new CannotCreateAbstract();
				}
            }
        }


    /// <summary>
    /// An unknown tag was encountered.
    /// </summary>
    [global::System.Serializable]
	public partial class UnknownTag : global::Goedel.Utilities.GoedelException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Deserialzer encountered unknown tag";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public UnknownTag  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new UnknownTag(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new UnknownTag(reason as string);
				}
			else {
				return new UnknownTag();
				}
            }
        }


    /// <summary>
    /// The input is not valid in the specified encoding.
    /// </summary>
    [global::System.Serializable]
	public partial class InvalidInput : global::Goedel.Utilities.GoedelException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Deserialzer encountered invalid input";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public InvalidInput  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new InvalidInput(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new InvalidInput(reason as string);
				}
			else {
				return new InvalidInput();
				}
            }
        }


    /// <summary>
    /// Data length did not match data presented.
    /// </summary>
    [global::System.Serializable]
	public partial class BadPartLength : global::Goedel.Utilities.GoedelException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Data length did not match data presented.";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public BadPartLength  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new BadPartLength(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new BadPartLength(reason as string);
				}
			else {
				return new BadPartLength();
				}
            }
        }


    /// <summary>
    /// Stream reader error, position not correctly marked.
    /// </summary>
    [global::System.Serializable]
	public partial class StreamMarkerError : global::Goedel.Utilities.GoedelException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Stream reader error, position not correctly marked.";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public StreamMarkerError  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new StreamMarkerError(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new StreamMarkerError(reason as string);
				}
			else {
				return new StreamMarkerError();
				}
            }
        }


    /// <summary>
    /// </summary>
    [global::System.Serializable]
	public partial class DictionaryInitialization : global::Goedel.Utilities.GoedelException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "An attempt was made to deserialize an object without initializing the dictionary";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public DictionaryInitialization  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new DictionaryInitialization(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new DictionaryInitialization(reason as string);
				}
			else {
				return new DictionaryInitialization();
				}
            }
        }


	}
