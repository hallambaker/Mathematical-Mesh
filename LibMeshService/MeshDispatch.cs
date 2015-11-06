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
    public class MeshServiceSession : MeshService {
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
        public MeshServiceSession(PublicMeshServiceProvider Host, JPCSession Session) {
            this.Provider = Host;
            //this.JPCSession = Session;
            }


        /// <summary>
		/// Respond with the 'hello' version and encoding info.
        /// </summary>		
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
        public override CreateResponse CreateAccount(
                CreateRequest Request) {
            var Response = new CreateResponse();
            var Success = Mesh.CreateAccount(Request.Account, Request.Profile);
            if (!Success) {
                Response.Status = 409;
                }

            return Response;
            }

        /// <summary>
		/// Base class for implementing the transaction.
        /// </summary>		
        public override PublishResponse Publish(
                PublishRequest Request) {

            Mesh.UpdateProfile(Request.Entry);
            var Response = new PublishResponse();
            return Response;
            }

        /// <summary>
		/// Base class for implementing the transaction.
        /// </summary>		
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
        public override TransferResponse Transfer(
                TransferRequest Request) {
            var Response = new TransferResponse();
            return Response;
            }

        /// <summary>
		/// Return the current status of the Mesh log.
        /// </summary>		
        public override StatusResponse Status(
                StatusRequest Request) {
            var Response = new StatusResponse();
            return Response;
            }

        /// <summary>
		/// Add a pending device request for an account
        /// </summary>		
        public override ConnectStartResponse ConnectStart(
                ConnectStartRequest Request) {

            var Pending = Mesh.PostConnectionRequest(Request.SignedRequest, 
                            Request.AccountID);

            return null;
            }

        /// <summary>
		/// Base class for implementing the transaction.
        /// </summary>		
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
        public override ConnectCompleteResponse ConnectComplete(
                ConnectCompleteRequest Request) {

            Mesh.CloseConnectionRequest(Request.AccountID, Request.Result);

            var ConnectCompleteResponse = new ConnectCompleteResponse();

            return ConnectCompleteResponse;
            }



        }




    }
