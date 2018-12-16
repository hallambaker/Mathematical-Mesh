using System;
using Goedel.Utilities;



namespace Goedel.Cryptography.Ticket {


    /// <summary>
    /// </summary>
    [Serializable]
	public class TicketException : global::System.Exception {

		/// <summary>
        /// Construct instance for exception "A cryptographic ticket exception occurred"
        /// </summary>		
		public TicketException () : base ("A cryptographic ticket exception occurred") {
			}
        
		/// <summary>
        /// Construct instance for exception "A cryptographic ticket exception occurred"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public TicketException (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public TicketException (string Description, System.Exception Inner) : 
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
				return new TicketException(Reason as string);
				}
			else {
				return new TicketException();
				}
            }
        }


    /// <summary>
    /// The ticket was in an unrecognized format or has been corrupted.
    /// </summary>
    [Serializable]
	public class BadTicket : TicketException {

		/// <summary>
        /// Construct instance for exception "The ticket could not be read"
        /// </summary>		
		public BadTicket () : base ("The ticket could not be read") {
			}
        
		/// <summary>
        /// Construct instance for exception "The ticket could not be read"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public BadTicket (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public BadTicket (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new BadTicket(Reason as string);
				}
			else {
				return new BadTicket();
				}
            }
        }


	}
