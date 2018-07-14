using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Protocol;


namespace Goedel.Confirm.Client {

    /// <summary>
    /// The RecryptClient class is a convenience interface to a RecryptService instance.
    /// This provides a single point at which dispatch methods for the various transactions 
    /// may perform sanity checking on input and output variables, enforce timeouts,
    /// attempt retry etc.
    /// </summary>
    public class ConfirmClient {
        ConfirmService Service;

        /// <summary>
        /// Convert message parameters to SRML data.
        /// </summary>
        /// <param name="Heading">The heading text (required).</param>
        /// <param name="Running">Additional descriptive text (optional).</param>
        /// <returns>The SRML data message.</returns>
        public static string ToRequestText (string Heading, string Running = null) {
            var Builder = new StringBuilder();

            Builder.Append("<srml>");
            Builder.Append("<h1>");
            Builder.Append(Heading);
            Builder.Append("</h1>");
            if (Running != null) {
                Builder.Append("<p>");
                Builder.Append(Running);
                Builder.Append("</p>");
                }
            Builder.Append("</srml>");
            return Builder.ToString();
            }

        /// <summary>
        /// Construct a confirmation client for the specified service address.
        /// </summary>
        /// <param name="Address">The service address.</param>
        public ConfirmClient(string Address) => Service = ConfirmPortal.Default.GetService(Address);

        /// <summary>
        /// Construct a confirmation client for the specified recryption profile.
        /// </summary>
        /// <param name="RecryptProfile">The recryption profile.</param>
        public ConfirmClient(ConfirmProfile RecryptProfile) => Service = ConfirmPortal.Default.GetService(RecryptProfile.Account);

        /// <summary>
        /// Post a Hello transaction.
        /// </summary>
        /// <returns>The hello response.</returns>
        public HelloResponse Hello () {
            var Request = new HelloRequest() { };
            return Service.Hello(Request);
            }

        /// <summary>
        /// Post a request transaction
        /// </summary>
        /// <param name="RequestEntry">The request entry.</param>
        /// <returns>The service response.</returns>
        public EnquireResponse Enquire (RequestEntry RequestEntry) {
            var Request = new EnquireRequest() {
                Request = RequestEntry
                };
            return Service.Enquire(Request);
            }

        /// <summary>
        /// Post a status transaction
        /// </summary>
        /// <param name="BrokerID">The transaction identifier returned by the broker.</param>
        /// <param name="Cancel">If true, cancel the response if the status is pending.</param>
        /// <returns>The service response.</returns>
        public StatusResponse Status (string BrokerID, bool Cancel) {
            var Request = new StatusRequest() {
                BrokerID = BrokerID,
                Cancel = Cancel
                };
            return Service.Status(Request);
            }

        /// <summary>
        /// Post a pending transaction
        /// </summary>
        /// <param name="ResponderID">The identifier of the responder for whom the pending transactions
        /// are being requested.</param>
        /// <returns>The service response.</returns>
        public PendingResponse Pending (string ResponderID) {
            var Request = new PendingRequest() {
                Responder = ResponderID
                };
            return Service.Pending(Request);
            }

        /// <summary>
        /// Post a response transaction
        /// </summary>
        /// <param name="ResponseEntry">The response information</param>
        /// <returns>The service response.</returns>
        public RespondResponse Respond (ResponseEntry ResponseEntry) {
            var Request = new RespondRequest() {
                Response = ResponseEntry};
            return Service.Respond(Request);
            }
        }
    }
