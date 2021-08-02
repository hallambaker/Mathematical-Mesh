using System.IO;

using Goedel.Utilities;


namespace Goedel.Protocol.Debug {



    /// <summary>
    /// Direct connection between client and service host with messages 
    /// encoded and decoded from JSON. For use in debugging issues that
    /// might be the result of JSON encoding issues and to collect samples
    /// for documentation.
    /// </summary>
    public class DebugLocalSession : JpcSessionSerialized {

        /// <summary>
        /// Trace Dictionary for this session
        /// </summary>
        public TraceDictionary Traces { get; set; }


        /// <summary>
        /// Create a remote session with debugging hooks.
        /// </summary>
        /// <param name="host">The host implementation</param>
        /// <param name="credential">The credential to be used.</param>
        public DebugLocalSession(JpcInterface host, ICredential credential)
                : base(host, credential) {
            }



        /// <summary>
        /// Post a request and retrieve the response.
        /// </summary>
        /// <param name="data">StreamBuffer object containing JSON encoded request.</param>
        /// <param name="requestObject">The abstract request object (for debugging).</param>
        /// <returns>StreamBuffer object containing JSON encoded response.</returns>
        public override Stream Post(MemoryStream data, JsonObject requestObject) {

            var DataText = data.GetUTF8();
            var JSONReader = new JsonReader(DataText);

            var ResultObject = Host.Dispatch(this, JSONReader);
            ResultObject.Future();

            "Need to reset the API here to be on the object.".TaskFunctionality(true);

            return null;
            }


        }


    }
