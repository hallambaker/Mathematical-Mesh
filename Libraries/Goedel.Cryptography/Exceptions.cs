
//using System;
//using Goedel.Utilities;



namespace Goedel.Cryptography {


    /// <summary>
    /// Base class for cryptographic exceptions.
    /// </summary>
    [global::System.Serializable]
	public partial class CryptographicException : global::Goedel.Utilities.GoedelException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "A cryptographic exception occurred..";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public CryptographicException  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new CryptographicException(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new CryptographicException(reason as string);
				}
			else {
				return new CryptographicException();
				}
            }
        }


    /// <summary>
    /// The operation requires cryptographic catalog initialization"
    /// </summary>
    [global::System.Serializable]
	public partial class CatalogNotInitialized : CryptographicException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The operation requires cryptographic catalog initialization";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public CatalogNotInitialized  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new CatalogNotInitialized(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new CatalogNotInitialized(reason as string);
				}
			else {
				return new CatalogNotInitialized();
				}
            }
        }


    /// <summary>
    /// The operation requires platform initialization
    /// </summary>
    [global::System.Serializable]
	public partial class PlatformNotInitialized : CryptographicException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The operation requires platform initialization";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public PlatformNotInitialized  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new PlatformNotInitialized(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new PlatformNotInitialized(reason as string);
				}
			else {
				return new PlatformNotInitialized();
				}
            }
        }


    /// <summary>
    /// The requested cryptographic operation is not supported
    /// </summary>
    [global::System.Serializable]
	public partial class OperationNotSupported : CryptographicException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The requested cryptographic operation is not supported";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public OperationNotSupported  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new OperationNotSupported(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new OperationNotSupported(reason as string);
				}
			else {
				return new OperationNotSupported();
				}
            }
        }


    /// <summary>
    /// No decryption key is available
    /// </summary>
    [global::System.Serializable]
	public partial class NoAvailableDecryptionKey : CryptographicException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "No decryption key is available";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public NoAvailableDecryptionKey  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new NoAvailableDecryptionKey(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new NoAvailableDecryptionKey(reason as string);
				}
			else {
				return new NoAvailableDecryptionKey();
				}
            }
        }


    /// <summary>
    /// Placeholder exception to be thrown as a placeholder to mark
    /// code needing improvement.
    /// </summary>
    [global::System.Serializable]
	public partial class ImplementationLimit : CryptographicException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Some implementation limit hit";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public ImplementationLimit  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new ImplementationLimit(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new ImplementationLimit(reason as string);
				}
			else {
				return new ImplementationLimit();
				}
            }
        }


    /// <summary>
    /// Some or all of the quorum parameters are incorrect.
    /// </summary>
    [global::System.Serializable]
	public partial class InvalidQuorum : CryptographicException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Quorum parameters invalid";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public InvalidQuorum  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new InvalidQuorum(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new InvalidQuorum(reason as string);
				}
			else {
				return new InvalidQuorum();
				}
            }
        }


    /// <summary>
    /// The recovery attempt failed because there weren't enough shares
    /// to recover the key.
    /// </summary>
    [global::System.Serializable]
	public partial class InsufficientShares : InvalidQuorum {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Not enough shares to recover key";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public InsufficientShares  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new InsufficientShares(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new InsufficientShares(reason as string);
				}
			else {
				return new InsufficientShares();
				}
            }
        }


    /// <summary>
    /// The number of shares required to create a quorum must be 
    /// equal to or smaller than the number of shares
    /// </summary>
    [global::System.Serializable]
	public partial class QuorumExceedsShares : InvalidQuorum {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Quorum can't exceed shares";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public QuorumExceedsShares  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new QuorumExceedsShares(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new QuorumExceedsShares(reason as string);
				}
			else {
				return new QuorumExceedsShares();
				}
            }
        }


    /// <summary>
    /// The quorum must require at least 2 shares.
    /// </summary>
    [global::System.Serializable]
	public partial class QuorumInsufficient : InvalidQuorum {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Quorum must be at least 2";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public QuorumInsufficient  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new QuorumInsufficient(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new QuorumInsufficient(reason as string);
				}
			else {
				return new QuorumInsufficient();
				}
            }
        }


    /// <summary>
    /// There must be at least two key shares.
    /// </summary>
    [global::System.Serializable]
	public partial class SharesInsufficient : InvalidQuorum {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Shares must be at least 2";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public SharesInsufficient  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new SharesInsufficient(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new SharesInsufficient(reason as string);
				}
			else {
				return new SharesInsufficient();
				}
            }
        }


    /// <summary>
    /// This implementation does not support the number of shares
    /// that were requested.
    /// </summary>
    [global::System.Serializable]
	public partial class QuorumExceeded : InvalidQuorum {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Too many shares specified";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public QuorumExceeded  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new QuorumExceeded(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new QuorumExceeded(reason as string);
				}
			else {
				return new QuorumExceeded();
				}
            }
        }


    /// <summary>
    /// The number of shares required to create a quorum exceeds the maximum
    /// permitted polynomial degree.
    /// </summary>
    [global::System.Serializable]
	public partial class QuorumDegreeExceeded : InvalidQuorum {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Degree too high";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public QuorumDegreeExceeded  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new QuorumDegreeExceeded(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new QuorumDegreeExceeded(reason as string);
				}
			else {
				return new QuorumDegreeExceeded();
				}
            }
        }


    /// <summary>
    /// The shares presented are not from the same set of shares.
    /// </summary>
    [global::System.Serializable]
	public partial class MismatchedShares : InvalidQuorum {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Keys must have same threshold";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public MismatchedShares  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new MismatchedShares(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new MismatchedShares(reason as string);
				}
			else {
				return new MismatchedShares();
				}
            }
        }


    /// <summary>
    /// A recryption attempt failed because there were no result values to combine.
    /// </summary>
    [global::System.Serializable]
	public partial class InsufficientResults : CryptographicException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "There must be at least one result";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public InsufficientResults  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new InsufficientResults(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new InsufficientResults(reason as string);
				}
			else {
				return new InsufficientResults();
				}
            }
        }


    /// <summary>
    /// Thje data presented did not match the expected fingerprint
    /// value.			
    /// </summary>
    [global::System.Serializable]
	public partial class FingerprintMatchFailed : CryptographicException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Data did not match expected fingerprint value";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public FingerprintMatchFailed  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new FingerprintMatchFailed(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new FingerprintMatchFailed(reason as string);
				}
			else {
				return new FingerprintMatchFailed();
				}
            }
        }


    /// <summary>
    /// A request was made for a cipher mode that the registered provider 
    /// does not support.
    /// </summary>
    [global::System.Serializable]
	public partial class CipherModeNotSupported : CryptographicException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The requested cipher mode is not supported by the provider";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public CipherModeNotSupported  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new CipherModeNotSupported(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new CipherModeNotSupported(reason as string);
				}
			else {
				return new CipherModeNotSupported();
				}
            }
        }


    /// <summary>
    /// A request was made for a cipher mode that the registered provider 
    /// does not support.			
    /// </summary>
    [global::System.Serializable]
	public partial class CryptographicOperationNotSupported : CryptographicException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The requested cryptographic operation is not supported by the provider";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public CryptographicOperationNotSupported  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new CryptographicOperationNotSupported(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new CryptographicOperationNotSupported(reason as string);
				}
			else {
				return new CryptographicOperationNotSupported();
				}
            }
        }


    /// <summary>
    /// The encryption key type does not match the recryption key type
    /// </summary>
    [global::System.Serializable]
	public partial class KeyTypeMismatch : CryptographicException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The encryption key type does not match the recryption key type";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public KeyTypeMismatch  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new KeyTypeMismatch(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new KeyTypeMismatch(reason as string);
				}
			else {
				return new KeyTypeMismatch();
				}
            }
        }


    /// <summary>
    /// The specified key did not have a valid cryptographic
    /// provider. This may be because the key algorithm is 
    /// not supported or the key parameters were found to be invalid.
    /// </summary>
    [global::System.Serializable]
	public partial class NoProviderSpecified : CryptographicException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "No provider specified";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public NoProviderSpecified  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new NoProviderSpecified(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new NoProviderSpecified(reason as string);
				}
			else {
				return new NoProviderSpecified();
				}
            }
        }


    /// <summary>
    /// The key value must not be null
    /// </summary>
    [global::System.Serializable]
	public partial class NullKeyValue : CryptographicException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The key value must not be null";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public NullKeyValue  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new NullKeyValue(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new NullKeyValue(reason as string);
				}
			else {
				return new NullKeyValue();
				}
            }
        }


    /// <summary>
    /// The parameter value must not be null
    /// </summary>
    [global::System.Serializable]
	public partial class NullParameter : CryptographicException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The parameter value must not be null";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public NullParameter  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new NullParameter(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new NullParameter(reason as string);
				}
			else {
				return new NullParameter();
				}
            }
        }


    /// <summary>
    /// The implementation does not support the requested key size
    /// </summary>
    [global::System.Serializable]
	public partial class KeySizeNotSupported : CryptographicException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The requested key size is not supported";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public KeySizeNotSupported  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new KeySizeNotSupported(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new KeySizeNotSupported(reason as string);
				}
			else {
				return new KeySizeNotSupported();
				}
            }
        }


    /// <summary>
    /// Initialization of the cryptographic support library failed.
    /// This is a fatal error that cannot be recovered from.
    /// </summary>
    [global::System.Serializable]
	public partial class InitializationFailed : CryptographicException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "Initialization of the cryptographic support library failed.";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public InitializationFailed  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new InitializationFailed(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new InitializationFailed(reason as string);
				}
			else {
				return new InitializationFailed();
				}
            }
        }


    /// <summary>
    /// The keypair presented was not of the expected type.
    /// </summary>
    [global::System.Serializable]
	public partial class InvalidKeyPairType : CryptographicException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The keypair presented was not of the expected type";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public InvalidKeyPairType  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new InvalidKeyPairType(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new InvalidKeyPairType(reason as string);
				}
			else {
				return new InvalidKeyPairType();
				}
            }
        }


    /// <summary>
    /// An attempt was made to create more recryption shares than the implementation supports.
    /// </summary>
    [global::System.Serializable]
	public partial class RecryptionShareLimitExceeded : CryptographicException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The number of recryption shares requested exceeds the implementation limit";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public RecryptionShareLimitExceeded  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new RecryptionShareLimitExceeded(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new RecryptionShareLimitExceeded(reason as string);
				}
			else {
				return new RecryptionShareLimitExceeded();
				}
            }
        }


    /// <summary>
    /// The cryptographic provider does not support the requested operation
    /// </summary>
    [global::System.Serializable]
	public partial class InvalidOperation : CryptographicException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The cryptographic provider does not support the requested operation";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public InvalidOperation  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new InvalidOperation(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new InvalidOperation(reason as string);
				}
			else {
				return new InvalidOperation();
				}
            }
        }


    /// <summary>
    /// The specified algorithm is not valid for the operation attempted
    /// </summary>
    [global::System.Serializable]
	public partial class InvalidAlgorithm : CryptographicException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The specified algorithm is not valid for the operation attempted";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public InvalidAlgorithm  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new InvalidAlgorithm(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new InvalidAlgorithm(reason as string);
				}
			else {
				return new InvalidAlgorithm();
				}
            }
        }


    /// <summary>
    /// The operation requested requires a private key that could not be found
    /// </summary>
    [global::System.Serializable]
	public partial class PrivateKeyNotFound : CryptographicException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The operation requested requires a private key that could not be found";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public PrivateKeyNotFound  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new PrivateKeyNotFound(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new PrivateKeyNotFound(reason as string);
				}
			else {
				return new PrivateKeyNotFound();
				}
            }
        }


    /// <summary>
    /// The key unwrap operation returned an invalid value.
    /// </summary>
    [global::System.Serializable]
	public partial class UnwrapFailed : CryptographicException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The key unwrap operation returned an invalid value.";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public UnwrapFailed  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new UnwrapFailed(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new UnwrapFailed(reason as string);
				}
			else {
				return new UnwrapFailed();
				}
            }
        }


    /// <summary>
    /// The named parameters specified in an operation are not known
    /// </summary>
    [global::System.Serializable]
	public partial class UnknownNamedParameters : CryptographicException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The named parameters specified in an operation are not known";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public UnknownNamedParameters  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new UnknownNamedParameters(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new UnknownNamedParameters(reason as string);
				}
			else {
				return new UnknownNamedParameters();
				}
            }
        }


    /// <summary>
    /// The cryptographic provider does not permit export of the private key parameters
    /// </summary>
    [global::System.Serializable]
	public partial class NotExportable : CryptographicException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "The cryptographic provider does not permit export of the private key parameters";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public NotExportable  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new NotExportable(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new NotExportable(reason as string);
				}
			else {
				return new NotExportable();
				}
            }
        }


	}
