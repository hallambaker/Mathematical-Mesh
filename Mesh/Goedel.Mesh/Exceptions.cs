
//  This file was automatically generated at 18-Oct-22 12:41:56 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  exceptional version 3.0.0.867
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2022
//  
//  Build Platform: Win32NT 10.0.19042.0
//  
//  

//using System;
//using Goedel.Utilities;



#pragma warning disable IDE0079
#pragma warning disable IDE1006 // Naming Styles
namespace Goedel.Mesh ;


/// <summary>
/// An internal assertion check failed.
/// </summary>
[global::System.Serializable]
public partial class Internal : global::Goedel.Utilities.GoedelException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"An internal error occurred"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public Internal  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new Internal(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// </summary>
[global::System.Serializable]
public partial class NoDeviceSecret : Internal {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The device Secret required to perform the operation is not installed on this device"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public NoDeviceSecret  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new NoDeviceSecret(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// </summary>
[global::System.Serializable]
public partial class NoMeshSecret : Internal {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The Mesh Secret required to perform the operation is not installed on this device"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public NoMeshSecret  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new NoMeshSecret(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// The assertion presented was invalid.
/// </summary>
[global::System.Serializable]
public partial class InvalidAssertion : Internal {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The assertion is invalid"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public InvalidAssertion  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new InvalidAssertion(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// The profile presented was invalid.
/// </summary>
[global::System.Serializable]
public partial class InvalidProfile : InvalidAssertion {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The profile is invalid"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public InvalidProfile  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new InvalidProfile(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// The requestor is not authorized for the specified operation
/// </summary>
[global::System.Serializable]
public partial class NotAuthorized : Internal {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The requestor is not authorized for the specified operation"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public NotAuthorized  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new NotAuthorized(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// The request is not authenticated  for the specified operation
/// </summary>
[global::System.Serializable]
public partial class NotAuthenticated : Internal {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The request is not authenticated for the specified operation"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public NotAuthenticated  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new NotAuthenticated(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// Mesh Messages MUST specify a valid message ID.
/// </summary>
[global::System.Serializable]
public partial class InvalidMessageID : Internal {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"Mesh Messages MUST specify a valid message ID"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public InvalidMessageID  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new InvalidMessageID(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// </summary>
[global::System.Serializable]
public partial class InvalidMessage : Internal {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The Message was invalid."
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public InvalidMessage  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new InvalidMessage(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// The specified connection URI was invalid
/// </summary>
[global::System.Serializable]
public partial class InvalidUri : Internal {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The specified connection URI was invalid"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public InvalidUri  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new InvalidUri(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// </summary>
[global::System.Serializable]
public partial class InvalidDate : Internal {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The specified date was invalid."
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public InvalidDate  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new InvalidDate(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// </summary>
[global::System.Serializable]
public partial class NotAdministrator : global::Goedel.Utilities.GoedelException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"This device does not have administration capability"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public NotAdministrator  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new NotAdministrator(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// </summary>
[global::System.Serializable]
public partial class NotSuperAdministrator : global::Goedel.Utilities.GoedelException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"This device does not have administration capability"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public NotSuperAdministrator  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new NotSuperAdministrator(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// </summary>
[global::System.Serializable]
public partial class KeyRecoveryFailed : global::Goedel.Utilities.GoedelException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The attempt to perform threshold key recovery failed"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public KeyRecoveryFailed  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new KeyRecoveryFailed(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// </summary>
[global::System.Serializable]
public partial class KeyActivationFailed : global::Goedel.Utilities.GoedelException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The attempt to perform threshold key activation failed"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public KeyActivationFailed  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new KeyActivationFailed(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// </summary>
[global::System.Serializable]
public partial class UnknownRight : global::Goedel.Utilities.GoedelException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The right {0} is not known."
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public UnknownRight  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new UnknownRight(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// </summary>
[global::System.Serializable]
public partial class InvalidUriMethod : global::Goedel.Utilities.GoedelException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The specified URI method is invalid"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public InvalidUriMethod  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new InvalidUriMethod(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// </summary>
[global::System.Serializable]
public partial class ServerOperationFailed : global::Goedel.Utilities.GoedelException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"Essential server operation failed."
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public ServerOperationFailed  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new ServerOperationFailed(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// </summary>
[global::System.Serializable]
public partial class ServerResponseInvalid : global::Goedel.Utilities.GoedelException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The server returned an invalid response."
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public ServerResponseInvalid  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new ServerResponseInvalid(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// </summary>
[global::System.Serializable]
public partial class InvalidFormat : global::Goedel.Utilities.GoedelException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The format {0} is not supported for the specified output."
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public InvalidFormat  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new InvalidFormat(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// </summary>
[global::System.Serializable]
public partial class LockRequestTimeout : global::Goedel.Utilities.GoedelException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The operation timed out waiting to acquire a lock."
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public LockRequestTimeout  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new LockRequestTimeout(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// Extensions class defining logging events and convenience methods.
/// </summary>
public  static partial class EventExtensions {

    /// <summary>
    /// Static initializer, is called once when the module loads.
    /// </summary>
    static EventExtensions() {
        _ActivatePublic = LoggerMessage.Define<string,string,MeshActor,MeshKeyOperation,string>(
            LogLevel.Trace, new EventId(100, nameof(_ActivatePublic)),
            "Activate Seed {Seed} + Key {Base} for {Actor}-{Operation} = {Result}");
        _ActivatePrivate = LoggerMessage.Define<string,string,MeshActor,MeshKeyOperation,string>(
            LogLevel.Trace, new EventId(101, nameof(_ActivatePrivate)),
            "Activate Seed {Seed} + Key {Base} for {Actor}-{Operation} = {Result}");
        _InternMessage = LoggerMessage.Define<string,string,MessageStatus>(
            LogLevel.Trace, new EventId(102, nameof(_InternMessage)),
            "Intern EnvelopeID {EnvelopeID} Message {Message} Status {Status}");
        _GotMessage = LoggerMessage.Define<string,string,MessageStatus>(
            LogLevel.Trace, new EventId(103, nameof(_GotMessage)),
            "Got Message type {MessageType} Message {Message} Status {Status}");
        _AddAccessCapability = LoggerMessage.Define<string>(
            LogLevel.Trace, new EventId(104, nameof(_AddAccessCapability)),
            "Add accessCapability {Key}");
        _GrantStore = LoggerMessage.Define<string,Access,Degree,string>(
            LogLevel.Debug, new EventId(120, nameof(_GrantStore)),
            "Grant store {Store} access {Access} degree {Degree} key {KeyId}");
        _GrantAccount = LoggerMessage.Define<bool,bool,bool>(
            LogLevel.Debug, new EventId(121, nameof(_GrantAccount)),
            "Grant account decrypt {Decrypt} authenticate {Authenticate} sign {Sign}");
        _GrantRoot = LoggerMessage.Define(
            LogLevel.Debug, new EventId(121, nameof(_GrantRoot)),
            "Grant root");
        _GrantAdmin = LoggerMessage.Define(
            LogLevel.Debug, new EventId(121, nameof(_GrantAdmin)),
            "Grant administrator access");
        }


    private static readonly Action<ILogger, string, string, MeshActor, MeshKeyOperation, string, Exception> _ActivatePublic;

	/// <summary>
    /// Write an event of type ActivatePublic to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="seed">Seed value identifier</param>
	/// <param name="baseKey">Base key</param>
	/// <param name="actor">Actor</param>
	/// <param name="operation">Operation</param>
	/// <param name="result">Result key</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void ActivatePublic(
			this ILogger logger,
			string seed,
			string baseKey,
			MeshActor actor,
			MeshKeyOperation operation,
			string result,
			Exception _exception=null) {
        _ActivatePublic(logger, seed, baseKey, actor, operation, result, _exception);
        }


    private static readonly Action<ILogger, string, string, MeshActor, MeshKeyOperation, string, Exception> _ActivatePrivate;

	/// <summary>
    /// Write an event of type ActivatePrivate to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="seed">Seed value identifier</param>
	/// <param name="baseKey">Base key</param>
	/// <param name="actor">Actor</param>
	/// <param name="operation">Operation</param>
	/// <param name="result">Result key</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void ActivatePrivate(
			this ILogger logger,
			string seed,
			string baseKey,
			MeshActor actor,
			MeshKeyOperation operation,
			string result,
			Exception _exception=null) {
        _ActivatePrivate(logger, seed, baseKey, actor, operation, result, _exception);
        }


    private static readonly Action<ILogger, string, string, MessageStatus, Exception> _InternMessage;

	/// <summary>
    /// Write an event of type InternMessage to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="envelopeId">Envelope identifier</param>
	/// <param name="messageId">Message identifier</param>
	/// <param name="status">Message status</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void InternMessage(
			this ILogger logger,
			string envelopeId,
			string messageId,
			MessageStatus status,
			Exception _exception=null) {
        _InternMessage(logger, envelopeId, messageId, status, _exception);
        }


    private static readonly Action<ILogger, string, string, MessageStatus, Exception> _GotMessage;

	/// <summary>
    /// Write an event of type GotMessage to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="messageType">MessageType</param>
	/// <param name="messageId">Message identifier</param>
	/// <param name="status">Message status</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void GotMessage(
			this ILogger logger,
			string messageType,
			string messageId,
			MessageStatus status,
			Exception _exception=null) {
        _GotMessage(logger, messageType, messageId, status, _exception);
        }


    private static readonly Action<ILogger, string, Exception> _AddAccessCapability;

	/// <summary>
    /// Write an event of type AddAccessCapability to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="key">Authentication key</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void AddAccessCapability(
			this ILogger logger,
			string key,
			Exception _exception=null) {
        _AddAccessCapability(logger, key, _exception);
        }


    private static readonly Action<ILogger, string, Access, Degree, string, Exception> _GrantStore;

	/// <summary>
    /// Write an event of type GrantStore to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="store">Store name</param>
	/// <param name="access">Access type</param>
	/// <param name="degree">Degree (direct/threshold)</param>
	/// <param name="keyId">Key identifier</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void GrantStore(
			this ILogger logger,
			string store,
			Access access,
			Degree degree,
			string keyId,
			Exception _exception=null) {
        _GrantStore(logger, store, access, degree, keyId, _exception);
        }


    private static readonly Action<ILogger, bool, bool, bool, Exception> _GrantAccount;

	/// <summary>
    /// Write an event of type GrantAccount to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="decrypt">Decrypt</param>
	/// <param name="authenticate">Authenticate</param>
	/// <param name="sign">Sign</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void GrantAccount(
			this ILogger logger,
			bool decrypt,
			bool authenticate,
			bool sign,
			Exception _exception=null) {
        _GrantAccount(logger, decrypt, authenticate, sign, _exception);
        }


    private static readonly Action<ILogger, Exception> _GrantRoot;

	/// <summary>
    /// Write an event of type GrantRoot to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void GrantRoot(
			this ILogger logger,
			Exception _exception=null) {
        _GrantRoot(logger, _exception);
        }


    private static readonly Action<ILogger, Exception> _GrantAdmin;

	/// <summary>
    /// Write an event of type GrantAdmin to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void GrantAdmin(
			this ILogger logger,
			Exception _exception=null) {
        _GrantAdmin(logger, _exception);
        }

	}



