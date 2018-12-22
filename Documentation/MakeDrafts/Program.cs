using System;
using System.IO;
using Goedel.Mesh;

//using Goedel.Mesh.Local;
//using Goedel.Mesh.Client;
//using Goedel.Mesh.Server;
using Goedel.Cryptography;
using Goedel.Protocol.Debug;

namespace ExampleGenerator {
    public partial class CreateExamples {


        string LogPortal = "Portal.jlog";
        string LogMesh = "Mesh.jlog";
        public bool All = false;

        static void Main(string[] args) {
            Goedel.IO.Debug.Initialize();
            Goedel.Cryptography.Cryptography.Initialize(); // initialize the cryptographic support libraries.

            var Program = new CreateExamples();
            Program.Go();
            }

        public TraceDictionary Traces;

        public void Go () {
            //// Delete data from previous runs
            //MakeClean();

            ExampleGenerator.MeshExamplesUDF(this);
            ExampleGenerator.MeshExamplesUDFCompressed(this);
            ExampleGenerator.MeshExamplesUDFCommitment(this);
            //GoContainer();
            //GenerateKeys();
            //GoDareContainer();
            //GoDareMessage();
            ////JSONReader.Trace = true;
            //GoContainer();
            //GoReference();
            //GoAdvanced();
            ////GoKeyExchange();
            //GoMesh();

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
