using Goedel.Cryptography;
using Goedel.Utilities;
using Goedel.XUnit;
using Goedel.Mesh;

using System;


namespace Scratchpad {

    // Some unit tests are passing because the following are not being checked

    // Encryption of catalogs (especially password!)
    // Presence of signatures
    // Who signed
    // Validity of signatures

    // Profile path math.





    partial class Program {
        static void Main() {
            Console.WriteLine("Hello World");

            Cryptography.Initialize();


            var _ = Goedel.Mesh.Client.HostCatalogItem.Initialize;
            _ = Goedel.Mesh.MeshProtocol.Initialize;
            _ = Goedel.Mesh.MeshItem.Initialize;
            _ = Goedel.Mesh.Server.CatalogItem.Initialize;
            _ = Goedel.XUnit.TestItem.Initialize;

            //TestContainers.Test().ContainerTest0();
            //TestContainers.Test().ContainerTest1();
            //TestContainers.Test().ContainerTest10();

            //TestContainers.Test().ContainerTestEncrypted();

            // This is failing because the policy isn't being read back.
            TestContainers.Test().ContainerFixedPolicy();
            TestContainers.Test().ContainerFixedExchange();

            //ShellTests.Test().TestFilePlain();
            //ShellTests.Test().TestArchive();
            //ShellTests.Test().TestLog();


            //Goedel.XUnit.MakeSiteDocs.Test().FullTest();

            //Goedel.XUnit.MakeSiteDocs.Test().DecodeSecondDevice();
            //Goedel.XUnit.MakeSiteDocs.Test().CreateSSH();
            //Goedel.XUnit.MakeSiteDocs.Test().CreateMail();

            //Goedel.XUnit.MakeSiteDocs.Test().GroupTests();

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
