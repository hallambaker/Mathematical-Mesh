using System;
using Goedel.Utilities;



namespace Goedel.Cryptography {


    /// <summary>
    /// Base class for cryptographic exceptions.
    /// </summary>
    [Serializable]
	public class CryptographicException : global::System.Exception {

		/// <summary>
        /// Construct instance for exception "A cryptographic exception occurred.."
        /// </summary>		
		public CryptographicException () : base ("A cryptographic exception occurred..") {
			}
        
		/// <summary>
        /// Construct instance for exception "A cryptographic exception occurred.."
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public CryptographicException (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public CryptographicException (string Description, System.Exception Inner) : 
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
				return new CryptographicException(Reason as string);
				}
			else {
				return new CryptographicException();
				}
            }
        }


    /// <summary>
    /// The operation requires cryptographic catalog initialization"
    /// </summary>
    [Serializable]
	public class CatalogNotInitialized : CryptographicException {

		/// <summary>
        /// Construct instance for exception "The operation requires cryptographic catalog initialization"
        /// </summary>		
		public CatalogNotInitialized () : base ("The operation requires cryptographic catalog initialization") {
			}
        
		/// <summary>
        /// Construct instance for exception "The operation requires cryptographic catalog initialization"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public CatalogNotInitialized (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public CatalogNotInitialized (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new CatalogNotInitialized(Reason as string);
				}
			else {
				return new CatalogNotInitialized();
				}
            }
        }


    /// <summary>
    /// The operation requires platform initialization
    /// </summary>
    [Serializable]
	public class PlatformNotInitialized : CryptographicException {

		/// <summary>
        /// Construct instance for exception "The operation requires platform initialization"
        /// </summary>		
		public PlatformNotInitialized () : base ("The operation requires platform initialization") {
			}
        
		/// <summary>
        /// Construct instance for exception "The operation requires platform initialization"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public PlatformNotInitialized (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public PlatformNotInitialized (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new PlatformNotInitialized(Reason as string);
				}
			else {
				return new PlatformNotInitialized();
				}
            }
        }


    /// <summary>
    /// No decryption key is available
    /// </summary>
    [Serializable]
	public class NoAvailableDecryptionKey : CryptographicException {

		/// <summary>
        /// Construct instance for exception "No decryption key is available"
        /// </summary>		
		public NoAvailableDecryptionKey () : base ("No decryption key is available") {
			}
        
		/// <summary>
        /// Construct instance for exception "No decryption key is available"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public NoAvailableDecryptionKey (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public NoAvailableDecryptionKey (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new NoAvailableDecryptionKey(Reason as string);
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
    [Serializable]
	public class ImplementationLimit : CryptographicException {

		/// <summary>
        /// Construct instance for exception "Some implementation limit hit"
        /// </summary>		
		public ImplementationLimit () : base ("Some implementation limit hit") {
			}
        
		/// <summary>
        /// Construct instance for exception "Some implementation limit hit"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public ImplementationLimit (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public ImplementationLimit (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new ImplementationLimit(Reason as string);
				}
			else {
				return new ImplementationLimit();
				}
            }
        }


    /// <summary>
    /// Some or all of the quorum parameters are incorrect.
    /// </summary>
    [Serializable]
	public class InvalidQuorum : CryptographicException {

		/// <summary>
        /// Construct instance for exception "Quorum parameters invalid"
        /// </summary>		
		public InvalidQuorum () : base ("Quorum parameters invalid") {
			}
        
		/// <summary>
        /// Construct instance for exception "Quorum parameters invalid"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public InvalidQuorum (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public InvalidQuorum (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new InvalidQuorum(Reason as string);
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
    [Serializable]
	public class InsufficientShares : InvalidQuorum {

		/// <summary>
        /// Construct instance for exception "Not enough shares to recover key"
        /// </summary>		
		public InsufficientShares () : base ("Not enough shares to recover key") {
			}
        
		/// <summary>
        /// Construct instance for exception "Not enough shares to recover key"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public InsufficientShares (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public InsufficientShares (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new InsufficientShares(Reason as string);
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
    [Serializable]
	public class QuorumExceedsShares : InvalidQuorum {

		/// <summary>
        /// Construct instance for exception "Quorum can\'t exceed shares"
        /// </summary>		
		public QuorumExceedsShares () : base ("Quorum can\'t exceed shares") {
			}
        
		/// <summary>
        /// Construct instance for exception "Quorum can\'t exceed shares"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public QuorumExceedsShares (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public QuorumExceedsShares (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new QuorumExceedsShares(Reason as string);
				}
			else {
				return new QuorumExceedsShares();
				}
            }
        }


    /// <summary>
    /// The quorum must require at least 2 shares.
    /// </summary>
    [Serializable]
	public class QuorumInsufficient : InvalidQuorum {

		/// <summary>
        /// Construct instance for exception "Quorum must be at least 2"
        /// </summary>		
		public QuorumInsufficient () : base ("Quorum must be at least 2") {
			}
        
		/// <summary>
        /// Construct instance for exception "Quorum must be at least 2"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public QuorumInsufficient (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public QuorumInsufficient (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new QuorumInsufficient(Reason as string);
				}
			else {
				return new QuorumInsufficient();
				}
            }
        }


    /// <summary>
    /// There must be at least two key shares.
    /// </summary>
    [Serializable]
	public class SharesInsufficient : InvalidQuorum {

		/// <summary>
        /// Construct instance for exception "Shares must be at least 2"
        /// </summary>		
		public SharesInsufficient () : base ("Shares must be at least 2") {
			}
        
		/// <summary>
        /// Construct instance for exception "Shares must be at least 2"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public SharesInsufficient (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public SharesInsufficient (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new SharesInsufficient(Reason as string);
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
    [Serializable]
	public class QuorumExceeded : InvalidQuorum {

		/// <summary>
        /// Construct instance for exception "Too many shares specified"
        /// </summary>		
		public QuorumExceeded () : base ("Too many shares specified") {
			}
        
		/// <summary>
        /// Construct instance for exception "Too many shares specified"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public QuorumExceeded (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public QuorumExceeded (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new QuorumExceeded(Reason as string);
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
    [Serializable]
	public class QuorumDegreeExceeded : InvalidQuorum {

		/// <summary>
        /// Construct instance for exception "Degree too high"
        /// </summary>		
		public QuorumDegreeExceeded () : base ("Degree too high") {
			}
        
		/// <summary>
        /// Construct instance for exception "Degree too high"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public QuorumDegreeExceeded (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public QuorumDegreeExceeded (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new QuorumDegreeExceeded(Reason as string);
				}
			else {
				return new QuorumDegreeExceeded();
				}
            }
        }


    /// <summary>
    /// The shares presented are not from the same set of shares.
    /// </summary>
    [Serializable]
	public class MismatchedShares : InvalidQuorum {

		/// <summary>
        /// Construct instance for exception "Keys must have same threshold"
        /// </summary>		
		public MismatchedShares () : base ("Keys must have same threshold") {
			}
        
		/// <summary>
        /// Construct instance for exception "Keys must have same threshold"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public MismatchedShares (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public MismatchedShares (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new MismatchedShares(Reason as string);
				}
			else {
				return new MismatchedShares();
				}
            }
        }


    /// <summary>
    /// A recryption attempt failed because there were no result values to combine.
    /// </summary>
    [Serializable]
	public class InsufficientResults : CryptographicException {

		/// <summary>
        /// Construct instance for exception "There must be at least one result"
        /// </summary>		
		public InsufficientResults () : base ("There must be at least one result") {
			}
        
		/// <summary>
        /// Construct instance for exception "There must be at least one result"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public InsufficientResults (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public InsufficientResults (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new InsufficientResults(Reason as string);
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
    [Serializable]
	public class FingerprintMatchFailed : CryptographicException {

		/// <summary>
        /// Construct instance for exception "Data did not match expected fingerprint value"
        /// </summary>		
		public FingerprintMatchFailed () : base ("Data did not match expected fingerprint value") {
			}
        
		/// <summary>
        /// Construct instance for exception "Data did not match expected fingerprint value"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public FingerprintMatchFailed (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public FingerprintMatchFailed (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new FingerprintMatchFailed(Reason as string);
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
    [Serializable]
	public class CipherModeNotSupported : CryptographicException {

		/// <summary>
        /// Construct instance for exception "The requested cipher mode is not supported by the provider"
        /// </summary>		
		public CipherModeNotSupported () : base ("The requested cipher mode is not supported by the provider") {
			}
        
		/// <summary>
        /// Construct instance for exception "The requested cipher mode is not supported by the provider"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public CipherModeNotSupported (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public CipherModeNotSupported (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new CipherModeNotSupported(Reason as string);
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
    [Serializable]
	public class CryptographicOperationNotSupported : CryptographicException {

		/// <summary>
        /// Construct instance for exception "The requested cryptographic operation is not supported by the provider"
        /// </summary>		
		public CryptographicOperationNotSupported () : base ("The requested cryptographic operation is not supported by the provider") {
			}
        
		/// <summary>
        /// Construct instance for exception "The requested cryptographic operation is not supported by the provider"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public CryptographicOperationNotSupported (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public CryptographicOperationNotSupported (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new CryptographicOperationNotSupported(Reason as string);
				}
			else {
				return new CryptographicOperationNotSupported();
				}
            }
        }


    /// <summary>
    /// The encryption key type does not match the recryption key type
    /// </summary>
    [Serializable]
	public class KeyTypeMismatch : CryptographicException {

		/// <summary>
        /// Construct instance for exception "The encryption key type does not match the recryption key type"
        /// </summary>		
		public KeyTypeMismatch () : base ("The encryption key type does not match the recryption key type") {
			}
        
		/// <summary>
        /// Construct instance for exception "The encryption key type does not match the recryption key type"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public KeyTypeMismatch (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public KeyTypeMismatch (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new KeyTypeMismatch(Reason as string);
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
    [Serializable]
	public class NoProviderSpecified : CryptographicException {

		/// <summary>
        /// Construct instance for exception "No provider specified"
        /// </summary>		
		public NoProviderSpecified () : base ("No provider specified") {
			}
        
		/// <summary>
        /// Construct instance for exception "No provider specified"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public NoProviderSpecified (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public NoProviderSpecified (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new NoProviderSpecified(Reason as string);
				}
			else {
				return new NoProviderSpecified();
				}
            }
        }


    /// <summary>
    /// The implementation does not support the requested key size
    /// </summary>
    [Serializable]
	public class KeySizeNotSupported : CryptographicException {

		/// <summary>
        /// Construct instance for exception "The requested key size is not supported"
        /// </summary>		
		public KeySizeNotSupported () : base ("The requested key size is not supported") {
			}
        
		/// <summary>
        /// Construct instance for exception "The requested key size is not supported"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public KeySizeNotSupported (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public KeySizeNotSupported (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new KeySizeNotSupported(Reason as string);
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
    [Serializable]
	public class InitializationFailed : CryptographicException {

		/// <summary>
        /// Construct instance for exception "Initialization of the cryptographic support library failed."
        /// </summary>		
		public InitializationFailed () : base ("Initialization of the cryptographic support library failed.") {
			}
        
		/// <summary>
        /// Construct instance for exception "Initialization of the cryptographic support library failed."
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public InitializationFailed (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public InitializationFailed (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new InitializationFailed(Reason as string);
				}
			else {
				return new InitializationFailed();
				}
            }
        }


    /// <summary>
    /// The keypair presented was not of the expected type.
    /// </summary>
    [Serializable]
	public class InvalidKeyPairType : CryptographicException {

		/// <summary>
        /// Construct instance for exception "The keypair presented was not of the expected type"
        /// </summary>		
		public InvalidKeyPairType () : base ("The keypair presented was not of the expected type") {
			}
        
		/// <summary>
        /// Construct instance for exception "The keypair presented was not of the expected type"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public InvalidKeyPairType (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public InvalidKeyPairType (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new InvalidKeyPairType(Reason as string);
				}
			else {
				return new InvalidKeyPairType();
				}
            }
        }


    /// <summary>
    /// An attempt was made to create more recryption shares than the implementation supports.
    /// </summary>
    [Serializable]
	public class RecryptionShareLimitExceeded : CryptographicException {

		/// <summary>
        /// Construct instance for exception "The number of recryption shares requested exceeds the implementation limit"
        /// </summary>		
		public RecryptionShareLimitExceeded () : base ("The number of recryption shares requested exceeds the implementation limit") {
			}
        
		/// <summary>
        /// Construct instance for exception "The number of recryption shares requested exceeds the implementation limit"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public RecryptionShareLimitExceeded (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public RecryptionShareLimitExceeded (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new RecryptionShareLimitExceeded(Reason as string);
				}
			else {
				return new RecryptionShareLimitExceeded();
				}
            }
        }


    /// <summary>
    /// The cryptographic provider does not support the requested operation
    /// </summary>
    [Serializable]
	public class InvalidOperation : CryptographicException {

		/// <summary>
        /// Construct instance for exception "The cryptographic provider does not support the requested operation"
        /// </summary>		
		public InvalidOperation () : base ("The cryptographic provider does not support the requested operation") {
			}
        
		/// <summary>
        /// Construct instance for exception "The cryptographic provider does not support the requested operation"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public InvalidOperation (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public InvalidOperation (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new InvalidOperation(Reason as string);
				}
			else {
				return new InvalidOperation();
				}
            }
        }


    /// <summary>
    /// The specified algorithm is not valid for the operation attempted
    /// </summary>
    [Serializable]
	public class InvalidAlgorithm : CryptographicException {

		/// <summary>
        /// Construct instance for exception "The specified algorithm is not valid for the operation attempted"
        /// </summary>		
		public InvalidAlgorithm () : base ("The specified algorithm is not valid for the operation attempted") {
			}
        
		/// <summary>
        /// Construct instance for exception "The specified algorithm is not valid for the operation attempted"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public InvalidAlgorithm (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public InvalidAlgorithm (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new InvalidAlgorithm(Reason as string);
				}
			else {
				return new InvalidAlgorithm();
				}
            }
        }


    /// <summary>
    /// The operation requested requires a private key that could not be found
    /// </summary>
    [Serializable]
	public class PrivateKeyNotFound : CryptographicException {

		/// <summary>
        /// Construct instance for exception "The operation requested requires a private key that could not be found"
        /// </summary>		
		public PrivateKeyNotFound () : base ("The operation requested requires a private key that could not be found") {
			}
        
		/// <summary>
        /// Construct instance for exception "The operation requested requires a private key that could not be found"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public PrivateKeyNotFound (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public PrivateKeyNotFound (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new PrivateKeyNotFound(Reason as string);
				}
			else {
				return new PrivateKeyNotFound();
				}
            }
        }


    /// <summary>
    /// The key unwrap operation returned an invalid value.
    /// </summary>
    [Serializable]
	public class UnwrapFailed : CryptographicException {

		/// <summary>
        /// Construct instance for exception "The key unwrap operation returned an invalid value."
        /// </summary>		
		public UnwrapFailed () : base ("The key unwrap operation returned an invalid value.") {
			}
        
		/// <summary>
        /// Construct instance for exception "The key unwrap operation returned an invalid value."
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public UnwrapFailed (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public UnwrapFailed (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new UnwrapFailed(Reason as string);
				}
			else {
				return new UnwrapFailed();
				}
            }
        }


    /// <summary>
    /// The named parameters specified in an operation are not known
    /// </summary>
    [Serializable]
	public class UnknownNamedParameters : CryptographicException {

		/// <summary>
        /// Construct instance for exception "The named parameters specified in an operation are not known"
        /// </summary>		
		public UnknownNamedParameters () : base ("The named parameters specified in an operation are not known") {
			}
        
		/// <summary>
        /// Construct instance for exception "The named parameters specified in an operation are not known"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public UnknownNamedParameters (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public UnknownNamedParameters (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new UnknownNamedParameters(Reason as string);
				}
			else {
				return new UnknownNamedParameters();
				}
            }
        }


    /// <summary>
    /// The cryptographic provider does not permit export of the private key parameters
    /// </summary>
    [Serializable]
	public class NotExportable : CryptographicException {

		/// <summary>
        /// Construct instance for exception "The cryptographic provider does not permit export of the private key parameters"
        /// </summary>		
		public NotExportable () : base ("The cryptographic provider does not permit export of the private key parameters") {
			}
        
		/// <summary>
        /// Construct instance for exception "The cryptographic provider does not permit export of the private key parameters"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		public NotExportable (string Description) : base (Description) {
			}

		/// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
		/// <param name="Inner">Inner Exception</param>	
		public NotExportable (string Description, System.Exception Inner) : 
				base (Description, Inner) {
			}




		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
			if (Reason as string != null) {
				return new NotExportable(Reason as string);
				}
			else {
				return new NotExportable();
				}
            }
        }


	}
