using System;
using Goedel.Utilities;



namespace Goedel.Platformsa {


    /// <summary>
    /// Base class for protocol exceptions.
    /// </summary>
    public class PlatformException : global::System.Exception {

		/// <summary>
        /// Construct instance for exception "An exception occurred in the platform library"
        /// </summary>		
		public PlatformException () : base ("An exception occurred in the platform library") {
			}
        
		/// <summary>
        /// Construct instance for exception "An exception occurred in the platform library"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public PlatformException (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public PlatformException (string Description, System.Exception Inner) : 
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
				return new PlatformException(Reason as string);
				}
			else {
				return new PlatformException();
				}
            }
        }


    /// <summary>
    /// An attempt was made to write past the end of a buffer.
    /// </summary>
    public class BufferWriteOverflow : PlatformException {

		/// <summary>
        /// Construct instance for exception "Buffer write overflow"
        /// </summary>		
		public BufferWriteOverflow () : base ("Buffer write overflow") {
			}
        
		/// <summary>
        /// Construct instance for exception "Buffer write overflow"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public BufferWriteOverflow (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public BufferWriteOverflow (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new BufferWriteOverflow(Reason as string);
				}
			else {
				return new BufferWriteOverflow();
				}
            }
        }


    /// <summary>
    /// An attempt was made to read past the end of a buffer.
    /// </summary>
    public class BufferReadOverflow : PlatformException {

		/// <summary>
        /// Construct instance for exception "Buffer read overflow"
        /// </summary>		
		public BufferReadOverflow () : base ("Buffer read overflow") {
			}
        
		/// <summary>
        /// Construct instance for exception "Buffer read overflow"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public BufferReadOverflow (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public BufferReadOverflow (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new BufferReadOverflow(Reason as string);
				}
			else {
				return new BufferReadOverflow();
				}
            }
        }


    /// <summary>
    /// A message contained a label longer than the permitted length
    /// </summary>
    public class LabelTooLong : PlatformException {

		/// <summary>
        /// Construct instance for exception "A message contained a label longer than the permitted length"
        /// </summary>		
		public LabelTooLong () : base ("A message contained a label longer than the permitted length") {
			}
        
		/// <summary>
        /// Construct instance for exception "A message contained a label longer than the permitted length"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public LabelTooLong (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public LabelTooLong (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new LabelTooLong(Reason as string);
				}
			else {
				return new LabelTooLong();
				}
            }
        }


    /// <summary>
    /// A message contained a tag longer than the permitted length
    /// </summary>
    public class TagTooLong : PlatformException {

		/// <summary>
        /// Construct instance for exception "A message contained a tag longer than the permitted length"
        /// </summary>		
		public TagTooLong () : base ("A message contained a tag longer than the permitted length") {
			}
        
		/// <summary>
        /// Construct instance for exception "A message contained a tag longer than the permitted length"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public TagTooLong (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public TagTooLong (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new TagTooLong(Reason as string);
				}
			else {
				return new TagTooLong();
				}
            }
        }


    /// <summary>
    /// Unicode labels are not supported
    /// </summary>
    public class UnicodeNotSupported : PlatformException {

		/// <summary>
        /// Construct instance for exception "Unicode labels are not supported"
        /// </summary>		
		public UnicodeNotSupported () : base ("Unicode labels are not supported") {
			}
        
		/// <summary>
        /// Construct instance for exception "Unicode labels are not supported"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public UnicodeNotSupported (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public UnicodeNotSupported (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new UnicodeNotSupported(Reason as string);
				}
			else {
				return new UnicodeNotSupported();
				}
            }
        }


    /// <summary>
    /// An illegal character was encountered
    /// </summary>
    public class IllegalCharacter : PlatformException {

		/// <summary>
        /// Construct instance for exception "An illegal character was encountered"
        /// </summary>		
		public IllegalCharacter () : base ("An illegal character was encountered") {
			}
        
		/// <summary>
        /// Construct instance for exception "An illegal character was encountered"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public IllegalCharacter (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public IllegalCharacter (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new IllegalCharacter(Reason as string);
				}
			else {
				return new IllegalCharacter();
				}
            }
        }


    /// <summary>
    /// A message contained an invalid IPv4 address
    /// </summary>
    public class InvalidIPv4 : PlatformException {

		/// <summary>
        /// Construct instance for exception "Not a valid IPv4 Address"
        /// </summary>		
		public InvalidIPv4 () : base ("Not a valid IPv4 Address") {
			}
        
		/// <summary>
        /// Construct instance for exception "Not a valid IPv4 Address"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public InvalidIPv4 (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public InvalidIPv4 (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new InvalidIPv4(Reason as string);
				}
			else {
				return new InvalidIPv4();
				}
            }
        }


    /// <summary>
    /// A message contained an invalid IPv6 address
    /// </summary>
    public class InvalidIPv6 : PlatformException {

		/// <summary>
        /// Construct instance for exception "Not a valid IPv6 Address"
        /// </summary>		
		public InvalidIPv6 () : base ("Not a valid IPv6 Address") {
			}
        
		/// <summary>
        /// Construct instance for exception "Not a valid IPv6 Address"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public InvalidIPv6 (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public InvalidIPv6 (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new InvalidIPv6(Reason as string);
				}
			else {
				return new InvalidIPv6();
				}
            }
        }


	}
