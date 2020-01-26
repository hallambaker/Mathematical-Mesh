using System;



namespace Goedel.Mesh {


    /// <summary>
    /// An internal assertion check failed.
    /// </summary>
    [Serializable]
	public class Internal : global::System.Exception {

		/// <summary>
        /// Construct instance for exception "An internal error occurred"
        /// </summary>		
		public Internal () : base ("An internal error occurred") {
			}
        
		/// <summary>
        /// Construct instance for exception "An internal error occurred"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public Internal (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public Internal (string Description, System.Exception Inner) : 
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
				return new Internal(Reason as string);
				}
			else {
				return new Internal();
				}
            }
        }


    /// <summary>
    /// The profile presented was invalid.
    /// </summary>
    [Serializable]
	public class InvalidProfile : Internal {

		/// <summary>
        /// Construct instance for exception "The profile is invalid"
        /// </summary>		
		public InvalidProfile () : base ("The profile is invalid") {
			}
        
		/// <summary>
        /// Construct instance for exception "The profile is invalid"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public InvalidProfile (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public InvalidProfile (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new InvalidProfile(Reason as string);
				}
			else {
				return new InvalidProfile();
				}
            }
        }


    /// <summary>
    /// The requestor is not authorized for the specified operation
    /// </summary>
    [Serializable]
	public class NotAuthorized : Internal {

		/// <summary>
        /// Construct instance for exception "The requestor is not authorized for the specified operation"
        /// </summary>		
		public NotAuthorized () : base ("The requestor is not authorized for the specified operation") {
			}
        
		/// <summary>
        /// Construct instance for exception "The requestor is not authorized for the specified operation"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public NotAuthorized (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public NotAuthorized (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new NotAuthorized(Reason as string);
				}
			else {
				return new NotAuthorized();
				}
            }
        }


    /// <summary>
    /// The request is not authenticated  for the specified operation
    /// </summary>
    [Serializable]
	public class NotAuthenticated : Internal {

		/// <summary>
        /// Construct instance for exception "The request is not authenticated for the specified operation"
        /// </summary>		
		public NotAuthenticated () : base ("The request is not authenticated for the specified operation") {
			}
        
		/// <summary>
        /// Construct instance for exception "The request is not authenticated for the specified operation"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public NotAuthenticated (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public NotAuthenticated (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new NotAuthenticated(Reason as string);
				}
			else {
				return new NotAuthenticated();
				}
            }
        }


    /// <summary>
    /// Mesh Messages MUST specify a valid message ID.
    /// </summary>
    [Serializable]
	public class InvalidMessageID : Internal {

		/// <summary>
        /// Construct instance for exception "Mesh Messages MUST specify a valid message ID"
        /// </summary>		
		public InvalidMessageID () : base ("Mesh Messages MUST specify a valid message ID") {
			}
        
		/// <summary>
        /// Construct instance for exception "Mesh Messages MUST specify a valid message ID"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public InvalidMessageID (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public InvalidMessageID (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new InvalidMessageID(Reason as string);
				}
			else {
				return new InvalidMessageID();
				}
            }
        }


	}
