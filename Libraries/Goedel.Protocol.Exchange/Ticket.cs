using System.IO;
using System.Collections.Generic;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
//using Goedel.Cryptography.Ticket;

namespace Goedel.Protocol.Exchange {

    /// <summary>
    /// Represents a ticket.
    /// </summary>
    public partial class ExchangeTicket {



        //byte[] SessionKey;
        //byte[] Ticket;

        /// <summary>
        /// Content type description.
        /// </summary>
        public virtual string ContentType => "application/json";

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="Service">The service the ticket was constructed for</param>
        /// <param name="Key">The key the ticket was constructed for</param>
        public ExchangeTicket (string Service, Key Key) {


            }

        /// <summary>
        /// Construct from service response.
        /// </summary>
        /// <param name="Response">Response from the service.</param>
        public ExchangeTicket (ExchangeResponse Response) {
            var Ticket = Response.Ticket;


            }


        readonly static byte[] EmptyBytes = new byte[0];

        /// <summary>
        /// Begin a message
        /// </summary>
        /// <returns>Encoded bytes</returns>
        public virtual byte[] BeginMessage() => EmptyBytes;

        /// <summary>
        /// Encode payload.
        /// </summary>
        /// <param name="Payload">The payload to encode.</param>
        /// <returns>Encoded bytes</returns>
        public virtual byte[] Encode(byte[] Payload) => Payload;

        /// <summary>
        /// Encode trailer
        /// </summary>
        /// <returns>Encoded bytes</returns>
        public virtual byte[] EndMessage() => EmptyBytes;


        /// <summary>
        /// Encode a JSON Object as payload.
        /// </summary>
        /// <param name="PayloadObject">The object to encode.</param>
        /// <returns>Encoded bytes</returns>
        public byte[] Encode(JSONObject PayloadObject) => Encode(PayloadObject.GetBytes());

        /// <summary>
        /// Begin message encoding to stream.
        /// </summary>
        /// <param name="Stream">Output stream</param>
        public virtual void BeginMessage (MemoryStream Stream) {
            var Data = BeginMessage();
            Stream.Write(Data, 0, Data.Length);
            return;
            }

        /// <summary>
        /// Encode content to stream.
        /// </summary>
        /// <param name="Stream">Output stream</param>
        /// <param name="Content">Input content.</param>
        public virtual void Encode (MemoryStream Stream, MemoryStream Content) {
            var Data = Content.ToArray();
            Stream.Write(Data, 0, Data.Length);
            return;
            }

        /// <summary>
        /// End message encoding to stream
        /// </summary>
        /// <param name="Stream">Output stream</param>
        public virtual void EndMessage (MemoryStream Stream) {
            var Data = EndMessage();
            Stream.Write(Data, 0, Data.Length);
            return;
            }

        }


    }
