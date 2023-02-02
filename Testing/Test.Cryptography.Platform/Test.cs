using Goedel.Cryptography;
using Goedel.Mesh.Test;
using Goedel.Utilities;

namespace Goedel.XUnit;

public partial class TestPlatform {

    public TestEnvironmentCommon TestEnvironment => testEnvironment ??
    new TestEnvironmentCommon().CacheValue(out testEnvironment);
    TestEnvironmentCommon testEnvironment;

    public MeshMachineTest MeshMachineTest => meshMachineTest ??
            new MeshMachineTest(TestEnvironment, "SpoolTest").CacheValue(out meshMachineTest);
    MeshMachineTest meshMachineTest;


    //public readonly KeyCollection KeyCollection;

    //public MeshMachineTest MeshMachine;

    public static TestPlatform Test() => new();
    public TestPlatform() {
        //var testEnvironmentCommon = new TestEnvironmentCommon();

        //MeshMachine = new MeshMachineTest(testEnvironmentCommon);
        //KeyCollection = new KeyCollectionTest(MeshMachine);
        }
    }
