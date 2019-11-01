using System;
using System.Collections.Generic;
using System.Threading;

namespace Goedel.Utilities {

    /// <summary>
    /// Class that provides a number guaranteed to be unique for a particular run.
    /// </summary>
    public static class Unique {
        static int Counter = 0;

        /// <summary>
        /// Create a filename that is guaranteed to be unique for this particular run.
        /// </summary>
        /// <returns>A string containing successive integers 1, 2, 3,...</returns>
        public static string Next() {

            var code = Interlocked.Increment(ref Counter);
            var id = Thread.CurrentThread.ManagedThreadId;

            return $"{code}-{id}";
            }




        }
    }
