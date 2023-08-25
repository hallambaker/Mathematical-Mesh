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

using System.Collections.Generic;
using Goedel.Cryptography;
using Goedel.Cryptography.KeyFile;
using Goedel.Mesh;
using Goedel.Mesh.Client;
using Goedel.Mesh.Test;
using Goedel.Test;
using Goedel.Test.Core;
using Xunit;

//#pragma warning disable CA1822

namespace Goedel.XUnit;

public partial class TestService {
    List<string> RightsDirect => new() { Rights.IdRolesWeb };
    List<string> RightsThreshold => new() { Rights.IdRolesThreshold };
    string TestFileText { get; } = "Test plaintext data";

    #region // Device access to account decryption key
    /// <summary>
    /// Connect a device by approving a request
    /// </summary>
    [Fact]
    public void MeshDeviceDirectKey() => MeshCheckAccountAuth(Rights.IdRolesWeb);

    /// <summary>
    /// Connect a device by approving a request
    /// </summary>
    [Fact]
    public void MeshDeviceThresholdKey() => MeshCheckAccountAuth(Rights.IdRolesThreshold);

    void MeshCheckAccountAuth(string role) {
        var rights = new List<string> { role };

        var testEnvironmentCommon = GetTestEnvironmentCommon();
        var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                DeviceAliceAdmin, AccountAlice, "main");

        // Encrypt file here
        var testFile = new TestFile(TestFileText);
        testFile.Encrypt(contextAccountAlice, AccountAlice, AccountAlice);
        testFile.Decrypt(contextAccountAlice.KeyCollection);

        // New Device
        var contextOnboardPending = MeshMachineTest.Connect(testEnvironmentCommon, DeviceAlice3,
                AccountAlice);

        // test decrypt - onbaording FAIL
        Xunit.Assert.Throws<NoAvailableDecryptionKey>(() =>
            testFile.Decrypt(contextOnboardPending.KeyCollection));

        // Admin Device
        contextAccountAlice.SynchronizeAsync().Sync();
        var connectRequest = contextAccountAlice.GetPendingMessageConnectionRequest();
        contextAccountAlice.ProcessAsync(connectRequest, roles: rights).Sync();

        // Check second device
        var contextOnboarded = TestCompletionSuccess(contextOnboardPending);

        // test decrypt, sync - onbaording Success

        contextOnboarded.SynchronizeAsync().Sync();

        var newContext = MeshMachineTest.RefetchContextUser(contextOnboarded);
        testFile.Decrypt(contextOnboarded);

        contextAccountAlice.DeleteDeviceAsync(contextOnboarded.CatalogedDevice.DeviceUdf).Sync();

        // test sync, decrypt - FAIL
        Xunit.Assert.Throws<ServerResponseInvalid>(() => newContext.SynchronizeAsync().Sync());

