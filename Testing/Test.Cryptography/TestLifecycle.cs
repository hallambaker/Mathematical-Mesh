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

namespace Goedel.XUnit;

public class TestLifecycle {


    public DeterministicSeed Seed => DeterministicSeed.Auto().CacheValue(out seed);
    DeterministicSeed seed;


    public TestEnvironmentCommon TestEnvironmentCommon => testEnvironmentCommon ??
        new TestEnvironmentCommon(Seed).CacheValue(out testEnvironmentCommon);
    TestEnvironmentCommon testEnvironmentCommon;


    KeyCollection KeyCollection => TestEnvironmentCommon.MakeKeyCollection(Seed);


    //public MeshMachineTest MeshMachine => meshMachine ?? 
    //        new MeshMachineTest(TestEnvironmentCommon).CacheValue(out meshMachine); 

    //MeshMachineTest meshMachine;


    public static TestLifecycle Test() => new();
    public TestLifecycle() {
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
        Crypto.Test_LifecycleMaster(CryptoAlgorithmID, KeyCollection, KeySize);

    [Theory]
    [InlineData(CryptoAlgorithmId.RSAExch)]
    [InlineData(CryptoAlgorithmId.RSASign)]
    [InlineData(CryptoAlgorithmId.DH)]
    [InlineData(CryptoAlgorithmId.Ed25519)]
    [InlineData(CryptoAlgorithmId.Ed448)]
    [InlineData(CryptoAlgorithmId.X25519)]
    [InlineData(CryptoAlgorithmId.X448)]
    public void Test_LifecycleAdmin(CryptoAlgorithmId CryptoAlgorithmID, int KeySize = 2048) =>
        Crypto.Test_LifecycleAdmin(CryptoAlgorithmID, KeyCollection, KeySize);

    [Theory]
    [InlineData(CryptoAlgorithmId.RSAExch)]
    [InlineData(CryptoAlgorithmId.RSASign)]
    [InlineData(CryptoAlgorithmId.DH)]
    [InlineData(CryptoAlgorithmId.Ed25519)]
    [InlineData(CryptoAlgorithmId.Ed448)]
    [InlineData(CryptoAlgorithmId.X25519)]
    [InlineData(CryptoAlgorithmId.X448)]
    public void Test_LifecycleDevice(CryptoAlgorithmId CryptoAlgorithmID, int KeySize = 2048) =>
Crypto.Test_LifecycleDevice(CryptoAlgorithmID, KeyCollection, KeySize);


    [Theory]
    [InlineData(CryptoAlgorithmId.RSAExch)]
    [InlineData(CryptoAlgorithmId.RSASign)]
    [InlineData(CryptoAlgorithmId.DH)]
    [InlineData(CryptoAlgorithmId.Ed25519)]
    [InlineData(CryptoAlgorithmId.Ed448)]
    [InlineData(CryptoAlgorithmId.X25519)]
    [InlineData(CryptoAlgorithmId.X448)]
    public void Test_LifecycleEphemeral(CryptoAlgorithmId CryptoAlgorithmID, int KeySize = 2048) =>
        Crypto.Test_LifecycleEphemeral(CryptoAlgorithmID, KeyCollection, KeySize);

    [Theory]
    [InlineData(CryptoAlgorithmId.RSAExch)]
    [InlineData(CryptoAlgorithmId.RSASign)]
    [InlineData(CryptoAlgorithmId.DH)]
    [InlineData(CryptoAlgorithmId.Ed25519)]
    [InlineData(CryptoAlgorithmId.Ed448)]
    [InlineData(CryptoAlgorithmId.X25519)]
    [InlineData(CryptoAlgorithmId.X448)]
    public void Test_LifecycleExportable(CryptoAlgorithmId CryptoAlgorithmID, int KeySize = 2048) =>
        Crypto.Test_LifecycleExportable(CryptoAlgorithmID, KeyCollection, KeySize);


    }
