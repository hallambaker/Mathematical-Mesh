using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Utilities;
using Goedel.IO;
using Goedel.Confirm;
using Goedel.Confirm.Client;
using Goedel.Confirm.Server;
using Goedel.Protocol.Debug;

namespace Goedel.Confirm.Documentation {
    public partial class Shell {
        public override void Register (Register Options) {
            var Output = Options.Out.Value;

            // Call the code to make the examples
            var Examples = new ConfirmExamples(Options);

            // Output the result to a file
            using (var Writer = Output.OpenTextWriterNew()) {
                var ExampleGenerator = new ExampleGenerator(Writer);
                ExampleGenerator.AdminExamples(Examples);
                }

            }
        }

    public partial class ConfirmExamples {

        public string ServiceAddress = "recrypt.example.com";

        public ConfirmClient RecryptClient;
        public ConfirmPortalTraced Portal;
        public TraceDictionary Traces { get; set; }

        /// <summary>
        /// Generate a set of example messages.
        /// </summary>
        /// <param name="Options"></param>
        public ConfirmExamples (Register Options) {
            StartService();
            Hello();
            Enquire();

            Pending();
            Respond();
            Status();
            Traces = Portal.Traces;
            }

        /// <summary>
        /// Start Mesh/Recrypt as a direct service
        /// </summary>
        void StartService () {
            Portal = new ConfirmPortalTraced();
            ConfirmPortal.Default = Portal;
            RecryptClient = new ConfirmClient(ServiceAddress);
            }

        public string LabelHello = "Hello";
        /// <summary>
        /// Publish profile
        /// </summary>
        void Hello () {
            Portal.Label(LabelHello);
            // Perform a hello transaction
            RecryptClient.Hello();
            }


        public string LabelEnquire = "Enquire";
        /// <summary>
        /// Publish profile
        /// </summary>
        void Enquire () {
            Portal.Label(LabelEnquire);
            // Perform a hello transaction
            RecryptClient.Enquire();
            }

        public string LabelStatus = "Status";
        /// <summary>
        /// Publish profile
        /// </summary>
        void Status () {
            Portal.Label(LabelStatus);
            // Perform a hello transaction
            RecryptClient.Status();
            }

        public string LabelPending = "Pending";
        /// <summary>
        /// Publish profile
        /// </summary>
        void Pending () {
            Portal.Label(LabelPending);
            // Perform a hello transaction
            RecryptClient.Pending();
            }

        public string LabelRespond = "Respond";
        /// <summary>
        /// Publish profile
        /// </summary>
        void Respond () {
            Portal.Label(LabelRespond);
            // Perform a hello transaction
            RecryptClient.Respond();
            }



        }

    }
