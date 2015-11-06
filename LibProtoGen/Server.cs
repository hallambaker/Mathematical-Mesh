using System;
using System.Collections.Generic;
using System.Net;

namespace Goedel.Protocol {

    /*
    *   Items described here:
    *
    *   Port - URI or UDP port to which requests are directed.
    *   Interface [Service] - The set of requests supported by that port
    *   Provider [Host] - A set of related interfaces that share state.
    *   Server - An executable that supports one or more providers.
    *   Service - A group of servers that offer semantically equivalent service.
    *
    */




    /// <summary>
    /// Describes a server port connection.
    /// </summary>
    public abstract class PortRegistration {

        /// <summary>
        /// Register this port on the server.
        /// </summary>
        public abstract void Open();

        /// <summary>
        /// Close this port and deregister.
        /// </summary>
        public abstract void Close();

        }

    /// <summary>
    /// Describes a HTTP server port connection.
    /// </summary>
    public class HTTPPortRegistration : PortRegistration {

        /// <summary>
        /// The HTTP service URI stem
        /// </summary>
        public string URI;

        /// <summary>
        /// The Registered service.
        /// </summary>
        public HostRegistration Host;

        /// <summary>
        /// Register this port with the server. Note the port will not 
        /// be called until it is registered.
        /// </summary>
        /// <param name="URI">HTTP URI to register.</param>
        /// <param name="Host">Service Provider to register.</param>
        public HTTPPortRegistration (string URI, HostRegistration Host) {
            this.URI = URI;
            this.Host = Host;
            }

        /// <summary>
        /// Close this port and deregister.
        /// </summary>
        public override void Open() {

            }

        /// <summary>
        /// Close this port and deregister.
        /// </summary>
        public override void Close() {

            }

        }

    /// <summary>
    /// Track registration of an interface.
    /// </summary>
    public class InterfaceRegistration {



        }


    /// <summary>
    /// Represents a specific service provider.
    /// </summary>
    public class HostRegistration {
        JPCServer JPCServer;
        JPCProvider JPCHost;

        List<PortRegistration> Ports;

        /// <summary>
        /// Create a host registration.
        /// </summary>
        /// <param name="JPCHost">Service provider to register</param>
        /// <param name="JPCServer">Server to register to.</param>
        public HostRegistration(JPCProvider JPCHost, JPCServer JPCServer) {
            this.JPCServer = JPCServer;
            this.JPCHost = JPCHost;
            Ports = new List<PortRegistration>();
            }

        /// <summary>
        /// Register a HTTP Port.
        /// </summary>
        /// <param name="URI">URI to register port at. If zero, a 
        /// random port is chosen and may be read from the port
        /// registration structure returned.</param>
        /// <returns>The port registration structure.</returns>
        public HTTPPortRegistration AddHTTP (string URI) {

            var HTTPPortRegistration = new HTTPPortRegistration(URI, this);
            Ports.Add(HTTPPortRegistration);

            return HTTPPortRegistration;
            }

        /// <summary>
        /// Register a service at the standard HTTP port.
        /// </summary>
        /// <param name="URI">URI to register port at. If zero, a 
        /// random port is chosen and may be read from the port
        /// registration structure returned.</param>
        /// <returns>The port registration structure.</returns>
        public HTTPPortRegistration AddService(string Domain) {

            var URI = JPCProvider.WellKnownToURI(Domain, 
                        JPCHost.JPCInterface.GetWellKnown, false);
            return AddHTTP(URI);
            }


        /// <summary>
        /// Register a UDP Port, not currently implemented.
        /// </summary>
        /// <param name="port">The UDP port to register the service at.
        /// </param>
        /// <returns></returns>
        public PortRegistration AddUDP(int port) {
            return null;
            }


        /// <summary>
        /// Register connected ports.
        /// </summary>
        public  void Open() {
            foreach (var Port in Ports) {
                Port.Open();
                }
            }

        /// <summary>
        /// Deregister connected ports.
        /// </summary>
        public  void Close() {
            foreach (var Port in Ports) {
                Port.Close();
                }
            }




        }

    /// <summary>
    /// Server object for multiple objects and services.
    /// </summary>
    /// <example>
    /// var Server = new JPCServer ();
    /// var HostReg = Server.Add (MyServiceProvider);
    /// var PortReg = HostReg.AddHTTP ("http://localhost/MyService/");
    /// </example>
    public class JPCServer {

        List<HostRegistration> Hosts;

        /// <summary>
        /// Create a server.
        /// </summary>
        public JPCServer() {
            Hosts = new List<HostRegistration>();
            }

        /// <summary>
        /// Add a service provider.
        /// </summary>
        /// <param name="JPCHost">The Service provider to add.</param>
        /// <returns>Host registration object.</returns>
        public HostRegistration Add(JPCProvider JPCHost) {
            var Registration = new HostRegistration(JPCHost, this);
            Hosts.Add(Registration);

            return Registration;
            }


        bool Active;

        /// <summary>
        /// The HTTP Listener.
        /// </summary>
        public HttpListener HttpListener;


        /// <summary>
        /// Blocking listener, reads one request at a time, blocking
        /// between each read.
        /// </summary>
        private void ListenBlocking() {

            Active = true;
            HttpListener = new HttpListener();
            foreach (var Host in Hosts) {
                Host.Open();
                }


            while (Active) {
                var Context = HttpListener.GetContext();
                Handle(Context);
                }

            }


        private void Handle (HttpListenerContext Context) {
            // Which provider handles this URI?

            

            // Get request data

            // Authenticate request data

            // Call dispatcher


            // Handle errors


                // Service not found
                // Authentication error
                // Error thrown by provider.

            }


        /// <summary>
        /// Start the server. Note that the server runs in a separate
        /// thread and so control returns to the main loop.
        /// </summary>
        public void StartAsync () {

            }

        /// <summary>
        /// Start the server and wait for completion using the unthreaded
        /// listener. Useful for tracking down locking and synchronization 
        /// bugs.
        /// </summary>
        public void RunBlocking () {
            ListenBlocking();
            }

        /// <summary>
        /// Stop the server.
        /// </summary>
        public void Stop () {
            Active = false;
            }


        }
    }
