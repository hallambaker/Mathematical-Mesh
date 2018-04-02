using System;
using Goedel.Utilities;



namespace Goedel.Account {


    /// <summary>
    /// </summary>
    public class AccountException : global::System.Exception {

		/// <summary>
        /// Construct instance for exception "Error occurred in Account library"
        /// </summary>		
		public AccountException () : base ("Error occurred in Account library") {
			}
        
		/// <summary>
        /// Construct instance for exception "Error occurred in Account library"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public AccountException (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public AccountException (string Description, System.Exception Inner) : 
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
				return new AccountException(Reason as string);
				}
			else {
				return new AccountException();
				}
            }
        }


    /// <summary>
    /// </summary>
    public class ProfileInvalid : AccountException {

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


	}
