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


using Goedel.Utilities;


namespace Goedel.Protocol.Presentation;

/// <summary>
/// A RUD datagram.
/// </summary>
public class Datagram {

    #region // Properties

    ///<summary>The number of packets this datagram is divided into.</summary> 
    public int PacketCount => throw new NYI();

    ///<summary>The maximum size of each packet.</summary> 
    public int MaxPacketSize => throw new NYI();

    ///<summary>Index of the last packet sent out.</summary> 
    public int PacketIndexLast => throw new NYI();

    /////<summary>Per packet payload size.</summary> 
    //int payloadLength;

    ///<summary>The datagram payload (may be in construction.</summary> 
    public byte[] Payload;

    ///<summary>The datagram packets that have been received.</summary> 
    public bool[] Arrived;

    #endregion

    #region // Destructor
    #endregion

    #region // Constructors
    #endregion

    #region // Implement Interface: Ixxx
    #endregion

    #region // Methods 

    /// <summary>
    /// Encode packet index <paramref name="i"/>.
    /// </summary>
    /// <param name="i">Packet to encode.</param>
    /// <returns>The encoded packet.</returns>
    public Packet GetPacket(int i) => throw new NYI();

    /// <summary>
    /// Get the next packet.
    /// </summary>
    /// <returns></returns>
    public Packet GetNextPacket() => throw new NYI();


    #endregion
    }
