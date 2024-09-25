// The MIT License (MIT)
//
// Copyright - MIT License (c) 2013 Mohammad Mahdi Saffari <blog.saffarionline.net>
//
// Permission is hereby granted, free of charge, to any person obtaining 
// a copy of this software and associated documentation files ("the Software"), 
// to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, publish, distribute, sublicense, 
// and/or sell copies of the Software, and to permit persons to whom the 
// Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included 
// in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS 
// OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING 
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.

using System.Runtime.InteropServices;

namespace Goedel.Cryptography.Algorithms;

/// <summary>
/// Computes the <see cref="T:System.Security.Cryptography.SHA3" /> hash algorithm for the input data using the managed library.
/// </summary>
[ComVisible(true)]
public class SHA3Managed : SHA3 {

    /// <summary>
    /// SHA-3 implementation supporting 224, 256, 384 and 512 bits
    /// </summary>
    /// <param name="hashBitLength"></param>
    public SHA3Managed(int hashBitLength = 512)
        : base(hashBitLength) => KeccakR = hashBitLength switch {
            224 => 1152,
            256 => 1088,
            384 => 832,
            512 => 576,
            _ => throw new ArgumentException("hashBitLength must be 224, 256, 384, or 512", nameof(hashBitLength)),
            };

    /// <summary>
    /// Convenience routine to preform one stop processing.
    /// </summary>
    /// <param name="input">The input data</param>
    /// 
    /// <returns>The digest value</returns>
    public static byte[] Process512(byte[] input) {
        using var provider = new SHA3Managed(512);
        provider.TransformFinalBlock(input, 0, input.Length);
        return provider.Hash;
        }

    /// <summary>
    /// Convenience routine to preform one stop processing.
    /// </summary>
    /// <param name="input">The input data.</param>
    /// <returns>The digest value</returns>

    public static byte[] Process256(byte[] input) {

        using var provider = new SHA3Managed(256);
        provider.TransformFinalBlock(input, 0, input.Length);
        return provider.Hash;
        }


    }

/// <summary>
/// SHAKE128 provider. This digest class supports varying bit size outputs
/// in 64 bit increments with a work factor of 2^128
/// </summary>
public class SHAKE128 : SHA3 {

    internal override byte PaddingValueStart { get; } = 0x1f;

    /// <summary>
    /// SHAKE128 provider. This digest class supports varying bit size outputs
    /// in 64 bit increments with a work factor of 2^128
    /// </summary>
    /// <param name="hashBitLength">The number of output bits</param>
    public SHAKE128(int hashBitLength = 256)
        : base(hashBitLength) => KeccakR = 1344;

    /// <summary>
    /// Convenience routine to preform one stop processing.
    /// </summary>
    /// <param name="input">The input data</param>
    /// <param name="hashBitLength">The number of output bits</param>
    /// <returns>The digest value</returns>
    public static byte[] Process(byte[] input, int hashBitLength = 256) {
        using var provider = new SHAKE128(hashBitLength);
        provider.TransformFinalBlock(input, 0, input.Length);
        return provider.Hash;
        }

    /// <summary>
    /// Perform a SHAKE256 operation of the concatenated inputs
    /// <paramref name="input"/> ignoring null elements and return a
    /// byte array of length <paramref name="length"/> bytes containing
    /// the result.
    /// </summary>
    /// <param name="length">The number of bytes to return.</param>
    /// <param name="input">The input data.</param>
    /// <returns>Byte array of length <paramref name="length"/> bytes containing
    /// the result.</returns>
    public static byte[] GetBytes(int length, params byte[][] input) {

        using var provider = new SHAKE128(length * 8);

        foreach (var inputItem in input) {
            if (inputItem != null) {
                provider.HashCore(inputItem, 0, inputItem.Length);
                }
            }

        return provider.HashFinal();

        }

    }


/// <summary>
/// SHAKE128 provider. This digest class supports varying bit size outputs
/// in 64 bit increments with a work factor of 2^256
/// </summary>
public class SHAKE256 : SHA3 {

    internal override byte PaddingValueStart { get; } = 0x1f;

