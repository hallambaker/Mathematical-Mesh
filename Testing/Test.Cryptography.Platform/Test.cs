namespace Goedel.XUnit;

public partial class TestPlatform {

    public TestEnvironmentCommon TestEnvironment => testEnvironment ??
            new TestEnvironmentCommon().CacheValue(out testEnvironment);
    TestEnvironmentCommon testEnvironment;

    public MeshMachineTest MeshMachineTest => meshMachineTest ??
            new MeshMachineTest(TestEnvironment, "SpoolTest").CacheValue(out meshMachineTest);
    MeshMachineTest meshMachineTest;




    public static TestPlatform Test() => new();
    public TestPlatform() {

        }
    }
