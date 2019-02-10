using System;
using Goedel.XUnit;
using Goedel.Cryptography;

namespace Scratchpad {

    partial class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World");

            //ShellTests.Test().TestProfileConnectPin();
            //ShellTests.Test().TestProfileEscrow();

            //ShellTests.Test().TestContainerArchive();
            //ShellTests.Test().TestContainerCatalogBase();
            //ShellTests.Test().TestContainerCatalogEncrypt();
            ShellTests.Test().TestContainerSpool();

            /* Skipping for now */
            //ShellTests.Test().TestProfileMail();
            //ShellTests.Test().TestProfileSSHPrivate();
            //ShellTests.Test().TestProfileSSHPublic();
            //ShellTests.Test().TestMessageGroup();
            }


        }
    }
