using System;
using System.Net;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Sockets;

using Goedel.Protocol;
using Goedel.Utilities;

namespace Goedel.Protocol.Service {
    /// <summary>
    /// Base class for connection handlers
    /// </summary>
    public abstract class Connection {

        ///<summary>The maximum request size</summary> 
        public const int MaxRequest = 0x10000;



        ///<summary>Specifies a resouce that is under contention, e.g. an account or the 
        ///account catalog. This allows requests for the same resource to be queued for
        ///dispatch after the blocking requests have completed.</summary> 
        public string Resource { get; protected set; } = null;

        ///<summary></summary> 
        public int Slot;

        ///<summary></summary> 
        public Service Service;

        /// <summary>
        /// Process the connection, dispatch the request and return the result.
        /// </summary>
        public abstract void Complete();

        }


    /// <summary>
    /// Connection handler for HTTP request
    /// </summary>
    public class ConnectionHttp : Connection {
        HttpListenerContext ListenerContext { get; }

        /// <summary>
        /// Constructor returning an instance to process the request 
        /// specified by <paramref name="listenerContext"/>.
        /// </summary>
        /// <param name="listenerContext">The HTTP request context.</param>
        public ConnectionHttp(HttpListenerContext listenerContext) => ListenerContext = listenerContext;

        /// <summary>
        /// Process the connection, dispatch the request and return the result.
        /// </summary>
        public override void Complete() {
            Service.Monitor.StartDispatch(Slot);

            var request = ListenerContext.Request;

            // get the provider here - if null - abort
            var provider = Service.GetProvider(
                    request.ServiceName, request.LocalEndPoint.Port, request.RawUrl);

            provider.AssertNotNull(NYI.Throw);

            request.InputStream.AssertNotNull(NYI.Throw);

            // Read the input stream until either it is closed or 64KB have been read
            var buffer = new byte[MaxRequest];
            var count = 0;
            var read = 1;
            while (count < MaxRequest & read > 0) {
                read = request.InputStream.Read(buffer, count, MaxRequest - count);
                count += read;
                }
            (count < MaxRequest).AssertTrue(NYI.Throw);

            // need to expand this signature so that the authentication data can be added in...
            var session = provider.JpcInterface.GetSession();

            var reader = new JsonReader(buffer);

            // Dispatch the request
            var result = provider.JpcInterface.Dispatch(session, reader);

            var response = ListenerContext.Response;
            response.StatusCode = (int)HttpStatusCode.OK;
            response.StatusDescription = "OK";
            response.KeepAlive = true;

            var jsonWriter = new JsonWriter(response.OutputStream);
            result.Serialize(jsonWriter, true);
            response.OutputStream.Close();

            Service.Monitor.EndDispatch(Slot);
            }
        }

    /// <summary>
    /// Connection handler for UDP request
    /// </summary>
    public class ConnectionUdp : Connection {
        byte[] Buffer { get; }

        /// <summary>
        /// Constructor, process the request contained in <paramref name="result"/>.
        /// </summary>
        /// <param name="result">The UDP receive result</param>
        public ConnectionUdp(UdpReceiveResult result) => Buffer = result.Buffer;

        /// <summary>
        /// Process the connection, dispatch the request and return the result.
        /// </summary>
        public override void Complete() {
            }

        }
    }
