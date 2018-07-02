using System;
using Goedel.Utilities;



namespace Goedel.Confirm {


    /// <summary>
    /// Error occurred in Recrypt library
    /// </summary>
    public class RecryptException : global::System.Exception {

		/// <summary>
        /// Construct instance for exception "Error occurred in Recrypt library"
        /// </summary>		
		public RecryptException () : base ("Error occurred in Recrypt library") {
			}
        
		/// <summary>
        /// Construct instance for exception "Error occurred in Recrypt library"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public RecryptException (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public RecryptException (string Description, System.Exception Inner) : 
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
				return new RecryptException(Reason as string);
				}
			else {
				return new RecryptException();
				}
            }
        }


    /// <summary>
    /// Profile not valid
    /// </summary>
    public class ProfileInvalid : RecryptException {

		/// <summary>
        /// Construct instance for exception "Profile not valid"
        /// </summary>		
		public ProfileInvalid () : base ("Profile not valid") {
			}
        
		/// <summary>
        /// Construct instance for exception "Profile not valid"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public ProfileInvalid (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public ProfileInvalid (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new ProfileInvalid(Reason as string);
				}
			else {
				return new ProfileInvalid();
				}
            }
        }


    /// <summary>
    /// The responder could not be found
    /// </summary>
    public class ResponderNotFound : RecryptException {

		/// <summary>
        /// Construct instance for exception "The responder could not be found"
        /// </summary>		
		public ResponderNotFound () : base ("The responder could not be found") {
			}
        
		/// <summary>
        /// Construct instance for exception "The responder could not be found"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public ResponderNotFound (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public ResponderNotFound (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new ResponderNotFound(Reason as string);
				}
			else {
				return new ResponderNotFound();
				}
            }
        }


    /// <summary>
    /// The enquiry could not be found
    /// </summary>
    public class BrokerIDNotFound : RecryptException {

		/// <summary>
        /// Construct instance for exception "The enquiry could not be found"
        /// </summary>		
		public BrokerIDNotFound () : base ("The enquiry could not be found") {
			}
        
		/// <summary>
        /// Construct instance for exception "The enquiry could not be found"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public BrokerIDNotFound (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public BrokerIDNotFound (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new BrokerIDNotFound(Reason as string);
				}
			else {
				return new BrokerIDNotFound();
				}
            }
        }


    /// <summary>
    /// The enquiry has already been responded to
    /// </summary>
    public class AlreadyResponded : RecryptException {

		/// <summary>
        /// Construct instance for exception "The enquiry has already been responded to"
        /// </summary>		
		public AlreadyResponded () : base ("The enquiry has already been responded to") {
			}
        
		/// <summary>
        /// Construct instance for exception "The enquiry has already been responded to"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public AlreadyResponded (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public AlreadyResponded (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new AlreadyResponded(Reason as string);
				}
			else {
				return new AlreadyResponded();
				}
            }
        }


	}
