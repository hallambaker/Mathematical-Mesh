using System.IO;
using Goedel.Mesh.Shell;
using Goedel.Cryptography;
using MT=Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Test;

namespace Goedel.Catalog.Test {
    [MT.TestClass]
    public partial class CatalogTests {
        static string ResultDirectory;
        static string ContainerDirectory = "Shells";

        const string DirectorySource = "Files";
        const string DirectoryEncrypted = "Encrypted";
        const string DirectoryDecrypted = "Decrypted";

        const string DirectoryTarget = "Target";
        string Target(string File) => DirectoryTarget + @"\" + File;

        const string DirectoryArchive = "Archive";
        const string DirectoryArchiveCopy = "ArchiveCopy";
        string Archive(string File) => DirectoryArchive + @"\" + File;

        const string FileTest1 = @"PHBLogo1.svg";
        const string FileTest2 = @"PHBLogo1.svg";
        const string FileTest3 = @"PHBLogo180.png";
        const string FileTest4 = @"PHBLogo256.ico";
        const string FileTest5 = @"PHBLogo256.png";

        /// <summary>
        /// 
        /// </summary>
        public static void TestDirect() {
            InitializeClass();
            var Instance = new CatalogTests();
            //Instance.TestBasicCalendar();
            //Instance.TestContainerSerial();
            Instance.TestContainerArchiveBase();
            //Instance.TestBasicBookMark();
            //Instance.TestBasicCredential();
            }

        static ShellDispatch ShellDispatchCommon;

        [MT.AssemblyInitialize]
        public static void InitializeClass(MT.TestContext Context) {
            ResultDirectory = Context.TestRunDirectory;
            Directory.SetCurrentDirectory(Directories.RunDirectoryFramework);
            
            InitializeClass();
            }

        public static void InitializeClass() {
            
            Directory.CreateDirectory(ContainerDirectory);
            Directory.CreateDirectory(DirectoryEncrypted);
            Directory.CreateDirectory(DirectoryDecrypted);
            Directory.CreateDirectory(DirectoryTarget);
            Directory.CreateDirectory(DirectoryArchive);
            CryptographyWindows.Initialize();

            ShellDispatchCommon = GetShell("TestFile.dcon");
            // OK so here create ourselves a set of test keys for encryption and signature


            }

        static ShellDispatch GetShell(string Filename) {
            Filename = ContainerDirectory + @"\" + Filename;

            File.Delete(Filename);
            return new ShellDispatch(Catalog: Filename);
            }
        }



    }
