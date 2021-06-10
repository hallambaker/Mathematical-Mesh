//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Cryptography;

//namespace Goedel.Discovery {

//    /// <summary>
//    /// Network initialization. Bind the .Net implementation methods
//    /// to the static delegates in the portable libraries.
//    /// </summary>
//    public static partial class PlatformFramework {
//        /// <summary>
//        /// Initialize the network and cryptography stacks for use with a
//        /// .NET Framework or Mono app.
//        /// (if this can be found)
//        /// </summary>
//        /// <param name="TestMode">If true, the application will be initialized in test/debug mode.</param>
//        public static void Initialize (bool TestMode = false) {
//            //Goedel.Discovery.Platform.DNSClient = new DNSClientUDP();
//            ////Goedel.Platform.Platform.QueryAsyncDelegate = DNSClientUDP.QueryAsync;
//            //Goedel.Discovery.Platform.GetRandomBytesD = GetRandomBytes;
//            }

//        ///// <summary>
//        ///// Cryptographic random number generator.
//        ///// </summary>
//        //private static RNGCryptoServiceProvider RNGCryptoServiceProvider = 
//        //    new RNGCryptoServiceProvider();



//        ///// <summary>
//        ///// Fill a byte array with cryptographically strong random data.
//        ///// </summary>
//        ///// <param name="Data">The array to fill with cryptographically strong random bytes.</param>
//        ///// <param name="Offset">The index of the array to start the fill operation.</param>
//        ///// <param name="Count">The number of bytes to fill</param>
//        //public static void GetRandomBytes(byte[] Data, int Offset, int Count) {
//        //    RNGCryptoServiceProvider.GetBytes(Data, Offset, Count);
//        //    }

//        }
//    }
