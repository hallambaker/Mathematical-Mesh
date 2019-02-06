using System;
using Goedel.XUnit;
using Goedel.Cryptography;

namespace Scratchpad {

    partial class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World");
            ShellTests.Test().TestProfileConnect();

            //TestCryptographyJose.Test().RoundTripKeyEphemeral(CryptoAlgorithmID.RSAExch);
            //TestKeyless.Test().FindCompression();
            //TestService.Test().MeshContact();

            //ShellTests.Test().TestMessageContact();
            //TestLifecycle.Test().Test_LifecycleMaster(CryptoAlgorithmID.DH);
            //TestService.Test().MeshConnect();
            }


        }
    }
