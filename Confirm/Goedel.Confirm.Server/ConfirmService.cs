using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Protocol;


namespace Goedel.Confirm.Server {
    public class ConfirmServiceLocal : ConfirmService {
        ConfirmLocalServiceProvider Provider;
        ConfirmStore ConfirmStore { get => Provider.ConfirmStore; }

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
        /// 
        /// </summary>
        /// <param name="Request"></param>
        /// <returns>The response object from the service</returns>
        public override EnquireResponse Enquire (
                EnquireRequest Request) {

            var BrokerID = ConfirmStore.EnquiryPost(Request.Request);

            var Response = new EnquireResponse() {
                BrokerID = BrokerID
                };

            return Response;
            }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Request"></param>
        /// <returns>The response object from the service</returns>
        public override StatusResponse Status (
                StatusRequest Request) {

            var ResponseEntry = ConfirmStore.EnquiryStatus(
                        Request.BrokerID, Request.Cancel);

            return new StatusResponse() {
                Response = ResponseEntry
                };

            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Request"></param>
        /// <returns>The response object from the service</returns>
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
        /// 
        /// </summary>
        /// <param name="Request"></param>
        /// <returns>The response object from the service</returns>
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
