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

namespace Goedel.Protocol.Service;

/// <summary>
/// Block cipher performing a null transform on 16 bytes at a time. 
/// For debugging use only.
/// </summary>
public class NullTransform16 : ICryptoTransform {

    ///<inheritdoc/>
    public bool CanReuseTransform => true;

    ///<inheritdoc/>
    public bool CanTransformMultipleBlocks => false;

    ///<inheritdoc/>
    public int InputBlockSize => 16;

    ///<inheritdoc/>
    public int OutputBlockSize => 16;

    ///<inheritdoc/>
    public void Dispose() {
        }

    ///<inheritdoc/>
    public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, 
            byte[] outputBuffer, int outputOffset) {
        Array.Copy(inputBuffer, inputOffset, outputBuffer, outputOffset, inputCount);
        return inputCount;
        }

    ///<inheritdoc/>
    public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount) {
        throw new NotImplementedException();
        }
    }
