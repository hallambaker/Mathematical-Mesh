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
using Goedel.Carnet.Server;
using Goedel.Discovery;

namespace Goedel.Mesh.Test;

/// <summary>
/// Test environment for one test with one service with one or more devices.
/// </summary>
public abstract class TestEnvironmentBase : Disposable {
    public MeshTestSet TestSet { get; }

    public DeterministicSeed Seed => TestSet.Seed;

    public DnsClient DnsClient => TestSet.DnsClient;
    public EarlClient EarlClient => TestSet.EarlClient;
    public EarlDispatch EarlDispatch => TestSet.EarlPublisher;


    public virtual string ServiceDns => "example.com";

    public static readonly string TestPath = "TestPath";


    public static string TestRoot => DeterministicSeed.TestRoot;

    public string Test => Seed.Seed;
    public static string CommonData => System.IO.Path.Combine(TestRoot, "CommonData");
    public string WorkingDirectory => System.IO.Path.Combine(DirectoryPath, "Working");

    public string DirectoryPath => Seed.Directory;


    public JpcConnection JpcConnection = JpcConnection.Serialized;

    public List<TestCLI> testCLIs = new();

    public Enveloped<ProfileAccount> EnvelopedProfileRegistry { get; set; }



    protected override void Disposing() {
        foreach (var test in testCLIs) {
            test.Shell.MeshHost.Dispose();
            //test.Dispose();
            }
        base.Disposing();
        }


    public virtual void StartService() {
        }


    protected virtual PublicCallsignResolver GetCallsignResolver() => throw new NYI();

    protected virtual CarnetServer GetCarnetServer() => throw new NYI();

    public DummyDnsService DummyDnsService { get; }

    public TestCLI GetTestCLI(string machineName = null) {
        var testShell = new TestShell(this, machineName) {
            NoCatch = true
            };
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

    public TestEnvironmentBase(MeshTestSet testSet) {
        TestSet = testSet;
        //seed ??= DeterministicSeed.Auto();
        if (DirectoryPath is null) {
            return;
            }

        DirectoryPath.DirectoryDelete();

        Directory.CreateDirectory(DirectoryPath);
        Directory.CreateDirectory(WorkingDirectory);
        Directory.SetCurrentDirectory(WorkingDirectory);
        }


    public MeshMachineTest GetMeshMachine(string device) => new(this, device);

    public string MachinePath(string machineName) => Path.Combine(DirectoryPath, machineName);


    public KeyCollection MakeKeyCollection(DeterministicSeed seed) {
        return new KeyCollectionTestEnv(DirectoryPath);
        }


    public CryptoParameters MakeCrypto(DeterministicSeed seed,
            CryptoAlgorithmId signId = CryptoAlgorithmId.NULL,
            CryptoAlgorithmId encryptId = CryptoAlgorithmId.NULL) =>
                MakeCrypto(seed, out _, out _, signId, encryptId);

    public CryptoParameters MakeCrypto(DeterministicSeed seed,
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

        return new CryptoParameters(keyCollection, signer: signKey, recipient: encryptKey);
        }


    public DarePolicy MakePolicy(DeterministicSeed seed,
            CryptoAlgorithmId signId = CryptoAlgorithmId.NULL,
            CryptoAlgorithmId encryptId = CryptoAlgorithmId.NULL) =>
        MakePolicy(seed, out _, out _, signId, encryptId);

    public DarePolicy MakePolicy(DeterministicSeed seed,
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
