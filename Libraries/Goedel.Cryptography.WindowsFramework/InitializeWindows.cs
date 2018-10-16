using System;
using System.Threading;
using Goedel.Utilities;
using Goedel.Cryptography.Windows;



namespace Goedel.Cryptography {

    /// <summary>
    /// Base class for initialization.
    /// </summary>
    public static class Cryptography {


        /// <summary>
        /// Perform initialization of the Goedel.Cryptography portable class
        /// with delegates to the .NET framework methods.
        /// </summary>
        /// <param name="TestMode">If true, the application will be initialized in test/debug mode.</param>
        public static void Initialize(bool TestMode = false) => CryptographyWindows.Initialize(TestMode);
        }


    /// <summary>
    /// Windows specific cryptographic routines. These are principally the interfaces to
    /// the registry and the key stores.
    /// </summary>
    public static class CryptographyWindows {

        static bool Initialized = false;
        static Mutex InitializationLock = new Mutex();

        /// <summary>
        /// Perform initialization of the Goedel.Cryptography portable class
        /// with delegates to the .NET framework methods.
        /// </summary>
        /// <param name="TestMode">If true, the application will be initialized in test/debug mode.</param>
        public static void Initialize(bool TestMode = false) {
            InitializationLock.WaitOne();

            CryptographyCommon.Initialize(TestMode);

            // We have to add these methods here because the .NET Standard 2.0 RSA implementation
            // is broken.

            //CryptoProviderSignatureRSA.Register();
            //CryptoProviderExchangeRSA.Register();




            //KeyPair.KeyPairFactoryRSA = Goedel.Cryptography.Windows.KeyPairRSAWindows.KeyPairFactory;
            KeyPairBaseRSA.KeyPairPublicFactory = KeyPairRSA.KeyPairPublicFactory;
            KeyPairBaseRSA.KeyPairPrivateFactory = KeyPairRSA.KeyPairPrivateFactory;
            //Platform.FindLocalDelegates.Add(KeyPairRSA.FindLocal);

            try {
                if (Initialized) {
                    return;
                    }
                Initialized = true;

                Platform.FindInKeyStore = KeyStore.FindInKeyStore;
                Platform.WriteToKeyStore = KeyStore.WriteToKeyStore;
                Platform.EraseFromKeyStore = KeyStore.EraseFromDevice;
                Platform.EraseTest.Add(KeyContainer.EraseTest);
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