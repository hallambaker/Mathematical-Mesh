//#region // Copyright - MIT License
////  © 2021 by Phill Hallam-Baker
////  
////  Permission is hereby granted, free of charge, to any person obtaining a copy
////  of this software and associated documentation files (the "Software"), to deal
////  in the Software without restriction, including without limitation the rights
////  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
////  copies of the Software, and to permit persons to whom the Software is
////  furnished to do so, subject to the following conditions:
////  
////  The above copyright notice and this permission notice shall be included in
////  all copies or substantial portions of the Software.
////  
////  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
////  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
////  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
////  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
////  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
////  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
////  THE SOFTWARE.
//#endregion

//using Goedel.Presence.Server;
//using Goedel.Protocol;
//using System.Net.Sockets;
//using System.Net;
//using System;
////using Goedel.Mesh.Shell.ServiceAdmin;


//namespace Goedel.XUnit;

//public class PresenceServerTesting : PresenceServer {

//    public int Skip { get; set; }
//    public int Stride { get; set; }

//    public int Count { get; set; }

//    public CommunicationConditions CommunicationConditions { get; set; }

//    public PresenceServerTesting(
//        GenericHostConfiguration hostConfiguration,
//        PresenceServiceConfiguration presenceServiceConfiguration) : 
//                base (hostConfiguration, presenceServiceConfiguration) {
        
        
//        }

//    /// <summary>
//    /// Unreliable UDP send. Will correctly send <see cref="Stride"/> packets
//    /// and then skip sending the next <see cref="Skip"/> packets. The starting
//    /// point in the sequence can be adjusted by changing the value of 
//    /// <see cref="Count"/>
//    /// </summary>
//    /// <param name="client"></param>
//    /// <param name="packet"></param>
//    /// <param name="bytes"></param>
//    /// <param name="endPoint"></param>
//    protected override void Send(
//                UdpClient client, byte[] packet, int bytes, IPEndPoint endPoint) {

//        if (Skip <= 0 || Count++ < Stride) {
//            client.Send(packet, packet.Length, endPoint);
//            return;
//            }
//        Console.WriteLine("Skip server");
//        if (Count > Skip + Stride) {
//            Count = 0;
            
//            }
//        }


//    }

