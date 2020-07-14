using Goedel.Cryptography.PKIX;
using Goedel.Utilities;

using System.Collections.Generic;
using System.Numerics;

namespace Goedel.Cryptography {
    /// <summary>
    /// Static class containing delegates to platform specific 
    /// factory methods. 
    /// </summary>
    public static class Platform {

        /// <summary>
        /// Static initializer
        /// </summary>
        static Platform() =>
            // Add the providers defined in the portable library to the catalog.
            FindLocalDelegates.Add(KeyPairDH.FindLocalAdvanced);

        /// <summary>Default SHA-2-512 provider optimized for small data items</summary>
        /// <remarks>This delegate must bound to the platform
        /// specific implementation by a call to  Platform.Initialize() before use</remarks>
        public static CryptoAlgorithm SHA2_512;
        /// <summary>Default SHA-2-256 provider optimized for small data items</summary>
        /// <remarks>This delegate must bound to the platform
        /// specific implementation by a call to  Platform.Initialize() before use</remarks>
        public static CryptoAlgorithm SHA2_256;
        /// <summary>Default SHA-3-512 provider optimized for small data items</summary>
        /// <remarks>This delegate must bound to the platform
        /// specific implementation by a call to  Platform.Initialize() before use</remarks>
        public static CryptoAlgorithm SHA3_512;
        /// <summary>Default SHA-3-256 provider optimized for small data items</summary>
        /// <remarks>This delegate must bound to the platform
        /// specific implementation by a call to  Platform.Initialize() before use</remarks>
        public static CryptoAlgorithm SHA3_256;
        /// <summary>Default SHA-1 provider optimized for small data items</summary>
        /// <remarks>This delegate must bound to the platform
        /// specific implementation by a call to  Platform.Initialize() before use</remarks>
        public static CryptoAlgorithm SHA1;

        /// <summary>Default HMAC-SHA2-512 provider optimized for small data items</summary>
        /// <remarks>This delegate must bound to the platform
        /// specific implementation by a call to  Platform.Initialize() before use</remarks>
        public static CryptoAlgorithm HMAC_SHA2_256;
        /// <summary>Default HMAC-SHA2-512 provider optimized for small data items</summary>
        /// <remarks>This delegate must bound to the platform
        /// specific implementation by a call to  Platform.Initialize() before use</remarks>
        public static CryptoAlgorithm HMAC_SHA2_384;
        /// <summary>Default HMAC-SHA2-512 provider optimized for small data items</summary>
        /// <remarks>This delegate must bound to the platform
        /// specific implementation by a call to  Platform.Initialize() before use</remarks>
        public static CryptoAlgorithm HMAC_SHA2_512;


        /// <summary>Default AES-256 provider optimized for small data items</summary>
        /// <remarks>This delegate must bound to the platform
        /// specific implementation by a call to  Platform.Initialize() before use</remarks>
        public static CryptoAlgorithm AES_256;


        /// <summary>Provider for AES block transform</summary>
        public static BlockProviderFactoryDelegate BlockProviderFactoryAes = null;


        /// <summary>Fill byte buffer with cryptographically strong random numbers.</summary>
        /// <param name="Data">The buffer to fill.</param>
        /// <param name="Offset">First byte to fill.</param>
        /// <param name="Count">Number of bytes to fill.</param>
        public delegate void FillRandomBytesDelegate(byte[] Data, int Offset, int Count);

        /// <summary>Fill byte buffer with cryptographically strong random numbers</summary>
        /// <remarks>This delegate must bound to the platform
        /// specific implementation by a call to  Platform.Initialize() before use</remarks>
        public static FillRandomBytesDelegate FillRandom = FillRandomBytesDefault;


        static void FillRandomBytesDefault(byte[] Data, int Offset, int Count) =>
                    throw new PlatformNotInitialized();

        /// <summary>
        /// Write a key to the machine keystore
        /// </summary>
        /// <param name="KeyPair">The key store</param>
        /// <param name="KeySecurity">The storage security level</param>
        public delegate void WriteToKeyStoreDelegate(IPKIXPrivateKey KeyPair, KeySecurity KeySecurity);

        /// <summary>
        /// Write a key to the machine keystore
        /// </summary>
        /// <remarks>This delegate must bound to the platform
        /// specific implementation by a call to  Platform.Initialize() before use</remarks>
        public static WriteToKeyStoreDelegate WriteToKeyStore = WriteToKeyStoreDefault;

