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


using Goedel.Cryptography.Nist;
using System.Reflection;

namespace Goedel.Cryptography;


/// <summary>
/// Generate a prime number from a UDF seed.
/// </summary>
/// <param name="ikm">The initial keying material.</param>
/// <param name="keySpecifier">The key specifier.</param>
/// <param name="keyName">The key name.</param>
public class PrimeGeneratorUdf(
                    byte[] ikm,
                    byte[] keySpecifier,
                    string keyName) : IPrimeGenerator {



    ///<summary>Dictionary tracking the number of times the method has been called.</summary> 
    public Dictionary<string, int> CallCount { get; } = new();

    ///<inheritdoc/>
    public BigInteger GetEntropy(
                BigInteger minInclusive, 
                BigInteger maxInclusive, 
                string tag = null, 
                int? hint = null) {

        BigInteger result;
        if (CallCount.TryGetValue(tag, out var count)) {
            CallCount.Remove(tag);
            }
        else {
            count = (int) (hint is null ? 0 : hint-1);
            }

        var bits = maxInclusive.CountBits();
        var nbytes = (bits + 7) / 8;
        do {
            count++;
            var tagExtended = $"{tag}.{count}";

            byte[] bytes = KeyPair.KeySeed(bits, ikm, keySpecifier, keyName, tagExtended);
            var trim = bits %8;

            var mask = (byte)0x7f;
            for (; trim > 0; trim--) {
                bytes[0] = (byte) (bytes[0] & mask);
                mask = (byte)( mask >> 1);
                }


            result = bytes.BigIntegerBigEndian();

            //Console.WriteLine($"Count {tagExtended}");

            } while (result > maxInclusive | result < minInclusive);

        CallCount.Add(tag, count);
        return result;
        }

    ///<inheritdoc/>
    public BigInteger GetEntropyUncounted(int bits, string tag) {
        byte[] bytes = KeyPair.KeySeed(bits, ikm, keySpecifier, keyName, tag);
        var result = bytes.BigIntegerBigEndian();
        return result;
        }

    ///<inheritdoc/>
    public (BigInteger, BigInteger) GetPrime(int bits, int modulus, string tag = null, int? hint = null) {
        var iterations = modulus switch {
            2048 => 32,
            3072 => 27,
            4096 => 22,
            _ => throw new CryptographicException()
            };

        var xp1 = GetEntropyUncounted(bits, tag);
        if (xp1.IsEven) {
            xp1++;
            }
        var p1 = xp1;


        var count = (int)(hint == null ? 0 : 2 * (hint));
        p1 += count;
        while (!NumberTheory.MillerRabin(p1, iterations)) {
            p1 += 2;
            count++;
            }

        CallCount.Add(tag, count);
        //Console.WriteLine($"Prime {tag}, {count}/{hint}, {p1}, {p1-xp1}");

        return (xp1, p1);
        }

    ///<inheritdoc/>
    public void Register(string tag, int count) => CallCount.Add(tag, count);

    /// <summary>
    /// Update the call count in the dictionary.
    /// </summary>
    /// <param name="tag">The identifier to update.</param>
    void UpdateCallCount(string tag) {
        if (CallCount.TryGetValue(tag, out var count)) {
            CallCount.Remove(tag);
            CallCount.Add(tag, count + 1);
            }
        else {
            CallCount.Add(tag, 1);
            }
        }

    }
