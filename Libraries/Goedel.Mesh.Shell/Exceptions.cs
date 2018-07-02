using System;
using Goedel.Utilities;



namespace Goedel.Mesh.Shell {


    /// <summary>
    /// Generic error in Mesh Shell library
    /// </summary>
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
    /// Account not valid
    /// </summary>
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


	}
