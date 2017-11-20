using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Protocol;
using Goedel.Account;

namespace Goedel.Account.Server {

    /// <summary>Account service using local provider.</summary>
    public class AccountServiceLocal : AccountService {
        AccountLocalServiceProvider Provider;

        /// <summary>The persistence store.</summary>
        AccountStore AccountStore  => Provider.AccountStore; 

        /// <summary>
        /// Main constructor.
        /// </summary>
        /// <param name="Host">The host name for the service/</param>
        /// <param name="Session">The JPC session.</param>
        public AccountServiceLocal (
                    AccountLocalServiceProvider Host,
                    JPCSession Session) {
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
        public override CreateResponse Create (
                CreateRequest Request) {

            // NYI: Sanity check inputs to server transactions

            var Result = AccountStore.CreateAccount(Request.Data);

            var Response = new CreateResponse() {
                };

            return Response;
            }

        /// <summary>
        /// Implements the transaction CreateGroup.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
        /// <returns>The response object from the service</returns>
        public override DeleteResponse Delete (
                DeleteRequest Request) {

            // NYI: Sanity check inputs to server transactions
            var Result = AccountStore.DeleteAccount(Request.AccountId);

            // NYI: all forms of error returns
            var Response = new DeleteResponse() {
                };

            return Response;
            }


        /// <summary>
        /// Implements the transaction CreateGroup.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
        /// <returns>The response object from the service</returns>
        public override UpdateResponse Update (
                UpdateRequest Request) {

            AccountStore.UpdateAccount(Request.Data);

            var Response = new UpdateResponse() {
                };

            return Response;
            }

        /// <summary>
        /// Implements the transaction CreateGroup.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
        /// <returns>The response object from the service</returns>
        public override GetResponse Get (
                GetRequest Request) {

            var Result = AccountStore.GetAccount(Request.AccountId);
            var Response = new GetResponse() {
                Data = Result
                };

            return Response;
            }


        }
    }
