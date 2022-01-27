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

using System.Net;
using System.Net.Sockets;

using Goedel.Protocol.Presentation;

namespace Goedel.Protocol.Service;

/// <summary>
/// Service provider managing HTTP and UDP listeners.
/// </summary>
public class RudService : Disposable {

    #region // Properties

    ///<summary>Maximum number of concurrent worker processes.</summary> 
    public int MaxDispatch { get; }

    ///<summary>Timeout for action on a worker thread.</summary> 
    public int Timeout { get; set; } = 60 * 1000;

    bool active = true;

    private readonly Thread serviceThread;



    private readonly Task<ServiceRequest>[] serviceTasks;

    private HttpListener httpListener = null;

    private readonly UdpClient[] udpListeners = null;

    ///<summary>The RDP Listener.</summary> 
    public Listener Listener;



    private readonly CancellationTokenSource cancellationTokenSource;
    private CancellationToken CancellationToken { get; }
    private readonly int udpListenerCount;
    private readonly int httpListenerCount = 1;
    private int ListenerCount => udpListenerCount + httpListenerCount;

    readonly Task[] dispatchTasks;
    readonly string[] dispatchTaskResource;
    readonly bool[] dispatchTaskActive;

    ///<summary>Service instrumentation.</summary> 
    public HostMonitor Monitor;
    readonly Dictionary<string, IProvider> providerMap = new();

    #endregion
    #region // Destructor
    /// <summary>
    /// Disposal routine, perform clean termination of all active threads.
    /// </summary>
    protected override void Disposing() {

        // Set the state to inactive
        active = false;
        cancellationTokenSource.Cancel();

        // shut down the HTTP and UDP listeners.
        httpListener?.Close();


        if (udpListeners != null) {
            foreach (var listener in udpListeners) {
                listener?.Close();
                }
            }
        }


    #endregion
    #region // Constructors



    /// <summary>
    /// Constructor returning an instance servicing the interfaces <paramref name="providers"/>.
    /// </summary>
    /// <param name="providers">The services to be served.</param>
    /// <param name="rdpListener">Specify the listener layer (default is <see cref="RudListener"/>.</param>
    /// <param name="maxCores">Maximum number of dispatch threads.</param>
    /// <param name="credential">Credential for the listener to use.</param>
    /// <remarks>Constructor returns after the service has been started and listener threads 
    /// initialized.</remarks>
    public RudService(IEnumerable<IProvider> providers,
            ICredentialPrivate credential = null,
            Listener rdpListener = null,
            int maxCores = 0) {

        Listener = rdpListener ?? new RudListener(credential, providers);

        cancellationTokenSource = new CancellationTokenSource();
        CancellationToken = cancellationTokenSource.Token;

        // set the number of dispatch tasks
        MaxDispatch = maxCores > 0 ? maxCores : Environment.ProcessorCount;

        // Set up the dispatchers
        //nullTask = Task.Run(NullTask);
        dispatchTasks = new Task[MaxDispatch];
        dispatchTaskResource = new string[MaxDispatch];
        dispatchTaskActive = new bool[MaxDispatch];
        for (var i = 0; i < MaxDispatch; i++) {
            dispatchTasks[i] = Task.Run(NullTask);
            dispatchTaskActive[i] = false;
            dispatchTaskResource[i] = null;
            }

        // Set up the listeners

        udpListenerCount = 0;

        // The HTTP listener handles multiplexing internally and so we only require one.
        HttpListener.IsSupported.AssertTrue(ServerNotSupported.Throw);
        httpListener = new HttpListener();
        foreach (var provider in providers) {
            foreach (var endpoint in provider.HTTPEndpoints) {
                var uri = endpoint.GetUriPrefix();
                //uri = "http://+:15099/.well-known/";
                //Screen.WriteLine($"Connect to URI {uri}");

                httpListener.Prefixes.Add(uri);
                providerMap.Add(uri, provider);
                }
            udpListenerCount += provider.UdpEndpoints.Count;
            }
        udpListenerCount = 0; // Hack - disable UDP for now, is throwing errors.

        // Start the monitoring service and bind values to every provider returning the JPC interface.
        Monitor = new HostMonitor(ListenerCount, MaxDispatch);

        foreach (var provider in providers) {
            if (provider.JpcInterface is IMonitorProvider monitorProvider) {
                monitorProvider.Monitor = Monitor;
                }
            }

        serviceTasks = new Task<ServiceRequest>[ListenerCount];


        httpListener.Start();
        WaitHttpRequest();

        //set up the UDP clients...
        //udpListeners = new UdpClient[udpListenerCount];
        //var listener = 1;
        //foreach (var provider in providers) {
        //    foreach (var endpoint in provider.UdpEndpoints) {
        //        udpListeners[listener] = endpoint.GetClient();
        //        WaitUdpListener(listener);
        //        listener++;
        //        }
        //    }


        var t = WaitServiceAsync();
        //t.Wait();

        //start the asynchronous services before returning.
        //serviceThread = new Thread(WaitService);
        //serviceThread.Start();



        //var connection = MiniProcess(httpListener);


        //var service = "http://voodoo:15099/.well-known/mmm/";
        //var webClient = new WebClient();
        //var data = new byte[12000];

        //var post = webClient.UploadData(service, data);



        }




