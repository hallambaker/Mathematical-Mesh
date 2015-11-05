using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.Protocol {

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
    /// Represents a specific service provider.
    /// </summary>
    public class HostRegistration {
        JPCServer JPCServer;
        JPCHost JPCHost;

        /// <summary>
        /// Create a host registration.
        /// </summary>
        /// <param name="JPCHost">Service provider to register</param>
        /// <param name="JPCServer">Server to register to.</param>
        public HostRegistration(JPCHost JPCHost, JPCServer JPCServer) {
            this.JPCServer = JPCServer;
            this.JPCHost = JPCHost;
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

            return null;
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
        public HostRegistration Add(JPCHost JPCHost) {
            var Registration = new HostRegistration(JPCHost, this);
            Hosts.Add(Registration);

            return Registration;
            }

        /// <summary>
        /// Start the server. Note that the server runs in a separate
        /// thread and so control returns to the main loop.
        /// </summary>
        public void StartAsync () {

            }

        /// <summary>
        /// Start the server and wait for completion.
        /// </summary>
        public void Run () {

            }

        /// <summary>
        /// Stop the server.
        /// </summary>
        public void Stop () {

            }


        }
    }
