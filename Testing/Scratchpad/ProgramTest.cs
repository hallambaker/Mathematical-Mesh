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
            //var x = Environment.CommandLine;
            /* These only pass because the checks are disabled. */

            TestCryptographyJose.Test().Test_Jose_Sign();
            //ShellTests.Test().TestFilePlain();
            //Goedel.XUnit.MakeSiteDocs.Test().CreateMail();
            //Goedel.XUnit.MakeSiteDocs.Test().CreateSSH();

            //Goedel.XUnit.MakeSiteDocs.Test().DecodeSecondDevice();
            //Goedel.XUnit.MakeSiteDocs.Test().DeleteDevice();
            //Goedel.XUnit.MakeSiteDocs.Test().FullTest();
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
