using System;
using Goedel.Utilities;



namespace Goedel.Mesh.Platform {


    /// <summary>
    /// An internal assertion check failed.
    /// </summary>
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
    /// </summary>
    public class Gateway : global::System.Exception {

		/// <summary>
        /// Construct instance for exception "Error occurred in Gateway"
        /// </summary>		
		public Gateway () : base ("Error occurred in Gateway") {
			}
        
		/// <summary>
        /// Construct instance for exception "Error occurred in Gateway"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public Gateway (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public Gateway (string Description, System.Exception Inner) : 
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
				return new Gateway(Reason as string);
				}
			else {
				return new Gateway();
				}
            }
        }


    /// <summary>
    /// </summary>
    public class NoPortalAccount : Gateway {

		/// <summary>
        /// Construct instance for exception "No Portal account specified"
        /// </summary>		
		public NoPortalAccount () : base ("No Portal account specified") {
			}
        
		/// <summary>
        /// Construct instance for exception "No Portal account specified"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public NoPortalAccount (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public NoPortalAccount (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new NoPortalAccount(Reason as string);
				}
			else {
				return new NoPortalAccount();
				}
            }
        }


    /// <summary>
    /// </summary>
    public class InvalidPortalAddress : Gateway {

		/// <summary>
        /// Construct instance for exception "Not a valid portal address"
        /// </summary>		
		public InvalidPortalAddress () : base ("Not a valid portal address") {
			}
        
		/// <summary>
        /// Construct instance for exception "Not a valid portal address"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public InvalidPortalAddress (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public InvalidPortalAddress (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new InvalidPortalAddress(Reason as string);
				}
			else {
				return new InvalidPortalAddress();
				}
            }
        }


    /// <summary>
    /// </summary>
    public class PortalConnectFail : Gateway {

		/// <summary>
        /// Construct instance for exception "Could not connect to portal"
        /// </summary>		
		public PortalConnectFail () : base ("Could not connect to portal") {
			}
        
		/// <summary>
        /// Construct instance for exception "Could not connect to portal"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public PortalConnectFail (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public PortalConnectFail (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new PortalConnectFail(Reason as string);
				}
			else {
				return new PortalConnectFail();
				}
            }
        }


    /// <summary>
    /// </summary>
    public class PublicationRequestRefused : Gateway {

		/// <summary>
        /// Construct instance for exception "Portal refused profile publication request"
        /// </summary>		
		public PublicationRequestRefused () : base ("Portal refused profile publication request") {
			}
        
		/// <summary>
        /// Construct instance for exception "Portal refused profile publication request"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public PublicationRequestRefused (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public PublicationRequestRefused (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new PublicationRequestRefused(Reason as string);
				}
			else {
				return new PublicationRequestRefused();
				}
            }
        }


	}
