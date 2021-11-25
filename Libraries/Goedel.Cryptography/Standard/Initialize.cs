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

using System.Security.Cryptography;


namespace Goedel.Cryptography;

/// <summary>
/// Initialize the cryptographic framework
/// </summary>
public static class CryptographyCommon {

    /// <summary>
    /// Cryptographic random number generator.
    /// </summary>
    private static RNGCryptoServiceProvider RNGCryptoServiceProvider =
        new();



    /// <summary>
    /// Fill a byte array with cryptographically strong random data.
    /// </summary>
    /// <param name="Data">The array to fill with cryptographically strong random bytes.</param>
    /// <param name="Offset">The index of the array to start the fill operation.</param>
    /// <param name="Count">The number of bytes to fill</param>
    public static void GetRandomBytes(byte[] Data, int Offset, int Count) =>
                RNGCryptoServiceProvider.GetBytes(Data, Offset, Count);


    }
