﻿using System;
using System.Net;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Sockets;

using Goedel.Protocol;
using Goedel.Utilities;

namespace Goedel.Protocol.Service {
    public class Service : Disposable {



        ///<summary>Maximum number of concurrent worker processes.</summary> 
        public int MaxDispatch { get; }

        ///<summary>Timeout for action on a worker thread.</summary> 
        public int Timeout { get; set; }  = 60 * 1000;

        bool active = true;


        public int Concurrent => concurrent;

        private int concurrent = 0;

        private Thread serviceThread;



        private Task<Connection>[] serviceTasks;

        private HttpListener httpListener=null;

        private UdpClient[] udpListeners;

        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken cancellationToken ;
        private int udpListenerCount;
        private int httpListenerCount = 1;
        private int ListenerCount => udpListenerCount + httpListenerCount;

        Task nullTask;
        Task[] dispatchTasks;
        string[] dispatchTaskResource;
        bool[] dispatchTaskActive;


        public DateTime ServiceStarted { get;  }




        public Monitor Monitor ;





        protected override void Disposing() {

            // Set the state to inactive
            active = false;
            cancellationTokenSource.Cancel();

            // shut down the HTTP and UDP listeners.
            httpListener?.Close();
            foreach (var listener in udpListeners) {
                listener?.Close();
                }

            }




        public Service(List<Provider> providers, int maxCores = 0) {

            cancellationTokenSource = new CancellationTokenSource();
            cancellationToken = cancellationTokenSource.Token;

            // set the number of dispatch tasks
            MaxDispatch = maxCores > 0 ? maxCores : Environment.ProcessorCount;

            // Set up the dispatchers
            //nullTask = Task.Run(NullTask);
            dispatchTasks = new Task[MaxDispatch];
            dispatchTaskResource = new string[MaxDispatch];
            dispatchTaskActive = new bool[MaxDispatch];
            for (var i = 0; i < MaxDispatch; i++) {
                dispatchTasks[i] = Task.Run (NullTask) ;
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
                    var uri = endpoint.Uri();
                    Screen.WriteLine($"Connect to URI {uri}");
                    httpListener.Prefixes.Add(uri);
                    }
                udpListenerCount += provider.UdpEndpoints.Count;
                }


            // Start the monitoring service
            Monitor = new Monitor(ListenerCount, MaxDispatch);
            serviceTasks = new Task<Connection>[ListenerCount];

            httpListener.Start();

            WaitHttpRequest();
            // set up the UDP clients...
            udpListeners = new UdpClient[udpListenerCount];
            var listener = 0;
            foreach (var provider in providers) {
                foreach (var endpoint in provider.UdpEndpoints) {
                    udpListeners[listener] = endpoint.GetClient();
                    WaitUdpListener(listener);
                    listener++;
                    }
                }

            // start the asynchronous services before returning.
            serviceThread = new Thread (WaitService);
            serviceThread.Start();
            }


        void WaitService() {

            while (active) {
                try {
                    Task.WaitAny(serviceTasks, cancellationToken);

                    // Dispatch a processing unit to the next available slot.
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

                catch (OperationCanceledException){
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
            for (var i=0; i< udpListeners.Length; i++) {
                udpListeners[i].Close(); // Gracefull termination of the UDP Listeners
                udpListeners[i] = null;
                }
            }


        // Dispatch completion of the specified connection.
        void Dispatch(Connection connection) {

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


        async Task<Connection> Process(HttpListener httpListener) {
            var connection = httpListener.GetContextAsync();
            await connection;

            // prepare the result for dispatch to a processing queue.
            return new ConnectionHttp(connection.Result);
            }
        async Task<Connection> Process(UdpClient UdpClient) {
            var connection = UdpClient.ReceiveAsync();

            await connection;
            return new ConnectionUdp(connection.Result);
            }

        }

    /// <summary>
    /// Base class for connection handlers
    /// </summary>
    public abstract class Connection {
        public string Resource { get; protected set; } = null;
        public int Slot;
        public Service Service;

        /// <summary>
        /// Process the connection, dispatch the request and return the result.
        /// </summary>
        public abstract void Complete();

        }

    /// <summary>
    /// Connection handler for HTTP request
    /// </summary>
    public class ConnectionHttp : Connection  {
        HttpListenerContext ListenerContext { get; }
        public ConnectionHttp(HttpListenerContext listenerContext) {
            ListenerContext = listenerContext;
            }

        /// <summary>
        /// Process the connection, dispatch the request and return the result.
        /// </summary>
        public override void Complete() {
            Service.Monitor.StartDispatch(Slot);


            var response = ListenerContext.Response;
            response.StatusCode = (int)HttpStatusCode.OK;
            response.StatusDescription = "OK";
            response.KeepAlive = true;

            var result = "Result".ToUTF8();


            response.ContentLength64 = result.Length;
            using (var stream = response.OutputStream) {
                stream.Write(result, 0, result.Length);
                stream.Close();
                }


            // Which resource is the request directed at?


            // Is the content length too long?


            // Get body


            // Authenticate




            Service.Monitor.EndDispatch(Slot);
            }
        }

    /// <summary>
    /// Connection handler for UDP request
    /// </summary>
    public class ConnectionUdp : Connection {
        byte[] Buffer { get; }

        /// <summary>
        /// Constructor, process the request contained in <paramref name="buffer"/>.
        /// </summary>
        /// <param name="result">The UDP receive result</param>
        public ConnectionUdp(UdpReceiveResult result) {
            Buffer = result.Buffer;
            }

        /// <summary>
        /// Process the connection, dispatch the request and return the result.
        /// </summary>
        public override void Complete() {
            }

        }
    }
