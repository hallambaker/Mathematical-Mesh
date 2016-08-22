using System;
using System.IO;
using Goedel.Mesh;
//using Goedel.Mesh.Local;
using Goedel.Mesh.Client;
//using Goedel.Mesh.Server;
using Goedel.Protocol.Debug;

namespace ExampleGenerator {
    public partial class CreateExamples {

        string Output1 = @"Examples\Examples.md";
        string Output2 = @"Examples\ExamplesWeb.md";

        string LogPortal = "Portal.jlog";
        string LogMesh = "Mesh.jlog";


        static void Main(string[] args) {
            var Program = new CreateExamples();
            Program.Go();
            }

        public TraceDictionary Traces;

        public void Go () {
            // Delete data from previous runs
            MakeClean();

            //// here make the examples
            //MakeExamples ();
            Go(Output1, Output2);

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





        //public void MakeExamples () {
        //    StartService();
        //    //Hello();


        //    Traces = Portal.Traces;

        //    using (var Writer = new StreamWriter(Output1)) {
        //        var ExampleGenerator = new ExampleGenerator(Writer);
        //        ExampleGenerator.MeshExamples(this);
        //        }

        //    using (var Writer = new StreamWriter(Output2)) {
        //        var ExampleGenerator = new ExampleGenerator(Writer);
        //        ExampleGenerator.MeshExamplesWeb(this);
        //        }
        //    }



        //public static string NameAccount = "alice";
        //public static string NameService = "example.com";
        //public readonly string AccountID = Account.ID(NameAccount, NameService);

        //// Set these variables to whatever type is used in the application
        //MeshClient MeshClient;
        //MeshPortalTraced Portal;
        ///// <summary>
        ///// Start the Mesh as a direct service
        ///// </summary>
        //void StartService() {
        //    // Create test Mesh
        //    File.Delete(LogMesh);
        //    File.Delete(LogPortal);

        //    Portal = new MeshPortalTraced(NameService, LogMesh, LogPortal);
        //    MeshPortal.Default = Portal;

        //    MeshClient = new MeshClient(NameService);
        //    }


        //public string LabelHello = "Hello";
        ///// <summary>
        ///// Create a new profile for alice@example.com
        ///// </summary>
        //void Hello() {
        //    Portal.Label(LabelHello);

        //    var Result = RecryptClient.Hello();
        //    }

        }
    }
