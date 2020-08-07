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


            //TestSplit.Test().TestKey(16);

            //ShellTests.Test().TestConnectRequest();

            //TestService.Test().MeshCatalogAccount();

            // Target for Thursday:
            //TestService.Test().MeshEscrowRecover();
            //ShellTests.Test().TestAccountDelete();
            //ShellTests.Test().TestEscrowChangeDevice();
            //ShellTests.Test().TestEscrowChangeService();
            //ShellTests.Test().TestEscrowDeleteDevice();

            // Target for Friday

            //// Connect by dynamic QR
            ///

            //TestService.Test().MeshDeviceConnectStaticQR();


            // fitst connect works but not the second. Is there a bug in the message processing?
            ShellTests.Test().TestProfileConnectPin();

            // make sure that the pin is marked as read.
            ShellTests.Test().TestProfileConnectPinReused();


            TestService.Test().MeshDeviceConnectDynamicQR();
            ShellTests.Test().TestProfileConnectPinInvalid();
            ShellTests.Test().TestProfileConnectPinExpired();

            ShellTests.Test().TestProfileConnectStaticQR();



            // The App bundle:
            //ShellTests.Test().TestMessageGroup();
            //ShellTests.Test().TestProfileMail();
            //ShellTests.Test().TestProfileSSHPrivate();
            //ShellTests.Test().TestProfileSSHPublic();


            // The Auth bundle:

            //TestService.Test().MeshGrantPrivs();
            //[Tests will likely need a rewrite here...]
            //   ShellTests.Test().TestProfileConnectAuth();
            //   ShellTests.Test().TestProfileConnectAuthAll();







            // **** Tests yet to be written

            // ** DARE Sign

            // ** Mess with signature, various ways




            // ** Is the profile signed?

            // ** Is the profile signature valid?

            // ** Is the password catalog encrypted?

            // ** Is the user capability encrypted?

            // ** Is the service capability encrypted?

            // ** are messages encrypted to the recipient only?

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
