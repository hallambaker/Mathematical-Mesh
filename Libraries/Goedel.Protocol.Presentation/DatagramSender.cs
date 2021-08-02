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
//  

using System;
using System.Collections.Generic;

using Goedel.Utilities;


namespace Goedel.Protocol.Presentation {

    /// <summary>
    /// Management of outbound UDP packets sent to a single destination.
    /// </summary>
    public class DatagramSender {

        #region // Properties

        ///<summary>The output queue</summary> 
        public List<Datagram> OutputQueue { get; } = new();

        ///<summary>Pending acknowledgements</summary> 
        List<uint> PendingAck { get; } = new();

        ///<summary>Sent packets waiting to be acknowledged</summary> 
        List<Packet> Unacknowledged { get; } = new();


        ///<summary>Time to schedule the next sender action.</summary> 
        public TimeSpan NextAction => throw new NYI();

        ///<summary>The transmit window specifying the maximum flight.</summary> 
        public int Window { get; private set; } = 2;

        #endregion

        #region // Destructor
        #endregion

        #region // Constructors
        #endregion


        #region // Methods 

        /// <summary>
        /// Queue the datagram <paramref name="datagram"/> for output at the priority 
        /// specified in the datagram.
        /// </summary>
        /// <param name="datagram">The datagram to queue.</param>
        public void QueueDatagram(Datagram datagram) {
            }


        /// <summary>
        /// Perform the next actions in queue.
        /// </summary>
        public void ProcessSend() {

            }

        /// <summary>
        /// Process acknowledgements in packet <paramref name="packet"/>
        /// </summary>
        /// <param name="packet">Received packet</param>
        public void ProcessReceipt(Packet packet) {
            // add packet sequence number to pending ack.

            // read list of acknowledgements, mark packets as acknowledged.

            // Determine space in output window

            // Send packets
            ProcessSend();
            }

        #endregion
        }
    }
