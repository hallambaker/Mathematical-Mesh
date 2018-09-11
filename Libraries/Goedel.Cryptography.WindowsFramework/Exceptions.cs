using System;
using Goedel.Utilities;



namespace Goedel.Cryptography.Windows {


    /// <summary>
    /// Encrypted data could not be decrypted. 
    /// </summary>
    public class DecryptionFailed : global::System.Exception {

		/// <summary>
        /// Construct instance for exception "Could not decrypt user data"
        /// </summary>		
		public DecryptionFailed () : base ("Could not decrypt user data") {
			}
        
		/// <summary>
        /// Construct instance for exception "Could not decrypt user data"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public DecryptionFailed (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public DecryptionFailed (string Description, System.Exception Inner) : 
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
				return new DecryptionFailed(Reason as string);
				}
			else {
				return new DecryptionFailed();
				}
            }
        }


    /// <summary>
    /// Data could not be encrypted. 
    /// </summary>
    [Serializable]
    public class EncryptionFailed : global::System.Exception {

		/// <summary>
        /// Construct instance for exception "Could not encrypt user data"
        /// </summary>		
		public EncryptionFailed () : base ("Could not encrypt user data") {
			}
        
		/// <summary>
        /// Construct instance for exception "Could not encrypt user data"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public EncryptionFailed (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public EncryptionFailed (string Description, System.Exception Inner) : 
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
				return new EncryptionFailed(Reason as string);
				}
			else {
				return new EncryptionFailed();
				}
            }
        }


    /// <summary>
    /// Memory allocation failed.
    /// </summary>
    public class InsufficientMemory : global::System.Exception {

		/// <summary>
        /// Construct instance for exception "Memory allocation failed"
        /// </summary>		
		public InsufficientMemory () : base ("Memory allocation failed") {
			}
        
		/// <summary>
        /// Construct instance for exception "Memory allocation failed"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public InsufficientMemory (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public InsufficientMemory (string Description, System.Exception Inner) : 
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
				return new InsufficientMemory(Reason as string);
				}
			else {
				return new InsufficientMemory();
				}
            }
        }


	}
