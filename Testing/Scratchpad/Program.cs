using System;
using Goedel.XUnit;
using Goedel.Cryptography;
using Goedel.Utilities;
namespace Scratchpad {

    partial class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World");

            Cryptography.Initialize();
            //TestSplit.Test().TestKeyShare(32, "FFFFFFFF");
            //TestSplit.Test().TestShares(1, 1);

            //Find();
            ShellTests.Test().TestKey();
            //ShellTests.Test().TestCommitment();
            //ShellTests.Test().TestProfileEscrow();

            //ShellTests.Test().TestContainerArchive();
            //ShellTests.Test().TestContainerCatalogBase();
            //ShellTests.Test().TestContainerCatalogEncrypt();
            //ShellTests.Test().TestContainerSpool();

            /* Skipping for now */
            //ShellTests.Test().TestProfileMail();
            //ShellTests.Test().TestProfileSSHPrivate();
            //Utilities.Test().BaseConversionFormatting();
            //TestLifecycle.Test().Test_LifecycleDevice(CryptoAlgorithmID.DH);
            }



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
