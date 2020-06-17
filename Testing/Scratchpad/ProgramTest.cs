using Goedel.Cryptography;
using Goedel.Utilities;
using Goedel.XUnit;
using Goedel.Mesh;

using System;


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


            // This test is failing because the message from Bob isn't passed to Alice.
            //TestService.Test().MeshMessageContact(); // Works but shouldn't
            //TestService.Test().MeshMessageConfirm(); // Works but shouldn't

            //ShellTests.Test().TestProfileConnectPin();

            //ShellTests.Test().TestMessageContactRemote();
            //ShellTests.Test().TestMessageContactBusinessCardFetch();
            //ShellTests.Test().TestMessageContactBusinessCardExchange();
            //ShellTests.Test().TestMessageContactBusinessCardReject();

            //ShellTests.Test().TestMessageContactInPerson();



            ShellTests.Test().TestMessageConfirmationAccept();

            ShellTests.Test().TestMessageConfirmationReject();


            // All the tests related to Groups.

            //StoreTests.Test().TestCatalog(); // Better get the basics right.
            //TestService.Test().MeshCatalogGroup();
            //ShellTests.Test().TestMessageGroup();

            //ShellTests.Test().TestContainerArchive();
            //ShellTests.Test().TestContainerCatalogBase();
            //ShellTests.Test().TestContainerCatalogEncrypt();

            //ShellTests.Test().TestFileEncrypt();
            //ShellTests.Test().TestFileSignEncrypt();


            // Shell connect tests
            //ShellTests.Test().TestProfileConnectAuth();
            //ShellTests.Test().TestProfileConnectAuthAdmin();
            //ShellTests.Test().TestProfileConnectAuthAll();

            // Application related shell commands
            //ShellTests.Test().TestProfileMail();
            //ShellTests.Test().TestProfileSSHPrivate();
            //ShellTests.Test().TestProfileSSHPublic();

            // The whole Escrow thing
            //ShellTests.Test().TestProfileEscrow();


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
