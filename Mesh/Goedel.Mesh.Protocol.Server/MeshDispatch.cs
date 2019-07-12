//   Copyright © 2015 by Comodo Group Inc.
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
//  

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Goedel.Protocol;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Core;
namespace Goedel.Mesh.Server {

    /// <summary>
    /// The host class. Receives a stream from the HTTP server caller and 
    /// dispatches the specified server.
    /// </summary>
    public class PublicMeshServiceProvider : MeshServiceProvider {


        IMeshMachine MeshMachine;

        ///<summary>The profile describing the service</summary>
        public ProfileService ProfileService;

        ///<summary>The profile describing the host</summary>
        public ProfileHost ProfileHost;


        /// <summary>
        /// Initialize a Mesh Service Provider.
        /// </summary>
        /// <param name="domain">The domain of the service provider.</param>
        /// <param name="serviceDirectory">The mesh persistence store filename.</param>
        public PublicMeshServiceProvider(string domain, string serviceDirectory) {

            MeshMachine = new MeshMachineCoreServer(serviceDirectory);

            Mesh = new MeshPersist(serviceDirectory);

            // Dummy profiles for the service and host at this point
            ProfileService = ProfileService.Generate(MeshMachine);
            ProfileHost = ProfileService.CreateHost(MeshMachine);
            }

        /// <summary>
        /// The mesh persistence provider.
        /// </summary>
        public MeshPersist Mesh { get; set; }


        }


    /// <summary>
    /// The session class implements the Mesh session.
    /// </summary>
    public class PublicMeshService : MeshService {
        PublicMeshServiceProvider Provider;

        /// <summary>
        /// The mesh persistence provider.
        /// </summary>
        public MeshPersist Mesh => Provider.Mesh;

        /// <summary>
        /// The mesh service dispatcher.
        /// </summary>
        /// <param name="Host">The service provider.</param>
        /// <param name="Session">The authentication context.</param>
        public PublicMeshService(PublicMeshServiceProvider Host, JpcSession Session) {
            this.Provider = Host;
            Host.Interfaces.Add(this);
            Host.Service = this;
            this.JpcSession = Session;
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Account"></param>
        void AuthenticateToAccount(string Account) {
            // Goal: Put the authentication code in place here to reject requests without authentication.
            }


        /// <summary>
        /// Respond with the 'hello' version and encoding info. This request does not 
        /// require authentication or authorization since it is the method a client
        /// calls to determine what the requirements for these are.
        /// </summary>		
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public override MeshHelloResponse Hello(
                HelloRequest Request, JpcSession jpcSession=null) {
            jpcSession = jpcSession ?? JpcSession;

            var HelloResponse = new MeshHelloResponse() {
                Version = new Goedel.Protocol.Version() {
                    Major = 3,
                    Minor = 0,
                    Encodings = new List<Goedel.Protocol.Encoding>(),
                    },
                EnvelopedProfileService = Provider.ProfileService.DareEnvelope,
                EnvelopedProfileHost = Provider.ProfileHost.DareEnvelope
                };

            var Encoding = new Goedel.Protocol.Encoding() {
                ID = new List<string> { "application/json" }
                };
            HelloResponse.Version.Encodings.Add(Encoding);

            return HelloResponse;
            }

        /// <summary>
		/// Base method for implementing the transaction CreateAccount.
        /// </summary>
        /// <param name="request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public override CreateResponse CreateAccount(
                CreateRequest request, JpcSession jpcSession = null) {

            jpcSession = jpcSession ?? JpcSession;


            try {
                var accountEntry = new AccountEntry(request);
                Mesh.AccountAdd(jpcSession, accountEntry);
                return new CreateResponse();
                }
            catch (System.Exception exception) {
                return new CreateResponse(exception);
                }
            }


        /// <summary>
        /// Base method for implementing the transaction Download.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
        /// <returns>The response object from the service</returns>
        public override StatusResponse Complete(
                CompleteRequest Request, JpcSession jpcSession = null) {
            jpcSession = jpcSession ?? JpcSession;
            try {
                return Mesh.AccountComplete(jpcSession, Request);
                }
            catch (System.Exception exception) {
                return new StatusResponse(exception);

                }

            }

        /// <summary>
        /// Base method for implementing the transaction Download.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
        /// <returns>The response object from the service</returns>
        public override StatusResponse Status(
                StatusRequest Request, JpcSession jpcSession = null) {
            jpcSession = jpcSession ?? JpcSession;
            try {
                return Mesh.AccountStatus(jpcSession, jpcSession.VerifiedAccount);
                }
            catch (System.Exception exception) {
                return new StatusResponse(exception);

                }

            }


        /// <summary>
        /// Base method for implementing the transaction  DeleteAccount.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
        /// <returns>The response object from the service</returns>
        public override DeleteResponse DeleteAccount(
                DeleteRequest Request, JpcSession jpcSession) {
            jpcSession = jpcSession ?? JpcSession;
            try {
                Mesh.AccountDelete(jpcSession, account: jpcSession.VerifiedAccount);
                return new DeleteResponse();
                }
            catch (System.Exception exception) {
                return new DeleteResponse(exception);

                }


            }


        /// <summary>
		/// Base method for implementing the transaction  Download.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public override DownloadResponse Download(
                DownloadRequest Request, JpcSession jpcSession) {
            jpcSession = jpcSession ?? JpcSession;
            try {
                var Updates = Mesh.AccountDownload(jpcSession, jpcSession.VerifiedAccount, Request.Select);
                return new DownloadResponse() { Updates = Updates};
                }
            catch (System.Exception exception) {
                return new DownloadResponse(exception);

                }
            }

        /// <summary>
		/// Base method for implementing the transaction  Upload.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public override UploadResponse Upload(
                UploadRequest Request, JpcSession jpcSession) {
            jpcSession = jpcSession ?? JpcSession;
            try {

                Mesh.AccountUpdate(jpcSession, jpcSession.VerifiedAccount, Request.Updates, Request.Self);
                return new UploadResponse();
                }
            catch (System.Exception exception) {
                return new UploadResponse(exception);

                }


            }
        /// <summary>
		/// Base method for implementing the transaction  Post.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public override PostResponse Post(
                PostRequest Request, JpcSession jpcSession) {
            jpcSession = jpcSession ?? JpcSession;
            try {
                Assert.True(Request.Accounts.Count == 1 & Request.Message.Count == 1,
                    NYI.Throw);
                Mesh.MessagePost(jpcSession, Request.Accounts[0], Request.Message[0]);
                return new PostResponse();
                }
            catch (System.Exception exception) {
                return new PostResponse(exception);

                }

            }

        /// <summary>
		/// Base method for implementing the transaction  Connect.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public override ConnectResponse Connect(
                ConnectRequest Request, JpcSession jpcSession) {
            jpcSession = jpcSession ?? JpcSession;


            // decode MessageConnectionRequestClient with verification
            var messageConnectionRequestClient = RequestConnection.Verify(
                    Request.MessageConnectionRequestClient);
            try {
                var connectResponse = Mesh.Connect(jpcSession, messageConnectionRequestClient);
                return connectResponse;
                }
            catch (System.Exception exception) {
                return new ConnectResponse(exception);

                }

            throw new NYI();
            }


        }
    }
