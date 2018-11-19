using System;
using Goedel.Utilities;



namespace Goedel.Mesh {


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
    /// The profile presented was invalid.
    /// </summary>
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


	}
