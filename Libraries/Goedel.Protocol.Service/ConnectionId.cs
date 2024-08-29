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


namespace Goedel.Protocol.Service;





/// <summary>
/// The connection identifier.
/// </summary>
public record ConnectionId {

    ///<summary>Unique serial number.</summary> 
    public ulong Serial { get; private set; }

    const ulong connectionInitial = 0;
    const ulong connectionInvalid = 1;
    const ulong connectionIgnore = 2;

    ///<summary>Reserves serial numbers 0-16</summary> 
    public const ulong ConnectionReserved = 16;

    ///<summary>Initial connection identifier.</summary> 
    public readonly static ConnectionId Initial = new ConnectionId(connectionInitial);

    ///<summary>Invalid connection identifier.</summary> 
    public readonly static ConnectionId Invalid = new ConnectionId(connectionInvalid);

    ///<summary>Ignore connection identifier</summary> 
    public readonly static ConnectionId Ignore = new ConnectionId(connectionIgnore);

    ///<summary>If true the connection identifier is an initial connection.</summary> 
    public bool IsInitial => Serial == connectionInitial;

    ///<summary>Connection token used for an initial packet.</summary> 
    public static readonly byte[] InitialPacket = new byte[16];

    /// <summary>
    /// Constructor, return an instance with unique serial number <paramref name="serial"/>.
    /// </summary>
    /// <param name="serial">The serial number of the connection.</param>
    public ConnectionId(ulong serial) {
        Serial = serial;
        }

    /// <summary>
    /// Constructor recovering the connection identifier from the first n bytes of
    /// <paramref name="plaintext"/>.
    /// </summary>
    /// <param name="plaintext">The decrypted identifier buffer.</param>
    public ConnectionId(byte[] plaintext) {
        Serial = plaintext.LittleEndian64();
        }

    /// <summary>
    /// Return the 
    /// </summary>
    /// <param name="decryptor"></param>
    /// <returns></returns>
    public static ConnectionId GetFirst(ICryptoTransform decryptor) {
        decryptor.Future();
        ulong serial = 16;
        return new ConnectionId(serial);
        }


    /// <summary>
    /// Write a connection token to the output buffer <paramref name="packet"/> beginning
    /// at byte <paramref name="packetOffset"/>. The connection token will be the result of
    /// encrypting the byte sequence formed from <see cref="Serial"/> followed by the
    /// value <paramref name="counter"/> using the encryption trasform <paramref name="encryptor"/>.
    /// </summary>
    /// <param name="encryptor">The encryptor to use</param>
    /// <param name="counter">Counter value, MUST be incremented on each use.</param>
    /// <param name="packet">Packet buffer to write the connection token to.</param>
    /// <param name="packetOffset">Offset within the buffer.</param>
    public void WriteConnectionToken(
                ICryptoTransform encryptor,
                ulong counter,
                byte[] packet,
                ref int packetOffset) {
        var plaintext = new byte[encryptor.InputBlockSize];
        plaintext.LittleEndianStore(Serial, 0);
        plaintext.LittleEndianStore(counter, 8);
        encryptor.TransformBlock(plaintext, 0, encryptor.InputBlockSize,
                packet, packetOffset);
        packetOffset += encryptor.OutputBlockSize;
        }
    }


/// <summary>
/// Issuer of connection identifiers.
/// </summary>
public record ConnectionIdGenerator {

    ///<summary>The first connection allocated (will never be issued though)</summary>  
    public ulong Start { get; }

    ///<sumary>The next connection identifier value to allocate.</sumary> 
    public ulong Serial { get; private set; }


    /// <summary>
    /// Constructor. Returns a new instance that is guaranteed to never issue a 
    /// connection identifier that could produce an all zeroes token.
    /// </summary>
    /// <param name="decryptor">The decryption transform.</param>
    public ConnectionIdGenerator(ICryptoTransform decryptor) {

        // make sure that se never issue a connection ID with all zeros by
        // setting the initial connection id to be one more than would 
        // give that result;
        var buffer = new byte[decryptor.OutputBlockSize];
        decryptor.TransformBlock(buffer, 0, buffer.Length, buffer, 0);
        Start = buffer.LittleEndian64();
        Serial = Start + 1;
        }

    /// <summary>
    /// Thread safe allocation of a unique new connection identifier which is
    /// guaranteed to never be one of the reserved values or to result in an 
    /// all zeros output.
    /// </summary>
    /// <returns>The new connection identifier.</returns>
    public ConnectionId GetNext() {

        // Make sure that we don't ever issue a reserved id
        Serial = Serial < ConnectionId.ConnectionReserved ? ConnectionId.ConnectionReserved :
            Serial;
        // Return the next serial number available.
        return new ConnectionId(Serial++);
        }

    }
