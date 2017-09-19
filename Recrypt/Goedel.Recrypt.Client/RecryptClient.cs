using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Protocol;
using Goedel.Recrypt;
using Goedel.Utilities;
using Goedel.Cryptography.Jose;

namespace Goedel.Recrypt.Client {

    /// <summary>
    /// The RecryptClient class is a convenience interface to a RecryptService instance.
    /// This provides a single point at which dispatch methods for the various transactions 
    /// may perform sanity checking on input and output variables, enforce timeouts,
    /// attempt retry etc.
    /// </summary>
    public class RecryptClient {
        RecryptService Service;
        public string Address;

        /// <summary>
        /// Defaultr constructor, create a MeshClient for the specified service.
        /// </summary>
        /// <param name="Address">The recryption service to connect to.</param>
        public RecryptClient (string Address) {
            Service = RecryptPortal.Default.GetService(Address);
            this.Address = Address;
            }

        public RecryptClient (RecryptProfile RecryptProfile) {
            Service = RecryptPortal.Default.GetService(RecryptProfile.Account);
            }


        /// <summary>
        /// Check protocol version.
        /// </summary>
        /// <returns>The service response</returns>
        public HelloResponse Hello () {
            var Request = new HelloRequest() { };
            return Service.Hello(Request);
            }

        /// <summary>
        /// Create a new recryption group.
        /// </summary>
        /// <returns>The service response</returns>
        public CreateGroupResponse CreateGroup (
                    RecryptionGroup RecryptionGroup) {
            var Request = new CreateGroupRequest() {
                RecryptionGroup= RecryptionGroup
                };
            return Service.CreateGroup(Request);
            }

        /// <summary>
        /// Update a recryption group definition.
        /// </summary>
        /// <returns>The service response</returns>
        public UpdateGroupResponse UpdateGroup (
                    RecryptionGroup RecryptionGroup) {
            var Request = new UpdateGroupRequest() {
                RecryptionGroup = RecryptionGroup
                };
            return Service.UpdateGroup(Request);
            }


        /// <summary>
        /// Update a recryption group definition.
        /// </summary>
        /// <returns>The service response</returns>
        public GetGroupResponse GetGroup (
                    string GroupID){
            var Request = new GetGroupRequest() {
                GroupID = GroupID
                };
           return Service.GetGroup(Request);
            }


        /// <summary>
        /// Create a new recryption group.
        /// </summary>
        /// <returns>The service response</returns>
        public GetKeyResponse RecryptKey (string GroupID) {


            var Request = new GetKeyRequest() {
                GroupID = GroupID
                };
            return Service.GetKey(Request);
            }


        /// <summary>
        /// Request a recryption operation on a Jose Recipient object
        /// </summary>
        /// <param name="MemberKeyUDF">The UDF of the encryption key for the device</param>
        /// <param name="MemberUDF">The UDF of the member profile</param>
        /// <param name="Recipient">The Recipient field in the encryption data</param>
        /// <returns>The service response</returns>
        public RecryptDataResponse RecryptData (
                    string MemberUDF,
                    string MemberKeyUDF,
                    Recipient Recipient) {


            var Request = new RecryptDataRequest() {
                MemberUDF = MemberUDF,
                MemberKeyUDF = MemberKeyUDF,
                GroupKeyID = Recipient.Header.Kid,
                EphemeralKey = Recipient.Header.Epk
                };
            return Service.RecryptData(Request);
            }




        /*********************************************************/

        /// <summary>
        /// Add a member to an existing recryption group
        /// </summary>
        /// <returns>The service response</returns>
        public AddMemberResponse AddMember (
                    string GroupID,
                    string MeshID) {
            var Request = new AddMemberRequest() { };
            return Service.AddMember(Request);
            }

        /// <summary>
        /// Update a member entry in an existing recryption group
        /// </summary>
        /// <returns>The service response</returns>
        public UpdateMemberResponse UpdateMember () {
            var Request = new UpdateMemberRequest() { };
            return Service.UpdateMember(Request);
            }



        /// <summary>
        /// Encrypt a file under a recryption group ID
        /// </summary>
        /// <param name="GroupID"></param>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public bool EncryptData (
                    string GroupID,
                    string Input,
                    string Output) {
            throw new Goedel.Utilities.NYI();
            }

        }
    }
