
//using System;
//using Goedel.Utilities;



namespace Goedel.Discovery {


    /// <summary>
    /// Base class for protocol exceptions.
    /// </summary>
    [global::System.Serializable]
	public partial class DiscoveryException : global::Goedel.Utilities.GoedelException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "An exception occurred in the discovery library";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public DiscoveryException  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new DiscoveryException(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new DiscoveryException(reason as string);
				}
			else {
				return new DiscoveryException();
				}
            }
        }


    /// <summary>
    /// An attempt was made to write past the end of a buffer.
    /// </summary>
    [global::System.Serializable]
	public partial class BufferWriteOverflow : DiscoveryException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Buffer write overflow";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public BufferWriteOverflow  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new BufferWriteOverflow(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new BufferWriteOverflow(reason as string);
				}
			else {
				return new BufferWriteOverflow();
				}
            }
        }


    /// <summary>
    /// An attempt was made to read past the end of a buffer.
    /// </summary>
    [global::System.Serializable]
	public partial class BufferReadOverflow : DiscoveryException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Buffer read overflow";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public BufferReadOverflow  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new BufferReadOverflow(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new BufferReadOverflow(reason as string);
				}
			else {
				return new BufferReadOverflow();
				}
            }
        }


    /// <summary>
    /// A message contained a label longer than the permitted length
    /// </summary>
    [global::System.Serializable]
	public partial class LabelTooLong : DiscoveryException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "A message contained a label longer than the permitted length";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public LabelTooLong  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new LabelTooLong(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new LabelTooLong(reason as string);
				}
			else {
				return new LabelTooLong();
				}
            }
        }


    /// <summary>
    /// Unicode labels are not supported
    /// </summary>
    [global::System.Serializable]
	public partial class UnicodeNotSupported : DiscoveryException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Unicode labels are not supported";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public UnicodeNotSupported  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new UnicodeNotSupported(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new UnicodeNotSupported(reason as string);
				}
			else {
				return new UnicodeNotSupported();
				}
            }
        }


    /// <summary>
    /// An illegal character was encountered
    /// </summary>
    [global::System.Serializable]
	public partial class IllegalCharacter : DiscoveryException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "An illegal character was encountered";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public IllegalCharacter  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new IllegalCharacter(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new IllegalCharacter(reason as string);
				}
			else {
				return new IllegalCharacter();
				}
            }
        }


    /// <summary>
    /// A message contained a tag longer than the permitted length
    /// </summary>
    [global::System.Serializable]
	public partial class TagTooLong : DiscoveryException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "A message contained a tag longer than the permitted length";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public TagTooLong  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new TagTooLong(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new TagTooLong(reason as string);
				}
			else {
				return new TagTooLong();
				}
            }
        }


    /// <summary>
    /// A message contained an invalid IPv4 address
    /// </summary>
    [global::System.Serializable]
	public partial class InvalidIPv4 : DiscoveryException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "A message contained an invalid IPv4 address";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public InvalidIPv4  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new InvalidIPv4(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new InvalidIPv4(reason as string);
				}
			else {
				return new InvalidIPv4();
				}
            }
        }


    /// <summary>
    /// A message contained an invalid IPv6 address
    /// </summary>
    [global::System.Serializable]
	public partial class InvalidIPv6 : DiscoveryException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "A message contained an invalid IPv6 address";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public InvalidIPv6  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new InvalidIPv6(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new InvalidIPv6(reason as string);
				}
			else {
				return new InvalidIPv6();
				}
            }
        }


	}
