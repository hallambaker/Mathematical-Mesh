using System;
using System.IO;
using Goedel.Cryptography;
using Goedel.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Mesh.Test;

namespace Goedel.Mesh.Test_Windows {
    [TestClass]
    public class TestProfilesWindows {

        public static void TestDirect() {
            InitializeClass();
            TestProfiles.Test.GenerateMaster();
            }

        [AssemblyInitialize]
        public static void Initialize(TestContext Context) {
            Directory.SetCurrentDirectory(Directories.RunDirectory);
            InitializeClass();
            }

        public static void InitializeClass() {

            global::Goedel.IO.Debug.Initialize();
            CryptographyWindows.Initialize();

            }

        [TestMethod]
        public void GenerateMaster() => TestProfiles.Test.GenerateMaster();

        [TestMethod]
        public void GenerateDevice() => TestProfiles.Test.GenerateDevice();

        }
    }
