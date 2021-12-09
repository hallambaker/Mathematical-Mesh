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



namespace Goedel.Protocol.Service;


/// <summary>
/// Service level logging class.
/// </summary>
public class LogService {

    long transactionIdentifier = 0;

    ///<summary>Reporting mode for console output</summary>  
    public ReportMode ConsoleOutput { get; set; } = ReportMode.None;

    ///<summary>The host monitor tracking start and end of host requests.</summary> 
    public HostMonitor HostMonitor { get; }

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="hostMonitor">The host montior describing the lower level connection
    /// status.</param>
    /// <param name="first">The first transaction number to be issued.</param>
    public LogService(
            IServiceConfiguration serviceConfiguration,
            IHostConfiguration hostConfiguration,
            HostMonitor hostMonitor, long first = 0) {
        HostMonitor = hostMonitor;
        transactionIdentifier = first - 1;

        ConsoleOutput = hostConfiguration.ConsoleOutput;

        if (ConsoleOutput != ReportMode.None) {
            var output = new StringBuilder();
            output.Append(DateTime.Now.ToRFC3339());
            output.AppendLine(
                $" {Resources.StartService}: {serviceConfiguration.WellKnown}" +
                $" {Resources.Host} {hostConfiguration.Id}" +
                $" {Resources.Port} {hostConfiguration.Port}");
            output.AppendLine($"    { Resources.ServiceProfile}: { hostConfiguration.ProfileUdf}");
            output.AppendLine($"    { Resources.DeviceProfile}: { hostConfiguration.DeviceUdf}");
            output.AppendLine($"    { Resources.Path}: {hostConfiguration.Path}");
            if (serviceConfiguration.Addresses != null) {
                foreach (var address in serviceConfiguration.Addresses) {
                    output.AppendLine($"    { Resources.ServiceAddress}: {address}");
                    }
                }
            if (serviceConfiguration.Addresses != null) {
                foreach (var dns in hostConfiguration.DNS) {
                    output.AppendLine($"    { Resources.HostAddress}: {dns}");
                    }
                }
            WriteToConsole(output);
            }
        }

    /// <summary>
    /// Begin a new transaction.
    /// </summary>
    /// <param name="token">The transaction token.</param>
    /// <param name="request">The request identifier.</param>
    /// <returns>The transaction record.</returns>
    public LogTransaction Start(string token, IReport request) {

        var id = Interlocked.Increment(ref transactionIdentifier);
        var transaction = new LogTransaction(this) {
            TransactionIdentifier = id,
            Token = token,
            Request = request
            };


        return transaction;
        }



    /// <summary>
    /// Report an error before transaction was begun.
    /// </summary>
    /// <param name="exception">The exception thrown.</param>
    public void UnknownCommand(Exception exception) {
        var output = new StringBuilder();

        output.Append(DateTime.Now.ToRFC3339());
        output.Append($" { Resources.Error} { Resources.UnknownCommand} {exception}");

        WriteToConsole(output);
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
    /// Record the start of the transaction <paramref name="logTransaction"/>.
    /// </summary>
    /// <param name="logTransaction">Transaction to log.</param>
    internal void Start(LogTransaction logTransaction) {
        if (!ReportStart(ConsoleOutput)) {
            return;
            }

        var output = new StringBuilder();
        output.Append(logTransaction.Start.ToRFC3339());
        output.Append($" { Resources.TransactionStart} ");
        output.Append(logTransaction.TransactionIdentifier);
        output.Append(" ");
        output.Append(logTransaction.Token);
        logTransaction.Request?.Report(output, ConsoleOutput);

        WriteToConsole(output);
        }

    /// <summary>
    /// Record successful completion of the transaction <paramref name="logTransaction"/>.
    /// </summary>
    /// <param name="logTransaction">Transaction to log.</param>
    internal void Success(LogTransaction logTransaction) {
        var output = new StringBuilder();

        output.Append(logTransaction.Start.ToRFC3339());
        output.Append($" { Resources.TransactionSuccess} ");

        if (!ReportStart(ConsoleOutput)) {
            output.Append(logTransaction.Token);
            logTransaction.Request?.Report(output, ConsoleOutput);
            }
        else {
            output.Append(logTransaction.TransactionIdentifier);
            }
        logTransaction.Response?.Report(output, ConsoleOutput);

        WriteToConsole(output);

        }

    /// <summary>
    /// Record failure of the transaction <paramref name="logTransaction"/>.
    /// </summary>
    /// <param name="logTransaction">Transaction to log.</param>
    internal void Fail(LogTransaction logTransaction) {
        var output = new StringBuilder();

        output.Append(logTransaction.Start.ToRFC3339());
        output.Append($" { Resources.TransactionFail} ");

        if (!ReportStart(ConsoleOutput)) {
            output.Append(logTransaction.Token);
            logTransaction.Request?.Report(output, ConsoleOutput);
            }
        else {
            output.Append(logTransaction.TransactionIdentifier);
            }
        output.Append(logTransaction.Exception);

        if (logTransaction.Response != null) {
            logTransaction.Response?.Report(output, ConsoleOutput);
            }

        WriteToConsole(output);
        }

    static bool ReportStart(ReportMode reportMode) =>
        reportMode == ReportMode.Full | reportMode == ReportMode.Event;

    }



/// <summary>
/// Record describing a specific transaction.
/// </summary>
public record LogTransaction {

    ///<summary>Transaction start time.</summary> 
    public DateTime Start { get; init; }

    ///<summary>Transaction finish time.</summary> 
    public DateTime Finish { get; set; } = DateTime.MinValue;

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
        Start = DateTime.Now;
        LogService = logService;
        LogService.Start(this);
        }

    /// <summary>
    /// Report successful completion.
    /// </summary>
    /// <param name="response">The response object.</param>
    public void Success(IReport response) {
        Finish = DateTime.Now;
        Response = response;
        LogService.Success(this);
        }

    /// <summary>
    /// Report failure.
    /// </summary>
    /// <param name="exception">The exception raised.</param>
    /// <param name="response">The response object.</param>
    public void Fail(Exception exception, IReport response = null) {
        Finish = DateTime.Now;
        Exception = exception;
        Response = response;
        LogService.Fail(this);
        }


    }
