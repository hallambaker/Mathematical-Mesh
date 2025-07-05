namespace Goedel.XUnit;


public partial class TestService {


    [Fact(Skip = "Carnet not yet implemented")]
    public void MeshCarnet() {
        var contextAccountCarnet = MeshMachineTest.GenerateAccountUser(TestEnvironment,
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


        var contextAccountAlice = MeshMachineTest.GenerateAccountUser(TestEnvironment,
        DeviceAliceAdmin, AccountAlice, "main");
        var contextAccountBob = MeshMachineTest.GenerateAccountUser(TestEnvironment,
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







    [Fact(Skip = "Test Mesh Presence")]
    public void MeshPresence() {
        var contextAccountAlice = MeshMachineTest.GenerateAccountUser(TestEnvironment,
                DeviceAliceAdmin, AccountAlice, "main");

        var contextAccountBob = MeshMachineTest.GenerateAccountUser(TestEnvironment,
                DeviceBobAdmin, AccountBob, "main");



        //var messageAlice = contextAccountAlice.PresenceConnect(presenceServer);
        //var messageBob  = contextAccountBob.PresenceConnect(presenceServer);



        //var whereAlice = contextAccountAlice.PresenceQuery(presenceServer, AccountBob);
        //var whereBob = contextAccountBob.PresenceQuery(presenceServer, AccountAlice);

        }

    [Fact(Skip = "Test the use of the Mesh Repository")]
    public void MeshRepository() {
        var plaintext = Platform.GetRandomBytes(1000);

        var repositoryServer = new RepositoryServer();

        var contextAccountAlice = MeshMachineTest.GenerateAccountUser(TestEnvironment,
                DeviceAliceAdmin, AccountAlice, "main");

        //var contextRepository = contextAccountAlice.Register(repositoryServer);

        //repositoryServer.Publish(plaintext);
        //contextRepository.Publish(plaintext);
        //contextRepository.Publish(plaintext);




        }



    }