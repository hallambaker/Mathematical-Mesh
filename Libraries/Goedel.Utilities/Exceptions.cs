using System;
using Goedel.Utilities;



namespace Goedel.Utilities {


    /// <summary>
    /// This feature has not been implemented
    /// </summary>
    public class NYI : global::System.Exception {

		/// <summary>
        /// Construct instance for exception "The feature has not been implemented"
        /// </summary>		
		public NYI () : base ("The feature has not been implemented") {
			}
        
		/// <summary>
        /// Construct instance for exception "The feature has not been implemented"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public NYI (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public NYI (string Description, System.Exception Inner) : 
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
				return new NYI(Reason as string);
				}
			else {
				return new NYI();
				}
            }
        }


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
    /// The file could not be read.
    /// </summary>
    public class FileReadError : global::System.Exception {

		/// <summary>
        /// Construct instance for exception "The file could not be read"
        /// </summary>		
		public FileReadError () : base ("The file could not be read") {
			}
        
		/// <summary>
        /// Construct instance for exception "The file could not be read"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public FileReadError (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public FileReadError (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}

		/// <summary>
        /// User data associated with the exception.
        /// </summary>	
		public object UserData;

		/// <summary>
        /// Construct instance for exception using a userdata parameter of
		/// type ExceptionData and the format string "The file {0} could not be read"
        /// </summary>		
        /// <param name="Object">User data</param>	
		public FileReadError (ExceptionData Object) : 
				base (global::System.String.Format ("The file {0} could not be read",
					Object.String					)) {
			UserData = Object;
			}

		/// <summary>
        /// Construct instance for exception using a userdata parameter of
		/// type ExceptionData and the format string "The file {0} could not be read"
        /// </summary>		
        /// <param name="Object">User data</param>	
		/// <param name="Inner">Inner Exception</param>	
		public FileReadError (ExceptionData Object, System.Exception Inner) : 
				base (global::System.String.Format ("The file {0} could not be read",
					Object.String					), Inner) {
			UserData = Object;
			}



		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new FileReadError(Reason as string);
				}
			else if (Reason as ExceptionData != null) {
				return new FileReadError(Reason as ExceptionData);
				}
			else {
				return new FileReadError();
				}
            }
        }


	}
