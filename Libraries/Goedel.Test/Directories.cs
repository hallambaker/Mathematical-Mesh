using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MT = Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Goedel.Test {
    public class Directories {

        public static string RunDirectory = @"..\..\..\..\WorkingDirectory";
        public static string RunDirectoryFramework = @"..\..\..\WorkingDirectory";
        public static string ResultDirectory;

        /// <summary>
        /// Directory for common test input data
        /// </summary>
        public static string CommonData = @"CommonData\";

        /// <summary>
        /// Directory for test output data
        /// </summary>
        public static string Results = @"Results\";


        public static string TestKey_SSH2 = CommonData + "TestKey_ssh2.pub";
        public static string TestKey_OpenSSH = CommonData + "TestKey_OpenSSH.pub";
        public static string TestKey_OpenSSH_Private = CommonData + "TestKey_OpenSSH.prv";
        public static string TestKey_PuTTY_Private = CommonData + "TestKey_PuTTY.ppk";
        public static string TestKey_Bitvise_Private = CommonData + "TestKey_Bitvise.bkp";


        public static string TestKey_Alice_Sign = CommonData + "TestKey_RSA_Alice.prv";
        public static string TestKey_Bob_Encrypt = CommonData + "TestKey_RSA_Bob.prv";


        public static void Initialize(MT.TestContext Context) {
            Context.Properties.TryGetValue("TestDeploymentDir", out var TestDeploymentDir);

            ResultDirectory = TestDeploymentDir as string;
            Directory.SetCurrentDirectory(RunDirectory);

            }


        }
    }
