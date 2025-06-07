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

namespace Goedel.XUnit;

public partial class TestContact : UnitTestSet {

    public static TestContact Test() => new();


    static TestContact() {
        Goedel.Cryptography.Core.Initialization.Initialized.TestTrue();
        Goedel.Contacts.Contacts._Initialized.TestTrue();

        // Bind to the test handle resolver
        }

    public virtual TestEnvironmentCommon GetTestEnvironmentCommon(DeterministicSeed seed = null) =>
            new(seed ?? Seed);

    [Fact]
    public void ContactSelf() {
        // Create an account for alice

        var testEnvironmentCommon = GetTestEnvironmentCommon();
        var contextAccountAlice = MakeAccount(testEnvironmentCommon, AccountAlice, DeviceAliceAdmin);

        // Get JSContact for Alice
        contextAccountAlice.TryGetContactSelf(out var contactSelf);
        }

    [Fact]
    public void ContactOther() {

        var testEnvironmentCommon = GetTestEnvironmentCommon();
        var contextAccountAlice = MakeAccount(testEnvironmentCommon, AccountAlice, DeviceAliceAdmin);
        var contextAccountBob = MakeAccount(testEnvironmentCommon, AccountBob, DeviceBobAdmin);

        TestExchange(contextAccountAlice, contextAccountBob);
        }

    [Fact]
    public void ContactHandle() {

        var testEnvironmentCommon = GetTestEnvironmentCommon();
        var contextAccountAlice = MakeAccount(testEnvironmentCommon, HandleAlice, DeviceAliceAdmin);
        var contextAccountBob = MakeAccount(testEnvironmentCommon, HandleBob, DeviceBobAdmin);

        TestExchange(contextAccountAlice, contextAccountBob);
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
