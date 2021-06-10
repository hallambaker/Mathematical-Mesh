using System;

namespace Goedel.Command {
    /// <summary>Track start and end time of parse.</summary>
    public abstract class Dispatch {
        /// <summary>Record start time.</summary>
        public DateTime Started = DateTime.Now;

        /// <summary>Calculate elapsed time.</summary>
        public TimeSpan Elapsed => DateTime.Now - Started;

        /// <summary>Command type data</summary>
        public virtual Type[] _Data { get; set; }

        /// <summary>Command description</summary>
        public virtual DescribeCommandEntry DescribeCommand { get; set; }
        }

    }
