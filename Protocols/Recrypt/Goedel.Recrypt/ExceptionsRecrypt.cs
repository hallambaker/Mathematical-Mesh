using System;
using Goedel.Utilities;



namespace Goedel.Recrypt {


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
    /// There is no recryption record for the specified key combination
    /// </summary>
    public class NoRecryptionRecord : RecryptException {

		/// <summary>
        /// Construct instance for exception "There is no recryption record for the specified key combination"
        /// </summary>		
		public NoRecryptionRecord () : base ("There is no recryption record for the specified key combination") {
			}
        
		/// <summary>
        /// Construct instance for exception "There is no recryption record for the specified key combination"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public NoRecryptionRecord (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public NoRecryptionRecord (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new NoRecryptionRecord(Reason as string);
				}
			else {
				return new NoRecryptionRecord();
				}
            }
        }


	}
