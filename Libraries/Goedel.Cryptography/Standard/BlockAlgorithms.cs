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

namespace Goedel.Cryptography.Standard;

/// <summary>
/// AES block encryption/decryption transform. This is used in the AES Key wrap and
/// other routines to wrap the block encryption provided at the platform level.
/// </summary>
public class AesBlock : BlockProvider {
    static readonly Aes Provider;
    readonly ICryptoTransform Transform;

    /// <summary>
    /// Return the block size in bits.
    /// </summary>
    public override int BlockSize => Provider.BlockSize;

    static AesBlock() {
        Provider = Aes.Create();
        Provider.Mode = CipherMode.ECB;
        Provider.Padding = PaddingMode.None;
        }


    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="Key">Key</param>
    /// <param name="Encrypt">If true, encrypt, otherwise decrypt</param>
    public AesBlock(byte[] Key, bool Encrypt) => 
            Transform = Encrypt ? Provider.CreateEncryptor(Key, null) : Provider.CreateDecryptor(Key, null);

    /// <summary>
    /// Factory method
    /// </summary>
    /// <param name="Key">The key to initialize the method</param>
    /// <param name="Encrypt">If true, create an encryptor, if false, create a decryptor.</param>
    /// <returns>The block provider.</returns>
    public static BlockProvider Factory(byte[] Key, bool Encrypt) => new AesBlock(Key, Encrypt);

    /// <summary>
    /// Encrypt or decrypt a single block of data under the specified key
    /// </summary>
    /// <param name="Input">Input byte array</param>
    /// <param name="InputOffset">Read offset in input array.</param>
    /// <param name="Output">Output byte array</param>
    /// <param name="OutputOffset">Write offset in output array.</param>
    public override void Process(byte[] Input, int InputOffset, byte[] Output, int OutputOffset) => Transform.TransformBlock(Input, InputOffset, Transform.InputBlockSize, Output, OutputOffset);


    }
