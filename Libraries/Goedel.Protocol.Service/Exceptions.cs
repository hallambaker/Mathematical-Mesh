
//  This file was automatically generated at 20-Jun-22 5:46:44 PM
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
namespace Goedel.Protocol.Service ;


/// <summary>
/// This platform does not support HTTP service
/// </summary>
[global::System.Serializable]
public partial class ServerNotSupported : global::Goedel.Utilities.GoedelException {

    ///<summary>The exception formatting delegate. May be overriden 
	///locally or globally to implement different exception formatting.</summary>
	public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
			global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


	///<summary>Templates for formatting response messages.</summary>
	public static new System.Collections.Generic.List<string> Templates {get; set;} = 
			new () {

			"This platform does not support HTTP service."
			};

	/// <summary>
	/// Construct instance for exception
	/// </summary>		
	/// <param name="description">Description of the error, may be used to override the 
	/// generated message.</param>	
	/// <param name="inner">Inner Exception</param>	
	/// <param name="args">Optional list of parameterized arguments.</param>
	public ServerNotSupported  (string description=null, System.Exception inner=null,
		params object[] args) : 
			base (ExceptionFormatDelegate(description, Templates,
				null, args), inner) {
		}





	/// <summary>
    /// The public fatory delegate
    /// </summary>
    /// public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

