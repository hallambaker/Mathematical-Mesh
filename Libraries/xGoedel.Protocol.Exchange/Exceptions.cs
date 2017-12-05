using System;
using Goedel.Utilities;



namespace Goedel.Protocol.Exchange {


    /// <summary>
    /// The service address specified is invalid.	
    /// </summary>
    public class InvalidAddress : global::System.Exception {

		/// <summary>
        /// Construct instance for exception "Invalid service address"
        /// </summary>		
		public InvalidAddress () : base ("Invalid service address") {
			}
        
		/// <summary>
        /// Construct instance for exception "Invalid service address"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public InvalidAddress (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public InvalidAddress (string Description, System.Exception Inner) : 
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
				return new InvalidAddress(Reason as string);
				}
			else {
				return new InvalidAddress();
				}
            }
        }


	}
