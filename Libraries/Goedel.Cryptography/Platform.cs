#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion
using Goedel.Cryptography.Standard;
using System.Runtime.InteropServices;

namespace Goedel.Cryptography;

/// <summary>
/// Static class containing delegates to platform specific 
/// factory methods. 
/// </summary>
public static class Platform {






    ///<summary>Initialization witness flag. This may be used to force initialization
    ///of the module prior to other modules being initialized.</summary> 
    public static bool Initialized { get; private set; }


    /// <summary>
    /// Static initializer
    /// </summary>
    static Platform() {
        // Add the providers defined in the portable library to the catalog.
        Initialized = true;
        FindLocalDelegates.Add(KeyPairDH.FindLocalAdvanced);
        }

    /// <summary>Default SHA-2-512 provider optimized for small data items</summary>
    /// <remarks>This delegate must bound to the platform
    /// specific implementation by a call to  Platform.Initialize() before use</remarks>
    public static CryptoAlgorithm SHA2_512 { get; set; } = CryptoProviderSHA2_512.Register();
    /// <summary>Default SHA-2-256 provider optimized for small data items</summary>
    /// <remarks>This delegate must bound to the platform
    /// specific implementation by a call to  Platform.Initialize() before use</remarks>
    public static CryptoAlgorithm SHA2_256 { get; set; } = CryptoProviderSHA2_256.Register();
    /// <summary>Default SHA-3-512 provider optimized for small data items</summary>
    /// <remarks>This delegate must bound to the platform
    /// specific implementation by a call { get; set; } to  Platform.Initialize() before use</remarks>
    public static CryptoAlgorithm SHA3_512 { get; set; } = CryptoProviderSHA3_512.Register();
    /// <summary>Default SHA-3-256 provider optimized for small data items</summary>
    /// <remarks>This delegate must bound to the platform
    /// specific implementation by a call to  Platform.Initialize() before use</remarks>
    public static CryptoAlgorithm SHA3_256 { get; set; } = CryptoProviderSHA3_256.Register();
    /// <summary>Default SHA-1 provider optimized for small data items</summary>
    /// <remarks>This delegate must bound to the platform
    /// specific implementation by a call to  Platform.Initialize() before use</remarks>
    public static CryptoAlgorithm SHA1 { get; set; } = CryptoProviderSHA1.Register();

    /// <summary>Default HMAC-SHA2-256 provider optimized for small data items</summary>
    /// <remarks>This delegate must bound to the platform
    /// specific implementation by a call to  Platform.Initialize() before use</remarks>
    public static CryptoAlgorithm HMAC_SHA2_256 { get; set; } = CryptoProviderHMACSHA2_256.Register();

    /// <summary>Default HMAC-SHA2-512 provider optimized for small data items</summary>
    /// <remarks>This delegate must bound to the platform
    /// specific implementation by a call to  Platform.Initialize() before use</remarks>
    public static CryptoAlgorithm HMAC_SHA2_512 { get; set; } = CryptoProviderHMACSHA2_512.Register();


    /// <summary>Default AES-256 provider optimized for small data items</summary>
    /// <remarks>This delegate must bound to the platform
    /// specific implementation by a call to  Platform.Initialize() before use</remarks>
    public static CryptoAlgorithm AES_256 { get; set; } = CryptoProviderEncryptAES.Register();


    /// <summary>Provider for AES block transform</summary>
    public static BlockProviderFactoryDelegate BlockProviderFactoryAes { get; set; } = AesBlock.Factory;


    /// <summary>Fill byte buffer with cryptographically strong random numbers.</summary>
    /// <param name="Data">The buffer to fill.</param>
    /// <param name="Offset">First byte to fill.</param>
    /// <param name="Count">Number of bytes to fill.</param>
    public delegate void FillRandomBytesDelegate(byte[] Data, int Offset, int Count);

    /// <summary>Fill byte buffer with cryptographically strong random numbers</summary>
    /// <remarks>This delegate must bound to the platform
    /// specific implementation by a call to  Platform.Initialize() before use</remarks>
    public static FillRandomBytesDelegate FillRandom { get; set; } = CryptographyCommon.GetRandomBytes;


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
    public static WriteToKeyStoreDelegate WriteToKeyStore { get; set; } = WriteToKeyStoreDefault;

    static void WriteToKeyStoreDefault(IPKIXPrivateKey keyPair, KeySecurity keySecurity) =>
                throw new PlatformNotInitialized();


    /// <summary>
    /// Retrieve record from the local key store. 
    /// </summary>
    /// <param name="udf">The key identifier</param>
    /// <param name="keyType">Key type, if known</param>
    /// <returns></returns>
    public delegate KeyPair FindInKeyStoreDelegate(string udf,
            CryptoAlgorithmId keyType = CryptoAlgorithmId.Default);

    /// <summary>
    /// Retrieve record from the local key store. 
    /// </summary>
    /// <remarks>This delegate must bound to the platform
    /// specific implementation by a call to  Platform.Initialize() before use</remarks>
    public static FindInKeyStoreDelegate FindInKeyStore { get; set; } = FindInKeyStoreDefault;

