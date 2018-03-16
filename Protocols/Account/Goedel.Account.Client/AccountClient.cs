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
        /// Create a new account.
        /// </summary>
        /// <param name="AccountID">The account identifier</param>
        /// <param name="UDF">The user's Mesh fingerprint.</param>
        /// <param name="ProfilePortal">The user's Personal Profile</param>
        /// <param name="PIN">PIN validator (if used).</param>
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
        /// Update an account definition.
        /// </summary>
        /// <param name="AccountID">The account identifier</param>
        /// <returns>The service response</returns>
        public DeleteResponse Delete (string AccountID) {
            var Request = new DeleteRequest() { };
            return Service.Delete(Request);
            }


        /// <summary>
        /// Update a member entry in an existing recryption group
        /// </summary>
        /// <param name="AccountID">The identifier of the member entry to update (what??)</param>
        /// <returns>The service response</returns>
        public UpdateResponse Update (string AccountID) {
            var Request = new UpdateRequest() { };
            return Service.Update(Request);
            }

        /// <summary>
        /// Request the account associated with the specified account ID.
        /// </summary>
        /// <param name="AccountID">The account identifier</param>
        /// <returns>The service response</returns>
        public GetResponse Get (string AccountID) {
            var Request = new GetRequest() { AccountId = AccountID };
            return Service.Get(Request);
            }


        /// <summary>
        /// Resolve an account identifier by making an account data request to the
        /// corresponding Account server.
        /// </summary>
        /// <param name="AccountID"></param>
        /// <returns></returns>
        public static AccountData GetAccountPofile (string AccountID) {

            AccountID.SplitAccountID(out var Account, out var Portal);

            var AccountClient = new AccountClient(Portal);

            var Response = AccountClient.Get(AccountID);
            return Response.Data;
            }
        }
    }
