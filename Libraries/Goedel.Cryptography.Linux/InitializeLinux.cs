using System;
using System.Threading;
using Goedel.Utilities;
using Goedel.Cryptography.Framework;



namespace Goedel.Cryptography.Linux{

    /// <summary>
    /// Initialize for the Linux style key store
    /// </summary>
    public static class CryptographyLinux {

        static bool Initialized = false;
        static Mutex InitializationLock = new Mutex();

        /// <summary>
        /// Perform initialization of the Goedel.Cryptography portable class
        /// with delegates to the .NET framework methods.
        /// </summary>
        /// <param name="TestMode">If true initialize the system in test mode so that
        /// settings may be tested and cleared without disrupting user work.</param>
        public static void Initialize(bool TestMode=false) {
            InitializationLock.WaitOne();

            CryptographyFramework.Initialize();
            try {
                if (Initialized) {
                    return;
                    }
                Initialized = true;

                Platform.FindInKeyStore = KeyStore.FindInKeyStore;
                Platform.WriteToKeyStore = KeyStore.WriteToKeyStore;
                Platform.EraseFromKeyStore = KeyStore.EraseFromDevice;
                }
            catch {
                throw new InitializationFailed();
                }
            finally {
                InitializationLock.ReleaseMutex();
                }

            }
        }

    }