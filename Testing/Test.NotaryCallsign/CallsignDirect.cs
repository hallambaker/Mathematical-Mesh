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


#pragma warning disable IDE0059
//#pragma warning disable CA1822

using Goedel.Callsign;
using Goedel.Callsign.Registry;
using Goedel.Callsign.Resolver;
using Goedel.Mesh.Test;
using Goedel.Mesh;
using Goedel.Cryptography;
using Goedel.Mesh.Server;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;

namespace Goedel.XUnit;

public partial class CallsignDirect : UnitTestSet {

    public static CallsignDirect Test() => new();
    public PublicCallsignResolver CallsignResolver { get; set; }

    public ResolverServiceClient ResolverServiceClient { get; set; }

    public TestEnvironmentCommon TestEnvironmentCommon => testEnvironmentCommon ??
        GetTestEnvironmentCommon().CacheValue(out testEnvironmentCommon);
    TestEnvironmentCommon testEnvironmentCommon;

    public virtual TestEnvironmentCommon GetTestEnvironmentCommon(DeterministicSeed seed = null) =>
            new(seed ?? Seed) {
                CallsignRegistry = AccountRegistry
                };


    void Initialize(out ContextUser contextAccountAlice, out ContextRegistry contextRegistry) {

        contextAccountAlice = MeshMachineTest.GenerateAccountUser(TestEnvironmentCommon,
                DeviceAliceAdmin, AccountAlice, "main");

        var pages = Page.LoadResources();

        var callsignMapping = new CallsignMapping();


        contextRegistry = contextAccountAlice.CreateRegistry(AccountRegistry);

        // Bind to the callsign @callsign
        TestEnvironmentCommon.MeshService.CallsignServiceProfile = contextRegistry.Profile as ProfileAccount;
        var bindRegistry = contextAccountAlice.CallsignRequest(CallsignRegistry, bind: true, transfer: null);
        contextRegistry.Process();


        CallsignResolver = TestEnvironmentCommon.Resolver;
        ResolverServiceClient = CallsignResolver.GetClient();

        CallsignResolver.SyncToRegistry();
        }




    [Fact]
    public void CreateRegistry() {

        Initialize(out var contextAccountAlice, out var contextRegistry);

        }

    [Fact]
    public void RegisterAlice() {

        Initialize(out var contextAccountAlice, out var contextRegistry);

        // Callsign is initially unassigned
        CheckResolve(CallsignAlice);

        // Make the binding request
        var bindAlice = contextAccountAlice.CallsignRequest(CallsignAlice, bind: true, transfer: null);

        // Callsign is not assigned until we process it.
        CheckResolve(CallsignAlice);

        contextRegistry.Process();

        CheckResponse(contextAccountAlice, bindAlice);
        CheckResolve(CallsignAlice, contextAccountAlice);
        }

    [Fact]
    public void RegisterAliceTransferBob() {


        Initialize(out var contextAccountAlice, out var contextRegistry);
        var contextAccountBob = MeshMachineTest.GenerateAccountUser(TestEnvironmentCommon,
                    DeviceBobAdmin, AccountBob, "main");
        var profileBob = contextAccountBob.ProfileUser;

        var bindAlice = contextAccountAlice.CallsignRequest(CallsignAlice, bind: true, transfer: null);
        var bindAliceBob = contextAccountAlice.CallsignRequest(CallsignBob, bind: false, transfer: null);
        contextRegistry.Process();

        CheckResponse(contextAccountAlice, bindAlice);
        CheckResponse(contextAccountAlice, bindAliceBob);

        CheckResolve(CallsignBob, contextAccountAlice);

        var transferBob = contextAccountAlice.CallsignRequest(CallsignBob, display: null, bind: false, transfer: profileBob);
        contextRegistry.Process();

        CheckResponse(contextAccountAlice, transferBob, bound: false);
        CheckResolve(CallsignBob, contextAccountBob, false);

        var bindBob = contextAccountBob.CallsignRequest(CallsignBob, bind: true, transfer: null);
        contextRegistry.Process();

        CheckResponse(contextAccountBob, bindBob);

        CheckResolve(CallsignBob, contextAccountBob);
        }

