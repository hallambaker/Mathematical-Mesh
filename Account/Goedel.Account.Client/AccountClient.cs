using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Protocol;

namespace Goedel.Account.Client {

    /// <summary>
    /// The RecryptClient class is a convenience interface to a RecryptService instance.
    /// This provides a single point at which dispatch methods for the various transactions 
    /// may perform sanity checking on input and output variables, enforce timeouts,
    /// attempt retry etc.
    /// </summary>
    public class AccountClient {
        AccountService Service;

        /// <summary>
        /// Defaultr constructor, create a MeshClient for the specified service.
        /// </summary>
        /// <param name="Address">The recryption service to connect to.</param>
        public AccountClient (string Address) {
            Service = AccountPortal.Default.GetService(Address);
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
        public CreateResponse Create (
                    string AccountID,
                    string UDF,
                    string ProfilePortal,
                    string PIN) {

            var AccountData = new AccountData() {
                AccountId = AccountID,
                MeshUDF = UDF,
                Portal = new List<string> { ProfilePortal }
                };
            var Request = new CreateRequest() {
                Data = AccountData
                };
            return Service.Create(Request);
            }

        /// <summary>
        /// Update a recryption group definition.
        /// </summary>
        /// <returns>The service response</returns>
        public DeleteResponse Delete (string AccountID) {
            var Request = new DeleteRequest() { };
            return Service.Delete(Request);
            }


        /// <summary>
        /// Update a member entry in an existing recryption group
        /// </summary>
        /// <returns>The service response</returns>
        public UpdateResponse Update (string AccountID) {
            var Request = new UpdateRequest() { };
            return Service.Update(Request);
            }

        /// <summary>
        /// Request the account associated with the specified account ID.
        /// </summary>
        /// <returns>The service response</returns>
        public GetResponse Get (string AccountID) {
            var Request = new GetRequest() { AccountId = AccountID};
            return Service.Get(Request);
            }

        }
    }
