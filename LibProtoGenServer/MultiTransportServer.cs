using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Text;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using Goedel.Registry;
using Goedel.Protocol;




namespace Goedel.Protocol {

    public class ServiceInstance {
        public string Prefix;
        public AuthenticatedServer Server;
        public Uri Uri;
        public string Stem;
        public Interface Interface;
        public int Priority = 100;
        public int Weight = 100;
        public Dispatch Dispatch;

        public string WellKnown;

        public bool WebService;

        public ServiceInstance(Interface Interface,
                    Dispatch Dispatch, AuthenticatedServer Server) {

            var WellKnown = Dispatch.Handle;

            this.WellKnown = WellKnown;
            this.Interface = Interface;
            this.Prefix = Interface.Prefix + ".well-known/" + WellKnown + "/";
            this.Dispatch = Dispatch;
            this.Server = Server;

            if (Interface.Is._Tag() == ConfigureType.UDP) {
                this.Uri = null;
                this.Stem = null;
                WebService = false;
                }
            else {
                this.Uri = new Uri(Prefix);
                this.Stem = Uri.AbsolutePath;
                WebService = true;
                }
            }


        }


    public class MultiTransportServer {
        static string HTTPIntegrityHeader = "Session";

        public List<ServiceInstance> Instances = new List<ServiceInstance>();

        public List<ServiceInstance> HTTPInstances = new List<ServiceInstance>();
        public List<ServiceInstance> UDPInstances = new List<ServiceInstance>();


        public bool Active;
        //Cluster         Cluster;
        ServerCluster ServerCluster;

        public int Timeout = 1000;
        public HttpListener Listener = new HttpListener();


        public ServiceInstance GetInstance(string URI) {
            foreach (ServiceInstance Instance in Instances) {
            if (Instance.Stem != null) {
                if (URI.StartsWith(Instance.Stem)) {
                    return Instance;
                    }
                }
                }
            return null;
            }

        int AsyncWaitHandles = 2;

        public MultiTransportServer(ServerCluster ServerCluster) {
            if (!HttpListener.IsSupported) {
                throw new Exception("Platform not supported");
                }

            this.ServerCluster = ServerCluster;

            //foreach (var Service in Cluster.Interfaces) {

            //    }

            foreach (var Service in ServerCluster.Cluster.Services) {
                var Server = Service.StartService(ServerCluster);

                //var ServerIdentifier = Service.ServerInstance.ServerIdentifierProperty;

                foreach (var On in Service.Interfaces) {
                    foreach (var Dispatch in Service.ServerInstance.Dispatchers) {
                        var ServiceInstance = new ServiceInstance(On.Interface, Dispatch, Server);

                        Instances.Add(ServiceInstance);

                        if (On.Interface.Is._Tag() == ConfigureType.UDP) {
                            Console.WriteLine("Add to UDP listener!  {0}", On.Interface.Id.Label);
                            UDPInstances.Add(ServiceInstance);
                            }
                        else if (On.Interface.Is._Tag() == ConfigureType.HTTP) {
                            Console.WriteLine("Add to HTTP listener!  {0}", On.Interface.Id.Label);
                            HTTPInstances.Add(ServiceInstance);
                            }
                        }
                    }
                }


            ServerCluster.ConnectServices ();
            }


        // can only have one active server per object instance, should set up a guard on this
        public void AsyncListener(EventWaitHandle SignalOnStart, EventWaitHandle Signal) {
            Active = true;


            foreach (ServiceInstance Instance in HTTPInstances) {
                Listener.Prefixes.Add(Instance.Prefix);
                Console.WriteLine("Listen to: {0}", Instance.Prefix);
                }


            Listener.Start();
            Console.WriteLine("Listening...");

            if (SignalOnStart != null) {
                SignalOnStart.Set();     // Tell the calling thread server is started.
                }


            WaitHandle[] WaitHandles = new EventWaitHandle[AsyncWaitHandles];
            List<IAsyncResult> Results = new List<IAsyncResult>();

            WaitHandles[0] = Signal;

            IAsyncResult PendingHTTPResult = Listener.BeginGetContext(
                    new AsyncCallback(HTTPListenerCallback), this);
            WaitHandles[1] = PendingHTTPResult.AsyncWaitHandle;



            while (Active) {
                int Index = EventWaitHandle.WaitAny(WaitHandles, -1);

                if (Index == 1) {
                    Console.WriteLine("HTTP Event!");

                    PendingHTTPResult = Listener.BeginGetContext(
                            new AsyncCallback(HTTPListenerCallback), this);
                    WaitHandles[1] = PendingHTTPResult.AsyncWaitHandle;
                    }
                else {
                    Console.WriteLine("Tick!");
                    }
                }

            Console.WriteLine("... talk to the hand !");

            Listener.Stop();
            }

        public static void HTTPListenerCallback(IAsyncResult result) {

            Console.WriteLine("Got a http request!");

            var Server = (MultiTransportServer)result.AsyncState;
            if (Server.Active) {
                HttpListener Listener = Server.Listener;
                HttpListenerContext context = Listener.EndGetContext(result);
                Server.HandleContext(context);
                }
            }


        public void HandleContext(HttpListenerContext Context) {
            HttpListenerRequest Request = Context.Request;
            HttpListenerResponse Response = Context.Response;
            BoundResponse BoundResponse = null;

            Console.WriteLine("Request: {0} {1}  Length {2}",
                Request.HttpMethod, Request.RawUrl, Request.ContentLength64);

            string Content;

            string[] IntegrityHeaders = Request.Headers.GetValues(HTTPIntegrityHeader);
            if (IntegrityHeaders != null) {
                foreach (string IntegrityHeader in IntegrityHeaders) {
                    Console.WriteLine("Integrity: {0}", IntegrityHeader);
                    }
                }
            else {
                Console.WriteLine("No Integrity header");
                }

            // Get the content 
            Stream body = Request.InputStream;
            Encoding encoding = Request.ContentEncoding;
            StreamReader Reader = new StreamReader(body, encoding);
            Content = Reader.ReadToEnd();
            Console.WriteLine(Content);
            Console.WriteLine("-----------");

            BoundRequest BoundRequest = new BoundRequest(Content);

            // Extract the MAC and Ticket fields from the header if present
            if (IntegrityHeaders != null) {
                CryptographicContext.ParseIntegrityHeader(IntegrityHeaders[0],
                    out BoundRequest.MAC, out BoundRequest.Ticket);
                }

            ServiceInstance Instance = GetInstance(Request.RawUrl);
            if (Instance == null) {
                BadRequest(Response);
                }

            BoundResponse = Instance.Dispatch.BoundDispatch (BoundRequest);

            Response.StatusCode = BoundResponse.Status;
            Response.StatusDescription = BoundResponse.StatusDescription;

            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(BoundResponse.Payload);

            Response.ContentLength64 = buffer.Length;

            Stream output = Response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
            }

        void BadRequest(HttpListenerResponse Response) {
            Response.StatusCode = 404;
            Response.StatusDescription = "Not Found";
            }
        }

    }
