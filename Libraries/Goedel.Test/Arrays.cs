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

using Goedel.Cryptography;

/// <summary>
/// 
/// </summary>
namespace Goedel.Test;


public static class Extensions {

    public static long SecondsInCE(this DateTime time) => time.Ticks / 10_000_000;
    public static long SecondsInCE(this DateTime? time) =>
                time == null ? -1 : SecondsInCE((DateTime)time);

    public static bool IsEqualTo(this DateTime first, DateTime second) =>
        first.SecondsInCE() == second.SecondsInCE();

    public static bool IsEqualTo(this DateTime? first, DateTime? second) =>
                first.SecondsInCE() == second.SecondsInCE();

    public static int[] Shuffle(int length) {
        var result = new int[length];
        var random = new Random();

        for (var i = 0; i < length; i++) {
            result[i] = i;
            }

        for (var i = 0; i < length; i++) {
            var j = random.Next(length - i);
            var x = result[j];
            result[j] = result[i];
            result[i] = x;
            }

        return result;
        }

    public static KeyShareSymmetric[] Shuffle(this KeyShareSymmetric[] keyShares, int count) {
        var permutation = Shuffle(keyShares.Length);
        var result = new KeyShareSymmetric[count];
        for (var i = 0; i < count; i++) {
            result[i] = keyShares[permutation[i]];
            }
        return result;
        }
    }

/// <summary>
/// 
/// </summary>
public static class MakeConstant {

    public static byte[] FillConstant(int length, int value) {
        var result = new byte[length];
        for (var i = 0; i < length; i++) {
            result[i] = (byte)value;
            }
        return result;


        }

    public static byte[] FillCount(int length, int offset = 0) {
        var result = new byte[length];
        for (var i = 0; i < length; i++) {
            result[i] = (byte)(offset + i);
            }
        return result;


        }


    }
