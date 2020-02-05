using System;
using Goedel.Utilities;



namespace Goedel.Mesh.Shell {


    /// <summary>
    /// Generic error in Mesh Shell library
    /// </summary>
    [Serializable]
	public class MeshShellException : global::System.Exception {

		/// <summary>
        /// Construct instance for exception "Unknown error occured."
        /// </summary>		
		public MeshShellException () : base ("Unknown error occured.") {
			}
        
		/// <summary>
        /// Construct instance for exception "Unknown error occured."
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public MeshShellException (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public MeshShellException (string Description, System.Exception Inner) : 
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
				return new MeshShellException(Reason as string);
				}
			else {
				return new MeshShellException();
				}
            }
        }


    /// <summary>
    /// The calculated fingerprint did not match the expected value.
    /// </summary>
    [Serializable]
	public class DidNotMatchExpectedValue : MeshShellException {

		/// <summary>
        /// Construct instance for exception "The calculated fingerprint did not match the expected value."
        /// </summary>		
		public DidNotMatchExpectedValue () : base ("The calculated fingerprint did not match the expected value.") {
			}
        
		/// <summary>
        /// Construct instance for exception "The calculated fingerprint did not match the expected value."
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public DidNotMatchExpectedValue (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public DidNotMatchExpectedValue (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new DidNotMatchExpectedValue(Reason as string);
				}
			else {
				return new DidNotMatchExpectedValue();
				}
            }
        }


    /// <summary>
    /// Account not valid
    /// </summary>
    [Serializable]
	public class AccountNotFound : MeshShellException {

		/// <summary>
        /// Construct instance for exception "Profile not found"
        /// </summary>		
		public AccountNotFound () : base ("Profile not found") {
			}
        
		/// <summary>
        /// Construct instance for exception "Profile not found"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public AccountNotFound (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public AccountNotFound (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new AccountNotFound(Reason as string);
				}
			else {
				return new AccountNotFound();
				}
            }
        }


    /// <summary>
    /// Account not valid
    /// </summary>
    [Serializable]
	public class ProfileNotFound : MeshShellException {

		/// <summary>
        /// Construct instance for exception "No profile defined."
        /// </summary>		
		public ProfileNotFound () : base ("No profile defined.") {
			}
        
		/// <summary>
        /// Construct instance for exception "No profile defined."
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
    /// The directory could not be found
    /// </summary>
    [Serializable]
	public class DirectoryNotFound : MeshShellException {

		/// <summary>
        /// Construct instance for exception "The directory could not be found"
        /// </summary>		
		public DirectoryNotFound () : base ("The directory could not be found") {
			}
        
		/// <summary>
        /// Construct instance for exception "The directory could not be found"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public DirectoryNotFound (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public DirectoryNotFound (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new DirectoryNotFound(Reason as string);
				}
			else {
				return new DirectoryNotFound();
				}
            }
        }


    /// <summary>
    /// The directory could not be found
    /// </summary>
    [Serializable]
	public class FileNotFound : MeshShellException {

		/// <summary>
        /// Construct instance for exception "The file could not be found"
        /// </summary>		
		public FileNotFound () : base ("The file could not be found") {
			}
        
		/// <summary>
        /// Construct instance for exception "The file could not be found"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public FileNotFound (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public FileNotFound (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new FileNotFound(Reason as string);
				}
			else {
				return new FileNotFound();
				}
            }
        }


	}
