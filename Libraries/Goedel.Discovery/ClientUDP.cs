using System.Net;
using System.Net.Sockets;
using System.Threading;
using Goedel.Utilities;

namespace Goedel.Discovery {

    /// <summary>
    /// UDP Client wrapper. Performs buffering on reads.
    /// </summary>
    public class ClientUDP : Disposable {

        IPEndPoint endPoint;
        UdpClient udpClient=null;
        Thread listenerThread;
        int maxRead;

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
        public ClientUDP (IPAddress address, int port, int timeOut = 0, int maxRead = 0) {
            endPoint = new IPEndPoint(address, port);
            udpClient = new UdpClient(Goedel.Discovery.Platform.GetRandomPort());
            udpClient.Connect(endPoint);

            if (timeOut > 0) {
                udpClient.Client.ReceiveTimeout = timeOut;
                }
            this.maxRead = maxRead;

            // Start the listener
            listenerThread = new Thread(Listen);
            listenerThread.Start();
            }


        bool active = true;
        


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
        private void Listen () {


            while (active) {
                var ThisEndPoint = endPoint;
                Data = udpClient.Receive(ref ThisEndPoint);
                ReadCount++;


                }

            }
        }
    }
