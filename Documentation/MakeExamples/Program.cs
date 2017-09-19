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
            Goedel.IO.Debug.Initialize();
            MeshWindows.Initialize(true);

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


        public void MakeClean () {
            var Process = System.Diagnostics.Process.Start("CMD.exe", "/C MakeClean");
            Process.WaitForExit();
            }

        public void MakeDocs () {
            var Process = System.Diagnostics.Process.Start("CMD.exe", "/C MakeDocs");
            Process.WaitForExit();
            }



        }
    }
