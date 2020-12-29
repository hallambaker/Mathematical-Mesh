using Goedel.Cryptography.Standard;

using System.Security.Cryptography;
using System.Threading;


namespace Goedel.Cryptography {
    /// <summary>
    /// Initialize the cryptographic framework
    /// </summary>
    public static class CryptographyCommon {

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
        public static void GetRandomBytes(byte[] Data, int Offset, int Count) => 
                    RNGCryptoServiceProvider.GetBytes(Data, Offset, Count);


        }
    }
