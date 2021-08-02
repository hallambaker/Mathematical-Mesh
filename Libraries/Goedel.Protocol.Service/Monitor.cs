﻿using System;
using System.Threading;

namespace Goedel.Protocol.Service {


    /// <summary>
    /// Monitor provider interface. Used by a provider to advertise availability of a monitor.
    /// </summary>
    public interface IMonitorProvider {
        #region // Properties
        ///<summary>The monitor class to be exposed.</summary> 
        public Monitor Monitor { get; set; }
        #endregion
        }



    /// <summary>
    /// Service monitoring class.
    /// </summary>
    public class Monitor {
        #region // Properties
        ///<summary>Total result since the Monitor was last restarted.</summary> 
        public MonitorResult Total { get; private set; }

        ///<summary>Total results in the most recent sample interval.</summary> 
        public MonitorResult Recent { get; private set; }

        private MonitorResult current;
        DateTime[] dispatcherStart;
        DateTime busyStart;

        #endregion
        #region // Constructors


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

        #endregion
        #region // Methods 
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


    }
