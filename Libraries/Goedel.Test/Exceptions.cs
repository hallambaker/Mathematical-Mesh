using System;



namespace Goedel.Test {


    /// <summary>
    /// An comparison check on the produced result failed
    /// </summary>
    [Serializable]
	public class Compare : global::System.Exception {

		/// <summary>
        /// Construct instance for exception "An comparison check on the produced result failed"
        /// </summary>		
		public Compare () : base ("An comparison check on the produced result failed") {
			}
        
		/// <summary>
        /// Construct instance for exception "An comparison check on the produced result failed"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public Compare (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public Compare (string Description, System.Exception Inner) : 
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
				return new Compare(Reason as string);
				}
			else {
				return new Compare();
				}
            }
        }


	}
