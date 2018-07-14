//   Copyright © 2015 by Comodo Group Inc.
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
//  
//  

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Diagnostics;
using Goedel.Utilities;

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

        /// <summary>
        /// The Registered service.
        /// </summary>
        public InterfaceRegistration Interface;

        /// <summary>
        /// The provider to dispatch to.
        /// </summary>
        public JPCProvider Provider;

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
        /// Register this port with the server. Note the port will not 
        /// be called until it is registered.
        /// </summary>
        /// <param name="URI">HTTP URI to register.</param>
        /// <param name="Host">Service Provider to register.</param>
        public HTTPPortRegistration (string URI, InterfaceRegistration Host) {
            this.URI = URI;
            this.Interface = Host;
            }

        /// <summary>
        /// Open this port and Register.
        /// </summary>
        public override void Open() {
            Provider = Interface.ProviderRegistration.JPCProvider;
            var JPCServer = Interface.ProviderRegistration.JPCServer;
            JPCServer.Register(this);

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

        /// <summary>The provider of the service. A provider may be registered
        /// at more than one server.</summary>
        public ProviderRegistration ProviderRegistration;
        /// <summary>The provider interface</summary>
        public JPCInterface Interface;

        List<PortRegistration> Ports;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="Interface">The provider interface.</param>
        /// <param name="ProviderRegistration">The provider.</param>
        public InterfaceRegistration (JPCInterface Interface, 
                    ProviderRegistration ProviderRegistration) {
            this.Interface = Interface;
            this.ProviderRegistration = ProviderRegistration;
            Ports = new List<PortRegistration>();
            }

        /// <summary>
        /// Register a HTTP Port.
        /// </summary>
        /// <param name="URI">URI to register port at. If zero, a 
        /// random port is chosen and may be read from the port
        /// registration structure returned.</param>
        /// <returns>The port registration structure.</returns>
        public HTTPPortRegistration AddHTTP(string URI) {

            var HTTPPortRegistration = new HTTPPortRegistration(URI, this);
            Ports.Add(HTTPPortRegistration);

            return HTTPPortRegistration;
            }

        /// <summary>
        /// Register a service at the standard HTTP port.
        /// </summary>
        /// <param name="Domain">DNS domain to register service to</param>
        /// <returns>The port registration structure.</returns>
        public HTTPPortRegistration AddService(string Domain) {

            var URI = JPCProvider.WellKnownToURI(Domain, Interface.GetWellKnown,
                Interface.GetDiscovery, false, true);
            return AddHTTP(URI);
            }


        /// <summary>
        /// Register a UDP Port, not currently implemented.
        /// </summary>
        /// <param name="port">The UDP port to register the service at.
        /// </param>
        /// <returns>The port registration created</returns>
        /// <exception cref="NYI">Not Yet Implemented</exception> 
        public PortRegistration AddUDP(int port) => throw NYI.Throw("Need to add implementation of Add UDP");//return null;

        /// <summary>
        /// Register connected ports.
        /// </summary>
        public void Open() {
            foreach (var Port in Ports) {
                Port.Open();
                }
            }

        /// <summary>
        /// Deregister connected ports.
        /// </summary>
        public void Close() {
            foreach (var Port in Ports) {
                Port.Close();
                }
            }


        }


    /// <summary>
    /// Represents a specific service provider.
    /// </summary>
    public class ProviderRegistration {
        /// <summary>The JPC Server</summary>
        public JPCServer JPCServer;
        /// <summary>The JPC Provider.</summary>
        public JPCProvider JPCProvider;

        List<InterfaceRegistration> Interfaces;


        /// <summary>
        /// Create a host registration.
        /// </summary>
        /// <param name="JPCHost">Service provider to register</param>
        /// <param name="JPCServer">Server to register to.</param>
        public ProviderRegistration(JPCProvider JPCHost, JPCServer JPCServer) {
            this.JPCServer = JPCServer;
            this.JPCProvider = JPCHost;
            Interfaces = new List<InterfaceRegistration>();
            }

        /// <summary>
        /// Add an interface.
        /// </summary>
        /// <param name="Interface">Interface to add,</param>
        /// <returns>Registration of interface.</returns>
        public InterfaceRegistration Add (JPCInterface Interface) {
            var InterfaceRegistration = new InterfaceRegistration (Interface, this);
            Interfaces.Add(InterfaceRegistration);

            return InterfaceRegistration;
            }

        /// <summary>
        /// Register connected ports.
        /// </summary>
        public  void Open() {
            foreach (var Interface in Interfaces) {
                Interface.Open();
                }
            }

        /// <summary>
        /// Deregister connected ports.
        /// </summary>
        public  void Close() {
            foreach (var Interface in Interfaces) {
                Interface.Close();
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

        List<ProviderRegistration> Hosts;
        List<PortRegistration> Ports;

        /// <summary>
        /// Create a server.
        /// </summary>
        public JPCServer() {
            Hosts = new List<ProviderRegistration>();
            Ports = new List<PortRegistration>();
            }

        /// <summary>
        /// Add a service provider.
        /// </summary>
        /// <param name="JPCHost">The Service provider to add.</param>
        /// <returns>Host registration object.</returns>
        public ProviderRegistration Add(JPCProvider JPCHost) {
            var Registration = new ProviderRegistration(JPCHost, this);
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

            //Trace.WriteLine("Start Listener");
            HttpListener.Start();
            while (Active) {
                //Trace.Write("Wait..");
                var Context = HttpListener.GetContext();
                //Trace.WriteLine("Dispatch");
                Handle(Context);
                }

            }

        private PortRegistration GetPort (List<PortRegistration> Ports, Uri URI) {
            foreach (var Port in Ports) {
                var HTTPPort = Port as HTTPPortRegistration;
                if (URI.AbsoluteUri == HTTPPort.URI) {
                    return Port;
                    }
                }
            return null;
            }


        private void Handle (HttpListenerContext Context) {
            Stream RequestStream = null, ResponseStream=null;
            try {
                // Get request data

                // This is not a very good implementation since it
                // lacks speed and support for authentication. But it is best to
                // add both at the same time.

                var Request = Context.Request;
                var Encoding = Request.ContentEncoding;
                RequestStream = Request.InputStream;

                var Port = GetPort  (Ports, Request.Url);   

                //var Reader = new StreamReader(RequestStream, Encoding);
                //var RequestBody = Reader.ReadToEnd();

                var RequestBody = Dechunk.ReadString(Request.ContentLength64, RequestStream);
                RequestStream.Close();

                // Authenticate request data
                // Not yet implemented.

                //Trace.WriteLine(RequestBody);

                // Call dispatcher
                var JSONReader = new JSONReader(RequestBody);
                var ResponseObject = Port.Provider.Dispatch(null, JSONReader);

                var ResponseBody = ResponseObject.ToString();
                var Buffer = System.Text.Encoding.UTF8.GetBytes(ResponseBody);

                var Response = Context.Response;
                Response.ContentType = "application/json";
                Response.ContentLength64 = Buffer.Length;
                ResponseStream = Response.OutputStream;
                ResponseStream.Write(Buffer, 0, Buffer.Length);
                }

            // Handle errors


            // Service not found
            // Authentication error
            // Error thrown by provider.

            finally {
                // Make certain all stream objects are cleaned up.
                if (RequestStream != null) { RequestStream.Close(); }
                if (ResponseStream != null) { ResponseStream.Close(); }
                }
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
        public void RunBlocking() => ListenBlocking();

        /// <summary>
        /// Stop the server.
        /// </summary>
        public void Stop() => Active = false;

        /// <summary>
        /// Register listener port.
        /// </summary>
        /// <param name="Port">Port to add listener on.</param>
        public void Register(HTTPPortRegistration Port) {
            Ports.Add(Port);
            HttpListener.Prefixes.Add(Port.URI);

            Trace.WriteLine("Add Listener on {0}", Port.URI);
            }

        }
    }
