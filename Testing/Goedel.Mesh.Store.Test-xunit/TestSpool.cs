#region // Copyright - MIT License
//  � 2021 by Phill Hallam-Baker
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

using System.Collections.Generic;

using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Mesh;
using Goedel.Mesh.Test;
using Goedel.Test;
using Goedel.Utilities;

using Xunit;

namespace Goedel.XUnit;

public partial class StoreTests {
    ///<summary>The test environment, base for all </summary>
    public TestEnvironmentCommon TestEnvironment => testEnvironment ??
        new TestEnvironmentCommon().CacheValue(out testEnvironment);
    TestEnvironmentCommon testEnvironment;

    public MeshMachineTest MeshMachineTest => meshMachineTest ??
            new MeshMachineTest(TestEnvironment, "SpoolTest").CacheValue(out meshMachineTest);
    MeshMachineTest meshMachineTest;

    public IKeyCollection KeyCollection => keyCollection ??
        MeshMachineTest.GetKeyCollection().CacheValue(out keyCollection);
    IKeyCollection keyCollection;

    static StoreTests() {
        }

    public static StoreTests Test() => new();


    [Fact]
    public void TestSpoolSingle() {
        var id = UDF.Nonce();

        var directory = TestEnvironment.Path;
        var file = "TestSpoolSingle";

        var signingKey = KeyPair.Factory(CryptoAlgorithmId.Ed448, KeySecurity.Exportable,
            KeyCollection);


        // create spool
        var spool = new Spool(directory, file, keyCollection: KeyCollection);


        CheckEntry(directory, file, spool, id).TestNull();

        // add element
        var entry1 = spool.Add(MakeMessage(id, signingKey));

        var entry = CheckEntry(directory, file, spool, id);
        entry.TestNotNull();
        entry.Open.TestTrue();
        entry.Closed.TestFalse();

        // mark element closed
        SetStatus(spool, id, MessageStatus.Closed, signingKey);

        var entry2 = CheckEntry(directory, file, spool, id);
        entry2.TestNotNull();
        entry2.Closed.TestTrue();
        entry2.Open.TestFalse();

        // mark element open (again)
        SetStatus(spool, id, MessageStatus.Open, signingKey);

        var entry3 = CheckEntry(directory, file, spool, id);
        entry3.TestNotNull();
        entry3.Open.TestTrue();
        entry3.Closed.TestFalse();

        }

    static DareEnvelope MakeMessage(string id, KeyPair signingKey) {
        var message = new Message() {
            MessageId = id
            };
        return message.Envelope(signingKey);
        }

    static MessageComplete SetStatus(Spool spool, string id, MessageStatus messageStatus, KeyPair signingKey) {

        var message = new MessageComplete() {

            References = new List<Reference> {
                    new Reference () {
                        MessageId = id,
                        MessageStatus = messageStatus
                        }
                    }
            };
        var envelope = message.Envelope(signingKey);
        spool.Add(envelope);

        return message;
        }


    /// <summary>
    /// Check entry 
    /// </summary>
    /// <param name="directory"></param>
    /// <param name="file"></param>
    /// <param name="spool"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    SpoolEntry CheckEntry(string directory, string file, Spool spool, string id) {
        var spoolEntry = spool.GetByMessageId(id);


        using var spool2 = new Spool(directory, file, keyCollection: KeyCollection);
        var spoolEntry2 = spool.GetByMessageId(id);

        if (spoolEntry == null) {
            (spoolEntry2 == null).TestTrue();

            }
        else {
            (spoolEntry2 != null).TestTrue();
            (spoolEntry.MessageStatus == spoolEntry2.MessageStatus).TestTrue();
            }


        return spoolEntry;
        }


    [Fact]
    public void TestCatalog() {

        var directory = TestEnvironment.Path;
        var file = "TestCatalogSingle";

        var encryptionKey = KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Exportable,
            KeyCollection);

        var catalog = new CatalogContact(directory, file, keyCollection: KeyCollection);

        // Alice
        var contactAlice = new ContactPerson("Alice", "Example");
        var catalogedAlice = new CatalogedContact(contactAlice, false);

        catalog.New(catalogedAlice);

        // Bob
        var contactBob = new ContactPerson("Alice", "Example");
        var catalogedBob = new CatalogedContact(contactBob, false);

        catalog.New(catalogedBob);


        // try to read back.


        }


    }
