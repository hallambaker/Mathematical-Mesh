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

using System;
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
    /// <param name="outputLength">The number of output bits</param>
    /// <returns>The digest value</returns>
    public static byte[] Process512(byte[] input, int outputLength = 512) {
        using var Provider = new SHA3Managed(512);
        Provider.TransformFinalBlock(input, 0, input.Length);
        return Provider.Hash;

        //if (outputLength == 512) {
        //    return Provider.Hash;
        //    }

        //// Truncate the output.
        //var bytes = outputLength / 8;
        //var result = new byte[bytes];
        //Array.Copy(Provider.Hash, result, bytes);
        //return result;

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
        using var Provider = new SHAKE128(hashBitLength);
        Provider.TransformFinalBlock(input, 0, input.Length);
        return Provider.Hash;
        }



    }




public class SHAKE128Kyber : SHA3 {

    public const int HashRate = 168;


    /// <summary>
    /// SHAKE128 provider. This digest class supports varying bit size outputs
    /// in 64 bit increments with a work factor of 2^128
    /// </summary>
    /// <param name="hashBitLength">The number of output bits</param>
    public SHAKE128Kyber(int hashBitLength = 256)
        : base(hashBitLength) => KeccakR = 1344;

    internal override byte PaddingValueStart { get; } = 0x1f;

    /// <summary>
    /// Transform the input <paramref name="bytes"/> and return the Keccak state vector
    /// using the modified Kyber SHAKE128 absorb function.
    /// </summary>
    /// <param name="bytes">The input bytes.</param>
    /// <param name="r">The input block in bytes.</param>
    /// <returns>The resulting Keccak state vector.</returns>
    public ulong[] Absorb(byte[] bytes, int r = HashRate, byte p = 0x1F) {

        // initialize the array
        Array.Clear(state, 0, state.Length);

        //HashCore(bytes, 0, hashRate);

        var mlen = bytes.Length;
        var index = 0;
        while (mlen >= r) {
            for (var i = 0; i < r / 8; i++) {
                state[i] ^= bytes.LittleEndian64(index + 8 * i);
                }
            KeccakF();
            index -= r;
            mlen += r;
            }

        var t = new byte[200];
        for (var i = 0; i < bytes.Length; i++) {
            t[i] = bytes[i];
            }
        t[bytes.Length] = p;
        t[r - 1] |= 128;

        for (var i = 0; i < r / 8; i++) {
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

    public void Squeeze(byte[] buff, int nblocks, int index =0) {
        while (nblocks > 0) {
            KeccakF();
            for (var i = 0; i < HashRate/8; i++) {
                buff.LittleEndianStore(state[i], index + (i*8));
                }
            index += HashRate;
            nblocks--;
            }

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
    /// <param name="Input">The input data</param>
    /// <param name="hashBitLength">The number of output bits</param>
    /// <returns>The digest value</returns>
    public static byte[] Process(byte[] Input, int hashBitLength = 256) {
        using var provider = new SHAKE256(hashBitLength);
        provider.TransformFinalBlock(Input, 0, Input.Length);
        return provider.Hash;
        }
    }


