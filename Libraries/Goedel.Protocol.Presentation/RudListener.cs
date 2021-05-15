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

using Goedel.Cryptography;
//using Goedel.Protocol.Presentation;
using Goedel.Utilities;

using System;
using System.Collections.Generic;
using System.Threading;

namespace Goedel.Protocol.Presentation {

    /// <summary>
    /// RUD Listener class, accepts connections from multiple sources and passes them to
    /// the specified service.
    /// </summary>
    public class RudListener : Listener {

        #region // Properties


        #endregion
        #region // Constructors

        /// <summary>
        /// Base constructor, populate the common properties.
        /// </summary>
        /// <param name="credential">The credential used by the listener.</param>
        /// <param name="providers">The service providers to be dispatched to.</param>
        public RudListener(ICredentialPrivate credential, List<RudProvider> providers) : 
                base(credential, providers) {
            }

        #endregion
        #region // Methods 
        RudStream streamResponderChallenge = null;

        ///<inheritdoc/>
        public override RudStream GetTemporaryResponder(
            Packet packetRequest) => streamResponderChallenge ??
                    MakeConnectionResponder().CacheValue(out streamResponderChallenge);


        private RudStream MakeConnectionResponder() {
            var responder = new ConnectionResponder(this);

            return new RudStream(null, null, rudConnection: responder);
            }


        ///<inheritdoc/>
        public override List<PacketExtension> MakeChallenge(
                Packet packetRequest,
                byte[] payload = null) {
            var bytes = Platform.GetRandomBytes(16);
            var challenge = new PacketExtension() {
                Tag = Constants.ExtensionTagsChallengeTag,
                Value = bytes
                };
            return new List<PacketExtension> { challenge };
            }

        ///<inheritdoc/>
        public override bool VerifyChallenge(
                Packet packetRequest) => true;

        ///<inheritdoc/>
        public override RudStream AcceptConnection(Packet packetRequest) {


            var responder = new ConnectionResponder(this, packetRequest);

            switch (packetRequest) {
                case PacketInitiatorComplete packetClientCompleteDeferred: {
                    responder.CompleteInitiatorComplete(packetClientCompleteDeferred);

                    return AcceptStream(packetClientCompleteDeferred.CiphertextExtensions, responder,
                        null);
                    }
                }


            throw new NYI();
            }




        ///<inheritdoc/>
        public override RudStream AcceptStream(List<PacketExtension> packetExtensions,
                RudConnection rudConnection = null,
                RudStream stream=null) {
            RudStream child = null;

            // NB: Some of this functionality could be expressed in the connection. Hoevever,
            // it is (probably) better to combine this with connection creation.

            byte[] streamId=null;
            byte[] encrypt = null;
            string account = null;
            string protocol = null;

            string streamType = null;

            foreach (var extension in packetExtensions) {

                switch (extension.Tag) {
                    case Constants.ExtensionTagsStreamReceiverTag:
                    case Constants.ExtensionTagsStreamClientTag: {
                        streamType = extension.Tag;
                        protocol = extension.Value.ToUTF8();
                        break;
                        }
                    case Constants.ExtensionTagsStreamIdTag: {
                        streamId = extension.Value;
                        break;
                        }
                    case Constants.ExtensionTagsEncryptTag: {
                        streamId = extension.Value;
                        break;
                        }
                    case Constants.ExtensionTagsClaimIdTag: {
                        account = extension.Value.ToUTF8();
                        break;
                        }
                    }
                }

            switch (streamType) {
                case Constants.ExtensionTagsStreamClientTag: {
                    child = new RudStreamService(stream, protocol, accountAddress: account, rudConnection: rudConnection);
                    break;
                    }
                case Constants.ExtensionTagsStreamReceiverTag: {
                    child = new RudStreamReceiver(stream, protocol, accountAddress: account);
                    break;
                    }
                default: {
                    return null;
                    }
                }


            child.SetOptions(child.LocalStreamId.Bytes, encrypt);

            Screen.WriteLine($"Replace {child.LocalStreamId.Value} ");
            if (DictionaryStreamsInbound.TryGetValue(child.LocalStreamId, out var _)) {
                DictionaryStreamsInbound.Remove(child.LocalStreamId);

                }
            DictionaryStreamsInbound.Add(child.LocalStreamId, child);


            return child;
            }

        #endregion
        }

    }
