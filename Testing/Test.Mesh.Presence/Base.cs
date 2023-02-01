global using System;

global using Goedel.Test;
global using Goedel.Utilities;
global using Xunit;
global using Goedel.Presence.Client;
global using Goedel.Protocol.Service;
global using System.Threading.Tasks;
global using System.Threading;
global using System.Net.Sockets;
global using Goedel.Mesh.Client;
global using Goedel.Mesh.Test;
global using System.Collections.Generic;
global using Goedel.Mesh.Shell;

namespace Goedel.XUnit;


/// <summary>
/// Test involving the presence client.
/// </summary>
public partial class TestPresence : ShellTestBase {


    List<IDisposable> Disposables= new List<IDisposable>();

    protected override void Disposing() {
        base.Disposing();
        foreach (var disposable in Disposables) {
            disposable.Dispose();
            }
        TestEnvironment?.Dispose();
        }

    CommunicationConditions CommunicationConditions { get; set; }
    //public int ServiceSkip = 0;
    //public int ServiceStride = 0;

    //public int AliceSkip = 0;
    //public int AliceStride = 0;

    //public int BobSkip = 0;
    //public int BobStride = 0;

    public override TestEnvironmentBase GetTestEnvironment(DeterministicSeed seed) =>
            new TestEnvironmentPresence(seed) {
                CommunicationConditions = CommunicationConditions
                };



    bool CreateAliceBob(
            out TestCLI aliceCLI,
            out TestCLI bobCLI, out ContextPresence alicePresence,
            out ContextPresence bobPresence, CommunicationConditions communicationConditions) {

        aliceCLI = GetAlice(out var contextAlice, out alicePresence, communicationConditions);
        bobCLI = GetBob(out var contextBob, out bobPresence, communicationConditions);

        var resultcuri = aliceCLI.Dispatch($"contact dynamic") as ResultPublish;
        var uri = resultcuri.Uri;

        var resultfetch = bobCLI.Dispatch($"contact exchange {uri}");

        var result6 = aliceCLI.Dispatch($"account sync /auto");

        return true;
        }



    /// <summary>
    /// Convenience constructor for all things Alice.
    /// </summary>
    /// <param name="contextAccount">The account context.</param>
    /// <param name="contextPresence">The presence context.</param>
    /// <returns></returns>
    public TestCLI GetAlice(
                out ContextUser contextAccount,
                out ContextPresence contextPresence,
                CommunicationConditions communicationConditions = null) =>
                MakeAccount(AliceAccount, out contextAccount, 
                    out contextPresence, communicationConditions?.Alice);

    /// <summary>
    /// Convenience constructor for all things Bob.
    /// </summary>
    /// <param name="contextAccount">The account context.</param>
    /// <param name="contextPresence">The presence context.</param>
    public TestCLI GetBob(
                out ContextUser contextAccount,
                out ContextPresence contextPresence,
                CommunicationConditions communicationConditions = null) =>
                MakeAccount(AccountB, out contextAccount, 
                    out contextPresence, communicationConditions?.Bob);


    /// <summary>
    /// Make an account for address <paramref name="address"/> and establishn a presence 
    /// provider context.
    /// </summary>
    /// <param name="address">That address of the account.</param>
    /// <param name="contextAccount">The account context.</param>
    /// <param name="contextPresence">The presence context.</param>
    /// <returns>The account CLI.</returns>
    public TestCLI MakeAccount(string address,
                out ContextUser contextAccount,
                out ContextPresence contextPresence,
                CommunicationDisruptor communicationDisruptor) {
        communicationDisruptor ??= CommunicationDisruptor.None;

        Console.WriteLine($"Make account {address}");

        address.SplitAccountIDService(out _, out var user);

        var cli = GetTestCLI(user + "-Admin");

        cli.ExampleNoCatch($"account create {address}");
        cli.Account = address;

        contextAccount = cli.ContextUser;

        var service = ContextPresence.GetService(contextAccount);
        contextPresence = new ContextPresenceTest(contextAccount, service, communicationDisruptor);
        contextPresence.Start();

        Disposables.Add(contextPresence);
        Disposables.Add(contextAccount);


        return cli;
        }


    /// <summary>
    /// Static constructor, put initializations here.
    /// </summary>
    static TestPresence() {
        }


    /// <summary>
    /// Create method, return an instance.
    /// </summary>
    /// <returns>The instance</returns>
    public static TestPresence Test() => new();


    MessageContent GenerateMessage (int index) => throw new NYI();


    bool VerifyMessage (int index, MessageContent messageContent) => throw new NYI();

    }

