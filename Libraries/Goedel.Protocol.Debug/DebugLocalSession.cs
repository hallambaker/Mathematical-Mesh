using System.IO;


namespace Goedel.Protocol.Debug {



    /// <summary>
    /// Direct connection between client and service host with messages 
    /// encoded and decoded from JSON. For use in debugging issues that
    /// might be the result of JSON encoding issues and to collect samples
    /// for documentation.
    /// </summary>
    public class DebugLocalSession : LocalRemoteSession {

        /// <summary>
        /// Trace Dictionary for this session
        /// </summary>
        public TraceDictionary Traces { get; set; }


        /// <summary>
        /// Create a remote session without authentication. This call
        /// is typically used when beginning an interaction that will
        /// lead to the authentication credential being established.
        /// </summary>
        /// <param name="host">The host implementation</param>
        /// <param name="accountAddress">User account</param>
        public DebugLocalSession(JPCProvider host, string accountAddress)
                : base(host, accountAddress) {
            }



        /// <summary>
        /// Post a request and retrieve the response.
        /// </summary>
        /// <param name="data">StreamBuffer object containing JSON encoded request.</param>
        /// <returns>StreamBuffer object containing JSON encoded response.</returns>
        public override Stream Post(MemoryStream data, JsonObject requestObject) {

            var DataText = data.GetUTF8();
            var JSONReader = new JsonReader(DataText);

            var ResultObject = Host.Dispatch(this, JSONReader);

            return null;
            }

        /// <summary>
        /// Post a request and retrieve the response.
        /// </summary>
        /// <param name="tag">Command</param>
        /// <param name="request">JSON encoded request.</param>
        /// <returns>JSON encoded response.</returns>
        public override string Post(string tag, JsonObject request) {

            var Buffer = new MemoryStream();
            var JSONWriter = new JSONWriter(Buffer);

            // Wrap the request object with the transaction name.
            JSONWriter.WriteObjectStart();
            JSONWriter.WriteToken(tag, 0);
            request.Serialize(JSONWriter, false);
            JSONWriter.WriteObjectEnd();

            // Now prepare a reader so that the data can be unpacked
            var DataText = Buffer.GetUTF8();
            var JSONReader = new JsonReader(DataText);

            // Send the request
            var ResultObject = Host.Dispatch(this, JSONReader);

            if (Traces != null) {
                Traces.Request(request);
                Traces.Response("200 OK", ResultObject);
                }

            // Return the response as a string for disassembly
            return ResultObject.ToString();
            }

        }


    }
