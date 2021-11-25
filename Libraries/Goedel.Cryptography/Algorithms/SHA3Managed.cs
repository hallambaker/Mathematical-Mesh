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
            _ => throw new ArgumentException("hashBitLength must be 224, 256, 384, or 512", "hashBitLength"),
            };
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
    /// <param name="Input">The input data</param>
    /// <param name="hashBitLength">The number of output bits</param>
    /// <returns>The digest value</returns>
    public static byte[] Process(byte[] Input, int hashBitLength = 256) {
        using var Provider = new SHAKE128(hashBitLength);
        Provider.TransformFinalBlock(Input, 0, Input.Length);
        return Provider.Hash;
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
        using var Provider = new SHAKE256(hashBitLength);
        Provider.TransformFinalBlock(Input, 0, Input.Length);
        return Provider.Hash;
        }
    }
