using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Protocol;
using Goedel.Account;
using Goedel.Utilities;

namespace Goedel.Account.Client {

    /// <summary>
    /// The RecryptClient class is a convenience interface to a RecryptService instance.
    /// This provides a single point at which dispatch methods for the various transactions 
    /// may perform sanity checking on input and output variables, enforce timeouts,
    /// attempt retry etc.
    /// </summary>
    public class AccountClient {
        AccountService AccountService;

        /// <summary>
        /// Default constructor, create a MeshClient for the specified service.
        /// </summary>
        /// <param name="Address">The recryption service to connect to.</param>
        public AccountClient (string Address) {
            Address.SplitAccountIDService(out var Service, out var Account);
            AccountService = AccountPortal.Default.GetService(Service, Account);
            }

        /// <summary>
        /// Check protocol version.
        /// </summary>
        /// <returns>The service response</returns>
        public HelloResponse Hello () {
            var Request = new HelloRequest() { };
            return AccountService.Hello(Request);
            }

        /// <summary>
        /// Create a new account.
        /// </summary>
        /// <param name="AccountID">The account identifier</param>
        /// <param name="UDF">The user's Mesh fingerprint.</param>
        /// <param name="PortalID">The user's portal account</param>
        /// <param name="PIN">PIN validator (if used).</param>
        /// <returns>The service response</returns>
        public CreateResponse Create (
                    AccountData AccountData) {


            var Request = new CreateRequest() {
                Data = AccountData
                };
            return AccountService.Create(Request);
            }

        /// <summary>
        /// Update an account definition.
        /// </summary>
        /// <param name="AccountID">The account identifier</param>
        /// <returns>The service response</returns>
        public DeleteResponse Delete (string AccountID) {
            var Request = new DeleteRequest() { };
            return AccountService.Delete(Request);
            }


        /// <summary>
        /// Update a member entry in an existing recryption group
        /// </summary>
        /// <param name="AccountID">The identifier of the member entry to update (what??)</param>
        /// <returns>The service response</returns>
        public UpdateResponse Update (string AccountID) {
            var Request = new UpdateRequest() { };
            return AccountService.Update(Request);
            }

        /// <summary>
        /// Request the account associated with the specified account ID.
        /// </summary>
        /// <param name="AccountID">The account identifier</param>
        /// <returns>The service response</returns>
        public GetResponse Get (string AccountID) {
            var Request = new GetRequest() { AccountId = AccountID };
            return AccountService.Get(Request);
            }



        }
    }
