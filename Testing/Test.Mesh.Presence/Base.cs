using System;

using Goedel.Test;
using Goedel.Utilities;
using Xunit;
using Goedel.Presence.Client;
using Goedel.Protocol.Service;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Goedel.Mesh.Client;
using Xunit.Sdk;
using Goedel.Mesh.Test;

namespace Goedel.XUnit;




/// <summary>
/// Test library for PQC algorithms.
/// </summary>
public class TestPresence : ShellTestBase {


    public override TestEnvironmentBase GetTestEnvironment() => new TestEnvironmentPresence();



    /// <summary>
    /// Convenience constructor for all things Alice.
    /// </summary>
    /// <param name="contextAccount">The account context.</param>
    /// <param name="contextPresence">The presence context.</param>
    /// <returns></returns>
    public TestCLI GetAlice(
                out ContextUser contextAccount,
                out ContextPresence contextPresence) =>
                        MakeAccount(AliceAccount, out contextAccount, out contextPresence);

    /// <summary>
    /// Convenience constructor for all things Bob.
    /// </summary>
    /// <param name="contextAccount">The account context.</param>
    /// <param name="contextPresence">The presence context.</param>
    public TestCLI GetBob(
                out ContextUser contextAccount,
                out ContextPresence contextPresence) =>
                MakeAccount(AccountB, out contextAccount, out contextPresence);


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
                out ContextPresence contextPresence) {

        address.SplitAccountIDService(out _, out var user);

        var cli = GetTestCLI(user + "-Admin");

        cli.ExampleNoCatch("account create {address}");
        cli.Account = address;

        contextAccount = cli.ContextUser;
        contextPresence = contextAccount.GetPresence();


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
    /// Test collection of presence service parameters from the MSP and
    /// use to bind to the presence service, then unbind.
    /// </summary>
    [Fact]
    public void PresenceServiceConnect() {


        var aliceCli = GetAlice(out var contextAlice, out var presenceAlice);


        }


    /// <summary>
    /// Test status update notification on catalog update
    /// </summary>
    [Fact] 
    public async void PresenceStatusUpdate() {


        var aliceCli = GetAlice(out var contextAlice, out var presenceAlice);
        var pollResult = await presenceAlice.Poll();

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
        var pollResultA = await presenceAlice.Poll();
        var pollResultB = await presenceBob.Poll();

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




    //[Theory]
    //[InlineData()]
    //public async void TestPipeline(int repeat = 1) {
    //    using var environment = new TestMini();

    //    var address = IPAddress.Loopback;
    //    int port = 0;
    //    var receiver = UdpSocket.GetUdpPort(address, ref port);

    //    var ipEndPoint = new IPEndPoint(address, port);

    //    var sender = new UdpClient();

    //    var data = environment.GetBytes(101);



    //    //await sender.SendAsync(data, data.Length, ipEndPoint);
    //    //try {
    //    //    var result1 = await receiver.ReceiveAsync();
    //    //    var task2 = receiver.ReceiveAsync();


    //    //    var result2 = await task2.ConfigureAwait(true);
    //    //    }
    //    //catch (Exception ex) {
    //    //    }
    //    //


    //    //for (var i = 0; i < repeat; i++) {
    //    //    await sender.SendAsync(data, data.Length, ipEndPoint);
    //    //    }
    //    //for (var i = 0; i < repeat + 1; i++) {
    //    //    var task = receiver.ReceiveAsync();
    //    //    Console.WriteLine($"    {i}");
    //    //    Task.WaitAll(task);
    //    //    //IPEndPoint? source = null;
    //    //    //var result = receiver.Receive(ref source);
    //    //    }


    //    var task = receiver.ReceiveAsync();
    //    sender.SendAsync(data, data.Length, ipEndPoint);


    //    Task.WaitAll(task);

    //    var task1 = receiver.ReceiveAsync();
    //    var task2 = receiver.ReceiveAsync();
    //    sender.SendAsync(data, data.Length, ipEndPoint);
    //    sender.SendAsync(data, data.Length, ipEndPoint);

    //    Task.WaitAll(task1, task2);



    //    }




    // ToDo: Fix the DataFull messages
    // Need to post an 'end of data' message in the packet.




    //[Theory]
    //[InlineData(100)]
    //[InlineData(1000)]
    //[InlineData(2000)]
    //public void UdpStreamBasic(int length = 100) {
    //    using var environment = new TestMini($"-{length}");

    //    using var socketReceiver = new UdpSocket();
    //    using var socketSender = new UdpSocket();

    //    var receiverEndpoint = new IPEndPoint(IPAddress.Loopback, socketReceiver.IPEndPoint.Port);
    //    var message = environment.GetBytes(length);

    //    // Put the receiver in wait mode.
    //    var task1 = WaitStreamData(socketReceiver);

    //    // Reserve a connection identifier to the specified endpoint. 
    //    // NB: this does not cause any packets to be sent.
    //    var connection = socketSender.ReserveConnection(receiverEndpoint);

    //    // Create the connection and send the data. The operations are batched for efficiency
    //    var pending = connection.BeginPending();
    //    var streamSocket = pending.OpenOutboundStreamPending ();
    //    pending.Post(streamSocket, message);
    //    var task2 = pending.CommitAsync();

    //    Console.WriteLine("Write complete");

    //    //wait for the receiver to complete. We don't need to wait for the sender because this
    //    // is implicit.
    //    var all = Task.WhenAll(task1, task2);
    //    all.Wait();

    //    // Check the recieved message is the same as the one sent.
    //    task1.Result.TestEqual(message);

    //    }

    //[Theory]
    //[InlineData(100)]
    //public async void UdpServiceBasic(int length = 100) {
    //    using var environment = new TestMini($"-{length}");

    //    using var socketReceiver = new UdpSocket();
    //    using var socketSender = new UdpSocket();

    //    var message = environment.GetBytes(length);

    //    socketReceiver.BindService(TestService.ReflectId, TestService.Reflect);

    //    var connection = await socketSender.GetConnection(socketReceiver.IPEndPoint);
    //    var result = await connection.ServiceRequest(TestService.ReflectId, message);

    //    // Check the recieved message is the same as the one sent.
    //    result.TestEqual(message);
    //    }

    //async Task<byte[]> WaitStreamData(UdpSocket receive) {
    //    Console.WriteLine("Read start");

    //    var connection = await receive.GetConnectionAsync();
    //    Console.WriteLine("Read got connection");

    //    var stream = await connection.GetStreamAsync();

    //    Console.WriteLine("Read got stream");
    //    var data = await stream.ReadBytesAsync();


    //    Console.WriteLine("Read complete");

    //    return data;
    //    }




    //[Fact]
    //public void ClientServerDirect() {

    //    using var environment = new TestEnvironmentPresence();
    //    var aliceAdmin = environment.GetAlice(out var aliceContext, out var alicePresence);



    //    }

    //[Fact]
    //public async void Poll() {
    //    using var environment = new TestEnvironmentPresence();
    //    var aliceAdmin = environment.GetAlice(out var aliceContext, out var alicePresence);


    //    var poll = alicePresence.Poll();
    //    await poll;
    //    // check poll result ??

    //    }

    //[Fact]
    //public async void ConnectAccept() {
    //    using var environment = new TestEnvironmentPresence();

    //    var aliceAdmin = environment.GetAlice(out var aliceContext, out var alicePresence);
    //    var bobAdmin = environment.GetBob(out var bobContext, out var bobPresence);

    //    // wait to start the connection
    //    var aliceWait = alicePresence.GetSessionRequest();
    //    var bobRequest = bobPresence.SessionRequest(aliceAdmin.Account);

    //    // Accept the connection
    //    var AliceSession = await aliceWait;
    //    AliceSession.SessionResponse();

    //    // Complete connection on Bob's side
    //    var bobSession = await bobRequest;
    //    bobSession.Accepted.TestTrue();

    //    // Test sending a single message

    //    var messageData = new MessageContent(
    //        MessageContentType.Binary, environment.GetBytes(256));


    //    var messageId = AliceSession.SendMessage(GenerateMessage(0));
    //    var receiveTask = bobSession.GetMessage();
    //    var message = await receiveTask;

    //    VerifyMessage(0, message).TestTrue();

    //    }


    MessageContent GenerateMessage (int index) => throw new NYI();


    bool VerifyMessage (int index, MessageContent messageContent) => throw new NYI();

    }


public class TestService {

    public const string ReflectId = "Reflect";

    //public static byte[] Reflect(PacketStream streamId, byte[] data) {
    //    return data;
    //    }

    //public static byte[] Double (PacketStream streamId, byte[] data) {
    //    var result = new byte[data.Length*2];
    //    Array.Copy(data, result, data.Length);
    //    Array.Copy(data, 0, result, data.Length, data.Length);
    //    return data;
    //    }

    //public static byte[] Fold (PacketStream streamId, byte[] data) {
    //    var outlength = data.Length / 2;
    //    var result = new byte[outlength];

    //    for (var i = 0; i < outlength; i++) {
    //        result[i] = (byte)(data[i] ^ data[i+ outlength]) ;
    //        }

    //    return data;
    //    }

    }
