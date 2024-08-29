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
using Goedel.IO;

namespace Goedel.Cryptography;

/// <summary>
/// Extension methods to return .NET Standard cryptographic providers from
/// CryptoAlgorithmID identifiers.
/// </summary>
public static class CryptoStreamFromID {

    private static readonly Aes Aes = Aes.Create();

    /// <summary>
    /// Return the key size and block size for the algorithm specified by <paramref name="cryptoAlgorithmID"/>.
    /// </summary>
    /// <param name="cryptoAlgorithmID">The algorithm to report the sizes of.</param>
    /// <returns>Tuple consisting (int KeySize, int BlockSize).</returns>
    public static (int KeySize, int BlockSize) GetKeySize(
                this CryptoAlgorithmId cryptoAlgorithmID
                ) {

        return cryptoAlgorithmID switch {
            CryptoAlgorithmId.AES128 or CryptoAlgorithmId.AES128GCM or CryptoAlgorithmId.AES128CTS or
            CryptoAlgorithmId.AES128HMAC or CryptoAlgorithmId.AES128CBCNone or CryptoAlgorithmId.AES128ECB => (128, 128),
            CryptoAlgorithmId.Default or CryptoAlgorithmId.AES256 or CryptoAlgorithmId.AES256CBC or
            CryptoAlgorithmId.AES256GCM or CryptoAlgorithmId.AES256CTS or CryptoAlgorithmId.AES256HMAC or
            CryptoAlgorithmId.AES256CBCNone or CryptoAlgorithmId.AES256ECB => (256, 128),
            CryptoAlgorithmId.HMAC_SHA_2_256 => (128, 0),
            CryptoAlgorithmId.HMAC_SHA_2_512 or CryptoAlgorithmId.HMAC_SHA_2_512T128 => (256, 0),
            _ => (-1, -1),
            };
        }

    /// <summary>
    /// Return an encryption transform the algorithm specified by <paramref name="cryptoAlgorithmID"/>.
    /// </summary>
    /// <param name="cryptoAlgorithmID">The algorithm.</param>
    /// <param name="key">The key to use.</param>
    /// <param name="iv">The initialization vector (if required).</param>
    /// <returns>The encryption transform.</returns>
    public static ICryptoTransform CreateEncryptor(
                    this CryptoAlgorithmId cryptoAlgorithmID,
                    byte[] key,
                    byte[] iv = null) {

        switch (cryptoAlgorithmID) {
            case CryptoAlgorithmId.Default:
            case CryptoAlgorithmId.AES128:
            case CryptoAlgorithmId.AES128GCM:
            case CryptoAlgorithmId.AES128CTS:
            case CryptoAlgorithmId.AES128CBCNone:
            case CryptoAlgorithmId.AES128ECB:
            case CryptoAlgorithmId.AES256:
            case CryptoAlgorithmId.AES256CBC:
            case CryptoAlgorithmId.AES256GCM:
            case CryptoAlgorithmId.AES256CTS:
            case CryptoAlgorithmId.AES256CBCNone:
            case CryptoAlgorithmId.AES256ECB:

            case CryptoAlgorithmId.AES128HMAC:
            case CryptoAlgorithmId.AES256HMAC: {
                return Aes.CreateEncryptor(key, iv);
                }
            default:
            return null;
            }
        }

    /// <summary>
    /// Return a decryption transform the algorithm specified by <paramref name="cryptoAlgorithmID"/>.
    /// </summary>
    /// <param name="cryptoAlgorithmID">The algorithm.</param>
    /// <param name="key">The key to use.</param>
    /// <param name="iV">The initialization vector (if required).</param>
    /// <returns>The decryption transform.</returns>
    public static ICryptoTransform CreateDecryptor(
                    this CryptoAlgorithmId cryptoAlgorithmID,
                    byte[] key,
                    byte[] iV) {

        switch (cryptoAlgorithmID) {
            case CryptoAlgorithmId.Default:
            case CryptoAlgorithmId.AES128:
            case CryptoAlgorithmId.AES128GCM:
            case CryptoAlgorithmId.AES128CTS:
            case CryptoAlgorithmId.AES128CBCNone:
            case CryptoAlgorithmId.AES128ECB:

            case CryptoAlgorithmId.AES256CBC:
            case CryptoAlgorithmId.AES256GCM:
            case CryptoAlgorithmId.AES256CTS:
            case CryptoAlgorithmId.AES256CBCNone:
            case CryptoAlgorithmId.AES256ECB:

            case CryptoAlgorithmId.AES128HMAC:
            case CryptoAlgorithmId.AES256HMAC: {
                return Aes.CreateDecryptor(key, iV);
                }


            }
        return null;
        }

