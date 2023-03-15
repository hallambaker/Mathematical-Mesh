#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion

using Goedel.Callsign.Resolver;

namespace Goedel.Mesh.Test;







public class TestEnvironmentCommon : TestEnvironmentBase {
    protected LogService Logger { get; set; }
    protected Configuration Configuration { get; set; }


    public string CallsignRegistry { get; set; }

    protected override void Disposing() {
        base.Disposing();
        MeshService.Dispose();
        }

    public virtual PublicMeshService MeshService => meshService ?? GetPublicMeshService().CacheValue(out meshService);
    PublicMeshService meshService;
    
    public virtual TestServiceRud TestServiceRud => testServiceRud ??
    new TestServiceRud(MeshService, null).CacheValue(out testServiceRud);
    TestServiceRud testServiceRud;

    public virtual PublicCallsignResolver Resolver => callsignResolver ??
                 GetCallsignResolver().CacheValue(out callsignResolver);
    PublicCallsignResolver callsignResolver;


    public IMeshMachineClient MeshMachineHost { get; set; }


    protected string HostFile = "whatev";
    public TestEnvironmentCommon(DeterministicSeed seed = null) : base (seed){

        }


    


    protected virtual PublicMeshService GetPublicMeshService() {
        // create the Mesh service

        //ServiceAdmin($"create example.com /host=host1.example.com /admin=alice.example.com /account=Domain\\user");
        // PublicMeshService.Create(MeshMachine, multiConfig, serviceDns, hostConfig, hostIp, hostDns, admin, runAs);


        MeshMachineHost = new MeshMachineTest(this, "host1");

        HostFile = System.IO.Path.Combine(MeshMachineHost.DirectoryMesh, "mmmconfiguration.json");
        Configuration = MeshMachineHost.CreatePublicMeshService( HostFile, ServiceDns);

        Logger = new LogService(Configuration.GenericHostConfiguration, Configuration.MeshServiceConfiguration, null);


        return new PublicMeshService(MeshMachineHost,
            Configuration.GenericHostConfiguration, Configuration.MeshServiceConfiguration, Logger);
        }

    protected virtual PublicCallsignResolver GetCallsignResolver() {
        _ = MeshService;


        var pathHost = System.IO.Path.Combine(
                MeshMachineHost.DirectoryMesh, CallsignResolver.__Tag) ; ;

        Configuration.CallsignResolverConfiguration = new CallsignResolverConfiguration() {
            Registry = CallsignRegistry,
            HostPath = pathHost
            };

        return PublicCallsignResolver.Create(MeshMachineHost,
                    Configuration.GenericHostConfiguration,
                    Configuration.CallsignResolverConfiguration,
                    Logger);


        //return new PublicCallsignResolver(MeshMachineHost,
        //    Configuration.GenericHostConfiguration, Configuration.CallsignResolverConfiguration, Logger);

        }




    //protected virtual 

    public override MeshServiceClient GetMeshClient(
        MeshMachineTest meshMachineTest,
        ICredentialPrivate credential,
        string accountAddress
        ) {

        JpcSession session = JpcConnection switch {
            JpcConnection.Direct => new JpcSessionDirect(MeshService, credential) {
                TargetAccount = accountAddress
                },
            JpcConnection.Serialized => new TestSession(MeshService, credential,
                    meshMachineTest.MeshProtocolMessages, meshMachineTest) {
                TargetAccount = accountAddress
                },
            JpcConnection.Rud => new TestSessionRud(TestServiceRud, credential,
                    meshMachineTest.MeshProtocolMessages, meshMachineTest) {
                TargetAccount = accountAddress
                },


            _ => throw new NYI()
            };

        return session.GetWebClient<MeshServiceClient>();
        }
    }



/// <summary>
/// Test environment for one test with one service with one or more devices.
/// </summary>
public abstract class TestEnvironmentBase : UnitTestSet {


    public virtual string ServiceDns => "example.com";

    public static readonly string TestPath = "TestPath";


    public static string TestRoot => DeterministicSeed.TestRoot;

    public string Test => Seed.Seed;
    public static string CommonData => System.IO.Path.Combine(TestRoot, "CommonData");
    public  string WorkingDirectory => System.IO.Path.Combine(DirectoryPath, "Working");

    public string DirectoryPath => Seed.Directory;
    //public virtual string ServiceDirectory => System.IO.Path.Combine(Path, "ServiceDirectory");



