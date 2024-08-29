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
using System.Net;
using System.Net.Sockets;

namespace Goedel.Discovery;

/// <summary>
/// UDP Client wrapper. Performs buffering on reads.
/// </summary>
public class ClientUDP : Disposable {
    readonly IPEndPoint endPoint;
    UdpClient udpClient = null;
    readonly Thread listenerThread;
    readonly int maxRead;

    ///<summary>The last data read.</summary>
    public byte[] Data;

    ///<summary>The number of reads</summary>
    public int ReadCount = 0;


    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="address">IP Address to bind to</param>
    /// <param name="port">UDP Port to bind to.</param>
    /// <param name="timeOut">Optional timeout value, if zero reads will not timeout.</param>
    /// <param name="maxRead">Maximum number of data values to accept</param>
    public ClientUDP(IPAddress address, int port, int timeOut = 0, int maxRead = 0) {
        endPoint = new IPEndPoint(address, port);
        udpClient = new UdpClient();
        udpClient.Connect(endPoint);

        if (timeOut > 0) {
            udpClient.Client.ReceiveTimeout = timeOut;
            }
        this.maxRead = maxRead;
        this.maxRead.Future();

        // Start the listener
        listenerThread = new Thread(Listen);
        listenerThread.Start();
        }

    readonly bool active = true;



    /// <summary>
    /// The class specific disposal routine.
    /// </summary>
    protected override void Disposing() {
        udpClient?.Dispose();
        udpClient = null;
        }

    /// <summary>
    /// The listener thread
    /// </summary>
    private void Listen() {


        while (active) {
            var ThisEndPoint = endPoint;
            Data = udpClient.Receive(ref ThisEndPoint);
            ReadCount++;


            }

        }
    }
