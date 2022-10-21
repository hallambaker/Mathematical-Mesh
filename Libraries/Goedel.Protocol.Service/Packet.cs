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
/// Base type for inbound and outbound packets.
/// </summary>

public abstract record PacketUDP {
    ///<summary>The connection token size (16 bytes)</summary> 
    public const int ConnectionTokenLength = 16;

    ///<summary>Byte offset for the salt field (2 bytes)</summary> 
    public const int OffsetSalt = ConnectionTokenLength;

    ///<summary>The salt length, currently fixed at 2 bytes but could be expanded
    ///or variable. Since the IV is the connection ID plus the salt, and
    ///since we are using a mode that does not collapse on nonce reuse such as OCB,
    ///this is more than sufficient.</summary> 
    public const int SaltLength = 2;

    ///<summary>Byte offset for the truncated serial field (2 bytes)</summary> 
    public const int OffsetSerial = OffsetSalt + SaltLength;

    ///<summary>The serial number precision. This is currently 2 bytes allowing for
    ///32767 simultaneous packets in flight without ambiguity.</summary> 
    public const int SerialLength = 2;

    ///<summary>Byte offset for the expecting field (2 bytes)</summary> 
    public const int OffsetExpecting = OffsetSerial + SerialLength;

    ///<summary>Byte offset for the acknowledgements field (2 bytes)</summary> 
    public const int OffsetAcknowledge = OffsetExpecting + SerialLength;

    ///<summary>The acknowledgement field length. This does not need to extend
    ///to the entire window. In the case that the </summary> 
    public const int AcknowledgeLength = 2;

    ///<summary>Byte offset for the reserved field (2 bytes)</summary> 
    public const int StartPayload = OffsetAcknowledge + AcknowledgeLength;


    ///<summary>The packet plaintext data. This is retained even for an 
    ///an outbound packet in case the packet needs to be resent.</summary> 
    public byte[] Plaintext { get; set; }


    ///<summary>Tag indicating a 1 byte integer encoding.</summary> 
    public const byte Integer1 = 0b0000_0000;
    ///<summary>Tag indicating a 2 byte integer encoding.</summary> 
    public const byte Integer2 = 0b0100_0000;
    ///<summary>Tag indicating a 4 byte integer encoding.</summary> 
    public const byte Integer4 = 0b1000_0000;
    ///<summary>Tag indicating a 8 byte integer encoding.</summary> 
    public const byte Integer8 = 0b1100_0000;

    ///<summary>Tag indicating a 8 byte integer encoding.</summary> 
    public const byte IntegerMask = 0b1100_0000;

    ///<summary>Tag indicating a 8 byte integer encoding.</summary> 
    public const byte IntegerFirst = 0b0011_1111;
    }


