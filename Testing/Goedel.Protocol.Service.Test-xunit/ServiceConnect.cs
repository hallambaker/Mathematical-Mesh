using Goedel.Protocol;
using Goedel.Test.Core;
using Goedel.Mesh.Client;
using Goedel.Utilities;
using Goedel.Protocol.Presentation;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;
using System;
using System.Collections;
using System.Collections.Generic;
using Goedel.Mesh.Test;
using System.Threading;
using Goedel.Mesh;
using Goedel.Mesh.Management;
using Goedel.Protocol.Service;
using Goedel.Test;
using Xunit;
using System.IO;

namespace Goedel.XUnit {
    public partial class TestPresentationMesh {


        public const string Domain = "localhost";
        //public string Protocol => ServiceManagementService.WellKnown;
        public const string Instance = "69";

        ServiceManagementService testProvider;

        [Fact]
        public void TestMeshService() {
            using var testEnvironmentCommon = SetTestEnvironment(new TestEnvironmentCommon());

            var clientCredential = GetInitiatorCredential();
            var hostCredential = GetResponderCredential();


            testProvider = new TestServiceStatus();
            var provider = new RudProvider(testProvider, TransportType.All, Domain, Instance);

            var providers = new List<RudProvider> { provider };
            using var server = new Goedel.Protocol.Service.RudService(providers, hostCredential);


            var meshServiceBinding = new ConnectionInitiator(clientCredential, Domain, Instance,
                        TransportType.Http);
            //meshServiceBinding.Initialize(null, null);

            //var x = ServiceManagementServiceClient.WellKnown;

            var clientAlice = meshServiceBinding.GetClient<ServiceManagementServiceClient>();


            var request = new ServiceStatusRequest();
            var response = clientAlice.ServiceStatus(request);



            var response2 = clientAlice.ServiceStatus(request);

            var response3 = clientAlice.ServiceStatus(request);


            }

        [Fact]
        public void TestMeshMultiService() {


            using var testEnvironmentCommon = SetTestEnvironment(new TestEnvironmentCommon());

            var clientCredential = GetInitiatorCredential();
            var hostCredential = GetResponderCredential();

            var meshService = testEnvironmentCommon.MeshService;

            testProvider = new TestServiceStatus();

            var meshProvider = new RudProvider(meshService, TransportType.All, Domain, Instance);
            var provider = new RudProvider(testProvider, TransportType.All, Domain, Instance);

            var providers = new List<RudProvider> { meshProvider, provider };

            using var server = new Goedel.Protocol.Service.RudService(providers, hostCredential);


            var Connection = new ConnectionInitiator(clientCredential, Domain, Instance, TransportType.Http);



            var statusClient = Connection.GetClient<ServiceManagementServiceClient>();
            var meshClient = Connection.GetClient<MeshServiceClient>();

            // no messages sent out until here where we initialize the stream and the protocol at
            // the same time.


            Screen.WriteLine($"Make the first mmm request");

            var helloRequest = new HelloRequest() { };
            var response1 = meshClient.Hello(helloRequest);


            Screen.WriteLine($"Make the second mmm request");
            // An ordinary request
            var response2 = meshClient.Hello(helloRequest);


            Screen.WriteLine($"Make the first status request");
            // Try to start a different service 
            var serviceStatusRequest = new ServiceStatusRequest() { };
            var response3 = statusClient.ServiceStatus(serviceStatusRequest);

            Screen.WriteLine($"Make the third mmm request");
            // Another ordinary request
            var response4 = meshClient.Hello(helloRequest);

            Screen.WriteLine($"Make the second status request");
            // An ordinary request on the new client.
            // failing because we are not fishing out the session id on the stream assignment...
            var response5 = statusClient.ServiceStatus(serviceStatusRequest);


            }
        [Fact]

        public void TestCreateAccount() {
            using var testEnvironmentCommon = SetTestEnvironment();
            var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                    DeviceAliceAdmin, AccountAlice, "main");

