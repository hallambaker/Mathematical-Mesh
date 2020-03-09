using System;
using Goedel.Utilities;



namespace Goedel.Mesh.Services {


    /// <summary>
    /// An internal assertion check failed.
    /// </summary>
    [Serializable]
	public class ServicesTBS : global::System.Exception {

		/// <summary>
        /// Construct instance for exception "An internal error occurred"
        /// </summary>		
		public ServicesTBS () : base ("An internal error occurred") {
			}
        
		/// <summary>
        /// Construct instance for exception "An internal error occurred"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public ServicesTBS (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public ServicesTBS (string Description, System.Exception Inner) : 
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
				return new ServicesTBS(Reason as string);
				}
			else {
				return new ServicesTBS();
				}
            }
        }


	}
