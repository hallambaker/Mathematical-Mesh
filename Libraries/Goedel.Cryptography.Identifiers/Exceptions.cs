
//  This file was automatically generated at 9/6/2024 1:44:59 AM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  exceptional version 3.0.0.867
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2022
//  
//  Build Platform: Win32NT 10.0.22631.0
//  
//  

//using System;
//using Goedel.Utilities;



#pragma warning disable IDE0079
#pragma warning disable IDE1006 // Naming Styles
namespace Goedel.Cryptography ;


/// <summary>
/// Base class for cryptographic exceptions.
/// </summary>
[global::System.Serializable]
public partial class CryptographicException : global::Goedel.Utilities.GoedelException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"A cryptographic exception occurred.."
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public CryptographicException  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new CryptographicException(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// The container specified a reference to an invalid frame"		
/// </summary>
[global::System.Serializable]
public partial class InvalidFrameIndex : CryptographicException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The container specified a reference to an invalid frame"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public InvalidFrameIndex  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new InvalidFrameIndex(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// An internal assertion check failed."
/// </summary>
[global::System.Serializable]
public partial class InternalCryptographicException : CryptographicException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"An internal assertion check failed"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public InternalCryptographicException  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new InternalCryptographicException(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// Key could not be found."
/// </summary>
[global::System.Serializable]
public partial class KeyNotFound : CryptographicException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"Key could not be found"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public KeyNotFound  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new KeyNotFound(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// An internal assertion check failed."
/// </summary>
[global::System.Serializable]
public partial class MismatchedCurves : CryptographicException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"Points are on different curves"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public MismatchedCurves  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new MismatchedCurves(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// The operation requires cryptographic catalog initialization"
/// </summary>
[global::System.Serializable]
public partial class CatalogNotInitialized : CryptographicException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The operation requires cryptographic catalog initialization"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public CatalogNotInitialized  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new CatalogNotInitialized(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// The operation requires platform initialization
/// </summary>
[global::System.Serializable]
public partial class PlatformNotInitialized : CryptographicException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The operation requires platform initialization"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public PlatformNotInitialized  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new PlatformNotInitialized(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// The requested cryptographic operation is not supported
/// </summary>
[global::System.Serializable]
public partial class OperationNotSupported : CryptographicException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The requested cryptographic operation is not supported"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public OperationNotSupported  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new OperationNotSupported(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// No encryption key is available
/// </summary>
[global::System.Serializable]
public partial class NoAvailableEncryptionKey : CryptographicException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"No encryption key is available"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public NoAvailableEncryptionKey  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new NoAvailableEncryptionKey(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// No decryption key is available
/// </summary>
[global::System.Serializable]
public partial class NoAvailableDecryptionKey : CryptographicException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"No decryption key is available"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public NoAvailableDecryptionKey  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new NoAvailableDecryptionKey(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// Placeholder exception to be thrown as a placeholder to mark
/// code needing improvement.
/// </summary>
[global::System.Serializable]
public partial class ImplementationLimit : CryptographicException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"Some implementation limit hit"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public ImplementationLimit  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new ImplementationLimit(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// Some or all of the quorum parameters are incorrect.
/// </summary>
[global::System.Serializable]
public partial class InvalidQuorum : CryptographicException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"Quorum parameters invalid"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public InvalidQuorum  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new InvalidQuorum(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// The recovery attempt failed because there weren't enough shares
/// to recover the key.
/// </summary>
[global::System.Serializable]
public partial class InsufficientShares : InvalidQuorum {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"Not enough shares to recover key"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public InsufficientShares  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new InsufficientShares(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// The number of shares required to create a quorum must be 
/// equal to or smaller than the number of shares
/// </summary>
[global::System.Serializable]
public partial class QuorumExceedsShares : InvalidQuorum {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"Quorum can't exceed shares"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public QuorumExceedsShares  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new QuorumExceedsShares(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// The quorum must require at least 2 shares.
/// </summary>
[global::System.Serializable]
public partial class QuorumInsufficient : InvalidQuorum {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"Quorum must be at least 2"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public QuorumInsufficient  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new QuorumInsufficient(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// There must be at least two key shares.
/// </summary>
[global::System.Serializable]
public partial class SharesInsufficient : InvalidQuorum {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"Shares must be at least 2"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public SharesInsufficient  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new SharesInsufficient(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// This implementation does not support the number of shares
/// that were requested.
/// </summary>
[global::System.Serializable]
public partial class QuorumExceeded : InvalidQuorum {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"Too many shares specified"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public QuorumExceeded  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new QuorumExceeded(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// The number of shares required to create a quorum exceeds the maximum
/// permitted polynomial degree.
/// </summary>
[global::System.Serializable]
public partial class QuorumDegreeExceeded : InvalidQuorum {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"Degree too high"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public QuorumDegreeExceeded  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new QuorumDegreeExceeded(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// The shares presented are not from the same set of shares.
/// </summary>
[global::System.Serializable]
public partial class MismatchedShares : InvalidQuorum {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"Keys must have same threshold"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public MismatchedShares  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new MismatchedShares(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// A recryption attempt failed because there were no result values to combine.
/// </summary>
[global::System.Serializable]
public partial class InsufficientResults : CryptographicException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"There must be at least one result"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public InsufficientResults  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new InsufficientResults(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// Thje data presented did not match the expected fingerprint
/// value.			
/// </summary>
[global::System.Serializable]
public partial class FingerprintMatchFailed : CryptographicException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"Data did not match expected fingerprint value"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public FingerprintMatchFailed  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new FingerprintMatchFailed(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// A request was made for a cipher mode that the registered provider 
/// does not support.
/// </summary>
[global::System.Serializable]
public partial class CipherModeNotSupported : CryptographicException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The requested cipher mode is not supported by the provider"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public CipherModeNotSupported  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new CipherModeNotSupported(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// A request was made for a cipher mode that the registered provider 
/// does not support.			
/// </summary>
[global::System.Serializable]
public partial class CryptographicOperationNotSupported : CryptographicException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The requested cryptographic operation is not supported by the provider"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public CryptographicOperationNotSupported  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new CryptographicOperationNotSupported(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// The encryption key type does not match the recryption key type
/// </summary>
[global::System.Serializable]
public partial class KeyTypeMismatch : CryptographicException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The encryption key type does not match the recryption key type"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public KeyTypeMismatch  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new KeyTypeMismatch(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// The specified key did not have a valid cryptographic
/// provider. This may be because the key algorithm is 
/// not supported or the key parameters were found to be invalid.
/// </summary>
[global::System.Serializable]
public partial class NoProviderSpecified : CryptographicException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"No provider specified"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public NoProviderSpecified  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new NoProviderSpecified(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// The key value must not be null
/// </summary>
[global::System.Serializable]
public partial class NullKeyValue : CryptographicException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The key value must not be null"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public NullKeyValue  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new NullKeyValue(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// The parameter value must not be null
/// </summary>
[global::System.Serializable]
public partial class NullParameter : CryptographicException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The parameter value must not be null"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public NullParameter  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new NullParameter(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// The implementation does not support the requested key size
/// </summary>
[global::System.Serializable]
public partial class KeySizeNotSupported : CryptographicException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The requested key size is not supported"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public KeySizeNotSupported  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new KeySizeNotSupported(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// Initialization of the cryptographic support library failed.
/// This is a fatal error that cannot be recovered from.
/// </summary>
[global::System.Serializable]
public partial class InitializationFailed : CryptographicException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"Initialization of the cryptographic support library failed."
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public InitializationFailed  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new InitializationFailed(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// The specified key size presents an insufficient work factor
/// </summary>
[global::System.Serializable]
public partial class InsufficientKeySize : CryptographicException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The specified key size presents an insufficient work factor"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public InsufficientKeySize  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new InsufficientKeySize(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// The keypair presented was not of the expected type.
/// </summary>
[global::System.Serializable]
public partial class InvalidKeyPairType : CryptographicException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The keypair presented was not of the expected type"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public InvalidKeyPairType  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new InvalidKeyPairType(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// An attempt was made to create more recryption shares than the implementation supports.
/// </summary>
[global::System.Serializable]
public partial class RecryptionShareLimitExceeded : CryptographicException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The number of recryption shares requested exceeds the implementation limit"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public RecryptionShareLimitExceeded  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new RecryptionShareLimitExceeded(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// </summary>
[global::System.Serializable]
public partial class InvalidRecoveredData : CryptographicException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The recovered data was invalid"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public InvalidRecoveredData  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new InvalidRecoveredData(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// </summary>
[global::System.Serializable]
public partial class KeyErasureFailed : CryptographicException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The private key could not be removed from the key store."
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public KeyErasureFailed  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new KeyErasureFailed(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// The cryptographic provider does not support the requested operation
/// </summary>
[global::System.Serializable]
public partial class InvalidOperation : CryptographicException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The cryptographic provider does not support the requested operation"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public InvalidOperation  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new InvalidOperation(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// The specified algorithm is not valid for the operation attempted
/// </summary>
[global::System.Serializable]
public partial class InvalidAlgorithm : CryptographicException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The specified algorithm is not valid for the operation attempted"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public InvalidAlgorithm  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new InvalidAlgorithm(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// </summary>
[global::System.Serializable]
public partial class InvalidPoint : CryptographicException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The specified point is not valid for the curve"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public InvalidPoint  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new InvalidPoint(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// The operation requested requires a private key that could not be found
/// </summary>
[global::System.Serializable]
public partial class PrivateKeyNotFound : CryptographicException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The operation requested requires a private key that could not be found"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public PrivateKeyNotFound  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new PrivateKeyNotFound(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// The key unwrap operation returned an invalid value.
/// </summary>
[global::System.Serializable]
public partial class UnwrapFailed : CryptographicException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The key unwrap operation returned an invalid value."
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public UnwrapFailed  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new UnwrapFailed(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// The named parameters specified in an operation are not known
/// </summary>
[global::System.Serializable]
public partial class UnknownNamedParameters : CryptographicException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The named parameters specified in an operation are not known"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public UnknownNamedParameters  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new UnknownNamedParameters(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// The cryptographic provider does not permit export of the private key parameters
/// </summary>
[global::System.Serializable]
public partial class NotExportable : CryptographicException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The cryptographic provider does not permit export of the private key parameters"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public NotExportable  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new NotExportable(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// Extensions class defining logging events and convenience methods.
/// </summary>
public  static partial class EventExtensions {

    /// <summary>
    /// Static initializer, is called once when the module loads.
    /// </summary>
    static EventExtensions() {
        }

	}



