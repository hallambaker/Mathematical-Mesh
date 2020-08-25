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

using Goedel.Protocol;
using Goedel.Utilities;

using System.Collections.Generic;
namespace Goedel.Mesh.Server {

    /// <summary>
    /// The host class. Receives a stream from the HTTP server caller and 
    /// dispatches the specified server.
    /// </summary>
    public class PublicMeshServiceProvider : MeshServiceProvider {


        IMeshMachine meshMachine;

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

            domain.Future();

            meshMachine = new MeshMachineCoreServer(serviceDirectory);

            Mesh = new MeshPersist(this, serviceDirectory);

            // Dummy profiles for the service and host at this point
            ProfileService = ProfileService.Generate(meshMachine);
            ProfileHost = ProfileService.CreateHost(meshMachine);
            }

        /// <summary>
        /// The mesh persistence provider.
        /// </summary>
        public MeshPersist Mesh { get; set; }


        }


    /// <summary>
    /// The session class implements the Mesh session. The implementations in this class are mostly 
    /// stubbs that martial and validate the parameters presented in the request and pass the
    /// work on to the <see cref="MeshPersist"/> instance <see cref="Mesh"/>
    /// </summary>
    public class PublicMeshService : MeshService {
        PublicMeshServiceProvider provider;

        /// <summary>
        /// The mesh persistence provider.
        /// </summary>
        public MeshPersist Mesh => provider.Mesh;

        /// <summary>
        /// The mesh service dispatcher.
        /// </summary>
        /// <param name="host">The service provider.</param>
        /// <param name="session">The authentication context.</param>
        public PublicMeshService(PublicMeshServiceProvider host, JpcSession session) {
            this.provider = host;
            host.Interfaces.Add(this);
            host.Service = this;
            this.JpcSession = session;
            }


        /// <summary>
        /// Respond with the 'hello' version and encoding info. This request does not 
        /// require authentication or authorization since it is the method a client
        /// calls to determine what the requirements for these are.
        /// </summary>		
        /// <param name="request">The request object to send to the host.</param>
        /// <param name="jpcSession">The connection authentication context.</param>
		/// <returns>The response object from the service</returns>
        public override MeshHelloResponse Hello(
                HelloRequest request, JpcSession jpcSession = null) {
            //jpcSession ??= JpcSession;

            var HelloResponse = new MeshHelloResponse() {
                Version = new Goedel.Protocol.Version() {
                    Major = 3,
                    Minor = 0,
                    Encodings = new List<Goedel.Protocol.Encoding>(),
                    },
                EnvelopedProfileService = provider.ProfileService.EnvelopedProfileService,
                EnvelopedProfileHost = provider.ProfileHost.EnvelopedProfileHost,
                Status = 201 // Must specify this explicitly since not derrived from MeshResponse.
                };

            var Encoding = new Goedel.Protocol.Encoding() {
                ID = new List<string> { "application/json" }
                };
            HelloResponse.Version.Encodings.Add(Encoding);

            return HelloResponse;
            }

        /// <summary>
		/// Server method implementing the transaction CreateAccount.
        /// </summary>
        /// <param name="request">The request object to send to the host.</param>
        /// <param name="jpcSession">The connection authentication context.</param>
		/// <returns>The response object from the service</returns>
        public override CreateResponse CreateAccount(
                CreateRequest request, JpcSession jpcSession = null) {

            jpcSession ??= JpcSession;


            try {
                var accountEntry = new AccountUser(request);
                Mesh.AccountAdd(jpcSession, accountEntry);
                return new CreateResponse();
                }
            catch (System.Exception exception) {
                return new CreateResponse(exception);
                }
            }



        /// <summary>
        /// Server method implementing the transaction CreateGroup.
        /// </summary>
        /// <param name="request">The request object to send to the host.</param>
        /// <param name="jpcSession">The connection authentication context.</param>
        /// <returns>The response object from the service</returns>
        public override CreateGroupResponse CreateGroup(CreateGroupRequest request, 
                    JpcSession jpcSession = null) {

            jpcSession ??= JpcSession;


            try {
                var accountEntry = new AccountGroup(request);
                Mesh.AccountAdd(jpcSession, accountEntry);
                return new CreateGroupResponse();
                }
            catch (System.Exception exception) {
                return new CreateGroupResponse(exception);
                }
            }


        /// <summary>
        /// Server method implementing the transaction Download.
        /// </summary>
        /// <param name="request">The request object to send to the host.</param>
        /// <param name="jpcSession">The connection authentication context.</param>
        /// <returns>The response object from the service</returns>
        public override CompleteResponse Complete(
                CompleteRequest request, JpcSession jpcSession = null) {
            jpcSession ??= JpcSession;
            try {
                return Mesh.AccountComplete(jpcSession, jpcSession.VerifiedAccount, request);
                }
            catch (System.Exception exception) {
                return new CompleteResponse(exception);

                }

            }

        /// <summary>
        /// Server method implementing the transaction Download.
        /// </summary>
        /// <param name="request">The request object to send to the host.</param>
        /// <param name="jpcSession">The connection authentication context.</param>
        /// <returns>The response object from the service</returns>
        public override StatusResponse Status(
                StatusRequest request, JpcSession jpcSession = null) {
            jpcSession ??= JpcSession;
            try {
                return Mesh.AccountStatus(jpcSession, jpcSession.VerifiedAccount);
                }
            catch (System.Exception exception) {
                return new StatusResponse(exception);

                }

            }


        /// <summary>
        /// Server method implementing the transaction  DeleteAccount.
        /// </summary>
        /// <param name="request">The request object to send to the host.</param>
        /// <param name="jpcSession">The connection authentication context.</param>
        /// <returns>The response object from the service</returns>
        public override DeleteResponse DeleteAccount(
                DeleteRequest request, JpcSession jpcSession) {
            jpcSession ??= JpcSession;
            try {
                Mesh.AccountDelete(jpcSession, account: jpcSession.VerifiedAccount);
                return new DeleteResponse();
                }
            catch (System.Exception exception) {
                return new DeleteResponse(exception);

                }


            }


        /// <summary>
		/// Server method implementing the transaction  Download.
        /// </summary>
        /// <param name="request">The request object to send to the host.</param>
        /// <param name="jpcSession">The connection authentication context.</param>
		/// <returns>The response object from the service</returns>
        public override DownloadResponse Download(
                DownloadRequest request, JpcSession jpcSession) {
            jpcSession ??= JpcSession;
            try {
                var Updates = Mesh.AccountDownload(jpcSession, jpcSession.VerifiedAccount, request.Select);
                return new DownloadResponse() { Updates = Updates };
                }
            catch (System.Exception exception) {
                return new DownloadResponse(exception);

                }
            }

        /// <summary>
		/// Server method implementing the transaction  Upload.
        /// </summary>
        /// <param name="request">The request object to send to the host.</param>
        /// <param name="jpcSession">The connection authentication context.</param>
		/// <returns>The response object from the service</returns>
        public override TransactResponse Transact(
                TransactRequest request, JpcSession jpcSession) {
            jpcSession ??= JpcSession;
            try {

                Mesh.AccountUpdate(jpcSession, jpcSession.VerifiedAccount, 
                        request.Updates, request.Inbound, request.Outbound, request.Local, request.Accounts);
                return new TransactResponse();
                }
            catch (System.Exception exception) {
                return new TransactResponse(exception);

                }


            }
        /// <summary>
		/// Server method implementing the transaction  Post.
        /// </summary>
        /// <param name="request">The request object to send to the host.</param>
        /// <param name="jpcSession">The connection authentication context.</param>
		/// <returns>The response object from the service</returns>
        public override PostResponse Post(   
                PostRequest request, JpcSession jpcSession) {
            jpcSession ??= JpcSession;
            try {
                //if (request.Outbound!= null) {
                //    Assert.AssertTrue(request.Outbound.Count == 1, NYI.Throw); // Hack: Support multiple messages in one post
                //    Mesh.MessagePost(jpcSession, jpcSession.VerifiedAccount, request.Accounts, request.Outbound[0]);
                //    }
                //if (request.Local != null) {
                //    Assert.AssertTrue(request.Local.Count == 1, NYI.Throw); // Hack: Support multiple messages in one post
                //    Mesh.MessagePost(jpcSession, jpcSession.VerifiedAccount, null, request.Local[0]);
                //    }
                ////if (request.Inbound != null) {
                ////    throw new NYI();
                ////    //Assert.AssertTrue(request.Self.Count == 1, NYI.Throw); // Hack: Support multiple messages in one post
                ////    //Mesh.MessagePost(jpcSession, jpcSession.VerifiedAccount, null, request.Self[0]);
                ////    }


                return new PostResponse();
                }
            catch (System.Exception exception) {
                return new PostResponse(exception);

                }

            }

        /// <summary>
		/// Server method implementing the transaction  Connect.
        /// </summary>
        /// <param name="request">The request object to send to the host.</param>
        /// <param name="jpcSession">The connection authentication context.</param>
		/// <returns>The response object from the service</returns>
        public override ConnectResponse Connect(
                ConnectRequest request, JpcSession jpcSession) {
            jpcSession ??= JpcSession;


            // decode MessageConnectionRequestClient with verification
            var requestConnection = request.EnvelopedRequestConnection.Decode();

            try {
                var connectResponse = Mesh.Connect(jpcSession, requestConnection);
                return connectResponse;
                }
            catch (System.Exception exception) {
                return new ConnectResponse(exception);

                }

            throw new NYI();
            }


        /// <summary>
		/// Server method implementing the transaction  Claim.
        /// </summary>
        /// <param name="request">The request object to send to the host.</param>
		/// <param name="session">The authentication binding.</param>
		/// <returns>The response object from the service</returns>
        public override ClaimResponse Claim(
                    ClaimRequest request, 
                    JpcSession session = null) => 
            Mesh.Claim(session, request.EnvelopedMessageClaim);

        /// <summary>
        /// Server method implementing the transaction  PollClaim.
        /// </summary>
        /// <param name="request">The request object to send to the host.</param>
        /// <param name="session">The authentication binding.</param>
        /// <returns>The response object from the service</returns>
        public override PollClaimResponse PollClaim(
                    PollClaimRequest request,
                    JpcSession session = null) =>
            Mesh.PollClaim(session, request.TargetAccountAddress, request.PublicationId);


        /// <summary>
        /// Server method implementing the transaction Operate
        /// </summary>
        /// <param name="request">The request object to send to the host.</param>
        /// <param name="session">The authentication binding.</param>
        /// <returns>The response object from the service</returns>
        public override OperateResponse Operate(
                    OperateRequest request, 
                    JpcSession session = null) =>
            Mesh.Operate(session, request.AccountAddress, request.Operations);

        }
    }
