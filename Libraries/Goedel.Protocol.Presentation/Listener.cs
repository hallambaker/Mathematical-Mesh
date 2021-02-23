using System.Threading.Tasks;


namespace Goedel.Protocol.Presentation {
    /// <summary>
    /// Base class for presentation listeners.
    /// </summary>
    public abstract partial class Listener {

        /// <summary>
        /// Request establishment of a client connection to the endpoint 
        /// <paramref name="destinationId"/> 
        /// </summary>
        /// <param name="destinationId">The endpoint to connect to.</param>
        /// <param name="payload">Optional payload. Note that this is sent enclair if
        /// <paramref name="hostCredential"/> is null.</param>
        /// <param name="hostCredential">The host credential. If not null, the payload 
        /// is sent encrypted under this credential.</param>
        /// <returns></returns>
        public abstract ConnectionClient GetConnectionClient(
                    PortId destinationId,
                    byte[] payload = null,
                    Credential hostCredential = null);


        /// <summary>
        /// Accept the inbound connection request described in <paramref name="packetRequest"/>.
        /// </summary>
        /// <param name="packetRequest">Parsed inbound request packet.</param>
        /// <param name="payload">Optional payload response. This is always encryted under the host credential
        /// at minimum.</param>
        /// <returns>The host connection. This may be used to wait for inbound requests from the 
        /// connection.</returns>
        public abstract ConnectionHost Accept(
                    Packet packetRequest,
                    byte[] payload = null);

        /// <summary>
        /// Defer creation of a host connection by sending a challenge to the source.
        /// </summary>
        /// <param name="packetRequest">Parsed inbound request packet.</param>
        /// <param name="payload">Optional payload response. This is always returned enclair.</param>
        public abstract void Challenge(
                    Packet packetRequest,
                    byte[] payload = null);

        /// <summary>
        /// Refuse an inbound connection.
        /// </summary>
        /// <param name="packetRequest">Parsed inbound request packet.</param>
        /// <param name="payload">Optional payload response. This is always returned enclair.</param>
        public abstract void Reject(
                    Packet packetRequest,
                    byte[] payload = null);


        }

    }
