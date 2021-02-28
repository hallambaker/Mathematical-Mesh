using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Goedel.Utilities;

namespace Goedel.Protocol.Service {


    /// <summary>
    /// Monitor provider interface. Used by a provider to advertise availability of a monitor.
    /// </summary>
    public interface IMonitorProvider {

        ///<summary>The monitor class to be exposed.</summary> 
        public Monitor Monitor { get; set; }

        }



    /// <summary>
    /// Service monitoring class.
    /// </summary>
    public class Monitor {

        ///<summary>Total result since the Monitor was last restarted.</summary> 
        public MonitorResult Total { get; private set; }
        
        ///<summary>Total results in the most recent sample interval.</summary> 
        public MonitorResult Recent { get; private set; }

        private MonitorResult current;
        DateTime[] dispatcherStart;
        DateTime busyStart;




        /// <summary>
        /// Constructor returning a monitor instance for <paramref name="listeners"/>
        /// listeners and <paramref name="dispatchers"/> dispatchers.
        /// </summary>
        /// <param name="listeners">The number of listener threads.</param>
        /// <param name="dispatchers">The number of dispatcher threads.</param>
        public Monitor(int listeners, int dispatchers) {

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
            Interlocked.Increment (ref (current.DispatcherRequests[dispatch]));
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
        public void MarkRecent () {
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
        public (MonitorResult, MonitorResult) GetStats () {
            lock (this) {
                var total = Total.Copy();
                var recent = Recent.Copy();
                recent.Add(current);
                return (total, recent);
                }
            }


        }

    /// <summary>
    /// Class containing a set of monitor results.
    /// </summary>
    public class MonitorResult {
        ///<summary>The time at which the result interval began</summary> 
        public DateTime TimeBegin => new DateTime(timeBegin);

        ///<summary>The time at which the next result interval began</summary> 
        public DateTime TimeEnd => new DateTime(timeEnd);

        ///<summary>The elapsed time.</summary> 
        public long TimeElapsed => 
            (timeEnd == DateTime.MaxValue.Ticks ? DateTime.Now.Ticks : timeEnd) - timeBegin;

        long timeBegin;
        long timeEnd;

        ///<summary>Number of listener events received</summary> 
        public int[] ListenerRequests => listenerRequests;
        private int[] listenerRequests;


        ///<summary>Number of dispatcher requests started.</summary> 
        public int[] DispatcherRequests => dispatcherRequests;
        private int[] dispatcherRequests;

        ///<summary>Time the dispatcher thread was busy in milliseconds</summary> 
        public long[] DispatcherBusy => dispatcherBusy;
        private long[] dispatcherBusy;

        ///<summary>Time all threads were busy.</summary> 
        public long Busy = 0;

        /// <summary>
        /// Constructor creating a new result for <paramref name="listeners"/> and
        /// <paramref name="dispatchers"/> dispatchers.
        /// </summary>
        /// <param name="listeners">The number of listener threads.</param>
        /// <param name="dispatchers">The number of dispatcher threads.</param>
        public MonitorResult(int listeners, int dispatchers) {
            timeBegin = DateTime.Now.Ticks;
            timeEnd = DateTime.MaxValue.Ticks;
            listenerRequests = new int[listeners];
            dispatcherRequests = new int[dispatchers];
            dispatcherBusy = new long[dispatchers];
            }

        /// <summary>
        /// Add the continguous result <paramref name="value"/> to the current result.
        /// </summary>
        /// <param name="value">The contiguous result data.</param>
        public void Add(MonitorResult value) {
            timeEnd = value.timeEnd;
            lock (value) {
                for (var i = 0; i < listenerRequests.Length; i++) {
                    Interlocked.Add(ref listenerRequests[i], value.listenerRequests[i]);
                    }
                for (var i = 0; i < dispatcherRequests.Length; i++) {
                    Interlocked.Add(ref dispatcherRequests[i], value.dispatcherRequests[i]);
                    Interlocked.Add(ref dispatcherBusy[i], value.dispatcherBusy[i]);
                    }
                }

            }

        /// <summary>
        /// Create a copy of the current monitor result, clear the current values and return
        /// the copy. This is performed 
        /// </summary>
        /// <returns>The copy of the original values.</returns>
        public MonitorResult CopyClear() {
            var result = new MonitorResult(ListenerRequests.Length, DispatcherRequests.Length);

            result.listenerRequests = Interlocked.Exchange(ref listenerRequests, result.listenerRequests);
            result.dispatcherRequests = Interlocked.Exchange(ref dispatcherRequests, result.dispatcherRequests);
            result.dispatcherBusy = Interlocked.Exchange(ref dispatcherBusy, result.dispatcherBusy);

            return result;
            }

        /// <summary>
        /// Create a copy of the current monitor result and return
        /// the copy. This is performed 
        /// </summary>
        /// <returns>The copy of the values.</returns>
        public MonitorResult Copy() {
            var result = new MonitorResult(ListenerRequests.Length, DispatcherRequests.Length);
            result.timeEnd = result.timeBegin;
            result.timeBegin = timeBegin;
            result.listenerRequests = listenerRequests;
            result.dispatcherRequests = dispatcherRequests;
            result.dispatcherBusy = dispatcherBusy;

            return result;
            }
        }


    }
