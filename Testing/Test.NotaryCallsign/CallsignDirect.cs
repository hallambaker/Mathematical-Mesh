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
using Goedel.Mesh.Test;
using Goedel.Mesh;

namespace Goedel.XUnit;

public partial class CallsignDirect : UnitTestSet {

    public static CallsignDirect Test() => new ();


    public TestEnvironmentCommon TestEnvironmentCommon => testEnvironmentCommon ??
        GetTestEnvironmentCommon().CacheValue(out testEnvironmentCommon);
    TestEnvironmentCommon testEnvironmentCommon;

    public virtual TestEnvironmentCommon GetTestEnvironmentCommon(DeterministicSeed seed = null) =>
            new(seed ?? Seed);


    void Initialize(out ContextUser contextAccountAlice, out ContextRegistry contextRegistry) {

        contextAccountAlice = MeshMachineTest.GenerateAccountUser(TestEnvironmentCommon,
                DeviceAliceAdmin, AccountAlice, "main");


        contextRegistry = contextAccountAlice.CreateRegistry(AccountRegistry);


        TestEnvironmentCommon.MeshService.CallsignServiceProfile = contextRegistry.Profile as ProfileAccount;

        var bindRegistry = contextRegistry.CallsignRequest(CallsignRegistry, true);
        contextRegistry.Process();

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
        var bindAlice = contextAccountAlice.CallsignRequest(CallsignAlice, true);
        
        // Callsign is not assigned until we process it.
        CheckResolve(CallsignAlice);

        contextRegistry.Process();

        CheckResolve(CallsignAlice, contextAccountAlice);
        }

    [Fact]
    public void RegisterAliceTransferBob() {


        Initialize(out var contextAccountAlice, out var contextRegistry);
        var contextAccountBob = MeshMachineTest.GenerateAccountUser(TestEnvironmentCommon,
                    DeviceBobAdmin, AccountBob, "main");
        var profileBob = contextAccountBob.ProfileUser;

        var bindAlice = contextAccountAlice.CallsignRequest(CallsignAlice, true);
        var bindAliceBob = contextAccountAlice.CallsignRequest(CallsignBob, false);
        contextRegistry.Process();

        CheckResponse(contextAccountAlice, bindAlice);
        CheckResponse(contextAccountAlice, bindAliceBob);

        CheckResolve(CallsignBob);

        var transferBob = contextAccountAlice.CallsignRequest(CallsignBob, false, transfer: profileBob);
        contextRegistry.Process();

        CheckResponse(contextAccountAlice, transferBob);
        CheckResolve(CallsignBob, contextAccountBob, false);

        var bindBob = contextAccountBob.CallsignRequest(CallsignBob, true);
        contextRegistry.Process();

        CheckResponse(contextAccountBob, bindBob);

        CheckResolve(CallsignBob, contextAccountBob);
        }

    [Fact]
    public void RegisterAliceDuplicate() {


        Initialize(out var contextAccountAlice, out var contextRegistry);
        var contextAccountMallet = MeshMachineTest.GenerateAccountUser(TestEnvironmentCommon,
                DeviceMallet, AccountMallet, "main");

        var bindAlice = contextAccountAlice.CallsignRequest(CallsignAlice, true);
        contextRegistry.Process();

        //
        var bindMallet = contextAccountMallet.CallsignRequest(CallsignAlice, true);
        contextRegistry.Process();


        CheckResponse(contextAccountAlice, bindAlice);
        CheckResponse(contextAccountMallet, bindMallet, false);

        }



    void CheckResolve(
                    string callsign,
                    ContextAccount account=null,
                    bool bound = true) {
        }


    void CheckResponse(
                    ContextAccount account,
                    CallsignRegistrationRequest request,
                    bool success = true) {
        }


    }
