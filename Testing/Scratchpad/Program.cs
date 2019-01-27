using System;
using Goedel.XUnit;
using Goedel.Cryptography;

namespace Scratchpad {

    partial class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World");
            //TestCryptographyJose.Test().RoundTripKey(CryptoAlgorithmID.Ed448);
            //TestKeyless.Test().FindCompression();
            ShellTests.Test().TestFileEncrypt();

            //TestService.Test().MeshConnect();
            }


        }
    }
