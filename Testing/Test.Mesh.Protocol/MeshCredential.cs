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



using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Mesh;
using Goedel.Mesh.Test;
using Goedel.Test;
using Goedel.Test.Core;

using Xunit;

namespace Goedel.XUnit;

public partial class TestService {

    #region // Properties
    #endregion

    #region // Destructor
    #endregion

    #region // Constructors
    #endregion

    #region // Implement Interface: Ixxx
    #endregion

    #region // Tests 

    MeshCredentialPublic GetMeshCredentialPublic(
        MeshCredentialPrivate MeshCredentialPrivate) => MeshCredentialPrivate.GetMeshCredentialPublic();


    [Fact]
    public void TestCredentialDevice() {
        var credentialTempPrivate = MakeCredentialDevice();
        var credentialTemp = GetMeshCredentialPublic(credentialTempPrivate);
        // Device validation should succeed.
        var validatedDevice = credentialTemp.VerifyDevice();
        (validatedDevice as MeshVerifiedDevice).TestNotNull();
        (validatedDevice as MeshVerifiedAccount).TestNull();

        Xunit.Assert.Throws<NotAuthenticated>(() => credentialTemp.VerifyAccount());
        }


    [Fact]
    public void TestCredentialAccount() {
        var testEnvironmentCommon = GetTestEnvironmentCommon();
        var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                DeviceAliceAdmin, AccountAlice, "main");
        var credentialTempPrivate = contextAccountAlice.GetMeshCredentialPrivate();
        var credentialTemp = GetMeshCredentialPublic(credentialTempPrivate);

        // Device validation should succeed.
        var validatedDevice = credentialTemp.VerifyDevice();
        (validatedDevice as MeshVerifiedDevice).TestNotNull();
        (validatedDevice as MeshVerifiedAccount).TestNotNull();

        var validatedaccount = credentialTemp.VerifyAccount();
        (validatedaccount as MeshVerifiedDevice).TestNotNull();
        (validatedaccount as MeshVerifiedAccount).TestNotNull();
        }




    [Theory]
    [InlineData(DataValidity.CorruptSigner)]
    [InlineData(DataValidity.CorruptSignature)]
    [InlineData(DataValidity.CorruptDigest)]
    [InlineData(DataValidity.CorruptPayload)]
    [InlineData(DataValidity.CorruptMissing)]
    public void TestCredentialDeviceFails(DataValidity dataValidity) {
        var alternative = dataValidity == DataValidity.CorruptSigner ?
             ProfileDevice.Generate() : null;
        var credentialTempPrivate = MakeCredentialDevice();

        var credentialTemp = GetMeshCredentialPublic(credentialTempPrivate);
        credentialTemp.ProfileDevice.DareEnvelope.Corrupt(dataValidity, alternative?.DareEnvelope);



        Xunit.Assert.Throws<InvalidProfile>(() => credentialTemp.VerifyDevice());
        Xunit.Assert.Throws<NotAuthenticated>(() => credentialTemp.VerifyAccount());
        }


    static MeshCredentialPrivate MakeCredentialDevice() {
        var profileDevice = ProfileDevice.Generate();
        return new MeshCredentialPrivate(profileDevice, null, null,
                    profileDevice.KeyAuthentication as KeyPairAdvanced);
        }




    [Theory]
    [InlineData(DataValidity.CorruptSigner)]
    [InlineData(DataValidity.CorruptSignature)]
    [InlineData(DataValidity.CorruptDigest)]
    [InlineData(DataValidity.CorruptPayload)]
    [InlineData(DataValidity.CorruptMissing)]
    public void TestCredentialAccountFails(DataValidity dataValidity) {
        var testEnvironmentCommon = GetTestEnvironmentCommon();
        var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                DeviceAliceAdmin, AccountAlice, "main");
        var credentialTempPrivate = contextAccountAlice.GetMeshCredentialPrivate();
        var credentialTemp = GetMeshCredentialPublic(credentialTempPrivate);

        DareEnvelope alternative = null;
        if (dataValidity == DataValidity.CorruptSigner) {
            var mallet = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
            DeviceMallet, AccountMallet, "main");
            alternative = mallet.ConnectionAccount.DareEnvelope;
            }

        credentialTemp.ConnectionDevice.DareEnvelope.Corrupt(dataValidity, alternative);


        var deviceHandle = credentialTemp.VerifyDevice();
        var accountHandle = credentialTemp.VerifyAccount();

        Xunit.Assert.Throws<InvalidAssertion>(() => accountHandle.Validate(contextAccountAlice.ProfileUser));

        }


    [Theory]
    [InlineData(DataValidity.CorruptSigner)]
    [InlineData(DataValidity.CorruptSignature)]
    [InlineData(DataValidity.CorruptDigest)]
    [InlineData(DataValidity.CorruptPayload)]
    [InlineData(DataValidity.CorruptMissing)]
    public void TestProfileFails(DataValidity dataValidity) {
        var testEnvironmentCommon = GetTestEnvironmentCommon();
        var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                DeviceAliceAdmin, AccountAlice, "main");
        var credentialTemp = contextAccountAlice.GetMeshCredentialPrivate();

        DareEnvelope alternative = null;
        if (dataValidity == DataValidity.CorruptSigner) {
            var mallet = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                    DeviceMallet, AccountMallet, "main");
            alternative = mallet.ConnectionAccount.DareEnvelope;
            }

        // This should pass
        contextAccountAlice.ProfileUser.Validate();

        // Corrupt the profile, it should fail
        contextAccountAlice.ProfileUser.DareEnvelope.Corrupt(dataValidity, alternative);
        Xunit.Assert.Throws<InvalidProfile>(() => contextAccountAlice.ProfileUser.Validate());

        }








    #endregion
    }
