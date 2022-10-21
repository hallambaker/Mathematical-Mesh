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

namespace Goedel.XUnit;




/// <summary>
/// Test library for PQC algorithms.
/// </summary>
public class TestPresence : Disposable {

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





    [Theory]
    [InlineData(100)]
    [InlineData(1000)]
    [InlineData(2000)]
    public void UdpStreamBasic(int length = 100) {
        using var environment = new TestMini($"-{length}");

        using var socketReceiver = new UdpSocket();
        using var socketSender = new UdpSocket();

        var receiverEndpoint = new IPEndPoint(IPAddress.Loopback, socketReceiver.IPEndPoint.Port);
        var message = environment.GetBytes(length);

        // Put the receiver in wait mode.
        var task1 = WaitStreamData(socketReceiver);

        // Reserve a connection identifier to the specified endpoint. 
        // NB: this does not cause any packets to be sent.
        var connection = socketSender.ReserveConnection(receiverEndpoint);

        // Create the connection and send the data. The operations are batched for efficiency
        var pending = connection.BeginPending();
        var streamSocket = pending.OpenOutboundStreamPending ();
        pending.Post(streamSocket, message);
        var task2 = pending.CommitAsync();

        Console.WriteLine("Write complete");

        //wait for the receiver to complete. We don't need to wait for the sender because this
        // is implicit.
        var all = Task.WhenAll(task1, task2);
        all.Wait();

        // Check the recieved message is the same as the one sent.
        task1.Result.TestEqual(message);

        }

    [Theory]
    [InlineData(100)]
    public async void UdpServiceBasic(int length = 100) {
        using var environment = new TestMini($"-{length}");

        using var socketReceiver = new UdpSocket();
        using var socketSender = new UdpSocket();

        var message = environment.GetBytes(length);

        socketReceiver.BindService(TestService.ReflectId, TestService.Reflect);

        var connection = await socketSender.GetConnection(socketReceiver.IPEndPoint);
        var result = await connection.ServiceRequest(TestService.ReflectId, message);

        // Check the recieved message is the same as the one sent.
        result.TestEqual(message);
        }

    async Task<byte[]> WaitStreamData(UdpSocket receive) {
        Console.WriteLine("Read start");

        var connection = await receive.GetConnectionAsync();
        Console.WriteLine("Read got connection");

        var stream = await connection.GetStreamAsync();

        Console.WriteLine("Read got stream");
        var data = await stream.ReadBytesAsync();


        Console.WriteLine("Read complete");

        return data;
        }




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

    public static byte[] Reflect(PacketStream streamId, byte[] data) {
        return data;
        }

    public static byte[] Double (PacketStream streamId, byte[] data) {
        var result = new byte[data.Length*2];
        Array.Copy(data, result, data.Length);
        Array.Copy(data, 0, result, data.Length, data.Length);
        return data;
        }

    public static byte[] Fold (PacketStream streamId, byte[] data) {
        var outlength = data.Length / 2;
        var result = new byte[outlength];

        for (var i = 0; i < outlength; i++) {
            result[i] = (byte)(data[i] ^ data[i+ outlength]) ;
            }

        return data;
        }

    }
