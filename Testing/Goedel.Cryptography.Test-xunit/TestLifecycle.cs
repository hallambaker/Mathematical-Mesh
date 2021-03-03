using Goedel.Cryptography;
using Goedel.Mesh.Test;
using Goedel.Test.Core;

using Xunit;

namespace Goedel.XUnit {
    public class TestLifecycle {
        KeyCollection keyCollection;

        public MeshMachineTest MeshMachine;

        public static TestLifecycle Test() => new TestLifecycle();
        public TestLifecycle() {
            var testEnvironmentCommon = new TestEnvironmentCommon();

            MeshMachine = new MeshMachineTest(testEnvironmentCommon);
            keyCollection = new KeyCollectionTest(MeshMachine);
            }

        [Theory]
        [InlineData(CryptoAlgorithmId.RSAExch)]
        [InlineData(CryptoAlgorithmId.RSASign)]
        [InlineData(CryptoAlgorithmId.DH)]
        [InlineData(CryptoAlgorithmId.Ed25519)]
        [InlineData(CryptoAlgorithmId.Ed448)]
        [InlineData(CryptoAlgorithmId.X25519)]
        [InlineData(CryptoAlgorithmId.X448)]
        public void Test_LifecycleMaster(CryptoAlgorithmId CryptoAlgorithmID, int KeySize = 2048) =>
            Crypto.Test_LifecycleMaster(CryptoAlgorithmID, keyCollection, KeySize);

        [Theory]
        [InlineData(CryptoAlgorithmId.RSAExch)]
        [InlineData(CryptoAlgorithmId.RSASign)]
        [InlineData(CryptoAlgorithmId.DH)]
        [InlineData(CryptoAlgorithmId.Ed25519)]
        [InlineData(CryptoAlgorithmId.Ed448)]
        [InlineData(CryptoAlgorithmId.X25519)]
        [InlineData(CryptoAlgorithmId.X448)]
        public void Test_LifecycleAdmin(CryptoAlgorithmId CryptoAlgorithmID, int KeySize = 2048) =>
            Crypto.Test_LifecycleAdmin(CryptoAlgorithmID, keyCollection, KeySize);

        [Theory]
        [InlineData(CryptoAlgorithmId.RSAExch)]
        [InlineData(CryptoAlgorithmId.RSASign)]
        [InlineData(CryptoAlgorithmId.DH)]
        [InlineData(CryptoAlgorithmId.Ed25519)]
        [InlineData(CryptoAlgorithmId.Ed448)]
        [InlineData(CryptoAlgorithmId.X25519)]
        [InlineData(CryptoAlgorithmId.X448)]
        public void Test_LifecycleDevice(CryptoAlgorithmId CryptoAlgorithmID, int KeySize = 2048) =>
    Crypto.Test_LifecycleDevice(CryptoAlgorithmID, keyCollection, KeySize);


        [Theory]
        [InlineData(CryptoAlgorithmId.RSAExch)]
        [InlineData(CryptoAlgorithmId.RSASign)]
        [InlineData(CryptoAlgorithmId.DH)]
        [InlineData(CryptoAlgorithmId.Ed25519)]
        [InlineData(CryptoAlgorithmId.Ed448)]
        [InlineData(CryptoAlgorithmId.X25519)]
        [InlineData(CryptoAlgorithmId.X448)]
        public void Test_LifecycleEphemeral(CryptoAlgorithmId CryptoAlgorithmID, int KeySize = 2048) =>
            Crypto.Test_LifecycleEphemeral(CryptoAlgorithmID, keyCollection, KeySize);

        [Theory]
        [InlineData(CryptoAlgorithmId.RSAExch)]
        [InlineData(CryptoAlgorithmId.RSASign)]
        [InlineData(CryptoAlgorithmId.DH)]
        [InlineData(CryptoAlgorithmId.Ed25519)]
        [InlineData(CryptoAlgorithmId.Ed448)]
        [InlineData(CryptoAlgorithmId.X25519)]
        [InlineData(CryptoAlgorithmId.X448)]
        public void Test_LifecycleExportable(CryptoAlgorithmId CryptoAlgorithmID, int KeySize = 2048) =>
            Crypto.Test_LifecycleExportable(CryptoAlgorithmID, keyCollection, KeySize);


        }
    }
