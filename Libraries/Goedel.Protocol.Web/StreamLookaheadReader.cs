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


namespace Goedel.Protocol.Web;

/// <summary>
/// Stream reader with one byte lookahead.
/// </summary>
public class StreamLookaheadReader {

    Stream Stream { get; }
    bool havePeek = false;
    int peek = -1;

    ///<summary>Maximum number of bytes to read. Unbounded if less than 0.</summary> 
    public int MaxRead { get; set; } = -1;
    int count = 0;

    ///<summary>If true, the number of bytes read since the last call to 
    ///<see cref="Start"/> is smaller than <see cref="MaxRead"/>.</summary> 
    public bool ValidLength => (MaxRead < 0) | (count < MaxRead);

    /// <summary>
    /// Constructor, return an instance reading the stream <paramref name="stream"/>.
    /// </summary>
    /// <param name="stream">The stream to be read.</param>
    public StreamLookaheadReader(Stream stream) {
        Stream = stream;
        }

    /// <summary>
    /// Reset the max character reader.
    /// </summary>
    public void Start(int maxRead) {
        MaxRead = maxRead;
        count = 0;
        }


    /// <summary>
    /// Return the next byte in the stream without advancing the read pointer.
    /// </summary>
    /// <returns>The next unread byte in the stream.</returns>
    public int Peek() {
        if (!havePeek) {
            peek = Stream.ReadByte();
            havePeek = true;
            }
        return peek;
        }

    /// <summary>
    /// Read the next byte and advance the read pointer.
    /// </summary>
    /// <returns>The next unread byte in the stream.</returns>
    public int ReadByte() {
        var result = Peek();
        havePeek = false;
        return result;
        }


    }
