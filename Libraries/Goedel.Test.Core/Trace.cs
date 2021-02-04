using Goedel.Protocol;
using Goedel.Utilities;
using Goedel.Mesh.Client;
using Goedel.Mesh;
using Goedel.Cryptography;
using System.Collections.Generic;

namespace Goedel.Test.Core {
    public class Trace {

        public byte[] Request;
        public byte[] Response;
        public Response ResponseObject;
        public Request RequestObject;

        public string XMLRequest => GetRequest();
        public string XMLResponse => GetResponse();

        public string GetRequest() => RequestText;
        public string GetResponse() => ResponseText;

        public string RequestText;
        public string ResponseText;
        public Trace(byte[] request, byte[] response, JsonObject requestObject) {
            Request = request;
            Response = response;
            RequestText = Request.ToUTF8();
            ResponseText = Response.ToUTF8();
            RequestObject = requestObject as Request;
            ResponseObject = Goedel.Protocol.Response.FromJson(Response.JsonReader(), true);
            }

        }


    public class MeshCredentialTraced : MeshCredential {
        ///<summary>The account address (Account@Domain or @callsign)</summary>
        public virtual string AccountAddress { get; }

        public List<Trace> MeshProtocolMessages { get; }

        public MeshCredentialTraced(
            CatalogedDevice catalogedDevice,
            IKeyLocate keyLocate) : base(catalogedDevice, keyLocate) {
            }


        public MeshCredentialTraced(
            string accountAddress, List<Trace> meshProtocolMessages
            ) {
            AccountAddress = accountAddress;
            MeshProtocolMessages = meshProtocolMessages;
                }


        }
    }
