using System;
using Goedel.Utilities;



namespace Goedel.Mesh {


    /// <summary>
    /// </summary>
    public class MeshException : global::System.Exception {

		/// <summary>
        /// Construct instance for exception "Error occurred in Mesh library"
        /// </summary>		
		public MeshException () : base ("Error occurred in Mesh library") {
			}
        
		/// <summary>
        /// Construct instance for exception "Error occurred in Mesh library"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public MeshException (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public MeshException (string Description, System.Exception Inner) : 
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
				return new MeshException(Reason as string);
				}
			else {
				return new MeshException();
				}
            }
        }


    /// <summary>
    /// </summary>
    public class ProfileInvalid : MeshException {

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
    /// </summary>
    public class InvalidResponse : MeshException {

		/// <summary>
        /// Construct instance for exception "Invalid response from server"
        /// </summary>		
		public InvalidResponse () : base ("Invalid response from server") {
			}
        
		/// <summary>
        /// Construct instance for exception "Invalid response from server"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public InvalidResponse (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public InvalidResponse (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new InvalidResponse(Reason as string);
				}
			else {
				return new InvalidResponse();
				}
            }
        }


    /// <summary>
    /// </summary>
    public class ProfileNotFound : MeshException {

		/// <summary>
        /// Construct instance for exception "Profile not found"
        /// </summary>		
		public ProfileNotFound () : base ("Profile not found") {
			}
        
		/// <summary>
        /// Construct instance for exception "Profile not found"
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
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new ProfileNotFound(Reason as string);
				}
			else {
				return new ProfileNotFound();
				}
            }
        }


    /// <summary>
    /// </summary>
    public class NotValidProfile : MeshException {

		/// <summary>
        /// Construct instance for exception "Profile is not valid"
        /// </summary>		
		public NotValidProfile () : base ("Profile is not valid") {
			}
        
		/// <summary>
        /// Construct instance for exception "Profile is not valid"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public NotValidProfile (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public NotValidProfile (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new NotValidProfile(Reason as string);
				}
			else {
				return new NotValidProfile();
				}
            }
        }


    /// <summary>
    /// </summary>
    public class PublicKeyNotFound : MeshException {

		/// <summary>
        /// Construct instance for exception "Public key could not be found"
        /// </summary>		
		public PublicKeyNotFound () : base ("Public key could not be found") {
			}
        
		/// <summary>
        /// Construct instance for exception "Public key could not be found"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public PublicKeyNotFound (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public PublicKeyNotFound (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new PublicKeyNotFound(Reason as string);
				}
			else {
				return new PublicKeyNotFound();
				}
            }
        }


    /// <summary>
    /// </summary>
    public class PrivateKeyNotFound : MeshException {

		/// <summary>
        /// Construct instance for exception "Private key could not be found"
        /// </summary>		
		public PrivateKeyNotFound () : base ("Private key could not be found") {
			}
        
		/// <summary>
        /// Construct instance for exception "Private key could not be found"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public PrivateKeyNotFound (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public PrivateKeyNotFound (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new PrivateKeyNotFound(Reason as string);
				}
			else {
				return new PrivateKeyNotFound();
				}
            }
        }


    /// <summary>
    /// </summary>
    public class KeyFingerprintMismatch : MeshException {

		/// <summary>
        /// Construct instance for exception "Key does not match fingerprint"
        /// </summary>		
		public KeyFingerprintMismatch () : base ("Key does not match fingerprint") {
			}
        
		/// <summary>
        /// Construct instance for exception "Key does not match fingerprint"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public KeyFingerprintMismatch (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public KeyFingerprintMismatch (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new KeyFingerprintMismatch(Reason as string);
				}
			else {
				return new KeyFingerprintMismatch();
				}
            }
        }


    /// <summary>
    /// </summary>
    public class InvalidProfileSignature : MeshException {

		/// <summary>
        /// Construct instance for exception "Profile signature is invalid"
        /// </summary>		
		public InvalidProfileSignature () : base ("Profile signature is invalid") {
			}
        
		/// <summary>
        /// Construct instance for exception "Profile signature is invalid"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public InvalidProfileSignature (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public InvalidProfileSignature (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new InvalidProfileSignature(Reason as string);
				}
			else {
				return new InvalidProfileSignature();
				}
            }
        }


    /// <summary>
    /// </summary>
    public class NotAdministrationDevice : MeshException {

		/// <summary>
        /// Construct instance for exception "Administration operation attempted on non administration device"
        /// </summary>		
		public NotAdministrationDevice () : base ("Administration operation attempted on non administration device") {
			}
        
		/// <summary>
        /// Construct instance for exception "Administration operation attempted on non administration device"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public NotAdministrationDevice (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public NotAdministrationDevice (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new NotAdministrationDevice(Reason as string);
				}
			else {
				return new NotAdministrationDevice();
				}
            }
        }


    /// <summary>
    /// </summary>
    public class InvalidProfileChain : MeshException {

		/// <summary>
        /// Construct instance for exception "Profile chain is not valid"
        /// </summary>		
		public InvalidProfileChain () : base ("Profile chain is not valid") {
			}
        
		/// <summary>
        /// Construct instance for exception "Profile chain is not valid"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public InvalidProfileChain (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public InvalidProfileChain (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new InvalidProfileChain(Reason as string);
				}
			else {
				return new InvalidProfileChain();
				}
            }
        }


    /// <summary>
    /// </summary>
    public class NoMasterProfile : MeshException {

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
    public class NoDeviceProfile : MeshException {

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


	}
