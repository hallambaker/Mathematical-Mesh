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

using System;
using System.Collections.Generic;
using System.IO;

using Goedel.Cryptography;
using Goedel.Cryptography.Core;
using Goedel.Cryptography.Dare;
using Goedel.IO;
using Goedel.Mesh.Client;
using Goedel.Protocol.Presentation;
using Goedel.Test;
using Goedel.Test.Core;

namespace Goedel.Mesh.Test;


//public class MeshMachineTestWeb : MeshMachineTest {
//    public MeshMachineTestWeb(TestEnvironmentCommon testEnvironmentPerTest, string name = "Test") :
//        base(testEnvironmentPerTest, name) {
//        }

//    }


/// <summary>
/// Test machine. The cryptographic keys and persistence stores are only 
/// stored as in-memory structures and never written to disk.
/// </summary>
public class MeshMachineTest : MeshMachineCore {

    public List<Trace> MeshProtocolMessages = new();

    //    {
    //    get {
    //        Screen.WriteLine($"GET MeshProtocolMessages { meshProtocolMessages.GetHashCode()}" );
    //        return meshProtocolMessages;
    //        }
    //    set {
    //        meshProtocolMessages = value;
    //        Screen.WriteLine($"SET MeshProtocolMessages { meshProtocolMessages.GetHashCode()}");

    //        }
    //    }
    //List<Trace> meshProtocolMessages;


    TestEnvironmentCommon testEnvironmentCommon;

    public string Name;
    public string Path => System.IO.Path.Combine(testEnvironmentCommon.Path, Name);




    ///<inheritdoc/>
    public override string GetFilePath(string filepath) => (filepath == null) ? null :
        System.IO.Path.IsPathRooted(filepath) ? filepath : System.IO.Path.Combine(Path, filepath);


    ///<inheritdoc/>
    public override MeshServiceClient GetMeshClient(
                ICredentialPrivate credential,
                string service,
                string accountAddress) => // Pass through to the test environment.
        testEnvironmentCommon.GetMeshClient(this, credential, service, accountAddress);


    public static Contact ContactAlice = new ContactPerson(
        "Alice", "Aardvark", email: "alice@example.com");

    public static Contact ContactBob = new ContactPerson(
        "Bob", "Baker", email: "bob@example.com");



    // Convenience routines 


    public ContextMeshPreconfigured Install(string filename) {
        var machine = new MeshMachineTest(testEnvironmentCommon, DirectoryMaster);
        return machine.MeshHost.Install(filename);
        }

    public ContextUser GetContextAccount(string localName = null, string accountName = null) {
        var machine = new MeshMachineTest(testEnvironmentCommon, DirectoryMaster);
        return machine.MeshHost.GetContextMesh(localName) as ContextUser;
        }


    public static ContextUser GenerateAccountUser(
                TestEnvironmentCommon testEnvironmentCommon,
                string machineName,
                string accountAddress,
                string localName = null) {

        var result = new MeshMachineTest(testEnvironmentCommon, machineName);
        var contextUser = result.MeshHost.ConfigureMesh(accountAddress, localName);
        return contextUser;
        }


    public static ContextUser RefetchContextUser(ContextUser contextUser) {
        var host = contextUser.MeshHost;
        var catalogedMachine = contextUser.CatalogedMachine;

        host.Deregister(contextUser);
        return host.GetContext(catalogedMachine) as ContextUser;
        }


    public override string ToString() => $"TestMachine:{Name}";


    public static ContextMeshPending Connect(
        TestEnvironmentCommon testEnvironmentCommon,
        string machineName,
        string accountId,
        string localName = null,
        string PIN = null,
        string connectUri = null) {

        var machine = new MeshMachineTest(testEnvironmentCommon, machineName);
        return machine.MeshHost.Connect(accountId, localName, pin: PIN);
        }


    Dictionary<string, KeyPair> dictionaryKeyPairByUDF = new();



    public override IKeyCollection GetKeyCollection() => new KeyCollectionTest(this);


    public MeshMachineTest(TestEnvironmentCommon testEnvironmentPerTest, string name = "Test") :
                base(testEnvironmentPerTest.MachinePath(name)) {
        Name = name;
        testEnvironmentCommon = testEnvironmentPerTest;
        }

    //public MeshMachineTest(MeshMachineTest existing) :
    //    base(existing.DirectoryMaster) =>
    //    testEnvironmentCommon = existing.testEnvironmentCommon;


    public void Persist(KeyPair keyPair) {
        dictionaryKeyPairByUDF.Remove(keyPair.KeyIdentifier);
        dictionaryKeyPairByUDF.Add(keyPair.KeyIdentifier, keyPair);
        }


    public KeyPair GetPrivate(string UDF) {
        dictionaryKeyPairByUDF.TryGetValue(UDF, out var Result);
        return Result;
        }

    long checkLength = 0;
    public void CheckHostCatalogExtended() {
        var filename = FileNameHost;

        using var stream = filename.OpenFileReadShared();

        Console.WriteLine($"Stream {stream.Length}");

        (stream.Length > checkLength).TestTrue();
        checkLength = stream.Length;

        return;
        }



    }


public class KeyCollectionTest : KeyCollectionCore {
    MeshMachineTest meshMachine;

    public override string DirectoryKeys => meshMachine.DirectoryKeys;


    public KeyCollectionTest(MeshMachineTest meshMachine) => this.meshMachine = meshMachine;



    }


public class KeyCollectionTestEnv : KeyCollectionCore {
    string path;

    public override string DirectoryKeys => Path.Combine(path, "Keys");


    public KeyCollectionTestEnv(string path) => this.path = path;



    }