    /// <summary>
    /// Return a Message Authentication Code provider for the algorithm 
    /// specified by <paramref name="cryptoAlgorithmID"/>.
    /// </summary>
    /// <param name="cryptoAlgorithmID">The algorithm.</param>
    /// <returns>The Message Authentication Code provider.</returns>
    public static HashAlgorithm CreateMac(
                    this CryptoAlgorithmId cryptoAlgorithmID) {

        return cryptoAlgorithmID switch {
            CryptoAlgorithmId.HMAC_SHA_2_256 => new HMACSHA256(),
            CryptoAlgorithmId.Default or CryptoAlgorithmId.HMAC_SHA_2_512 => new HMACSHA512(),
            CryptoAlgorithmId.HMAC_SHA_2_512T128 => new HMACSHA512(),
            CryptoAlgorithmId.AES128HMAC => new HMACSHA256(),
            CryptoAlgorithmId.AES256HMAC => new HMACSHA512(),
            _ => null,
            };
        }

    /// <summary>
    /// Return a Message Authentication Code provider for the algorithm 
    /// specified by <paramref name="cryptoAlgorithmID"/>.
    /// </summary>
    /// <param name="cryptoAlgorithmID">The algorithm.</param>
    /// <param name="key">The key to use.</param>
    /// <returns>The Message Authentication Code provider.</returns>
    public static HashAlgorithm CreateMac(
                    this CryptoAlgorithmId cryptoAlgorithmID,
                    byte[] key) {

        return cryptoAlgorithmID switch {
            CryptoAlgorithmId.HMAC_SHA_2_256 => new HMACSHA256(key),
            CryptoAlgorithmId.Default or CryptoAlgorithmId.HMAC_SHA_2_512 => new HMACSHA512(key),
            CryptoAlgorithmId.HMAC_SHA_2_512T128 => new HMACSHA512(key),
            CryptoAlgorithmId.AES128HMAC => new HMACSHA256(key),
            CryptoAlgorithmId.AES256HMAC => new HMACSHA512(key),
            _ => null,
            };
        }

    /// <summary>
    /// Return a digest provider for the algorithm 
    /// specified by <paramref name="cryptoAlgorithmID"/>.
    /// </summary>
    /// <param name="cryptoAlgorithmID">The algorithm.</param>
    /// <returns>The digest provider.</returns>
    public static HashAlgorithm CreateDigest(
                    this CryptoAlgorithmId cryptoAlgorithmID
                    ) {

        return cryptoAlgorithmID switch {
            CryptoAlgorithmId.SHA_2_256 => SHA256.Create(),
            CryptoAlgorithmId.Default or CryptoAlgorithmId.SHA_2_512 => SHA512.Create(),
            CryptoAlgorithmId.SHA_2_512T128 => SHA512.Create(),
            CryptoAlgorithmId.SHA_3_256 => new SHA3Managed(256),
            CryptoAlgorithmId.SHA_3_512 => new SHA3Managed(512),
            CryptoAlgorithmId.SHAKE_128 => new SHAKE128(),
            CryptoAlgorithmId.SHAKE_256 => new SHAKE256(),
            _ => null,
            };
        }

