using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Goedel.Utilities {

    /// <summary>
    /// Delegate specifying an initialization routine to be called.
    /// </summary>
    /// <param name="TestMode">If true, initialize package using test mode configuration (if defined).</param>
    public delegate void InitializationDelegate(bool TestMode = false);

    /// <summary>
    /// Base class for all initialization classes.
    /// </summary>
    public class Initialization {



        static Mutex Mutex = new Mutex();


        /// <summary>
        /// Initialize a package.
        /// </summary>
        /// <param name="initializationDelegate">Initialization delegate to be called exactly once.</param>
        /// <param name="TestMode">If true, initialize package using test mode configuration (if defined).</param>
        public static void Initialize(ref bool flag, InitializationDelegate initializationDelegate, bool TestMode = false) {

            Mutex.WaitOne();
            try {
                if (flag) {
                    return;
                    }
                flag = true;
                initializationDelegate(TestMode);
                }
            finally {
                Mutex.ReleaseMutex();
                }

            }

        }
    }
