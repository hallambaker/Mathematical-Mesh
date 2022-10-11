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



public record Frame {

    IPEndPoint IPEndPoint { get; }

    PacketConnection ReceiverId { get; }

    byte[] Payload;

    ulong Acknowledged = 0;



    }

public record FrameReceiver {


    public void ProcessPacket(PacketInbound inboundPacket) {
        }

    }

/// <summary>
/// Frame receiver class handling messages sent to the socket itself.
/// </summary>
public record FrameReceiverSocket : FrameReceiver {
    }

public record FrameReceiverStream  : FrameReceiver {
    }

public record FrameReceiverService : FrameReceiver {




    }




public class ServiceBinding {

    ///<summary>The enclosing service.</summary> 
    UdpSocket UdpService { get; }

    public ServiceBinding(UdpSocket udpService) {
        UdpService = udpService;
        }

    public void Unbind() {
        }

    }


public record TransactionRequest {
    }

public record TransactionResult {
    }

public class OutboundStream {
    }
public class InboundStream {

    ///<summary>The enclosing service.</summary> 
    public UdpSocket UdpService { get; }

    ///<summary>The IP Endpoint (Address, port).</summary> 
    public IPEndPoint IPEndPoint => UdpService.IPEndPoint;

    public PacketConnection ReceiverId { get; }

    public InboundStream(UdpSocket udpService) {
        UdpService = udpService;
        }

    public async Task<byte[]> GetMessageAsync() {

        throw new NYI();
        }


    public void Close() {
        }

    }