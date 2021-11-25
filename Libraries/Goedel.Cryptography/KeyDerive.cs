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
using System;

using Goedel.Utilities;

namespace Goedel.Cryptography;

/// <summary>
/// Base class for key derivation functions
/// </summary>
public abstract class KeyDerive {
    /// <summary>Salt used to derive keys to authenticate messages send by the client, i.e. the initiator
    /// to the server.</summary>
    public static readonly byte[] KeyedUDFMaster = "KeyedUDFMaster".ToBytes();
    /// <summary>Salt used to derive keys to authenticate messages send by the client, i.e. the initiator
    /// to the server.</summary>
    public static readonly byte[] KeyedUDFExpand = "KeyedUDFExpand".ToBytes();



    /// <summary>
    /// Key Derivation function
    /// </summary>
    /// <param name="info">The information to be used to vary this key</param>
    /// <param name="length">The length of the key to extract in bits</param>
    /// <returns>The key agreement result.</returns>
    public abstract byte[] Derive(byte[] info, int length = 0);

    }


/// <summary>
/// The HKDF function described in RFC 5869
/// </summary>
public class KeyDeriveHKDF : KeyDerive {

    //CryptoProviderAuthentication Provider;
    CryptoAlgorithmId Algorithm { get; init; }

    /// <summary>The Pseudorandom key constructed from the IKM and salt</summary>
    public byte[] PRK { get; set; }

    /// <summary>The Pseudorandom key constructed from the IKM and salt</summary>
    public int DefaultLength { get; set; } = 256;

    /// <summary>
    /// Construct a KDF instance for the specified keying material
    /// </summary>
    /// <param name="ikm">The input Keying material</param>
    /// <param name="salt">A salt to vary the key derivation by application</param>
    /// <param name="algorithm">The MAC algorithm to use</param>
    public KeyDeriveHKDF(byte[] ikm, string salt,
            CryptoAlgorithmId algorithm = CryptoAlgorithmId.Default) :
                    this(ikm, salt?.ToBytes(), algorithm) {
        }


    /// <summary>
    /// Construct a KDF instance for the specified keying material
    /// </summary>
    /// <param name="ikm">The input Keying material</param>
    /// <param name="salt">A salt to vary the key derivation by application</param>
    /// <param name="algorithm">The MAC algorithm to use</param>
    public KeyDeriveHKDF(byte[] ikm, byte[] salt = null,
            CryptoAlgorithmId algorithm = CryptoAlgorithmId.Default) {
        Algorithm = algorithm;
        PRK = Extract(Algorithm, ikm, salt);
        }

    ///<inheritdoc/>
    public override byte[] Derive(byte[] info, int length = 0) {
        length = length == 0 ? DefaultLength : length;

        return Expand(Algorithm, PRK, length, info);
        }

    /// <summary>
    /// Construct a HKDF instance for algorithm <paramref name="algorithm"/>, generate
    /// a PRK from the values <paramref name="ikm"/> and <paramref name="salt"/>,
    /// then use it to generate an output value od <paramref name="length"/> bits
    /// with additional input <paramref name="info"/>.
    /// </summary>
    /// <param name="ikm">The initial keying material</param>
    /// <param name="salt">The salt value.</param>
    /// <param name="info">The info tag.</param>
    /// <param name="length">Number of bits to generate</param>
    /// <param name="algorithm">HMAC algorithm to use</param>
    /// <returns>The generated bits.</returns>
    public static byte[] Derive(
            byte[] ikm, byte[] salt = null, byte[] info = null, int length = 0,
            CryptoAlgorithmId algorithm = CryptoAlgorithmId.Default) {
        var kdf = new KeyDeriveHKDF(ikm, salt, algorithm);
        return kdf.Derive(info, length);
        }


    /// <summary>
    /// Generate <paramref name="length"/> random bits using <paramref name="ikm"/> as a seed value and
    /// <paramref name="salt"/> as a salt.
    /// <para>This function is intended to be used to provide a pseudo-random number 
    /// generator for testing purposes and to securely generate nonces.</para>
    /// </summary>
    /// <param name="ikm">The initial keying material.</param>
    /// <param name="length">The number of bits to return.</param>
    /// <param name="salt">Optional salt value.</param>
    /// <returns>The pseudo-random output.</returns>
    public static byte[] Random(byte[] ikm, int length = 128, byte[] salt = null) {
        var prk = Extract(CryptoAlgorithmId.Default, ikm, salt);
        return Expand(CryptoAlgorithmId.Default, prk, length);

        }


    /// <summary>
    /// The extraction function
    /// </summary>
    /// <param name="algorithm">The MAC algorithm to use</param>
    /// <param name="ikm">The initial keying material</param>
    /// <param name="salt">Salt to be used to vary the derived key across domains.</param>
    /// <returns>The extracted value.</returns>
    public static byte[] Extract(CryptoAlgorithmId algorithm,
                byte[] ikm, byte[] salt = null) {
        var (size, _) = algorithm.GetKeySize();

        var Key = salt ?? new byte[size / 8];
        return ikm.GetMAC(Key, cryptoAlgorithmID: algorithm);
        }

    /// <summary>
    /// The expansion function
    /// </summary>
    /// <param name="algorithm">The MAC algorithm to use</param>
    /// <param name="prk">The pseudo-random key.</param>
    /// <param name="length">Length of output key in bits</param>
    /// <param name="info">Information data</param>
    /// <returns>The expanded value.</returns>
    public static byte[] Expand(CryptoAlgorithmId algorithm,
        byte[] prk, int length, byte[] info = null) {

        var (size, _) = algorithm.GetKeySize();
        info ??= Array.Empty<byte>();

        var result = new byte[length / 8];

        Assert.AssertTrue(length < (255 * (size / 8)), ImplementationLimit.Throw);

        byte index = 1;

        // Calculate T1 and add to Result
        var data = new byte[info.Length + 1];
        data.AppendChecked(0, info);
        data[^1] = index++;
        var t = data.GetMAC(prk, cryptoAlgorithmID: algorithm);

        var offset = result.AppendChecked(0, t);

        data = new byte[t.Length + info.Length + 1];
        data.AppendChecked(t.Length, info);

        while (offset < result.Length) {
            data.AppendChecked(0, t);
            data[^1] = index++;
            t = data.GetMAC(prk, cryptoAlgorithmID: algorithm);
            offset = result.AppendChecked(offset, t);
            }

        return result;
        }




    }
