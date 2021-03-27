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
using Goedel.Protocol.Service;
using Goedel.Protocol.Presentation;
using Goedel.Utilities;

using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Goedel.Mesh.Session {

    /// <summary>
    /// This class contains some material that should move to Goedel.Protocol.Presentation
    /// and some that should go to Goedel.Mesh. 
    /// </summary>
    public class MeshSession : SessionInitiator, IJpcSession {

        #region // Properties
        ///<inheritdoc/>
        public VerifiedAccount VerifiedAccount { get; }

        public string Domain { get; }
        public string Protocol { get; }
        public string Instance { get; }


        public ObjectEncoding ObjectEncoding { get; set; } =
            ObjectEncoding.JSON;

        public string Uri { get; }


        WebClient WebClient { get; set; }


        ///<inheritdoc/>
        protected override void Disposing() => WebClient?.Dispose();

        #endregion
        #region // Constructors

        public MeshSession(Credential clientCredential, string domain,
                    string protocol, string instance = null,
                    PresentationType presentationTypes = PresentationType.All) {

            Domain = domain;
            Protocol = protocol;
            Instance = instance;
            CredentialSelf = clientCredential;


            Uri = HttpEndpoint.GetUri(Domain, Protocol, Instance);

            WebClient = new WebClient();

            }


        #endregion
        #region // Implement Inteface IJpcSession


        public JsonObject Initialize(
                string tag,
                JsonObject request) {

            

            byte[] span = null;
            if (request != null) {
                span = SerializePayload(tag, request, out var stream);
                }

            var (buffer, position) = MakeTagKeyExchange(PlaintextPacketType.ClientInitial);
            var encoded = SerializeClientInitial(span, null, buffer, position);


            Screen.WriteLine($"Wait on URI {Uri}");

            var result = Transact(encoded);
            result.Wait();

            var responseData = result.Result;
            var response = ParsePayload(responseData);

            return response;
            }


        ///<inheritdoc/>
        public JsonObject Post(
                string tag,
                JsonObject request) {

            var span = SerializePayload(tag, request, out var stream);

            // now wrap the presentation around it.

            var result = Transact(span);

            



            throw new NYI();
            }




        private byte[] SerializePayload(string tag, JsonObject request, out MemoryStream stream) {
            stream = new MemoryStream();
            var writer = JsonObject.GetJsonWriter(ObjectEncoding);
            writer.WriteObjectStart();

            bool first = true;
            request.Serialize(writer, true, ref first);
            writer.WriteToken(tag, 0);
            writer.WriteObjectEnd();

            // avoid the copy by using a Span.
            return stream.ToArray();
            }

        private JsonObject ParsePayload(byte[] responseData) {
            using var reader = new JsonBcdReader(responseData);
            return JsonObject.FromJson(reader, true);
            }



        #endregion
        #region // Override Methods


        public Task<byte[]> Transact(byte[] payload) =>
                    WebClient.UploadDataTaskAsync(Uri, payload);
            




        #endregion
        #region // Methods
        #endregion
        }
    }