    /// <summary>
    /// Constructor returning an instance servicing the interfaces <paramref name="providers"/>.
    /// </summary>
    /// <param name="providers">The services to be served.</param>
    /// <param name="rdpListener">Specify the listener layer (default is <see cref="RudListener"/>.</param>
    /// <param name="maxCores">Maximum number of dispatch threads.</param>
    /// <param name="credential">Credential for the listener to use.</param>
    /// <remarks>Constructor returns after the service has been started and listener threads 
    /// initialized.</remarks>
    public RudService(
        CancellationToken cancellationToken,
        IEnumerable<IProvider> providers,
            ICredentialPrivate credential = null,
            Listener rdpListener = null,
            int maxCores = 0) {

        Listener = rdpListener ?? new RudListener(credential, providers);
        CancellationToken = cancellationToken;

        // set the number of dispatch tasks
        MaxDispatch = maxCores > 0 ? maxCores : Environment.ProcessorCount;

        // Set up the dispatchers
        //nullTask = Task.Run(NullTask);
        dispatchTasks = new Task[MaxDispatch];
        dispatchTaskResource = new string[MaxDispatch];
        dispatchTaskActive = new bool[MaxDispatch];
        for (var i = 0; i < MaxDispatch; i++) {
            dispatchTasks[i] = Task.Run(NullTask);
            dispatchTaskActive[i] = false;
            dispatchTaskResource[i] = null;
            }

        // Set up the listeners

        udpListenerCount = 0;

        // The HTTP listener handles multiplexing internally and so we only require one.
        HttpListener.IsSupported.AssertTrue(ServerNotSupported.Throw);
        httpListener = new HttpListener();
        foreach (var provider in providers) {
            foreach (var endpoint in provider.HTTPEndpoints) {
                var uri = endpoint.GetUriPrefix();
                //uri = "http://+:15099/.well-known/";
                //Screen.WriteLine($"Connect to URI {uri}");

                httpListener.Prefixes.Add(uri);
                providerMap.Add(uri, provider);
                }
            udpListenerCount += provider.UdpEndpoints.Count;
            }
        udpListenerCount = 0; // Hack - disable UDP for now, is throwing errors.

        // Start the monitoring service and bind values to every provider returning the JPC interface.
        Monitor = new HostMonitor(ListenerCount, MaxDispatch);

        foreach (var provider in providers) {
            if (provider.JpcInterface is IMonitorProvider monitorProvider) {
                monitorProvider.Monitor = Monitor;
                }
            }

        serviceTasks = new Task<ServiceRequest>[ListenerCount+1];
        serviceTasks[ListenerCount] = WaitCancellationToken();

        httpListener.Start();
        WaitHttpRequest();

        //set up the UDP clients...
        //udpListeners = new UdpClient[udpListenerCount];
        //var listener = 1;
        //foreach (var provider in providers) {
        //    foreach (var endpoint in provider.UdpEndpoints) {
        //        udpListeners[listener] = endpoint.GetClient();
        //        WaitUdpListener(listener);
        //        listener++;
        //        }
        //    }



        //start the asynchronous services before returning.
        serviceThread = new Thread(WaitService);
        serviceThread.Start();

        var t = WaitServiceAsync();
        }




    #endregion
    #region // Methods 



    //public async Task WaitService() {
    //    await serviceThread.Join();
    //    }

    // The choreography here is flawed but leave as is for now. Need to have a three stage 
    // scheme in which we first construct the complete request, then dispatch it on
    // a managed queue and finally release it.

    /// <summary>
    /// Return a provider.
    /// </summary>
    /// <param name="domain">Domain to which the provider is bound.</param>
    /// <param name="port">Port to which the provider is bound.</param>
    /// <param name="resource">Protocol serviced.</param>
    /// <returns>The provider.</returns>
    public IProvider GetProvider(string domain, int port, string resource) {

        var test = $"http://+:{port}{resource}";
        if (providerMap.TryGetValue(test, out var provider)) {
            return provider;
            }

        test = $"http://{domain}:{port}{resource}";
        if (providerMap.TryGetValue(test, out provider)) {
            return provider;
            }
        return null;
        }

