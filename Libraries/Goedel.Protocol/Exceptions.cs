using System;
using Goedel.Utilities;



namespace Goedel.Protocol {


    /// <summary>
    /// A dechunking exception occurred.
    /// </summary>
    [Serializable]
	public class Dechunking : global::System.Exception {

		/// <summary>
        /// Construct instance for exception "Key could not be read."
        /// </summary>		
		public Dechunking () : base ("Key could not be read.") {
			}
        
		/// <summary>
        /// Construct instance for exception "Key could not be read."
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public Dechunking (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public Dechunking (string Description, System.Exception Inner) : 
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
				return new Dechunking(Reason as string);
				}
			else {
				return new Dechunking();
				}
            }
        }


    /// <summary>
    /// The requested operation is not known to this server.
    /// </summary>
    [Serializable]
	public class UnknownOperation : Dechunking {

		/// <summary>
        /// Construct instance for exception "The requested operation is not known to this server."
        /// </summary>		
		public UnknownOperation () : base ("The requested operation is not known to this server.") {
			}
        
		/// <summary>
        /// Construct instance for exception "The requested operation is not known to this server."
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public UnknownOperation (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public UnknownOperation (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new UnknownOperation(Reason as string);
				}
			else {
				return new UnknownOperation();
				}
            }
        }


    /// <summary>
    /// Message exceeds permitted size limit
    /// </summary>
    [Serializable]
	public class MessageTooBig : Dechunking {

		/// <summary>
        /// Construct instance for exception "Message is too big"
        /// </summary>		
		public MessageTooBig () : base ("Message is too big") {
			}
        
		/// <summary>
        /// Construct instance for exception "Message is too big"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public MessageTooBig (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public MessageTooBig (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new MessageTooBig(Reason as string);
				}
			else {
				return new MessageTooBig();
				}
            }
        }


    /// <summary>
    /// Could not reach the specified host
    /// </summary>
    [Serializable]
	public class ConnectionFail : global::System.Exception {

		/// <summary>
        /// Construct instance for exception "Connection to host failed."
        /// </summary>		
		public ConnectionFail () : base ("Connection to host failed.") {
			}
        
		/// <summary>
        /// Construct instance for exception "Connection to host failed."
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public ConnectionFail (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public ConnectionFail (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}

		/// <summary>
        /// User data associated with the exception.
        /// </summary>	
		public object UserData;

		/// <summary>
        /// Construct instance for exception using a userdata parameter of
		/// type ExceptionData and the format string "Connection to host [{0}] Failed."
        /// </summary>		
        /// <param name="Object">User data</param>	
		public ConnectionFail (ExceptionData Object) : 
				base (global::System.String.Format ("Connection to host [{0}] Failed.",
					Object.String					)) => UserData = Object;


		/// <summary>
        /// Construct instance for exception using a userdata parameter of
		/// type ExceptionData and the format string "Connection to host [{0}] Failed."
        /// </summary>		
        /// <param name="Object">User data</param>	
		/// <param name="Inner">Inner Exception</param>	
		public ConnectionFail (ExceptionData Object, System.Exception Inner) : 
				base (global::System.String.Format ("Connection to host [{0}] Failed.",
					Object.String					), Inner) => UserData = Object;



		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new ConnectionFail(Reason as string);
				}
			else if (Reason as ExceptionData != null) {
				return new ConnectionFail(Reason as ExceptionData);
				}
			else {
				return new ConnectionFail();
				}
            }
        }


    /// <summary>
    /// A serialized data stream contains a type tag describing an abstract type that cannot be constructed.
    /// </summary>
    [Serializable]
	public class CannotCreateAbstract : global::System.Exception {

		/// <summary>
        /// Construct instance for exception "Deserialzer encountered tag describing abstract type"
        /// </summary>		
		public CannotCreateAbstract () : base ("Deserialzer encountered tag describing abstract type") {
			}
        
		/// <summary>
        /// Construct instance for exception "Deserialzer encountered tag describing abstract type"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public CannotCreateAbstract (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public CannotCreateAbstract (string Description, System.Exception Inner) : 
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
				return new CannotCreateAbstract(Reason as string);
				}
			else {
				return new CannotCreateAbstract();
				}
            }
        }


    /// <summary>
    /// An unknown tag was encountered.
    /// </summary>
    [Serializable]
	public class UnknownTag : global::System.Exception {

		/// <summary>
        /// Construct instance for exception "Deserialzer encountered unknown tag"
        /// </summary>		
		public UnknownTag () : base ("Deserialzer encountered unknown tag") {
			}
        
		/// <summary>
        /// Construct instance for exception "Deserialzer encountered unknown tag"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public UnknownTag (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public UnknownTag (string Description, System.Exception Inner) : 
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
				return new UnknownTag(Reason as string);
				}
			else {
				return new UnknownTag();
				}
            }
        }


    /// <summary>
    /// The input is not valid in the specified encoding.
    /// </summary>
    [Serializable]
	public class InvalidInput : global::System.Exception {

		/// <summary>
        /// Construct instance for exception "Deserialzer encountered invalid input"
        /// </summary>		
		public InvalidInput () : base ("Deserialzer encountered invalid input") {
			}
        
		/// <summary>
        /// Construct instance for exception "Deserialzer encountered invalid input"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public InvalidInput (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public InvalidInput (string Description, System.Exception Inner) : 
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
				return new InvalidInput(Reason as string);
				}
			else {
				return new InvalidInput();
				}
            }
        }


    /// <summary>
    /// Data length did not match data presented.
    /// </summary>
    [Serializable]
	public class BadPartLength : global::System.Exception {

		/// <summary>
        /// Construct instance for exception "Data length did not match data presented."
        /// </summary>		
		public BadPartLength () : base ("Data length did not match data presented.") {
			}
        
		/// <summary>
        /// Construct instance for exception "Data length did not match data presented."
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public BadPartLength (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public BadPartLength (string Description, System.Exception Inner) : 
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
				return new BadPartLength(Reason as string);
				}
			else {
				return new BadPartLength();
				}
            }
        }


    /// <summary>
    /// Stream reader error, position not correctly marked.
    /// </summary>
    [Serializable]
	public class StreamMarkerError : global::System.Exception {

		/// <summary>
        /// Construct instance for exception "Stream reader error, position not correctly marked."
        /// </summary>		
		public StreamMarkerError () : base ("Stream reader error, position not correctly marked.") {
			}
        
		/// <summary>
        /// Construct instance for exception "Stream reader error, position not correctly marked."
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public StreamMarkerError (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public StreamMarkerError (string Description, System.Exception Inner) : 
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
				return new StreamMarkerError(Reason as string);
				}
			else {
				return new StreamMarkerError();
				}
            }
        }


    /// <summary>
    /// </summary>
    [Serializable]
	public class DictionaryInitialization : global::System.Exception {

		/// <summary>
        /// Construct instance for exception "An attempt was made to deserialize an object without initializing the dictionary"
        /// </summary>		
		public DictionaryInitialization () : base ("An attempt was made to deserialize an object without initializing the dictionary") {
			}
        
		/// <summary>
        /// Construct instance for exception "An attempt was made to deserialize an object without initializing the dictionary"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public DictionaryInitialization (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public DictionaryInitialization (string Description, System.Exception Inner) : 
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
				return new DictionaryInitialization(Reason as string);
				}
			else {
				return new DictionaryInitialization();
				}
            }
        }


	}