    [Fact]
    public void RegisterAliceDuplicate() {


        Initialize(out var contextAccountAlice, out var contextRegistry);
        var contextAccountMallet = MeshMachineTest.GenerateAccountUser(TestEnvironmentCommon,
                DeviceMallet, AccountMallet, "main");
        //contextAccountMallet.ProfileRegistryCallsign = contextAccountAlice.ProfileRegistryCallsign;

        var bindAlice = contextAccountAlice.CallsignRequest(CallsignAlice, bind: true, transfer: null);
        contextRegistry.Process();

        //
        var bindMallet = contextAccountMallet.CallsignRequest(CallsignAlice, bind: true, transfer: null);
        contextRegistry.Process();


        CheckResponse(contextAccountAlice, bindAlice);
        CheckResponse(contextAccountMallet, bindMallet, false);
        CheckResolve(CallsignAlice, contextAccountAlice);
        }

    /// <summary>
    /// Alice registers the callsign @alice which Bob uses to exchange contacts.
    /// </summary>
    /// <exception cref="NYI"></exception>
    [Fact]
    public void RegisterAliceConnectBob() {
        Initialize(out var contextAccountAlice, out var contextRegistry);
        var contextAccountBob = MeshMachineTest.GenerateAccountUser(TestEnvironmentCommon,
                DeviceBobAdmin, AccountBob, "mainbob");

        var bindAlice = contextAccountAlice.CallsignRequest(CallsignAlice, bind: true, transfer: null);
        contextRegistry.Process();
        CheckResponse(contextAccountAlice, bindAlice);


        CallsignResolver.SyncToRegistry();
        var bobRequest = contextAccountBob.ContactRequest(CallsignAlice);

        }


    [Fact]
    public void TestRegisterSuccess() {

        var tests = new List<string> {
            "@alice",
            "@bob",
            "@1verylongcallsign",
            "@gödel",
            "@alice_cryptographer"
            };


        Initialize(out var contextAccountAlice, out var contextRegistry);

        foreach (var callsign in tests) {
            var bindAlice = contextAccountAlice.CallsignRequest(callsign, bind: true, transfer: null);
            contextRegistry.Process();

            CheckResponse(contextAccountAlice, bindAlice);
            }

        }


    [Fact]
    public void TestRegisterFail() {
        var tests = new List<string> {
            "@alice™",
            "@alice®",
            "@12345"
            };


        Initialize(out var contextAccountAlice, out var contextRegistry);

        foreach (var callsign in tests) {
            var bindAlice = contextAccountAlice.CallsignRequest(callsign, bind: true, transfer: null);
            contextRegistry.Process();

            CheckResponse(contextAccountAlice, bindAlice, false);
            }
        }






    void CheckResponse(
                    ContextUser account,
                    CallsignRegistrationRequest request,
                    bool success = true,
                    bool bound = true) {
        account.Sync();
        // check result.

        if (!account.TryGetMessageResponse(request, out var index)) {
            // message is not supposed to have been received yet.
            success.TestFalse();
            return;
            }

        //Here check we got the expected message response

        var message = index.JsonObject as CallsignRegistrationResponse;
        message.TestNotNull();

        if (!success) {
            message.Registered.TestFalse();
            return;
            }

        var registration = message.CatalogedRegistration.EnvelopedRegistration.Decode();
        var entry = registration.Entry.Decode();
        if (bound) {
            account.Profile.Matches(entry.ProfileUdf).TestTrue();
            }
        else {
            }
        }

    void CheckResolve(
                string callsign,
                ContextAccount account = null,
                bool bound = true) {

        CallsignResolver.SyncToRegistry();
        var queryResponse = ResolverServiceClient.Query(callsign);

        if (account == null) {
            queryResponse.Success().TestFalse();
            queryResponse.Result.TestNull();
            return;
            }
        queryResponse.Success().TestTrue();

        var result = queryResponse.Result.Decode();
        var binding = result.Entry.Decode();

        var bindingUdf = binding.ProfileUdf;

        if (!bound) {
            binding.ProfileUdf.TestNull();
            return;
            }
        var boundtoaccount = account.Profile.Matches (binding.ProfileUdf);



        // expand this to unpack queryResponse and check it is bound to the specified account.

        //"MDJS-6ZFZ-HJBB-OIQ7-XXPX-NSXL-MGDT"
        //"MDJS-6ZFZ-HJBB-OIQ7-XXPX-NSXL-MGDT"


        (bound == boundtoaccount).TestTrue();

        }
    }
