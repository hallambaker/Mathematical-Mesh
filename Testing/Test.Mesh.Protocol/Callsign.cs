



using Xunit;
namespace Goedel.XUnit;


public partial class TestService {

    public const string CallsignAlice = "@Alice";
    public const string CallsignAlice2 = "@callsign";
    public const string CallsignBob = "@Bob";
    [Fact]
    public void MeshCallsign() {
        var testEnvironmentCommon = GetTestEnvironmentCommon();

        var contextAccountRegistry = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                DeviceServiceRegistry, AccountRegistryAdmin, "main");
        var contextRegistry = contextAccountRegistry.CreateRegistry(AccountRegistry);

        //var resolverServer = new ResolverServer(AccountCallsign);
        var resolverServer = ContextResolver.Create(
                contextAccountRegistry.MeshHost, AccountResolver, 
                contextRegistry.CatalogedRegistry.EnvelopedProfileRegistry
                );


        var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                DeviceAliceAdmin, AccountAlice, "main");
        var contextAccountBob = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                DeviceBobAdmin, AccountBob, "main");

        contextAccountAlice.CallsignRegistry = AccountRegistry;
        contextAccountBob.CallsignRegistry = AccountRegistry;

        var callsignRequestAlice1 = contextAccountAlice.CallsignRequest(CallsignAlice, true,
                registry: AccountRegistry);
        contextRegistry.Process();
        resolverServer.Update();

        var result1 = resolverServer.Resolve(CallsignAlice);
        var result2 = resolverServer.Resolve(CallsignAlice2);

        var callsignRequestAlice2 = contextAccountAlice.CallsignRequest(CallsignAlice2);
        contextRegistry.Process();
        resolverServer.Update();

        var result3 = resolverServer.Resolve(CallsignAlice);
        var result4 = resolverServer.Resolve(CallsignAlice2);


        var callsignRequestAlice3 = contextAccountAlice.CallsignRequest(CallsignAlice2, true);
        contextRegistry.Process();
        resolverServer.Update();

        var result5 = resolverServer.Resolve(CallsignAlice);
        var result6 = resolverServer.Resolve(CallsignAlice2);


        var callsignRequestBob = contextAccountBob.CallsignRequest(CallsignBob, true);
        contextRegistry.Process();
        resolverServer.Update();

        var result7 = resolverServer.Resolve(CallsignAlice);
        var result8 = resolverServer.Resolve(CallsignAlice2);
        var result9 = resolverServer.Resolve(CallsignBob);






        }


    [Fact]
    public void MeshCarnet() {
        var testEnvironmentCommon = GetTestEnvironmentCommon();

        var contextAccountCarnet = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                DeviceServiceCarnet, AccountAdminCarnet, "main");
        //var contextRegistry = contextAccountRegistry.CreateRegistry(AccountRegistry);
        ////var resolverServer = new ResolverServer(AccountCallsign);
        //var resolverServer = ContextResolver.Create(
        //        contextAccountRegistry.MeshHost, AccountResolver, 
        //        contextRegistry.CatalogedMachine.EnvelopedProfileAccount
        //        );

        //// create a payments server

        var contextCarnet = ContextCarnet.Create(contextAccountCarnet.MeshHost, AccountCarnet);
        var carnetServer = new CarnetServer();


        var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
        DeviceAliceAdmin, AccountAlice, "main");
        var contextAccountBob = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                DeviceBobAdmin, AccountBob, "main");



        contextCarnet.Issue(AccountAlice, 100);
        contextCarnet.Issue(AccountBob, 500);


        var paymentToken1 = contextAccountAlice.Spend(20);
        var paymentToken2 = contextAccountAlice.Spend(70);
        var paymentToken3 = contextAccountAlice.Spend(20);

        carnetServer.Spend(paymentToken1);
        carnetServer.Spend(paymentToken1);
        carnetServer.Spend(paymentToken2);
        carnetServer.Spend(paymentToken3);
        }


    [Fact]
    public void MeshPresence() {
        var testEnvironmentCommon = GetTestEnvironmentCommon();


        var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                DeviceAliceAdmin, AccountAlice, "main");
        
        var contextAccountBob = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                DeviceBobAdmin, AccountBob, "main");



        //var messageAlice = contextAccountAlice.PresenceConnect(presenceServer);
        //var messageBob  = contextAccountBob.PresenceConnect(presenceServer);



        //var whereAlice = contextAccountAlice.PresenceQuery(presenceServer, AccountBob);
        //var whereBob = contextAccountBob.PresenceQuery(presenceServer, AccountAlice);

        }

    [Fact]
    public void MeshRepository() {
        var testEnvironmentCommon = GetTestEnvironmentCommon();
        var plaintext = Platform.GetRandomBytes(1000);

        var repositoryServer = new RepositoryServer();

        var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                DeviceAliceAdmin, AccountAlice, "main");

        //var contextRepository = contextAccountAlice.Register(repositoryServer);

        //repositoryServer.Publish(plaintext);
        //contextRepository.Publish(plaintext);
        //contextRepository.Publish(plaintext);




        }



    }