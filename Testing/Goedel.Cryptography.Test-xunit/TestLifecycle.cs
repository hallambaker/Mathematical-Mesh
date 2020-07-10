using Goedel.Cryptography;
using Goedel.Mesh.Test;
using Goedel.Test.Core;

using Xunit;

namespace Goedel.XUnit {
    public class TestLifecycle {
        keyCollection KeyCollection;

        public MeshMachineTest MeshMachine;

        public static TestLifecycle Test() => new TestLifecycle();
        public TestLifecycle() {
            var testEnvironmentCommon = new TestEnvironmentCommon();

            MeshMachine = new MeshMachineTest(testEnvironmentCommon);
            KeyCollection = new KeyCollectionTest(MeshMachine);
            }

        [Theory]
        [InlineData(CryptoAlgorithmId.RSAExch)]
        [InlineData(CryptoAlgorithmId.RSASign)]
        [InlineData(CryptoAlgorithmId.DH)]
        [InlineData(CryptoAlgorithmId.Ed25519)]
        [InlineData(CryptoAlgorithmId.Ed448)]
        //[InlineData(CryptoAlgorithmID.X25519)]
        //[InlineData(CryptoAlgorithmID.X448)]
        public void Test_LifecycleMaster(CryptoAlgorithmId CryptoAlgorithmID, int KeySize = 2048) =>
            Crypto.Test_LifecycleMaster(CryptoAlgorithmID, KeyCollection, KeySize);

        [Theory]
        [InlineData(CryptoAlgorithmId.RSAExch)]
        [InlineData(CryptoAlgorithmId.RSASign)]
        [InlineData(CryptoAlgorithmId.DH)]
        [InlineData(CryptoAlgorithmId.Ed25519)]
        [InlineData(CryptoAlgorithmId.Ed448)]
        //[InlineData(CryptoAlgorithmID.X25519)]
        //[InlineData(CryptoAlgorithmID.X448)]
        public void Test_LifecycleAdmin(CryptoAlgorithmId CryptoAlgorithmID, int KeySize = 2048) =>
            Crypto.Test_LifecycleAdmin(CryptoAlgorithmID, KeyCollection, KeySize);

        [Theory]
        [InlineData(CryptoAlgorithmId.RSAExch)]
        [InlineData(CryptoAlgorithmId.RSASign)]
        [InlineData(CryptoAlgorithmId.DH)]
        [InlineData(CryptoAlgorithmId.Ed25519)]
        [InlineData(CryptoAlgorithmId.Ed448)]
        //[InlineData(CryptoAlgorithmID.X25519)]
        //[InlineData(CryptoAlgorithmID.X448)]
        public void Test_LifecycleDevice(CryptoAlgorithmId CryptoAlgorithmID, int KeySize = 2048) =>
    Crypto.Test_LifecycleDevice(CryptoAlgorithmID, KeyCollection, KeySize);


        [Theory]
        [InlineData(CryptoAlgorithmId.RSAExch)]
        [InlineData(CryptoAlgorithmId.RSASign)]
        [InlineData(CryptoAlgorithmId.DH)]
        [InlineData(CryptoAlgorithmId.Ed25519)]
        [InlineData(CryptoAlgorithmId.Ed448)]
        //[InlineData(CryptoAlgorithmID.X25519)]
        //[InlineData(CryptoAlgorithmID.X448)]
        public void Test_LifecycleEphemeral(CryptoAlgorithmId CryptoAlgorithmID, int KeySize = 2048) =>
            Crypto.Test_LifecycleEphemeral(CryptoAlgorithmID, KeyCollection, KeySize);

        [Theory]
        [InlineData(CryptoAlgorithmId.RSAExch)]
        [InlineData(CryptoAlgorithmId.RSASign)]
        [InlineData(CryptoAlgorithmId.DH)]
        [InlineData(CryptoAlgorithmId.Ed25519)]
        [InlineData(CryptoAlgorithmId.Ed448)]
        //[InlineData(CryptoAlgorithmID.X25519)]
        //[InlineData(CryptoAlgorithmID.X448)]
        public void Test_LifecycleExportable(CryptoAlgorithmId CryptoAlgorithmID, int KeySize = 2048) =>
            Crypto.Test_LifecycleExportable(CryptoAlgorithmID, KeyCollection, KeySize);


        }
    }