    static KeyPair FindInKeyStoreDefault(string udf,
            CryptoAlgorithmId keyType = CryptoAlgorithmId.Default) =>
                throw new PlatformNotInitialized();


    /// <summary>
    /// Retrieve record from the local key store. 
    /// </summary>
    /// <param name="udf">The key identifier</param>
    /// <param name="KeyType">Key type, if known</param>
    /// <returns>True if key was found, otherwise false</returns>
    public delegate bool EraseFromKeyStoreDelegate(string udf,
            CryptoAlgorithmId KeyType = CryptoAlgorithmId.Default);

    /// <summary>
    /// Retrieve record from the local key store. 
    /// </summary>
    /// <remarks>This delegate must bound to the platform
    /// specific implementation by a call to  Platform.Initialize() before use</remarks>
    public static EraseFromKeyStoreDelegate EraseFromKeyStore { get; set; } = EraseFromKeyStoreDefault;

    static bool EraseFromKeyStoreDefault(string udf,
            CryptoAlgorithmId keyType = CryptoAlgorithmId.Default) =>
                throw new PlatformNotInitialized();



    /// <summary>
    /// Delegate to erase test keys from the machine.
    /// </summary>
    public delegate void EraseTestDelegate();

    /// <summary>
    /// List of registered key erasure delegates
    /// </summary>
    public static List<EraseTestDelegate> EraseTest { get; set; } = new List<EraseTestDelegate>();

    /// <summary>
    /// Get a specified number of random bytes.
    /// </summary>
    /// <param name="min">Number of bytes to get</param>
    /// <param name="max">Maximum number of bytes to get. Ignored if less than 
    /// <paramref name="min"/>.</param>
    /// <returns>Random data</returns>
    public static byte[] GetRandomBytes(int min, int max = 0) {
        var length = max <= min ? min :
            min + (int)GetRandomInteger(max - min);

        var data = new byte[length];
        FillRandom(data, 0, length);
        return data;
        }

    /// <summary>
    /// Return a randomly assigned UDP port.
    /// </summary>
    /// <returns>The randomly assigned port in the range 4096-65535</returns>
    public static int GetRandomPort() {
        var Bytes = GetRandomBytes(3);
        int Result = Bytes[0] + 256 * Bytes[1];

        if (Result < 4096) {
            Result |= 256 * (Bytes[2] | 0x10);
            }

        if (Result > 65535) {
            }

        return Result;
        }


    /// <summary>
    /// Return a random positive integer that is strictly less than <paramref name="max"/>
    /// </summary>
    /// <param name="max">Maximum value to return.</param>
    /// <returns>The random value.</returns>
    public static int GetRandomInteger(int max) => ((int)GetRandomBigInteger(30)) % max;


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

    /// <summary>
    /// Create an (encryptor, decryptor) pair for AES with a 128 bit key derrived from
    /// <paramref name="randomSeed"/> (if not null) and the platform random number
    /// generator otherwise. The seed input is guarded against leaking the random seed 
    /// output by performing a KDF using the value <paramref name="tag"/> for
    /// domain separation.
    /// </summary>
    /// <param name="tag"></param>
    /// <param name="randomSeed"></param>
    /// <returns></returns>
    public static (ICryptoTransform, ICryptoTransform) GetAes128FromSeed(
            string tag, byte[]? randomSeed = null) {
        // Initialize the encryptor and decryptor.
        randomSeed ??= GetRandomBytes(128);
        var aesKey = SHAKE128.GetBytes(16, tag.ToUTF8(), randomSeed);
        var aes = Aes.Create();
        aes.Mode = CipherMode.ECB;
        var decryptor = aes.CreateDecryptor(aesKey, null);
        var encryptor = aes.CreateEncryptor(aesKey, null);
        return (encryptor, decryptor);
        }


    /// <summary>Find a key by fingerprint in the local key stores</summary>
    /// <param name="UDF"></param>
    /// <returns></returns>
    public delegate KeyPair FindLocalDelegate(string UDF);

    /// <summary>
    /// Catalog of all local key stores.
    /// </summary>
    public static List<FindLocalDelegate> FindLocalDelegates { get; set; } =
        new List<FindLocalDelegate>();

    /// <summary>
    /// Shared RFC 3394 Key Wrap provider.
    /// </summary>
    public static KeyWrapRFC3394 KeyWrapRFC3394 { get; set; } = new KeyWrapRFC3394();

    ///<summary>Returns information used to configure the platform.</summary>
    public static GetPlatformInformationDelegate GetPlatformInformation { get; set; }



    /// <summary>
    /// Wipe contents of each <paramref name="inputs"/> unless null.
    /// </summary>
    /// <param name="inputs">List of arrays to wipe</param>
    public static void Wipe(params byte[][] inputs) {
        foreach (var x in inputs) {
            if (x != null) {
                Array.Clear(x);
                }
            }
        }

    /// <summary>
    /// Dispose each of <paramref name="inputs"/> unless null.
    /// </summary>
    /// <param name="inputs">List of arrays to wipe</param>
    public static void Dispose(params IDisposable[] inputs) {
        foreach (var x in inputs) {
            x?.Dispose();
            }
        }


    }
