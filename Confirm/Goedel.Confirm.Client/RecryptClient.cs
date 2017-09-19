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

        public ConfirmClient (string Address) {
            Service = ConfirmPortal.Default.GetService(Address);
            }

        public ConfirmClient (ConfirmProfile RecryptProfile) {
            Service = ConfirmPortal.Default.GetService(RecryptProfile.Account);
            }


        public HelloResponse Hello () {
            var Request = new HelloRequest() { };
            return Service.Hello(Request);
            }

        public EnquireResponse Enquire (RequestEntry RequestEntry) {

            var Request = new EnquireRequest() {
                Request = RequestEntry
                };
            return Service.Enquire(Request);
            }

        public StatusResponse Status (string BrokerID, bool Cancel) {
            var Request = new StatusRequest() {
                BrokerID = BrokerID,
                Cancel = Cancel
                };
            return Service.Status(Request);
            }

        public PendingResponse Pending (string ResponderID) {
            var Request = new PendingRequest() {
                Responder = ResponderID
                };
            return Service.Pending(Request);
            }


        public RespondResponse Respond (ResponseEntry ResponseEntry) {
            var Request = new RespondRequest() {
                Response = ResponseEntry};
            return Service.Respond(Request);
            }
        }
    }
