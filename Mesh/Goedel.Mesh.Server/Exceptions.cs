
//  This file was automatically generated at 17-May-22 5:11:06 PM
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
namespace Goedel.Mesh.Server ;


/// <summary>
/// Generic Mesh Service Error
/// </summary>
[global::System.Serializable]
public partial class MeshServerException : global::Goedel.Utilities.GoedelException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"Unknown error occured."
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public MeshServerException  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new MeshServerException(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// Generic Mesh Service Error
/// </summary>
[global::System.Serializable]
public partial class MeshServerResponse : MeshServerException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"Mesh message response exception"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public MeshServerResponse  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new MeshServerResponse(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// The responseId was not found
/// </summary>
[global::System.Serializable]
public partial class MeshResponseNotFound : MeshServerResponse {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The responseId was not found"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public MeshResponseNotFound  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new MeshResponseNotFound(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// The respondent replied that they refused to accept the request
/// </summary>
[global::System.Serializable]
public partial class MeshResponseRefused : MeshServerResponse {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The respondent refused to accept the request"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public MeshResponseRefused  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new MeshResponseRefused(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// The request message expired before the respondent replied
/// </summary>
[global::System.Serializable]
public partial class MeshResponseExpired : MeshServerResponse {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The request message expired before the respondent replied"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public MeshResponseExpired  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new MeshResponseExpired(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// The service request message is larger than permitted by the service policy
/// </summary>
[global::System.Serializable]
public partial class MeshRequestSize : MeshServerException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The service request message is larger than permitted by the service policy"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public MeshRequestSize  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new MeshRequestSize(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// </summary>
[global::System.Serializable]
public partial class MeshUnknownAccount : MeshServerException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The specified account is unknown"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public MeshUnknownAccount  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new MeshUnknownAccount(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// </summary>
[global::System.Serializable]
public partial class MeshAccountAlreadyRegistered : MeshServerException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The specified account is already registered"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public MeshAccountAlreadyRegistered  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new MeshAccountAlreadyRegistered(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// </summary>
[global::System.Serializable]
public partial class MeshRedirect : MeshServerException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The specified account has been transfered to another service"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public MeshRedirect  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new MeshRedirect(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// </summary>
[global::System.Serializable]
public partial class MeshOperationFailed : MeshServerException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"A requested cryptographic operation failed."
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public MeshOperationFailed  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new MeshOperationFailed(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// </summary>
[global::System.Serializable]
public partial class MeshMessageControl : MeshServerException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"Mesh message control exception"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public MeshMessageControl  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new MeshMessageControl(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// </summary>
[global::System.Serializable]
public partial class MeshServiceBlockedSender : MeshMessageControl {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The request was ignored because the sending account is blocked by the service"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public MeshServiceBlockedSender  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new MeshServiceBlockedSender(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// </summary>
[global::System.Serializable]
public partial class MeshServiceBlockedService : MeshMessageControl {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The request was ignored because the requesting service is blocked by the service"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public MeshServiceBlockedService  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new MeshServiceBlockedService(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// </summary>
[global::System.Serializable]
public partial class MeshRecipientBlockedSender : MeshMessageControl {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The request was ignored because the sending account is blocked by the recipient"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public MeshRecipientBlockedSender  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new MeshRecipientBlockedSender(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// </summary>
[global::System.Serializable]
public partial class MeshRecipientBlockedService : MeshMessageControl {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The request was ignored because the requesting service is blocked by the recipient"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public MeshRecipientBlockedService  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new MeshRecipientBlockedService(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// </summary>
[global::System.Serializable]
public partial class MeshMessageInsufficientPrivilege : MeshMessageControl {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The request was refused because the sender has insufficient privileges"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public MeshMessageInsufficientPrivilege  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new MeshMessageInsufficientPrivilege(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// </summary>
[global::System.Serializable]
public partial class MeshMessageInvalid : MeshMessageControl {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The request was refused because it was invalid"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public MeshMessageInvalid  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new MeshMessageInvalid(args:reasons) ;
		
	/// <summary>
    /// The public fatory delegate
    /// </summary>
    public static new global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


    }


/// <summary>
/// </summary>
[global::System.Serializable]
public partial class MeshMessageUnsupported : MeshMessageControl {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"The request was refused because the message type is not supported"
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public MeshMessageUnsupported  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new MeshMessageUnsupported(args:reasons) ;
		
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
        _DispatchBegin = LoggerMessage.Define(
            LogLevel.Trace, new EventId(100, nameof(_DispatchBegin)),
            "Dispatch begin");
        _DispatchParse = LoggerMessage.Define(
            LogLevel.Trace, new EventId(101, nameof(_DispatchParse)),
            "Dispatch parse failed");
        _DispatchStart = LoggerMessage.Define<string>(
            LogLevel.Trace, new EventId(102, nameof(_DispatchStart)),
            "Dispatch start transaction {Request}");
        _DispatchFail = LoggerMessage.Define<string,string>(
            LogLevel.Trace, new EventId(103, nameof(_DispatchFail)),
            "Dispatch transaction fail {Request} {Reason}");
        _DispatchComplete = LoggerMessage.Define<string>(
            LogLevel.Trace, new EventId(104, nameof(_DispatchComplete)),
            "Dispatch transaction fail {Request}");
        _LockAttempt = LoggerMessage.Define<string>(
            LogLevel.Trace, new EventId(110, nameof(_LockAttempt)),
            "Lock attempt {Resource}");
        _LockAcquire = LoggerMessage.Define<string>(
            LogLevel.Trace, new EventId(111, nameof(_LockAcquire)),
            "Lock acquired {Resource}");
        _LockRelease = LoggerMessage.Define<string>(
            LogLevel.Trace, new EventId(112, nameof(_LockRelease)),
            "Lock released {Resource}");
        _ThresholdKeyAgreement = LoggerMessage.Define<string>(
            LogLevel.Trace, new EventId(120, nameof(_ThresholdKeyAgreement)),
            "Threshold Key Agreement {Account}");
        _ThresholdKeyIdentifier = LoggerMessage.Define<string,string>(
            LogLevel.Trace, new EventId(121, nameof(_ThresholdKeyIdentifier)),
            "Threshold Key Agreement {Account} / {KeyId}");
        _ThresholdAuthorization = LoggerMessage.Define<string,bool>(
            LogLevel.Trace, new EventId(122, nameof(_ThresholdAuthorization)),
            "Threshold Key Agreement {Account} / {KeyId}");
        }


    private static readonly Action<ILogger, Exception> _DispatchBegin;

	/// <summary>
    /// Write an event of type DispatchBegin to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void DispatchBegin(
			this ILogger logger,
			Exception _exception=null) {
        _DispatchBegin(logger, _exception);
        }


    private static readonly Action<ILogger, Exception> _DispatchParse;

	/// <summary>
    /// Write an event of type DispatchParse to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void DispatchParse(
			this ILogger logger,
			Exception _exception=null) {
        _DispatchParse(logger, _exception);
        }


    private static readonly Action<ILogger, string, Exception> _DispatchStart;

	/// <summary>
    /// Write an event of type DispatchStart to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="request">Request name</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void DispatchStart(
			this ILogger logger,
			string request,
			Exception _exception=null) {
        _DispatchStart(logger, request, _exception);
        }


    private static readonly Action<ILogger, string, string, Exception> _DispatchFail;

	/// <summary>
    /// Write an event of type DispatchFail to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="request">Request name</param>
	/// <param name="reason">Reason</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void DispatchFail(
			this ILogger logger,
			string request,
			string reason,
			Exception _exception=null) {
        _DispatchFail(logger, request, reason, _exception);
        }


    private static readonly Action<ILogger, string, Exception> _DispatchComplete;

	/// <summary>
    /// Write an event of type DispatchComplete to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="request">Request name</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void DispatchComplete(
			this ILogger logger,
			string request,
			Exception _exception=null) {
        _DispatchComplete(logger, request, _exception);
        }


    private static readonly Action<ILogger, string, Exception> _LockAttempt;

	/// <summary>
    /// Write an event of type LockAttempt to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="resource">Resource name</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void LockAttempt(
			this ILogger logger,
			string resource,
			Exception _exception=null) {
        _LockAttempt(logger, resource, _exception);
        }


    private static readonly Action<ILogger, string, Exception> _LockAcquire;

	/// <summary>
    /// Write an event of type LockAcquire to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="resource">Resource name</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void LockAcquire(
			this ILogger logger,
			string resource,
			Exception _exception=null) {
        _LockAcquire(logger, resource, _exception);
        }


    private static readonly Action<ILogger, string, Exception> _LockRelease;

	/// <summary>
    /// Write an event of type LockRelease to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="resource">Resource name</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void LockRelease(
			this ILogger logger,
			string resource,
			Exception _exception=null) {
        _LockRelease(logger, resource, _exception);
        }


    private static readonly Action<ILogger, string, Exception> _ThresholdKeyAgreement;

	/// <summary>
    /// Write an event of type ThresholdKeyAgreement to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="account">Account name</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void ThresholdKeyAgreement(
			this ILogger logger,
			string account,
			Exception _exception=null) {
        _ThresholdKeyAgreement(logger, account, _exception);
        }


    private static readonly Action<ILogger, string, string, Exception> _ThresholdKeyIdentifier;

	/// <summary>
    /// Write an event of type ThresholdKeyIdentifier to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="account">Account name</param>
	/// <param name="keyId">Key Identifier</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void ThresholdKeyIdentifier(
			this ILogger logger,
			string account,
			string keyId,
			Exception _exception=null) {
        _ThresholdKeyIdentifier(logger, account, keyId, _exception);
        }


    private static readonly Action<ILogger, string, bool, Exception> _ThresholdAuthorization;

	/// <summary>
    /// Write an event of type ThresholdAuthorization to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="account">Account name</param>
	/// <param name="authorized">Authorized</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void ThresholdAuthorization(
			this ILogger logger,
			string account,
			bool authorized,
			Exception _exception=null) {
        _ThresholdAuthorization(logger, account, authorized, _exception);
        }

	}



