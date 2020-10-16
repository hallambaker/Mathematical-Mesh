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

            //TestGoedelCryptography.Test().UDFMultipleKeyTest(100, UdfAlgorithmIdentifier.MeshProfileDevice);
            //TestGoedelCryptography.Test().UDFKeyGen(UDFKeyGen.TEST1);
            //TestGoedelCryptography.Test().UDFKeyGen(UDFKeyGen.TEST2);
            //TestGoedelCryptography.Test().UDFKeyGen(UDFKeyGen.TEST3);
            //TestGoedelCryptography.Test().UDFKeyGen(UDFKeyGen.TEST4);
            //TestGoedelCryptography.Test().UDFKeyGen(UDFKeyGen.TEST_KG_Device);
            //TestGoedelCryptography.Test().UDFKeyGen(UDFKeyGen.TEST_KG_User);
            //TestGoedelCryptography.Test().UDFKeyGen(UDFKeyGen.TEST_KG_Service);


            // Currently failing on these main tests
            // Likely more now because CatalogAccess has been changed.
            //TestService.Test().MeshDeviceConnectApprove();
            //TestService.Test().MeshDeviceConnectStaticQR();
            TestService.Test().MeshCatalogGroup();
            //ShellTests.Test().TestMessageConfirmationAccept();



            //ShellTests.Test().TestMessageConfirmationAccept();
            //ShellTests.Test().TestAuthWeb();
            //ShellTests.Test().MeshDeviceConnectDynamicQR();
            //TestService.Test().MeshCatalogGroup();



            // 4 tests
            //TestService.Test().MeshGrantAdmin();
            //TestService.Test().MeshGrantExternal();
            //TestService.Test().MeshGrantSuperAdmin();
            //TestService.Test().MeshGrantRevokeExternal();

            // 3 tests
            // The Auth bundle:
            //ShellTests.Test().TestProfileConnectAuth();
            //ShellTests.Test().TestProfileConnectAuthAll();
            //ShellTests.Test().TestProfileConnectAuthAdmin();

            // 3 tests
            // The App bundle:
            //ShellTests.Test().TestProfileMail();
            //ShellTests.Test().TestProfileSSHPrivate();
            //ShellTests.Test().TestProfileSSHPublic();




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
