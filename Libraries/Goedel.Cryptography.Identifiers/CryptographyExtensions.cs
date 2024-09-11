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

namespace Goedel.Cryptography;

public static class CryptographyExtensions {

    /// <summary>
    /// Return a manifest prefix in the form described in FIPS204 for DilithiumPure.
    /// The message is not included in the manifest as it may be long.
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public static byte[] CreateManifestPrefixPure(
            byte[] context) {
        // 𝑀′ ← BytesToBits(IntegerToBytes(0, 1) ∥ IntegerToBytes(|𝑐𝑡𝑥|, 1) ∥ 𝑐𝑡𝑥) ∥ �

        //1
        var clen = context?.Length ?? 0;
        (clen < 256).AssertTrue(CryptographicException.Throw);

        var length = 1 + 1 + clen;
        var bytes = new byte[length];

        //5
        int i = 0;
        bytes[i++] = 0;
        if (context is null) {
            bytes[i++] = 0;
            }
        else {
            bytes[i++] = (byte)clen;
            Array.Copy(context, 0, bytes, i, length);
            i += clen;
            }
        (length == i).AssertTrue(CryptographicException.Throw);

        return bytes;
        }

    /// <summary>
    /// Return a manifest in the form described in FIPS204 for DilithiumHashed
    /// </summary>
    /// <param name="digest">The digest value.</param>
    /// <param name="oid">An OID specifying the digest algorithm.</param>
    /// <param name="context">Optional context string of 255 bytes or fewer.</param>
    /// <returns>The manifest bytes.</returns>
    public static byte[] CreateManifestHashed(
                byte[] digest,
                byte[] oid,
                byte[]? context) {
        // M' ← BytesToBits(IntegerToBytes(1, 1) ∥ IntegerToBytes(|𝑐𝑡𝑥|, 1) ∥ 𝑐𝑡𝑥 ∥ OID ∥ PH𝑀)

        //1
        var clen = context?.Length ?? 0;
        (clen < 256).AssertTrue(CryptographicException.Throw);

        // 22
        var length = 1 + 1 + clen + oid.Length + digest.Length;
        var bytes = new byte[length];

        int i = 0;
        bytes[i++] = 1;
        if (context is null) {
            bytes[i++] = 0;
            }
        else {
            bytes[i++] = (byte)clen;
            Array.Copy(context, 0, bytes, i, length);
            i += clen;
            }

        Array.Copy(oid, 0, bytes, i, oid.Length);
        i += oid.Length;

        Array.Copy(digest, 0, bytes, i, digest.Length);
        i += oid.Length;

        (length == i).AssertTrue(CryptographicException.Throw);

        return bytes;
        }
    }
