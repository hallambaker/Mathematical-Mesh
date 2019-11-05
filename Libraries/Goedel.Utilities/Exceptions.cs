
/* Unmerged change from project 'Goedel.Utilities'
Before:
using System;
using Goedel.Utilities;
After:
using Goedel.Utilities;

using System;
*/
using System;



namespace Goedel.Utilities {


    /// <summary>
    /// This feature has not been implemented
    /// </summary>
    [Serializable]
    public class NYI : global::System.Exception {

        /// <summary>
        /// Construct instance for exception "The feature has not been implemented"
        /// </summary>		
        public NYI() : base("The feature has not been implemented") {
            }

        /// <summary>
        /// Construct instance for exception "The feature has not been implemented"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        public NYI(string Description) : base(Description) {
            }

        /// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        /// <param name="Inner">Inner Exception</param>	
        public NYI(string Description, System.Exception Inner) :
                base(Description, Inner) {
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
    [Serializable]
    public class Internal : global::System.Exception {

        /// <summary>
        /// Construct instance for exception "An internal error occurred"
        /// </summary>		
        public Internal() : base("An internal error occurred") {
            }

        /// <summary>
        /// Construct instance for exception "An internal error occurred"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        public Internal(string Description) : base(Description) {
            }

        /// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        /// <param name="Inner">Inner Exception</param>	
        public Internal(string Description, System.Exception Inner) :
                base(Description, Inner) {
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
    [Serializable]
    public class FileReadError : global::System.Exception {

        /// <summary>
        /// Construct instance for exception "The file could not be read"
        /// </summary>		
        public FileReadError() : base("The file could not be read") {
            }

        /// <summary>
        /// Construct instance for exception "The file could not be read"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        public FileReadError(string Description) : base(Description) {
            }

        /// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        /// <param name="Inner">Inner Exception</param>	
        public FileReadError(string Description, System.Exception Inner) :
                base(Description, Inner) {
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
        public FileReadError(ExceptionData Object) :
                base(global::System.String.Format("The file {0} could not be read",
                    Object.String)) => UserData = Object;


        /// <summary>
        /// Construct instance for exception using a userdata parameter of
        /// type ExceptionData and the format string "The file {0} could not be read"
        /// </summary>		
        /// <param name="Object">User data</param>	
        /// <param name="Inner">Inner Exception</param>	
        public FileReadError(ExceptionData Object, System.Exception Inner) :
                base(global::System.String.Format("The file {0} could not be read",
                    Object.String), Inner) => UserData = Object;




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


    /// <summary>
    /// A call was made to a routine that has not yet been made
    /// 64 bit clean with a value that exceeds the Int32 limits.
    /// </summary>
    [Serializable]
    public class Not64Bit : global::System.Exception {

        /// <summary>
        /// Construct instance for exception "Item too large"
        /// </summary>		
        public Not64Bit() : base("Item too large") {
            }

        /// <summary>
        /// Construct instance for exception "Item too large"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        public Not64Bit(string Description) : base(Description) {
            }

        /// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        /// <param name="Inner">Inner Exception</param>	
        public Not64Bit(string Description, System.Exception Inner) :
                base(Description, Inner) {
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
                return new Not64Bit(Reason as string);
                }
            else {
                return new Not64Bit();
                }
            }
        }


    /// <summary>
    /// </summary>
    [Serializable]
    public class EnvironmentVariableRequired : global::System.Exception {

        /// <summary>
        /// Construct instance for exception "A required environment variable is undefined."
        /// </summary>		
        public EnvironmentVariableRequired() : base("A required environment variable is undefined.") {
            }

        /// <summary>
        /// Construct instance for exception "A required environment variable is undefined."
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        public EnvironmentVariableRequired(string Description) : base(Description) {
            }

        /// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        /// <param name="Inner">Inner Exception</param>	
        public EnvironmentVariableRequired(string Description, System.Exception Inner) :
                base(Description, Inner) {
            }

        /// <summary>
        /// User data associated with the exception.
        /// </summary>	
        public object UserData;

        /// <summary>
        /// Construct instance for exception using a userdata parameter of
        /// type ExceptionData and the format string "The environment variable {0} must be defined"
        /// </summary>		
        /// <param name="Object">User data</param>	
        public EnvironmentVariableRequired(ExceptionData Object) :
                base(global::System.String.Format("The environment variable {0} must be defined",
                    Object.String)) => UserData = Object;


        /// <summary>
        /// Construct instance for exception using a userdata parameter of
        /// type ExceptionData and the format string "The environment variable {0} must be defined"
        /// </summary>		
        /// <param name="Object">User data</param>	
        /// <param name="Inner">Inner Exception</param>	
        public EnvironmentVariableRequired(ExceptionData Object, System.Exception Inner) :
                base(global::System.String.Format("The environment variable {0} must be defined",
                    Object.String), Inner) => UserData = Object;




        /// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
            if (Reason as string != null) {
                return new EnvironmentVariableRequired(Reason as string);
                }
            else if (Reason as ExceptionData != null) {
                return new EnvironmentVariableRequired(Reason as ExceptionData);
                }
            else {
                return new EnvironmentVariableRequired();
                }
            }
        }


    /// <summary>
    /// </summary>
    [Serializable]
    public class ExpectedSuccess : global::System.Exception {

        /// <summary>
        /// Construct instance for exception "Service request failed when it should have succeded"
        /// </summary>		
        public ExpectedSuccess() : base("Service request failed when it should have succeded") {
            }

        /// <summary>
        /// Construct instance for exception "Service request failed when it should have succeded"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        public ExpectedSuccess(string Description) : base(Description) {
            }

        /// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        /// <param name="Inner">Inner Exception</param>	
        public ExpectedSuccess(string Description, System.Exception Inner) :
                base(Description, Inner) {
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
                return new ExpectedSuccess(Reason as string);
                }
            else {
                return new ExpectedSuccess();
                }
            }
        }


    /// <summary>
    /// </summary>
    [Serializable]
    public class ExpectedError : global::System.Exception {

        /// <summary>
        /// Construct instance for exception "Service request succeeded when it should have returned an error"
        /// </summary>		
        public ExpectedError() : base("Service request succeeded when it should have returned an error") {
            }

        /// <summary>
        /// Construct instance for exception "Service request succeeded when it should have returned an error"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        public ExpectedError(string Description) : base(Description) {
            }

        /// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        /// <param name="Inner">Inner Exception</param>	
        public ExpectedError(string Description, System.Exception Inner) :
                base(Description, Inner) {
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
                return new ExpectedError(Reason as string);
                }
            else {
                return new ExpectedError();
                }
            }
        }


    }
