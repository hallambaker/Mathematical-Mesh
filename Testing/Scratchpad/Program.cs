using System;
using Goedel.XUnit;
using Goedel.Cryptography;

namespace Scratchpad {

    partial class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World");
            //TestGoedelCryptography.Test().TestDerive_5869_Separate();
            //TestKeyless.Test().FindCompression();
            ShellTests.Test().TestFilePlain();

            //TestService.Test().MeshConnect();
            }


        }
    }