    static System.Exception _Throw(object reasons) => new ServerNotSupported(args:reasons) ;
		
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
        _ListenerStart = LoggerMessage.Define(
            LogLevel.Information, new EventId(1, nameof(_ListenerStart)),
            "Starting Listener");
        _ListenerEnd = LoggerMessage.Define(
            LogLevel.Information, new EventId(2, nameof(_ListenerEnd)),
            "Ending listener");
        _ServiceStart = LoggerMessage.Define<string,string,string>(
            LogLevel.Information, new EventId(3, nameof(_ServiceStart)),
            "Starting service {ServiceName} key {serviceUdf} Host {hostUdf}");
        _ServiceEnd = LoggerMessage.Define<string>(
            LogLevel.Information, new EventId(4, nameof(_ServiceEnd)),
            "Ending listener {ServiceName}");
        _TransactionStart = LoggerMessage.Define<long,string>(
            LogLevel.Debug, new EventId(5, nameof(_TransactionStart)),
            "Starting transation {TransactionId} {TransactionMethod}");
        _TransactionCompleted = LoggerMessage.Define<long,string>(
            LogLevel.Information, new EventId(6, nameof(_TransactionCompleted)),
            "Transaction completed {TransactionId} {TransactionMethod}");
        _LoadContextUser = LoggerMessage.Define<string>(
            LogLevel.Trace, new EventId(100, nameof(_LoadContextUser)),
            "Load context for user {accountAddress}");
        _DisposeContextUser = LoggerMessage.Define<string>(
            LogLevel.Trace, new EventId(101, nameof(_DisposeContextUser)),
            "Dispose context for user {accountAddress}");
        _OpenFile = LoggerMessage.Define<string,string>(
            LogLevel.Trace, new EventId(101, nameof(_OpenFile)),
            "Open file {FileName} with access {aCCESS}");
        _CloseFile = LoggerMessage.Define<string>(
            LogLevel.Trace, new EventId(102, nameof(_CloseFile)),
            "Close file {FileName}");
        _OpenContainer = LoggerMessage.Define<string,string>(
            LogLevel.Trace, new EventId(103, nameof(_OpenContainer)),
            "Open file {FileName} with access {aCCESS}");
        _CloseContainer = LoggerMessage.Define<string>(
            LogLevel.Trace, new EventId(104, nameof(_CloseContainer)),
            "Close file {FileName}");
        _TransactionFailed = LoggerMessage.Define<long,string>(
            LogLevel.Information, new EventId(1000, nameof(_TransactionFailed)),
            "Transaction failed {TransactionId} {TransactionMethod}");
        _TransactionUnauthorized = LoggerMessage.Define<long,string>(
            LogLevel.Information, new EventId(1001, nameof(_TransactionUnauthorized)),
            "Transaction not authorized {TransactionId} {TransactionMethod}");
        _TransactionNotSupported = LoggerMessage.Define<string>(
            LogLevel.Information, new EventId(1002, nameof(_TransactionNotSupported)),
            "Transaction not supported {TransactionMethod}");
        _TransactionUnknown = LoggerMessage.Define<string>(
            LogLevel.Information, new EventId(1003, nameof(_TransactionUnknown)),
            "Transaction not known {TransactionMethod}");
        _UnhandledException = LoggerMessage.Define(
            LogLevel.Information, new EventId(2000, nameof(_UnhandledException)),
            "Unhandled exception");
        }


    private static readonly Action<ILogger, Exception> _ListenerStart;

	/// <summary>
    /// Write an event of type ListenerStart to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void ListenerStart(
			this ILogger logger,
			Exception _exception=null) {
        _ListenerStart(logger, _exception);
        }


    private static readonly Action<ILogger, Exception> _ListenerEnd;

	/// <summary>
    /// Write an event of type ListenerEnd to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void ListenerEnd(
			this ILogger logger,
			Exception _exception=null) {
        _ListenerEnd(logger, _exception);
        }


    private static readonly Action<ILogger, string, string, string, Exception> _ServiceStart;

	/// <summary>
    /// Write an event of type ServiceStart to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="serviceName">The service name</param>
	/// <param name="serviceUdf">Service key identifier</param>
	/// <param name="hostUdf">Host key identifier</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void ServiceStart(
			this ILogger logger,
			string serviceName,
			string serviceUdf,
			string hostUdf,
			Exception _exception=null) {
        _ServiceStart(logger, serviceName, serviceUdf, hostUdf, _exception);
        }


    private static readonly Action<ILogger, string, Exception> _ServiceEnd;

	/// <summary>
    /// Write an event of type ServiceEnd to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="serviceName">The service name</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void ServiceEnd(
			this ILogger logger,
			string serviceName,
			Exception _exception=null) {
        _ServiceEnd(logger, serviceName, _exception);
        }


    private static readonly Action<ILogger, long, string, Exception> _TransactionStart;

	/// <summary>
    /// Write an event of type TransactionStart to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="transactionId">Transaction identifier</param>
	/// <param name="method">The transaction method</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void TransactionStart(
			this ILogger logger,
			long transactionId,
			string method,
			Exception _exception=null) {
        _TransactionStart(logger, transactionId, method, _exception);
        }


    private static readonly Action<ILogger, long, string, Exception> _TransactionCompleted;

	/// <summary>
    /// Write an event of type TransactionCompleted to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="transactionId">Transaction identifier</param>
	/// <param name="method">The transaction method</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void TransactionCompleted(
			this ILogger logger,
			long transactionId,
			string method,
			Exception _exception=null) {
        _TransactionCompleted(logger, transactionId, method, _exception);
        }


    private static readonly Action<ILogger, string, Exception> _LoadContextUser;

	/// <summary>
    /// Write an event of type LoadContextUser to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="accountAddress">The account address</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void LoadContextUser(
			this ILogger logger,
			string accountAddress,
			Exception _exception=null) {
        _LoadContextUser(logger, accountAddress, _exception);
        }


    private static readonly Action<ILogger, string, Exception> _DisposeContextUser;

	/// <summary>
    /// Write an event of type DisposeContextUser to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="accountAddress">The account address</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void DisposeContextUser(
			this ILogger logger,
			string accountAddress,
			Exception _exception=null) {
        _DisposeContextUser(logger, accountAddress, _exception);
        }


    private static readonly Action<ILogger, string, string, Exception> _OpenFile;

	/// <summary>
    /// Write an event of type OpenFile to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="filename">The file name</param>
	/// <param name="mode">The access mode</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void OpenFile(
			this ILogger logger,
			string filename,
			string mode,
			Exception _exception=null) {
        _OpenFile(logger, filename, mode, _exception);
        }


    private static readonly Action<ILogger, string, Exception> _CloseFile;

	/// <summary>
    /// Write an event of type CloseFile to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="filename">The file name</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void CloseFile(
			this ILogger logger,
			string filename,
			Exception _exception=null) {
        _CloseFile(logger, filename, _exception);
        }


    private static readonly Action<ILogger, string, string, Exception> _OpenContainer;

	/// <summary>
    /// Write an event of type OpenContainer to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="filename">The file name</param>
	/// <param name="mode">The access mode</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void OpenContainer(
			this ILogger logger,
			string filename,
			string mode,
			Exception _exception=null) {
        _OpenContainer(logger, filename, mode, _exception);
        }


    private static readonly Action<ILogger, string, Exception> _CloseContainer;

	/// <summary>
    /// Write an event of type CloseContainer to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="filename">The file name</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void CloseContainer(
			this ILogger logger,
			string filename,
			Exception _exception=null) {
        _CloseContainer(logger, filename, _exception);
        }


    private static readonly Action<ILogger, long, string, Exception> _TransactionFailed;

	/// <summary>
    /// Write an event of type TransactionFailed to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="transactionId">Transaction identifier</param>
	/// <param name="method">The transaction method</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void TransactionFailed(
			this ILogger logger,
			long transactionId,
			string method,
			Exception _exception=null) {
        _TransactionFailed(logger, transactionId, method, _exception);
        }


    private static readonly Action<ILogger, long, string, Exception> _TransactionUnauthorized;

	/// <summary>
    /// Write an event of type TransactionUnauthorized to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="transactionId">Transaction identifier</param>
	/// <param name="method">The transaction method</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void TransactionUnauthorized(
			this ILogger logger,
			long transactionId,
			string method,
			Exception _exception=null) {
        _TransactionUnauthorized(logger, transactionId, method, _exception);
        }


    private static readonly Action<ILogger, string, Exception> _TransactionNotSupported;

	/// <summary>
    /// Write an event of type TransactionNotSupported to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="method">The transaction method</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void TransactionNotSupported(
			this ILogger logger,
			string method,
			Exception _exception=null) {
        _TransactionNotSupported(logger, method, _exception);
        }


    private static readonly Action<ILogger, string, Exception> _TransactionUnknown;

	/// <summary>
    /// Write an event of type TransactionUnknown to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="method">The transaction method</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void TransactionUnknown(
			this ILogger logger,
			string method,
			Exception _exception=null) {
        _TransactionUnknown(logger, method, _exception);
        }


    private static readonly Action<ILogger, Exception> _UnhandledException;

	/// <summary>
    /// Write an event of type UnhandledException to <paramref name="logger"/> 
    /// </summary>
    /// <param name="logger">The logger to write the output to.</param>
	/// <param name="_exception">Exception (if thrown)</param>
    public static void UnhandledException(
			this ILogger logger,
			Exception _exception=null) {
        _UnhandledException(logger, _exception);
        }

	}



