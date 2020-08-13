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

            TestService.Test().MeshCatalogGroup();

            // 4 tests
            //TestService.Test().MeshGrantAdmin();
            //TestService.Test().MeshGrantExternal();
            //TestService.Test().MeshGrantSuperAdmin();
            //TestService.Test().MeshGrantRevokeExternal();

            // 5 tests
            //ShellTests.Test().TestProfileBookmark();
            //ShellTests.Test().TestProfileCalendar();
            //ShellTests.Test().TestProfileContact();
            //ShellTests.Test().TestProfileNetwork();
            //ShellTests.Test().TestProfilePassword();

            // 7 tests
            //ShellTests.Test().TestMessageConfirmationAccept();
            //ShellTests.Test().TestMessageConfirmationReject();
            //ShellTests.Test().TestMessageContactBusinessCardFetch();
            //ShellTests.Test().TestMessageContactBusinessCardExchange();
            //ShellTests.Test().TestMessageContactBusinessCardReject();
            //ShellTests.Test().TestMessageContactInPerson();
            //ShellTests.Test().TestMessageContactRemote();



            // 4 tests
            // The App bundle:
            //ShellTests.Test().TestMessageGroup();
            //ShellTests.Test().TestProfileMail();
            //ShellTests.Test().TestProfileSSHPrivate();
            //ShellTests.Test().TestProfileSSHPublic();

            // 3 tests
            // The Auth bundle:
            //ShellTests.Test().TestProfileConnectAuth();
            //ShellTests.Test().TestProfileConnectAuthAll();
            //ShellTests.Test().TestProfileConnectAuthAdmin();



            // The Auth bundle:

            //TestService.Test().MeshRevokeExternal();
            //TestService.Test().MeshGrantExternal();
            //TestService.Test().MeshGrantAdmin();
            //TestService.Test().MeshGrantSuperAdmin();


            //TestService.Test().MeshGrantPrivs();
            //[Tests will likely need a rewrite here...]
            //   ShellTests.Test().TestProfileConnectAuth();
            //   ShellTests.Test().TestProfileConnectAuthAll();
            //   ShellTests.Test().TestProfileConnectAuthAdmin();


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
