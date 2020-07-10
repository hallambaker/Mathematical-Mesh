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

            // ** Fast access to simple tests for regression fixing.
            TestService.Test().MeshCatalogAccount();
            //ShellTests.Test().TestProfileConnect();


            // ***** Currently failing tests


            // ** Finish off the group stuff
            //ShellTests.Test().TestMessageGroup();

            // ** Sure this has worked in the past.
            ShellTests.Test().TestMessageConfirmationAccept();
            //ShellTests.Test().TestMessageConfirmationReject();




            // ** Just need some testing on the PIN expiry/reuse stuff.
            //ShellTests.Test().TestProfileConnectDynamicQR();
            //ShellTests.Test().TestProfileConnectPinExpired();
            //ShellTests.Test().TestProfileConnectPinInvalid();
            //ShellTests.Test().TestProfileConnectPinReused();

            // ** The signature interface
            //ShellTests.Test().TestFileSign();
            //ShellTests.Test().TestFileSignEncrypt();

            // ** The catalog/archive interfaces
            //ShellTests.Test().TestContainerArchive();
            //ShellTests.Test().TestContainerCatalogBase();
            //ShellTests.Test().TestContainerCatalogEncrypt();

            // ** The whole Escrow thing
            //ShellTests.Test().TestEscrowAccountService();
            //ShellTests.Test().TestEscrowMeshOnly();



            // **** Needs a lot of design work
            // ** Application related shell commands
            //ShellTests.Test().TestProfileMail();
            //ShellTests.Test().TestProfileContact();
            //ShellTests.Test().TestProfileSSHPrivate();
            //ShellTests.Test().TestProfileSSHPublic();

            // ** The Device Authorization stuff - nix these and restart
            //ShellTests.Test().TestProfileConnectAuth();
            //ShellTests.Test().TestProfileConnectAuthAdmin();
            //ShellTests.Test().TestProfileConnectAuthAll();



            // **** Tests yet to be written

            // ** Is the profile signed?

            // ** Is the profile signature valid?

            // ** Is the password catalog encrypted?

            // ** Is the user capability encrypted?

            // ** Is the service capability encrypted?


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
