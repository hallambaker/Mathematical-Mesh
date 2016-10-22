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
using Goedel.Debug;

namespace Goedel.Mesh {

    /// <summary>
    /// The host class. Receives a stream from the HTTP server caller and 
    /// dispatches the specified server.
    /// </summary>
    public class PublicMeshServiceProvider : MeshServiceProvider {
        Mesh _Mesh;
        /// <summary>
        /// Initialize a Mesh Service Provider.
        /// </summary>
        /// <param name="Domain">The domain of the service provider.</param>
        /// <param name="MeshStore">The mesh persistence store filename.</param>
        /// <param name="PortalStore">The portal persistence store fielname.</param>
        public PublicMeshServiceProvider(string Domain, string MeshStore, string PortalStore) {
            _Mesh = new Mesh(Domain, MeshStore, PortalStore);
            }

        /// <summary>
        /// The mesh persistence provider.
        /// </summary>
        public Mesh Mesh {
            get {
                return _Mesh;
                }

            set {
                _Mesh = value;
                }
            }


        }


    /// <summary>
    /// The session class implements the Mesh session.
    /// </summary>
    public class PublicMeshService : MeshService {
        PublicMeshServiceProvider Provider;

        /// <summary>
        /// The mesh persistence provider.
        /// </summary>
        public Mesh Mesh {
            get {
                return Provider.Mesh;
                }
            }

        /// <summary>
        /// The mesh service dispatcher.
        /// </summary>
        /// <param name="Host">The service provider.</param>
        /// <param name="Session">The authentication context.</param>
        public PublicMeshService(PublicMeshServiceProvider Host, JPCSession Session) {
            this.Provider = Host;
            Host.Interfaces.Add(this);
            Host.Service = this;
            //this.JPCSession = Session;
            }


        /// <summary>
        /// Respond with the 'hello' version and encoding info.
        /// </summary>		
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public override HelloResponse Hello(
                HelloRequest Request) {

            var HelloResponse = new HelloResponse();
            HelloResponse.Version = new Version();
            HelloResponse.Version.Major = 0;
            HelloResponse.Version.Minor = 7;
            HelloResponse.Version.Encodings = new List<Encoding>();

            var Encoding = new Encoding();
            Encoding.ID = new List<string> { "application/json" };
            HelloResponse.Version.Encodings.Add(Encoding);

            return HelloResponse;
            }

        /// <summary>
        /// Base class for implementing the transaction.
        /// </summary>		
        /// <param name="Request">The request object to send to the host.</param>
        /// <returns>The response object from the service</returns>
        public override ValidateResponse ValidateAccount(
                ValidateRequest Request) {

            var ValidateResponse = new ValidateResponse();

            ValidateResponse.Minimum = 1;
            ValidateResponse.InvalidCharacters = @".,:;{}()[]<>?|\@#";
            ValidateResponse.Valid = Mesh.CheckAccount(Request.Account);

            if (!ValidateResponse.Valid) {
                ValidateResponse.Reason = "That name is not available";
                }

            return ValidateResponse;
            }

        /// <summary>
		/// Base class for implementing the transaction.
        /// </summary>		
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public override CreateResponse CreateAccount(
                CreateRequest Request) {
            var Response = new CreateResponse();
            var Success = Mesh.CreateAccount(Request.Account, Request.Profile);
            if (!Success) {
                Response.StatusCode = 409;
                }

            return Response;
            }

        /// <summary>
		/// Base class for implementing the transaction.
        /// </summary>		
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public override PublishResponse Publish(
                PublishRequest Request) {

            Mesh.UpdateProfile(Request.Entry);
            var Response = new PublishResponse();
            return Response;
            }

        /// <summary>
		/// Base class for implementing the transaction.
        /// </summary>		
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public override GetResponse Get(
                GetRequest Request) {
            var Response = new GetResponse();

            if (Request.Account != null) {
                var Account = Mesh.GetAccount(Request.Account);
                if (Account == null) return Response;

                var Profile = Mesh.GetSignedPersonalProfile(Account.UserProfileUDF);

                var EntryDatas = new List<Entry> { Profile };
                Response.Entries = EntryDatas;
                }
            else if (Request.Identifier != null) {

                var Profile = Mesh.GetProfile (Request.Identifier);
                if (Profile == null) return Response;

                var EntryDatas = new List<Entry> { Profile };
                Response.Entries = EntryDatas;
                }

            return Response;
            }

        /// <summary>
		/// Request a transfer of a part of the mesh log to another node
        /// </summary>		
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public override TransferResponse Transfer(
                TransferRequest Request) {
            var Response = new TransferResponse();
            return Response;
            }

        /// <summary>
        /// Return the current status of the Mesh log.
        /// </summary>		
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public override StatusResponse Status(
                StatusRequest Request) {
            var Response = new StatusResponse();
            return Response;
            }

        /// <summary>
		/// Add a pending device request for an account
        /// </summary>		
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public override ConnectStartResponse ConnectStart(
                ConnectStartRequest Request) {
            var ConnectStartResponse = new ConnectStartResponse();
            Mesh.PostConnectionRequest(Request.SignedRequest, 
                            Request.AccountID);

            return ConnectStartResponse;
            }

        /// <summary>
		/// Base class for implementing the transaction.
        /// </summary>		
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public override ConnectStatusResponse ConnectStatus(
                ConnectStatusRequest Request) {


            var Status = Mesh.GetRequestStatus(Request.AccountID, Request.DeviceID);
            var ConnectStatusResponse = new ConnectStatusResponse();

            ConnectStatusResponse.Result = Status;

            return ConnectStatusResponse;
            }

        /// <summary>
        ///  Get pending device add requests for an account
        /// </summary>		
        /// <param name="Request">The request object to send to the host.</param>
        /// <returns>The response object from the service</returns>
        public override ConnectPendingResponse ConnectPending(
                ConnectPendingRequest Request) {


            var Pending = Mesh.GetPendingRequests(Request.AccountID);
            var ConnectPendingResponse = new ConnectPendingResponse();
            ConnectPendingResponse.Pending = Pending;

            return ConnectPendingResponse;
            }

        /// <summary>
		/// Base class for implementing the transaction.
        /// </summary>		
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns> 
        public override ConnectCompleteResponse ConnectComplete(
                ConnectCompleteRequest Request) {

            Mesh.CloseConnectionRequest(Request.AccountID, Request.Result);

            var ConnectCompleteResponse = new ConnectCompleteResponse();

            return ConnectCompleteResponse;
            }



        }




    }
