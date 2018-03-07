using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Security.Cryptography;
using Goedel.Cryptography.Framework;


namespace Goedel.Cryptography {
    /// <summary>
    /// Initialize the cryptographic framework
    /// </summary>
    public static class CryptographyFramework {

        static bool Initialized = false;
        static Mutex InitializationLock = new Mutex();

        /// <summary>
        /// Perform initialization of the Goedel.Cryptography portable class
        /// with delegates to the .NET framework methods.
        /// </summary>
        /// <param name="TestMode">If true, the application will be initialized in
        /// test/debug mode.</param>
        public static void Initialize(bool TestMode = false) {

            InitializationLock.WaitOne();

            try {
                if (Initialized) {
                    return;
                    }
                Initialized = true;

                KeyPair.TestMode = TestMode;

                // This is actually a duplicate of Goedel.Platform but it is 
                // needed so often as to make this the easiest solution.
                Goedel.Cryptography.Platform.FillRandom = GetRandomBytes;

                // Load the default algorithms for each class first

                Platform.SHA2_512 = CryptoProviderSHA2_512.Register();
                Platform.SHA2_256 = CryptoProviderSHA2_256.Register();
                Platform.SHA3_512 = CryptoProviderSHA3_512.Register();
                Platform.SHA3_256 = CryptoProviderSHA3_256.Register();
                CryptoProviderSHAKE128.Register();
                CryptoProviderSHAKE256.Register();

                Platform.SHA1 = CryptoProviderSHA1.Register();

                Platform.HMAC_SHA2_512 = CryptoProviderHMACSHA2_512.Register();
                Platform.HMAC_SHA2_256 = CryptoProviderHMACSHA2_256.Register();

                Platform.AES_256 = CryptoProviderEncryptAES.Register();

                Platform.BlockProviderFactoryAes = AesBlock.Factory;

                CryptoProviderSignatureRSA.Register();
                CryptoProviderExchangeRSA.Register();

                // Although this is in the portable library, we register it here so
                // as to allow for the possibility we might override it.
                CryptoProviderExchangeDH.Register();

                Platform.FindLocalDelegates.Add(KeyPairRSA.FindLocal);

                //Configure the key pair factories
                KeyPairBaseRSA.KeyPairPublicFactory = KeyPairRSA.KeyPairPublicFactory;
                KeyPairBaseRSA.KeyPairPrivateFactory = KeyPairRSA.KeyPairPrivateFactory;
                KeyPairBaseDH.KeyPairPublicFactory = KeyPairDH.KeyPairPublicFactory;
                KeyPairBaseDH.KeyPairPrivateFactory = KeyPairDH.KeyPairPrivateFactory;



                }
            catch {
                throw new Goedel.Cryptography.InitializationFailed();
                }
            finally {
                InitializationLock.ReleaseMutex();
                }

            }


        /// <summary>
        /// Cryptographic random number generator.
        /// </summary>
        private static RNGCryptoServiceProvider RNGCryptoServiceProvider =
            new RNGCryptoServiceProvider();



        /// <summary>
        /// Fill a byte array with cryptographically strong random data.
        /// </summary>
        /// <param name="Data">The array to fill with cryptographically strong random bytes.</param>
        /// <param name="Offset">The index of the array to start the fill operation.</param>
        /// <param name="Count">The number of bytes to fill</param>
        public static void GetRandomBytes(byte[] Data, int Offset, int Count) {
            RNGCryptoServiceProvider.GetBytes(Data, Offset, Count);
            }


        }
    }
