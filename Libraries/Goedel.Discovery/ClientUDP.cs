using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Goedel.Discovery {

    /// <summary>
    /// UDP Client wrapper. Performs buffering on reads.
    /// </summary>
    public class ClientUDP {

        IPEndPoint EndPoint;
        UdpClient UdpClient;
        Thread ListenerThread;
        int MaxRead;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Address">IP Address to bind to</param>
        /// <param name="Port">UDP Port to bind to.</param>
        /// <param name="TimeOut">Optional timeout value, if zero reads will not timeout.</param>
        /// <param name="MaxRead">Maximum number of data values to accept</param>
        public ClientUDP (IPAddress Address, int Port, int TimeOut = 0, int MaxRead = 0) {
            EndPoint = new IPEndPoint(Address, Port);
            UdpClient = new UdpClient(Goedel.Discovery.Platform.GetRandomPort());
            UdpClient.Connect(EndPoint);

            if (TimeOut > 0) {
                UdpClient.Client.ReceiveTimeout = TimeOut;
                }
            this.MaxRead = MaxRead;

            // Start the listener
            ListenerThread = new Thread(Listen);
            ListenerThread.Start();
            }


        bool Active = true;
        int ReadCount = 0;

        /// <summary>
        /// The listener thread
        /// </summary>
        private void Listen () {


            while (Active) {
                var ThisEndPoint = EndPoint;
                var Data = UdpClient.Receive(ref ThisEndPoint);
                ReadCount++;


                }

            }
        }
    }
