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


            //ShellTests.Test().TestProfileConnectDynamicQR();
            ShellTests.Test().TestProfileConnectStaticQR();



            // Service Tests
            //TestService.Test().MeshDeviceConnectApprove();
            //TestService.Test().MeshDeviceConnectPIN();
            //TestService.Test().MeshCatalogMultipleDevice();
            //TestService.Test().MeshCatalogAccount();


            // This test is failing because the message from Bob isn't passed to Alice.
            //TestService.Test().MeshMessageContact();
            //TestService.Test().MeshMessageConfirm();

            //TestService.Test().MeshServiceFull();


            // Shell connect tests
            //ShellTests.Test().TestProfileConnect();

            //ShellTests.Test().TestProfileConnectAuthAdmin();
            //ShellTests.Test().TestProfileConnectAuthAll();


            //StoreTests.Test().TestSpoolSingle();



            // This is failing because the containerInfo field is not being correctly updated

            //ShellTests.Test().TestProfileConnectPin();


            //ShellTests.Test().TestProfileConnectAuth();







            // From the command line:

            // Archive related shell commands
            //ShellTests.Test().TestContainerArchive();
            //ShellTests.Test().TestContainerCatalogBase();
            //ShellTests.Test().TestContainerCatalogEncrypt();

            //ShellTests.Test().TestFileEncrypt();
            //ShellTests.Test().TestFileSignEncrypt();




            // The whole Escrow thing
            //ShellTests.Test().TestProfileEscrow();

            // Application related shell commands
            //ShellTests.Test().TestProfileMail();
            //ShellTests.Test().TestProfileSSHPrivate();
            //ShellTests.Test().TestProfileSSHPublic();



            // All the tests related to Groups.
            //TestService.Test().MeshCatalogGroup();
            //ShellTests.Test().TestMessageGroup();
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
