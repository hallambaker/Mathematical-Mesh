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

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Goedel.Mesh.Test;

public class TestHost {
    static string Domain => "example.com";

    static string Protocol => "mmm";

    static string Instance => "69";


    static string Alice => "alice";
    static string Bob => "bob";





    Random Random { get; } = new Random();


    // Dispatch delegate for the flogging
    delegate int FlogDelegate(TestClient client, int index);

    //public TestService(TestEnvironmentCommon TestEnvironmentCommon) {


    //    var meshProvider = TestEnvironmentCommon.MeshService;

    //    var monitorProvider = new ServiceManagementServiceProvider();



    //    // Set up the service
    //    var httpEndpoint = new HttpEndpoint(Domain, Protocol, Instance);
    //    var udpEndpoint = new UdpEndpoint(Protocol, Instance);
    //    var endpoints = new List<Endpoint> { httpEndpoint, udpEndpoint };




    //    using var provider = new Provider(endpoints, meshProvider);


    //    var providers = new List<Provider> { provider };
    //    using var service = new Service(providers);

    //    // Set up the client(s)
    //    var accountAlice = httpEndpoint.Account(Alice);
    //    var accountBob = httpEndpoint.Account(Bob);

    //    var clientAlice = new TestClient(accountAlice, endpoints);
    //    var clientBob = new TestClient(accountBob, endpoints);



    //    // Exercise the service
    //    var clients = new List<TestClient> { clientAlice, clientBob };
    //    Flog(clients, Work, 100);


    //    // Service shut down is performed automatically when the Dispose methods are 
    //    // called on the Service and Provider in turn.


    //    }


    static void Flog(List<TestClient> clients, FlogDelegate workDelegate, int count) {

        int threadCount = 0;

        var cancellationSource = new CancellationTokenSource();
        var options = new ParallelOptions {
            CancellationToken = cancellationSource.Token
            };

        var loopResult = Parallel.For(0, count, options, (i, loopState) => {

            Interlocked.Increment(ref threadCount);
            //Screen.WriteLine($"Start thread {i}/{threadCount}");

            workDelegate(clients[0], i);

            Interlocked.Decrement(ref threadCount);
            //Screen.WriteLine($"End thread {i}/{threadCount}");
        });


        }

    const int MaxRandom = 0x10000;

    static float[] ErrorProbabilities => new float[] { 1, 1, 1, 1 };
    static int[] CumulativeProbabilities { get; } = MakeCumulative(ErrorProbabilities, MaxRandom);

    static int[] MakeCumulative(float[] probabilities, int max) {
        var result = new int[probabilities.Length];
        var value = 0;

        for (var i = 0; i < probabilities.Length; i++) {
            value += (int)(probabilities[i] / 100) * max;
            result[i] = value;
            }

        return result;
        }

    int Work(TestClient client, int index) {
        var value = Random.Next(MaxRandom);

        if (value < CumulativeProbabilities[0]) {
            return WorkTooLarge(client, index);
            }
        if (value < CumulativeProbabilities[1]) {
            return WorkTooSlow(client, index);
            }
        if (value < CumulativeProbabilities[2]) {
            return WorkBadFormat(client, index);
            }
        if (value < CumulativeProbabilities[3]) {
            return WorkUnauthorized(client, index);
            }
        return WorkSuccess(client, index);

        }

    static int WorkSuccess(TestClient client, int index) {

        client.NextAction();


        return 0;
        }

    static int WorkTooLarge(TestClient client, int index) => WorkSuccess(client, index);

    static int WorkTooSlow(TestClient client, int index) => WorkSuccess(client, index);

    static int WorkBadFormat(TestClient client, int index) => WorkSuccess(client, index);

    static int WorkUnauthorized(TestClient client, int index) => WorkSuccess(client, index);

    }
