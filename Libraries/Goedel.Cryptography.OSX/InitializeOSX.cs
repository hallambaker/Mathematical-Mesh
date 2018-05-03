using System;
using System.Threading;

using Goedel.Utilities;

namespace Goedel.Cryptography{

    /// <summary>
    /// Base class for initialization.
    /// </summary>
    public static class Cryptography {


        /// <summary>
        /// Perform initialization of the Goedel.Cryptography portable class
        /// with delegates to the .NET framework methods.
        /// </summary>
        /// <param name="TestMode">If true, the application will be initialized in test/debug mode.</param>
        public static void Initialize (bool TestMode = false) {
            CryptographyOSX.Initialize(TestMode);

            }
        }



    /// <summary>
    /// Initialize for the Linux style key store
    /// </summary>
    public static class CryptographyOSX {

        //static bool Initialized = false;
        static Mutex InitializationLock = new Mutex();

        /// <summary>
        /// Perform initialization of the Goedel.Cryptography portable class
        /// with delegates to the .NET framework methods.
        /// </summary>
        /// <param name="TestMode">If true initialize the system in test mode so that
        /// settings may be tested and cleared without disrupting user work.</param>
        public static void Initialize(bool TestMode=false) {
            InitializationLock.WaitOne();

            throw new NYI();

            //CryptographyFramework.Initialize();
            //try {
            //    if (Initialized) {
            //        return;
            //        }
            //    Initialized = true;

            //    Platform.FindInKeyStore = KeyStore.FindInKeyStore;
            //    Platform.WriteToKeyStore = KeyStore.WriteToKeyStore;
            //    Platform.EraseFromKeyStore = KeyStore.EraseFromDevice;
            //    }
            //catch {
            //    throw new InitializationFailed();
            //    }
            //finally {
            //    InitializationLock.ReleaseMutex();
            //    }

            }
        }

    }