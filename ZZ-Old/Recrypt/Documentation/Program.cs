using System;
using System.IO;
using Goedel.Recrypt;
using Goedel.Recrypt.Local;
using Goedel.Recrypt.Client;
using Goedel.Recrypt.Server;
using Goedel.Protocol.Debug;

namespace ExampleGenerator {
    public class CreateExamples {

        string Output1 = @"Examples\Examples.md";

        static void Main(string[] args) {
            var Program = new CreateExamples();
            Program.Go();
            }

        public void Go () {
            // Delete data from previous runs
            MakeClean();

            // here make the examples
            MakeExamples ();

            // Make the documentation
            MakeDocs();
            }


        public void MakeClean() {
            var Process = System.Diagnostics.Process.Start("CMD.exe", "/C MakeClean");
            Process.WaitForExit();
            }

        public void MakeDocs() {
            var Process = System.Diagnostics.Process.Start("CMD.exe", "/C MakeDocs");
            Process.WaitForExit();
            }


        public TraceDictionary Traces;
        public void MakeExamples () {
            StartService();
            Hello();


            Traces = Portal.Traces;

            using (var Writer = new StreamWriter(Output1)) {
                var ExampleGenerator = new ExampleGenerator(Writer);
                ExampleGenerator.RecryptExamplesWeb(this);
                }
            }


        public static string NameService = "example.com";
        string LogPortal = "Portal.jlog";
        RecryptClient RecryptClient;
        RecryptPortalTraced Portal;
        /// <summary>
        /// Start the Mesh as a direct service
        /// </summary>
        void StartService() {
            // Create test Mesh
            File.Delete(LogPortal);

            Portal = new RecryptPortalTraced(NameService, LogPortal);
            RecryptPortal.Default = Portal;


            RecryptClient = new RecryptClient(NameService);
            }


        public string LabelHello = "Hello";
        /// <summary>
        /// Create a new profile for alice@example.com
        /// </summary>
        void Hello() {
            Portal.Label(LabelHello);

            var Result = RecryptClient.Hello();
            }

        }
    }
