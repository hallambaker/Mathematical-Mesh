
namespace Goedel.XUnit;


public partial class TestPresence  {


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
    [InlineData(null, 30)]
    public void PresenceHeartbeat(CommunicationConditions communicationConditions = null,
                int cycles = 30) {
        "Disable".TaskFunctionality(true);
        //ServiceSkip = serviceSkip; 
        //ServiceStride = serviceStride;
        //AliceSkip = clientSkip; 
        //AliceStride = clientStride;

        communicationConditions ??= CommunicationConditions.Fast;
        var timeout = communicationConditions.Alice.HeartbeatMilliSeconds;

        var aliceCli = GetAlice(out var contextAlice, out var presenceAlice, communicationConditions);
        var pollResult = presenceAlice.Poll();

        Thread.Sleep(timeout * cycles);

        // Count the number of heartbeats collected.

        (presenceAlice.PresenceListenerState ==
            PresenceListenerState.Connected).TestTrue();

        // Check that we got close to the expected number of heartbeats
        (presenceAlice.MessageSerial > (cycles - 5)).TestTrue();

        Disposing();
        }



    /// <summary>
    /// Alice attempts to establish connection to Bob by placing a request at
    /// Bob's MSP. Bob receives notification via update.
    /// </summary>
    [Fact(Skip = "Need to ensure termination")]
    public void PresenceSessionRequest() {



        ThreadPool.SetMinThreads(100, 100);

        CreateAliceBob(out var aliceCli,
            out var bobCli, out var presenceAlice, out var presenceBob, CommunicationConditions.Normal);

        // Make sure both sender and receiver are ready before attempting to establish connection
        var pollResultA = presenceAlice.Poll();
        var pollResultB = presenceBob.Poll();


        Console.WriteLine("####################################################################");


        // Test Alice sends after Bob calls to wait.
        var t1 = presenceBob.GetSessionRequestAsync();
        Console.WriteLine("Next!!!!");
        var t2 = presenceAlice.SessionRequestAsync(AccountB);
        Console.WriteLine("Nex???");
        Task.WaitAll(t1, t2);
        Console.WriteLine("Done!!!!");

        //// Test Alice sends before Bob calls to wait.
        //var t3 = presenceAlice.SessionRequestAsync(AccountB);
        //var t4 = presenceBob.GetSessionRequestAsync();

        //await t3;
        //await t4;
        }





    }
