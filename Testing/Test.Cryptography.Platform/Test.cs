using Goedel.Cryptography;
using Goedel.Mesh.Test;


namespace Goedel.XUnit;

public partial class TestPlatform {
    public readonly KeyCollection KeyCollection;

    public MeshMachineTest MeshMachine;

    public static TestPlatform Test() => new();
    public TestPlatform() {
        var testEnvironmentCommon = new TestEnvironmentCommon();

        MeshMachine = new MeshMachineTest(testEnvironmentCommon);
        KeyCollection = new KeyCollectionTest(MeshMachine);
        }
    }