     void WaitService() {
        var t =  WaitServiceAsync();
        t.Wait();
        }


    async Task WaitServiceAsync() {

        while (active) {
            try {
                await Task.WhenAny(serviceTasks);

                //Dispatch a processing unit to the next available slot.
                for (var listener = 0; listener < udpListenerCount + 1; listener++) {
                    if (serviceTasks[listener].IsCompleted) {
                        Dispatch(serviceTasks[listener].Result);
                        }
                    }

                if (active) {
                    if (serviceTasks[0].IsCompleted) {
                        WaitHttpRequest();
                        }
                    for (var listener = 0; listener < udpListenerCount; listener++) {
                        if (serviceTasks[listener + 1].IsCompleted) {
                            WaitUdpListener(listener);
                            }
                        }
                    }

                Reclaim(); // dispose of all resources held by unused tasks
                }

            catch (OperationCanceledException) {
                Canceled();
                }

            }
        }

    /// <summary>
    /// Null task, simply runs to completion. This is used to allow gracefull shutdown of the
    /// dispatch threads.
    /// </summary>
    void NullTask() {
        }

    void Canceled() {
        // Since active is true, no more requests for HTTP or UDP connections will be queued.

        // Wait for the outstanding tasks to be completed

        Task.WaitAll(dispatchTasks);

        foreach (var task in dispatchTasks) {
            task.Dispose(); // force cleanup of the dispatch tasks
            }
        httpListener.Close(); // Gracefull termination of the HTTP Listener
        httpListener = null;


        for (var i = 0; udpListeners != null && i < udpListeners.Length; i++) {
            udpListeners[i].Close(); // Gracefull termination of the UDP Listeners
            udpListeners[i] = null;
            }
        }


    // Dispatch completion of the specified connection.
    void Dispatch(ServiceRequest connection) {

        // First purge all finished tasks and check to see if there is an outstanding request competing for the same resource

        int targetSlot = -1;
        bool complete = false;
        int free = 0;
        var resource = connection?.Resource;

        for (var i = 0; i < MaxDispatch; i++) {
            if (dispatchTaskActive[i]) {
                if (dispatchTasks[i].IsCompleted) {
                    Reclaim(i);
                    }
                else if (resource != null && dispatchTaskResource[i] == resource) {
                    // Append this task to the outstanding chain of tasks waiting on that resource.
                    // This avoids the need for contention locking within the dispatch code.
                    dispatchTasks[i] = dispatchTasks[i].ContinueWith((antecendent) => connection.Complete());
                    complete = true;
                    }
                else {
                    targetSlot = i;
                    free++;
                    }
                }
            }

        if (complete) {
            return;
            }

        // Wait for a spare slot
        if (targetSlot < 0) {
            // start timer here
            Monitor.StartBusy();
            Task.WaitAny(dispatchTasks);
            Monitor.EndBusy();
            // end timer here and add to the 'blocked' allocation
            targetSlot = Reclaim();
            }


        if (!active) {
            return;
            }

        // Post this request to the next empty slot.
        dispatchTaskActive[targetSlot] = true;
        dispatchTaskResource[targetSlot] = connection.Resource;
        connection.Slot = targetSlot;
        connection.Service = this;
        dispatchTasks[targetSlot] = Task.Run(connection.Complete);

        }


    void Reclaim(int i) {
        dispatchTaskActive[i] = false;
        dispatchTasks[i].Dispose();
        }


    int Reclaim() {
        var targetSlot = -1;

        for (var i = 0; i < MaxDispatch; i++) {
            if (dispatchTasks[i].IsCompleted) {
                Reclaim(i);
                targetSlot = i;
                }
            }
        return targetSlot;
        }



    void WaitHttpRequest() {
        if (active) {
            serviceTasks[0] = Process(httpListener);
            }
        }

    void WaitUdpListener(int listener) {
        if (active) {
            serviceTasks[listener + 1] = Process(udpListeners[listener]);
            }
        }

    async Task<ServiceRequest> WaitCancellationToken() {
        await CancellationToken;
        active = false;

        return (ServiceRequest)null;

        }



    async Task<ServiceRequest> Process(HttpListener httpListener) {
        while (true) {
            var connection = httpListener.GetContextAsync();
            await connection;

            // prepare the result for dispatch to a processing queue.
            var request = new ServiceRequestHttp(this, connection.Result);
            if (!request.Refused) {
                return request;
                }
            else {

                }
            }
        }

    static async Task<ServiceRequest> Process(UdpClient UdpClient) {
        var connection = UdpClient.ReceiveAsync();

        await connection;
        return new ServiceRequestUdp(connection.Result);
        }
    #endregion
    }
