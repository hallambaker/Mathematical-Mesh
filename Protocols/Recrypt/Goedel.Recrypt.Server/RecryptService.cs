using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Protocol;
using Goedel.Recrypt;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;

namespace Goedel.Recrypt.Server {

    /// <summary>Recryption service running on the local host.</summary>
    public class RecryptServiceLocal : RecryptService {
        RecryptLocalServiceProvider Provider;


        RecryptStore RecryptStore  => Provider.RecryptStore; 

        /// <summary>
        /// The mesh service dispatcher.
        /// </summary>
        /// <param name="Host">The service provider.</param>
        /// <param name="Session">The authentication context.</param>
        public RecryptServiceLocal (RecryptLocalServiceProvider Host, JPCSession Session) {
            this.Provider = Host;
            Host.Interfaces.Add(this);
            Host.Service = this;
            this.JPCSession = Session;
            }


        /// <summary>
        /// Implements the transaction Hello.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
        /// <returns>The response object from the service</returns>
        public override HelloResponse Hello (
                HelloRequest Request) {

            var Version = new Goedel.Protocol.Version() {
                Major = 0,
                Minor = 1
                };

            var Response = new HelloResponse() {
                Version = Version
                };

            return Response;
            }



        /// <summary>
        /// Implements the transaction CreateGroup.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
        /// <returns>The response object from the service</returns>
        public override CreateGroupResponse CreateGroup (
                CreateGroupRequest Request) {

            RecryptStore.CreateGroup(Request.RecryptionGroup);
            var Response = new CreateGroupResponse() {
                };

            return Response;
            }

        /// <summary>
        /// Implements the transaction CreateGroup.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
        /// <returns>The response object from the service</returns>
        public override UpdateGroupResponse UpdateGroup (
                UpdateGroupRequest Request) {

            RecryptStore.UpdateGroup(Request.RecryptionGroup);
            var Response = new UpdateGroupResponse() {
                };

            return Response;
            }

        /// <summary>
        /// GetGroup Transaction Dispatch.
        /// </summary>
        /// <param name="Request">The request object</param>
        /// <returns>The response object</returns>
        public override GetGroupResponse GetGroup (GetGroupRequest Request) {

            var GroupID = Request.GroupID;
            var RecryptionGroup = RecryptStore.GetGroup(GroupID);

            var Response = new GetGroupResponse() {
                RecryptionGroup = RecryptionGroup
                };

            return Response;
            }

        /// <summary>
        /// GetKey Transaction Dispatch.
        /// </summary>
        /// <param name="Request">The request object</param>
        /// <returns>The response object</returns>
        public override GetKeyResponse GetKey (GetKeyRequest Request) {
            var RecryptionGroup = RecryptStore.GetGroup(Request.GroupID);


            var Response = new GetKeyResponse() {
                SignedKey = RecryptionGroup.CurrentEncryptionKey
                };

            return Response;
            }


        /// <summary>
        /// Implements the transaction Recrypt Data.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
        /// <returns>The response object from the service</returns>
        public override RecryptDataResponse RecryptData (
                RecryptDataRequest Request) {

            var UserDecryptionEntry = RecryptStore.GetUserDecryptionEntry(
                    Request.GroupKeyID, Request.MemberUDF, Request.MemberKeyUDF);
            if (UserDecryptionEntry == null) {
                return new RecryptDataResponse () {
                    };
                }

            // Perform the recryption
            return UserDecryptionEntry.RecryptData(Request);
            }





        ///// <summary>
        ///// Implements the transaction CreateGroup.
        ///// </summary>
        ///// <param name="Request">The request object to send to the host.</param>
        ///// <returns>The response object from the service</returns>
        //public override AddMemberResponse AddMember (
        //        AddMemberRequest Request) {

        //    RecryptStore.AddMember(Request.RecryptionGroup, Request.MemberEntry);
        //    var Response = new AddMemberResponse() {
        //        };

        //    return Response;
        //    }

        ///// <summary>
        ///// Implements the transaction CreateGroup.
        ///// </summary>
        ///// <param name="Request">The request object to send to the host.</param>
        ///// <returns>The response object from the service</returns>
        //public override UpdateMemberResponse UpdateMember (
        //        UpdateMemberRequest Request) {

        //    RecryptStore.UpdateMember(Request.RecryptionGroup, Request.MemberEntry);
        //    var Response = new UpdateMemberResponse() {
        //        };

        //    return Response;
        //    }






        }
    }
