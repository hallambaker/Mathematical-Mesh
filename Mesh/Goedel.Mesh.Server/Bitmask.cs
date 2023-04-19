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


namespace Goedel.Mesh.Server;

/// <summary>
/// Represents a bitmask used to specify which stores were affected by an update.
/// </summary>
public record Bitmask {

    byte[] bitmask;

    /// <summary>
    /// Add the data in <paramref name="data"/> to the bit field vector
    /// creating or extended as necessary.
    /// </summary>
    /// <param name="data">The data to add.</param>
    public void Add(byte[] data) {

        // Ignore if the bitmask is null.
        if (data is null) {
            return;
            }

        if (bitmask is null) {
            bitmask = new byte[data.Length];
            Array.Copy(data, bitmask, bitmask.Length);
            return;
            }

        if (data.Length > bitmask.Length) {
            var bitmask2 = new byte[data.Length];
            Array.Copy(bitmask, bitmask2, bitmask.Length);
            }

        for (var i = 0; i < data.Length; i++) {
            bitmask[i] |= data[i];
            }
        }

    /// <summary>
    /// Return the bit field vector.
    /// </summary>
    public byte[] GetBits => bitmask;

    }