    public JpcConnection JpcConnection = JpcConnection.Serialized;

    public List<TestCLI> testCLIs = new();

    protected override void Disposing() {
        foreach (var test in testCLIs) {
            test.Shell.MeshHost.Dispose();
            //test.Dispose();
            }
        base.Disposing();
        }


    public virtual void StartService() {
        }



    public TestCLI GetTestCLI(string machineName = null) {
        var testShell = new TestShell(this, machineName) { 
            NoCatch=true};
        var result = new TestCLI(testShell);
        testCLIs.Add(result);
        return result;

        }

    public abstract MeshServiceClient GetMeshClient(
        MeshMachineTest meshMachineTest,
        ICredentialPrivate credential,
        string accountAddress);




    /// <summary>
    /// Perform initialization of the Goedel.Cryptography portable class
    /// with delegates to the .NET framework methods.
    /// </summary>
    /// <param name="testMode">If true, the application will be initialized in
    /// test/debug mode.</param>

    static TestEnvironmentBase() {
        }

    public TestEnvironmentBase(DeterministicSeed seed = null) {

        //seed ??= DeterministicSeed.Auto();
        Seed = seed ?? Seed;

        DirectoryPath.DirectoryDelete();

        Directory.CreateDirectory(DirectoryPath);
        Directory.CreateDirectory(WorkingDirectory);
        Directory.SetCurrentDirectory(WorkingDirectory);
        }


    public MeshMachineTest GetMeshMachine(string device) => new(this, device);

    public string MachinePath(string machineName) => Path.Combine(DirectoryPath, machineName);


    public static KeyCollection MakeKeyCollection(DeterministicSeed seed) {
        var testEnvironment = new TestEnvironmentCommon(seed);
        //var machineAdmin = new MeshMachineTest(TestEnvironment, "Test");
        return new KeyCollectionTestEnv(testEnvironment.DirectoryPath);
        }


    public static CryptoParameters MakeCrypto(DeterministicSeed seed,
            CryptoAlgorithmId signId = CryptoAlgorithmId.NULL,
            CryptoAlgorithmId encryptId = CryptoAlgorithmId.NULL) =>
                MakeCrypto(seed, out _, out _, signId, encryptId);

    public static CryptoParameters MakeCrypto(DeterministicSeed seed,
            out KeyPair signKey, out KeyPair encryptKey,
            CryptoAlgorithmId signId = CryptoAlgorithmId.NULL,
            CryptoAlgorithmId encryptId = CryptoAlgorithmId.NULL) {

        encryptKey = null;
        signKey = null;

        var keyCollection = MakeKeyCollection(seed);


        if (encryptId != CryptoAlgorithmId.NULL) {
            encryptKey = KeyPair.Factory(encryptId,
                    KeySecurity.Exportable, keyCollection, keyUses: KeyUses.Encrypt);
            }
        if (signId != CryptoAlgorithmId.NULL) {
            signKey = KeyPair.Factory(encryptId,
                    KeySecurity.Exportable, keyCollection, keyUses: KeyUses.Sign);
            }

        return new CryptoParameters(keyCollection, signer: signKey, recipient:encryptKey);
        }


    public static DarePolicy MakePolicy(DeterministicSeed seed,
            CryptoAlgorithmId signId = CryptoAlgorithmId.NULL,
            CryptoAlgorithmId encryptId = CryptoAlgorithmId.NULL) =>
        MakePolicy(seed, out _, out _, signId, encryptId);
    public static DarePolicy MakePolicy(DeterministicSeed seed,
        out KeyPair signKey, out KeyPair encryptKey,
        CryptoAlgorithmId signId = CryptoAlgorithmId.NULL,
        CryptoAlgorithmId encryptId = CryptoAlgorithmId.NULL) {

        encryptKey = null;
        signKey = null;

        var keyCollection = MakeKeyCollection(seed);


        if (encryptId != CryptoAlgorithmId.NULL) {
            encryptKey = KeyPair.Factory(encryptId,
                    KeySecurity.Exportable, keyCollection, keyUses: KeyUses.Encrypt);
            }
        if (signId != CryptoAlgorithmId.NULL) {
            signKey = KeyPair.Factory(encryptId,
                    KeySecurity.Exportable, keyCollection, keyUses: KeyUses.Sign);
            }

        return new DarePolicy(keyCollection, signKey, encryptKey);
        }


    }
