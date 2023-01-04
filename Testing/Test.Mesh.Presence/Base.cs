using System;

using Goedel.Test;
using Goedel.Utilities;
using Xunit;
using Goedel.Presence.Client;
using Goedel.Protocol.Service;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using Goedel.Mesh.Client;
using Xunit.Sdk;
using Goedel.Mesh.Test;
using System.Collections.Generic;

namespace Goedel.XUnit;

/// <summary>
/// Test library for PQC algorithms.
/// </summary>
public class TestPresence : ShellTestBase {


    List<IDisposable> Disposables= new List<IDisposable>();

    public void Disposing() {
        foreach (var disposable in Disposables) {
            disposable.Dispose();
            }
        TestEnvironment.Dispose();
        }


    public int ServiceSkip = 0;
    public int ServiceStride = 0;

    public int AliceSkip = 0;
    public int AliceStride = 0;

    public int BobSkip = 0;
    public int BobStride = 0;

    public override TestEnvironmentBase GetTestEnvironment() =>
            new TestEnvironmentPresence() {
                Skip= ServiceSkip,
                Stride= ServiceStride,
                };



    /// <summary>
    /// Convenience constructor for all things Alice.
    /// </summary>
    /// <param name="contextAccount">The account context.</param>
    /// <param name="contextPresence">The presence context.</param>
    /// <returns></returns>
    public TestCLI GetAlice(
                out ContextUser contextAccount,
                out ContextPresence contextPresence,
                int heartbeatTimeout = 30_000) =>
                        MakeAccount(AliceAccount, out contextAccount, 
                            out contextPresence, heartbeatTimeout,
                            AliceSkip, AliceStride);

    /// <summary>
    /// Convenience constructor for all things Bob.
    /// </summary>
    /// <param name="contextAccount">The account context.</param>
    /// <param name="contextPresence">The presence context.</param>
    public TestCLI GetBob(
                out ContextUser contextAccount,
                out ContextPresence contextPresence,
                int heartbeatTimeout = 30_000) =>
                MakeAccount(AccountB, out contextAccount, 
                    out contextPresence, heartbeatTimeout,
                            BobSkip, BobStride);


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
                int heartbeatTimeout = 30_000,
                int skip=0, int stride=1) {


        Console.WriteLine($"Make account {address}");

        address.SplitAccountIDService(out _, out var user);

        var cli = GetTestCLI(user + "-Admin");

        cli.ExampleNoCatch("account create {address}");
        cli.Account = address;

        contextAccount = cli.ContextUser;

        var service = ContextPresence.GetService(contextAccount);
        contextPresence = new ContextPresenceTest(service) {
            HeartbeatMilliSeconds = heartbeatTimeout,
            Stride =stride, 
            Skip = skip};
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
    /// Factory method, return an instance.
    /// </summary>
    /// <returns>The instance</returns>
    public static TestPresence Test() => new();



    /// <summary>
    /// Test status update notification on catalog update
    /// </summary>
    [Fact] 
    public void PresenceStatusUpdate() {


        var aliceCli = GetAlice(out var contextAlice, out var presenceAlice);
        var pollResult = presenceAlice.Poll();

        Disposing();
        }



    [Theory]
    [InlineData()]
    public void PresenceHeartbeat(
                int cycles = 30, 
                int timeout = 1000,
                int clientSkip = 0,
                int clientStride = 5,
                int serviceSkip = 0,
                int serviceStride = 5) {
        
        ServiceSkip = serviceSkip; 
        ServiceStride = serviceStride;
        AliceSkip = clientSkip; 
        AliceStride = clientStride;

        var aliceCli = GetAlice(out var contextAlice, 
                out var presenceAlice, timeout);
        var pollResult = presenceAlice.Poll();

        Thread.Sleep(timeout * cycles);

        // Count the number of heartbeats collected.

        (presenceAlice.PresenceListenerState ==
            PresenceListenerState.Connected).TestTrue();

        // Check that we got close to the expected number of heartbeats
        (presenceAlice.MessageSerial > (cycles-5)).TestTrue();

        Disposing();
        }







    /// <summary>
    /// Alice attempts to establish connection to Bob by placing a request at
    /// Bob's MSP. Bob receives notification via update.
    /// </summary>
    [Fact] 
    public async void PresenceSessionRequest() {


        var aliceCli = GetAlice(out var contextAlice, out var presenceAlice);
        var bobCli = GetAlice(out var contextBob, out var presenceBob);

        // Make sure both sender and receiver are ready before attempting to establish connection
        var pollResultA = presenceAlice.Poll();
        var pollResultB = presenceBob.Poll();

        // Test Alice sends before Bob calls to wait.
        await AliceContactBob(presenceAlice);
        await BobWaitAlice(presenceBob);

        // Test Alice sends after Bob calls to wait.
        await BobWaitAlice(presenceBob);
        await AliceContactBob(presenceAlice);

        }


    async Task AliceContactBob(ContextPresence contextPresence) {

        await contextPresence.SessionRequest(AccountB);
        }

    async Task BobWaitAlice(ContextPresence contextPresence) {

        await contextPresence.GetSessionRequest();

        }

    /// <summary>
    /// Test status update notification with presence service shutdown and restart.
    /// </summary>
    [Fact] 
    public void PresenceStatusRebind() => throw new NYI();


    /// <summary>
    /// Test status update notification with unreliable UDP service.
    /// </summary>
    [Fact] 
    public void PresenceStatusUnreliable() => throw new NYI();



    MessageContent GenerateMessage (int index) => throw new NYI();


    bool VerifyMessage (int index, MessageContent messageContent) => throw new NYI();

    }


public class TestService {

    public const string ReflectId = "Reflect";



    }