            var contextOnboardPending = MeshMachineTest.Connect(testEnvironmentCommon, "device3",
                    AccountAlice, "device2");

            contextAccountAlice.Sync();
            var connectRequest = contextAccountAlice.GetPendingMessageConnectionRequest();
            contextAccountAlice.Process(connectRequest);

            var contextOnboarded = TestCompletionSuccess(contextOnboardPending);


            }

        static ContextUser TestCompletionSuccess(ContextMeshPending contextMeshPending) {
            var contextUser = contextMeshPending.Complete();
            contextUser.Sync(); // Will fail if cannot complete

            return contextUser;
            }

        [Fact]
        public void TestImpersonationConnect() => throw new NYI();


        [Fact]
        public void TestCreateGroup() => GroupTest();

        [Fact]
        public void TestImpersonationConfirm() => throw new NYI();
        [Fact]
        public void TestImpersonationGroup() {

            var (contextAlice, contextBob, contextGroup) = GroupTest();

            // impersonate Alice, can't do admin thing



            // impersonate Bob, can't get decryption key



            throw new NYI();

            }


        (ContextUser, ContextUser, ContextGroup) GroupTest() {
            using var testEnvironmentCommon = SetTestEnvironment();
            var plaintext = Platform.GetRandomBytes(1000);

            var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                    DeviceAliceAdmin, AccountAlice, "main");
            var contextAccountBob = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                    DeviceBobAdmin, AccountBob, "main");

            Exchange(contextAccountAlice, contextAccountBob);

            // Generate a recryption group
            var contextGroup = contextAccountAlice.CreateGroup(AccountGroup);

            var groupList = new List<string>() { AccountGroup };
            // Encrypt to the group
            var envelope = contextAccountAlice.DareEncode(plaintext, recipients: groupList, sign: true);

            // attempt to decrypt with Alice's key
            // this should fail as Alice doesn't have the decryption key.

            Xunit.Assert.Throws<NoAvailableDecryptionKey>(() =>
                contextAccountAlice.DareDecode(envelope, verify: true));

            // Create a member entry for Alice
            contextGroup.Add(AccountAlice);
            contextAccountAlice.Sync();
            contextAccountAlice.ProcessAutomatics();

            // need to sync messages here to accept the group addition.

            // this should now succeed
            var decrypt2 = contextAccountAlice.DareDecode(envelope, verify: true);
            decrypt2.IsEqualTo(plaintext).TestTrue();

            Xunit.Assert.Throws<NoAvailableDecryptionKey>(() =>
              contextAccountBob.DareDecode(envelope, verify: true));

            // Create a member entry fo Bob
            contextGroup.Add(AccountBob);

            var decrypt3 = contextAccountAlice.DareDecode(envelope, verify: true);
            decrypt3.IsEqualTo(plaintext).TestTrue();

            // Create a member entry fo Bob
            contextGroup.Delete(AccountBob);

            var decrypt4 = contextAccountAlice.DareDecode(envelope, verify: true);
            decrypt4.IsEqualTo(plaintext).TestTrue();


            return (contextAccountAlice, contextAccountBob, contextGroup);
            }


        public static bool Exchange(ContextUser contextAccountAlice, ContextUser contextAccountBob) {
            contextAccountBob.ContactRequest(AccountAlice);
            var sync = contextAccountAlice.Sync();


            var fromBob = contextAccountAlice.GetPendingMessageContactRequest();
            contextAccountAlice.Process(fromBob);
            var syncBob = contextAccountBob.Sync();

            var fromAlice = contextAccountBob.GetPendingMessageContactRequest();
            contextAccountBob.Process(fromAlice);

            return true;
            }


        [Theory]
        [InlineData(DataValidity.CorruptSigner)]
        [InlineData(DataValidity.CorruptSignature)]
        [InlineData(DataValidity.CorruptDigest)]
        [InlineData(DataValidity.CorruptPayload)]
        [InlineData(DataValidity.CorruptMissing)]
        public void TestImpersonationSync(DataValidity dataValidity) {
            using var testEnvironmentCommon = SetTestEnvironment();
            var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                    DeviceAliceAdmin, AccountAlice, "main");

            // check, this should succeed.
            contextAccountAlice.Sync();

            // check, this should also succeed.
            contextAccountAlice.MeshClient = null;
            contextAccountAlice.Sync();

            // Corrupt the credential
            DareEnvelope alternative = null;
            if (dataValidity == DataValidity.CorruptSigner) {
                var mallet = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                DeviceAliceAdmin, AccountMallet, "main");
                alternative = mallet.ConnectionDevice.DareEnvelope;
                }
            contextAccountAlice.ConnectionDevice.DareEnvelope.Corrupt(dataValidity, alternative);

            // check, this should now fail.
            contextAccountAlice.MeshClient = null;

            switch (dataValidity) {
                case DataValidity.CorruptPayload: {
                    Xunit.Assert.Throws<InvalidInput>(() => contextAccountAlice.Sync());
                    break;
                    }
                default: {
                    Xunit.Assert.Throws<ServerResponseInvalid>(() => contextAccountAlice.Sync());
                    break;
                    }

                }
            }



        [Fact]
        public void TestDeviceDeletion() {
            using var testEnvironmentCommon = SetTestEnvironment();
            var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                    DeviceAliceAdmin, AccountAlice, "main");

            contextAccountAlice.Sync();

            var contextOnboardPending = MeshMachineTest.Connect(testEnvironmentCommon, "device3",
                    AccountAlice, "device2");


            contextAccountAlice.Sync();
            var connectRequest = contextAccountAlice.GetPendingMessageConnectionRequest();
            contextAccountAlice.Process(connectRequest);

            var contextOnboarded = TestCompletionSuccess(contextOnboardPending);

            // should succeed
            contextOnboarded.Sync();
            var contextOnboardedUdf = contextOnboarded.CatalogedDevice.DeviceUdf;

            contextAccountAlice.DeleteDevice(contextOnboardedUdf);

            // should fail. [But doesn't]
            Xunit.Assert.Throws<ServerResponseInvalid>(() => contextOnboarded.Sync());
            }



        [Fact]
        public void TestAccountDeletion() {
            using var testEnvironmentCommon = SetTestEnvironment();
            var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                    DeviceAliceAdmin, AccountAlice, "main");

            contextAccountAlice.Sync();

            var contextOnboardPending = MeshMachineTest.Connect(testEnvironmentCommon, "device3",
                    AccountAlice, "device2");


            contextAccountAlice.Sync();
            var connectRequest = contextAccountAlice.GetPendingMessageConnectionRequest();
            contextAccountAlice.Process(connectRequest);

            var contextOnboarded = TestCompletionSuccess(contextOnboardPending);

            // should succeed
            contextOnboarded.Sync();
            var contextOnboardedUdf = contextOnboarded.CatalogedDevice.DeviceUdf;

            contextAccountAlice.DeleteAccount();


            // We don't have support for account revocation yet.
            Xunit.Assert.Throws<ServerResponseInvalid>(() => contextAccountAlice.Sync());
            Xunit.Assert.Throws<ServerResponseInvalid>(() => contextOnboarded.Sync());

            throw new NYI();

            }

        [Fact]
        public void TestPreconnect() {
            using var testEnvironmentCommon = SetTestEnvironment();
            var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                    DeviceAliceAdmin, AccountAlice, "main");

            var contextOnboardPending = MeshMachineTest.Connect(testEnvironmentCommon, "device3",
                    AccountAlice, "device2");

            Xunit.Assert.Throws<ServerResponseInvalid>(() => contextOnboardPending.Sync());
            }

        }


    public class TestServiceStatus : ServiceManagementService {
        //public override JpcSession GetSession() => throw new NotImplementedException();
        public override ServiceStatusResponse ServiceStatus(ServiceStatusRequest request, IJpcSession session) => new() {
            Start = DateTime.Now
            };

        }

    }