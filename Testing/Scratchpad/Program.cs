using Goedel.Cryptography;
using Goedel.Utilities;
using Goedel.XUnit;

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

            // The tests we need to clear to get the group encryption stuff going:



            //TestDare.Test().MessageGroup();
            //TestDare.Test().MessageEncrypted();

            //TestService.Test().MeshCatalogAccount();
            TestService.Test().MeshCatalogGroup();

            // From the command line:
            //ShellTests.Test().TestFileEncrypt();
            //ShellTests.Test().TestFileSignEncrypt();
            //ShellTests.Test().TestMessageGroup();

            // Archive related shell commands
            //ShellTests.Test().TestContainerArchive();
            //ShellTests.Test().TestContainerCatalogBase();
            //ShellTests.Test().TestContainerCatalogEncrypt();

            // Application related shell commands
            //ShellTests.Test().TestProfileMail();
            //ShellTests.Test().TestProfileSSHPrivate();
            //ShellTests.Test().TestProfileSSHPublic();

            // Shell connect tests
            //ShellTests.Test().TestProfileConnect();
            //ShellTests.Test().TestProfileConnectAuth();
            //ShellTests.Test().TestProfileConnectAuthAdmin();
            //ShellTests.Test().TestProfileConnectAuthAll();
            //ShellTests.Test().TestProfileConnectEARL();
            //ShellTests.Test().TestProfileConnectPin();


            // The whole Escrow thing
            //ShellTests.Test().TestProfileEscrow();

            }


        /*
         * Need to have a better theory of how MessagIDs are processed and some specific tests
         * 
         * message status {accountA} has to be fixed up
         *  - detect completion of connection
         *  - detect outstanding connection requests
         * 
         * May well be something strange going on with the handling/enumeration of spools
         *  - Is it possible to traverse in reverse
         * 
         * Track read / unread messages
         * 
         * Correct bug when connecting a third device to a profile - getting just the original
         * request.
         * 
         * 
         */


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
