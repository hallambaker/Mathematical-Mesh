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

//#pragma warning disable IDE0059
//#pragma warning disable CA1822

using Goedel.Contacts;
using Goedel.Discovery;
using Goedel.Mesh.Shell;
using Goedel.Utilities;

namespace Goedel.XUnit;

public partial class TestContact : UnitTestSet {

    public static TestContact Test() => new();


    static TestContact() {
        Goedel.Cryptography.Core.Initialization.Initialized.TestTrue();
        Goedel.Contacts.Contacts._Initialized.TestTrue();

        // Bind to the test handle resolver
        }

    public virtual TestEnvironmentCommon GetTestEnvironmentCommon(
                    DeterministicSeed seed = null,
                    bool dummyDns = false) =>
            new(seed ?? Seed, dummyDns: dummyDns);

    [Fact]
    public void ContactSelf() {
        // Create an account for alice

        var testEnvironmentCommon = GetTestEnvironmentCommon();
        var contextAccountAlice = MakeAccount(testEnvironmentCommon, AccountAlice, DeviceAliceAdmin);

        // Get JSContact for Alice
        contextAccountAlice.TryGetContactSelf(out var contactSelf);
        var contactAlice = contactSelf.JsContact;
        

        // Publish EARL of contact for self.
        var response = contextAccountAlice.PublishEarl(contactSelf.JsContact.GetBytes(false), MediaTypes.JSContactScheme,
                MediaTypes.JSContact).Sync();

        var earl = response.Earl;

        // attempt resolution through the JSContact earl - jscontact://example.com/....
        var contactAliceAtAlice = 
                EarlClient.ResolveEarl<JsContact>(earl).Sync();


        contactAlice.TestIsEqual(contactAliceAtAlice);


        // While we could repeat this testing for resolution by Bob, the test client
        // is the same so it is pointless.
        }


    [Fact]
    public void ContactHandle() {

        // Need to be able to publish the handle records...
        var testEnvironmentCommon = GetTestEnvironmentCommon(dummyDns : true);
        var contextAccountAlice = MakeAccount(testEnvironmentCommon, HandleAlice, DeviceAliceAdmin);
        var contextAccountBob = MakeAccount(testEnvironmentCommon, HandleBob, DeviceBobAdmin);

        // Get JSContact for Alice
        contextAccountAlice.TryGetContactSelf(out var contactSelf);
        var contactAlice = contactSelf.JsContact;

        // Publish EARL of contact for self and bind a handle
        var earl = contextAccountAlice.PublishEarl(contactAlice).Sync();
        contextAccountAlice.BindHandle(
            MediaTypes.JSContactPrefix, HandleAlice, MediaTypes.EarlTag, earl).Sync();


        // attempt resolution as @alice.example.com
        var contactAliceAtBob = EarlClient.ResolveContactHandle(HandleAlice).SyncNoCatch();
        contactAlice.TestIsEqual(contactAliceAtBob);

        DnsClient.Default = null;
        }










    private ContextUser MakeAccount(
                TestEnvironmentCommon testEnvironmentCommon,
                string accountId, string deviceId) {
        var contextAccount = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                deviceId, accountId, "main");


        // Get JSContact for Alice
        contextAccount.TryGetContactSelf(out var contactAlice);
        return contextAccount;
        }


    private bool TestExchange(ContextUser contextAccountAlice, ContextUser contextAccountBob) {

        // Get JSContact for Alice
        contextAccountBob.TryGetContactSelf(out var contactBob);

        contextAccountAlice.AddContact(contactBob);

        // check contact is the same when fetched
        var contactBob2 = contextAccountAlice.GetContact(AccountBob);
        (contactBob2 == contactBob).TestTrue();


        // Alice create message to send to Bob
        throw new NYI();


        // Bob Authenticate message

        return true;
        }





    }
