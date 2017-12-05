using System;
using System.Collections.Generic;
using System.Diagnostics;
using Goedel.Utilities;
using Goedel.Test;
using Goedel.IO;
using Goedel.Cryptography;
using Goedel.Cryptography.KeyFile;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UT=Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test {
    [TestClass]
    public class UnitTest1 {

        [AssemblyInitialize]
        public static void Initialize (TestContext Context) {
            Goedel.IO.Debug.Initialize();
            CryptographyFramework.Initialize();
            }

        [AssemblyCleanup]
        public static void Cleanup() {
            }

        [TestMethod]
        public void TestKeyRead () {

            var SSH_Public = KeyFileDecode.DecodePEM(Directories.TestKey_SSH2);
            var SSH_AuthHosts = KeyFileDecode.DecodeAuthHost(Directories.TestKey_OpenSSH);
            var SSH_Private = KeyFileDecode.DecodePEM(Directories.TestKey_OpenSSH_Private);

            UT.Assert.AreEqual(SSH_Public.UDF, SSH_Private.UDF);
            UT.Assert.AreEqual(SSH_AuthHosts[0].SSHData.KeyPair.UDF, SSH_Private.UDF);

            }
        [TestMethod]
        public void TestWritePEMRSA() {
            var SignerKeyPair = KeyFileDecode.DecodePEM(Directories.TestKey_OpenSSH_Private);
            var OutFile = Directories.Results + "TestWritePEMRSA.prv";
            var DataString = SignerKeyPair.ToPEMPrivate();
            OutFile.WriteFileNew(DataString);

            }
        // TEST: Write File SSH Public RSA
        // TEST: Write File PEM Putty RSA
        // TEST: Write File PEM SSH RSA
        }
    }
