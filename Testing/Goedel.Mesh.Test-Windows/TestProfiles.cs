using System;
using System.IO;
using Goedel.Cryptography;
using Goedel.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Goedel.Mesh.Test_Windows {
    [TestClass]
    public class TestProfiles {

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
        public void GenerateMaster() => Goedel.Mesh.Test.TestProfiles.Test.GenerateMaster();

        [TestMethod]
        public void GenerateDevice() => Goedel.Mesh.Test.TestProfiles.Test.GenerateDevice();

        }
    }
