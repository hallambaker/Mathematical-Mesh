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
using System.Collections.Generic;

using Goedel.Protocol.Presentation;
using Goedel.Utilities;
using Goedel.Protocol.Service;
using Goedel.Protocol;

namespace Goedel.Test.Core {




    public class RudListenerTest : RudListener {
        #region // Properties

        RudStream streamResponderChallenge = null;
        #endregion
        #region // Constructors
        /// <summary>
        /// Base constructor, populate the common properties.
        /// </summary>
        /// <param name="credential">The credential used by the listener.</param>
        /// <param name="providers">The service providers to be dispatched to.</param>
        public RudListenerTest(ICredentialPrivate credential, List<RudProvider> providers) :
                base(credential, providers) {
            }
        #endregion
        #region // Methods 

        ///<inheritdoc/>
        public override RudStream GetTemporaryResponder(
            Packet packetRequest) => streamResponderChallenge ??
                    MakeConnectionResponder().CacheValue(out streamResponderChallenge);


        private RudStream MakeConnectionResponder() {
            var responder = new ConnectionResponder(this);

            return new RudStream(null, null, rudConnection: responder);
            }

        public (byte[], Trace) Dispatch(byte[] requestBytes, TestSessionRud session) {
            //var jsonReader = new JsonReader(requestBytes);

            //var result = Host.Dispatch(session, jsonReader);

            //var responseBytes = result.GetBytes();
            //var trace = new Trace(requestBytes, responseBytes, Host);
            //return (responseBytes, trace);

            throw new NYI();
            }

        #endregion

        }

    public class ConnectionInitiatorTest : ConnectionInitiator {
        public ConnectionInitiatorTest(
            ICredentialPrivate credentialPrivate,
            string domain) : base(credentialPrivate, domain,
                null, TransportType.Direct, null) {
            }
        }

    public class ConnectionResponderTest : ConnectionResponder {



        /// <summary>
        /// Constructor for a connection host instance connected to <paramref name="listener"/>
        /// </summary>
        /// <param name="listener">The listener this connection is to service.</param>
        /// <param name="packetIn">The packet resulting in creation of the responder.</param>
        public ConnectionResponderTest(Listener listener,
                Packet packetIn = null) : base(listener, packetIn) {


            }

        }


    public class ServiceRequestDirect : ServiceRequest {
        public override void Abort(RequestQuality requestQuality) => throw new System.NotImplementedException();
        public override void Complete() => throw new System.NotImplementedException();
        protected override void ReturnResponse(byte[] payload) => throw new System.NotImplementedException();
        }


    }
