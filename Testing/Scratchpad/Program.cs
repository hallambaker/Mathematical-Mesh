using System;
using Goedel.XUnit;
using Goedel.Cryptography;
using Goedel.Utilities;


namespace Scratchpad {

    partial class Program {
        static void Main() {
            Console.WriteLine("Hello World");

            Cryptography.Initialize();

            var _ = Goedel.Mesh.Client.HostCatalogItem.Initialize;
            _ = Goedel.Mesh.MeshProtocol.Initialize;
            _ = Goedel.Mesh.MeshItem.Initialize;
            _ = Goedel.Mesh.Server.CatalogItem.Initialize;
            _ = Goedel.XUnit.TestItem.Initialize;


            // The tests we need to clear to write the 3.0 docs.

            TestService.Test().MeshDeviceConnectApprove();


            //ShellTests.Test().TestHello();
            //ShellTests.Test().TestProfileConnect();
            //ShellTests.Test().TestProfilePassword();
            //ShellTests.Test().TestMessageContact();

            }


        public static void Find(
                    CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.SHA_3_512) {
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
