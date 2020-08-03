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

            // ** Fast access to simple tests for regression fixing.
            //TestService.Test().MeshCatalogAccount();
            //ShellTests.Test().TestMessageContactInPerson();

            TestService.Test().MeshDeviceConnectApprove();


            // ***** Currently failing tests


            // ** Just need some testing on the PIN expiry/reuse stuff.

            //****The PIN is not being marked as used.
            //ShellTests.Test().TestProfileConnectPinReused();

            //****This is failing because the PIN code is not type Encryption or EncryptSignature
            // This is required for EARLs.
            //ShellTests.Test().TestProfileConnectDynamicQR();



            //ShellTests.Test().TestAccountDelete();



            // **** Needs a lot of design work

            // ** Application related shell commands

            //ShellTests.Test().TestProfileMail();
            //ShellTests.Test().TestProfileSSHPrivate();
            //ShellTests.Test().TestProfileSSHPublic();

            // ** The Device Authorization stuff - nix these and restart
            //ShellTests.Test().TestProfileConnectAuth();
            //ShellTests.Test().TestProfileConnectAuthAdmin();
            //ShellTests.Test().TestProfileConnectAuthAll();

            // ** The whole Escrow thing
            //ShellTests.Test().TestEscrowAccountService();
            //ShellTests.Test().TestEscrowMeshOnly();




            // **** Tests yet to be written

            // ** Is the profile signed?

            // ** Is the profile signature valid?

            // ** Is the password catalog encrypted?

            // ** Is the user capability encrypted?

            // ** Is the service capability encrypted?

            // ** are messages encrypted to the recipient only?



            // **** Tests recently solved

            //ShellTests.Test().TestMessageGroup();
            //ShellTests.Test().TestMessageConfirmationAccept();
            //ShellTests.Test().TestMessageConfirmationReject();
            //ShellTests.Test().TestProfileConnectPinExpired();
            //ShellTests.Test().TestProfileConnectPinInvalid();
            //ShellTests.Test().TestMessageContactBusinessCardExchange();
            //ShellTests.Test().TestProfileContact();
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
