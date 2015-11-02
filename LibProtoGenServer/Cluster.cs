using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using Goedel.Registry;
using Goedel.Protocol;

namespace Goedel.Protocol {

    public class ServerFactoryEntry {
        public ServerFactory ServerFactory;
        public string Handle;
        public bool Connection;

        public ServerFactoryEntry(ServerFactory ServerFactory, string Handle,
                        bool Connection) {
            this.ServerFactory = ServerFactory;
            this.Handle = Handle;
            this.Connection = Connection;
            }
        }


    public class ServiceInterfaceInstance {
        public AuthenticatedServer      Server;
        public ServiceInterface         Interface;

        public ServiceInterfaceInstance(AuthenticatedServer Server,
                ServiceInterface Interface) {
            this.Server = Server;
            this.Interface = Interface;
            }

        }

    public class ServerCluster {
        Config      Config;
        public Cluster     Cluster;

        public List<ServerFactoryEntry> ServerFactoryEntries = 
                new List<ServerFactoryEntry>();

        public List<AuthenticatedServer> ServerInstances = 
                new List<AuthenticatedServer>();
        public List<AuthenticatedServer> ConnectServerInstances = 
                new List<AuthenticatedServer>();


        // Bogus?
        //public List<ServerIdentifier> ServerIdentifiers = 
        //        new List<ServerIdentifier>();

        //// The list of registered service providers
        //public List<Dispatch> DispatchCallbacks = new List<Dispatch>();

        //// The service providers to call when a service instance is created
        //public List<Dispatch> InstanceCallbacks = new List<Dispatch>();


        EventWaitHandle SignalOnStart, Signal;
        public MultiTransportServer OmniServer;


        public ServerCluster (Config Config, string Handle) {
            Console.WriteLine("Starting Server");
            this.Config = Config;
            Cluster     = Config.GetCluster (Handle);
            }


        public void RegisterService(ServerFactory ServerFactory, string Handle, 
                        bool Connection) {
            var    ServerFactoryEntry = new ServerFactoryEntry (
                ServerFactory, Handle, Connection);
            ServerFactoryEntries.Add (ServerFactoryEntry);
            }


        public void RegisterService(ServerFactory ServerFactory, string Handle) {
            RegisterService (ServerFactory, Handle, false);
            }


        public void ConnectServices() {
            foreach (var ConnectServer in ConnectServerInstances) {
                foreach (var Server in ServerInstances) {
                    if (ConnectServer != Server) {
                        ConnectServer.RegisterService(Server);
                        }
                    }
                }
            }


        //public void InstanceCallback(Dispatch Dispatch) {
        //    InstanceCallbacks.Add(Dispatch);
        //    }


        public ServerFactoryEntry GetService(string Handle) {
            foreach (var ServerFactoryEntry in ServerFactoryEntries) {
                if (ServerFactoryEntry.Handle == Handle) {
                    return ServerFactoryEntry;
                    }
                }
            return null;
            }

        public AuthenticatedServer StartService(Service Service) {
            AuthenticatedServer  ServerInstance;
            
            var ServerIdentifier = GetService (Service.Server);
            if (ServerIdentifier == null) 
                throw new Exception ("Service not implemented " + Service.Server);

            ServerInstance = ServerIdentifier.ServerFactory (Service);


            Console.WriteLine ("Stated service {0}", Service.Server);

            ServerInstance.ServerCluster = this;
            ServerInstances.Add (ServerInstance);

            if (ServerIdentifier.Connection) {
                ConnectServerInstances.Add (ServerInstance);
                }

            return ServerInstance;
            }


        public void Instance() {
            OmniServer.AsyncListener(SignalOnStart, Signal);
            }

        Thread oThread;
        public void Start() {
            

            OmniServer = new MultiTransportServer (this);

            SignalOnStart = new EventWaitHandle (false, EventResetMode.AutoReset);
            Signal = new EventWaitHandle (false, EventResetMode.AutoReset);
            oThread = new Thread (new ThreadStart (this.Instance));
            oThread.Start ();

            SignalOnStart.WaitOne ();
            }

        public void Stop() {
            OmniServer.Active = false;
            Signal.Set (); // signal the server to stop
            }

        }
    }
