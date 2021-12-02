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

// Modified 2018, Phillip Hallam-Baker.
// Imported into Goedel libraries.

using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Goedel.Cryptography.Algorithms;

/// <summary>
/// 
/// </summary>
[ComVisible(true)]
public class HMACSHA3 : HMAC {


    /// <summary>
    /// Constructor for an HMACSHA3 HMAC.
    /// </summary>
    /// <param name="hashBitLength">The hash bit length, must be 224, 256, 384 or 512</param>
    public HMACSHA3(int hashBitLength = 512) : this(Utilities.GenerateRandom(0x80), hashBitLength) { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <param name="hashBitLength"></param>
    public HMACSHA3(byte[] key, int hashBitLength = 512) {
        Contract.Requires(key != null);

        key.AssertNotNull(NullKeyValue.Throw);
        base.HashName = "SHA3Managed";

        base.BlockSizeValue = hashBitLength switch {
            224 => 144,
            256 => 136,
            384 => 104,
            512 => 72,
            _ => throw new KeySizeNotSupported(),
            };
        base.HashSizeValue = hashBitLength;
        Initialize();
        base.Key = (byte[])key.Clone();
        }

    }
