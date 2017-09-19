using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Utilities;
using Goedel.IO;
using Goedel.Recrypt;
using Goedel.Recrypt.Client;
using Goedel.Recrypt.Server;
using Goedel.Protocol.Debug;

namespace Goedel.Recrypt.Documentation {
    public partial class Shell {
        public override void Register (Register Options) {
            var Output = Options.Out.Value;

            // Call the code to make the examples
            var Examples = new RecryptExamples(Options);

            // Output the result to a file
            using (var Writer = Output.OpenTextWriterNew()) {
                var ExampleGenerator = new ExampleGenerator(Writer);
                ExampleGenerator.AdminExamples(Examples);
                }

            }
        }

    public partial class RecryptExamples {

        public string ServiceAddress = "recrypt.example.com";

        public RecryptClient RecryptClient;
        public RecryptPortalTraced Portal;
        public TraceDictionary Traces { get; set; }

        /// <summary>
        /// Generate a set of example messages.
        /// </summary>
        /// <param name="Options"></param>
        public RecryptExamples (Register Options) {
            StartService();
            Hello();
            Create();
            Recrypt();
            Suspend();
            Traces = Portal.Traces;
            }

        /// <summary>
        /// Start Mesh/Recrypt as a direct service
        /// </summary>
        void StartService () {
            Portal = new RecryptPortalTraced();
            RecryptPortal.Default = Portal;
            RecryptClient = new RecryptClient(ServiceAddress);
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

        public string LabelCreate = "Create";
        /// <summary>
        /// Publish profile
        /// </summary>
        void Create () {
            Portal.Label(LabelCreate);
            // Perform a hello transaction
            RecryptClient.CreateGroup();
            }

        public string LabelRecrypt = "Recrypt";
        /// <summary>
        /// Publish profile
        /// </summary>
        void Recrypt () {
            Portal.Label(LabelRecrypt);
            // Perform a hello transaction
            RecryptClient.RecryptData();
            }

        public string LabelSuspend = "Suspend";
        /// <summary>
        /// Publish profile
        /// </summary>
        void Suspend () {
            Portal.Label(LabelSuspend);
            // Perform a hello transaction
            RecryptClient.UpdateMember();
            }

        }

    }
