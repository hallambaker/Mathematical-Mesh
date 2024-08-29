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

using Goedel.Mesh;

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


    [Theory]
    [InlineData(10, 5, true)]
    public void TestAppendDirect(
        int batches = 10,
        int items = 5,
        bool direct = true) {

        // Create store
        var directory = TestEnvironment.DirectoryPath;
        var filename = DeterministicSeed.GetUnique(batches, items, direct);
        var signingKey = KeyPair.Factory(CryptoAlgorithmId.Ed448, KeySecurity.Exportable, KeyCollection);

        var store = new SpoolOutbound(directory, filename, create: true);


        var count = 0;
        // loop
        for (var batch = 0; batch < batches; batch++) {

            var spoolEntry = store.SpoolIndexEntryLast;
            for (var item = 0; item < items; item++) {
                var message = MakeMessage($"{filename} {count++}", signingKey);

                if (direct) {
                    store.AppendDirect(message, true);
                    }
                else {
                    store.AppendDirect(message);
                    }
                }

            var i = 0;
            foreach (var envelope in store.Select(1)) {
                i++;
                }
            //Console.WriteLine($"Got {i}/{count}");


            var j = 0;
            foreach (var entry in store.GetMessages(start: spoolEntry.Next(), reverse: false)) {
                j++;
                //Console.WriteLine($"Got {j}/{items} ${entry.Index}");
                }

            (i == count).TestTrue();
            }





        // append element

        // enumerate over store



        }




    [Fact]
    public void TestSpoolSingle() {
        var message_id = Udf.Nonce();

        var directory = TestEnvironment.DirectoryPath;
        var file = "TestSpoolSingle";

        var signingKey = KeyPair.Factory(CryptoAlgorithmId.Ed448, KeySecurity.Exportable,
            KeyCollection);
        var message = MakeMessage(message_id, signingKey);

        // create spool
        var spool = new Spool(directory, file, keyCollection: KeyCollection);
        var envelope_id = message.EnvelopeId;

        CheckEntry(directory, file, spool, message_id).TestNull();

        // add element
        var entry1 = spool.AppendDirect(message);

        var entry = CheckEntry(directory, file, spool, message_id);
        entry.TestNotNull();
        entry.IsOpen.TestTrue();

        // mark element closed
        SetStatus(spool, message_id, StateSpoolMessage.Closed, signingKey);

        var entry2 = CheckEntry(directory, file, spool, message_id);
        entry2.TestNotNull();
        entry2.IsOpen.TestFalse();

        // mark element open (again)
        SetStatus(spool, message_id, StateSpoolMessage.Initial, signingKey);

        var entry3 = CheckEntry(directory, file, spool, message_id);
        entry3.TestNotNull();
        entry3.IsOpen.TestTrue();


        }

    static DareEnvelope MakeMessage(string id, KeyPair signingKey = null) {
        var message = new Message() {
            Sender = id,
            MessageId = id
            };
        return message.Envelope(signingKey);
        }

    static MessageComplete SetStatus(Spool spool, string id, StateSpoolMessage messageStatus, KeyPair signingKey) {

        var message = new MessageComplete() {

            References = new List<Reference> {
                    new Reference () {
                        MessageId = id,
                        MessageStatus = messageStatus
                        }
                    }
            };
        var envelope = message.Envelope(signingKey);
        spool.AppendDirect(envelope);

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
    SpoolIndexEntry CheckEntry(string directory, string file, Spool spool, string id) {
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

        var directory = TestEnvironment.DirectoryPath;
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
