using System;
using System.Threading;
using System.Collections.Generic;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Core;
using Goedel.Cryptography.Dare;
using Goedel.Test.Core;
using Goedel.Utilities;
using Goedel.Cryptography.Algorithms;
using Goedel.Mesh.Test;
using Xunit;

namespace Goedel.XUnit {
    public class TestLifecycle {
        KeyCollection KeyCollection;

        public MeshMachineTest MeshMachine;

        public static TestLifecycle Test() => new TestLifecycle();
        public TestLifecycle() {
            var testEnvironmentCommon = new TestEnvironmentCommon();

            MeshMachine = new MeshMachineTest(testEnvironmentCommon);
            KeyCollection = new KeyCollectionTest(MeshMachine);
            }

        [Theory]
        [InlineData(CryptoAlgorithmID.RSAExch)]
        [InlineData(CryptoAlgorithmID.RSASign)]
        [InlineData(CryptoAlgorithmID.DH)]
        [InlineData(CryptoAlgorithmID.Ed25519)]
        [InlineData(CryptoAlgorithmID.Ed448)]
        //[InlineData(CryptoAlgorithmID.X25519)]
        //[InlineData(CryptoAlgorithmID.X448)]
        public void Test_LifecycleMaster(CryptoAlgorithmID CryptoAlgorithmID, int KeySize = 2048) =>
            Crypto.Test_LifecycleMaster(CryptoAlgorithmID, KeyCollection, KeySize);

        [Theory]
        [InlineData(CryptoAlgorithmID.RSAExch)]
        [InlineData(CryptoAlgorithmID.RSASign)]
        [InlineData(CryptoAlgorithmID.DH)]
        [InlineData(CryptoAlgorithmID.Ed25519)]
        [InlineData(CryptoAlgorithmID.Ed448)]
        //[InlineData(CryptoAlgorithmID.X25519)]
        //[InlineData(CryptoAlgorithmID.X448)]
        public void Test_LifecycleAdmin(CryptoAlgorithmID CryptoAlgorithmID, int KeySize = 2048) =>
            Crypto.Test_LifecycleAdmin(CryptoAlgorithmID, KeyCollection, KeySize);

                [Theory]
        [InlineData(CryptoAlgorithmID.RSAExch)]
        [InlineData(CryptoAlgorithmID.RSASign)]
        [InlineData(CryptoAlgorithmID.DH)]
        [InlineData(CryptoAlgorithmID.Ed25519)]
        [InlineData(CryptoAlgorithmID.Ed448)]
        //[InlineData(CryptoAlgorithmID.X25519)]
        //[InlineData(CryptoAlgorithmID.X448)]
        public void Test_LifecycleDevice(CryptoAlgorithmID CryptoAlgorithmID, int KeySize = 2048) =>
            Crypto.Test_LifecycleDevice(CryptoAlgorithmID, KeyCollection, KeySize);


        [Theory]
        [InlineData(CryptoAlgorithmID.RSAExch)]
        [InlineData(CryptoAlgorithmID.RSASign)]
        [InlineData(CryptoAlgorithmID.DH)]
        [InlineData(CryptoAlgorithmID.Ed25519)]
        [InlineData(CryptoAlgorithmID.Ed448)]
        //[InlineData(CryptoAlgorithmID.X25519)]
        //[InlineData(CryptoAlgorithmID.X448)]
        public void Test_LifecycleEphemeral(CryptoAlgorithmID CryptoAlgorithmID, int KeySize = 2048) =>
            Crypto.Test_LifecycleEphemeral(CryptoAlgorithmID, KeyCollection, KeySize);

        [Theory]
        [InlineData(CryptoAlgorithmID.RSAExch)]
        [InlineData(CryptoAlgorithmID.RSASign)]
        [InlineData(CryptoAlgorithmID.DH)]
        [InlineData(CryptoAlgorithmID.Ed25519)]
        [InlineData(CryptoAlgorithmID.Ed448)]
        //[InlineData(CryptoAlgorithmID.X25519)]
        //[InlineData(CryptoAlgorithmID.X448)]
        public void Test_LifecycleExportable(CryptoAlgorithmID CryptoAlgorithmID, int KeySize = 2048) =>
            Crypto.Test_LifecycleExportable(CryptoAlgorithmID, KeyCollection, KeySize);


        }
    }
