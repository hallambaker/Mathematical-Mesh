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

using Microsoft.Extensions.Options;

namespace Goedel.Protocol.Service;


/// <summary>
/// Monitor provider interface. Used by a provider to advertise availability of a monitor.
/// </summary>
public interface IMonitorProvider {
    #region // Properties
    ///<summary>The monitor class to be exposed.</summary> 
    public HostMonitor Monitor { get; set; }
    #endregion
    }



/// <summary>
/// Service monitoring class.
/// </summary>
public class HostMonitor {
    #region // Properties
    ///<summary>Total result since the Monitor was last restarted.</summary> 
    public MonitorResult Total { get; private set; }

    ///<summary>Total results in the most recent sample interval.</summary> 
    public MonitorResult Recent { get; private set; }

    private MonitorResult current;
    private DateTime[] dispatcherStart;
    DateTime busyStart;
    
    ///<summary>The system logger.</summary> 
    public ILogger Logger { get; }

    #endregion
    #region // Constructors


    /// <summary>
    /// Constructor returning a monitor instance using the logger <paramref name="logger"/>.
    /// </summary>
    /// <param name="logger">The system logger output.</param>
    /// <param name="hostConfiguration">The host configuration</param>
    public HostMonitor(ILogger<HostMonitor> logger,
                IOptionsMonitor<GenericHostConfiguration> hostConfiguration) {
        
        Logger = logger;
        }

    #endregion
    #region // Methods 

    /// <summary>
    /// Write an event to the event logger.
    /// </summary>
    /// <param name="logEvent">The event to log.</param>
    /// <param name="args">Event arguments.</param>
    public void Log(FatEvent logEvent, params object[] args) =>
            Logger.Log(logEvent, args);

    /// <summary>
    /// Start the monitor with <paramref name="listeners"/>
    /// listeners and <paramref name="dispatchers"/> dispatchers.
    /// </summary>
    /// <param name="listeners">The number of listener threads.</param>
    /// <param name="dispatchers">The number of dispatcher threads.</param>
    public void StartMonitor(int listeners, int dispatchers) {

        // initialize the result buffers to null:
        current = new MonitorResult(listeners, dispatchers);
        Recent = current.CopyClear();
        Total = Recent.CopyClear();

        dispatcherStart = new DateTime[dispatchers];
        }


    /// <summary>
    /// Mark the start of period when the service is blocked because no dispatcher threads are available.
    /// </summary>
    public void StartBusy() => busyStart = DateTime.Now;

    /// <summary>
    /// Mark the end of period when the service is blocked because no dispatcher threads are available.
    /// </summary>
    public void EndBusy() {
        var now = DateTime.Now;
        var interval = (now - busyStart).Milliseconds;
        Interlocked.Add(ref (current.Busy), interval);
        }

    /// <summary>
    /// Mark the start of dispatch on thread <paramref name="dispatch"/>
    /// </summary>
    /// <param name="dispatch">Index of the thread that was started.</param>
    public void StartDispatch(int dispatch) {
        dispatcherStart[dispatch] = DateTime.Now;
        Interlocked.Increment(ref (current.DispatcherRequests[dispatch]));
        }

    /// <summary>
    /// Mark the end of dispatch on thread <paramref name="dispatch"/>
    /// </summary>
    /// <param name="dispatch">Index of the thread that was ended.</param>
    public void EndDispatch(int dispatch) {
        var now = DateTime.Now;
        var interval = (now - dispatcherStart[dispatch]).Milliseconds;
        Interlocked.Add(ref (current.DispatcherBusy[dispatch]), interval);
        }

    /// <summary>
    /// Mark the end of the 'Recent' period.
    /// </summary>
    public void MarkRecent() {
        lock (this) {
            Recent = current.CopyClear();
            Total.Add(Recent);
            }
        }


    /// <summary>
    /// Return a snapshot of the server status for the total time since the 
    /// collection period began and for the most recent collection interval.
    /// </summary>
    /// <returns></returns>
    public (MonitorResult, MonitorResult) GetStats() {
        lock (this) {
            var total = Total.Copy();
            var recent = Recent.Copy();
            recent.Add(current);
            return (total, recent);
            }
        }

    #endregion
    }