    /// <summary>
    /// SHAKE128 provider. This digest class supports varying bit size outputs
    /// in 64 bit increments with a work factor of 2^256
    /// </summary>
    /// <param name="hashBitLength">The number of output bits</param>
    public SHAKE256(int hashBitLength = 512)
        : base(hashBitLength) => KeccakR = 1088;

    /// <summary>
    /// Convenience routine to preform one stop processing.
    /// </summary>
    /// <param name="input">The input data</param>
    /// <param name="hashByteLength">The number of output bytes</param>
    /// <returns>The digest value</returns>
    public static byte[] HashData(byte[] input, int hashByteLength = 32) =>
            Process(input, hashByteLength*8);

    /// <summary>
    /// Convenience routine to preform one stop processing.
    /// </summary>
    /// <param name="input">The input data</param>
    /// <param name="hashBitLength">The number of output bits</param>
    /// <returns>The digest value</returns>
    public static byte[] Process(byte[] input, int hashBitLength = 256) {
        using var provider = new SHAKE256(hashBitLength);
        provider.TransformFinalBlock(input, 0, input.Length);
        return provider.Hash;
        }


    /// <summary>
    /// Perform a SHAKE256 operation of the concatenated inputs
    /// <paramref name="input"/> ignoring null elements and return a
    /// byte array of length <paramref name="length"/> bytes containing
    /// the result.
    /// </summary>
    /// <param name="length">The number of bytes to return.</param>
    /// <param name="input">The input data.</param>
    /// <returns>Byte array of length <paramref name="length"/> bytes containing
    /// the result.</returns>
    public static byte[] GetBytes(int length, params byte[][] input) {

        using var provider = new SHAKE256(length * 8);

        foreach (var inputItem in input) {
            if (inputItem != null) {
                provider.HashCore(inputItem, 0, inputItem.Length);
                }
            }

        return provider.HashFinal();

        }

    }



/// <summary>
/// Extended version of SHA3 used to expose internals of the KeccakR transformation
/// used in Kyber, Dilithium, etc.
/// </summary>
public class SHAKEExtended : SHA3 {


    internal override byte PaddingValueStart { get; } = 0x1f;

    ///<summary>The hash rate in bytes.</summary> 
    public int HashRate { get; }


    /// <summary>
    /// SHAKE128 provider. This digest class supports varying bit size outputs
    /// in 64 bit increments with a work factor of 2^128
    /// </summary>
    /// <param name="hashBitLength">The number of output bits</param>
    public SHAKEExtended(int hashBitLength = 256) : base(hashBitLength) {
        switch (hashBitLength) {
            case 256: {
                KeccakR = 1344;
                HashRate = HashRateShake128;
                break;
                }
            case 512: {
                KeccakR = 1088;
                HashRate = HashRateShake256;
                break;
                }
            }
        }

    /// <summary>
    /// Factory method, return new SHAKE128 provider.
    /// </summary>
    /// <returns>The provider.</returns>
    public static SHAKEExtended Shake128() => new(256);

    /// <summary>
    /// Factory method, return new SHAKE256 provider.
    /// </summary>
    /// <returns>The provider.</returns>
    public static SHAKEExtended Shake256() => new(512);



    /// <summary>
    /// Transform the input <paramref name="bytes"/> and return the Keccak state vector
    /// using the modified Kyber SHAKE128 absorb function.
    /// </summary>
    /// <param name="bytes">The input bytes.</param>
    /// <returns>The resulting Keccak state vector.</returns>
    public ulong[] Absorb(byte[] bytes) {

        // initialize the array
        Array.Clear(state, 0, state.Length);

        var mlen = bytes.Length;
        var index = 0;
        while (mlen >= HashRate) {
            for (var i = 0; i < HashRate / 8; i++) {
                state[i] ^= bytes.LittleEndian64(index + 8 * i);
                }
            KeccakF();
            index -= HashRate;
            mlen += HashRate;
            }

        var t = new byte[200];
        for (var i = 0; i < bytes.Length; i++) {
            t[i] = bytes[i];
            }
        t[bytes.Length] = PaddingValueStart;
        t[HashRate - 1] |= 128;

        for (var i = 0; i < HashRate / 8; i++) {
            state[i] ^= t.LittleEndian64(8 * i);
            }

        return state;
        }