    /// <summary>
    /// Return a shake provider for the algorithm 
    /// specified by <paramref name="cryptoAlgorithmID"/>.
    /// </summary>
    /// <param name="cryptoAlgorithmID">The algorithm.</param>
    /// <param name="hashBitLength">The number of output bits to generate.</param>
    /// <returns>The digest provider.</returns>
    public static HashAlgorithm CreateShake(
                    CryptoAlgorithmId cryptoAlgorithmID,
                    int hashBitLength
                    ) => cryptoAlgorithmID switch {
                        CryptoAlgorithmId.SHAKE_128 => new SHAKE128(hashBitLength),
                        CryptoAlgorithmId.SHAKE_256 => new SHAKE256(hashBitLength),
                        _ => null,
                        };

    /// <summary>
    /// Calculate the digest value of the contents of <paramref name="fileName"/> using the algorithm
    /// specified by <paramref name="cryptoAlgorithmID"/>.
    /// </summary>
    /// <param name="fileName">The file containing the data to digest.</param>
    /// <param name="cryptoAlgorithmID">The digest algorithm.</param>
    /// <returns>The digest value.</returns>
    public static byte[] GetDigestOfFile(this string fileName,
            CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.SHA_2_512) {
        var hashProvider = cryptoAlgorithmID.CreateDigest();
        using (var inputStream = fileName.OpenFileRead()) {
            using var cryptoStream = new CryptoStream(Stream.Null, hashProvider, CryptoStreamMode.Write);
            inputStream.CopyTo(cryptoStream);
            }
        return hashProvider.Hash;

        }

    /// <summary>
    /// Calculate the digest value of <paramref name="utf8"/> using the algorithm
    /// specified by <paramref name="cryptoAlgorithmID"/>.
    /// </summary>
    /// <param name="utf8">String to be converted to UTF8 to provide the digest input.</param>
    /// <param name="cryptoAlgorithmID">The digest algorithm.</param>
    /// <returns>The digest value.</returns>
    public static byte[] GetDigest(this string utf8,
            CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.SHA_2_512) =>
        GetDigest(utf8.ToUTF8(), cryptoAlgorithmID: cryptoAlgorithmID);

    /// <summary>
    /// Calculate the digest of the portion of <paramref name="data"/> specified by
    /// <paramref name="offset"/> and <paramref name="count"/> with the digest algorithm specified
    /// by <paramref name="cryptoAlgorithmID"/>.
    /// </summary>
    /// <param name="data">The input to compute the hash code for.</param>
    /// <param name="cryptoAlgorithmID"></param>
    /// <param name="offset">The offset into the byte array from which to begin using data.</param>
    /// <param name="count">The number of bytes in the array to use as data. If less than 0,
    /// defaults to the remaining bytes <paramref name="data"/> after <paramref name="offset"/>.</param>
    /// <returns>The computed hash code.</returns>
    public static byte[] GetDigest(this byte[] data,
                CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.SHA_2_512, int offset = 0,
        int count = -1) {
        count = count < 0 ? data.Length - offset : count;
        using var hashAlgorithm = cryptoAlgorithmID.CreateDigest();
        return hashAlgorithm.ComputeHash(data, offset, count);
        }

    /// <summary>
    /// Calculate the digest of the portion of <paramref name="data"/> specified by
    /// <paramref name="offset"/> and <paramref name="count"/> with the digest algorithm specified
    /// by <paramref name="cryptoAlgorithmID"/>.
    /// </summary>
    /// <param name="data">The input to compute the hash code for.</param>
    /// <param name="offset">The offset into the byte array from which to begin using data.</param>
    /// <param name="count">The number of bytes in the array to use as data. If less than 0,
    /// defaults to the remaining bytes <paramref name="data"/> after <paramref name="offset"/>.</param>
    /// <param name="cryptoAlgorithmID"></param>
    /// <param name="key">The secret key for the MAC operation.</param>
    /// <returns>The computed hash code.</returns>
    public static byte[] GetMAC(this byte[] data, byte[] key,
        CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.HMAC_SHA_2_512, int offset = 0,
        int count = -1) {
        count = count < 0 ? data.Length - offset : count;
        cryptoAlgorithmID = cryptoAlgorithmID.Default(CryptoAlgorithmId.HMAC_SHA_2_512);

        using var hashAlgorithm = cryptoAlgorithmID.CreateMac(key);
        return hashAlgorithm.ComputeHash(data, offset, count);
        }
    }