        static void WriteToKeyStoreDefault(IPKIXPrivateKey KeyPair, KeySecurity KeySecurity) =>
                    throw new PlatformNotInitialized();


        /// <summary>
        /// Retrieve record from the local key store. 
        /// </summary>
        /// <param name="UDF">The key identifier</param>
        /// <param name="KeyType">Key type, if known</param>
        /// <returns></returns>
        public delegate KeyPair FindInKeyStoreDelegate(string UDF,
                CryptoAlgorithmId KeyType = CryptoAlgorithmId.Default);

        /// <summary>
        /// Retrieve record from the local key store. 
        /// </summary>
        /// <remarks>This delegate must bound to the platform
        /// specific implementation by a call to  Platform.Initialize() before use</remarks>
        public static FindInKeyStoreDelegate FindInKeyStore = FindInKeyStoreDefault;

        static KeyPair FindInKeyStoreDefault(string UDF,
                CryptoAlgorithmId KeyType = CryptoAlgorithmId.Default) =>
                    throw new PlatformNotInitialized();


        /// <summary>
        /// Retrieve record from the local key store. 
        /// </summary>
        /// <param name="UDF">The key identifier</param>
        /// <param name="KeyType">Key type, if known</param>
        /// <returns>True if key was found, otherwise false</returns>
        public delegate bool EraseFromKeyStoreDelegate(string UDF,
                CryptoAlgorithmId KeyType = CryptoAlgorithmId.Default);

        /// <summary>
        /// Retrieve record from the local key store. 
        /// </summary>
        /// <remarks>This delegate must bound to the platform
        /// specific implementation by a call to  Platform.Initialize() before use</remarks>
        public static EraseFromKeyStoreDelegate EraseFromKeyStore = EraseFromKeyStoreDefault;

        static bool EraseFromKeyStoreDefault(string UDF,
                CryptoAlgorithmId KeyType = CryptoAlgorithmId.Default) =>
                    throw new PlatformNotInitialized();



        /// <summary>
        /// Delegate to erase test keys from the machine.
        /// </summary>
        public delegate void EraseTestDelegate();

        /// <summary>
        /// List of registered key erasure delegates
        /// </summary>
        public static List<EraseTestDelegate> EraseTest = new List<EraseTestDelegate>();

        /// <summary>
        /// Get a specified number of random bytes.
        /// </summary>
        /// <param name="Length">Number of bytes to get</param>
        /// <returns>Random data</returns>
        public static byte[] GetRandomBytes(int Length) {
            var Data = new byte[Length];
            FillRandom(Data, 0, Length);
            return Data;
            }


        /// <summary>
        /// Get a specified number of random bits.
        /// </summary>
        /// <param name="Length">Number of bits to get</param>
        /// <returns>Random data</returns>
        public static byte[] GetRandomBits(int Length) => GetRandomBytes(Length / 8);

        /// <summary>
        /// Get a Big integer with a specified number of random bits.
        /// </summary>
        /// <param name="Bits">Number of bits to get</param>
        /// <returns>Random data</returns>
        public static BigInteger GetRandomBigInteger(int Bits) {
            var RandomBytes = GetRandomBytes(1 + Bits / 8);
            RandomBytes[^1] = 0; // make sure it is positive
            return new BigInteger(RandomBytes);
            }


        /// <summary>
        /// Get a Big Integer that is smaller than the input value
        /// </summary>
        /// <param name="Ceiling">Number of bits to get</param>
        /// <returns>Random data</returns>
        public static BigInteger GetRandomBigInteger(BigInteger Ceiling) {
            Assert.AssertTrue(Ceiling > 0, CryptographicException.Throw);

            // Generate extra bits to avoid a biased sample.
            var Bits = 16 + 8 * (Ceiling.ToByteArray().Length);
            var Test = GetRandomBigInteger(Bits);

            return Test % Ceiling;
            }


        /// <summary>Find a key by fingerprint in the local key stores</summary>
        /// <param name="UDF"></param>
        /// <returns></returns>
        public delegate KeyPair FindLocalDelegate(string UDF);

        /// <summary>
        /// Catalog of all local key stores.
        /// </summary>
        public static List<FindLocalDelegate> FindLocalDelegates =
            new List<FindLocalDelegate>();

        /// <summary>
        /// Shared RFC 3394 Key Wrap provider.
        /// </summary>
        public static KeyWrapRFC3394 KeyWrapRFC3394 = new KeyWrapRFC3394();

        ///<summary>Returns information used to configure the platform.</summary>
        public static GetPlatformInformationDelegate GetPlatformInformation;



        }



    }