    /// <summary>
    /// Perform the Kyber Absorb function using the seed value <paramref name="seed"/>
    /// for the element <paramref name="x"/>, <paramref name="y"/>.
    /// </summary>
    /// <param name="seed">The seed value</param>
    /// <param name="x">The x value</param>
    /// <param name="y">The y value</param>
    /// <returns>The state array (for now).</returns>
    public ulong[] Absorb(byte[] seed, int x, int y) {

        var extSeed = new byte[seed.Length + 2];

        for (var i = 0; i < seed.Length; i++) {
            extSeed[i] = seed[i];
            }
        extSeed[seed.Length] = (byte)x;
        extSeed[seed.Length + 1] = (byte)y;

        var state = Absorb(extSeed);
        return state;

        }

    /// <summary>
    /// Perform the Kyber Absorb function using the seed value <paramref name="seed"/>
    /// for the element <paramref name="x"/>.
    /// </summary>
    /// <param name="seed">The seed value</param>
    /// <param name="x">The x value</param>
    /// <returns>The state array (for now).</returns>
    public ulong[] AbsorbD(byte[] seed, int x) {

        var extSeed = new byte[seed.Length + 2];

        for (var i = 0; i < seed.Length; i++) {
            extSeed[i] = seed[i];
            }
        extSeed[seed.Length] = (byte)x;
        extSeed[seed.Length + 1] = (byte)(x >> 8);

        var state = Absorb(extSeed);
        return state;

        }

    /// <summary>
    /// Perform the Keccak squeeze function on the current state vector to return
    /// <paramref name="nblocks"/> of data in <paramref name="buffer"/> starting
    /// at byte <paramref name="index"/>/
    /// </summary>
    /// <param name="buffer">The output buffer.</param>
    /// <param name="nblocks">The number of output blocks to generate.</param>
    /// <param name="index">The first byte to write.</param>
    public void Squeeze(byte[] buffer, int nblocks, int index = 0) {
        while (nblocks > 0) {
            KeccakF();
            for (var i = 0; i < HashRate / 8; i++) {
                buffer.LittleEndianStore(state[i], index + (i * 8));
                }
            index += HashRate;
            nblocks--;
            }

        }

    }


/// <summary>
/// Extension class with convenience methods.
/// </summary>
public static class Extensions {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static string GetBufferFingerprint(this byte[] buffer) {
        var hash = SHAKE128.Process(buffer);
        return hash.ToStringBase16(Format: ConversionFormat.Dash4);
        }

    /// <summary>
    /// Output SHAKE128 digest of <paramref name="buffer"/> in hexadecimal.
    /// </summary>
    /// <param name="buffer">The buffer to output.</param>
    /// <param name="tag">Optional descriptive tag.</param>
    /// <param name="output">Output to write the result to.</param>
    public static void DumpBufferFingerprint(
                    this byte[] buffer,
                    string? tag = null,
                    TextWriter output = null) {

        output ??= Console.Out;
        if (tag != null) {
            output.WriteLine(tag);
            }

        output.WriteLine(GetBufferFingerprint(buffer));
        }

    /// <summary>
    /// Output selected byte values of <paramref name="buffer"/> in hexadecimal.
    /// </summary>
    /// <param name="buffer">The buffer to write.</param>
    /// <param name="tag">Optional descriptive tag.</param>
    /// <param name="length">Length to be written (if &lt;0, the entire buffer length)</param>
    /// <param name="first">First byte to be written</param>
    /// <param name="output">Output to write the result to.</param>
    public static void DumpBufferHex(
                    this byte[] buffer,
                    string? tag = null,
                    int length = -1,
                    int first = 0,
                    TextWriter output = null) {

        output ??= Console.Out;
        if (tag != null) {
            output.WriteLine(tag);
            }
        output.WriteLine(buffer.ToStringBase16(length: length, Format: ConversionFormat.Dash4, first: first));
        }

    }