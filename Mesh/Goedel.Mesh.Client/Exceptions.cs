using System;
using Goedel.Utilities;



namespace Goedel.Mesh.Client {


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
    /// The action requested can only be performed by an administrator account
    /// </summary>
    [Serializable]
	public class NotAdministrator : global::System.Exception {

		/// <summary>
        /// Construct instance for exception "An error occurred"
        /// </summary>		
		public NotAdministrator () : base ("An error occurred") {
			}
        
		/// <summary>
        /// Construct instance for exception "An error occurred"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public NotAdministrator (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public NotAdministrator (string Description, System.Exception Inner) : 
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
				return new NotAdministrator(Reason as string);
				}
			else {
				return new NotAdministrator();
				}
            }
        }


    /// <summary>
    /// The attempt to synchronize with the service failed.
    /// </summary>
    [Serializable]
	public class SyncFailed : global::System.Exception {

		/// <summary>
        /// Construct instance for exception "An error occurred"
        /// </summary>		
		public SyncFailed () : base ("An error occurred") {
			}
        
		/// <summary>
        /// Construct instance for exception "An error occurred"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public SyncFailed (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public SyncFailed (string Description, System.Exception Inner) : 
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
				return new SyncFailed(Reason as string);
				}
			else {
				return new SyncFailed();
				}
            }
        }


    /// <summary>
    /// Error occurred in Gateway
    /// </summary>
    [Serializable]
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
    /// No Portal account specified
    /// </summary>
    [Serializable]
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
    /// Could not connect to portal
    /// </summary>
    [Serializable]
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
    /// Portal refused profile publication request
    /// </summary>
    [Serializable]
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


    /// <summary>
    /// The connection request did not complete
    /// </summary>
    [Serializable]
	public class Connection : global::System.Exception {

		/// <summary>
        /// Construct instance for exception "Connection did not complete"
        /// </summary>		
		public Connection () : base ("Connection did not complete") {
			}
        
		/// <summary>
        /// Construct instance for exception "Connection did not complete"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public Connection (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public Connection (string Description, System.Exception Inner) : 
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
				return new Connection(Reason as string);
				}
			else {
				return new Connection();
				}
            }
        }


    /// <summary>
    /// The connection request was refused
    /// </summary>
    [Serializable]
	public class ConnectionRefused : Connection {

		/// <summary>
        /// Construct instance for exception "The connection request was refused"
        /// </summary>		
		public ConnectionRefused () : base ("The connection request was refused") {
			}
        
		/// <summary>
        /// Construct instance for exception "The connection request was refused"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public ConnectionRefused (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public ConnectionRefused (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new ConnectionRefused(Reason as string);
				}
			else {
				return new ConnectionRefused();
				}
            }
        }


    /// <summary>
    /// The connection request is still pending
    /// </summary>
    [Serializable]
	public class ConnectionPending : Connection {

		/// <summary>
        /// Construct instance for exception "The connection request is still pending"
        /// </summary>		
		public ConnectionPending () : base ("The connection request is still pending") {
			}
        
		/// <summary>
        /// Construct instance for exception "The connection request is still pending"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public ConnectionPending (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public ConnectionPending (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new ConnectionPending(Reason as string);
				}
			else {
				return new ConnectionPending();
				}
            }
        }


    /// <summary>
    /// The connection request is still pending
    /// </summary>
    [Serializable]
	public class ConnectionExpired : Connection {

		/// <summary>
        /// Construct instance for exception "The connection request is still pending"
        /// </summary>		
		public ConnectionExpired () : base ("The connection request is still pending") {
			}
        
		/// <summary>
        /// Construct instance for exception "The connection request is still pending"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public ConnectionExpired (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public ConnectionExpired (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new ConnectionExpired(Reason as string);
				}
			else {
				return new ConnectionExpired();
				}
            }
        }


    /// <summary>
    /// The connection request is still pending
    /// </summary>
    [Serializable]
	public class ConnectionAccountUnknown : Connection {

		/// <summary>
        /// Construct instance for exception "The connection request is still pending"
        /// </summary>		
		public ConnectionAccountUnknown () : base ("The connection request is still pending") {
			}
        
		/// <summary>
        /// Construct instance for exception "The connection request is still pending"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public ConnectionAccountUnknown (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public ConnectionAccountUnknown (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new ConnectionAccountUnknown(Reason as string);
				}
			else {
				return new ConnectionAccountUnknown();
				}
            }
        }


	}
