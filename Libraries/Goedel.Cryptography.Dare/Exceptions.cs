
//using System;
//using Goedel.Utilities;



namespace Goedel.Cryptography.Dare {


    /// <summary>
    /// An attempt was made to access a container type that is not supported by the
    /// class.
    /// </summary>
    [global::System.Serializable]
	public partial class InvalidContainerTypeException : global::Goedel.Utilities.GoedelException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "This class does not support the specified container type.";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public InvalidContainerTypeException  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new InvalidContainerTypeException(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new InvalidContainerTypeException(reason as string);
				}
			else {
				return new InvalidContainerTypeException();
				}
            }
        }


    /// <summary>
    /// An attempt was made to create a frame that is larger than the maximum frame size allowed by
    /// the application
    /// </summary>
    [global::System.Serializable]
	public partial class FrameTooLargeException : global::Goedel.Utilities.GoedelException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The frame was too large for this implementation to handle";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public FrameTooLargeException  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new FrameTooLargeException(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new FrameTooLargeException(reason as string);
				}
			else {
				return new FrameTooLargeException();
				}
            }
        }


    /// <summary>
    /// An attempt was made to create a new container file in a mode that did not
    /// allow creation of a new file.
    /// </summary>
    [global::System.Serializable]
	public partial class InvalidFileModeException : global::Goedel.Utilities.GoedelException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The file mode is invalid for creating a new file";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public InvalidFileModeException  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new InvalidFileModeException(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new InvalidFileModeException(reason as string);
				}
			else {
				return new InvalidFileModeException();
				}
            }
        }


    /// <summary>
    /// The file format was found to be invalid or otherwise corrupt.
    /// </summary>
    [global::System.Serializable]
	public partial class InvalidFileFormatException : global::Goedel.Utilities.GoedelException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "An error was encountered in reading the container file";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public InvalidFileFormatException  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new InvalidFileFormatException(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new InvalidFileFormatException(reason as string);
				}
			else {
				return new InvalidFileFormatException();
				}
            }
        }


    /// <summary>
    /// An attempt was made to create an object with an existing object identifier
    /// </summary>
    [global::System.Serializable]
	public partial class ObjectIdentifierNotUnique : global::Goedel.Utilities.GoedelException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "An attempt was made to create an object with an existing object identifier";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public ObjectIdentifierNotUnique  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new ObjectIdentifierNotUnique(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new ObjectIdentifierNotUnique(reason as string);
				}
			else {
				return new ObjectIdentifierNotUnique();
				}
            }
        }


    /// <summary>
    /// Access was refused
    /// </summary>
    [global::System.Serializable]
	public partial class AccessRefused : global::Goedel.Utilities.GoedelException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Access was refused";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public AccessRefused  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new AccessRefused(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new AccessRefused(reason as string);
				}
			else {
				return new AccessRefused();
				}
            }
        }


    /// <summary>
    /// A data record could not be read because it was incomplete.
    /// </summary>
    [global::System.Serializable]
	public partial class DataRecordTruncated : global::Goedel.Utilities.GoedelException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "A data record could not be read because it was incomplete.";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public DataRecordTruncated  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new DataRecordTruncated(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new DataRecordTruncated(reason as string);
				}
			else {
				return new DataRecordTruncated();
				}
            }
        }


	}
