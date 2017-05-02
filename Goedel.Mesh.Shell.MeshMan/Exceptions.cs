using System;
using Goedel.Utilities;



namespace Goedel.Mesh.MeshMan {


    /// <summary>
    /// </summary>
    public class MeshManException : global::System.Exception {

		/// <summary>
        /// Construct instance for exception "Error occurred in MeshMan"
        /// </summary>		
		public MeshManException () : base ("Error occurred in MeshMan") {
			}
        
		/// <summary>
        /// Construct instance for exception "Error occurred in MeshMan"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public MeshManException (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public MeshManException (string Description, System.Exception Inner) : 
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
				return new MeshManException(Reason as string);
				}
			else {
				return new MeshManException();
				}
            }
        }


    /// <summary>
    /// </summary>
    public class NoMasterProfile : MeshManException {

		/// <summary>
        /// Construct instance for exception "No master profile"
        /// </summary>		
		public NoMasterProfile () : base ("No master profile") {
			}
        
		/// <summary>
        /// Construct instance for exception "No master profile"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public NoMasterProfile (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public NoMasterProfile (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new NoMasterProfile(Reason as string);
				}
			else {
				return new NoMasterProfile();
				}
            }
        }


    /// <summary>
    /// </summary>
    public class NoPersonalProfile : MeshManException {

		/// <summary>
        /// Construct instance for exception "No personal profile"
        /// </summary>		
		public NoPersonalProfile () : base ("No personal profile") {
			}
        
		/// <summary>
        /// Construct instance for exception "No personal profile"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public NoPersonalProfile (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public NoPersonalProfile (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new NoPersonalProfile(Reason as string);
				}
			else {
				return new NoPersonalProfile();
				}
            }
        }


    /// <summary>
    /// </summary>
    public class NoDeviceProfile : MeshManException {

		/// <summary>
        /// Construct instance for exception "No device profile"
        /// </summary>		
		public NoDeviceProfile () : base ("No device profile") {
			}
        
		/// <summary>
        /// Construct instance for exception "No device profile"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public NoDeviceProfile (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public NoDeviceProfile (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new NoDeviceProfile(Reason as string);
				}
			else {
				return new NoDeviceProfile();
				}
            }
        }


    /// <summary>
    /// </summary>
    public class NoPortalAccount : MeshManException {

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
    public class InvalidPortalAddress : MeshManException {

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
    public class PortalConnectFail : MeshManException {

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
    public class PortalRefusedRequest : MeshManException {

		/// <summary>
        /// Construct instance for exception "Portal refused request XXX"
        /// </summary>		
		public PortalRefusedRequest () : base ("Portal refused request XXX") {
			}
        
		/// <summary>
        /// Construct instance for exception "Portal refused request XXX"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public PortalRefusedRequest (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public PortalRefusedRequest (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new PortalRefusedRequest(Reason as string);
				}
			else {
				return new PortalRefusedRequest();
				}
            }
        }


    /// <summary>
    /// </summary>
    public class ProfileNotFound : MeshManException {

		/// <summary>
        /// Construct instance for exception "Could not find profile"
        /// </summary>		
		public ProfileNotFound () : base ("Could not find profile") {
			}
        
		/// <summary>
        /// Construct instance for exception "Could not find profile"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public ProfileNotFound (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public ProfileNotFound (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}


		/// <summary>
        /// Construct instance for exception using a userdata parameter of
		/// type ExceptionData and the format string "The personal profile {0} could not be found"
        /// </summary>		
        /// <param name="Object">User data</param>	
		public ProfileNotFound (ExceptionData Object) : 
				base (global::System.String.Format ("The personal profile {0} could not be found",
					Object.String					)) {
			UserData = Object;
			}

		/// <summary>
        /// Construct instance for exception using a userdata parameter of
		/// type ExceptionData and the format string "The personal profile {0} could not be found"
        /// </summary>		
        /// <param name="Object">User data</param>	
		/// <param name="Inner">Inner Exception</param>	
		public ProfileNotFound (ExceptionData Object, System.Exception Inner) : 
				base (global::System.String.Format ("The personal profile {0} could not be found",
					Object.String					), Inner) {
			UserData = Object;
			}



		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new ProfileNotFound(Reason as string);
				}
			else if (Reason as ExceptionData != null) {
				return new ProfileNotFound(Reason as ExceptionData);
				}
			else {
				return new ProfileNotFound();
				}
            }
        }


    /// <summary>
    /// </summary>
    public class PublicationRequestRefused : MeshManException {

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
    /// </summary>
    public class InvalidEscrowParameters : MeshManException {

		/// <summary>
        /// Construct instance for exception "Invalid escrow parameters"
        /// </summary>		
		public InvalidEscrowParameters () : base ("Invalid escrow parameters") {
			}
        
		/// <summary>
        /// Construct instance for exception "Invalid escrow parameters"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public InvalidEscrowParameters (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public InvalidEscrowParameters (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new InvalidEscrowParameters(Reason as string);
				}
			else {
				return new InvalidEscrowParameters();
				}
            }
        }


    /// <summary>
    /// </summary>
    public class InvalidShares : MeshManException {

		/// <summary>
        /// Construct instance for exception "An error occurred"
        /// </summary>		
		public InvalidShares () : base ("An error occurred") {
			}
        
		/// <summary>
        /// Construct instance for exception "An error occurred"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public InvalidShares (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public InvalidShares (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}


		/// <summary>
        /// Construct instance for exception using a userdata parameter of
		/// type ExceptionData and the format string "The number of shares is invalid: {0}"
        /// </summary>		
        /// <param name="Object">User data</param>	
		public InvalidShares (ExceptionData Object) : 
				base (global::System.String.Format ("The number of shares is invalid: {0}",
					Object.Int					)) {
			UserData = Object;
			}

		/// <summary>
        /// Construct instance for exception using a userdata parameter of
		/// type ExceptionData and the format string "The number of shares is invalid: {0}"
        /// </summary>		
        /// <param name="Object">User data</param>	
		/// <param name="Inner">Inner Exception</param>	
		public InvalidShares (ExceptionData Object, System.Exception Inner) : 
				base (global::System.String.Format ("The number of shares is invalid: {0}",
					Object.Int					), Inner) {
			UserData = Object;
			}



		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new InvalidShares(Reason as string);
				}
			else if (Reason as ExceptionData != null) {
				return new InvalidShares(Reason as ExceptionData);
				}
			else {
				return new InvalidShares();
				}
            }
        }


    /// <summary>
    /// </summary>
    public class InvalidQuorum : MeshManException {

		/// <summary>
        /// Construct instance for exception "An error occurred"
        /// </summary>		
		public InvalidQuorum () : base ("An error occurred") {
			}
        
		/// <summary>
        /// Construct instance for exception "An error occurred"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public InvalidQuorum (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public InvalidQuorum (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}


		/// <summary>
        /// Construct instance for exception using a userdata parameter of
		/// type ExceptionData and the format string "The quorum is invalid: {0}"
        /// </summary>		
        /// <param name="Object">User data</param>	
		public InvalidQuorum (ExceptionData Object) : 
				base (global::System.String.Format ("The quorum is invalid: {0}",
					Object.Int					)) {
			UserData = Object;
			}

		/// <summary>
        /// Construct instance for exception using a userdata parameter of
		/// type ExceptionData and the format string "The quorum is invalid: {0}"
        /// </summary>		
        /// <param name="Object">User data</param>	
		/// <param name="Inner">Inner Exception</param>	
		public InvalidQuorum (ExceptionData Object, System.Exception Inner) : 
				base (global::System.String.Format ("The quorum is invalid: {0}",
					Object.Int					), Inner) {
			UserData = Object;
			}



		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new InvalidQuorum(Reason as string);
				}
			else if (Reason as ExceptionData != null) {
				return new InvalidQuorum(Reason as ExceptionData);
				}
			else {
				return new InvalidQuorum();
				}
            }
        }


	}
