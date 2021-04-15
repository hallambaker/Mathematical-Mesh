//  Copyright © 2021 by Threshold Secrets Llc.
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

using Goedel.Protocol;
using Goedel.Protocol.Presentation;
using Goedel.Utilities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Goedel.Protocol.Presentation {


    public struct DataGram {
        public byte[] Data;
        public bool IsFinal;
        }


    public delegate JsonObject TransactionPostDelegate(string tag, JsonObject request);

    public delegate void AsynchronousReceiveDelegate(DataGram dataGram);

    /// <summary>
    /// An RDP Stream
    /// </summary>
    public class RdpStream {

        ///<summary>The underlying connection</summary> 
        public virtual RdpConnection RdpConnection { get; }

        ///<summary>The child streams formed from this stream that MAY be rekeyed under this.</summary> 
        public List<RdpStream> ChildStreams;

        #region // Methods
        ///<summary>The local stream Id, this is generated localy and MAY contain hidden structure.</summary> 
        public StreamId LocalStreamId { get; protected set; }

        /// <summary>
        /// Perform a forward secrecy operation on the stream. If <paramref name="recurse"/> is
        /// true, the child streams will be marked to perform a rekey operation.
        /// </summary>
        /// <param name="recurse"></param>
        public void ForwardSecrecy(bool recurse) => throw new NYI();

        /// <summary>
        /// Request creation of a transactional stream in the client role.
        /// </summary>
        /// <param name="credential">Optional additional credential to be presented.</param>
        /// <returns>The created stream.</returns>
        public RdpStreamClient MakeStreamClient(Credential credential=null) => throw new NYI();


        /// <summary>
        /// Request creation of an asynchronous stream in the sender role.
        /// </summary>
        /// <param name="credential">Optional additional credential to be presented.</param>
        /// <returns>The created stream.</returns>
        public RdpStreamClient MakeStreamSender(Credential credential = null) => throw new NYI();

        /// <summary>
        /// Request creation of a transactional stream in the server role
        /// </summary>
        /// <param name="transactionPostDelegate">Optional delegate to be called when a request is received.</param>
        /// <returns>The created stream.</returns>
        public RdpStreamService MakeStreamService(TransactionPostDelegate transactionPostDelegate = null) => throw new NYI();


        /// <summary>
        /// Request creation of an asynchronous stream in the receiver role.
        /// </summary>
        /// <param name="asynchronousReceiveDelegate">Optional delegate to be called when data is received.</param>
        /// <returns></returns>
        public RdpStreamReceiver MakeStreamReceiver(AsynchronousReceiveDelegate asynchronousReceiveDelegate = null) => throw new NYI();

        /// <summary>
        /// Cause queued requests to be flushed.
        /// </summary>
        public void Flush () => throw new NYI();

        public async Task<RdpStream> AsyncReceiveStreamOffer() => throw new NYI();

        #endregion

        }


    /// <summary>
    /// The client side of an RDP transactional stream.
    /// </summary>
    public class RdpStreamClient : RdpStream, IJpcSession {

        #region // Methods
        public VerifiedAccount VerifiedAccount => throw new System.NotImplementedException();

        public JsonObject Post(string tag, JsonObject request) => throw new System.NotImplementedException();


        public async Task<JsonObject> PostAsync(string tag, JsonObject request) => throw new System.NotImplementedException();
        #endregion
        }


    public class RdpStreamService : RdpStream {

        #region // Methods
        public async Task<DataGram> AsyncRequestDatagram() => throw new NYI();

        public async Task<JsonObject> AsyncRequestObject() => throw new NYI();


        public void Respond (DataGram dataGram) => throw new NYI();


        public void Respond(JsonObject jsonObject) => throw new NYI();
        #endregion
        }



    public class RdpStreamSender: RdpStream {
        #region // Methods
        public async Task<DataGram> AsyncControlDatagram() => throw new NYI();

        public async void Send(DataGram dataGram) {

            }
        #endregion

        }


    public class RdpStreamReceiver: RdpStream {
        #region // Methods
        public async Task<DataGram> AsyncReceive() => throw new NYI();

        public async void SendControlDatagram(DataGram dataGram) {

            }
        #endregion

        }


    }
