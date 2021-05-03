using Goedel.Cryptography;
using Goedel.Utilities;
using Goedel.XUnit;
using Goedel.Mesh;

using System;


namespace Scratchpad {

    // ToDo: Connect Dispatch to Web Client
    // ToDo: Parse account details from client
    // ToDo: Verify account details.
    // ToDo: Unit tests to attempt use of illegit credential.
    // ToDo: Audit the profile creation mechanism
    // ToDo: Clear all unit tests

    // ToDo: RUD Documentation - Grab examples from connection formation
    // ToDo: RUD Documentation - Describe stream lifecycle
    // ToDo: RUD Documentation - Describe account binding

    // ToDo: Meshman stand alone app
    // ToDo: Server stand alone app
    // ToDo: Server logging
    // ToDo: Server status info
    // ToDo: Server admin permissions



    partial class Program {
        static void Main() {
            Screen.WriteLine($"Start test  {DateTime.Now}");


            // Need to build out TestEnvironmentRdp as a listener
            TestPresentationMesh.Test().TestMeshMultiService();




            //TestAsymmetric.Test().EncryptTest(CryptoAlgorithmId.RSAExch);



            //TestService.Test().MeshCatalogAccount();


            //TestPresentationMesh.Test().InitialImmediateTest();
            //TestPresentationMesh.Test().ClientImmediateTest();
            //TestPresentationMesh.Test().InitialDeferredTest();
            //TestPresentationMesh.Test().ClientDeferredTest();


            //ShellTests.Test().TestArchive();
            //ServiceDiscovery.Test().TestDNSMultiple(10000);
            //ShellTests.Test().TestLog();
            //ShellTests.Test().TestHello();
            //ShellTestsHTTP.Test().TestHello();
            //GoedelProtocolService.Test().TestService();
            //Goedel.XUnit.MakeSiteDocs.Test().FullTest();
            //TestService.Test().ProtocolHello();


            // This is probably failing because the code is not properly marking messages as read.//Goedel.XUnit.MakeSiteDocs.Test().FullTest();

            }





        public static void Find(
                    CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.SHA_3_512) {
            //  Magic number for SHA2 is 4187123
            //  Magic number for SHA3 is  774665
            for (var i = 0; true; i++) {
                if ((i % 1000) == 0) {
                    Console.WriteLine(i);
                    }

                var document = $"UDF Compressed Document {i}";
                var contentType = "text/plain";
                var utf8 = document.ToUTF8();
                var digest = Platform.SHA3_512.Process(utf8);

                var buffer = UDF.UDFBuffer(digest, contentType);
                var UDFData = buffer.GetDigest(cryptoAlgorithmID);

                if (UDF.GetCompression(UDFData) > 0) {
                    Console.WriteLine($"!!!!!!!!!!!!!!!!  {i}");
                    return;
                    }

                }
            }

        }
    }
