using System.IO;

namespace Goedel.Mesh.Test {
    public class Directories {




        /// <summary>
        /// Directory for test output data
        /// </summary>
        public static string Results = @"Results\";


        public static string TestKey_SSH2 => Path.Combine(TestEnvironmentCommon.CommonData, "TestKey_ssh2.pub");
        public static string TestKey_OpenSSH => Path.Combine(TestEnvironmentCommon.CommonData, "TestKey_OpenSSH.pub");
        public static string TestKey_OpenSSH_Private => Path.Combine(TestEnvironmentCommon.CommonData, "TestKey_OpenSSH.prv");
        public static string TestKey_PuTTY_Private => Path.Combine(TestEnvironmentCommon.CommonData, "TestKey_PuTTY.ppk");
        public static string TestKey_Bitvise_Private => Path.Combine(TestEnvironmentCommon.CommonData, "TestKey_Bitvise.bkp");


        public static string TestKey_Alice_Sign => Path.Combine(TestEnvironmentCommon.CommonData, "TestKey_RSA_Alice.prv");
        public static string TestKey_Bob_Encrypt => Path.Combine(TestEnvironmentCommon.CommonData, "TestKey_RSA_Bob.prv");




        }
    }
