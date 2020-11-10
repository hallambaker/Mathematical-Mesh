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



            // Need to re-engineer shell tests so that they can be run as a monolithic process or detached. 

            //ShellTests.Test().TestFilePlain();

            //Goedel.XUnit.MakeSiteDocs.Test().DeleteDevice();



            //Goedel.XUnit.MakeSiteDocs.Test().FullTest();

            //Goedel.XUnit.MakeSiteDocs.Test().DecodeSecondDevice();
            //Goedel.XUnit.MakeSiteDocs.Test().CreateSSH();
            //Goedel.XUnit.MakeSiteDocs.Test().CreateMail();
            //Goedel.XUnit.MakeSiteDocs.Test().TestContact();
            Goedel.XUnit.MakeSiteDocs.Test().TestConfirmation();
            //Goedel.XUnit.MakeSiteDocs.Test().GroupTests();




            //ShellTests.Test().TestEscrowDeleteDevice();
            //Goedel.XUnit.MakeSiteDocs.Test().Recover();


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
