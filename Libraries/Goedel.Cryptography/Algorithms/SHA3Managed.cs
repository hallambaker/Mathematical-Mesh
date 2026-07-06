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
/// SHAKE128 provider. This digest class supports varying bit size outputs
/// in 64 bit increments with a work factor of 2^128
/// </summary>
public class SHAKE128 {


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
        using var provider = new Shake128();

        foreach (var inputItem in input) {
            if (inputItem != null) {
                provider.AppendData(inputItem);
                }
            }
        return provider.GetCurrentHash(length);
        }

    }


/// <summary>
/// SHAKE128 provider. This digest class supports varying bit size outputs
/// in 64 bit increments with a work factor of 2^256
/// </summary>
public class SHAKE256  {

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
        using var provider = new Shake256();

        foreach (var inputItem in input) {
            if (inputItem != null) {
                provider.AppendData(inputItem);
                }
            }
        return provider.GetCurrentHash(length);

        }

    }

