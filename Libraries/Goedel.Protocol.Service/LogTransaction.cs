#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion



using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
namespace Goedel.Protocol.Service;



/// <summary>
/// Service level logging class.
/// </summary>
public class LogService {

    long transactionIdentifier = 0;




    ///<summary>Reporting mode for console output</summary>  
    public LogLevelSeverity ConsoleOutput { get; set; } = LogLevelSeverity.None;

    ///<summary>The host monitor tracking start and end of host requests.</summary> 
    public HostMonitor HostMonitor { get; }
    
    ///<summary>The logger instance</summary> 
    public ILogger Logger { get; set; } 



    ///<summary>The host configuration</summary> 
    GenericHostConfiguration GenericHostConfiguration { get; }

    ///<summary>The service configuration</summary> 
    ServiceConfiguration GenericServiceConfiguration { get; }

    /// <summary>
    /// Create a transaction logging service instance.
    /// </summary>
    /// <param name="genericHostConfiguration">The host configuration</param>
    /// <param name="meshHostConfiguration">The service configuration</param>
    /// <param name="hostMonitor">The host monitor service</param>
    /// <param name="first">Index of the first log entry</param>
    public LogService(
            GenericHostConfiguration genericHostConfiguration,
            ServiceConfiguration meshHostConfiguration,
            HostMonitor? hostMonitor, long first = 0) {
        GenericHostConfiguration = genericHostConfiguration;
        GenericServiceConfiguration = meshHostConfiguration;

        HostMonitor = hostMonitor;
        transactionIdentifier = first - 1;
        Logger = HostMonitor?.Logger ?? NullLogger.Instance;
        }


    /// <summary>
    /// Begin a new transaction.
    /// </summary>
    /// <param name="token">The transaction token.</param>
    /// <param name="request">The request identifier.</param>
    /// <returns>The transaction record.</returns>
    public LogTransaction Start(string token, IReport request) {

        var id = Interlocked.Increment(ref transactionIdentifier);
        var logTransaction = new LogTransaction(this) {
            TransactionIdentifier = id,
            Token = token,
            Request = request
            };
        Logger.TransactionStart(id, token);

        return logTransaction;
        }



    /// <summary>
    /// Report unknown command.
    /// </summary>
    /// <param name="command">The unknown command.</param>
    public void UnknownCommand(string command) {

        Logger.TransactionUnknown(command);

        //Log (Event.UnknownCommand, command);
        }

    /// <summary>
    /// Atomic write to console.
    /// </summary>
    /// <param name="output">The text to write.</param>
    static void WriteToConsole(StringBuilder output) {
        lock (Console.Out) {
            Console.WriteLine(output);
            }
        }

    /// <summary>
    /// Record successful completion of the transaction <paramref name="logTransaction"/>.
    /// </summary>
    /// <param name="logTransaction">Transaction to log.</param>
    internal void Success(LogTransaction logTransaction) {
        Logger.TransactionCompleted(logTransaction.TransactionIdentifier, logTransaction.Token);

        //Log(Event.EndTransaction, logTransaction.TransactionIdentifier,
        //    logTransaction.Token);
        }

    /// <summary>
    /// Record failure of the transaction <paramref name="logTransaction"/>.
    /// </summary>
    /// <param name="logTransaction">Transaction to log.</param>
    internal void Fail(LogTransaction logTransaction) {
        Logger.TransactionFailed(logTransaction.TransactionIdentifier, logTransaction.Token);

        //Log(Event.FailTransaction, logTransaction.TransactionIdentifier,
        //    logTransaction.Token);
        }

    //static bool ReportStart(LogLevelSeverity reportMode) =>
    //    reportMode == LogLevelSeverity.Trace | reportMode == LogLevelSeverity.Warning;

    }



/// <summary>
/// Record describing a specific transaction.
/// </summary>
public record LogTransaction {

    ///<summary>Transaction start time.</summary> 
    public System.DateTime Start { get; init; }

    ///<summary>Transaction finish time.</summary> 
    public System.DateTime Finish { get; set; } = System.DateTime.MinValue;

    ///<summary>The service logging instance.</summary> 
    public LogService LogService { get; }

    ///<summary>Unique, monotonically increasing transaction identifier.</summary> 
    public long TransactionIdentifier { get; init; }

    ///<summary>The transaction method identifier.</summary> 
    public string Token { get; init; }

    ///<summary>The request object.</summary> 
    public IReport Request { get; init; }

    ///<summary>The response object</summary> 
    public IReport Response { get; private set; }

    ///<summary>Exception (if occurred)</summary> 
    public Exception Exception { get; private set; }

    /// <summary>
    /// Constructor, create new instance of a transaction log entry for 
    /// <paramref name="logService"/>.
    /// </summary>
    /// <param name="logService">The service to log.</param>
    public LogTransaction(LogService logService) {
        Start = System.DateTime.Now;
        LogService = logService;
        }

    /// <summary>
    /// Report successful completion.
    /// </summary>
    /// <param name="response">The response object.</param>
    public void Success(IReport response) {
        Finish = System.DateTime.Now;
        Response = response;
        LogService.Success(this);
        }

    /// <summary>
    /// Report failure.
    /// </summary>
    /// <param name="exception">The exception raised.</param>
    /// <param name="response">The response object.</param>
    public void Fail(Exception exception, IReport response = null) {
        Finish = System.DateTime.Now;
        Exception = exception;
        Response = response;
        LogService.Fail(this);
        }


    }
