using System;
using System.IO;
using Goedel.Mesh;
//using Goedel.Mesh.Local;
using Goedel.Mesh.Client;
//using Goedel.Mesh.Server;
using Goedel.Protocol.Debug;

namespace ExampleGenerator {
    public partial class CreateExamples {


        string LogPortal = "Portal.jlog";
        string LogMesh = "Mesh.jlog";
        public bool All = true;

        static void Main(string[] args) {
            Goedel.IO.Debug.Initialize();
            MeshWindows.Initialize(true);

            var Program = new CreateExamples();
            Program.Go();
            }

        public TraceDictionary Traces;

        public void Go () {
            //// Delete data from previous runs
            //MakeClean();


            GoKeyExchange();
            GoContainer();
            GoMesh();

            // Make the documentation
            MakeDocs();
            }


        public void MakeClean () {
            var Process = System.Diagnostics.Process.Start("CMD.exe", "/C MakeClean");
            Process.WaitForExit();
            }

        public void MakeDocs () {
            var Process = All ? System.Diagnostics.Process.Start("CMD.exe", "/C MakeDocs") :
                System.Diagnostics.Process.Start("CMD.exe", "/C MakeOneDoc");
            Process.WaitForExit();
            }



        }
    }
