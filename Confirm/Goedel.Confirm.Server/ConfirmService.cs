using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Protocol;


namespace Goedel.Confirm.Server {

    /// <summary>Copnfirmation service running on the local host.</summary>
    public class ConfirmServiceLocal : ConfirmService {
        ConfirmLocalServiceProvider Provider;

        ConfirmStore ConfirmStore  => Provider.ConfirmStore; 

        /// <summary>
        /// Construct a service from a service provider and a JPCsession.
        /// </summary>
        /// <param name="ServiceProvider">The service provider</param>
        /// <param name="Session">The JPC Session.</param>
        public ConfirmServiceLocal (
                    ConfirmLocalServiceProvider ServiceProvider,
                    JPCSession Session) {
            this.Provider = ServiceProvider;
            ServiceProvider.Interfaces.Add(this);
            ServiceProvider.Service = this;
            this.JPCSession = Session;
            }


        /// <summary>
        /// Base method for implementing the transaction  Hello.
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
        /// Enquire transaction dispatch
        /// </summary>
        /// <param name="Request">The request object.</param>
        /// <returns>The response object.</returns>
        public override EnquireResponse Enquire (
                EnquireRequest Request) {

            var BrokerID = ConfirmStore.EnquiryPost(Request.Request);

            var Response = new EnquireResponse() {
                BrokerID = BrokerID
                };

            return Response;
            }

        /// <summary>
        /// Status transaction dispatch
        /// </summary>
        /// <param name="Request">The request object.</param>
        /// <returns>The response object.</returns>
        public override StatusResponse Status (
                StatusRequest Request) {

            var ResponseEntry = ConfirmStore.EnquiryStatus(
                        Request.BrokerID, Request.Cancel);

            return new StatusResponse() {
                Response = ResponseEntry
                };

            }


        /// <summary>
        /// Pending transaction dispatch
        /// </summary>
        /// <param name="Request">The request object.</param>
        /// <returns>The response object.</returns>
        public override PendingResponse Pending (
                PendingRequest Request) {

            var Pending = ConfirmStore.GetPending(
                    Request.Responder, Request.MaxResponse, Request.AfterId);

            var Response = new PendingResponse() {
                Entries=Pending
                };

            return Response;
            }

        /// <summary>
        /// Respond transaction dispatch
        /// </summary>
        /// <param name="Request">The request object.</param>
        /// <returns>The response object.</returns>
        public override RespondResponse Respond (
                RespondRequest Request) {

            // NYI, need more info here.
            ConfirmStore.Response(Request.Response);

            var Response = new RespondResponse() {
                };

            return Response;
            }

        }
    }