        if (role == Rights.IdRolesThreshold) {
            Xunit.Assert.Throws<CryptographicOperationRefused>(() => testFile.Decrypt(newContext.KeyCollection));

            }
        else {
            testFile.Decrypt(contextOnboarded.KeyCollection);
            }

        }
    #endregion
    #region // Device access to applications

    [Fact]
    public void MeshDeviceSsh() {
        var roles = new List<string> { Rights.IdRolesWeb };

        var testEnvironmentCommon = GetTestEnvironmentCommon();
        var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                DeviceAliceAdmin, AccountAlice, "main");

        // New Device
        var contextOnboardPending = MeshMachineTest.Connect(testEnvironmentCommon, DeviceAlice2, AccountAlice);

        // Admin Device
        contextAccountAlice.SynchronizeAsync().Sync();
        var connectRequest = contextAccountAlice.GetPendingMessageConnectionRequest();
        contextAccountAlice.ProcessAsync(connectRequest, roles: roles).Sync();

        // Check second device
        var contextOnboarded = TestCompletionSuccess(contextOnboardPending);
        ExerciseAccount(contextOnboarded);

        var id = "ssh";
        // Create an ssh application
        var applicationSSH = CatalogedApplicationSsh.Create(id, roles);

        var transaction1 = contextAccountAlice.TransactBegin();
        transaction1.ApplicationCreate(applicationSSH);
        var result1 = transaction1.TransactAsync().Sync();
        

        // Connect a third device
        var contextOnboardPending2 = MeshMachineTest.Connect(testEnvironmentCommon, DeviceAlice3, AccountAlice);

        // Admin Device
        contextAccountAlice.SynchronizeAsync().Sync();
        var connectRequest2 = contextAccountAlice.GetPendingMessageConnectionRequest();
        contextAccountAlice.ProcessAsync(connectRequest2, roles: roles).Sync();


        var contextOnboarded2 = TestCompletionSuccess(contextOnboardPending2);
        ExerciseAccount(contextOnboarded2);

        contextOnboarded.SynchronizeAsync().Sync();
        // this is likely failing because the updates are not being correctly 
        // processd on the cataloged devices...

        var applicationSsh1 = contextAccountAlice.GetApplicationSsh(id);
        var applicationEntrySsh1 = contextAccountAlice.GetApplicationEntrySsh(applicationSsh1.Key);
        var applicationSsh2 = contextOnboarded.GetApplicationSsh(id);
        var applicationEntrySsh2 = contextOnboarded.GetApplicationEntrySsh(applicationSsh2.Key);
        var applicationSsh3 = contextOnboarded2.GetApplicationSsh(id);
        var applicationEntrySsh3 = contextOnboarded2.GetApplicationEntrySsh(applicationSsh3.Key);
        // check applicationSsh1 == applicationSsh2
        // check we have a private key for each device.

        applicationSsh1.TestNotNull();
        applicationEntrySsh1.TestNotNull();
        applicationSsh2.TestNotNull();
        applicationEntrySsh2.TestNotNull();


        applicationSsh3.TestNotNull();
        applicationEntrySsh3.TestNotNull();

        CheckKeysMatch(applicationSsh1.ClientKey, applicationSsh2.ClientKey, applicationSsh3.ClientKey,
                applicationEntrySsh1.Activation.ClientKey, applicationEntrySsh2.Activation.ClientKey,
                applicationEntrySsh3.Activation.ClientKey);

        // Extract some files

        applicationSsh1.ClientKey.ToKeyFile("MeshDeviceSshPublic1", KeyFileFormat.OpenSSH);
        applicationSsh2.ClientKey.ToKeyFile("MeshDeviceSshPublic2", KeyFileFormat.OpenSSH);

        applicationEntrySsh1.Activation.ClientKey.ToKeyFile("MeshDeviceSshPrivate1", KeyFileFormat.PEMPrivate);
        applicationEntrySsh2.Activation.ClientKey.ToKeyFile("MeshDeviceSshPrivate2", KeyFileFormat.PEMPrivate);

        }


    [Fact]
    public void MeshDeviceMail() {
        var roles = new List<string> { Rights.IdRolesWeb };

        var testEnvironmentCommon = GetTestEnvironmentCommon();
        var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                DeviceAliceAdmin, AccountAlice, "main");

        // New Device
        var contextOnboardPending = MeshMachineTest.Connect(testEnvironmentCommon, DeviceAlice2, AccountAlice);

        // Admin Device
        contextAccountAlice.SynchronizeAsync().Sync();
        var connectRequest = contextAccountAlice.GetPendingMessageConnectionRequest();
        contextAccountAlice.ProcessAsync(connectRequest, roles: roles).Sync();

        // Check second device
        var contextOnboarded = TestCompletionSuccess(contextOnboardPending);
        ExerciseAccount(contextOnboarded);

        var id = "alice@example.net";
        // Create an ssh application
        var applicationMail = CatalogedApplicationMail.Create(id, roles);

        var transaction1 = contextAccountAlice.TransactBegin();
        transaction1.ApplicationCreate(applicationMail);
        var result1 = transaction1.TransactAsync().Sync();


        // Connect a third device
        var contextOnboardPending2 = MeshMachineTest.Connect(testEnvironmentCommon, DeviceAlice3, AccountAlice);

        // Admin Device
        contextAccountAlice.SynchronizeAsync().Sync();
        var connectRequest2 = contextAccountAlice.GetPendingMessageConnectionRequest();
        contextAccountAlice.ProcessAsync(connectRequest2, roles: roles).Sync();


        var contextOnboarded2 = TestCompletionSuccess(contextOnboardPending2);
        ExerciseAccount(contextOnboarded2);

        contextOnboarded.SynchronizeAsync().Sync();

        var application1 = contextAccountAlice.GetApplicationMail(id);
        var applicationEntry1 = contextAccountAlice.GetApplicationEntryMail(id);
        var application2 = contextOnboarded.GetApplicationMail(id);
        var applicationEntry2 = contextOnboarded.GetApplicationEntryMail(id);
        var application3 = contextOnboarded2.GetApplicationMail(id);
        var applicationEntry3 = contextOnboarded2.GetApplicationEntryMail(id);
        // check applicationSsh1 == applicationSsh2
        // check we have a private key for each device.

        application1.TestNotNull();
        applicationEntry1.TestNotNull();
        application2.TestNotNull();
        applicationEntry2.TestNotNull();


        application3.TestNotNull();
        applicationEntry3.TestNotNull();

        CheckKeysMatch(application1.OpenpgpEncrypt, application2.OpenpgpEncrypt, application3.OpenpgpEncrypt,
                applicationEntry1.Activation.OpenpgpEncrypt, applicationEntry2.Activation.OpenpgpEncrypt,
                applicationEntry3.Activation.OpenpgpEncrypt);

        CheckKeysMatch(application1.OpenpgpSign, application2.OpenpgpSign, application3.OpenpgpSign,
                applicationEntry1.Activation.OpenpgpSign, applicationEntry2.Activation.OpenpgpSign,
                applicationEntry3.Activation.OpenpgpSign);

        CheckKeysMatch(application1.SmimeEncrypt, application2.SmimeEncrypt, application3.SmimeEncrypt,
                applicationEntry1.Activation.SmimeEncrypt, applicationEntry2.Activation.SmimeEncrypt,
                applicationEntry3.Activation.SmimeEncrypt);
        CheckKeysMatch(application1.SmimeSign, application2.SmimeSign, application3.SmimeSign,
                applicationEntry1.Activation.SmimeSign, applicationEntry2.Activation.SmimeSign,
                applicationEntry3.Activation.SmimeSign);

        // Check the keys differ and are not null
        CheckKeysDiffer(application1.OpenpgpEncrypt, application1.OpenpgpSign, application1.SmimeEncrypt,
            applicationEntry1.Activation.SmimeSign);

        // Extract some files

        application1.OpenpgpEncrypt.ToKeyFile("MeshDeviceOpenpgpEncryptPublic1", KeyFileFormat.PEMPublic);
        application2.OpenpgpEncrypt.ToKeyFile("MeshDeviceOpenpgpEncryptPublic2", KeyFileFormat.PEMPublic);

        applicationEntry1.Activation.OpenpgpEncrypt.ToKeyFile("MeshDeviceOpenpgpEncryptPrivate1", KeyFileFormat.PEMPrivate);
        applicationEntry2.Activation.OpenpgpEncrypt.ToKeyFile("MeshDeviceOpenpgpEncryptPrivate2", KeyFileFormat.PEMPrivate);


        // Phase2: Bagging on these for now, export in S/MIME formats

        //application1.SmimeEncrypt.ToKeyFile("MeshDeviceOpenpgpEncryptPublic1", KeyFileFormat.X509DER);
        //application2.SmimeEncrypt.ToKeyFile("MeshDeviceOpenpgpEncryptPublic2", KeyFileFormat.X509DER);

        //applicationEntry1.Activation.SmimeEncrypt.ToKeyFile("MeshDeviceOpenpgpEncryptPrivate1", KeyFileFormat.PKCS12);
        //applicationEntry2.Activation.SmimeEncrypt.ToKeyFile("MeshDeviceOpenpgpEncryptPrivate2", KeyFileFormat.PKCS12);

        }



    void CheckKeysDiffer(params KeyData[] keys) {

        var dictionary = new SortedSet<string>();

        foreach (var key in keys) {
            key.TestNotNull();
            dictionary.Add(key.GetKeyPair().KeyIdentifier).TestTrue();
            }
        }


    void CheckKeysMatch(params KeyData[] keys) {

        keys.TestNotNull();
        if (keys.Length == 0) {
            return;
            }
        var keyIdentifier = keys[0].GetKeyPair().KeyIdentifier;
        foreach (var key in keys) {
            (keyIdentifier == key.GetKeyPair().KeyIdentifier).TestTrue();
            }
        }

    /// <summary>
    /// Connect a device by approving a request
    /// </summary>
    [Fact]
    public void MeshDeviceDeveloper() {
        var rights = new List<string> { Rights.IdRolesDeveloper, Rights.IdRolesWeb };


        var testEnvironmentCommon = GetTestEnvironmentCommon();
        var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                DeviceAliceAdmin, AccountAlice, "main");

        // New Device
        var contextOnboardPending = MeshMachineTest.Connect(testEnvironmentCommon, DeviceAlice3,
                AccountAlice);

        // Admin Device
        contextAccountAlice.SynchronizeAsync().Sync();
        var connectRequest = contextAccountAlice.GetPendingMessageConnectionRequest();
        contextAccountAlice.ProcessAsync(connectRequest, roles: rights).Sync();

        // Check second device
        var contextOnboarded = TestCompletionSuccess(contextOnboardPending);
        ExerciseAccount(contextOnboarded);

        //Check the access catalog
        //   Should have no threshold entry
        //   Should have service auth entry

        }

    #endregion



    }
